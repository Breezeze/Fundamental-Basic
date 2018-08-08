using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3._5操作系统作业.cs;

namespace _3._5操作系统作业
{
    public partial class Form1 : Form
    {

        #region 全局变量

        int times = -2;//记录是否第一次运行
        AddCode ac;//实例添加页面
        int CPU_Time = 0;

        #endregion

        #region 调度算法

        /// <summary>
        /// 抢占调度
        /// </summary>
        public bool Dispatch_Grab = false;
        /// <summary>
        /// 最短处理机执行期优先调度
        /// </summary>
        public bool Dispatch_PriorityForTimeOfExecute = false;
        /// <summary>
        /// 时间片轮转调度
        /// </summary>
        public bool Dispatch_TimeSlicingCycle = true;
        public List<int[]> list = new List<int[]>();


        #endregion

        #region 初始化窗口

        public Form1()
        {
            InitializeComponent();
            CPU.form = this;
            //初始化进度条
            progressBar2.Value = 0;
            progressBar2.Minimum = 0;
            progressBar2.Maximum = Store.ProcedureMemory.Length;
            //初始化进度条
            progressBar3.Value = 0;
            progressBar3.Minimum = 0;
            progressBar3.Maximum = Store.VariableMemory.Length;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }



        #endregion

        #region 更新窗口反馈文本框

        #region 资源

        /// <summary>
        /// 修改资源状态Label
        /// </summary>
        /// <param name="resourceindex">资源索引号</param>
        /// <param name="mag">修改内容</param>
        public void ReviseStateText(int resourceindex, string mag)
        {
            switch (resourceindex)
            {
                case 0:
                    CPU.form.StateA.Text = mag;
                    break;
                case 1:
                    CPU.form.StateB.Text = mag;
                    break;
                case 2:
                    CPU.form.StateC.Text = mag;
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// 修改资源剩余时间Label
        /// </summary>
        /// <param name="resourceindex">资源索引号</param>
        /// <param name="mag">修改内容</param>
        public void ReviseTimeText(int resourceindex, string mag)
        {
            switch (resourceindex)
            {
                case 0:
                    CPU.form.EndTimeA.Text = mag;
                    break;
                case 1:
                    CPU.form.EndTimeB.Text = mag;
                    break;
                case 2:
                    CPU.form.EndTimeC.Text = mag;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 就绪阻塞队列

        /// <summary>
        /// 更新就绪队列显示框
        /// </summary>
        public void UpdataRTB1()
        {
            richTextBox1.Text = "";
            for (int i = 0; i < Store.ReadyQueue.Count; i++)
            {
                this.richTextBox1.AppendText(Store.ProcedureMemory[Store.ReadyQueue[i]].ProcessName + "\t\t" + Store.ProcedureMemory[Store.ReadyQueue[i]].Priority + "\n");
            }
        }
        /// <summary>
        /// 更新阻塞队列显示框
        /// </summary>
        public void UpdataRTB2()
        {
            richTextBox2.Text = "";
            for (int i = 0; i < Store.BlockQueue.Count; i++)
            {
                this.richTextBox2.AppendText(Store.ProcedureMemory[Store.BlockQueue[i]].ProcessName + "\n");
            }
        }

        #endregion

        #region 当前运行程序

        /// <summary>
        /// 更新三个CPU运行反馈框
        /// </summary>
        /// <param name="procedureindex">程序索引</param>
        /// <param name="mag">运行结果</param>
        public void UpadetaThreeText(string mag)
        {

            if (CPU.ProcedureIndex != -1)
            {
                this.textBox1.Text = Store.ProcedureMemory[CPU.ProcedureIndex].ProcessName;
                this.textBox2.Text = Store.ProcedureMemory[CPU.ProcedureIndex].OneCode[Store.ProcedureMemory[CPU.ProcedureIndex].CodeIndex - 1] + ";";
                this.textBox3.Text = mag;
            }
            else
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
            }
        }
        /// <summary>
        /// 更新当前程序代码显示框
        /// </summary>
        public void UpadetaCurrentProcessText()
        {
            if (CPU.ProcedureIndex != -1)
            {
                richTextBox4.Text = "";
                richTextBox5.Text = "";
                label20.Text = "初始优先级：" + Store.ProcedureMemory[CPU.ProcedureIndex].Priority;
                for (int i = 0; i < Store.ProcedureMemory[CPU.ProcedureIndex].OneCode.Count; i++)
                {
                    if (i < 8)
                        richTextBox4.AppendText(Store.ProcedureMemory[CPU.ProcedureIndex].OneCode[i] + ";\n");
                    else
                        richTextBox5.AppendText(Store.ProcedureMemory[CPU.ProcedureIndex].OneCode[i] + ";\n");
                }
            }
        }

        #endregion

        #region 内存进度条

        /// <summary>
        /// 更新PCB内存占用比进度条
        /// </summary>
        public void StoreProgressBarOfPCB()
        {
            int value = 0;
            for (int i = 0; i < Store.ProcedureMemory.Length; i++)
            {
                if (Store.ProcedureMemory[i].Occupy)
                    value++;
            }
            progressBar2.Value = value;
        }
        /// <summary>
        /// 更新变量内存占用比进度条
        /// </summary>
        public void StoreProgressBarOfVariable()
        {
            int value = 0;
            for (int i = 0; i < Store.VariableMemory.Length; i++)
            {
                if (Store.VariableMemory[i].Occupy)
                    value++;
            }
            progressBar3.Value = value;
        }

        #endregion

        #region 日志信息

        /// <summary>
        /// 添加日志信息
        /// </summary>
        /// <param name="log">内容</param>
        public void output(string log)
        {
            richTextBox6.AppendText(DateTime.Now.ToString("HH:mm:ss   ") + log + "\r\n");   //HH;mm;ss为指定时间的输出格式,hms均为开头字母
        }
        //日志框清除
        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox5.Text = "";
        }

        #endregion

        #endregion

        #region 窗口事件

        //退出按钮
        private void button3_Click(object sender, EventArgs e)
        {

            //消息框中需要显示哪些按钮，此处显示“确定”和“取消”
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            //"确定要退出吗？"是对话框的显示信息，"退出系统"是对话框的标题
            //默认情况下，如MessageBox.Show("确定要退出吗？")只显示一个“确定”按钮。
            DialogResult dr = MessageBox.Show("确定要退出吗?", "退出系统", messButton);
            if (dr == DialogResult.OK)//如果点击“确定”按钮
            {
                this.Close();
            }
        }
        //打开添加代码窗口
        private void button4_Click(object sender, EventArgs e)
        {
            ac = new AddCode();
            ac.Show();
        }
        //开始键
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "开始运行")
            {
                if (Store.ReadyQueue.Count != 0)
                {
                    button1.Text = "暂停";
                    times++;
                    if (times == -1)
                    {
                        //初始化
                        CPU.ProcedureIndex = -1;
                    }
                    //时间片轮转调度
                    if (CPU.form.Dispatch_TimeSlicingCycle)
                    {
                        //初始化进度条
                        progressBar1.Value = 0;
                        progressBar1.Minimum = 0;
                        //进度条长度即时间片长度 （一个单位长度的时间片可以运行6句代码）
                        progressBar1.Maximum = 300 * Convert.ToInt32(Speed.Text) + 41;
                        timer2.Enabled = true;
                    }
                    else
                        timer1.Enabled = true;
                }
                else
                    //提示弹框
                    MessageBox.Show("CPU：您还没有添加程序，臣妾做不到呀！", "知道了", MessageBoxButtons.OK);
            }
            else if (button1.Text == "暂停")
            {
                button1.Text = "继续";
                timer1.Enabled = false;
                timer2.Enabled = false;
            }
            else if (button1.Text == "继续")
            {
                if (button2.Text == " 停止 ")
                    button2.Text = "停止";
                else
                    button1.Text = "暂停";
                timer1.Enabled = true;
                timer2.Enabled = false;
            }
        }
        //停止键
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            progressBar1.Value = 0;
            button2.Text = " 停止 ";
            if (CPU.ProcedureIndex != -1)
            {
                Store.ProcedureMemory[CPU.ProcedureIndex] = new Procedure();
            }
            CPU.ProcedureIndex = -1;
            CPU.form.UpadetaThreeText("");
            CPU.form.richTextBox4.Text = "";
            CPU.form.richTextBox5.Text = "";
            output("您启用了停止键，CPU已终止当前程序的执行，并删除该程序！");
            button1.Text = "继续";
        }
        //CPU_timer事件
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region 调度算法

            //时间片轮转调度
            if (CPU.form.Dispatch_TimeSlicingCycle)
                return;
            //抢占调度
            if (CPU.form.Dispatch_Grab)
                Queue.Dispatch_Grab();

            #endregion

            CPU_timer();
        }
        //时间片_timer事件
        private void timer2_Tick(object sender, EventArgs e)
        {
            PGB_Control();
        }

        #endregion



        /// <summary>
        /// CPU的timer1事件
        /// </summary>
        private void CPU_timer()
        {
            CPU_Time++;
            textBox4.Text = "     " + CPU_Time + "    s";
            CPU.Run();
            CPU.ResourceTime();
            CPU.form.StoreProgressBarOfPCB();
            CPU.form.StoreProgressBarOfVariable();

        }
        /// <summary>
        /// 时间片的timer2事件
        /// </summary>
        private void PGB_Control()
        {
            if (progressBar1.Value == 0)
            {
                CPU.form.output("开始新的时间片");
                //list = Queue.AllotTime();
            }
            int time = 5;
            if (progressBar1.Value + time <= progressBar1.Maximum)
            {
                progressBar1.Value += time;
            }
            else
            {
                progressBar1.Value = 0;
                //progressBar1.Value += time;
            }
            if (progressBar1.Value % 50 == 0)
            {
                CPU.ResourceTime();

                Queue.Dispatch_TimeSlicingCycle();

                CPU.form.UpadetaCurrentProcessText();
                CPU.form.UpdataRTB1();
                CPU.form.UpdataRTB2();
                CPU.form.StoreProgressBarOfPCB();
                CPU.form.StoreProgressBarOfVariable();
            }



        }





    }
}
