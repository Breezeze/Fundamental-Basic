using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model
{
    class T_UserInfo
    {
        public T_UserInfo()
        {
            this.UserLevel = -1;
        }
        public T_UserInfo(int nid, string account, string password, string username, string gender, string phone)
        {
            this.Nid = nid;
            this.Account = account;
            this.PassWord = password;
            this.UserName = username;
            this.Gender = gender;
            this.Phone = phone;
            this.UserLevel = -1;
        }
        public T_UserInfo(int nid, string account, string password, string username, string gender, string phone, int userlevel, DateTime registertime)
            : this(nid, account, password, username, gender, phone)
        {
            this.RegisterTime = registertime;
            this.UserLevel = userlevel;
        }
        public int Nid { get; set; }
        public string Account { get; set; }
        public string PassWord { get; set; }
        public string UserName { get; set; }
        public int UserLevel { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public DateTime RegisterTime { get; set; }
        public string GetLevelName()
        {
            return this.UserLevel == 1 ? "管理员" : "普通用户";
        }
    }
}
