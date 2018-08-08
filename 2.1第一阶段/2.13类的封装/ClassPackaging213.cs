using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1第一阶段
{
    class ClassPackaging213        //Class封装
    {
        private double num;
        private int length;
        public ClassPackaging213() { }
        public ClassPackaging213(double _Num)
        {
            this.Num = _Num;
        }
        private int[] digit = new int[20];
        public int Length
        {
            get { return length; }//只读属性—无set
        }
        public double Num
        {
            get { return num; }
            set     //定义赋值属性的规则
            {
                num = value;    //value即定义值
                double _num = value;
                //得到长度length
                for (length = 0; _num > 1; length++)
                {
                    _num = _num / 10;
                }
                //依次读取各位上的数
                for (int i = 0; i < length; i++)
                {
                    _num = _num * 10;
                    digit[i] = (int)_num % 10;
                }
                //交换位置
                int _length = length;
                for (int i = 0; i < _length; i++, _length--)
                {
                    digit[i] = digit[_length] + (digit[_length] = digit[i]) * 0;
                }
                //digit[length]实际对应的是未赋值的0，交换后digit[0]未赋值，可令digit[i]对应小数点前第i位
            }
        }
        //索引器
        public int this[int i]
        {
            get
            {
                return (int)digit[i];
            }
        }

    }
}
