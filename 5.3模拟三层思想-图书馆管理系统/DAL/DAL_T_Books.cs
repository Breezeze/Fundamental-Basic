using LMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAL
{
    class DAL_T_Books
    {
        /// <summary>
        /// 添加图书信息
        /// </summary>
        public static int AddBook(T_Books book)
        {
            string sql;
            try
            {
                sql = "select Count(*) from T_Books where BookName='" + book.BookName + "'";
                if (FS.SQLHelper.GetInt(sql) == 0)
                {
                    sql = "insert T_Books (BookName,BookClasses,Author,Press,Price) values ('" + book.BookName + "'," + book.BookClasses + ",'" + book.Author + "','" + book.Press + "'," + book.Price + ")";
                    return FS.SQLHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, null);
                }
                else
                    return -1;
            }
            catch
            {
                return -2;
            }
        }
        /// <summary>
        /// 查询单个图书信息
        /// </summary>
        public static T_Books GetOneInfo(string bookname, int id)
        {
            try
            {
                string sql = "select * from T_Books where ";
                if (bookname != null)
                    sql += "BookName='" + bookname + "'";
                else
                    sql += "Nid=" + id;
                DataTable dt = FS.SQLHelper.GetTable(sql, System.Data.CommandType.Text, null);
                if (dt.Rows.Count != 0)
                {
                    T_Books book = new T_Books((int)dt.Rows[0]["Nid"], dt.Rows[0]["BookName"].ToString(), (int)dt.Rows[0]["BookClasses"], dt.Rows[0]["Author"].ToString(), dt.Rows[0]["Press"].ToString(), (decimal)dt.Rows[0]["Price"], (bool)dt.Rows[0]["IsLeased"], dt.Rows[0]["Leasee"].ToString(), dt.Rows[0]["LeaseTime"]);
                    return book;
                }
                else
                    return null;
            }
            catch
            {
                return new T_Books() { Nid = -2 };
            }

        }
        /// <summary>
        /// 查询所有图书信息
        /// </summary>
        public static DataTable GetAllInfo()
        {
            string sql;
            try
            {
                sql = "select * from T_Books ";
                return FS.SQLHelper.GetTable(sql, CommandType.Text, null);
            }
            catch
            {
                throw new Exception("数据库连接失败！");
            }
        }
        /// <summary>
        /// 查询特定类别下的图书
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        public static DataTable GetAllNameOfClasses(int classes)
        {
            string sql;
            try
            {
                sql = "select distinct BookName from T_Books where BookClasses=" + classes;
                return FS.SQLHelper.GetTable(sql, CommandType.Text, null);
            }
            catch (Exception)
            {
                throw new Exception("数据库连接失败！");
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public static int Modify(T_Books book)
        {
            string sql;
            try
            {
                sql = "update T_Books set ";
                if (book.BookName != null)
                    sql += "BookName='" + book.BookName + "',";
                if (book.BookClasses != 0)
                    sql += "BookClasses='" + book.BookClasses + "',";
                if (book.Author != null)
                    sql += "Author='" + book.Author + "',";
                if (book.Press != null)
                    sql += "Press='" + book.Press + "',";
                if (book.Price != (decimal)0)
                    sql += "Price='" + book.Price + "',";
                if (book.Leasee != null)
                {
                    sql += "IsLeased='" + book.IsLeased + "',";
                    sql += "Leasee='" + book.Leasee + "',";
                    sql += "LeaseTime='" + book.LeaseTime + "',";
                }
                sql = sql.Substring(0, sql.Length - 1);
                sql += " where Nid=" + book.Nid;
                return FS.SQLHelper.ExecuteNonQuery(sql, CommandType.Text, null);
            }
            catch
            {
                return -2;
            }
        }


    }
}
