using System;
using System.Collections.Generic;
using System.Web;
using Tools;

namespace Accounting.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            try
            {
                System.Web.UI.WebControls.Login Login1 = (System.Web.UI.WebControls.Login)LoginView1.FindControl("Login1");
                Guid UserId = new Guid("6b98368f-015c-4383-a611-d19e2a316ad7");
                List<string> userRoleList = new List<string>() { "Admin" };
                bool isSuperAdmin = false;
                Session["UserName"] = Login1.UserName;
                Session["UserId"] = UserId;
                Session["UserRoles"] = userRoleList;
                Session["IsSuperAdmin"] = isSuperAdmin;
                Session["CompanyId"] = 1;
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }

        }
        protected void LoginStatus1_LoggingOut(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
        {
            try
            {

                Session.Clear();
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }

        }

        protected void Login1_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {
            e.Authenticated = true;
        }
    }
}