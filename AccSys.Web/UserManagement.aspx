﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="AccSys.Web.UserManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/tab.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/tab.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField runat="server" ID="HfCanView" />
    <asp:HiddenField runat="server" ID="HfCanAdd" />
    <asp:HiddenField runat="server" ID="HfCanEdit" />
    <asp:HiddenField runat="server" ID="HfCanDelete" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="float: right; width: 100%">
                <div id="RightPane" class="ui-layout-center ui-helper-reset ui-widget-content" style="top: 100px">
                    <!-- Tabs pane -->
                    <div id="tabs" class="jqgtabs">
                        <ul>
                            <li><a href="#tabs-1">User Management</a></li>
                        </ul>
                        <div id="tabs-1" style="font-size: 10px; font-weight: bold; height: 100%; width: 100%;">
                            <div style="text-align: center">
                                <br />
                                <h1>User Settings</h1>
                                <!-- Begin Body -->
                                <div style="text-align: left; margin-top: 20px;">
                                    <div class="col-md-3">
                                        <img src="Images/file.gif" alt="" class="tabLnkIcon" />
                                        <a href='<%=ResolveClientUrl("frmUsers.aspx") %>' class="tablink Hyperlink" id="users">Users</a>
                                    </div>
                                    <div class="col-md-3">
                                        <img src="Images/file.gif" alt="" class="tabLnkIcon" />
                                        <a href='<%=ResolveClientUrl("frmRoles.aspx") %>' class="tablink Hyperlink" id="roles">Roles</a>
                                    </div>
                                    <div class="col-md-3">
                                        <img src="Images/file.gif" alt="" class="tabLnkIcon" />
                                        <a href='<%=ResolveClientUrl("frmResources.aspx") %>' class="tablink Hyperlink" id="resources">Resources</a>
                                    </div>
                                    <div class="col-md-3">
                                        <img src="Images/file.gif" alt="" class="tabLnkIcon" />
                                        <a href='<%=ResolveClientUrl("frmRoleAccess.aspx") %>' class="tablink Hyperlink" id="roleresources">Role Access</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- #RightPane -->
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
