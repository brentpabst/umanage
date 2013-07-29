﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="AppDepartment.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.AppDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>Department Maintenance</strong>
        <br />
        You can specify that users must choose a department versus being able to enter one
        manually.
    </p>
    <table class="form">
        <tbody>
            <tr>
                <th>
                    Enable Department List:
                </th>
                <td>
                    <asp:CheckBox ID="cbOffice" runat="server" Text="&nbsp;" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Save Changes" CssClass="submit" OnClick="btnSubmit_Click" />
                    <ums:OutputMessage ID="omResult" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
        CssClass="grid" DataKeyNames="DepartmentId">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetActiveDepartments"
        TypeName="THS.UMS.AO.Departments"></asp:ObjectDataSource>
    <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource2" DefaultMode="Edit">
        <EmptyDataTemplate>
            <div class="form">
                <asp:Button ID="AddButton" runat="server" CausesValidation="True" CommandName="New"
                    CssClass="submit" Text="Add Department" />
            </div>
        </EmptyDataTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="OfficeIdTextBox" runat="server" Text='<%# Bind("DepartmentId") %>'
                Visible="false" />
            <table class="form">
                <tbody>
                    <tr>
                        <th>
                            Is Department Enabled?
                        </th>
                        <td>
                            <asp:CheckBox ID="IsEnabledCheckBox" runat="server" Checked='<%# Bind("IsEnabled") %>' />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Name:
                        </th>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' CssClass="text-req" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter a name for this department."
                                SetFocusOnError="True" ControlToValidate="NameTextBox" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                                PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator1">
                            </ajax:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Description:
                        </th>
                        <td>
                            <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>'
                                CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                CssClass="submit" Text="Save Changes" />
                            &nbsp;
                            <asp:Button ID="AddButton" runat="server" CausesValidation="True" CommandName="New"
                                CssClass="submit" Text="Add Department" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </EditItemTemplate>
        <InsertItemTemplate>
            <table class="form">
                <tbody>
                    <tr>
                        <th>
                            Name:
                        </th>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' CssClass="text-req" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter a name for this department."
                                SetFocusOnError="True" ControlToValidate="NameTextBox" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                                PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator1">
                            </ajax:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Description:
                        </th>
                        <td>
                            <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>'
                                CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                CssClass="submit" Text="Add Department" />
                            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" Text="Cancel" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </InsertItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="THS.UMS.DTO.DepartmentDTO"
        InsertMethod="AddDepartment" SelectMethod="GetDepartment" TypeName="THS.UMS.AO.Departments"
        UpdateMethod="UpdateDepartment" OnInserted="ObjectDataSource2_Inserted" OnUpdated="ObjectDataSource2_Updated">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" DbType="Guid" Name="key" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
