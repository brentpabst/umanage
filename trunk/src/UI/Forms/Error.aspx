<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.Master" AutoEventWireup="true"
    CodeBehind="Error.aspx.cs" Inherits="THS.UMS.UI.Forms.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h1>
        Uh Oh, That wasn't supposed to happen!</h1>
    <p>
        Something just broke and it should not have. The system administrator will get notified
        of the problem but in the mean time you can reload the application by clicking the
        link below.
    </p>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/" Text="Reload the Application"></asp:HyperLink>
</asp:Content>
