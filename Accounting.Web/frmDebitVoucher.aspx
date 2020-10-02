<%@ Page Title="" Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmDebitVoucher.aspx.cs" Inherits="Accounting.Web.frmDebitVoucher" %>
<%@ Register Src="UserControls/CtlDebitVoucher.ascx" TagName="CtlDebitVoucher" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:HiddenField runat="server" ID="HfCanView" />
    <asp:HiddenField runat="server" ID="HfCanAdd" />
    <asp:HiddenField runat="server" ID="HfCanEdit" />
    <asp:HiddenField runat="server" ID="HfCanDelete" />
    <uc1:CtlDebitVoucher ID="CtlDebitVoucher1" runat="server" />
</asp:Content>
