<%@ Page Title="" Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmStockInOut.aspx.cs" Inherits="AccSys.Web.frmStockInOut" %>

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
                                    Stock In Out
                                </div>
                            </div>
                        </div>
                        <div class="panel-body" style="padding-left: 0;">
                            <table class="datatable">
                                <tr class="row">
                                    <td class="InputLabel">Trans Type
                                     <asp:Label ID="lblStockId" runat="server" Text="0" Visible="False"></asp:Label>
                                    </td>
                                    <td class="InputField">
                                        <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                            <asp:ListItem Value="Store In For Customer">Store In For Customer</asp:ListItem>
                                            <asp:ListItem Value="Store Out Via Requisition">Store Out Via Requisition</asp:ListItem>
                                            <asp:ListItem Value="Store Out For Customer">Store Out For Customer</asp:ListItem>
                                            <asp:ListItem Value="Damage">Damage</asp:ListItem>
                                            <asp:ListItem Value="Store In For Supplier">Store In For Supplier</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="InputLabel">
                                        <asp:Label ID="lblCustSupp" runat="server" Text="Customer"></asp:Label>
                                    </td>
                                    <td class="InputField">

                                        <asp:TextBox ID="txtCustSupp" runat="server" ValidationGroup="post" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCustSuppId" runat="server" Text="0" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="row">
                                    <td class="InputLabel">Date
                                    </td>
                                    <td class="InputField">
                                        <asp:TextBox ID="txtDate" runat="server" ValidationGroup="post" TextMode="Date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDate" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="InputLabel">Voucher No.
                                    </td>
                                    <td class="InputField">
                                        <asp:TextBox ID="txtVoucherNo" runat="server" ValidationGroup="post"></asp:TextBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr class="row">
                                    <td class="InputLabel">Chalan Date
                                    </td>
                                    <td class="InputField">
                                        <asp:TextBox ID="txtChalanDate" runat="server" ValidationGroup="post" TextMode="Date"></asp:TextBox>
                                    </td>
                                    <td class="InputLabel">Chalan No.
                                    </td>
                                    <td class="InputField">
                                        <asp:TextBox ID="txtChalanNo" runat="server" ValidationGroup="post"></asp:TextBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr class="row">
                                    <td class="InputLabel">Remarks
                                    </td>
                                    <td class="InputField" colspan="3">
                                        <asp:TextBox ID="txtRemarks" runat="server" ValidationGroup="post"></asp:TextBox>
                                        <asp:Label ID="lblTransRefId" runat="server" Text="0" Visible="False"></asp:Label>
                                        <asp:Label ID="lblRefId" runat="server" Text="0" Visible="False"></asp:Label>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr class="row">
                                    <td colspan="5">
                                        <div class="grid" style="width: auto;">
                                            <div class="panel panel-success">
                                                <div class="panel-heading form-horizontal">
                                                    <div class="control-group">
                                                        <div id="inoutOrder" runat="server" class="controls form-inline" style="text-align: right;">
                                                            <label style="float: left">Order</label>
                                                            <cc1:OrderDropDownListChosen ID="ddlOrder" runat="server" Type="2" Style="float: left; width: 80%;" NullItemText="Select an order" NullItemValue="0">
                                                            </cc1:OrderDropDownListChosen>
                                                            <asp:LinkButton SecurityCommandName="Add" ID="btnAddorder" runat="server" Text="Add" CssClass="btn btn-default btn-sm glyphicon glyphicon-plus-sign"
                                                                ValidationGroup="add" OnClick="btnAddOrder_Click" />
                                                        </div>
                                                        <div id="inoutReq" runat="server" class="controls form-inline" style="text-align: right;" visible="false">
                                                            <label style="float: left">Requisition</label>
                                                            <cc1:RequisitionDropDownList ID="ddlReq" runat="server" Style="float: left; width: 80%;" NullItemText="Select a requisition" NullItemValue="0">
                                                            </cc1:RequisitionDropDownList>
                                                            <asp:LinkButton SecurityCommandName="Add" ID="btnAddReq" runat="server" Text="Add" CssClass="btn btn-default btn-sm glyphicon glyphicon-plus-sign"
                                                                ValidationGroup="add" OnClick="btnAddReq_Click" />
                                                        </div>
                                                        <div id="inoutItem" runat="server" class="controls form-inline" style="text-align: right" visible="false">
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
                                                            <asp:LinkButton SecurityCommandName="Add" ID="btnAddItem" runat="server" Text="Add" CssClass="btn btn-default btn-sm glyphicon glyphicon-plus-sign"
                                                                ValidationGroup="add" OnClick="btnAddItem_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-body">
                                                    <asp:GridView ID="gvInOutItems" runat="server" CssClass="datatable"
                                                        GridLines="None" AutoGenerateColumns="False"
                                                        Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="ID" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRefId" runat="server" Text='<%# Bind("RefID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="RefNo" HeaderText="RefNo" ItemStyle-HorizontalAlign="Left" />
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
                                                                    <asp:LinkButton ID="btnRemove" runat="server" CssClass="glyphicon glyphicon-remove" CausesValidation="False" OnClick="btnRemove_Click"></asp:LinkButton>
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
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr class="row">
                                    <td class="InputLabel"></td>
                                    <td colspan="4">
                                        <asp:HrnLinkButton SecurityCommandName="Add" ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default glyphicon glyphicon-saved"
                                            ValidationGroup="post" OnClick="btnSave_Click" />
                                        <asp:LinkButton ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default glyphicon glyphicon-erase"
                                            CausesValidation="False" OnClick="btnReset_Click" />
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
                            Stocks          
                        </label>
                        <label>
                            <asp:Literal ID="Literal3" Text="Invoice No." runat="server"></asp:Literal>
                        </label>
                        <asp:TextBox ID="txtSrcVoucherNo" runat="server"></asp:TextBox>
                        <label>
                            <asp:Literal ID="Literal4" Text="Type" runat="server"></asp:Literal>
                        </label>
                        <asp:DropDownList ID="ddlSrcType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                             <asp:ListItem Value="">All</asp:ListItem>
                            <asp:ListItem Value="Store In For Customer">Store In For Customer</asp:ListItem>
                            <asp:ListItem Value="Store Out Via Requisition">Store Out Via Requisition</asp:ListItem>
                            <asp:ListItem Value="Store Out For Customer">Store Out For Customer</asp:ListItem>
                            <asp:ListItem Value="Damage">Damage</asp:ListItem>
                            <asp:ListItem Value="Store In For Supplier">Store In For Supplier</asp:ListItem>
                        </asp:DropDownList>
                        <label>
                            <asp:Literal ID="Literal1" Text="Date" runat="server"></asp:Literal>
                        </label>
                        <asp:TextBox ID="txtFromDate" runat="server" Width="140px" TextMode="Date"></asp:TextBox>
                        <ajax:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
                        <label>
                            <asp:Literal ID="Literal2" Text="-" runat="server"></asp:Literal></label>
                        <asp:TextBox ID="txtToDate" runat="server" Width="140px" TextMode="Date"></asp:TextBox>
                        <ajax:CalendarExtender ID="CalendarExtender33" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>

                        <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" CssClass="btn btn-sm btn-default glyphicon glyphicon-search" />
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
                                <asp:HrnLinkButton ID="lbtnEdit" runat="server" CausesValidation="False" SecurityCommandName="Edit" CssClass="glyphicon glyphicon-edit" OnClick="lbtnEdit_Click">Edit</asp:HrnLinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID" SortExpression="StockMID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("StockMID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date" SortExpression="TransDate">
                            <ItemTemplate>
                                <asp:Label ID="lblTransDate" runat="server" Text='<%# Bind("TransDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TransType" HeaderText="Trans Type" SortExpression="TransType" />
                        <asp:BoundField DataField="VoucherNo" HeaderText="Voucher No." SortExpression="VoucherNo" />
                        <asp:BoundField DataField="ChalanNo" HeaderText="Chalan No." SortExpression="ChalanNo" />
                        <asp:TemplateField HeaderText="Chalan Date" SortExpression="ChalanDate">
                            <ItemTemplate>
                                <asp:Label ID="lblChalanDate" runat="server" Text='<%# Bind("ChalanDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RefId" SortExpression="RefID">
                            <ItemTemplate>
                                <asp:Label ID="lblRefId" runat="server" Text='<%# Bind("RefID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Module" SortExpression="Module">
                            <ItemTemplate>
                                <asp:Label ID="lblModule" runat="server" Text='<%# Bind("Module") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" SortExpression="CompanyID" Visible="False" />
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
