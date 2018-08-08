using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace GaoDeRegeo
{
    class HttpGetHelper
    {
        /// <summary>
        /// 高德地图解析函数
        /// </summary>
        /// <param name="strResult">返回结果</param>
        public static string GaoDeAnalysis(string parameters)
        {
            string strResult = "";
            string url = string.Format("http://restapi.amap.com/v3/geocode/regeo?{0}", parameters);
            // 下载于www.mycodes.net
            try
            {
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            req.ContentType = "multipart/form-data";
            req.Accept = "*/*";
            //req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";
            req.UserAgent = "";
            req.Timeout = 30000;//30秒连接不成功就中断 
            req.Method = "GET";
            req.KeepAlive = true;

            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                strResult = sr.ReadToEnd();
            }
            }
            catch (Exception ex)
            {
                strResult = "";
            }
            return strResult;
        }

    }
}
