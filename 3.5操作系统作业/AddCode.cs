using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3._5操作系统作业.cs;

namespace _3._5操作系统作业
{
    public partial class AddCode : Form
    {
        //窗口打开初始化
        public AddCode()
        {
            InitializeComponent();
            ProcessName.BringToFront();
            label2.Visible = label3.Visible = Priority.Visible = !CPU.form.Dispatch_PriorityForTimeOfExecute;

            List<Source> source = new List<Source>();
            source.Add(new Source() { ShowText = "实例 1", HiddenValue = "a" });
            source.Add(new Source() { ShowText = "实例 2", HiddenValue = "b" });
            source.Add(new Source() { ShowText = "实例 3", HiddenValue = "c" });
            source.Add(new Source() { ShowText = "实例 4", HiddenValue = "d" });
            //设置下拉框的数据源
            comboBox1.DataSource = source;
            //设置显示框显示内容对应数据源的属性
            comboBox1.DisplayMember = "ShowText";
            //设置索引
            comboBox1.ValueMember = "HiddenValue";
            //默认索引
            comboBox1.SelectedValue = "a";
        }

        //保存
        private void button2_Click(object sender, EventArgs e)
        {
            //检测是否为空
            if (ProcessName.Text != "" && Priority.Text != "" && AllCode.Text != "")
            {
                string processname = ProcessName.Text;
                string allcode = AllCode.Text;
                bool b = Store.CheckEqual(processname);
                if (b)
                {
                    //申请一个程序内存块，并存储信息
                    int index = Store.ApplyProcess(processname, allcode);
                    if (index != -1)
                    {
                        //最短处理机执行期优先调度算法
                        if (CPU.form.Dispatch_PriorityForTimeOfExecute)
                            Queue.Dispatch_PriorityForTimeOfExecute(index);
                        else
                            Store.ProcedureMemory[index].Priority = Convert.ToInt32(Priority.Text);
                        //放入就绪队列
                        Queue.PutInReadyQueue(index);
                        CPU.form.StoreProgressBarOfPCB();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBoxButtons RemindButton = MessageBoxButtons.OK;
                DialogResult dr1 = MessageBox.Show("请将程序信息填写完整", "确定", RemindButton);
            }
        }
        //退出
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //下拉框
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(comboBox1.SelectedValue) == "a")
            {
                ProcessName.Text = "exa_1";
                Priority.Text = "1";
                AllCode.Text = "int i=1;\nwait(A,2);\nint j=5;\nint end=6;\nj++;\ni--;\nend=++;\nreturn end;";
            }
            else if (Convert.ToString(comboBox1.SelectedValue) == "b")
            {
                ProcessName.Text = "exa_2";
                Priority.Text = "3";
                AllCode.Text = "int i=1;\nwait(C,2);\nint j=5;\nint end=6;\nj++;\ni--;\nend++;\nreturn end;";
            }
            else if (Convert.ToString(comboBox1.SelectedValue) == "c")
            {
                ProcessName.Text = "exa_3";
                Priority.Text = "2";
                AllCode.Text = "int i=1;\nwait(B,2);\nint j=5;\nint end=6;\nj++;\ni--;\nend++;\nreturn end;";
            }
            else if (Convert.ToString(comboBox1.SelectedValue) == "d")
            {
                ProcessName.Text = "exa_4";
                Priority.Text = "7";
                AllCode.Text = "int i=1;\nwait(A,2);\nint j=5;\nint end=6;\nj++;\ni--;\nend++;\nreturn end;";
            }

        }
        //代码语法提示窗口
        private void button3_Click(object sender, EventArgs e)
        {
            Prompt pro = new Prompt();
            pro.Show();


        }




    }
}
