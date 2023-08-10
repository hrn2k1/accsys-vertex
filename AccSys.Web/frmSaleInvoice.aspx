<%@ Page Title="" Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmSaleInvoice.aspx.cs" Inherits="AccSys.Web.frmSaleInvoice" %>

<%@ Register Assembly="AccSys.Web" Namespace="AccSys.Web.DbControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .InputLabel {
            text-align: left;
            width: 130px !important;
            font-weight: bold !important;
        }

        .InputField {
            width: 200px !important;
            text-align: left;
        }

            .InputField input[type='text'], .InputField select {
                width: 100% !important;
            }

        .amount {
            text-align: right !important;
            max-width: 150px !important;
        }

        .panel-heading input {
            height: auto !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="HfCanView" />
    <asp:HiddenField runat="server" ID="HfCanAdd" />
    <asp:HiddenField runat="server" ID="HfCanEdit" />
    <asp:HiddenField runat="server" ID="HfCanDelete" />
    <div id="form">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="grid" style="width: auto;">
                    <div class="panel panel-success">
                        <div class="panel-heading form-horizontal">
                            <div class="control-group">
                                <div class="controls form-inline">
                                    Sales Invoice
                                </div>
                            </div>
                        </div>
                        <div class="panel-body" style="padding-left: 0;">
                            <table class="datatable">
                                <tr class="row">
                                    <td class="InputLabel">Invoice Type
                                     <asp:Label ID="lblInvId" runat="server" Text="0" Visible="False"></asp:Label>
                                    </td>
                                    <td class="InputField">
                                        <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value="Direct Sale">Direct Sale</asp:ListItem>
                                            <asp:ListItem Value="Sales Order">Sales Order</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="InputLabel">Invoice Date
                                    </td>
                                    <td class="InputField">
                                        <asp:TextBox ID="txtDate" runat="server" ValidationGroup="post" TextMode="Date"></asp:TextBox>
                                        <ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDate" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr class="row">
                                    <td class="InputLabel">Invoice No.
                                    </td>
                                    <td class="InputField">
                                        <asp:TextBox ID="txtInvNo" runat="server" ValidationGroup="post"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtInvNo" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="InputLabel">Chalan No.
                                    </td>
                                    <td class="InputField">
                                        <asp:TextBox ID="txtChalanNo" runat="server" ValidationGroup="post"></asp:TextBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr class="row">
                                    <td class="InputLabel">Customer or Cash A/C
                                    </td>
                                    <td class="InputField">
                                        <cc1:AccountDropDownListChosen ID="ddlAccount" runat="server" NullItemText="Select an account" NullItemValue="0">
                                        </cc1:AccountDropDownListChosen>
                                    </td>
                                    <td class="InputLabel">Sales A/C
                                    </td>
                                    <td class="InputField">
                                        <cc1:AccountDropDownListChosen ID="ddlSalesAccount" runat="server" NullItemText="Select an account" NullItemValue="0">
                                        </cc1:AccountDropDownListChosen>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr class="row">
                                    <td class="InputLabel">Remarks
                                    </td>
                                    <td class="InputField">
                                        <asp:TextBox ID="txtRemarks" runat="server" ValidationGroup="post"></asp:TextBox>
                                        <asp:Label ID="lblTransRefId" runat="server" Text="0" Visible="False"></asp:Label>
                                        <asp:Label ID="lblStockRefId" runat="server" Text="0" Visible="False"></asp:Label>
                                    </td>
                                    <td class="InputLabel">Currency
                                    </td>
                                    <td class="InputField">
                                        <cc1:CurrencyDropDownList ID="ddlCurrency" runat="server"></cc1:CurrencyDropDownList>
                                        Rate
                                        <asp:TextBox ID="txtRate" runat="server" ValidationGroup="post" Text="1" Style="width: 60px !important; text-align: right;"></asp:TextBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr class="row">
                                    <td colspan="5">
                                        <div class="grid" style="width: auto;">
                                            <div class="panel panel-success">
                                                <div class="panel-heading form-horizontal">
                                                    <div class="control-group">
                                                        <div id="invorder" runat="server" class="controls form-inline" style="text-align: right;" visible="false">
                                                            <label style="float: left">Order</label>
                                                            <cc1:OrderDropDownListChosen ID="ddlOrder" runat="server" Type="2" Style="float: left; width: 80%;" NullItemText="Select an order" NullItemValue="0">
                                                            </cc1:OrderDropDownListChosen>
                                                            <asp:LinkButton SecurityCommandName="Add" ID="btnAddorder" runat="server" OnClick="btnAddOrder_Click" Text="Add" CssClass="btn btn-default btn-sm glyphicon glyphicon-plus-sign"
                                                                ValidationGroup="add" />
                                                        </div>
                                                        <div id="invdirect" runat="server" class="controls form-inline" style="text-align: right">
                                                            <label style="float: left">Item</label>
                                                            <cc1:ItemDropDownListChosen ID="ddlItem" runat="server" Style="float: left; width: 300px;" NullItemText="Select an item" NullItemValue="0">
                                                            </cc1:ItemDropDownListChosen>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlItem" ErrorMessage="*" ValidationGroup="add"></asp:RequiredFieldValidator>
                                                            <label>Qty</label>
                                                            <asp:TextBox ID="txtQty" runat="server" Width="100px" ValidationGroup="add"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQty" ErrorMessage="*" ValidationGroup="add"></asp:RequiredFieldValidator>
                                                            <label>Unit Price</label>
                                                            <asp:TextBox ID="txtUnitPrice" runat="server" Width="100px" ValidationGroup="add"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUnitPrice" ErrorMessage="*" ValidationGroup="add"></asp:RequiredFieldValidator>
                                                            <asp:LinkButton SecurityCommandName="Add" ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-default btn-sm glyphicon glyphicon-plus-sign"
                                                                OnClick="btnAdd_Click" ValidationGroup="add" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-body">
                                                    <asp:GridView ID="gvInvItems" runat="server" CssClass="datatable"
                                                        GridLines="None" AutoGenerateColumns="False"
                                                        Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="ID" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="OrderID" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblOrderId" runat="server" Text='<%# Bind("OrderID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="OrderNo" HeaderText="OrderNo" ItemStyle-HorizontalAlign="Left" />
                                                            <asp:TemplateField HeaderText="ItemID" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("ItemID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="ItemName" HeaderText="Item" ItemStyle-HorizontalAlign="Left" />
                                                            <asp:TemplateField HeaderText="Qty" ItemStyle-CssClass="amount" HeaderStyle-CssClass="amount">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="lblQty" runat="server" Font-Bold="True" Style="text-align: right"
                                                                        Text='<%# Bind("Qty", "{0:0.00}") %>' OnTextChanged="txtQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Unit Price" ItemStyle-CssClass="amount" HeaderStyle-CssClass="amount">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="lblUnitPrice" runat="server" Font-Bold="True" Style="text-align: right" Text='<%# Bind("UnitPrice", "{0:0.00}") %>' OnTextChanged="txtUnitPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount" ItemStyle-CssClass="amount" HeaderStyle-CssClass="amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAmount" runat="server" Font-Bold="True" Style="text-align: right"
                                                                        Text='<%# Bind("Amount", "{0:0.00}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnRemove" runat="server" OnClick="btnRemove_Click" CssClass="glyphicon glyphicon-remove" CausesValidation="False"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <asp:Label EnableViewState="false" ID="EmptyTemp" runat="server" Text="No Data Found"></asp:Label>
                                                        </EmptyDataTemplate>
                                                        <RowStyle CssClass="row" />
                                                        <HeaderStyle CssClass="row" />
                                                        <PagerStyle CssClass="pager" />
                                                    </asp:GridView>
                                                </div>
                                                <div class="panel-footer" style="padding: 5px 55px 5px 0; text-align: right;">
                                                    <div>
                                                        <label>Total Qty</label>
                                                        <asp:TextBox ID="txtTotalQty" runat="server" Style="text-align: right; padding: 0 5px; margin-left: 10px; width: 100px;" ValidationGroup="post" ReadOnly="True"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="txtTotalQty" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                                        <label>Amount</label>
                                                        <asp:TextBox ID="txtTotalAmount" runat="server" Style="text-align: right; padding: 0 5px; margin-left: 10px; width: 100px;" ValidationGroup="post" ReadOnly="True"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                            ControlToValidate="txtTotalAmount" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div>
                                                        <label>Discount</label>
                                                        <asp:TextBox ID="txtDiscount" runat="server" Style="text-align: right; padding: 0 5px; margin-left: 10px; width: 100px;" ValidationGroup="post" AutoPostBack="true" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                                                        <asp:DropDownList ID="ddlDiscountType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDiscountType_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">Fixed Value</asp:ListItem>
                                                            <asp:ListItem Value="1">Percentage</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <label>Net Amount</label>
                                                        <asp:TextBox ID="txtTransAmount" runat="server" Style="text-align: right; padding: 0 5px; margin-left: 10px; width: 100px;" ValidationGroup="post" ReadOnly="True"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                            ControlToValidate="txtTransAmount" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr class="row">
                                    <td class="InputLabel"></td>
                                    <td colspan="4">
                                        <asp:HrnLinkButton SecurityCommandName="Add" ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="btn btn-default glyphicon glyphicon-saved"
                                            ValidationGroup="post" />
                                        <asp:LinkButton ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" CssClass="btn btn-default glyphicon glyphicon-erase"
                                            CausesValidation="False" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="panel-footer" style="padding: 0;">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <%--<div id="dlg" style="z-index: 999; background-color: Blue; height: 100%; left: 0;
                opacity: 0.2; position: absolute; top: 0; width: 100%; vertical-align: middle;
                text-align: center;" align="center">
                <img alt="Please Wait..." src="Images/please_wait.gif" style="z-index: 9999; margin: 20%" />
            </div>--%>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    <div class="grid" style="width: auto; overflow: auto">
        <div class="panel panel-success">
            <div class="panel-heading form-horizontal" style="text-align: right;">
                <div class="control-group">
                    <div class="controls form-inline">
                        <label style="float: left;">
                            Invoices          
                        </label>
                         <label>
                            <asp:Literal ID="Literal1" Text="Date" runat="server"></asp:Literal>
                        </label>
                        <asp:TextBox ID="txtFromDate" runat="server" Width="140px" TextMode="Date"></asp:TextBox>
                        <ajax:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
                        <label>
                            <asp:Literal ID="Literal2" Text="-" runat="server"></asp:Literal></label>
                        <asp:TextBox ID="txtToDate" runat="server" Width="140px" TextMode="Date"></asp:TextBox>
                        <ajax:CalendarExtender ID="CalendarExtender33" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
                        
                        <asp:LinkButton SecurityCommandName="View" ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" CssClass="btn btn-sm btn-default glyphicon glyphicon-search" />
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <asp:GridView ID="gvData" runat="server" AllowPaging="True" CssClass="datatable"
                    GridLines="None" AllowSorting="True" AutoGenerateColumns="False"
                    EmptyDataText="No Data Found.">
                    <Columns>
                        <asp:TemplateField HeaderText="S/L">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HrnLinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" CausesValidation="False" SecurityCommandName="Edit" CssClass="glyphicon glyphicon-edit">Edit</asp:HrnLinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID" SortExpression="InvoiceID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("InvoiceID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date" SortExpression="InvoiceDate">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoiceDate" runat="server" Text='<%# Bind("InvoiceDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type" SortExpression="InvoiceType">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoiceType" runat="server" Text='<%# Bind("InvoiceType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="InvoiceNo" SortExpression="InvoiceNo">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%# Bind("InvoiceNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount" SortExpression="TransAmount">
                            <ItemTemplate>
                                <asp:Label ID="lblInvoiceAmount" runat="server" Text='<%# Bind("TransAmount", "{0:0.00}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" SortExpression="CompanyID" Visible="False" />
                        <asp:TemplateField HeaderText="VID" SortExpression="TransRefId" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblTransRefId" runat="server" Text='<%# Bind("TransRefId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SID" SortExpression="StockRefId" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblStockRefId" runat="server" Text='<%# Bind("StockRefId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:HrnLinkButton SecurityCommandName="Delete" ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CausesValidation="False" CssClass="glyphicon glyphicon-remove" OnClientClick="if(!confirm('Do you want to delete?')) return false;">Delete</asp:HrnLinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label EnableViewState="false" ID="EmptyTemp" runat="server" Text="No Data Found"></asp:Label>
                    </EmptyDataTemplate>
                    <RowStyle CssClass="row" />
                    <HeaderStyle CssClass="row" />
                    <PagerStyle CssClass="pager" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsCommon" runat="server" EnablePaging="True" MaximumRowsParameterName="MaximumRows"
                    OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetDataCount"
                    SelectMethod="GetData" StartRowIndexParameterName="StartRowIndex" TypeName="Accounting.DataAccess.CommonDataSource">
                    <SelectParameters>
                        <asp:Parameter Name="SelectedColumns" Type="String" />
                        <asp:Parameter Name="FromTable" Type="String" />
                        <asp:Parameter Name="Where" Type="String" />
                        <asp:Parameter Name="OrderBy" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>
