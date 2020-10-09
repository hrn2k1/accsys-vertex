using Accounting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;

namespace Accounting.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CompanyId"] == null)
                {
                    Server.TransferRequest("~/Login.aspx");
                }

                if(Session["Company"] != null)
                {
                    var company = (CompanyInformation)Session["Company"];
                    lblCompanyName.Text = company.CompanyName;
                    lblCompanyName.ToolTip = company.CompanyName;
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