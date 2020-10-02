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

namespace Accounting.UI
{
    public partial class frmPurchasesInvoice : Form
    {
     private SqlConnection conn = ConnectionHelper.getConnection();
      private DataTable dtPurInvoice = null;
       private Account obAccount = null;
       private DaTransaction obDaTrans = null;
       private int CustSupplID = 0, RefID = 0;
        public frmPurchasesInvoice()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmPurchasesInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = ConnectionHelper.getConnection();
                cmbInvoiceType.SelectedIndex = 0;
                loadPurchaseInvoiceDetails(-2);
                loadCurrency();
                txtInvoiceNo.Text = GlobalFunctions.generateNo(conn, "T_Purchase_Invoice", "InvoiceNo", "PI-");
                loadItem();
                loadCounts();
                loadSizes();
                loadColors();
                DaAccount AccDa = new DaAccount();
                txtPurchasesRawAccID.Text = (AccDa.GetAccountIdOfTitle(conn, txtPurchasesRowAcc.Text)).ToString();
                txtFinishAccID.Text = (AccDa.GetAccountIdOfTitle(conn, txtFinishAcc.Text)).ToString();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadItem()
        {
            DataTable Items = new DataTable();
            try
            {
                Items = new DAChartsOfItem().getItemsForGrid(conn);
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
                dtCounts = new DaCounts().getCountsForGrid(conn);
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
                dtSizes = new DaSizes().getSizesForGrid(conn);
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
                dtColors = new Dacolors().getColorsForGrid(conn);
                ColColorID.DataSource = dtColors;
                ColColorID.DisplayMember = "ColorsName";
                ColColorID.ValueMember = "ColorsID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadPurchaseInvoiceDetails(int InvoiceID)
        {
            try
            {
                DaPurchaseInvoice obDaPurchaseInvoice = new DaPurchaseInvoice();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                //if (ctlDGVPurchaseDTL.Columns.Count > 0) ctlDGVPurchaseDTL.Columns.Clear();
                if (ctlDGVPurchaseDTL.Rows.Count > 0) ctlDGVPurchaseDTL.Rows.Clear();
                dtPurInvoice = obDaPurchaseInvoice.PurchaseInvoiceDetails(conn, InvoiceID);
                int i, nR = dtPurInvoice.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    ctlDGVPurchaseDTL.Rows.Add(new object[] {
                    dtPurInvoice.Rows[i].Field<object>("SLNo"),dtPurInvoice.Rows[i].Field<object>("OrderID"),
                    dtPurInvoice.Rows[i].Field<object>("ItemID"),dtPurInvoice.Rows[i].Field<object>("CountID"),
                    dtPurInvoice.Rows[i].Field<object>("SizeID"),dtPurInvoice.Rows[i].Field<object>("ColorID"),
                    dtPurInvoice.Rows[i].Field<object>("ColorCode"),dtPurInvoice.Rows[i].Field<object>("Labdip"),
                    dtPurInvoice.Rows[i].Field<object>("OrderQty"),dtPurInvoice.Rows[i].Field<object>("UnitID"),dtPurInvoice.Rows[i].Field<object>("Unit"),
                    dtPurInvoice.Rows[i].Field<object>("InvQty"),dtPurInvoice.Rows[i].Field<object>("UnitPrice"),
                    dtPurInvoice.Rows[i].Field<object>("PriceAmount"),dtPurInvoice.Rows[i].Field<object>("Remarks")
                    });
                }

                //ctlDGVPurchaseDTL.DataSource = dtPurInvoice;
                //dtPurInvoice.Columns["ItemID"].Unique = true;
                //dtOrderItems.Columns["ItemID"].Unique = true;
                /*
                ctlDGVPurchaseDTL.setColumnsVisible(false, "SLNo", "InvoiceID", "OrderID", "ItemID", "Size", "Shade", "UnitID");
                ctlDGVPurchaseDTL.setColumnsReadOnly(true, "ColorCode", "Labdip", "Item", "Color", "Count", "Unit", "UnitPrice", "OrderQty", "OrderValue", "InvUnit", "PriceAmount");
                ctlDGVPurchaseDTL.setColumnsFormat(new string[] { "OrderQty", "UnitPrice", "OrderValue", "InvQty", "InvUnitPrice", "PriceAmount" }, "0.00", "0.00", "0.00", "0.00", "0.00", "0.00");
                ctlDGVPurchaseDTL.Columns["OrderQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctlDGVPurchaseDTL.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctlDGVPurchaseDTL.Columns["OrderValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctlDGVPurchaseDTL.Columns["InvQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctlDGVPurchaseDTL.Columns["InvUnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctlDGVPurchaseDTL.Columns["PriceAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                 * */
                CalculateRecords();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        private void addOrder(int OrderMID)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                DataTable dt = new DataTable();
                DaPurchaseInvoice obDaPurchaseInvoice = new DaPurchaseInvoice();
                dt = obDaPurchaseInvoice.loadOrder(conn, OrderMID);
                int i, nR = dt.Rows.Count;
                //dtPurInvoice.Rows.Clear();
                ctlDGVPurchaseDTL.Rows.Clear();
                for (i = 0; i < nR; i++)
                {
                    ctlDGVPurchaseDTL.Rows.Add(new object[] {
                    null,dt.Rows[i].Field<object>("OrderID"),
                    dt.Rows[i].Field<object>("ItemID"),dt.Rows[i].Field<object>("CountID"),
                    dt.Rows[i].Field<object>("SizeID"),dt.Rows[i].Field<object>("ColorID"),
                    dt.Rows[i].Field<object>("ColorCode"),dt.Rows[i].Field<object>("Labdip"),
                    dt.Rows[i].Field<object>("OrderQty"),dt.Rows[i].Field<object>("UnitID"),dt.Rows[i].Field<object>("Unit"),dt.Rows[i].Field<object>("AvailQty"),
                    dt.Rows[i].Field<object>("UnitPrice"),GlobalFunctions.isNull( dt.Rows[i].Field<object>("AvailQty"),0.0) * GlobalFunctions.isNull(dt.Rows[i].Field<object>("UnitPrice"),0.0)/*dt.Rows[i].Field<object>("OrderValue")*/,dt.Rows[i].Field<object>("Remarks")
                    });
                }

                /*
                for (i = 0; i < nR; i++)
                {
                    try
                    {
                        dtPurInvoice.Rows.Add(0, 0, dt.Rows[i].Field<object>("OrderID"), dt.Rows[i].Field<object>("ItemID"),
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
                }
                */
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void txtPurchasesAcc_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void ctlDGVPurchaseDTL_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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
                //MessageBox.Show("Select a item");
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
                DataTable dt = new DAChartsOfItem().GetItemsWithPrice(where, dtpInvoiceDate.Value.Date, Cols, conn);

                int i, nR = dt.Rows.Count;

                for (i = 0; i < nR; i++)
                {
                    ctlDGVPurchaseDTL.Rows.Add(new object[] {
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
        private void ctlDGVPurchaseDTL_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
                if (ctlDGVPurchaseDTL.Columns[e.ColumnIndex].Name.ToLower() == ColInvQty.Name.ToLower()  || ctlDGVPurchaseDTL.Columns[e.ColumnIndex].Name.ToLower() == ColUnitPrice.Name.ToLower())
                {
                    ctlDGVPurchaseDTL.Rows[e.RowIndex].Cells[ColPriceAmount.Name].Value = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColInvQty.Name, e.RowIndex].Value, 0.0) * GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColUnitPrice.Name, e.RowIndex].Value, 0.0);
                    if (ctlDGVPurchaseDTL.Columns[e.ColumnIndex].Name == ColItemID.Name)
                    {
                        ctlDGVPurchaseDTL[ColUnit.Name, e.RowIndex].Value = new DAChartsOfItem().getUnitOfItem(conn, GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColItemID.Name, e.RowIndex].Value, 0));
                        //Convert.ToDouble(ctlDGVPurchaseDTL.Rows[e.RowIndex].Cells["InvQty"].Value == DBNull.Value ? 0 : ctlDGVPurchaseDTL.Rows[e.RowIndex].Cells["InvQty"].Value) * Convert.ToDouble(ctlDGVPurchaseDTL.Rows[e.RowIndex].Cells["InvUnitPrice"].Value);
                    }
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
                double TTLraw = 0.0,TTLfinish=0.0;
                int i, nR = ctlDGVPurchaseDTL.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    subTotal += GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColPriceAmount.Name, i].Value, 0.0);

                    if(new DaOpeningStock().getItemCategory(conn,GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColItemID.Name,i].Value,0)).ToLower()=="finished good")
                        TTLfinish += GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColPriceAmount.Name, i].Value, 0.0);
                    else
                        TTLraw += GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColPriceAmount.Name, i].Value, 0.0);
                        //Convert.ToDouble(ctlDGVPurchaseDTL.Rows[i].Cells["PriceAmount"].Value == DBNull.Value ? 0 : ctlDGVPurchaseDTL.Rows[i].Cells["PriceAmount"].Value);
                }
                txtTransAmount.Text = subTotal.ToString("0.00");
                //txtTotalBill.Text = txtTransAmount.Text;
                ctlNumFinish.Value = TTLfinish;
                ctlNumRaw.Value = TTLraw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void ctlDGVPurchaseDTL_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (ctlDGVPurchaseDTL.Columns[ctlDGVPurchaseDTL.CurrentCell.ColumnIndex].CellType.Name != "DataGridViewComboBoxCell")
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        private void resetInvoice()
        {
            try
            {
                cmbInvoiceType.SelectedIndex = 0;
                loadPurchaseInvoiceDetails(-2);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                txtInvoiceNo.Text = GlobalFunctions.generateNo(conn, "T_Purchase_Invoice", "InvoiceNo", "PI-");
                txtInvoiceID.Text = "0";
                txtSupplierAccID.Text = "0";
                txtTransRefID.Text = "0";
                txtSupplierAcc.Text = "";
                DaAccount AccDa = new DaAccount();
                txtPurchasesRowAcc.Text = "Raw Materials Purchase";
                txtPurchasesRawAccID.Text = (AccDa.GetAccountIdOfTitle(conn, txtPurchasesRowAcc.Text)).ToString();

                txtFinishAcc.Text = "Finished Goods Purchase";
                txtFinishAccID.Text = (AccDa.GetAccountIdOfTitle(conn, txtFinishAcc.Text)).ToString();
                
                txtRemarks.Text = "";
                txtTransAmount.Text = "0.0";
                //txtTotalBill.Text = "0.0";
                txtStockRefID.Text = "0";
                txtRate.Text = "1";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Resel " + ex.Message);
            }
        }
        private bool validation()
        {
            if (txtInvoiceNo.Text == "")
            {
                MessageBox.Show("Please inser a valid InvoiceNo");
                return false;
            }
            if (txtSupplierAcc.Text == "")
            {
                MessageBox.Show("Please choose a Supplier");
                return false;
            }
            if (txtPurchasesRowAcc.Text == "")
            {
                MessageBox.Show("Please choose a Purchase Account");
                return false;
            }
            if (cmbInvoiceType.SelectedIndex != 2 && ctlDGVPurchaseDTL.Rows.Count == 0)
            {
                MessageBox.Show("Empty Order" + Environment.NewLine + "Please Select an Order or Items ");
                return false;
            }
            if (txtTransAmount.Text == "0.00" || txtTransAmount.Text == "0.0")
            {
                MessageBox.Show("Please Check Invoice Quantity and Unit Price");
                return false;
            }
                return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation() == false) return;
            DaPurchaseInvoice obDaPurchaseInvoice = new DaPurchaseInvoice();
            Purchases_Invoice obPurchase_Invoice = null;
            Purchases_Invoice_DTL obPurchase_Invoice_DTL = null;
            DaStockInOut obDaIO = new DaStockInOut();
            SqlTransaction trans = null;
            Bills objBills = new Bills();
            DaBills objDaBills = new DaBills();
            obDaTrans = new DaTransaction();
            int TMID = 0;
            int InvID = 0;
            int StockDID = 0;
            int StockMID = 0;
            try
            {
                TransactionMaster obTM = new TransactionMaster();
                TransactionDetail objTD = new TransactionDetail();
                Stock_InOut_Master objINOUTM = new Stock_InOut_Master();
                Stock_InOut_Detail objINOUTD = new Stock_InOut_Detail();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                trans = conn.BeginTransaction();

                // Transaction Master Save update 

                if (txtTransRefID.Text != "0")
                {
                    obDaTrans.DeleteTransDetail(int.Parse(txtTransRefID.Text), conn, trans);
                    //txtTMID.Text = "0";
                }

                obTM = createTransactionMaster(trans);
                TMID = obDaTrans.SaveEditTransactionMaster(obTM, conn, trans);

                //Transaction Detail Save update
                int SupplierAccID, PurchaseAccID,PurchaseAcc2ID;
                double CurrencyRate;
                CurrencyRate = Convert.ToDouble(txtRate.Text);
                SupplierAccID = Convert.ToInt32(txtSupplierAccID.Text);
                PurchaseAccID = Convert.ToInt32(txtPurchasesRawAccID.Text);
                PurchaseAcc2ID = Convert.ToInt32(txtFinishAccID.Text);
                double dblTransAmt = Convert.ToDouble(txtTransAmount.Text) * CurrencyRate;
                int TransDID = 0;

                //Credit Supplier Account
                TransDID = obDaTrans.getTransDID(conn, trans, TMID, SupplierAccID);
                objTD = createTransactionDetail(TransDID, TMID, SupplierAccID, dblTransAmt, 0);
                obDaTrans.SaveEditTransactionDetail(objTD, conn, trans);

                //Debit Purchase Account
                if (ctlNumRawTK.Value != 0)
                {
                    TransDID = obDaTrans.getTransDID(conn, trans, TMID, PurchaseAccID);
                    objTD = createTransactionDetail(TransDID, TMID, PurchaseAccID, 0, ctlNumRawTK.Value);
                    obDaTrans.SaveEditTransactionDetail(objTD, conn, trans);
                }
                if (ctlNumFinishTK.Value != 0)
                {
                    TransDID = obDaTrans.getTransDID(conn, trans, TMID, PurchaseAcc2ID);
                    objTD = createTransactionDetail(TransDID, TMID, PurchaseAcc2ID, 0, ctlNumFinishTK.Value);
                    obDaTrans.SaveEditTransactionDetail(objTD, conn, trans);
                }
                if (cmbInvoiceType.SelectedIndex != 2)
                {
                    // StockInOut Master Save Update
                    objINOUTM = createInOutMaster(trans, CustSupplID, RefID);
                    StockMID = obDaIO.SaveUpdateStockInOutMaster(objINOUTM, conn, trans);

                    //Stock I/O Detail Save Update
                    int ItemID, ColorID, CountID, SizeID;
                    double UnitPrice = 0.0, Amt = 0.0, Qty = 0, orderQty = 0;
                    string colorCode = "", Lapdip = "";
                    int i, nR;
                    nR = ctlDGVPurchaseDTL.Rows.Count;
                    //if ((int)llblPOs.Tag == 2) nR--;
                    if (ctlDGVPurchaseDTL.AllowUserToAddRows==true) nR--;
                    for (i = 0; i < nR; i++)
                    {
                        //ItemID = Convert.ToInt32(ctlDGVPurchaseDTL.Rows[i].Cells["ItemID"].Value);
                        //orderQty = Convert.ToDouble(ctlDGVPurchaseDTL.Rows[i].Cells["OrderQty"].Value); 
                        //Qty = Convert.ToDouble(ctlDGVPurchaseDTL.Rows[i].Cells["InvQty"].Value);
                        ItemID = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColItemID.Name, i].Value, 0);
                        orderQty = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColOrderQty.Name, i].Value, 0);
                        Qty = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColInvQty.Name, i].Value, 0);
                        CountID = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColCountID.Name, i].Value, 0);
                        SizeID = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColSizeID.Name, i].Value, 0);
                        ColorID = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColColorID.Name, i].Value, 0);
                        if (cmbInvoiceType.SelectedIndex != 1)
                        {
                            if (Qty > orderQty)
                            {
                                if (trans != null)
                                    trans.Rollback();
                                return;
                            }
                        }
                        UnitPrice = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColUnitPrice.Name, i].Value, 0.0);
                        Amt = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColPriceAmount.Name, i].Value, 0.0);
                        colorCode=GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColColorCode.Name,i].Value,"");
                        Lapdip = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColLabdip.Name, i].Value, "");
                        //UnitPrice = Convert.ToDouble(ctlDGVPurchaseDTL.Rows[i].Cells["InvUnitPrice"].Value);
                        //Amt = Convert.ToDouble(ctlDGVPurchaseDTL.Rows[i].Cells["PriceAmount"].Value);
                        StockDID = obDaIO.getIODID(conn, trans, StockMID, ItemID);
                        objINOUTD = createInOutDetail(StockMID, StockDID, ItemID, CountID, SizeID, ColorID,colorCode,Lapdip, Qty, UnitPrice, Amt);
                        obDaIO.SaveUpdateStockInOutDetail(objINOUTD, conn, trans);
                    }
                    ///////////// UpdateRawMaterialAndFinishGoodsAccountBalance
                    
                        new DaStockInOut().UpdateRawMaterialAndFinishGoodsAccountBalance(conn, trans);

                }
                //Purchase Invoice Bills SaveUpdate
                objBills = CreateObjectBills();
                objDaBills.SaveUpdateBills(conn, trans, objBills);

                //PurchaseInvoice Save update
                obPurchase_Invoice = createPurchaseInvoice(TMID, StockMID);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                InvID = obDaPurchaseInvoice.SaveUpdatePurchase_Invoice(obPurchase_Invoice,conn,trans);

                //PurchaseInvoiceDetail Save update
                if (cmbInvoiceType.SelectedIndex != 2)
                {
                    int i, nR;
                    nR = ctlDGVPurchaseDTL.Rows.Count;
                    //if ((int)llblPOs.Tag == 2) nR--;
                    if (ctlDGVPurchaseDTL.AllowUserToAddRows == true) nR--;
                    for (i = 0; i < nR; i++)
                    {
                        obPurchase_Invoice_DTL = createPurchaseInvoiceDetails(InvID, i);
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        obDaPurchaseInvoice.saveUpdatePurchase_Invoice_DTL(obPurchase_Invoice_DTL, conn, trans);
                    }
                }
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
                objTM.TransactionMasterID = int.Parse(txtTransRefID.Text);
                objTM.TransactionDate = dtpInvoiceDate.Value.Date;
                if (txtTransRefID.Text == "0")
                    if (txtSupplierAcc.Text.ToLower().Contains("cash"))
                    {
                        objTM.VoucherNo = new DaTransaction().getVoucherNo(conn, trans, "D");
                    }
                    else
                    { objTM.VoucherNo = new DaTransaction().getVoucherNo(conn, trans, "J"); }
                    else
                        objTM.VoucherNo = "";
                objTM.VoucherPayee = "";
                if (txtSupplierAcc.Text.ToLower().Contains("cash"))
                {
                    objTM.VoucherType = 2;
                }
                else
                { objTM.VoucherType = 3; }
                objTM.TransactionMethodID = -1;
                objTM.MethodRefID = -1;
                objTM.MethodRefNo = string.Empty;
                objTM.TransactionDescription = txtRemarks.Text;
                objTM.ApprovedBy = string.Empty;
                objTM.ApprovedDate = new DateTime(1900, 1, 1);
                objTM.Module = "Purchase Invoice";
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
        private Purchases_Invoice createPurchaseInvoice(int transRefID, int stockMID)
        {
            Purchases_Invoice obPurchase_Invoice = new Purchases_Invoice();
            try
            {
                obPurchase_Invoice.InvoiceID = Convert.ToInt32(txtInvoiceID.Text);
                obPurchase_Invoice.InvoiceType = cmbInvoiceType.SelectedItem.ToString();
                obPurchase_Invoice.InvoiceNo = txtInvoiceNo.Text.ToString();

                obPurchase_Invoice.InvoiceDate = dtpInvoiceDate.Value.Date;
                obPurchase_Invoice.SupplierAccountID = Convert.ToInt32(txtSupplierAccID.Text);
                obPurchase_Invoice.PurchasesAccountID = Convert.ToInt32(txtPurchasesRawAccID.Text);
                obPurchase_Invoice.PurchasesAccount2ID = Convert.ToInt32(txtFinishAccID.Text);
                obPurchase_Invoice.TransAmmount = Convert.ToDouble(txtTransAmount.Text);

                //obSales_Invoice.DiscountRate = cboDiscount.SelectedIndex == 0 ? 0 : txtDiscount.Value;
                //obSales_Invoice.DiscountAmount = cboDiscount.SelectedIndex == 0 ? txtDiscount.Value : Convert.ToDouble(txtSubTotal.Text) * txtDiscount.Value / 100;
                //obPurchase_Invoice.TransAmount = Convert.ToDouble(txtTotalBill.Text);

                obPurchase_Invoice.TransRefID = transRefID;
                obPurchase_Invoice.StockRefID = stockMID;
                obPurchase_Invoice.CurrencyID = (int)cmbCurrency.SelectedValue;
                obPurchase_Invoice.Remarks = txtRemarks.Text;
                obPurchase_Invoice.Rate =Convert.ToDouble( txtRate.Text);

                return obPurchase_Invoice;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private Purchases_Invoice_DTL createPurchaseInvoiceDetails(int InvoiceID, int rowID)
        {
            Purchases_Invoice_DTL obPurchase_Invoice_DTL = new Purchases_Invoice_DTL();
            try
            {
                /*
                obPurchase_Invoice_DTL.SLNO = Convert.ToInt32(ctlDGVPurchaseDTL.Rows[rowID].Cells["SLNo"].Value);
                obPurchase_Invoice_DTL.InvoiceID = InvoiceID;
                if (ctlDGVPurchaseDTL.Rows[rowID].Cells["OrderID"].Value == null || ctlDGVPurchaseDTL.Rows[rowID].Cells["OrderID"].Value == DBNull.Value)
                    obPurchase_Invoice_DTL.OrderID = 0;
                else
                    obPurchase_Invoice_DTL.OrderID = Convert.ToInt32(ctlDGVPurchaseDTL.Rows[rowID].Cells["OrderID"].Value);
                obPurchase_Invoice_DTL.ItemID = Convert.ToInt32(ctlDGVPurchaseDTL.Rows[rowID].Cells["ItemID"].Value);
                obPurchase_Invoice_DTL.InvQty = Convert.ToDouble(ctlDGVPurchaseDTL.Rows[rowID].Cells["InvQty"].Value);
                obPurchase_Invoice_DTL.UnitID = Convert.ToInt32(ctlDGVPurchaseDTL.Rows[rowID].Cells["UnitID"].Value);
                obPurchase_Invoice_DTL.UnitPrice = Convert.ToDouble(ctlDGVPurchaseDTL.Rows[rowID].Cells["InvUnitPrice"].Value);
                obPurchase_Invoice_DTL.PriceAmmount = Convert.ToDouble(ctlDGVPurchaseDTL.Rows[rowID].Cells["PriceAmount"].Value);
                obPurchase_Invoice_DTL.Remarks = ctlDGVPurchaseDTL.Rows[rowID].Cells["Remarks"].Value.ToString();
                obPurchase_Invoice_DTL.ColorCode = ctlDGVPurchaseDTL.Rows[rowID].Cells["ColorCode"].Value.ToString();
                obPurchase_Invoice_DTL.Labdip = ctlDGVPurchaseDTL.Rows[rowID].Cells["Labdip"].Value.ToString();
                 * */
                obPurchase_Invoice_DTL.SLNO = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColSLNo.Name, rowID].Value, 0);
                obPurchase_Invoice_DTL.InvoiceID = InvoiceID;
                obPurchase_Invoice_DTL.OrderID = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColOrderID.Name, rowID].Value, 0);
                obPurchase_Invoice_DTL.ItemID = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColItemID.Name, rowID].Value, 0);
                obPurchase_Invoice_DTL.InvQty = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColInvQty.Name, rowID].Value, 0.0);
                obPurchase_Invoice_DTL.UnitID = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColUnitID.Name, rowID].Value, 0);
                obPurchase_Invoice_DTL.UnitPrice = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColUnitPrice.Name, rowID].Value, 0.0);
                obPurchase_Invoice_DTL.PriceAmmount = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColPriceAmount.Name, rowID].Value, 0.0);
                obPurchase_Invoice_DTL.ColorCode = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColColorCode.Name, rowID].Value, "");
                obPurchase_Invoice_DTL.Labdip = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColLabdip.Name, rowID].Value, "");
                obPurchase_Invoice_DTL.Remarks = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColRemarks.Name, rowID].Value, "");

                obPurchase_Invoice_DTL.ColorID = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColColorID.Name, rowID].Value, 0);
                obPurchase_Invoice_DTL.CountID = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColCountID.Name, rowID].Value, 0);
                obPurchase_Invoice_DTL.SizeID = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColSizeID.Name, rowID].Value, 0);
                return obPurchase_Invoice_DTL;
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
                obIOMaster.StockMID = Convert.ToInt32(txtStockRefID.Text);
                obIOMaster.TransType = "Store In For Supplier";
                obIOMaster.TransDate = dtpInvoiceDate.Value.Date;
                obIOMaster.VoucherNo = obDaIO.getVoucherNo(conn, trans, "II");
                obIOMaster.ChalanNo = "";
                obIOMaster.ChalanDate = dtpInvoiceDate.Value.Date;
                obIOMaster.CustSupplID = CustSupplID;
                obIOMaster.RefID = RefID;
                obIOMaster.Remarks = "Store In ";
                obIOMaster.Module = "Purchase Invoice";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obIOMaster;
        }
        private Stock_InOut_Detail createInOutDetail(int IOMID, int IODID, int ItemID, int CountID, int SizeId, int ColorId, string colorCode,string lapdip,double Qty, double UnitPrice, double Amt)
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
                obIOD.InAmount = Amt;
                obIOD.OutAmount = 0.0;
                obIOD.Budle_Pack_Qty = "Store In";
                obIOD.ShortQty = 0;
                obIOD.ColorID = ColorId;
                obIOD.CountID = CountID;
                obIOD.SizeID = SizeId;
                obIOD.Specifications = colorCode;
                obIOD.Budle_Pack_Size = lapdip;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obIOD;
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

                txtInvoiceID.Text = obPurchase_Invoice.InvoiceID.ToString();
                if (obPurchase_Invoice.InvoiceType.ToString() == "Purchases Order")
                    cmbInvoiceType.SelectedIndex = 0;
                else if (obPurchase_Invoice.InvoiceType.ToString() == "Direct Purchases")
                    cmbInvoiceType.SelectedIndex = 1;
                else
                    cmbInvoiceType.SelectedIndex = 2;
                txtInvoiceNo.Text = obPurchase_Invoice.InvoiceNo.ToString();

                dtpInvoiceDate.Value = obPurchase_Invoice.InvoiceDate;
                obAccount = new Account();
                DaAccount obDaAccount = new DaAccount();
                obAccount = obDaAccount.getPurchaseAccount(conn, obPurchase_Invoice.SupplierAccountID);
                CustSupplID = obAccount.LedgerID;
                txtSupplierAcc.Text = obAccount.AccountTitle.ToString();
                txtSupplierAccID.Text = obPurchase_Invoice.SupplierAccountID.ToString();

                obAccount = obDaAccount.getPurchaseAccount(conn, obPurchase_Invoice.PurchasesAccountID);
                if (obAccount != null)
                {
                    txtPurchasesRawAccID.Text = obPurchase_Invoice.PurchasesAccountID.ToString();
                    txtPurchasesRowAcc.Text = obAccount.AccountTitle.ToString();
                }
                else
                {
                    txtPurchasesRawAccID.Text = "0";
                    txtPurchasesRowAcc.Text = string.Empty;
                }
               
                obAccount = obDaAccount.getPurchaseAccount(conn, obPurchase_Invoice.PurchasesAccount2ID);
                if (obAccount != null)
                {
                    txtFinishAccID.Text = obPurchase_Invoice.PurchasesAccount2ID.ToString();
                    txtFinishAcc.Text = obAccount.AccountTitle.ToString();
                }
                else
                {
                    txtFinishAccID.Text = "0";
                    txtFinishAcc.Text = string.Empty;
                }

                txtRate.Text = obPurchase_Invoice.Rate.ToString("0.00");
               
               
                //txtTotalBill.Text = obPurchase_Invoice.TransAmmount.ToString();

                txtRemarks.Text = obPurchase_Invoice.Remarks.ToString();
                txtTransRefID.Text = obPurchase_Invoice.TransRefID.ToString();
                txtStockRefID.Text = obPurchase_Invoice.StockRefID.ToString();
                cmbCurrency.SelectedValue = obPurchase_Invoice.CurrencyID;
                loadPurchaseInvoiceDetails(obPurchase_Invoice.InvoiceID);

                if (cmbInvoiceType.SelectedIndex == 2)
                    ctlNumRaw.Value = obPurchase_Invoice.TransAmmount;// / Convert.ToDouble(txtRate.Text);
                if (ctlDGVPurchaseDTL.Rows.Count == 0)
                {
                    //txtTransAmount.Text = obPurchase_Invoice.TransAmmount.ToString();
                    //ctlNumRaw.Value = obPurchase_Invoice.TransAmmount;// / Convert.ToDouble(txtRate.Text);
                    return;
                }
                if (cmbInvoiceType.SelectedIndex != 2)
                    RefID = GlobalFunctions.isNull(ctlDGVPurchaseDTL[ColOrderID.Name, 0].Value, 0);
                        //ctlDGVPurchaseDTL.Rows[0].Cells["OrderID"].Value == DBNull.Value ? 0 : Convert.ToInt32(ctlDGVPurchaseDTL.Rows[0].Cells["OrderID"].Value);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error"+ex);
            }
        
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DaPurchaseInvoice obDaPurchaseInvoice = new DaPurchaseInvoice();
            int InvoiceID = Convert.ToInt32(txtInvoiceID.Text);
            int TMID = Convert.ToInt32(txtTransRefID.Text);
            int StockRefID = Convert.ToInt32(txtStockRefID.Text);
            SqlTransaction trans = null;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                trans = conn.BeginTransaction();
                obDaPurchaseInvoice.DeletePurchaseInvoice(conn, trans,InvoiceID, TMID, StockRefID);

                ///////////// UpdateRawMaterialAndFinishGoodsAccountBalance
                
                    new DaStockInOut().UpdateRawMaterialAndFinishGoodsAccountBalance(conn, trans);
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
        private void txtInvoiceNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }
        private void txtSupplierAcc_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }
        private void txtPurchasesAcc_Enter(object sender, EventArgs e)
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
        private void txtInvoiceNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }
        private void txtSupplierAcc_Leave(object sender, EventArgs e)
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
        private void txtPurchasesAcc_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }
        //private void loadPurchaseInvoiceDetail(int InvoiceID)
        //{
        //    try
        //    {
        //        DaPurchaseInvoice obDaPurchaseInvoice = new DaPurchaseInvoice();
        //        if (conn.State != ConnectionState.Open)
        //            conn.Open();
        //        dtPurInvoice = obDaPurchaseInvoice.loadPurchasesInvoiceDetails(conn, InvoiceID);
        //        if (ctlDGVPurchaseDTL.Columns.Count > 0) ctlDGVPurchaseDTL.Columns.Clear();
        //        ctlDGVPurchaseDTL.DataSource = dtPurInvoice;
        //        ctlDGVPurchaseDTL.setColumnsVisible(false, "SLNo", "InvoiceID", "OrderID", "ItemID", "UnitID");
        //        ctlDGVPurchaseDTL.setColumnsReadOnly(true, "Item", "Color", "Count", "Size", "Shade", "Unit", "UnitPrice", "OrderQty", "OrderValue", "InvUnit", "PriceAmount");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private void cmbInvoiceType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }
        private void cmbInvoiceType_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }
        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }
        private void txtSupplierAcc_KeyDown(object sender, KeyEventArgs e)
        {
           

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    obAccount = new Account();
                    frmAccountSearch obfrmSupplierAccount = new frmAccountSearch();
                    obfrmSupplierAccount.ShowDialog(" LedgerTypeID=3 or (LedgerTypeID=1 and AccountTitle like '%cash%') ", Convert.ToInt32(txtSupplierAccID.Text));
                    obAccount = obfrmSupplierAccount.SelectedAccount;
                    if (obAccount == null) return;
                    CustSupplID = obAccount.LedgerID;
                    txtSupplierAcc.Text = obAccount.AccountTitle.ToString();
                    txtSupplierAccID.Text = obAccount.AccountID.ToString();
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to find Account " + ex.Message);
            }

        }
        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }
        private void dtpInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }
        private void btnFind_KeyDown(object sender, KeyEventArgs e)
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
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }
        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }
        private void txtTransAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }
        private void txtTotalBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }
        private void cmbInvoiceType_SelectedValueChanged(object sender, EventArgs e)
        {
            loadPurchaseInvoiceDetails(-2);
            try
            {
                if (cmbInvoiceType.SelectedIndex == 2)
                {
                    ctlDGVPurchaseDTL.Enabled = false;
                    //txtTransAmount.ReadOnly = false;
                    ctlNumFinish.ReadOnly = false;
                    ctlNumRaw.ReadOnly = false;
                    pFinish.Enabled = false;
                    llblPOs.Enabled = false;
                    llblPOs.Tag = 0;
                }
                else
                {
                    DaAccount AccDa = new DaAccount();
                    txtPurchasesRowAcc.Text = "Raw Materials Purchase";
                    txtPurchasesRawAccID.Text = (AccDa.GetAccountIdOfTitle(conn, txtPurchasesRowAcc.Text)).ToString();

                    txtFinishAcc.Text = "Finished Goods Purchase";
                    txtFinishAccID.Text = (AccDa.GetAccountIdOfTitle(conn, txtFinishAcc.Text)).ToString();
                    ctlDGVPurchaseDTL.Enabled = true;
                    //txtTransAmount.ReadOnly = true;
                    pFinish.Enabled = true;
                    llblPOs.Enabled = true;
                    ctlNumFinish.ReadOnly = true;
                    ctlNumRaw.ReadOnly = true;
                    if (cmbInvoiceType.SelectedIndex == 0)
                    {
                        llblPOs.Text = "Select Purchase Order to Invoice";
                        llblPOs.Tag = 1; //PO

                        ColColorID.ReadOnly = true;
                        ColColorCode.ReadOnly = true;
                        ColCountID.ReadOnly = true;
                        ColItemID.ReadOnly = true;
                        ColLabdip.ReadOnly = true;
                        ColSizeID.ReadOnly = true;
                        ctlDGVPurchaseDTL.AllowUserToAddRows = false;

                    }
                    else if (cmbInvoiceType.SelectedIndex == 1)
                    {

                        llblPOs.Text = "Select Items to Invoice";
                        llblPOs.Tag = 2; //Items

                        ColColorID.ReadOnly = false;
                        ColColorCode.ReadOnly = false;
                        ColCountID.ReadOnly = false;
                        ColItemID.ReadOnly = false;
                        ColLabdip.ReadOnly = false;
                        ColSizeID.ReadOnly = false;
                        ctlDGVPurchaseDTL.AllowUserToAddRows = true;
                    }
                    else
                    {
                        ColColorID.ReadOnly = false;
                        ColColorCode.ReadOnly = false;
                        ColCountID.ReadOnly = false;
                        ColItemID.ReadOnly = false;
                        ColLabdip.ReadOnly = false;
                        ColSizeID.ReadOnly = false;
                        ctlDGVPurchaseDTL.AllowUserToAddRows = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private Bills CreateObjectBills()
        {
            try
            {
                Bills objBills = new Bills();
                objBills.BillsID = 0;
                objBills.BillAmount = Convert.ToDouble(txtTransAmount.Text);
                objBills.BillDate = dtpInvoiceDate.Value.Date;
                objBills.BillsType = "Bills Payable";
                objBills.CustomerSupplierAccountID = Convert.ToInt32(txtSupplierAccID.Text);
                objBills.DueAmount = Convert.ToDouble(txtTransAmount.Text);
                objBills.RefInvoiceID = Convert.ToInt32(txtInvoiceID.Text);
                objBills.RefInvoiceNo = txtInvoiceNo.Text.ToString();
                objBills.Remarks = "";
                objBills.Module = "Purchase Invoice";
                objBills.BillForAccountID = Convert.ToInt32(txtPurchasesRawAccID.Text);
                objBills.BillForAccount2ID = Convert.ToInt32(txtFinishAccID.Text);
                return objBills;
            }
            catch (Exception ex)
            {
                throw ex;
            }


          
           
        }
        private void frmPurchasesInvoice_Paint(object sender, PaintEventArgs e)
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
        private void llblPOs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if ((int)llblPOs.Tag == 1)
                {

                    if (txtSupplierAccID.Text == "0")
                    {
                        MessageBox.Show("Please Select A supplier account first");
                        return;
                    }
                    int SupplierPurchaseAcc = Convert.ToInt32(txtSupplierAccID.Text);
                    frmSearchPurchaseOrder obfrmsearchPurchaseOrder = new frmSearchPurchaseOrder(SupplierPurchaseAcc);
                    obfrmsearchPurchaseOrder.ShowDialog();
                    Order_Master obOrderNo;

                    obOrderNo = obfrmsearchPurchaseOrder.ReturnOrderNo();
                    if (obOrderNo == null) return;
                    RefID = obOrderNo.OrderMID;
                    cmbCurrency.SelectedValue = obOrderNo.CurrencyID;
                    addOrder(obOrderNo.OrderMID);
                }
                else
                {
                    loadItems();
                }
                CalculateRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Order loading failed " + ex.Message);
            }
        }

        private void txtPurchasesAcc_KeyDown_1(object sender, KeyEventArgs e)
        {
                
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    obAccount = new Account();
                    frmAccountSearch obfrmCustomerAccount = new frmAccountSearch();
                    obfrmCustomerAccount.ShowDialog(Convert.ToInt32(txtPurchasesRawAccID.Text));
                    obAccount = obfrmCustomerAccount.SelectedAccount;
                    if (obAccount == null) return;
                    txtPurchasesRowAcc.Text = obAccount.AccountTitle;
                    txtPurchasesRawAccID.Text = obAccount.AccountID.ToString();
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to find Account " + ex.Message);
            }

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

        private void txtTransAmount_TextChanged(object sender, EventArgs e)
        {
            double db;
            db = Convert.ToDouble(txtTransAmount.Text) * Convert.ToDouble(txtRate.Text);
            txtTK.Text = db.ToString("0.00");
            
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double db;
                db = Convert.ToDouble(txtTransAmount.Text) * Convert.ToDouble(txtRate.Text);
                txtTK.Text = db.ToString("0.00");
                ctlNumRawTK.Value = ctlNumRaw.Value * Convert.ToDouble(txtRate.Text);
                ctlNumFinishTK.Value = ctlNumFinish.Value * Convert.ToDouble(txtRate.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRate_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void cmbCurrency_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void ctlDGVPurchaseDTL_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (ctlDGVPurchaseDTL.Columns[e.ColumnIndex].CellType.Name == "DataGridViewComboBoxCell")
                SendKeys.Send("{F4}");
        }

        private void txtInvoiceID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceID.Text == "0") return;
                if (cmbInvoiceType.SelectedIndex == 0)
                {
                    llblPOs.Enabled = false;
                }
                else
                    llblPOs.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CtlNum_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ctlNumRawTK.Value = ctlNumRaw.Value * Convert.ToDouble(txtRate.Text);
                ctlNumFinishTK.Value = ctlNumFinish.Value * Convert.ToDouble(txtRate.Text);
                txtTransAmount.Text = (ctlNumRaw.Value + ctlNumFinish.Value).ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFinishAcc_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    obAccount = new Account();
                    frmAccountSearch obfrmpurchaeAccount = new frmAccountSearch();
                    obfrmpurchaeAccount.ShowDialog(Convert.ToInt32(txtFinishAccID.Text));
                    obAccount = obfrmpurchaeAccount.SelectedAccount;
                    if (obAccount == null) return;
                    txtFinishAcc.Text = obAccount.AccountTitle;
                    txtFinishAccID.Text = obAccount.AccountID.ToString();
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to find Account " + ex.Message);
            }
        }

        private void txtSupplierAcc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
