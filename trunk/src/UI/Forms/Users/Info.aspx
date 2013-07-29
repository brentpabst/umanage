<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.Master" AutoEventWireup="true"
    CodeBehind="Info.aspx.cs" Inherits="THS.UMS.UI.Forms.Users.Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <ums:UserInfo ID="UserInfo1" runat="server" />
</asp:Content>
