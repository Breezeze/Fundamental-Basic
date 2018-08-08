using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1第一阶段
{

    //设置登记函数
    static class Dengji
    {
        //参数为父类类型，但是子类可以传入
        static public void dengji(Person2162 person)
        {
            person.Introduce();
        }
    }
    //父类
    class Person2162
    {
        public virtual void Introduce() { }
    }

    class Chinese2162 : Person2162
    {
        public override void Introduce()
        {
            Console.WriteLine("读取身份证号，姓名");
        }

    }
    class American2162 : Person2162
    {
        public override void Introduce()
        {
            Console.WriteLine("读取社保号，姓名");
        }
    }
    class British2162 : Person2162
    {
        public override void Introduce()
        {
            Console.WriteLine("......");
        }
    }





}
