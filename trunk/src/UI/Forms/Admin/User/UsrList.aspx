<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.master" AutoEventWireup="true"
    CodeBehind="UsrList.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.User.UsrList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <table class="form" id="tblManager" runat="server">
        <tbody>
            <tr>
                <th>
                    Search for User:
                </th>
                <td>
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="text" ValidationGroup="Search"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter a name to search for!"
                        SetFocusOnError="True" ControlToValidate="txtSearch" Display="None" ValidationGroup="Search"></asp:RequiredFieldValidator>
                    <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="text-invalid"
                        PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator3">
                    </ajax:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="submit" OnClick="btnSearch_Click"
                        ValidationGroup="Search" />
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <asp:GridView ID="GridView1" runat="server" CssClass="grid" AutoGenerateColumns="False"
        ShowHeaderWhenEmpty="true" EmptyDataText="No Users were found.">
        <Columns>
            <%--<asp:BoundField DataField="DisplayName" HeaderText="DisplayName" SortExpression="DisplayName" />--%>
            <asp:HyperLinkField DataTextField="SortName" HeaderText="Name" DataNavigateUrlFields="UpnUsername"
                DataNavigateUrlFormatString="~/admin/user/show/{0}" />
            <asp:BoundField DataField="EmployeeId" HeaderText="Employee Id" SortExpression="EmployeeId" />
            <asp:BoundField DataField="UpnUsername" HeaderText="Username" SortExpression="UpnUsername" />
            <asp:TemplateField HeaderText="Account Locked">
                <ItemTemplate>
                    <asp:Label ID="lblLocked" runat="server" Text='<%# FormatBoolean((bool)Eval("AccountLocked")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Account Expires">
                <ItemTemplate>
                    <asp:Label ID="lblAcctExpires" runat="server" Text='<%# AccountExpires((DateTime)Eval("AccountExpDate"))%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Password Expires">
                <ItemTemplate>
                    <asp:Label ID="lblPwdExpires" runat="server" Text='<%# PasswordExpires((DateTime)Eval("PasswordExpDate")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
