using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1第一阶段
{
    public class Shape216//父类
    {
        public virtual double Perimeter()//周长
        {
            return -1;
        }
        public virtual double Acreage()//面积
        {
            return -1;
        }
    }
    public class Circle216 : Shape216    //圆
    {
        public Circle216(double radii)
        {
            this.Radii = radii;
        }
        public double Radii { get; set; }// radii半径
        public override double Perimeter()
        {
            double perimeter = Radii * 2 * 3.14;
            return perimeter;
        }
        public override double Acreage()
        {
            double acreage = Radii * Radii * 3.14;
            return acreage;
        }
    }
    public class Rectangle216 : Shape216    //正方形
    {
        public Rectangle216(double squares)
        {
            this.Squares = squares;
        }
        public double Squares { get; set; }// Squares边长
        public override double Perimeter()
        {
            double perimeter = Squares * 4;
            return perimeter;
        }
        public override double Acreage()
        {
            double acreage = Squares * Squares;
            return acreage;
        }
    }
    public class Square216 : Shape216    //矩形
    {
        public Square216(double width, double length)
        {
            this.Width = width;
            this.Lenth = length;
        }
        public double Width { get; set; }// 宽度
        public double Lenth { get; set; }//长度

        public override double Perimeter()
        {
            double perimeter = Width * 2 + Lenth * 2;
            return perimeter;
        }
        public override double Acreage()
        {
            double acreage = Width * Lenth;
            return acreage;
        }
    }








}
