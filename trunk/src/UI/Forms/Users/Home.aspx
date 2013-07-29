<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="THS.UMS.UI.Forms.Users.Home"
    Theme="HomePage" %>

<%@ Import Namespace="THS.UMS.DTO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="SHORTCUT ICON" href="/Images/UMS.ico" />
    <link rel="icon" type="image/vnd.microsoft.icon" href="/Images/UMS.ico" />
    <link rel="icon" type="image/png" href="/Images/UMS.png" />
    <meta name="application-name" content="uManage" />
    <meta name="msapplication-tooltip" content="uManage - User Self-Service Portal" />
    <meta name="msapplication-window" content="width=1024;height=955" />
    <meta name="msapplication-navbutton-color" content="#414B55" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="page">
        <div id="logo">
            <!-- Logo Displays Here -->
        </div>
        <div id="name">
            <asp:Literal ID="lOrgName" runat="server"></asp:Literal>
        </div>
        <asp:Panel ID="pnlAlert" runat="server" CssClass="alert" Visible="false">
            <asp:Literal ID="lAlert" runat="server"></asp:Literal>
        </asp:Panel>
        <div id="left">
            <asp:Repeater ID="rptPosts" runat="server" DataSourceID="ObjectDataSource2">
                <ItemTemplate>
                    <div class="header">
                        <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("Subject") %>'></asp:Literal>
                        -
                        <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("VisibleFrom", "{0:d}") %>'></asp:Literal>
                    </div>
                    <div class="content">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Message") %>'></asp:Literal>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetVisiblePosts"
                TypeName="THS.UMS.AO.Posts"></asp:ObjectDataSource>
        </div>
        <div id="right">
            <div class="header">
                About Me
            </div>
            <ums:UserBadge ID="UserBadge1" runat="server" DisableHeaders="true" />
            <div class="content">
            </div>
            <asp:Panel ID="pnlQuickLinks" runat="server">
                <div class="header">
                    Quick Links
                </div>
                <div class="content">
                    <asp:Repeater ID="rptQuickLinks" runat="server" DataSourceID="ObjectDataSource1">
                        <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Url") %>' Text='<%# Eval("Text") %>'></asp:HyperLink></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetLinks"
                        TypeName="THS.UMS.AO.Links"></asp:ObjectDataSource>
                </div>
            </asp:Panel>
            <div class="header">
                uManage Links
            </div>
            <div class="content">
                <asp:Repeater ID="rptUManageLinks" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Title") %>' NavigateUrl='<%# Eval("Url") %>'></asp:HyperLink>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Panel ID="pnlAdminVisible" runat="server" Visible="<%# IsAdmin() %>">
                            <li>
                                <asp:HyperLink ID="HyperLink2" runat="server" Text="View Admin Portal" NavigateUrl="~/admin/dash"></asp:HyperLink></li>
                        </asp:Panel>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="clear">
        </div>
        <div id="foot">
            &copy;
            <%= DateTime.UtcNow.Year %>
            <asp:Literal ID="lOrgNameFoot" runat="server"></asp:Literal>
            | Powered By <a href="http://umanage.codeplex.com" target="_blank">uManage</a>
        </div>
    </div>
    </form>
</body>
</html>
