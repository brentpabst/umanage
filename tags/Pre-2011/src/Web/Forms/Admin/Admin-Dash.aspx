<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Admin.Master" AutoEventWireup="true"
    CodeBehind="Admin-Dash.aspx.cs" Inherits="PPI.UMS.Web.Forms.Admin.Admin_Dash" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-head">
        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Admin,Menu_Admin_Dash_Title %>"></asp:Label>
    </div>
    <div class="content-main">
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" style="width: 100%; border-collapse: collapse;">
                    <tr>
                        <td>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <%# AddGroupingRowIfDateHasChanged() %>
                <tr class="timeline-row<%# Container.DataItemIndex % 2 %>">
                    <td valign="top" style="width: 90px;">
                        <%# TimeFormat() %>
                    </td>
                    <td valign="top" style="width: 90px; text-align: right;">
                        <asp:Label ID="lblCat" runat="server" CssClass='<%# Eval("Category", "timeline-category cat-{0}") %>'
                            Text='<%# ((String)Eval("Category")).ToUpper() %>'></asp:Label>
                    </td>
                    <td valign="top" style="width: 48px;">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("CreatedBy", "~/Controls/UserPhotoThumbnail.ashx?username={0}") %>' />
                    </td>
                    <td valign="top" style="color: black;">
                        <strong>
                            <asp:Label ID="Label3" runat="server" Text="<%# UserFullName() %>"></asp:Label></strong>
                        <span class="timeline-title">
                            <asp:Label ID="Label1" runat="server" Text='<%# ((String)Eval("Title")).ToLower() %>'></asp:Label></span>
                        <em>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Description", "\"{0}\"") %>'></asp:Label></em>
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <ums:Dialog ID="Dialog1" runat="server" Title="<%$ Resources:Admin,Config_Dash_Empty_Title %>"
                    Message="<%$ Resources:Admin,Config_Dash_Empty_Message %>" Mode="Warning" DefaultShow="true" />
            </EmptyDataTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetTopMessages"
            TypeName="PPI.UMS.BLL.Messages" OldValuesParameterFormatString="original_{0}">
        </asp:ObjectDataSource>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TaskBar" runat="server">
    <div class="taskbar-header">
        <asp:Label ID="Label4" runat="server" Text="<%$ resources:Admin,Menu_Sidebar_TimelineTasks %>"></asp:Label>
    </div>
    <div class="taskbar-cont">
        <ul class="menu-config">
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Forms/Admin/Admin-FullTimeline.aspx"
                    Text="<%$ Resources:Admin,Menu_Sidebar_FullTimeline %>"></asp:HyperLink>
            </li>
        </ul>
    </div>
    <div class="taskbar-header">
        <asp:Label ID="Label6" runat="server" Text="Quick Actions"></asp:Label>
    </div>
    <div class="taskbar-cont">
        <ul class="menu-config">
            <li>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Forms/Admin/Admin-AddUser.aspx"
                    Text="<%$ Resources:Admin,Menu_Admin_AddUser_Title %>"></asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Forms/Admin/Admin-UserList.aspx"
                    Text="<%$ Resources:Admin,Menu_Admin_UserManage_Title %>"></asp:HyperLink>
            </li>
        </ul>
    </div>
</asp:Content>
