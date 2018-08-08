using LMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL
{
    class BLL_T_UserInfo
    {
        public static string Login(string acc, string pwd)
        {
            int num = DAL.DAL_T_UserInfo.Login(acc, pwd);
            if (num > 0)
                return "登陆成功" + num;
            else if (num == 0)
                return "账号或密码错误！";
            else if (num == -1)
                return "存在相同账号，请联系管理员！";
            else if (num == -2)
                return "数据库连接失败！";
            else
                return "后台出现未知错误！";

        }
        public static string Register(string account, string password, string username, string gender, string phone)
        {
            int num = DAL.DAL_T_UserInfo.Register(new LMS.Model.T_UserInfo(0, account, password, username, gender, phone) { UserLevel = 2 });
            if (num == 1)
                return "注册成功";
            else if (num == -2)
                return "数据库连接失败！";
            else if (num == -1)
                return "存在相同账号，请更换账号后重试！";
            else if (num == 0)
                return "连接数据库成功，但是未能更新数据库！";
            else
                return "发生未知错误！";
        }
        public static T_UserInfo GetSelf(int id)
        {
            T_UserInfo user = DAL.DAL_T_UserInfo.GetSelf(id);
            if (user == null)
                throw new Exception("登录信息有误！");
            else if (user.Nid == -2)
                throw new Exception("数据库连接失败！");
            else
                return user;
        }
        /// <summary>
        /// 修改基本信息
        /// </summary>
        public static int ModifyBasic(int id, string username, string phone)
        {
            return DAL.DAL_T_UserInfo.Modify(new T_UserInfo() { Nid = id, UserName = username, Phone = phone });
        }
        public static int ModifyBasic(int id, string username, string gender, int userlevel, string phone)
        {
            return DAL.DAL_T_UserInfo.Modify(new T_UserInfo() { Nid = id, UserName = username, Gender = gender, UserLevel = userlevel, Phone = phone });
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        public static int ModifyPwd(int id, string password)
        {
            return DAL.DAL_T_UserInfo.Modify(new T_UserInfo() { Nid = id, PassWord = password });
        }

        public static List<T_UserInfo> GetUserInfo(int userlevel)
        {
            DataTable dt = DAL.DAL_T_UserInfo.GetUserInfo(userlevel);
            List<T_UserInfo> list = new List<T_UserInfo>();
            if (dt.Rows.Count != 0)
                foreach (DataRow dr in dt.Rows)
                {
                    T_UserInfo user = new T_UserInfo((int)dr["Nid"], dr["Account"].ToString(), dr["PassWord"].ToString(), dr["UserName"].ToString(), dr["Gender"].ToString(), dr["Phone"].ToString(), (int)dr["UserLevel"], (DateTime)dr["RegisterTime"]);
                    list.Add(user);
                }
            else
                return null;
            return list;
        }
    }
}
