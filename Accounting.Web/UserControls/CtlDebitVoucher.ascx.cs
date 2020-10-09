﻿using Accounting.DataAccess;
using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Tools;

namespace Accounting.Web.UserControls
{
    public partial class CtlDebitVoucher : System.Web.UI.UserControl
    {
        public int VoucherId
        {
            get { return Tools.Utility.IsNull<int>(ViewState["VoucherId"], 0); }
            set { ViewState["VoucherId"] = value; }
        }
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
                            Session["DrVAccs"] = null;
                            lblTransMID.Text = "0";
                            txtApprovedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                            txtVoucherNo.Text = objDaTrans.getVoucherNo(connection, "D", Tools.Utility.IsNull<int>(Session["CompanyId"], 0));
                            txtApprovedBy.Text = Context.User.Identity.Name;
                            txtDescription.Text = "";
                            txtVoucherPerson.Text = "";
                            btnSave.Text = "Post";
                            chkApprovedBy.Checked = false;
                            txtTotalAmount.Text = string.Format("{0:0.00}", 0);
                        }
                        else
                        {
                            lblTransMID.Text = objTransMaster.TransactionMasterID.ToString();
                            txtVoucherNo.Text = objTransMaster.VoucherNo;
                            txtDate.Text = string.Format("{0:dd/MM/yyyy}", objTransMaster.TransactionDate);
                            ddlTransMethod.SelectedValue = objTransMaster.TransactionMethodID.ToString();
                            txtRefNo.Text = objTransMaster.MethodRefNo;
                            txtDescription.Text = objTransMaster.TransactionDescription;
                            txtVoucherPerson.Text = objTransMaster.VoucherPayee;
                            chkApprovedBy.Checked = objTransMaster.ApprovedBy != "";
                            txtApprovedBy.Text = objTransMaster.ApprovedBy;
                            txtApprovedDate.Text = string.Format("{0:dd/MM/yyyy}", objTransMaster.ApprovedDate);
                            btnSave.Text = "Update&Post";
                            DataTable dtVAccs = objDaTrans.GetVoucherAccounts(connection, objTransMaster.TransactionMasterID);
                            DataTable dtDrVAccs = new DataTable();
                            dtDrVAccs.Columns.Add("AccountID", typeof(int));
                            dtDrVAccs.Columns.Add("AccountNo", typeof(string));
                            dtDrVAccs.Columns.Add("AccountTitle", typeof(string));
                            dtDrVAccs.Columns.Add("Amount", typeof(double));

                            double totalDrAmt = 0.0;

                            foreach (DataRow row in dtVAccs.Rows)
                            {
                                if (Tools.Utility.IsNull<double>(row["CreditAmt"], 0.0) > 0.0)
                                {
                                    ddlPaidFromAC.SelectedValue = Tools.Utility.IsNull<string>(row["AccountID"], "0");
                                    continue;
                                }
                                dtDrVAccs.Rows.Add(row["AccountID"], row["AccountNo"], row["AccountTitle"], row["DebitAmt"]);
                                totalDrAmt += Tools.Utility.IsNull<double>(row["DebitAmt"], 0.0);
                            }
                            txtTotalAmount.Text = string.Format("{0:0.00}", totalDrAmt);

                            Session["DrVAccs"] = dtDrVAccs;
                            gvData.DataSource = dtDrVAccs;
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
                DataTable dtDrVAccs = new DataTable();
                if (Session["DrVAccs"] == null)
                {
                    dtDrVAccs = new DataTable();
                    dtDrVAccs.Columns.Add("AccountID", typeof(int));
                    dtDrVAccs.Columns.Add("AccountNo", typeof(string));
                    dtDrVAccs.Columns.Add("AccountTitle", typeof(string));
                    dtDrVAccs.Columns.Add("Amount", typeof(double));
                }
                else
                {
                    dtDrVAccs = (DataTable)Session["DrVAccs"];
                }
                int AccID = Convert.ToInt32(ddlPaidForAC.SelectedValue);
                if (AccID <= 0) return;
                foreach (DataRow r in dtDrVAccs.Rows)
                {
                    if (Tools.Utility.IsNull<int>(r["AccountID"], 0) == AccID)
                    {
                        return;
                    }
                }
                dtDrVAccs.Rows.Add(AccID, ddlPaidForAC.SelectedAccountNo(), ddlPaidForAC.SelectedAccountTitle(), Convert.ToDouble(txtAmount.Text.Trim()));

                gvData.DataSource = dtDrVAccs;
                gvData.DataBind();
                txtAmount.Text = "";
                double totalAmt = 0.0;
                foreach (DataRow r in dtDrVAccs.Rows)
                {
                    totalAmt += Tools.Utility.IsNull<double>(r["Amount"], 0.0);

                }
                txtTotalAmount.Text = string.Format("{0:0.00}", totalAmt);
                Session["DrVAccs"] = dtDrVAccs;
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
                DataTable dtDrVAccs = (DataTable)Session["DrVAccs"];
                foreach (DataRow r in dtDrVAccs.Rows)
                {
                    if (Tools.Utility.IsNull<int>(r["AccountID"], 0) == AccID)
                    {
                        dtDrVAccs.Rows.Remove(r);
                        break;
                    }
                }
                gvData.DataSource = dtDrVAccs;
                gvData.DataBind();

                double totalAmt = 0.0;
                foreach (DataRow r in dtDrVAccs.Rows)
                {
                    totalAmt += Tools.Utility.IsNull<double>(r["Amount"], 0.0);

                }
                txtTotalAmount.Text = string.Format("{0:0.00}", totalAmt);
                Session["DrVAccs"] = dtDrVAccs;
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
                objTM.TransactionDate = Tools.Utility.GetDateValue(txtDate.Text.Trim());
                objTM.VoucherNo = txtVoucherNo.Text.Trim();
                objTM.VoucherPayee = txtVoucherPerson.Text.Trim();
                objTM.VoucherType = (int)VoucherTypes.Debit;
                objTM.TransactionMethodID = Convert.ToInt32(ddlTransMethod.SelectedValue);
                objTM.MethodRefID = -1;
                objTM.MethodRefNo = txtRefNo.Text.Trim();
                objTM.TransactionDescription = txtDescription.Text;
                objTM.Module = "Voucher";
                if (chkApprovedBy.Checked)
                {
                    objTM.ApprovedBy = txtApprovedBy.Text;
                    objTM.ApprovedDate = Tools.Utility.GetDateValue(txtApprovedDate.Text.Trim()).AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second);
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
            if (ddlPaidFromAC.SelectedValue == "0")
            {
                lblMsg.Text = UIMessage.Message2User("Select an account (Paid from)", UserUILookType.Warning);
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

                objTD = CreateTransDetailObject(0, TMID, Convert.ToInt32(ddlPaidFromAC.SelectedValue), Convert.ToDouble(txtTotalAmount.Text), 0, strCmnt);

                objDaTrans.SaveEditTransactionDetail(objTD, connection, trans);
                foreach (GridViewRow row in gvData.Rows)
                {
                    Label lblAccID = (Label)row.FindControl("lblAccountID");
                    int AccID = Convert.ToInt32(lblAccID.Text);
                    Label lblAmt = (Label)row.FindControl("lblAmt");
                    double Amt = Convert.ToDouble(lblAmt.Text);
                    objTD = CreateTransDetailObject(0, TMID, AccID, 0, Amt, ddlPaidFromAC.SelectedAccountTitle());

                    objDaTrans.SaveEditTransactionDetail(objTD, connection, trans);
                }

                trans.Commit();
                connection.Close();
                if (btnSave.Text == "Post")
                    lblMsg.Text = UIMessage.Message2User("Successfully posted the debit voucher", UserUILookType.Success);
                else
                    lblMsg.Text = UIMessage.Message2User("Successfully changed the debit voucher", UserUILookType.Success);
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
                    txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtTotalAmount.Text = "0.00";
                    txtAmount.Text = "";
                    gvData.DataSource = null;
                    gvData.DataBind();
                    Session["DrVAccs"] = null;
                    lblTransMID.Text = "0";
                    txtVoucherNo.Text = objDaTrans.getVoucherNo(connection, "D", Tools.Utility.IsNull<int>(Session["CompanyId"], 0));
                    ddlPaidForAC.Bind();
                    ddlPaidFromAC.Bind();
                    btnSave.Text = "Post";
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
    }
}