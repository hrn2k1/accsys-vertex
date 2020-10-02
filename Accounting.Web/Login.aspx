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

    <table summary="" id="headerTable" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td>
                    <div id="logo">
                        <img src="Images/logo.png" alt="" usemap="#mwlogomap">
                        <map name="mwlogomap" id="mwlogomap">
                            <area shape="rect" coords="0,30,200,47" href="#"
                                alt="Built with Mathematica Technology" title="Built with Leatest Experiences">
                            <area shape="rect" coords="0,0,617,30" href="#" alt="Vertex Group"
                                title="Vertex Group">
                        </map>
                        <img src="Logo/logo.jpg" alt="" style="float: right" height="65" width="100" />
                    </div>
                </td>
                <td>
                    <div id="searchWrapper">
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <table summary="" id="pageTable1" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>

                <td class="mainCell no-sidebar" align="center">
                    <div id="mainContent" style="margin: 8%; width: 30%; min-height: 10px;">
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
                                                OnLoggedIn="Login1_LoggedIn" meta:resourcekey="Login1Resource1" OnAuthenticate="Login1_Authenticate">
                                                <LayoutTemplate>
                                                    <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                                                        <tr>
                                                            <td>
                                                                <table cellpadding="0">

                                                                    <tr>
                                                                        <td align="right" style="text-align: left">
                                                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" meta:resourcekey="UserNameLabelResource1" Text="User Name:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UserName" runat="server" meta:resourcekey="UserNameResource1"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                                                                ControlToValidate="UserName" ErrorMessage="User Name is required."
                                                                                ToolTip="User Name is required." ValidationGroup="Login1" meta:resourcekey="UserNameRequiredResource1" Text="*"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" style="text-align: left">
                                                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" meta:resourcekey="PasswordLabelResource1" Text="Password:"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="Password" runat="server" TextMode="Password" meta:resourcekey="PasswordResource1"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                                                                ControlToValidate="Password" ErrorMessage="Password is required."
                                                                                ToolTip="Password is required." ValidationGroup="Login1" meta:resourcekey="PasswordRequiredResource1" Text="*"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="text-align: left">
                                                                            <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." meta:resourcekey="RememberMeResource1" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2" style="color: Red; text-align: left;">
                                                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False" meta:resourcekey="FailureTextResource1"></asp:Literal>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" colspan="2">
                                                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="LogIn" CssClass="btn btn-default glyphicon glyphicon-log-in"
                                                                                ValidationGroup="Login1" meta:resourcekey="LoginButtonResource1" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2"></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </LayoutTemplate>

                                            </asp:Login>
                                        </AnonymousTemplate>
                                        <LoggedInTemplate>
                                            <asp:LoginName ID="LoginName1" runat="server" meta:resourcekey="LoginName1Resource1" />
                                            <asp:LoginStatus ID="LoginStatus1" runat="server" meta:resourcekey="LoginStatus1Resource1" OnLoggingOut="LoginStatus1_LoggingOut" />
                                        </LoggedInTemplate>
                                    </asp:LoginView>
                                </div>

                            </div>
                        </form>
                    </div>
                    <!--End main content -->
                    <!--Start resources content -->
                    <div id="resourcesContent" style="margin: 0 10px">
                        <h1>Softwares By Vertex Group</h1>
                        <table summary="" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tbody>
                                <tr>
                                    <td>
                                        <span class="title"><a href="#"><em>HR Management</em>&nbsp;»</a></span>
                                        <p style="float:left">
                                            Total Human Resource Management System for Garments, Industries.
                                        </p>
                                    </td>
                                    <td>
                                        <span class="title"><a href="#">Production Management&nbsp;»</a></span>
                                        <p style="float:left">
                                            Production Management System for any kind of Production Company.
                                        </p>
                                    </td>
                                    <td class="last">
                                        <span class="title"><a href="#">Accounting System&nbsp;»</a></span>
                                        <p style="float:left">
                                            Total Accounting System with Double Entry System for any kind of Company.
                                        </p>

                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                    <!--End resources content -->
                    <!--Start footer content -->
                    <div id="footer" style="margin: 10px 30px">
                        <table summary="" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tbody>
                                <tr>
                                    <td>
                                        <a href="#">
                                            <img src="Images/contact-icon.gif" alt="" title="" border="0">
                                            Contact the <em>Developer</em> Team</a>
                                    </td>
                                    <td class="copyright">© 2010-2015 <a href="#" target="_blank">Vertex Group</a>
                                        | <a href="#">Terms of Use</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <!--End footer content -->
                </td>
            </tr>
        </tbody>
    </table>

</body>
</html>
