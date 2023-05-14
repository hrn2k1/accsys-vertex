<%@ Page Title="" Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmJournalVoucher.aspx.cs" Inherits="AccSys.Web.frmJournalVoucher" %>
<%@ Register Src="UserControls/CtlJournalVoucher.ascx" TagName="CtlJournalVoucher" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="HfCanView" />
    <asp:HiddenField runat="server" ID="HfCanAdd" />
    <asp:HiddenField runat="server" ID="HfCanEdit" />
    <asp:HiddenField runat="server" ID="HfCanDelete" />
    <uc1:CtlJournalVoucher ID="CtlJournalVoucher1" runat="server" VoucherId="0" />
</asp:Content>
