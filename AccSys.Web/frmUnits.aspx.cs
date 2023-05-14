using Accounting.DataAccess;
using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Tools;

namespace AccSys.Web
{
    public partial class frmUnits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    
                    LoadUnits();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private void LoadUnits()
        {
            var companyId = GlobalFunctions.isNull(Session["CompanyID"], 0);
            gvData.DataSourceID = "odsCommon";
            odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @" UnitsID, UnitsName, CompanyID ";
            odsCommon.SelectParameters["FromTable"].DefaultValue = @" P_Units ";
            odsCommon.SelectParameters["Where"].DefaultValue = "CompanyID=" + companyId.ToString();
            odsCommon.SelectParameters["OrderBy"].DefaultValue = " UnitsName ";
            gvData.PageIndex = 0;
            gvData.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var unit = new Units()
                {
                    UnitsID = Convert.ToInt32(lblId.Text),
                    UnitsName = txtUnitName.Text.Trim(),
                    CompanyId = GlobalFunctions.isNull(Session["CompanyID"], 0)
                };
                new DaUnits().SaveUpdateUnits(unit, ConnectionHelper.getConnection());
                LoadUnits();
                lblId.Text = "0";
                txtUnitName.Text = "";
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
                new DaUnits().DeleteUnits(ConnectionHelper.getConnection(), id);
                lblMsg.Text = UIMessage.Message2User("Successfully deleted", UserUILookType.Success);
                LoadUnits();
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
                txtUnitName.Text = lblName.Text;
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}