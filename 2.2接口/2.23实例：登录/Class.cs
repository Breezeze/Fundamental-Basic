using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2接口
{

    //设置登记函数
    static class Dengji
    {
        //参数为接口类型，但是可以传入实现该接口的类所创建的对象
        static public void dengji(IIntroduce cla)
        {
            cla.Introduce();
        }
    }
    //Person类实现了IIntroduce接口，并且把接口中的Introduce()方法实现成了虚方法，所以继承Person类的子类就可以重写该方法
    //同时，Person的子类虽然看似没有实现接口（class后没有:IIntoduce），但其实实现了接口
    //也可以在子类后面写上接口，这样运行时类型转换效率较快
    class Person223 : IIntroduce
    {
        public virtual void Introduce() { }

    }
    #region Person223的subclass

    class Chinese223 : Person223
    {
        public override void Introduce()
        {
            Console.WriteLine("录入读取身份证号，姓名");
        }

    }
    class American223 : Person223
    {
        public override void Introduce()
        {
            Console.WriteLine("录入读取社保号，姓名");
        }
    }
    class British223 : Person223
    {
        public override void Introduce()
        {
            Console.WriteLine("录入......");
        }
    }

    #endregion

    class House : IIntroduce
    {
        public void Introduce()
        {
            Console.WriteLine("录入房子的基本信息");
        }
    }


}
