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
    public partial class frmBillsPayable : Form
    {
        public frmBillsPayable()
        {
            InitializeComponent();
        }
        private SqlConnection formCon = null;
        private DataTable dtBills = new DataTable();
        private CurrencyManager cmBills = null;
        private DataTable dtBillAdjusts = null;
        private DaBills objDaBills = null;
        private double BalQty = 0, BalAmt = 0;
        private void loadCollectionMethods()
        {
            try
            {
                cboPayMethod.DataSource = new DaTransMethod().getTransactionMethods(formCon);
                cboPayMethod.DisplayMember = "TransMethod";
                cboPayMethod.ValueMember = "TransMethodID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

        private void loadBills(int customerID)
        {
            try
            {
                
                dtBills = objDaBills.getBills(formCon, "Bills Payable", customerID,chkLCBill.Checked,pnlOption.Tag.ToString());
                ctldgvBills.DataSource = dtBills;
                cmBills = (CurrencyManager)this.BindingContext[dtBills];
                cmBills.PositionChanged += new EventHandler(cmBills_PositionChanged);
                cmBills_PositionChanged(null, null);
                ctldgvBills.setColumnsVisible(false, "BillsID", "InvoiceID", "Module", "CurrencyRate", "CurrencyID");
                ctldgvBills.setColumnsWidth(new string[]{"InvoiceNo","BillAmount","BillDate","DueAmount","Remarks"},70,120,70,120,300);
                ctldgvBills.setColumnsFormat(new string[] { "BillAmount", "BillDate", "DueAmount" }, "0.00", "dd/MM/yyyy", "0.00");
                ctldgvBills.setColumnsHeaderText(new string[] { "InvoiceNo","AdjustNow" }, "Bill No","PayNow");
                getTotal(ctldgvBills, "DueAmount", ctlNumDue);
                if (ctldgvBills.Rows.Count == 0) return;
                cmbBPCurrency.SelectedValue = GlobalFunctions.isNull(ctldgvBills["CurrencyID", 0].Value, 0);
                ctlNumBPRate.Value = GlobalFunctions.isNull(ctldgvBills["CurrencyRate", 0].Value, 0.0);
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
                ctlNumPayAmt.Value = 0;
                txtAdjID.Text = "0";
                txtChequeLCNo.Text = "";
                txtPayFromAcc.Text = "";
                txtPayFromAcc.Tag = null;
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
        private void loadCurrency()
        {
            try
            {
                DataTable dtt = new DataTable();
                DataTable dtBPC = new DataTable();
                DataTable dtBAC = new DataTable();
                DaOrder objDAorder = new DaOrder();
                dtt = objDAorder.LoadCurrency(formCon);
                dtBPC = dtt;
                dtBAC = dtt;
                cmbCurrency.DataSource = dtt;
                cmbCurrency.DisplayMember = "Code";
                cmbCurrency.ValueMember = "CurrencyID";

                
                cmbBPCurrency.DataSource = dtBPC;
                cmbBPCurrency.DisplayMember = "Code";
                cmbBPCurrency.ValueMember = "CurrencyID";
                cmbBACurrency.DataSource = dtBAC;
                cmbBACurrency.DisplayMember = "Code";
                cmbBACurrency.ValueMember = "CurrencyID";


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void cboColMethod_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboPayMethod.SelectedValue == null || cboPayMethod.SelectedValue.GetType() == typeof(DataRowView)) return;
                switch ((int)cboPayMethod.SelectedValue)
                {
                    case 1: txtChequeLCNo.Enabled = false; txtChequeLCNo.ReadOnly = true; dtpAcceptDate.Enabled = false; dtpMaturityDate.Enabled = false; break;
                    case 2: lblRefNo.Text = "Cheque No."; txtChequeLCNo.Enabled = true; txtChequeLCNo.ReadOnly = false; dtpAcceptDate.Enabled = false; dtpMaturityDate.Enabled = false; break;
                    case 3: lblRefNo.Text = "Cheque No."; txtChequeLCNo.Enabled = true; txtChequeLCNo.ReadOnly = false; dtpAcceptDate.Enabled = false; dtpMaturityDate.Enabled = false; break;
                    case 4: lblRefNo.Text = "LC No."; txtChequeLCNo.Enabled = true; txtChequeLCNo.ReadOnly = true; dtpAcceptDate.Enabled = true; dtpMaturityDate.Enabled = true; break;
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
                if (ctlNumPayAmt.Value <= 0)
                {
                    MessageBox.Show("Correctly Entry Collection Amount"); return false;
                }
                if (ctlNumPayAmt.Value > ctlNumDue.Value)
                {
                    MessageBox.Show("Collection Amount must be less than or equal Due Amount"); return false;
                }
                if (txtPayFromAcc.Tag == null)
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
                string VNo = objDaTrans.getVoucherNo(formCon, "D");
             
                trans=formCon.BeginTransaction();
                TransactionMaster objTM = CreateTransMasterObject(VNo);
                TransMID = objDaTrans.SaveEditTransactionMaster(objTM, formCon, trans);

                TransactionDetail objTD = null;
                objTD = CreateTransDetailObject(0, TransMID, ((Account)txtBillOfAcc.Tag).AccountID, 0, ctlNumPayAmt.Value);
                objDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);
                objTD = CreateTransDetailObject(0, TransMID, ((Account)txtPayFromAcc.Tag).AccountID, ctlNumPayAmt.Value,0);
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

                loadBills(((Account)txtBillOfAcc.Tag).AccountID);
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
                objBa.AdjustDate = dtpPayDate.Value.Date;
                objBa.AdjustAmount = ColAmt;
                objBa.AdjustAccountID = ((Account)txtPayFromAcc.Tag).AccountID;
                objBa.AdjustMethodID = (int)cboPayMethod.SelectedValue;
                objBa.AdjustRefNo = txtChequeLCNo.Text.Trim();
                if (lblRefNo.Text.Trim().Substring(0, 2).ToUpper() == "LC" && txtChequeLCNo.Tag != null)
                    objBa.AdjustRefLCID = ((LC_Master)txtChequeLCNo.Tag).LCID;
                else
                    objBa.AdjustRefLCID = -1;

                objBa.Remarks = txtRemarks.Text;
                objBa.TransRefID = transID;
                objBa.TransVoucherNo = Vno;
                if (dtpAcceptDate.Enabled)
                    objBa.AcceptDate = dtpAcceptDate.Value.Date;
                else
                    objBa.AcceptDate = new DateTime(1900, 1, 1);
                if (dtpMaturityDate.Enabled)
                    objBa.MaturityDate = dtpMaturityDate.Value.Date;
                else
                    objBa.MaturityDate = new DateTime(1900, 1, 1);

                objBa.BillAccountID = ((Account)txtBillOfAcc.Tag).AccountID;
                objBa.CurrencyID =(int) cmbBPCurrency.SelectedValue;
                objBa.CurrencyRate = ctlNumBPRate.Value;
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
                objTM.TransactionDate = dtpPayDate.Value.Date;
                objTM.VoucherNo = Vno;
                objTM.VoucherPayee = "";
                objTM.VoucherType = 2;
                objTM.TransactionMethodID =(int)cboPayMethod.SelectedValue;
                objTM.MethodRefID = -1;
                objTM.MethodRefNo = txtChequeLCNo.Text.Trim();
                objTM.TransactionDescription = txtRemarks.Text;

                objTM.ApprovedBy = "Bill Collector";
                objTM.ApprovedDate = dtpPayDate.Value.Date;
                objTM.Module = "Bills Payable";



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
            
        }

        private void txtChequeLCNo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (lblRefNo.Text.Trim().Substring(0, 2).ToUpper() == "LC")
                {

                    frmSearchLC frm = new frmSearchLC();
                    frm.ShowDialog();
                    int lcID = frm.LCID;

                    LC_Master lc = new DaLC().GetLC_Master(lcID, formCon);
                    if (lc == null) return;
                    txtChequeLCNo.Text = lc.LCNo;
                   
                    txtChequeLCNo.Tag = lc;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmBillsPayable_Paint(object sender, PaintEventArgs e)
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
                    if (sender.Equals(txtPayFromAcc))
                        dtpPayDate.Focus();
                    else
                        cboPayMethod.Focus();
                    if (sender.Equals(txtPayFromAcc)) return;
                    loadBills(objSelectedAcc.AccountID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
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

        private void cboPayMethod_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void cboPayMethod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control c = (Control)sender;
                SelectNextControl(c, true, true, true, true);
            }
        }

        private void txtLCNo_KeyDown(object sender, KeyEventArgs e)
        {
            DataTable dt = new DataTable();
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

                    ctlNumLcValue.Value = lc.TotalValue;
                    ctlNumBillAmt.Value = lc.TotalValue;
                    ctlNumLCQty.Value = lc.TotalQty;
                    ctlNumBillQty.Value = lc.TotalQty;
                    txt.Tag = lc;
                    lblCurrency.Text = new DaCurrency().getCurrency(formCon, lc.CurrencyID);
                    lblCurrency1.Text = lblCurrency.Text;
                    cmbCurrency.SelectedValue = lc.CurrencyID;

                    dt = new DaLC().getReceivedQty(formCon, lcID);
                    if (dt.Rows.Count != 0)
                    {
                        ctlNumRecvAmt.Value = Convert.ToDouble(dt.Rows[0].Field<object>("ReceivedQty"));
                        BalAmt = Convert.ToDouble(dt.Rows[0].Field<object>("TotalBilAmt"));
                        BalQty = Convert.ToDouble(dt.Rows[0].Field<object>("TotalBilQty"));
                        ctlNumBillAmt.Value = ctlNumLcValue.Value - BalAmt;
                        ctlNumBillQty.Value = ctlNumLCQty.Value - BalQty;
                    }
                    else
                    {
                        ctlNumRecvAmt.Value = 0;
                    }

                    SelectNextControl((Control)sender, true, true, true, true);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BillOrRate_ValueChanged(object sender, EventArgs e)
        {
            ctlNumBillAmtTK.Value = ctlNumBillAmt.Value * ctlNumRate.Value;
            ctlNumBalAmt.Value = ctlNumLcValue.Value - ctlNumBillAmt.Value - BalAmt;
        }

        private void txtAccBillEntry_KeyDown(object sender, KeyEventArgs e)
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

        private void txt_Enter(object sender, EventArgs e)
        {
            Control ctl = (Control)sender;
            ctl.BackColor = Color.Black;
            ctl.ForeColor = Color.White;
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            Control ctl = (Control)sender;
            ctl.BackColor = Color.White;
            ctl.ForeColor = Color.Black;
        }

        private void Ctl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            SelectNextControl((Control)sender, true, true, true, true);
        }
        private bool validationBillentry()
        {
            if (txtBillForAcc.Tag == null)
            {
                MessageBox.Show("Please Select Bill Account");
                return false;
            }
            if (txtBillFromAcc.Tag == null)
            {
                MessageBox.Show("Please Select From Account");
                return false;
            }
            if (ctlNumBillQty.Value > (ctlNumLCQty.Value - BalQty) && chkLC.Checked==true)
            {
                //ctlNumBillQty.Value = ctlNumLCQty.Value - BalQty;
                MessageBox.Show("Bill Quantity Exceeded" + Environment.NewLine + "Please Retype Balance Quantity");
                return false;
            }
            if (ctlNumBillAmt.Value > (ctlNumLcValue.Value - BalAmt) && chkLC.Checked == true)
            {
                //ctlNumBalAmt.Value = ctlNumLcValue.Value - BalAmt;
                MessageBox.Show("Bill Amount Exceeded" + Environment.NewLine + "Please Retype Bil Amount");
                return false;
            }
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
                objTM.Module = "Bill Entry";
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
                objBills.BillsType = "Bills Payable";
                objBills.CustomerSupplierAccountID = ((Account)txtBillFromAcc.Tag).AccountID;
                objBills.DueAmount = objBills.BillAmount; //Convert.ToDouble(txtTransAmount.Text);
                objBills.RefInvoiceID = 0;
                objBills.RefInvoiceNo = txtBillNo.Text.Trim();
                objBills.Remarks = txtComment.Text;
                objBills.Module = "Bill Entry";
                objBills.BillForAccountID = ((Account)txtBillForAcc.Tag).AccountID;
                objBills.CurrencyID =(int) cmbCurrency.SelectedValue; //((LC_Master)txtLCNo.Tag).CurrencyID;
                objBills.CurrencyRate = ctlNumRate.Value;
                objBills.LCID = chkLC.Checked ? ((LC_Master)txtLCNo.Tag).LCID : 0;
                objBills.TransRefID = transref;
                objBills.BillQuantity = ctlNumBillQty.Value;
                return objBills;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validationBillentry() == false) return;
            if (MessageBox.Show("Are you sure to save", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            TransactionMaster obTM = new TransactionMaster();
            TransactionDetail objTD = new TransactionDetail();
            Bills obBill = new Bills();
            DaTransaction obDaTrans = new DaTransaction();
            DaBills obDaBill = new DaBills();
            SqlTransaction trans=null;
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
                int SupplierAccID, BillForAccID;


                SupplierAccID = ((Account)txtBillFromAcc.Tag).AccountID;
                BillForAccID = ((Account)txtBillForAcc.Tag).AccountID;
                double dblTransAmt = ctlNumBillAmtTK.Value;
                int TransDID = 0;
                TransDID = obDaTrans.getTransDID(formCon, trans, TMID, SupplierAccID);
                objTD = createTransactionDetail(TransDID, TMID, SupplierAccID, dblTransAmt, 0);
                obDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);

                TransDID = obDaTrans.getTransDID(formCon, trans, TMID, BillForAccID);
                objTD = createTransactionDetail(TransDID, TMID, BillForAccID, 0, dblTransAmt);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                int suppID, lcID;
                DateTime sDt, eDt;
                suppID = chkSupplier.Checked ? ((Account)txtSrcSupplier.Tag).AccountID : 0;
                lcID = chkSrcLC.Checked ? ((LC_Master)txtSrcLcNo.Tag).LCID : 0;
                sDt = chkSrcDate.Checked ? dtpSdate.Value.Date : new DateTime(1900, 1, 1);
                eDt = chkSrcDate.Checked ? dtpEdate.Value.Date : new DateTime(1900, 1, 1);
                DataTable dtBills = new DaBills().getBills(formCon, suppID, lcID, sDt, eDt);
                dgvBills.DataSource = dtBills;
                dgvBills.Columns["BillsID"].Visible = false;
                dgvBills.Columns["TransRefID"].Visible = false;  
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

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            bool f = ((CheckBox)sender).Checked;

            if (sender.Equals(chkSrcLC))
                txtSrcLcNo.Enabled = f;
            else if (sender.Equals(chkSupplier))
                txtSrcSupplier.Enabled = f;
            else if (sender.Equals(chkSrcDate))
            {
                dtpSdate.Enabled = f;
                dtpEdate.Enabled = f;
            }
            else if (sender.Equals(chkLC))
            {
                txtLCNo.Enabled = f;
                cmbCurrency.Enabled = !f;
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
                    txtBillFromAcc.Text = "";
                    txtBillFromAcc.Tag = null;
                    txtLCNo.Text = "";
                    txtLCNo.Tag = null;
                    chkLC.Checked = false;
                    ctlNumLCQty.Value = 0;
                    ctlNumLcValue.Value = 0;
                    ctlNumRate.Value = 0;
                    ctlNumRecvAmt.Value = 0;
                    ctlNumBillQty.Value = 0;
                    ctlNumBillAmt.Value = 0;
                    txtComment.Text = "";
                    lblTransRefID.Text = "0";
                    lblCurrency.Text = "";
                    lblCurrency1.Text = "";
                    BalAmt = 0;
                    BalQty = 0;
                    
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
                    txtBillFromAcc.Text = acc2.AccountTitle;
                    txtBillFromAcc.Tag = acc2;
                    int lcID=objBill.LCID;
                    chkLC.Checked = objBill.LCID > 0 ? true : false;
                    if (lcID > 0)
                    {
                        LC_Master lc = new DaLC().GetLC_Master(lcID, formCon);
                        txtLCNo.Text = lc.LCNo;
                        txtLCNo.Tag = lc;

                        ctlNumLCQty.Value = lc.TotalQty;
                        ctlNumLcValue.Value = lc.TotalValue;
                        lblCurrency.Text = new DaCurrency().getCurrency(formCon, lc.CurrencyID);
                        lblCurrency1.Text = lblCurrency.Text;
                        cmbCurrency.SelectedValue = lc.CurrencyID;
                    }
                    else
                    {
                        txtLCNo.Text = "";
                        txtLCNo.Tag = null;

                        ctlNumLCQty.Value = 0;
                        ctlNumLcValue.Value = 0;
                        lblCurrency.Text = "";
                        lblCurrency1.Text = "";
                    }
                    ctlNumRate.Value = objBill.CurrencyRate;
                    ctlNumRecvAmt.Value = 0;
                    ctlNumBillQty.Value = objBill.BillQuantity;
                    ctlNumBillAmt.Value = objBill.BillAmount;
                    txtComment.Text = objBill.Remarks;
                    lblTransRefID.Text = objBill.TransRefID.ToString();
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        private void btnDelBill_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            try
            {
                if(dgvBills.SelectedRows.Count==0) return ;
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

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
                pnlOption.Tag = rb.Tag;
            try
            {
                if (txtBillOfAcc.Tag == null) return;


                loadBills(((Account)txtBillOfAcc.Tag).AccountID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkLCBill_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBillOfAcc.Tag == null) return;


                loadBills(((Account)txtBillOfAcc.Tag).AccountID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtChequeLCNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (lblRefNo.Text == "LC No.")
                    {
                        TextBox txt = (TextBox)sender;
                        frmSearchLC frm = new frmSearchLC();
                        frm.ShowDialog();
                        int lcID = frm.LCID;

                        LC_Master lc = new DaLC().GetLC_Master(lcID, formCon);
                        if (lc == null) return;
                        txt.Text = lc.LCNo;


                        txt.Tag = lc;
                        //lblCurrency.Text = new DaCurrency().getCurrency(formCon, lc.CurrencyID);
                        //lblCurrency1.Text = lblCurrency.Text;
                        //cmbCurrency.SelectedValue = lc.CurrencyID;
                    }
                    SelectNextControl((Control)sender, true, true, true, true);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSupp_KeyDown(object sender, KeyEventArgs e)
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
        CurrencyManager cmLCAdjust = null;
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPayBills = new DataTable();
                int suppID = chkSupp.Checked ? ((Account)txtSupp.Tag).AccountID : 0;
                dtPayBills = new DaBills().getBillPaysForAdjust(formCon, suppID, chkLCPay.Checked,chkAll.Checked);
                dgvPaidBills.DataSource = dtPayBills;
                cmLCAdjust = (CurrencyManager)this.BindingContext[dtPayBills];
                cmLCAdjust.PositionChanged += new EventHandler(cmLCAdjust_PositionChanged);
                dgvPaidBills.setColumnsVisible(false, "BillsID", "BillAdjustID", "AdjustRefLCID","CurrencyRate","CurrencyID");
                dgvPaidBills.setColumnsReadOnly(true, "BillAdjustID", "BillsID", "PayDate", "PayAmtTK", "PayAmtFC", "PaidFrom", "PayFromLC", "BillOf","DueAmt");
                SelectNextControl((Control)sender, true, true, true, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void cmLCAdjust_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtLCadj = new DataTable();

                dtLCadj = new DaBills().getLcAdjusts(formCon, GlobalFunctions.isNull(dgvPaidBills["BillAdjustID", cmLCAdjust.Position].Value, 0));
                dgvLCAdj.DataSource = dtLCadj;
                dgvLCAdj.setColumnsVisible(false, "AdjustID", "BillPayID", "TransRefID");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void adjustAcc_KeyDown(object sender, KeyEventArgs e)
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

        private void dgvPaidBills_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            //    int tick;
            //    if (dgvPaidBills.Columns[e.ColumnIndex].Name != chk.Name) return;

            //    if (GlobalFunctions.isNull(dgvPaidBills[chk.Name, e.RowIndex].Value, 0) == 1)
            //    {

            //        for (int i = 0; i < dgvPaidBills.Rows.Count; i++)
            //        {
            //            if (i != e.RowIndex)
            //                dgvPaidBills[chk.Name, i].Value = 0;
            //        }


            //        ctlNumBABillAmt.Value = GlobalFunctions.isNull(dgvPaidBills["PayAmtTK", e.RowIndex].Value, 0.0);
            //        dgvPaidBills.Tag = e.RowIndex;
            //        cmbBACurrency.SelectedValue = GlobalFunctions.isNull(dgvPaidBills["CurrencyID", e.RowIndex].Value, 0);
            //        ctlNumBARate.Value = GlobalFunctions.isNull(dgvPaidBills["CurrencyRate", e.RowIndex].Value, 0.0);
            //    }
            //    else
            //    {
            //        ctlNumBABillAmt.Value = 0;
            //        dgvPaidBills.Tag = e.RowIndex;
            //        //cmbBACurrency.SelectedValue = null; //GlobalFunctions.isNull(dgvPaidBills["CurrencyID", e.RowIndex].Value, 0);
            //        //ctlNumBARate.Value = 1;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private bool validationBillAdjust()
        {
            if (txtAdjFromAcc.Tag == null)
            {
                MessageBox.Show("Please Adjust Account");
                return false;
            }
            if (txtAdjToAcc.Tag == null)
            {
                MessageBox.Show("Please Adjust Account");
                return false;
            }
            if (ctlNumBAadjustAmt.Value <= 0 || ctlNumBAadjustAmt.Value > ctlNumBABillAmt.Value)
            {
                MessageBox.Show("Adjust Amount Exceeded its limit" + Environment.NewLine + "Please Retype Adjust Amount");
                return false;
            }
            return true;
        }
        private void btnAdjustPost_Click(object sender, EventArgs e)
        {
            if (validationBillAdjust() == false) return;
            TransactionMaster obTM = new TransactionMaster();
            TransactionDetail objTD = new TransactionDetail();
            Import_Bill_LCAdjust obimportBill = new Import_Bill_LCAdjust();
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
                TMID = Convert.ToInt32(lblBATransRefID.Text);
                if (TMID > 0)
                    obDaTrans.DeleteTransaction(TMID, formCon, trans);

                obTM = createTransactionMasterOfAdj(trans);
                TMID = obDaTrans.SaveEditTransactionMaster(obTM, formCon, trans);

                //Transaction Detail Save update
                int AdjFromAccID, adjToAccID;

                    
                AdjFromAccID = ((Account)txtAdjFromAcc.Tag).AccountID;
                adjToAccID = ((Account)txtAdjToAcc.Tag).AccountID;
                double dblTransAmt = ctlNumBAadjustAmt.Value;
                //int TransDID = 0;
                //TransDID = obDaTrans.getTransDID(formCon, trans, TMID, AdjFromAccID);
                objTD = createTransactionDetailOfAdj(0, TMID, AdjFromAccID, dblTransAmt, 0);
                obDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);

                //TransDID = obDaTrans.getTransDID(formCon, trans, TMID, adjToAccID);
                objTD = createTransactionDetailOfAdj(0, TMID, adjToAccID, 0, dblTransAmt);
                obDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);

                obimportBill = CreateAdjustObject(TMID);
                obDaBill.SaveUpdateImport_Bill(formCon, trans, obimportBill);

                trans.Commit();
               
                
                MessageBox.Show("Bill Save Successful");
                reset();
                //btnSearch_Click(null, null);

            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }

        }
        private void reset()
        {
            try
            {
                //btnSearch_Click(null, null);
                btnFind_Click(null, null);
                txtAdjFromAcc.Tag = null;
                txtAdjFromAcc.Text = "";
                txtAdjToAcc.Tag = null;
                txtAdjToAcc.Text = "";
                ctlNumBABillAmt.Value = 0;
                ctlNumBAadjustAmt.Value = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #region Create Object
        private Import_Bill_LCAdjust CreateAdjustObject(int _TransRefID)
        {
            Import_Bill_LCAdjust objIB = new Import_Bill_LCAdjust();

            try
            {
                objIB.AdjustID = 0;
                objIB.AdjustAmount = ctlNumBAadjustAmt.Value;
                objIB.AdjustDate = dtpBAAdjDate.Value.Date;
                objIB.AdjustFromAccID = ((Account)txtAdjFromAcc.Tag).AccountID;
                objIB.BillPayID =GlobalFunctions.isNull( dgvPaidBills["BillAdjustID", (int)dgvPaidBills.Tag].Value,0);
                objIB.CurrencyID =(int) cmbBACurrency.SelectedValue;
                objIB.CurrencyRate = ctlNumBARate.Value;
                objIB.LCID = GlobalFunctions.isNull(dgvPaidBills["AdjustRefLCID", (int)dgvPaidBills.Tag].Value, 0);
                objIB.PayFromAccID = ((Account)txtAdjToAcc.Tag).AccountID;
                objIB.Remarks = txtBAremarks.Text;
                objIB.TransRefID = _TransRefID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objIB;
        }

        private TransactionMaster createTransactionMasterOfAdj(SqlTransaction trans)
        {
            TransactionMaster objTM = null;
            try
            {
                objTM = new TransactionMaster();
                objTM.TransactionMasterID = 0; //Convert.ToInt32(lblBATransRefID.Text);
                objTM.TransactionDate = dtpBAAdjDate.Value.Date;
                if (lblBATransRefID.Text == "0")
                    objTM.VoucherNo = new DaTransaction().getVoucherNo(formCon, trans, "J");
                else
                    objTM.VoucherNo = "";
                objTM.VoucherPayee = "";
                objTM.VoucherType = 3;
                objTM.TransactionMethodID = -1;
                objTM.MethodRefID = -1;
                objTM.MethodRefNo = string.Empty;
                objTM.TransactionDescription = txtBAremarks.Text;
                objTM.ApprovedBy = string.Empty;
                objTM.ApprovedDate = new DateTime(1900, 1, 1);
                objTM.Module = "Bill Adjust";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return objTM;
        }
        private TransactionDetail createTransactionDetailOfAdj(int TDID, int TMID, int AccountID, double CrAmt, double DbAmt)
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
     
        #endregion

        private void ctlNumBPRate_valueChanged(object sender, EventArgs e)
        {
            if (ctlNumBPRate.Value == 0) ctlNumBPRate.Value = 1;
            ctlNumFCAmt.Value = ctlNumPayAmt.Value / ctlNumBPRate.Value;
        }

        private void ctlNumPayAmt_valueChanged(object sender, EventArgs e)
        {
            try
            {
                if (gbxInput.Tag != null) return;
                double value = ctlNumPayAmt.Value;
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
                    due = GlobalFunctions.isNull(ctldgvBills["DueAmount", i].Value, 0);
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
                if (ctlNumBPRate.Value == 0) ctlNumBPRate.Value = 1;
                ctlNumFCAmt.Value = ctlNumPayAmt.Value / ctlNumBPRate.Value;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvPaidBills_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
                
                if (dgvPaidBills.Columns[e.ColumnIndex].Name != chk.Name) return;
                dgvPaidBills.EndEdit();
                if (GlobalFunctions.isNull(dgvPaidBills[chk.Name, e.RowIndex].Value, 0) == 0)
                {

                    for (int i = 0; i < dgvPaidBills.Rows.Count; i++)
                    {
                        if (i != e.RowIndex)
                            dgvPaidBills[chk.Name, i].Value = 0;
                    }


                    ctlNumBABillAmt.Value = GlobalFunctions.isNull(dgvPaidBills["DueAmt", e.RowIndex].Value, 0.0);
                    dgvPaidBills.Tag = e.RowIndex;
                    cmbBACurrency.SelectedValue = GlobalFunctions.isNull(dgvPaidBills["CurrencyID", e.RowIndex].Value, 0);
                    ctlNumBARate.Value = GlobalFunctions.isNull(dgvPaidBills["CurrencyRate", e.RowIndex].Value, 0.0);
                }
                else
                {
                    ctlNumBABillAmt.Value = 0;
                    dgvPaidBills.Tag = e.RowIndex;
                    //cmbBACurrency.SelectedValue = null; //GlobalFunctions.isNull(dgvPaidBills["CurrencyID", e.RowIndex].Value, 0);
                    //ctlNumBARate.Value = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctlNumBAadjustAmt_valueChanged(object sender, EventArgs e)
        {
            if (ctlNumBARate.Value == 0) ctlNumBARate.Value = 1;
            ctlNumBAFCAmt.Value = ctlNumBAadjustAmt.Value / ctlNumBARate.Value;
        }

        private void chkSupp_CheckedChanged(object sender, EventArgs e)
        {
            txtSupp.Enabled = chkSupp.Checked;
        }

        private void ctlNumBillQty_valueChanged(object sender, EventArgs e)
        {
            try
            {
                //ctlNumBalQty.Value=ctlNumLCQty.Value
                ctlNumBalQty.Value = ctlNumLCQty.Value - ctlNumBillQty.Value - BalQty;
                //ctlNumBalAmt.Value = ctlNumLcValue.Value - ctlNumBillAmt.Value - BalAmt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteBillAdjust_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            try
            {
                if (dgvLCAdj.SelectedRows.Count == 0) return;
                if (MessageBox.Show("Do you really want to the bill? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                trans = formCon.BeginTransaction();
                int AdjustID = GlobalFunctions.isNull(dgvLCAdj["AdjustID", dgvLCAdj.SelectedRows[0].Index].Value, 0);
                if (AdjustID > 0)
                    new DaBills().DeleteBillAdjust(formCon, trans, AdjustID);

                int TRID = GlobalFunctions.isNull(dgvLCAdj["TransRefID", dgvLCAdj.SelectedRows[0].Index].Value, 0);
                if (TRID > 0)
                    new DaTransaction().DeleteTransaction(TRID, formCon, trans);
                trans.Commit();

                //btnSearch_Click(sender, null);
                //btnReset_Click(sender, null);
                btnFind_Click(null, null);
                cmLCAdjust_PositionChanged(null, null);
                reset();
                MessageBox.Show("Deleted Successfully");
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ctldgvAdjusts.SelectedRows.Count == 0) return;
                if (MessageBox.Show("Do you really want to the bill pay? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                int adjID = GlobalFunctions.isNull(ctldgvAdjusts.SelectedRows[0].Cells["BillAdjustID"].Value, 0);
                new DaBills().DeleteBillAdjust(formCon, adjID);
                Account objSelectedAcc = (Account)txtBillOfAcc.Tag;
                loadBills(objSelectedAcc.AccountID);
                MessageBox.Show("Successfully Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
