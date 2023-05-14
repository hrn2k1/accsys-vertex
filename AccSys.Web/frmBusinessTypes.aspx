<%@ Page Title="" Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmBusinessTypes.aspx.cs" Inherits="AccSys.Web.frmBusinessTypes" %>
<%@ Register Assembly="AccSys.Web" Namespace="AccSys.Web.DbControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="grid" style="width: auto; overflow: auto">
        <div class="panel panel-success">
            <div class="panel-heading form-horizontal">
                <div class="control-group">
                    <div class="controls form-inline">
                        <label>
                            Business Type &nbsp;&nbsp;&nbsp;
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
                        <asp:TemplateField HeaderText="ID" SortExpression="BusinessTypeID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("BusinessTypeID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type" SortExpression="Name" HeaderStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
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

    <div class="grid" style="width: auto; overflow: auto">
        <div class="panel panel-success">
            <div class="panel-heading form-horizontal">
                <div class="control-group">
                    <div class="controls form-inline">
                        <label>
                            Business Subtype &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSubName" runat="server" ValidationGroup="post1" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSubName" ErrorMessage="*" ValidationGroup="post1"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>
                            <asp:Label ID="lblSubId" runat="server" Text='0' Visible="false"></asp:Label>
                        </label>
                        <asp:LinkButton SecurityCommandName="Save" ID="lbtnSubSave" runat="server" Text="Add" ValidationGroup="post1" CssClass="btn btn-sm btn-default glyphicon glyphicon-plus" OnClick="btnSubSave_Click" />
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <asp:Label ID="lblSubMsg" runat="server"></asp:Label>
                <asp:GridView ID="gvSubData" runat="server" AllowPaging="True" CssClass="datatable"
                    GridLines="None" AllowSorting="True" AutoGenerateColumns="False"
                    EmptyDataText="No Data Found.">
                    <Columns>
                        <asp:TemplateField HeaderText="S/L" HeaderStyle-Width="30px">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("RowID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TypeId" SortExpression="BusinessTypeID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblTypeId" runat="server" Text='<%# Bind("BusinessTypeID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="BusinessTypeName" HeaderText="Type" SortExpression="BusinessTypeName" HeaderStyle-Width="300px" />
                        <asp:TemplateField HeaderText="ID" SortExpression="BusinessSubTypeID" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("BusinessSubTypeID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SubType" SortExpression="Name" HeaderStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnSubEdit_Click"  CausesValidation="False" SecurityCommandName="Edit" CssClass="glyphicon glyphicon-edit">Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:LinkButton SecurityCommandName="Delete" ID="lbtnDelete" runat="server" OnClick="lbtnSubDelete_Click" CausesValidation="False" CssClass="glyphicon glyphicon-remove" OnClientClick="if(!confirm('Do you want to delete?')) return false;">Delete</asp:LinkButton>
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
                <asp:ObjectDataSource ID="odsCommonSub" runat="server" EnablePaging="True" MaximumRowsParameterName="MaximumRows"
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
