<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WordleWebApp.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Wordle Web App</title>
    <style>
        body {
            margin: 0;
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .container {
            background: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            width: 100%;
            max-width: 400px;
        }
        h3 {
            text-align: center;
            margin-bottom: 15px;
        }
        .form-group {
            margin-bottom: 10px;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        .form-group input[type="text"],
        .form-group input[type="password"] {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        .actions {
            text-align: center;
            margin-top: 15px;
        }
        .actions input[type="submit"],
        .actions button,
        .actions .btn {
            padding: 10px 20px;
            border: none;
            background: #007bff;
            color: #fff;
            border-radius: 4px;
            cursor: pointer;
        }
        .error {
            color: #d9534f;
            text-align: center;
            margin-top: 10px;
        }
        hr {
            margin: 20px 0;
            border: none;
            border-top: 1px solid #eee;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="container">
        <div class="login-section">
            <h3>Returning Users</h3>
            <div class="form-group">
                <asp:Label ID="lblUsername" runat="server" Text="Username:" AssociatedControlID="txtUsername" />
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" Text="Password:" AssociatedControlID="txtPassword" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
            </div>
            <div class="actions">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn" />
            </div>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" CssClass="error" />
        </div>

        <hr />

        <div class="register-section">
            <h3>New Users</h3>
            <div class="form-group">
                <asp:Label ID="lblUsernameRegister" runat="server" Text="Username:" AssociatedControlID="txtUsernameRegister" />
                <asp:TextBox ID="txtUsernameRegister" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblPasswordRegister" runat="server" Text="Password:" AssociatedControlID="txtPasswordRegister" />
                <asp:TextBox ID="txtPasswordRegister" runat="server" TextMode="Password" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblPasswordConfirm" runat="server" Text="Confirm Password:" AssociatedControlID="txtPasswordConfirm" />
                <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:CheckBox ID="saveUsernameCB" runat="server" Text="Save Username" />
            </div>
            <div class="actions">
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn" />
            </div>
            <asp:Label ID="lblRegisterError" runat="server" ForeColor="Red" CssClass="error" />
        </div>
    </form>
</body>
</html>
