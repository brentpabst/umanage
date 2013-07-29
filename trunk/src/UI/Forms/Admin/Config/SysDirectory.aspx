<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="SysDirectory.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.SysDirectory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>Active Directory Settings</strong>
        <br />
        You can change the user account used to interface with the directory here. You cannot
        change the directory name once the application is configured, use the application
        reset function instead.
    </p>
    <p>
        <strong>Note:</strong> If your organization utilizes multiple directories (a forest with multiple domains
        all trusted) this account should reside at your top most directory. Make sure it
        has been granted proper permissions to all child domains as well, this system will
        not check permissions on child domains.
    </p>
    <table class="form">
        <tbody>
            <tr>
                <th>
                    Current Directory:
                </th>
                <td>
                    <asp:TextBox ID="txtDirectory" runat="server" CssClass="text" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Username:
                </th>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="text-req"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter the username to use!"
                        SetFocusOnError="True" ControlToValidate="txtUsername" Display="None"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                        PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator1">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <th>
                    Password:
                </th>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="text-req" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter the password to use!"
                        SetFocusOnError="True" ControlToValidate="txtPassword" Display="None"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="text-invalid"
                        PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator2">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Save Changes" CssClass="submit" OnClientClick="return confirm('Before the changes are made the system will perform a test to ensure the account specified has all required permissions.\r\n\r\nAre you sure you want to proceed?');"
                        OnClick="btnSubmit_Click" />
                    <ums:OutputMessage ID="omResult" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
