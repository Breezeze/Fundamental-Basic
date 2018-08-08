using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3委托
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1.委托的初步声明（定义委托后，在类中使用委托）

            //DoCW c1 = new DoCW();
            ////不添加委托
            //c1.Do();
            //Console.WriteLine("\n\n\n");
            ////添加委托
            ////将函数赋值给委托，这样，委托就可以使用了，委托中存储的就是M1方法
            //c1.method = M1;
            //c1.Do();

            #endregion

            #region 2.委托作为参数（主函数使用委托）

            string[] str1 = { "fs", "asd", "Johnson" };
            //声明委托
            ChangeString cs = new ChangeString();
            //使用委托作为参数，即函数作为参数
            string[] str2 = cs.Change(str1, M2);
            string[] str3 = cs.Change(str1, M3);
            //实现了通过调用一个方法完成不同的操作
            foreach (string item in str2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n\n");
            foreach (string item in str3)
            {
                Console.WriteLine(item);
            }

            #endregion



            Console.ReadKey();

        }

        //1.委托的初步声明（定义委托后，在类中使用委托）
        public static void M1()
        {
            Console.WriteLine("当前时间：" + DateTime.Now.ToString());
        }
        //2.委托作为参数（主函数使用委托）
        public static string M2(string mag)
        {
            return "★" + mag + "★";
        }
        public static string M3(string mag)
        {
            return mag.ToUpper();
        }




    }
}
