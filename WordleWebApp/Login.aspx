<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WordleWebApp.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>Returning Users Log in Here</h3>
        <div>
            <asp:Label ID="lblUsername" runat="server" Text="Username:" />
            <asp:TextBox ID="txtUsername" runat="server" />
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password:" />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
            <br />

            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
        </div>

           <h3>New Users Register Here</h3>
           <div>
               <asp:Label ID="lblUsernameRegister" runat="server" Text="Username:" />
               <asp:TextBox ID="txtUsernameRegister" runat="server" />
               <br />
               <asp:Label ID="lblPasswordRegister" runat="server" Text="Password:" />
               <asp:TextBox ID="txtPasswordRegister" runat="server" TextMode="Password" />
               <br />
               <asp:Label ID="lblPasswordConfirm" runat="server" Text="Confirm Password:" />
               <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password" />
               <br />
            <asp:CheckBox ID="saveUsernameCB" runat="server" Text="Save Username" />
               <br />
               <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
               <asp:Label ID="lblRegisterError" runat="server" ForeColor="Red" />
           </div>

    </form>
</body>
</ /html>