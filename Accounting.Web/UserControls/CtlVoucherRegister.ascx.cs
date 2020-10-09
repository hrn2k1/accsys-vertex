using Accounting.DataAccess;
using System;
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
                txtFromDate.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(-7));
                txtToDate.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                btnSearch_Click(null, null);
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
                if (ddlAccount.SelectedValue != "0" && ddlAccount.SelectedValue != "")
                    where += (where != "" ? " AND " : "") + string.Format(" TransMID IN (SELECT TransMID FROM T_Transaction_Detail WHERE AccountID={0}) ", ddlAccount.SelectedValue);
                if (ddlVoucherType.SelectedValue != "0" && ddlVoucherType.SelectedValue != "")
                    where += (where != "" ? " AND " : "") + string.Format(" VoucherType={0} ", ddlVoucherType.SelectedValue);
                if (!string.IsNullOrWhiteSpace(txtVoucherNo.Text))
                {
                    where += (where != "" ? " AND " : "") + string.Format(" VoucherNo LIKE '{0}' ", txtVoucherNo.Text.Trim());
                }

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
                int top = Convert.ToInt32(ddlTop.SelectedItem.Value);
                var dtVouchers = DaTransaction.SearchVouchers(top, CreateWhere(), null, " TransMID, TransDate, VoucherNo, VoucherType, AccountNo, AccountTitle, DebitAmt, CreditAmt ");
                gvData.DataSource = dtVouchers;
                gvData.DataBind();
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
            int voucherNo = 0;
            foreach (GridViewRow row in gvData.Rows)
            {
                if (row.Cells[7].Text == "0.00") row.Cells[7].Text = "";
                if (row.Cells[8].Text == "0.00") row.Cells[8].Text = "";
                HyperLink lnkVoucher = (HyperLink)row.Cells[2].FindControl("lnkVoucher");
                if (lnkVoucher.Text != vn)
                {
                    row.CssClass = "row voucher";
                    row.Cells[0].Text = (++voucherNo).ToString();
                    vn = lnkVoucher.Text;
                    lnkVoucher.NavigateUrl = string.Format("~/frm{0}Voucher.aspx?id={1}", row.Cells[3].Text, lnkVoucher.ToolTip);
                    lnkVoucher.ToolTip = string.Format("{0}", lnkVoucher.Text);
                }
                else
                {
                    row.Cells[0].Text = "";
                    row.Cells[1].Text = "";
                    lnkVoucher.Text = "";
                    row.Cells[3].Text = "";
                }
            }

        }

        
        protected void gvData_DataBound(object sender, EventArgs e)
        {
            ArrangeGrid();
        }
    }
}