<%@ Page Title="" Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmUser.aspx.cs" Inherits="AccSys.Web.frmUser" %>
<%@ Register src="UserControls/CtlUsers.ascx" tagname="CtlUsers" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtlUsers ID="CtlUsers1" runat="server" />
</asp:Content>
