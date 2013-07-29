<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="Conf-Dash.aspx.cs" Inherits="PPI.UMS.Web.Forms.Admin.Config.Conf_Dash" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-head">
        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Admin,Menu_Config_Dash_Title %>"></asp:Label>
    </div>
    <div class="content-main">
        <ums:Dialog ID="Dialog1" runat="server" Title="<%$ Resources:Admin,Config_Dash_Dialog_Title %>"
            Message="<%$ Resources:Admin,Config_Dash_Dialog_Message %>" Mode="Info" DefaultShow="true" />
        <br />
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" style="width: 100%; border-collapse: collapse;">
                    <tr>
                        <td>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
                <asp:HyperLink ID="HyperLink1" runat="server" Text="<%$ Resources:Global,ViewAll %>"
                    NavigateUrl="~/Forms/Admin/Config/Conf-FullTimeline.aspx"></asp:HyperLink>
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetTopSystemMessages"
            TypeName="PPI.UMS.BLL.Messages" OldValuesParameterFormatString="original_{0}">
        </asp:ObjectDataSource>
    </div>
</asp:Content>
