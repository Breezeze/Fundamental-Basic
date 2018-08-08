using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2._1第一阶段;
using System.Diagnostics;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace _1._3基础
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 01-类型转换---Convert.To*()--TryParse()--as关键字--byte数组转换

            #region 01.1    基础转换

            ////字节数小的数据类型转化为字节数大的数据类型时，可以使用隐性转换
            //int i1 = 666;
            //double d1 = i1;
            //Console.WriteLine(i1 + "int→double=" + d1);


            ////但是当 大→小 时，需要使用显性转换，同时可能会出现问题
            //double d2 = 234.56;
            //int i2 = (int)d2;
            //Console.WriteLine(d2 + "double→int=" + i2);


            ////特殊转换
            //int i3 = 100;
            //char c1 = (char)i3;
            //int i4 = 66;
            //char c2 = (char)i4;
            //Console.WriteLine("100int→char={0}，66int→char={1}", c1, c2);
            //char c3 = '赵';
            //int i5 = (int)c3;
            //Console.WriteLine("'赵'→int=" + i5);

            #region 查看各种类型存储时所占字节数大小

            //Console.WriteLine("bool→" + sizeof(bool));//1
            //Console.WriteLine("byte→" + sizeof(byte));//1
            //Console.WriteLine("char→" + sizeof(char));//2
            //Console.WriteLine("short→" + sizeof(short));//2
            //Console.WriteLine("int→" + sizeof(int));//4
            //Console.WriteLine("long→" + sizeof(long));//8
            //Console.WriteLine("float→" + sizeof(float));//4
            //Console.WriteLine("double→" + sizeof(double));//8
            //Console.WriteLine("decimal→" + sizeof(decimal));//16

            #endregion

            #endregion

            #region 01.2    调用方法进行转换

            ////Convert强制转换
            ////所有类型都可以转换为string字符串类型
            //int i1 = 666;
            //string s1 = Convert.ToString(i1);
            //Console.WriteLine("666int→string=" + s1);


            ////TryParse(#，*)
            ////    # 所需转化的字符串,   * 转化成功后接收数字的数字变量
            ////把任意字符串转换为数字类型
            ////成功返回true，失败返回false
            //string s2 = "125125sdfa";
            //int i2;
            //bool b1 = int.TryParse(s2, out i2);
            //if (b1 == true)
            //{
            //    Console.WriteLine("{0}string→int={1}", s2, i2);
            //}
            //else
            //{
            //    Console.WriteLine("转化失败");
            //}

            ////通过编码层次改变数据类型
            //string msg = "哈喽沃德，你好世界，Hello World！！！";
            //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(msg);
            //string str = System.Text.Encoding.UTF8.GetString(bytes);


            #endregion

            #region 01.3    as关键字，is关键字
            //对象的类型转换
            //在 2.类的应用-2.1第一阶段-2.16-对象的类型转换有讲

            ////as
            //object[] obj = new object[3];
            //obj[0] = "hello";
            //obj[1] = 3.12;
            //obj[1] = new Object();
            //for (int i = 0; i < obj.Length; i++)
            //{
            //    string str = obj[i] as string;        //   * as # 会尝试将*变量尝试转化成#类型   成功则正常转化，失败则赋值为null
            //    if (str != null)
            //    {
            //        Console.WriteLine(str);
            //    }
            //    else
            //    {
            //        Console.WriteLine("obj[{0}]无法转化string类型", i);
            //    }
            //}



            ////is
            //object[] obj = { 123, 123, "asdfwef", 's' };
            //for (int i = 0; i < obj.Length; i++)
            //{
            //    if (obj[i] is int)      //可以转化返回true，不可以转化返回false
            //        Console.WriteLine("obj可以转化为int类型");
            //    else
            //        Console.WriteLine("obj无法转化");
            //}

            #endregion

            #region 01.4    byte数组之间的转化

            ////string类型转化成byte数组
            //byte[] b = Encoding.UTF8.GetBytes("lajfsdiovcx");

            ////byte数组类型转化为string字符串
            //string str = "";
            //for (int i = 0; i < b.Length; i++)
            //{
            //    str += (char)b[i];
            //}
            //Console.WriteLine(str);

            #endregion

            #endregion

            #region 02-异常处理---try{}catch{}finally{}--exception

            #region 基本格式

            ////手动抛出异常，即运行该代码会结束程序并显示错误弹框，提示括号内的内容
            ////一般不要这么做，除非是非常严重甚至影响程序运行的错误才会用
            //throw new Exception("哈哈哈哈");

            /*
             
            try
            {
                //可能出现异常的代码

            }
            catch (DataMisalignedException)//Ctrl+J
            {
                //如果try中出现异常，则不执行try中的代码，并执行catch中的代码

                throw;//类似于return，向上一级try抛出该异常，只能在catch中写，如果没有上一级try结构，不需要写
                //抛出异常的同时，会结束该try结构所在函数（如果是控制台项目中的主函数，会直接终止主函数，不运行下面的代码）

                //可以写多个catch异常处理方法，括号内为异常类型
                //写多个catch 并括号内是不同的异常类，可以将不同的异常使用不同的处理代码
            }
            catch (Exception ex)//括号中写可能的异常
            {
                //Exception是所有异常的祖宗类，当 catch中使用Exception时，无论什么类型的异常都可以获取
                Console.WriteLine(ex.Message);//ex.Message异常消息
            }
            finally
            {
                //可以不写
                //无论try是否出现异常，都会执行这里的代码
                //一般和资源操作（文件、数据库操作）会用到
                //因为无论是否成功执行代码，都要释放资源

                //如果在catch中使用了throw，则finally括号后的代码不会执行，但finally中的代码依然会执行
                //但是finally中不能写return
            }
            
            */

            #endregion

            //try
            //{
            //    #region 第二级try结构

            //    try
            //    {
            //        int i1 = 0;
            //        int i2 = 100 / i1;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("二级try中的错误：" + ex.Message);
            //        throw;
            //    }
            //    finally
            //    {
            //        Console.WriteLine("二级try的finally");
            //    }
            //    Console.WriteLine("这是二级try中finally括号后的代码");

            //    #endregion
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("一级try错误：" + ex.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("一级try中finally");
            //}




            #endregion

            #region 03-参数修饰符---parmas--ref--out

            #region 03.1-params可变参数修饰符

            //int[] i = new int[5];
            //i[0] = 1;
            //i[1] = 2;
            //i[2] = 3;
            //i[3] = 4;
            //i[4] = 5;
            //int add1 = Add131(i);
            //int add2 = Add131(i[0], i[1], i[2], i[3], i[4]);
            //Console.WriteLine(add1);
            //Console.WriteLine(add2);

            #endregion

            #region 03.2-ref指针参数修饰符

            ////调用使用ref修饰参数的函数时，传的参数必须是已经赋值的变量
            //int i = 10;
            //AddOne132(ref i);
            //Console.WriteLine(i);


            #endregion

            #region 03.3-out赋值参数修饰符

            //调用out修饰参数的函数时，传的参数必须是已经声明的变量
            //int i = 111;
            //Assignment133(out i);
            //Console.WriteLine(i);
            //Assignment133(out i, 777);
            //Console.WriteLine(i);

            #endregion

            #region 03.4-实例1-交换值

            //int i1 = 111;
            //int i2 = 222;
            //i1 = Change134(i1, ref i2);
            //Console.WriteLine("i1={0}，i2={1}", i1, i2);

            #endregion

            #region 03.5-实例2-模拟登陆

            //go: Console.Write("请输入用户名：");
            //    string account = Console.ReadLine();
            //    Console.Write("请输入密码：");
            //    string password = Console.ReadLine();
            //    //要求用函数，并且有两个返回值，一个bool返回对错，一个string返回结果
            //    string resultstring;
            //    bool resultbool = Judge135(account, password, out resultstring);
            //    Console.WriteLine("\n" + resultstring);
            //    if (resultbool)
            //    {
            //        Console.WriteLine("请选择您要办理的业务");
            //    }
            //    else
            //    {
            //        Console.WriteLine("\a请重新输入\n");
            //        goto go;
            //    }
            #endregion

            #endregion

            #region 04-代码效率测试（检测运行时间）---Stopwatch

            ////Stopwatch提供一组方法和属性，可用于准确地测量运行时间。
            ////创建Stopwatch类型的变量
            //Stopwatch wacth = new Stopwatch();
            //wacth.Start();//开始计时
            //string str = string.Empty;
            //while (str.Length < 100000)
            //{
            //    str += "asdfsdfasfasdfas";
            //}
            //wacth.Stop();
            //Console.WriteLine(wacth.Elapsed);//获取当前实例测量得出的总时间



            #endregion

            #region 05-集合
            /*
             * 常用集合：
             * 1）类似数组的集合：ArrayList、List<T>
             * 2）键值对集合（哈希表集合）：一个键对应一个值，根据键直接查找到值，速度快
                  Hashtable、Dictionary<K,V>       （<K,V>即表示键值对）
             * 3）堆栈集合：
                  Stack、Stack<T>（LIFO（last in frist out后进先出））
             * 4）队列集合：
                  Queue、Queue<T>（FIFO）
             * 5）可排序键值对集合(插入、检索没有哈希表集合高效)：
                  SortedList、SortedList<K,V>（占用内存更少，可以通过索引访问）
                  SortedDictionary<K,V>（占用内存更多，没有索引，但插入、删除元素速度比SortedList快）
             * 6）Set集合：无序，不重复。
                  Hashtable<T>可以将HashSet类视为不包含值的
                  Dictionary集合，与List<T>类似。
                  SortedSet<T>，有序无重复集合
             * 7）双向链表集合：LinkedList<T>，增删速度快
             */


            #region 05.1-ArrayList动态数组集合
            /*
             * ArrayList集合类似object数组，可储存多种类型
             * arraylist.Count集合所包含的元素数，即集合的长度
             * arraylist.Add(*)在集合最后添加，如果*是数组，则横向添加数组
             * arraylist.AddRange()纵向添加集合成员
             * arraylist.Insert(int #,*)在指定索引位置#插入* ，之后的向后排（0索引即第一个）
             * arraylist.RemoveAt(*)删除[*]位置的元素，使用后arraylist.Count - 1
             * arraylist.Remove()调用类型内部的Equals()方法，Equals()方法返回值为true，则删除第一项匹配元素
             * arraylist.Clear()清空集合
             * arraylist.Reverse()反转
             * arraylist.Contains(#)查看是否有#该元素
             * arraylist.Sort()排序，前提是元素实现了IComparable接口的类型
                    也可以建立一个比较器（实现了IComparbable接口的类），将这个类创建一个对象后作为Sort的传参来进行自定义排序
                    如： arraylist.Sort(new class comparator:IComparer{public int Compare(object x, object y){Person217 n=x as Person217;Person217 m=y as Person217;if (n!=null&&m!=null)return n.Name.Length-m.Name.Length;elsethrow new ArgumentException();}});
            */

            #region 基础

            //ArrayList arr = new ArrayList() { 
            //1,9.9,true
            //};
            //arr.Add(true);
            //arr.Add("asdfsdffwetbcv");
            ////甚至可以添加对象
            //Person217 person = new Chinese217();
            //person.Name = "sdf";
            //arr.Add(new Chinese217() { Name = "张三" });
            ////当纵向添加数组时，使用AddRange()
            ////纵向，即将一个有n个元素的数组或集合，添加到ArrayList的结尾，使ArrayList增加n个元素
            //arr.AddRange(new string[] { "中国", "美国", "外地球" });
            ////而使用Add()是将整个数组横向添加进ArrayList中
            //arr.Add(new int[] { 1, 2, 3, 4, 5, 6, 7 });

            //Console.WriteLine("arraylist.Count=" + arr.Count);
            //Console.WriteLine("遍历该ArrayList集合：");
            //for (int i = 0; i < arr.Count; i++)
            //{
            //    if (i != arr.Count - 1)
            //        Console.WriteLine(i + "\t" + arr[i]);
            //    else
            //    {
            //        Console.Write(i + "\t" + arr[i] + "：");
            //        for (int j = 0; j < ((int[])(arr[i])).Length; j++)
            //            Console.Write(((int[])(arr[i]))[j] + "\t");
            //    }
            //}

            ////在arraylist的第1个位置后插入"Insert"
            //arr.Insert(1, "Insert");

            ////要注意假如要删除[3]和[5]的元素，应第一次*=3,第二次*=4
            ////因为第一次删除[3]的元素后，之前的[4]移动到了[3]，即后面元素全部向前进了一位
            //arr.RemoveAt(0);

            ////注意：删除第一项匹配元素
            //arr.Remove(true);

            //Console.WriteLine("\n\n修改后的ArrayList集合");
            //for (int i = 0; i < arr.Count; i++)
            //{
            //    Console.WriteLine(i + "\t" + arr[i].ToString());
            //}

            #endregion

            #region 实例-合并两个集合并去除相同项

            //ArrayList arr1 = new ArrayList() { "a", "b", "c", "d", "e" };
            //ArrayList arr2 = new ArrayList() { "d", "e", "f", "e", "h" };
            //ArrayList arr3 = new ArrayList();

            //arr3.AddRange(arr1);
            //foreach (object item in arr2)
            //{
            //    if (!arr1.Contains(item))
            //    {
            //        arr3.Add(item);
            //    }
            //}
            //for (int i = 0; i < arr3.Count; i++)
            //{
            //    Console.WriteLine(arr3[i]);
            //}

            #endregion

            #region 实例-随机生成10个不相同的偶数，加到集合中

            //Random random = new Random();
            //ArrayList arr1 = new ArrayList();
            //while (arr1.Count != 10)
            //{
            //    int i = random.Next(0, 101);
            //    if (i % 2 == 0 && !arr1.Contains(i))
            //    {
            //        arr1.Add(i);
            //    }
            //}
            //for (int i = 0; i < arr1.Count; i++)
            //{
            //    Console.WriteLine(arr1[i]);
            //}


            #endregion

            #region 实例-将一个包含多个数字的字符串进行重新排列，奇数在左，偶数在右

            #region 方法一

            //string str1 = "1 2 3 4 5 6 7 8 9 10";
            //string[] num = str1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //string[] str2 = new string[num.Length];
            //int i = 0;
            //foreach (object item in num)
            //{
            //    int j = Convert.ToInt32(item);
            //    if (j % 2 != 0)
            //    {
            //        str2[i] = (string)item;
            //        i++;
            //    }
            //}
            //foreach (object item in num)
            //{
            //    int j = Convert.ToInt32(item);
            //    if (j % 2 == 0)
            //    {
            //        str2[i] = (string)item;
            //        i++;
            //    }
            //}
            //string str3 = string.Join(" ", str2);
            //Console.WriteLine(str3);

            #endregion

            #region 方法二

            //string str1 = "1 2 3 4 5 6 7 8 9 10";
            //string[] num = str1.Split(' ');
            //ArrayList arr1 = new ArrayList();
            //ArrayList arr2 = new ArrayList();
            //foreach (object item in num)
            //    if (Convert.ToInt32(item) % 2 != 0)
            //        arr1.Add(item);
            //    else
            //        arr2.Add(item);
            //arr1.AddRange(arr2);
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < arr1.Count; i++)
            //    sb.Append(arr1[i] + " ");
            //Console.WriteLine(sb.ToString().Trim());

            #endregion

            #endregion

            #endregion

            #region 05.2-Hashtable键值对集合
            /*
             * 键值对集合特点：
             * 1）键值具有唯一性，不能重复
             * 2）键值对集合无法用for循环遍历，因为无法根据索引获取内容，只能通过键值取值
             * 3）想要遍历键值对集合可以使用foreach循环
             * 内部方法：
             * .ContainsKey(#)  #为键值，判断集合中是否有该键值
             */

            //Hashtable hash = new Hashtable();
            //hash.Add("", "");
            //hash.Add("hahah", "哈哈哈");
            //hash.Add(123, "一二三");
            //hash.Add(false, "删除");

            ////调用
            //Console.WriteLine(hash[123]);

            ////修改
            //hash[""] = "空值";

            ////删除
            //hash.Remove(false);

            ////直接遍历
            //Console.WriteLine();
            //foreach (DictionaryEntry item in hash)
            //{
            //    Console.WriteLine(item.Key + "\t" + item.Value);
            //}
            //////根据键值遍历集合，并打印所有的键值
            ////Console.WriteLine("所有键值：");
            ////foreach (object item in hash.Keys)
            ////{
            ////    Console.WriteLine(item.ToString());
            ////}
            //////根据值遍历集合，并打印所有的值
            ////Console.WriteLine("所有值：");
            ////foreach (object item in hash.Values)
            ////{
            ////    Console.WriteLine(item.ToString());
            ////}

            #endregion

            //List<T>泛型集合操作类似于ArrayList

            #endregion

            #region 06-装箱与拆箱
            //定义：
            //装箱：把值类型转换为引用类型，叫装箱
            //拆箱：把引用类型转换为值类型，叫拆箱
            //引用类型：将变量的数据存储于堆中，该变量存储的仅仅是指向存储该数据的内存地址（C中的指针）
            //值类型：直接存储变量数据

            #region 05.1辨别到底什么是装箱拆箱

            #region 装箱

            //int i = 3;
            //string str = i.ToString();      //虽然int是值类型，string是引用类型，但这不是装箱
            //Console.WriteLine(str);

            //int i = 56;
            //object obj = i;           //这是装箱
            //Console.WriteLine(obj);
            /*
            因为int是Int32类型，Int32是一个结构继承字System.ValueType，而该类又继承自Object，所以int和object类型有子父类关系，所以可以发生类型转换
            也就是说，装箱的前提是，两种类型必须是相近的类型，可以发生类型转换的类型，同时发生了内存空间的变化—申请了一个新的内存单元来存储第二个类型
            从内存层次上讲，第一个类型转化为第二个类型时，是通过拷贝第一个类型的ASCII码来转换的（并不改变类型的ASCII码）
            而上面int转化为string类型，这是两种完全不同的类型，在内存层次上将ASCII码都改变了，所以不叫装箱
             */

            //Person2161 p = new Person2161();
            //object o = p;           //这个也不是装箱，因为 都是引用类型（只是把p的地址赋值给了o）

            #endregion

            #region 拆箱

            //int i = 10;
            //double d = i;
            //int i2 = (int)d;//没有拆箱，因为都是值类型

            //object o = 13;
            //int i = (int)o;//这里发生了拆箱

            //int i = 9;
            //object o = i;       //装箱
            //double m = (double)o;       //拆箱
            //运行的话会提示失败，因为用什么类型装的箱，还要用什么类型来拆箱

            #endregion

            #endregion

            #region 05.2装箱拆箱的效率问题------装箱效率低

            ////使用装箱
            //ArrayList arr1 = new ArrayList();
            //Stopwatch watch1 = new Stopwatch();
            //watch1.Start();
            //for (int i = 0; i < 10000000; i++)
            //{
            //    arr1.Add(i);
            //}
            //watch1.Stop();
            //Console.WriteLine("将一到一千万使用装箱填充到数组里，用时：" + watch1.ElapsedMilliseconds + "毫秒");
            ////不使用装箱
            //List<int> list = new List<int>();      //泛型
            //Stopwatch watch2 = new Stopwatch();
            //watch2.Start();
            //for (int i = 0; i < 10000000; i++)
            //{
            //    list.Add(i);
            //}
            //watch2.Stop();
            //Console.WriteLine("不使用装箱，则用了{0}毫秒完成时间", watch2.ElapsedMilliseconds);
            //double times = (double)watch1.ElapsedMilliseconds / (double)watch2.ElapsedMilliseconds;
            //Console.WriteLine("由此可算出，在这个简单程序中，不使用装箱，是使用装箱效率的{0}倍", times.ToString("f2"));       //保留两位小数

            #endregion

            #endregion

            #region 07-文件操作IO
            //基础：
            //File              操作文件，静态类，对文件整体操作，拷贝，删除，剪切
            //Directory         操作目录（文件夹），静态类
            //FileInfo          文件类，用来描述文件对象（获取指定目录下所有文件时，返回一个FileInfo数组）
            //DirectoryInfo     文件夹的类，用来描述文件夹对象（获取指定目录下的所有目录时，返回一个DirectoryInfo数组）
            //Path              对文件或目录的路径进行操作，静态类
            //Stream            文件流，抽象类（流：把一个数据转存为一个字节数组，这个字节数组就是流）
            //      FileStream      文件流
            //      StreamReader    快速读取文本文件
            //      StreamWrite     快速写入文本文件

            #region 07.1-Path  操作路径

            //string filePath = @"D:\专业\网络中心\修改拓展名.doc.rar";
            //Console.WriteLine("文件路径：\n" + filePath);

            ////1.更改路径字符串的扩展名（本质是修改字符串，真正的文件拓展名不会被修改）
            //Console.WriteLine("\n1.==============" + Path.ChangeExtension(filePath, "txt"));

            ////2.返回指定路径字符串的目录信息
            //Console.WriteLine("\n2.==============" + Path.GetDirectoryName(filePath));

            ////3.返回指定的路径字符串的扩展名
            //Console.WriteLine("\n3.==============" + Path.GetExtension(filePath));

            ////4.返回指定路径字符串的文件名和扩展名(或文件夹名)
            //Console.WriteLine("\n4.==============" + Path.GetFileName(filePath));

            ////5.返回不具有扩展名的指定路径字符串的文件名
            //Console.WriteLine("\n5.==============" + Path.GetFileNameWithoutExtension(filePath));

            ////6.获取指定路径的根目录信息  
            //Console.WriteLine("\n6.==============" + Path.GetPathRoot(filePath));

            ////7.返回随机文件夹名或文件名
            //Console.WriteLine("\n7.==============" + Path.GetRandomFileName());

            ////8.创建磁盘上唯一命名的零字节的临时文件并返回该文件的完整路径
            //Console.WriteLine("\n8.==============" + Path.GetTempFileName());

            ////9.返回当前系统的临时文件夹的路径
            //Console.WriteLine("\n9.==============" + Path.GetTempPath());

            ////10.确定路径是否包括文件扩展名
            //Console.WriteLine("\n10.==============" + Path.HasExtension(filePath));

            ////11.获取一个值，指定的路径字符串是包含绝对路径信息为true，相对路径信息为false
            //Console.WriteLine("\n11.==============" + Path.IsPathRooted(filePath));

            ////12.链接两个路径字符串（自动判断有没有斜杠，没有则自动补上斜杠）
            //Console.WriteLine("\n12.==============" + Path.Combine(@"E:\Randy0528", @"中文目录\JustTest.rar"));

            ////13.判断文件路径是否存在
            //Console.WriteLine("\n13.==============" + Directory.Exists(filePath));

            ////14.获取绝对路径
            //Console.WriteLine("\n14.==============" + Path.GetFullPath(filePath));

            #endregion

            #region 07.2-Directory   操作文件夹(目录=文件夹)

            ////判断一个路径是否存在(只能判断文件夹是否存在，不会判断文件，即最后一个斜杠后还是文件夹)
            ////Directory.Exists();
            ////而File.Exists()验证文件是否存在

            ////读取指定目录下的所有子目录
            ////共有两个重载，第二参数为模糊查找的条件（遵循Windows通配符查找规则），第三参数为选择是否查找子目录
            //string[] dirs = Directory.GetDirectories(@"D:\专业\网络中心\指导视频\2.C#第一阶段-语法");
            //foreach (var str in dirs)
            //    Console.WriteLine(str);

            ////读取指定目录下的所有子文件
            ////重载与上面相似
            //Console.WriteLine("================================================================");
            //string[] files = Directory.GetFiles(@"D:\专业\网络中心");
            //foreach (var str in files)
            //    Console.WriteLine(str);


            ////删除指定文件夹：
            ////Directory.Delete(#)
            ////如果指定目录不存在，则运行时会报错
            ////所以删除，修改等指令常在  if(Directory.Exists(#)) 后使用
            ////即：
            //if (Directory.Exists(@"d:\sf\afda\sdfa")) 
            //    Directory.Delete(@"d:\sf\afda\sdfa");
            //else 
            //    Console.WriteLine("无该路径，请检查输入是否有误 ！");
            ////但是应注意，Directory.Delete(#)只能删除空的文件夹
            ////Directory.Delete("路径",true)，使用重载，第二参数为 “是否使用递归运算删除子文件和子文件夹”的bool值
            ////即：第二重载可以删除非空文件夹


            #region 查看路径是否存在，不存在则创建目录

            //string path = @"C:\Program Files\Microsoft.NET";
            //if (!Directory.Exists(path))
            //{
            //    Console.WriteLine("文件路径不存在!");
            //    // Directory.CreateDirectory(path);  //创建目录
            //}

            #endregion

            #endregion

            #region 07.3-File   操作文件

            //string filePath = @"D:\专业\网络中心\项目-C#\基础示例\1.3基础\bin\Debug\07.4-实例所示文件\修改文件名.doc";

            ////判断文件是否存在
            //bool b = File.Exists(filePath);
            //Console.WriteLine(b);

            ////拷贝文件--即复制粘贴到目标
            //File.Copy(@"D:\复制粘贴.doc", @"C:\复制粘贴.doc");

            ////创建文件
            //File.Create(@"D:\复制粘贴.doc");

            ////删除文件
            //File.Delete(@"D:\复制粘贴.doc");

            ////修改文件名（即移动=剪切文件）
            //string _filePath = Path.GetDirectoryName(filePath) + @"\_" + Path.GetFileName(filePath); ;
            //if (File.Exists(filePath))
            //{
            //    File.Move(filePath, _filePath);
            //    Console.WriteLine("已更名为“" + Path.GetFileName(_filePath) + "”");
            //}
            //else if (File.Exists(_filePath))
            //{
            //    File.Move(_filePath, filePath);
            //    Console.WriteLine("已更名为“" + Path.GetFileName(filePath) + "”");
            //}



            #region 数据写入/读取文件---
            //File.WriteAllLines()等函数是覆盖执行，即在指定路径创建新文件，写入数据
            //而File.AppendAllText()函数是将string类型数据追加到文本后面，即添加

            //string filepath = @"D:\专业\网络中心\项目-C#\基础示例\1.3基础\bin\Debug\07.4-实例所示文件\将数据写入文本.txt";

            ////以string行的形式写入文本
            //string[] msg1 = new string[] { "aaaaaaa", "bbbbbbb", "cccccccc" };
            //File.WriteAllLines(filepath, msg1);
            ////根据类型读取文本数据
            //string[] msg2 = File.ReadAllLines(filepath);
            //foreach (var item in msg2)
            //{
            //    Console.WriteLine(item);
            //}

            ////以byte类型数组的形式写入文本
            //string msg = "哈喽沃德你好世界Hello World、！！！";
            //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(msg);
            //File.WriteAllBytes(filepath, bytes);

            ////根据类型读取文本数据
            //msg = File.ReadAllText(filepath);
            //Console.WriteLine(msg);

            ////追加文本
            //string[] msg2 = new string[] { "aaaaaaa", "bbbbbbb", "cccccccc" };
            //File.AppendAllLines(filepath, msg2);

            #endregion

            #region 实战：  把csv文件中的联系人姓名和电话显示出来

            //string[] str1 = File.ReadAllLines(@"07.4-实例所示文件\Person.csv", Encoding.Default);
            //for (int i = 0; i < str1.Length; i++)
            //{
            //    string[] str2 = str1[i].Split(',');
            //    Console.WriteLine("姓名：{0}\t电话：{1}", str2[0] + str2[1], str2[2]);
            //}

            #endregion

            #endregion

            #region 07.4-FileStream     文件流

            #region 创建文件

            //string text = "二叉树定义：\n在计算机科学中，二叉树是每个节点最多有两个子树的树结构。通常子树被称作“左子树”（left subtree）和“右子树”（right subtree）。二叉树常被用于实现二叉查找树和二叉堆。";
            ////第一步、创建文件流
            //FileStream fs = new FileStream(@"D:\专业\网络中心\项目-C#\基础示例\1.3基础\bin\Debug\07.4-实例所示文件\文件流操作尝试.txt", FileMode.CreateNew);
            //byte[] b = Encoding.UTF8.GetBytes(text);
            ////第二步、读文件，写文件
            //fs.Write(b, 0, b.Length);
            ////第三步、释放相关资源（Dispose()方法中调用Close()方法和Flush()方法）
            ////清空缓冲区（一个byte数组）    fs.Flush();
            ////关闭文件流      fs.Close();
            //fs.Dispose();

            #region 通过使用using(){}语句，自动完成资源释放

            //string text = "二叉树定义：\n在计算机科学中，二叉树是每个节点最多有两个子树的树结构。通常子树被称作“左子树”（left subtree）和“右子树”（right subtree）。二叉树常被用于实现二叉查找树和二叉堆。";
            //using (FileStream fs = new FileStream(@"D:\专业\网络中心\项目-C#\基础示例\1.3基础\bin\Debug\07.4-实例所示文件\文件流操作尝试.txt", FileMode.CreateNew))
            //{
            //    byte[] b = Encoding.UTF8.GetBytes(text);
            //    fs.Write(b, 0, b.Length);
            //}

            #endregion

            #endregion

            #region 拷贝文件

            //Copy(@"07.4-实例所示文件\示例文件.avi", @"07.4-实例所示文件\拷贝件.avi", 4);

            #endregion

            #region 加密文件
            //实质就是，在使用文件流拷贝文件过程中，以任意方式，修改部分流的内容
            //而解密时，依据加密过程，复原为原文件

            //Encrypt(@"07.4-实例所示文件\04示例文件1.avi", @"07.4-实例所示文件\加密件.avi", 4);
            //Encrypt(@"07.4-实例所示文件\加密件.avi", @"07.4-实例所示文件\解密还原_示例文件.avi", 4);

            #endregion

            #region 针对于大文本文件的文件流    StreamRead与StreamWrite

            #region StreamWriter写入

            //string path = @"07.4-实例所示文件\07.4写入.text";
            //using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            //{
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        if (i % 10 == 0 && i != 0)
            //            sw.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            //        sw.WriteLine(i + "=========" + System.DateTime.Now.ToString());//显示当前时间
            //    }
            //}
            ////path = Path.GetDirectoryName(path);
            //System.Diagnostics.Process.Start(Path.GetFullPath(path));//获取绝对路径后，从文件资源管理器打开该文件位置

            #endregion

            #region StreamRead读取

            //string path = @"07.4-实例所示文件\07.4写入.text";
            //using (StreamReader sr = new StreamReader(Path.GetFullPath(path), Encoding.UTF8))
            //{
            //    ////方法一
            //    //int count = 0;
            //    //string line;
            //    //while ((line = sr.ReadLine()) != null)
            //    //{
            //    //    count++;
            //    //    Console.WriteLine(line);
            //    //}
            //    //Console.WriteLine(count);

            //    //方法二
            //    int count = 0;
            //    while (!sr.EndOfStream)
            //    {
            //        count++;
            //        string line = sr.ReadLine();
            //        Console.WriteLine(line);
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine(count);
            //}

            #endregion

            #region 读取+写入相结合为修改

            //string path = @"07.4-实例所示文件\07.4写入.text";
            //List<string> list = new List<string>();
            //using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            //{
            //    int count = 0;
            //    for (string line; !sr.EndOfStream; )
            //    {
            //        line = sr.ReadLine();
            //        Match mat = Regex.Match(line, @"\d+", RegexOptions.ECMAScript);
            //        if (mat.Success && mat.Index == 0)
            //        {
            //            int num = Convert.ToInt32(mat.Value) * 2;
            //            line = num.ToString() + line.Substring(mat.Length);
            //            count++;
            //        }
            //        list.Add(line);
            //    }
            //    Console.WriteLine("修改了" + count + "行");
            //}
            //using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            //{
            //    int count = 0;
            //    foreach (string line in list)
            //    {
            //        count++;
            //        sw.WriteLine(line);
            //    }
            //    Console.WriteLine("写入了" + count + "行");
            //}

            #endregion

            #endregion

            #endregion

            #endregion

            #region 08-反射

            #region 08.1-通过反射根据类名和方法名进行调用

            ////1.Load(命名空间名称)，GetType(命名空间.类名)  
            //Type type = Type.GetType("_1._3基础.Program");
            ////2.GetMethod(需要调用的方法名称)  
            //MethodInfo method = type.GetMethod("SayHello");
            ////3.调用的实例化方法（非静态方法）需要创建类型的一个实例  
            //object obj = Activator.CreateInstance(type);
            ////4.方法需要传入的参数  
            //object[] parameters = new object[] { };
            ////5.调用方法，如果调用的是一个静态方法，就不需要第3步（创建类型的实例）  
            ////  相应地调用静态方法时，Invoke的第一个参数为null  
            //method.Invoke(obj, parameters); 
            #endregion

            #region 08.2-通过反射获取类的属性

            ////第一步，获取属性 并 筛选
            ////获取 实体类 类型对象
            //Type t = Type.GetType("_1._3基础.ClaExa");
            ////获取 实体类 所有的 公有属性
            //List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            //Console.WriteLine("打印获取到的所有的公有属性：");
            //proInfos.ForEach(p => Console.WriteLine(p));
            ////创建 实体类的属性 字典集合
            //Dictionary<string, PropertyInfo> dictPros = new Dictionary<string, PropertyInfo>();
            ////将 实体属性 中药修改的属性名 添加到 字典集合中 （键：属性名，值：属性对象）
            //proInfos.ForEach(p =>
            //{
            //    if (p.Name.Contains("MyProperty1") || p.Name.Contains("MyProperty3"))
            //        dictPros.Add(p.Name, p);
            //});
            //Console.WriteLine("\n打印筛选后的结果：");
            //foreach (var item in dictPros)
            //{
            //    Console.WriteLine(item.Value + "\t" + item.Key);
            //}

            ////第二步，实例化对象并为属性赋值
            ////实例化对象
            //object obj = Activator.CreateInstance(t);
            ////给对象的属性赋值
            //dictPros["MyProperty1"].SetValue(obj, 11);
            ////取出该属性
            //Console.WriteLine("\n赋值结果：");
            //Console.WriteLine("obj.MyProperty1" + dictPros["MyProperty1"].GetValue(obj));

            #endregion




            #endregion

            #region 09-多线程-并发执行-线程锁

            //ParallelDemo pd = new ParallelDemo();
            //pd.ParallelInvokeMethod();


            #endregion

            #region 10-using的使用
            //using()创建或指定一个资源，在{***}中执行代码后，运行该资源类型中的Dispose()方法，该资源的类型在定义时必须实现IDisposable接口方法

            //using (person p =new person())
            //{
            //    //****
            //}

            //////等同于下面

            //person p=new person();
            //try
            //{
            //    //****
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //finally
            //{
            //    p.Dispose();
            //}

            #endregion

            #region 11-接口调用 WebClient

            ////地址
            //string url = @"http://api.hicc.cn/api/Tem_FSF/Update";
            //string url1 = @"http://api.hicc.cn/api/TStudentLogin/Login?Account=20154233047&pwd=20154233047";
            ////实例化
            //WebClient client = new WebClient();
            ////上传并接收数据
            //Byte[] responseData = client.DownloadData(url1);
            ////接收返回的json的流数据，并转码
            //string srcString = Encoding.UTF8.GetString(responseData);
            //Console.WriteLine(srcString);

            //var client = new RestClient("http://api.hicc.cn/token");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Postman-Token", "62dcf93f-74f2-6f27-6ded-b37aefaf9dc2");
            //request.AddHeader("Cache-Control", "no-cache");
            //request.AddParameter("undefined", "grant_type=client_credentials&client_id=StudentForest&client_secret=information12016921", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);

            #endregion

            #region 12-枚举

            //Console.WriteLine("通过枚举值获取枚举名：  " + Enum.GetName(typeof(MyEnum), 1));
            //Console.WriteLine("通过枚举名获取枚举值：  " + (int)MyEnum.asd1);

            #endregion

            #region 13-Json工具-序列化-反序列化

            #region 1.DataContractJsonSerializer方式序列化和反序列化
            //使用DataContractJsonSerializer方式需要引入的命名空间
            //在System.Runtime.Serialization.dll.中
            //using System.Runtime.Serialization.Json;


            //Student stu = new Student()
            //{
            //    ID = 1,
            //    Name = "曹操",
            //    Sex = "男",
            //    Age = 1000
            //};
            ////序列化
            //DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Student));
            //MemoryStream msObj = new MemoryStream();
            ////将序列化之后的Json格式数据写入流中
            //js.WriteObject(msObj, stu);
            //msObj.Position = 0;
            ////从0这个位置开始读取流中的数据
            //StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            //string json = sr.ReadToEnd();
            //sr.Close();
            //msObj.Close();
            //Console.WriteLine(json);


            ////反序列化
            //string toDes = "{\"ID\":\"1\",\"Name\":\"曹操\",\"Sex\":\"男\",\"Age\":\"1230\"}";
            //using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(toDes)))
            //{
            //    DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(Student));
            //    Student model = (Student)deseralizer.ReadObject(ms);// //反序列化ReadObject
            //    Console.WriteLine("ID=" + model.ID);
            //    Console.WriteLine("Name=" + model.Name);
            //    Console.WriteLine("Age=" + model.Age);
            //    Console.WriteLine("Sex=" + model.Sex);
            //}

            #endregion

            #region 2.JavaScriptSerializer方式实现序列化和反序列化
            //使用JavaScriptSerializer方式需要引入的命名空间
            //这个在程序集System.Web.Extensions.dll.中
            //using System.Web.Script.Serialization;

            //Student stu = new Student()
            //{
            //    ID = 1,
            //    Name = "关羽",
            //    Age = 2000,
            //    Sex = "男"
            //};

            //JavaScriptSerializer js = new JavaScriptSerializer();
            //string jsonData = js.Serialize(stu);//序列化
            //Console.WriteLine(jsonData);


            //////反序列化方式一：
            ////string desJson = jsonData;
            ////Student model = js.Deserialize<Student>(desJson);// //反序列化
            ////string message = string.Format("ID={0},Name={1},Age={2},Sex={3}", model.ID, model.Name, model.Age, model.Sex);
            ////Console.WriteLine(message);

            //////反序列化方式2
            //string desJson = jsonData;
            //dynamic modelDy = js.Deserialize<dynamic>(desJson); //反序列化
            //string messageDy = string.Format("动态的反序列化,ID={0},Name={1},Age={2},Sex={3}",
            //    modelDy["ID"], modelDy["Name"], modelDy["Age"], modelDy["Sex"]);//这里要使用索引取值，不能使用对象.属性
            //Console.WriteLine(messageDy);

            #endregion

            #region 3.Json.NET序列化
            //使用Json.NET类库需要引入的命名空间
            //using Newtonsoft.Json;

            //List<Student> lstStuModel = new List<Student>()
            //{
            //new Student(){ID=1,Name="张飞",Age=250,Sex="男"},
            //new Student(){ID=2,Name="潘金莲",Age=300,Sex="女"}
            //};

            ////Json.NET序列化
            //string jsonData = JsonConvert.SerializeObject(lstStuModel);
            //Console.WriteLine(jsonData);


            ////Json.NET反序列化
            //string json = @"{ 'Name':'C#','Age':'3000','ID':'1','Sex':'女'}";
            //Student descJsonStu = JsonConvert.DeserializeObject<Student>(json);//反序列化
            //Console.WriteLine(string.Format("反序列化： ID={0},Name={1},Sex={2},Sex={3}", descJsonStu.ID, descJsonStu.Name, descJsonStu.Age, descJsonStu.Sex));

            #endregion


            #endregion

            

            Console.WriteLine("\n\nok");
            Console.ReadKey();

        }
        #region 函数声明

        #region 03-参数修饰符

        #region 03.1-params可变参数修饰符

        static int Add131(int i1, int i2)
        {
            return i1 + i2;
        }
        static int Add131(int i1, int i2, int i3)
        {
            return i1 + i2 + i3;
        }
        //params关键字：参数修饰符-可变参数，可以使参数有无限多个，但是必须是同一类型
        //声明函数时，规定params修饰的参数是数组形式
        //使用params修饰参数的函数时，参数可以是普通变量也可以是数组变量
        //如果调用时不传参数，则i数组长度为0
        static int Add131(params int[] i)
        {
            int add = 0;
            for (int j = 0; j < i.Length; j++)
            {
                add += i[j];
            }
            return add;
        }

        #endregion

        #region 03.2-ref指针修饰符

        //ref修饰后，传的参数是变量的存储地址，和C语言的指针类似
        //因为传的是地址，所以在函数中的参数就是调用函数时的传参，这两个是同一个变量
        static void AddOne132(ref int i)
        {
            i++;
        }

        #endregion

        #region 03.3-out赋值修饰符

        //和ref指针原理、用法相似，out修饰后，不需要返回参数，直接根据变量的存储地址进行运算
        //可作为变量初始化函数
        //out主要用于函数有多个返回值的情况
        static void Assignment133(out int i)
        {
            i = 100;
        }
        static void Assignment133(out int i1, int i2)
        {
            i1 = i2 * 10;
        }


        #endregion

        #region 03.4-实例1-交换值

        static int Change134(int i1, ref int i2)
        {
            int i3 = i2;
            i2 = i1;
            return i3;
        }

        #endregion

        #region 03.5-实例2-模拟登陆

        static bool Judge135(string acc, string pas, out string resstr)
        {
            if (acc == "admin")
            {
                if (pas == "admin")
                {
                    resstr = "登陆成功！";
                    return true;
                }
                else
                {
                    resstr = "登陆失败，密码错误！";
                    return false;
                }
            }
            else
            {
                resstr = "登陆失败，无效用户！";
                return false;
            }
        }

        #endregion


        #endregion

        #region 07.3-File   操作文件    修改文件名

        public static bool ChangeName(string OldName)
        {
            try
            {
                if (File.Exists(OldName))
                {
                    File.Move(OldName, Path.GetDirectoryName(OldName) + @"\_" + Path.GetFileName(OldName));
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }
        }






        #endregion

        #region 07.4-FileStream     文件流     拷贝文件
        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="Path">源文件地址</param>
        /// <param name="NewPath">拷贝的目的地址</param>
        /// <param name="BufferSize">缓冲区大小（MB为单位）</param>
        private static void Copy(string OldPath, string NewPath, int BufferSize)
        {
            //第一步，创建一个读取源文件的文件流
            using (FileStream fsRead = new FileStream(OldPath, FileMode.Open, FileAccess.Read))
            {//FileStream fsRead = File.OpenRead(Path);达到同样功能
                //第二步，创建一个写入新文件的文件流
                using (FileStream fsWrite = new FileStream(NewPath, FileMode.Create, FileAccess.Write))
                {
                    //创建缓冲区
                    byte[] Buffer = new byte[1024 * 1024 * BufferSize];//缓冲区大小需要设置合理，要相对于拷贝的文件大小来设置其大小 

                    //第三步，通过fsRead读取源文件，然后在通过fsWrite写入新文件
                    //读
                    int byteCount = fsRead.Read(Buffer, 0, Buffer.Length);//返回值为实际读取到的字节个数

                    //需要循环执行读写操作
                    while (byteCount > 0)
                    {
                        //写
                        fsWrite.Write(Buffer, 0, byteCount);

                        //进度显示
                        double ProgressLength = fsRead.Position * 1.0 / fsRead.Length;
                        Console.WriteLine("已经拷贝了：{0}%", (int)(ProgressLength * 100));
                        //在FileStream类中，有一个Position属性，自动记录上次的位置，所以不需要我们考虑衔接的问题

                        //读
                        byteCount = fsRead.Read(Buffer, 0, Buffer.Length);
                    }
                }
            }
        }

        #endregion

        #region 07.4-FileStream     文件流     加密文件

        /// <summary>
        /// 加密文件
        /// </summary>
        /// <param name="OldPath">源文件地址</param>
        /// <param name="NewPath">加密的目的地址</param>
        /// <param name="BufferSize">缓冲区大小（MB为单位）</param>
        private static void Encrypt(string OldPath, string NewPath, int BufferSize)
        {
            //第一步，创建一个读取源文件的文件流
            using (FileStream fsRead = new FileStream(OldPath, FileMode.Open, FileAccess.Read))
            {
                //第二步，创建一个写入新文件的文件流
                using (FileStream fsWrite = new FileStream(NewPath, FileMode.Create, FileAccess.Write))
                {
                    //创建缓冲区
                    byte[] Buffer = new byte[1024 * 1024 * BufferSize];//缓冲区大小需要设置合理，要相对于拷贝的文件大小来设置其大小 

                    //第三步，通过fsRead读取源文件，然后在通过fsWrite写入新文件
                    //读
                    int byteCount = fsRead.Read(Buffer, 0, Buffer.Length);//返回值为实际读取到的字节个数

                    //需要循环执行读写操作
                    while (byteCount > 0)
                    {
                        //=================================加密=================================
                        for (int i = 0; i < Buffer.Length; i += Buffer.Length / 1024)
                        {
                            Buffer[i] = (byte)(byte.MaxValue - Buffer[i]);
                        }
                        //=================================加密=================================

                        //写
                        fsWrite.Write(Buffer, 0, byteCount);

                        //进度显示
                        double ProgressLength = fsRead.Position * 1.0 / fsRead.Length;
                        Console.WriteLine("已经加密了：{0}%", (int)(ProgressLength * 100));
                        //在FileStream类中，有一个Position属性，自动记录上次的位置，所以不需要我们考虑衔接的问题

                        //读
                        byteCount = fsRead.Read(Buffer, 0, Buffer.Length);
                    }
                }
            }
        }



        #endregion

        #region 08-反射的函数
        public void SayHello()
        {
            Console.WriteLine("hello");
        }

        #endregion

        #endregion
    }

}
