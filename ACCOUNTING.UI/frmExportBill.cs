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
    public partial class frmExportBill : Form
    {
        public frmExportBill()
        {
            InitializeComponent();
        }

        DataTable dtBillAccounts = null;
        DataTable dtInvoice = new DataTable();
        DataTable dtRealBillAccounts = null;
        ExportBill objExportBill = null;
        DaExportBill objDaExportBill = null;
        DaTransaction objDaTrans = null;
        SqlConnection formCon = null;
        private void frmExportBill_Load(object sender, EventArgs e)
        {
            try
            {
                objDaExportBill = new DaExportBill();
                objDaTrans = new DaTransaction();
                formCon = ConnectionHelper.getConnection();
                cboBPType.SelectedIndex = 0;
                
                //loadExportBill(-1);
                txtTypeNo.Focus();
                loadInvoiceNos(Convert.ToInt32(txtBEBillID.Text));
                cboBEBillType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadInvoiceNos(int BillID)
        {
            try
            {
                dtInvoice = objDaExportBill.getExportBillInvoices(formCon, BillID);
                dgvInvoices.DataSource = dtInvoice;
                dgvInvoices.Columns["BillID"].Visible = false;
                dgvInvoices.setColumnsWidth(new string[] { "InvoiceNo", "InvoiceValue", "InvoiceQty", "ExpNo", "Comment"}, 120,100,100,120,290);
                dgvInvoices.setColumnsFormat(new string[] { "InvoiceValue", "InvoiceQty" }, "0.00");
                dgvInvoices.Columns["InvoiceValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInvoices.Columns["InvoiceQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTypeNo.Text = cboBPType.SelectedItem.ToString() + " No.";
            txtBPLoanNo.Enabled = cboBPType.SelectedItem.ToString() == "FDBP" || cboBPType.SelectedItem.ToString() == "IDBP" ? true : false;
        }

        private void txtLCNo_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    frmSearchLC frm = new frmSearchLC();
            //    frm.ShowDialog();
            //    int lcID = frm.LCID;

            //    LC_Master lc = new DaLC().GetLC_Master(lcID, formCon);
            //    if (lc == null) return;
            //    txtLCNo.Text = lc.LCNo;
            //    ctlNumLCValue.Value = lc.TotalValue;
            //    ctlnumBillAmt.Value = lc.TotalValue;
            //    txtLCNo.Tag = lc;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void loadExportBill( int ExpBillID)
        {
            try
            {
                dgvSlNo.Rows.Clear();
                #region M

                if (ExpBillID <= 0)
                {
                    txtBPBillID.Text = "0";



                    txtBPLCNo.Text = string.Empty;
                    txtBPLCNo.Tag = null;
                    ctlNumBPLCValue.Value = 0;
                    ctlNumBPLCQty.Value = 0;
                    ctlnumBPBillAmt.Value = 0;
                    string cc = "";
                    lblCurrency1.Text = cc;
                    lblCurrency2.Text = cc;
                    lblCurrency3.Text = cc;
                    txtBPLoanNo.Text = string.Empty;
                    txtTypeNo.Text = string.Empty;

                    dtpPurchaseDate.Value = DateTime.Now;
                    ctlNumBPPurchaseAmtTK.Value = 0;
                    ctlNumBPPurchaseAmt.Value = 0;

                    chkAccDate.Checked = false;
                    dtpAcceptDate.Value = DateTime.Now;


                    chkMaturity.Checked = false;
                    dtpMaturityDate.Value = DateTime.Now;


                }
                else
                {
                    objExportBill = objDaExportBill.getExportBill(formCon, ExpBillID);
                    txtBPBillID.Text = objExportBill.BillID.ToString();


                    if (objExportBill.LCID == -1)
                    {
                        txtBPLCNo.Text = string.Empty;
                        txtBPLCNo.Tag = null;
                        ctlNumBPLCValue.Value = 0;
                        ctlNumBPLCQty.Value = 0;
                    }
                    else
                    {
                        LC_Master lc = new DaLC().GetLC_Master(objExportBill.LCID, formCon);
                        txtBPLCNo.Text = lc.LCNo;
                        txtBPLCNo.Tag = lc;
                        string cc = new DaCurrency().getCurrency(formCon, lc.CurrencyID);
                        lblCurrency1.Text = cc;
                        lblCurrency2.Text = cc;
                        lblCurrency3.Text = cc;
                    }

                    txtBPLoanNo.Text = objExportBill.LoanNo;

                    txtTypeNo.Text = objExportBill.BillNo;

                    if (objExportBill.PurchaseDate == new DateTime(1900, 1, 1))
                        dtpPurchaseDate.Value = DateTime.Now;
                    else
                        dtpPurchaseDate.Value = objExportBill.PurchaseDate;
                    ctlnumBPBillAmt.Value = objExportBill.BillAmount;
                    ctlNumBPLCValue.Value = objExportBill.LCValue;
                    ctlNumBPLCQty.Value = objExportBill.LCQuantity;
                    ctlNumBPPurchaseAmt.Value = objExportBill.PurchaseAmount;
                    if (objExportBill.AcceptDate == new DateTime(1900, 1, 1))
                    {
                        chkAccDate.Checked = false;
                        dtpAcceptDate.Value = DateTime.Now;
                    }
                    else
                    {
                        chkAccDate.Checked = true;
                        dtpAcceptDate.Value = objExportBill.AcceptDate;
                    }
                    if (objExportBill.MaturityDate == new DateTime(1900, 1, 1))
                    {
                        chkMaturity.Checked = false;
                        dtpMaturityDate.Value = DateTime.Now;
                    }
                    else
                    {
                        chkMaturity.Checked = true;
                        dtpMaturityDate.Value = objExportBill.MaturityDate;
                    }
                    ctlNumRate.Value = objExportBill.CurrencyRate;
                }
                #endregion
                #region D

                dtBillAccounts = objDaExportBill.getExportBillAccount(formCon, ExpBillID);
                ctldgvJrAccounts.DataSource = dtBillAccounts;
                //dtBillAccounts.Columns["AccountID"].Unique = true;
                ctldgvJrAccounts.setColumnsVisible(false, "SlNo", "BillID", "AccountID", "Ref");
                ctldgvJrAccounts.Columns["AccountTitle"].ReadOnly = true;
                ctldgvJrAccounts.Columns["Particulars"].HeaderText = "Remarks";
                ctldgvJrAccounts.setColumnsWidth(new string[] { "AccountTitle", "Particulars" }, 250, 200);
                ctldgvJrAccounts.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctldgvJrAccounts.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctldgvJrAccounts.setColumnsFormat(new string[] { "Debit", "Credit" }, "0.00", "0.00");
                getTotal(ctldgvJrAccounts, "Debit", ctlNumJrTotalDrAmt);

                getTotal(ctldgvJrAccounts, "Credit", ctlNumJrTotalCrAmt);
                ctlNumBPPurchaseAmtTK.Value = ctlNumJrTotalCrAmt.Value;
                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadRealizedExportBill(ExportBill expBill)
        {
            int ExpBillID;

            try
            {
                dgvRSlNo.Rows.Clear();
                if (expBill == null)
                    ExpBillID = -1;
                else
                    ExpBillID = expBill.BillID;
                #region M

                if (ExpBillID <= 0)
                {
                    txtRealizedBillNo.Tag =null;
                    txtRealizedBillNo.Text = string.Empty;
                    dtpRealizedDate.Value = DateTime.Now;
                    ctlNumRealizedAmt.Value = 0;
                    ctlNumLoss.Value = 0;

                    ctlNumRBillAmt.Value = 0;
                    ctlNumRPurchaseAmt.Value= 0;
                }
                else
                {
                    txtRealizedBillNo.Tag = expBill;
                    txtRealizedBillNo.Text = expBill.BillNo;
                    if(expBill.RealisedDate !=new DateTime(1900,1,1))
                    dtpRealizedDate.Value = expBill.RealisedDate;
                    ctlNumRealizedAmt.Value = expBill.RealisedAmount;
                    ctlNumLoss.Value = expBill.RealisedLoss;
                    ctlNumRBillAmt.Value = expBill.BillAmount;
                    ctlNumRPurchaseAmt.Value = expBill.PurchaseAmount;
                    ctlNumRRate.Value = expBill.CurrencyRate;
                    ctlNumRBillAmtTK.Value = Math.Round(ctlNumRRate.Value * ctlNumRBillAmt.Value, 2);
                    ctlNumRPurAmtTK.Value = Math.Round(ctlNumRRate.Value * ctlNumRPurchaseAmt.Value, 2);
                }
                #endregion
                #region D
                dtRealBillAccounts = objDaExportBill.getExportBillAccountAtRealization(formCon, ExpBillID);
                ctldgvRealAccounts.DataSource = dtRealBillAccounts;
                //dtRealBillAccounts.Columns["AccountID"].Unique = true;
                ctldgvRealAccounts.setColumnsVisible(false, "SlNo", "BillID", "AccountID","Ref");
                ctldgvRealAccounts.Columns["AccountTitle"].ReadOnly = true;
                ctldgvRealAccounts.Columns["Particulars"].HeaderText = "Remarks";
                ctldgvRealAccounts.setColumnsWidth(new string[] { "AccountTitle", "Particulars" }, 250, 200);
                ctldgvRealAccounts.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctldgvRealAccounts.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctldgvRealAccounts.setColumnsFormat(new string[] { "Debit", "Credit" }, "0.00", "0.00");
                getTotal(ctldgvRealAccounts, "Debit", ctlNumDebit);

                getTotal(ctldgvRealAccounts, "Credit", ctlNumCredit);
                getVoucherCount();
                HighLightPostedAccounts();
                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ctldgvJrAccounts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowID = e.RowIndex;
                if (rowID < 0 || e.ColumnIndex < 0) return; 

                if (ctldgvJrAccounts.Columns[e.ColumnIndex].Name.ToLower() == "Debit".ToLower())
                {
                    ctldgvJrAccounts.Rows[e.RowIndex].Cells["Debit"].ReadOnly = Convert.ToDouble(ctldgvJrAccounts.Rows[e.RowIndex].Cells["Credit"].Value == DBNull.Value ? 0 : ctldgvJrAccounts.Rows[e.RowIndex].Cells["Credit"].Value) > 0 ? true : false;
                }
                if (ctldgvJrAccounts.Columns[e.ColumnIndex].Name.ToLower() == "Credit".ToLower())
                {
                    ctldgvJrAccounts.Rows[e.RowIndex].Cells["Credit"].ReadOnly = Convert.ToDouble(ctldgvJrAccounts.Rows[e.RowIndex].Cells["Debit"].Value == DBNull.Value ? 0 : ctldgvJrAccounts.Rows[e.RowIndex].Cells["Debit"].Value) > 0 ? true : false;
                }
                if (ctldgvJrAccounts.Columns[e.ColumnIndex].Name.ToLower() == "AccountTitle".ToLower())
                {
                    int accID = 0;
                    if (ctldgvJrAccounts.Rows[e.RowIndex].Cells["AccountID"].Value == DBNull.Value || ctldgvJrAccounts.Rows[e.RowIndex].Cells["AccountID"].Value == null)
                        accID = 0;
                    else
                        accID = Convert.ToInt32(ctldgvJrAccounts.Rows[e.RowIndex].Cells["AccountID"].Value);
                    frmAccountSearch frm = new frmAccountSearch();
                    if (accID == 0)
                        frm.ShowDialog();
                    else
                        frm.ShowDialog(accID);

                    Account objSelectedAcc = frm.SelectedAccount;
                    if (objSelectedAcc == null) return;



                    if (CellIntValue(ctldgvJrAccounts.Rows[rowID].Cells["SlNo"].Value) == 0)
                        ctldgvJrAccounts.Rows[rowID].Cells["SlNo"].Value = 0;
                    ctldgvJrAccounts.Rows[rowID].Cells["AccountID"].Value = objSelectedAcc.AccountID;
                   
                    ctldgvJrAccounts.Rows[rowID].Cells["AccountTitle"].Value = objSelectedAcc.AccountTitle;

                    ctldgvJrAccounts.EndEdit();
                    //ctldgvJrAccounts.CurrentCell = ctldgvJrAccounts.Rows[rowID].Cells["Debit"];
                    SendKeys.Send("{TAB}");
                    //SendKeys.Send("{TAB}");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvJrAccounts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Black;
            e.CellStyle.ForeColor = Color.White;
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            dtpAcceptDate.Enabled = chkAccDate.Checked;
            dtpMaturityDate.Enabled = chkMaturity.Checked;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                loadExportBill(-1);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    MessageBox.Show(ex.Message);
                else throw ex;
            }
        }

        private void ctldgvJrAccounts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ctldgvJrAccounts.Columns[e.ColumnIndex].Name.ToLower() == "Debit".ToLower())
                    getTotal(ctldgvJrAccounts, "Debit", ctlNumJrTotalDrAmt);
                if (ctldgvJrAccounts.Columns[e.ColumnIndex].Name.ToLower() == "Credit".ToLower())
                    getTotal(ctldgvJrAccounts, "Credit", ctlNumJrTotalCrAmt);
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
                    sum += Math.Round( Convert.ToDouble(ctldgv.Rows[i].Cells[cellName].Value),2);
                }
                ctl.Value = Math.Round(sum, 2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void getVoucherCount()
        {
            try
            {
                int c = 0;
                for (int i = 0; i < ctldgvRealAccounts.Rows.Count - 1; i++)
                {
                    if (GlobalFunctions.isNull(ctldgvRealAccounts[VoucherType.Name, i].Value, "") != "")
                        c++;
                }
                lblVCount.Text =  c.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private int CellIntValue(object o)
        {
            if (o == null || o == DBNull.Value)
                return 0;
            else
                return Convert.ToInt32(o);
        }
        private double CellDoubleValue(object o)
        {
            if (o == null || o == DBNull.Value)
                return 0;
            else
                return Convert.ToDouble(o);
        }
        private void btnJrRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (ctldgvJrAccounts.CurrentRow == null) return;
                int rowID = ctldgvJrAccounts.CurrentRow.Index;
                if (rowID < 0) return;
                int SLno =  GlobalFunctions.isNull( ctldgvJrAccounts.Rows[rowID].Cells["SlNo"].Value,0);

                //dtJrTab.Rows[rowID].Delete();
                ctldgvJrAccounts.Rows.RemoveAt(rowID);
                if (SLno != 0)
                    dgvSlNo.Rows.Add(SLno, 0);
                getTotal(ctldgvJrAccounts, "Debit", ctlNumJrTotalDrAmt);

                getTotal(ctldgvJrAccounts, "Credit", ctlNumJrTotalCrAmt);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private double PostedAmount(ctlDaraGridView ctl,string postColName)
        {
            try
            {
                double postDrAmt = 0, postCrAmt = 0;
                int i, nR;
                nR = ctl.Rows.Count;
                for (i = 0; i < nR - 1; i++)
                {
                    if (CellValue(ctl.Rows[i].Cells[postColName].Value) == 1)
                    {
                        postDrAmt += Math.Round( CellValue(ctl.Rows[i].Cells["Debit"].Value),2);
                        postCrAmt += Math.Round( CellValue(ctl.Rows[i].Cells["Credit"].Value),2);
                    }
                }
                return Math.Round( postDrAmt - postCrAmt,2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool BillEntryValidation(string Tab)
        {
            if (Tab == "Purchase")
            {
                if (txtTypeNo.Text.Trim() == "")
                {
                    MessageBox.Show("Enter valid Bill No.");
                    return false;
                }
                if (PostedAmount(ctldgvJrAccounts, "posted") != 0)
                {
                    MessageBox.Show("Posted Debit and Credit amount is not equal");
                    return false;
                }
                if (ctlNumJrTotalDrAmt.Value != ctlNumJrTotalCrAmt.Value)
                {
                    MessageBox.Show("Total Debit and Credit amount is not equal");
                    return false;
                }
                if (ctlNumBPPurchaseAmtTK.Value != ctlNumJrTotalCrAmt.Value)
                {
                    MessageBox.Show("Total Debit and Credit amount is not equal to Purchase amount");
                    return false;
                }
                if (txtBPLCNo.Tag == null)
                {
                    MessageBox.Show("Correctly Select the LC");
                    return false;
                }
                
            }
            else if (Tab == "Bill Entry")
            {
                if (txtBEBillNo.Text.Trim() == "")
                {
                    MessageBox.Show("Enter valid Bill No.");
                    return false;
                }
                if (txtBELCNo.Tag==null)
                {
                    MessageBox.Show("Select a LC");
                    return false;
                }
                if (ctlNumBEBillAmt.Value<=0)
                {
                    MessageBox.Show("Enter valid Bill Amount");
                    return false;
                }
                //if (/*ctlNumBEBalAmt.Value < 0 &&*/ Convert.ToInt32(txtBEBillID.Text)<=0)
                //{
                //    MessageBox.Show("Such bill amount is not avaiable.");
                //    return false;
                //}
            }
            else
            {
                if (PostedAmount(ctldgvRealAccounts, "posting") != 0)
                {
                    MessageBox.Show("Posted Debit and Credit amount is not equal");
                    return false;
                }
                if (ctlNumDebit.Value != ctlNumCredit.Value)
                {
                    MessageBox.Show("Total Debit and Credit amount is not equal");
                    return false;
                }
                if (ctlNumRealizedAmt.Value <= 0)
                {
                    MessageBox.Show("Correctly Entry the Realized Amount");
                    return false;
                }
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            try
            {
                if (BillEntryValidation("Purchase") == false) return;
                //objExportBill = CreateExportBillObject();
                int BillID;
                string BillType,LoanNo;
                double Pamt;
                DateTime pDate,aDate,mDate;
                BillID=Convert.ToInt32(txtBPBillID.Text);
                BillType=cboBPType.SelectedItem.ToString();
                LoanNo=txtBPLoanNo.Text;
                Pamt=ctlNumBPPurchaseAmt.Value;
                pDate=dtpPurchaseDate.Value.Date;
                if (chkAccDate.Checked)
                    aDate = dtpAcceptDate.Value.Date;
                else
                    aDate = new DateTime(1900, 1, 1);
                if (chkMaturity.Checked)
                    mDate = dtpMaturityDate.Value.Date;
                else
                    mDate = new DateTime(1900, 1, 1);
                double rate = ctlNumRate.Value;

                int lcID = objDaExportBill.getExportBill(formCon,BillID).LCID;
                string LcNo = new DaLC().GetLC_Master(lcID, formCon).LCNo;
                trans = formCon.BeginTransaction();
                 BillID = objDaExportBill.PurchaseExportBill(BillID,BillType,pDate,Pamt,LoanNo,aDate,mDate,rate, formCon, trans);
                int i, nR;
                int nPosted = 0;
                nR = dgvSlNo.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    objDaExportBill.DeleteExportBillAccount(formCon, trans, Convert.ToInt32(dgvSlNo.Rows[i].Cells[0].Value));
                }
                nR = ctldgvJrAccounts.Rows.Count;
                BillAccount objBAC = new BillAccount();
                string reff = "";
                for (i = 0; i < nR - 1; i++)
                {
                    //if (CellValue(ctldgvJrAccounts.Rows[i].Cells["posted"].Value) == 1)
                    //{
                        
                        reff = "First Voucher";
                    //}
                    //else
                    //{
                    //    reff = "";
                    //}
                    objBAC = CreateBillAccObject(Convert.ToInt32(ctldgvJrAccounts.Rows[i].Cells["SlNo"].Value), BillID, Convert.ToInt32(ctldgvJrAccounts.Rows[i].Cells["AccountID"].Value), ctldgvJrAccounts.Rows[i].Cells["Particulars"].Value.ToString(),Math.Round( CellValue(ctldgvJrAccounts.Rows[i].Cells["Debit"].Value),2),Math.Round( CellValue(ctldgvJrAccounts.Rows[i].Cells["Credit"].Value),2), Convert.ToInt32(CellValue(ctldgvJrAccounts.Rows[i].Cells["posted"].Value)),reff,"",0);
                    objDaExportBill.SaveUpdateBillAccount(objBAC, formCon, trans);
                    if (CellValue(ctldgvJrAccounts.Rows[i].Cells["posted"].Value) == 1)
                        nPosted += 1;
                }
                if (nPosted > 0)
                {
                    #region TransDesc
                    string TDesc = "";
                    for (i = 0; i < nR - 1; i++)
                    {
                        TDesc += GlobalFunctions.isNull(ctldgvJrAccounts.Rows[i].Cells["Particulars"].Value, "");

                        if (i != nR - 2)
                            TDesc += Environment.NewLine;

                    }
                    #endregion
                    TransactionMaster objTM = CreateTransMasterObject(dtpPurchaseDate.Value.Date, trans, 4, lcID, LcNo, 1, TDesc);
                    int transID = objDaTrans.SaveEditTransactionMaster(objTM, formCon, trans);



                    TransactionDetail objTD = new TransactionDetail();
                    for (i = 0; i < nR - 1; i++)
                    {
                        if (CellValue(ctldgvJrAccounts.Rows[i].Cells["posted"].Value) == 1)
                        {
                            objTD = CreateTransDetailObject(0, transID, Convert.ToInt32(ctldgvJrAccounts.Rows[i].Cells["AccountID"].Value),Math.Round( CellValue(ctldgvJrAccounts.Rows[i].Cells["Credit"].Value),2), Math.Round( CellValue(ctldgvJrAccounts.Rows[i].Cells["Debit"].Value),2));
                            objDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);
                        }

                    }
                    objDaExportBill.UpdateTransRefIDinExportBill(formCon, trans, BillID, transID);
                }

                trans.Commit();
                btnReset_Click(null, null);
                MessageBox.Show("Save OK");
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();

                MessageBox.Show(ex.Message);
            }
        }

        private double CellValue(object obj)
        {
            
            if (obj == null || obj == DBNull.Value)
                return 0;
            else
              return   Convert.ToDouble(obj);
        }
        private ExportBill CreateExportBillObject()
        {
            ExportBill objEB = null;
            try
            {
                objEB = new ExportBill();
                objEB.BillID = int.Parse(txtBPBillID.Text);
                
                objEB.BillType = cboBPType.SelectedItem.ToString();
                objEB.BillNo = txtTypeNo.Text.Trim();
               
                objEB.BillDate = dtpPurchaseDate.Value.Date;
                objEB.BillAmount = ctlnumBPBillAmt.Value;
                
                objEB.LoanNo = txtBPLoanNo.Text.Trim();
                if (txtBPLCNo.Tag != null)
                {
                    objEB.LCID = ((LC_Master)txtBPLCNo.Tag).LCID;
                    objEB.LCValue = ctlNumBPLCValue.Value;
                }
                else
                {
                    objEB.LCID = -1;
                    objEB.LCValue = 0;
                }
                objEB.RealisedAmount = 0;
                objEB.RealisedDate = new DateTime(1900, 1, 1);
                objEB.RealisedLoss = 0;
                if (chkAccDate.Checked)
                    objEB.AcceptDate = dtpAcceptDate.Value.Date;
                else
                    objEB.AcceptDate = new DateTime(1900, 1, 1);

                if (chkMaturity.Checked)
                    objEB.MaturityDate = dtpMaturityDate.Value.Date;
                else
                    objEB.MaturityDate = new DateTime(1900, 1, 1);

                //objEB.remarks = txtRemark.Text;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objEB;
        }

        private BillAccount CreateBillAccObject(int slNo,int billID,int AccID,string prtclrs ,double Dr,double Cr,int posted,string Reff,string VType,int VSlNo)
   
        {
            BillAccount objBA = null;
            try
            {
                objBA = new BillAccount();
                objBA.SlNo = slNo;
                objBA.BillID = billID;
                objBA.AccountID = AccID;
                objBA.Particulars = prtclrs;
                objBA.DebitAmount = Dr;
                objBA.CreditAmount = Cr;
                objBA.Posted = posted;
                objBA.Reference = Reff;
                objBA.VoucherType = VType;
                objBA.VoucherSlNo = VSlNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objBA;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            try
            {
                frmSearchExportBill frm = new frmSearchExportBill();
                frm.ShowDialog(1,-1);
                if (frm.SelectedExportBill == null) return;
                loadExportBill(frm.SelectedExportBill.BillID);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void txtRealizedBillNo_Enter(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        frmSearchExportBill frm = new frmSearchExportBill();
        //        frm.ShowDialog();
        //        if (frm.SelectedExportBill == null) return;
        //        loadRealizedExportBill(frm.SelectedExportBill);

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void ctldgvRealAccounts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType() != typeof(DataGridViewComboBoxEditingControl))
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            else
                SendKeys.Send("{F4}");
        }

        private void ctldgvRealAccounts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowID = e.RowIndex;
                if (rowID < 0 || e.ColumnIndex < 0) return; ;

                if (ctldgvRealAccounts.Rows[rowID].ReadOnly == false)
                {
                    if (ctldgvRealAccounts.Columns[e.ColumnIndex].Name.ToLower() == "Debit".ToLower())
                    {
                        ctldgvRealAccounts.Rows[e.RowIndex].Cells["Debit"].ReadOnly = Convert.ToDouble(ctldgvRealAccounts.Rows[e.RowIndex].Cells["Credit"].Value == DBNull.Value ? 0 : ctldgvRealAccounts.Rows[e.RowIndex].Cells["Credit"].Value) > 0 ? true : false;
                    }
                    if (ctldgvRealAccounts.Columns[e.ColumnIndex].Name.ToLower() == "Credit".ToLower())
                    {
                        ctldgvRealAccounts.Rows[e.RowIndex].Cells["Credit"].ReadOnly = Convert.ToDouble(ctldgvRealAccounts.Rows[e.RowIndex].Cells["Debit"].Value == DBNull.Value ? 0 : ctldgvRealAccounts.Rows[e.RowIndex].Cells["Debit"].Value) > 0 ? true : false;
                    }
                    if (ctldgvRealAccounts.Columns[e.ColumnIndex].Name.ToLower() == "AccountTitle".ToLower())
                    {
                        int accID = 0;
                        if (ctldgvRealAccounts.Rows[e.RowIndex].Cells["AccountID"].Value == DBNull.Value || ctldgvRealAccounts.Rows[e.RowIndex].Cells["AccountID"].Value == null)
                            accID = 0;
                        else
                            accID = Convert.ToInt32(ctldgvRealAccounts.Rows[e.RowIndex].Cells["AccountID"].Value);
                        frmAccountSearch frm = new frmAccountSearch();
                        if (accID == 0)
                            frm.ShowDialog();
                        else
                            frm.ShowDialog(accID);
                        Account objSelectedAcc = frm.SelectedAccount;
                        if (objSelectedAcc == null) return;



                        if (CellIntValue(ctldgvRealAccounts.Rows[rowID].Cells["SlNo"].Value) == 0)
                            ctldgvRealAccounts.Rows[rowID].Cells["SlNo"].Value = 0;
                        ctldgvRealAccounts.Rows[rowID].Cells["AccountID"].Value = objSelectedAcc.AccountID;

                        ctldgvRealAccounts.Rows[rowID].Cells["AccountTitle"].Value = objSelectedAcc.AccountTitle;

                        ctldgvRealAccounts.EndEdit();
                        //ctldgvJrAccounts.CurrentCell = ctldgvJrAccounts.Rows[rowID].Cells["Debit"];
                        SendKeys.Send("{TAB}");
                        //SendKeys.Send("{TAB}");


                    }
                    if (ctldgvRealAccounts.Columns[e.ColumnIndex].Name == VoucherType.Name)
                    {

                        double sum = 0;
                        for (int k = e.RowIndex-1; k >= 0; k--)
                        {
                            sum += Math.Round( GlobalFunctions.isNull(ctldgvRealAccounts["Debit", k].Value, 0.0),2) - Math.Round( GlobalFunctions.isNull(ctldgvRealAccounts["Credit", k].Value, 0.0),2);
                        }
                        ctldgvRealAccounts.Rows[e.RowIndex].Cells[VoucherType.Name].ReadOnly = (Math.Round( sum,2) != 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvRealAccounts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ctldgvRealAccounts.Columns[e.ColumnIndex].Name.ToLower() == "Debit".ToLower())
                    getTotal(ctldgvRealAccounts, "Debit", ctlNumDebit);
                if (ctldgvRealAccounts.Columns[e.ColumnIndex].Name.ToLower() == "Credit".ToLower())
                    getTotal(ctldgvRealAccounts, "Credit", ctlNumCredit);
                if (ctldgvRealAccounts.Columns[e.ColumnIndex].Name == VoucherType.Name)
                {
                    getVoucherCount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            try
            {
                if (BillEntryValidation("Realize") == false) return;
                ExportBill objREB = (ExportBill)txtRealizedBillNo.Tag;
                if (objREB == null) return;


                int lcID = objREB.LCID;
                string LcNo = new DaLC().GetLC_Master(lcID, formCon).LCNo;

                trans = formCon.BeginTransaction();
                int BillID = objDaExportBill.RealizeExportBill(objREB.BillID, dtpRealizedDate.Value.Date, ctlNumRealizedAmt.Value, ctlNumLoss.Value, -1, ctlNumRRate.Value, formCon, trans);
                int i, nR;
                int nPosted = 0;
                nR = dgvRSlNo.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    objDaExportBill.DeleteExportBillAccount(formCon, trans, Convert.ToInt32(dgvRSlNo.Rows[i].Cells[0].Value));
                }
                nR = ctldgvRealAccounts.Rows.Count;
                BillAccount objBAC = new BillAccount();
                string Vt;
                int VSLN=0;
                for (i = 0; i < nR - 1; i++)
                {
                    if (ctldgvRealAccounts.Rows[i].ReadOnly == true) continue;
                    Vt = GlobalFunctions.isNull(ctldgvRealAccounts["VoucherType", i].Value, "");
                    if (Vt != "")
                        VSLN++;
                    objBAC = CreateBillAccObject(Convert.ToInt32(ctldgvRealAccounts.Rows[i].Cells["SlNo"].Value), BillID, Convert.ToInt32(ctldgvRealAccounts.Rows[i].Cells["AccountID"].Value), ctldgvRealAccounts.Rows[i].Cells["Particulars"].Value.ToString(),Math.Round( CellValue(ctldgvRealAccounts.Rows[i].Cells["Debit"].Value),2), Math.Round( CellValue(ctldgvRealAccounts.Rows[i].Cells["Credit"].Value),2), Convert.ToInt32(CellValue(ctldgvRealAccounts.Rows[i].Cells["posting"].Value)), "", Vt, VSLN);
                    objDaExportBill.SaveUpdateBillAccount(objBAC, formCon, trans);
                    if (CellValue(ctldgvRealAccounts.Rows[i].Cells["Posting"].Value) == 1)
                        nPosted += 1;
                }
                if (nPosted > 0)
                {

                    
                    string TRIDs = "";
                    TransactionMaster objTM;
                    TransactionDetail objTD;
                    int transID=0;
                    int VoucherTypeID=-1;
                    string strV;
                    for (i = 0; i < nR - 1; i++)
                    {
                        strV = GlobalFunctions.isNull(ctldgvRealAccounts["VoucherType", i].Value, "");
                        if (strV != "")
                        {
                            switch (strV)
                            {
                                case "Credit Voucher": VoucherTypeID = 1; break;
                                case "Debit Voucher": VoucherTypeID = 2; break;
                                case "Journal Voucher": VoucherTypeID = 3; break;
                                default: VoucherTypeID = -1; break;
                            }

                            #region TransDesc
                            string TDesc = GlobalFunctions.isNull(ctldgvRealAccounts.Rows[i].Cells["Particulars"].Value, "") + Environment.NewLine;
                            for (int j = i+1; j < nR-1; j++)
                            {
                                if (GlobalFunctions.isNull(ctldgvRealAccounts["VoucherType", j].Value, "") != "") break;
                                TDesc += GlobalFunctions.isNull(ctldgvRealAccounts.Rows[j].Cells["Particulars"].Value, "");

                                //if (j != i - 1)
                                    TDesc += Environment.NewLine;

                               

                            }
                            #endregion

                            objTM = CreateTransMasterObject(dtpRealizedDate.Value.Date, trans, 4, lcID, LcNo, VoucherTypeID, TDesc);
                            transID = objDaTrans.SaveEditTransactionMaster(objTM, formCon, trans);
                            TRIDs += "," + transID.ToString();
                        }
                        objTD = new TransactionDetail();

                        //if (ctldgvRealAccounts.Rows[i].ReadOnly == true) continue;
                        if (CellValue(ctldgvRealAccounts.Rows[i].Cells["posting"].Value) == 1)
                        {
                            objTD = CreateTransDetailObject(0, transID, Convert.ToInt32(ctldgvRealAccounts.Rows[i].Cells["AccountID"].Value),Math.Round( CellValue(ctldgvRealAccounts.Rows[i].Cells["Credit"].Value),2), Math.Round( CellValue(ctldgvRealAccounts.Rows[i].Cells["Debit"].Value),2));
                            objDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);
                        }

                    }
                   
                    objDaExportBill.UpdateRealizedTransRefIDsinExportBill(formCon, trans, BillID, TRIDs);
                }

                trans.Commit();
                loadRealizedExportBill(null);
                MessageBox.Show("Realized Successfully", "Export Bill");
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private TransactionMaster CreateTransMasterObject(DateTime transDate, SqlTransaction trans,int TramsMID, int MethodRefID, string MethodRefNo,int VoucherTypeID,string TransDesc)
        {
            TransactionMaster objTM = new TransactionMaster();
            try
            {
                string Vprefix = "C";
                switch (VoucherTypeID)
                {
                    case 1: Vprefix = "C"; break;
                    case 2: Vprefix = "D"; break;
                    case 3: Vprefix = "J"; break;
                };
                objTM.TransactionMasterID = 0;//int.Parse(txtJrTMID.Text);
                objTM.TransactionDate = transDate;
                objTM.VoucherNo = objDaTrans.getVoucherNo(formCon, trans, Vprefix);
                objTM.VoucherPayee = "";
                objTM.VoucherType = VoucherTypeID; //1
                objTM.TransactionMethodID = TramsMID;// 4;
                objTM.MethodRefID = MethodRefID;
                objTM.MethodRefNo = MethodRefNo;
                objTM.TransactionDescription = TransDesc;

                objTM.ApprovedBy = "Export Bill Manager";
                objTM.ApprovedDate = transDate;
                objTM.Module = "Export Bill";



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
        private void HighLightPostedAccounts()
        {
            try
            {
                int i, nR;
                nR = ctldgvRealAccounts.Rows.Count;
                for (i = 0; i < nR-1; i++)
                {
                    if (ctldgvRealAccounts.Rows[i].Cells["Ref"].Value.ToString() == "First Voucher")
                    {
                        ctldgvRealAccounts.Rows[i].ReadOnly = true;
                        ctldgvRealAccounts.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                        ctldgvRealAccounts.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tpRealisation_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    SendKeys.Send("{TAB}");
            //    loadRealizedExportBill(null);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void tpEntry_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    btnReset_Click(null, null);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnRRemove_Click(object sender, EventArgs e)
        {
            try
            {
                ctlDaraGridView dgv = null;

                switch (((Button)sender).Name)
                {
                    case "btnRRemove": dgv = ctldgvRealAccounts; break;
                    //case "btnDrRemove": dgv = ctldgvRealAccountsDr; break;
                    //case "btnJrRRemove": dgv = ctldgvRealAccountsJr; break;
                };

                if (dgv.CurrentRow == null) return;
                if (dgv.CurrentRow.ReadOnly == true) return;
                int rowID = dgv.CurrentRow.Index;
                if (rowID < 0) return;
                int SLno = dgv.Rows[rowID].Cells["SlNo"].Value == null || dgv.Rows[rowID].Cells["SlNo"].Value == DBNull.Value ? 0 : Convert.ToInt32(dgv.Rows[rowID].Cells["SlNo"].Value);

                //dtJrTab.Rows[rowID].Delete();
                dgv.Rows.RemoveAt(rowID);
                if (SLno != 0)
                    dgvRSlNo.Rows.Add(SLno, 0);
                getTotal(dgv, "Debit", ctlNumDebit);

                getTotal(dgv, "Credit", ctlNumCredit);
                getVoucherCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlNumLoss_valueChanged(object sender, EventArgs e)
        {
            ctlNumRealizedAmt.Value = Math.Round(ctlNumRBillAmt.Value - ctlNumLoss.Value, 2);
        }

        private void frmExportBill_Paint(object sender, PaintEventArgs e)
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

        private void tp_Paint(object sender, PaintEventArgs e)
        {
            try
            {

                FormColorClass.ColorTabControl((TabPage)sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void cboType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void cboInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtLCNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TextBox txt = (TextBox)sender;
                    frmSearchLC frm = new frmSearchLC();
                    DataTable dt = new DataTable();
                    frm.ShowDialog();
                    int lcID = frm.LCID;

                    LC_Master lc = new DaLC().GetLC_Master(lcID, formCon);
                    if (lc == null) return;
                    txt.Text = lc.LCNo;
                    if (sender.Equals(txtBELCNo))
                    {
                        ctlNumBELCValue.Value = lc.TotalValue;
                        ctlNumBELCQty.Value = lc.TotalQty;
                        double[] QV = new DaExportBill().getAvaiableQtyValueForBill(formCon, lc.LCID);
                        lblAvailQty.Text = QV[0].ToString("0.00");
                        lblAvailValue.Text = QV[1].ToString("0.00");
                        //addInvoice(lc.LCID);
                    }
                    //ctlNumLCValue.Value = lc.TotalValue;
                    //ctlnumBillAmt.Value = lc.TotalValue;
                    txt.Tag = lc;
                    txtBELCNo.Tag = lc;
                    lblCurrency.Text = new DaCurrency().getCurrency(formCon,lc.CurrencyID);
                    SelectNextControl((Control)sender, true, true, true, true);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void addInvoice(int LcId)
        {DataTable dt=new DataTable();
            try
            {
                dt = new DaBills().getInvoice(formCon, LcId);
                //dgvInvoices.DataSource = dt;
                //dgvInvoices.setColumnsVisible(false, "ComInvoiceID", "ComInvoiceDate", "ExpDate");
                int i, nR = dt.Rows.Count;
                if (nR == 0) return;
                for (i = 0; i < nR; i++)
                {
                    dtInvoice.Rows.Add(
                        null, dt.Rows[i].Field<object>("InvoiceNo"), dt.Rows[i].Field<object>("InvoiceQty"),
                        dt.Rows[i].Field<object>("InvoiceValue"), dt.Rows[i].Field<object>("ExpNo"),
                        dt.Rows[i].Field<object>("Comment")
                        );
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ctlNumLCValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void ctlnumBillAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void chkAccDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void dtpAcceptDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void chkMaturity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void dtpMaturityDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void dtpBillDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtTypeNo_KeyDown(object sender, KeyEventArgs e)
        {
            
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmSearchExportBill frm = new frmSearchExportBill();
                    frm.ShowDialog(0,0);
                    if (frm.SelectedExportBill == null) return;
                    loadExportBill(frm.SelectedExportBill.BillID);
                    SelectNextControl((Control)sender, true, true, true, true);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtLoanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtExpNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void ctldgvJrAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void dgvSlNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void ctlNumJrTotalDrAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnReset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void cboType_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void cboInvoiceNo_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void txtTypeNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtLoanNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtExpNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtRemark_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtRemark_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtExpNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtLoanNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtTypeNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtBillNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtBillNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtRealizedBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    
                    frmSearchExportBill frm = new frmSearchExportBill();
                    frm.ShowDialog(1,0);
                    if (frm.SelectedExportBill == null) return;
                    loadRealizedExportBill(frm.SelectedExportBill);
                    
                    SelectNextControl((Control)sender, true, true, true, true);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpRealizedDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void ctlNumRealizedAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void ctlNumLoss_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void dgvRSlNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void ctldgvRealAccounts_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtRealizedBillNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtRealizedBillNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void btnAmendment_Click(object sender, EventArgs e)
        {

        }

        private void dgvInvoices_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            e.CellStyle.BackColor = Color.Black;
            e.CellStyle.ForeColor = Color.White;
        }

        private void dgvInvoices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvInvoices.Columns[e.ColumnIndex].Name.ToLower() == "InvoiceQty".ToLower())
                    getTotal(dgvInvoices, "InvoiceQty", ctlNumTotalQty);
                if (dgvInvoices.Columns[e.ColumnIndex].Name.ToLower() == "InvoiceValue".ToLower())
                {
                    getTotal(dgvInvoices, "InvoiceValue", ctlNumTotalValue);
                    ctlNumBEBillAmt.Value = ctlNumTotalValue.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBEsave_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            try
            {
                if (BillEntryValidation("Bill Entry") == false) return;
                objExportBill = CreateExportBillObject_BillEntry();
                trans = formCon.BeginTransaction();
                int BillID = objDaExportBill.SaveUpdateExportBill(objExportBill, formCon, trans);
                int i, nR;
                double InvQty, InvAmt;
                string InvNo, ExpNo, cmnt;
                ExportBillInvoices objInv = new ExportBillInvoices();
                objDaExportBill.DeleteInvoices(formCon, trans, BillID);
                nR = dgvInvoices.Rows.Count;

                for (i = 0; i < nR - 1; i++)
                {
                    InvNo = dgvInvoices["InvoiceNo", i].Value.ToString();
                    InvQty = dgvInvoices["InvoiceQty", i].Value == DBNull.Value || dgvInvoices["InvoiceQty", i].Value == null ? 0.0 : Convert.ToDouble(dgvInvoices["InvoiceQty", i].Value);
                    InvAmt = dgvInvoices["InvoiceValue", i].Value == DBNull.Value || dgvInvoices["InvoiceValue", i].Value == null ? 0.0 : Convert.ToDouble(dgvInvoices["InvoiceValue", i].Value);
                    ExpNo = dgvInvoices["ExpNo", i].Value.ToString();
                    cmnt = dgvInvoices["Comment", i].Value.ToString();

                    objInv = CreateInvoiceObject(BillID, InvNo, InvQty, InvAmt, ExpNo, cmnt);
                    objDaExportBill.InsertExportBillInvoices(formCon, trans, objInv);
                }

                trans.Commit();
                btnBEReset_Click(sender, null);
                MessageBox.Show("Save OK");
            }
            catch (SqlException sex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show("Error in " + sex.Procedure+Environment.NewLine+ sex.Number.ToString());
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();

                MessageBox.Show(ex.Message);
            }
        }

        private ExportBillInvoices CreateInvoiceObject(int billID,string InvNo,double InvQty,double InvAmt,string Exp,string cmnt)
        {
            ExportBillInvoices objInv = null;
            try
            {
                objInv = new ExportBillInvoices();
                objInv.BillID = billID;
                objInv.InvoiceNo = InvNo;
                objInv.InvoiceQuantity = InvQty;
                objInv.InvoiceValue = InvAmt;
                objInv.ExpNo = Exp;
                objInv.Comment = cmnt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objInv;
        }
        private ExportBill CreateExportBillObject_BillEntry()
        {
            ExportBill objEB = null;
            try
            {
                objEB = new ExportBill();
                objEB.BillID = int.Parse(txtBEBillID.Text);

                objEB.BillType = cboBEBillType.SelectedItem.ToString();
                objEB.BillNo = txtBEBillNo.Text.Trim();

                objEB.BillDate = dtpBillEntryDate.Value.Date;
                objEB.BillAmount = ctlNumBEBillAmt.Value;

                objEB.LoanNo = string.Empty;
                if (txtBELCNo.Tag != null)
                {
                    LC_Master lc=(LC_Master)txtBELCNo.Tag;
                    objEB.LCID = lc.LCID;
                    objEB.LCValue = ctlNumBELCValue.Value;
                    objEB.LCQuantity = ctlNumBELCQty.Value;
                    objEB.CurrencyID = lc.CurrencyID;
                }
                else
                {
                    objEB.LCID = -1;
                    objEB.LCValue = 0;
                    objEB.LCQuantity = 0;
                    objEB.CurrencyID = 0;
                }
                objEB.RealisedAmount = 0;
                objEB.RealisedDate = new DateTime(1900, 1, 1);
                objEB.RealisedLoss = 0;
                objEB.AcceptDate = new DateTime(1900, 1, 1);

                objEB.MaturityDate = new DateTime(1900, 1, 1);
                objEB.PurchaseAmount = 0;
                objEB.PurchaseDate = new DateTime(1900, 1, 1);
                objEB.TransactionRefID = -1;
                objEB.RealizedTransactionRefID = -1;
                
                objEB.remarks = txtBERemarks.Text;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objEB;
        }
        private void loadExportBillBillEntry(int ExpBillID)
        {
            try
            {
                #region M

                if (ExpBillID <= 0)
                {
                    txtBEBillID.Text = "0";



                    txtBELCNo.Text = string.Empty;
                    txtBELCNo.Tag = null;



                    txtBERemarks.Text = string.Empty;
                    txtBEBillNo.Text = string.Empty;

                    dtpBillEntryDate.Value = DateTime.Now;
                    ctlNumBEBillAmt.Value = 0;
                    ctlNumBELCValue.Value = 0;
                    ctlNumBELCQty.Value = 0;
                   
                    lblAvailQty.Text= "0.00";
                    lblAvailValue.Text = "0.00";
                    lblCurrency.Text = "";
                }
                else
                {
                    objExportBill = objDaExportBill.getExportBill(formCon, ExpBillID);
                    txtBEBillID.Text = objExportBill.BillID.ToString();


                    if (objExportBill.LCID == -1)
                    {
                        txtBELCNo.Text = string.Empty;
                        txtBELCNo.Tag = null;
                        ctlNumBELCValue.Value = 0;
                        ctlNumBELCQty.Value = 0;
                        lblCurrency.Text = "";
                    }
                    else
                    {
                        LC_Master lc = new DaLC().GetLC_Master(objExportBill.LCID, formCon);
                        txtBELCNo.Text = lc.LCNo;
                        txtBELCNo.Tag = lc;
                        ctlNumBELCValue.Value = lc.TotalValue;
                        ctlNumBELCQty.Value = lc.TotalQty;
                        double[] QV = new DaExportBill().getAvaiableQtyValueForBill(formCon, lc.LCID);
                        lblAvailQty.Text = QV[0].ToString("0.00");
                        lblAvailValue.Text = QV[1].ToString("0.00");
                        lblCurrency.Text = new DaCurrency().getCurrency(formCon, lc.CurrencyID);
                    }


                    txtBERemarks.Text = objExportBill.remarks;
                    txtBEBillNo.Text = objExportBill.BillNo;

                    dtpBillEntryDate.Value = objExportBill.BillDate;
                    ctlNumBEBillAmt.Value = objExportBill.BillAmount;


                }
                #endregion
                #region D
                loadInvoiceNos(ExpBillID);

                getTotal(dgvInvoices, "InvoiceQty", ctlNumTotalQty);

                getTotal(dgvInvoices, "InvoiceValue", ctlNumTotalValue);
                ctlNumBEBillAmt.Value = ctlNumTotalValue.Value;



                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnBEReset_Click(object sender, EventArgs e)
        {
            try
            {
                loadExportBillBillEntry(-1);
            }
            catch (Exception ex)
            {
                if (sender.Equals(btnBEReset))
                    MessageBox.Show(ex.Message);
                else
                    throw ex;
            }
        }

        private void btnBEFind_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearchExportBill frm = new frmSearchExportBill();
                frm.ShowDialog(-1,-1);
                if (frm.SelectedExportBill == null) return;
                loadExportBillBillEntry(frm.SelectedExportBill.BillID);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctlNumBEBillAmt_valueChanged(object sender, EventArgs e)
        {
            ctlNumBEBalAmt.Value = Convert.ToDouble(lblAvailValue.Text) - ctlNumBEBillAmt.Value;
        }

        private void ctlNumBPPurchaseAmtTK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {

                
            }
        }

        private void tpBillEntry_Enter(object sender, EventArgs e)
        {
            //try
            //{
            //    btnBEReset_Click(null, null);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void ctlNumRate_valueChanged(object sender, EventArgs e)
        {
            ctlNumBPPurchaseAmtTK.Value = Math.Round(ctlNumBPPurchaseAmt.Value * ctlNumRate.Value, 2);
        }

        private void btnBEDelete_Click(object sender, EventArgs e)
        {
            SqlTransaction trans=null;
            try
            {
                int BID = Convert.ToInt32(txtBEBillID.Text);
                if (BID <= 0) return;
                if (MessageBox.Show("Do you really want to delete this export bill?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                
                trans=formCon.BeginTransaction();
                objDaExportBill.DeleteExportBill(formCon, trans,BID , "BE");
                trans.Commit();
                btnBEReset_Click(null, null);
                MessageBox.Show("Deleted Successfully");
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBPDelete_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            try
            {
                int Bid = Convert.ToInt32(txtBPBillID.Text);
                if (Bid <= 0) return;
                if (MessageBox.Show("Do you really want to delete this purchase?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
               
                trans = formCon.BeginTransaction();
                objDaExportBill.DeleteExportBill(formCon, trans,Bid , "BP");
                trans.Commit();
                btnReset_Click(null, null);
                MessageBox.Show("Deleted Successfully");
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRDelete_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            try
            {
                ExportBill objREB = (ExportBill)txtRealizedBillNo.Tag;
                if (objREB == null) return;
                if (MessageBox.Show("Do you really want to delete this realization?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
               
                trans = formCon.BeginTransaction();
                objDaExportBill.DeleteExportBill(formCon, trans, objREB.BillID, "R");
                trans.Commit();
                loadRealizedExportBill(null);
                MessageBox.Show("Deleted Successfully");
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void chk_Enter(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            chk.ForeColor = Color.Red;
        }

        private void chk_Leave(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            chk.ForeColor = Color.Red;
        }

        private void ctlNumRBillAmt_valueChanged(object sender, EventArgs e)
        {
            //ctlNumRBillAmtTK.Value =Math.Round( ctlNumRRate.Value * ctlNumRBillAmt.Value,2);
            //ctlNumRPurAmtTK.Value =Math.Round( ctlNumRRate.Value * ctlNumRPurchaseAmt.Value,2);
            ctlNumRealizedTK.Value =Math.Round( ctlNumRRate.Value * ctlNumRealizedAmt.Value,2);

        }

        private void ctlNumTotalQty_valueChanged(object sender, EventArgs e)
        {
            ctlNumBEBalQty.Value = Math.Round(Convert.ToDouble(lblAvailQty.Text) - ctlNumTotalQty.Value, 2);
        }

        private void llblAddInvoice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtBELCNo.Tag == null)
                {
                    MessageBox.Show("Please Load a LC");
                    return;
                }
                int Lcid = ((LC_Master)txtBELCNo.Tag).LCID;
                addInvoice(Lcid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFindRealized_Click(object sender, EventArgs e)
        {
            try
            {
                

                    frmSearchExportBill frm = new frmSearchExportBill();
                    frm.ShowDialog(-1, 1);
                    if (frm.SelectedExportBill == null) return;
                    loadRealizedExportBill(frm.SelectedExportBill);

                  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRReset_Click(object sender, EventArgs e)
        {
            try
            {
                loadRealizedExportBill(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void ctldgvRealAccounts_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
           
        }
    }
}
