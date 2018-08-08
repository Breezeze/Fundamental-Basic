using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._5操作系统作业.cs
{
    public static class CPU
    {
        /// <summary>
        /// 当前程序在内存中的索引
        /// </summary>
        public static int ProcedureIndex { get; set; }
        /// <summary>
        /// 运行结果
        /// </summary>
        public static string Result { get; set; }
        /// <summary>
        /// 当前使用窗口
        /// </summary>
        public static Form1 form { get; set; }

        /// <summary>
        /// CPU运行
        /// </summary>
        public static void Run()
        {
            //检测CPU中是否存储着程序
            if (ProcedureIndex == -1)//不存在程序正在执行
            {
                if (Store.ReadyQueue.Count != 0)
                {
                    Queue.BreakOutReadyQueue();
                    CPU.form.output("开始运行下一个程序");
                    CPU.form.UpadetaCurrentProcessText();
                    Run(); 
                }
                else
                {
                    if (Store.BlockQueue.Count == 0)
                    {
                        CPU.form.timer1.Enabled = false;
                        CPU.form.timer2.Enabled = false;
                        CPU.form.UpadetaThreeText("");
                        //提示弹框
                        System.Windows.Forms.MessageBox.Show("所有程序运行完毕", "提示", System.Windows.Forms.MessageBoxButtons.OK);
                    }
                    else
                    {
                        //有程序在阻塞状态
                        CPU.form.textBox3.Text = "CPU休息中";
                    }
                }
            }
            else//继续执行程序下一步代码
            {
                //检测是否完成程序的所有代码
                if (Store.ProcedureMemory[ProcedureIndex].CodeIndex != Store.ProcedureMemory[ProcedureIndex].OneCode.Count)
                {
                    //执行代码
                    AnalysisCode.AnalysisOneCode(Store.ProcedureMemory[CPU.ProcedureIndex].OneCode[Store.ProcedureMemory[ProcedureIndex].CodeIndex], ProcedureIndex);
                    //实时反馈
                    CPU.form.UpadetaThreeText(CPU.Result);
                }
                else//程序运行完成
                {
                    CPU.form.output("程序“" + Store.ProcedureMemory[CPU.ProcedureIndex].ProcessName + "”运行完毕！");
                    Store.ReleaseMemory(CPU.ProcedureIndex);
                    ProcedureIndex = -1;
                    CPU.form.UpadetaThreeText("");
                    if (!CPU.form.Dispatch_TimeSlicingCycle)
                        Run();
                    else
                        Queue.Dispatch_TimeSlicingCycle();
                }
            }
        }

        /// <summary>
        /// 时间事件，资源
        /// </summary>
        public static void ResourceTime()
        {
            for (int i = 0; i < Store.ResourceMemory.Length; i++)
            {
                if (Store.ResourceMemory[i].Occupy && Store.ResourceMemory[i].EndTime != -1)
                {
                    Store.ResourceMemory[i].EndTime--;
                    CPU.form.ReviseTimeText(i, "剩余占用时间：" + Store.ResourceMemory[i].EndTime + "s");
                    if (Store.ResourceMemory[i].EndTime == 0)
                        Store.ReleaseResource(Store.ResourceMemory[i].Name);
                }
            }
        }

    }

    /// <summary>
    /// 内存存储器
    /// </summary>
    public static class Store
    {
        static Store()
        {
            for (int i = 0; i < VariableMemory.Length; i++)
                VariableMemory[i] = new Variable();
            for (int i = 0; i < ResourceMemory.Length; i++)
                ResourceMemory[i] = new Resource();
            for (int i = 0; i < ProcedureMemory.Length; i++)
                ProcedureMemory[i] = new Procedure();
            ResourceMemory[0].Name = "A";
            ResourceMemory[1].Name = "B";
            ResourceMemory[2].Name = "C";
        }

        /// <summary>
        /// 变量存储器
        /// </summary>
        public static Variable[] VariableMemory = new Variable[20];
        /// <summary>
        /// 资源控制器
        /// </summary>
        public static Resource[] ResourceMemory = new Resource[3];
        /// <summary>
        /// 程序信息存储器（PCB）
        /// </summary>
        public static Procedure[] ProcedureMemory = new Procedure[10];
        /// <summary>
        /// 就绪队列
        /// </summary>
        public static List<int> ReadyQueue = new List<int>();
        /// <summary>
        /// 阻塞队列
        /// </summary>
        public static List<int> BlockQueue = new List<int>();

        #region 检测重名

        /// <summary>
        /// 检测重名
        /// </summary>
        /// <param name="ProcessIndex">所属程序的索引</param>
        /// <param name="VariableName">变量名</param>
        static public void CheckEqual(int ProcessIndex, string VariableName)
        {
            for (int i = 0; i < Store.VariableMemory.Length; i++)
                if (Store.VariableMemory[i].ProcessIndex == ProcessIndex && Store.VariableMemory[i].Name == VariableName)
                    throw new Exception("出现错误，错误原因：企图声明已存在的变量名");
        }
        /// <summary>
        /// 检测重名
        /// </summary>
        /// <param name="ProcessName">程序名</param>
        static public bool CheckEqual(string ProcessName)
        {
            for (int i = 0; i < Store.ProcedureMemory.Length; i++)
                if (Store.ProcedureMemory[i].ProcessName == ProcessName)
                {
                    MessageBox.Show("企图建立的程序重名！", "确定", MessageBoxButtons.OK);
                    return false;
                }
            return true;
        }

        #endregion

        #region 申请变量内存

        /// <summary>
        /// 申请变量内存块
        /// </summary>
        /// <param name="ProcessIndex">所属程序的索引</param>
        /// <param name="VariableName">变量名</param>
        /// <param name="Type">变量类型</param>
        /// <returns>返回伸到的内存块的索引</returns>
        static public int ApplyVariable(int ProcessIndex, string VariableName, string Type)
        {
            CheckEqual(ProcessIndex, VariableName);
            int i;
            for (i = 0; i < Store.VariableMemory.Length; i++)
                if (Store.VariableMemory[i].Occupy == false)
                    break;
                else if (i + 1 == Store.VariableMemory.Length)
                    return -1;
            //记录变量类型
            Store.VariableMemory[i].Type = Type;
            //记录变量名
            Store.VariableMemory[i].Name = VariableName;
            //更改该存储空间的状态为占用
            Store.VariableMemory[i].Occupy = true;
            //记录所属进程名
            Store.VariableMemory[i].ProcessIndex = ProcessIndex;
            return i;
        }

        #endregion

        #region 申请程序内存

        /// <summary>
        /// 申请程序内存块
        /// </summary>
        /// <returns>返回申请到的内存块的索引</returns>
        static public int ApplyProcess(string procedurename, string allcode)
        {
            int index;
            for (index = 0; index < Store.ProcedureMemory.Length; index++)
                if (Store.ProcedureMemory[index].Occupy == false)
                    break;
                else if (index + 1 == Store.ProcedureMemory.Length)
                {
                    System.Windows.Forms.MessageBox.Show("没有内存了", "朕知道了", System.Windows.Forms.MessageBoxButtons.OK);
                    return -1;
                }

            Store.ProcedureMemory[index] = new Procedure(procedurename, allcode);
            return index;
        }

        #endregion

        #region 申请资源

        /// <summary>
        /// 申请资源
        /// </summary>
        /// <param name="releasename">资源名字</param>
        /// <param name="occupytime">占用时间</param>
        public static bool ApplyResource(string releasename, int occupytime)
        {
            for (int i = 0; i < Store.ResourceMemory.Length; i++)
            {
                if (Store.ResourceMemory[i].Name == releasename)
                {
                    //未被占用
                    if (!Store.ResourceMemory[i].Occupy)
                    {
                        Store.ResourceMemory[i].Occupy = true;
                        Store.ResourceMemory[i].ProcessIndex = CPU.ProcedureIndex;
                        CPU.form.ReviseStateText(i, "占用");
                        if (occupytime != -1)//规定时间占用
                        {
                            Store.ResourceMemory[i].EndTime = occupytime + 1;
                            Store.ResourceMemory[i].NeedTime = occupytime;
                        }
                        else//持续占用
                        {
                            Store.ResourceMemory[i].EndTime = -1;
                            Store.ResourceMemory[i].NeedTime = -1;
                        }
                        return true;
                    }
                    //被占用，但是是本程序占用
                    else if (Store.ResourceMemory[i].ProcessIndex == CPU.ProcedureIndex)
                    {
                        if (occupytime != -1)//规定时间占用
                        {
                            Store.ResourceMemory[i].EndTime += occupytime + 1;
                            Store.ResourceMemory[i].NeedTime += occupytime;
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region 程序运行结束，释放所属程序所有内存

        /// <summary>
        /// 程序运行结束，内存释放
        /// </summary>
        /// <param name="index">程序索引</param>
        public static void ReleaseMemory(int index)
        {
            CPU.form.richTextBox3.AppendText(Store.ProcedureMemory[CPU.ProcedureIndex].ProcessName + "\n");
            //释放变量存储器中的内存
            for (int i = 0; i < Store.VariableMemory.Length; i++)
            {
                if (Store.VariableMemory[i].ProcessIndex == index)
                {
                    Store.VariableMemory[i] = new Variable();
                }
            }
            //阻塞程序可就绪检测
            Queue.CheckBlockOfVariable();
            //释放PCB
            Store.ProcedureMemory[index] = new Procedure();
        }

        #endregion

        #region 资源释放

        /// <summary>
        /// 资源释放
        /// </summary>
        /// <param name="vari"></param>
        public static void ReleaseResource(string resourcename)
        {
            for (int index = 0; index < Store.ResourceMemory.Length; index++)
            {
                if (resourcename == Store.ResourceMemory[index].Name)
                {
                    Store.ResourceMemory[index].Occupy = false;
                    Store.ResourceMemory[index].ProcessIndex = -1;
                    Store.ResourceMemory[index].NeedTime = 0;
                    Store.ResourceMemory[index].EndTime = 0;
                    CPU.form.ReviseStateText(index, "空闲");
                    CPU.form.ReviseTimeText(index, "");
                    //阻塞程序可就绪检测
                    Queue.CheckBlockOfResource(Store.ResourceMemory[index].Name);
                }
            }
        }


        #endregion
    }

    /// <summary>
    /// 内存单元-变量
    /// </summary>
    public class Variable
    {
        public Variable() { }
        public Variable(string name, string type, object value, int processindex)
        {
            this.Name = name;
            this.Type = type;
            this.Value = value;
            this.ProcessIndex = processindex;
            this.Occupy = true;
        }
        /// <summary>
        /// 是否被占用
        /// </summary>
        public bool Occupy { get; set; }
        /// <summary>
        /// 所属进程的索引
        /// </summary>
        public int ProcessIndex { get; set; }
        /// <summary>
        /// 变量的值
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// 变量类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 变量名
        /// </summary>
        public string Name { get; set; }

    }

    /// <summary>
    /// 内存单元-资源
    /// </summary>
    public class Resource
    {
        public Resource()
        {
            this.ProcessIndex = -1;
            EndTime = 0;
            NeedTime = 0;
            Occupy = false;
        }
        /// <summary>
        /// 资源名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 当前占用此资源的程序
        /// </summary>
        public int ProcessIndex { get; set; }
        /// <summary>
        /// 距离结束的时间
        /// </summary>
        public int EndTime { get; set; }
        /// <summary>
        /// 所需总共时间
        /// </summary>
        public int NeedTime { get; set; }
        /// <summary>
        /// 是否被占用
        /// </summary>
        public bool Occupy { get; set; }
    }

    /// <summary>
    /// 内存单元-进程控制块PCB
    /// </summary>
    public class Procedure
    {
        public Procedure() { }

        public Procedure(string processname, string allcode)
        {
            this.ProcessName = processname;
            this.AllCode = allcode;
            this.State = "Ready";
            this.Occupy = true;
            string[] onecode = AllCode.Split(new char[] { ';', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (onecode.Length == 0)
                throw new Exception("出现错误，错误原因：未写入代码！");
            for (int i = 0; i < onecode.Length; i++)
            {
                this.OneCode.Add(onecode[i]);
            }
        }

        /// <summary>
        /// 程序名
        /// </summary>
        public string ProcessName { get; set; }
        /// <summary>
        /// 程序优先级
        /// </summary>
        public double Priority { get; set; }
        /// <summary>
        /// 所有代码
        /// </summary>
        public string AllCode { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 此单元内存是否被占用
        /// </summary>
        public bool Occupy { get; set; }
        /// <summary>
        /// 单句代码集合
        /// </summary>
        public List<string> OneCode = new List<string>();
        /// <summary>
        /// 即将运行的代码的索引
        /// </summary>
        public int CodeIndex { get; set; }
    }

}
