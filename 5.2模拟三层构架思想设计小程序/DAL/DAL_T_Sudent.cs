using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.模拟三层构架思想设计小程序.DAL
{
    public class DAL_T_Sudent
    {
        //在编写方法前，确定该方法的参数与返回值
        //参数：执行sql语句的时候需要外界传入的值
        //返回值：该sql语句在数据库中执行完毕后数据库返回什么值，就将当前的方法的返回值设置为对应的类型

        /// <summary>
        /// 根据id查询数据
        /// </summary>
        /// <param name="nid"></param>
        /// <returns></returns>
        public static DataTable GetOne(int nid)
        {

            string sql = "select * from T_Student where Nid=" + nid;
            return FS.SQLHelper.GetTable(sql, CommandType.Text, null);
        }
        /// <summary>
        /// 根据id进行年龄+1
        /// </summary>
        /// <param name="nid"></param>
        /// <returns></returns>
        public static int UpdateAge(int nid)
        {
            string sql = "update T_Student set Age=Age+1 where Nid=" + nid;
            return FS.SQLHelper.ExecuteNonQuery(sql, CommandType.Text, null);
        }
    }
}
