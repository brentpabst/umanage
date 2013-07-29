<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="SysSmtp.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.SysSmtp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>Configure Mail Settings</strong>
        <br />
        The application uses an active SMTP server to send notifications to users and other
        system functions. To monitor all outbound e-mail messages please visit the Auto
        Utilities instead.
    </p>
    <asp:Label ID="lblConfError" runat="server" Visible="false" Text="<p>There was an error loading the configuration file.  Make sure you have properly configured the Auto Utility configuration file and that the Application Pool user identity has permission to read and update the file.</p>"></asp:Label>
    <asp:Panel ID="pnlSettings" runat="server">
        <table class="form">
            <tbody>
                <tr>
                    <th>
                        Server:
                    </th>
                    <td>
                        <asp:TextBox ID="txtServer" runat="server" CssClass="text-req"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter the server to use!"
                            SetFocusOnError="True" ControlToValidate="txtServer" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator1">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th>
                        Port:
                    </th>
                    <td>
                        <asp:TextBox ID="txtPort" runat="server" CssClass="text-req"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter the port to use!"
                            SetFocusOnError="True" ControlToValidate="txtPort" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator2">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th>
                        From Address:
                    </th>
                    <td>
                        <asp:TextBox ID="txtFrom" runat="server" CssClass="text-req"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter the from address to use!"
                            SetFocusOnError="True" ControlToValidate="txtFrom" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator3">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th>
                        Use SSL/TLS?:
                    </th>
                    <td>
                        <asp:CheckBox ID="cbSsl" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th>
                        Authentication Mode:
                    </th>
                    <td>
                        <asp:RadioButtonList ID="rblAuthMode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblAuthMode_SelectedIndexChanged"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Text="None" Value="NA"></asp:ListItem>
                            <asp:ListItem Text="Basic" Value="BA"></asp:ListItem>
                            <asp:ListItem Text="Windows/NTLM" Value="WI"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <tr>
                            <th>
                                Username:
                            </th>
                            <td>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="text-req"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You must enter the username to use!"
                                    SetFocusOnError="True" ControlToValidate="txtUsername" Display="None"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" HighlightCssClass="text-invalid"
                                    PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator4">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Password:
                            </th>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="text-req"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="You must enter the password!"
                                    SetFocusOnError="True" ControlToValidate="txtPassword" Display="None"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" HighlightCssClass="text-invalid"
                                    PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator5">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Confirm Password:
                            </th>
                            <td>
                                <asp:TextBox ID="txtConfPassword" runat="server" TextMode="Password" CssClass="text-req"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="You must enter the confirmation password!"
                                    SetFocusOnError="True" ControlToValidate="txtConfPassword" Display="None"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" HighlightCssClass="text-invalid"
                                    PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator6">
                                </ajax:ValidatorCalloutExtender>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Your passwords do not match!"
                                    SetFocusOnError="true" ControlToCompare="txtPassword" ControlToValidate="txtConfPassword"
                                    Display="None"></asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" HighlightCssClass="text-invalid"
                                    PopupPosition="TopLeft" TargetControlID="CompareValidator1">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <tr>
                    <th>
                        Test Address:
                    </th>
                    <td>
                        <asp:TextBox ID="txtTest" runat="server" CssClass="text-req"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="You must enter the e-mail address to test with!"
                            SetFocusOnError="True" ControlToValidate="txtTest" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator7">
                        </ajax:ValidatorCalloutExtender>
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
            </tbody>
        </table>
    </asp:Panel>
</asp:Content>
