<%@ Page Title="" Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmRequisition.aspx.cs" Inherits="AccSys.Web.frmRequisition" %>
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
    .amount{
        text-align:right !important;
        max-width:150px !important;
    }
    .panel-heading input
    {
        height: auto !important;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="form">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="grid" style="width: auto;">
                <div class="panel panel-success">
                    <div class="panel-heading form-horizontal">
                        <div class="control-group">
                            <div class="controls form-inline">
                                Requisition
                            </div>
                        </div>
                    </div>
                    <div class="panel-body" style="padding-left:0;">
                        <table class="datatable">
                            <tr class="row" id="trParent" runat="server">
                                <td class="InputLabel">
                                    Req. No.
                                     <asp:Label ID="lblReqId" runat="server" Text="0" Visible="False"></asp:Label>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtReqNo" runat="server" ValidationGroup="post"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReqNo" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                </td>
                                <td class="InputLabel">
                                    Req. Date
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtDate" runat="server" ValidationGroup="post" TextMode="Date"></asp:TextBox>
                                    <ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDate" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr class="row" runat="server" id="trLedgerNo">
                                <td class="InputLabel">
                                    Req. Section
                                </td>
                                <td class="InputField">
                                    <cc1:SectionDropDownList ID="ddlSection" NullItemText="" NullItemValue="-1" runat="server">
                                    </cc1:SectionDropDownList>
                                </td>
                                <td class="InputLabel">
                                    Req By
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtReqBy" runat="server"></asp:TextBox>
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
                                                        <label style="float:left">Item</label>
                                                         <cc1:ItemDropDownListChosen ID="ddlItem" runat="server" style="float:left;width:200px;" NullItemText="Select an item" NullItemValue="0">
                                                        </cc1:ItemDropDownListChosen>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlItem" ErrorMessage="*" ValidationGroup="add"></asp:RequiredFieldValidator>
                                                        <label>Spec</label>
                                                        <asp:TextBox ID="txtSpec" runat="server" ValidationGroup="add"></asp:TextBox>
                                                        <label>Bdl/Pk Size</label>
                                                        <asp:TextBox ID="txtSize" runat="server" ValidationGroup="add"></asp:TextBox>
                                                        <label>Qty</label>
                                                        <asp:TextBox ID="txtQty" runat="server" Width="100px" ValidationGroup="add"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQty" ErrorMessage="*" ValidationGroup="add"></asp:RequiredFieldValidator>
                                                        <asp:LinkButton SecurityCommandName="Add" ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-default btn-sm glyphicon glyphicon-plus-sign"
                                                            ValidationGroup="add" OnClick="btnAdd_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body">
                                                <asp:GridView ID="gvReqItems" runat="server" CssClass="datatable"
                                                    GridLines="None" AutoGenerateColumns="False" 
                                                    Width="100%" >
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
                                                        <asp:TemplateField HeaderText="Specifications">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSpec" runat="server" Text='<%# Bind("Spec") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bundle Size" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSize" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Qty" ItemStyle-CssClass="amount" HeaderStyle-CssClass="amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQty" runat="server" Font-Bold="True" 
                                                                    Text='<%# Bind("Qty", "{0:0.00}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnRemove" runat="server" OnClick="btnRemove_Click"  CssClass="glyphicon glyphicon-remove" CausesValidation="False"></asp:LinkButton>
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
                                                <asp:TextBox ID="txtTotalQty" runat="server" Style="text-align: right;padding:0 5px;margin-left:10px;" ValidationGroup="post" ReadOnly="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="txtTotalQty" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                </td>
                                <td></td>
                            </tr>

                            <tr class="row" style="vertical-align: top">
                                <td class="InputLabel">
                                 Description
                                </td>
                                <td class="InputField" colspan="4">
                                    <asp:TextBox ID="txtDescription" runat="server" style="width: 100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="row">
                                <td class="InputLabel"></td>
                                <td colspan="4" >
                                    <asp:LinkButton SecurityCommandName="Add" ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default glyphicon glyphicon-saved"
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
<div class="grid" style="width: auto; overflow:auto">
        <div class="panel panel-success">
            <div class="panel-heading form-horizontal" style="text-align: right;">
                <div class="control-group">
                    <div class="controls form-inline">
                        <label style="float: left;">
                              Requisitions          
                        </label>
                        <asp:LinkButton SecurityCommandName="View" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-sm btn-default glyphicon glyphicon-search" />
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <asp:GridView ID="gvData" runat="server" AllowPaging="True" CssClass="datatable"
                    GridLines="None" AllowSorting="True" AutoGenerateColumns="False" 
                    EmptyDataText="No Data Found." >
                    <Columns>
                        <asp:TemplateField HeaderText="S/L">
                            <ItemTemplate>
                                <%--<%# Container.DataItemIndex + 1 %>--%>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" CausesValidation="False" SecurityCommandName="Edit" CssClass="glyphicon glyphicon-edit">Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID" SortExpression="ReqMID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("ReqMID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date" SortExpression="ReqDate">
                            <ItemTemplate>
                                <asp:Label ID="lblReqDate" runat="server" Text='<%# Bind("ReqDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ReqNo" SortExpression="ReqNo">
                            <ItemTemplate>
                                <asp:Label ID="lblReqNo" runat="server" Text='<%# Bind("ReqNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ReqSectionID" SortExpression="ReqSectionID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblSectionId" runat="server" Text='<%# Bind("ReqSectionID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SectionName" HeaderText="Section" SortExpression="SectionName" />
                        <asp:TemplateField HeaderText="Req By" SortExpression="ReqBy">
                            <ItemTemplate>
                                <asp:Label ID="lblReqBy" runat="server" Text='<%# Bind("ReqBy") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" SortExpression="CompanyID" Visible="False" />
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton SecurityCommandName="Delete" ID="lbtnDelete" runat="server" CausesValidation="False" CssClass="glyphicon glyphicon-remove" OnClientClick="if(!confirm('Do you want to delete?')) return false;" OnClick="lbtnDelete_Click" >Delete</asp:LinkButton>
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
