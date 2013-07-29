<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/User.Master" AutoEventWireup="true"
    CodeBehind="Error.aspx.cs" Inherits="PPI.UMS.Web.Forms.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/UMS-Error.png" AlternateText="Error Logo" />
    <h2>
        We Doubt it's your fault!
    </h2>
    <p>
        From time to time problems come up with the system and can cause you to see this
        message. More than likely we were unable to handle an error in the system so we
        are showing you this page instead. Sorry about that!
    </p>
    <h4>
        Let's Try That Again...
    </h4>
    <p>
        You can use the navigation bar up above or simply
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/">click here</asp:HyperLink>
        to reload the application.
    </p>
</asp:Content>
