using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1第一阶段
{
    static class StaticPerson211
    {
        //静态类的静态构造函数
        //无访问修饰符，无参数，只会被调用一次（在使用静态类之前被动调用）
        static StaticPerson211()
        {
            Console.WriteLine("静态类的静态构造函数被调用了！！！！");
        }

        public static string Name   //每个成员都要有static，即静态
        {
            get;
            set;
        }
        public static void Sayhi()
        {
            Console.WriteLine("Hello!");
        }


    }
}
