<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cookie运用-取.aspx.cs" Inherits="Cookie运用_取" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="JS/jquery-1.11.1.min.js"></script>
    <script type="text/javascript">

        //$(function () {
        //    $('#btn').click(function () {
        //        alert($.cookie('Color'));
        //    })
        //})

    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="text" name="color" id="_color" value="" runat="server" /><br />
            <asp:Button ID="Button1" runat="server" Text="后台取Cookie" OnClick="Button1_Click" /><br />
            <input type="button" id="btn" value="前台取Cookie" />
        </div>
    </form>
</body>
</html>
