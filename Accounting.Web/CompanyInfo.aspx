<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanyInfo.aspx.cs" Inherits="Accounting.Web.CompanyInfo" %>
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
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="CompanyID" DataSourceID="dsCompany"
                    Width="80%" meta:resourcekey="FormView1Resource1">
                    <EditItemTemplate>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="InstituteName" Text="Institute Name" runat="server" meta:resourcekey="InstituteNameResource1"></asp:Literal>
                            </span>
                            <asp:TextBox ID="CompanyNameTextBox" runat="server" CssClass="form-control"
                                Text='<%# Bind("CompanyName") %>' meta:resourcekey="CompanyNameTextBoxResource1" />
                            <asp:Label ID="CompanyIDLabel1" runat="server" Text='<%# Eval("CompanyID") %>' Visible="False" meta:resourcekey="CompanyIDLabel1Resource1" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="AddressLine1" Text="Address Line 1" runat="server" meta:resourcekey="AddressLine1Resource1"></asp:Literal></span>
                            <asp:TextBox ID="AddressLine1TextBox" runat="server" CssClass="form-control"
                                Text='<%# Bind("AddressLine1") %>' meta:resourcekey="AddressLine1TextBoxResource1" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="AddressLine2" Text="Address Line 2" runat="server" meta:resourcekey="AddressLine2Resource1"></asp:Literal></span>
                            <asp:TextBox ID="AddressLine2TextBox" runat="server" CssClass="form-control"
                                Text='<%# Bind("AddressLine2") %>' meta:resourcekey="AddressLine2TextBoxResource1" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="Phone" Text="Phone" runat="server" meta:resourcekey="PhoneResource1"></asp:Literal></span>
                            <asp:TextBox ID="PhoneTextBox" runat="server" CssClass="form-control"
                                Text='<%# Bind("Phone") %>' meta:resourcekey="PhoneTextBoxResource1" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="Fax" Text="Fax" runat="server" meta:resourcekey="FaxResource1"></asp:Literal></span>
                            <asp:TextBox ID="FaxTextBox" runat="server" Text='<%# Bind("Fax") %>' CssClass="form-control"
                                meta:resourcekey="FaxTextBoxResource1" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="WebSite" Text="Website" runat="server" meta:resourcekey="WebSiteResource1"></asp:Literal></span>
                            <asp:TextBox ID="WebSiteTextBox" runat="server" Text='<%# Bind("WebSite") %>' CssClass="form-control" meta:resourcekey="WebSiteTextBoxResource1" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="Email" Text="Email" runat="server" meta:resourcekey="EmailResource1"></asp:Literal></span>
                            <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' CssClass="form-control" meta:resourcekey="EmailTextBoxResource1" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="lLogo" Text="Logo" runat="server"></asp:Literal></span>
                            <asp:FileUpload ID="fuLogo" CssClass="form-control" runat="server" />
                        </div>
                        <div class="btn-group" role="group">

                            <asp:LinkButton ID="UpdateButton" runat="server" CssClass="btn btn-default glyphicon glyphicon-ok-circle"
                                CommandName="Update" Text="Update" meta:resourcekey="UpdateButtonResource1" SecurityCommandName="Edit" />
                            <asp:LinkButton ID="UpdateCancelButton" runat="server" CssClass="btn btn-default glyphicon glyphicon-remove-circle" CausesValidation="False"
                                CommandName="Cancel" Text="Cancel" meta:resourcekey="UpdateCancelButtonResource1"></asp:LinkButton>
                        </div>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="InstituteName" Text="Institute Name" runat="server" meta:resourcekey="InstituteNameResource2"></asp:Literal></span>
                            <asp:Label ID="CompanyIDLabel" runat="server" Text='<%# Eval("CompanyID") %>' Visible="False" meta:resourcekey="CompanyIDLabelResource1" />
                            <asp:Label ID="CompanyNameLabel" runat="server" CssClass="form-control" Text='<%# Bind("CompanyName") %>' meta:resourcekey="CompanyNameLabelResource1" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="AddressLine1" Text="Address Line 1" runat="server" meta:resourcekey="AddressLine1Resource2"></asp:Literal></span>
                            <asp:Label ID="AddressLine1Label" runat="server" CssClass="form-control" Text='<%# Bind("AddressLine1") %>' meta:resourcekey="AddressLine1LabelResource1" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="AddressLine2" Text="Address Line 2" runat="server" meta:resourcekey="AddressLine2Resource2"></asp:Literal></span>
                            <asp:Label ID="AddressLine2Label" runat="server" CssClass="form-control" Text='<%# Bind("AddressLine2") %>' meta:resourcekey="AddressLine2LabelResource1" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="Phone" Text="Phone" runat="server" meta:resourcekey="PhoneResource2"></asp:Literal></span>
                            <asp:Label ID="PhoneLabel" CssClass="form-control" runat="server" Text='<%# Bind("Phone") %>' meta:resourcekey="PhoneLabelResource1" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="Fax" Text="Fax" runat="server" meta:resourcekey="FaxResource2"></asp:Literal></span>
                            <asp:Label ID="FaxLabel" runat="server" CssClass="form-control" Text='<%# Bind("Fax") %>' meta:resourcekey="FaxLabelResource1" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="WebSite" Text="Website" runat="server" meta:resourcekey="WebSiteResource2"></asp:Literal></span>
                            <asp:Label ID="WebSiteLabel" runat="server" CssClass="form-control" Text='<%# Bind("WebSite") %>' meta:resourcekey="WebSiteLabelResource1" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <asp:Literal ID="Email" Text="Email" runat="server" meta:resourcekey="EmailResource2"></asp:Literal></span>
                            <asp:Label ID="EmailLabel" runat="server" CssClass="form-control" Text='<%# Bind("Email") %>' meta:resourcekey="EmailLabelResource1" />
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
                                CommandName="New" Text="New" Visible="False" meta:resourcekey="NewButtonResource1" />
                            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CssClass="btn btn-default glyphicon glyphicon-edit"
                                CommandName="Edit" Text="Edit" meta:resourcekey="EditButtonResource1" SecurityCommandName="Edit"></asp:LinkButton>
                        </div>

                    </ItemTemplate>
                </asp:FormView>
                <div style="float: left; width: 100%;">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>

                <asp:SqlDataSource ID="dsCompany" runat="server" SelectCommand="SELECT [CompanyID], [CompanyName], [AddressLine1], [AddressLine2], [Email], [Phone], [Fax], [Website] FROM [Company] WHERE ([CompanyID] = @CompanyID)"
                    UpdateCommand="UPDATE [Company] SET [CompanyName] = @CompanyName, [AddressLine1] = @AddressLine1, [AddressLine2] = @AddressLine2, [Email] = @Email, [Phone] = @Phone, [Fax] = @Fax, [Website] = @Website WHERE [CompanyID] = @CompanyID"
                    DeleteCommand="DELETE FROM [Company] WHERE [CompanyID] = @CompanyID" InsertCommand="INSERT INTO [Company] ([CompanyName], [AddressLine1], [AddressLine2], [Email], [Phone], [Fax], [Website]) VALUES (@CompanyName, @AddressLine1, @AddressLine2, @Email, @Phone, @Fax, @Website)" OnDeleted="DsData_OperationCompleted" OnInserted="DsData_OperationCompleted" OnSelected="DsData_OperationCompleted" OnUpdated="DsData_OperationCompleted">
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
                      
                        <asp:Parameter Name="CompanyID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>


</asp:Content>
