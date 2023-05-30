using Accounting.DataAccess;
using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Tools;

namespace AccSys.Web.UserControls
{
    public partial class CtlJournalVoucher : System.Web.UI.UserControl
    {
        public int VoucherId
        {
            get { return Tools.Utility.IsNull<int>(ViewState["VoucherId"], 0); }
            set { ViewState["VoucherId"] = value; }
        }
        private string _dateFormat = "yyyy-MM-dd";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    using (var connection = new SqlConnection(ConnectionHelper.DefaultConnectionString))
                    {
                        connection.Open();
                        var objDaTrans = new DaTransaction();
                        TransactionMaster objTransMaster = null;
                        if (VoucherId > 0)
                            objTransMaster = objDaTrans.getTransMaster(connection, VoucherId);
                        if (objTransMaster == null)
                        {
                            Session["JrVAccs"] = null;
                            lblTransMID.Text = "0";
                            txtApprovedDate.Text = DateTime.Now.ToString(_dateFormat);
                            txtDate.Text = DateTime.Now.ToString(_dateFormat);
                            txtVoucherNo.Text = objDaTrans.getVoucherNo(connection, "J", Tools.Utility.IsNull<int>(Session["CompanyId"], 0));
                            txtApprovedBy.Text = Context.User.Identity.Name;
                            txtDescription.Text = "";
                            btnSave.Text = "Post";
                            lblModule.Text = "Voucher";
                            chkApprovedBy.Checked = false;
                            txtTotalDrAmount.Text = string.Format("{0:0.00}", 0);
                            txtTotalCrAmount.Text = string.Format("{0:0.00}", 0);
                        }
                        else
                        {
                            lblTransMID.Text = objTransMaster.TransactionMasterID.ToString();
                            txtVoucherNo.Text = objTransMaster.VoucherNo;
                            txtDate.Text = string.Format("{0:"+ _dateFormat + "}", objTransMaster.TransactionDate);
                            txtDescription.Text = objTransMaster.TransactionDescription;
                            chkApprovedBy.Checked = objTransMaster.ApprovedBy != "";
                            txtApprovedBy.Text = objTransMaster.ApprovedBy;
                            txtApprovedDate.Text = string.Format("{0:"+ _dateFormat + "}", objTransMaster.ApprovedDate);
                            btnSave.Text = "Update&Post";
                            lblModule.Text = objTransMaster.Module;
                            DataTable dtVAccs = objDaTrans.GetVoucherAccounts(connection, objTransMaster.TransactionMasterID);
                            DataTable dtJrVAccs = new DataTable();
                            dtJrVAccs.Columns.Add("AccountID", typeof(int));
                            dtJrVAccs.Columns.Add("AccountNo", typeof(string));
                            dtJrVAccs.Columns.Add("AccountTitle", typeof(string));
                            dtJrVAccs.Columns.Add("DrAmount", typeof(double));
                            dtJrVAccs.Columns.Add("CrAmount", typeof(double));

                            double totalDrAmt = 0.0;
                            double totalCrAmt = 0.0;
                            foreach (DataRow row in dtVAccs.Rows)
                            {
                                dtJrVAccs.Rows.Add(row["AccountID"], row["AccountNo"], row["AccountTitle"], row["DebitAmt"], row["CreditAmt"]);
                                totalDrAmt += Tools.Utility.IsNull<double>(row["DebitAmt"], 0.0);
                                totalCrAmt += Tools.Utility.IsNull<double>(row["CreditAmt"], 0.0);
                            }
                            txtTotalDrAmount.Text = string.Format("{0:0.00}", totalDrAmt);
                            txtTotalCrAmount.Text = string.Format("{0:0.00}", totalCrAmt);
                            Session["JrVAccs"] = dtJrVAccs;
                            gvData.DataSource = dtJrVAccs;
                            gvData.DataBind();
                        }
                        connection.Close();
                    }
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
                DataTable dtJrVAccs = new DataTable();
                if (Session["JrVAccs"] == null)
                {
                    dtJrVAccs = new DataTable();
                    dtJrVAccs.Columns.Add("AccountID", typeof(int));
                    dtJrVAccs.Columns.Add("AccountNo", typeof(string));
                    dtJrVAccs.Columns.Add("AccountTitle", typeof(string));
                    dtJrVAccs.Columns.Add("DrAmount", typeof(double));
                    dtJrVAccs.Columns.Add("CrAmount", typeof(double));

                }
                else
                {
                    dtJrVAccs = (DataTable)Session["JrVAccs"];
                }
                int AccID = Convert.ToInt32(ddlVoucherAC.SelectedValue);
                if (AccID <= 0) return;
                foreach (DataRow r in dtJrVAccs.Rows)
                {
                    if (Tools.Utility.IsNull<int>(r["AccountID"], 0) == AccID)
                    {
                        return;
                    }
                }
                if (ddlDrCr.SelectedValue == "Dr")
                    dtJrVAccs.Rows.Add(AccID, ddlVoucherAC.SelectedAccountNo(), ddlVoucherAC.SelectedAccountTitle(), Convert.ToDouble(txtAmount.Text.Trim()), null);
                else
                    dtJrVAccs.Rows.Add(AccID, ddlVoucherAC.SelectedAccountNo(), ddlVoucherAC.SelectedAccountTitle(), null, Convert.ToDouble(txtAmount.Text.Trim()));
                gvData.DataSource = dtJrVAccs;
                gvData.DataBind();
                txtAmount.Text = "";
                double totalDrAmt = 0.0;
                double totalCrAmt = 0.0;
                foreach (DataRow r in dtJrVAccs.Rows)
                {
                    totalDrAmt += Tools.Utility.IsNull<double>(r["DrAmount"], 0.0);
                    totalCrAmt += Tools.Utility.IsNull<double>(r["CrAmount"], 0.0);
                }
                txtTotalDrAmount.Text = string.Format("{0:0.00}", totalDrAmt);
                txtTotalCrAmount.Text = string.Format("{0:0.00}", totalCrAmt);
                Session["JrVAccs"] = dtJrVAccs;
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                Label lblAccID = (Label)((LinkButton)sender).NamingContainer.FindControl("lblAccountID");
                int AccID = Convert.ToInt32(lblAccID.Text);
                DataTable dtJrVAccs = (DataTable)Session["JrVAccs"];
                foreach (DataRow r in dtJrVAccs.Rows)
                {
                    if (Tools.Utility.IsNull<int>(r["AccountID"], 0) == AccID)
                    {
                        dtJrVAccs.Rows.Remove(r);
                        break;
                    }
                }
                gvData.DataSource = dtJrVAccs;
                gvData.DataBind();

                double totalDrAmt = 0.0;
                double totalCrAmt = 0.0;
                foreach (DataRow r in dtJrVAccs.Rows)
                {
                    totalDrAmt += Tools.Utility.IsNull<double>(r["DrAmount"], 0.0);
                    totalCrAmt += Tools.Utility.IsNull<double>(r["CrAmount"], 0.0);
                }
                txtTotalDrAmount.Text = string.Format("{0:0.00}", totalDrAmt);
                txtTotalCrAmount.Text = string.Format("{0:0.00}", totalCrAmt);
                Session["JrVAccs"] = dtJrVAccs;
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        private TransactionMaster CreateTransMasterObject()
        {
            TransactionMaster objTM = null;
            try
            {
                objTM = new TransactionMaster();
                objTM.TransactionMasterID = Convert.ToInt32(lblTransMID.Text);
                objTM.TransactionDate = Tools.Utility.GetDateValue(txtDate.Text.Trim(), DateNumericFormat.YYYYMMDD);
                objTM.VoucherNo = txtVoucherNo.Text.Trim();
                objTM.VoucherPayee = "";
                objTM.VoucherType = (int)VoucherTypes.Journal;
                objTM.TransactionMethodID = -1;
                objTM.MethodRefID = -1;
                objTM.MethodRefNo = "";
                objTM.TransactionDescription = txtDescription.Text;
                objTM.Module = "Voucher";
                if (chkApprovedBy.Checked)
                {
                    objTM.ApprovedBy = txtApprovedBy.Text;
                    objTM.ApprovedDate = Tools.Utility.GetDateValue(txtApprovedDate.Text.Trim(), DateNumericFormat.YYYYMMDD).AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second);
                }
                else
                {
                    objTM.ApprovedBy = "";
                    objTM.ApprovedDate = Tools.Utility.NullDate;
                }
                objTM.CompanyID = Tools.Utility.IsNull<int>(Session["CompanyId"], 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objTM;
        }
        private TransactionDetail CreateTransDetailObject(int TDID, int TMID, int AccountID, double CrAmt, double DrAmt, string cmnt)
        {
            TransactionDetail objTD = null;
            try
            {
                objTD = new TransactionDetail();
                objTD.TransactionDetailID = TDID;
                objTD.TransactionMasterID = TMID;
                objTD.TransactionAccountID = AccountID;
                objTD.CreditAmount = CrAmt;
                objTD.DebitAmount = DrAmt;
                objTD.Comments = cmnt; // string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objTD;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (lblModule.Text != "Voucher" && lblModule.Text != "")
            {
                lblMsg.Text = UIMessage.Message2User("You can't chnage this voucher from here. Please change it from <b>" + lblModule.Text + "</b>", UserUILookType.Danger);
                return;
            }

            if (txtTotalCrAmount.Text != txtTotalDrAmount.Text || Convert.ToDouble(txtTotalCrAmount.Text) <= 0 || Convert.ToDouble(txtTotalDrAmount.Text) <= 0)
            {
                lblMsg.Text = UIMessage.Message2User("Correctly entry the amount", UserUILookType.Warning);
                return;
            }

            SqlConnection connection = null;
            SqlTransaction trans = null;
            try
            {
                int TMID = 0;
                var objDaTrans = new DaTransaction();
                var objTM = new TransactionMaster();
                var objTD = new TransactionDetail();
                connection = new SqlConnection(ConnectionHelper.DefaultConnectionString);
                connection.Open();
                trans = connection.BeginTransaction();
                objTM = CreateTransMasterObject();
                objDaTrans.DeleteTransAccounts(connection, trans, objTM.TransactionMasterID);
                TMID = objDaTrans.SaveEditTransactionMaster(objTM, connection, trans);

                foreach (GridViewRow row in gvData.Rows)
                {
                    Label lblAccID = (Label)row.FindControl("lblAccountID");
                    int AccID = Convert.ToInt32(lblAccID.Text);
                    Label lblDrAmt = (Label)row.FindControl("lblDrAmt");
                    double drAmt = lblDrAmt.Text == "" ? 0 : Convert.ToDouble(lblDrAmt.Text);
                    Label lblCrAmt = (Label)row.FindControl("lblCrAmt");
                    double crAmt = lblCrAmt.Text == "" ? 0 : Convert.ToDouble(lblCrAmt.Text);
                    objTD = CreateTransDetailObject(0, TMID, AccID, crAmt, drAmt, "");

                    objDaTrans.SaveEditTransactionDetail(objTD, connection, trans);
                }
                trans.Commit();
                connection.Close();
                if (btnSave.Text == "Post")
                    lblMsg.Text = UIMessage.Message2User("Successfully posted the journal voucher", UserUILookType.Success);
                else
                    lblMsg.Text = UIMessage.Message2User("Successfully changed the journal voucher", UserUILookType.Success);
                btnReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                if (connection.State != ConnectionState.Closed) connection.Close();
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionHelper.DefaultConnectionString))
                {
                    connection.Open();
                    var objDaTrans = new DaTransaction();
                    txtDescription.Text = "";
                    txtDate.Text = DateTime.Now.ToString(_dateFormat);
                    txtTotalDrAmount.Text = "0.00";
                    txtTotalCrAmount.Text = "0.00";
                    txtAmount.Text = "";
                    gvData.DataSource = null;
                    gvData.DataBind();
                    Session["JrVAccs"] = null;
                    lblTransMID.Text = "0";
                    txtVoucherNo.Text = objDaTrans.getVoucherNo(connection, "J", Tools.Utility.IsNull<int>(Session["CompanyId"], 0));
                    ddlVoucherAC.Bind();
                    btnSave.Text = "Post";
                    lblModule.Text = "Voucher";
                    connection.Close();
                    if (sender.Equals(btnReset))
                    {
                        lblMsg.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int TMID = Convert.ToInt32(lblTransMID.Text);
            if (TMID <= 0)
            {
                return;
            }
            if (lblModule.Text != "Voucher" && lblModule.Text != "")
            {
                lblMsg.Text = UIMessage.Message2User("You can't delete this voucher from here. Please delete it from <b>" + lblModule.Text + "</b>", UserUILookType.Danger);
                return;
            }
            SqlConnection connection = null;
            SqlTransaction trans = null;
            try
            {
                var objDaTrans = new DaTransaction();
                connection = new SqlConnection(ConnectionHelper.DefaultConnectionString);
                connection.Open();
                trans = connection.BeginTransaction();
                objDaTrans.DeleteTransaction(TMID, connection, trans);
                trans.Commit();
                connection.Close();
                lblMsg.Text = UIMessage.Message2User("Successfully deleted the debit voucher", UserUILookType.Success);
                btnReset_Click(sender, e);

            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                if (connection.State != ConnectionState.Closed) connection.Close();
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}