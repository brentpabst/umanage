<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="Conf-MsftTag.aspx.cs" Inherits="PPI.UMS.Web.Forms.Admin.Config.Conf_MsftTag" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-head">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Admin,Menu_Config_Tag_Title %>"></asp:Label>
    </div>
    <div class="content-main">
        <span style="color: Red; font-weight: bold;">Microsoft Tag is not yet available for
            use!</span>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/uManage-MsftTag.png" AlternateText="Tag" />
                </td>
                <td valign="top">
                    <p>
                        uManage now supports Microsoft Tag integration for dynamic generation of tags based
                        on the contact information stored in uManage and Active Directory. By utilizing
                        Microsoft Tag integration you will allow employees to generate tags for their contact
                        information that can then be distributed to others. This presents a nice marketing
                        and collaboration opportunity and allows it to happen seamlessly.
                    </p>
                    <p>
                        <strong>Requirements</strong>
                        <br />
                        In order to use Microsoft Tag you must have the following:
                    </p>
                    <ol>
                        <li>The Web Server must have internet access</li>
                        <li>You must have a valid Microsoft Tag API Key</li>
                    </ol>
                    <p>
                        <strong>Obtaining a API Key</strong>
                        <br />
                        Do the following to obtain an API key:
                    </p>
                    <ol>
                        <li>Browse to the request site: <a href="http://tag.microsoft.com/ws/accessrequest.aspx"
                            target="_blank">http://tag.microsoft.com/ws/accessrequest.aspx</a></li>
                        <li>You will need a Windows Live ID to login</li>
                        <li>Fill out the form</li>
                        <li>Wait for your key to arrive via e-mail</li>
                        <li>If you have problems or it takes more than a day to get your key try contacting
                            the Tag team at Microsoft on Twitter: @microsofttag</li>
                    </ol>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <ums:Dialog ID="Dialog1" runat="server" />
                <table class="form">
                    <tr>
                        <td class="header">
                            Enable Microsoft Tag?
                        </td>
                        <td>
                            <asp:CheckBox ID="cbEnable" runat="server" AutoPostBack="True" OnCheckedChanged="cbEnable_CheckedChanged" />
                        </td>
                    </tr>
                    <tr class="required">
                        <td class="header">
                            Tag API Key:
                        </td>
                        <td>
                            <asp:TextBox ID="txtApiKey" runat="server" CssClass="textbox-required" Enabled="false"
                                Style="width: 375px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Save Configuration" CssClass="submit"
                                OnClick="btnSubmit_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
