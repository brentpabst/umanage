<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="SysAuto.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.SysAuto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>Automated Utility</strong>
        <br />
        Use this screen to control and view the status of the service utility.
    </p>
    <div class="box">
        <div class="head">
            Configuration File
        </div>
        <table class="form">
            <tbody>
                <tr>
                    <td colspan="2">
                        Please enter the local or UNC file path to the configuration file for the service
                        utility. Make sure the application pool user account has permission to modify the
                        configuration file. Do NOT enter ".config" at the end of the path.
                    </td>
                </tr>
                <tr>
                    <th>
                        File Path:
                    </th>
                    <td>
                        <asp:TextBox ID="txtPath" runat="server" CssClass="text-req"></asp:TextBox>&nbsp;.config
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter a path to the configuration file!"
                            SetFocusOnError="True" ControlToValidate="txtPath" Display="None" ValidationGroup="Search"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator1">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Update Configuration File" OnClick="btnSubmit_Click"
                            CssClass="submit" />
                        <ums:OutputMessage ID="omResult" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <br />
    <div class="box">
        <div class="head">
            Mail Queue
        </div>
        <div class="content">
            <asp:GridView ID="GridView1" runat="server" CssClass="grid" AutoGenerateColumns="False"
                DataSourceID="ObjectDataSource1" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:BoundField DataField="Address" HeaderText="Recipient" SortExpression="Address" />
                    <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
                    <asp:BoundField DataField="SubmittedOn" HeaderText="Submitted (UTC)" SortExpression="SubmittedOn"
                        DataFormatString="{0:d}" />
                    <asp:BoundField DataField="EffectiveDate" HeaderText="Send Date (UTC)" SortExpression="EffectiveDate"
                        DataFormatString="{0:d}" />
                    <asp:BoundField DataField="Attempts" HeaderText="Attempts" SortExpression="Attempts" />
                </Columns>
                <EmptyDataTemplate>
                    There are no messages pending.
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetActiveEmail"
                TypeName="THS.UMS.AO.Emails"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
