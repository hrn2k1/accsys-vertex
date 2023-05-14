using Accounting.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;

namespace AccSys.Web
{
    public partial class frmCompanies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadCompanies();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private void LoadCompanies()
        {
            gvData.DataSourceID = "odsCommon";
            odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @" CompanyID, CompanyName, Phone, Email ";
            odsCommon.SelectParameters["FromTable"].DefaultValue = @" Company ";
            odsCommon.SelectParameters["Where"].DefaultValue = "1=1";
            odsCommon.SelectParameters["OrderBy"].DefaultValue = " CompanyName ";
            gvData.PageIndex = 0;
            gvData.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DaCompany.CreateNewCompany(txtName.Text.Trim());
                LoadCompanies();
                txtName.Text = "";
                lblMsg.Text = UIMessage.Message2User("Successfully created", UserUILookType.Success);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}