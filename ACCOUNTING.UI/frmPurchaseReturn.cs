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
    public partial class frmPurchaseReturn : Form
    {
        Account obAccount = null;
        SqlConnection conn = ConnectionHelper.getConnection();
        public DataTable dtPurInvoice = null;
        private DaTransaction obDaTrans = null;
        private int CustSupplID = 0, RefID = 0;
        public frmPurchaseReturn()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                frmFindPurchaseInvoice obfrmFindPurchaseInvoice = new frmFindPurchaseInvoice();
                obfrmFindPurchaseInvoice.ShowDialog();
                Purchases_Invoice obPurchase_Invoice = new Purchases_Invoice();
                obPurchase_Invoice = obfrmFindPurchaseInvoice.obPurchaseInvoics;
                if (obPurchase_Invoice == null) return;

                txtPIID.Text = obPurchase_Invoice.InvoiceID.ToString();
                //if (obPurchase_Invoice.InvoiceType.ToString() == "Purchases Order")
                //    cmbInvoiceType.SelectedIndex = 0;
                //else if (obPurchase_Invoice.InvoiceType.ToString() == "Direct Purchases")
                //    cmbInvoiceType.SelectedIndex = 1;
                //else
                //    cmbInvoiceType.SelectedIndex = 2;
                //txtPurchaseInvoiceNo.Text = obPurchase_Invoice.InvoiceNo.ToString();

                //dtpRetDate.Text = obPurchase_Invoice.InvoiceDate.ToString();
                obAccount = new Account();
                DaAccount obDaAccount = new DaAccount();
                obAccount = obDaAccount.getPurchaseAccount(conn, obPurchase_Invoice.SupplierAccountID);
                txtSupplierAccNo.Text = obAccount.AccountTitle.ToString();
                txtSupplierAccID.Text = obPurchase_Invoice.SupplierAccountID.ToString();

                obAccount = obDaAccount.getPurchaseAccount(conn, obPurchase_Invoice.PurchasesAccountID);
                txtPurchaseAccID.Text = obPurchase_Invoice.PurchasesAccountID.ToString();
                txtPurchaseAccNo.Text = obAccount.AccountTitle.ToString();
                cmbCurrency.SelectedValue = obPurchase_Invoice.CurrencyID;
                txtRate.Text = obPurchase_Invoice.Rate.ToString("0.00");


                txtReturnAmount.Text = obPurchase_Invoice.TransAmmount.ToString("0.00");
                //txtTotalBill.Text = obPurchase_Invoice.TransAmmount.ToString();

                txtRemarks.Text = obPurchase_Invoice.Remarks.ToString();
                txtTransRefID.Text = obPurchase_Invoice.TransRefID.ToString();
                txtStockRefID.Text = obPurchase_Invoice.StockRefID.ToString();
                loadPurchaseInvoice(obPurchase_Invoice.InvoiceID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadPurchaseInvoiceDetails(int ReturnMID)
        {
            try
            {
                DaPurchaseInvoice obDaPurchaseInvoice = new DaPurchaseInvoice();
                DaPurchaseReturn objDaPurchaseReturn = new DaPurchaseReturn();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtPurInvoice = objDaPurchaseReturn.PurchaseReturnDetails(conn, ReturnMID);
                if (ctlDGVPurchaseReturn.Columns.Count > 0) ctlDGVPurchaseReturn.Columns.Clear();
                ctlDGVPurchaseReturn.DataSource = dtPurInvoice;
                //ctlDGVPurchaseReturn.setColumnsVisible(false, "SLNo", "OrderID", "ItemID", "UnitID", "OrderQty", "PriceAmount");
                ctlDGVPurchaseReturn.setColumnsVisible(false, "RetnDID", "ItemID", "UnitID");
                //ctlDGVPurchaseReturn.setColumnsReadOnly(true, "InvQty","Item", "Color", "Count", "Size", "Shade", "Unit", "UnitPrice","OrderValue", "InvUnit","UnitPrice","PriceAmount");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadPurchaseInvoice(int InvoiceID)
        {
            try
            {
                //DaPurchaseInvoice obDaPurchaseInvoice = new DaPurchaseInvoice();
                DaPurchaseReturn objDaPurchaseReturn = new DaPurchaseReturn();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtPurInvoice = objDaPurchaseReturn.PurchaseReturnDetail(conn, InvoiceID);
                if (ctlDGVPurchaseReturn.Columns.Count > 0) ctlDGVPurchaseReturn.Columns.Clear();
                ctlDGVPurchaseReturn.DataSource = dtPurInvoice;
                ctlDGVPurchaseReturn.setColumnsVisible(false, "RetnDID", "ItemID", "UnitID","UnitPrice", "OrderValue");
                ctlDGVPurchaseReturn.setColumnsReadOnly(true, "InvQty", "Item", "Prd.Type", "Count", "Size", "ColorCode","Labdip", "Unit", "UnitPrice", "OrderValue", "RetnPriceAmount");
                ctlDGVPurchaseReturn.setColumnsFormat(new string[] { "UnitPrice", "InvQty", "OrderValue", "RetnQty", "RtnUnitPrice", "RetnPriceAmount" }, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00");
                ctlDGVPurchaseReturn.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctlDGVPurchaseReturn.Columns["InvQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctlDGVPurchaseReturn.Columns["OrderValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctlDGVPurchaseReturn.Columns["RetnQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctlDGVPurchaseReturn.Columns["RtnUnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctlDGVPurchaseReturn.Columns["RetnPriceAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadPurchaseReturnDetails(int ReturnMID)
        {
            try
            {
                DaPurchaseReturn obDaPurchaseReturn = new DaPurchaseReturn();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtPurInvoice = obDaPurchaseReturn.PurchaseReturnDetails(conn, ReturnMID);
                if (ctlDGVPurchaseReturn.Columns.Count > 0) ctlDGVPurchaseReturn.Columns.Clear();
                ctlDGVPurchaseReturn.DataSource = dtPurInvoice;
                ctlDGVPurchaseReturn.setColumnsVisible(false, "RetnDID", "ItemID", "UnitID");
                ctlDGVPurchaseReturn.setColumnsReadOnly(true, "Item", "Prd.Type", "Count", "Size", "Unit", "RetnPriceAmount");
                ctlDGVPurchaseReturn.setColumnsFormat(new string[] { "RetnPriceAmount", "RtnUnitPrice", "RetnQty" }, "0.00", "0.00", "0.00");
                ctlDGVPurchaseReturn.Columns["RetnPriceAmount"].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleRight;
                ctlDGVPurchaseReturn.Columns["RtnUnitPrice"].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleRight;
                ctlDGVPurchaseReturn.Columns["RetnQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ctlDGVPurchaseReturn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ctlDGVPurchaseReturn.Columns[e.ColumnIndex].Name.ToLower() == "retnqty" || ctlDGVPurchaseReturn.Columns[e.ColumnIndex].Name.ToLower() == "rtnunitprice")
                {
                    ctlDGVPurchaseReturn.Rows[e.RowIndex].Cells["RetnPriceAmount"].Value = Convert.ToDouble(ctlDGVPurchaseReturn.Rows[e.RowIndex].Cells["RetnQty"].Value == DBNull.Value ? 0 : ctlDGVPurchaseReturn.Rows[e.RowIndex].Cells["RetnQty"].Value) * Convert.ToDouble(ctlDGVPurchaseReturn.Rows[e.RowIndex].Cells["RtnUnitPrice"].Value);
                    CalculateRecords();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Calculate OrderValue " + ex.Message);
            }
        }
        private void CalculateRecords()
        {
            try
            {
                double subTotal = 0.0;
                int i, nR = ctlDGVPurchaseReturn.Rows.Count;
                if (ctlDGVPurchaseReturn.CurrentRow.Cells["RetnQty"].Value != null)
                {
                    for (i = 0; i < nR; i++)
                    {
                        subTotal += Convert.ToDouble(ctlDGVPurchaseReturn.Rows[i].Cells["RetnPriceAmount"].Value == DBNull.Value ? 0 : ctlDGVPurchaseReturn.Rows[i].Cells["RetnPriceAmount"].Value);
                    }
                    txtReturnAmount.Text = subTotal.ToString("0.00");
                }
                //txtTotalBill.Text = txtTransAmount.Text;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DaPurchaseReturn obDaPurchaseReturn = new DaPurchaseReturn();
            PurchaseReturn obPurchaseReturn = null;
            PurchaseReturnDetails obPurchaseReturnDTL = null;
            DaStockInOut obDaIO = new DaStockInOut();
            SqlTransaction trans = null;
            Bills objBills = new Bills();
            DaBills objDaBills = new DaBills();
            obDaTrans = new DaTransaction();
            int TransMID = 0;
            int retunMID = 0;
            int StockDID = 0;
            int StockMID = 0;
            int ItemID = 0;
            double UnitPrice = 0.0, Amt = 0.0, Qty = 0;
            int i, nR;
            try
            {
                TransactionMaster obTM = new TransactionMaster();
                TransactionDetail objTD = new TransactionDetail();
                Stock_InOut_Master objINOUTM = new Stock_InOut_Master();
                Stock_InOut_Detail objINOUTD = new Stock_InOut_Detail();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                trans = conn.BeginTransaction();
                //PurchaseReturn Save update
                StockMID = Convert.ToInt32(txtStockRefID.Text);
                TransMID = Convert.ToInt32(txtTransRefID.Text);
                obPurchaseReturn = createPurchaseReturn(TransMID, StockMID);

                retunMID = obDaPurchaseReturn.SaveUpdatePurchaseReturnMaster(obPurchaseReturn, conn, trans); //****

                //ReturnReturnDetail Save update

                nR = ctlDGVPurchaseReturn.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    obPurchaseReturnDTL = createPurchaseReturnDetails(retunMID, i);
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    obDaPurchaseReturn.saveUpdatePurchase_Return_DTL(obPurchaseReturnDTL, conn, trans);
                }
                // transaction Master Save update 
                obTM = createTransactionMaster(trans);
                TransMID = obDaTrans.SaveEditTransactionMaster(obTM, conn, trans);  //*******

                //Transaction Detail Save update
                int SupplierAccID, PurchaseAccID;
                double CurrencyRate;
                SupplierAccID = Convert.ToInt32(txtSupplierAccID.Text);
                PurchaseAccID = Convert.ToInt32(txtPurchaseAccID.Text);
                CurrencyRate = Convert.ToDouble(txtRate.Text);
                double dblTransAmt = Convert.ToDouble(txtReturnAmount.Text) * CurrencyRate;
                int TransDID = 0;

                //Debit Supplier Account
                TransDID = obDaTrans.getTransDID(conn, trans, TransMID, SupplierAccID);
                objTD = createTransactionDetail(TransDID, TransMID, SupplierAccID, 0, dblTransAmt);
                obDaTrans.SaveEditTransactionDetail(objTD, conn, trans);

                //Credit Purchase Account
                TransDID = obDaTrans.getTransDID(conn, trans, TransMID, PurchaseAccID);
                objTD = createTransactionDetail(TransDID, TransMID, PurchaseAccID, dblTransAmt, 0);
                obDaTrans.SaveEditTransactionDetail(objTD, conn, trans);



                // StockInOut Master Save Update
                objINOUTM = createInOutMaster(trans, CustSupplID, RefID);
                StockMID = obDaIO.SaveUpdateStockInOutMaster(objINOUTM, conn, trans);  //*****

                //StockIO Detail Save Update

                nR = ctlDGVPurchaseReturn.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    ItemID = Convert.ToInt32(ctlDGVPurchaseReturn.Rows[i].Cells["ItemID"].Value);
                    Qty = ctlDGVPurchaseReturn.Rows[i].Cells["RetnQty"].Value == DBNull.Value || ctlDGVPurchaseReturn.Rows[i].Cells["RetnQty"].Value == null ? 0 : Convert.ToDouble(ctlDGVPurchaseReturn.Rows[i].Cells["RetnQty"].Value);
                    UnitPrice = ctlDGVPurchaseReturn.Rows[i].Cells["RtnUnitPrice"].Value == DBNull.Value || ctlDGVPurchaseReturn.Rows[i].Cells["RtnUnitPrice"].Value == null ? 0 : Convert.ToDouble(ctlDGVPurchaseReturn.Rows[i].Cells["RtnUnitPrice"].Value);
                    Amt = ctlDGVPurchaseReturn.Rows[i].Cells["RetnPriceAmount"].Value == DBNull.Value || ctlDGVPurchaseReturn.Rows[i].Cells["RetnPriceAmount"].Value == null ? 0 : Convert.ToDouble(ctlDGVPurchaseReturn.Rows[i].Cells["RetnPriceAmount"].Value);
                    StockDID = obDaIO.getIODID(conn, trans, StockMID, ItemID);
                    objINOUTD = createInOutDetail(StockMID, StockDID, ItemID, Qty, UnitPrice, Amt);
                    obDaIO.SaveUpdateStockInOutDetail(objINOUTD, conn, trans);
                }
                ///////////// UpdateRawMaterialAndFinishGoodsAccountBalance
               
                new DaStockInOut().UpdateRawMaterialAndFinishGoodsAccountBalance(conn, trans);

                //Purchase Return Bills
                objBills = CreateObjectBills();
                objDaBills.SaveUpdateBills(conn, trans, objBills);

                ////////////////////////

                obDaPurchaseReturn.UpdateRefIDs(conn, trans, retunMID, TransMID, StockMID);


                trans.Commit();
                MessageBox.Show("Save Successfull");
                loadCurrency();
                btnReset_Click(null, null);

            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                MessageBox.Show("Unable to Save or update " + ex.Message);
            }

        }
        private TransactionMaster createTransactionMaster(SqlTransaction trans)
        {
            TransactionMaster objTM = null;
            try
            {
                objTM = new TransactionMaster();
                objTM.TransactionMasterID = 0;//int.Parse(txtTransRefID.Text);
                objTM.TransactionDate = dtpRetDate.Value.Date;
                
                    objTM.VoucherNo = new DaTransaction().getVoucherNo(conn, trans, "J");
                
                objTM.VoucherPayee = "";
                objTM.VoucherType = 3;
                objTM.TransactionMethodID = -1;
                objTM.MethodRefID = -1;
                objTM.MethodRefNo = string.Empty;
                objTM.TransactionDescription = "Via Purchase Return";
                objTM.ApprovedBy = string.Empty;
                objTM.ApprovedDate = new DateTime(1900, 1, 1);
                objTM.Module = "Purchase Return";

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
        private PurchaseReturn createPurchaseReturn(int transRefID, int stockMID)
        {
            PurchaseReturn obPurchase_Return = new PurchaseReturn();
            try
            {
                obPurchase_Return.ReturnMID = Convert.ToInt32(txtReturnMID.Text);

                obPurchase_Return.InvoiceNo= txtPurchaseInvoiceNo.Text.ToString();
                obPurchase_Return.PurchaseInvoiceID = int.Parse(txtPIID.Text);
                obPurchase_Return.ReturnDate = dtpRetDate.Value.Date;
                obPurchase_Return.SupplierAccountID = Convert.ToInt32(txtSupplierAccID.Text);
                obPurchase_Return.PurchaseAccountID = Convert.ToInt32(txtPurchaseAccID.Text);
                obPurchase_Return.ReturnAmount = Convert.ToDouble(txtReturnAmount.Text);

                //obSales_Invoice.DiscountRate = cboDiscount.SelectedIndex == 0 ? 0 : txtDiscount.Value;
                //obSales_Invoice.DiscountAmount = cboDiscount.SelectedIndex == 0 ? txtDiscount.Value : Convert.ToDouble(txtSubTotal.Text) * txtDiscount.Value / 100;
                //obPurchase_Invoice.TransAmount = Convert.ToDouble(txtTotalBill.Text);

                obPurchase_Return.TransRefID = transRefID;
                obPurchase_Return.StockRefID = stockMID;
                obPurchase_Return.Remarks = txtRemarks.Text;
                obPurchase_Return.CurrencyID = (int)cmbCurrency.SelectedValue;
                obPurchase_Return.Rate = Convert.ToDouble(txtRate.Text);

                return obPurchase_Return;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private PurchaseReturnDetails createPurchaseReturnDetails(int ReturnMID, int rowID)
        {
            PurchaseReturnDetails obPurchase_Return_DTL = new PurchaseReturnDetails();
            try
            {
                //obPurchase_Invoice_DTL.SLNO = Convert.ToInt32(ctlDGVPurchaseDTL.Rows[rowID].Cells["SLNo"].Value);
                obPurchase_Return_DTL.ReturnMID = ReturnMID;
                
                obPurchase_Return_DTL.ReturnDID =GlobalFunctions.isNull(ctlDGVPurchaseReturn.Rows[rowID].Cells["RetnDID"].Value,0);
                obPurchase_Return_DTL.ItemID = Convert.ToInt32(ctlDGVPurchaseReturn.Rows[rowID].Cells["ItemID"].Value);
                obPurchase_Return_DTL.ReturnQty = GlobalFunctions.isNull( ctlDGVPurchaseReturn.Rows[rowID].Cells["RetnQty"].Value,0.0);
                obPurchase_Return_DTL.UnitID = GlobalFunctions.isNull(ctlDGVPurchaseReturn.Rows[rowID].Cells["UnitID"].Value,0);
                obPurchase_Return_DTL.UnitPrice = GlobalFunctions.isNull(ctlDGVPurchaseReturn.Rows[rowID].Cells["RtnUnitPrice"].Value,0.0);
                obPurchase_Return_DTL.ReturnAmount = GlobalFunctions.isNull(ctlDGVPurchaseReturn.Rows[rowID].Cells["RetnPriceAmount"].Value,0.0);
                obPurchase_Return_DTL.Remarks = GlobalFunctions.isNull(ctlDGVPurchaseReturn.Rows[rowID].Cells["Remarks"].Value,"");
                obPurchase_Return_DTL.ColorCode = GlobalFunctions.isNull(ctlDGVPurchaseReturn.Rows[rowID].Cells["ColorCode"].Value, ""); ;
                obPurchase_Return_DTL.Labdip = GlobalFunctions.isNull(ctlDGVPurchaseReturn.Rows[rowID].Cells["Labdip"].Value, ""); ;
                
                return obPurchase_Return_DTL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private Stock_InOut_Master createInOutMaster(SqlTransaction trans, int CustSupplID, int RefID)
        {
            Stock_InOut_Master obIOMaster = null;
            DaStockInOut obDaIO = new DaStockInOut();
            try
            {
                obIOMaster = new Stock_InOut_Master();
                obIOMaster.StockMID = 0;// Convert.ToInt32(txtStockRefID.Text);
                obIOMaster.TransType = "Store Out For Purchase Return";
                obIOMaster.TransDate = dtpRetDate.Value.Date;
                obIOMaster.VoucherNo = obDaIO.getVoucherNo(conn, trans, "IO");
                obIOMaster.ChalanNo = "";
                obIOMaster.ChalanDate = dtpRetDate.Value.Date;
                obIOMaster.CustSupplID = CustSupplID;
                obIOMaster.RefID = RefID;
                obIOMaster.Remarks = "Store Out For Purchase Return ";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obIOMaster;
        }
        private Stock_InOut_Detail createInOutDetail(int IOMID, int IODID, int ItemID, double Qty, double UnitPrice, double Amt)
        {
            Stock_InOut_Detail obIOD = new Stock_InOut_Detail();
            try
            {
                obIOD.StockDID = IODID;
                obIOD.StockMID = IOMID;
                obIOD.TransNature = "In";
                obIOD.ItemID = ItemID;
                obIOD.InQty = Qty;
                obIOD.OutQty = 0;
                obIOD.UnitPrice = UnitPrice;
                obIOD.InAmount = 0.0;
                obIOD.OutAmount = Amt;
                obIOD.Budle_Pack_Qty = "Store Out";
                obIOD.ShortQty = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obIOD;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                resetInvoice();
                loadCurrency();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Reset " + ex.Message);
            }
        }
        private void resetInvoice()
        {
            try
            {
              
                loadPurchaseInvoiceDetails(-2);

                txtPurchaseInvoiceNo.Text = GlobalFunctions.generateNo(conn, "T_Purchase_Return", "InvoiceNo", "PR-");
                txtPIID.Text = "0";
                txtSupplierAccID.Text = "0";
                txtTransRefID.Text = "0";
                txtSupplierAccNo.Text = "";
                txtPurchaseAccNo.Text = "";

                txtPurchaseAccID.Text = "0";
                txtRemarks.Text = "";
                txtReturnAmount.Text = "0.0";
                //txtTotalBill.Text = "0.0";
                txtStockRefID.Text = "0";
                txtReturnMID.Text = "0";
                txtRate.Text = "1";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void btnPurRet_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch_Purchase_Return frmobj = new frmSearch_Purchase_Return();
                frmobj.ShowDialog();


                PurchaseReturn obPurchase_Return = new PurchaseReturn();
                obPurchase_Return = frmobj.obPurchaseReturn;
                if (obPurchase_Return == null) return;

                txtPIID.Text = obPurchase_Return.PurchaseInvoiceID.ToString();

                txtPurchaseInvoiceNo.Text = obPurchase_Return.InvoiceNo.ToString();

                dtpRetDate.Value = obPurchase_Return.ReturnDate;
                obAccount = new Account();
                DaAccount obDaAccount = new DaAccount();
                obAccount = obDaAccount.getPurchaseAccount(conn, obPurchase_Return.SupplierAccountID);
                txtSupplierAccNo.Text = obAccount.AccountTitle.ToString();
                txtSupplierAccID.Text = obPurchase_Return.SupplierAccountID.ToString();

                obAccount = obDaAccount.getPurchaseAccount(conn, obPurchase_Return.PurchaseAccountID);
                txtPurchaseAccID.Text = obPurchase_Return.PurchaseAccountID.ToString();
                txtPurchaseAccNo.Text = obAccount.AccountTitle.ToString();

                cmbCurrency.SelectedValue = obPurchase_Return.CurrencyID;
                txtReturnAmount.Text = obPurchase_Return.ReturnAmount.ToString();
                //txtTotalBill.Text = obPurchase_Invoice.TransAmmount.ToString();
                txtReturnMID.Text = obPurchase_Return.ReturnMID.ToString();
                txtRemarks.Text = obPurchase_Return.Remarks.ToString();
                txtTransRefID.Text = obPurchase_Return.TransRefID.ToString();
                txtStockRefID.Text = obPurchase_Return.StockRefID.ToString();
                txtRate.Text = obPurchase_Return.Rate.ToString("0.00");
                loadPurchaseReturnDetails(obPurchase_Return.ReturnMID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DaPurchaseReturn obDaPurchaseReturn = new DaPurchaseReturn();
            int ReturnMID = Convert.ToInt32(txtReturnMID.Text);
            //int TMID = Convert.ToInt32(txtTransRefID.Text);
            //int StockRefID = Convert.ToInt32(txtStockRefID.Text);
            //int InvoiceID = Convert.ToInt32(txtPIID.Text);
            if (ReturnMID == 0)
            {
                MessageBox.Show("Select Any Purchase Return");
                return;
            }
            SqlTransaction trans = null;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                trans = conn.BeginTransaction();
                obDaPurchaseReturn.DeletePurchaseReturn(conn,trans, ReturnMID);
                ///////////// UpdateRawMaterialAndFinishGoodsAccountBalance
                
                new DaStockInOut().UpdateRawMaterialAndFinishGoodsAccountBalance(conn, trans);
                trans.Commit();
                MessageBox.Show("Delete Successfull");
                loadCurrency();
                btnReset_Click(null, null);
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show("Unable to Delete " + ex.Message);
            }
        }
        private void txtPurchaseInvoiceNo_Enter(object sender, EventArgs e)
        {

            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }
        private void txtSupplierAccNo_Enter(object sender, EventArgs e)
        {

            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }
        private void txtCustomerAccNo_Enter(object sender, EventArgs e)
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
        private void txtPurchaseInvoiceNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }
        private void txtSupplierAccNo_Leave(object sender, EventArgs e)
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
        private void txtRemarks_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }
        private void txtPurchaseInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }
        private void txtSupplierAccNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }
        private void txtCustomerAccNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }
        private void dtpRetDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }
        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
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
        private void btnReset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }
        private void btnPurRet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }
        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }
        private void ctlDGVPurchaseReturn_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Black;
            e.CellStyle.ForeColor = Color.White;
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        private Bills CreateObjectBills()
        {
            try
            {
                Bills objBills = new Bills();
                objBills.BillAmount = Convert.ToDouble(txtReturnAmount.Text);
                objBills.BillDate = dtpRetDate.Value.Date;
                objBills.BillsID = 0;
                objBills.BillsType = "Bills Receivable";
                objBills.DueAmount = Convert.ToDouble(txtReturnAmount.Text);
                objBills.Module = "Purchase Return";
                objBills.RefInvoiceID = Convert.ToInt32(txtPIID.Text);
                objBills.RefInvoiceNo = txtPurchaseInvoiceNo.Text.ToString();
                objBills.CustomerSupplierAccountID = Convert.ToInt32(txtSupplierAccID.Text);
                objBills.BillForAccountID = Convert.ToInt32(txtPurchaseAccID.Text);
                objBills.Remarks = "";
                return objBills;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmPurchaseReturn_Paint(object sender, PaintEventArgs e)
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
        /*
        private void txtSupplierAccNo_Click(object sender, EventArgs e)
        {
            try
            {
                Ledgers objSupplier;
                int SuppliersID = 0;
                string SuppliersName = "";
                frmSupplierSearch frmSup = new frmSupplierSearch();
                frmSup.ShowDialog();
                objSupplier = frmSup.SelectedSupplier;
                if (frmSup == null) return;
                if (objSupplier == null) return;
                SuppliersID = objSupplier.LedgerID;
                SuppliersName = objSupplier.LedgerName;
                txtSupplierAccID.Text = SuppliersID.ToString();
                txtSupplierAccNo.Text = SuppliersName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */
        /*
        private void txtCustomerAccNo_Click(object sender, EventArgs e)
        {
            try
            {
                Ledgers objCustomers;
                int CustomersID = 0;
                string CustomersName = "";
                //frmCustomer obCustomer = new frmCustomer();
                //frmCustomer frmCusr = new frmCustomer();
                frmSearchCustomer frmCusr = new frmSearchCustomer();
                frmCusr.ShowDialog();
                //obCustomer.ShowDialog();
                objCustomers = frmCusr.ReturnCustomerID();
                if (frmCusr == null) return;
                if (objCustomers == null) return;
                CustomersID = objCustomers.LedgerID;
                CustomersName = objCustomers.LedgerName;
                //if (CustomerID == 0) return;
                txtCustomerAccNo.Text = CustomersName;
                txtCustomerAccID.Text = CustomersID.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */
        private void frmPurchaseReturn_Load(object sender, EventArgs e)
        {
            loadCurrency();
            btnReset_Click(null, null);
            
        }

        private void llblPInv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            btnFind_Click(sender, null);
        }


        private void loadCurrency()
        {
            try
            {
                DataTable dtt = new DataTable();
                DaOrder objDAorder = new DaOrder();
                dtt = objDAorder.LoadCurrency(conn);
                cmbCurrency.DataSource = dtt;
                cmbCurrency.DisplayMember = "Code";
                cmbCurrency.ValueMember = "CurrencyID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error to load currency" + ex);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double db;
                db = Convert.ToDouble(txtReturnAmount.Text) * Convert.ToDouble(txtRate.Text);
                txtTK.Text = db.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Select in correct format" + ex);
            }
        }

        private void txtReturnAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double db;
                db = Convert.ToDouble(txtReturnAmount.Text) * Convert.ToDouble(txtRate.Text);
                txtTK.Text = db.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Select in correct format" + ex);
            }
        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtRate_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void cmbCurrency_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }
    }
}
