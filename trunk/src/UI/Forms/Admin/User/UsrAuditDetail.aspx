<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.Master" AutoEventWireup="true"
    CodeBehind="UsrAuditDetail.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.User.UsrAuditDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="form">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/admin/user/audit">Return to Audit List</asp:HyperLink>
    </div>
    <br />
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
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Middle Name:
                            </th>
                            <td>
                                <asp:TextBox ID="txtMiddleName" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblMiddleName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Last Name:
                            </th>
                            <td>
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblLastName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                E-Mail Address:
                            </th>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Website:
                            </th>
                            <td>
                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblWebsite" runat="server"></asp:Label>
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
                                <asp:Label ID="lblOffice" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Address:
                            </th>
                            <td>
                                <asp:TextBox ID="txtAddress1" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblAddress1" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Box/Ste/Apt:
                            </th>
                            <td>
                                <asp:TextBox ID="txtAddress2" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                City:
                            </th>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                State/Province:
                            </th>
                            <td>
                                <asp:TextBox ID="txtState" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblState" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Postal Code:
                            </th>
                            <td>
                                <asp:TextBox ID="txtPostalCode" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblPostalCode" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Country:
                            </th>
                            <td>
                                <asp:TextBox ID="txtCountry" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblCountry" runat="server"></asp:Label>
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
                                <asp:Label ID="lblOfficePhone" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Home Phone:
                            </th>
                            <td>
                                <asp:TextBox ID="txtHomePhone" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblHomePhone" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Mobile Phone:
                            </th>
                            <td>
                                <asp:TextBox ID="txtMobilePhone" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblMobilePhone" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Fax:
                            </th>
                            <td>
                                <asp:TextBox ID="txtFax" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblFax" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Pager:
                            </th>
                            <td>
                                <asp:TextBox ID="txtPager" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblPager" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                SIP/Skype:
                            </th>
                            <td>
                                <asp:TextBox ID="txtSip" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblSip" runat="server"></asp:Label>
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
                                <asp:TextBox ID="txtCompany" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblCompany" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Department:
                            </th>
                            <td>
                                <asp:TextBox ID="txtDepartment" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Job Title:
                            </th>
                            <td>
                                <asp:TextBox ID="txtJobTitle" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblJobTitle" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Employee ID:
                            </th>
                            <td>
                                <asp:TextBox ID="txtEmployeeId" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Label ID="lblEmployeeId" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <div class="head">
                My Manager
            </div>
            <table class="form" id="tblManager" runat="server">
                <tbody>
                    <tr>
                        <th>
                            Manager:
                        </th>
                        <td>
                            <asp:TextBox ID="txtManager" runat="server" CssClass="text"></asp:TextBox>
                            <asp:Label ID="lblManager" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />
        <div class="box">
            <div class="head">
                Audit Log Details
            </div>
            <table class="form">
                <tbody>
                    <tr>
                        <th>
                            Log ID:
                        </th>
                        <td>
                            <asp:Label ID="lblLogId" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Log Date:
                        </th>
                        <td>
                            <asp:Label ID="lblLogDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Log Date (UTC):
                        </th>
                        <td>
                            <asp:Label ID="lblLogDateUtc" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Submitted By:
                        </th>
                        <td>
                            <asp:Label ID="lblSubmittedBy" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Username:
                        </th>
                        <td>
                            <asp:Label ID="lblUpnUsername" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class="clear">
    </div>
</asp:Content>
