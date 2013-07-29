<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.Master" AutoEventWireup="true"
    CodeBehind="GroupDetail.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Groups.GroupDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="form">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/admin/group/list">Return to Group List</asp:HyperLink>
        <h3>
            <asp:Label ID="Label1" runat="server" Text="Group:"></asp:Label>
            <asp:Label ID="lblGroupName" runat="server" Text=""></asp:Label>
        </h3>
    </div>
    <ajax:TabContainer ID="tabContainer1" runat="server" ActiveTabIndex="0" OnActiveTabChanged="tabContainer1_ActiveTabChanged"
        AutoPostBack="true">
        <ajax:TabPanel runat="server" HeaderText="Details" ID="tpnlDetails">
            <ContentTemplate>
                <asp:UpdatePanel ID="pnlDetails" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <ums:OutputMessage ID="ouManagerAdd" runat="server" />
                        <table class="form" id="Table2" runat="server">
                            <tbody>
                                <tr>
                                    <th>
                                        Description:
                                    </th>
                                    <td>
                                        <asp:Literal ID="lDescription" runat="server"></asp:Literal>
                                        <%--<asp:TextBox ID="txtDescription" runat="server" Text="" CssClass="text" />
                                        &nbsp;
                                        <asp:LinkButton ID="lbUpdateDisc" runat="server" OnClick="lnkUpdateDisc_Click" Visible="false" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Type:
                                    </th>
                                    <td>
                                        <asp:Label runat="server" ID="lblSecurityGroup"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Managed By:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtSearchManager" runat="server" CssClass="text" ValidationGroup="SearchManager" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter a name to search for!"
                                            SetFocusOnError="True" ControlToValidate="txtSearchManager" Display="None" ValidationGroup="Search"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator1">
                                        </ajax:ValidatorCalloutExtender>
                                        <asp:LinkButton ID="lbSearchForManager" runat="server" OnClick="lbSearchForManager_Click"
                                            ValidationGroup="SearchManager">Search</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Results:
                                    </th>
                                    <td>
                                        <asp:GridView ID="gvManagerResults" runat="server" CssClass="grid" EmptyDataText="No User's Found"
                                            AutoGenerateColumns="false" OnRowCommand="grdManager_RowCommand">
                                            <SelectedRowStyle CssClass="selected" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnAddManager" CommandName="AddManager" CommandArgument='<%# Eval("UpnUserName") %>'
                                                            runat="server">Add</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DisplayName" HeaderText="User" SortExpression="DisplayName" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajax:TabPanel>
        <ajax:TabPanel runat="server" HeaderText="Members" ID="tpnlMembers">
            <ContentTemplate>
                <asp:UpdatePanel ID="pnlMembers" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <ums:OutputMessage ID="ouMemberResult" runat="server" />
                        <asp:GridView ID="grdGroupMembers" runat="server" CssClass="grid" AutoGenerateColumns="false"
                            ShowHeaderWhenEmpty="true" EmptyDataText="No Users were found." DataKeyNames="upnUserName"
                            OnRowCommand="grdGroupMembers_RowCommand">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnRemove" runat="server" CommandName="RemoveUser" CommandArgument='<%# Eval("upnUsername") %>'>Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="SortName" HeaderText="Name" />
                                <asp:BoundField DataField="UpnUsername" HeaderText="Username" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajax:TabPanel>
        <ajax:TabPanel runat="server" HeaderText="Add Members" ID="tpnlAddUser">
            <ContentTemplate>
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="pnlAddUsers">
                    <ContentTemplate>
                        <ums:OutputMessage ID="ouMemberAdd" runat="server" />
                        <table class="form" id="Table1" runat="server">
                            <tbody>
                                <tr>
                                    <th>
                                        Users:
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtUser" runat="server" CssClass="text" ValidationGroup="Search"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter a name to search for!"
                                            SetFocusOnError="True" ControlToValidate="txtUser" Display="None" ValidationGroup="Search"></asp:RequiredFieldValidator>
                                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="text-invalid"
                                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator3">
                                        </ajax:ValidatorCalloutExtender>
                                        <asp:LinkButton ID="lbSearchUser" runat="server" OnClick="lbSearchUser_Click" ValidationGroup="Search">Search</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Results:
                                    </th>
                                    <td>
                                        <asp:GridView ID="gvUserResult" runat="server" CssClass="grid" EmptyDataText="No User's Found."
                                            DataKeyNames="UpnUsername" AutoGenerateColumns="False" OnRowCommand="grdUsers_RowCommand">
                                            <SelectedRowStyle CssClass="selected" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnAdd" CommandName="AddUser" CommandArgument='<%# Eval("UpnUserName") %>'
                                                            runat="server">Add</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DisplayName" HeaderText="User" SortExpression="DisplayName" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajax:TabPanel>
    </ajax:TabContainer>
</asp:Content>
