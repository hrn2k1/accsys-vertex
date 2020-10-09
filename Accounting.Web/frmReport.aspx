<%@ Page Title="" Language="C#" MasterPageFile="~/SiteEmpty.Master" AutoEventWireup="true" CodeBehind="frmReport.aspx.cs" Inherits="Accounting.Web.frmReport" %>
<%@ Register Assembly="Accounting.Web" Namespace="Accounting.Web.DbControls" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .crystal-report-container {
            text-align: center;
            width: 100%;
            background-color: #ccc;
        }

        .crystal-report-viewer {
            background-color: #fff;
            text-align: initial;
            margin-top: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="report-parameters">
        <asp:Label ID="lblAccount" runat="server" Text="Account" Visible="false" />
        <cc1:accountdropdownlistchosen id="ddlAccount" runat="server"
            NullItemText="Select Account" NullItemValue="0" width="200px"  Visible="false">
        </cc1:accountdropdownlistchosen>
        <asp:Label ID="lblDateFrom" runat="server" Text="Date"  Visible="false" />
        <asp:TextBox ID="txtFromDate" runat="server" Width="100px" Visible="false"></asp:TextBox>
        <ajax:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
         <asp:Label ID="lblDateTo" runat="server" Text="-" Visible="false" />
        <asp:TextBox ID="txtToDate" runat="server" Width="100px" Visible="false"></asp:TextBox>
        <ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy"></ajax:CalendarExtender>
        <asp:LinkButton ID="btnShow" runat="server" Text="Show" CssClass="btn btn-sm btn-default glyphicon glyphicon-refresh" OnClick="btnShow_Click" />
    </div>
    <div class="crystal-report-container">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" DisplayGroupTree="False" CssClass="crystal-report-viewer" />
    </div>
</asp:Content>
