using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02.MD5散列加密
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            comboBox1.SelectedIndex = 0;
        }
        //textBox3文本变化，发生事件
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                textBox1.Text = GetStringMD5(textBox3.Text);
        }
        //下拉框索引值改变，发生事件
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label1.Text = "字符串：";
                textBox3.Text = "";
                textBox1.Text = "";
            }
            else
            {
                label1.Text = "文件：";
                textBox3.Text = "";
                textBox1.Text = "";
            }
        }
        //对比按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(textBox2.Text))
            {
                MessageBox.Show("MD5值相同！", "提示", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("不相同！", "提示", MessageBoxButtons.OK);
            }
        }
        //设置拖动文件到窗口时，光标显示
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void textBox3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        //读取拖动到窗口的文件的路径
        private void textBox3_DragDrop(object sender, DragEventArgs e)
        {
            string[] path = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (path.Count() != 1)
            {
                MessageBox.Show("不支持文件夹");
            }
            else
            {
                textBox3.Text = path[0];
                textBox1.Text = GetFileMD5(path[0]);
            }
        }


        //获取字符串MD5值
        private static string GetStringMD5(string msg)
        {
            StringBuilder SBMD5 = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                byte[] md5Buffer = md5.ComputeHash(Encoding.UTF8.GetBytes(msg));
                for (int i = 0; i < md5Buffer.Length; i++)
                {
                    SBMD5.Append(md5Buffer[i].ToString("x2"));
                }
            }
            return SBMD5.ToString();
        }
        //根据文件路径，获取文件MD5值
        private static string GetFileMD5(string path)
        {
            StringBuilder SBMD5 = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                using (FileStream fsRead = File.OpenRead(path))
                {
                    byte[] md5buffer = md5.ComputeHash(fsRead);
                    for (int i = 0; i < md5buffer.Length; i++)
                    {
                        SBMD5.Append(md5buffer[i].ToString("x2"));
                    }
                }
            }
            return SBMD5.ToString();
        }



    }
}
