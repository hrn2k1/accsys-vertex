using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Accounting.Utility;
using Accounting.DataAccess;
using Accounting.Entity;
using Accounting.Controls;

using System.Drawing.Drawing2D;
using Accounting.Reports;
using CrystalDecisions.Shared;

namespace Accounting.UI
{
    public partial class frmVouchers : Form
    {
        public frmVouchers()
        {
            InitializeComponent();
        }
        SqlConnection formCon = null;
        
        DataTable dtDrTab = null;
        DataTable dtCrTab = null;
        DataTable dtJrTab = null;
        DaTransaction objDaTrans = null;
        int _VoucherTypeID=0;
        int _TransactionID = 0;
        bool _isEditable = true;
        public void ShowDialog(int SelectTabIndex)
        {
            tcVoucher.SelectedIndex = SelectTabIndex;
            _VoucherTypeID = 0;
            _TransactionID = 0;
            this.ShowDialog();
        }
        public void ShowDialog(int VoucherTypeID, int TransactionID)
        {
            _VoucherTypeID = VoucherTypeID;
            _TransactionID = TransactionID;
            switch (VoucherTypeID)
            {
                case 1: tcVoucher.SelectedTab = tpCredit; break;
                case 2: tcVoucher.SelectedTab = tpDebit;  break;
                case 3: tcVoucher.SelectedTab = tpJournal; break;
            };
            this.ShowDialog();
        }
        public void ShowDialog(int VoucherTypeID, int TransactionID,bool IsEditable)
        {
            _VoucherTypeID = VoucherTypeID;
            _TransactionID = TransactionID;
            _isEditable = IsEditable;
            switch (VoucherTypeID)
            {
                case 1: tcVoucher.SelectedTab = tpCredit; break;
                case 2: tcVoucher.SelectedTab = tpDebit; break;
                case 3: tcVoucher.SelectedTab = tpJournal; break;
            };
            this.ShowDialog();
        }
        private void frmVouchers_Load(object sender, EventArgs e)
        {

            try
            {
                formCon = ConnectionHelper.getConnection();
                loadPaymentMethods();
                loadCollectionMethods();
                loadDrTabAccountGrid(-1);
                loadCrTabAccountGrid(-1);
                loadJrTabAccountGrid(-1);

                if (_VoucherTypeID != 0 && _TransactionID != 0)
                {
                    switch (_VoucherTypeID)
                    {
                        case 1: loadCrTabAccountGrid(_TransactionID); break;
                        case 2: loadDrTabAccountGrid(_TransactionID); break;
                        case 3: loadJrTabAccountGrid(_TransactionID); break;
                    };
                }
                MakeEditable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MakeEditable()
        {
            btnCrPost.Enabled = _isEditable;
            btnDrPost.Enabled = _isEditable;
            btnJrPost.Enabled = _isEditable;
            btnDrDelete.Enabled = _isEditable;
            btnCrDelete.Enabled = _isEditable;
            btnJrDelete.Enabled = _isEditable;
        }
        private void loadDrTabAccountGrid(int TMID)
        {
            try
            {
                objDaTrans = new DaTransaction();
              
                
                //////////////////////
                TransactionMaster objTransM = objDaTrans.getTransMaster(formCon, TMID);

                if (objTransM != null)
                {
                    txtDrTMID.Text = objTransM.TransactionMasterID.ToString();
                    txtDrVoucherNo.Text = objTransM.VoucherNo;
                    dtpDrDate.Value = objTransM.TransactionDate;
                    cboPayMethod.SelectedValue = objTransM.TransactionMethodID;
                    txtDrRefNo.Text = objTransM.MethodRefNo;
                    rtxtDrDesc.Text = objTransM.TransactionDescription;

                    txtDrAppvBy.Text = objTransM.ApprovedBy;
                    if (objTransM.ApprovedDate == new DateTime(1900, 1, 1))
                    {
                        chkDrAppvBy.Checked = false;
                    }
                    else
                    {
                        chkDrAppvBy.Checked = true;
                        dtpDrAppvDate.Value = objTransM.ApprovedDate;
                    }
                }
                else
                {
                    txtDrTMID.Text = "0";
                    txtDrVoucherNo.Text = objDaTrans.getVoucherNo(formCon,"D");
                    dtpDrDate.Value = DateTime.Now;
                    cboPayMethod.SelectedIndex = 0;
                    txtDrRefNo.Text = string.Empty;
                    rtxtDrDesc.Text = string.Empty;

                    txtDrAppvBy.Text = string.Empty;

                    chkDrAppvBy.Checked = false;

                    dtpDrAppvDate.Value = DateTime.Now;

                }

                /////////////////////
                DataTable dtt = objDaTrans.getTransAccounts(formCon, TMID, "Credit");
                if (dtt.Rows.Count != 0)
                {
                    Account DrAcc = new DaAccount().GetAccount(formCon, dtt.Rows[0].Field<int>("AccountID"));
                    txtDrAccount.Text = DrAcc.AccountTitle;
                    txtDrAccount.Tag = DrAcc;
                    lblPayAC.Tag = dtt.Rows[0].Field<int>("TransDID");
                }
                else
                {
                   
                    txtDrAccount.Text = string.Empty;
                    txtDrAccount.Tag = null;
                    lblPayAC.Tag = 0;
                }
                dtDrTab = objDaTrans.getTransAccounts(formCon, TMID, "Debit");
                ctldgvDrAccounts.DataSource = dtDrTab;
                dtDrTab.Columns["AccountID"].Unique = true;
                ctldgvDrAccounts.setColumnsVisible(false, "TransDID", "AccountID");
                ctldgvDrAccounts.setColumnsWidth(new string[] { "AccountNo", "AccountTitle", "Amount" }, 100, 350, 120);
                ctldgvDrAccounts.Columns["Amount"].DefaultCellStyle.Format = "0.00";
                ctldgvDrAccounts.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvDrTDID.Rows.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadCrTabAccountGrid(int TMID)
        {
            try
            {
                objDaTrans = new DaTransaction();


                //////////////////////
                TransactionMaster objTransM = objDaTrans.getTransMaster(formCon, TMID);

                if (objTransM != null)
                {
                    txtCrTMID.Text = objTransM.TransactionMasterID.ToString();
                    txtCrVoucherNo.Text = objTransM.VoucherNo;
                    dtpCrDate.Value = objTransM.TransactionDate;
                    cboCollectionMethod.SelectedValue = objTransM.TransactionMethodID;
                    txtCrRefNo.Text = objTransM.MethodRefNo;
                    rtxtCrDesc.Text = objTransM.TransactionDescription;

                    txtCrAppvBy.Text = objTransM.ApprovedBy;
                    if (objTransM.ApprovedDate == new DateTime(1900, 1, 1))
                    {
                        chkCrAppvBy.Checked = false;
                    }
                    else
                    {
                        chkCrAppvBy.Checked = true;
                        dtpCrAppvDate.Value = objTransM.ApprovedDate;
                    }
                }
                else
                {
                    txtCrTMID.Text = "0";
                    txtCrVoucherNo.Text = objDaTrans.getVoucherNo(formCon, "C"); 
                    dtpCrDate.Value = DateTime.Now;
                    cboCollectionMethod.SelectedIndex = 0;
                    txtCrRefNo.Text = string.Empty;
                    rtxtCrDesc.Text = string.Empty;

                    txtCrAppvBy.Text = string.Empty;

                    chkCrAppvBy.Checked = false;

                    dtpCrAppvDate.Value = DateTime.Now;

                }

                /////////////////////
                DataTable dtt = objDaTrans.getTransAccounts(formCon, TMID, "Debit");
                if (dtt.Rows.Count != 0)
                {
                    Account CrAcc = new DaAccount().GetAccount(formCon, dtt.Rows[0].Field<int>("AccountID"));
                    txtCrAccount.Text = CrAcc.AccountTitle;
                    txtCrAccount.Tag = CrAcc;
                    lblRecAC.Tag = dtt.Rows[0].Field<int>("TransDID");
                }
                else
                {

                    txtCrAccount.Text = string.Empty;
                    txtCrAccount.Tag = null;
                    lblRecAC.Tag = 0;
                }

                objDaTrans = new DaTransaction();
                dtCrTab = objDaTrans.getTransAccounts(formCon, TMID, "Credit");
                ctldgvCrAccounts.DataSource = dtCrTab;
                dtCrTab.Columns["AccountID"].Unique = true;
                ctldgvCrAccounts.setColumnsVisible(false, "TransDID", "AccountID");
                ctldgvCrAccounts.setColumnsWidth(new string[] { "AccountNo", "AccountTitle", "Amount" }, 100, 350, 120);
                ctldgvCrAccounts.Columns["Amount"].DefaultCellStyle.Format = "0.00";
                ctldgvCrAccounts.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvCrTDID.Rows.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadJrTabAccountGrid(int TMID)
        {
            try
            {
                objDaTrans = new DaTransaction();

                //////////////////////
                TransactionMaster objTransM = objDaTrans.getTransMaster(formCon, TMID);

                if (objTransM != null)
                {
                    txtJrTMID.Text = objTransM.TransactionMasterID.ToString();
                    txtJrVoucherNo.Text = objTransM.VoucherNo;
                    dtpJrDate.Value = objTransM.TransactionDate;
                    
                    rtxtJrDesc.Text = objTransM.TransactionDescription;

                    txtJrAppvBy.Text = objTransM.ApprovedBy;
                    if (objTransM.ApprovedDate == new DateTime(1900, 1, 1))
                    {
                        chkJrAppvBy.Checked = false;
                    }
                    else
                    {
                        chkJrAppvBy.Checked = true;
                        dtpJrAppvDate.Value = objTransM.ApprovedDate;
                    }
                }
                else
                {
                    txtJrTMID.Text = "0";
                    txtJrVoucherNo.Text = objDaTrans.getVoucherNo(formCon, "J"); 
                    dtpJrDate.Value = DateTime.Now;
                    
                    rtxtJrDesc.Text = string.Empty;

                    txtJrAppvBy.Text = string.Empty;

                    chkJrAppvBy.Checked = false;

                    dtpJrAppvDate.Value = DateTime.Now;

                }

                /////////////////////
                dtJrTab = objDaTrans.getTransAccounts(formCon, TMID, "Journal");
                ctldgvJrAccounts.DataSource = dtJrTab;
                dtJrTab.Columns["AccountID"].Unique = true;
                ctldgvJrAccounts.setColumnsVisible(false, "TransDID", "AccountID");
                ctldgvJrAccounts.setColumnsWidth(new string[] { "AccountNo", "AccountTitle", "Debit","Credit" }, 100, 300, 120,120);
                ctldgvJrAccounts.setColumnsFormat(new string[] { "Debit", "Credit" }, "0.00", "0.00");
                ctldgvJrAccounts.setColumnsReadOnly(true, "AccountNo", "AccountTitle");
                ctldgvJrAccounts.Columns["Debit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctldgvJrAccounts.Columns["Credit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                getTotal(ctldgvJrAccounts, "Debit", ctlNumJrTotalDrAmt);

                getTotal(ctldgvJrAccounts, "Credit", ctlNumJrTotalCrAmt);
                dgvJrTDID.Rows.Clear();
               // ctldgvJrAccounts.EditingControl.KeyDown += new KeyEventHandler(EditingControl_KeyDown);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadPaymentMethods()
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

        private void loadCollectionMethods()
        {
            try
            {
                cboCollectionMethod.DataSource = new DaTransMethod().getTransactionMethods(formCon);
                cboCollectionMethod.DisplayMember = "TransMethod";
                cboCollectionMethod.ValueMember = "TransMethodID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chkDrAppvBy_CheckedChanged(object sender, EventArgs e)
        {
            txtDrAppvBy.Enabled = chkDrAppvBy.Checked;
            dtpDrAppvDate.Enabled = chkDrAppvBy.Checked;
        }

        private void chkCrAppvBy_CheckedChanged(object sender, EventArgs e)
        {
            txtCrAppvBy.Enabled = chkCrAppvBy.Checked;
            dtpCrAppvDate.Enabled = chkCrAppvBy.Checked;
        }

        private void chkJrAppvBy_CheckedChanged(object sender, EventArgs e)
        {
            txtJrAppvBy.Enabled = chkJrAppvBy.Checked;
            dtpJrAppvDate.Enabled = chkJrAppvBy.Checked;
        }

        private void cboPayMethod_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPayMethod.SelectedValue == null || cboPayMethod.SelectedValue.GetType() == typeof(DataRowView)) return;
            int i = (int)cboPayMethod.SelectedValue;

            switch (i)
            {
                case 1: { lblRefNo.Visible = false; txtDrRefNo.Visible = false; txtDrRefNo.Text=""; break; }
                case 2: { lblRefNo.Visible = true; txtDrRefNo.Visible = true; lblRefNo.Text = "Cheque No."; break; }
                case 4: { lblRefNo.Visible = true; txtDrRefNo.Visible = true; lblRefNo.Text = "LC No."; break; }
                case 3: { lblRefNo.Visible = true; txtDrRefNo.Visible = true; lblRefNo.Text = "DD/TT No.";  break; }
            };
        }

        private void cboCollectionMethod_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCollectionMethod.SelectedValue == null || cboCollectionMethod.SelectedValue.GetType() == typeof(DataRowView)) return;
            int i = (int)cboCollectionMethod.SelectedValue;

            switch (i)
            {
                case 1: { lblCrRefNo.Visible = false; txtCrRefNo.Visible = false; txtCrRefNo.Text = ""; break; }
                case 2: { lblCrRefNo.Visible = true; txtCrRefNo.Visible = true; lblCrRefNo.Text = "Cheque No."; break; }
                case 4: { lblCrRefNo.Visible = true; txtCrRefNo.Visible = true; lblCrRefNo.Text = "LC No."; break; }
                case 3: { lblCrRefNo.Visible = true; txtCrRefNo.Visible = true; lblCrRefNo.Text = "DD/TT No."; break; }
            };
        }

        private void txtAccountFields_Enter(object sender, EventArgs e)
        {

        }

        private void btnDrAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDrVoucherFor.Tag == null || ctlNumDrAmt.Value <= 0) return;

                Account oAcc = (Account)txtDrVoucherFor.Tag;
                dtDrTab.Rows.Add(0, oAcc.AccountID, oAcc.AccountNo, oAcc.AccountTitle, ctlNumDrAmt.Value);

                txtDrVoucherFor.Text = string.Empty;
                txtDrVoucherFor.Tag = null;
                ctlNumDrAmt.Value = 0;

                /* for Our company Only */
                //string str="";
                //int i, nR;
                //nR=ctldgvDrAccounts.Rows.Count;
                //for (i = 0; i < nR; i++)
                //{
                //    str += ctldgvDrAccounts[3, i].Value.ToString();
                //    if (i < nR - 1)
                //        str += ",";
                //}
                //rtxtDrDesc.Text = str;
                ////////////////////////////////////////////
                txtDrVoucherFor.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDrRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int rowID=ctldgvDrAccounts.CurrentRow.Index;
                int transdid = Convert.ToInt32(ctldgvDrAccounts.Rows[rowID].Cells["TransDID"].Value);

                //dtDrTab.Rows[rowID].Delete();
                ctldgvDrAccounts.Rows.RemoveAt(rowID);
                if (transdid != 0)
                    dgvDrTDID.Rows.Add(transdid,0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCrAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCrRcvFrom.Tag == null || ctlNumCrAmt.Value <= 0) return;

                Account oAcc = (Account)txtCrRcvFrom.Tag;
                dtCrTab.Rows.Add(0, oAcc.AccountID, oAcc.AccountNo, oAcc.AccountTitle, ctlNumCrAmt.Value);

                txtCrRcvFrom.Text = string.Empty;
                txtCrRcvFrom.Tag = null;
                ctlNumCrAmt.Value = 0;
                /* for Our company Only */
                //string str = "";
                //int i, nR;
                //nR = ctldgvCrAccounts.Rows.Count;
                //for (i = 0; i < nR; i++)
                //{
                //    str += ctldgvCrAccounts[3, i].Value.ToString();
                //    if (i < nR - 1)
                //        str += ",";
                //}
                //rtxtCrDesc.Text = str;
                ////////////////////////////////////////////
                txtCrRcvFrom.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCrRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int rowID = ctldgvCrAccounts.CurrentRow.Index;
                int transdid = Convert.ToInt32(ctldgvCrAccounts.Rows[rowID].Cells["TransDID"].Value);

                //dtCrTab.Rows[rowID].Delete();
                ctldgvCrAccounts.Rows.RemoveAt(rowID);
                if (transdid != 0)
                    dgvCrTDID.Rows.Add(transdid, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvJrAccounts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowID = e.RowIndex;
                if (rowID < 0 || e.ColumnIndex < 0) return; ;

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



                    if (CellIntValue(ctldgvJrAccounts.Rows[rowID].Cells["TransDID"].Value) == 0)
                        ctldgvJrAccounts.Rows[rowID].Cells["TransDID"].Value = 0;
                        ctldgvJrAccounts.Rows[rowID].Cells["AccountID"].Value = objSelectedAcc.AccountID;
                        ctldgvJrAccounts.Rows[rowID].Cells["AccountNo"].Value = objSelectedAcc.AccountNo;
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
        private void txt_Enter(object sender, EventArgs e)
        {
           
            if (sender.GetType() == typeof(ctlNum))
            {
                ctlNum c = (ctlNum)sender;
                c.BackgroudColor = Color.Black;
                c.TextColor = Color.White;
                c.ForeColor = Color.White;
            }
            else
            {
                Control ctl = (Control)sender;
                ctl.BackColor = Color.Black;
                ctl.ForeColor = Color.White;
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(ctlNum))
            {
                ctlNum c = (ctlNum)sender;
                c.BackgroudColor = Color.White;
                c.TextColor = Color.Black;
                c.ForeColor = Color.Black;
            }
            else
            {
                Control ctl = (Control)sender;
                ctl.BackColor = Color.White;
                ctl.ForeColor = Color.Black;
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

        

        private void ctldgvDrAccounts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                getTotal(ctldgvDrAccounts, "Amount", ctlNumDrTotalAmt);
            }
            catch (Exception ex)
            {
                if (sender == null)
                    throw ex;
                else
                    MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvDrAccounts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                getTotal(ctldgvDrAccounts, "Amount", ctlNumDrTotalAmt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvCrAccounts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                getTotal(ctldgvCrAccounts, "Amount", ctlNumCrTotalAmt);
            }
            catch (Exception ex)
            {
                if (sender == null)
                    throw ex;
                else
                    MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvCrAccounts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                getTotal(ctldgvCrAccounts, "Amount", ctlNumCrTotalAmt); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvJrAccounts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(ctldgvJrAccounts.Columns[e.ColumnIndex].Name.ToLower()=="Debit".ToLower())
                getTotal(ctldgvJrAccounts, "Debit", ctlNumJrTotalDrAmt);
                if (ctldgvJrAccounts.Columns[e.ColumnIndex].Name.ToLower() == "Credit".ToLower())
                getTotal(ctldgvJrAccounts, "Credit", ctlNumJrTotalCrAmt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,ex.GetType().Name);
            }
        }

        private void ctldgvJrAccounts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Black;
            e.CellStyle.ForeColor = Color.White;
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void cbo_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void btnDrPost_Click(object sender, EventArgs e)
        {
            if (txtDrAccount.Tag == null)
            {
                MessageBox.Show("Correctly entry the account");
                return;
            }
            if (ctlNumDrTotalAmt.Value <= 0)
            {
                MessageBox.Show("Correctly entry the amount");
                return;
            }
           
            SqlTransaction trans = null;
            try
            {
                int TMID = 0;
                int i, nR;
                TransactionMaster objTM = new TransactionMaster();
                TransactionDetail objTD = new TransactionDetail();
                trans = formCon.BeginTransaction();

                nR = dgvDrTDID.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    objDaTrans.DeleteTransAccount(Convert.ToInt32(dgvDrTDID.Rows[i].Cells[0].Value), formCon, trans);
                }
                objTM = CreateTransMasterObject("Debit");
                TMID = objDaTrans.SaveEditTransactionMaster(objTM, formCon, trans);

                /////////////////////////////////////
                string strCmnt = "";
                int ii, nRR;
                nRR = ctldgvDrAccounts.Rows.Count;
                for (ii = 0; ii < nR; ii++)
                {
                    strCmnt += ctldgvDrAccounts[3, ii].Value.ToString();
                    if (ii < nRR - 1)
                        strCmnt += Environment.NewLine;
                }
                //////////////////////
                objTD = CreateTransDetailObject(Convert.ToInt32(lblPayAC.Tag), TMID, ((Account)txtDrAccount.Tag).AccountID, ctlNumDrTotalAmt.Value, 0, strCmnt);

                objDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);
               
                nR = ctldgvDrAccounts.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    objTD = CreateTransDetailObject(Convert.ToInt32(ctldgvDrAccounts.Rows[i].Cells["TransDID"].Value), TMID, Convert.ToInt32(ctldgvDrAccounts.Rows[i].Cells["AccountID"].Value), 0, Convert.ToDouble(ctldgvDrAccounts.Rows[i].Cells["Amount"].Value),txtDrAccount.Text);

                    objDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);
                }

                trans.Commit();
                btnDrReset_Click(null, null);
                MessageBox.Show("Successfully posted");
                txtDrVoucherNo.Focus();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        #region create objects
        private TransactionMaster CreateTransMasterObject(string TabName)
        {
            TransactionMaster objTM = null;
            try
            {
                objTM = new TransactionMaster();

                if (TabName == "Debit")
                {
                    objTM.TransactionMasterID = int.Parse(txtDrTMID.Text);
                    objTM.TransactionDate = dtpDrDate.Value.Date;
                    objTM.VoucherNo = txtDrVoucherNo.Text.Trim();
                    objTM.VoucherPayee = "";
                    objTM.VoucherType = Convert.ToInt32(tpDebit.Tag);
                    objTM.TransactionMethodID = Convert.ToInt32(cboPayMethod.SelectedValue);
                    objTM.MethodRefID = -1;
                    objTM.MethodRefNo = txtDrRefNo.Text.Trim();
                    objTM.TransactionDescription = rtxtDrDesc.Text;
                    objTM.Module = "Voucher";
                    if (chkDrAppvBy.Checked)
                    {
                        objTM.ApprovedBy = txtDrAppvBy.Text;
                        objTM.ApprovedDate = dtpDrAppvDate.Value.Date;
                    }
                    else
                    {
                        objTM.ApprovedBy =string.Empty;
                        objTM.ApprovedDate = new DateTime(1900,1,1);
                    }
                    
                }
                else if (TabName == "Credit")
                {
                    objTM.TransactionMasterID = int.Parse(txtCrTMID.Text);
                    objTM.TransactionDate = dtpCrDate.Value.Date;
                    objTM.VoucherNo = txtCrVoucherNo.Text.Trim();
                    objTM.VoucherPayee = "";
                    objTM.VoucherType = Convert.ToInt32(tpCredit.Tag);
                    objTM.TransactionMethodID = Convert.ToInt32(cboCollectionMethod.SelectedValue);
                    objTM.MethodRefID = -1;
                    objTM.MethodRefNo = txtCrRefNo.Text.Trim();
                    objTM.TransactionDescription = rtxtCrDesc.Text;
                    objTM.Module = "Voucher";
                    if (chkCrAppvBy.Checked)
                    {
                        objTM.ApprovedBy = txtCrAppvBy.Text;
                        objTM.ApprovedDate = dtpCrAppvDate.Value.Date;
                    }
                    else
                    {
                        objTM.ApprovedBy = string.Empty;
                        objTM.ApprovedDate = new DateTime(1900, 1, 1);
                    }

                }

                else if (TabName == "Journal")
                {
                    objTM.TransactionMasterID = int.Parse(txtJrTMID.Text);
                    objTM.TransactionDate = dtpJrDate.Value.Date;
                    objTM.VoucherNo = txtJrVoucherNo.Text.Trim();
                    objTM.VoucherPayee = "";
                    objTM.VoucherType = Convert.ToInt32(tpJournal.Tag);
                    objTM.TransactionMethodID = -1;
                    objTM.MethodRefID = -1;
                    objTM.MethodRefNo = string.Empty;
                    objTM.TransactionDescription = rtxtJrDesc.Text;
                    objTM.Module = "Voucher";
                    if (chkJrAppvBy.Checked)
                    {
                        objTM.ApprovedBy = txtJrAppvBy.Text;
                        objTM.ApprovedDate = dtpJrAppvDate.Value.Date;
                    }
                    else
                    {
                        objTM.ApprovedBy = string.Empty;
                        objTM.ApprovedDate = new DateTime(1900, 1, 1);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objTM;
        }

        private TransactionDetail CreateTransDetailObject(int TDID, int TMID, int AccountID, double CrAmt, double DrAmt,string cmnt)
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

        #endregion

        private void btnDrReset_Click(object sender, EventArgs e)
        {
            try
            {
                loadDrTabAccountGrid(-1);
            }
            catch (Exception ex)
            {
                if (sender == null)
                    throw ex;
                else
                    MessageBox.Show(ex.Message);
            }
        }

        private void btnCrPost_Click(object sender, EventArgs e)
        {
            if (txtCrAccount.Tag == null)
            {
                MessageBox.Show("Correctly entry the account");
                return;
            }
            if (ctlNumCrTotalAmt.Value <= 0)
            {
                MessageBox.Show("Correctly entry the amount");
                return;
            }
           
            SqlTransaction trans = null;
            try
            {
                int TMID = 0;
                int i, nR;
                TransactionMaster objTM = new TransactionMaster();
                TransactionDetail objTD = new TransactionDetail();
                trans = formCon.BeginTransaction();

                nR = dgvCrTDID.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    objDaTrans.DeleteTransAccount(Convert.ToInt32(dgvCrTDID.Rows[i].Cells[0].Value), formCon, trans);
                }
                objTM = CreateTransMasterObject("Credit");
                TMID = objDaTrans.SaveEditTransactionMaster(objTM, formCon, trans);
                /////////////////////////////////////
                string strCmnt = "";
                int ii, nRR;
                nRR = ctldgvCrAccounts.Rows.Count;
                for (ii = 0; ii < nR; ii++)
                {
                    strCmnt += ctldgvCrAccounts[3, ii].Value.ToString();
                    if (ii < nRR - 1)
                        strCmnt += Environment.NewLine;
                }
                //////////////////////

                objTD = CreateTransDetailObject(Convert.ToInt32(lblRecAC.Tag), TMID, ((Account)txtCrAccount.Tag).AccountID, 0, ctlNumCrTotalAmt.Value, strCmnt);

                objDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);

               
               
                nR = ctldgvCrAccounts.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    objTD = CreateTransDetailObject(Convert.ToInt32(ctldgvCrAccounts.Rows[i].Cells["TransDID"].Value), TMID, Convert.ToInt32(ctldgvCrAccounts.Rows[i].Cells["AccountID"].Value), Convert.ToDouble(ctldgvCrAccounts.Rows[i].Cells["Amount"].Value), 0,txtCrAccount.Text);

                    objDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);
                }

                trans.Commit();
                btnCrReset_Click(null, null);
                MessageBox.Show("Successfully posted");
                txtCrVoucherNo.Focus();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCrReset_Click(object sender, EventArgs e)
        {
            try
            {
                loadCrTabAccountGrid(-1);
            }
            catch (Exception ex)
            {
                if (sender == null)
                    throw ex;
                else
                    MessageBox.Show(ex.Message);
            }
        }

        private void btnJrReset_Click(object sender, EventArgs e)
        {
            try
            {
                loadJrTabAccountGrid(-1);
            }
            catch (Exception ex)
            {
                if (sender == null)
                    throw ex;
                else
                    MessageBox.Show(ex.Message);
            }
        }

        private void btnJrPost_Click(object sender, EventArgs e)
        {
            if ((ctlNumJrTotalDrAmt.Value != ctlNumJrTotalCrAmt.Value) || (ctlNumJrTotalDrAmt.Value <= 0) || (ctlNumJrTotalCrAmt.Value <= 0))
            {
                MessageBox.Show("Correctly entry the amount","Transaction Manager",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
           
            SqlTransaction trans = null;
            try
            {
                int TMID = 0;
                int i, nR;
                TransactionMaster objTM = new TransactionMaster();
                TransactionDetail objTD = new TransactionDetail();
                trans = formCon.BeginTransaction();
                nR = dgvJrTDID.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    objDaTrans.DeleteTransAccount(Convert.ToInt32(dgvJrTDID.Rows[i].Cells[0].Value), formCon, trans);
                }
                objTM = CreateTransMasterObject("Journal");
                TMID = objDaTrans.SaveEditTransactionMaster(objTM, formCon, trans);

                

                
                nR = ctldgvJrAccounts.Rows.Count-1;
                for (i = 0; i < nR; i++)
                {
                    double Cr = ctldgvJrAccounts.Rows[i].Cells["Credit"].Value == null || ctldgvJrAccounts.Rows[i].Cells["Credit"].Value == DBNull.Value ? 0 : Convert.ToDouble(ctldgvJrAccounts.Rows[i].Cells["Credit"].Value);
                    double Dr = ctldgvJrAccounts.Rows[i].Cells["Debit"].Value == null || ctldgvJrAccounts.Rows[i].Cells["Debit"].Value == DBNull.Value ? 0 : Convert.ToDouble(ctldgvJrAccounts.Rows[i].Cells["Debit"].Value);
                    objTD = CreateTransDetailObject(Convert.ToInt32(ctldgvJrAccounts.Rows[i].Cells["TransDID"].Value), TMID, Convert.ToInt32(ctldgvJrAccounts.Rows[i].Cells["AccountID"].Value), Cr,Dr,"");

                    objDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);
                }

                trans.Commit();
                btnJrReset_Click(null, null);
                MessageBox.Show("Successfully posted");
                txtJrVoucherNo.Focus();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctldgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int rowID = e.RowIndex;

                if (sender.Equals(ctldgvDrAccounts))
                {
                    txtDrVoucherFor.Text = ctldgvDrAccounts.Rows[rowID].Cells["AccountTitle"].Value.ToString();
                    txtDrVoucherFor.Enabled = false;
                    btnDrAdd.Enabled = false;
                    btnDrRemove.Enabled = false;
                    btnDrEdit.Enabled = true;
                    ctlNumDrAmt.Value = Convert.ToDouble(ctldgvDrAccounts.Rows[rowID].Cells["Amount"].Value);
                    ctldgvDrAccounts.Enabled = false;
                    btnDrEdit.Tag = rowID;
                }
                else if (sender.Equals(ctldgvCrAccounts))
                {
                    txtCrRcvFrom.Text = ctldgvCrAccounts.Rows[rowID].Cells["AccountTitle"].Value.ToString();
                    txtCrRcvFrom.Enabled = false;
                    btnCrAdd.Enabled = false;
                    btnCrRemove.Enabled = false;
                    btnCrEdit.Enabled = true;
                    ctlNumCrAmt.Value = Convert.ToDouble(ctldgvCrAccounts.Rows[rowID].Cells["Amount"].Value);
                    ctldgvCrAccounts.Enabled = false;
                    btnCrEdit.Tag = rowID;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ctldgvDrAccounts.Rows[(int)btnDrEdit.Tag].Cells["Amount"].Value = ctlNumDrAmt.Value;

                txtDrVoucherFor.Text = string.Empty;
                txtDrVoucherFor.Tag = null;
                ctlNumDrAmt.Value = 0;

                txtDrVoucherFor.Enabled = true;
                btnDrAdd.Enabled = true;
                btnDrRemove.Enabled = true;
                btnDrEdit.Enabled = false;
               
                ctldgvDrAccounts.Enabled = true;
                btnDrEdit.Tag = null;
                ctldgvDrAccounts_RowsAdded(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ctldgvCrAccounts.Rows[(int)btnCrEdit.Tag].Cells["Amount"].Value = ctlNumCrAmt.Value;

                txtCrRcvFrom.Text = string.Empty;
                txtCrRcvFrom.Tag = null;
                ctlNumCrAmt.Value = 0;

               
                txtCrRcvFrom.Enabled = true;
                btnCrAdd.Enabled = true;
                btnCrRemove.Enabled = true;
                btnCrEdit.Enabled = false;
              
                ctldgvCrAccounts.Enabled = true;
                btnCrEdit.Tag = null;
                ctldgvCrAccounts_RowsAdded(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVReg_Click(object sender, EventArgs e)
        {
            try
            {
                frmVoucherRegister frmVReg = new frmVoucherRegister();

                frmVReg.ShowDialog();
                int VTid = frmVReg.SelectedVoucherTypeID;
                int TMID=frmVReg.SelectedTransactionID;
                switch (VTid)
                {
                    case 1: tcVoucher.SelectedTab=tpCredit; loadCrTabAccountGrid(TMID); break;
                    case 2: tcVoucher.SelectedTab = tpDebit; loadDrTabAccountGrid(TMID); break;
                    case 3: tcVoucher.SelectedTab = tpJournal; loadJrTabAccountGrid(TMID); break;
                };
                _isEditable = frmVReg.IsEditable;
                MakeEditable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJrRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int rowID = ctldgvJrAccounts.CurrentRow.Index;
                int transdid = Convert.ToInt32(ctldgvJrAccounts.Rows[rowID].Cells["TransDID"].Value);

                //dtJrTab.Rows[rowID].Delete();
                ctldgvJrAccounts.Rows.RemoveAt(rowID);
                if (transdid != 0)
                    dgvJrTDID.Rows.Add(transdid, 0);
                getTotal(ctldgvJrAccounts, "Debit", ctlNumJrTotalDrAmt);

                getTotal(ctldgvJrAccounts, "Credit", ctlNumJrTotalCrAmt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            int TransMID=-1;
            try
            {
                if (sender.Equals(btnDrDelete))
                    TransMID = Convert.ToInt32(txtDrTMID.Text);
                else if(sender.Equals(btnCrDelete))
                    TransMID = Convert.ToInt32(txtCrTMID.Text);
                else if (sender.Equals(btnJrDelete))
                    TransMID = Convert.ToInt32(txtJrTMID.Text);

                if (TransMID == 0) return;
                if (MessageBox.Show("Do you really want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                trans = formCon.BeginTransaction();

                objDaTrans.DeleteTransaction(TransMID, formCon, trans);

                trans.Commit();

                if (sender.Equals(btnDrDelete))
                    btnDrReset_Click(null, null);
                else if (sender.Equals(btnCrDelete))
                    btnCrReset_Click(null, null);
                else if (sender.Equals(btnJrDelete))
                    btnJrReset_Click(null, null);

                MessageBox.Show("Transaction has been deleted successfully", "Transaction Manager");
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void frmVouchers_Paint(object sender, PaintEventArgs e)
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

        private void tabPage_Paint(object sender, PaintEventArgs e)
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

        private void tpDebit_Enter(object sender, EventArgs e)
        {
            txtDrVoucherNo.Focus();
        }

        private void Ctl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
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

        private void btnDrPrint_Click(object sender, EventArgs e)
        {
            try
            {
                VoucherPrint(Convert.ToInt32(txtDrTMID.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region report variable
        frmReportViewer frmRV = new frmReportViewer();
        ParameterValues pvc = new ParameterValues();
        ParameterDiscreteValue pdv = new ParameterDiscreteValue();

        #endregion
        private void VoucherPrint(int TransMID)
        {
            try
            {
                rptVoucher rptV = new rptVoucher();

                pdv.Value = TransMID;
                pvc.Add(pdv);
                rptV.DataDefinition.ParameterFields["@TransMID"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptV.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
               
                
                frmRV.ShowDialog(rptV, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void JournalVoucherPrint(int TransMID)
        {
            try
            {
                rptJournalVoucher rptV = new rptJournalVoucher();

                pdv.Value = TransMID;
                pvc.Add(pdv);
                rptV.DataDefinition.ParameterFields["@TransMID"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptV.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);


                frmRV.ShowDialog(rptV, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnCrPrint_Click(object sender, EventArgs e)
        {
            try
            {
                VoucherPrint(Convert.ToInt32(txtCrTMID.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJPrint_Click(object sender, EventArgs e)
        {
            try
            {
                JournalVoucherPrint(Convert.ToInt32(txtJrTMID.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
