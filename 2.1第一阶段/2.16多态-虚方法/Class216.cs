using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1第一阶段
{
    public class Person2161
    {
        //virtual关键字设置虚方法，必须有{}括号
        //virtual设置是设置方法属性的关键字，可以使子类重写该方法
        public virtual void show()
        {
            //可以是空括号，即括号中什么都不写
            Console.WriteLine("~~~~~~~~~~~~~~这是父类未重写的方法(它也可以被实现)~~~~~~~~~~");
        }
        public string Type { get; set; }
    }

    #region Subclass

    public class Chinese2161 : Person2161
    {
        //override关键字重写方法
        public override void show()
        {
            Console.Write("我是中国的");
        }
    }
    public class American2161 : Person2161
    {
        public override void show()
        {
            Console.Write("我是美国的");
        }
    }
    public class British2161 : Person2161
    {
        public override void show()
        {
            Console.Write("我是英国的");
        }
    }
    public class Japanese2161 : Person2161
    {
        public override void show()
        {
            Console.Write("我是日本的");
        }
    }

    #endregion

}
