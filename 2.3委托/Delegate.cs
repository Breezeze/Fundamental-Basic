using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3委托
{
    //第一步，定义一个委托
    //这里就像定义了一个类一样，将来使用它的时候还需要声明该类型的变量
    public delegate void T1Delegate();

    //委托的类型必须和要传递的方法的要求相同，如参数和返回值类型
    public delegate string T2Delegate(string mag);

}
