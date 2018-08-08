using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1第一阶段
{
    public abstract class Person217
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //抽象方法
        //抽象方法在父类中不能有任何实现，所以抽象方法没有方法体，即无{};
        public abstract void Show();
    }

    //子类继承抽象父类以后，必须重写父类的抽象成员，除非子类也是抽象类
    #region SubClass

    public class Chinese217 : Person217
    {
        //在Person217上Alt+Shift+F10自动添加重写代码
        //public override void Show()
        //{
        //    throw new NotImplementedException();
        //}

        public override void Show()
        {
            Console.WriteLine("我是中国人");
        }
    }
    public class American217 : Person217
    {
        public override void Show()
        {
            Console.WriteLine("我是美国人");
        }
    }
    public class British217 : Person217
    {
        public override void Show()
        {
            Console.WriteLine("我是英国人");
        }
    }
    public class Japanese217 : Person217
    {
        public override void Show()
        {
            Console.WriteLine("我是日本人");
        }
    }

    #endregion
}
