using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._1计算器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
                textBox1.Text = textBox1.Text + "0";
        }
        private void num1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
                textBox1.Text = textBox1.Text + "1";
        }
        private void num2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
                textBox1.Text = textBox1.Text + "2";
        }
        private void num3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
                textBox1.Text = textBox1.Text + "3";
        }
        private void num4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
                textBox1.Text = textBox1.Text + "4";
        }
        private void num5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
                textBox1.Text = textBox1.Text + "5";
        }
        private void num6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
                textBox1.Text = textBox1.Text + "6";
        }
        private void num7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
                textBox1.Text = textBox1.Text + "7";
        }

        private void num8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
                textBox1.Text = textBox1.Text + "8";
        }
        private void num9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
                textBox1.Text = textBox1.Text + "9";
        }
        int point = 0;              //设置全局变量
        private void num11_Click(object sender, EventArgs e)
        {
            if (point != 0 || textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text + ".";
                point++;
            }
        }
        //加减乘除运算
        string algorithm = "0";
        private void i1_Click(object sender, EventArgs e)       //加法
        {
            if (textBox1.Text != "" )
            {
                textBox2.Text = textBox1.Text;
                algorithm = "+";
                textBox1.Text = "";
                point = 0;
            }
        }
        private void i2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox2.Text = textBox1.Text;
                algorithm = "-";
                textBox1.Text = "";
                point = 0;
            };
        }
        private void i3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox2.Text = textBox1.Text;
                algorithm = "×";
                textBox1.Text = "";
                point = 0;
            }
        }
        private void i4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox2.Text = textBox1.Text;
                algorithm = "÷";
                textBox1.Text = "";
                point = 0;
            }
        }
        //清零
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        //等于
        private void end_Click(object sender, EventArgs e)
        {
            double change;
            switch (algorithm)
            {
                case "+":
                    change = Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text);
                    textBox2.Text = Convert.ToString(change);
                    textBox1.Text = "";
                    break;
                case "-":
                    change = Convert.ToDouble(textBox2.Text) - Convert.ToDouble(textBox1.Text);
                    textBox2.Text = Convert.ToString(change);
                    textBox1.Text = "";
                    break;
                case "×":
                    change = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text);
                    textBox2.Text = Convert.ToString(change);
                    textBox1.Text = "";
                    break;
                case "÷":
                    if (textBox1.Text == "0")
                        textBox2.Text = "除法运算除数不能为零";
                    else
                    {
                        change = Convert.ToDouble(textBox2.Text) / Convert.ToDouble(textBox1.Text);
                        textBox2.Text = Convert.ToString(change);
                        textBox1.Text = "";
                    }
                    break;
                default:
                    textBox2.Text = textBox1.Text;
                    textBox1.Text = "";
                    break;
            }
        }









    }
}
