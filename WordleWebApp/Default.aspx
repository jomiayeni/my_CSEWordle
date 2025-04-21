<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="WordleWebApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        Welcome, <asp:Label ID="lblUsername" runat="server" />
    </div>

    <div>
    <asp:Label ID="lblAppStartTime" runat="server" CssClass="app-start-time" />
    </div>

    <h1>Home page</h1>

    <p>Welcome to our webapp. Users can log in and register to play games</p>
    <h3>Service Directory</h3>
    <asp:GridView ID="ServiceDirectoryGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Provider" HeaderText="Provider" />
            <asp:BoundField DataField="ComponentType" HeaderText="Component Type" />
            <asp:BoundField DataField="Operation" HeaderText="Operation" />
            <asp:BoundField DataField="Parameters" HeaderText="Parameters" />
            <asp:BoundField DataField="ReturnType" HeaderText="Return Type" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:HyperLinkField DataNavigateUrlFields="TryItLink" Text="TryIt" HeaderText="TryIt Link" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnGoToMember" runat="server" Text="Go to Member Page" OnClick="btnGoToMember_Click" />
    <asp:Button ID="btnGoToStaff" runat="server" Text="Go to Staff Page" OnClick="btnGoToStaff_Click" />
</asp:Content>