using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cookie运用_存 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //在服务器端设置cookie
        Response.SetCookie(new HttpCookie("Color", _color.Value.ToString()));//客户端即前台也可以通过$.cookie取到
        Response.Write("<script> alert('已存储！');</script>");
    }
}