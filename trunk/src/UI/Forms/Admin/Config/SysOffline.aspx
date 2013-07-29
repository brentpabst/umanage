<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="SysOffline.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.SysOffline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>Take Application Offline</strong>
        <br />
        You can take the application offline for various reasons like system upgrades, planned
        outages, etc. Once offline the application can only be restored by deleting the
        "App_Offline.htm" file in the root of the virtual directory.
    </p>
    <table class="form">
        <tbody>
            <tr>
                <th>
                    Take Application Offline?
                </th>
                <td>
                    <asp:CheckBox ID="cbVerify" runat="server" Text="Yes" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit Changes" CssClass="submit"
                        OnClick="btnSubmit_Click" />
                    <ums:OutputMessage ID="omResult" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
