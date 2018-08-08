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
    public partial class Login : Form
    {
        public Login()
        {
            //使用三层架构思想，创建程序结构
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string account = textBox1.Text;
            string password = textBox2.Text;
            if (account != "" && password != "")
            {
                string msg = BLL.BLL_T_UserInfo.Login(account, password);
                int index = msg.IndexOf("登陆成功");
                if (index == 0)
                {
                    this.Hide();
                    MainScreen ms = new MainScreen(Convert.ToInt32(msg.Substring(4)));
                    ms.ShowDialog();
                    //因为ms.ShowDialog()规定，ms窗口未关闭，不进行之后操作
                    System.Environment.Exit(0);
                }
                else
                    MessageBox.Show(msg);
            }
            else
                MessageBox.Show("请输入完整！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Register(0).ShowDialog();
        }
    }
}
