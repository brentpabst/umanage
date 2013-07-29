<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.Master" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h3>
        Location Metrics
    </h3>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
        CssClass="grid" ShowFooter="True" EmptyDataText="Metrics could not be found, ensure locations are setup properly."
        OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Location">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Location.LocationName") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <span style="font-size: 80%;">Totals</span>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Domain">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Location.Directory") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TotalUserCount" HeaderText="Total Users" SortExpression="TotalUserCount" />
            <asp:BoundField DataField="ExpiredAccountCount" HeaderText="Expired Accounts" SortExpression="ExpiredAccountCount" />
            <asp:BoundField DataField="ExpiredPasswordCount" HeaderText="Expired Passwords" SortExpression="ExpiredPasswordCount" />
            <asp:BoundField DataField="ExpiringAccountCount" HeaderText="Expiring Accounts" SortExpression="ExpiringAccountCount" />
            <asp:BoundField DataField="ExpiringPasswordCount" HeaderText="Expiring Passwords"
                SortExpression="ExpiringPasswordCount" />
        </Columns>
        <FooterStyle CssClass="footer" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetLocationMetrics"
        TypeName="THS.UMS.AO.Metrics"></asp:ObjectDataSource>
</asp:Content>
