<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="AppSettings.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.AppSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>Portal Settings</strong>
        <br />
        These settings affect how the portal appears to users.
    </p>
    <table class="form">
        <tbody>
            <tr>
                <td>
                    <asp:CheckBoxList ID="cblSettings" runat="server">
                        <asp:ListItem Value="DisplayUserLocationSection" Text="Display Address Information"></asp:ListItem>
                        <asp:ListItem Value="DisplayUserPhoneSection" Text="Display Phone Information"></asp:ListItem>
                        <asp:ListItem Value="DisplayUserOrganizationSection" Text="Display Organization Information"></asp:ListItem>
                        <asp:ListItem Value="DisplayUserPhotoSection" Text="Display Photo"></asp:ListItem>
                        <asp:ListItem Value="AllowUserAttibChanges" Text="Allow Information Changes (Overrides All Others)"></asp:ListItem>
                        <asp:ListItem Value="AllowUserNameChanges" Text="Allow Name Changes"></asp:ListItem>
                        <asp:ListItem Value="AllowUserEmailChanges" Text="Allow E-Mail Changes"></asp:ListItem>
                        <asp:ListItem Value="AllowUserLocationChanges" Text="Allow Address Changes"></asp:ListItem>
                        <asp:ListItem Value="AllowUserPhoneChanges" Text="Allow Phone Changes"></asp:ListItem>
                        <asp:ListItem Value="AllowUserPhotoChanges" Text="Allow Photo Changes"></asp:ListItem>
                        <asp:ListItem Value="AllowUserPasswordChanges" Text="Allow Password Changes"></asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Save Changes" CssClass="submit" OnClick="btnSubmit_Click" />
                    <ums:OutputMessage ID="omResult" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
