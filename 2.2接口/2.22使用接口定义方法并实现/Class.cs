using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2接口
{

    public class TestClass222 : ITest222
    {
        //可以补一个字段来操作属性
        public void M1()
        {
            throw new NotImplementedException();
        }
        public int M2()
        {
            throw new NotImplementedException();
        }
        public string M3(string msg)
        {
            throw new NotImplementedException();
        }
        public string M4
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public string this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
    //当一个类实现某个接口时，如果实现的时候把接口的成员标记为abstract，同时该类也是一个抽象类时，可以不对接口的成员进行实现，当然代码不能少。
    public abstract class TestAbstract222 : ITest222
    {

        public abstract void M1();
        public abstract int M2();
        public abstract string M3(string msg);
        public abstract string M4
        {
            get;
            set;
        }
        public abstract string this[int index]
        {
            get;
            set;
        }
    }

}
