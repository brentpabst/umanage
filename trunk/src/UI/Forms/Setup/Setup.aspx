<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="THS.UMS.UI.Forms.Setup.Setup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body class="user">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="user-page">
                <div class="user-head">
                    <div class="left user-head-title">
                        uManage Installation
                    </div>
                    <div class="right user-head-name">
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="user-content">
                    <div class="left" style="width: 49%; margin-right: 2%;">
                        <div class="box">
                            <div class="head">
                                Instructions
                            </div>
                            <p>
                                <strong>Welcome to uManage!</strong>
                                <br />
                                To complete the installation of the system make sure to complete the tasks on this
                                screen. Additional configuration options are available once the system is installed.
                            </p>
                            <p>
                                You will not be able to leave this screen until all tasks have been verified. However,
                                you can close the browser and continue at any time.
                            </p>
                            <asp:Panel ID="pnlDatabase" runat="server">
                                <div class="head">
                                    Database
                                </div>
                                <p>
                                    The system database in an important part of uManage. At this stage the system database
                                    should have already been configured. If not make sure to read the installation instructions
                                    that ship with the uManage release to ensure you have properly installed the database.
                                </p>
                                <table class="form">
                                    <tbody>
                                        <tr>
                                            <th>
                                                Server/Host:
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtDbServer" runat="server" CssClass="text-req"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                Database/Initial Catalog:
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtDbCatalog" runat="server" CssClass="text-req"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                Use Integrated Security?
                                            </th>
                                            <td>
                                                <asp:RadioButtonList ID="rblDbWinSecurity" runat="server" RepeatDirection="Horizontal"
                                                    AutoPostBack="True" OnSelectedIndexChanged="rblDbWinSecurity_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="True" Selected="true"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="False"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <asp:Panel ID="pnlDbSqlAuth" runat="server">
                                            <tr>
                                                <th>
                                                    SQL Username:
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="txtDbUsername" runat="server" CssClass="text-req"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>
                                                    SQL Password:
                                                </th>
                                                <td>
                                                    <asp:TextBox ID="txtDbPassword" runat="server" CssClass="text-req"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlDirectory" runat="server">
                                <div class="head">
                                    Directory
                                </div>
                                <p>
                                    uManage requires information in order to connect to the directories on your network.
                                    If you have multiple domains within your forest make sure to specify an account
                                    with delegated permissions across all domains.
                                </p>
                                <table class="form">
                                    <tbody>
                                        <tr>
                                            <th>
                                                Root Forest Domain:
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtAdDomain" runat="server" CssClass="text-req"></asp:TextBox>
                                                <br />
                                                Example: mydomain.local
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                User Principal Name:
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtAdUsername" runat="server" CssClass="text-req"></asp:TextBox>
                                                <br />
                                                Example: user@mydomain.local
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                Password:
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtAdPassword" runat="server" CssClass="text-req"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlUser" runat="server">
                                <div class="head">
                                    User Permissions
                                </div>
                                <p>
                                    You must setup an initial administrative user. This user will have full access to
                                    uManage. Enter the User Principal Name (UPN) for the user in the textbox below.
                                </p>
                                <table class="form">
                                    <tbody>
                                        <tr>
                                            <th>
                                                User Principal Name:
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtUpnUser" runat="server" CssClass="text-req"></asp:TextBox>
                                                <br />
                                                Example: user@mydomain.local
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="left" style="width: 49%;">
                        <asp:Panel ID="pnlOther" runat="server" Visible="false">
                            <div class="box">
                                <div class="head">
                                    Other Settings
                                </div>
                                <table class="form">
                                    <tbody>
                                        <tr>
                                            <th>
                                                Application Title:
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtAppTitle" runat="server" CssClass="text-req"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                Application URL:
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtAppUrl" runat="server" CssClass="text-req"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <br />
                        </asp:Panel>
                        <div class="box">
                            <div class="head">
                                Finalize Installation
                            </div>
                            <div class="form">
                                <table class="form">
                                    <tbody>
                                        <tr>
                                            <th>
                                                Database Verified:
                                            </th>
                                            <td>
                                                <asp:Label ID="lblIsDatabaseVerified" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                Directory Verified:
                                            </th>
                                            <td>
                                                <asp:Label ID="lblIsDirectoryVerified" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                User Verified:
                                            </th>
                                            <td>
                                                <asp:Label ID="lblIsUserSecVerified" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnVerifyReqs" runat="server" Text="Verify Settings" CssClass="submit"
                                                    OnClick="btnVerifyReqs_Click" />
                                                <asp:Button ID="btnSubmit" runat="server" Text="Save Settings & Launch" CssClass="submit"
                                                    OnClick="btnSubmit_Click" />
                                                <br />
                                                <br />
                                                <ums:OutputMessage ID="omResult" runat="server" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="user-foot">
                    &copy; 2010 -
                    <%= DateTime.Today.Year %>
                    Tarheel Solutions, Inc. | <a href="http://umanage.codeplex.com" target="_blank">uManage</a>
                    - Version
                    <asp:Label ID="lblVersion" runat="server"></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="progress">
                <div class="progress-border">
                    <div class="progress-win">
                        <div class="progress-head">
                            Loading
                        </div>
                        <div class="progress-cont">
                            <div class="left" style="padding: 4px 15px 0 5px;">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Loading.gif" />
                            </div>
                            <div class="left">
                                Please Wait... Loading!
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="progress-foot">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="cancelPostback()">Cancel</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
