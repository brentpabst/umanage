<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="SysSummary.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.SysSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>About the uManage Software</strong>
        <br />
        uManage
        <br />
        &copy;
        <%= DateTime.Today.Year %>
        Tarheel Solutions, Inc.
        <br />
        All Rights Reserved
        <br />
        Version:
        <asp:Label ID="lblVersion" runat="server"></asp:Label>
        <br />
        License: <a href="http://umanage.codeplex.com/license" target="_blank">Microsoft Public
            License</a>
    </p>
    <p>
        uManage is an Active Directory Self-Service Portal application designed for use
        on intranet systems. It allows users to update their personal information while
        still allowing IT departments to control the access to user's information.
    </p>
    <p>
        Special thanks to KentWA and rikishipabst for their work in updating and providing
        uManage.
    </p>
</asp:Content>
