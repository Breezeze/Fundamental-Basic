using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1第一阶段
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 2.11类的创建引用及静态类

            #region 类的创建和运用

            ////使用内部class
            //Person2111 p2111 = new Person2111();
            //p2111.Name = "Name1";
            //p2111.Age = 1;
            //p2111.Height = 111;
            //Console.WriteLine("对象名\tName\tAge\tHeight\tEmail\tcs");
            //Console.WriteLine("p2111\t{0}\t{1}\t{2}", p2111.Name, p2111.Age, p2111.Height);
            //Console.WriteLine();

            ////使用构造函数初始化
            //Person2112 p2112 = new Person2112("Name2", 2, "222");
            //Console.WriteLine("p2112\t{0}\t{1}\t{2}\t{3}\t{4}", p2112.Name, p2112.Age, p2112.Height, p2112.Email, Person2112.cs);//静态成员的调用
            //Console.WriteLine();
            ////不一样的参数类型会导致使用不同的构造函数
            //Person2112 p2113 = new Person2112("Name3", 3, 333);
            //Console.WriteLine("p2113\t{0}\t{1}\t{2}\t{3}\t{4}", p2113.Name, p2113.Age, p2113.Height, p2113.Email, Person2112.cs);
            //Console.WriteLine();
            ////通过传实例初始化对象的构造函数
            //Person2112 p2114 = new Person2112("Name4", 4, 444, "444");
            //Person2112 p2115 = new Person2112(p2114);
            //Console.WriteLine("p2115\t{0}\t{1}\t{2}\t{3}\t{4}", p2115.Name, p2115.Age, p2115.Height, p2115.Email, Person2112.cs);


            #endregion

            #region 静态static
            //如果取消注释，上面的代码也要取消注释

            //静态类：
            //静态类只能有静态成员，不能有实例成员，即都要有static，且无法被继承（静态与多态相对应），无法实例化
            //使用静态类无法创建对象，应直接通过类名来操作成员，可在静态类中设置多种方法，直接调用（Console.WriteLine()就是静态类中的方法）
            //静态成员：
            //只能通过类名加“.”调用
            //类中的静态成员只会被分配一个内存单元，所以由同一个类定义的不同实例对象中一个静态属性的值是相同的
            //什么时候使用静态类?
            //整个程序需要共享一些数据的时候

            //Console.WriteLine("请输入Person2.cs的值");
            //Person2112.cs = Convert.ToString(Console.ReadLine());

            //Console.WriteLine("p2112\t{0}\t{1}\t{2}\t{3}\t{4}", p2112.Name, p2112.Age, p2112.Height, p2112.Email, Person2112.cs);
            //Console.WriteLine("p2113\t{0}\t{1}\t{2}\t{3}\t{4}", p2113.Name, p2113.Age, p2113.Height, p2113.Email, Person2112.cs);
            //Console.WriteLine("p2114\t{0}\t{1}\t{2}\t{3}\t{4}", p2115.Name, p2115.Age, p2115.Height, p2115.Email, Person2112.cs);
            //Console.WriteLine();

            //StaticPerson211.Name = "123456789";
            //Console.WriteLine(StaticPerson211.Name);
            //StaticPerson211.Sayhi();


            #endregion

            #endregion

            #region 2.12类的索引器
            //索引器就是，在对象的后面可以用类似数组角标的形式（class[0]）来调用对象中的属性

            //Index212 a212 = new Index212();
            //for (int i = 0; i < a212.Length; i++)
            //{
            //    Console.WriteLine(a212[i]);
            //}
            //Index212[] b212 = new Index212[3];
            //Console.WriteLine(b212[2]); 


            #endregion

            #region 2.13类的封装
            //封装就是将一段代码整理压缩，使调用其代码时可以只使用一句代码

            ////运用Class封装和索引器提取数字各位上的数
            //Console.WriteLine("请输入一个数字");
            ////使用构造函数
            //ClassPackaging213 a213 = new ClassPackaging213(Convert.ToInt32(Console.ReadLine()));
            //Console.WriteLine("数字{5}的个位为{0}，十位为{1}，百位为{2}，千位为{3}，共{4}位。", a213[1], a213[2], a213[3], a213[4], a213.Length, a213.Num);

            #endregion

            #region 2.14类的继承

            //Student214 stu2141 = new Student214("冯时", 20, "男", 20154233047);
            //Teacher214 tea2141 = new Teacher214("冯老师", 40, "男", 100000);
            //Console.WriteLine("{0},{1},{2},{3}", stu2141.Name, stu2141.Age, stu2141.Gender, stu2141.SNo);
            //Console.WriteLine("{0},{1},{2},{3}", tea2141.Name, tea2141.Age, tea2141.Gender, tea2141.Salary + "元");

            ////类可以定义数组
            //Person214[] per214 = new Person214[3];
            //Person214 p2141 = new Person214("冯时", 20, "男");
            //Person214 p2142 = new Person214("冯老师", 40, "男");
            //Person214 p2143 = new Person214("冯小时", 10, "男");
            //per214[0] = p2141;
            //per214[1] = p2142;
            //per214[2] = p2143;
            //Console.WriteLine("{0},{1},{2}", per214[0].Name, per214[0].Age, per214[0].Gender);
            //Console.WriteLine("{0},{1},{2}", per214[1].Name, per214[1].Age, per214[1].Gender);
            //Console.WriteLine("{0},{1},{2}", per214[2].Name, per214[2].Age, per214[2].Gender); 


            #endregion

            #region 2.15访问修饰符
            //C#中的访问修饰符
            //public        公有的，任何情况都可以访问到  
            //private       私有的，只能在当前类的内部访问到（如果不写访问修饰符，默认为private）——（钥匙图标）
            //protected     可继承的，在当前类内部可以访问，在子类内部也可以访问到
            //internal      当前程序集内部可以访问，即一个项目，而一个解决方案中的不同项目不可以访问（在控制台文件中指生成的一个exe文件内）——（信封图标）
            //protected internal    当前类内部，所有子类内部，当前程序集内部都可以访问


            //定义类时，类的默认访问修饰符为public
            //测试可不可以被“.”出来
            //aaa215 a215 = new aaa215();
            //a215.Internal = 0;
            //a215.Public = 0;

            //bbb215 b215 = new bbb215();
            //b215.Internal = 0;
            //b215.Public = 0; 


            #endregion

            #region 2.16多态-虚方法
            //多态：不同对象收到相同调用/参数时，会有不同行为（同一个类在不同场合下表现出不同的行为特征）
            //多态与静态相对
            //多态的作用：把不同的子类对象都当做父类使用，可以屏蔽不同子类对象的差异，写出通用的代码，做出通用的程序，以适用需求的不同变化
            #region 里氏替换来实现不同的函数调用

            //Person216[] p216 = new Person216[7];     //建立类数组
            //p216[0] = new Chinese216();              //因为Chinese类继承Person类，父子关系，所以可以这样定义/初始化（里氏替换原则）
            //p216[0].Type = "人";
            //p216[1] = new American216();
            //p216[1].Type = "牛";
            //p216[2] = new American216();
            //p216[2].Type = "羊";
            //p216[3] = new Japanese216();
            //p216[3].Type = "狗";
            //p216[4] = new Chinese216();
            //p216[4].Type = "马";
            //p216[5] = new British216();
            //p216[5].Type = "虎";
            //p216[6] = new Person216();
            //for (int i = 0; i < p216.Length; i++)
            //{
            //    p216[i].show();
            //    Console.WriteLine(p216[i].Type);
            //}

            #endregion

            #region 对象的类型转换

            //两种方法：
            Person2161 a216 = new Chinese2161();
            //一、转换之前进行判断
            if (a216 is Chinese2161)
            { Chinese2161 b216 = (Chinese2161)a216; }
            //二、使用as（成功的话赋值，失败赋值NULL，不报异常）
            Chinese2161 c216 = a216 as Chinese2161;


            #endregion

            #region 实例：重写Shape类求面积和周长

            ////如果用父类Shape216定义后new子类，无法使用子类的属性
            ////即：
            ////Rectangle216 re216 = new Rectangle216(4);
            ////re216.Squares报错
            //Shape216 re216 = new Rectangle216(4);
            //Console.WriteLine("正方形周长为：{0}，面积为：{1}。", re216.Perimeter(), re216.Acreage());
            //Shape216 sq216 = new Square216(4, 2);
            //Console.WriteLine("长方形周长为：{0}，面积为：{1}。", sq216.Perimeter(), sq216.Acreage());
            //Shape216 ci216 = new Circle216(4);
            //Console.WriteLine("圆周长为：{0}，面积为：{1}。", ci216.Perimeter(), ci216.Acreage());


            #endregion

            #region 实例：登记

            ////调用函数,传的参数是子类对象，调用这个对象的Introduce方法
            //Dengji.dengji(new Chinese2162());
            //Dengji.dengji(new American2162());
            //Dengji.dengji(new British2162());

            #endregion

            #endregion

            #region 2.17多态-抽象类
            //抽象类特点
            //抽象成员必须写在抽象类中
            //抽象类中可以有实例成员
            //所有成员访问修饰符都不能是private
            //不能被实例化，即不能被new对象，只能通过其他类继承抽象类来实现多态
            //抽象类的子类必须override重写所有成员，除非子类也是抽象类
            //抽象类的存在意义就是为了子类继承后实现多态
            //=====================================
            //抽象类和虚方法的差别：
            //虚方法可以被实例化，在正常的方法前加了virtual，允许其子类重写
            #region 建立类数组

            //Person217[] p217 = new Person217[6];     //建立类数组
            //p217[0] = new Chinese217();           //因为Chinese类继承Person类，父子关系，所以可以这样定义/初始化（里氏替换原则）
            //p217[1] = new American217();
            //p217[2] = new American217();
            //p217[3] = new Japanese217();
            //p217[4] = new Chinese217();
            //p217[5] = new British217();
            //for (int i = 0; i < p217.Length; i++)
            //{
            //    p217[i].Show();
            //}
            //Console.WriteLine();


            #endregion

            #region 实例：重写Shape类求面积和周长

            ////声明时略有不同，因为抽象类不能被实例化
            //Rectangle217 re217 = new Rectangle217(4);
            //Console.WriteLine("边长为{0}的正方形，周长为：{1}，面积为：{2}。", re217.Squares, re217.Perimeter(), re217.Acreage());
            //Square217 sq217 = new Square217(4, 2);
            //Console.WriteLine("长度{0}，宽度{1}的长方形，周长为：{2}，面积为：{3}。", sq217.Lenth, sq217.Width, sq217.Perimeter(), sq217.Acreage());
            //Circle217 ci217 = new Circle217(4);
            //Console.WriteLine("半径为{0}的圆，周长为：{1}，面积为：{2}。", ci217.Radii, ci217.Perimeter(), ci217.Acreage());
            //Console.WriteLine();


            #endregion

            #endregion
            

            Console.ReadKey();

        }
    }

    #region 2.11类的引用

    class Person2111
    {
        //当代码语句下方出现一个字符长度的下划线时，Alt+Shift+F10显示菜单

        //通过私有成员即内部变量间接控制类的属性
        //写完内部变量的定义后可直接Ctrl+R+E来封装
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private int height;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        //通过构造函数初始类成员
        public Person2111() { }
        public Person2111(string n)   //构造函数可以重载，多次定义，但是需要不同的传参
        {
            this.name = n;
        }
        public Person2111(string n, int a)
        {
            this.name = n;
            this.age = a;
        }
        public Person2111(string n, int a, int h)
        {
            this.name = n;
            this.age = a;
            this.height = h;
        }
    }

    #endregion

}
