<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlChartOfItems.ascx.cs" Inherits="AccSys.Web.UserControls.CtlChartOfItems" %>
<%@ Register Assembly="AccSys.Web" Namespace="AccSys.Web.DbControls" TagPrefix="cc1" %>
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
                                <label>Chart of Items</label>
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
                                    <asp:Literal ID="Literal3" Text="Name" runat="server"></asp:Literal>
                                    <asp:Label ID="lblId" runat="server" Text="0" Visible="False"></asp:Label>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtName" runat="server"  ValidationGroup="AccSave"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                        ErrorMessage="*" ValidationGroup="AccSave"></asp:RequiredFieldValidator>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal4" Text="Type" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:DropDownList ID="ddlType" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" >
                                        <asp:ListItem Value="Item">Item</asp:ListItem>
                                        <asp:ListItem Value="Group">Item Group</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td> </td>
                            </tr>
                            <tr class="row" >
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal5" Text="Parent Group" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <cc1:ItemGroupDropDownListChosen ID="ddlParent" runat="server"
                                        NullItemText="Select parent" NullItemValue="0">
                                    </cc1:ItemGroupDropDownListChosen>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal6" Text="Category" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:DropDownList ID="ddlCategory" runat="server" >
                                        <asp:ListItem>Finished Good</asp:ListItem>
                                        <asp:ListItem>Raw Material</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                 <td> </td>
                            </tr>
                            <tr class="row" runat="server" id="trItemRow1">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal7" Text="Item Code" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtItemCode" runat="server" ValidationGroup="AccSave"></asp:TextBox>
                                </td>
                                 <td class="InputLabel">
                                    <asp:Literal ID="Literal25" Text="HS Code" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtHSCode" runat="server" ValidationGroup="AccSave"></asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr class="row" runat="server" id="trItemRow2">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal26" Text="Unit" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <cc1:UnitDropDownList ID="ddlUnit" runat="server" >
                                    </cc1:UnitDropDownList>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal8" Text="Unit price" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtUnitPrice" runat="server"  ValidationGroup="AccSave"></asp:TextBox>
                                </td>
                                <td> </td>
                            </tr>
                            <tr class="row" runat="server" id="trItemRow3">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal9" Text="Opening Qty" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtOpeningQty" runat="server"  ValidationGroup="AccSave"></asp:TextBox>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal27" Text="Opening Value" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtOpeningValue" runat="server"  ValidationGroup="AccSave"></asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                             <tr class="row" runat="server" id="trItemRow4">
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal28" Text="Min Qty" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtMinQty" runat="server"  ValidationGroup="AccSave"></asp:TextBox>
                                </td>
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal29" Text="Current Qty" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtCurrentQty" runat="server"  ValidationGroup="AccSave"></asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr class="row" runat="server" id="trItemRow5">
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
                                <td class="InputLabel">
                                    <asp:Literal ID="Literal30" Text="Purpose" runat="server"></asp:Literal>
                                </td>
                                <td class="InputField">
                                    <asp:TextBox ID="txtPurpose" runat="server"  ValidationGroup="AccSave"></asp:TextBox>
                                </td>
                                 <td> </td>
                            </tr>
                            <tr class="row">
                                 <td class="InputLabel"> </td>
                                <td colspan="4" align="left">
                                    <asp:LinkButton ID="btnSave" runat="server" Text="Save" SecurityCommandName="Add" CssClass="btn btn-default glyphicon glyphicon-saved"
                                        ValidationGroup="AccSave" OnClick="btnSave_Click"  />
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
        <li><a href="#tabs-1">Chart of Items</a></li>
        <li><a href="#tabs-2">Item Tree</a></li>
    </ul>
    <div id="tabs-1" style="padding: 5px 2px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="grid" style="width: auto; overflow:auto">
                    <div class="panel panel-success">
                        <div class="panel-heading form-horizontal" style="text-align: right;">
                            <div class="control-group">
                                <div class="controls form-inline">
                                    <label style="float: left;">
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
                                            <asp:LinkButton ID="lbtnEdit" runat="server" CausesValidation="False" SecurityCommandName="Edit" CssClass="glyphicon glyphicon-edit"
                                              OnClick="lbtnEdit_Click" >Edit</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" SortExpression="Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                    <asp:BoundField DataField="ParentName" HeaderText="Parent Group" SortExpression="ParentName" />
                                    <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" SortExpression="CompanyID" Visible="False" />
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton SecurityCommandName="Delete" ID="lbtnDelete" runat="server" CausesValidation="False" CssClass="glyphicon glyphicon-remove" OnClick="lbtnDelete_Click" OnClientClick="if(!confirm('Do you want to delete?')) return false;" >Delete</asp:LinkButton>
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
                                        <asp:Literal ID="Literal1" runat="server" Text="Chart of Items" />
                                    </label>
                                </div>

                            </div>
                        </div>
                        <div class="panel-body">
                             <div>
                            <asp:LinkButton ID="lbtnExpandAll" runat="server" CausesValidation="False" OnClick="lbtnExpandAll_Click"  >
                                <span aria-hidden="true" class="glyphicon glyphicon-collapse-down"></span>
                                <asp:Literal ID="Literal22" Text="Expand All" runat="server"></asp:Literal>
                             </asp:LinkButton>
                                     &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbtnCollapAll" runat="server" CausesValidation="False" OnClick="lbtnCollapAll_Click"  >
                                        <span aria-hidden="true" class="glyphicon glyphicon-collapse-up"></span>
                                        <asp:Literal ID="Literal23" Text="Collapse All" runat="server"></asp:Literal>
                                    </asp:LinkButton>
                                   &nbsp;&nbsp;
                                    <asp:LinkButton ID="lbtnRefresh" runat="server" CausesValidation="False" OnClick="lbtnRefresh_Click"  >
                                        <span aria-hidden="true" class="glyphicon glyphicon-refresh"></span>
                                        <asp:Literal ID="Literal24" Text="Refresh" runat="server"></asp:Literal>
                                    </asp:LinkButton>
                        </div>
                        <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" >
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