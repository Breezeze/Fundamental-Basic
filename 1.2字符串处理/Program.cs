using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1._2字符串处理
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 一、多种函数使用方法

            #region 01-字符串和字符数组之间转化---ToCharArray()--new string()

            ////字符串具有不可更改性，所以想要改变字符串中间的某个字符，可以通过这种方法：
            ////字符串→字符数组→字符串
            ////与08不同之处：
            ////08是将字符串以匹配值分割成字符串数组，不含有匹配值，可以理解为全文替换
            ////01是修改单个字符
            //Console.WriteLine("01-字符串和字符数组之间转化：");
            //string str1 = "哈ha123";
            //Console.WriteLine(str1);
            //char[] char1 = str1.ToCharArray();  //字符串转化为字符数组
            //for (int i = 0; i < char1.Length; i++)
            //{
            //    Console.Write(char1[i] + "  ");
            //}
            //Console.WriteLine();
            //char1[1] = '哈';
            //string str2 = new string(char1);    //字符数组转化为字符串
            //Console.WriteLine(str2);
            //Console.WriteLine();

            #endregion

            #region 02-大小写转化---ToLower()--ToUpper()

            //Console.WriteLine("02-大小写转化：");
            //string str1 = "FengShi";
            //string str2 = str1.ToLower();
            //string str3 = str1.ToUpper();
            //Console.WriteLine("str1=\"{0}\",str1.ToLower()=\"{1}\",str1.ToUpper()=\"{2}\"", str1, str2, str3);
            //Console.WriteLine();

            #endregion

            #region 03-比较两个字符串是否完全相同---Equals()

            //Console.WriteLine("03-比较两个字符串是否完全相同：");
            //string str1 = "abc";
            //string str2 = "ABC";
            //if (str1.Equals(str2))      //str1 == str2
            //{
            //    Console.WriteLine("str1和str2相同");
            //}
            //else
            //{
            //    Console.WriteLine("不相同");
            //}
            //Console.WriteLine();

            #endregion

            #region 04-查找---IndexOf()--Regex.Match()--正则表达式

            #region 04.1-匹配的字符或者字符串的位置--IndexOf()--LastIndexOf()

            //Console.WriteLine("04.1查找匹配的字符或者字符串的位置：");
            //string str1 = "哈哈哈，小明在第5位，中间的小明在第15位，最后的小明在26位！";
            //int index1 = str1.IndexOf("小明");
            //int index2 = str1.LastIndexOf("小明");
            //Console.WriteLine("字符串是：" + str1);
            //Console.WriteLine("小明第一次出现在{0}位，最后一次出现在{1}位，因为数组角标从0开始。", index1, index2);
            //Console.WriteLine(); 

            #endregion

            #region  04.2-查找-提取匹配的（符合要求的）字符串--Regex.Match()

            ////这种方法是找符合要求的，比如要求是数字
            ////而1.41是寻找特定的字符或者字符串在该字符串中的位置

            //Console.WriteLine("04.2 通过Match()和Matches()提取匹配的字符串：");
            //string str1 = "今天是2016年8月10日16:27:49";

            ////单个提取
            ////调用IsMatch()时要判断完全匹配，关键词用^$开始结束
            ////Regex.Match()括号内：(字符串名，@+"所要匹配项"，方法)
            ////\d表示一个数字，\d+表示第一个数字在内的整串数字
            //Console.WriteLine("04-单个提取:");
            //Match mat1 = Regex.Match(str1, @"\d+", RegexOptions.ECMAScript);
            //Console.WriteLine(mat1.Value);
            //Console.WriteLine();

            ////提取所有
            //Console.WriteLine("04-提取所有:");
            //MatchCollection mat2 = Regex.Matches(str1, @"\d+", RegexOptions.ECMAScript);
            ////for循环输出
            //for (int i = 0; i < mat2.Count; i++)     //matchcollection.Count所匹配项的数量
            //{
            //    Console.Write(mat2[i].Value + "  ");
            //}
            //Console.WriteLine();
            //Console.WriteLine();

            ////逐个提取
            //Console.WriteLine("04-逐个提取:");
            //Regex reg1 = new Regex(@"\d+", RegexOptions.ECMAScript);
            //Match mat3 = reg1.Match(str1);
            //Console.WriteLine(mat3.Value);
            //for (int i = 0; mat3.Value.Length != 0; i++)
            //{                       //mat.Index 上次匹配第一个字符的位置
            //    mat3 = reg1.Match(str1, mat3.Index + mat3.Value.Length);     //加上mat.Value.Length   使得从匹配字符之后开始重新匹配
            //    Console.WriteLine(mat3.Value);
            //}
            //Console.WriteLine();

            #endregion

            #region 04.3正则表达式
            /*
            电子邮件：[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)+$
            或者：w+([-+.]w+)*@w+([-.]w+)*.w+([-.]w+)*
            匹配中文字符的正则表达式： [u4e00-u9fa5]
            匹配双字节字符(包括汉字在内)：[^x00-xff]
            匹配空行的正则表达式：n[s| ]*r
            匹配HTML标记的正则表达式：/<(.*)>.*|<(.*) />/
            匹配首尾空格的正则表达式：(^s*)|(s*$)
            匹配ip地址：\d+\.\d+\.\d+\.\d+
            匹配网址URL的正则表达式：^[a-zA-z]+://(w+(-w+)*)(.(w+(-w+)*))*(?S*)?$
            匹配帐号是否合法(字母开头，允许5-16字节，允许字母数字下划线)：^[a-zA-Z][a-zA-Z0-9_]{4,15}$
            匹配国内电话号码：(d{3}-|d{4}-)?(d{8}|d{7})?
            匹配身份证：\d{15}|\d{18}
            匹配腾讯QQ号：^[1-9]*[1-9][0-9]*$
            匹配一个普通的网址（不含 ? & 等符号的网址）: /http://\f*


            下表是元字符及其在正则表达式上下文中的行为的一个完整列表： 

            \ 将下一个字符标记为一个特殊字符、或一个原义字符、或一个后向引用、或一个八进制转义符。
            ^ 匹配输入字符串的开始位置。如果设置了 RegExp 对象的Multiline 属性，^ 也匹配 ’\n’ 或 ’\r’ 之后的位置。 
            $ 匹配输入字符串的结束位置。如果设置了 RegExp 对象的Multiline 属性，$ 也匹配 ’\n’ 或 ’\r’ 之前的位置。 
            * 匹配前面的子表达式零次或多次。 
            + 匹配前面的子表达式一次或多次。+ 等价于 {1,}。 
            ? 匹配前面的子表达式零次或一次。? 等价于 {0,1}。
            
            {n} n 是一个非负整数，匹配确定的n 次。
            {n,} n 是一个非负整数，至少匹配n 次。 
            {n,m} m 和 n 均为非负整数，其中n <= m。最少匹配 n 次且最多匹配 m 次。在逗号和两个数之间不能有空格。
            ? 当该字符紧跟在任何一个其他限制符 (*, +, ?, {n}, {n,}, {n,m}) 后面时，匹配模式是非贪婪的。非贪婪模式尽可能少的匹配所搜索的字符串，而默认的贪婪模式则尽可能多的匹配所搜索的字符串。 
            . 匹配除 "\n" 之外的任何单个字符。要匹配包括 ’\n’ 在内的任何字符，请使用象 ’[.\n]’ 的模式。 
            (pattern) 匹配pattern 并获取这一匹配。 
            (?:pattern) 匹配pattern 但不获取匹配结果，也就是说这是一个非获取匹配，不进行存储供以后使用。 
            (?=pattern) 正向预查，在任何匹配 pattern 的字符串开始处匹配查找字符串。这是一个非获取匹配，也就是说，该匹配不需要获取供以后使用。 
            (?!pattern) 负向预查，与(?=pattern)作用相反 
            x|y 匹配 x 或 y。 
            
            [xyz] 字符集合。 
            [^xyz] 负值字符集合。 
            [a-z] 字符范围，匹配指定范围内的任意字符。 
            [^a-z] 负值字符范围，匹配任何不在指定范围内的任意字符。 
            \b 匹配一个单词边界，也就是指单词和空格间的位置。
            \B 匹配非单词边界。 
            \cx 匹配由x指明的控制字符。 
            \d 匹配一个数字字符。等价于 [0-9]。 
            \D 匹配一个非数字字符。等价于 [^0-9]。 
            \f 匹配一个换页符。等价于 \x0c 和 \cL。 
            \n 匹配一个换行符。等价于 \x0a 和 \cJ。 
            \r 匹配一个回车符。等价于 \x0d 和 \cM。 
            \s 匹配任何空白字符，包括空格、制表符、换页符等等。等价于[ \f\n\r\t\v]。 
            \S 匹配任何非空白字符。等价于 [^ \f\n\r\t\v]。 
            \t 匹配一个制表符。等价于 \x09 和 \cI。 
            \v 匹配一个垂直制表符。等价于 \x0b 和 \cK。 
            \w 匹配包括下划线的任何单词字符。等价于’[A-Za-z0-9_]’。 
            \W 匹配任何非单词字符。等价于 ’[^A-Za-z0-9_]’。 
            \xn 匹配 n，其中 n 为十六进制转义值。十六进制转义值必须为确定的两个数字长。
            \num 匹配 num，其中num是一个正整数。对所获取的匹配的引用。 
            \n 标识一个八进制转义值或一个后向引用。如果 \n 之前至少 n 个获取的子表达式，则 n 为后向引用。否则，如果 n 为八进制数字 (0-7)，则 n 为一个八进制转义值。 
            \nm 标识一个八进制转义值或一个后向引用。如果 \nm 之前至少有is preceded by at least nm 个获取得子表达式，则 nm 为后向引用。如果 \nm 之前至少有 n 个获取，则 n 为一个后跟文字 m 的后向引用。如果前面的条件都不满足，若 n 和 m 均为八进制数字 (0-7)，则 \nm 将匹配八进制转义值 nm。 
            \nml 如果 n 为八进制数字 (0-3)，且 m 和 l 均为八进制数字 (0-7)，则匹配八进制转义值 nml。 
            \un 匹配 n，其中 n 是一个用四个十六进制数字表示的Unicode字符。  

            */

            #endregion



            #endregion

            #region 05-截取字符串---Substring()

            //Console.WriteLine("05-截取字符串：");
            //string str1 = "听说过冯时吗？";
            ////Substring(#,*) 从字符串的第#+1位向后截取*个字符
            //string str1 = str1.Substring(3, 2);
            //Console.WriteLine(str1);
            //Console.WriteLine(str1 + "，是谁？");
            //Console.WriteLine();

            #endregion

            #region 06-判断是否为空函数---string.IsNullOrEmpty()

            ////函数判断是否为空字符串或者null，返回bool值，非空返回false
            //Console.WriteLine("06-判断是否为空函数：");
            //string str1 = "哈哈哈哈~~~";
            ////换行：\n
            //if (!string.IsNullOrEmpty(str1))
            //    Console.WriteLine("字符串str161“{0}”不是空字符串或者null，长度为{1}\nstring.IsNullOrEmpty(str1)={2}", str1, str1.Length, string.IsNullOrEmpty(str1));
            //else
            //    Console.WriteLine("字符串str161“{0}”为空字符串或者null，长度为{1}\nstring.IsNullOrEmpty(str1)={2}", str1, str1.Length, string.IsNullOrEmpty(str1));
            //Console.WriteLine();

            #endregion

            #region 07-替换---Replace()

            //Console.WriteLine("07-替换：");
            //string str1 = "劳资怎么宗打挫字，也是负了！";
            //string str2 = str1.Replace("劳资", "老子").Replace("宗", "总").Replace("打挫", "打错").Replace("负了", "服了");
            //Console.WriteLine("原字符串：      " + str1);
            //Console.WriteLine("替换后的字符串：" + str2);
            //Console.WriteLine();


            #endregion

            #region 08-分割---Split()

            //Console.WriteLine("1.8分割和连接：");
            //string str1 = "小明，小李，小丽，，，小红，，";
            //Console.WriteLine("初始字符串str1：\t" + str1);

            ////Split()把字符串根据括号内的字符分割成数组
            //string[] str2 = str1.Split('，');
            //Console.WriteLine("\n分割后的字符串：");
            //for (int i = 0; i < str2.Length; i++)
            //    Console.Write("str2[{0}]={1}\t", i, str2[i]);


            ////当运用函数时，不知道参数是什么时，可以选到要使用的重载后，Ctrl+J，自动转到所需参数的下拉框
            //Console.WriteLine("\n使用Split()的第4个重载（不返回空字符串）时，所得到的：");
            //string[] str3 = str1.Split(new char[] { '，' }, StringSplitOptions.RemoveEmptyEntries);
            //for (int i = 0; i < str3.Length; i++)
            //    Console.Write("str3[" + i + "]=" + str3[i] + "\t");


            //Console.WriteLine("\n\n使用Split()的第6个重载（指定从第一个开始，最大返回子字符串的个数）时，所得到的：");
            //string[] str4 = str1.Split(new char[] { '，' }, 3, StringSplitOptions.RemoveEmptyEntries);
            //for (int i = 0; i < str4.Length; i++)
            //    Console.Write("str4[" + i + "]=" + str4[i] + "\t");  //此时，最后一个字符串是剩下的全部父字符串
            //Console.WriteLine("\n");

            #endregion

            #region 09-字符串拼接---Format()--Join()--StringBuilder

            #region 09.1-输出时拼接---Format()

            ////和Console.WriteLine相似的语法
            //Console.WriteLine("09字符串拼接：");
            //string str1 = "小明";
            //string str2 = string.Format("我叫{0}，今年{1}岁了，现在在上{2}。", str1, 19, "大学");
            //Console.WriteLine(str2); 

            #endregion

            #region 09.2-通过字符或字符串拼接多个字符串---Join()

            ////把数组的每个元素用括号内字符或字符串连接
            //string[] str1 = "小明，小李，小丽，，，小红，，".Split(',');    //使用1.8中的Split()方法分割字符串，此时str1是字符串数组
            //string str2 = string.Join("_", str1);
            //Console.WriteLine("\n\n使用string.Join(\"_\", str182)替换后的字符串：\n" + str2);

            #endregion

            #region 09.3-极长字符串的拼接---StringBuilder--Stopwatch
            //StringBuilder对长字符串处理快，是因为他每次都是修改同一块内存的值，不会重复创建大量对象，也不会产生垃圾内存
            //所以它大大提高了字符串拼接的效率，但是对于短字符串可能比普通方法要慢


            ////建立目标字符串，建立检测运行时间的Stopwatch类型变量
            //string str1 = "打南边来了个喇嘛，手里提拉着五斤鳎目，打北边来了个哑巴，腰里别着个喇叭。南边提拉鳎目的喇嘛，要拿鳎目换北边儿别喇叭的哑巴的喇叭，哑巴不乐意拿喇叭换提拉鳎目的喇嘛的鳎目，喇嘛非要拿鳎目换别喇叭的哑巴的喇叭。喇嘛抡起鳎目抽了别喇叭的哑巴一鳎目，哑巴摘下喇叭打了提拉鳎目的喇嘛一喇叭，也不知是提拉鳎目的喇嘛抽了别喇叭的哑巴几鳎目，还是别喇叭的哑巴打了提拉鳎目的喇嘛几喇叭。只知道，喇嘛炖鳎目，哑巴嘀嘀嗒嗒吹喇叭。";
            //for (int i = 0; i < 10; i++)
            //{
            //    str1 += str1;
            //}
            //string[] str2 = str1.Split(new char[] { '，', '。' }, StringSplitOptions.RemoveEmptyEntries);
            //Stopwatch watch = new Stopwatch();
            ////原始方法
            //watch.Start();
            //string str3 = string.Empty;//空字符串
            //for (int i = 0; i < str2.Length; i++)
            //{
            //    str3 += str2[i] + "    ";
            //}
            //watch.Stop();
            //Console.WriteLine("笨拙方法用时：" + watch.Elapsed);
            ////使用StringBuilder
            //watch.Restart();
            //StringBuilder str4 = new StringBuilder();
            //for (int i = 0; i < str2.Length; i++)
            //{
            //    str4.Append(str2[i] + "    ");
            //}
            //watch.Stop();
            //Console.WriteLine("使用StringBuilder用时：" + watch.Elapsed);  //StringBuilder是一个工具，并不是真正的string类型

            #endregion

            #endregion

            #region 10-判断开头字符

            //string str1 = "张大仙";
            //if (str1.StartsWith("张"))
            //{
            //    Console.WriteLine("{0}姓张", str1);
            //}
            //else
            //{
            //    Console.WriteLine("{0}不姓张", str1);
            //}

            #endregion

            #region 11-去除开头结尾的空白字符---.Trim()

            //string str1 = "    哈哈哈哈哈~~~~      ";
            //string str2 = str1.Trim();
            //Console.WriteLine("str1是：（" + str1 + "）");
            //Console.WriteLine("修改后：（" + str2 + "）");
            #endregion

            #region 12-汉字转化为拼音

            //Console.WriteLine("请输入汉字：");
            //string userInput = Console.ReadLine();
            //Console.WriteLine(GetPinYin(userInput));

            #endregion



            #endregion



            #region 二、实战

            #region 01-把csv文件中的联系人姓名和电话显示出来

            //string[] str1 = File.ReadAllLines("Person.csv", Encoding.Default);
            //for (int i = 0; i < str1.Length; i++)
            //{
            //    string[] str2 = str1[i].Split(',');
            //    Console.WriteLine("姓名：{0}\t电话：{1}", str2[0] + str2[1], str2[2]);
            //}

            #endregion

            #region 02-分解日期--Split()的依次分割

            //Console.WriteLine("Split()的依次分割");
            //Console.WriteLine("请输入日期(年-月-日)");
            //string str1 = Console.ReadLine();
            //string[] str2 = str1.Split(new char[] { '年', '月', '日' });
            //Console.WriteLine("分解为：\n年：{0}\n月：{1}\n日：{2}\n\n", str2[0], str2[1], str2[2]);

            #endregion

            #region 03-从文件路径中提取文件名，包含后缀

            ////在字符串前加@，可以取消字符串内部编译过程
            //string str1 = "C:\a\b.text";      // \a为电脑响起提示声
            //Console.WriteLine(str1);
            //string str2 = @"C:\a\b.text";
            //Console.WriteLine(str2);
            ////效率很低
            //int index1 = str2.LastIndexOf('\\');
            //string str3 = str2.Substring(index1 + 1);
            //Console.WriteLine("文件名为" + str3);
            ////微软提供了实现这个功能的方法
            //string str4 = Path.GetFileName(str2);
            //Console.WriteLine("文件名为" + str4);

            #endregion

            #region 04-从“192.168.10.5[port=21,type=ftp]”中读取IP、Port、Servise

            ////这个字符串表示IP地址是192.168.10.5的服务器的21端口提供的是ftp服务，如果type省略，代表默认为http服务
            //string str1 = "192.168.10.5[port=21,type=ftp]";
            //string[] str2 = str1.Split(new string[] { "[port=", ",type=", "]" }, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine("第一个：\nIP：{0}\nPort：{1}\nService：{2}", str2[0], str2[1], str2[2]);

            //string str3 = "192.168.10.5[port=23]";
            //string[] str4 = str3.Split(new string[] { "[port=", ",type=", "]" }, StringSplitOptions.RemoveEmptyEntries);
            ////通过判断式来决定输出的是默认值“http”还是上面标注的内容
            //Console.WriteLine("\n第二个：\nIP：{0}\nPort：{1}\nService：{2}", str4[0], str4[1], str4.Length == 3 ? str4[2] : "http");

            #endregion


















            #endregion



            Console.ReadKey();
        }
        #region 函数声明

        private static string GetPinYin(string userInput)
        {
            StringBuilder sbPY = new StringBuilder();
            foreach (char itemC in userInput)
            {
                if (ChineseChar.IsValidChar(itemC))
                {
                    ChineseChar CC = new ChineseChar(itemC);
                    sbPY.Append(CC.Pinyins[0].Substring(0, CC.Pinyins[0].Length - 1).ToLower());
                }
            }
            return sbPY.ToString();
        }
        #endregion

    }
}
