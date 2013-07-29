<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.Master" AutoEventWireup="true"
    CodeBehind="Conf-Domain.aspx.cs" Inherits="PPI.UMS.Web.Forms.Admin.Config.Conf_Domain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-head">
        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Admin,Menu_Config_Domain_Title %>"></asp:Label>
    </div>
    <div class="content-main">
        <ums:Dialog ID="dlgADMessage" runat="server" />
        <table class="form">
            <tr>
                <td class="header">
                    <asp:Label ID="Label8" runat="server" Text="<%$ Resources:Setup, Setup_ADConfigure_Domain %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtADFQDN" runat="server" CssClass="textbox" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Admin, Config_Domain_FQDNNoEdit %>"></asp:Label>
                </td>
            </tr>
            <tr class="required">
                <td class="header">
                    <asp:Label ID="Label9" runat="server" Text="<%$ Resources:Setup, Setup_ADConfigure_Username %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtADUsername" runat="server" CssClass="textbox-required"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None"
                        ValidationGroup="Domain" SetFocusOnError="true" ControlToValidate="txtADUsername"
                        ErrorMessage="<%$ Resources:Setup,Setup_Invalid_Username %>"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator4">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr class="required">
                <td class="header">
                    <asp:Label ID="Label10" runat="server" Text="<%$ Resources:Setup, Setup_ADConfigure_Password %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtADPassword" runat="server" CssClass="textbox-required" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None"
                        ValidationGroup="Domain" SetFocusOnError="true" ControlToValidate="txtADPassword"
                        ErrorMessage="<%$ Resources:Setup,Setup_Invalid_Password %>">
                    </asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator3">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr class="required">
                <td class="header">
                    <asp:Label ID="Label11" runat="server" Text="<%$ Resources:Setup, Setup_ADConfigure_VerifyPassword %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtADConfPassword" runat="server" CssClass="textbox-required" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                        ValidationGroup="Domain" SetFocusOnError="true" ControlToValidate="txtADConfPassword"
                        ErrorMessage="<%$ Resources:Setup,Setup_Invalid_Password %>"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator2">
                    </ajax:ValidatorCalloutExtender>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="None" SetFocusOnError="true"
                        ValidationGroup="Domain" ControlToValidate="txtADConfPassword" ControlToCompare="txtADPassword"
                        ErrorMessage="<%$ Resources:Setup,Setup_Invalid_ComparePassword %>"></asp:CompareValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="CompareValidator1">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
        </table>
        <p>
            <asp:Label ID="Label12" runat="server" Text="<%$ Resources:Admin, Config_Domain_Notice %>"></asp:Label>
        </p>
        <asp:Button ID="Button1" runat="server" CssClass="submit" Text="<%$ Resources:Admin,Config_Domain_SubmitText %>"
            OnClick="Button1_Click" ValidationGroup="Domain" OnClientClick="<%$ Resources:Admin,Config_Domain_Submit_Conf %>" />
    </div>
</asp:Content>
