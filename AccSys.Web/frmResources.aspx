<%@ Page Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmResources.aspx.cs" Inherits="AccSys.Web.frmResources" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="HfCanView" />
    <asp:HiddenField runat="server" ID="HfCanAdd" />
    <asp:HiddenField runat="server" ID="HfCanEdit" />
    <asp:HiddenField runat="server" ID="HfCanDelete" />
    <div class="grid" style="width: auto;">
        <div class="panel panel-success">
            <div class="panel-heading form-horizontal">
                <div class="control-group">
                    <div class="controls form-inline">
                        <label>
                            <asp:Literal ID="Literal1" runat="server" Text="Resources" />
                        </label>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="mid">
                    <table>
                        <tr>
                            <td>
                                <asp:Literal ID="lGroup" Text="Group" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGroup" runat="server" ValidationGroup="insert"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtGroup" ErrorMessage="*" ValidationGroup="insert"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="lName" Text="Name" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" ValidationGroup="insert"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="txtName" ErrorMessage="*" ValidationGroup="insert"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="lPath" Text="Path" runat="server"></asp:Literal>
                            </td>
                            <td style="margin-left: 80px">
                                <asp:TextBox ID="txtPath" runat="server" ValidationGroup="insert" Width="300px"></asp:TextBox>
                            </td>
                            <td style="margin-left: 80px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txtPath" ErrorMessage="*" ValidationGroup="insert"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="lType" Text="Type" runat="server"></asp:Literal>
                            </td>
                            <td style="margin-left: 80px">
                                <asp:DropDownList ID="ddlType" runat="server">
                                    <asp:ListItem meta:resourcekey="ListItemResource1">Page</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource2">ReportPage</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource3">Others</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="margin-left: 80px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td style="margin-left: 80px">
                                <asp:HrnLinkButton SecurityCommandName="Add" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-default glyphicon glyphicon-saved"
                                    ValidationGroup="insert" />
                                <asp:LinkButton ID="btnReset" runat="server" OnClick="btnReset_Click" CssClass="btn btn-default glyphicon glyphicon-erase"
                                    Text="Reset" />
                            </td>
                            <td style="margin-left: 80px">&nbsp;</td>
                        </tr>
                    </table>

                    <div>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div style="width: 100%; overflow: auto">
                        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" CssClass="datatable"
                            EmptyDataText="No Resource Found."
                            AllowSorting="True" DataKeyNames="ResourceID" DataSourceID="DsResources"
                            AllowPaging="True" PageSize="20" BorderWidth="0px" GridLines="None">
                            <Columns>
                                <asp:TemplateField ShowHeader="False" HeaderText="Edit">
                                    <EditItemTemplate>
                                        <asp:HrnLinkButton SecurityCommandName="Edit" ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update" CssClass="glyphicon glyphicon-ok"></asp:HrnLinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="glyphicon glyphicon-remove-circle"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:HrnLinkButton SecurityCommandName="Edit" ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" CssClass="glyphicon glyphicon-edit"></asp:HrnLinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="GroupName" HeaderText="Group"
                                    SortExpression="GroupName" />
                                <asp:BoundField DataField="ResourceID" HeaderText="ResourceID"
                                    InsertVisible="False" ReadOnly="True" SortExpression="ResourceID"
                                    Visible="False" />
                                <asp:BoundField DataField="ResourceName" HeaderText="Resource Name"
                                    SortExpression="ResourceName" />
                                <asp:BoundField DataField="ResourcePath" HeaderText="Path"
                                    SortExpression="ResourcePath" />
                                <asp:BoundField DataField="ResourceType" HeaderText="Type"
                                    SortExpression="ResourceType" />
                                <asp:TemplateField ShowHeader="False" HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:HrnLinkButton SecurityCommandName="Delete" ID="LinkButton4" runat="server" CausesValidation="False" OnClientClick="return confirm('Do you really want to delete it?');"
                                            CommandName="Delete" Text="Delete" CssClass="glyphicon glyphicon-remove"></asp:HrnLinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Position="TopAndBottom" />
                            <PagerStyle CssClass="pager" />
                            <RowStyle CssClass="row" />
                            <HeaderStyle CssClass="row" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="DsResources" runat="server"
                            ConnectionString="<%$ ConnectionStrings:DbConnectionString %>"
                            DeleteCommand="DELETE FROM [Resources] WHERE [ResourceID] = @ResourceID"
                            InsertCommand="INSERT INTO [Resources] ([GroupName], [ResourceName], [ResourcePath], [ResourceType]) VALUES (@GroupName, @ResourceName, @ResourcePath, @ResourceType)"
                            SelectCommand="SELECT [GroupName], [ResourceID], [ResourceName], [ResourcePath], [ResourceType] FROM [Resources] ORDER BY [GroupName]"
                            UpdateCommand="UPDATE [Resources] SET [GroupName] = @GroupName, [ResourceName] = @ResourceName, [ResourcePath] = @ResourcePath, [ResourceType] = @ResourceType WHERE [ResourceID] = @ResourceID" OnDeleted="DsData_OperationCompleted" OnInserted="DsData_OperationCompleted" OnSelected="DsData_OperationCompleted" OnUpdated="DsData_OperationCompleted">
                            <DeleteParameters>
                                <asp:Parameter Name="ResourceID" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:ControlParameter ControlID="txtGroup" Name="GroupName" PropertyName="Text"
                                    Type="String" />
                                <asp:ControlParameter ControlID="txtName" Name="ResourceName"
                                    PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="txtPath" Name="ResourcePath"
                                    PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="ddlType" Name="ResourceType"
                                    PropertyName="SelectedValue" Type="String" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="GroupName" Type="String" />
                                <asp:Parameter Name="ResourceName" Type="String" />
                                <asp:Parameter Name="ResourcePath" Type="String" />
                                <asp:Parameter Name="ResourceType" Type="String" />
                                <asp:Parameter Name="ResourceID" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
