<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Emp.Master" AutoEventWireup="true"
    CodeBehind="Admin-UserList.aspx.cs" Inherits="PPI.UMS.Web.Forms.Admin.Admin_UserList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-head">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Admin,Menu_Admin_UserList_Title %>"></asp:Label>
    </div>
    <div class="content-main">
        <asp:GridView ID="GridView1" runat="server" CssClass="auth-grid" CellSpacing="-1"
            GridLines="None" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
            <HeaderStyle CssClass="auth-grid-head" />
            <RowStyle CssClass="auth-grid-row" />
            <AlternatingRowStyle CssClass="auth-grid-row-alt" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text="<%$ Resources:Admin,Emp_List_Details %>"
                            NavigateUrl='<%# Eval("UserName", "~/Forms/Admin/Admin-UserManage.aspx?Username={0}") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="EmployeeId" HeaderText="<%$ Resources:Admin,Emp_List_ID %>"
                    ReadOnly="True" SortExpression="EmployeeId" />
                <asp:BoundField DataField="SortName" HeaderText="<%$ Resources:Admin,Emp_List_Name %>"
                    ReadOnly="True" SortExpression="SortName" />
                <asp:BoundField DataField="JobTitle" HeaderText="<%$ Resources:Admin,Emp_List_Title %>"
                    ReadOnly="True" SortExpression="JobTitle" />
                <asp:BoundField DataField="Email" HeaderText="<%$ Resources:Admin,Emp_List_Email %>"
                    ReadOnly="True" SortExpression="Email" />
                <asp:BoundField DataField="AccountStatus" HeaderText="<%$ Resources:Admin,Emp_List_Status %>"
                    ReadOnly="True" SortExpression="AccountStatus" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetAllEmployees" TypeName="PPI.UMS.BLL.Employees"></asp:ObjectDataSource>
    </div>
</asp:Content>
