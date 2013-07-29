<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserBadge.ascx.cs" Inherits="THS.UMS.UI.Controls.Helpers.UserBadge" %>
<style type="text/css">
    .badge
    {
    }
    
    .badge .name
    {
        font-weight: bold;
        padding: 4px 5px;
        font-size: .9em;
        background-color: Silver;
    }
    
    .badge .body
    {
        margin: 3px 0px;
    }
</style>
<div class="badge">
    <div class="name">
        <asp:Label ID="lblName" runat="server"></asp:Label>
    </div>
    <div class="body">
        <div class="left" style="width: 100px">
            <asp:Image ID="imgPhoto" runat="server" />
        </div>
        <div class="left" style="min-width: 200px;">
            <asp:Literal ID="lblBasicInfo" runat="server" />
        </div>
        <div class="clear">
        </div>
    </div>
</div>
