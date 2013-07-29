<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SlidingPanel.ascx.cs"
    Inherits="PPI.UMS.Web.Controls.SlidingPanel" %>
<ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" Collapsed="True"
    ExpandControlID="divPanelHeader" CollapseControlID="divPanelHeader" ImageControlID="imgExpand"
    CollapsedImage="~/Images/SlidingPanel-Expand.png" ExpandedImage="~/Images/SlidingPanel-Collapse.png">
</ajax:CollapsiblePanelExtender>
<div id="divPanelHeader" runat="server">
    <table class="slidingpanel-table" onmouseover="this.className='slidingpanel-table-active';"
        onmouseout="this.className='slidingpanel-table';">
        <tr>
            <td class="slidingpanel-title">
                <asp:Label ID="lblOptions" runat="server"></asp:Label>
            </td>
            <td class="slidingpanel-bar">
            </td>
            <td class="slidingpanel-image">
                <asp:Image ID="imgExpand" runat="server" />
            </td>
        </tr>
    </table>
</div>
