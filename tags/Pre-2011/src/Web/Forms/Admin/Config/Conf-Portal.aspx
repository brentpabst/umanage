<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="Conf-Portal.aspx.cs" Inherits="PPI.UMS.Web.Forms.Admin.Config.Conf_Portal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-head">
        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Admin,Menu_Config_Portal_Title %>"></asp:Label>
    </div>
    <div class="content-main">
        <ums:Dialog ID="Dialog1" runat="server" />
        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Admin,Config_Portal_Body %>"></asp:Label>
        <table class="form">
            <tr>
                <td>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                        <asp:ListItem Value="allowpassword" Text="<%$ Resources:Setup, Setup_PortalSettings_AllowPassChange %>"></asp:ListItem>
                        <asp:ListItem Value="displaynotes" Text="<%$ Resources:Setup, Setup_PortalSettings_DisplayNotes %>"></asp:ListItem>
                        <asp:ListItem Value="displaylocation" Text="<%$ Resources:Setup, Setup_PortalSettings_DisplayLocation %>"></asp:ListItem>
                        <asp:ListItem Value="displayphone" Text="<%$ Resources:Setup, Setup_PortalSettings_DisplayPhone %>"></asp:ListItem>
                        <asp:ListItem Value="displayorg" Text="<%$ Resources:Setup, Setup_PortalSettings_DisplayOrg %>"></asp:ListItem>
                        <asp:ListItem Value="displayphoto" Text="<%$ Resources:Setup, Setup_PortalSettings_DisplayPhoto %>"></asp:ListItem>
                        <asp:ListItem Value="allowany" Text="<%$ Resources:Setup, Setup_PortalSettings_AllowChanges %>"></asp:ListItem>
                        <asp:ListItem Value="allowname" Text="<%$ Resources:Setup, Setup_PortalSettings_AllowName %>"></asp:ListItem>
                        <asp:ListItem Value="allowemail" Text="<%$ Resources:Setup, Setup_PortalSettings_AllowEmail %>"></asp:ListItem>
                        <asp:ListItem Value="allowlocation" Text="<%$ Resources:Setup, Setup_PortalSettings_AllowLocation %>"></asp:ListItem>
                        <asp:ListItem Value="allowphone" Text="<%$ Resources:Setup, Setup_PortalSettings_AllowPhone %>"></asp:ListItem>
                        <asp:ListItem Value="allowphoto" Text="<%$ Resources:Setup, Setup_PortalSettings_AllowPhoto %>"></asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="<%$ Resources:Admin,Config_Portal_SubmitText %>"
                        CssClass="submit" ValidationGroup="SMTP" OnClick="btnSubmit_Click" OnClientClick="<%$ Resources:Admin,Config_Portal_Submit_Conf %>" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
