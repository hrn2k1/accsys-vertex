using Accounting.DataAccess;
using AccSys.Web.WebControls;
using System;
using Tools;

namespace AccSys.Web
{
    public partial class frmCompanies : BasePage
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