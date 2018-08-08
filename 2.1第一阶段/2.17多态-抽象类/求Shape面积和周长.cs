using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1第一阶段
{
    //抽象类和虚方法实现多态的区别：父类定义,声明定义
    public abstract class Shape217//父类
    {
        public abstract double Perimeter();//周长
        public abstract double Acreage();//面积
    }
    public class Circle217 : Shape217    //圆
    {
        public Circle217(double radii)
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
    public class Rectangle217 : Shape217    //正方形
    {
        public Rectangle217(double squares)
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
    public class Square217 : Shape217    //矩形
    {
        public Square217(double width, double length)
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
