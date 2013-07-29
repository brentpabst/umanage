<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="AppTemplates.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.AppTemplates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>E-Mail Templates</strong>
        <br />
        Select the e-mail template from the list below and make any changes needed.
    </p>
    <table class="form">
        <tbody>
            <tr>
                <th>
                    Select Template:
                </th>
                <td>
                    <asp:DropDownList ID="ddlTemplates" runat="server" CssClass="list" AppendDataBoundItems="True"
                        AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Value" DataValueField="Key"
                        OnSelectedIndexChanged="ddlTemplates_SelectedIndexChanged">
                        <asp:ListItem Text="Select a Template..." Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetEmailTemplateList"
                        TypeName="THS.UMS.AO.Emails"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <th>
                    Edit Template:
                </th>
                <td>
                    <ajax:Editor ID="eTemplate" runat="server" Height="300px"></ajax:Editor>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Save Changes" CssClass="submit" OnClick="btnSubmit_Click" />
                    <ums:OutputMessage ID="omResult" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
