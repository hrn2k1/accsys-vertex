<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Accounting.Web.Default" %>
<%@ Register Assembly="Accounting.Web" Namespace="Accounting.Web.DbControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField runat="server" ID="HfCanView" />
    <asp:HiddenField runat="server" ID="HfCanAdd" />
    <asp:HiddenField runat="server" ID="HfCanEdit" />
    <asp:HiddenField runat="server" ID="HfCanDelete" />
    <div align="left">
        <br />
        <h1>Welcome to Vertex Accounting System</h1>
        <div style="padding: 50px 20px">
            The Total Accounting Solution
               <cc1:AccountDropDownListChosen ID="AccountDropDownList1" Width="200px" NullItemText="<div class='account-row'>Select an account</div>" NullItemValue="0" runat="server">
               </cc1:AccountDropDownListChosen>
            <br />
            <cc1:AccountByLedgerTypeDropDownListChosen ID="AccountDropDownList2" LedgerType="BankLedger" Width="400px" NullItemText="<div class='account-row'>Select an account</div>" NullItemValue="0" runat="server">
            </cc1:AccountByLedgerTypeDropDownListChosen>
        </div>
    </div>
</asp:Content>
