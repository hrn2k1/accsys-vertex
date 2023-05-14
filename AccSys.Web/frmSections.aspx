<%@ Page Title="" Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmSections.aspx.cs" Inherits="AccSys.Web.frmSections" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid" style="width: auto; overflow: auto">
        <div class="panel panel-success">
            <div class="panel-heading form-horizontal">
                <div class="control-group">
                    <div class="controls form-inline">
                        <label>
                            Section Name &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtName" runat="server" ValidationGroup="post" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName" ErrorMessage="*" ValidationGroup="post"></asp:RequiredFieldValidator>
                            <asp:Label ID="lblId" runat="server" Text='0' Visible="false"></asp:Label>
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
                        <asp:TemplateField HeaderText="ID" SortExpression="SectionID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("SectionID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Section" SortExpression="Name" HeaderStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CompanyID" HeaderText="CompanyID" SortExpression="CompanyID" Visible="False" />
                        <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click"  CausesValidation="False" SecurityCommandName="Edit" CssClass="glyphicon glyphicon-edit">Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:LinkButton SecurityCommandName="Delete" ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CausesValidation="False" CssClass="glyphicon glyphicon-remove" OnClientClick="if(!confirm('Do you want to delete?')) return false;">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField >
                            <ItemTemplate>
                                &nbsp;
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
