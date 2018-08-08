using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2接口
{

    //定义一个类来实现接口
    //实现接口中的类，必须将接口中的所有成员都实现
    //直接实现接口中的方法即可，无需使用override关键字
    public class SupperMan221 : IFlyable221
    {

        public void Fly()
        {
            Console.WriteLine("超人飞了！！！");
        }

        public void Jumb()
        {
            Console.WriteLine("超人跳了一下。");
        }
    }
    //一个类可以实现多个接口
    //当一个类继承了父类且实现了接口时，父类放在第一位。即：public class SpiderMan:SupperMan,IFlyable,IEat
    public class SpiderMan221 : IFlyable221, IEat221
    {

        public void Fly()
        {
            Console.WriteLine("蜘蛛侠飞了！！！");
        }

        public void Jumb()
        {
            Console.WriteLine("蜘蛛侠跳了一下。");
        }

        public void Eat()
        {
            Console.WriteLine("蜘蛛侠吃饭了~~~~");
        }
    }


}
