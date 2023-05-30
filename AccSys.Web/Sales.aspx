<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="AccSys.Web.Sales" %>

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
                            <li>
                                <a href="#tabs-1">Sales</a>
                            </li>
                        </ul>
                        <div id="tabs-1" style="font-size: 1em; font-weight: bold; height: 100%; width: 100%;">
                            <div style="text-align: center">
                                <br />
                                <h1>Sales Management</h1>
                                <!-- Begin Body -->
                                <div style="text-align: left; margin-top: 5%;">
                                    <div class="col-md-4">
                                        <img src="Images/file.gif" alt="" class="tabLnkIcon">
                                        <a href='<%=ResolveClientUrl("frmSaleOrder.aspx") %>' class="tablink Hyperlink" id="so">
                                            Sales Order
                                        </a>
                                    </div>
                                    <div class="col-md-4">
                                        <img src="Images/file.gif" alt="" class="tabLnkIcon">
                                        <a href='<%=ResolveClientUrl("frmSaleInvoice.aspx") %>' class="tablink Hyperlink" id="si">
                                            Sales Invoice
                                        </a>
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
