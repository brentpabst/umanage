<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="Conf-Users.aspx.cs" Inherits="PPI.UMS.Web.Forms.Admin.Config.Conf_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-head">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Admin,Menu_Config_Users_Title %>"></asp:Label>
    </div>
    <div class="content-main">
        <p>
            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Admin,Config_Users_Body %>"></asp:Label>
        </p>
        <p>
            <strong>
                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Admin,Config_Users_CurrentUsers %>"></asp:Label>
            </strong>
        </p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <ums:Dialog ID="Dialog1" runat="server" />
                <table class="form">
                    <tr>
                        <td class="header">
                            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:Admin,Config_Users_SelectUsername %>"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="dropdown"
                                AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem Value="NA" Text="<%$ Resources:Admin,Config_Users_SelectUser %>"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="header vtop">
                            <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Admin,Config_Users_UserRoles %>"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="cbAdmin" runat="server" Text="Admin" />
                            <br />
                            <asp:CheckBox ID="cbSystem" runat="server" Text="System" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnUpdateSubmit" runat="server" CssClass="submit" Text="<%$ Resources:Admin,Config_Users_Update %>"
                                OnClick="btnUpdateSubmit_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <p>
            <strong>
                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Admin,Config_Users_NewUsers %>"></asp:Label>
            </strong>
        </p>
        <ums:Dialog ID="Dialog2" runat="server" />
        <table class="form">
            <tr>
                <td class="header">
                    <asp:Label ID="Label7" runat="server" Text="<%$ Resources:Admin,Config_Users_EnterUsername %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" CssClass="textbox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="header vtop">
                    <asp:Label ID="Label6" runat="server" Text="<%$ Resources:Admin,Config_Users_AssignRoles %>"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="cbNewAdmin" runat="server" Text="Admin" />
                    <br />
                    <asp:CheckBox ID="cbNewSystem" runat="server" Text="System" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnNewSubmit" runat="server" CssClass="submit" Text="<%$ Resources:Admin,Config_Users_Add %>"
                        OnClick="btnNewSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
