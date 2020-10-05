<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlCreditVoucher.ascx.cs" Inherits="Accounting.Web.UserControls.CtlCreditVoucher" %>
<%@ Register Assembly="Accounting.Web" Namespace="Accounting.Web.DbControls" TagPrefix="cc1" %>
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
</style>
<div id="form">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="grid" style="width: auto;">
                <div class="panel panel-success">
                    <div class="panel-heading form-horizontal">
                        <div class="control-group">
                            <div class="controls form-inline">
                                <label>
                                    <asp:Literal ID="Literal2" runat="server" Text="Credit Voucher" />
                                </label>
                            </div>

                        </div>
                    </div>
                    <div class="panel-body">
                        <table class="datatable">
                            <tr class="row" id="trParent" runat="server">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal4" Text="Voucher No." runat="server"></asp:Literal>
                                    <asp:Label ID="lblTransMID" runat="server" Text="0" Visible="False"></asp:Label>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtVoucherNo" runat="server"
                                        ValidationGroup="post" ReadOnly="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                        ControlToValidate="txtVoucherNo" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal5" Text="Date" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtDate" runat="server" ValidationGroup="post"></asp:TextBox>
                                    <ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                        ControlToValidate="txtDate" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                </td>
                                <td></td>
                            </tr>
                            <tr class="row" runat="server" id="trLedgerNo">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal6" Text="Collected with" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <cc1:TransMethodDropDownList ID="ddlTransMethod" runat="server">
                                    </cc1:TransMethodDropDownList>
                                </td>
                                <td class="InputField">
                                    <asp:Literal ID="Literal7" Text="Ref No." runat="server"></asp:Literal></td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtRefNo" runat="server"></asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr class="row">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal8" Text="Collected By" runat="server"></asp:Literal></td>
                                <td class="InputField" colspan="3">
                                    <asp:TextBox ID="txtVoucherPerson" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="row">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal9" Text="Collected to A/C" runat="server"></asp:Literal></td>
                                <td class="InputField" colspan="3">
                                    <cc1:CustomAccountDropDownListChosen ID="ddlToAC" runat="server"
                                        FilterBy="(ParentID=2 OR ParentID=7)">
                                    </cc1:CustomAccountDropDownListChosen>
                                    <asp:Label ID="lblToAccTDId" runat="server" Text="0" Visible="false" />
                                </td>
                                <td></td>
                            </tr>
                            <tr class="row">
                                <td colspan="4">
                                    <div class="grid" style="width: auto;">
                                        <div class="panel panel-success">
                                            <div class="panel-heading form-horizontal">
                                                <div class="control-group">
                                                    <div class="controls form-inline" style="text-align: right;">
                                                        <label style="float: left;">
                                                            <asp:Literal ID="ltlTitle" runat="server" Text="Colleceted From A/C" />
                                                        </label>

                                                        <cc1:AccountDropDownListChosen ID="ddlFromAC" runat="server" Width="420px" NullItemText="Select an account" NullItemValue="0">
                                                        </cc1:AccountDropDownListChosen>
                                                        <asp:TextBox ID="txtAmount" runat="server" Width="100px" ValidationGroup="add"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="txtAmount" ErrorMessage="*" ValidationGroup="add"></asp:RequiredFieldValidator>
                                                        <asp:LinkButton SecurityCommandName="Add" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="btn btn-default btn-sm glyphicon glyphicon-plus-sign"
                                                            ValidationGroup="add" />

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body">
                                                <asp:GridView ID="gvData" runat="server" CssClass="datatable"
                                                    GridLines="None" AutoGenerateColumns="False" 
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="TransDID"  Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTransDID" runat="server" Text='<%# Bind("TransDID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="AccountID" SortExpression="AccountID" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAccountID" runat="server" Text='<%# Bind("AccountID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="AccountNo" HeaderText="AccountNo" ItemStyle-HorizontalAlign="Left"
                                                            SortExpression="AccountNo" />
                                                        <asp:TemplateField HeaderText="AccountTitle" SortExpression="AccountTitle" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblACTitle" runat="server" Text='<%# Bind("AccountTitle") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount" SortExpression="Amount" ItemStyle-CssClass="amount" HeaderStyle-CssClass="amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAmt" runat="server" Font-Bold="True" 
                                                                    Text='<%# Bind("Amount", "{0:0.00}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField  ItemStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnRemove" runat="server" OnClick="btnRemove_Click" CssClass="glyphicon glyphicon-remove"
                                                                    CausesValidation="False"></asp:LinkButton>
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
                                                <label>
                                                    <asp:Literal ID="Literal1" Text="Total Amount" runat="server"></asp:Literal>
                                                </label>
                                                <asp:TextBox ID="txtTotalAmount" runat="server" Style="text-align: right;padding:0 5px;margin-left:10px;"
                                                    ValidationGroup="post" ReadOnly="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="txtTotalAmount" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                </td>
                                <td></td>
                            </tr>

                            <tr class="row" style="vertical-align: top">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal10" Text="Description" runat="server"></asp:Literal></td>
                                <td class="InputField" colspan="3">
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="100%"
                                        Rows="3"></asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr class="row" style="vertical-align: top">
                                <td class="InputLabel">
                                    <asp:CheckBox ID="chkApprovedBy" runat="server" Text="Approved By"
                                        Checked="True" Enabled="False" />
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtApprovedBy" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal11" Text="Approved Date" runat="server"></asp:Literal></td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtApprovedDate" runat="server" Width="120px" ReadOnly="True"></asp:TextBox>
                                    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtApprovedDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
                                </td>
                                <td></td>
                            </tr>
                            <tr class="row">
                                <td class="InputLabel"></td>
                                <td colspan="4" >
                                    <asp:LinkButton SecurityCommandName="Add" ID="btnSave" runat="server" Text="Post" CssClass="btn btn-default glyphicon glyphicon-saved"
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
            <div id="dlg" style="z-index: 999; background-color: Blue; height: 100%; left: 0; opacity: 0.2; position: absolute; top: 0; width: 100%; vertical-align: middle; text-align: center;"
                align="center">
                <img alt="Please Wait..." src="Images/please_wait.gif" style="z-index: 9999; margin: 20%" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</div>
