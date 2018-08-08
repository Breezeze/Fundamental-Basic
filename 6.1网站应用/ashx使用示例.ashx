<%@ WebHandler Language="C#" Class="ashx使用示例" %>

using System;
using System.Web;

public class ashx使用示例 : IHttpHandler
{
    //点击Submit按钮，触发form表单中的action，根据action指定路径调用ashx中的方法
    //网站网址为 “@1/@2.ashx?@3=@4&@5=@6”
    //?后为参数，由此传值
    //@1为域名，@2为ashx文件名
    //@4为提交上来的form表单中 name为@3的元素的value值
    public void ProcessRequest(HttpContext context)
    {
        //表示相应的数据是html数据
        context.Response.ContentType = "text/html";
        //获取提交过来的数据
        string UserName = context.Request["UserName"];
        //将数据返回到浏览器端
        //模拟成之前请求的页面
        //如果什么都不输出，返回一个空页面
        string path = context.Server.MapPath("ashx使用示例.html");
        string html = System.IO.File.ReadAllText(path);
        //添加JS，恢复用户输入的内容
        html += "<script>  $(function () {  $(\"input[name='UserName']\").val('" + UserName + "');  })  </script>";
        context.Response.Write(html);
        context.Response.Write(UserName + "<br />");

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}