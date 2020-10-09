<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Accounting.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login to System</title>
    <meta http-equiv="x-ua-compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0" />

    <link href="themes/redmond/jquery-ui-1.8.1.custom.css" rel="stylesheet" type="text/css" />
    <%-- <link href="Styles/jquery-ui-1.8.1.custom.css" rel="stylesheet" type="text/css" />--%>
    <link href="Styles/Grid.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.11.4.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="Styles/TTL.css" />
    <script src="Scripts/TTL.js" type="text/javascript"></script>
    <link href="Content/ems.css" rel="stylesheet" />

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("center").hide();
            //$("div[style*=position:fixed]").hide();
            $("div").each(function () {
                var divstyle = $(this).attr("onmouseout");
                var re = "ssac";
                if (divstyle != null) {
                    //alert(divstyle );
                    if (divstyle.toString().search(re) != -1) {
                        //   alert(divstyle);
                        $(this).hide();
                    }
                }
                var divstyle1 = $(this).attr("style");
                var re1 = "opacity: 0.9";
                if (divstyle1 != null) {
                    //alert(divstyle );
                    if (divstyle1.toString().search(re1) != -1) {
                        //   alert(divstyle);
                        $(this).hide();
                    }
                }
                //if (divstyle.indexof("position: fixed") != -1)

            });
        });
    </script>
</head>
<body>

    <table summary="" id="pageTable1" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>

                <td class="mainCell no-sidebar" align="center">
                    <div id="mainContent" style="margin-top: 25vh; width: 30%; min-height: 10px; min-width: 300px;">
                        <form id="Form1" runat="server">
                            <div style="border-bottom: 1px solid #A9E163;">Log In To Syestem</div>
                            <br />
                            <div>
                                <img src="Images/spacer.gif" alt="" height="2" width="100%" />
                            </div>
                            <div align="center">
                                <div>
                                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <asp:LoginView ID="LoginView1" runat="server">
                                        <AnonymousTemplate>
                                            <asp:Login ID="Login1" runat="server" RenderOuterTable="False"
                                                TitleText="Log In To Syestem" CreateUserText="Register"
                                                OnLoggedIn="Login1_LoggedIn"  OnAuthenticate="Login1_Authenticate">
                                                <LayoutTemplate>
                                                    <table cellpadding="0">
                                                         <tr>
                                                            <td align="right" style="text-align: left">
                                                                <asp:Label ID="CompanyLabel" runat="server" AssociatedControlID="ddlCompany" Text="Company:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" Width="200px" ></asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="CompanyRequired" runat="server"
                                                                    ControlToValidate="ddlCompany" ErrorMessage="Company is required."
                                                                    ToolTip="Company is required." ValidationGroup="Login1" Text="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="text-align: left">
                                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Text="User:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="UserName" runat="server" Width="200px" ></asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                                                    ControlToValidate="UserName" ErrorMessage="User Name is required."
                                                                    ToolTip="User Name is required." ValidationGroup="Login1" Text="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" style="text-align: left">
                                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Text="Password:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="192px" ></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                                                    ControlToValidate="Password" ErrorMessage="Password is required."
                                                                    ToolTip="Password is required." ValidationGroup="Login1" Text="*"></asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: left">
                                                                <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2" style="color: Red; text-align: left;">
                                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False" ></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="LogIn" CssClass="btn btn-default glyphicon glyphicon-log-in"
                                                                    ValidationGroup="Login1"/>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2"></td>
                                                        </tr>
                                                    </table>
                                                </LayoutTemplate>

                                            </asp:Login>
                                        </AnonymousTemplate>
                                        <LoggedInTemplate>
                                            <asp:LoginName ID="LoginName1" runat="server"  />
                                            <asp:LoginStatus ID="LoginStatus1" runat="server" OnLoggingOut="LoginStatus1_LoggingOut" />
                                        </LoggedInTemplate>
                                    </asp:LoginView>
                                </div>

                            </div>
                        </form>
                    </div>
                    <!--End main content -->
                </td>
            </tr>
        </tbody>
    </table>

</body>
</html>
