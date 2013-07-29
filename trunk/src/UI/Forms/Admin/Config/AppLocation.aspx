<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/Config.master" AutoEventWireup="true"
    CodeBehind="AppLocation.aspx.cs" Inherits="THS.UMS.UI.Forms.Admin.Config.AppLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <p>
        <strong>Organization Locations</strong>
        <br />
        These settings control the different locations your organization has as well as
        the active directory links for each location. Each location can have its own directory
        and new user configuration settings however they can be identical to other locations.
    </p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
        CssClass="grid" DataKeyNames="LocationId">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="LocationName" HeaderText="Location Name" SortExpression="LocationName" />
            <asp:BoundField DataField="OrganizationName" HeaderText="Organization Name" SortExpression="OrganizationName" />
            <asp:BoundField DataField="Directory" HeaderText="Directory" SortExpression="Directory" />
            <asp:BoundField DataField="DirectoryNt" HeaderText="NT Directory" SortExpression="DirectoryNt" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetActiveLocations"
        TypeName="THS.UMS.AO.Locations"></asp:ObjectDataSource>
    <br />
    <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource2" DefaultMode="Edit"
        RenderOuterTable="False">
        <EditItemTemplate>
            <table class="form">
                <tbody>
                    <tr>
                        <th>
                            Location Enabled:
                        </th>
                        <td>
                            <asp:CheckBox ID="IsEnabledCheckBox" runat="server" Checked='<%# Bind("IsEnabled") %>' />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Location Name:
                        </th>
                        <td>
                            <asp:TextBox ID="LocationNameTextBox" runat="server" Text='<%# Bind("LocationName") %>'
                                CssClass="text-req" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter a name for this location."
                                SetFocusOnError="True" ControlToValidate="LocationNameTextBox" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                                PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator1">
                            </ajax:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Organization Name:
                        </th>
                        <td>
                            <asp:TextBox ID="OrganizationNameTextBox" runat="server" Text='<%# Bind("OrganizationName") %>'
                                CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Address:
                        </th>
                        <td>
                            <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            City:
                        </th>
                        <td>
                            <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Province:
                        </th>
                        <td>
                            <asp:TextBox ID="ProvinceTextBox" runat="server" Text='<%# Bind("Province") %>' CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Postal Code:
                        </th>
                        <td>
                            <asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%# Bind("PostalCode") %>'
                                CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Country:
                        </th>
                        <td>
                            <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Phone:
                        </th>
                        <td>
                            <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Domain Name:
                        </th>
                        <td>
                            <asp:TextBox ID="DirectoryTextBox" runat="server" Text='<%# Bind("Directory") %>'
                                CssClass="text-req" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="You must enter the full path of your domain name."
                                SetFocusOnError="True" ControlToValidate="DirectoryTextBox" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" HighlightCssClass="text-invalid"
                                PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator5">
                            </ajax:ValidatorCalloutExtender>
                            <br />
                            (i.e. MyDomain.local)
                        </td>
                    </tr>
                    <tr>
                        <th>
                            New User DN:
                        </th>
                        <td>
                            <asp:TextBox ID="DistinguishedPathTextBox" runat="server" Text='<%# Bind("DistinguishedPath") %>'
                                CssClass="text-req" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter the full path of where to store new user accounts."
                                SetFocusOnError="True" ControlToValidate="DistinguishedPathTextBox" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" HighlightCssClass="text-invalid"
                                PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator2">
                            </ajax:ValidatorCalloutExtender>
                            <br />
                            (i.e. OU=MyUsers,DC=MyDomain,DC=local)
                            <br />
                            This is where new user accounts will be stored.
                        </td>
                    </tr>
                    <tr>
                        <th>
                            New Username Format:
                        </th>
                        <td>
                            <asp:TextBox ID="NewUsernameFormatTextBox" runat="server" Text='<%# Bind("NewUsernameFormat") %>'
                                CssClass="text-req" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter the format for new usernames."
                                SetFocusOnError="True" ControlToValidate="NewUsernameFormatTextBox" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" HighlightCssClass="text-invalid"
                                PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator3">
                            </ajax:ValidatorCalloutExtender>
                            <br />
                            Valid Tokens:
                            <br />
                            First Name: $fname$
                            <br />
                            Middle Name: $mname$
                            <br />
                            Last Name: $lname$
                            <br />
                            First Initial: $fi$
                            <br />
                            Middle Initial: $mi$
                            <br />
                            Last Initial: $li$
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Security Group:
                        </th>
                        <td>
                            <asp:TextBox ID="UmsDirectoryGroupTextBox" runat="server" Text='<%# Bind("UmsDirectoryGroup") %>'
                                CssClass="text-req" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You must enter the security group this location should use."
                                SetFocusOnError="True" ControlToValidate="UmsDirectoryGroupTextBox" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" HighlightCssClass="text-invalid"
                                PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator4">
                            </ajax:ValidatorCalloutExtender>
                            <br />
                            Specify the group that the system should use to search and add new users.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LocationIdLabel" runat="server" Text='<%# Bind("LocationId") %>' Visible="false" />
                        </td>
                        <td>
                            <asp:Button ID="btnUpdate" runat="server" CssClass="submit" CommandName="Update"
                                Text="Save Changes" />&nbsp;<asp:Button ID="btnInsert" runat="server" CssClass="submit"
                                    CommandName="New" Text="Add New Location" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </EditItemTemplate>
        <InsertItemTemplate>
            <table class="form">
                <tbody>
                    <tr>
                        <th>
                            Location Name:
                        </th>
                        <td>
                            <asp:TextBox ID="LocationNameTextBox" runat="server" Text='<%# Bind("LocationName") %>'
                                CssClass="text-req" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter the name of the location!"
                                SetFocusOnError="True" ControlToValidate="LocationNameTextBox" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="text-invalid"
                                PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator1">
                            </ajax:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Organization Name:
                        </th>
                        <td>
                            <asp:TextBox ID="OrganizationNameTextBox" runat="server" Text='<%# Bind("OrganizationName") %>'
                                CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Address:
                        </th>
                        <td>
                            <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            City:
                        </th>
                        <td>
                            <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Province:
                        </th>
                        <td>
                            <asp:TextBox ID="ProvinceTextBox" runat="server" Text='<%# Bind("Province") %>' CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Postal Code:
                        </th>
                        <td>
                            <asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%# Bind("PostalCode") %>'
                                CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Country:
                        </th>
                        <td>
                            <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Phone:
                        </th>
                        <td>
                            <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' CssClass="text" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Domain Name:
                        </th>
                        <td>
                            <asp:TextBox ID="DirectoryTextBox" runat="server" Text='<%# Bind("Directory") %>'
                                CssClass="text-req" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="You must enter the full path of your domain name."
                                SetFocusOnError="True" ControlToValidate="DirectoryTextBox" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" HighlightCssClass="text-invalid"
                                PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator5">
                            </ajax:ValidatorCalloutExtender>
                            <br />
                            (i.e. MyDomain.local)
                        </td>
                    </tr>
                    <tr>
                        <th>
                            New User DN:
                        </th>
                        <td>
                            <asp:TextBox ID="DistinguishedPathTextBox" runat="server" Text='<%# Bind("DistinguishedPath") %>'
                                CssClass="text-req" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter the full path where new accounts should be stored!"
                                SetFocusOnError="True" ControlToValidate="DistinguishedPathTextBox" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" HighlightCssClass="text-invalid"
                                PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator2">
                            </ajax:ValidatorCalloutExtender>
                            <br />
                            (i.e. OU=MyUsers,DC=MyDomain,DC=local)
                            <br />
                            This is where new user accounts will be stored.
                        </td>
                    </tr>
                    <tr>
                        <th>
                            New Username Format:
                        </th>
                        <td>
                            <asp:TextBox ID="NewUsernameFormatTextBox" runat="server" Text='<%# Bind("NewUsernameFormat") %>'
                                CssClass="text-req" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter the username format to use for new accounts!"
                                SetFocusOnError="True" ControlToValidate="NewUsernameFormatTextBox" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" HighlightCssClass="text-invalid"
                                PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator3">
                            </ajax:ValidatorCalloutExtender>
                            <br />
                            Valid Tokens:
                            <br />
                            First Name: $fname$
                            <br />
                            Middle Name: $mname$
                            <br />
                            Last Name: $lname$
                            <br />
                            First Initial: $fi$
                            <br />
                            Middle Initial: $mi$
                            <br />
                            Last Initial: $li$
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Security Group:
                        </th>
                        <td>
                            <asp:TextBox ID="UmsDirectoryGroupTextBox" runat="server" Text='<%# Bind("UmsDirectoryGroup") %>'
                                CssClass="text-req" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You must enter the security group to assign to this location!"
                                SetFocusOnError="True" ControlToValidate="UmsDirectoryGroupTextBox" Display="None"></asp:RequiredFieldValidator>
                            <ajax:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" HighlightCssClass="text-invalid"
                                PopupPosition="TopLeft" TargetControlID="RequiredFieldValidator4">
                            </ajax:ValidatorCalloutExtender>
                            <br />
                            Specify the group that the system should use to search and add new users.
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                CssClass="submit" Text="Add Location" />
                            &nbsp;<asp:Button ID="InsertCancelButton" runat="server" CausesValidation="False"
                                CssClass="submit" CommandName="Cancel" Text="Cancel" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </InsertItemTemplate>
        <EmptyDataTemplate>
            <div class="form">
                <asp:Button ID="btnInsert" runat="server" CssClass="submit" CommandName="New" Text="Add New Location" />
            </div>
        </EmptyDataTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetLocation"
        TypeName="THS.UMS.AO.Locations" DataObjectTypeName="THS.UMS.DTO.LocationDTO"
        InsertMethod="InsertLocation" UpdateMethod="UpdateLocation" OnInserted="ObjectDataSource2_Inserted"
        OnUpdated="ObjectDataSource2_Updated">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" DbType="Guid" Name="id" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
