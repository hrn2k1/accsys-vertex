<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlVoucherRegister.ascx.cs" Inherits="Accounting.Web.UserControls.CtlVoucherRegister" %>
<%@ Register Assembly="Accounting.Web" Namespace="Accounting.Web.DbControls" TagPrefix="cc1" %>
<style type="text/css">
    .GridAmount {
        text-align: right !important;
    }
    .GridAmount a {
        padding-right: 6px !important;
    }
</style>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <div class="grid" style="width: auto;">
            <div class="panel panel-success" style="min-height:400px;font-size:small;font-weight:normal;">
                <div class="panel-heading form-horizontal">
                    <div class="control-group">
                        <div class="controls form-inline" style="text-align: right;">
                            <label style="float: left;">
                                <asp:Literal ID="ltlTitle" runat="server" Text="Search by" />
                            </label>
                           <%-- <asp:Literal ID="Literal3" Text="Voucher No." runat="server"></asp:Literal></label>--%>
                            <asp:TextBox ID="txtVoucherNo" runat="server" Width="100px" PlaceHolder="Voucher No."></asp:TextBox>
                            <cc1:AccountDropDownListChosen ID="ddlAccount" runat="server"
                                NullItemText="Select Account" NullItemValue="0" Width="250px">
                            </cc1:AccountDropDownListChosen>
                            <cc1:VoucherTypeDropDownList ID="ddlVoucherType" runat="server"
                                NullItemText="Voucher Type" NullItemValue="0">
                            </cc1:VoucherTypeDropDownList>
                            <label>
                                <asp:Literal ID="Literal1" Text="Date" runat="server"></asp:Literal></label>
                            <asp:TextBox ID="txtFromDate" runat="server" Width="100px"></asp:TextBox>
                            <ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
                            <label>
                                <asp:Literal ID="Literal2" Text="-" runat="server"></asp:Literal></label>
                            <asp:TextBox ID="txtToDate" runat="server" Width="100px"></asp:TextBox>
                            <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
                            <asp:LinkButton ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-sm btn-default glyphicon glyphicon-search"
                                OnClick="btnSearch_Click" />
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gvData" runat="server" AllowPaging="True" CssClass="datatable"
                        GridLines="None" AllowSorting="True" AutoGenerateColumns="False"
                        EmptyDataText="No Voucher Found." OnSorting="gvData_Sorting" PageSize="200"
                        Width="100%" ShowHeaderWhenEmpty="True" OnDataBound="gvData_DataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="S/L">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TransDate" HeaderText="Date"
                                SortExpression="TransDate" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText="Voucher No." SortExpression="VoucherNo">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="lnkVoucher" NavigateUrl='#' ToolTip='<%# Bind("TransMID") %>'  Text='<%# Bind("VoucherNo") %>' SecurityCommandName="Edit" onclick="return VoucherLinkClicked(this);"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="VoucherType" HeaderText="Voucher Type"
                                SortExpression="VoucherType" />
                             <asp:BoundField DataField="TransMID" HeaderText="VoucherID" Visible="false" />
                            <asp:BoundField DataField="AccountNo" HeaderText="Account No."
                                SortExpression="AccountNo" />
                            <asp:BoundField DataField="AccountTitle" HeaderText="Account Title"
                                SortExpression="AccountTitle" />
                            <asp:BoundField DataField="DebitAmt" DataFormatString="{0:0.00}" HeaderText="Debit"
                                SortExpression="DebitAmt">
                                <HeaderStyle HorizontalAlign="Right" CssClass="GridAmount" />
                                <ItemStyle HorizontalAlign="Right" CssClass="GridAmount" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CreditAmt" HeaderText="Credit"
                                SortExpression="CreditAmt" DataFormatString="{0:0.00}" >
                                <HeaderStyle HorizontalAlign="Right" CssClass="GridAmount" />
                                <ItemStyle HorizontalAlign="Right" CssClass="GridAmount" />
                            </asp:BoundField>
                            
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label EnableViewState="false" ID="EmptyTemp" runat="server" Text="No Voucher Found"></asp:Label>
                        </EmptyDataTemplate>
                        <RowStyle CssClass="row" />
                        <HeaderStyle CssClass="row" />
                        <PagerStyle CssClass="pager" />
                    </asp:GridView>
                   <asp:ObjectDataSource ID="odsCommon" runat="server" EnablePaging="True" MaximumRowsParameterName="MaximumRows"
                        OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetVoucherCount"
                        SelectMethod="GetVouchers" StartRowIndexParameterName="StartRowIndex" TypeName="Accounting.DataAccess.CommonDataSource">
                        <SelectParameters>
                            <asp:Parameter Name="SelectedColumns" Type="String" />
                            <asp:Parameter Name="Where" Type="String" />
                            <asp:Parameter Name="VouchersPerPage" Type="Int32" DefaultValue="10" />
                            <asp:Parameter Name="OrderBy" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
        </div>

    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
        <ProgressTemplate>
            <div id="dlg" style="z-index: 999; background-color: Blue; height: 100%; left: 0; opacity: 0.2; position: absolute; top: 0; width: 100%; vertical-align: middle; text-align: center;"
                align="center">
                <img alt="Please Wait..." src="Images/please_wait.gif" style="z-index: 9999; margin: 20%" />
            </div>
        </ProgressTemplate>
</asp:UpdateProgress>