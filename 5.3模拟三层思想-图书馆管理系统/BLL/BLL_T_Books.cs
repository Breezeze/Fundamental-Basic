using LMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL
{
    class BLL_T_Books
    {
        public static string AddBook(string bookname, int bookclasses, string author, string press, decimal price)
        {
            int num = DAL.DAL_T_Books.AddBook(new T_Books(bookname, bookclasses, author, press, price));
            if (num == 1)
                return "添加成功";
            else if (num == -2)
                return "数据库连接失败！";
            else if (num == -1)
                return "存在相同账号，请更换账号后重试！";
            else if (num == 0)
                return "连接数据库成功，但是未能更新数据库！";
            else
                return "发生未知错误！";
        }

        public static T_Books GetOneInfo(string bookname, int id)
        {
            T_Books book = DAL.DAL_T_Books.GetOneInfo(bookname, id);
            if (book == null)
                throw new Exception("未找到该该书，请检查拼写是否正确！");
            else if (book.Nid == -2)
                throw new Exception("数据库连接失败！");
            else
                return book;
        }

        public static List<T_Books> GetAllInfo()
        {
            List<T_Books> list = new List<T_Books>();
            DataTable dt = DAL.DAL_T_Books.GetAllInfo();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new T_Books((int)dr["Nid"], dr["BookName"].ToString(), (int)dr["BookClasses"], dr["Author"].ToString(), dr["Press"].ToString(), (decimal)dr["Price"], (bool)dr["IsLeased"], dr["Leasee"].ToString(), dr["LeaseTime"]));
            }
            return list;
        }

        public static string[] GetAllNameOfClasses(int classes)
        {
            DataTable dt = DAL.DAL_T_Books.GetAllNameOfClasses(classes);
            string[] name = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                name[i] = dt.Rows[i]["BookName"].ToString();
            }
            return name;
        }

        public static int Modify(T_Books book)
        {
            return DAL.DAL_T_Books.Modify(book);
        }


    }
}
