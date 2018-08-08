using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._5操作系统作业.cs
{
    public static class Queue
    {
        /// <summary>
        /// 放入就绪队列并排序
        /// </summary>
        /// <param name="processindex">该程序在内存中的索引</param>
        /// <param name="priority">该优先级</param>
        public static void PutInReadyQueue(int processindex)
        {
            for (int i = 0; i < Store.ReadyQueue.Count; i++)
            {
                if (Store.ProcedureMemory[Store.ReadyQueue[i]].Priority < Store.ProcedureMemory[processindex].Priority)
                {
                    Store.ReadyQueue.Insert(i, processindex);
                    Store.ProcedureMemory[processindex].State = "Ready";
                    CPU.form.UpdataRTB1();
                    return;
                }
            }
            Store.ReadyQueue.Add(processindex);
            CPU.form.UpdataRTB1();
        }

        /// <summary>
        /// 取出就绪队列第一个并执行
        /// </summary>
        /// <param name="processindex"></param>
        public static void BreakOutReadyQueue()
        {
            CPU.ProcedureIndex = Store.ReadyQueue[0];
            //删除
            Store.ReadyQueue.RemoveAt(0);
            //更新
            CPU.form.UpdataRTB1();
            //更改程序状态
            Store.ProcedureMemory[CPU.ProcedureIndex].State = "In CPU";
        }

        /// <summary>
        /// 根据提供的程序号删除就绪队列中的程序
        /// </summary>
        /// <param name="processindex"></param>
        public static void DeleteOneReadyQueue(int processindex)
        {
            for (int i = 0; i < Store.ReadyQueue.Count; i++)
            {
                if (Store.ReadyQueue[i] == processindex)
                {
                    Store.ReadyQueue.RemoveAt(i);
                    return;
                }
            }
        }

        /// <summary>
        /// 放入阻塞队列
        /// </summary>
        /// <param name="processindex">程序索引</param>
        /// <param name="type">阻塞原因</param>
        public static void IntoBlockQueue(int processindex, string type)
        {
            //检测程序之前是否持续占用资源，进入阻塞队列即取消目标程序的资源占据，并添加资源申请的代码到程序中
            for (int i = 0; i < Store.ResourceMemory.Length; i++)
            {
                if (Store.ResourceMemory[i].Occupy)
                    if (Store.ResourceMemory[i].ProcessIndex == CPU.ProcedureIndex)
                        if (Store.ResourceMemory[i].NeedTime == -1)
                        {
                            Store.ProcedureMemory[CPU.ProcedureIndex].OneCode.Insert(Store.ProcedureMemory[CPU.ProcedureIndex].CodeIndex, "wait(" + Store.ResourceMemory[i].Name + ")");
                            Store.ReleaseResource(Store.ResourceMemory[i].Name);
                        }
            }
            //删除CPU当前程序
            CPU.ProcedureIndex = -1;
            //排序
            for (int i = 0; i < Store.BlockQueue.Count; i++)
            {
                if (Store.ProcedureMemory[Store.BlockQueue[i]].Priority < Store.ProcedureMemory[processindex].Priority)
                {
                    Store.BlockQueue.Insert(i, processindex);
                    Store.ProcedureMemory[processindex].State = "Block for " + type;
                    return;
                }
            }
            Store.BlockQueue.Add(processindex);
            Store.ProcedureMemory[processindex].State = "Block for " + type;
            CPU.form.UpdataRTB2();
        }

        /// <summary>
        /// 从阻塞队列中取出因申请变量内存失败而阻塞的程序，放入就绪队列
        /// </summary>
        public static void CheckBlockOfVariable()
        {
            //检测内存剩余
            int varfree = 0;
            for (int j = 0; j < Store.VariableMemory.Length; j++)
                if (Store.VariableMemory[j].Occupy == false)
                    varfree++;
            //检测程序是否因变量内存不足而阻塞
            for (int i = 0; i < Store.BlockQueue.Count; i++)
            {
                int blockindex = Store.BlockQueue[i];
                if (Store.ProcedureMemory[blockindex].State == "Block for variable")
                {
                    int varneed = NumOfVarNeed(blockindex);
                    if (varneed <= varfree)
                    {
                        Store.ProcedureMemory[blockindex].Priority += 10;
                        PutInReadyQueue(blockindex);
                        Store.BlockQueue.RemoveAt(i);
                        Store.ProcedureMemory[blockindex].State = "Ready";
                        CPU.form.output("从阻塞队列中取出程序“" + Store.ProcedureMemory[blockindex].ProcessName + "”。");
                        break;
                    }
                }
            }
            CPU.form.UpdataRTB2();
        }
        /// <summary>
        /// 从阻塞队列中取出因申请资源失败而阻塞的程序，放入就绪队列
        /// </summary>
        /// <param name="index">资源名</param>
        public static void CheckBlockOfResource(string name)
        {
            //检测程序是否因申请资源失败而阻塞
            for (int i = 0; i < Store.BlockQueue.Count; i++)
            {
                int blockindex = Store.BlockQueue[i];
                if (Store.ProcedureMemory[blockindex].State == "Block for " + name)
                {
                    //Store.ProcedureMemory[blockindex].Priority += 3;
                    PutInReadyQueue(blockindex);
                    Store.BlockQueue.RemoveAt(i);
                    Store.ProcedureMemory[blockindex].State = "Ready";
                    CPU.form.output("从阻塞队列中取出程序“" + Store.ProcedureMemory[blockindex].ProcessName + "”。");
                }
            }
            CPU.form.UpdataRTB2();
        }
        /// <summary>
        /// 从阻塞队列中取出因时间片使用时间用尽而阻塞的程序，放入就绪队列
        /// </summary>
        public static void CheckBlockOfTime()
        {

            for (int i = 0; i < Store.BlockQueue.Count; i++)
                if (Store.ProcedureMemory[Store.BlockQueue[i]].State == "Block for Time Exhaust")
                {
                    Queue.PutInReadyQueue(Store.BlockQueue[i]);
                    Store.BlockQueue.RemoveAt(i);
                    i--;
                }
        }

        /// <summary>
        /// 测定程序即将需求变量内存的数量
        /// </summary>
        /// <param name="processindex">程序索引</param>
        /// <returns></returns>
        public static int NumOfVarNeed(int processindex)
        {
            int num = 0;
            for (int i = Store.ProcedureMemory[processindex].CodeIndex; i < Store.ProcedureMemory[processindex].OneCode.Count; i++)
            {
                int index1 = Store.ProcedureMemory[processindex].OneCode[i].IndexOf("string");
                int index2 = Store.ProcedureMemory[processindex].OneCode[i].IndexOf("int");
                int index3 = Store.ProcedureMemory[processindex].OneCode[i].IndexOf("char");
                if (index1 != -1 || index2 != -1 || index3 != -1)
                    num++;
            }
            return num;
        }

        /// <summary>
        /// 测定程序即将需求资源的数量
        /// </summary>
        /// <param name="processindex"></param>
        /// <returns></returns>
        public static int NumOfResNeed(int processindex)
        {
            int num = 0;
            for (int i = Store.ProcedureMemory[processindex].CodeIndex; i < Store.ProcedureMemory[processindex].OneCode.Count; i++)
            {
                int index1 = Store.ProcedureMemory[processindex].OneCode[i].IndexOf("wait");
                if (index1 != -1)
                    num++;
            }
            return num;
        }


        #region 抢占式调度

        /// <summary>
        /// 抢占式调度
        /// （就绪队列第一位程序优先级超过正在运行的至少3级即抢占CPU）
        /// </summary>
        public static void Dispatch_Grab()
        {
            if (CPU.ProcedureIndex != -1)
            {
                //从阻塞队列转移到就绪队列
                for (int i = 0; i < Store.BlockQueue.Count; i++)
                {
                    if (Store.ProcedureMemory[Store.BlockQueue[i]].State == "Block for priority is too low")
                    {
                        if (Store.ReadyQueue.Count < 2)
                        {
                            PutInReadyQueue(i);
                            Store.BlockQueue.RemoveAt(i);
                            Store.ProcedureMemory[i].State = "Ready";
                            CPU.form.output("从阻塞队列中取出程序“" + Store.ProcedureMemory[i].ProcessName + "”。");
                        }
                        else
                        {
                            if (Store.ProcedureMemory[Store.ReadyQueue[Store.ReadyQueue.Count - 1]].Priority < Store.ProcedureMemory[Store.BlockQueue[i]].Priority)
                            {
                                PutInReadyQueue(i);
                                Store.BlockQueue.RemoveAt(i);
                                Store.ProcedureMemory[i].State = "Ready";
                                CPU.form.output("从阻塞队列中取出程序“" + Store.ProcedureMemory[i].ProcessName + "”。");
                            }
                        }
                    }
                }
                //优先级抢占
                if (Store.ReadyQueue.Count != 0)
                {
                    if (Store.ProcedureMemory[Store.ReadyQueue[0]].Priority - Store.ProcedureMemory[CPU.ProcedureIndex].Priority > 3)
                    {
                        CPU.form.output("程序“" + Store.ProcedureMemory[CPU.ProcedureIndex].ProcessName + "”被优先级抢占CPU。");
                        IntoBlockQueue(CPU.ProcedureIndex, "priority is too low");
                        CPU.ProcedureIndex = -1;

                    }
                }
                CPU.form.UpdataRTB2();
            }
        }

        #endregion

        #region 最短处理机执行期优先调度

        /// <summary>
        /// 最短处理机执行期优先调度
        /// （根据运行时间评估程序的优先级）
        /// </summary>
        /// <param name="processindex"></param>
        public static void Dispatch_PriorityForTimeOfExecute(int processindex)
        {
            if (!CPU.form.Dispatch_PriorityForTimeOfExecute)
                return;
            int varneed = NumOfVarNeed(processindex);
            int resneed = NumOfResNeed(processindex);
            Store.ProcedureMemory[processindex].Priority = 10 - resneed - varneed * 0.5 - Store.ProcedureMemory[processindex].OneCode.Count * 0.5;
        }

        #endregion

        #region 时间片轮转调度

        /// <summary>
        /// 时间片轮转调度
        /// </summary>
        public static void Dispatch_TimeSlicingCycle()
        {
            //计划数组未完成
            if (CPU.form.list.Count != 0)
            {
                //程序未运行完毕
                if (Store.ProcedureMemory[CPU.form.list[0][0]].Occupy)
                {
                    //程序未因其他原因阻塞
                    if (Store.ProcedureMemory[CPU.form.list[0][0]].State == "In CPU" || Store.ProcedureMemory[CPU.form.list[0][0]].State == "Ready" || Store.ProcedureMemory[CPU.form.list[0][0]].State == "Block for Time Exhaust")
                    {
                        //给予程序的CPU执行时间未到或程序还未开始执行
                        if (CPU.form.list[0][1] != 0)
                        {
                            CPU.ProcedureIndex = CPU.form.list[0][0];
                            Queue.DeleteOneReadyQueue(CPU.ProcedureIndex);
                            //运行
                            CPU.Run();
                            //给予的时间减一
                            if (CPU.form.list.Count != 0)
                            {
                                CPU.form.list[0][1]--;
                            }
                        }
                        //给予程序的CPU执行时间已到
                        else
                        {
                            //将没有时间的程序放入阻塞队列，并切换下一个程序运行
                            if (CPU.form.list.Count != 1)
                            {
                                Queue.IntoBlockQueue(CPU.form.list[0][0], "Time Exhaust");
                                CPU.form.list.RemoveAt(0);
                                CPU.ProcedureIndex = CPU.form.list[0][0];
                                Queue.DeleteOneReadyQueue(CPU.ProcedureIndex);
                                CPU.Run();
                                //给予的时间减一
                                CPU.form.list[0][1]--;
                            }
                            //计划数组已空，时间片正常完成一圈
                            else
                            {
                                Queue.IntoBlockQueue(CPU.form.list[0][0], "Time Exhaust");
                                CPU.form.list.RemoveAt(0);
                                Queue.CheckBlockOfTime();
                                CPU.form.UpadetaThreeText("");
                            }
                        }
                    }
                    //程序因其他原因被阻塞
                    else
                    {
                        if (CPU.form.list.Count != 1)
                        {
                            CPU.form.list[1][1] += CPU.form.list[0][1];
                            CPU.form.list.RemoveAt(0);
                            CPU.ProcedureIndex = CPU.form.list[0][0];
                            Queue.DeleteOneReadyQueue(CPU.ProcedureIndex);
                            Dispatch_TimeSlicingCycle();
                        }
                        //时间片未轮转完，但计划数组中已空
                        else
                        {
                            CPU.form.textBox3.Text = "CPU休息中";
                        }
                    }
                }
                //程序已运行完毕
                else
                {
                    //不是最后一个程序
                    if (CPU.form.list.Count != 1)
                    {
                        CPU.form.list[1][1] += CPU.form.list[0][1];
                        CPU.form.list.RemoveAt(0);
                        CPU.ProcedureIndex = CPU.form.list[0][0];
                        Queue.DeleteOneReadyQueue(CPU.ProcedureIndex);
                        Dispatch_TimeSlicingCycle();
                    }
                    //最后一个程序运行完毕
                    else
                    {
                        CPU.form.output("时间片未轮转完，计划程序即运行结束");
                        CPU.form.progressBar1.Value = CPU.form.progressBar1.Maximum;
                        CPU.form.list = AllotTime();
                    }
                }
            }
            //时间片未轮转完，但计划数组中已空
            else
            {
                CPU.form.progressBar1.Value = CPU.form.progressBar1.Maximum;
                CPU.form.list = AllotTime();
            }
        }
        /// <summary>
        /// 为一圈时间片分配程序运行时间
        /// </summary>
        /// <returns>返回一个集合，集合每行的第一位为程序索引，第二位为一圈时间片可以运行几句代码</returns>
        public static List<int[]> AllotTime()
        {
            List<int[]> list = new List<int[]>();
            switch (Store.ReadyQueue.Count)
            {
                case 0:
                    if (CPU.ProcedureIndex == -1)
                    {
                        CPU.form.timer2.Enabled = false;
                        CPU.form.UpadetaThreeText("");
                        //提示弹框
                        System.Windows.Forms.MessageBox.Show("所有程序运行完毕", "朕知道了", System.Windows.Forms.MessageBoxButtons.OK);
                    }
                    break;
                case 1:
                    int[] j1 = new int[2];
                    j1[0] = Store.ReadyQueue[0];
                    j1[1] = Convert.ToInt32(CPU.form.Speed.Text) * 6;
                    list.Add(j1);
                    break;
                case 2:
                    int[] j2 = new int[2];
                    int[] j3 = new int[2];
                    j2[0] = Store.ReadyQueue[0];
                    j2[1] = Convert.ToInt32(CPU.form.Speed.Text) * 4;
                    j3[0] = Store.ReadyQueue[1];
                    j3[1] = Convert.ToInt32(CPU.form.Speed.Text) * 2;
                    list.Add(j2);
                    list.Add(j3);
                    break;
                default:
                    for (int i = 0; i < 3; i++)   //一次时间片最多运行3个程序
                    {
                        int[] j4 = new int[2];
                        j4[0] = Store.ReadyQueue[i];
                        j4[1] = Convert.ToInt32(CPU.form.Speed.Text) * 2;
                        if (i == 0)
                            j4[1] += 1;
                        else if (i == 2)
                            j4[1] -= 1;
                        list.Add(j4);
                    }
                    break;
            }
            return list;
        }

        #endregion

    }
}
