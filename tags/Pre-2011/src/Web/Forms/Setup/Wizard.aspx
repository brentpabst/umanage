<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wizard.aspx.cs" Inherits="PPI.UMS.Web.Forms.Setup.Wizard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body class="user">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
        <div class="user-page">
            <div class="user-logo">
                <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/UMS-Logo.png" AlternateText="Logo" />
            </div>
            <div class="user-content">
                <div class="user-content-head">
                </div>
                <div class="user-content-mid">
                    <div class="title setup">
                        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Setup, Setup_Title %>"></asp:Label>
                    </div>
                    <asp:Wizard ID="Wizard1" runat="server" DisplaySideBar="False" FinishDestinationPageUrl="~/Default.aspx"
                        Width="100%" OnActiveStepChanged="Wizard1_ActiveStepChanged" OnFinishButtonClick="Wizard1_FinishButtonClick">
                        <FinishCompleteButtonStyle CssClass="submit" />
                        <FinishPreviousButtonStyle CssClass="submit" />
                        <StartNextButtonStyle CssClass="submit" />
                        <StepNextButtonStyle CssClass="submit" />
                        <StepPreviousButtonStyle CssClass="submit" />
                        <WizardSteps>
                            <asp:WizardStep ID="wzdWelcome" runat="server" AllowReturn="false">
                                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Setup, Setup_WelcomeMessage %>"></asp:Label>
                            </asp:WizardStep>
                            <asp:WizardStep ID="wzdProcess" runat="server" AllowReturn="false">
                                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Setup, Setup_ProcessMessage %>"></asp:Label>
                            </asp:WizardStep>
                            <asp:WizardStep ID="wzdLicense" runat="server" AllowReturn="false">
                                <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Setup, Setup_LicenseMessage %>"></asp:Label>
                                <asp:TextBox ID="txtLicense" runat="server" TextMode="MultiLine" Width="100%" Rows="5"></asp:TextBox>
                                <p>
                                    <asp:Label ID="Label6" runat="server" Text="<%$ Resources:Setup, Setup_LicenseAgreement %>"></asp:Label>
                                </p>
                            </asp:WizardStep>
                            <asp:WizardStep ID="wzdDomain" runat="server" AllowReturn="false">
                                <asp:RadioButton ID="rbDomainConnect" runat="server" Visible="false" />
                                <p>
                                    <strong>
                                        <asp:Label ID="Label7" runat="server" Text="<%$ Resources:Setup, Setup_ADConfigure_Title %>"></asp:Label></strong>
                                </p>
                                <ums:Dialog ID="dlgADMessage" runat="server" />
                                <table class="form">
                                    <tr>
                                        <td class="header">
                                            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:Setup, Setup_ADConfigure_Domain %>"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtADFQDN" runat="server" CssClass="textbox"></asp:TextBox>
                                            <ajax:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtADFQDN"
                                                WatermarkCssClass="textbox watermarktext" WatermarkText="yourdomain.ext">
                                            </ajax:TextBoxWatermarkExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                                                SetFocusOnError="true" ControlToValidate="txtADFQDN" ErrorMessage="<%$ Resources:Setup,Setup_Invalid_Domain %>"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="textbox-invalid"
                                                PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator1">
                                            </ajax:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="header">
                                            <asp:Label ID="Label9" runat="server" Text="<%$ Resources:Setup, Setup_ADConfigure_Username %>"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtADUsername" runat="server" CssClass="textbox-required"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None"
                                                SetFocusOnError="true" ControlToValidate="txtADUsername" ErrorMessage="<%$ Resources:Setup,Setup_Invalid_Username %>"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" HighlightCssClass="textbox-invalid"
                                                PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator4">
                                            </ajax:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="header">
                                            <asp:Label ID="Label10" runat="server" Text="<%$ Resources:Setup, Setup_ADConfigure_Password %>"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtADPassword" runat="server" CssClass="textbox-required" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None"
                                                SetFocusOnError="true" ControlToValidate="txtADPassword" ErrorMessage="<%$ Resources:Setup,Setup_Invalid_Password %>">
                                            </asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="textbox-invalid"
                                                PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator3">
                                            </ajax:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="header">
                                            <asp:Label ID="Label11" runat="server" Text="<%$ Resources:Setup, Setup_ADConfigure_VerifyPassword %>"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtADConfPassword" runat="server" CssClass="textbox-required" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                                                SetFocusOnError="true" ControlToValidate="txtADConfPassword" ErrorMessage="<%$ Resources:Setup,Setup_Invalid_Password %>"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="textbox-invalid"
                                                PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator2">
                                            </ajax:ValidatorCalloutExtender>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="None" SetFocusOnError="true"
                                                ControlToValidate="txtADConfPassword" ControlToCompare="txtADPassword" ErrorMessage="<%$ Resources:Setup,Setup_Invalid_ComparePassword %>"></asp:CompareValidator>
                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" HighlightCssClass="textbox-invalid"
                                                PopupPosition="BottomLeft" TargetControlID="CompareValidator1">
                                            </ajax:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                </table>
                                <p>
                                    <asp:Label ID="Label12" runat="server" Text="<%$ Resources:Setup, Setup_ADConfigure_TestPrompt %>"></asp:Label>
                                </p>
                            </asp:WizardStep>
                            <asp:WizardStep ID="wzdDatabase" runat="server" AllowReturn="false">
                                <asp:RadioButton ID="rbDatabaseConnect" runat="server" Visible="false" />
                                <p>
                                    <strong>
                                        <asp:Label ID="Label15" runat="server" Text="<%$ Resources:Setup, Setup_Database_Title %>"></asp:Label>
                                    </strong>
                                </p>
                                <p>
                                    <asp:Label ID="Label16" runat="server" Text="<%$ Resources:Setup, Setup_Database_Message %>"></asp:Label>
                                </p>
                                <ums:Dialog ID="dlgDatabase" runat="server" />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="cbEnableDbSetup" runat="server" Text="<%$ Resources:Setup,Setup_Database_AutoConfigure %>"
                                            AutoPostBack="true" OnCheckedChanged="cbEnableDbSetup_CheckedChanged" Checked="true" />
                                        <asp:Panel ID="pnlDbDetails" runat="server">
                                            <table class="form">
                                                <tr>
                                                    <td class="header">
                                                        <asp:Label ID="Label17" runat="server" Text="<%$ Resources:Setup, Setup_Database_Server %>"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDbServer" runat="server" CssClass="textbox-required"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None"
                                                            SetFocusOnError="true" ControlToValidate="txtDbServer" ErrorMessage="<%$ Resources:Setup,Setup_Invalid_DbServer %>"></asp:RequiredFieldValidator>
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" HighlightCssClass="textbox-invalid"
                                                            PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator5">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="header">
                                                        <asp:Label ID="Label18" runat="server" Text="<%$ Resources:Setup, Setup_Database_Password %>"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDbSaPass" runat="server" CssClass="textbox-required" TextMode="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="None"
                                                            SetFocusOnError="true" ControlToValidate="txtDbSaPass" ErrorMessage="<%$ Resources:Setup,Setup_Invalid_Password %>"></asp:RequiredFieldValidator>
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" HighlightCssClass="textbox-invalid"
                                                            PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator6">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="header">
                                                        <asp:Label ID="Label20" runat="server" Text="<%$ Resources:Setup, Setup_Database_UserAccount %>"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAddUserRoles" runat="server" CssClass="textbox-required"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="None"
                                                            SetFocusOnError="true" ControlToValidate="txtAddUserRoles" ErrorMessage="<%$ Resources:Setup,Setup_Invalid_UserAccount %>"></asp:RequiredFieldValidator>
                                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" HighlightCssClass="textbox-invalid"
                                                            PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator7">
                                                        </ajax:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <p>
                                    <asp:Label ID="Label19" runat="server" Text="<%$ Resources:Setup, Setup_Database_Footer %>"></asp:Label>
                                </p>
                            </asp:WizardStep>
                            <asp:WizardStep ID="wzdPortal" runat="server" AllowReturn="false">
                                <p>
                                    <asp:Label ID="Label13" runat="server" Text="<%$ Resources:Setup, Setup_PortalSettings_Title %>"></asp:Label>
                                </p>
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                                    <asp:ListItem Value="AllowUserPasswordChanges" Text="<%$ Resources:Setup, Setup_PortalSettings_AllowPassChange %>"
                                        Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="DisplayUserAccountNotes" Text="<%$ Resources:Setup, Setup_PortalSettings_DisplayNotes %>"
                                        Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="DisplayUserLocationSection" Text="<%$ Resources:Setup, Setup_PortalSettings_DisplayLocation %>"
                                        Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="DisplayUserPhoneSection" Text="<%$ Resources:Setup, Setup_PortalSettings_DisplayPhone %>"
                                        Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="DisplayUserPhotoSection" Text="<%$ Resources:Setup, Setup_PortalSettings_DisplayPhoto %>"
                                        Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="DisplayUserOrganizationSection" Text="<%$ Resources:Setup, Setup_PortalSettings_DisplayOrg %>"
                                        Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="AllowUserAttibChanges" Text="<%$ Resources:Setup, Setup_PortalSettings_AllowChanges %>"
                                        Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="AllowUserNameChanges" Text="<%$ Resources:Setup, Setup_PortalSettings_AllowName %>"
                                        Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="AllowUserEmailChanges" Text="<%$ Resources:Setup, Setup_PortalSettings_AllowEmail %>"
                                        Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="AllowUserLocationChanges" Text="<%$ Resources:Setup, Setup_PortalSettings_AllowLocation %>"
                                        Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="AllowUserPhoneChanges" Text="<%$ Resources:Setup, Setup_PortalSettings_AllowPhone %>"
                                        Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="AllowUserPhotoChanges" Text="<%$ Resources:Setup, Setup_PortalSettings_AllowPhoto %>"
                                        Selected="True"></asp:ListItem>
                                </asp:CheckBoxList>
                            </asp:WizardStep>
                            <asp:WizardStep ID="wzdSummary" runat="server" Title="Confirmation" AllowReturn="false">
                                <p>
                                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Setup, Setup_Summary_Title %>"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lblDomain" runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDomainController" runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblUsername" runat="server"></asp:Label>
                                    <asp:Label ID="lblPassword" runat="server" Visible="false"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lblDbServer" runat="server"></asp:Label>
                                    <asp:Label ID="lblDbPassword" runat="server" Visible="false"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDbCatalog" runat="server"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDbUser" runat="server"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lblSettings" runat="server"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="Label14" runat="server" Text="<%$ Resources:Setup, Setup_Summary_Prompt %>"></asp:Label>
                                </p>
                            </asp:WizardStep>
                        </WizardSteps>
                    </asp:Wizard>
                </div>
                <div class="user-content-foot">
                </div>
            </div>
            <div class="user-copy-info">
                <asp:Label ID="lblCopyright" runat="server" Text="<%$ Resources:Global, CopyrightTag %>"></asp:Label>
                <br />
                <asp:Label ID="lblOpenSource" runat="server" Text="<%$ Resources:Global, OpenSourceTag %>"></asp:Label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
