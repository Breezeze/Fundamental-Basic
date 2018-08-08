using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS
{
    public abstract class SQLHelper
    {
        private static readonly string ConnStr = "User ID=笔记;Password=123.123;Initial Catalog=LibraryManagement;Data Source=.;";

        #region 检索单个值

        /// <summary>
        /// 查询单个值，返回String
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static string GetStr(string strSQL)
        {
            string strTmp;
            using (SqlConnection objConn = new SqlConnection(ConnStr))
            {
                using (SqlCommand objCmd = new SqlCommand(strSQL, objConn))
                {
                    objCmd.CommandType = CommandType.Text;

                    objConn.Open();
                    strTmp = Convert.ToString(objCmd.ExecuteScalar());
                    objConn.Close();
                }
            }

            return strTmp;
        }

        /// <summary>
        /// 查询单个值，返回Int
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static int GetInt(string strSQL)
        {
            int intTmp;
            using (SqlConnection objConn = new SqlConnection(ConnStr))
            {
                using (SqlCommand objCmd = new SqlCommand(strSQL, objConn))
                {
                    objCmd.CommandType = CommandType.Text;

                    objConn.Open();
                    intTmp = Convert.ToInt32(objCmd.ExecuteScalar());
                    objConn.Close();
                }
            }
            return intTmp;
        }

        /// <summary>
        /// 检索单个值，返回object
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="cmdType">选择执行SQL语句还是存储过程</param>
        /// <param name="pms">参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string strSQL, CommandType cmdType, params SqlParameter[] pms)
        {
            object objTmp;
            using (SqlConnection objConn = new SqlConnection(ConnStr))
            {
                using (SqlCommand objCmd = new SqlCommand(strSQL, objConn))
                {
                    objCmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        objCmd.Parameters.AddRange(pms);
                    }
                    objConn.Open();
                    objTmp = objCmd.ExecuteScalar();//返回受影响行数
                    objConn.Close();
                }
            }
            return objTmp;
        }

        #endregion

        #region 执行增/删/改等SQL语句，返回受影响行数
        /// <summary>
        /// 执行增/删/改等SQL语句，返回受影响行数
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="cmdType">选择执行SQL语句还是存储过程</param>
        /// <param name="pms">参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string strSQL, CommandType cmdType, params SqlParameter[] pms)
        {
            int intTmp = 0;
            using (SqlConnection objConn = new SqlConnection(ConnStr))
            {
                using (SqlCommand objCmd = new SqlCommand(strSQL, objConn))
                {
                    objCmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        objCmd.Parameters.AddRange(pms);
                    }
                    objConn.Open();
                    intTmp = objCmd.ExecuteNonQuery();//返回受影响行数
                    objConn.Close();
                }
            }
            return intTmp;
        }



        #endregion

        #region 检索多个值

        /// <summary>
        /// 返回数据库多个数据
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="cmdType"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string strSQL, CommandType cmdType, params SqlParameter[] pms)
        {
            SqlConnection objconn = new SqlConnection(ConnStr);
            using (SqlCommand objcmd = new SqlCommand(strSQL, objconn))
            {
                objcmd.CommandType = cmdType;
                if (pms != null)
                {
                    objcmd.Parameters.AddRange(pms);
                }
                try
                {
                    objconn.Open();
                    return objcmd.ExecuteReader(CommandBehavior.CloseConnection);//返回并接受数据后自动关闭数据库连接
                }
                catch
                {
                    objconn.Close();
                    objconn.Dispose();
                    throw;
                }
            }
        }
        //常用-返回DataTable类型
        public static DataTable GetTable(string strSQL, CommandType cmdType, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(strSQL, ConnStr))
            {
                adapter.SelectCommand.CommandType = cmdType;
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);//数据填充
                return dt;
            }
        }





        #endregion

    }
}
