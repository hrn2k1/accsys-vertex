<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AccSys.Web.Default" %>
<%@ Register Assembly="AccSys.Web" Namespace="AccSys.Web.DbControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .ex-label {
            width: 90px;
            display: inline-block;
            margin-bottom: 10px;
        }
    </style>
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
            <fieldset>
                <legend>Example</legend>
            <span class="ex-label" >Account:</span><cc1:AccountDropDownListChosen ID="AccountDropDownList1" Width="200px" NullItemText="<div class='account-row'>Select an account</div>" NullItemValue="0" runat="server">
               </cc1:AccountDropDownListChosen>
            <br />
            <span class="ex-label" >Bank Account:</span><cc1:AccountByLedgerTypeDropDownListChosen ID="AccountDropDownList2" LedgerType="BankLedger" Width="200px" NullItemText="<div class='account-row'>Select an account</div>" NullItemValue="0" runat="server">
            </cc1:AccountByLedgerTypeDropDownListChosen>
            <br />
            <span class="ex-label" >Item:</span><cc1:ItemDropDownListChosen ID="ItemDropDownListChosen1" Width="200px" NullItemText="Select an item" NullItemValue="0" runat="server">
               </cc1:ItemDropDownListChosen>
                <br />
            <span class="ex-label" >Ledger:</span><cc1:LedgerDropDownListChosen ID="LedgerDropDownListChosen1" Width="200px" NullItemText="Select a ledger" NullItemValue="0" runat="server">
               </cc1:LedgerDropDownListChosen>
            </fieldset>
        </div>
    </div>
</asp:Content>
