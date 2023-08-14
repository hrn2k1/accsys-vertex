using Accounting.Utility;
using AccSys.Web.WebControls;
using System;
using System.Data;
using System.Data.SqlClient;
using Tools;

namespace AccSys.Web
{
    public partial class BalanceSheetSetup : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    using (var adapter = new SqlDataAdapter("SELECT ReportId, ReportName FROM CustomReport ORDER BY ReportName", ConnectionHelper.getConnection()))
                    {
                        var data = new DataTable();
                        adapter.Fill(data);
                        adapter.Dispose();
                        ddlReport.DataSource = data;
                        ddlReport.DataValueField = "ReportId";
                        ddlReport.DataTextField = "ReportName";
                        ddlReport.DataBind();
                    }
                    LoadReportDetail();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var connection = ConnectionHelper.getConnection();
                var qstr = $@"INSERT INTO CustomReportDetail (ReportId, Head, SortOrder, QueryType, QueryText, Filter, CssClass, Side)
                              VALUES ({ddlReport.SelectedValue}, '{txtHead.Text.Trim()}', {txtSortOrder.Text.Trim().ToInt()},
                                      '{ddlQueryType.SelectedValue}', '{txtQueryText.Text}', '{txtFilter.Text}', '{txtCssClass.Text}', '{ddlSide.SelectedValue}')";
                using (var cmd = new SqlCommand(qstr, connection))
                {
                    if (connection.State != ConnectionState.Open) connection.Open();
                    cmd.ExecuteNonQuery();
                    if (connection.State == ConnectionState.Closed) connection.Close();
                }
                LoadReportDetail();
                btnReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtHead.Text = string.Empty;
            txtQueryText.Text = string.Empty;
            txtFilter.Text = string.Empty;
            txtCssClass.Text = string.Empty;
        }

        protected void LoadReportDetail()
        {
            try
            {
                gvData.DataSourceID = "odsCommon";
                odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @" * ";
                odsCommon.SelectParameters["FromTable"].DefaultValue = @" CustomReportDetail ";
                odsCommon.SelectParameters["Where"].DefaultValue = $"ReportId={ddlReport.SelectedValue}";
                odsCommon.SelectParameters["OrderBy"].DefaultValue = " SortOrder ";
                gvData.PageIndex = 0;
                gvData.DataBind();
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = ((System.Web.UI.WebControls.Label)((HrnLinkButton)sender).NamingContainer.FindControl("lblId")).Text.ToInt();
                var connection = ConnectionHelper.getConnection();
                var qstr = $"DELETE FROM CustomReportDetail WHERE Id={id}";
                using (var cmd = new SqlCommand(qstr, connection))
                {
                    if (connection.State != ConnectionState.Open) connection.Open();
                    cmd.ExecuteNonQuery();
                    if (connection.State == ConnectionState.Closed) connection.Close();
                }
                LoadReportDetail();
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

            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}