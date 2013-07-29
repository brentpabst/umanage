<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="SysReset.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.SysReset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <span style="color: Red; font-weight: bold;">STOP! READ THIS FIRST!</span>
        <br />
        Ensure you understand the specifics below before using the Application Reset functionality.
        It could cause potential loss of information and settings.
    </p>
    <p>
        <strong>What Should I Know?</strong>
        <br />
        The application reset function was designed primarily for developers and system
        administrators that need to reset the system to it's out of the box, factory default,
        fresh smelling state. This function primarily un-does everything the setup wizard
        sets up behind the scenes. It even re-enables the setup wizard once complete. For
        those who require more detail here is what get's modified:
    </p>
    <ul class="list">
        <li>Setup Wizard Re-Enabled</li>
        <li>Database Connection String is Removed (Data is not affected)</li>
        <li>Active Directory Connection is severed</li>
        <li>The Web.Config file is decrypted</li>
        <li>All App Settings are reset</li>
        <li>For security reasons the application is taken offline (Protection from evil-doers)</li>
    </ul>
    <p>
        Only do this if you want to re-configure the application!
    </p>
    <div class="form">
        <asp:Button ID="btnSubmit" runat="server" Text="Reset Application" CssClass="submit"
            OnClick="btnSubmit_Click" />
        <ums:OutputMessage ID="omResult" runat="server" />
    </div>
</asp:Content>
