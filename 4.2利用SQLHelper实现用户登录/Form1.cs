using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01.利用SQLHelper实现用户登录
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string sql = "select COUNT(*) from T_UserInfo where LoginId=@Lid and LoginPwd=@Lpwd";
                SqlParameter[] pms = new SqlParameter[]{
                    new SqlParameter("@Lid",textBox1.Text),
                    new SqlParameter("Lpwd",textBox2.Text)
                };
                //因为SQL语句是查询COUNT，所以下面可以大胆的直接转化，而不用考虑null的问题
                int i = (int)FS.SQLHelper.ExecuteScalar(sql, CommandType.Text, pms);
                if (i > 0)
                {
                    MessageBox.Show("登录成功", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("登录失败，请检查账号或者密码是否正确！", "提示", MessageBoxButtons.OK);
                }
            }
        }




















    }
}
