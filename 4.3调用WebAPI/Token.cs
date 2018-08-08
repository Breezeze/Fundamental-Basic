using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace IDAL
{
    /// <summary>
    /// author:wang  2016.7.29
    /// </summary>

    public sealed class Token
    {
        private static TokenFormat instance;
        private static DateTime date = DateTime.Now;
        private static readonly object obj = new object();
        //token持续时间
        private static readonly int time = 2;

        //私有构造函数  防止外部实例化
        private Token() { }

        public static TokenFormat GetInstance()
        {

            DateTime d = DateTime.Now;
            if (instance == null || d.AddHours(-time).CompareTo(date) > 0)
            {
                lock (obj)
                {
                    if (instance == null || d.AddHours(-time).CompareTo(date) > 0)
                    {
                        instance = GetToken();
                        date = DateTime.Now;
                    }
                }

            }

            return instance;

        }
        private static TokenFormat GetToken()
        {

            string post = "grant_type=client_credentials&client_id=StudentForest&client_secret=information12016921";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"http://api.hicc.cn//token");
            req.Method = "POST";
            byte[] data = Encoding.UTF8.GetBytes(post);
            req.GetRequestStream().Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader streamReader = new StreamReader(res.GetResponseStream());
            string token = streamReader.ReadToEnd();
            res.Close();
            streamReader.Close();
            req.Abort();

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            return serializer.Deserialize<TokenFormat>(token);

        }

    }
    public class TokenFormat
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
    }
}
