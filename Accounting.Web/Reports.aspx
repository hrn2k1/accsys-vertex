<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Accounting.Web.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/tab.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/tab.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="float: right; width: 100%">
        <div id="RightPane" class="ui-layout-center ui-helper-reset ui-widget-content" style="top: 100px">
            <!-- Tabs pane -->
            <div id="tabs" class="jqgtabs">
                <ul>
                    <li>
                        <a href="#tabs-1">Reports</a>
                    </li>
                </ul>
                <div id="tabs-1" style="font-size: 1em; font-weight: bold; height: 100%; width: 100%;">
                    <div style="text-align: center">
                        <br />
                        <h1>Accounting Reports</h1>
                        <!-- Begin Body -->
                        <div style="text-align: left; margin-top:20px;">
                            <div class="col-md-3">
                                <img src="Images/file.gif" alt="" class="tabLnkIcon" />
                                <a href='<%=ResolveClientUrl("frmReport.aspx?rpt=chartofaccounts") %>' class="tablink Hyperlink" id="report_coa">Chart of Accounts</a>
                            </div>
                            <div class="col-md-3">
                                <img src="Images/file.gif" alt="" class="tabLnkIcon" />
                                <a href='<%=ResolveClientUrl("frmReport.aspx?rpt=ledgerbook") %>' class="tablink Hyperlink" id="report_lb">Ledger Book</a>
                            </div>
                            <div class="col-md-3">
                                <img src="Images/file.gif" alt="" class="tabLnkIcon" />
                                <a href='<%=ResolveClientUrl("frmReport.aspx?rpt=journalbook") %>' class="tablink Hyperlink" id="report_jb">Journal Book</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- #RightPane -->
    </div>
</asp:Content>
