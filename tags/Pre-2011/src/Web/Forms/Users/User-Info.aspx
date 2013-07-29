<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.Master" AutoEventWireup="true"
    CodeBehind="User-Info.aspx.cs" Inherits="PPI.UMS.Web.Forms.Users.User_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title about">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:User, Menu_AboutMe_Title %>"></asp:Label>
    </div>
    <p>
        <asp:Label ID="lblSubTitle" runat="server"></asp:Label>
    </p>
    <ums:Dialog ID="dlgMessage" runat="server" />
    <ums:SlidingPanel ID="sldAboutMe" runat="server" TargetControlID="pnlAboutMe" HeaderTitle="<%$ Resources:User,Info_MyInfo_Title %>"
        Expanded="true" />
    <asp:Panel ID="pnlAboutMe" runat="server" CssClass="slidingpanel">
        <table class="form">
            <tr class="required">
                <td class="header">
                    <asp:Label ID="lblFirstName" runat="server" Text="<%$ Resources:User,Info_FirstName_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="textbox-required"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                        SetFocusOnError="true" ControlToValidate="txtFirstName" ValidationGroup="UserInfo"
                        ErrorMessage="<%$ Resources:User,Info_Change_Invalid_Name %>"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator1">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblMiddleName" runat="server" Text="<%$ Resources:User,Info_MiddleName_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr class="required">
                <td class="header">
                    <asp:Label ID="lblLastName" runat="server" Text="<%$ Resources:User,Info_LastName_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="textbox-required"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None"
                        SetFocusOnError="true" ControlToValidate="txtLastName" ValidationGroup="UserInfo"
                        ErrorMessage="<%$ Resources:User,Info_Change_Invalid_Name %>"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator3">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr class="required">
                <td class="header">
                    <asp:Label ID="lblEmail" runat="server" Text="<%$ Resources:User,Info_Email_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox-required"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"
                        SetFocusOnError="true" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ValidationGroup="UserInfo" ErrorMessage="<%$ Resources:User,Info_Change_Invalid_Email %>"></asp:RegularExpressionValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RegularExpressionValidator1">
                    </ajax:ValidatorCalloutExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                        SetFocusOnError="true" ControlToValidate="txtEmail" ValidationGroup="UserInfo"
                        ErrorMessage="<%$ Resources:User,Info_Change_Invalid_Email %>"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RequiredFieldValidator2">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblWebsite" runat="server" Text="<%$ Resources:User,Info_Website_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtWebsite" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ums:SlidingPanel ID="sldPhoto" runat="server" TargetControlID="pnlPic" HeaderTitle="<%$ Resources:User,Info_Photo_Title %>" />
    <asp:Panel ID="pnlPic" runat="server" CssClass="slidingpanel">
        <ums:Dialog ID="dlgPhoto" runat="server" />
        <table class="form">
            <tr>
                <td class="header" valign="top">
                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:User,Info_Photo_Current_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:Image ID="imgPhoto" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="header" valign="top">
                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:User,Info_Photo_New_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="fuPhoto" runat="server" CssClass="textbox" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="None"
                        SetFocusOnError="true" ValidationGroup="UserInfo" ErrorMessage="<%$ Resources:User,Info_Change_Photo_Invalid_Ext %>"
                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.png|.PNG|.bmp|.BMP|.jpeg|.JPEG|.jpg|.JPG|.gif|.GIF)$"
                        ControlToValidate="fuPhoto"></asp:RegularExpressionValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" HighlightCssClass="textbox-invalid"
                        PopupPosition="BottomLeft" TargetControlID="RegularExpressionValidator3">
                    </ajax:ValidatorCalloutExtender>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="<%$ Resources:User,Info_Photo_New_Extensions %>"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:User,Info_Photo_Clear_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbClearPhoto" runat="server" Checked="false" Text="<%$ Resources:User,Info_Photo_Clear_Text %>" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ums:SlidingPanel ID="sldLocation" runat="server" TargetControlID="pnlLocation" HeaderTitle="<%$ Resources:User,Info_MyLoc_Title %>" />
    <asp:Panel ID="pnlLocation" runat="server" CssClass="slidingpanel">
        <ums:Dialog ID="dlgLocation" runat="server" />
        <table class="form">
            <tr>
                <td class="header">
                    <asp:Label ID="lblOffice" runat="server" Text="<%$ Resources:User,Info_Office_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlOffice" runat="server" CssClass="dropdown" DataSourceID="ObjectDataSource1"
                        DataTextField="Name" DataValueField="Name" AppendDataBoundItems="True">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetActiveLocation" TypeName="PPI.UMS.BLL.Locations"></asp:ObjectDataSource>
                    <asp:TextBox ID="txtOffice" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="header vtop">
                    <asp:Label ID="lblAddress" runat="server" Text="<%$ Resources:User,Info_Address1_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="textbox" TextMode="MultiLine"
                        Rows="4"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblPOBox" runat="server" Text="<%$ Resources:User,Info_Address2_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPOBox" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblCity" runat="server" Text="<%$ Resources:User,Info_City_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblState" runat="server" Text="<%$ Resources:User,Info_State_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblZip" runat="server" Text="<%$ Resources:User,Info_ZipCode_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtZip" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblCountry" runat="server" Text="<%$ Resources:User,Info_Country_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ums:SlidingPanel ID="sldPhone" runat="server" TargetControlID="pnlPhone" HeaderTitle="<%$ Resources:User,Info_MyPhone_Title %>" />
    <asp:Panel ID="pnlPhone" runat="server" CssClass="slidingpanel">
        <ums:Dialog ID="dlgPhone" runat="server" />
        <table class="form">
            <tr>
                <td class="header">
                    <asp:Label ID="lblOfficePhone" runat="server" Text="<%$ Resources:User,Info_OfficePhone_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtOfficePhone" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblHomePhone" runat="server" Text="<%$ Resources:User,Info_HomePhone_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtHomePhone" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblPager" runat="server" Text="<%$ Resources:User,Info_PagerPhone_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPager" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblMobile" runat="server" Text="<%$ Resources:User,Info_MobilePhone_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblFax" runat="server" Text="<%$ Resources:User,Info_FaxPhone_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFax" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblIPPhone" runat="server" Text="<%$ Resources:User,Info_IPPhone_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIPPhone" runat="server" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <ums:SlidingPanel ID="sldOrg" runat="server" TargetControlID="pnlOrg" HeaderTitle="<%$ Resources:User,Info_MyOrg_Title %>" />
    <asp:Panel ID="pnlOrg" runat="server" CssClass="slidingpanel">
        <ums:Dialog ID="dlgOrgInfo" runat="server" Mode="Info" Title="<%$ Resources:User,Info_Org_Info_Title %>"
            Message="<%$ Resources:User,Info_Org_Info_Message %>" DefaultShow="true" />
        <table class="form">
            <tr>
                <td class="header">
                    <asp:Label ID="lblCompanyHead" runat="server" Text="<%$ Resources:User,Info_Company_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCompany" runat="server" CssClass="textbox"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblDepartmentHead" runat="server" Text="<%$ Resources:User,Info_Department_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDepartment" runat="server" CssClass="textbox"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="header" valign="top">
                    <asp:Label ID="lblManagerHead" runat="server" Text="<%$ Resources:User,Info_Manager_Header %>"></asp:Label>
                </td>
                <td>
                    <ums:UserContactCard ID="uccManager" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblEmployeeIdHead" runat="server" Text="<%$ Resources:User,Info_EmployeeId_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEmployeeId" runat="server" CssClass="textbox"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="header">
                    <asp:Label ID="lblTitleHead" runat="server" Text="<%$ Resources:User,Info_Position_Header %>"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTitle" runat="server" CssClass="textbox"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table class="form">
        <tr>
            <td style="width: 187px;">
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="<%$ Resources:User, Info_Change_Submit %>"
                    CssClass="submit" OnClick="btnSubmit_Click" ValidationGroup="UserInfo" OnClientClick="<%$ Resources:User, Info_Change_Alert_Code %>" />
            </td>
        </tr>
    </table>
</asp:Content>
