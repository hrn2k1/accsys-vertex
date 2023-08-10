<%@ Page Title="" Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmPurchaseOrder.aspx.cs" Inherits="AccSys.Web.frmPurchaseOrder" %>

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
                                    Purchase Order
                                </div>
                            </div>
                        </div>
                        <div class="panel-body" style="padding-left: 0;">
                            <table class="datatable">
                                <tr class="row">
                                    <td class="InputLabel">Supplier
                                     <asp:Label ID="lblOrderId" runat="server" Text="0" Visible="False"></asp:Label>
                                    </td>
                                    <td class="InputField">
                                        <cc1:LedgerDropDownListChosen ID="ddlSupplier" Width="200px" NullItemText="Select supplier" NullItemValue="0" LedgerType="3" runat="server">
                                        </cc1:LedgerDropDownListChosen>
                                    </td>
                                    <td class="InputLabel">Order Date
                                    </td>
                                    <td class="InputField">
                                        <asp:TextBox ID="txtDate" runat="server" ValidationGroup="post" TextMode="Date"></asp:TextBox>
                                        <ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDate" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr class="row">
                                    <td class="InputLabel">Order No.
                                    </td>
                                    <td class="InputField">
                                        <asp:TextBox ID="txtOrderNo" runat="server" ValidationGroup="post"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOrderNo" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="InputLabel">Currency
                                    </td>
                                    <td class="InputField">
                                        <cc1:CurrencyDropDownList ID="ddlCurrency" runat="server"></cc1:CurrencyDropDownList>
                                    </td>
                                    <td>
                                     Rate: <asp:TextBox ID="txtRate" runat="server" Text="1" ValidationGroup="post"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="row">
                                    <td class="InputLabel">Buyer Ref.
                                    </td>
                                    <td class="InputField" colspan="3">
                                        <asp:TextBox ID="txtBuyerref" runat="server" TextMode="MultiLine" Rows="2" Width="100%" ValidationGroup="post"></asp:TextBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr class="row">
                                    <td colspan="5">
                                        <div class="grid" style="width: auto;">
                                            <div class="panel panel-success">
                                                <div class="panel-heading form-horizontal">
                                                    <div class="control-group">
                                                        <div class="controls form-inline" style="text-align: right">
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
                                                                ValidationGroup="add" OnClick="btnAdd_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-body">
                                                    <asp:GridView ID="gvOrderItems" runat="server" CssClass="datatable"
                                                        GridLines="None" AutoGenerateColumns="False"
                                                        Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="ID" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
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
                                                    <label>Total Qty</label>
                                                    <asp:TextBox ID="txtTotalQty" runat="server" Style="text-align: right; padding: 0 5px; margin-left: 10px; width: 100px;" ValidationGroup="post" ReadOnly="True"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                        ControlToValidate="txtTotalQty" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                                    <label>Amount</label>
                                                    <asp:TextBox ID="txtTotalAmount" runat="server" Style="text-align: right; padding: 0 5px; margin-left: 10px; width: 100px;" ValidationGroup="post" ReadOnly="True"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                        ControlToValidate="txtTotalAmount" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
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
                                        <asp:LinkButton ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-default glyphicon glyphicon-erase"
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
                            Orders          
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
                        <asp:TemplateField HeaderText="ID" SortExpression="OrderID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("OrderID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SupplierId" SortExpression="SupplierID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblSupplierId" runat="server" Text='<%# Bind("SupplierID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SupplierName" HeaderText="Supplier" SortExpression="SupplierName" />
                        <asp:TemplateField HeaderText="Date" SortExpression="OrderDate">
                            <ItemTemplate>
                                <asp:Label ID="lblDate" runat="server" Text='<%# Bind("OrderDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="OrderNo" SortExpression="OrderNo">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNo" runat="server" Text='<%# Bind("OrderNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty" SortExpression="OrderQty">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderQty" runat="server" Text='<%# Bind("OrderQty", "{0:0.00}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Value" SortExpression="OrderValue">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderValue" runat="server" Text='<%# Bind("OrderValue", "{0:0.00}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" SortExpression="CompanyID" Visible="False" />
                        <asp:TemplateField HeaderText="BuyerRef" SortExpression="Buyer_ref" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblBuyerRef" runat="server" Text='<%# Bind("Buyer_ref") %>'></asp:Label>
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
