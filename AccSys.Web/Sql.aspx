<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sql.aspx.cs" Inherits="AccSys.Web.Sql" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <div style="width: 100%">
            <asp:TextBox ID="txtSql" runat="server" TextMode="MultiLine" Rows="5" Width="100%"></asp:TextBox>
        </div>
        <div style="width: 100%">
            <asp:Button ID="btnExecute" runat="server" Text="Execute" OnClick="btnExecute_Click" />
        </div>
    </form>
</body>
</html>
