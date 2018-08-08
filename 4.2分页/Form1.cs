using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4._2分页
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetTimes();
            GetDivision();
        }

        #region 全局变量

        int Total;//信息总数
        int Page;//总页数
        int Present = 1;//当前页数

        #endregion

        #region 加载下拉框

        /// <summary>
        /// 获取年级下拉框
        /// </summary>
        /// <returns></returns>
        private void GetTimes()
        {
            List<Source> list = new List<Source>();
            string sql = "select Description,Code from T_Dic_Times";
            DataTable dt = SQLHelper.GetTable(sql, CommandType.Text, null);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Source(dr["Description"].ToString(), dr["Code"].ToString()));
            }
            CB_Times.DisplayMember = "ShowText";
            CB_Times.ValueMember = "HiddenValue";
            CB_Times.DataSource = list;
            CB_Times.SelectedValue = list[list.Count - 1].HiddenValue;
            CB_Times.SelectedText = list[list.Count - 1].ShowText;
        }
        /// <summary>
        /// 获取学部下拉框
        /// </summary>
        /// <returns></returns>
        private void GetDivision()
        {
            List<Source> list = new List<Source>();
            string sql = "select Description,Code from T_Dic_Division";
            DataTable dt = SQLHelper.GetTable(sql, CommandType.Text, null);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Source(dr["Description"].ToString(), dr["Code"].ToString()));
            }
            CB_Division.DisplayMember = "ShowText";
            CB_Division.ValueMember = "HiddenValue";
            CB_Division.DataSource = list;
        }
        /// <summary>
        /// 获取专业下拉框
        /// </summary>
        /// <returns></returns>
        private void GetProfessional(object sender, EventArgs e)
        {
            List<Source> list = new List<Source>();
            string sql = "select Description,Code from T_Dic_Professional where DivisionCode=" + CB_Division.SelectedValue;
            DataTable dt = SQLHelper.GetTable(sql, CommandType.Text, null);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Source(dr["Description"].ToString(), dr["Code"].ToString()));
            }
            CB_Professional.DisplayMember = "ShowText";
            CB_Professional.ValueMember = "HiddenValue";
            CB_Professional.DataSource = list;

        }
        /// <summary>
        /// 获取班级下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetClass(object sender, EventArgs e)
        {
            List<Source> list = new List<Source>();
            string sql = "select Description,Code from T_Dic_Class Where ProfessionalCode=" + CB_Professional.SelectedValue + " and DivisionCode=" + CB_Division.SelectedValue;
            DataTable dt = SQLHelper.GetTable(sql, CommandType.Text, null);
            list.Add(new Source("所有", "默认"));
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Source(dr["Description"].ToString(), dr["Code"].ToString()));
            }
            CB_Class.DisplayMember = "ShowText";
            CB_Class.ValueMember = "HiddenValue";
            CB_Class.DataSource = list;

        }

        #endregion

        #region 分页设计

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="index">指定当前的检索</param>
        /// <param name="num">指定显示条数</param>
        /// <returns></returns>
        private List<Student> GetStudentTable(int index, int num)
        {
            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@times",CB_Times.SelectedValue.ToString()),
                new SqlParameter("@professional",CB_Professional.SelectedValue.ToString()),
            new SqlParameter("@class",CB_Class.SelectedValue.ToString())
            };
            string sql = "select top " + num + " * from (select top " + index + " Nid, StudentName,GenderDescription,NationalDescription,StudentNu,IdNumber from View_T_StudentInfotoShow where TimeCode=@times and ProfessionCode=@professional";
            if (CB_Class.SelectedValue.ToString() != "默认")
            {
                sql += " and ClassNo=@class";
            }
            sql += " order by StudentNu) a order by StudentNu desc";
            List<Student> list = new List<Student>();
            DataTable dt = SQLHelper.GetTable(sql, CommandType.Text, pms);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Student(dr["StudentName"].ToString(), dr["GenderDescription"].ToString(), dr["NationalDescription"].ToString(), dr["StudentNu"].ToString(), dr["IdNumber"].ToString()));
            }
            return list;
        }
        //获取总页数
        private int GetTotalPagesNum()
        {
            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@times",CB_Times.SelectedValue.ToString()),
                new SqlParameter("@professional",CB_Professional.SelectedValue.ToString()),
            new SqlParameter("@class",CB_Class.SelectedValue.ToString())
            };
            string sqlnum = "select Count(*) from View_T_StudentInfotoShow where TimeCode=@times and ProfessionCode=@professional";
            if (CB_Class.SelectedValue.ToString() != "默认")
            {
                sqlnum += " and ClassNo=@class";
            }
            return (int)SQLHelper.ExecuteScalar(sqlnum, CommandType.Text, pms);
        }
        //分页处理
        private void LoadingTable()
        {
            int index = Present * 10;
            List<Student> list = GetStudentTable(index > Total ? Total : index, index > Total ? index - Total : 10);
            list.Reverse();
            this.dataGridView1.Rows.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[i].Cells[0].Value = i + 1 + 10 * (Present - 1);
                this.dataGridView1.Rows[i].Cells[1].Value = list[i].StudentName;
                this.dataGridView1.Rows[i].Cells[2].Value = list[i].Gender;
                this.dataGridView1.Rows[i].Cells[3].Value = list[i].National;
                this.dataGridView1.Rows[i].Cells[4].Value = list[i].StudentNu;
                this.dataGridView1.Rows[i].Cells[5].Value = list[i].Idnumber;
            }
        }

        #endregion

        #region 事件

        //查询按钮
        private void button1_Click(object sender, EventArgs e)
        {
            Total = GetTotalPagesNum();
            label6.Text = "共" + Total + "条数据";
            Page = Total % 10 == 0 ? (Total / 10) : (int)(Total * 1.0 / 10 + 1);
            Present = 1;
            label5.Text = "第 1/" + Page + " 页";
            LoadingTable();
        }
        //上一页按钮
        private void button2_Click(object sender, EventArgs e)
        {
            if (Present != 1 && this.dataGridView1.Rows.Count != 0)
            {
                Present--;
                label5.Text = "第 " + Present + "/" + Page + " 页";
                LoadingTable();
            }

        }
        //下一页按钮
        private void button3_Click(object sender, EventArgs e)
        {
            if (Present != Page && this.dataGridView1.Rows.Count != 0)
            {
                Present++;
                label5.Text = "第 " + Present + "/" + Page + " 页";
                LoadingTable();
            }
        }
        //首页
        private void button5_Click(object sender, EventArgs e)
        {
            Present = 1;
            label5.Text = "第 " + Present + "/" + Page + " 页";
            LoadingTable();
        }
        //尾页
        private void button4_Click(object sender, EventArgs e)
        {
            Present = Page;
            label5.Text = "第 " + Present + "/" + Page + " 页";
            LoadingTable();
        }

        #endregion


    }
    //下拉框选项类
    public class Source
    {
        public Source() { }
        public Source(string text, string value)
        {
            this.ShowText = text;
            this.HiddenValue = value;
        }
        public string ShowText { get; set; }
        public string HiddenValue { get; set; }
    }
    //信息类
    public class Student
    {
        public Student() { }
        public Student(string studentname, string gender, string national, string studentnu, string idnumber)
        {
            this.StudentName = studentname;
            this.Gender = gender;
            this.National = national;
            this.StudentNu = studentnu;
            this.Idnumber = idnumber;
        }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public string National { get; set; }
        public string StudentNu { get; set; }
        public string Idnumber { get; set; }
    }
}
