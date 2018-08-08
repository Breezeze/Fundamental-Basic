using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model
{
    class T_Books
    {
        public T_Books() { }
        public T_Books(int id, string bookname, int bookclasses, string author, string press, decimal price, bool isleased, string leasee, object leasetime)
        {
            this.Nid = id;
            this.BookName = bookname;
            this.BookClasses = bookclasses;
            this.Author = author;
            this.Press = press;
            this.Price = price;
            this.IsLeased = isleased;
            this.Leasee = leasee;
            this.LeaseTime = leasetime;
        }
        public T_Books(string bookname, int bookclasses, string author, string press, decimal price)
        {
            this.BookName = bookname;
            this.BookClasses = bookclasses;
            this.Author = author;
            this.Press = press;
            this.Price = price;
        }

        public DateTime GetLeaseTime()
        {
            return (DateTime)this.LeaseTime;
        }

        public string GetBookClasses()
        {
            string classesname = "";
            switch (this.BookClasses)
            {
                case 1:
                    classesname = "儿童图书";
                    break;
                case 2:
                    classesname = "编程教材";
                    break;
                case 3:
                    classesname = "修真小说";
                    break;
                case 4:
                    classesname = "社会百谈";
                    break;
                default:
                    throw new Exception("系统出错！请联系管理员！");
            }
            return classesname;
        }
        public int Nid { get; set; }
        public string BookName { get; set; }
        public int BookClasses { get; set; }
        public string Author { get; set; }
        public string Press { get; set; }
        public decimal Price { get; set; }
        public bool IsLeased { get; set; }
        public string Leasee { get; set; }
        public object LeaseTime { get; set; }



    }
}
