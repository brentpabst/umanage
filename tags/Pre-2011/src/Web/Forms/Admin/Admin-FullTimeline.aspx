<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Admin.Master" AutoEventWireup="true"
    CodeBehind="Admin-FullTimeline.aspx.cs" Inherits="PPI.UMS.Web.Forms.Admin.Admin_FullTimeline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-head">
        <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:Admin,Menu_Config_Timeline_Title %>"></asp:Label>
    </div>
    <div class="content-main">
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
            <LayoutTemplate>
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="30">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
                            FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" NextPageText="&gt;" PreviousPageText="&lt;" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False"
                            FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" NextPageText="&gt;" PreviousPageText="&lt;" />
                    </Fields>
                </asp:DataPager>
                <table cellspacing="0" cellpadding="0" style="width: 100%; border-collapse: collapse;">
                    <tr>
                        <td colspan="4" class="timeline-full-spacer">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
                <asp:DataPager ID="DataPager2" runat="server" PagedControlID="ListView1" PageSize="30">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
                            FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" NextPageText="&gt;" PreviousPageText="&lt;" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False"
                            FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" NextPageText="&gt;" PreviousPageText="&lt;" />
                    </Fields>
                </asp:DataPager>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="<%$ Resources:Global,ViewLess %>"
                    NavigateUrl="~/Forms/Admin/Admin-Dash.aspx"></asp:HyperLink>
            </LayoutTemplate>
            <ItemTemplate>
                <tr class="timeline-full-row">
                    <td valign="top" style="width: 70px; text-align: right;">
                        <div class='<%# Eval("Category", "timeline-full-category cat-{0}") %>'>
                            <asp:Label ID="lblCat" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                        </div>
                    </td>
                    <td valign="top" style="padding-right: 5px;">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                        -
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                    </td>
                    <td valign="top" style="width: 100px;">
                        <%# UserDisplayName() %>
                    </td>
                    <td valign="top" style="width: 50px;">
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("CreatedOn", "{0:MMM dd}") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="timeline-full-spacer">
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <ums:Dialog ID="Dialog1" runat="server" Title="<%$ Resources:Admin,Config_Dash_Empty_Title %>"
                    Message="<%$ Resources:Admin,Config_Dash_Empty_Message %>" Mode="Warning" DefaultShow="true" />
            </EmptyDataTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllMessages"
            TypeName="PPI.UMS.BLL.Messages" OldValuesParameterFormatString="original_{0}">
        </asp:ObjectDataSource>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TaskBar" runat="server">
</asp:Content>
