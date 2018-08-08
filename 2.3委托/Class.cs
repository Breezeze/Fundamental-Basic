using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3委托
{
    class DoCW
    {
        //第二步，通过委托类型，声明一个委托变量
        public T1Delegate method;
        public void Do()
        {

            Console.WriteLine("===========");
            if (method != null)
            {
                //将来这个委托存储的就是个方法，所以可以直接这样写，就相当于调用了里面的方法
                method();
                //这句话是method.Invoke();的简写
            }
            Console.WriteLine("===========");
        }
    }

    class ChangeString
    {

        public string[] Change(string[] mag, T2Delegate method)
        {
            string[] ret=new String[3];
            for (int i = 0; i < mag.Length; i++)
            {
                ret[i] = method(mag[i]);
            }
            return ret;
        }


    }


}
