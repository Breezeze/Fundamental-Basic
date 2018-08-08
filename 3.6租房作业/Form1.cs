using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._6租房作业
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 全局变量

        List<YearLease> YLlist = new List<YearLease>();
        List<DayLease> DLlist = new List<DayLease>();
        YearLease BufferYearLease = new YearLease();
        DayLease BufferDayLease = new DayLease();
        TextBox SelectedTextBox;

        #endregion

        #region tabpage1事件


        #region 用户输入基本信息

        #region 实时更新数据

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BufferYearLease.LesseeName = textBox1.Text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                BufferYearLease.MonthRent = Convert.ToInt32(textBox2.Text);
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                textBox7.Text = BufferYearLease.TotalRent.ToString();
                textBox6.Text = BufferYearLease.Debt.ToString();
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
                BufferYearLease.HaveToPayRent = Convert.ToInt32(textBox5.Text);
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                textBox7.Text = BufferYearLease.TotalRent.ToString();
                textBox6.Text = BufferYearLease.Debt.ToString();
            }
        }

        #endregion

        #region 日期选择

        //日历控件日期选择
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Visible = false;
            if (SelectedTextBox == textBox3)
            {
                BufferYearLease.StartTime = monthCalendar1.SelectionStart;
                SelectedTextBox.Text = BufferYearLease.StartTime.ToString("d");
            }
            else
            {
                BufferYearLease.EndTime = monthCalendar1.SelectionStart;
                SelectedTextBox.Text = BufferYearLease.EndTime.ToString("d");
            }
        }
        //选择日期
        private void textBox3_Click(object sender, EventArgs e)
        {
            SelectedTextBox = textBox3;
            monthCalendar1.Visible = true;
        }
        //选择日期
        private void textBox4_Click(object sender, EventArgs e)
        {
            SelectedTextBox = textBox4;
            monthCalendar1.Visible = true;
        }
        //日期选择框输入判断
        private void SelectedDate1_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                if (BufferYearLease.EndTime.CompareTo(BufferYearLease.StartTime) < 0)
                {
                    MessageBox.Show("终止时间应晚于起始时间！", "警告");
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
            }
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                textBox7.Text = BufferYearLease.TotalRent.ToString();
                textBox6.Text = BufferYearLease.Debt.ToString();
            }
        }

        #endregion

        #endregion

        //录入键
        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    YLlist.Add(BufferYearLease);
                    //更新下拉框
                    comboBox1.Items.Add(BufferYearLease.LesseeName);
                    button2.PerformClick();
                    MessageBox.Show("录入完成！");
                }
                else
                    MessageBox.Show("请输入完整！", "提示");
            else
                MessageBox.Show("请先预览租约信息！");
        }
        //清空键
        private void button2_Click(object sender, EventArgs e)
        {
            BufferYearLease = new YearLease();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            richTextBox1.Text = "";
        }
        //预览租赁信息键
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                richTextBox1.Text = BufferYearLease.GetLeases();
            }
        }
        //查看租赁信息键
        private void button7_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            if (index != -1)
                richTextBox1.Text = YLlist[index].GetLeases();
        }

        #endregion

        #region tabpage2事件

        #region 日期选择

        private void textBox13_Click(object sender, EventArgs e)
        {
            SelectedTextBox = textBox13;
            monthCalendar2.Visible = true;
        }
        private void textBox8_Click(object sender, EventArgs e)
        {
            SelectedTextBox = textBox8;
            monthCalendar2.Visible = true;
        }
        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar2.Visible = false;
            if (SelectedTextBox == textBox13)
            {
                BufferDayLease.StartTime = monthCalendar2.SelectionStart;
                SelectedTextBox.Text = BufferDayLease.StartTime.ToString("d");
            }
            else
            {
                BufferDayLease.EndTime = monthCalendar2.SelectionStart;
                SelectedTextBox.Text = BufferDayLease.EndTime.ToString("d");
            }
        }
        private void SelectedDate2_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text != "" && textBox13.Text != "")
            {
                if (BufferDayLease.EndTime.CompareTo(BufferDayLease.StartTime) < 0)
                {
                    MessageBox.Show("终止时间应晚于起始时间！", "警告");
                    textBox8.Text = "";
                    textBox13.Text = "";
                }
            }
            if (textBox8.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "")
                textBox9.Text = BufferDayLease.TotalRent.ToString();
        }

        #endregion

        #region 实时更新数据

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text != "")
                BufferDayLease.LesseeName = textBox11.Text;
            if (textBox8.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "")
                textBox9.Text = BufferDayLease.TotalRent.ToString();
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text != "")
                BufferDayLease.DayRent = Convert.ToInt32(textBox12.Text);
            if (textBox8.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "")
                textBox9.Text = BufferDayLease.TotalRent.ToString();
        }

        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = BufferDayLease.GetLeases();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            BufferDayLease = new DayLease();
            textBox8.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox9.Text = "";
            richTextBox2.Text = "";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text != "")
                if (textBox8.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "")
                {
                    DLlist.Add(BufferDayLease);
                    //更新下拉框
                    comboBox2.Items.Add(BufferDayLease.LesseeName);
                    button5.PerformClick();
                    MessageBox.Show("录入完成！");
                }
                else
                    MessageBox.Show("请输入完整！", "提示");
            else
                MessageBox.Show("请先预览租约信息！");

        }
        private void button8_Click(object sender, EventArgs e)
        {
            int index = comboBox2.SelectedIndex;
            if (index != -1)
                richTextBox2.Text = DLlist[index].GetLeases();
        }

        #endregion

        //限制输入数字
        private void LimitInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

















    }
}
