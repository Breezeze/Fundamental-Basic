using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._3基础
{
    #region 09-多线程-并发执行-线程锁

    public class ParallelDemo
    {
        private Stopwatch stopWatch = new Stopwatch();
        object obj = new object();
        public void Run1()
        {
            lock (obj)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Task 1 is cost 2 sec");
            }
        }
        public void Run2()
        {
            //lock (obj)
            //{
            Thread.Sleep(500);
            Console.WriteLine("Task 2 is cost 3 sec");
            //}
        }

        public void ParallelInvokeMethod()
        {
            stopWatch.Start();
            Parallel.Invoke(Run1, Run2);
            stopWatch.Stop();
            Console.WriteLine("Parallel run " + stopWatch.ElapsedMilliseconds + " ms.\n");

            stopWatch.Restart();
            Run1();
            Run2();
            stopWatch.Stop();
            Console.WriteLine("Normal run " + stopWatch.ElapsedMilliseconds + " ms.");
        }

    }
    #endregion

    #region 10-using的使用

    class person : IDisposable
    {

        public void Dispose()
        {
            Console.WriteLine("Dispose()被调用了");
        }
    }
    #endregion

    #region 08-反射

    public class ClaExa
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
        public int MyProperty3 { get; set; }
        public int MyProperty4 { get; set; }
    }


    #endregion

    #region 12-枚举

    public enum MyEnum
    {
        asd1 = 1,
        we2 = 2,
        zxc3 = 3,
    }
    #endregion

    #region 13-json-序列化工具

    [DataContract]
    public class Student
    {
        [DataMember]//契约
        //使用DataContractJsonSerializer序列化和反序列化必须要加的
        //其他两种方式不是必须加
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string Sex { get; set; }
    }


    #endregion

}

