<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HashPassword.aspx.cs" Inherits="WordleWebApp.HashPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtInput" runat="server" />
<asp:Button ID="btnHash" runat="server" Text="Hash" OnClick="btnHash_Click" />
<asp:Label ID="lblOutput" runat="server" />
        </div>
    </form>
</body>
</html>
