<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BalanceSheetSetup.aspx.cs" Inherits="AccSys.Web.BalanceSheetSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .input-group {
            width: 100%;
            margin: 3px 0;
        }

        .input-group-addon {
            width: 200px;
            text-align: left !important;
        }

        .companylogo {
            width: 100px !important;
            height: 100px !important;
        }

        .width-50 {
            width: 50% !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField runat="server" ID="HfCanView" />
    <asp:HiddenField runat="server" ID="HfCanAdd" />
    <asp:HiddenField runat="server" ID="HfCanEdit" />
    <asp:HiddenField runat="server" ID="HfCanDelete" />
    <div class="panel panel-success">
        <div class="panel-heading" style="padding: 5px 10px !important; font-size: 1.5em;">
            <asp:Literal ID="lInfo" Text="Balance Sheet Setup" runat="server"></asp:Literal>
        </div>
        <div class="panel-body">
            <div class="mid">
                <div class="input-group">
                    <span class="input-group-addon">
                        <asp:Literal ID="Report" Text="Report" runat="server"></asp:Literal>
                    </span>
                    <asp:DropDownList ID="ddlReport" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <asp:Literal ID="Literal1" Text="Head" runat="server"></asp:Literal>
                    </span>
                    <asp:TextBox ID="txtHead" runat="server" CssClass="form-control" />
                </div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <asp:Literal ID="Literal2" Text="Value Type" runat="server"></asp:Literal>
                    </span>
                    <asp:DropDownList ID="ddlQueryType" runat="server" CssClass="form-control">
                        <asp:ListItem Value="Scalar">Scalar</asp:ListItem>
                        <asp:ListItem Value="Table">Table</asp:ListItem>
                        <asp:ListItem Value="">None</asp:ListItem>
                    </asp:DropDownList>
                    <span class="input-group-addon">
                        <asp:Literal ID="Literal7" Text="Display Order" runat="server"></asp:Literal>
                    </span>
                    <asp:TextBox ID="txtSortOrder" runat="server" CssClass="form-control" TextMode="Number" />
                </div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <asp:Literal ID="Literal3" Text="Value Query" runat="server"></asp:Literal>
                    </span>
                    <asp:TextBox ID="txtQueryText" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
                </div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <asp:Literal ID="Literal4" Text="Accounts Filter" runat="server"></asp:Literal>
                    </span>
                    <asp:TextBox ID="txtFilter" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                </div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <asp:Literal ID="Literal5" Text="CSS Class" runat="server"></asp:Literal>
                    </span>
                    <asp:TextBox ID="txtCssClass" runat="server" CssClass="form-control" />
                </div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <asp:Literal ID="Literal6" Text="Side" runat="server"></asp:Literal>
                    </span>
                    <asp:DropDownList ID="ddlSide" runat="server" CssClass="form-control">
                        <asp:ListItem Value="L">Asset Side</asp:ListItem>
                        <asp:ListItem Value="R">Liability Side</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="btn-group" role="group">
                    <asp:Button ID="btnAdd" runat="server" CausesValidation="False"
                        CssClass="lnkbtn btn btn-primary" Text="Add" Width="120px" OnClick="btnAdd_Click" />
                     <asp:Button ID="btnReset" runat="server" CausesValidation="False"
                        CssClass="lnkbtn btn btn-default" Text="Reset" Width="120px" OnClick="btnReset_Click" />
                </div>
                <div style="float: left; width: 100%;">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="grid" style="width: auto; overflow: auto">
        <div class="panel panel-success">
            <div class="panel-body">
                <asp:GridView ID="gvData" runat="server" AllowPaging="True" CssClass="datatable"
                    GridLines="None" AllowSorting="True" AutoGenerateColumns="False"
                    EmptyDataText="No Data Found.">
                    <Columns>
                        <asp:TemplateField HeaderText="S/L">
                            <ItemTemplate>
                                <%--<%# Container.DataItemIndex + 1 %>--%>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HrnLinkButton ID="lbtnEdit" runat="server"  CausesValidation="False" SecurityCommandName="Edit" CssClass="glyphicon glyphicon-edit" OnClick="lbtnEdit_Click">Edit</asp:HrnLinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID" SortExpression="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                <asp:Label ID="lblReportId" runat="server" Text='<%# Bind("ReportId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Head" SortExpression="Head">
                            <ItemTemplate>
                                <asp:Label ID="lblHead" runat="server" Text='<%# Bind("Head") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SortOrder" SortExpression="SortOrder" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblSortOrder" runat="server" Text='<%# Bind("SortOrder") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="QueryType" SortExpression="QueryType" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblQueryType" runat="server" Text='<%# Bind("QueryType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Query Text" SortExpression="QueryText">
                            <ItemTemplate>
                                <asp:Label ID="lblQueryText" runat="server" Text='<%# Bind("QueryText") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Filter" SortExpression="Filter">
                            <ItemTemplate>
                                <asp:Label ID="lblFilter" runat="server" Text='<%# Bind("Filter") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="CssClass" SortExpression="CssClass">
                            <ItemTemplate>
                                <asp:Label ID="lblCssClass" runat="server" Text='<%# Bind("CssClass") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Side" SortExpression="Side" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblSide" runat="server" Text='<%# Bind("Side") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:HrnLinkButton SecurityCommandName="Delete" ID="lbtnDelete" runat="server" CausesValidation="False" CssClass="glyphicon glyphicon-remove" OnClientClick="if(!confirm('Do you want to delete?')) return false;" OnClick="lbtnDelete_Click" >Delete</asp:HrnLinkButton>
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
