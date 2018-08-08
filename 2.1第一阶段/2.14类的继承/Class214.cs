using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1第一阶段
{
    class Person214
    {
        //构造函数无法被继承
        public Person214() { }     //当子类有构造函数时，会默认的调用父类中无参的构造函数
        //当子类和父类同时有构造函数时，应在父类中增加一个无参函数，或使用Teacher的方法
        public Person214(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

    }
    class Student214 : Person214      //继承了Person中的属性
    {
        public long SNo { get; set; }

        public Student214(string name, int age, string gender, long sno)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.SNo = sno;
        }
    }
    class Teacher214 : Person214
    {
        public long Salary { get; set; }
        //通过  :base()   在子类中指定子类的构造函数调用父类中的有参数的构造函数
        //:base()与2.1中的:this()类似
        //构造函数调用顺序为先父类后子类
        public Teacher214(string name, int age, string gender, long salary)
            : base(name, age, gender)
        {
            this.Salary = salary;
        }
    }
}
