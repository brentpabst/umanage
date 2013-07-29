<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.Master" AutoEventWireup="true"
    CodeBehind="Password.aspx.cs" Inherits="THS.UMS.UI.Forms.Users.Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
    <table class="form">
        <tbody>
            <tr>
                <th>
                    Current Password:
                </th>
                <td>
                    <asp:TextBox ID="txtCurrentPass" runat="server" TextMode="Password" CssClass="text-req"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter your current password!"
                        SetFocusOnError="True" ControlToValidate="txtCurrentPass" Display="None"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                        PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator1">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <th>
                    New Password:
                </th>
                <td>
                    <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" CssClass="text-req"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter your new password!"
                        SetFocusOnError="True" ControlToValidate="txtNewPass" Display="None"></asp:RequiredFieldValidator>
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
                        SetFocusOnError="True" ControlToValidate="txtConfPass" Display="None"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="text-invalid"
                        PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator3">
                    </ajax:ValidatorCalloutExtender>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Your passwords do not match!"
                        SetFocusOnError="true" ControlToCompare="txtNewPass" ControlToValidate="txtConfPass"
                        Display="None"></asp:CompareValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" HighlightCssClass="text-invalid"
                        PopupPosition="TopLeft" TargetControlID="CompareValidator1">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Change Password" CssClass="submit"
                        OnClick="btnSubmit_Click" />
                    <ums:OutputMessage ID="OutputMessage1" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
    <div class="user-info">
        <strong>Why can't I change my password?</strong>
        <br />
        <ol>
            <li>1. Have you used the password before? If so choose a new password.</li>
            <li>2. Make sure your password is secure. Use a number or character to make it a strong
                password.</li>
            <li>3. Contact your administrator if your password still won't change.</li>
        </ol>
    </div>
</asp:Content>
