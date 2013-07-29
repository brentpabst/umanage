<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="Conf-Reset.aspx.cs" Inherits="PPI.UMS.Web.Forms.Admin.Config.Conf_Reset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-head">
        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Admin,Menu_Config_AppReset_Title %>"></asp:Label>
    </div>
    <div class="content-main">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Admin,Config_AppReset_Body %>"></asp:Label>
        <asp:Button ID="Button1" runat="server" CssClass="submit" Text="<%$ Resources:Admin,Config_AppReset_SubmitText %>"
            OnClientClick="<%$ Resources:Admin,Config_AppReset_Conf %>" OnClick="Button1_Click" />
    </div>
</asp:Content>
