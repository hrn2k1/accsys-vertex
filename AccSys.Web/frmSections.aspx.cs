using Accounting.DataAccess;
using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;

namespace AccSys.Web
{
    public partial class frmSections : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {                    
                    LoadSections();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private void LoadSections()
        {
            var companyId = GlobalFunctions.isNull(Session["CompanyID"], 0);
            gvData.DataSourceID = "odsCommon";
            odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @" SectionID, Name, CompanyID ";
            odsCommon.SelectParameters["FromTable"].DefaultValue = @" Section ";
            odsCommon.SelectParameters["Where"].DefaultValue = "CompanyID=" + companyId.ToString();
            odsCommon.SelectParameters["OrderBy"].DefaultValue = " Name ";
            gvData.PageIndex = 0;
            gvData.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var section = new Section()
                {
                    SectionID = Convert.ToInt32(lblId.Text),
                    Name = txtName.Text.Trim(),
                    Description="",
                    CompanyId = GlobalFunctions.isNull(Session["CompanyID"], 0)
                };
                new DaSection().SaveUpdateSection(section, ConnectionHelper.getConnection());
                LoadSections();
                lblId.Text = "0";
                txtName.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            Label lblRowId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblId");
            int id = lblRowId.Text.ToInt();

            try
            {
                new DaSection().deleteSection(ConnectionHelper.getConnection(), id);
                lblMsg.Text = UIMessage.Message2User("Successfully deleted", UserUILookType.Success);
                LoadSections();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Label lblRowId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblId");
                lblId.Text = lblRowId.Text;
                Label lblName = (Label)((LinkButton)sender).NamingContainer.FindControl("lblName");
                txtName.Text = lblName.Text;
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}