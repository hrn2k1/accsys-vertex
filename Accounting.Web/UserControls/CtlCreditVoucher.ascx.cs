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
    public partial class CtlCreditVoucher : System.Web.UI.UserControl
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
                    if (VoucherId == 0)
                    {
                        Session["CrVAccs"] = null;
                        txtApprovedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        //txtVoucherNo.Text = new DaTransaction().GenerateVoucherNo("C", Session.CompanyId());
                        txtApprovedBy.Text = Context.User.Identity.Name;
                        txtDescription.Text = "";
                        btnSave.Text = "Post";

                        txtTotalAmount.Text = string.Format("{0:0.00}", 0);

                    }
                    else
                    {
                        TransactionMaster objTransMaster = null; // DaTransaction.getAS_Transaction_Master(string.Format("TransMID={0}", VoucherId));
                        lblTransMID.Text = VoucherId.ToString();
                        txtVoucherNo.Text = objTransMaster.VoucherNo;
                        txtDate.Text = string.Format("{0:dd/MM/yyyy}", objTransMaster.TransactionDate);
                        ddlTransMethod.SelectedValue = objTransMaster.TransactionMethodID.ToString();
                        txtRefNo.Text = objTransMaster.MethodRefNo;
                        txtDescription.Text = objTransMaster.TransactionDescription;
                        chkApprovedBy.Checked = objTransMaster.ApprovedBy != "";
                        txtApprovedBy.Text = objTransMaster.ApprovedBy;
                        txtApprovedDate.Text = string.Format("{0:dd/MM/yyyy}", objTransMaster.ApprovedDate);
                        btnSave.Text = "Change";
                        DataTable dtVAccs = new DataTable(); // DalTransactionDetail.getVoucherAccounts(VoucherId);
                        DataTable dtCrVAccs = new DataTable();
                        dtCrVAccs.Columns.Add("AccountID", typeof(int));
                        dtCrVAccs.Columns.Add("AccountNo", typeof(string));
                        dtCrVAccs.Columns.Add("AccountTitle", typeof(string));
                        dtCrVAccs.Columns.Add("Amount", typeof(double));


                        double totalCrAmt = 0.0;

                        foreach (DataRow row in dtVAccs.Rows)
                        {
                            if (Tools.Utility.IsNull<double>(row["DebitAmt"], 0.0) > 0.0)
                            {
                                ddlToAC.SelectedValue = Tools.Utility.IsNull<string>(row["AccountID"], "0");
                                continue;
                            }
                            dtCrVAccs.Rows.Add(row["AccountID"], row["AccountNo"], row["AccountTitle"], row["CreditAmt"]);
                            totalCrAmt += Tools.Utility.IsNull<double>(row["CreditAmt"], 0.0);

                        }
                        txtTotalAmount.Text = string.Format("{0:0.00}", totalCrAmt);

                        Session["CrVAccs"] = dtCrVAccs;
                        gvData.DataSource = dtCrVAccs;
                        gvData.DataBind();
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
                foreach (DataRow r in dtCrVAccs.Rows)
                {
                    if (Tools.Utility.IsNull<int>(r["AccountID"], 0) == AccID)
                    {
                        return;
                    }
                }
                dtCrVAccs.Rows.Add(AccID, ddlFromAC.SelectedAccountNo(), ddlFromAC.SelectedAccountTitle(), Convert.ToDouble(txtAmount.Text.Trim()));

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

        private TransactionMaster CreateTransactionMasterObject()
        {
            TransactionMaster obj = new TransactionMaster();
            try
            {
                obj.VoucherType = (int)VoucherTypes.Credit;
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
                obj.CompanyID = Tools.Utility.IsNull<int>(Session["CompanyID"], 0);
                obj.MethodRefID = 0;
                obj.MethodRefNo = txtRefNo.Text.Trim();
                obj.ModifiedDate = DateTime.Now;
                obj.Module = "Credit Voucher";
                obj.TransactionDate = Tools.Utility.GetDateValue(txtDate.Text.Trim());
                obj.TransactionDescription = txtDescription.Text;
                obj.TransactionMethodID = Convert.ToInt32(ddlTransMethod.SelectedValue);
                obj.TransactionMasterID = Convert.ToInt32(lblTransMID.Text);
                //obj.UserID = Tools.Utility.IsNull<Guid>(Session["UserID"], Tools.Utility.NullGuid);

                obj.VoucherPayee = txtVoucherPerson.Text.Trim();
                
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
            //if (Convert.ToDouble(txtTotalAmount.Text) == 0)
            //{
            //    lblMsg.Text = UIMessage.Message2User("Collected From Accounts Needed.", UserUILookType.Warning);
            //    return;
            //}
            //SqlTransaction trans = null;
            //try
            //{
            //    TransactionMaster objTM = CreateTransactionMasterObject();
            //    TransactionDetail objTD = new TransactionDetail();
            //    //DalTransactionMaster
            //    using (SqlConnection con = ConnectionHelper.getConnection())
            //    {
            //        con.Open();
            //        trans = con.BeginTransaction();
            //        if (objTM.TransactionMasterID > 0)
            //            DaTransaction.DeleteVoucherDetail(objTM.TransMID, con, trans);
            //        int TransMID = DalTransactionMaster.SaveAS_Transaction_Master(objTM, con, trans);
            //        string cmnt = "";
            //        foreach (GridViewRow row in gvData.Rows)
            //        {
            //            Label lblACTitle = (Label)row.FindControl("lblACTitle");
            //            cmnt += cmnt == "" ? lblACTitle.Text : Environment.NewLine + lblACTitle.Text;
            //        }
            //        objTD = CreateTransactionDetailObject(TransMID, Convert.ToInt32(ddlToAC.SelectedValue), 0.0, Convert.ToDouble(txtTotalAmount.Text), 0, cmnt);
            //        int TransDID = DalTransactionDetail.SaveAS_Transaction_Detail(objTD, con, trans);
            //        foreach (GridViewRow row in gvData.Rows)
            //        {
            //            Label lblAccID = (Label)row.FindControl("lblAccountID");
            //            int AccID = Convert.ToInt32(lblAccID.Text);
            //            Label lblAmt = (Label)row.FindControl("lblAmt");
            //            double Amt = Convert.ToDouble(lblAmt.Text);

            //            objTD = CreateTransactionDetailObject(TransMID, AccID, Amt, 0.0, Convert.ToInt32(ddlToAC.SelectedValue), ddlToAC.SelectedItem.Text);
            //            TransDID = DalTransactionDetail.SaveAS_Transaction_Detail(objTD, con, trans);

            //        }
            //        if (chkApprovedBy.Checked)
            //            DalTransactionMaster.ApprovedVoucher(TransMID, txtApprovedBy.Text, Utility.GetDateValue(txtApprovedDate.Text), con, trans);
            //        trans.Commit();
            //        con.Close();
            //        btnReset_Click(sender, e);
            //        if (btnSave.Text == "Post")
            //            lblMsg.Text = UIMessage.Message2User("Successfully posted the credit voucher", UserUILookType.Success);
            //        else
            //            lblMsg.Text = UIMessage.Message2User("Successfully changed the credit voucher", UserUILookType.Success);
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
                txtVoucherPerson.Text = "";
                txtRefNo.Text = "";
                txtDescription.Text = "";
                txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtTotalAmount.Text = "0.00";
                txtAmount.Text = "";
                gvData.DataSource = null;
                gvData.DataBind();
                Session["CrVAccs"] = null;
                lblTransMID.Text = "0";
                lblMsg.Text = "";
                //txtVoucherNo.Text = DalTransactionMaster.GenerateVoucherNo("C", Tools.Utility.IsNull<int>(Session["CompanyID"], 0));
                ddlFromAC.Bind();
                ddlToAC.Bind();
                btnSave.Text = "Post";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}