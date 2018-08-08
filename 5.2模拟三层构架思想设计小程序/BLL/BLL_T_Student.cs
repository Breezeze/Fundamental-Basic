using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.模拟三层构架思想设计小程序.BLL
{
    class BLL_T_Student
    {
        public static T_Student GetOne(int Nid)
        {
            DataTable dt = DAL.DAL_T_Sudent.GetOne(Nid);
            T_Student one = null;
            if (dt.Rows.Count != 0)
                one = new T_Student((int)dt.Rows[0]["Nid"], dt.Rows[0]["StudentName"].ToString(), dt.Rows[0]["StudentNu"].ToString(), dt.Rows[0]["Gender"].ToString(), (int)dt.Rows[0]["Age"]);
            return one;
        }

        public static bool UpdateAgeAddOne(int Nid)
        {
            return DAL.DAL_T_Sudent.UpdateAge(Nid) == 1;
        }

    }
}
