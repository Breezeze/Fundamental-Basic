using LMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS.UI
{
    public partial class MainScreen : Form
    {
        private T_UserInfo User;
        private List<T_UserInfo> ListUser = new List<T_UserInfo>();
        private List<T_Books> ListBook = new List<T_Books>();

        public MainScreen()
        {
            throw new Exception("非法进入程序！");
        }
        public MainScreen(int id)
        {
            InitializeComponent();
            User = new T_UserInfo() { Nid = id };
            UploadPage4();
            UploadPage1();
            UploadPage2();
        }
        //限制输入数字
        private void LimitInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        #region 个人信息管理页

        /// <summary>
        /// 加载界面
        /// </summary>
        private void UploadPage4()
        {
            try
            {
                User = BLL.BLL_T_UserInfo.GetSelf(this.User.Nid);
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载个人信息时出错：\n" + ex.Message);
                System.Environment.Exit(0);
            }
            textBox5.Text = User.Account;
            textBox3.Text = User.UserName;
            textBox2.Text = User.Gender;
            textBox4.Text = User.Phone;
            textBox26.Text = User.RegisterTime.ToString("F");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            string phone = textBox4.Text;
            int num = BLL.BLL_T_UserInfo.ModifyBasic(this.User.Nid, name, phone);
            if (num == 1)
            {
                UploadPage4();
                MessageBox.Show("修改信息成功！");
            }
            else if (num == -2)
                MessageBox.Show("数据库连接失败！");
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox10.Text)
            {
                string oldpwd = textBox16.Text;
                string newpwd = textBox1.Text;
                if (oldpwd == User.PassWord)
                {
                    int num = BLL.BLL_T_UserInfo.ModifyPwd(User.Nid, newpwd);
                    if (num == 1)
                    {
                        textBox1.Text = "";
                        textBox10.Text = "";
                        textBox16.Text = "";
                        User.PassWord = newpwd;
                        MessageBox.Show("更改密码成功！");
                    }
                    else
                        MessageBox.Show("更新数据库时出现未知错误！");
                }
                else
                    MessageBox.Show("旧密码不正确，请重试！");
            }
            else
                MessageBox.Show("两次输入的新密码不相同，请重试！");
        }

        #endregion

        #region 用户信息管理页

        private void UploadPage2()
        {
            if (User.UserLevel == 2)
                this.tabControl1.TabPages.Remove(this.tabPage2);
            else
                try
                {
                    if (User.UserLevel == 1)
                    {
                        label20.Visible = false;
                        comboBox4.Visible = false;
                    }
                    ListUser = BLL.BLL_T_UserInfo.GetUserInfo(User.UserLevel);
                    this.comboBox2.Items.Clear();
                    this.comboBox2.Items.Insert(0, "");
                    this.dataGridView2.Rows.Clear();
                    for (int i = 0; i < ListUser.Count; i++)
                    {
                        this.dataGridView2.Rows.Add();
                        this.dataGridView2.Rows[i].Cells[0].Value = ListUser[i].Account;
                        this.dataGridView2.Rows[i].Cells[1].Value = ListUser[i].UserName;
                        this.dataGridView2.Rows[i].Cells[2].Value = ListUser[i].GetLevelName();
                        this.dataGridView2.Rows[i].Cells[3].Value = ListUser[i].Gender;
                        this.dataGridView2.Rows[i].Cells[4].Value = ListUser[i].Phone;
                        this.dataGridView2.Rows[i].Cells[5].Value = ((DateTime)ListUser[i].RegisterTime).ToString("F");

                        this.comboBox2.Items.Insert(0, ListUser[i].UserName);
                    }
                    comboBox2.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载用户信息时出错:\n" + ex.Message);
                    System.Environment.Exit(0);
                }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string selectedname = ((Control)sender).Name == "button3" ? comboBox2.Text : textBox6.Text;
            if (selectedname != "")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Insert(0, "男");
                comboBox3.Items.Insert(1, "女");
                comboBox4.Items.Clear();
                comboBox4.Items.Insert(0, "管理员");
                comboBox4.Items.Insert(1, "普通用户");
                for (int i = 0; i < ListUser.Count; i++)
                    if (selectedname == ListUser[i].UserName)
                    {
                        textBox7.Text = ListUser[i].Account;
                        textBox8.Text = ListUser[i].UserName;
                        textBox11.Text = ListUser[i].Phone;
                        textBox13.Text = ListUser[i].RegisterTime.ToString("yyyy年mm月dd日  HH:mm:ss");
                        comboBox3.SelectedIndex = ListUser[i].Gender == "男" ? 0 : 1;
                        comboBox4.SelectedIndex = ListUser[i].UserLevel - 1;
                        return;
                    }
            }
            else
            {
                MessageBox.Show("请输入或选择想要查找的用户的用户名！");
                return;
            }
            MessageBox.Show("未找到您查询的用户名");
        }
        private void button13_Click(object sender, EventArgs e)
        {
            int selectedid = 0;
            for (int i = 0; i < ListUser.Count; i++)
            {
                if (ListUser[i].Account == textBox7.Text)
                {
                    selectedid = ListUser[i].Nid;
                    break;
                }
            }
            int num = BLL.BLL_T_UserInfo.ModifyBasic(selectedid, textBox8.Text, comboBox3.Text, comboBox4.SelectedIndex + 1, textBox11.Text);
            if (num == 1)
            {
                UploadPage2();
                MessageBox.Show("修改信息成功！");
            }
            else if (num == -2)
                MessageBox.Show("数据库连接失败！");

        }

        #endregion

        #region 图书信息管理页

        private void UploadPage1()
        {
            //加载图书信息界面
            if (User.UserLevel == 2)
            {
                button4.Visible = false;
                button14.Visible = false;
                button15.Visible = false;
                textBox15.ReadOnly = false;
                textBox18.ReadOnly = false;
                textBox19.ReadOnly = false;
                textBox20.ReadOnly = false;
                textBox25.ReadOnly = false;
                comboBox7.Enabled = false;
            }
            comboBox5.SelectedIndex = 0;
            try
            {
                ListBook = BLL.BLL_T_Books.GetAllInfo();
                this.comboBox6.Items.Clear();
                this.comboBox1.Items.Clear();
                this.dataGridView1.Rows.Clear();
                for (int i = 0; i < ListBook.Count; i++)
                {
                    this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[i].Cells[0].Value = ListBook[i].Nid;
                    this.dataGridView1.Rows[i].Cells[1].Value = ListBook[i].BookName;
                    this.dataGridView1.Rows[i].Cells[2].Value = ListBook[i].GetBookClasses();
                    this.dataGridView1.Rows[i].Cells[3].Value = ListBook[i].Author;
                    this.dataGridView1.Rows[i].Cells[4].Value = ListBook[i].Press;
                    this.dataGridView1.Rows[i].Cells[5].Value = ListBook[i].Price;

                    this.comboBox6.Items.Insert(0, ListBook[i].BookName);
                    if (ListBook[i].IsLeased)
                    {
                        this.dataGridView1.Rows[i].Cells[6].Value = ListBook[i].Leasee;
                        this.dataGridView1.Rows[i].Cells[7].Value = ListBook[i].GetLeaseTime().ToString("F");
                        if (ListBook[i].Leasee == User.UserName)
                        {
                            this.comboBox1.Items.Insert(0, ListBook[i].BookName);
                        }
                    }
                    else
                    {
                        this.dataGridView1.Rows[i].Cells[6].Value = "无";
                        this.dataGridView1.Rows[i].Cells[7].Value = "无";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("图书信息列表加载失败：\n" + ex.Message);
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            new Register(1).Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            bool text = ((Control)sender).Name == "button5";
            if ((text ? textBox14.Text : comboBox6.Text) != "")
                try
                {
                    T_Books book;
                    if (text)
                    {
                        int id = Convert.ToInt32(textBox14.Text);
                        book = BLL.BLL_T_Books.GetOneInfo(null, id);
                    }
                    else
                    {
                        string name = comboBox6.Text;
                        book = BLL.BLL_T_Books.GetOneInfo(name, -1);
                    }
                    textBox19.Text = book.BookName;
                    textBox25.Text = book.Nid.ToString();
                    textBox20.Text = book.Author;
                    textBox18.Text = book.Press;
                    textBox15.Text = book.Price.ToString("F");
                    this.comboBox7.Items.Clear();
                    this.comboBox7.Items.Insert(0, "儿童图书");
                    this.comboBox7.Items.Insert(1, "编程教材");
                    this.comboBox7.Items.Insert(2, "修真小说");
                    this.comboBox7.Items.Insert(3, "社会百谈");
                    comboBox7.SelectedIndex = book.BookClasses - 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载图书信息时出错:\n" + ex.Message);
                }
            else
                MessageBox.Show("请输入或选择要查询图书的名称！");

        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            for (int i = 0; i < ListBook.Count; i++)
            {
                if (comboBox5.Text == ListBook[i].GetBookClasses() || comboBox5.SelectedIndex == 0)
                    this.comboBox6.Items.Insert(0, ListBook[i].BookName);
            }
            //if (classes == 0)
            //{
            //    for (int i = 0; i < ListBook.Count; i++)
            //    {
            //        this.comboBox6.Items.Insert(i, ListBook[i].BookName);
            //    }
            //}
            //else
            //{
            //    try
            //    {
            //        string[] namelist = BLL.BLL_T_Books.GetAllNameOfClasses(classes);
            //        for (int i = 0; i < namelist.Length; i++)
            //        {
            //            this.comboBox6.Items.Insert(i, namelist[i]);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("加载图书信息时出错:\n" + ex.Message);
            //    }
            //}
            if (comboBox6.Items.Count != 0)
                this.comboBox6.SelectedIndex = 0;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            string name = textBox19.Text;
            string nid = textBox25.Text;
            int classes = comboBox7.SelectedIndex;
            string author = textBox20.Text;
            string press = textBox18.Text;
            Decimal price = Convert.ToDecimal(textBox15.Text);
            int num = BLL.BLL_T_Books.Modify(new T_Books(textBox19.Text, comboBox7.SelectedIndex, textBox20.Text, textBox18.Text, Convert.ToDecimal(textBox15.Text)) { Nid = Convert.ToInt32(textBox25.Text) });
            if (num == 1)
            {
                UploadPage1();
                MessageBox.Show("修改信息成功！");
            }
            else if (num == -2)
                MessageBox.Show("数据库连接失败！");

        }

        #endregion

        #region 租借页

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox21.Text != "")
                try
                {
                    T_Books book = BLL.BLL_T_Books.GetOneInfo(textBox21.Text, -1);
                    textBox19.Text = book.BookName;
                    textBox24.Text = book.Nid.ToString();
                    textBox9.Text = book.GetBookClasses();
                    textBox22.Text = book.Author;
                    textBox17.Text = book.Press;
                    textBox12.Text = book.Price.ToString("F");
                    textBox23.Text = book.IsLeased ? "已被租借" : "可以租借";
                    button11.Visible = !book.IsLeased;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载图书信息时出错:\n" + ex.Message);
                }
            else
                MessageBox.Show("请输入或选择要查询图书的名称！");
        }
        private void button11_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox24.Text);
            int num = BLL.BLL_T_Books.Modify(new T_Books() { Nid = id, IsLeased = true, LeaseTime = DateTime.Now, Leasee = User.UserName });
            if (num == 1)
            {
                UploadPage1();
                MessageBox.Show("借书成功！");
            }
            else if (num == -2)
                MessageBox.Show("数据库连接失败！");

        }
        private void button10_Click(object sender, EventArgs e)
        {
            int id = -1;
            for (int i = 0; i < ListBook.Count; i++)
                if (ListBook[i].BookName == comboBox1.Text)
                {
                    id = ListBook[i].Nid;
                    break;
                }
            int num = BLL.BLL_T_Books.Modify(new T_Books() { Nid = id, IsLeased = false, LeaseTime = DateTime.Now, Leasee = User.UserName });
            if (num == 1)
            {
                UploadPage1();
                MessageBox.Show("还书成功！");
            }
            else if (num == -2)
                MessageBox.Show("数据库连接失败！");

        }

        #endregion

    }
}
