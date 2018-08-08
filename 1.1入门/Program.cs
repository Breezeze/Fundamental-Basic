using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1入门
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ctrl+M+M折叠或展开当前代码，Ctrl+M+O折叠所有代码
            //当代码下方出现一个字符长度的下划线时，Alt+Shift+F10打开功能下拉框
            //当运用函数时，不知道参数是什么时，可以选到要使用的重载后，Ctrl+J，自动转到所需参数的下拉框

            //01
            #region       1+1/2+1/3+…+1/n求和

            //Console.WriteLine("输入回车继续");
            //Console.ReadKey();
            //Console.WriteLine("此程序计算\"1+1/2+1/3+…+1/n\"的结果，请输入n的值");
            //double min = Convert.ToDouble(Console.ReadLine());
            //double end = 0;
            //double i = 1;
            //double m = 0;
            //while (i <= min)
            //{
            //    m = 1 / i;
            //    end = end + m;
            //    i++;
            //}
            //Console.WriteLine("最后得数为" + end);

            #endregion
            //02
            #region   输入数字分等级（含switch选择器）

            //Console.WriteLine("请输入成绩");
            //double i1 = int.Parse(Console.ReadLine());       //这句话和 double i1 = Convert.InTot32(Console.ReadLine());  功能一致
            //int start = (int)(i1 / 10);                   //(int)(#)表示将一个数删除小数点后的部分，保留整数部分
            //if (start <= 10 && start >= 0)
            //{
            //    switch (start)
            //    {
            //        case 10:                               //case后只能写常数
            //        case 9:                                //不同case的执行结果一致时，可以简写（即删除执行语句和break）
            //            Console.WriteLine("优秀");
            //            break;                     //break为结束语句，必须有
            //        case 8:
            //        case 7:
            //            Console.WriteLine("合格");
            //            break;
            //       default:                         //defult功能是除了以上情况以外，相当于if语句中的else
            //            Console.WriteLine("不合格");
            //            break;
            //    }
            //}
            //else Console.WriteLine("输入了错误的成绩");
            //Console.ReadKey();

            #endregion
            //03
            #region   数据交换（变换器，判断式）

            //Console.WriteLine("请输入第一个数字a");
            //int num1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("下面请输入第二个数字b");
            //int num2 = Convert.ToInt32(Console.ReadLine());

            ////第一种方法:新建一个数据充当储存器
            //int tmp = num1;
            //num1 = num2;
            //num2 = tmp;

            //////第二种方法的转换部分：
            ////num2 = num1 + (num1 = num2) * 0;
            //////先运行括号内的部分，实现了num1的变换，同时，因为在等号同一侧，第一个num1并没有因为括号中的部分改变值，
            //////后边的式子乘以0，使得计算完括号内的式子后，整体式子变成了num2=num1，实现了num2的变换

            //Console.WriteLine("此时第一个数字a为：{0}，第二个数字b为：{1}。", num1, num2);
            //Console.ReadKey();

            ////使用判断式
            //int max = num1 > num2 ? num1 : num2;    //判断num1>num2的布尔值，如果是true则整句话相当于num1，false则为num2
            //int min = num1 < num2 ? num1 : num2;
            //Console.WriteLine("其中较大的值为" + max + "较小的值为" + min + "。");

            #endregion
            //04
            #region  给数字排序（数组、for变换器）

            //int[] name = new int[3];                                 //创建一个叫name的数组，里面有3个数
            //int i;                                                   //定义一个整数i
            //Console.WriteLine("请依次输入3个数：");
            //for (i = 0; i < name.Length; i++)                        //i < name.Length意思是i大于name的长度
            //{
            //    name[i] = Convert.ToInt32(Console.ReadLine());       //将用户输入的数字依次定义为name数组中的元素，并通过for保证name个数相同
            //}                                                        //name[i]代表name数组中第i个元素
            //int m = 0;
            //for (i = 0; i < name.Length; i++)                      
            //{
            //    if (name[i] > name[i + 1])                          //if后的括号内&&表示为并且
            //    {
            //        m = name[i];
            //        name[i] = name[i + 1];
            //        name[i + 1] = m;
            //    }
            //}
            //Console.WriteLine();
            //for (i = 0; i < name.Length; i++)                //之所以是i < name.Length  ，是因为数组序号是从0开始的
            //{
            //    Console.WriteLine（name[i]);
            //}
            //Console.ReadKey();

            #endregion
            //05
            #region    数组行换列，列换行（2维数组定义）


            //Console.WriteLine("这是个将表格的行换列,列换行的转化程序");
            //Console.ReadKey();
            ////定义初始数组
            //double[,] a = new double[3, 4] { { 1.1, 1.2, 1.3, 1.4 }, { 2.1, 2.2, 2.3, 2.4 }, { 3.1, 3.2, 3.3, 3.4 } };
            //double[,] b = new double[4, 3];                //定义二维数组
            ////表达初始数组a
            //Console.Write("\n");
            //Console.WriteLine("初始数组为3行4列，如下");
            //int i, j;
            //for (i = 0; i < 3; i++)
            //{
            //    for (j = 0; j < 4; j++)
            //    {
            //        Console.Write("{0}   ", a[i, j]);       // C#的空格在""里面直接显示（多维数组的输出若想让人看清应制成表格状）
            //    }                                                                       //即在元素之间加空格隔开，一行元素后换行
            //    Console.WriteLine();
            //}
            //Console.WriteLine();
            //Console.WriteLine("按任意键转化");
            //Console.ReadKey();
            ////转化
            //int m, n;
            //for (m = 0; m < 4; m++)
            //{
            //    for (n = 0; n < 3; n++)
            //    {
            //        b[m, n] = a[n, m];
            //    }
            //}
            ////表达结果数组b
            //Console.WriteLine();
            //Console.WriteLine("转化完成，结果如下");
            //for (i = 0; i < 4; i++)
            //{
            //    for (j = 0; j < 3; j++)
            //    {
            //        Console.Write("{0}   ", b[i, j]);
            //    }
            //    Console.Write("\n");
            //}



            #endregion
            //06
            #region      求平均值（构建并调用、重载函数）

            //double a;
            //a = ave106(12, 13, 14);         // [函数名](#,#,#)的值即构建函数中的return返回值
            //Console.WriteLine(a);
            //Console.ReadKey();

            #endregion
            //07
            #region   冒泡排序

            //思路：先建立数组读取输入的数字，而后通过两个循环语句依次比较大小，换位置
            Console.WriteLine("这是一个对数据排序的程序");
            Console.WriteLine("请输入5个数");
            int[] score = new int[5];         //建立数组
            int i, j;
            int exchange = 0;

            for (i = 0; i < score.Length; i++)
            {
                //score[i] = int.Parse (Console.ReadLine());        //读取用户输入的数字
                score[i] = Convert.ToInt32(Console.ReadLine());     //两种方法均可
            }

            int check = 0;
            for (i = 0; i < score.Length - 1; i++)                  //第一个for的作用：整体比较，执行次数和数组一致，确保初始数组中最后一个数都可以交换到第一个位置
            {
                for (j = 0; j < score.Length - 1; j++)              //第二个for的作用：相邻的两个数比较
                {
                    if (score[j] > score[j + 1])
                    {
                        exchange = score[j];
                        score[j] = score[j + 1];
                        score[j + 1] = exchange;
                        check++;
                    }
                }
            }
            Console.WriteLine("已排序，交换语句执行了{0}次", check);

            for (i = 0; i < score.Length; i++)
            {
                Console.WriteLine("{0,5}", score[i]);
            }
            Console.ReadKey();

            #endregion
            //08
            #region 求二位质数(用中间变量做选择器)

            //Console.WriteLine("二位数质数有：");
            //int a, b, c = 0 , d = 0;
            //int[] end = new int[100];
            //for (a = 11; a < 101; a++)            //二位数依次检测
            //{
            //    for (b = 2; b < a / 2; b++)       //检测是否为质数
            //    {
            //        if (a % b == 0)               //余数为0，说明能整除，不是质数，
            //        {
            //            c = 1;                    //通过局部变量c选择下面的执行代码
            //            break;
            //        }
            //        else c = 2;
            //    }
            //    if (c == 2)                      //确定为质数后，储存于end数组中
            //    {
            //        end[d] = a;
            //        d++;
            //    }
            //}
            //for(int i=0 ; i < end.Length - 1 ; i++ )   //输出质数
            //{
            //    if (end[i] != 0)                //前面定义数组end的长度为100，只表达已赋值的数组元素
            //    {
            //        if (i+1 == d )            //此选择式缘由：共有d+1-1=d个质数（d++在储存质数之后执行），数组元素是从0开始，第n个数组元素的坐标为n+1
            //            Console.WriteLine(end[i] + "。");    //最后一个质数后加句号
            //        else
            //            Console.Write("{0},", end[i]);      //输出时的两种方法，C语言多用此方法
            //    }
            //    else break;
            //}
            //Console.ReadKey();

            #endregion
            //09
            #region 拓展——求任意给定范围的质数（使用函数+纠错处理）

        //    Console.WriteLine("该程序可计算出范围内所有质数，按任意键继续");
        //    Console.ReadKey();
        //wrong: Console.WriteLine("请输出下限");
        //    int low = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("请输入上限");
        //    int up = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        //    if (low >= up || low < 0)
        //    {
        //        Console.WriteLine("输入错误，请重新输入");
        //        goto wrong;
        //    }
        //    check109(low, up);
        //    output109(storage109);                              //传参格式：括号内写变量名称（数组也是变量）
        //    Console.WriteLine("在{0}至{1}之间共有{2}个质数", low, up, d109);
        //    Console.ReadKey();

            #endregion
            //10
            #region  随机生成100以内的偶数，加入集合（随机数组）

            //List<int> list = new List<int>();                    //List为集合，<T>泛型
            //Random random = new Random();                         //random函数功能：返回一个随机数
            //while (list.Count < 10)                               //list.Count是集合list的长度     (和数组中的**.Length相近)
            //{
            //    int num = random.Next(1, 101);                   //random.Next(x,y)功能是：返回一个x到y-1之间的随机数
            //    if (num % 2 == 0 && !list.Contains(num))         //list.Contains(x)功能：判断list集合中是否有x元素，并输出bool类型
            //    {
            //        list.Add(num);                               //在集合list中添加num一个元素
            //    }
            //}
            //Console.WriteLine("结果如下");
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}

            #endregion


            Console.ReadKey();
        }

        #region 函数声明

        #region   一、06-求平均数函数

        //重载函数
        public static double ave106(double m, double n)
        {
            double z = (m + n) / 2;
            return z;
        }
        public static double ave106(double a, double b, double c)
        {
            double z = (a + b + c) / 3;
            return z;
        }
        public static double ave106(double a, double b, double c, double d)
        {
            double z = (a + b + c + d) / 3;
            return z;
        }

        #endregion

        #region 一、09-求两位质数拓展-删除最后一位逗号

        #region 设置全局变量（必须在函数外设置）
        static int a109 = 0, b109 = 0, c109 = 0, d109 = 0;    //static设置函数或变量为静态的
        static int[] storage109 = new int[1000];              //storage作为储存数组
        #endregion

        #region 检测函数+储存函数
        public static void check109(int i, int j)    //check检测，该函数功能：检测并储存
        {                                         //void修饰函数表示无return返回值
            for (a109 = i; a109 < j; a109++)               //二位数依次检测
            {
                for (b109 = 2; b109 < a109 / 2; b109++)       //检测是否为质数
                {
                    if (a109 % b109 == 0)               //余数为0，说明能整除，不是质数，
                    {
                        c109 = 1;                    //通过局部变量c选择下面的执行代码
                        break;
                    }
                    else c109 = 2;
                }
                if (c109 == 2)                       //因为上面的检测循环必须要进行多次，从2开始至少要除到n/2，所以
                {
                    storage109[d109] = a109;               //确定为质数后，储存于end数组中
                    d109++;                          //d确定有多少个质数
                }
            }
        }
        #endregion

        #region 输出函数
        public static void output109(int[] a)     //output输入
        {
            for (int i = 1; i < 100; i++)      //输出质数
            {
                if (a[i] != 0)                 //前面定义数组end的长度很长，未赋值的数组元素为0，所以只表达已赋值的数组元素
                {   //下面的选择式：共有d+1-1=d个质数（d++在储存质数之后执行），数组元素是从0开始，第n个数组元素的坐标为n+1 
                    if (i + 1 != d109 && i % 5 != 0)                //并且每输入5个质数后换行，显得整齐
                        Console.Write("{0}\t", a[i]);     //%%并且，||或者
                    else
                        Console.WriteLine("{0}", a[i]);
                }
                else break;
            }
        }
        #endregion

        #endregion

        #endregion
    }
}
