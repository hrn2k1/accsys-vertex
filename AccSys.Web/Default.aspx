<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AccSys.Web.Default" %>

<%@ Register Assembly="AccSys.Web" Namespace="AccSys.Web.DbControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .board {
            width: calc(33.33% - 30px);
            margin: 15px;
            height: 200px;
            float: left;
        }

            .board .panel-heading {
                padding: 5px !important;
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
        <h1>Bashboard</h1>
        <div class="panel panel-success board">
            <div class="panel-heading">
                Chart of accounts
            </div>
            <div class="panel-body grid">
                <table class="datatable" style="margin-left: 0">
                    <tr class="row">
                        <th>Cash accounts</th>
                        <td>
                            <asp:Label ID="lblCash" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr class="row">
                        <th>Bank accounts</th>
                        <td>
                            <asp:Label ID="lblBank" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr class="row">
                        <th>Customer accounts</th>
                        <td>
                            <asp:Label ID="lblCustomer" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr class="row">
                        <th>Supplier accounts</th>
                        <td>
                            <asp:Label ID="lblSupplier" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr class="row">
                        <th>General accounts</th>
                        <td>
                            <asp:Label ID="lblGeneral" runat="server" Text="0"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="panel panel-success board">
            <div class="panel-heading">
                Transactions
            </div>
            <div class="panel-body grid">
                <table class="datatable" style="margin-left: 0">
                    <tr class="row">
                        <th>Credit vouchers</th>
                        <td>
                            <asp:Label ID="lblCredit" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr class="row">
                        <th>Debit vouchers</th>
                        <td>
                            <asp:Label ID="lblDebit" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr class="row">
                        <th>Journal vouchers</th>
                        <td>
                            <asp:Label ID="lblJournal" runat="server" Text="0"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="panel panel-success board">
            <div class="panel-heading">
                Recent
            </div>
            <div class="panel-body grid">
                <table class="datatable" style="margin-left: 0">
                    <tr class="row">
                        <th>Last transaction on</th>
                        <td>
                            <asp:Label ID="lblLastTransTime" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
