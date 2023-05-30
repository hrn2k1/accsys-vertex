<%@ Page Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmRoleAccess.aspx.cs" Inherits="AccSys.Web.frmRoleAccess" %>

<%@ Register Assembly="AccSys.Web" Namespace="AccSys.Web.DbControls" TagPrefix="cc1" %>

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
                    <div class="input-area">
                        <label>
                            <asp:Literal ID="lRole" Text="Role" runat="server"></asp:Literal>
                        </label>
                        <cc1:RoleDropDownList ID="ddlRoles" runat="server" />
                        <label>
                            <asp:Literal ID="lGroup" Text="Group" runat="server"></asp:Literal>
                        </label>
                        <asp:DropDownList ID="ddlGroup" runat="server" AppendDataBoundItems="True"
                            DataSourceID="dsGroupNames" DataTextField="GroupName"
                            DataValueField="GroupName">
                            <asp:ListItem Value="all">All</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dsGroupNames" runat="server"
                            ConnectionString="<%$ ConnectionStrings:DbConnectionString %>"
                            SelectCommand="SELECT DISTINCT [GroupName] FROM [Resources] ORDER BY [GroupName]"></asp:SqlDataSource>

                        <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CssClass="btn btn-sm btn-default glyphicon glyphicon-search" Text="Search" />
                        <asp:HrnLinkButton SecurityCommandName="Add" ID="btnSave" runat="server" Text="Save" CssClass="btn btn-sm btn-default glyphicon glyphicon-saved" ValidationGroup="insert" OnClick="btnSave_Click" />

                    </div>
                    <div>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div style="width: 100%; overflow: auto">
                        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" CssClass="datatable"
                            EmptyDataText="No Data Found."
                            AllowSorting="True" AllowPaging="True" PageSize="100" BorderWidth="0px" GridLines="None">
                            <RowStyle CssClass="row" />
                            <HeaderStyle CssClass="row" />
                            <Columns>
                                <asp:TemplateField HeaderText="S/L">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ResourceID" InsertVisible="False"
                                    SortExpression="ResourceID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblResourceID" runat="server" Text='<%# Bind("ResourceID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ResourceID") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="GroupName" HeaderText="Group Name" SortExpression="GroupName" />
                                <asp:BoundField DataField="ResourceName" HeaderText="Page Name" SortExpression="ResourceName" />
                                <asp:TemplateField HeaderText="Can View" SortExpression="CanView">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkTickView" runat="server" AutoPostBack="True"
                                            OnCheckedChanged="chkTickView_CheckedChanged" Text="CanView" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkView" runat="server" Checked='<%# Bind("CanView") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Can Add" SortExpression="CanAdd">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkTickAdd" runat="server" AutoPostBack="True"
                                            OnCheckedChanged="chkTickAdd_CheckedChanged" Text="CanAdd" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkAdd" runat="server" Checked='<%# Bind("CanAdd") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Can Edit" SortExpression="CanEdit">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkTickEdit" runat="server" AutoPostBack="True"
                                            OnCheckedChanged="chkTickEdit_CheckedChanged" Text="CanEdit" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkEdit" runat="server" Checked='<%# Bind("CanEdit") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Can Delete" SortExpression="CanDelete">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkTickDelete" runat="server" AutoPostBack="True"
                                            OnCheckedChanged="chkTickDelete_CheckedChanged" Text="CanDelete" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkDelete" runat="server" Checked='<%# Bind("CanDelete") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Position="TopAndBottom" />
                            <PagerStyle CssClass="pager" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
