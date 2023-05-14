<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VoucherRegister.aspx.cs" Inherits="AccSys.Web.VoucherRegister" %>
<%@ Register Src="UserControls/CtlVoucherRegister.ascx" TagName="CtlVoucherRegister" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/tab.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/tab.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField runat="server" ID="HfCanView" />
    <asp:HiddenField runat="server" ID="HfCanAdd" />
    <asp:HiddenField runat="server" ID="HfCanEdit" />
    <asp:HiddenField runat="server" ID="HfCanDelete" />

    <div style="float: right; width: 100%">
        <div id="RightPane" class="ui-layout-center ui-helper-reset ui-widget-content" style="top: 100px">
            <!-- Tabs pane -->
            <div id="tabs" class="jqgtabs">
                <ul>
                    <li>
                        <a href="#tabs-1">
                            <asp:Literal ID="SetupMainTab" runat="server" Text="Voucher Register"></asp:Literal>
                        </a>
                    </li>
                </ul>
                <div id="tabs-1" style="font-size: 1em; font-weight: bold; height: 100%; width: 100%;">
                    <uc1:CtlVoucherRegister ID="CtlVoucherRegister1" runat="server" />
                </div>
            </div>
        </div>
        <!-- #RightPane -->
    </div>

</asp:Content>
