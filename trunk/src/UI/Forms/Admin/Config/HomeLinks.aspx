<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="HomeLinks.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.HomeLinks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>Quick Links</strong>
        <br />
        Quick Links allow you to define standard links that users will be able to utilize
        from the cutom home page of uManage.
    </p>
    <table class="form">
        <tr>
            <th>
                Enable Quick Links:
            </th>
            <td>
                <asp:CheckBox ID="cbEnabled" runat="server" />
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
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
        DataKeyNames="LinkId" CssClass="grid">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Text" HeaderText="Display Text" SortExpression="Text" />
            <asp:BoundField DataField="Url" HeaderText="URL" SortExpression="Url" />
            <asp:BoundField DataField="Order" HeaderText="Display Order" SortExpression="Order" />
        </Columns>
        <EmptyDataTemplate>
            <strong>Oops!</strong> No links were found.
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetLinks"
        TypeName="THS.UMS.AO.Links"></asp:ObjectDataSource>
    <br />
    <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource2" DefaultMode="Edit"
        OnItemCommand="FormView1_ItemCommand" DataKeyNames="LinkId">
        <InsertItemTemplate>
            <table class="form">
                <tr>
                    <th>
                        Display Text:
                    </th>
                    <td>
                        <asp:TextBox ID="TextTextBox" runat="server" Text='<%# Bind("Text") %>' CssClass="text" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter a name for this link."
                            SetFocusOnError="True" ControlToValidate="TextTextBox" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator1">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th>
                        URL:
                    </th>
                    <td>
                        <asp:TextBox ID="UrlTextBox" runat="server" Text='<%# Bind("Url") %>' CssClass="text" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter a URL for this link."
                            SetFocusOnError="True" ControlToValidate="UrlTextBox" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator2">
                        </ajax:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="You must enter a valid URL."
                            ControlToValidate="UrlTextBox" Display="none" SetFocusOnError="true" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RegularExpressionValidator1">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th>
                        Display Order:
                    </th>
                    <td>
                        <asp:TextBox ID="OrderTextBox" runat="server" Text='<%# Bind("Order") %>' CssClass="text" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter a display order number."
                            SetFocusOnError="True" ControlToValidate="OrderTextBox" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator3">
                        </ajax:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="You must enter a valid number."
                            ControlToValidate="OrderTextBox" Display="none" SetFocusOnError="true" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RegularExpressionValidator2">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                            Text="Add New Link" CssClass="submit" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </InsertItemTemplate>
        <EditItemTemplate>
            <asp:Label ID="LinkIdLabel" runat="server" Text='<%# Bind("LinkId") %>' Visible="false" />
            <table class="form">
                <tr>
                    <th>
                        Display Text:
                    </th>
                    <td>
                        <asp:TextBox ID="TextTextBox" runat="server" Text='<%# Bind("Text") %>' CssClass="text" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter a name for this link."
                            SetFocusOnError="True" ControlToValidate="TextTextBox" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator1">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th>
                        URL:
                    </th>
                    <td>
                        <asp:TextBox ID="UrlTextBox" runat="server" Text='<%# Bind("Url") %>' CssClass="text" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter a URL for this link."
                            SetFocusOnError="True" ControlToValidate="UrlTextBox" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator2">
                        </ajax:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="You must enter a valid URL."
                            ControlToValidate="UrlTextBox" Display="none" SetFocusOnError="true" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RegularExpressionValidator1">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th>
                        Display Order:
                    </th>
                    <td>
                        <asp:TextBox ID="OrderTextBox" runat="server" Text='<%# Bind("Order") %>' CssClass="text" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter a display order number."
                            SetFocusOnError="True" ControlToValidate="OrderTextBox" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator3">
                        </ajax:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="You must enter a valid number."
                            ControlToValidate="OrderTextBox" Display="none" SetFocusOnError="true" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RegularExpressionValidator2">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update Link" CssClass="submit" />
                        &nbsp;<asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="Delete Link" CssClass="submit" OnClientClick="return confirm('Are you sure you want to delete this link?');" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <div class="form">
                <asp:Button ID="AddButton" runat="server" CausesValidation="True" CommandName="New"
                    CssClass="submit" Text="Add New Link" />
            </div>
        </EmptyDataTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="THS.UMS.DTO.LinkDTO"
        DeleteMethod="DeleteLink" InsertMethod="AddLink" SelectMethod="GetLink" TypeName="THS.UMS.AO.Links"
        OnInserted="ObjectDataSource2_Inserted" OnDeleted="ObjectDataSource2_Deleted"
        OnUpdated="ObjectDataSource2_Updated" UpdateMethod="UpdateLink">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" DbType="Guid" Name="id" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
