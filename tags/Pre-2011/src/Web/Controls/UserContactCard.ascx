<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserContactCard.ascx.cs"
    Inherits="PPI.UMS.Web.Controls.UserContactCard" %>
<div class="contactcard">
    <div class="contactcard-head">
        <asp:Label ID="lblName" runat="server"></asp:Label>
    </div>
    <table>
        <tr>
            <td valign="top" class="image">
                <asp:Image ID="Image1" runat="server" />
            </td>
            <td valign="top">
                Title:
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                <br />
                Office Phone:
                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                <div class="contactcard-foot">
                    <asp:HyperLink ID="HyperLink1" runat="server" Text="E-mail"></asp:HyperLink>
                    |
                    <asp:HyperLink ID="HyperLink2" runat="server" Text="Details"></asp:HyperLink>
                </div>
            </td>
        </tr>
    </table>
</div>
