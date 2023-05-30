<%@ Page Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmRoles.aspx.cs" Inherits="AccSys.Web.frmRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="HfCanView" />
    <asp:HiddenField runat="server" ID="HfCanAdd" />
    <asp:HiddenField runat="server" ID="HfCanEdit" />
    <asp:HiddenField runat="server" ID="HfCanDelete" />
    <div class="grid">
        <div class="rounded">
            <div class="top-outer">
                <div class="top-inner">
                    <div class="top">
                        <asp:Panel ID="Panel2" runat="server">
                            <div class="title">
                                <asp:Literal ID="Literal1" runat="server" Text="Roles" />
                            </div>
                            <div class="search">
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
            <div class="mid-outer">
                <div class="mid-inner">
                    <div class="mid">
                        <table class="datatable">
                            <tr class="row">
                                <td class="InputLabel">
                                    <asp:Label ID="Literal33" Text="Role" runat="server" AssociatedControlID="txtRoleName"></asp:Label>
                                    <asp:Label ID="lblRoleId" runat="server" Text="0" Visible="False"></asp:Label>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtRoleName" runat="server" ValidationGroup="Create"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RoleNameRequired" runat="server" ControlToValidate="txtRoleName" ValidationGroup="Create"
                                        ErrorMessage="Role name is required." ToolTip="Role name is required.">*</asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr class="row">
                                <td class="InputLabel"></td>
                                <td colspan="2" align="left">
                                    <asp:HrnLinkButton ID="btnCreate" runat="server" SecurityCommandName="Add" CssClass="btn btn-default"
                                        OnClick="btnCreate_Click" ValidationGroup="Create">
                                    <i class="glyphicon glyphicon-saved"></i> Create Role
                                    </asp:HrnLinkButton>
                                    <asp:LinkButton ID="btnReset" runat="server" CssClass="btn btn-default" ValidationGroup="Reset"
                                        OnClick="btnReset_Click">
                                    <i class="glyphicon glyphicon-erase"></i> Reset
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <asp:Label ID="lblMsg" runat="server" Style="font-weight: 700"></asp:Label>
                        </div>
                        <div style="width: 100%; overflow: auto">
                            <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False"
                                CssClass="datatable" Font-Names="Calibri" Font-Size="10pt" EmptyDataText="No Role Found.">
                                <RowStyle CssClass="row" />
                                <HeaderStyle CssClass="row" />
                                <Columns>
                                    <asp:TemplateField HeaderText="RoleId" SortExpression="RoleId" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Bind("RoleId") %>' ID="lblRoleId"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RoleName" SortExpression="RoleName">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Bind("RoleName") %>' ID="lblRoleName"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:HrnLinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" CausesValidation="False" SecurityCommandName="Edit" CssClass="glyphicon glyphicon-edit">Edit</asp:HrnLinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:HrnLinkButton SecurityCommandName="Delete" ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CausesValidation="False" CssClass="glyphicon glyphicon-remove" OnClientClick="if(!confirm('Do you want to delete?')) return false;">Delete</asp:HrnLinkButton>
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
            <div class="bottom-outer">
                <div class="bottom-inner">
                    <div class="bottom">
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
