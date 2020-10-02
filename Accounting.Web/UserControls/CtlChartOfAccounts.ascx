<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlChartOfAccounts.ascx.cs" Inherits="Accounting.Web.UserControls.CtlChartOfAccounts" %>
<%@ Register Assembly="Accounting.Web" Namespace="Accounting.Web.DbControls" TagPrefix="cc1" %>
<style type="text/css">
    .InputLabel {
        text-align: left;
        width:130px !important;
        font-weight:bold !important;
    }

    .InputField {
        width: 200px  !important;
        text-align: left;
    }
    .InputField input[type='text'],.InputField select{
        width:100% !important;
    }
    .ui-widget input, .ui-widget select {
        font-family: inherit !important;
    }
</style>
<style type="text/css">
    .rotate {
        /* for Safari */
        -webkit-transform: rotate(-90deg); /* for Firefox */
        -moz-transform: rotate(-90deg); /* for Internet Explorer */
        filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
    }

    ul a {
        color: #371C1C;
        display: block;
        font-size: 12px;
        line-height: 10px;
        padding-left: 0;
        padding-right: 5px;
        text-decoration: none;
    }

    .ui-widget-content {
        border: none;
    }

    .ui-widget-header {
        background: none;
        border: none;
    }
</style>
<script type="text/javascript">
    $(document).ready(function () {

        var maintab = $('#tabs').tabs();
    });
</script>
<div id="form">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="grid" style="width: auto;">
                <div class="panel panel-success">
                    <div class="panel-heading form-horizontal">
                        <div class="control-group">
                            <div class="controls form-inline">
                                <label>
                                    <asp:Literal ID="Literal2" runat="server" Text="Chart of Accounts" />
                                </label>
                            </div>

                        </div>
                    </div>
                    <div class="panel-body">
                        <div>
                            <asp:Label ID="lblPanel1Msg" runat="server"></asp:Label>
                        </div>
                        <table class="datatable">
                            <tr class="row">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal3" Text="Ledger Title" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtLedgerTitle" runat="server"  ValidationGroup="AccSave"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLedgerTitle"
                                        ErrorMessage="*" ValidationGroup="AccSave"></asp:RequiredFieldValidator>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal4" Text="Ledger Type" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <cc1:LedgerTypeDropDownList ID="ddlLedgerType" runat="server" >
                                    </cc1:LedgerTypeDropDownList>
                                </td>
                                <td> </td>
                            </tr>
                            <tr class="row">
                                <td colspan="5">
                                    <asp:CheckBox ID="chkAccount" runat="server" Text="Effect to Chart of Account" AutoPostBack="True"
                                        Checked="True" OnCheckedChanged="chkAccount_CheckedChanged"  />
                                    <asp:Label ID="lblAccountID" runat="server" Text="0" Visible="False"></asp:Label>
                                </td>

                            </tr>
                            <tr class="row" runat="server" id="trParent">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal5" Text="Parent Account" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <cc1:ParentAccountDropDownListChosen ID="ddlParent" runat="server"  AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlParent_SelectedIndexChanged"
                                        NullItemText="Select parent" NullItemValue="0">
                                    </cc1:ParentAccountDropDownListChosen>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal6" Text="Category" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:DropDownList ID="ddlACType" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlACType_SelectedIndexChanged">
                                        <asp:ListItem Value="Account">Account</asp:ListItem>
                                        <asp:ListItem Value="Group">Account Group</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                 <td> </td>
                            </tr>
                            <tr class="row" runat="server" id="trLedgerNo">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal7" Text="Ledger No." runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtLedgerNo" runat="server" 
                                        ValidationGroup="AccSave" ReadOnly="True"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLedgerNo"
                                        ErrorMessage="*" ValidationGroup="AccSave"></asp:RequiredFieldValidator>
                                </td>
                                <td colspan="3">
                                    <asp:CheckBox ID="chkInventory" runat="server" Text="Inventory Related?"  />
                                </td>
                            </tr>
                            <tr class="row" runat="server" id="trBalance">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal8" Text="Opening Balance" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtOpBal" runat="server"  ValidationGroup="AccSave"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOpBal"
                                        ErrorMessage="*" ValidationGroup="AccSave"></asp:RequiredFieldValidator>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal9" Text="Current Balance" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtCurBal" runat="server"  ReadOnly="True"></asp:TextBox>
                                </td>
                                 <td> </td>
                            </tr>
                            <tr class="row">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal10" Text="Status" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="120px">
                                        <asp:ListItem>Active</asp:ListItem>
                                        <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                                        <asp:ListItem>Suspend</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;
                                </td>
                                <td class="InputField">&nbsp;
                                </td>
                                 <td> </td>
                            </tr>
                            <tr class="row">
                                <td colspan="5">
                                    <asp:CheckBox ID="chkLedger" runat="server" Text="Detail Information" AutoPostBack="True"
                                        Checked="True" OnCheckedChanged="chkLedger_CheckedChanged"  />
                                    <asp:Label ID="lblLedgerID" runat="server" Text="0" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr class="row" runat="server" id="trDtl1">
                                <td class="InputLabel">
                                    <asp:Literal ID="Label1" runat="server" Text="Contact Person"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtContact" runat="server" ></asp:TextBox>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal11" Text="Bank A/C Type" runat="server"></asp:Literal>
                                </td>
                                <td  class="InputField">
                                    <asp:TextBox ID="txtBankACType" runat="server" ></asp:TextBox>
                                </td>
                                 <td> </td>
                            </tr>
                            <tr class="row" runat="server" id="trDtl2">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal12" Text="Address" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtAddress" runat="server" ></asp:TextBox>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal13" Text="Phone" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtPhone" runat="server" ></asp:TextBox>
                                </td>
                                 <td> </td>
                            </tr>
                            <tr class="row" runat="server" id="trDtl3">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal14" Text="Fax" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtFax" runat="server" ></asp:TextBox>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal15" Text="Email" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox>
                                </td>
                                 <td> </td>
                            </tr>
                            <tr class="row" runat="server" id="trDtl4">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal16" Text="Country" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <cc1:CountryDropDownList ID="ddlCountry" runat="server">
                                    </cc1:CountryDropDownList>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal17" Text="Currency" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <cc1:CurrencyDropDownList ID="ddlCurrency" runat="server">
                                    </cc1:CurrencyDropDownList>
                                </td>
                                 <td> </td>
                            </tr>
                            <tr class="row" runat="server" id="trDtl5">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal18" Text="Bussiness Type" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtBusinessType" runat="server" ></asp:TextBox>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal19" Text="Remarks" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtRemarks" runat="server" ></asp:TextBox>
                                </td>
                                 <td> </td>
                            </tr>
                            <tr class="row">
                                 <td class="InputLabel"> </td>
                                <td colspan="4" align="left">
                                    <asp:LinkButton ID="btnSave" runat="server" Text="Save" SecurityCommandName="Add" CssClass="btn btn-default glyphicon glyphicon-saved"
                                        ValidationGroup="AccSave1" OnClick="btnSave_Click" />
                                    <asp:LinkButton ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-default glyphicon glyphicon-erase"
                                        CausesValidation="False" OnClick="btnReset_Click" />
                                </td>
                            </tr>
                        </table>


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
<div>
  <asp:Label ID="lblMsg" runat="server"></asp:Label>
</div>
<div id="tabs">
    <ul>
        <li><a href="#tabs-1">
            <asp:Literal ID="Literal20" Text="Account Grid" runat="server"></asp:Literal></a></li>
        <li><a href="#tabs-2">
            <asp:Literal ID="Literal21" Text="Account Tree" runat="server"></asp:Literal></a></li>
    </ul>
    <div id="tabs-1" style="padding: 5px 2px;" >
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="grid" style="width: auto;overflow:auto">
                    <div class="panel panel-success">
                        <div class="panel-heading form-horizontal" style="text-align: right;">
                            <div class="control-group">
                                <div class="controls form-inline">
                                    <label style="float: left;">
                                        <asp:Literal ID="ltlTitle" runat="server" Text="Search by" />
                                    </label>
                                    <asp:DropDownList ID="ddlLedgerAccount" runat="server" Visible="False" CssClass="input-small">
                                        <asp:ListItem>Account</asp:ListItem>
                                        <asp:ListItem>Ledger</asp:ListItem>
                                    </asp:DropDownList>
                                    <cc1:ParentAccountDropDownListChosen ID="ddlSrcParent" runat="server" Width="300px" CssClass="input-small"
                                        NullItemText="Parent" NullItemValue="0">
                                    </cc1:ParentAccountDropDownListChosen>
                                    <cc1:LedgerTypeDropDownList ID="ddlSrcLedgerType" runat="server" NullItemText="Ledger Type" CssClass="input-small"
                                        NullItemValue="0">
                                    </cc1:LedgerTypeDropDownList>
                                    <asp:DropDownList ID="ddlAccGroup" runat="server" CssClass="input-small">
                                        <asp:ListItem Value="All">Account / Group</asp:ListItem>
                                        <asp:ListItem>Account</asp:ListItem>
                                        <asp:ListItem>Group</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:LinkButton SecurityCommandName="View" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-sm btn-default glyphicon glyphicon-search" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="gvData" runat="server" AllowPaging="True" CssClass="datatable"
                                GridLines="None" AllowSorting="True" AutoGenerateColumns="False" OnPageIndexChanging="gvData_PageIndexChanging"
                                EmptyDataText="No Account Found." OnSorting="gvData_Sorting" PageSize="20">
                                <Columns>
                                    <asp:TemplateField HeaderText="S/L">
                                        <ItemTemplate>
                                            <%--<%# Container.DataItemIndex + 1 %>--%>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">

                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnEdit" runat="server" CausesValidation="False" SecurityCommandName="Edit" CssClass="glyphicon glyphicon-edit"
                                                OnClick="lbtnEdit_Click">Edit</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AccountID" SortExpression="AccountID" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAccountID" runat="server" Text='<%# Bind("AccountID") %>'></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AccountNo" HeaderText="AccountNo" SortExpression="Account.AccountNo" />
                                    <asp:BoundField DataField="AccountTitle" HeaderText="AccountTitle" SortExpression="Account.AccountTitle" />
                                    <asp:BoundField DataField="LedgerType" HeaderText="LedgerType" SortExpression="LedgerType" />
                                    <asp:BoundField DataField="ParentACNo" HeaderText="ParentACNo" SortExpression="ParentACNo" />
                                    <asp:BoundField DataField="ParentACTitle" HeaderText="ParentACTitle" SortExpression="ParentACTitle" />
                                    <asp:BoundField DataField="OpeningBalance" DataFormatString="{0:0.00}" HeaderText="OpeningBalance"
                                        SortExpression="Account.OpeningBalance" />
                                    <asp:BoundField DataField="CurrentBalance" DataFormatString="{0:0.00}" HeaderText="CurrentBalance"
                                        SortExpression="Account.CurrentBalance" />
                                    <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" SortExpression="CompanyID"
                                        Visible="False" />
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton SecurityCommandName="Delete" ID="lbtnDelete" runat="server" CausesValidation="False" CssClass="glyphicon glyphicon-remove">Delete</asp:LinkButton>
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

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="tabs-2" style="padding: 5px 2px;" >
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="grid" style="width: auto;">
                    <div class="panel panel-success">
                        <div class="panel-heading form-horizontal">
                            <div class="control-group">
                                <div class="controls form-inline">
                                    <label>
                                        <asp:Literal ID="Literal1" runat="server" Text="Chart of Accounts" />
                                    </label>
                                </div>

                            </div>
                        </div>
                        <div class="panel-body">
                             <div>
                            <asp:LinkButton ID="lbtnExpandAll" runat="server" CausesValidation="False" OnClick="lbtnExpandAll_Click" >
                                <span aria-hidden="true" class="glyphicon glyphicon-collapse-down"></span>
                                <asp:Literal ID="Literal22" Text="Expand All" runat="server"></asp:Literal>
                                </asp:LinkButton>
                            &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbtnCollapAll" runat="server" CausesValidation="False" OnClick="lbtnCollapAll_Click"  >
                                        <span aria-hidden="true" class="glyphicon glyphicon-collapse-up"></span>
                                        <asp:Literal ID="Literal23" Text="Collapse All" runat="server"></asp:Literal>

                                    </asp:LinkButton>
                            &nbsp;&nbsp;
                                    <asp:LinkButton ID="lbtnRefresh" runat="server" CausesValidation="False" OnClick="lbtnRefresh_Click" >
                                        <span aria-hidden="true" class="glyphicon glyphicon-refresh"></span>
                                        <asp:Literal ID="Literal24" Text="Refresh" runat="server"></asp:Literal>

                                    </asp:LinkButton>
                        </div>
                        <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                            <ParentNodeStyle Font-Bold="False" />
                            <RootNodeStyle Font-Bold="False" />
                        </asp:TreeView>
                        </div>
                    </div>
                </div>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>