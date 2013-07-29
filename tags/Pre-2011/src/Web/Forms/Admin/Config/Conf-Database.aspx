<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="Conf-Database.aspx.cs" Inherits="PPI.UMS.Web.Forms.Admin.Config.Conf_Database" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-head">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Admin,Menu_Config_Database_Title %>"></asp:Label>
    </div>
    <div class="content-main">
        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Admin,Config_Database_Body %>"></asp:Label>
        <table class="form">
            <tr class="required">
                <td class="header">
                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Admin,Config_Database_Server %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtServer" runat="server" CssClass="textbox-required" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr class="required">
                <td class="header">
                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Admin,Config_Database_Catalog %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCatalog" runat="server" CssClass="textbox-required" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr class="required">
                <td class="header">
                    <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Admin,Config_Database_Username %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="textbox-required" Enabled="false"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
