<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlUsers.ascx.cs" Inherits="AccSys.Web.UserControls.CtlUsers" %>

<div class="grid">
    <div class="rounded">
        <div class="top-outer">
            <div class="top-inner">
                <div class="top">
                    <asp:Panel ID="Panel2" runat="server">
                        <div class="title">
                            <asp:Literal ID="Literal1" runat="server" Text="Users" />
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
                                <asp:Label ID="Literal33" Text="User Name" runat="server" AssociatedControlID="txtUserName"></asp:Label>
                                <asp:Label ID="lblId" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                            <td class="InputField">
                                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserName"
                                    ErrorMessage="User Name is required." ToolTip="User Name is required.">*</asp:RequiredFieldValidator>
                            </td>
                            <td></td>
                        </tr>
                        <tr class="row">
                            <td class="InputLabel">
                                <asp:Label ID="Literal4" Text="Role" runat="server" AssociatedControlID="ddlRole"></asp:Label>
                            </td>
                            <td class="InputField">
                                <asp:DropDownList ID="ddlRole" runat="server" Height="16px" Width="121px">
                                    <asp:ListItem>Administrator</asp:ListItem>
                                    <asp:ListItem>SuperAdministrator</asp:ListItem>
                                    <asp:ListItem>User</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td></td>
                        </tr>
                        <tr class="row">
                            <td colspan="3">
                                <asp:CheckBox ID="chkPass" runat="server" Checked="true" Text="Reset Password" OnCheckedChanged="chkPass_CheckedChanged" AutoPostBack="true" Visible="false" />
                            </td>
                        </tr>
                        <tr class="row">
                            <td class="InputLabel">
                                <asp:Label ID="Literal5" Text="Password" runat="server" AssociatedControlID="txtPassword"></asp:Label>
                            </td>
                            <td class="InputField">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ValidationGroup="Create"></asp:TextBox>
                                <asp:Label ID="lblPassword" runat="server" Visible="false"></asp:Label>
                                <asp:RequiredFieldValidator ID="vtxtPassword" runat="server" ControlToValidate="txtPassword" ValidationGroup="Create"
                                    ErrorMessage="Password is required." ToolTip="Password is required.">*</asp:RequiredFieldValidator>
                            </td>
                            <td></td>
                        </tr>
                        <tr class="row">
                            <td class="InputLabel">
                                <asp:Label ID="Literal2" Text="Confirm Password" runat="server" AssociatedControlID="txtConfirmPassword"></asp:Label>
                            </td>
                            <td class="InputField">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" ValidationGroup="Create"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="vtxtConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ValidationGroup="Create"
                                    ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required.">*</asp:RequiredFieldValidator>
                            </td>
                            <td></td>
                        </tr>
                        <tr class="row">
                            <td colspan="3" style="color: red">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPassword" ValidationGroup="Create"
                                    ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."></asp:CompareValidator>
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>

                        <tr class="row">
                            <td class="InputLabel"></td>
                            <td colspan="2" align="left">
                                <asp:LinkButton ID="btnCreate" runat="server" SecurityCommandName="Add" CssClass="btn btn-default"
                                    OnClick="btnCreate_Click" ValidationGroup="Create">
                                    <i class="glyphicon glyphicon-saved"></i> Create User
                                </asp:LinkButton>
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
                            CssClass="datatable" Font-Names="Calibri" Font-Size="10pt" EmptyDataText="No User Found.">
                            <RowStyle CssClass="row" />
                            <HeaderStyle CssClass="row" />
                            <Columns>
                                <asp:TemplateField HeaderText="UserID" SortExpression="UserID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Bind("UserID") %>' ID="lblUserId"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UserName" SortExpression="UserName">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Bind("UserName") %>' ID="lblUserName"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Role" SortExpression="Role">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Bind("Role") %>' ID="lblRole"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" CausesValidation="False" SecurityCommandName="Edit" CssClass="glyphicon glyphicon-edit">Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton SecurityCommandName="Delete" ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CausesValidation="False" CssClass="glyphicon glyphicon-remove" OnClientClick="if(!confirm('Do you want to delete?')) return false;">Delete</asp:LinkButton>
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
