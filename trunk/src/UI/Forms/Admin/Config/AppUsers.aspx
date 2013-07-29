<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="AppUsers.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.AppUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>Manage Users</strong>
        <br />
        You can use this screen to manage the roles different users have.
    </p>
    <table class="form">
        <tbody>
            <tr>
                <th>
                    Add User or Edit?
                </th>
                <td>
                    <asp:RadioButtonList ID="rblMode" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                        OnSelectedIndexChanged="rblMode_SelectedIndexChanged">
                        <asp:ListItem Text="Add User" Value="ADD"></asp:ListItem>
                        <asp:ListItem Text="Update User" Value="MOD" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr id="RowAdd" runat="server">
                <th>
                    Search for User:
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
            <tr id="RowAddResult" runat="server">
                <th>
                    Results:
                </th>
                <td>
                    <asp:GridView ID="gvResult" runat="server" CssClass="grid" EmptyDataText="No User's Found."
                        DataKeyNames="Key" AutoGenerateColumns="False">
                        <SelectedRowStyle CssClass="selected" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="Value" HeaderText="User" SortExpression="Value" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr id="RowSelect" runat="server">
                <th>
                    Select User:
                </th>
                <td>
                    <asp:DropDownList ID="ddlUserList" runat="server" DataSourceID="ObjectDataSource2"
                        DataTextField="SortName" DataValueField="UpnUsername" AppendDataBoundItems="true"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlUserList_SelectedIndexChanged">
                        <asp:ListItem Text="Select a User..." Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetEmployeesWithRoles"
                        TypeName="THS.UMS.AO.Providers.Roles"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <th>
                    Roles:
                </th>
                <td>
                    <asp:CheckBoxList ID="cblUserRoles" runat="server" DataSourceID="ObjectDataSource1"
                        DataTextField="Value" DataValueField="Key">
                    </asp:CheckBoxList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllRolesCollection"
                        TypeName="THS.UMS.AO.Providers.Roles"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Save Changes" CssClass="submit" 
                        onclick="btnSubmit_Click" />
                    <ums:OutputMessage ID="omResult" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
