using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Entity;
using Accounting.DataAccess;
using System.Data.SqlClient;
using Accounting.Utility;
namespace Accounting.UI
{
    public partial class frmLoan : Form
    {
        SqlConnection conn = ConnectionHelper.getConnection();
         private DaTransaction obDaTrans = null;
         DataTable dt = new DataTable();
         private Loan objloan = new Loan();
        //LC_Master objlcmaster = null;
         int LCID = 0;
         string sLcType = "";
         double Acceptvalue = 0, LoanTaken = 0, MaxValue = 0;
         public frmLoan()
         {
             InitializeComponent();
         }

         private void btnCancel_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void LoadLoan()
         {
             try
             {
                 DaLoan objloan = new DaLoan();
                 DataTable dtt = new DataTable();
                 string loan,lc;
                 DateTime sDate,eDate;
                 if(chkLoanNo.Checked) loan=txtLoanNoLike.Text ; else loan ="";
                 if(chkLC.Checked) lc=txtLcNoLike.Text; else lc="";
                 if(chkDate.Checked==false)
                 {
                     sDate=new DateTime(1900,1,1);
                     eDate=new DateTime(1900,1,1);
                 }
                 else
                 {
                     sDate=dtpSdate.Value.Date;
                     eDate=dtpEdate.Value.Date;
                 }
                 dtt = objloan.GetLoanInfo(conn,loan,lc,sDate,eDate);
                 ctlDGVLoan.DataSource = dtt;
                 ctlDGVLoan.setColumnsVisible(false, "LCID", "LoanAccID", "LoanID", "RefAccID", "TransRefID", "CompanyID");
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }

         private void RefreshLoan()
         {
             //dt = new DataTable();
             //ctlDGVLoan.DataSource = dt;
             txtLoanID.Text = "0";
             txtLoanNo.Text = "";
             txtReffAccID.Text = "0";
             txtLoanAmount.Value = 0;
             cmbInterestPeriod.SelectedIndex = 0;
             txtInterestRate.Text = "0.0";
             txtDueAmount.Text = "0.0";
             txtRemarks.Text = "";
             txtloanRefID.Text = "0";
             txtLCID.Text = "0";
             txtLCNo.Text = "";
             txtRefAccount.Text = "";
             txtLoanAccount.Text = "";
             lblTtlLoanAmt.Text = "0";
             lblLCValue.Text = "0";
             lblAcceptValue1.Text = "0";

             LCID = 0;
             sLcType = "";
             Acceptvalue = 0;
             LoanTaken = 0;
             MaxValue = 0;
             ctlNumAcceptedPercent.Value = 0;
             ctlNumLoanAmountAtTK.Value = 0;
             ctlNumRate.Value = 1;
          

         }
        
        private void frmLoan_Load(object sender, EventArgs e)
        {
            RefreshLoan();
            //LoadLoan();
            txtLoanNo.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            RefreshLoan();
            //LoadLoan();
        }

        private bool validation()
        {
            if (txtReffAccID.Text == "0")
            {
                MessageBox.Show("Please select a Refference Account No");
                return false;
            }
            if (txtloanRefID.Text.Trim() == "0")
            {
                MessageBox.Show("Please select a Loan Account No. ");
                return false;
            }
            if (ctlNumLoanAmountAtTK.Value <= 0)
            {
                MessageBox.Show("Please check loan amount");
                return false;
            }
            /*
            if (sLcType == "Import LC" || sLcType == "Direct Import LC")
            {
                if (txtLoanAmount.Value > MaxValue)
                {
                    MessageBox.Show("Value exceeded the accepted amount");
                    txtLoanAmount.Value = MaxValue;
                    return false;
                }
            }
            */
            if (txtLoanAmount.Value > MaxValue)
            {
                MessageBox.Show("Loan Amount Exceeded" + Environment.NewLine + "Please Check Loan Amount");
                txtLoanAmount.Value = MaxValue;
                return false;
            }
            return true;
        }
        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (validation() == false) return;
            ////////////saveupdate TransectionMaster
            if (MessageBox.Show("Are you sure to save", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No) return;
            SqlTransaction trans = null;
            Bills objBills = new Bills();
            DaBills objDaBills = new DaBills();
            obDaTrans = new DaTransaction();
            int TMID = 0;
            
            try
            {
                TransactionMaster obTM = new TransactionMaster();
                TransactionDetail objTD = new TransactionDetail();


                // transaction Master Save update 
                obTM = createTransactionMaster(trans);
                TMID = obDaTrans.SaveEditTransactionMaster(obTM, conn, trans);

                //Transaction Detail Save update
                int RefAccID, LoanAccID;
                RefAccID = Convert.ToInt32(txtReffAccID.Text);
                LoanAccID = Convert.ToInt32(txtloanRefID.Text);
                double dblTransAmt = txtLoanAmount.Value;
                int TransDID = 0;
                TransDID = obDaTrans.getTransDID(conn, trans, TMID, RefAccID);
                objTD = createTransactionDetail(TransDID, TMID, RefAccID, dblTransAmt, 0);
                obDaTrans.SaveEditTransactionDetail(objTD, conn, trans);

                TransDID = obDaTrans.getTransDID(conn, trans, TMID, LoanAccID);
                objTD = createTransactionDetail(TransDID, TMID, LoanAccID, 0, dblTransAmt);
                obDaTrans.SaveEditTransactionDetail(objTD, conn, trans);



                Loan obLoan = new Loan();
                DaLoan DaobLoan = new DaLoan();
                obLoan = CreateObjectLoan(TMID);
                DaobLoan.SaveUpdate(obLoan, conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            MessageBox.Show("Data Saved Successfully");
            RefreshLoan();
            //LoadLoan();
        }

        private Loan CreateObjectLoan(int transRefID)
        {
            Loan objloan = new Loan();
            try
            {
                objloan.LoanID = int.Parse(txtLoanID.Text);
                objloan.LoanNo = txtLoanNo.Text.ToString();
                objloan.RefAccID = int.Parse(txtReffAccID.Text.ToString());
                objloan.LoanAccID = int.Parse(txtloanRefID.Text);
                //objloan.LoanAmount = txtLoanAmount.Value;
                objloan.InterestRate = double.Parse(txtInterestRate.Text);
                objloan.InterestPeriod = cmbInterestPeriod.Text;
                objloan.ApplyDate = DTPApplyDate.Value.Date;
                objloan.SanktionDate = DTPSanctionDate.Value.Date;
                objloan.ExpireDate = DTPExpireDate.Value.Date;
                objloan.DueAmount = double.Parse(txtDueAmount.Text);
                objloan.Remarks = txtRemarks.Text;
                objloan.LCID = int.Parse(txtLCID.Text);
                objloan.TransRefID = transRefID;

                objloan.LoanAmount = ctlNumLoanAmountAtTK.Value;
                objloan.AcceptedPercent = ctlNumAcceptedPercent.Value;
                objloan.Rate = ctlNumRate.Value;
                return objloan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeleteLoans()
        {
            DaLoan objDaLoan = new DaLoan();
            try
            {
                int dd = Convert.ToInt32(ctlDGVLoan.CurrentRow.Cells["LoanID"].Value);
                objDaLoan.DeleteLoan(dd, conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an Error" + ex);
            }
            MessageBox.Show("Data is Deleted Successfully");
            RefreshLoan();
            LoadLoan();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteLoans();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ctlDGVLoan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DaCommercialDocuments objda=new DaCommercialDocuments();
                if (e.RowIndex<0) return;
                int ab = e.RowIndex;
                txtDueAmount.Text = GlobalFunctions.isNull( ctlDGVLoan.Rows[ab].Cells["DueAmount"].Value,0.0).ToString("0.00");
                txtInterestRate.Text = GlobalFunctions.isNull(ctlDGVLoan.Rows[ab].Cells["InterestRate"].Value,0.0).ToString("0.00");
                //txtLoanAccID.Text = ctlDGVLoan.Rows[ab].Cells["LoanAccID"].Value.ToString();
                //txtLoanAmount.Value = Math.Round(GlobalFunctions.isNull(ctlDGVLoan.Rows[ab].Cells["LoanAmount"].Value, 0.0) / GlobalFunctions.isNull(ctlDGVLoan.Rows[ab].Cells["LoanAmount"].Value, 0.0), 2);
                txtLoanID.Text = ctlDGVLoan.Rows[ab].Cells["LoanID"].Value.ToString();
                txtLoanNo.Text = ctlDGVLoan.Rows[ab].Cells["LoanNo"].Value.ToString();
                txtloanRefID.Text = ctlDGVLoan.Rows[ab].Cells["LoanAccID"].Value.ToString();
                txtReffAccID.Text = ctlDGVLoan.Rows[ab].Cells["RefAccID"].Value.ToString();
                DTPApplyDate.Value =Convert.ToDateTime( ctlDGVLoan.Rows[ab].Cells["ApplyDate"].Value);
                DTPExpireDate.Value =Convert.ToDateTime( ctlDGVLoan.Rows[ab].Cells["ExpireDate"].Value);
                DTPSanctionDate.Value =Convert.ToDateTime( ctlDGVLoan.Rows[ab].Cells["SanktionDate"].Value);
                txtTransRefID.Text = ctlDGVLoan.Rows[ab].Cells["TransRefID"].Value.ToString();
                txtRemarks.Text = ctlDGVLoan.Rows[ab].Cells["Remarks"].Value.ToString();
                cmbInterestPeriod.Text = ctlDGVLoan.Rows[ab].Cells["InterestPeriod"].Value.ToString();
                txtLCID.Text = ctlDGVLoan.Rows[ab].Cells["LCID"].Value.ToString();
                txtLCNo.Text = objda.GetLCNO(int.Parse(txtLCID.Text), conn);
                txtLCID_TextChanged(sender, null);
                
                ctlNumRate.Value = Convert.ToDouble(ctlDGVLoan.Rows[ab].Cells["Rate"].Value);
                ctlNumAcceptedPercent.Value = Convert.ToDouble(ctlDGVLoan.Rows[ab].Cells["AcceptedPercent"].Value);
                ctlNumLoanAmountAtTK.Value = Convert.ToDouble(ctlDGVLoan.Rows[ab].Cells["LoanAmount"].Value);
                txtLoanAmount.Value = Math.Round(GlobalFunctions.isNull(ctlDGVLoan.Rows[ab].Cells["LoanAmount"].Value, 0.0) / GlobalFunctions.isNull(ctlDGVLoan.Rows[ab].Cells["Rate"].Value, 0.0) / GlobalFunctions.isNull(ctlDGVLoan.Rows[ab].Cells["AcceptedPercent"].Value, 0.0)*100.0, 2);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message +Environment.NewLine+"Please select a row");
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            try
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
                txtReffAccID.Text = objSelectedAcc.AccountID.ToString();
               // if (sender.Equals(txtPayFromAcc)) return;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtLoanAccount_Enter(object sender, EventArgs e)
        {
            try
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
                txtloanRefID.Text = objSelectedAcc.AccountID.ToString();
                // if (sender.Equals(txtPayFromAcc)) return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //private void txtLoanAmount_Enter(object sender, EventArgs e)
        //{
        //    TextBox conl = (TextBox)sender;
        //    conl.BackColor = Color.Black;
        //    conl.ForeColor = Color.White;
        //    conl.SelectAll();
        //}

        private void txtInterestRate_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtDueAmount_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtRemarks_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }
        
        private void txtLoanNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }
        
        /*
        private void txtLoanAmount_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }
        */
        /*
        private void txtInterestRate_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }
        */
        /*
        private void txtDueAmount_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }
        */
        /*
        private void txtRemarks_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

       */
        private void txtRefAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtLoanAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtLoanAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtInterestRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtDueAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void cmbInterestPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DTPApplyDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DTPSanctionDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DTPExpireDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void btnNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void btnSaveUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void btnDelete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtLCNo_Enter_1(object sender, EventArgs e)
        {

            frmSearchLC objfrm = new frmSearchLC();
            objfrm.ShowDialog();

            if (objfrm == null) return;
            if (objfrm.LCID == 0)
            {
                txtLoanAmount.Enabled = false;
                ctlNumAcceptedPercent.Enabled = false;
                ctlNumRate.Enabled = false;
                ctlNumLoanAmountAtTK.ReadOnly = false;
                //txtLoanAmount.ReadOnly = false;
                //ctlNumAcceptedPercent.Value = 100;
            }
            else
            {
                //txtLoanAmount.ReadOnly = true;
                //ctlNumAcceptedPercent.Value = 0;
                ctlNumLoanAmountAtTK.ReadOnly = true;
                LCID = objfrm.LCID;
                txtLCID.Text = LCID.ToString();
            }

            txtLCID_TextChanged(sender, null);
            /*
            DaLC objdalc = new DaLC();

            LC_Master objlcmaster = objdalc.GetLC_Master(LCID, conn);

            if (objlcmaster == null) return;

            txtLCID.Text = objlcmaster.LCID.ToString();
            txtLCNo.Text = objlcmaster.LCNo;

            lblLCValue.Text = objlcmaster.TotalValue.ToString();
            sLcType = objlcmaster.LCType;
            if (sLcType == "Import LC" || sLcType == "Direct Import LC")
            {
                Acceptvalue = objdalc.getAcceptValue(conn, objlcmaster.LCID);
                MaxValue = Acceptvalue - LoanTaken;
                lblAcceptValue.Visible = true;
                lblAcceptValue1.Text = Acceptvalue.ToString();
                txtLoanAmount.Value = MaxValue;
            }
            else
            {
                lblAcceptValue.Visible = false;
                lblAcceptValue1.Text = "";
                MaxValue = objlcmaster.TotalValue - LoanTaken;
                txtLoanAmount.Value = MaxValue;
            }
            */
        }

        private void txtLCNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private TransactionMaster createTransactionMaster(SqlTransaction trans)
        {
            TransactionMaster objTM = null;
            try
            {
                objTM = new TransactionMaster();
                objTM.TransactionMasterID = int.Parse(txtTransRefID.Text);
                objTM.TransactionDate = DTPApplyDate.Value.Date;
                if (txtTransRefID.Text == "0")
                    objTM.VoucherNo = new DaTransaction().getVoucherNo(conn, trans, "J");
                else
                    objTM.VoucherNo = "";
                objTM.VoucherPayee = "";
                objTM.VoucherType = 3;
                objTM.TransactionMethodID = -1;
                objTM.MethodRefID = -1;
                objTM.MethodRefNo = string.Empty;
                objTM.TransactionDescription = txtRemarks.Text;
                objTM.ApprovedBy = string.Empty;
                objTM.ApprovedDate = new DateTime(1900, 1, 1);
                objTM.Module = "Loan Module";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return objTM;
        }


         private TransactionDetail createTransactionDetail(int TDID, int TMID, int AccountID, double CrAmt, double DbAmt)
        {
            TransactionDetail objTD = new TransactionDetail();
            try
            {
                objTD.TransactionDetailID = TDID;
                objTD.TransactionMasterID = TMID;
                objTD.TransactionAccountID = AccountID;
                objTD.CreditAmount = CrAmt;
                objTD.DebitAmount = DbAmt;
                objTD.Comments = string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return objTD;
        }

         private void frmLoan_Paint(object sender, PaintEventArgs e)
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

         private void txtReffAccID_TextChanged(object sender, EventArgs e)
         {
             DaAccount objDAAccount = new DaAccount();
             Account objAccount = new Account();
             if (txtReffAccID.Text == "0") return;
             try
             {
                 objAccount = objDAAccount.getPurchaseAccount(conn, int.Parse(txtReffAccID.Text));
                 txtRefAccount.Text = objAccount.AccountTitle.ToString();
             }
             catch (Exception ex)
             {
                 MessageBox.Show("There is an Error to load Account Title"+ex);
             }
         }

         private void txtloanRefID_TextChanged(object sender, EventArgs e)
         {
             DaAccount objDAAccount = new DaAccount();
             Account objAccount = new Account();

             try
             {
                 objAccount = objDAAccount.getPurchaseAccount(conn, int.Parse(txtloanRefID.Text));
                 if (txtloanRefID.Text == "0") return;
                 txtLoanAccount.Text = objAccount.AccountTitle.ToString();

             }
             catch (Exception ex)
             {
                 MessageBox.Show("There is an Error to load Account Title" + ex);
             }
         }

         private void txtTransRefID_TextChanged(object sender, EventArgs e)
         {

         }

         private void txtLCID_TextChanged(object sender, EventArgs e)
         {
             txtLoanAmount.Enabled = true;
             ctlNumAcceptedPercent.Enabled = true;
             ctlNumRate.Enabled = true;

             DaLC objdalc = new DaLC();
             DaLoan obDaLoan = new DaLoan();

             LC_Master objlcmaster = objdalc.GetLC_Master(Convert.ToInt32(txtLCID.Text), conn);

             if (objlcmaster == null) return;

             //txtLCID.Text = objlcmaster.LCID.ToString();
             txtLCNo.Text = objlcmaster.LCNo;

             lblLCValue.Text = objlcmaster.TotalValue.ToString();
             sLcType = objlcmaster.LCType;
             if (objlcmaster.CurrencyID == 0)
             {
                 lblCurrency.Text = "TK";
                 lblCurrency1.Text = "TK";
                 lblCurrencyL.Text = "TK";
                 lblCurrencyA.Text = "TK";
             }
             else
             {
                 DataTable dt = obDaLoan.loadCurrency(conn, objlcmaster.CurrencyID);
                 lblCurrency.Text = dt.Rows[0].Field<object>("Code").ToString();
                 lblCurrency1.Text = dt.Rows[0].Field<object>("Code").ToString();
                 lblCurrencyL.Text = lblCurrency.Text;
                 lblCurrencyA.Text = lblCurrency.Text;
             }
             if (txtLCID.Text == "0")
             {
                 return;
             }
             //int lcid = Convert.ToInt32(txtLCID.Text);
             //DaLC obDaLC = new DaLC();
             if (conn.State != ConnectionState.Open)
                 conn.Open();
             try
             {
                 dt = obDaLoan.loadLoanAgainstLC(conn, Convert.ToInt32(txtLCID.Text));
                 //ctlDGVLoan.DataSource = dt;
                 //ctlDGVLoan.setColumnsVisible(false, "LCType");
                 //ctlDGVLoan.setColumnsFormat(new string[] { "TotalQty", "TotalValue", "LoanAmount" }, "0.00", "0.00", "0.00");
                 //ctlDGVLoan.Columns["TotalQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                 //ctlDGVLoan.Columns["TotalValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                 //ctlDGVLoan.Columns["LoanAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                 if (dt.Rows.Count != 0)
                 {
                     LoanTaken = 0;
                     int i, nR = dt.Rows.Count;
                     for (i = 0; i < nR; i++)
                     {
                         LoanTaken += GlobalFunctions.isNull(dt.Rows[i].Field<object>("LoanAmount"), 0.0) / GlobalFunctions.isNull(dt.Rows[i].Field<object>("Rate"), 1.0);
                     }
                     lblTtlLoanAmt.Text = LoanTaken.ToString();
                 }
                 else
                     lblTtlLoanAmt.Text = "0";

                 if (sLcType == "Import LC" || sLcType == "Direct Import LC")
                 {
                     Acceptvalue = objdalc.getAcceptValue(conn, Convert.ToInt32(txtLCID.Text));
                     MaxValue = Acceptvalue - LoanTaken;
                     lblAcceptValue.Visible = true;
                     lblAcceptValue1.Text = Acceptvalue.ToString();
                     txtLoanAmount.Value = MaxValue;
                 }
                 else
                 {
                     lblAcceptValue.Visible = false;
                     lblAcceptValue1.Text = "";
                     MaxValue = objlcmaster.TotalValue - LoanTaken;
                     txtLoanAmount.Value = MaxValue;
                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         private void txtLoanNo_TextChanged(object sender, EventArgs e)
         {

         }

         private void txtLoanNo_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Enter)
                 SelectNextControl((Control)sender, true, true, true, true);
         }

         private void txtLoanNo_Enter(object sender, EventArgs e)
         {
             TextBox conl = (TextBox)sender;
             conl.BackColor = Color.Black;
             conl.ForeColor = Color.White;
             conl.SelectAll();
         }

         private void txtRefAccount_Leave(object sender, EventArgs e)
         {
             Control crl = (Control)sender;
             crl.ForeColor = Color.Black;
             crl.BackColor = Color.White;
         }

         private void txtLoanAccount_Leave(object sender, EventArgs e)
         {
             Control crl = (Control)sender;
             crl.ForeColor = Color.Black;
             crl.BackColor = Color.White;
         }

         private void cmbInterestPeriod_Enter(object sender, EventArgs e)
         {
             SendKeys.Send("{F4}");
         }

         private void btnFind_Click(object sender, EventArgs e)
         {
             frmFindLoan objLoan = new frmFindLoan();
             objLoan.ShowDialog();
             //Loan objloan = new Loan();
             if (objLoan.loan == null )
             {
                 if (objLoan.lcid != 0)
                 {
                     LCID = objLoan.lcid;
                     txtLCID.Text = objLoan.lcid.ToString();
                 }
                 return;
             }
             else
             {
                 objloan = objLoan.loan;
                 GetLoanDTL();
             }
         }


         private void GetLoanDTL()
         {
             try
             {
                 DaCommercialDocuments objda = new DaCommercialDocuments();
                 //if (e.RowIndex < 0) return;
                 //int ab = e.RowIndex;
                 txtDueAmount.Text = objloan.DueAmount.ToString();
                 txtInterestRate.Text = objloan.InterestRate.ToString();
                 //txtLoanAccID.Text = ctlDGVLoan.Rows[ab].Cells["LoanAccID"].Value.ToString();
                 if (objloan.LCID != 0)
                 {
                     ctlNumRate.Value = objloan.Rate;
                     ctlNumAcceptedPercent.Value = objloan.AcceptedPercent;
                     txtLoanAmount.Value = objloan.LoanAmount / (objloan.Rate * objloan.AcceptedPercent);
                 }
                 else
                 {
                     txtLoanAmount.Value = objloan.LoanAmount;
                 }
                 ctlNumLoanAmountAtTK.Value = objloan.LoanAmount;
                 txtLoanID.Text = objloan.LoanID.ToString();
                 txtLoanNo.Text = objloan.LoanNo.ToString();
                 txtloanRefID.Text = objloan.LoanAccID.ToString();
                 txtReffAccID.Text = objloan.RefAccID.ToString();
                 DTPApplyDate.Value = objloan.ApplyDate;
                 DTPExpireDate.Value = objloan.ExpireDate;
                 DTPSanctionDate.Value = objloan.SanktionDate;
                 txtTransRefID.Text = objloan.TransRefID.ToString();
                 txtRemarks.Text = objloan.Remarks.ToString();
                 cmbInterestPeriod.Text = objloan.InterestPeriod.ToString();
                 txtLCNo.Text = objda.GetLCNO(int.Parse(txtLCID.Text), conn);
                 LCID = objloan.LCID;
                 txtLCID.Text = objloan.LCID.ToString();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message + Environment.NewLine + "Please select a row");
             }


         }

         private void txtLCNo_TextChanged(object sender, EventArgs e)
         {
         }

         private void ctlNumAcceptedPercent_valueChanged(object sender, EventArgs e)
         {
             if (ctlNumAcceptedPercent.Value > 100)
             {
                 MessageBox.Show("Please Type Between 0 to 100");
                 ctlNumAcceptedPercent.Value = 0;
                 return;
             }
             try
             {
                
                 ctlNumLoanAmountAtTK.Value = (ctlNumRate.Value * txtLoanAmount.Value * ctlNumAcceptedPercent.Value) / 100;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         private void ctlNumRate_valueChanged(object sender, EventArgs e)
         {
             try
             {
                 
                 ctlNumLoanAmountAtTK.Value = (ctlNumRate.Value * txtLoanAmount.Value * ctlNumAcceptedPercent.Value) / 100;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         private void txtLoanAmount_valueChanged(object sender, EventArgs e)
         {
             try
             {
                 ctlNumLoanAmountAtTK.Value = (ctlNumRate.Value * txtLoanAmount.Value * ctlNumAcceptedPercent.Value) / 100;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         private void btnSearch_Click(object sender, EventArgs e)
         {
             try
             {
                 LoadLoan();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         private void chkLoanNo_CheckedChanged(object sender, EventArgs e)
         {
             if (sender.Equals(chkDate))
             {
                 dtpSdate.Enabled = dtpEdate.Enabled = chkDate.Checked;
             }
             else if(sender.Equals(chkLC))
                 txtLcNoLike.Enabled=chkLC.Checked;
             else
                 txtLoanNoLike.Enabled=chkLoanNo.Checked;
         }

         private void ctlNumRate_Load(object sender, EventArgs e)
         {

         }
    }
}
