using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.DataAccess;
using System.Data.SqlClient;
using Accounting.Utility;
using Accounting.Entity;
using CrystalDecisions.Shared;
using Accounting.Reports;

namespace Accounting.UI
{
    public partial class frmSalesInvoice : Form
    {
        private SqlConnection formConnection = null;
        private DataTable dtInvoice = null;
        private Account obAccount = null;
        private DaTransaction obDaTrans = null;
        private int CustSupplID = 0, RefID = 0;
        public frmSalesInvoice()
        {
            InitializeComponent();
        }
        private void frmSalesInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                formConnection = ConnectionHelper.getConnection();
                txtInvoiceNo.Text = GlobalFunctions.generateNo(formConnection, "T_Sales_Invoice", "InvoiceNo", "SI-");
                txtChalanNo.Text = GlobalFunctions.generateNo(formConnection, "T_Sales_Invoice", "ChalanNo", "CO-");
                cboInvoiceType.SelectedIndex = 0;
                cboDiscount.SelectedIndex = 0;
                //loadOrderItems(-1);
                loadInvoiceDetails(-4);
                loadCurrency();
                loadItem();
                loadCounts();
                loadSizes();
                loadColors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load Form " + ex.Message);
            }
        }
        private void loadItem()
        {
            DataTable Items = new DataTable();
            try
            {
                Items = new DAChartsOfItem().getItemsForGrid(formConnection);
                ColItemID.DataSource = Items;
                ColItemID.DisplayMember = "ItemName";
                ColItemID.ValueMember = "ItemID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadCounts()
        {
            DataTable dtCounts = new DataTable();
            try
            {
                dtCounts = new DaCounts().getCountsForGrid(formConnection);
                ColCountID.DataSource = dtCounts;
                ColCountID.DisplayMember = "CountName";
                ColCountID.ValueMember = "CountID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadSizes()
        {
            DataTable dtSizes = new DataTable();
            try
            {
                dtSizes = new DaSizes().getSizesForGrid(formConnection);
                ColSizeID.DataSource = dtSizes;
                ColSizeID.DisplayMember = "SizesName";
                ColSizeID.ValueMember = "SizesID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadColors()
        {
            DataTable dtColors = new DataTable();
            try
            {
                dtColors = new Dacolors().getColorsForGrid(formConnection);
                ColColorID.DataSource = dtColors;
                ColColorID.DisplayMember = "ColorsName";
                ColColorID.ValueMember = "ColorsID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadInvoiceDetails(int InvoiceID)
        {
            try
            {
                if (dgvSalesInvoiceDetails.Rows.Count > 1) dgvSalesInvoiceDetails.Rows.Clear();

                DaSalesInvoice obDaSalesInvoice = new DaSalesInvoice();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dtInvoice = obDaSalesInvoice.loadInvoiceDetails(formConnection, InvoiceID);
                int i, nR = dtInvoice.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    dgvSalesInvoiceDetails.Rows.Add(new object[] {
                    dtInvoice.Rows[i].Field<object>("SLNo"),dtInvoice.Rows[i].Field<object>("OrderID"),
                    dtInvoice.Rows[i].Field<object>("ItemID"),dtInvoice.Rows[i].Field<object>("CountID"),
                    dtInvoice.Rows[i].Field<object>("SizeID"),dtInvoice.Rows[i].Field<object>("ColorID"),
                    dtInvoice.Rows[i].Field<object>("ColorCode"),dtInvoice.Rows[i].Field<object>("Labdip"),
                    dtInvoice.Rows[i].Field<object>("OrderQty"),dtInvoice.Rows[i].Field<object>("UnitID"),dtInvoice.Rows[i].Field<object>("Unit"),
                    dtInvoice.Rows[i].Field<object>("InvQty"),dtInvoice.Rows[i].Field<object>("UnitPrice"),
                    dtInvoice.Rows[i].Field<object>("PriceAmount"),dtInvoice.Rows[i].Field<object>("Remarks")
                    });
                }

                /*
                if (dgvSalesInvoiceDetails.Columns.Count > 0) dgvSalesInvoiceDetails.Columns.Clear();
                dgvSalesInvoiceDetails.DataSource = dtInvoice;
                dgvSalesInvoiceDetails.Columns["Remarks"].HeaderText = "C.Qty";
                //dtInvoice.Columns["ItemID"].Unique = true;
                dgvSalesInvoiceDetails.setColumnsVisible(false, "SLNo", "InvoiceID", "OrderID", "ItemID", "Shade","UnitID");
                dgvSalesInvoiceDetails.setColumnsReadOnly(true, "Item", "Color", "Count", "Size","Unit", "UnitPrice", "OrderQty", "OrderValue", "InvUnit", "PriceAmount");
                dgvSalesInvoiceDetails.setColumnsFormat(new string[] { "InvQty", "UnitPrice", "OrderQty", "OrderValue", "InvUnitPrice", "PriceAmount" }, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00");
                dgvSalesInvoiceDetails.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesInvoiceDetails.Columns["OrderQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesInvoiceDetails.Columns["OrderValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesInvoiceDetails.Columns["InvUnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesInvoiceDetails.Columns["PriceAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesInvoiceDetails.Columns["InvQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSalesInvoiceDetails.setColumnsWidth(new string[] { "Item" }, 200);
                 * */
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        private void txtSalesAccount_KeyDown(object sender, KeyEventArgs e)
        {
           
                
            
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    obAccount = new Account();
                    frmAccountSearch obfrmCustomerAccount = new frmAccountSearch();
                    obfrmCustomerAccount.ShowDialog();
                    obAccount = obfrmCustomerAccount.SelectedAccount;
                    if (obAccount == null) return;
                    txtSalesAccount.Text = obAccount.AccountTitle;
                    txtSalesAcc.Text = obAccount.AccountID.ToString();
                    SelectNextControl((Control)sender, true, true, true, true);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to find Account " + ex.Message);
            }
        }
        private void addOrder(int OrderMID)
        {
            try
            {
                if (dgvSalesInvoiceDetails.Rows.Count > 1) dgvSalesInvoiceDetails.Rows.Clear();

                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                DataTable dt = new DataTable();
                DaSalesInvoice obDaSalesInvoice = new DaSalesInvoice();
                dt = obDaSalesInvoice.loadOrder(formConnection, OrderMID);
                int i, nR = dt.Rows.Count;
                //dtInvoice.Rows.Clear();
                for (i = 0; i < nR; i++)
                {
                    dgvSalesInvoiceDetails.Rows.Add(new object[] {
                    null,dt.Rows[i].Field<object>("OrderID"),
                    dt.Rows[i].Field<object>("ItemID"),dt.Rows[i].Field<object>("CountID"),
                    dt.Rows[i].Field<object>("SizeID"),dt.Rows[i].Field<object>("ColorID"),
                    dt.Rows[i].Field<object>("ColorCode"),dt.Rows[i].Field<object>("Labdip"),
                    dt.Rows[i].Field<object>("OrderQty"),dt.Rows[i].Field<object>("UnitID"),dt.Rows[i].Field<object>("Unit"),dt.Rows[i].Field<object>("AvailQty"),
                    dt.Rows[i].Field<object>("UnitPrice"),GlobalFunctions.isNull(dt.Rows[i].Field<object>("AvailQty"),0.0)*GlobalFunctions.isNull(dt.Rows[i].Field<object>("UnitPrice"),0.0),dt.Rows[i].Field<object>("Remarks")
                    });
                }
                /*
                try
                {
                    dtInvoice.Rows.Add(0, 0, dt.Rows[i].Field<object>("OrderID"), dt.Rows[i].Field<object>("ItemID"),
                        dt.Rows[i].Field<object>("Item"), dt.Rows[i].Field<object>("Count"),
                         dt.Rows[i].Field<object>("Size"), dt.Rows[i].Field<object>("Color"),

                        dt.Rows[i].Field<object>("Shade"), dt.Rows[i].Field<object>("ColorCode"),
                         dt.Rows[i].Field<object>("Labdip"), dt.Rows[i].Field<object>("OrderQty"),
                        dt.Rows[i].Field<object>("Unit"), dt.Rows[i].Field<object>("UnitPrice"),
                        dt.Rows[i].Field<object>("OrderValue"), 0, dt.Rows[i].Field<object>("UnitID"),
                        dt.Rows[i].Field<object>("Unit"), dt.Rows[i].Field<object>("UnitPrice")
                        );
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                 * */
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private bool Validation()
        {
            if (txtInvoiceNo.Text.Trim() == "")
            {
                MessageBox.Show("Enter a valid InvoiceNo");
                return false;
            }
            if (txtCustomerAccount.Text.Trim() == "")
            {
                MessageBox.Show("Please select a Customer first");
                return false;
            }
            if (txtSalesAccount.Text.Trim() == "")
            {
                MessageBox.Show("Please select a Sales Account first");
                return false;
            }
            if ((cboInvoiceType.SelectedIndex != 2) && (dgvSalesInvoiceDetails.Rows.Count == 0))
            {
                MessageBox.Show("Its not a valid order without items." + Environment.NewLine + "Please input items and their quantity");
                return false;
            }
            if (txtSubTotal.Text == "0.00")
            {
                MessageBox.Show("Please check the Quantity and UnitPrice");
                return false;
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation() == false) return;
            DaSalesInvoice obDaSalesInvoice = new DaSalesInvoice();
            DaStockInOut obDaIO = new DaStockInOut();
            Sales_Invoice obSales_Invoice = null;
            Sales_Invoice_Detail obSales_Invoice_Detail = null;
            SqlTransaction trans = null;
            obDaTrans = new DaTransaction();
            int TMID = 0;
            int InvID = 0;
            try
            {
                TransactionMaster obTM = new TransactionMaster();
                TransactionDetail objTD = new TransactionDetail();
                Stock_InOut_Master objINOUTM = new Stock_InOut_Master();
                Stock_InOut_Detail objINOUTD = new Stock_InOut_Detail();
                Bills obBills = new Bills();
                DaBills obDaBills = new DaBills();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                trans = formConnection.BeginTransaction();
                
                // transaction Master Save update 
                if (txtTMID.Text != "0")
                {
                    obDaTrans.DeleteTransDetail(int.Parse(txtTMID.Text), formConnection, trans);
                    //txtTMID.Text = "0";
                }
                obTM = createTransactionMaster(trans);
                TMID = obDaTrans.SaveEditTransactionMaster(obTM, formConnection, trans);

                //Transaction Detail Save update
                int CustAcc,SalesAcc;
                double CurrencyRate;
                CurrencyRate = Convert.ToDouble(txtRate.Text);
                CustAcc=Convert.ToInt32(txtCustomerAcc.Text);
                SalesAcc=Convert.ToInt32(txtSalesAcc.Text);
                double dblTransAmt = Convert.ToDouble(txtTotalBill.Text) * CurrencyRate;
                int TransDID=0;
                
                //Debit Customer Account
                TransDID = obDaTrans.getTransDID(formConnection, trans, TMID, CustAcc);
                objTD = createTransactionDetail(TransDID, TMID, CustAcc, 0, dblTransAmt);
                obDaTrans.SaveEditTransactionDetail(objTD, formConnection, trans);

                //Credit Supplier Account
                TransDID = obDaTrans.getTransDID(formConnection, trans, TMID, SalesAcc);
                objTD = createTransactionDetail(TransDID, TMID, SalesAcc, dblTransAmt, 0);
                obDaTrans.SaveEditTransactionDetail(objTD, formConnection, trans);

                // StockInOut Master Save Update
                int StockMID = 0;
                if (cboInvoiceType.SelectedIndex != 2)
                {
                    objINOUTM = createInOutMaster(trans, CustSupplID, RefID);
                    StockMID = obDaIO.SaveUpdateStockInOutMaster(objINOUTM, formConnection, trans);

                    //StockIO Detail Save Update
                    int StockDID = 0;
                    int ItemID = 0, Countid, SizeId, ColorId;
                    double Qty = 0, orderqty = 0;
                    double UnitPrice = 0.0, Amt = 0.0;
                    string colorCode, labDip;
                    int i, nR;
                    nR = dgvSalesInvoiceDetails.Rows.Count;
                     if ((int)llblSOs.Tag == 2) nR--;
                    for (i = 0; i < nR; i++)
                    {
                        ItemID = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColItemID.Name, i].Value, 0);
                        Countid = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColCountID.Name, i].Value, 0);
                        SizeId = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColSizeID.Name, i].Value, 0);
                        ColorId = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColColorID.Name, i].Value, 0);
                        colorCode = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColColorCode.Name, i].Value, "");
                        labDip = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColLabdip.Name, i].Value, "");
                        Qty = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColInvQty.Name, i].Value, 0);
                        orderqty = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColOrderQty.Name, i].Value, 0);
                        if (cboInvoiceType.SelectedIndex != 1)
                        {
                            if (Qty > orderqty)
                            {
                                if (trans != null)
                                    trans.Rollback();
                                return;
                            }
                        }
                        UnitPrice = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColInvUnitPrice.Name, i].Value, 0.0);
                        Amt = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColPriceAmount.Name, i].Value, 0.0);
                        StockDID = obDaIO.getIODID(formConnection, trans, StockMID, ItemID);
                        objINOUTD = createInOutDetail(StockMID, StockDID, ItemID, Countid, SizeId, ColorId, colorCode, labDip, Qty, UnitPrice, Amt);
                        obDaIO.SaveUpdateStockInOutDetail(objINOUTD, formConnection, trans);
                    }

                    ///////////// UpdateRawMaterialAndFinishGoodsAccountBalance
              
                        new DaStockInOut().UpdateRawMaterialAndFinishGoodsAccountBalance(formConnection, trans);
                }

                //SalesInvoice Save update
                obSales_Invoice = createSalesInvoice(TMID, StockMID);
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                InvID = obDaSalesInvoice.saveUpdateSales_Invoice(obSales_Invoice, formConnection, trans);

                //SalesInvoiceDetail Save update
                if (cboInvoiceType.SelectedIndex != 2)
                {
                    int i, nR;
                    nR = dgvSalesInvoiceDetails.Rows.Count;
                    if ((int)llblSOs.Tag == 2) nR--;
                    for (i = 0; i < nR; i++)
                    {
                        obSales_Invoice_Detail = createSalesInvoiceDetails(InvID, i);
                        if (formConnection.State != ConnectionState.Open)
                            formConnection.Open();
                        obDaSalesInvoice.saveUpdateSales_Invoice_Detail(obSales_Invoice_Detail, formConnection, trans);
                    }
                }
                //Bills Save Update
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
                MessageBox.Show("Unable to Save or update " + ex.Message);
            }
        }
        private Sales_Invoice createSalesInvoice(int transRefID,int StockRefID)
        {
            Sales_Invoice obSales_Invoice = new Sales_Invoice();
            try
            {
                obSales_Invoice.InvoiceID = Convert.ToInt32(txtInvoiceID.Text);
                obSales_Invoice.InvoiceType = cboInvoiceType.SelectedItem.ToString();
                obSales_Invoice.InvoiceNo = txtInvoiceNo.Text.ToString();
                obSales_Invoice.ChalanNo = txtChalanNo.Text.ToString();
                obSales_Invoice.InvoiceDate = dtpInvoiceDate.Value.Date;
                obSales_Invoice.CustomerAccount = Convert.ToInt32(txtCustomerAcc.Text);
                obSales_Invoice.SalesAccount = Convert.ToInt32(txtSalesAcc.Text);
                obSales_Invoice.SalesAmount = Convert.ToDouble(txtSubTotal.Text);

                obSales_Invoice.DiscountRate = cboDiscount.SelectedIndex == 0 ? 0 : txtDiscount.Value;
                obSales_Invoice.DiscountAmount = cboDiscount.SelectedIndex == 0 ? txtDiscount.Value : Convert.ToDouble(txtSubTotal.Text) * txtDiscount.Value / 100;
                obSales_Invoice.TransAmount = Convert.ToDouble(txtTotalBill.Text);

                obSales_Invoice.TransRefID = transRefID;
                obSales_Invoice.StockRefID = StockRefID;
                obSales_Invoice.Remarks = rtxtRemarks.Text;
                obSales_Invoice.CurrencyID =(int)cmbCurrency.SelectedValue;
                obSales_Invoice.Rate = Convert.ToDouble(txtRate.Text);

                return obSales_Invoice;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private Sales_Invoice_Detail createSalesInvoiceDetails(int InvoiceID,int rowID)
        {
            Sales_Invoice_Detail obSales_Invoice_Detail = new Sales_Invoice_Detail();
            try
            {
                /*
                obSales_Invoice_Detail.SLNo = Convert.ToInt32(dgvSalesInvoiceDetails.Rows[rowID].Cells["SLNo"].Value);
                obSales_Invoice_Detail.InvoiceID = InvoiceID;
                if (dgvSalesInvoiceDetails.Rows[rowID].Cells["OrderID"].Value == null || dgvSalesInvoiceDetails.Rows[rowID].Cells["OrderID"].Value==DBNull.Value)
                    obSales_Invoice_Detail.OrderID = 0;
                else
                    obSales_Invoice_Detail.OrderID = Convert.ToInt32(dgvSalesInvoiceDetails.Rows[rowID].Cells["OrderID"].Value);
                obSales_Invoice_Detail.ItemID = Convert.ToInt32(dgvSalesInvoiceDetails.Rows[rowID].Cells["ItemID"].Value);
                obSales_Invoice_Detail.InvQty = Convert.ToDouble(dgvSalesInvoiceDetails.Rows[rowID].Cells["InvQty"].Value);
                obSales_Invoice_Detail.UnitID = Convert.ToInt32(dgvSalesInvoiceDetails.Rows[rowID].Cells["UnitID"].Value);
                obSales_Invoice_Detail.UnitPrice = Convert.ToDouble(dgvSalesInvoiceDetails.Rows[rowID].Cells["InvUnitPrice"].Value);
                obSales_Invoice_Detail.PriceAmount = Convert.ToDouble(dgvSalesInvoiceDetails.Rows[rowID].Cells["PriceAmount"].Value);
                obSales_Invoice_Detail.Remarks = dgvSalesInvoiceDetails.Rows[rowID].Cells["Remarks"].Value.ToString();
                obSales_Invoice_Detail.ColorCode = dgvSalesInvoiceDetails.Rows[rowID].Cells["ColorCode"].Value.ToString();
                obSales_Invoice_Detail.Labdip = dgvSalesInvoiceDetails.Rows[rowID].Cells["Labdip"].Value.ToString();
                return obSales_Invoice_Detail;
                 * */
                obSales_Invoice_Detail.SLNo = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColSLNo.Name, rowID].Value, 0);
                obSales_Invoice_Detail.InvoiceID = InvoiceID;
                obSales_Invoice_Detail.OrderID = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColOrderID.Name, rowID].Value, 0);
                obSales_Invoice_Detail.ItemID = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColItemID.Name, rowID].Value, 0);
                obSales_Invoice_Detail.InvQty = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColInvQty.Name, rowID].Value, 0.0);
                obSales_Invoice_Detail.UnitID = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColUnitID.Name, rowID].Value, 0);
                obSales_Invoice_Detail.UnitPrice = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColInvUnitPrice.Name, rowID].Value, 0.0);
                obSales_Invoice_Detail.PriceAmount = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColPriceAmount.Name, rowID].Value, 0.0);
                obSales_Invoice_Detail.Remarks = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColRemarks.Name, rowID].Value, "");
                obSales_Invoice_Detail.ColorCode = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColColorCode.Name, rowID].Value, "");
                obSales_Invoice_Detail.Labdip = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColLabdip.Name, rowID].Value, "");
                obSales_Invoice_Detail.ColorID = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColColorID.Name, rowID].Value, 0);
                obSales_Invoice_Detail.CountID = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColCountID.Name, rowID].Value, 0);
                obSales_Invoice_Detail.SizeID = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColSizeID.Name, rowID].Value, 0);
                return obSales_Invoice_Detail;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private TransactionMaster createTransactionMaster(SqlTransaction trans)
        {
            TransactionMaster objTM = null;
            try
            {
                objTM = new TransactionMaster();
                objTM.TransactionMasterID = int.Parse(txtTMID.Text);
                objTM.TransactionDate = dtpInvoiceDate.Value.Date;
                if (txtTMID.Text == "0")
                    objTM.VoucherNo = new DaTransaction().getVoucherNo(formConnection, trans, "J");
                else
                    objTM.VoucherNo = "";
                objTM.VoucherPayee = "";
                objTM.VoucherType = 3;
                objTM.TransactionMethodID = -1;
                objTM.MethodRefID = -1;
                objTM.MethodRefNo = string.Empty;
                objTM.TransactionDescription = "Via Sales Invoice";
                objTM.ApprovedBy = string.Empty;
                objTM.ApprovedDate = new DateTime(1900, 1, 1);
                objTM.Module = "Sales Invoice";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return objTM;
        }
        private TransactionDetail createTransactionDetail(int TDID,int TMID,int AccountID,double CrAmt,double DbAmt)
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
        private Stock_InOut_Master createInOutMaster(SqlTransaction trans, int CustSupplID, int RefID)
        {
            Stock_InOut_Master obIOMaster = null;
            DaStockInOut obDaIO = new DaStockInOut();
            try
            {
                obIOMaster = new Stock_InOut_Master();
                obIOMaster.StockMID = Convert.ToInt32(txtStockRefID.Text);
                obIOMaster.TransType = "Store Out For Customer";
                obIOMaster.TransDate = dtpInvoiceDate.Value.Date;
                obIOMaster.VoucherNo = obDaIO.getVoucherNo(formConnection, trans, "IO");
                obIOMaster.ChalanNo = txtChalanNo.Text;
                obIOMaster.ChalanDate = dtpInvoiceDate.Value.Date;
                obIOMaster.CustSupplID = CustSupplID;
                obIOMaster.RefID = RefID;
                obIOMaster.Remarks = "Store out via Sales invoice";
                obIOMaster.Module = "Sales Invoice";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obIOMaster;
        }
        private Stock_InOut_Detail createInOutDetail(int IOMID, int IODID, int ItemID, int Countid, int Sizeid, int Colorid, string colorcode, string labdip, double Qty, double UnitPrice, double Amt)
        {
            Stock_InOut_Detail obIOD = new Stock_InOut_Detail();
            try
            {
                obIOD.StockDID = IODID;
                obIOD.StockMID = IOMID;
                obIOD.TransNature = "Out";
                obIOD.ItemID = ItemID;
                obIOD.InQty = 0;
                obIOD.OutQty = Qty;
                obIOD.UnitPrice = UnitPrice;
                obIOD.InAmount = 0.0;
                obIOD.OutAmount = Amt;
                obIOD.Budle_Pack_Qty = "Store out";
                obIOD.ShortQty = 0;
                obIOD.Specifications = colorcode;
                obIOD.Budle_Pack_Size = labdip;
                obIOD.ColorID = Colorid;
                obIOD.CountID = Countid;
                obIOD.SizeID = Sizeid;
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
                objBills.BillAmount = Convert.ToDouble(txtTotalBill.Text);
                objBills.BillDate = dtpInvoiceDate.Value.Date;
                objBills.BillsType = "Bills Receivable";
                objBills.CustomerSupplierAccountID = Convert.ToInt32(txtCustomerAcc.Text);
                objBills.DueAmount = Convert.ToDouble(txtTotalBill.Text);
                objBills.RefInvoiceID = InvoiceID;
                    //Convert.ToInt32(txtInvoiceID.Text);
                objBills.RefInvoiceNo = txtInvoiceNo.Text.ToString();
                objBills.Remarks = "";
                objBills.Module = "Sales Invoice";
                objBills.BillForAccountID = Convert.ToInt32(txtSalesAcc.Text);
                return objBills;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void txtSalesAccount_Click(object sender, EventArgs e)
        {

        }
        private void dgvSalesInvoiceDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if ((cboInvoiceType.SelectedIndex == 1) && (dgvSalesInvoiceDetails.Columns[e.ColumnIndex].Name == "ColItemID"))
            //    {
            //        if (e.ColumnIndex == -1) return;
            //        loadItems();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Unable to open Item " + ex.Message);
            //}
        }
        private void loadItems()
        {
            try
            {
                frmItemSearch frm = new frmItemSearch();
                frm.ShowDialog();
                string Items = frm.ItemList;
                if (Items == "") return;
                addItems(Items);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void addItems(string items)
        {
            try
            {
                string where = " WHERE ItemID IN " + items;
                string Cols = "ItemID, UnitID, UnitsName AS Unit, dbo.fnGetPriceOfTime(" + CustSupplID.ToString() + ",ItemID,0,0,0,@priceDate) AS UnitPrice ";
                //string Cols = "ItemID,ItemName AS Item,CountName AS Count,SizesName AS Size,ColorsName AS Color,ShadeNo AS Shade ,null as ColorCode,null as Labdip,UnitID,UnitsName AS Unit,dbo.fnGetPriceOfTime(-1,ItemID,@priceDate) AS UnitPrice ";
                DataTable dt = new DAChartsOfItem().GetItemsWithPrice(where, dtpInvoiceDate.Value.Date, Cols, formConnection);

                int i, nR = dt.Rows.Count;

                for (i = 0; i < nR; i++)
                {
                    dgvSalesInvoiceDetails.Rows.Add(new object[] {
                    null,null,dt.Rows[i].Field<object>("ItemID"),null,null,null,null,null,0,dt.Rows[i].Field<object>("UnitID"),
                    dt.Rows[i].Field<object>("Unit"),0,dt.Rows[i].Field<object>("UnitPrice"),0,""
                });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void dgvSalesInvoiceDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex == -1)
                    return;
                if (dgvSalesInvoiceDetails.Columns[e.ColumnIndex].Name.ToLower() == "colinvqty" || dgvSalesInvoiceDetails.Columns[e.ColumnIndex].Name.ToLower() == "colinvunitprice")
                {
                    dgvSalesInvoiceDetails.Rows[e.RowIndex].Cells["ColPriceAmount"].Value = Convert.ToDouble(dgvSalesInvoiceDetails.Rows[e.RowIndex].Cells["ColInvQty"].Value == DBNull.Value ? 0 : dgvSalesInvoiceDetails.Rows[e.RowIndex].Cells["ColInvQty"].Value) * Convert.ToDouble(dgvSalesInvoiceDetails.Rows[e.RowIndex].Cells["ColInvUnitPrice"].Value);
                    CalculateRecords();
                }
                if (dgvSalesInvoiceDetails.Columns[e.ColumnIndex].Name == ColItemID.Name)
                    dgvSalesInvoiceDetails[ColUnit.Name, e.RowIndex].Value = new DAChartsOfItem().getUnitOfItem(formConnection, GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColItemID.Name, e.RowIndex].Value, 0));
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
                int i, nR = dgvSalesInvoiceDetails.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    subTotal += Convert.ToDouble(dgvSalesInvoiceDetails.Rows[i].Cells["ColPriceAmount"].Value == DBNull.Value ? 0 : dgvSalesInvoiceDetails.Rows[i].Cells["ColPriceAmount"].Value);
                }
                txtSubTotal.Text = subTotal.ToString("0.00");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                MessageBox.Show("Unable to Resel " + ex.Message);
            }
        }
        private void resetInvoice()
        {
            try
            {
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                loadInvoiceDetails(-4);
                txtChalanNo.Text = GlobalFunctions.generateNo(formConnection, "T_Sales_Invoice", "ChalanNo", "CO-");
                txtCustomerAcc.Text = "0";
                txtCustomerAccount.Text = "";
                txtDiscount.Value = 0;
                txtInvoiceID.Text = "0";
                txtInvoiceNo.Text = GlobalFunctions.generateNo(formConnection, "T_Sales_Invoice", "InvoiceNo", "SI-");
                //txtInvoiceNo.Text = "";
                txtSalesAcc.Text = "0";
                txtSalesAccount.Text = "";
                txtSubTotal.Text = "0.00";
                txtTotalBill.Text = "0.00";
                txtTMID.Text = "0";
                txtStockRefID.Text = "0";
                cboInvoiceType.SelectedIndex = 0;
                cboDiscount.SelectedIndex = 0;
                rtxtRemarks.Text = "";
                txtRate.Text = "1";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            frmFindInvoice obfrmFindInvoice = new frmFindInvoice();
            obfrmFindInvoice.ShowDialog();
            Sales_Invoice obSales_Invoice = new Sales_Invoice();
            obSales_Invoice = obfrmFindInvoice.obInvoice;
            if (obSales_Invoice == null) return;

            txtInvoiceID.Text = obSales_Invoice.InvoiceID.ToString();
            cmbCurrency.SelectedValue = obSales_Invoice.CurrencyID;
            if (obSales_Invoice.InvoiceType.ToString() == "Sales Order")
            {
                cboInvoiceType.SelectedIndex = 0;
            }
            else if (obSales_Invoice.InvoiceType.ToString() == "Direct Sale")
                cboInvoiceType.SelectedIndex = 1;
            else
                cboInvoiceType.SelectedIndex = 2;
            txtInvoiceNo.Text = obSales_Invoice.InvoiceNo.ToString();
            txtRate.Text = obSales_Invoice.Rate.ToString("0.00");
            txtChalanNo.Text = obSales_Invoice.ChalanNo.ToString();
            dtpInvoiceDate.Text = obSales_Invoice.InvoiceDate.ToString();
            obAccount = new Account();
            DaAccount obDaAccount = new DaAccount();
            obAccount = obDaAccount.getSalesAccount(formConnection, obSales_Invoice.CustomerAccount);
            txtCustomerAccount.Text = obAccount.AccountTitle.ToString();
            CustSupplID = Convert.ToInt32(obAccount.LedgerID);
            txtCustomerAcc.Text = obSales_Invoice.CustomerAccount.ToString();

            obAccount = obDaAccount.getSalesAccount(formConnection, obSales_Invoice.SalesAccount);
            txtSalesAcc.Text = obSales_Invoice.SalesAccount.ToString();
            txtSalesAccount.Text = obAccount.AccountTitle.ToString();

            txtSubTotal.Text = obSales_Invoice.SalesAmount.ToString();
            txtTotalBill.Text = obSales_Invoice.TransAmount.ToString();

            if (obSales_Invoice.DiscountRate == 0)
            {
                cboDiscount.SelectedIndex = 0;
                txtDiscount.Value = obSales_Invoice.DiscountAmount;
            }
            else
            {
                cboDiscount.SelectedIndex = 1;
                double disRate = (100 * (Convert.ToDouble(txtSubTotal.Text) - Convert.ToDouble(txtTotalBill.Text))) / Convert.ToDouble(txtSubTotal.Text);
                txtDiscount.Value = disRate;
            }
            rtxtRemarks.Text = obSales_Invoice.Remarks.ToString();
            txtTMID.Text = obSales_Invoice.TransRefID.ToString();
            txtStockRefID.Text = obSales_Invoice.StockRefID.ToString();
            
            loadInvoiceDetails(obSales_Invoice.InvoiceID);
            if (cboInvoiceType.SelectedIndex != 2)
                RefID = GlobalFunctions.isNull(dgvSalesInvoiceDetails[ColOrderID.Name, 0].Value, 0);
                    //dgvSalesInvoiceDetails.Rows[0].Cells["OrderID"].Value == DBNull.Value ? 0 : Convert.ToInt32(dgvSalesInvoiceDetails.Rows[0].Cells["OrderID"].Value);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DaSalesInvoice obDaSalesInvoice = new DaSalesInvoice();
            int InvoiceID = Convert.ToInt32(txtInvoiceID.Text);
            int TMID = Convert.ToInt32(txtTMID.Text);
            int StockRefID = Convert.ToInt32(txtStockRefID.Text);
            SqlTransaction trans = null;
            try
            {
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                trans = formConnection.BeginTransaction();
                obDaSalesInvoice.DeleteInvoice(formConnection,trans, InvoiceID, TMID, StockRefID);

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
                MessageBox.Show("Unable to Delete " + ex.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmSalesInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }
        private void dgvSalesInvoiceDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvSalesInvoiceDetails.Columns[dgvSalesInvoiceDetails.CurrentCell.ColumnIndex].CellType.Name == "DataGridViewComboBoxCell")
                SendKeys.Send("{F4}");
            else
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        private void txtDiscount_valueChanged(object sender, EventArgs e)
        {
            if (txtSubTotal.Text == "")
                return;
            double discount = 0.0;
            if (cboDiscount.SelectedIndex == 0)
            {
                discount = txtDiscount.Value;
                if (discount > Convert.ToDouble(txtSubTotal.Text))
                {
                    MessageBox.Show("Such amount of Discount not Accepted");
                    txtTotalBill.Text = "";
                    txtDiscount.Value = 0.0;
                    return;
                }
            }
            else if (txtDiscount.Value > 100)
            {
                MessageBox.Show("Please check % amount");
                txtTotalBill.Text = "";
                txtDiscount.Value = 0.0;
                return;
            }
            else if (txtDiscount.Value <= 0)
                discount = 0;
            else
                discount = (Convert.ToDouble(txtSubTotal.Text) * txtDiscount.Value) / 100;

            txtTotalBill.Text = (Convert.ToDouble(txtSubTotal.Text) - discount).ToString();

        }
        private void cboInvoiceType_SelectedValueChanged(object sender, EventArgs e)
        {
            loadInvoiceDetails(-4);
            try
            {
                if (cboInvoiceType.SelectedIndex == 2)
                {
                    dgvSalesInvoiceDetails.Enabled = false;
                    txtSubTotal.ReadOnly = false;
                    llblSOs.Enabled = false;
                    llblSOs.Tag = 0;
                }
                else
                {
                    dgvSalesInvoiceDetails.Enabled = true;
                    txtSubTotal.ReadOnly = true;
                    llblSOs.Enabled = true;
                }
                if (cboInvoiceType.SelectedIndex == 0)
                {
                    llblSOs.Text = "Select Sales Order to Invoice";
                    llblSOs.Tag = 1; //SO

                    ColColorID.ReadOnly = true;
                    ColColorCode.ReadOnly = true;
                    ColCountID.ReadOnly = true;
                    ColItemID.ReadOnly = true;
                    ColLabdip.ReadOnly = true;
                    ColSizeID.ReadOnly = true;
                    dgvSalesInvoiceDetails.AllowUserToAddRows = false;
                }
                else if (cboInvoiceType.SelectedIndex == 1)
                {
                    llblSOs.Text = "Select Items to Invoice";
                    llblSOs.Tag = 2; //Items

                    ColColorID.ReadOnly = false;
                    ColColorCode.ReadOnly = false;
                    ColCountID.ReadOnly = false;
                    ColItemID.ReadOnly = false;
                    ColLabdip.ReadOnly = false;
                    ColSizeID.ReadOnly = false;
                    dgvSalesInvoiceDetails.AllowUserToAddRows = true;
                }
                else
                {
                    ColColorID.ReadOnly = false;
                    ColColorCode.ReadOnly = false;
                    ColCountID.ReadOnly = false;
                    ColItemID.ReadOnly = false;
                    ColLabdip.ReadOnly = false;
                    ColSizeID.ReadOnly = false;
                    dgvSalesInvoiceDetails.AllowUserToAddRows = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvSalesInvoiceDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void frmSalesInvoice_Paint(object sender, PaintEventArgs e)
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
        private void dgvSalesInvoiceDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSalesInvoiceDetails.Columns[e.ColumnIndex].ReadOnly == true)
                SendKeys.Send("{TAB}");
        }
        private void llblSOs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if ((int)llblSOs.Tag == 1)
                {
                    if (txtCustomerAcc.Text == "0")
                    {
                        MessageBox.Show("Please Select A customer account first");
                        return;
                    }
                    int CustomerSalesAcc = Convert.ToInt32(txtCustomerAcc.Text);
                    frmsearchSalesOrder obfrmsearchSalesOrder = new frmsearchSalesOrder(CustomerSalesAcc);
                    obfrmsearchSalesOrder.ShowDialog();
                    Order_Master obOrderNo;
                    obOrderNo = obfrmsearchSalesOrder.ReturnOrderNo();
                    if (obOrderNo == null) return;
                    RefID = obOrderNo.OrderMID;
                    cmbCurrency.SelectedValue = obOrderNo.CurrencyID;
                    txtRate.Text = obOrderNo.Rate.ToString("0.00");
                    addOrder(obOrderNo.OrderMID);
                    CalculateRecords();
                }
                else if ((int)llblSOs.Tag == 2)
                {
                    loadItems();
                    //CalculateRecords();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Order loading failed " + ex.Message);
            }
        }

        private void rtxtRemarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboInvoiceType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtChalanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtCustomerAccount_KeyDown(object sender, KeyEventArgs e)
        {
            
               
            
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    obAccount = new Account();
                    frmAccountSearch obfrmCustomerAccount = new frmAccountSearch();
                    obfrmCustomerAccount.ShowDialog(" LedgerTypeID=2");
                    obAccount = obfrmCustomerAccount.SelectedAccount;
                    if (obAccount == null) return;
                    CustSupplID = obAccount.LedgerID;
                    txtCustomerAccount.Text = obAccount.AccountTitle.ToString();
                    txtCustomerAcc.Text = obAccount.AccountID.ToString();
                    
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to find Account " + ex.Message);
            }
            
        }

        private void dtpInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void dgvSalesInvoiceDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void rtxtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void cboDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void cboInvoiceType_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void txtInvoiceNo_Enter(object sender, EventArgs e)
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
            //conl.SelectAll();
        }

        private void txtInvoiceNo_Leave(object sender, EventArgs e)
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

        private void rtxtRemarks_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region report variable
            frmReportViewer frmRV = new frmReportViewer();
            ParameterValues pvc = new ParameterValues();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();

            #endregion
            try
            {

                rptSalesDeliveryChalan rptSalesDelivery = new rptSalesDeliveryChalan();

                pdv.Value = Convert.ToInt32(txtInvoiceID.Text);
                pvc.Add(pdv);
                rptSalesDelivery.DataDefinition.ParameterFields["@InvoiceID"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptSalesDelivery.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptSalesDelivery, false);

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
                db = Convert.ToDouble(txtTotalBill.Text) * Convert.ToDouble(txtRate.Text);
                txtTK.Text = db.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select in correct formate" + ex);
            }
        }

        private void txtTotalBill_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double db;
                db = Convert.ToDouble(txtTotalBill.Text) * Convert.ToDouble(txtRate.Text);
                txtTK.Text = db.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select in correct formate" + ex);
            }
        }

        private void txtInvoiceID_TextChanged(object sender, EventArgs e)
        {
            if (txtInvoiceID.Text == "0") return;
            if (cboInvoiceType.SelectedIndex == 0)
            {
                llblSOs.Enabled = false;
            }
            else
                llblSOs.Enabled = true;
        }
    }
}
