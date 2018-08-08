using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1第一阶段
{
    //定义类时，类的默认访问修饰符为public
    public class Person2112
    {
        //通过prop直接编写类属性
        public Person2112() { }
        public Person2112(string name)
            : this(name, 0, 0, "null")     //通过  :this()  来先调用重载最后一个构造函数，来省略重复的代码
        {
            //this.Name = name;
        }
        public Person2112(string name, int age)
            : this(name, age, 0, "null") { }
        public Person2112(string name, int age, int height)
            : this(name, age, height, "null") { }
        public Person2112(string name, int age, string email)
            : this(name, age, 0, email) { }
        public Person2112(string name, int age, int height, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Height = height;
            this.Email = email;
        }
        //通过同一类型的实例初始化
        public Person2112(Person2112 p2)
            : this(p2.Name, p2.Age, p2.Height, p2.Email) { }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public string Email { get; set; }
        public static string cs { get; set; }    //静态成员
        public static void SayHi()
        {
            Console.WriteLine("Hello");
        }
    }
}
