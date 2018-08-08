using LMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAL
{
    class DAL_T_UserInfo
    {
        /// <summary>
        /// 登陆--查
        /// </summary>
        public static int Login(string acc, string pwd)
        {
            string sql;
            try
            {
                sql = "select COUNT(*) from T_UserInfo where Account='" + acc + "'";
                int count = FS.SQLHelper.GetInt(sql);
                if (count == 1)
                {
                    sql = "select Nid from T_UserInfo where Account='" + acc + "' and PassWord='" + pwd + "'";
                    int id = FS.SQLHelper.GetInt(sql);
                    return id;
                }
                else if (count > 1)
                    return -1;
                else
                    return 0;
            }
            catch
            {
                return -2;
            }
        }
        /// <summary>
        /// 注册--增
        /// </summary>
        public static int Register(T_UserInfo User)
        {
            string sql;
            try
            {
                sql = "select Count(*) from T_UserInfo where Account='" + User.Account + "'";
                if (FS.SQLHelper.GetInt(sql) == 0)
                {
                    sql = "insert T_UserInfo (Account,PassWord,UserName,UserLevel,Gender,Phone,RegisterTime) values ('" + User.Account + "','" + User.PassWord + "','" + User.UserName + "'," + User.UserLevel + ",'" + User.Gender + "','" + User.Phone + "','" + DateTime.Now + "')";
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
        /// 获得本用户的所有信息--查
        /// </summary>
        public static T_UserInfo GetSelf(int id)
        {
            string sql;
            try
            {
                sql = "select * from T_UserInfo where Nid=" + id;
                DataTable dt = FS.SQLHelper.GetTable(sql, System.Data.CommandType.Text, null);
                if (dt.Rows.Count != 0)
                {
                    T_UserInfo user = new T_UserInfo((int)dt.Rows[0]["Nid"], dt.Rows[0]["Account"].ToString(), dt.Rows[0]["PassWord"].ToString(), dt.Rows[0]["UserName"].ToString(), dt.Rows[0]["Gender"].ToString(), dt.Rows[0]["Phone"].ToString(), (int)dt.Rows[0]["UserLevel"], (DateTime)dt.Rows[0]["RegisterTime"]);
                    return user;
                }
                else
                    return null;
            }
            catch
            {
                return new T_UserInfo() { Nid = -2 };
            }
        }
        /// <summary>
        /// 修改信息--改
        /// </summary>
        public static int Modify(T_UserInfo User)
        {
            string sql;
            try
            {
                sql = "update T_UserInfo set ";
                if (User.Account != null)
                    sql += "Account='" + User.Account + "',";
                if (User.PassWord != null)
                    sql += "PassWord='" + User.PassWord + "',";
                if (User.UserName != null)
                    sql += "UserName='" + User.UserName + "',";
                if (User.UserLevel != -1)
                    sql += "UserLevel='" + User.UserLevel + "',";
                if (User.Gender != null)
                    sql += "Gender='" + User.Gender + "',";
                if (User.Phone != null)
                    sql += "Phone='" + User.Phone + "',";
                sql = sql.Substring(0, sql.Length - 1);
                sql += " where Nid=" + User.Nid;
                return FS.SQLHelper.ExecuteNonQuery(sql, CommandType.Text, null);
            }
            catch
            {
                return -2;
            }
        }
        /// <summary>
        /// 显示比自己低一级的用户信息--查
        /// </summary>
        public static DataTable GetUserInfo(int userlevel)
        {
            string sql;
            try
            {
                sql = "select * from T_UserInfo where UserLevel>" + userlevel;
                return FS.SQLHelper.GetTable(sql, CommandType.Text, null);
            }
            catch
            {
                throw new Exception("数据库连接失败！");
            }
        }

    }
}
