<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.Master" AutoEventWireup="true"
    CodeBehind="UsrDetail.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.User.UsrDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="form">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/admin/user/list">Return to User List</asp:HyperLink>
    </div>
    <br />
    <ajax:TabContainer ID="TabContainer1" runat="server">
        <ajax:TabPanel runat="server" HeaderText="General" ID="tpnGeneral">
            <ContentTemplate>
                <ums:UserInfo ID="UserInfo1" runat="server" />
            </ContentTemplate>
        </ajax:TabPanel>
        <ajax:TabPanel runat="server" HeaderText="Account" ID="tpnAccount">
            <ContentTemplate>
                <div class="box">
                    <div class="head">
                        <asp:Label ID="Label1" runat="server" Text="User Account for:"></asp:Label>
                        <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                    </div>
                    <table id="Table1" class="form">
                        <tbody>
                            <tr>
                                <th>
                                    Full Username:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtUserName" runat="server" Text="" CssClass="text" />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Account Locked:
                                </th>
                                <td>
                                    <asp:CheckBox runat="server" ID="chkUnlock" AutoPostBack="true" OnCheckedChanged="chkUnlock_CheckedChanged" />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="lblDisableWarning" runat="server" ForeColor="Red" Visible="false"
                                        Text="Account is Disabled: " />
                                    <asp:Label ID="lblDisable" runat="server" Text="Disable Account: " />
                                </th>
                                <td>
                                    <asp:LinkButton runat="server" ID="lnkDisable" Text="Disable" OnClick="lnkDisable_Click"
                                        OnClientClick="return confirm('Are you certain you want to disable this user?');"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <br />
                <div class="box">
                    <div class="head">
                        <asp:Label ID="Label2" runat="server" Text="Reset Password"></asp:Label>
                    </div>
                    <table id="Table2" class="form">
                        <tbody>
                            <tr>
                                <th>
                                    New Password:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" CssClass="text-req"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter your new password!"
                                        SetFocusOnError="True" ControlToValidate="txtNewPass" Display="None" ValidationGroup="chgPassword"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="text-invalid"
                                        PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator2">
                                    </ajax:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Confirm Password:
                                </th>
                                <td>
                                    <asp:TextBox ID="txtConfPass" runat="server" TextMode="Password" CssClass="text-req"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must confirm your new password!"
                                        SetFocusOnError="True" ControlToValidate="txtConfPass" Display="None" ValidationGroup="chgPassword"></asp:RequiredFieldValidator>
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="text-invalid"
                                        PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator3">
                                    </ajax:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Your passwords do not match!"
                                        SetFocusOnError="true" ControlToCompare="txtNewPass" ControlToValidate="txtConfPass"
                                        Display="None" ValidationGroup="chgPassword"></asp:CompareValidator>
                                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                                        PopupPosition="TopLeft" TargetControlID="CompareValidator1">
                                    </ajax:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Require Password Change:
                                </th>
                                <td>
                                    <asp:CheckBox ID="chkChangePass" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                </th>
                                <td>
                                    <asp:LinkButton runat="server" ID="lnkUpdatePass" Text="Update Password" OnClick="lnkUpdatePass_Click"
                                        ValidationGroup="chgPassword" />
                                    <ums:OutputMessage ID="OutputMessage1" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </ContentTemplate>
        </ajax:TabPanel>
        <ajax:TabPanel runat="server" ID="pnlMemberOf" HeaderText="Groups">
            <ContentTemplate>
                <div class="box">
                    <div class="head">
                        Group Membership
                    </div>
                    <asp:GridView ID="grdGroups" runat="server" CssClass="grid" EmptyDataText="No Groups Found"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Group Name" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </ajax:TabPanel>
    </ajax:TabContainer>
</asp:Content>
