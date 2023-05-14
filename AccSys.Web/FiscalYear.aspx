<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FiscalYear.aspx.cs" Inherits="AccSys.Web.FiscalYear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="grid" style="width: auto; overflow: auto">
        <div class="panel panel-success">
            <div class="panel-heading form-horizontal">
                <div class="control-group">
                    <div class="controls form-inline">
                        <label>
                            <asp:Label ID="lblFYId" runat="server" Text='0' Visible="false"></asp:Label>
                            Fiscal Year Title &nbsp;
                            <asp:TextBox ID="txtTitle" runat="server" ValidationGroup="start" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle" ErrorMessage="*" ValidationGroup="start"></asp:RequiredFieldValidator>
                             Start Date &nbsp;
                            <asp:TextBox ID="txtStartDate" runat="server" ValidationGroup="start" TextMode="Date" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStartDate" ErrorMessage="*" ValidationGroup="start"></asp:RequiredFieldValidator>
                             <asp:Label ID="lblEndDate" runat="server" Text='End Date' Visible="false"></asp:Label> &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtEndDate" runat="server" ValidationGroup="end" TextMode="Date" Visible="false" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEndDate" ErrorMessage="*" ValidationGroup="end"></asp:RequiredFieldValidator>
                            
                        </label>
                        <asp:LinkButton SecurityCommandName="Save" ID="btnStart" runat="server" Text="Start" ValidationGroup="start" CssClass="btn btn-sm btn-default glyphicon glyphicon-plus" OnClick="btnStart_Click" />
                        <asp:LinkButton SecurityCommandName="Save" ID="btnEnd" runat="server" Text="End" ValidationGroup="end" CssClass="btn btn-sm btn-default glyphicon glyphicon-stop" OnClick="btnEnd_Click" Visible="false" />
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <asp:GridView ID="gvData" runat="server" AllowPaging="True" CssClass="datatable"
                    GridLines="None" AllowSorting="True" AutoGenerateColumns="False"
                    EmptyDataText="No Data Found.">
                    <Columns>
                        <asp:TemplateField HeaderText="S/L" HeaderStyle-Width="30px">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID" SortExpression="FiscalYearID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("FiscalYearID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Title" SortExpression="Title" HeaderStyle-Width="400px">
                            <ItemTemplate>
                                <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Start Date" SortExpression="StartDate">
                            <ItemTemplate>
                                <asp:Label ID="lblStartDate" runat="server" Text='<%# Bind("StartDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="End Date" SortExpression="EndDate">
                            <ItemTemplate>
                                <asp:Label ID="lblEndDate" runat="server" Text='<%# Bind("EndDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                <asp:LinkButton ID="lbtnEnd" runat="server" OnClick="lbtnEnd_Click" CssClass="glyphicon glyphicon-stop"  CausesValidation="False" Visible='<%# Bind("Current") %>'>End</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" SortExpression="CompanyID" Visible="False" />

                        <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="50px" Visible="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click"  CausesValidation="False" SecurityCommandName="Edit" CssClass="glyphicon glyphicon-edit">Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:LinkButton SecurityCommandName="Delete" ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CausesValidation="False" CssClass="glyphicon glyphicon-remove" OnClientClick="if(!confirm('Do you want to delete?')) return false;">Delete</asp:LinkButton>
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
