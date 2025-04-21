<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="WordleWebApp.Logout" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logout</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            padding: 40px;
            background-color: #f4f4f4;
        }
        .container {
            background-color: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0px 0px 10px rgba(0,0,0,0.2);
            max-width: 400px;
            margin: auto;
            text-align: center;
        }
        .logout-time {
            font-weight: bold;
            color: darkgreen;
        }
        .login-button {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>You have been logged out.</h2>
            <p>Logout time:</p>
            <p class="logout-time">
                <asp:Label ID="lblLogoutTime" runat="server" />
            </p>
            <p>Would you like to log in again?</p>
            <asp:Button ID="btnLogin" runat="server" Text="Log In Again" PostBackUrl="~/Login.aspx" CssClass="login-button" />
        </div>
    </form>
</body>
</html>
