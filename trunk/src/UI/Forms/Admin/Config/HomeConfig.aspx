<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="HomeConfig.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.HomeConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>Home Page</strong>
        <br />
        The home page tool allows you to provide a simple start or launch page designed
        for intranet use. It ties in to uManage and can link to any other URL.
        <br />
        <br />
        You can use this page to turn it on or off and configure simple settings.
    </p>
    <table class="form">
        <tr>
            <th>
                Enable Home Page:
            </th>
            <td>
                <asp:CheckBox ID="cbEnabled" runat="server" />
            </td>
        </tr>
        <tr>
            <th>
                Override Normal Load:
            </th>
            <td>
                <asp:CheckBox ID="cbOverride" runat="server" />
            </td>
        </tr>
        <tr>
            <th>
                Organization Name:
            </th>
            <td>
                <asp:TextBox ID="txtOrgName" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Save Changes" CssClass="submit" OnClick="btnSubmit_Click" />
                <ums:OutputMessage ID="omResult" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
