using AccSys.Web.WebControls;
using System;
using System.Web;
using Tools;

namespace AccSys.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CompanyID"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                var company = Session.Company();
                if (company != null)
                {                    
                    lblCompanyName.Text = company.CompanyName;
                    lblCompanyName.ToolTip = company.CompanyName;
                    ImgLogo.ImageUrl = "~/" + company.CompanyLogo;
                }
            }
            
        }
        protected void LoginStatus2_LoggedOut(object sender, EventArgs e)
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
    }
}