<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlJournalVoucher.ascx.cs" Inherits="AccSys.Web.UserControls.CtlJournalVoucher" %>
<%@ Register Assembly="AccSys.Web" Namespace="AccSys.Web.DbControls" TagPrefix="cc1" %>
<style type="text/css">
    .InputLabel {
        text-align: left;
        width: 110px !important;
        font-weight: bold !important;
    }

    .InputField {
        width: 250px !important;
        text-align: left;
    }

        .InputField input[type='text'], .InputField select {
            width: 100% !important;
        }

    .amount {
        text-align: right !important;
        max-width: 150px !important;
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
                                <label>Journal Voucher</label>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <table class="datatable">
                            <tr class="row" id="trParent" runat="server">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal4" Text="Voucher No." runat="server"></asp:Literal>
                                    <asp:Label ID="lblTransMID" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="lblModule" runat="server" Text="" Visible="False"></asp:Label>
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
                                    <asp:TextBox ID="txtDate" runat="server" ValidationGroup="post" TextMode="Date"></asp:TextBox>
                                    <ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                        ControlToValidate="txtDate" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
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
                                                            <asp:Literal ID="ltlTitle" runat="server" Text="Voucher A/C" />
                                                        </label>
                                                        <cc1:AccountDropDownListChosen ID="ddlVoucherAC" runat="server" Width="385px" NullItemText="Select an account" NullItemValue="0">
                                                        </cc1:AccountDropDownListChosen>
                                                        <asp:DropDownList ID="ddlDrCr" runat="server">
                                                            <asp:ListItem>Dr</asp:ListItem>
                                                            <asp:ListItem>Cr</asp:ListItem>
                                                        </asp:DropDownList>
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
                                                        <asp:TemplateField HeaderText="Dr Amount" SortExpression="DrAmount" ItemStyle-CssClass="amount" HeaderStyle-CssClass="amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDrAmt" runat="server" Font-Bold="True"
                                                                    Text='<%# Bind("DrAmount", "{0:0.00}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Cr Amount" SortExpression="CrAmount" ItemStyle-CssClass="amount" HeaderStyle-CssClass="amount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCrAmt" runat="server" Font-Bold="True"
                                                                    Text='<%# Bind("CrAmount", "{0:0.00}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50px">
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
                                                    <asp:Literal ID="Literal1" Text="Total Dr" runat="server"></asp:Literal></label>
                                                <asp:TextBox ID="txtTotalDrAmount" runat="server" Style="text-align: right; padding: 0 5px; margin-left: 10px; max-width: 100px"
                                                    ValidationGroup="post" ReadOnly="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="txtTotalDrAmount" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                                                <label>
                                                    <asp:Literal ID="Literal6" Text="Cr" runat="server"></asp:Literal></label>
                                                <asp:TextBox ID="txtTotalCrAmount" runat="server" Style="text-align: right; padding: 0 5px; max-width: 100px;"
                                                    ValidationGroup="post" ReadOnly="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                    ControlToValidate="txtTotalCrAmount" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
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
                                    <asp:TextBox ID="txtApprovedDate" runat="server" Width="120px" ReadOnly="True" TextMode="Date"></asp:TextBox>
                                    <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtApprovedDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
                                </td>
                                <td></td>
                            </tr>
                            <tr class="row">
                                <td class="InputLabel"></td>
                                <td colspan="4">
                                    <asp:HrnLinkButton SecurityCommandName="Add" ID="btnSave" runat="server" Text="Post" CssClass="btn btn-default glyphicon glyphicon-saved"
                                        ValidationGroup="post" OnClick="btnSave_Click" />
                                    <asp:LinkButton ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default glyphicon glyphicon-erase"
                                        CausesValidation="False" OnClick="btnReset_Click" />
                                    <asp:HrnLinkButton SecurityCommandName="Delete" ID="btnDelete" OnClientClick="if(!confirm('Do you want to delete?')) return false;" runat="server" Text="Delete" CssClass="btn btn-default glyphicon glyphicon-remove"
                                        OnClick="btnDelete_Click" />
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
