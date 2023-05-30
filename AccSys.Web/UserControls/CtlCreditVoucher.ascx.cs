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
    public partial class CtlCreditVoucher : System.Web.UI.UserControl
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
                            Session["CrVAccs"] = null;
                            lblTransMID.Text = "0";
                            txtApprovedDate.Text = DateTime.Now.ToString(_dateFormat);
                            txtDate.Text = DateTime.Now.ToString(_dateFormat);
                            txtVoucherNo.Text = objDaTrans.getVoucherNo(connection, "C", Tools.Utility.IsNull<int>(Session["CompanyId"], 0));
                            txtApprovedBy.Text = Context.User.Identity.Name;
                            txtDescription.Text = "";
                            txtVoucherPerson.Text = "";
                            btnSave.Text = "Post";
                            lblModule.Text = "Voucher";
                            txtTotalAmount.Text = string.Format("{0:0.00}", 0);
                            chkApprovedBy.Checked = false;
                        }
                        else
                        {
                            lblTransMID.Text = objTransMaster.TransactionMasterID.ToString();
                            txtVoucherNo.Text = objTransMaster.VoucherNo;
                            txtDate.Text = string.Format("{0:" + _dateFormat + "}", objTransMaster.TransactionDate);
                            if (objTransMaster.TransactionMethodID <= 0)
                                ddlTransMethod.SelectedIndex = 0;
                            else
                                ddlTransMethod.SelectedValue = objTransMaster.TransactionMethodID.ToString();
                            txtRefNo.Text = objTransMaster.MethodRefNo;
                            txtDescription.Text = objTransMaster.TransactionDescription;
                            txtVoucherPerson.Text = objTransMaster.VoucherPayee;
                            chkApprovedBy.Checked = objTransMaster.ApprovedBy != "";
                            txtApprovedBy.Text = objTransMaster.ApprovedBy;
                            txtApprovedDate.Text = string.Format("{0:" + _dateFormat + "}", objTransMaster.ApprovedDate);
                            btnSave.Text = "Update&Post";
                            lblModule.Text = objTransMaster.Module;
                            DataTable dtVAccs = objDaTrans.GetVoucherAccounts(connection, objTransMaster.TransactionMasterID);
                            DataTable dtCrVAccs = new DataTable();
                            dtCrVAccs.Columns.Add("TransDID", typeof(int));
                            dtCrVAccs.Columns.Add("AccountID", typeof(int));
                            dtCrVAccs.Columns.Add("AccountNo", typeof(string));
                            dtCrVAccs.Columns.Add("AccountTitle", typeof(string));
                            dtCrVAccs.Columns.Add("Amount", typeof(double));

                            double totalCrAmt = 0.0;
                            foreach (DataRow row in dtVAccs.Rows)
                            {
                                if (Tools.Utility.IsNull<double>(row["DebitAmt"], 0.0) > 0.0)
                                {
                                    lblToAccTDId.Text = row["TransDID"].ToString();
                                    ddlToAC.SelectedValue = Tools.Utility.IsNull<string>(row["AccountID"], "0");
                                    continue;
                                }
                                dtCrVAccs.Rows.Add(row["TransDID"], row["AccountID"], row["AccountNo"], row["AccountTitle"], row["CreditAmt"]);
                                totalCrAmt += Tools.Utility.IsNull<double>(row["CreditAmt"], 0.0);
                            }
                            txtTotalAmount.Text = string.Format("{0:0.00}", totalCrAmt);

                            Session["CrVAccs"] = dtCrVAccs;
                            gvData.DataSource = dtCrVAccs;
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
                DataTable dtCrVAccs = new DataTable();
                if (Session["CrVAccs"] == null)
                {
                    dtCrVAccs = new DataTable();
                    dtCrVAccs.Columns.Add("TransDID", typeof(int));
                    dtCrVAccs.Columns.Add("AccountID", typeof(int));
                    dtCrVAccs.Columns.Add("AccountNo", typeof(string));
                    dtCrVAccs.Columns.Add("AccountTitle", typeof(string));
                    dtCrVAccs.Columns.Add("Amount", typeof(double));
                }
                else
                {
                    dtCrVAccs = (DataTable)Session["CrVAccs"];
                }
                int AccID = Convert.ToInt32(ddlFromAC.SelectedValue);
                if (AccID <= 0) return;
                foreach (DataRow r in dtCrVAccs.Rows)
                {
                    if (Tools.Utility.IsNull<int>(r["AccountID"], 0) == AccID)
                    {
                        return;
                    }
                }
                dtCrVAccs.Rows.Add(0, AccID, ddlFromAC.SelectedAccountNo(), ddlFromAC.SelectedAccountTitle(), Convert.ToDouble(txtAmount.Text.Trim()));

                gvData.DataSource = dtCrVAccs;
                gvData.DataBind();
                txtAmount.Text = "";
                double totalAmt = 0.0;
                foreach (DataRow r in dtCrVAccs.Rows)
                {
                    totalAmt += Tools.Utility.IsNull<double>(r["Amount"], 0.0);

                }
                txtTotalAmount.Text = string.Format("{0:0.00}", totalAmt);
                Session["CrVAccs"] = dtCrVAccs;
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
                DataTable dtCrVAccs = (DataTable)Session["CrVAccs"];
                foreach (DataRow r in dtCrVAccs.Rows)
                {
                    if (Tools.Utility.IsNull<int>(r["AccountID"], 0) == AccID)
                    {
                        dtCrVAccs.Rows.Remove(r);
                        break;
                    }
                }
                gvData.DataSource = dtCrVAccs;
                gvData.DataBind();

                double totalAmt = 0.0;
                foreach (DataRow r in dtCrVAccs.Rows)
                {
                    totalAmt += Tools.Utility.IsNull<double>(r["Amount"], 0.0);

                }
                txtTotalAmount.Text = string.Format("{0:0.00}", totalAmt);
                Session["CrVAccs"] = dtCrVAccs;
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
                objTM.VoucherPayee = txtVoucherPerson.Text.Trim();
                objTM.VoucherType = (int)VoucherTypes.Credit;
                objTM.TransactionMethodID = Convert.ToInt32(ddlTransMethod.SelectedValue);
                objTM.MethodRefID = -1;
                objTM.MethodRefNo = txtRefNo.Text.Trim();
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
            if (ddlToAC.SelectedValue == "0")
            {
                lblMsg.Text = UIMessage.Message2User("Select an account (Received to)", UserUILookType.Warning);
                return;
            }
            if (Convert.ToDouble(txtTotalAmount.Text) <= 0)
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
                /////////////////////////////////////
                string strCmnt = "";
                foreach (GridViewRow row in gvData.Rows)
                {
                    Label lblAccTitle = (Label)row.FindControl("lblACTitle");
                    if (row.RowIndex > 0)
                        strCmnt += Environment.NewLine;
                    strCmnt += lblAccTitle.Text;
                }

                objTD = CreateTransDetailObject(0, TMID, Convert.ToInt32(ddlToAC.SelectedValue), 0, Convert.ToDouble(txtTotalAmount.Text), strCmnt);

                objDaTrans.SaveEditTransactionDetail(objTD, connection, trans);
                foreach (GridViewRow row in gvData.Rows)
                {
                    Label lblAccID = (Label)row.FindControl("lblAccountID");
                    int AccID = Convert.ToInt32(lblAccID.Text);
                    Label lblAmt = (Label)row.FindControl("lblAmt");
                    double Amt = Convert.ToDouble(lblAmt.Text);
                    objTD = CreateTransDetailObject(0, TMID, AccID, Amt, 0, ddlToAC.SelectedAccountTitle());

                    objDaTrans.SaveEditTransactionDetail(objTD, connection, trans);
                }

                trans.Commit();
                connection.Close();
                if (btnSave.Text == "Post")
                    lblMsg.Text = UIMessage.Message2User("Successfully posted the credit voucher", UserUILookType.Success);
                else
                    lblMsg.Text = UIMessage.Message2User("Successfully changed the credit voucher", UserUILookType.Success);
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
                    txtVoucherPerson.Text = "";
                    txtRefNo.Text = "";
                    txtDescription.Text = "";
                    txtVoucherPerson.Text = "";
                    txtDate.Text = DateTime.Now.ToString(_dateFormat);
                    txtTotalAmount.Text = "0.00";
                    txtAmount.Text = "";
                    gvData.DataSource = null;
                    gvData.DataBind();
                    Session["CrVAccs"] = null;
                    lblTransMID.Text = "0";
                    txtVoucherNo.Text = objDaTrans.getVoucherNo(connection, "C", Tools.Utility.IsNull<int>(Session["CompanyId"], 0));
                    ddlFromAC.Bind();
                    ddlToAC.Bind();
                    btnSave.Text = "Post";
                    lblToAccTDId.Text = "0";
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
                lblMsg.Text = UIMessage.Message2User("Successfully deleted the credit voucher", UserUILookType.Success);
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