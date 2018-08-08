using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03.模拟三层构架思想设计小程序.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && button1.Text == "查询")
            {
                int id = Convert.ToInt32(textBox1.Text);
                BLL.T_Student T = BLL.BLL_T_Student.GetOne(id);
                if (T != null)
                {
                    label2.Text = "id=" + T.Nid;
                    label2.Text += "\n姓名=" + T.StudentName;
                    label2.Text += "\n学号=" + T.StudentNu;
                    label2.Text += "\n性别=" + T.Gender;
                    label2.Text += "\n年龄=" + T.Age;
                    button1.Text = "年龄加一";
                }
            }
            else if (textBox1.Text != "" && button1.Text == "年龄加一")
            {
                int id = Convert.ToInt32(textBox1.Text);
                bool succeed = BLL.BLL_T_Student.UpdateAgeAddOne(id);
                if (succeed)
                {
                    MessageBox.Show("成功！");
                }
                button1.Text = "查询";
            }
        }
    }
}
