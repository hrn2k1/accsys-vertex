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
    public partial class FiscalYear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var companyId = GlobalFunctions.isNull(Session["CompanyID"], 0);
                    LoadFiscalYears();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private void LoadFiscalYears()
        {
            gvData.DataSourceID = "odsCommon";
            odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @" FiscalYearID, Title, StartDate, EndDate, CompanyID,  CAST(CASE WHEN EndDate IS NULL THEN 1 ELSE 0 END AS BIT) AS [Current] ";
            odsCommon.SelectParameters["FromTable"].DefaultValue = @" FiscalYear ";
            odsCommon.SelectParameters["Where"].DefaultValue = string.Format(" CompanyID={0} ", Session["CompanyID"] ?? 1); ;
            odsCommon.SelectParameters["OrderBy"].DefaultValue = " StartDate DESC ";
            gvData.PageIndex = 0;
            gvData.DataBind();
        }
        protected void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                int companyId = GlobalFunctions.isNull(Session["CompanyID"], 0);
                DateTime startDate = Tools.Utility.GetDateValue(txtStartDate.Text.Trim(), DateNumericFormat.YYYYMMDD);
                DaFiscalYear.StartFiscalYear(txtTitle.Text.Trim(), startDate, companyId, 1);
                lblMsg.Text = UIMessage.Message2User("Successfully Started", UserUILookType.Success);
                Reset();
                LoadFiscalYears();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private void Reset()
        {
            txtTitle.Text = "";
            txtTitle.Enabled = true;
            txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtStartDate.Enabled = true;
            txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtEndDate.Visible = false;
            lblEndDate.Visible = false;
            btnStart.Visible = true;
            btnEnd.Visible = false;
            lblFYId.Text = "0";
        }
        protected void btnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = lblFYId.Text.ToInt();
                DateTime endDate = Tools.Utility.GetDateValue(txtEndDate.Text.Trim(), DateNumericFormat.YYYYMMDD);
                DaFiscalYear.EndFiscalYear(id, endDate);
                lblMsg.Text = UIMessage.Message2User("Successfully Ended", UserUILookType.Success);
                Reset();
                LoadFiscalYears();
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
                new DaFiscalYear().DeleteFiscalYear(ConnectionHelper.getConnection(), id);
                lblMsg.Text = UIMessage.Message2User("Successfully deleted", UserUILookType.Success);
                LoadFiscalYears();
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
                lblFYId.Text = lblRowId.Text;
                Label lblTitle = (Label)((LinkButton)sender).NamingContainer.FindControl("lblTitle");
                txtTitle.Text = lblTitle.Text;
                txtTitle.Enabled = true;
                Label lblStartDate = (Label)((LinkButton)sender).NamingContainer.FindControl("lblStartDate");
                string date = lblStartDate.Text;
                txtStartDate.Text = Tools.Utility.GetDateValue(date, DateNumericFormat.DDMMYYYY).ToString("yyyy-MM-dd");
                txtStartDate.Enabled = true;
                lblEndDate.Visible = false;
                txtEndDate.Visible = false;
                btnEnd.Visible = false;
                btnStart.Visible = true;
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void lbtnEnd_Click(object sender, EventArgs e)
        {
            try
            {

                Label lblRowId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblId");
                lblFYId.Text = lblRowId.Text;
                Label lblTitle = (Label)((LinkButton)sender).NamingContainer.FindControl("lblTitle");
                txtTitle.Text = lblTitle.Text;
                txtTitle.Enabled = false;
                Label lblStartDate = (Label)((LinkButton)sender).NamingContainer.FindControl("lblStartDate");
                string date = lblStartDate.Text;
                txtStartDate.Text = Tools.Utility.GetDateValue(date, DateNumericFormat.DDMMYYYY).ToString("yyyy-MM-dd");
                txtStartDate.Enabled = false;
                lblEndDate.Visible = true;
                txtEndDate.Visible = true;
                btnEnd.Visible = true;
                btnStart.Visible = false;
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}