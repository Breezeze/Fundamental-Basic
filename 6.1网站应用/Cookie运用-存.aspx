<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cookie运用-存.aspx.cs" Inherits="Cookie运用_存" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="text" name="color" id="_color" value="" runat="server" />
            <asp:Button ID="Button1" runat="server" Text="存Cookie" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
