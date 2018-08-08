using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1连接数据库
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 方法一

            // string ConStr1, ConStr2, sql;
            // ConStr1 = "Server= ;DataDase=Student;uid=sa;pwd=956wan";
            // /*
            // "Server=.:这个点代表的是本机的意思，  还可以写成server=localhost,　
            // "user id=sa":连接的验证用户名为sa.    还可以写成"uid=sa".
            //"password=":连接的验证密码为空.       还可以写为"pwd=".
            //"DataBase=Exercise"指的就是你建立的数据库名，
            //  */
            // ConStr2 = "Server=.;Database=Exercise;Trusted_Connection=SSPI";
            // //"Trusted_Connection=SSPI"来代替登陆名和密码


            // /*
            // SqlDataAdapter 对象。 用于填充DataSet （数据集）。
            // SqlDataReader 对象。 从数据库中读取流..
            // 后面要做增删改查还需要用到 DataSet 对象。
            // */

            // //创建连接SQL的对象        Alt+Shift+F10
            // SqlConnection mycon = new SqlConnection(ConStr2);
            // //SQL语句
            // sql = "select * from Table_1";
            // //打开数据库
            // mycon.Open();
            // //控制指令
            // SqlDataAdapter myda = new SqlDataAdapter(sql, ConStr1);
            // DataSet myds = new DataSet();
            // myda.Fill(myds, "Table_1");
            // //Table_1.DataSource = myds.Tables["lianxi"];

            // mycon.Close();

            #endregion



            #region 方法二

            // /*
            // SqlDataAdapter 对象。 用于填充DataSet （数据集）。
            // SqlDataReader 对象。 从数据库中读取流..
            // 后面要做增删改查还需要用到 DataSet 对象。
            // */

            //创建一个连接SQL的对象
            SqlConnection CON = new SqlConnection();
            //连接数据库的身份验证字符串
            CON.ConnectionString = "server=.;database=Student;uid=sa;pwd=956wan";
            /*"Server=.:这个点代表的是本机的意思，  还可以写成server=localhost,　
            "user id=sa":连接的验证用户名为sa.    还可以写成"uid=sa".
           "password=":连接的验证密码为空.       还可以写为"pwd=".
           "DataBase=Exercise"指的就是你建立的数据库名， */

            //CON.ConnectionString = "Server=.;Database=Student;Trusted_Connection=SSPI";
            //使用Windows身份验证登陆的话："Trusted_Connection=SSPI"来代替登陆名和密码

            //打开数据库
            CON.Open();
            //创建一个操作SQL的对象
            SqlCommand com = new SqlCommand();
            //对象之间的传值
            com.Connection = CON;
            //指定解析语法
            com.CommandType = CommandType.Text;
            //SQL语句
            com.CommandText = "insert Table_1 ([Name],[StuNum],[Gender],[PhoneNum]) values ('王馨',2015423301,'男',12345678901)";
            //创建一个执行SQL语句的对象
            SqlDataReader dr = com.ExecuteReader();
            //受影响行数
            int i = com.ExecuteNonQuery();
            //关闭执行
            dr.Close();
            //关闭数据库
            CON.Close();
            Console.WriteLine(i);


            #endregion


        }
    }
}
