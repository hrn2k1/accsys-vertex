<%@ Page Title="" Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmCreditVoucher.aspx.cs" Inherits="AccSys.Web.frmCreditVoucher" %>
<%@ Register Src="UserControls/CtlCreditVoucher.ascx" TagName="CtlCreditVoucher" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="HfCanView" />
    <asp:HiddenField runat="server" ID="HfCanAdd" />
    <asp:HiddenField runat="server" ID="HfCanEdit" />
    <asp:HiddenField runat="server" ID="HfCanDelete" />
    <uc1:CtlCreditVoucher ID="CtlCreditVoucher1" runat="server" VoucherId ="0" />
</asp:Content>
