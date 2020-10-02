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
using Accounting.Controls;


namespace Accounting.UI
{
    public partial class frmBillReceivable : Form
    {
        public frmBillReceivable()
        {
            InitializeComponent();
        }
        private SqlConnection formCon = null;
        private DataTable dtBills = new DataTable();
        private CurrencyManager cmBills = null;
        private DataTable dtBillAdjusts = null;
        private DaBills objDaBills = null;
        private void loadCollectionMethods()
        {
            try
            {
                DataTable dt = new DaTransMethod().getTransactionMethods(formCon);
                cboColMethod.DataSource = dt;
                cboColMethod.DisplayMember = "TransMethod";
                cboColMethod.ValueMember = "TransMethodID";
                dt.Rows.RemoveAt(3);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void txtAcc_Enter(object sender, EventArgs e)
        {

        }

        private void loadBills(int customerID, bool all)
        {
            try
            {
                dtBills = objDaBills.getBills(formCon, "Bills Receivable", customerID, all);
                ctldgvBills.DataSource = dtBills;
                cmBills = (CurrencyManager)this.BindingContext[dtBills];
                cmBills.PositionChanged += new EventHandler(cmBills_PositionChanged);
                cmBills_PositionChanged(null, null);
                ctldgvBills.setColumnsVisible(false, "BillsID", "InvoiceID", "Module");
                ctldgvBills.setColumnsWidth(new string[]{"InvoiceNo","BillAmount","BillDate","DueAmount","Remarks"},70,120,70,120,300);
                ctldgvBills.setColumnsFormat(new string[] { "BillAmount", "BillDate", "DueAmount" }, "0.00", "dd/MM/yyyy", "0.00");

                getTotal(ctldgvBills, "DueAmount", ctlNumDue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void cmBills_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                if(cmBills==null) return ;
                int pos,bID;
                pos=cmBills.Position;
                if(pos <0) return ;
                bID=Convert.ToInt32( ctldgvBills["BillsID",pos].Value);
                loadAdjustments(bID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadAdjustments(int billID)
        {
            try
            {
                ctlNumColAmt.Value = 0;
                txtAdjID.Text = "0";
                txtChequeLCNo.Text = "";
                txtCollectToAcc.Text = "";
                txtCollectToAcc.Tag = null;
                txtRemarks.Text = "";
                dtBillAdjusts = objDaBills.getBillAdjusts(formCon, billID);
                ctldgvAdjusts.DataSource = dtBillAdjusts;
                ctldgvAdjusts.setColumnsVisible(false, "BillAdjustID", "TransRefID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmBillReceivable_Load(object sender, EventArgs e)
        {
            try
            {
                formCon = ConnectionHelper.getConnection();
                objDaBills = new DaBills();
                loadCurrency();
                loadCollectionMethods();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboColMethod_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboColMethod.SelectedValue == null || cboColMethod.SelectedValue.GetType() == typeof(DataRowView)) return;
                switch ((int)cboColMethod.SelectedValue)
                {
                    case 1: txtChequeLCNo.Enabled = false; break;
                    case 2: lblRefNo.Text = "Cheque No."; txtChequeLCNo.Enabled = true; break;
                    case 3: lblRefNo.Text = "Cheque No."; txtChequeLCNo.Enabled = true; break;
                    case 4: lblRefNo.Text = "LC No."; txtChequeLCNo.Enabled = true; break;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlNumColAmt_valueChanged(object sender, EventArgs e)
        {
            try
            {
                if (gbxInput.Tag != null) return;
                double value = ctlNumColAmt.Value;
                double due = 0;
                int i, nR;
                nR = ctldgvBills.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    if (value == 0)
                    {
                        ctldgvBills["AdjustNow", i].Value = DBNull.Value;
                        continue;
                    }
                    due=GlobalFunctions.isNull(ctldgvBills["DueAmount", i].Value, 0);
                    if (due <= value)
                    {
                       
                        ctldgvBills["AdjustNow", i].Value = due;
                        value -= due;
                    }
                    else
                    {
                        ctldgvBills["AdjustNow", i].Value = value;
                        value -= value;
                    }
                    
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getTotal(ctlDaraGridView ctldgv, string cellName, ctlNum ctl)
        {
            try
            {
                double sum = 0;
                int i, nR;
                nR = ctldgv.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    if (ctldgv.Rows[i].Cells[cellName].Value == null || ctldgv.Rows[i].Cells[cellName].Value == DBNull.Value) continue;
                    sum += Convert.ToDouble(ctldgv.Rows[i].Cells[cellName].Value);
                }
                ctl.Value = sum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Validation()
        {
            try
            {
                if (txtBillOfAcc.Tag == null)
                {
                    MessageBox.Show("Correctly Select Bill of Account"); return false;
                }
                if (ctlNumDue.Value == 0)
                {
                    MessageBox.Show("No Due Amount"); return false;
                }
                if (ctlNumColAmt.Value <= 0)
                {
                    MessageBox.Show("Correctly Entry Collection Amount"); return false;
                }
                if (ctlNumColAmt.Value > ctlNumDue.Value)
                {
                    MessageBox.Show("Collection Amount must be less than or equal Due Amount"); return false;
                }
                if (txtCollectToAcc.Tag == null)
                {
                    MessageBox.Show("Correctly Select Collection Account"); return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        private void btnPost_Click(object sender, EventArgs e)
        {
            SqlTransaction trans=null;
            try
            {
                if (Validation() == false) return;
                int i, nR;
                int AdjID, BillsID;
                double AdjNow = 0;
                int TransMID = 0;
                DaTransaction objDaTrans = new DaTransaction(); 
                string VNo = objDaTrans.getVoucherNo(formCon, "C"); ;
             
                trans=formCon.BeginTransaction();
                TransactionMaster objTM = CreateTransMasterObject(VNo);
                TransMID = objDaTrans.SaveEditTransactionMaster(objTM, formCon, trans);
                TransactionDetail objTD = null;
                objTD = CreateTransDetailObject(0, TransMID, ((Account)txtBillOfAcc.Tag).AccountID,  ctlNumColAmt.Value,0);
                objDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);
                objTD = CreateTransDetailObject(0, TransMID, ((Account)txtCollectToAcc.Tag).AccountID,0, ctlNumColAmt.Value);
                objDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);

                nR = ctldgvBills.Rows.Count;
                BillAdjust objBa = null;
               
                for (i = 0; i < nR; i++)
                {
                    AdjID=0;
                    BillsID=Convert.ToInt32( ctldgvBills["BillsID", i].Value);
                    AdjNow=GlobalFunctions.isNull(ctldgvBills["AdjustNow", i].Value, 0);
                    if (AdjNow == 0) continue;
                    objBa = CreateBillAdjustObject(AdjID, BillsID, AdjNow, TransMID, VNo);
                    objDaBills.SaveUpdateBillsAdjust(formCon, trans, objBa);
                }

                trans.Commit();

                loadBills(((Account)txtBillOfAcc.Tag).AccountID,chkAll.Checked);
                MessageBox.Show("Save OK");
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private BillAdjust CreateBillAdjustObject(int AdjID,int BillsID,double ColAmt,int transID,string Vno)
        {
            BillAdjust objBa = null;
            try
            {
                objBa = new BillAdjust();
                objBa.BillAdjustID = AdjID;
                objBa.BillsID = BillsID;
                objBa.AdjustDate = dtpCollectDate.Value.Date;
                objBa.AdjustAmount = ColAmt;
                objBa.AdjustAccountID = ((Account)txtCollectToAcc.Tag).AccountID;
                objBa.AdjustMethodID = (int)cboColMethod.SelectedValue;
                objBa.AdjustRefNo = txtChequeLCNo.Text.Trim();
                objBa.AdjustRefLCID = -1;
                objBa.Remarks = txtRemarks.Text;
                objBa.TransRefID = transID;
                objBa.TransVoucherNo = Vno;
                objBa.AcceptDate = new DateTime(1900, 1, 1);
                objBa.MaturityDate = new DateTime(1900, 1, 1);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objBa;
        }


        private TransactionMaster CreateTransMasterObject(string Vno)
        {
            TransactionMaster objTM = null;
            try
            {
                objTM = new TransactionMaster();
                objTM.TransactionMasterID = 0;//int.Parse(txtJrTMID.Text);
                objTM.TransactionDate = dtpCollectDate.Value.Date;
                objTM.VoucherNo = Vno;
                objTM.VoucherPayee = "";
                objTM.VoucherType = 1;
                objTM.TransactionMethodID =(int)cboColMethod.SelectedValue;
                objTM.MethodRefID = -1;
                objTM.MethodRefNo = txtChequeLCNo.Text.Trim();
                objTM.TransactionDescription = txtRemarks.Text;

                objTM.ApprovedBy = "Bill Collector";
                objTM.ApprovedDate = dtpCollectDate.Value.Date;
                objTM.Module = "Bills Receivable";



            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objTM;
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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBillOfAcc.Tag == null) return;

                
                loadBills(((Account)txtBillOfAcc.Tag).AccountID, chkAll.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmBillReceivable_Paint(object sender, PaintEventArgs e)
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

        private void txtBillOfAcc_KeyDown(object sender, KeyEventArgs e)
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
                   
                    if (txtAC.Equals(txtBillOfAcc))
                        cboColMethod.Focus();
                    else
                        dtpCollectDate.Focus();
                    if (sender.Equals(txtCollectToAcc)) return;
                    loadBills(objSelectedAcc.AccountID, chkAll.Checked);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control c = (Control)sender;
                SelectNextControl(c, true, true, true, true);
            }
        }

        private void cboColMethod_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void txtBillOfAcc_Enter(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.BackColor = Color.Black;
            c.ForeColor = Color.White;
        }

        private void txtBillOfAcc_Leave(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.BackColor = Color.White;
            c.ForeColor = Color.Black;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
             try
             {
                 if (ctldgvAdjusts.SelectedRows.Count == 0) return;
                 if (MessageBox.Show("Do you really want to the bill adjust? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                     return;
                 int adjID = GlobalFunctions.isNull(ctldgvAdjusts.SelectedRows[0].Cells["BillAdjustID"].Value, 0);
                 new DaBills().DeleteBillAdjust(formCon, adjID);
                 Account objSelectedAcc = (Account)txtBillOfAcc.Tag;
                 loadBills(objSelectedAcc.AccountID, chkAll.Checked);
                 MessageBox.Show("Successfully Deleted");
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            bool f = ((CheckBox)sender).Checked;

            if (sender.Equals(chkSupplier))
                txtSrcCustomer.Enabled = f;
            else if (sender.Equals(chkSrcDate))
            {
                dtpSdate.Enabled = f;
                dtpEdate.Enabled = f;
            }
            
        }

       

        private void txtAcc_KeyDown(object sender, KeyEventArgs e)
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSrcLcNo_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TextBox txt = (TextBox)sender;
                    frmSearchLC frm = new frmSearchLC();
                    frm.ShowDialog();
                    int lcID = frm.LCID;

                    LC_Master lc = new DaLC().GetLC_Master(lcID, formCon);
                    if (lc == null) return;
                    txt.Text = lc.LCNo;


                    txt.Tag = lc;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSrcSupplier_KeyDown(object sender, KeyEventArgs e)
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

                }
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
                int suppID, lcID;
                DateTime sDt, eDt;
                suppID = chkSupplier.Checked ? ((Account)txtSrcCustomer.Tag).AccountID : 0;
                lcID = 0; // chkSrcLC.Checked ? ((LC_Master)txtSrcLcNo.Tag).LCID : 0;
                sDt = chkSrcDate.Checked ? dtpSdate.Value.Date : new DateTime(1900, 1, 1);
                eDt = chkSrcDate.Checked ? dtpEdate.Value.Date : new DateTime(1900, 1, 1);
                DataTable dtBills = new DaBills().getReceivableBills(formCon, suppID, lcID, sDt, eDt);
                dgvBills.DataSource = dtBills;
                dgvBills.Columns["BillsID"].Visible = false;
                dgvBills.Columns["TransRefID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void loadBill(int Bid)
        {
            try
            {
                Bills objBill = new Bills();
                if (Bid <= 0)
                    objBill = null;
                else
                    objBill = new DaBills().getBill(formCon, Bid);

                if (objBill == null)
                {
                    txtBillNo.Text = "";
                    txtBillNo.Tag = 0;
                    dtpBillDate.Value = DateTime.Now;
                    txtBillForAcc.Text = "";
                    txtBillForAcc.Tag = null;
                    txtBillToAcc.Text = "";
                    txtBillToAcc.Tag = null;
                    
                   
                    
                    
                    ctlNumRate.Value = 0;
                   
                    ctlNumBillQty.Value = 0;
                    ctlNumBillAmt.Value = 0;
                    txtRemarks.Text = "";
                    lblTransRefID.Text = "0";
                    
                    lblCurrency1.Text = "";
                    //BalAmt = 0;
                    //BalQty = 0;

                }
                else
                {
                    txtBillNo.Text = objBill.RefInvoiceNo;
                    txtBillNo.Tag = objBill.BillsID;
                    dtpBillDate.Value = objBill.BillDate;

                    DaAccount DaAcc = new DaAccount();
                    Account acc1 = DaAcc.GetAccount(formCon, objBill.BillForAccountID);
                    txtBillForAcc.Text = acc1.AccountTitle;
                    txtBillForAcc.Tag = acc1;
                    Account acc2 = DaAcc.GetAccount(formCon, objBill.CustomerSupplierAccountID);
                    txtBillToAcc.Text = acc2.AccountTitle;
                    txtBillToAcc.Tag = acc2;
                    int lcID = objBill.LCID;
                   
                    //if (lcID > 0)
                    //{
                    //    LC_Master lc = new DaLC().GetLC_Master(lcID, formCon);
                    //    txtLCNo.Text ="";
                    //    txtLCNo.Tag = lc;

                    //    ctlNumLCQty.Value = lc.TotalQty;
                    //    ctlNumLcValue.Value = lc.TotalValue;
                    //    lblCurrency.Text = new DaCurrency().getCurrency(formCon, lc.CurrencyID);
                    //    lblCurrency1.Text = lblCurrency.Text;
                    //    cmbCurrency.SelectedValue = lc.CurrencyID;
                    //}
                    //else
                    //{
                        
                        lblCurrency1.Text = "";
                    //}
                        cmbCurrency.SelectedValue = objBill.CurrencyID;
                        ctlNumRate.Value = objBill.CurrencyRate == 0 ? 1 : objBill.CurrencyRate;
                    //ctlNumRecvAmt.Value = 0;
                    ctlNumBillQty.Value = objBill.BillQuantity;
                    ctlNumBillAmt.Value = objBill.BillAmount;
                    txtRemarks.Text = objBill.Remarks;
                    lblTransRefID.Text = objBill.TransRefID.ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {

                loadBill(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int BillID;
                BillID = GlobalFunctions.isNull(dgvBills["BillsID", e.RowIndex].Value, 0);
                loadBill(BillID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validationBillentry() == false) return;
            if (MessageBox.Show("Are you sure to save", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            TransactionMaster obTM = new TransactionMaster();
            TransactionDetail objTD = new TransactionDetail();
            Bills obBill = new Bills();
            DaTransaction obDaTrans = new DaTransaction();
            DaBills obDaBill = new DaBills();
            SqlTransaction trans = null;
            int TMID;
            try
            {

                if (formCon.State != ConnectionState.Open)
                    formCon.Open();
                trans = formCon.BeginTransaction();

                // Transaction Master Save update 
                TMID = Convert.ToInt32(lblTransRefID.Text);
                //if (TMID > 0)
                //    obDaTrans.DeleteTransaction(TMID, formCon, trans);

                obTM = createTransactionMaster(trans);
                TMID = obDaTrans.SaveEditTransactionMaster(obTM, formCon, trans);

                //Transaction Detail Save update
                int CustomerAccID, BillForAccID;


                CustomerAccID = ((Account)txtBillToAcc.Tag).AccountID;
                BillForAccID = ((Account)txtBillForAcc.Tag).AccountID;
                double dblTransAmt = ctlNumBillAmtTK.Value;
                int TransDID = 0;
                TransDID = obDaTrans.getTransDID(formCon, trans, TMID, CustomerAccID);
                objTD = createTransactionDetail(TransDID, TMID, CustomerAccID, 0, dblTransAmt);
                obDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);

                TransDID = obDaTrans.getTransDID(formCon, trans, TMID, BillForAccID);
                objTD = createTransactionDetail(TransDID, TMID, BillForAccID, dblTransAmt, 0);
                obDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);

                obBill = CreateObjectBills(TMID);
                obDaBill.SaveUpdateBills(formCon, trans, obBill);

                trans.Commit();
                loadBill(0);
                chkSrcDate.Checked = true;
                btnSearch_Click(sender, null);
                MessageBox.Show("Bill Save Successful");

            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private bool validationBillentry()
        {
            if (txtBillForAcc.Tag == null)
            {
                MessageBox.Show("Please Select Bill Account");
                return false;
            }
            if (txtBillToAcc.Tag == null)
            {
                MessageBox.Show("Please Select From Account");
                return false;
            }
            //if (ctlNumBillQty.Value > (ctlNumLCQty.Value - BalQty) && chkLC.Checked == true)
            //{
            //    //ctlNumBillQty.Value = ctlNumLCQty.Value - BalQty;
            //    MessageBox.Show("Bill Quantity Exceeded" + Environment.NewLine + "Please Retype Balance Quantity");
            //    return false;
            //}
            //if (ctlNumBillAmt.Value > (ctlNumLcValue.Value - BalAmt) && chkLC.Checked == true)
            //{
            //    //ctlNumBalAmt.Value = ctlNumLcValue.Value - BalAmt;
            //    MessageBox.Show("Bill Amount Exceeded" + Environment.NewLine + "Please Retype Bil Amount");
            //    return false;
            //}
            return true;
        }
        #region Object create
        private TransactionMaster createTransactionMaster(SqlTransaction trans)
        {
            TransactionMaster objTM = null;
            try
            {
                objTM = new TransactionMaster();
                objTM.TransactionMasterID = Convert.ToInt32(lblTransRefID.Text);
                objTM.TransactionDate = dtpBillDate.Value.Date;
                if (lblTransRefID.Text == "0")
                    objTM.VoucherNo = new DaTransaction().getVoucherNo(formCon, trans, "J");
                else
                    objTM.VoucherNo = "";
                objTM.VoucherPayee = "";
                objTM.VoucherType = 3;
                objTM.TransactionMethodID = -1;
                objTM.MethodRefID = -1;
                objTM.MethodRefNo = string.Empty;
                objTM.TransactionDescription = txtComment.Text;
                objTM.ApprovedBy = string.Empty;
                objTM.ApprovedDate = new DateTime(1900, 1, 1);
                objTM.Module = "Sales Bill Entry";
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
        private Bills CreateObjectBills(int transref)
        {
            try
            {
                Bills objBills = new Bills();
                objBills.BillsID = GlobalFunctions.isNull(txtBillNo.Tag, 0);
                objBills.BillAmount = ctlNumBillAmtTK.Value;
                objBills.BillDate = dtpBillDate.Value.Date;
                objBills.BillsType = "Bills Receivable";
                objBills.CustomerSupplierAccountID = ((Account)txtBillToAcc.Tag).AccountID;
                objBills.DueAmount = objBills.BillAmount; //Convert.ToDouble(txtTransAmount.Text);
                objBills.RefInvoiceID = 0;
                objBills.RefInvoiceNo = txtBillNo.Text.Trim();
                objBills.Remarks = txtRemarks.Text;
                objBills.Module = "Sales Bill Entry";
                objBills.BillForAccountID = ((Account)txtBillForAcc.Tag).AccountID;
                if (cmbCurrency.SelectedValue == null)
                    objBills.CurrencyID = 0;
                else
                    objBills.CurrencyID = (int)cmbCurrency.SelectedValue; //((LC_Master)txtLCNo.Tag).CurrencyID;
                objBills.CurrencyRate = ctlNumRate.Value;
                objBills.LCID = 0; //chkLC.Checked ? ((LC_Master)txtLCNo.Tag).LCID : 0;
                objBills.TransRefID = transref;
                objBills.BillQuantity = ctlNumBillQty.Value;
                return objBills;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadCurrency()
        {
            try
            {
                DataTable dtt = new DataTable();
                
                DaOrder objDAorder = new DaOrder();
                dtt = objDAorder.LoadCurrency(formCon);
                
                cmbCurrency.DataSource = dtt;
                cmbCurrency.DisplayMember = "Code";
                cmbCurrency.ValueMember = "CurrencyID";


              


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void BillOrRate_ValueChanged(object sender, EventArgs e)
        {
            ctlNumBillAmtTK.Value = ctlNumBillAmt.Value * ctlNumRate.Value;
           
        }

        private void btnDelBill_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            try
            {
                if (dgvBills.SelectedRows.Count == 0) return;
                if (MessageBox.Show("Do you really want to the bill? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                trans = formCon.BeginTransaction();
                int bID = GlobalFunctions.isNull(dgvBills["BillsID", dgvBills.SelectedRows[0].Index].Value, 0);
                if (bID > 0)
                    new DaBills().DeleteBill(formCon, trans, bID);
                int TRID = GlobalFunctions.isNull(dgvBills["TransRefID", dgvBills.SelectedRows[0].Index].Value, 0);
                if (TRID > 0)
                    new DaTransaction().DeleteTransaction(TRID, formCon, trans);

                trans.Commit();
                btnSearch_Click(sender, null);
                btnReset_Click(sender, null);
                MessageBox.Show("Deleted Successfully");
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
