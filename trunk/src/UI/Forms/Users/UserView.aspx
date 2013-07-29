<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.Master" AutoEventWireup="true"
    CodeBehind="UserView.aspx.cs" Inherits="THS.UMS.UI.Forms.Users.InfoView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="form">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/user/search">Search for another User</asp:HyperLink>
    </div>
    <br />
    <ums:UserInfo ID="UserInfo1" runat="server" DisplayMode="ViewUser" />
</asp:Content>
