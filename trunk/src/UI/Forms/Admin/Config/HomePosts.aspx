<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="HomePosts.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.HomePosts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>Wall Posts</strong>
        <br />
        Use this form to manage and maintain any announcements or posts to the home page
        wall.
    </p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
        DataKeyNames="PostId" CssClass="grid">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
            <asp:BoundField DataField="PostedBy" HeaderText="Posted By" SortExpression="PostedBy" />
            <asp:BoundField DataField="PostedOn" HeaderText="Posted On" SortExpression="PostedOn"
                DataFormatString="{0:d}" />
            <asp:BoundField DataField="VisibleFrom" HeaderText="Visible From" SortExpression="VisibleFrom"
                DataFormatString="{0:d}" />
            <asp:BoundField DataField="VisibleTo" HeaderText="Visible Until" SortExpression="VisibleTo"
                DataFormatString="{0:d}" />
        </Columns>
        <EmptyDataTemplate>
            <strong>Oops!</strong> No posts were found.
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetPosts"
        TypeName="THS.UMS.AO.Posts"></asp:ObjectDataSource>
    <br />
    <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource2" DataKeyNames="PostId"
        DefaultMode="Edit" OnItemCommand="FormView1_ItemCommand">
        <EmptyDataTemplate>
            <div class="form">
                <asp:Button ID="AddButton" runat="server" CausesValidation="True" CommandName="New"
                    CssClass="submit" Text="Add New Post" />
            </div>
        </EmptyDataTemplate>
        <EditItemTemplate>
            <asp:Label ID="PostIdTextBox" runat="server" Text='<%# Bind("PostId") %>' Visible="false" />
            <table class="form">
                <tr>
                    <th>
                        Subject:
                    </th>
                    <td>
                        <asp:TextBox ID="SubjectTextBox" runat="server" Text='<%# Bind("Subject") %>' CssClass="text" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter a subject for this post."
                            SetFocusOnError="True" ControlToValidate="SubjectTextBox" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator1">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th>
                        Visible From:
                    </th>
                    <td>
                        <asp:TextBox ID="VisibleFromTextBox" runat="server" Text='<%# Bind("VisibleFrom", "{0:d}") %>'
                            CssClass="text" />
                        <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="VisibleFromTextBox" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter a visible from date."
                            SetFocusOnError="True" ControlToValidate="VisibleFromTextBox" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator2">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th>
                        Visible Until:
                    </th>
                    <td>
                        <asp:TextBox ID="VisibleToTextBox" runat="server" Text='<%# Bind("VisibleTo", "{0:d}") %>'
                            CssClass="text" />
                        <ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="VisibleToTextBox" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter a visible to date."
                            SetFocusOnError="True" ControlToValidate="VisibleToTextBox" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator3">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th class="top">
                        Message:
                    </th>
                    <td>
                        <ajax:Editor ID="eMessage" runat="server" Height="300px" Content='<%# Bind("Message") %>' />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update Post" CssClass="submit" />
                        &nbsp;
                        <asp:Button ID="DeleteButton" runat="server" CausesValidation="false" CommandName="Delete"
                            Text="Delete Post" CssClass="submit" OnClientClick="return confirm('Are you sure you want to delete this post?');" />
                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </EditItemTemplate>
        <InsertItemTemplate>
            <table class="form">
                <tr>
                    <th>
                        Subject:
                    </th>
                    <td>
                        <asp:TextBox ID="SubjectTextBox" runat="server" Text='<%# Bind("Subject") %>' CssClass="text" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter a subject for this post."
                            SetFocusOnError="True" ControlToValidate="SubjectTextBox" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator1">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th>
                        Visible From:
                    </th>
                    <td>
                        <asp:TextBox ID="VisibleFromTextBox" runat="server" Text='<%# Bind("VisibleFrom") %>'
                            CssClass="text" />
                        <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="VisibleFromTextBox"
                            SelectedDate="<%# DateTime.UtcNow.Date%>" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter a visible from date."
                            SetFocusOnError="True" ControlToValidate="VisibleFromTextBox" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator2">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th>
                        Visible Until:
                    </th>
                    <td>
                        <asp:TextBox ID="VisibleToTextBox" runat="server" Text='<%# Bind("VisibleTo") %>'
                            CssClass="text" />
                        <ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="VisibleToTextBox"
                            SelectedDate="<%# DateTime.UtcNow.AddMonths(1).Date%>" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter a visible to date."
                            SetFocusOnError="True" ControlToValidate="VisibleToTextBox" Display="None"></asp:RequiredFieldValidator>
                        <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="text-invalid"
                            PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator3">
                        </ajax:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <th class="top">
                        Message:
                    </th>
                    <td>
                        <ajax:Editor ID="eTemplate" runat="server" Height="300px" Content='<%# Bind("Message") %>' />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                            Text="Add New Post" CssClass="submit" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                            CommandName="Cancel" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </InsertItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="THS.UMS.DTO.PostDTO"
        DeleteMethod="DeletePost" InsertMethod="AddPost" SelectMethod="GetPost" TypeName="THS.UMS.AO.Posts"
        UpdateMethod="UpdatePost" OnInserted="ObjectDataSource2_Inserted" OnDeleted="ObjectDataSource2_Deleted"
        OnUpdated="ObjectDataSource2_Updated">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" DbType="Guid" Name="Id" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
