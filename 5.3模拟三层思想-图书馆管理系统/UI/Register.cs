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
    public partial class Register : Form
    {
        public Register()
        {
            throw new Exception("非法使用程序！");
        }
        public Register(int id)
        {
            InitializeComponent();
            Point p3 = new Point(this.textBox4.Location.X - this.label4.Location.X, this.textBox4.Location.Y - this.label4.Location.Y);
            if (id == 0)//用户注册
            {
                this.Text = "用户注册";
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
                this.comboBox2.Items.Insert(0, "--请选择--");
                this.comboBox2.Items.Insert(1, "男");
                this.comboBox2.Items.Insert(2, "女");
                comboBox2.SelectedIndex = 0;
            }
            else//添加图书
            {
                this.Text = "添加图书";
                label1.Text = "图书名称：";
                label2.Text = "作   者：";
                label3.Text = "出 版 社：";
                label4.Text = "价   格：";
                label5.Text = "类   别：";
                this.label3.Location = new Point(this.textBox3.Location.X - p3.X, this.textBox3.Location.Y - p3.Y);
                this.comboBox2.Items.Insert(0, "--请选择--");
                this.comboBox2.Items.Insert(1, "儿童图书");
                this.comboBox2.Items.Insert(2, "编程教材");
                this.comboBox2.Items.Insert(3, "修真小说");
                this.comboBox2.Items.Insert(4, "社会百谈");
                comboBox2.SelectedIndex = 0;
                textBox6.Visible = label6.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox2.SelectedIndex != 0)
            {
                if (this.Text == "用户注册")
                    if (textBox6.Text != "")
                        if (textBox2.Text == textBox3.Text)
                        {
                            string account = textBox1.Text;
                            string password = textBox2.Text;
                            string username = textBox6.Text;
                            string gender = comboBox2.Text;
                            string phone = textBox4.Text;
                            string msg = BLL.BLL_T_UserInfo.Register(account, password, username, gender, phone);
                            if (msg == "注册成功")
                            {
                                MessageBox.Show("注册成功！");
                                this.Close();
                            }
                            else
                                MessageBox.Show(msg);
                        }
                        else
                            MessageBox.Show("两次密码输入不相同，请重试！");
                    else
                        MessageBox.Show("请将信息填写完整！");
                else
                {
                    string bookname = textBox1.Text;
                    string author = textBox2.Text;
                    string press = textBox3.Text;
                    decimal price = Convert.ToDecimal(textBox4.Text);
                    int classes = comboBox2.SelectedIndex;
                    string msg = BLL.BLL_T_Books.AddBook(bookname, classes, author, press, price);
                    if (msg == "添加成功")
                    {
                        MessageBox.Show("添加成功！");
                        this.Close();
                    }
                    else
                        MessageBox.Show(msg);
                }
            }
            else
                MessageBox.Show("请将信息填写完整！");
        }
        //限制输入数字
        private void LimitInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

    }
}
