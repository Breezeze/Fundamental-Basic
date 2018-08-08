using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2接口
{

    //定义一个接口，用interface关键字定义
    //接口名以大写I开头
    //接口只能包含方法（属性，事件，索引器都是方法）
    //接口的成员不能有任何实现
    //成员中不能有任何访问修饰符，默认为public，如果手动写了修饰符则报错
    public interface IFlyable221
    {
        void Fly();

        void Jumb();
    }

    //在什么时候需要使用接口（而不是使用抽象类或者虚方法）来实现多态：
    //1.当多个类型不能抽象出一个合理的父类的时候，但是又要对某些方法进行多态，即，把公共的方法抽象到一个接口中，然后让不同的子类实现该接口（例如：不容易寻找到飞机和鸟的父类，虽然他们都可以实现飞行）
    //2.因为接口可以多实现，所以解决了类的单继承问题。当一个 类需要同时“继承”多个类的行为时，可以考虑使用多接口来进行多实现
    public interface IEat221
    {
        void Eat();
    }

    //接口可以继承接口
}
