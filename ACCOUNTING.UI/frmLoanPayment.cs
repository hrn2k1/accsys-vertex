using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Utility;
using Accounting.Entity;
using Accounting.DataAccess;
using System.Data.SqlClient;

namespace Accounting.UI
{
    public partial class frmLoanPayment : Form
    {
        SqlConnection conn = null;
        public frmLoanPayment()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoanPayment_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                FormColorClass.ColorForm(this, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadPaymentMethod()
        {
            DataTable dt = new DataTable();
            DaLoan objdaloan = new DaLoan();
            try
            {
                dt = objdaloan.GetPayMethod(conn);

                cmbPayMethod.DataSource = dt;
                cmbPayMethod.DisplayMember = "TransMethod";
                cmbPayMethod.ValueMember = "TransMethodID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmLoanPayment_Load(object sender, EventArgs e)
        {
            conn = ConnectionHelper.getConnection();
            LoadPaymentMethod();
        }

        private void txtLoanID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtLoanID.Text == "" || txtLoanID.Text == "0") return;
                int loanId = Convert.ToInt32(txtLoanID.Text);
                loadLoan(loanId,DTPPayDate.Value.Date);
                loadLoanAdjust(loanId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbPayMethod_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPayMethod.SelectedValue == null || cmbPayMethod.SelectedValue.GetType() == typeof(DataRowView)) return;
                switch ((int)cmbPayMethod.SelectedValue)
                {
                    case 1: txtChequeLCNo.Enabled = false; dtpAcceptDate.Enabled = false; break;
                    case 2: lblRefNo.Text = "Cheque No."; txtChequeLCNo.Enabled = true; dtpAcceptDate.Enabled = false; break;
                    case 3: lblRefNo.Text = "DD/TT No."; txtChequeLCNo.Enabled = true; dtpAcceptDate.Enabled = true; break;
                    case 4: lblRefNo.Text = "LC No."; txtChequeLCNo.Enabled = true; dtpAcceptDate.Enabled = false; break;
                    //case 3: lblRefNo.Text = "LC No."; txtChequeLCNo.Enabled = true; dtpAcceptDate.Enabled = true; break;
                    //case 4: lblRefNo.Text = "Cheque No."; txtChequeLCNo.Enabled = true; dtpAcceptDate.Enabled = false; break;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //dtpMaturityDate.Enabled = false; 
        }

        private void txtChequeLCNo_Enter(object sender, EventArgs e)
        {

        }
        private bool validation()
        {
            if (txtLoanNo.Text.Trim() == "")
            {
                MessageBox.Show("Please select a loan No first");
                return false;
            }
            if (txtPayNow.Value <= 0)
            {
                MessageBox.Show("Please insert a valid amount");
                return false;
            }
            return true;
        }
        private void btnPost_Click(object sender, EventArgs e)
        {
            if (validation() == false) return;
            if (MessageBox.Show("Are you sure to psted", "Conformation Message", MessageBoxButtons.YesNo) == DialogResult.No) return;
            DaTransaction objDaTrans = new DaTransaction();
            DaLoan obDaLoan = new DaLoan();
            TransactionMaster obTransMaster = new TransactionMaster();
            TransactionDetail obTransactionDetail = new TransactionDetail();
            SqlTransaction trans = null;
            LoanAdjust obloanAdjust = new LoanAdjust();
            int TransMid = 0, TransDID = 0;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                trans = conn.BeginTransaction();

                //Save UpDate TransMaster
                string VNo = objDaTrans.getVoucherNo(conn, trans, "J");
                obTransMaster = createTransMaster(VNo);
                TransMid = objDaTrans.SaveEditTransactionMaster(obTransMaster, conn, trans);

                //Save UpDate TransDetail

                //######## Credit ***********
                int AccountId=0;
                double AdjustAmt = 0;
                AdjustAmt = txtPayNow.Value;

                AccountId = ((Account)txtPayFromAcc.Tag).AccountID;
                TransDID = objDaTrans.getTransDID(conn, trans, TransMid, AccountId);
                obTransactionDetail = CreateTransDetailObject(TransDID, TransMid, AccountId, AdjustAmt, 0);
                objDaTrans.SaveEditTransactionDetail(obTransactionDetail, conn, trans);
                ////********* Debit **********
                AccountId = Convert.ToInt32(txtLoanAccID.Text);
                TransDID = objDaTrans.getTransDID(conn, trans, TransMid, AccountId);
                obTransactionDetail = CreateTransDetailObject(TransDID, TransMid, AccountId, 0, AdjustAmt);
                objDaTrans.SaveEditTransactionDetail(obTransactionDetail, conn, trans);

                //////// ********** Save Update Loan Adjustment ***********///////
                obloanAdjust = createLoanAdjust(TransMid,AdjustAmt);
                obDaLoan.SaveUpdateLoanAdjust(obloanAdjust, conn, trans);
                trans.Commit();
                MessageBox.Show("posted Successfully");
                
                int loanId = ctlDGVLoan.Rows[0].Cells["LoanID"].Value == DBNull.Value ? 0 : Convert.ToInt32(ctlDGVLoan.Rows[0].Cells["LoanID"].Value);
                loadLoanAdjust(loanId);
                loadLoan(loanId,DateTime.Now.Date);
                /*
                dtloanAdjust = obDaLoan.loadLoanPayment(conn, loanId);
                dgvLoanAdjust.DataSource = dtloanAdjust;
                 * */
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }
        private LoanAdjust createLoanAdjust(int TransRefID,double AdjustAmount)
        {
            LoanAdjust obLoanAdjust = null;
            try
            {
                obLoanAdjust = new LoanAdjust();
                obLoanAdjust.AdjustAmount = AdjustAmount;
                obLoanAdjust.AdjustDate = DTPPayDate.Value.Date;
                obLoanAdjust.AdjustMethodID = (int)cmbPayMethod.SelectedValue;
                obLoanAdjust.AdjustRefNo = txtChequeLCNo.Text.ToString();
                obLoanAdjust.LoanAdjustID = Convert.ToInt32(txtLoanAdjustID.Text);
                obLoanAdjust.LoanID = ctlDGVLoan.Rows[0].Cells["LoanID"].Value == DBNull.Value ? 0 : Convert.ToInt32(ctlDGVLoan.Rows[0].Cells["LoanID"].Value);
                obLoanAdjust.PayFrom = ((Account)txtPayFromAcc.Tag).AccountID;
                obLoanAdjust.Remarks = txtRemarks.Text.ToString();
                obLoanAdjust.TransRefID = TransRefID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obLoanAdjust;
        }
        private TransactionMaster createTransMaster(string VNo)
        {
            TransactionMaster obtransMaster = new TransactionMaster();
            try
            {
                obtransMaster.TransactionMasterID = 0;
                obtransMaster.TransactionDate = DTPPayDate.Value.Date;
                obtransMaster.VoucherNo = VNo;
                obtransMaster.VoucherPayee = "";
                obtransMaster.VoucherType = 3;
                obtransMaster.TransactionMethodID = (int)cmbPayMethod.SelectedValue;
                obtransMaster.MethodRefID = -1;
                obtransMaster.MethodRefNo = txtChequeLCNo.Text.Trim();
                obtransMaster.TransactionDescription = txtRemarks.Text;
                obtransMaster.ApprovedBy = "";
                obtransMaster.ApprovedDate = DTPPayDate.Value.Date;
                obtransMaster.Module = "Loan Payment";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obtransMaster;
        }
        
        private TransactionDetail CreateTransDetailObject(int TDID, int TMID, int AccountID, double CrAmt, double DrAmt)
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
                objTD.Comments = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objTD;
        }
        private void loadLoan(int LoanId,DateTime payDate)
        {
            DataTable dtLoan = new DataTable();
            DaLoan obDaLoan = new DaLoan();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtLoan = obDaLoan.loadLoan(conn, LoanId,payDate);
                ctlDGVLoan.DataSource = dtLoan;
                ctlDGVLoan.setColumnsVisible(false, "LoanID", "RefAccID", "ApplyDate",/* "SanktionDate", "InterestRate",*/ "ExpireDate", "LoanAccID", "LCID", "TransRefID", "Rate", "Remarks", "CompanyID", "AcceptedPercent");
                ctlDGVLoan.setColumnsFormat(new string[] { "Interest", "DueAmount", "LoanAmount", "InterestRate", "SanktionDate", "ExpireDate"}, "0.00", "0.00", "0.00", "0.00", "dd/MM/yyyy", "dd/MM/yyyy");
                txtDueAmount.Value =Math.Round( Convert.ToDouble(dtLoan.Rows[0].Field<object>("DueAmount")) + Convert.ToDouble(dtLoan.Rows[0].Field<object>("Interest")));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void loadLoanAdjust(int loanId)
        {
            DataTable dtloanAdjust = new DataTable();
            DaLoan obDaLoan = new DaLoan();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtloanAdjust = obDaLoan.loadLoanPayment(conn, loanId);
                dgvLoanAdjust.DataSource = dtloanAdjust;
                dgvLoanAdjust.setColumnsVisible(false, "LoanAdjustID", "LoanID", "AdjustMethodID", "PayFrom", "TransRefID");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (dgvLoanAdjust.Rows.Count == 0) return;
                if (dgvLoanAdjust.CurrentRow == null)
                {
                    MessageBox.Show("Please Select A Row");
                    return;
                }
                int RowID = dgvLoanAdjust.CurrentRow.Index;
                int LoanAdjID =GlobalFunctions.isNull( dgvLoanAdjust.Rows[RowID].Cells["LoanAdjustID"].Value,0);
                DaLoan DAobjLoan = new DaLoan();
                
                DAobjLoan.DeleteLoanAdjust(LoanAdjID,conn);
                
                MessageBox.Show("Deleted Successfully");
                int loanId = ctlDGVLoan.Rows[0].Cells["LoanID"].Value == DBNull.Value ? 0 : Convert.ToInt32(ctlDGVLoan.Rows[0].Cells["LoanID"].Value);
                loadLoanAdjust(loanId);
                loadLoan(loanId,DateTime.Now.Date);
              
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLoanPayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(conn);
        }

        private void txtLoanNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmLoanSearch objfrm = new frmLoanSearch();
                    objfrm.ShowDialog();
                    Loan obLoan = new Loan();
                    Account objAccount = new Account();
                    DaAccount objDaAccount = new DaAccount();
                    obLoan = objfrm.ReturnLoan();
                    if (obLoan == null) return;

                    else
                    {
                        txtLoanNo.Text = obLoan.LoanNo.ToString();
                        txtLoanID.Text = obLoan.LoanID.ToString();
                        //txtLoanAccID.Text = obLoan.LoanAccID.ToString();
                        txtLoanAccID.Text = obLoan.RefAccID.ToString();
                        //txtDueAmount.Value = obLoan.DueAmount;
                        int ab = int.Parse(txtLoanAccID.Text);
                        objAccount = objDaAccount.GetAccount(conn, ab);
                        txtLoanAccount.Text = objAccount.AccountTitle.ToString();
                    }
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ctl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtPayFromAcc_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TextBox txtAC = (TextBox)sender;


                    frmAccountSearch frm = new frmAccountSearch();
                    if (txtAC.Tag == null)
                        frm.ShowDialog();
                    else
                    {
                        Account acc = (Account)txtAC.Tag;
                        frm.ShowDialog(acc.AccountID);
                    }
                    Account objSelectedAcc = frm.SelectedAccount;
                    if (objSelectedAcc == null) return;

                    txtAC.Text = objSelectedAcc.AccountTitle;
                    txtAC.Tag = objSelectedAcc;
                    SelectNextControl((Control)sender, true, true, true, true);
                    if (sender.Equals(txtPayFromAcc)) return;
                    //loadBills(objSelectedAcc.AccountID, chkAll.Checked);
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbPayMethod_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            Control conl = (Control)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void DTPPayDate_ValueChanged(object sender, EventArgs e)
        {
            txtLoanID_TextChanged(sender, null);
        }
    }
}
