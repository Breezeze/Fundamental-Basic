using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _4._3调用WebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 使用token令牌调用API

            IDAL.TokenFormat tf = IDAL.Token.GetInstance();
            string _data = tf.token_type + " " + tf.access_token;
            string serviceAddress = @"http://api.hicc.cn/api/Tem_FSF/Insert?temp=3&wet=2&pmtw=3&pmten=3&cigrate=5";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            //request.Headers.Add(HttpRequestHeader.Authorization, _data);
            request.Headers["Authorization"] = _data;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            Console.WriteLine(retString);

            #endregion

            Console.ReadKey();
        }
    }
}
