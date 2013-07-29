<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.Master" AutoEventWireup="true"
    CodeBehind="User-Pass.aspx.cs" Inherits="PPI.UMS.Web.Forms.Users.User_Pass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title login">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:User, Menu_MyPassword_Title %>"></asp:Label>
    </div>
    <p>
        <asp:Label ID="lblSubTitle" runat="server"></asp:Label>
    </p>
    <ums:Dialog ID="dlgMessage" runat="server" />
    <table id="tblPassChange" runat="server" class="form">
        <tr class="required">
            <td class="header">
                <asp:Label ID="lblOldPass" runat="server" Text="<%$ Resources:User,Password_OldPass_Title %>"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOldPass" runat="server" CssClass="textbox-required" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                    SetFocusOnError="true" ControlToValidate="txtOldPass" ErrorMessage="<%$ Resources:User,Password_Change_Invalid_Password %>"></asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="textbox-invalid"
                    PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator1">
                </ajax:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr class="required">
            <td class="header">
                <asp:Label ID="lblNewPass" runat="server" Text="<%$ Resources:User,Password_NewPass_Title %>"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNewPass" runat="server" CssClass="textbox-required" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                    SetFocusOnError="true" ControlToValidate="txtNewPass" ErrorMessage="<%$ Resources:User,Password_Change_Invalid_Password %>"></asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="textbox-invalid"
                    PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator2">
                </ajax:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr class="required">
            <td class="header">
                <asp:Label ID="lblConfPass" runat="server" Text="<%$ Resources:User,Password_ConfPass_Title %>"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtConfPass" runat="server" CssClass="textbox-required" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None"
                    SetFocusOnError="true" ControlToValidate="txtConfPass" ErrorMessage="<%$ Resources:User,Password_Change_Invalid_Password %>"></asp:RequiredFieldValidator><asp:CompareValidator
                        ID="CompareValidator1" runat="server" Display="None" SetFocusOnError="true" ControlToValidate="txtConfPass"
                        ControlToCompare="txtNewPass" ErrorMessage="<%$ Resources:User,Password_Change_Invalid_Confirm %>"></asp:CompareValidator>
                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="textbox-invalid"
                    PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator3">
                </ajax:ValidatorCalloutExtender>
                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" HighlightCssClass="textbox-invalid"
                    PopupPosition="BottomLeft" TargetControlID="CompareValidator1">
                </ajax:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="<%$ Resources:User, Password_Change_Submit_Text %>"
                    CssClass="submit" OnClick="btnSubmit_Click" OnClientClick="<%$ Resources:User, Password_Change_Alert_Code %>" />
            </td>
        </tr>
    </table>
</asp:Content>
