<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="AccSys.Web.AccountPage" %>

<%@ Register Assembly="AccSys.Web" Namespace="AccSys.Web.DbControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                                <asp:Literal ID="Literal1" runat="server" Text="User" />
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
                                <td class="InputLabel" style="width: 150px">
                                    <asp:Label ID="Literal33" Text="User Name" runat="server" AssociatedControlID="lblUserName"></asp:Label>
                                    <asp:Label ID="lblId" runat="server" Text="0" Visible="False"></asp:Label>
                                </td>
                                <td class="InputField">
                                    <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                                </td>
                                <td></td>
                            </tr>

                            <tr class="row">
                                <td class="InputLabel">
                                    <asp:Label ID="LabelRole" Text="Role" runat="server" AssociatedControlID="lblRole" ></asp:Label>
                                </td>
                                <td class="InputField">
                                    <asp:Label ID="lblRole" Text="" runat="server"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr class="row">
                                <td colspan="3">
                                    Change password
                                </td>
                            </tr>
                            <tr class="row">
                                <td class="InputLabel">
                                    <asp:Label ID="Label1" Text="Current Password" runat="server" AssociatedControlID="txtCurrentPassword"></asp:Label>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr class="row">
                                <td class="InputLabel">
                                    <asp:Label ID="Literal5" Text="New Password" runat="server" AssociatedControlID="txtPassword"></asp:Label>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                                        ErrorMessage="New password is required." ToolTip="New password is required.">*</asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr class="row">
                                <td class="InputLabel">
                                    <asp:Label ID="Literal2" Text="Confirm New Password" runat="server" AssociatedControlID="txtConfirmPassword"></asp:Label>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="txtConfirmPassword"
                                        ErrorMessage="Confirm password is required." ToolTip="Confirm password is required.">*</asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr class="row">
                                <td colspan="3" style="color: red !important">
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPassword"
                                        ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."></asp:CompareValidator>
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr class="row">
                                <td class="InputLabel"></td>
                                <td colspan="2" align="left">
                                    <asp:LinkButton ID="btnUpdate" runat="server" OnClick="btnUpdate_Click"  CssClass="btn btn-default">
                                       <i class="glyphicon glyphicon-edit"></i> Change Password
                                    </asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <asp:Label ID="lblMsg" runat="server" Style="font-weight: 700"></asp:Label>
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

