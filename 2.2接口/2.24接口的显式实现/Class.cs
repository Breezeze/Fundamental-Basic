using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2接口
{
    class Person224:IFace1,IFace2
    {
        public void Fly()
        {
            Console.WriteLine("实现了IFace1的方法");
        }
        //显式实现接口
        //为了避免方法重名
        //显式实现接口的方法默认修饰符是private
        //只有用IFace2创建实例时才能调用这个方法
        void IFace2.Fly()
        {
            Console.WriteLine("实现IFace2");
        }
    }
}
