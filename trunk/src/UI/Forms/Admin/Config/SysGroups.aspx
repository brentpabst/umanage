<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="SysGroups.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.SysGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>Groups to Ignore</strong>
        <br />
        Add groups here that you do not want to allow to be managed via uManage. (List as
        comma seperated)
    </p>
    <table class="form">
        <tr>
            <th class="top">
                Group List:
            </th>
            <td>
                <asp:TextBox ID="txtGroups" runat="server" Enabled="true" CssClass="text" Height="300px"
                    Width="500" Wrap="true" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
            </th>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Save Changes" CssClass="submit" OnClick="btnSubmit_Click" />
                <ums:OutputMessage ID="omResult" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
