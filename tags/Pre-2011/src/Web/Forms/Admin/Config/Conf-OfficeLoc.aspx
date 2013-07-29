<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="Conf-OfficeLoc.aspx.cs" Inherits="PPI.UMS.Web.Forms.Admin.Config.Conf_OfficeLoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-head">
        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Admin,Menu_Config_OfficeLoc_Title %>"></asp:Label>
    </div>
    <div class="content-main">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Admin,Config_OfficeLoc_Body %>"></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="form">
                    <tr>
                        <td class="header">
                            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Admin,Config_OfficeLoc_Enable %>"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                <asp:ListItem Text="<%$ Resources:Global,Yes %>" Value="true"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:Global,No %>" Value="false"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                <hr />
                <asp:Panel ID="pnlShowHide" runat="server">
                    <ums:Dialog ID="dlgEdit" runat="server" />
                    <div>
                        <div style="float: left;">
                            <table class="form">
                                <tr>
                                    <td colspan="2">
                                        <strong>
                                            <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Admin,Config_OfficeLoc_EditLocs %>"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="header">
                                        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Admin,Config_OfficeLoc_SelectLoc %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSelectedLocation" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                                            CssClass="dropdown" DataTextField="Name" DataValueField="Name" AppendDataBoundItems="True">
                                            <asp:ListItem Text="<%$ Resources:Admin,Config_OfficeLoc_DefaultDropDownText %>"
                                                Value="NA"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetActiveLocation" TypeName="PPI.UMS.BLL.Locations"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" CssClass="submit" Text="<%$ Resources:Admin,Config_OfficeLoc_Save %>"
                                            OnClick="Button1_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="float: left; margin-left: 40px;">
                            <table class="form">
                                <tr>
                                    <td colspan="2">
                                        <strong>
                                            <asp:Label ID="Label7" runat="server" Text="<%$ Resources:Admin,Config_OfficeLoc_AddLoc %>"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                                <tr class="required">
                                    <td class="header">
                                        <asp:Label ID="Label8" runat="server" Text="<%$ Resources:Admin,Config_OfficeLoc_Name %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLocation" CssClass="textbox-required" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAdd" runat="server" CssClass="submit" Text="<%$ Resources:Admin,Config_OfficeLoc_Add %>"
                                            OnClick="btnAdd_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
