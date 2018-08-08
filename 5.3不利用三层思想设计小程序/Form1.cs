using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0_3.不利用三层思想设计小程序
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "查询")
            {
                button1.Text = "年龄+1";
                string sql = "select * from T_Student where Nid=" + textBox1.Text.Trim();
                DataTable dt = SQLHelper.GetTable(sql, CommandType.Text, null);
                if (dt.Rows.Count != 0)
                    label2.Text = dt.Rows[0]["StudentName"].ToString() + "   " + dt.Rows[0]["StudentNu"].ToString() + "    " + dt.Rows[0]["Age"].ToString();
            }
            else
            {
                string sql = "update T_Student set Age=Age+1 where Nid=" + textBox1.Text.Trim();
                int num = SQLHelper.ExecuteNonQuery(sql, CommandType.Text, null);
                button1.Text = "查询";
                if (num == 1)
                {
                    MessageBox.Show("成功！");
                }
            }

        }





    }
}
