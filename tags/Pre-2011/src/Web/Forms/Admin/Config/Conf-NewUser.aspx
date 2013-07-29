<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="Conf-NewUser.aspx.cs" Inherits="PPI.UMS.Web.Forms.Admin.Config.Conf_NewUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-head">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Admin,Menu_Config_NewUser_Title %>"></asp:Label>
    </div>
    <div class="content-main">
        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Admin,Config_NewUser_Body %>"></asp:Label>
        <table class="form">
            <tr>
                <td class="header">
                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Admin,Config_NewUser_Enable %>"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rblEnableCreation" runat="server" RepeatDirection="Horizontal"
                        AutoPostBack="True" OnSelectedIndexChanged="rblEnableCreation_SelectedIndexChanged">
                        <asp:ListItem Text="<%$ Resources:Global,Yes %>" Value="True"></asp:ListItem>
                        <asp:ListItem Text="<%$ Resources:Global,No %>" Value="False"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <hr />
        <asp:Panel ID="pnlOptions" runat="server">
            <ums:Dialog ID="dlg" runat="server" />
            <table class="form">
                <tr>
                    <td class="group" colspan="2">
                        <strong>
                            <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Admin,Config_NewUser_Format %>"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td class="header vtop">
                        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Admin,Config_NewUser_FormatTitle %>"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="<%$ Resources:Admin,Config_NewUser_FormatStrings %>"></asp:Label>
                    </td>
                </tr>
                <tr class="required">
                    <td class="header vtop">
                        <asp:Label ID="Label7" runat="server" Text="<%$ Resources:Admin,Config_NewUser_FormatTest %>"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFormat" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources:Admin,Config_NewUser_FormatTest_Missing %>"
                            Display="None" SetFocusOnError="true" ControlToValidate="txtFormat"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1" HighlightCssClass="textbox-invalid"
                            PopupPosition="BottomLeft">
                        </asp:ValidatorCalloutExtender>
                        <br />
                        <asp:LinkButton ID="lbTest" runat="server" OnClick="lbTest_Click" Text="<%$ Resources:Admin,Config_NewUser_FormatTest_Button %>"></asp:LinkButton>:
                        <asp:Label ID="lblSampleName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="group" colspan="2">
                        <strong>
                            <asp:Label ID="Label16" runat="server" Text="<%$ Resources:Admin,Config_NewUser_Container %>"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td class="header vtop">
                        <asp:Label ID="Label17" runat="server" Text="<%$ Resources:Admin,Config_NewUser_DN %>"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDN" runat="server" CssClass="textbox"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label18" runat="server" Text="<%$ Resources:Admin,Config_NewUser_DN_Instructions %>"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="group" colspan="2">
                        <strong>
                            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:Admin,Config_NewUser_Company %>"></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td class="header">
                        <asp:Label ID="Label9" runat="server" Text="<%$ Resources:Admin,Config_NewUser_Name %>"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="header">
                        <asp:Label ID="Label10" runat="server" Text="<%$ Resources:Admin,Config_NewUser_Address %>"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="header">
                        <asp:Label ID="Label11" runat="server" Text="<%$ Resources:Admin,Config_NewUser_City %>"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="header">
                        <asp:Label ID="Label12" runat="server" Text="<%$ Resources:Admin,Config_NewUser_State %>"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtState" runat="server" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="header">
                        <asp:Label ID="Label13" runat="server" Text="<%$ Resources:Admin,Config_NewUser_Postal %>"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPostal" runat="server" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="header">
                        <asp:Label ID="Label14" runat="server" Text="<%$ Resources:Admin,Config_NewUser_Country %>"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCountry" runat="server" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="header">
                        <asp:Label ID="Label15" runat="server" Text="<%$ Resources:Admin,Config_NewUser_Phone %>"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" CssClass="submit" Text="<%$ Resources:Admin,Config_NewUser_Save %>"
                            OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
