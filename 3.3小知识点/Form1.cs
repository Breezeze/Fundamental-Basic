using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._3小知识点
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int V;

        public void output(string log)
        {
            richTextBox1.AppendText(DateTime.Now.ToString("HH:mm:ss   ") + log + "\r\n");   //HH;mm;ss为指定时间的输出格式,hms均为开头字母
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            V = Convert.ToInt32(textBox1.Text);
            progressBar1.Value = 0;//即时进展
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            timer1.Enabled = true;
            output("进度条开始运行");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                button2.Text = "继续";
                timer1.Enabled = false;
                output("进度条已暂停");
            }
            else
            {
                button2.Text = "暂停";
                timer1.Enabled = true;
                output("进度条正在运行");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            progressBar1.Value = 0;
            richTextBox1.Text = "";
            output("进度条已停止");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum - V)
            {
                progressBar1.Value += V;
                label2.Text = progressBar1.Value + "/100";
                if (progressBar1.Value % 25 < V)
                {
                    output("已完成" + ((int)progressBar1.Value / 25) * 25 + "%");
                }
            }
            else
            {
                progressBar1.Value = 0;
                label2.Text = "0/100";
                output("进度条运行完成！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //消息框中需要显示哪些按钮，此处显示“确定”和“取消”
            MessageBoxButtons KeepButton = MessageBoxButtons.OKCancel;
            //"确定要退出吗？"是对话框的显示信息，"退出系统"是对话框的标题
            //默认情况下，如MessageBox.Show("确定退出？")只显示一个“确定”按钮。
            DialogResult dr = MessageBox.Show("确定退出？", "退出系统", KeepButton);
            if (dr == DialogResult.OK)//如果点击“确定”按钮
            {
                this.Close();
            }
        }
    }
}
