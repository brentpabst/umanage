<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.Master" AutoEventWireup="true"
    CodeBehind="UsrAudit.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.User.UsrAudit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <strong>Audit History</strong>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
        CssClass="grid">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" Text="View Details" NavigateUrl='<%# Eval("LogId", "~/admin/user/audit/show/{0}") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="LogDate" HeaderText="Change Date" SortExpression="LogDate" />
            <asp:BoundField DataField="LogDateUtc" HeaderText="Change Date (UTC)" SortExpression="LogDateUtc" />
            <asp:BoundField DataField="SubmittedBy" HeaderText="Changed By" SortExpression="SubmittedBy" />
            <asp:BoundField DataField="UpnUsername" HeaderText="User Modified" SortExpression="UpnUsername" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetLastAuditLogs"
        TypeName="THS.UMS.AO.AuditLog"></asp:ObjectDataSource>
</asp:Content>
