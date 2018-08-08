using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1第一阶段
{
    class Index212
    {
        public string[] _array = { "第一个", "第二个", "第三个", "第四个" };
        public int Length       //读取长度
        {
            get
            {
                return _array.Length;
            }           //不设置set属性，则该属性只读
            //反之，只可修改不可读取
        }
        //索引器的定义：
        //this表示这个对象
        public string this[int i]
        {
            get
            {
                return _array[i];
            }
            set
            {
                _array[i] = value;
            }
        }
    }
}
