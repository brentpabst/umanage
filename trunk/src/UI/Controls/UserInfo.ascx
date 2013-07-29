<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="UserInfo.ascx.cs" Inherits="THS.UMS.UI.Controls.UserInfo" %>
<asp:Wizard ID="Wizard1" runat="server" Width="100%" DisplaySideBar="False" OnActiveStepChanged="Wizard1_ActiveStepChanged">
    <StartNavigationTemplate>
    </StartNavigationTemplate>
    <StepNavigationTemplate>
    </StepNavigationTemplate>
    <FinishNavigationTemplate>
    </FinishNavigationTemplate>
    <WizardSteps>
        <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1">
            <asp:Panel ID="pnlLocationSelect" runat="server" Visible="false">
                <table class="form">
                    <tbody>
                        <tr>
                            <th>
                                Select A Location:
                            </th>
                            <td>
                                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="select" DataSourceID="ObjectDataSource2"
                                    DataTextField="LocationName" DataValueField="LocationId" AppendDataBoundItems="true"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                                    <asp:ListItem Text="Select a Location..." Value="SELECT"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetActiveLocations"
                                    TypeName="THS.UMS.AO.Locations"></asp:ObjectDataSource>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlUserInfo" runat="server">
                <div class="left" style="width: 49%; margin-right: 2%;">
                    <div class="box">
                        <asp:Panel ID="pnlPersonal" runat="server">
                            <div class="head">
                                About Me
                            </div>
                            <table class="form">
                                <tbody>
                                    <tr>
                                        <th>
                                            First Name:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="text-req"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter your first name!"
                                                SetFocusOnError="True" ControlToValidate="txtFirstName" Display="None"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                                                PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator1">
                                            </ajax:ValidatorCalloutExtender>
                                            <asp:Literal ID="lFirstName" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Middle Name:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtMiddleName" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lMiddleName" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Last Name:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtLastName" runat="server" CssClass="text-req"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter your last name!"
                                                SetFocusOnError="True" ControlToValidate="txtLastName" Display="None"></asp:RequiredFieldValidator>
                                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="text-invalid"
                                                PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator2">
                                            </ajax:ValidatorCalloutExtender>
                                            <asp:Literal ID="lLastName" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            E-Mail Address:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lEmail" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Website:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtWebsite" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lWebsite" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlLocation" runat="server">
                            <div class="head">
                                My Location
                            </div>
                            <table class="form">
                                <tbody>
                                    <tr>
                                        <th>
                                            Office:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtOffice" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:DropDownList ID="ddlOffice" runat="server" DataSourceID="ObjectDataSource1"
                                                DataTextField="Name" DataValueField="OfficeId" AppendDataBoundItems="true">
                                                <asp:ListItem Text="Select an Office" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetActiveOffices"
                                                TypeName="THS.UMS.AO.Offices"></asp:ObjectDataSource>
                                            <asp:Literal ID="lOffice" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Address:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtAddress1" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lAddress1" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Box/Ste/Apt:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtAddress2" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lAddress2" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            City:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lCity" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            State/Province:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtState" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lState" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Postal Code:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtPostalCode" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lPostalCode" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Country:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtCountry" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lCountry" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlPhone" runat="server">
                            <div class="head">
                                My Phone Numbers
                            </div>
                            <table class="form">
                                <tbody>
                                    <tr>
                                        <th>
                                            Office Phone:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtOfficePhone" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lOfficePhone" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Home Phone:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtHomePhone" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lHomePhone" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Mobile Phone:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtMobilePhone" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lMobilePhone" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Fax:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtFax" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lFax" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Pager:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtPager" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lPager" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            SIP/Skype:
                                        </th>
                                        <td>
                                            <asp:TextBox ID="txtSip" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:Literal ID="lSip" runat="server" Visible="false"></asp:Literal>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlActions" runat="server">
                            <div class="head">
                                Actions
                            </div>
                            <table class="form">
                                <tbody>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnRefresh" runat="server" Text="Refresh Information" CssClass="submit"
                                                OnClick="btnRefresh_Click" ValidationGroup="RefreshInfo" />
                                            <asp:Button ID="btnSubmit" runat="server" Text="Save Changes" CssClass="submit" OnClick="btnSubmit_Click" />
                                            <ums:OutputMessage ID="omResult" runat="server" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </div>
                </div>
                <div class="left" style="width: 49%;">
                    <div class="box">
                        <asp:Panel ID="pnlOrg" runat="server">
                            <div class="head">
                                My Organization
                            </div>
                            <table class="form">
                                <tbody>
                                    <tr>
                                        <th>
                                            Organization:
                                        </th>
                                        <td>
                                            <asp:Label ID="lblCompany" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtCompany" runat="server" CssClass="text"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Department:
                                        </th>
                                        <td>
                                            <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtDepartment" runat="server" CssClass="text"></asp:TextBox>
                                            <asp:DropDownList ID="ddlDepartment" runat="server" DataSourceID="ObjectDataSource3"
                                                DataTextField="Name" DataValueField="DepartmentId" AppendDataBoundItems="true">
                                                <asp:ListItem Text="Select a Department" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetActiveDepartments"
                                                TypeName="THS.UMS.AO.Departments"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Job Title:
                                        </th>
                                        <td>
                                            <asp:Label ID="lblJobTitle" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtJobTitle" runat="server" CssClass="text"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Employee ID:
                                        </th>
                                        <td>
                                            <asp:Label ID="lblEmployeeId" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtEmployeeId" runat="server" CssClass="text"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            Badge ID:
                                        </th>
                                        <td>
                                            <asp:Label ID="lblBadgeId" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtBadgeId" runat="server" CssClass="text"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                        <div class="head">
                            My Manager
                        </div>
                        <div style="margin: 5px;">
                            <ums:UserBadge ID="ubManager" runat="server" />
                        </div>
                        <table class="form" id="tblManager" runat="server">
                            <tbody>
                                <tr id="tblManagerRowClear">
                                    <th>
                                        Clear Manager?
                                    </th>
                                    <td>
                                        <asp:CheckBox ID="cbClearManager" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Manager:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtManager" runat="server" CssClass="text" ValidationGroup="Search"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter a name to search for!"
                                            SetFocusOnError="True" ControlToValidate="txtManager" Display="None" ValidationGroup="Search"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="text-invalid"
                                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator3">
                                        </ajax:ValidatorCalloutExtender>
                                        <asp:LinkButton ID="lbSearchManager" runat="server" OnClick="lbSearchManager_Click"
                                            ValidationGroup="Search">Search</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Results:
                                    </th>
                                    <td>
                                        <asp:GridView ID="gvManagerResult" runat="server" CssClass="grid" EmptyDataText="No User's Found."
                                            DataKeyNames="Key" AutoGenerateColumns="False">
                                            <SelectedRowStyle CssClass="selected" />
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True" />
                                                <asp:BoundField DataField="Value" HeaderText="User" SortExpression="Value" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <asp:Panel ID="pnlPhoto" runat="server">
                            <div class="head">
                                My Photo
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnSavePhoto" />
                                    <asp:PostBackTrigger ControlID="btnClearPhoto" />
                                    <asp:PostBackTrigger ControlID="btnNext" />
                                </Triggers>
                                <ContentTemplate>
                                    <table class="form">
                                        <tbody>
                                            <asp:Panel ID="pnlClearPhoto" runat="server">
                                                <tr>
                                                    <th class="top">
                                                        Current Photo:
                                                    </th>
                                                    <td>
                                                        <asp:Image ID="imgPhoto" runat="server" />
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlChangePhoto" runat="server">
                                                <tr>
                                                    <th>
                                                        Upload New Photo:
                                                    </th>
                                                    <td>
                                                        <asp:FileUpload ID="fuPhoto" runat="server" ValidationGroup="Photo" />
                                                        <asp:Label ID="lblUploadPath" runat="server" Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="pnlSubmitPhoto" runat="server">
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Button ID="btnClearPhoto" runat="server" Text="Remove Picture" CssClass="submit"
                                                                OnClientClick="return confirm('Are you sure you want to remove your current photo?\r\n\r\nPress OK to remove your photo.');"
                                                                OnClick="btnClearPhoto_Click" ValidationGroup="Photo" />
                                                            <asp:Button ID="btnSavePhoto" runat="server" Text="Save Picture" CssClass="submit"
                                                                ValidationGroup="Photo" OnClick="btnSavePhoto_Click" />
                                                            <ums:OutputMessage ID="omPhoto" runat="server" />
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                            </asp:Panel>
                                        </tbody>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                    <br />
                    <asp:Panel ID="pnlWizardSteps" runat="server" Visible="false">
                        <div class="box">
                            <div class="head">
                                Actions
                            </div>
                            <div class="form" style="padding-left: 5px;">
                                <asp:Button ID="btnNext" runat="server" Text="Validate User" CssClass="submit" CommandName="MoveNext" />
                                <ums:OutputMessage ID="omWizardStep1" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <div class="clear">
                </div>
            </asp:Panel>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2">
            <div class="box">
                <div class="head">
                    Account Settings
                </div>
                <table class="form">
                    <tbody>
                        <tr>
                            <th>
                                New Username:
                            </th>
                            <td>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="text-req"></asp:TextBox>
                                <asp:LinkButton ID="lbCheckUsername" runat="server" Text="Check Username" OnClick="lbCheckUsername_Click"></asp:LinkButton>
                                <br />
                                <br />
                                <ums:OutputMessage ID="omUsername" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Enable Account:
                            </th>
                            <td>
                                <asp:CheckBox ID="cbEnable" runat="server" Checked="true" AutoPostBack="true" OnCheckedChanged="cbEnable_CheckedChanged" />
                                <br />
                                If you only want to create an employee record but not allow them to login to any
                                computers you should clear the checkbox above.
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Temporary Password:
                            </th>
                            <td>
                                <asp:RadioButtonList ID="rblPassword" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblPassword_SelectedIndexChanged">
                                    <asp:ListItem Text="System Generated" Value="SYS" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Let me set it" Value="MAN"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="text-req"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You must enter a password for the user!"
                                    SetFocusOnError="True" ControlToValidate="txtPassword" Display="None" ValidationGroup="Search"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" HighlightCssClass="text-invalid"
                                    PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator4">
                                </ajax:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                E-Mail Information:
                            </th>
                            <td>
                                <asp:TextBox ID="txtAddEmail" runat="server" CssClass="text"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="You must enter an e-mail address!"
                                    SetFocusOnError="True" ControlToValidate="txtAddEmail" Display="None" ValidationGroup="Search"></asp:RequiredFieldValidator>
                                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" HighlightCssClass="text-invalid"
                                    PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator5">
                                </ajax:ValidatorCalloutExtender>
                                <br />
                                The system will e-mail the new username and password as well as instructions for
                                logging in to Windows. By Default it will be sent to you.
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <br />
            <div class="box">
                <div class="head">
                    Actions
                </div>
                <div class="form" style="padding-left: 5px;">
                    <asp:Button ID="btnSaveClose" runat="server" Text="Add User" CssClass="submit" OnClick="btnSaveClose_OnClick" />
                    <asp:HyperLink ID="hlCancel" runat="server" Text="Cancel" NavigateUrl="~/admin/user/add"></asp:HyperLink>
                    <ums:OutputMessage ID="omAddUser" runat="server" />
                </div>
            </div>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep3" runat="server" Title="Step 3">
            Show User Info Here
        </asp:WizardStep>
    </WizardSteps>
</asp:Wizard>
