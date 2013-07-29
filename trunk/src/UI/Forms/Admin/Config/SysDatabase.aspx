<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="SysDatabase.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.SysDatabase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>Application Database</strong>
        <br />
        Changes to the database configuration are not allowed after the application has
        been configured. Use Application Reset instead.
    </p>
    <table class="form">
        <tbody>
            <tr>
                <th>
                    Database Server:
                </th>
                <td>
                    <asp:TextBox ID="txtServer" runat="server" Enabled="false" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Catalog / Database:
                </th>
                <td>
                    <asp:TextBox ID="txtCatalog" runat="server" Enabled="false" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Database Username:
                </th>
                <td>
                    <asp:TextBox ID="txtUser" runat="server" Enabled="false" CssClass="text"></asp:TextBox>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
