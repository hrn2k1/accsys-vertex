<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlVoucherRegister.ascx.cs" Inherits="Accounting.Web.UserControls.CtlVoucherRegister" %>
<%@ Register Assembly="Accounting.Web" Namespace="Accounting.Web.DbControls" TagPrefix="cc1" %>
<style type="text/css">
    .GridAmount {
        text-align: right !important;
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
                            
                            <cc1:AccountDropDownListChosen ID="ddlAccount" runat="server"
                                NullItemText="Select Account" NullItemValue="0" Width="300px">
                            </cc1:AccountDropDownListChosen>
                            <cc1:VoucherTypeDropDownList ID="ddlVoucherType" runat="server"
                                NullItemText="Voucher Type" NullItemValue="0">
                            </cc1:VoucherTypeDropDownList>
                            <%--<asp:DropDownList ID="ddlDrCr" runat="server">
                                <asp:ListItem Value="All"></asp:ListItem>
                                <asp:ListItem>Dr</asp:ListItem>
                                <asp:ListItem>Cr</asp:ListItem>
                            </asp:DropDownList>--%>
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
                        GridLines="None" AllowSorting="True" AutoGenerateColumns="False" OnPageIndexChanging="gvData_PageIndexChanging"
                        EmptyDataText="No Voucher Found." OnSorting="gvData_Sorting" PageSize="20"
                        Width="100%" ShowHeaderWhenEmpty="True">
                        <Columns>
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
                                <ItemStyle HorizontalAlign="Right" CssClass="GridAmount" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CreditAmt" HeaderText="Credit"
                                SortExpression="CreditAmt" DataFormatString="{0:0.00}" >
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

    </ContentTemplate>
</asp:UpdatePanel>
