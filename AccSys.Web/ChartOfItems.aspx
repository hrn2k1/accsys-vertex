<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChartOfItems.aspx.cs" Inherits="AccSys.Web.ChartOfItems" %>
<%@ Register Src="UserControls/CtlChartOfItems.ascx" TagName="CtlChartOfItems" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField runat="server" ID="HfCanView" />
    <asp:HiddenField runat="server" ID="HfCanAdd" />
    <asp:HiddenField runat="server" ID="HfCanEdit" />
    <asp:HiddenField runat="server" ID="HfCanDelete" />
    <uc1:CtlChartOfItems ID="CtlChartOfItems1" runat="server" />
</asp:Content>