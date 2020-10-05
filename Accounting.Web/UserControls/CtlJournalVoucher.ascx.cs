using Accounting.DataAccess;
using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;

namespace Accounting.Web.UserControls
{
    public partial class CtlJournalVoucher : System.Web.UI.UserControl
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
                            Session["JrVAccs"] = null;
                            lblTransMID.Text = "0";
                            txtApprovedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                            txtVoucherNo.Text = objDaTrans.getVoucherNo(connection, "J", Tools.Utility.IsNull<int>(Session["CompanyId"], 0));
                            txtApprovedBy.Text = Context.User.Identity.Name;
                            txtDescription.Text = "";
                            btnSave.Text = "Post";
                            chkApprovedBy.Checked = false;
                            txtTotalDrAmount.Text = string.Format("{0:0.00}", 0);
                            txtTotalCrAmount.Text = string.Format("{0:0.00}", 0);
                        }
                        else
                        {
                            lblTransMID.Text = objTransMaster.TransactionMasterID.ToString();
                            txtVoucherNo.Text = objTransMaster.VoucherNo;
                            txtDate.Text = string.Format("{0:dd/MM/yyyy}", objTransMaster.TransactionDate);
                            txtDescription.Text = objTransMaster.TransactionDescription;
                            chkApprovedBy.Checked = objTransMaster.ApprovedBy != "";
                            txtApprovedBy.Text = objTransMaster.ApprovedBy;
                            txtApprovedDate.Text = string.Format("{0:dd/MM/yyyy}", objTransMaster.ApprovedDate);
                            btnSave.Text = "Update&Post";
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

        private TransactionMaster CreateTransactionMasterObject()
        {
            TransactionMaster obj = new TransactionMaster();
            try
            {
                obj.VoucherType = (int)VoucherTypes.Journal;
                obj.VoucherNo = txtVoucherNo.Text.Trim();

                if (chkApprovedBy.Checked)
                {
                    obj.ApprovedBy = txtApprovedBy.Text;
                    obj.ApprovedDate = Tools.Utility.GetDateValue(txtApprovedDate.Text.Trim()).AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second);

                }
                else
                {
                    obj.ApprovedBy = "";
                    obj.ApprovedDate = Tools.Utility.NullDate;
                }
                obj.CompanyID = Tools.Utility.IsNull<int>(Session["CompanyId"],0);
                obj.MethodRefID = 0;
                obj.MethodRefNo = "";
                obj.ModifiedDate = DateTime.Now;
                obj.Module = "Journal Voucher";
                obj.TransactionDate = Tools.Utility.GetDateValue(txtDate.Text.Trim());
                obj.TransactionDescription = txtDescription.Text;
                obj.TransactionMethodID = 0;
                obj.TransactionMasterID = Convert.ToInt32(lblTransMID.Text);
                //obj.UserID = Tools.Utility.IsNull<Guid>(Session["UserID"], Tools.Utility.NullGuid);

                obj.VoucherPayee = "";
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }
        private TransactionDetail CreateTransactionDetailObject(int MasterID, int AccountID, double CrAmount, double DrAmount, int OppAccID, string cmnt)
        {
            TransactionDetail obj = new TransactionDetail();
            try
            {
                obj.TransactionMasterID = MasterID;
                obj.TransactionDetailID = 0;
                obj.TransactionAccountID = AccountID;
                obj.Comments = cmnt;
                obj.CreditAmount = CrAmount;
                obj.DebitAmount = DrAmount;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return obj;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (Convert.ToDouble(txtTotalDrAmount.Text) == 0 && Convert.ToDouble(txtTotalCrAmount.Text) == 0)
            //{
            //    lblMsg.Text = UIMessage.Message2User("Voucher Accounts Needed.", UserUILookType.Warning);
            //    return;
            //}
            //if (Convert.ToDouble(txtTotalDrAmount.Text) != Convert.ToDouble(txtTotalCrAmount.Text))
            //{
            //    lblMsg.Text = UIMessage.Message2User("Debit Amount and Credit Amount must be equal.", UserUILookType.Warning);
            //    return;
            //}
            //SqlTransaction trans = null;
            //try
            //{
            //    TransactionMaster objTM = CreateTransactionMasterObject();
            //    TransactionDetail objTD = new TransactionDetail();
            //    //DalTransactionMaster
            //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ERPConnectionString"].ConnectionString))
            //    {
            //        con.Open();
            //        trans = con.BeginTransaction();
            //        if (objTM.TransMID > 0)
            //            DalTransactionMaster.DeleteVoucherDetail(objTM.TransMID, con, trans);
            //        int TransMID = DalTransactionMaster.SaveAS_Transaction_Master(objTM, con, trans);
            //        string cmntDr = "", cmntCr = "";
            //        foreach (GridViewRow row in gvData.Rows)
            //        {
            //            Label lblACTitle = (Label)row.FindControl("lblACTitle");
            //            Label lblDrAmt = (Label)row.FindControl("lblDrAmt");
            //            double DrAmt = lblDrAmt.Text.Trim() == "" ? 0.0 : Convert.ToDouble(lblDrAmt.Text);

            //            if (DrAmt == 0)
            //                cmntDr += cmntDr == "" ? lblACTitle.Text : Environment.NewLine + lblACTitle.Text;
            //            else
            //                cmntCr += cmntCr == "" ? lblACTitle.Text : Environment.NewLine + lblACTitle.Text;
            //        }
            //        string cmnt = "";
            //        foreach (GridViewRow row in gvData.Rows)
            //        {
            //            Label lblAccID = (Label)row.FindControl("lblAccountID");
            //            int AccID = Convert.ToInt32(lblAccID.Text);
            //            Label lblDrAmt = (Label)row.FindControl("lblDrAmt");
            //            double DrAmt = lblDrAmt.Text.Trim() == "" ? 0.0 : Convert.ToDouble(lblDrAmt.Text);
            //            Label lblCrAmt = (Label)row.FindControl("lblCrAmt");
            //            double CrAmt = lblCrAmt.Text.Trim() == "" ? 0.0 : Convert.ToDouble(lblCrAmt.Text);
            //            if (DrAmt == 0)
            //                cmnt = cmntDr;
            //            else
            //                cmnt = cmntCr;
            //            objTD = CreateTransactionDetailObject(TransMID, AccID, CrAmt, DrAmt, 0, cmnt);
            //            int TransDID = DalTransactionDetail.SaveAS_Transaction_Detail(objTD, con, trans);

            //        }
            //        if (chkApprovedBy.Checked)
            //            DalTransactionMaster.ApprovedVoucher(TransMID, txtApprovedBy.Text, Utility.GetDateValue(txtApprovedDate.Text), con, trans);
            //        trans.Commit();
            //        con.Close();
            //        btnReset_Click(sender, e);
            //        if (btnSave.Text == "Post")
            //            lblMsg.Text = UIMessage.Message2User("Successfully posted the journal voucher", UserUILookType.Success);
            //        else
            //            lblMsg.Text = UIMessage.Message2User("Successfully changed the journal voucher", UserUILookType.Success);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (trans != null) trans.Rollback();
            //    lblMsg.Text = ex.CustomDialogMessage();
            //}
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
                    txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtTotalDrAmount.Text = "0.00";
                    txtTotalCrAmount.Text = "0.00";
                    txtAmount.Text = "";
                    gvData.DataSource = null;
                    gvData.DataBind();
                    Session["JrVAccs"] = null;
                    lblTransMID.Text = "0";
                    lblMsg.Text = "";
                    txtVoucherNo.Text = objDaTrans.getVoucherNo(connection, "J", Tools.Utility.IsNull<int>(Session["CompanyId"], 0));
                    ddlVoucherAC.Bind();
                    btnSave.Text = "Post";
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}