<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.Master" AutoEventWireup="true"
    CodeBehind="User-Account.aspx.cs" Inherits="PPI.UMS.Web.Forms.Users.User_Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title about">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:User, Menu_MyAccount_Title %>"></asp:Label>
    </div>
    <p>
        <asp:Label ID="lblSubTitle" runat="server"></asp:Label>
    </p>
    <table class="form">
        <tr>
            <td class="header">
                <asp:Label ID="lblHeadUsername" runat="server" Text="<%$ Resources:User,MyAccount_Username_Header %>"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblUsername" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="header">
                <asp:Label ID="lblHeadAccountLocked" runat="server" Text="<%$ Resources:User,MyAccount_AccountLocked_Header %>"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAccountLocked" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="header">
                <asp:Label ID="lblHeadAccountExp" runat="server" Text="<%$ Resources:User,MyAccount_AccountExp_Header %>"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAccountExp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="header">
                <asp:Label ID="lblHeadPassExp" runat="server" Text="<%$ Resources:User,MyAccount_PasswordExp_Header %>"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPasswordExp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="header vtop">
                <asp:Label ID="lblHeadNotes" runat="server" Text="<%$ Resources:User,MyAccount_Notes_Header %>"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" ReadOnly="true" Rows="5"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
