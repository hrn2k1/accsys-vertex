using Accounting.DataAccess;
using Accounting.Utility;
using AccSys.Web.WebControls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Tools;

namespace AccSys.Web
{
    public partial class Login : System.Web.UI.Page
    {

        private void LoadCompany(SqlConnection conn)
        {
            System.Web.UI.WebControls.Login Login1 = (System.Web.UI.WebControls.Login)LoginView1.FindControl("Login1");
            if (Login1 == null) return;
            var control = Login1.FindControl("ddlCompany");
            if (control != null)
            {
                var ddlCompany = (DropDownList)control;
                DaLogIn obj = new DaLogIn();
                DataTable dtt = new DataTable();
                dtt = obj.GetCompant(conn);
                ddlCompany.DataSource = dtt;
                ddlCompany.DataTextField = "CompanyName";
                ddlCompany.DataValueField = "CompanyID";
                ddlCompany.DataBind();
            }
        }

        private void LoadUser(SqlConnection conn)
        {
            System.Web.UI.WebControls.Login Login1 = (System.Web.UI.WebControls.Login)LoginView1.FindControl("Login1");
            if (Login1 == null) return;
            var control = Login1.FindControl("UserName");
            if (control != null)
            {
                var ddlUser = (DropDownList)control;
                DaLogIn objl = new DaLogIn();
                DataTable dt = new DataTable();
                dt = objl.GetUsers(conn);
                ddlUser.DataSource = dt;
                ddlUser.DataTextField = "UserName";
                ddlUser.DataValueField = "UserName";
                ddlUser.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    using (var connection = new SqlConnection(ConnectionHelper.DefaultConnectionString))
                    {
                        connection.Open();
                        LoadCompany(connection);
                        LoadUser(connection);
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            try
            {
                System.Web.UI.WebControls.Login Login1 = (System.Web.UI.WebControls.Login)LoginView1.FindControl("Login1");
                var control = Login1.FindControl("UserName");
                if (control != null)
                {
                    var ddlUser = (DropDownList)control;
                    Session.UserName(ddlUser.SelectedValue);
                    var user = new DaLogIn().GetUser(ddlUser.SelectedValue);
                    var role = user.RoleId > 0 ? new DaRole().GetRole(user.RoleId) : null;
                    Session.UserId(user.UserID);
                    Session.UserRoleId(user.RoleId);
                    var isSuperAdmin = role != null ? role.RoleName.Contains("Super") : false;
                    Session.IsSuperAdmin(isSuperAdmin);
                    control = Login1.FindControl("ddlCompany");
                    if (control != null)
                    {
                        var ddlCompany = (DropDownList)control;
                        int companyId = Convert.ToInt32(ddlCompany.SelectedValue);
                        Session.CompanyId(companyId);
                        var objDaCompany = new DaCompany();
                        var company = objDaCompany.GetCompany(companyId);
                        var logo = company.CompanyLogo;
                        if (logo != null)
                        {
                            var logo64 = Convert.ToBase64String(logo);
                        }
                        Session.Company(company);
                    }
                    var access = DalResourceAuthorization.GetAuthorizationResources(user.UserID);
                    Session.UserRoleAccess(access);                    
                }
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
            System.Web.UI.WebControls.Login Login1 = (System.Web.UI.WebControls.Login)LoginView1.FindControl("Login1");
            var control = Login1.FindControl("UserName");
            if (control != null)
            {
                var ddlUser = (DropDownList)control;
                Login1.UserName = ddlUser.SelectedValue;
                string strpass = string.IsNullOrWhiteSpace(Login1.Password) ? Login1.Password.Trim() : GlobalFunctions.Encode(Login1.Password, GlobalFunctions.CypherText);
                var objDaLogin = new DaLogIn();
                e.Authenticated = objDaLogin.ValidateUserPassword(ddlUser.SelectedValue, strpass);
            }
        }
    }
}