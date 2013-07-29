<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="Conf-SMTP.aspx.cs" Inherits="PPI.UMS.Web.Forms.Admin.Config.Conf_SMTP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-head">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Admin,Menu_Config_SMTP_Title %>"></asp:Label>
    </div>
    <div class="content-main">
        <ums:Dialog ID="Dialog1" runat="server" />
        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Admin,Config_SMTP_Body %>"></asp:Label>
        <table class="form">
            <tr class="required">
                <td class="header">
                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Admin,Config_SMTP_Server_Title %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtServer" runat="server" CssClass="textbox-required"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                        ValidationGroup="SMTP" SetFocusOnError="true" ControlToValidate="txtServer" ErrorMessage="<%$ Resources:Admin,Config_SMTP_Server_Required %>">
                    </asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator1">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr class="required">
                <td class="header">
                    <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Admin,Config_SMTP_Port_Title %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPort" runat="server" CssClass="textbox-required"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                        ValidationGroup="SMTP" SetFocusOnError="true" ControlToValidate="txtPort" ErrorMessage="<%$ Resources:Admin,Config_SMTP_Port_Required %>"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator2">
                    </ajax:ValidatorCalloutExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="None"
                        ErrorMessage="<%$ Resources:Admin,Config_SMTP_Port_InValid %>" SetFocusOnError="True"
                        ValidationExpression="^\d+$" ControlToValidate="txtPort" ValidationGroup="SMTP"></asp:RegularExpressionValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RegularExpressionValidator3">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr class="required">
                <td class="header">
                    <asp:Label ID="Label6" runat="server" Text="<%$ Resources:Admin,Config_SMTP_From_Title %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFrom" runat="server" CssClass="textbox-required"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None"
                        ValidationGroup="SMTP" SetFocusOnError="true" ControlToValidate="txtFrom" ErrorMessage="<%$ Resources:Admin,Config_SMTP_From_Required %>"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator3">
                    </ajax:ValidatorCalloutExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"
                        ErrorMessage="<%$ Resources:Admin,Config_SMTP_From_InValid %>" SetFocusOnError="True"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtFrom"
                        ValidationGroup="SMTP"></asp:RegularExpressionValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RegularExpressionValidator1">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="Label7" runat="server" Text="<%$ Resources:Admin,Config_SMTP_SSL_Title %>"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbSSL" runat="server" />
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="upnlCredAuth" runat="server">
            <ContentTemplate>
                <table class="form">
                    <tr>
                        <td class="header">
                            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:Admin,Config_SMTP_Auth_Title %>"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rblAuthMode" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow" AutoPostBack="True" OnSelectedIndexChanged="rblAuthMode_SelectedIndexChanged">
                                <asp:ListItem Text="None" Value="NA"></asp:ListItem>
                                <asp:ListItem Text="Username/Password" Value="CRED"></asp:ListItem>
                                <asp:ListItem Text="NTLM/Windows" Value="WIN"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="pnlCRED" runat="server">
                    <table class="form">
                        <tr class="required">
                            <td class="header">
                                <asp:Label ID="Label9" runat="server" Text="<%$ Resources:Admin,Config_SMTP_User_Title %>"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="textbox-required"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None"
                                    ValidationGroup="SMTP" SetFocusOnError="true" ControlToValidate="txtUsername"
                                    ErrorMessage="<%$ Resources:Admin,Config_SMTP_User_Required %>">
                                </asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" HighlightCssClass="textbox-invalid"
                                    PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator4">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr class="required">
                            <td class="header">
                                <asp:Label ID="Label10" runat="server" Text="<%$ Resources:Admin,Config_SMTP_Pass_Title %>"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPass" runat="server" CssClass="textbox-required" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None"
                                    ValidationGroup="SMTP" SetFocusOnError="true" ControlToValidate="txtPass" ErrorMessage="<%$ Resources:Admin,Config_SMTP_Pass_Required %>">    </asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" HighlightCssClass="textbox-invalid"
                                    PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator5">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr class="required">
                            <td class="header">
                                <asp:Label ID="Label11" runat="server" Text="<%$ Resources:Admin,Config_SMTP_ConfPass_Title %>"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtConfPass" runat="server" CssClass="textbox-required" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="None"
                                    ValidationGroup="SMTP" SetFocusOnError="true" ControlToValidate="txtConfPass"
                                    ErrorMessage="<%$ Resources:Admin,Config_SMTP_ConfPass_Required %>">
                                </asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" HighlightCssClass="textbox-invalid"
                                    PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator6">
                                </ajax:ValidatorCalloutExtender>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="None" ValidationGroup="SMTP"
                                    SetFocusOnError="true" ControlToCompare="txtPass" ControlToValidate="txtConfPass"
                                    ErrorMessage="<%$ Resources:Admin,Config_SMTP_ConfPass_NoCompare %>">
                                </asp:CompareValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" HighlightCssClass="textbox-invalid"
                                    PopupPosition="BottomLeft" TargetControlID="CompareValidator1">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Admin,Config_SMTP_Notice %>"></asp:Label>
        <table class="form">
            <tr class="required">
                <td class="header">
                    <asp:Label ID="Label12" runat="server" Text="<%$ Resources:Admin,Config_SMTP_Test_Title %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTestEmail" runat="server" CssClass="textbox-required"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="None"
                        ValidationGroup="SMTP" SetFocusOnError="true" ControlToValidate="txtTestEmail"
                        ErrorMessage="<%$ Resources:Admin,Config_SMTP_Test_Required %>"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator7">
                    </ajax:ValidatorCalloutExtender>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="None"
                        ErrorMessage="<%$ Resources:Admin,Config_SMTP_Test_InValid %>" SetFocusOnError="True"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtTestEmail"
                        ValidationGroup="SMTP"></asp:RegularExpressionValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RegularExpressionValidator2">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="<%$ Resources:Admin,Config_SMTP_SubmitText %>"
                        CssClass="submit" ValidationGroup="SMTP" OnClick="btnSubmit_Click" OnClientClick="<%$ Resources:Admin,Config_SMTP_Submit_Conf %>" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
