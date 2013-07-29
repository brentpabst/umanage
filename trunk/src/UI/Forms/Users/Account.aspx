<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.Master" AutoEventWireup="true"
    CodeBehind="Account.aspx.cs" Inherits="THS.UMS.UI.Forms.Users.Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <table class="grid">
        <thead>
            <tr>
                <th>
                    <asp:Label ID="lblHeadUsername" runat="server" Text="Full Username"></asp:Label>
                </th>
                <th>
                    <asp:Label ID="lblHeadAccountLocked" runat="server" Text="Account Locked"></asp:Label>
                </th>
                <th>
                    <asp:Label ID="lblHeadAccountExp" runat="server" Text="Account Expires"></asp:Label>
                </th>
                <th>
                    <asp:Label ID="lblHeadPassExp" runat="server" Text="Password Expires"></asp:Label>
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="lblUsername" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAccountLocked" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAccountExp" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPasswordExp" runat="server"></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <br />
    <div class="user-info">
        <strong>Administrator Information:</strong>
        <br />
        <asp:Label ID="lblDn" runat="server"></asp:Label>
    </div>
</asp:Content>
