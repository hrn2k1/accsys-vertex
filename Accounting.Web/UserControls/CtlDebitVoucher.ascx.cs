using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
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
                    if (VoucherId == 0)
                    {
                        Session["DrVAccs"] = null;
                        txtApprovedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        //txtVoucherNo.Text = DalTransactionMaster.GenerateVoucherNo("D", Session.CompanyId());
                        txtApprovedBy.Text = Context.User.Identity.Name;
                        txtDescription.Text = "";
                        btnSave.Text = "Post";

                        txtTotalAmount.Text = string.Format("{0:0.00}", 0);
                    }
                    else
                    {
                        TransactionMaster objTransMaster = null; // DalTransactionMaster.getAS_Transaction_Master(string.Format("TransMID={0}", VoucherId));
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

        private TransactionMaster CreateTransactionMasterObject()
        {
            TransactionMaster obj = new TransactionMaster();
            try
            {
                obj.VoucherType = (int)VoucherTypes.Debit;
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
                obj.CompanyID = Tools.Utility.IsNull<int>(Session["CompanyId"], 0);
                obj.MethodRefID = 0;
                obj.MethodRefNo = txtRefNo.Text.Trim();
                obj.ModifiedDate = DateTime.Now;
                obj.Module = "Debit Voucher";
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
            //    lblMsg.Text = UIMessage.Message2User("Paid For Accounts Needed.", UserUILookType.Warning);
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
            //        string cmnt = "";
            //        foreach (GridViewRow row in gvData.Rows)
            //        {
            //            Label lblACTitle = (Label)row.FindControl("lblACTitle");
            //            cmnt += cmnt == "" ? lblACTitle.Text : Environment.NewLine + lblACTitle.Text;
            //        }
            //        objTD = CreateTransactionDetailObject(TransMID, Convert.ToInt32(ddlPaidFromAC.SelectedValue), Convert.ToDouble(txtTotalAmount.Text), 0.0, 0, cmnt);
            //        int TransDID = DalTransactionDetail.SaveAS_Transaction_Detail(objTD, con, trans);
            //        foreach (GridViewRow row in gvData.Rows)
            //        {
            //            Label lblAccID = (Label)row.FindControl("lblAccountID");
            //            int AccID = Convert.ToInt32(lblAccID.Text);
            //            Label lblAmt = (Label)row.FindControl("lblAmt");
            //            double Amt = Convert.ToDouble(lblAmt.Text);

            //            objTD = CreateTransactionDetailObject(TransMID, AccID, 0.0, Amt, Convert.ToInt32(ddlPaidFromAC.SelectedValue), ddlPaidFromAC.SelectedItem.Text);
            //            TransDID = DalTransactionDetail.SaveAS_Transaction_Detail(objTD, con, trans);

            //        }
            //        if (chkApprovedBy.Checked)
            //            DalTransactionMaster.ApprovedVoucher(TransMID, txtApprovedBy.Text, Utility.GetDateValue(txtApprovedDate.Text), con, trans);
            //        trans.Commit();
            //        con.Close();
            //        btnReset_Click(sender, e);
            //        if (btnSave.Text == "Post")
            //            lblMsg.Text = UIMessage.Message2User("Successfully posted the debit voucher", UserUILookType.Success);
            //        else
            //            lblMsg.Text = UIMessage.Message2User("Successfully changed the debit voucher", UserUILookType.Success);
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
                Session["DrVAccs"] = null;
                lblTransMID.Text = "0";
                lblMsg.Text = "";
                //txtVoucherNo.Text = DalTransactionMaster.GenerateVoucherNo("D", Session.CompanyId());
                ddlPaidForAC.Bind();
                ddlPaidFromAC.Bind();
                btnSave.Text = "Post";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}