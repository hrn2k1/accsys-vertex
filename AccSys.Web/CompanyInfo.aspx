<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanyInfo.aspx.cs" Inherits="AccSys.Web.CompanyInfo" %>
<%@ Register Assembly="AccSys.Web" Namespace="AccSys.Web.DbControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .input-group {
            width: 100%;
            margin: 3px 0;
        }

        .input-group-addon {
            width: 120px;
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
            <asp:Literal ID="lInfo" Text="Company Information" runat="server" ></asp:Literal>
        </div>
        <div class="panel-body">
            <div class="mid">

                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="CompanyID" DataSourceID="dsCompany" Width="80%">
                    <EditItemTemplate>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="InstituteName" Text="Institute Name" runat="server" ></asp:Literal>
                            </span>
                            <asp:TextBox ID="CompanyNameTextBox" runat="server" CssClass="form-control" Text='<%# Bind("CompanyName") %>' />
                            <asp:Label ID="CompanyIDLabel1" runat="server" Text='<%# Eval("CompanyID") %>' Visible="False" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="AddressLine1" Text="Address Line 1" runat="server"></asp:Literal></span>
                            <asp:TextBox ID="AddressLine1TextBox" runat="server" CssClass="form-control" Text='<%# Bind("AddressLine1") %>' />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="AddressLine2" Text="Address Line 2" runat="server" ></asp:Literal></span>
                            <asp:TextBox ID="AddressLine2TextBox" runat="server" CssClass="form-control" Text='<%# Bind("AddressLine2") %>' />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="Phone" Text="Phone" runat="server" ></asp:Literal></span>
                            <asp:TextBox ID="PhoneTextBox" runat="server" CssClass="form-control" Text='<%# Bind("Phone") %>' />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="Fax" Text="Fax" runat="server" ></asp:Literal></span>
                            <asp:TextBox ID="FaxTextBox" runat="server" Text='<%# Bind("Fax") %>' CssClass="form-control" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="WebSite" Text="Website" runat="server" ></asp:Literal></span>
                            <asp:TextBox ID="WebSiteTextBox" runat="server" Text='<%# Bind("WebSite") %>' CssClass="form-control" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="Email" Text="Email" runat="server" ></asp:Literal></span>
                            <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' CssClass="form-control"  />
                        </div>
                         <div class="input-group">
                            <span class="input-group-addon">
                            <asp:Literal ID="Literal1" Text="Business Type" runat="server" ></asp:Literal></span>
                            <cc1:BusinessTypeDropDownList ID="ddlLedgerType"  runat="server" CssClass="form-control width-50" SelectedValue='<%# Bind("BusinessTypeID") %>' AutoPostBack="True" OnSelectedIndexChanged="ddlLedgerType_SelectedIndexChanged"></cc1:BusinessTypeDropDownList>
                            <cc1:BusinessSubTypeDropDownList ID="BusinessSubTypeDropDownList1"  runat="server" CssClass="form-control width-50" SelectedValue='<%# Bind("BusinessSubTypeID") %>'></cc1:BusinessSubTypeDropDownList>
                        </div>
                       
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="lLogo" Text="Logo" runat="server"></asp:Literal></span>
                            <asp:FileUpload ID="fuLogo" CssClass="form-control" runat="server" />
                        </div>
                        <div class="btn-group" role="group">

                            <asp:HrnLinkButton ID="UpdateButton" runat="server" CssClass="btn btn-default glyphicon glyphicon-ok-circle"
                                CommandName="Update" Text="Update" SecurityCommandName="Edit" />
                            <asp:LinkButton ID="UpdateCancelButton" runat="server" CssClass="btn btn-default glyphicon glyphicon-remove-circle" CausesValidation="False"
                                CommandName="Cancel" Text="Cancel" ></asp:LinkButton>
                        </div>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="InstituteName" Text="Institute Name" runat="server" ></asp:Literal></span>
                            <asp:Label ID="CompanyIDLabel" runat="server" Text='<%# Eval("CompanyID") %>' Visible="False" />
                            <asp:Label ID="CompanyNameLabel" runat="server" CssClass="form-control" Text='<%# Bind("CompanyName") %>' />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="AddressLine1" Text="Address Line 1" runat="server" ></asp:Literal></span>
                            <asp:Label ID="AddressLine1Label" runat="server" CssClass="form-control" Text='<%# Bind("AddressLine1") %>' />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="AddressLine2" Text="Address Line 2" runat="server" ></asp:Literal></span>
                            <asp:Label ID="AddressLine2Label" runat="server" CssClass="form-control" Text='<%# Bind("AddressLine2") %>' />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="Phone" Text="Phone" runat="server" ></asp:Literal></span>
                            <asp:Label ID="PhoneLabel" CssClass="form-control" runat="server" Text='<%# Bind("Phone") %>' />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="Fax" Text="Fax" runat="server" ></asp:Literal></span>
                            <asp:Label ID="FaxLabel" runat="server" CssClass="form-control" Text='<%# Bind("Fax") %>' />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="WebSite" Text="Website" runat="server" ></asp:Literal></span>
                            <asp:Label ID="WebSiteLabel" runat="server" CssClass="form-control" Text='<%# Bind("WebSite") %>' />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="Email" Text="Email" runat="server"></asp:Literal></span>
                            <asp:Label ID="EmailLabel" runat="server" CssClass="form-control" Text='<%# Bind("Email") %>' />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                            <asp:Literal ID="Literal1" Text="Business Type" runat="server" ></asp:Literal></span>
                            <cc1:BusinessTypeDropDownList ID="ddlLedgerType1" ReadOnly="true"  runat="server" CssClass="form-control width-50" SelectedValue='<%# Bind("BusinessTypeID") %>'></cc1:BusinessTypeDropDownList>
                            <cc1:BusinessSubTypeDropDownList ID="BusinessSubTypeDropDownList2"  ReadOnly="true"   runat="server" CssClass="form-control width-50" SelectedValue='<%# Bind("BusinessSubTypeID") %>'></cc1:BusinessSubTypeDropDownList>
                       </div>
                        
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="lLogo" Text="Logo" runat="server"></asp:Literal></span>
                            <span class="form-control" style="height: auto; overflow: auto;">
                                <asp:Image ID="ImageLogo" CssClass="companylogo" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "CompanyID", "~/Logo/logo_{0}.jpg") %>' runat="server" />
                            </span>
                        </div>
                        <div class="btn-group" role="group">
                            <asp:Button ID="NewButton" runat="server" CausesValidation="False" CssClass="lnkbtn"
                                CommandName="New" Text="New" Visible="False" />
                            <asp:HrnLinkButton ID="EditButton" runat="server" CausesValidation="False" CssClass="btn btn-default glyphicon glyphicon-edit"
                                CommandName="Edit" Text="Edit" SecurityCommandName="Edit"></asp:HrnLinkButton>
                        </div>

                    </ItemTemplate>
                </asp:FormView>
                <div style="float: left; width: 100%;">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>

                <asp:SqlDataSource ID="dsCompany" runat="server" SelectCommand="SELECT [CompanyID], [CompanyName], [AddressLine1], [AddressLine2], [Email], [Phone], [Fax], [Website], [BusinessTypeID], [BusinessSubTypeID] FROM [Company] WHERE ([CompanyID] = @CompanyID)"
                    UpdateCommand="UPDATE [Company] SET [CompanyName] = @CompanyName, [AddressLine1] = @AddressLine1, [AddressLine2] = @AddressLine2, [Email] = @Email, [Phone] = @Phone, [Fax] = @Fax, [Website] = @Website, [BusinessTypeID]=@BusinessTypeID, [BusinessSubTypeID]=@BusinessSubTypeID WHERE [CompanyID] = @CompanyID"
                    DeleteCommand="DELETE FROM [Company] WHERE [CompanyID] = @CompanyID" InsertCommand="INSERT INTO [Company] ([CompanyName], [AddressLine1], [AddressLine2], [Email], [Phone], [Fax], [Website], [BusinessTypeID], [BusinessSubTypeID]) VALUES (@CompanyName, @AddressLine1, @AddressLine2, @Email, @Phone, @Fax, @Website, @BusinessTypeID, @BusinessSubTypeID)" OnDeleted="DsData_OperationCompleted" OnInserted="DsData_OperationCompleted" OnSelected="DsData_OperationCompleted" OnUpdated="DsData_OperationCompleted">
                    <DeleteParameters>
                        <asp:Parameter Name="CompanyID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CompanyName" Type="String" />
                        <asp:Parameter Name="AddressLine1" Type="String" />
                        <asp:Parameter Name="AddressLine2" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="Phone" Type="String" />
                        <asp:Parameter Name="Fax" Type="String" />
                        <asp:Parameter Name="Website" Type="String" />
                        <asp:Parameter Name="BusinessTypeID" Type="Int32" />
                        <asp:Parameter Name="BusinessSubTypeID" Type="Int32" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:SessionParameter Name="CompanyID" SessionField="CompanyID" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CompanyName" Type="String" />
                        <asp:Parameter Name="AddressLine1" Type="String" />
                        <asp:Parameter Name="AddressLine2" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="Phone" Type="String" />
                        <asp:Parameter Name="Fax" Type="String" />
                        <asp:Parameter Name="Website" Type="String" />
                       <asp:Parameter Name="BusinessTypeID" Type="Int32" />
                        <asp:Parameter Name="BusinessSubTypeID" Type="Int32" />
                        <asp:Parameter Name="CompanyID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>


</asp:Content>
