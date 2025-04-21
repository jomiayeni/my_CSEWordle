<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="WordleWebApp.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to the staff page</h1>
            <p>Here users can append words to the list.</p>
            <p>
                <asp:TextBox ID="enterWordHereTB" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="addWordBtn" runat="server" Text="Add word" OnClick="addWordBtn_Click" />
                <asp:Label ID="WordAddedLbl" runat="server" Text=""></asp:Label>
            </p>
            <p>
                <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
            </p>
        </div>
    </form>
</body>
</html>
