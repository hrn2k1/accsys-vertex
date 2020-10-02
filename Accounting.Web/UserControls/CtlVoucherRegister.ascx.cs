using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;

namespace Accounting.Web.UserControls
{
    public partial class CtlVoucherRegister : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                txtFromDate.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                txtToDate.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now);

            }
        }

        public void Bind()
        {
            btnSearch_Click(null, null);
        }
        private string CreateWhere()
        {
            string where = "";
            try
            {
                where = string.Format(" CompanyID={0}", Tools.Utility.IsNull<int>(Session["CompanyId"], 0));
                where += string.Format(" AND (TransDate BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}')", Tools.Utility.GetDateValue(txtFromDate.Text.Trim()), Tools.Utility.GetDateValue(txtToDate.Text.Trim()));
                if (ddlAccount.SelectedValue != "0")
                    where += (where != "" ? " AND " : "") + string.Format(" AccountID={0} ", ddlAccount.SelectedValue);
                if (ddlVoucherType.SelectedValue != "0")
                    where += (where != "" ? " AND " : "") + string.Format(" VoucherTypeID={0} ", ddlVoucherType.SelectedValue);
                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return where;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvData.DataSourceID = "odsCommon";
                odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @" * ";
                odsCommon.SelectParameters["FromTable"].DefaultValue = @" VW_Transactions ";
                odsCommon.SelectParameters["Where"].DefaultValue = CreateWhere();
                odsCommon.SelectParameters["OrderBy"].DefaultValue = " TransDate DESC,VoucherNo";

                if (sender != null)
                    gvData.PageIndex = 0;
                gvData.DataBind();

                ArrangeGrid();

                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private void ArrangeGrid()
        {
            string vn = "";
            foreach (GridViewRow row in gvData.Rows)
            {
               HyperLink lnkVoucher = (HyperLink)row.Cells[1].FindControl("lnkVoucher");
                if (lnkVoucher.Text != vn)
                {
                    vn = lnkVoucher.Text;
                    lnkVoucher.NavigateUrl = string.Format("~/frm{0}Voucher.aspx?id={1}", row.Cells[2].Text, lnkVoucher.ToolTip);
                    lnkVoucher.ToolTip = string.Format("{0}", lnkVoucher.Text);
                }
                else
                {
                    row.Cells[0].Text = "";
                    lnkVoucher.Text = "";
                    row.Cells[2].Text = "";
                }
            }

        }
        protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            btnSearch_Click(null, null);
        }

        protected void gvData_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                string sOrder = "ASC";
                if (ViewState[e.SortExpression.Replace(".", "_")] != null)
                    sOrder = ViewState[e.SortExpression.Replace(".", "_")].ToString();

                gvData.DataSourceID = "odsCommon";
                odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @" * ";
                odsCommon.SelectParameters["FromTable"].DefaultValue = @" VW_Transactions ";
                odsCommon.SelectParameters["Where"].DefaultValue = CreateWhere();
                odsCommon.SelectParameters["OrderBy"].DefaultValue = string.Format("{0} {1}", e.SortExpression, sOrder);
                gvData.DataBind();


                ViewState[e.SortExpression.Replace(".", "_")] = sOrder == "DESC" ? "ASC" : "DESC";
                ArrangeGrid();
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
    }
}