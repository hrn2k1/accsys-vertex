<%@ Page Title="" Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmCompanies.aspx.cs" Inherits="AccSys.Web.frmCompanies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid" style="width: auto; overflow: auto">
        <div class="panel panel-success">
            <div class="panel-heading form-horizontal">
                <div class="control-group">
                    <div class="controls form-inline">
                        <label>
                            Company Name &nbsp;&nbsp;
                            <asp:TextBox ID="txtName" runat="server" ValidationGroup="post" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                        </label>
                        <asp:LinkButton SecurityCommandName="Save" ID="btnSave" runat="server" Text="Add" ValidationGroup="post" CssClass="btn btn-sm btn-default glyphicon glyphicon-plus" OnClick="btnSave_Click" />
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
                        <asp:TemplateField HeaderText="Id" SortExpression="CompanyID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("CompanyID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" SortExpression="CompanyName" HeaderStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phone" SortExpression="Phone" HeaderStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" SortExpression="Email" HeaderStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
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
