using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2接口
{

    //如何使用接口定义方法并在类中实现
    public interface ITest222
    {
        void M1();

        int M2();

        string M3(string msg);

        //看起来像是个“自动属性”，但是该属性出现在了接口中
        //所以编译器不会把该属性自动实现，所以必须交给实现该接口的类来实现该属性
        string M4 { get; set; }

        string this[int index] { get; set; }
    }
}
