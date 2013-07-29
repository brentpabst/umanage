<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.master" AutoEventWireup="true"
    CodeBehind="UsrAdd.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.User.UsrAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <ums:UserInfo ID="UserInfo1" runat="server" DisplayMode="AddUser" />
</asp:Content>
