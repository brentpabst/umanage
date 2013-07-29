<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.master" AutoEventWireup="true"
    CodeBehind="GroupList.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Groups.GroupList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <table class="form" id="tblManager" runat="server">
        <tr>
            <th>
                Search for Group:
            </th>
            <td>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="text" ValidationGroup="Search"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter a group to search for!"
                    SetFocusOnError="True" ControlToValidate="txtSearch" Display="None" ValidationGroup="Search"></asp:RequiredFieldValidator>
                <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="text-invalid"
                    PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator3">
                </ajax:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lnkShowAll" runat="server" OnClick="lnkShowAll_Click">Show All</asp:LinkButton>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="submit" OnClick="btnSearch_Click"
                    ValidationGroup="Search" />
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="grdGroups" runat="server" CssClass="grid" AutoGenerateColumns="false"
        ShowHeaderWhenEmpty="true" EmptyDataText="No Groups were found.">
        <Columns>
            <asp:HyperLinkField Text="View" HeaderText="View" DataNavigateUrlFields="Name" DataNavigateUrlFormatString="~/admin/group/show/{0}" />
            <asp:BoundField DataField="Name" HeaderText="Group Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
        </Columns>
    </asp:GridView>
</asp:Content>
