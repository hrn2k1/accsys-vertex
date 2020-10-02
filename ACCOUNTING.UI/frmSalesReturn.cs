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
    public partial class frmSalesReturn : Form
    {
        private Account obAccout = null;
        private DataTable dtSalesReturn = null;
        private SqlConnection formConnection = null;
        private int CustomerAccountID = 0, RefID = 0;
        public frmSalesReturn()
        {
            InitializeComponent();
        }
        private void frmSalesReturn_Load(object sender, EventArgs e)
        {
            formConnection = ConnectionHelper.getConnection();
            txtInvoiceNo.Text = GlobalFunctions.generateNo(formConnection, "T_Sales_Return", "InvoiceNo", "SR-");
            loadReturnDetail(-4);
            loadCurrency();
        }
        private void loadReturnDetail(int ReturnMID)
        {
            dtSalesReturn = new DataTable();
            DaSalesReturn obDareturn = new DaSalesReturn();
            try
            {
                dtSalesReturn = obDareturn.loadSalesreturnDetail(formConnection, ReturnMID);
                dgvSalesReturn.DataSource = dtSalesReturn;
                dgvSalesReturn.Columns["Remarks"].HeaderText = "C.Qty";
                dgvSalesReturn.setColumnsVisible(false, "ReturnDID", "ReturnMID", "ItemID", "ColorID", "CountID", "SizeID", "UnitID", "InvUnitPrice", "PriceAmount", "InvUnit");
                dgvSalesReturn.setColumnsReadOnly(true, "Item", "Color", "Count", "Size", "ColorCode", "Labdip", "InvUnit", "Unit", "InvQty", "InvUnitPrice", "PriceAmount", "ReturnAmount");
                dgvSalesReturn.setColumnsFormat(new string[] { "InvQty", "ReturnQty", "InvUnitPrice", "PriceAmount", "UnitPrice", "ReturnAmount" }, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00");
                dgvSalesReturn.Columns["InvQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesReturn.Columns["ReturnQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesReturn.Columns["InvUnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesReturn.Columns["PriceAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesReturn.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesReturn.Columns["ReturnAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesReturn.setColumnsWidth(new string[] { "Item", "Color", "Count", "Size", "Unit", "ColorCode", "Labdip", "InvQty", "InvUnitPrice", "PriceAmount", "ReturnAmount", "Remarks" }, 150, 60, 60, 60, 60, 70, 70, 90, 90, 90, 90, 90);
            }
            catch (Exception xe)
            {
                throw new Exception(xe.Message);
            }
        }

        private void txtCustomerAccNo_Enter(object sender, EventArgs e)
        {

        }

        private void txtSalesAccNo_Enter(object sender, EventArgs e)
        {

        }
        private void llblSelectInvoice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dtSalesReturn.Rows.Count > 0)
                {
                    MessageBox.Show("Please Reset the current invoice " + Environment.NewLine + "Then select new invoice");
                    return;
                }
                frmFindInvoice frmInvoice = new frmFindInvoice();
                frmInvoice.ShowDialog();
                Sales_Invoice obSalesInvoice = new Sales_Invoice();
                obSalesInvoice = frmInvoice.obInvoice;
                if (obSalesInvoice == null) return;
                RefID = obSalesInvoice.InvoiceID;
                //txtInvoiceNo.Text = obSalesInvoice.InvoiceNo.ToString();
                txtChalanNo.Text = obSalesInvoice.ChalanNo.ToString();
                cmbCurrency.SelectedValue = obSalesInvoice.CurrencyID;
                txtCusAcc.Text = obSalesInvoice.CustomerAccount.ToString();
                obAccout = new Account();

                obAccout = new DaAccount().GetAccount(formConnection, obSalesInvoice.CustomerAccount);
                txtCustomerAccNo.Text = obAccout.AccountTitle.ToString();

                obAccout = new DaAccount().GetAccount(formConnection, obSalesInvoice.SalesAccount);
                txtSalesAcc.Text = obSalesInvoice.SalesAccount.ToString();
                txtSalesAccNo.Text = obAccout.AccountTitle.ToString();

                //Invoice search
                //DataTable dt = new DaSalesInvoice().loadInvoiceDetails(formConnection, obSalesInvoice.InvoiceID);
                //dgvSalesReturn.DataSource = dt;
                DataTable dt = new DaSalesReturn().loadReturnDetails(formConnection, obSalesInvoice.InvoiceID);

                int i, nR = dt.Rows.Count;
                txtInvoiceID.Text = obSalesInvoice.InvoiceID.ToString();
                if (dtSalesReturn.Rows.Count > 0) dtSalesReturn.Rows.Clear();
                for (i = 0; i < nR; i++)
                {
                    dtSalesReturn.Rows.Add(0, 0, dt.Rows[i].Field<object>("ItemID"), dt.Rows[i].Field<object>("Item"),
                         dt.Rows[i].Field<object>("CountID"), dt.Rows[i].Field<object>("Count"),
                         dt.Rows[i].Field<object>("SizeID"), dt.Rows[i].Field<object>("Size"),
                         dt.Rows[i].Field<object>("ColorID"), dt.Rows[i].Field<object>("Color"),
                        dt.Rows[i].Field<object>("ColorCode"), dt.Rows[i].Field<object>("Labdip"),
                        dt.Rows[i].Field<object>("InvQty"), dt.Rows[i].Field<object>("UnitID"),
                        dt.Rows[i].Field<object>("Unit"), dt.Rows[i].Field<object>("UnitPrice"),
                        dt.Rows[i].Field<object>("PriceAmount"), null,
                        dt.Rows[i].Field<object>("Unit"), dt.Rows[i].Field<object>("UnitPrice"),
                        null, dt.Rows[i].Field<object>("Remarks"));
                }
                calculateReturnAmt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //dgvSalesReturn.setColumnsReadOnly(false, "UnitPrice");
        }
        private bool validation()
        {
            if (txtInvoiceNo.Text.Trim() == "")
            {
                MessageBox.Show("Empty Invoice no");
                return false;
            }
            if (dgvSalesReturn.Rows.Count == 0)
            {
                MessageBox.Show("Empty Item" + Environment.NewLine + "Please select an Invoce"); ;
                return false;
            }
            if (ctlNumReturnAmount.Value == 0)
            {
                MessageBox.Show("Please Check Return Quantity and Unit Price");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation() == false) return;
            //calculateReturnAmt();
            int T_RefID = 0, S_RefID = 0, ReturnMID = 0, T_DID = 0;
            double TransAmt = 0.0;
            double CurrencyRate;
            SqlTransaction trans = null;
            DaSalesReturn obDaSRet = new DaSalesReturn();
            DaTransaction obDaTrans = new DaTransaction();
            DaStockInOut obDaIO = new DaStockInOut();
            TransactionMaster obTM = new TransactionMaster();
            TransactionDetail obTD = new TransactionDetail();
            Stock_InOut_Detail obInOutD = new Stock_InOut_Detail();
            Stock_InOut_Master obInOutM = new Stock_InOut_Master();
            SalesReturn obSalesRet = new SalesReturn();
            SalesReturnDetail obSalesRetD = new SalesReturnDetail();
            Bills obBills = new Bills();
            DaBills obDaBills = new DaBills();
            try
            {
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                trans = formConnection.BeginTransaction();
                int i, nR;
                //Save Sales Return
                obSalesRet = createSalesReturn(T_RefID, S_RefID);
                ReturnMID = obDaSRet.SaveUpdateSalesReturn(obSalesRet, formConnection, trans);


                //Save Sales ReturnDetail
                nR = dgvSalesReturn.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    obSalesRetD = createReturnDetail(ReturnMID, i);
                    obDaSRet.SaveUpdateSalesReturnDetail(obSalesRetD, formConnection, trans);
                }

                //Save Transaction Master
                if (txtTransrefID.Text != "0")
                {
                    obDaTrans.DeleteTransDetail(int.Parse(txtTransrefID.Text), formConnection, trans);
                    //txtTMID.Text = "0";
                }

                obTM = createTransMaster(trans);
                T_RefID = obDaTrans.SaveEditTransactionMaster(obTM, formConnection, trans);

                //Save Transaction Detail
                CurrencyRate = Convert.ToDouble(txtRate.Text);
                TransAmt = Convert.ToDouble(ctlNumReturnAmount.Value) * CurrencyRate;
                int CusAccID = Convert.ToInt32(txtCusAcc.Text);
                int SalesAccID = Convert.ToInt32(txtSalesAcc.Text);

                //Credit Customer Account
                T_DID = obDaTrans.getTransDID(formConnection, trans, T_RefID, CusAccID);
                obTD = createTransDetail(T_RefID, T_DID, CusAccID, TransAmt, 0);
                obDaTrans.SaveEditTransactionDetail(obTD, formConnection, trans);

                //Dabit Sales Account
                T_DID = obDaTrans.getTransDID(formConnection, trans, T_RefID, SalesAccID);
                obTD = createTransDetail(T_RefID, T_DID, SalesAccID, 0, TransAmt);
                obDaTrans.SaveEditTransactionDetail(obTD, formConnection, trans);

                //Save StockINOUT Master
                obInOutM = createIOMaster(trans, CustomerAccountID, RefID);
                S_RefID = obDaIO.SaveUpdateStockInOutMaster(obInOutM, formConnection, trans);

                //Save StockINOUT Detail
                int StockDID = 0;
                int ItemID, Countid, Sizeid, Colorid;
                string colorCode, labDip;
                double UnitPrice = 0.0, Amt = 0.0, InvQty = 0, Qty = 0;
                nR = dgvSalesReturn.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    InvQty = GlobalFunctions.isNull(dgvSalesReturn.Rows[i].Cells["InvQty"].Value, 0.0);
                    ItemID = GlobalFunctions.isNull(dgvSalesReturn.Rows[i].Cells["ItemID"].Value, 0);
                    Qty = GlobalFunctions.isNull(dgvSalesReturn.Rows[i].Cells["ReturnQty"].Value, 0.0);
                    UnitPrice = GlobalFunctions.isNull(dgvSalesReturn.Rows[i].Cells["UnitPrice"].Value, 0.0);
                    Amt = GlobalFunctions.isNull(dgvSalesReturn.Rows[i].Cells["ReturnAmount"].Value, 0.0);
                    Countid = GlobalFunctions.isNull(dgvSalesReturn.Rows[i].Cells["CountID"].Value, 0);
                    Sizeid = GlobalFunctions.isNull(dgvSalesReturn.Rows[i].Cells["SizeID"].Value, 0);
                    Colorid = GlobalFunctions.isNull(dgvSalesReturn.Rows[i].Cells["ColorID"].Value, 0);
                    colorCode = GlobalFunctions.isNull(dgvSalesReturn.Rows[i].Cells["Colorcode"].Value, "");
                    labDip = GlobalFunctions.isNull(dgvSalesReturn.Rows[i].Cells["Labdip"].Value, "");

                    //InvQty = Convert.ToDouble(dgvSalesReturn.Rows[i].Cells["InvQty"].Value);
                    //ItemID = Convert.ToInt32(dgvSalesReturn.Rows[i].Cells["ItemID"].Value);
                    //Qty = Convert.ToDouble(dgvSalesReturn.Rows[i].Cells["ReturnQty"].Value);
                    //UnitPrice = Convert.ToDouble(dgvSalesReturn.Rows[i].Cells["UnitPrice"].Value);
                    //Amt = Convert.ToDouble(dgvSalesReturn.Rows[i].Cells["ReturnAmount"].Value);
                    /*
                    if (InvQty < Qty)
                    {
                        if (trans != null)
                            trans.Rollback();
                        MessageBox.Show("Return Quantity is greater than Invoice Quantity ");
                        return;
                    }
                      */
                    StockDID = obDaIO.getIODID(formConnection, trans, S_RefID, ItemID);
                    obInOutD = createIODetail(S_RefID, StockDID, ItemID,Countid,Sizeid,Colorid, Qty, UnitPrice, Amt,colorCode,labDip);
                    obDaIO.SaveUpdateStockInOutDetail(obInOutD, formConnection, trans);
                }

                ///////////// UpdateRawMaterialAndFinishGoodsAccountBalance
           
                    new DaStockInOut().UpdateRawMaterialAndFinishGoodsAccountBalance(formConnection, trans);

                obDaSRet.UpdateRefIDs(formConnection, trans, ReturnMID, T_RefID, S_RefID);

                //Bills Save Update
                int InvID = 0;
                InvID = Convert.ToInt32(txtInvoiceID.Text);
                obBills = CreateObjectBills(InvID);
                obDaBills.SaveUpdateBills(formConnection, trans, obBills);

                    trans.Commit();
                    MessageBox.Show("Save Successfull");
                    loadCurrency();
                    btnReset_Click(null, null);
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                MessageBox.Show("Unable to Save or Update " + ex.Message);
            }
        }
        private SalesReturn createSalesReturn(int T_RefID, int S_RefID)
        {
            SalesReturn obS_Return = new SalesReturn();
            try
            {
                obS_Return.ReturnMID = Convert.ToInt32(txtReturnMID.Text);
                obS_Return.SalesInvoiceID = Convert.ToInt32(txtInvoiceID.Text);
                obS_Return.InvoiceNo = txtInvoiceNo.Text;
                obS_Return.ChalanNo = txtChalanNo.Text;
                obS_Return.ReturnDate = dtpReturnDate.Value.Date;
                obS_Return.CustomerAccount = Convert.ToInt32(txtCusAcc.Text);
                obS_Return.SalesAccount = Convert.ToInt32(txtSalesAcc.Text);
                obS_Return.ReturnAmount = Convert.ToDouble(ctlNumReturnAmount.Value);
                obS_Return.TransRefID = T_RefID;
                obS_Return.StockRefID = S_RefID;
                obS_Return.Remarks = rtxtRemarks.Text;
                obS_Return.CurrencyID = (int)cmbCurrency.SelectedValue;
                obS_Return.Rate = Convert.ToDouble(txtRate.Text);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obS_Return;
        }
        private SalesReturnDetail createReturnDetail(int ReturmMID,int rowID)
        {
            SalesReturnDetail obR_Detail = new SalesReturnDetail();
            try
            {
                obR_Detail.ReturnDID = Convert.ToInt32(dgvSalesReturn.Rows[rowID].Cells["ReturnDID"].Value);
                obR_Detail.ReturnMID = ReturmMID;
                obR_Detail.ItemID = Convert.ToInt32(dgvSalesReturn.Rows[rowID].Cells["ItemID"].Value);
                obR_Detail.CountID = GlobalFunctions.isNull(dgvSalesReturn.Rows[rowID].Cells["CountID"].Value, 0);
                obR_Detail.SizeID = GlobalFunctions.isNull(dgvSalesReturn.Rows[rowID].Cells["SizeID"].Value, 0);
                obR_Detail.ColorID = GlobalFunctions.isNull(dgvSalesReturn.Rows[rowID].Cells["ColorID"].Value, 0);
                obR_Detail.ReturnQty = Convert.ToDouble(dgvSalesReturn.Rows[rowID].Cells["ReturnQty"].Value);
                obR_Detail.UnitID = Convert.ToInt32(dgvSalesReturn.Rows[rowID].Cells["UnitID"].Value);
                obR_Detail.UnitPrice = Convert.ToDouble(dgvSalesReturn.Rows[rowID].Cells["UnitPrice"].Value);
                obR_Detail.ReturnAmount = Convert.ToDouble(dgvSalesReturn.Rows[rowID].Cells["ReturnAmount"].Value);
                obR_Detail.Remarks = dgvSalesReturn.Rows[rowID].Cells["Remarks"].Value.ToString();
                obR_Detail.ColorCode = dgvSalesReturn.Rows[rowID].Cells["ColorCode"].Value.ToString();
                obR_Detail.Labdip = dgvSalesReturn.Rows[rowID].Cells["Labdip"].Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obR_Detail;
        }
        private TransactionMaster createTransMaster(SqlTransaction trans)
        {
            TransactionMaster onTM = new TransactionMaster();
            try
            {
                onTM.TransactionMasterID = 0;// Convert.ToInt32(txtTransrefID.Text);
                onTM.TransactionDate = dtpReturnDate.Value.Date;
                //if (txtTransrefID.Text == "0")
                onTM.VoucherNo = new DaTransaction().getVoucherNo(formConnection, trans, "J");
                //else
                //    onTM.VoucherNo = "";
                onTM.VoucherPayee = "";
                onTM.VoucherType = 3;
                onTM.TransactionMethodID = -1;
                onTM.MethodRefID = -1;
                onTM.MethodRefNo = string.Empty;
                onTM.TransactionDescription = "Via Sales Return";
                onTM.ApprovedBy = string.Empty;
                onTM.ApprovedDate = new DateTime(1900, 1, 1);
                onTM.Module = "Sales Return";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return onTM;
        }
        private TransactionDetail createTransDetail(int T_RefID, int T_DID,int AccountID,double Credit,double Debit)
        {
            TransactionDetail obTD = new TransactionDetail();
            try
            {
                obTD.TransactionDetailID = T_DID;
                obTD.TransactionMasterID = T_RefID;
                obTD.TransactionAccountID = Convert.ToInt32(txtSalesAcc.Text);
                obTD.TransactionAccountID = AccountID;
                obTD.CreditAmount = Credit;
                obTD.DebitAmount = Debit;
                obTD.Comments = string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obTD;
        }
        private Stock_InOut_Master createIOMaster(SqlTransaction trans, int CusAccID, int RefID)
        {
            Stock_InOut_Master obIOM = new Stock_InOut_Master();
            DaStockInOut obDaIO = new DaStockInOut();
            try
            {
                obIOM.StockMID = 0;// Convert.ToInt32(txtStockRefID.Text);
                obIOM.TransType = "Store In For Supplier";
                obIOM.TransDate = dtpReturnDate.Value.Date;
                obIOM.VoucherNo = obDaIO.getVoucherNo(formConnection, trans, "II");
                obIOM.ChalanNo = txtChalanNo.Text.ToString();
                obIOM.ChalanDate = dtpReturnDate.Value.Date;
                obIOM.CustSupplID = CusAccID;
                obIOM.RefID = RefID;
                obIOM.Remarks = "Store In For Sales Return";
                obIOM.Module = "Sales Return";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obIOM;
        }
        private Stock_InOut_Detail createIODetail(int IOMID, int IODID, int ItemID, int Countid, int Sizeid, int Colorid, double RetQty, double UnitPrice, double RetAmt, string colorcode, string labdip)
        {
            Stock_InOut_Detail obIOD = new Stock_InOut_Detail();
            try
            {
                obIOD.StockDID = IODID;
                obIOD.StockMID = IOMID;
                obIOD.TransNature = "In";
                obIOD.ItemID = ItemID;
                obIOD.CountID = Countid;
                obIOD.SizeID = Sizeid;
                obIOD.ColorID = Colorid;
                obIOD.InQty = RetQty;
                obIOD.OutQty = 0;
                obIOD.UnitPrice = UnitPrice;
                obIOD.InAmount = RetAmt;
                obIOD.OutAmount = 0.0;
                obIOD.Budle_Pack_Qty = "Store In";
                obIOD.ShortQty = 0;
                obIOD.Specifications = colorcode;
                obIOD.Budle_Pack_Size = labdip;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obIOD;
        }
        private Bills CreateObjectBills(int InvoiceID)
        {
            try
            {
                Bills objBills = new Bills();
                objBills.BillsID = 0;
                objBills.BillAmount = Convert.ToDouble(ctlNumReturnAmount.Value);
                objBills.BillDate = dtpReturnDate.Value.Date;
                objBills.BillsType = "Bills Payable";
                objBills.CustomerSupplierAccountID = Convert.ToInt32(txtCusAcc.Text);
                objBills.DueAmount = Convert.ToDouble(ctlNumReturnAmount.Value);
                objBills.RefInvoiceID = InvoiceID;
                //Convert.ToInt32(txtInvoiceID.Text);
                objBills.RefInvoiceNo = txtInvoiceNo.Text.ToString();
                objBills.Remarks = "";
                objBills.Module = "Sales Return";
                objBills.BillForAccountID = Convert.ToInt32(txtSalesAcc.Text);
                return objBills;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            loadReturnDetail(-4);
            loadCurrency();
            resetReturn();
        }
        private void resetReturn()
        {
            try
            {
                txtChalanNo.Text = "";
                txtCusAcc.Text = "0";
                txtCustomerAccNo.Text = "";
                txtInvoiceID.Text = "0";
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                txtInvoiceNo.Text = GlobalFunctions.generateNo(formConnection, "T_Sales_Return", "InvoiceNo", "SR-");

                //txtInvoiceNo.Text = "";
                ctlNumReturnAmount.Value = 0;
                txtReturnMID.Text = "0";
                txtSalesAcc.Text = "0";
                txtSalesAccNo.Text = "";
                txtStockRefID.Text = "0";
                txtTransrefID.Text = "0";
                rtxtRemarks.Text = "";
                txtRate.Text = "1.00";
                dtpReturnDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            SalesReturn obSalesReturn = new SalesReturn();
            frmFindSalesReturn frm = new frmFindSalesReturn();
            frm.ShowDialog();
            try
            {
                obSalesReturn = frm.obSalesReturn;
                if (obSalesReturn == null) return;
                obAccout = new Account();
                txtReturnMID.Text = obSalesReturn.ReturnMID.ToString();
                txtRate.Text = obSalesReturn.Rate.ToString("0.00");
                cmbCurrency.SelectedValue = obSalesReturn.CurrencyID;
                txtTransrefID.Text = obSalesReturn.TransRefID.ToString();
                txtStockRefID.Text = obSalesReturn.StockRefID.ToString();
                obAccout = new DaAccount().GetAccount(formConnection, obSalesReturn.CustomerAccount);
                txtCustomerAccNo.Text = obAccout.AccountTitle.ToString();
                txtCusAcc.Text = obSalesReturn.CustomerAccount.ToString();

                obAccout = new DaAccount().GetAccount(formConnection, obSalesReturn.SalesAccount);
                txtSalesAccNo.Text = obAccout.AccountTitle.ToString();
                txtSalesAcc.Text = obSalesReturn.SalesAccount.ToString();
                txtInvoiceID.Text = obSalesReturn.SalesInvoiceID.ToString();
                txtInvoiceNo.Text = obSalesReturn.InvoiceNo;
                txtChalanNo.Text = obSalesReturn.ChalanNo;
                dtpReturnDate.Value = obSalesReturn.ReturnDate.Date;
                rtxtRemarks.Text = obSalesReturn.Remarks;
                ctlNumReturnAmount.Value = obSalesReturn.ReturnAmount;

                //DataTable dt = new DaSalesInvoice().loadInvoiceDetails(formConnection, obSalesReturn.SalesInvoiceID);
                DataTable dtt = new DaSalesReturn().loadSalesreturnDetail(formConnection, obSalesReturn.ReturnMID);
                dgvSalesReturn.DataSource = dtt;

                //int i, nR = dt.Rows.Count;
                //if (dtSalesReturn.Rows.Count > 0)
                //    dtSalesReturn.Rows.Clear();

                txtInvoiceID.Text = obSalesReturn.SalesInvoiceID.ToString();
                /*
                for (i = 0; i < nR; i++)
                {
                    dtSalesReturn.Rows.Add(dtt.Rows[i].Field<int>("ReturnDID"), dtt.Rows[i].Field<int>("ReturnMID"), dt.Rows[i].Field<object>("ItemID"), dt.Rows[i].Field<object>("Item"),
                         dt.Rows[i].Field<object>("Count"), dt.Rows[i].Field<object>("Size"), dt.Rows[i].Field<object>("Color"),
                        dt.Rows[i].Field<object>("Shade"),dt.Rows[i].Field<object>("ColorCode"),dt.Rows[i].Field<object>("Labdip"), dt.Rows[i].Field<object>("InvQty"), dt.Rows[i].Field<object>("UnitID"),
                        dt.Rows[i].Field<object>("Unit"), dt.Rows[i].Field<object>("InvUnitPrice"), dt.Rows[i].Field<object>("PriceAmount"),
                        dtt.Rows[i].Field<object>("ReturnQty"), dtt.Rows[i].Field<object>("UnitPrice"), dtt.Rows[i].Field<object>("ReturnAmount"),
                        dtt.Rows[i].Field<object>("Remarks"));
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Find Sales return " + ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DaSalesReturn obDaSalesReturn = new DaSalesReturn();
            SqlTransaction trans = null;
            try
            {
                int RetMID = Convert.ToInt32(txtReturnMID.Text);
                if (RetMID == 0)
                    return;
                if (MessageBox.Show("Are you sure to delete ", "Conformation Message", MessageBoxButtons.YesNo) == DialogResult.No) return;
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                trans = formConnection.BeginTransaction();
                obDaSalesReturn.DeleteSalesReturn(formConnection,trans, RetMID);
                ///////////// UpdateRawMaterialAndFinishGoodsAccountBalance
        
                    new DaStockInOut().UpdateRawMaterialAndFinishGoodsAccountBalance(formConnection, trans);
                trans.Commit();
                btnReset_Click(null, null);
                loadCurrency();
                MessageBox.Show("Delete Successfull");
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show("Unable to Save " + ex.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvSalesReturn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSalesReturn.Columns[e.ColumnIndex].Name.ToLower() == "returnqty" || dgvSalesReturn.Columns[e.ColumnIndex].Name.ToLower() == "unitprice")
            {
                dgvSalesReturn.Rows[e.RowIndex].Cells["ReturnAmount"].Value = GlobalFunctions.isNull(dgvSalesReturn.Rows[e.RowIndex].Cells["ReturnQty"].Value, 0.0) * GlobalFunctions.isNull(dgvSalesReturn.Rows[e.RowIndex].Cells["UnitPrice"].Value, 0.0);
                    //Convert.ToDouble(dgvSalesReturn.Rows[e.RowIndex].Cells["ReturnQty"].Value == DBNull.Value ? 0 : dgvSalesReturn.Rows[e.RowIndex].Cells["ReturnQty"].Value) * Convert.ToDouble(dgvSalesReturn.Rows[e.RowIndex].Cells["UnitPrice"].Value == DBNull.Value ? 0.0 : dgvSalesReturn.Rows[e.RowIndex].Cells["UnitPrice"].Value);
                calculateReturnAmt();
            }

        }
        private void calculateReturnAmt()
        {
            double ReturnAmt = 0.0;
            try
            {
                int i, nR = dgvSalesReturn.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    ReturnAmt += GlobalFunctions.isNull(dgvSalesReturn.Rows[i].Cells["ReturnAmount"].Value, 0.0);
                        //Convert.ToDouble(dgvSalesReturn.Rows[i].Cells["ReturnAmount"].Value == DBNull.Value ? 0.0 : dgvSalesReturn.Rows[i].Cells["ReturnAmount"].Value);
                }
                ctlNumReturnAmount.Value = ReturnAmt;
                //lblCurrency.Text = cmbCurrency.cur;
                }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void dgvSalesReturn_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Black;
            e.CellStyle.ForeColor = Color.White;
        }
        private void frmSalesReturn_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void frmSalesReturn_Paint(object sender, PaintEventArgs e)
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

        private void dgvSalesReturn_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSalesReturn.Columns[e.ColumnIndex].ReadOnly == true)
                SendKeys.Send("{TAB}");
        }

        private void txtCustomerAccNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtCustomerAccNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtSalesAccNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtChalanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void dtpReturnDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void rtxtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnReset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnDelete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtInvoiceNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtCustomerAccNo_Enter_1(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtSalesAccNo_Enter_1(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtChalanNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void rtxtRemarks_Enter(object sender, EventArgs e)
        {
            Control conl = (Control)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
           // conl.SelectAll();
        }

        private void rtxtRemarks_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtChalanNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtSalesAccNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtCustomerAccNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtInvoiceNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }


        private void loadCurrency()
        {
            try
            {
                DataTable dtt = new DataTable();
                DaOrder objDAorder = new DaOrder();
                dtt = objDAorder.LoadCurrency(formConnection);
                cmbCurrency.DataSource = dtt;
                cmbCurrency.DisplayMember = "Code";
                cmbCurrency.ValueMember = "CurrencyID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error to load currency" + ex);
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double db;
                db = Convert.ToDouble(ctlNumReturnAmount.Value) * Convert.ToDouble(txtRate.Text);
                txtTK.Text = db.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select in correct format" + ex);
            }
        }

        private void ctlNumReturnAmount_valueChanged(object sender, EventArgs e)
        {
            try
            {
                double db;
                db = Convert.ToDouble(ctlNumReturnAmount.Value) * Convert.ToDouble(txtRate.Text);
                txtTK.Text = db.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select in correct format"+ex);
            }
        }

    }
}
