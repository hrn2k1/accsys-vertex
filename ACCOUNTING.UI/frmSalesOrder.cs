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
using Accounting.Entity;
using Accounting.DataAccess;
using Accounting.Reports;
using CrystalDecisions.Shared;

namespace Accounting.UI
{
    public partial class frmSalesOrder : Form
    {
        private SqlConnection formConnection = null;
        private DataTable dtDetails = new DataTable();
        private DataTable dtItems = new DataTable();
        private DataTable dtCounts = new DataTable();
        private DataTable dtSizes = new DataTable();
        private DataTable dtColors = new DataTable();
        private bool IsAmendment = false;
        public frmSalesOrder()
        {
            try
            {
                InitializeComponent();
            }
            catch{}
        }

        private void frmSalesOrder_Load(object sender, EventArgs e)
        {
            try
            {
                formConnection = ConnectionHelper.getConnection();
                loadFactory();
                loadCurrency();
                loadItems();
                loadCounts();
                loadSizes();
                loadColors();
                refresh();
                //loadOrderItems(-4);
                //formLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void loadItems()
        {
            try
            {
                dtItems = new DAChartsOfItem().getItemsForGrid(formConnection); // .GetItems(" WHERE CompanyID="+LogInInfo.CompanyID.ToString(), " ItemID,ItemName ", formConnection);
                colItem.DataSource = dtItems;
                colItem.DisplayMember = "ItemName";
                colItem.ValueMember = "ItemID";
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadCounts()
        {
            try
            {
                dtCounts = new DaCounts().getCountsForGrid(formConnection);
                colCount.DataSource = dtCounts;
                colCount.DisplayMember = "CountName";
                colCount.ValueMember = "CountID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadSizes()
        {
            try
            {
                dtSizes = new DaSizes().getSizesForGrid(formConnection);
                colSize.DataSource = dtSizes;
                colSize.DisplayMember = "SizesName";
                colSize.ValueMember = "SizesID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadColors()
        {
            try
            {
                dtColors = new Dacolors().getColorsForGrid(formConnection);
                colColor.DataSource = dtColors;
                colColor.DisplayMember = "ColorsName";
                colColor.ValueMember = "ColorsID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadOrderItems(int OrderMasterID)
        {
            try
            {
                if (dgvOrderDetails.Rows.Count > 0) dgvOrderDetails.Rows.Clear();
                dtDetails = new DaOrder().getOrderItems(formConnection, OrderMasterID);

                int i, nR;
                nR = dtDetails.Rows.Count;

                for (i = 0; i < nR; i++)
                {
                    dgvOrderDetails.Rows.Add(new object[] 
                    {
                        dtDetails.Rows[i].Field<object>("OrderMID"),dtDetails.Rows[i].Field<object>("OrderDID"),
                        dtDetails.Rows[i].Field<object>("ItemID"),dtDetails.Rows[i].Field<object>("CountID"),
                        dtDetails.Rows[i].Field<object>("SizeID"),dtDetails.Rows[i].Field<object>("ColorID"),
                        dtDetails.Rows[i].Field<object>("ColorCode"),dtDetails.Rows[i].Field<object>("labdip"),
                        dtDetails.Rows[i].Field<object>("OrderQty"),dtDetails.Rows[i].Field<object>("UnitsName"),
                        dtDetails.Rows[i].Field<object>("UnitPrice"),dtDetails.Rows[i].Field<object>("OrderValue"),
                        dtDetails.Rows[i].Field<object>("Remarks")
                    });
                }
                //dgvOrderDetails.DataSource = dtDetails;

                //dtDetails.Columns["ItemID"].Unique = true;
                //dgvOrderDetails.setColumnsVisible(false, "OrderDID", "OrderMID", "ItemID", "Shade", "UnitID", "GroupName", "ItemDescription", "ItemCode");
                //dgvOrderDetails.setColumnsReadOnly(true, "ItemName", "ItemCode", "Size", "Color", "Shade", "Count", "GroupName", "Unit", "OrderValue", "ItemDescription");
                //dgvOrderDetails.setColumnsFormat(new string[] { "OrderQty", "UnitPrice", "OrderValue" }, "0.00", "0.00", "0.00");
                //dgvOrderDetails.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvOrderDetails.Columns["OrderValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvOrderDetails.Columns["OrderQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvOrderDetails.setColumnsWidth(new string[] { "ItemName", "ColorCode", "Labdip", "Size", "Color", "Count", "Unit", "OrderQty", "UnitPrice", "OrderValue" }, 150, 60, 60, 60, 60, 60, 60, 60, 90, 90, 90);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //private void formLoad()
        //{
        //    try
        //    {
        //        DaOrder obDaOrder = new DaOrder();
        //        dtDetails=obDaOrder.loadForm(formConnection);
        //        if (dtDetails == null) return;
        //        dgvOrderDetails.DataSource = dtDetails;
        //        //dgvOrderDetails.setColumnsVisible(false, "ItemID");
        //        //dgvOrderDetails.setColumnsDisplayOrder(new string[] { "ItemName", "ColorsName", "CountName", "SizesName", "ShadeNo" });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private void loadFactory()
        {
            try
            {
                int Cid = txtCustomerID.Text == "" ? 0 : int.Parse(txtCustomerID.Text);
                DaOrder obDaOrder = new DaOrder();
                cmbFactoryName.DataSource = obDaOrder.loadFactory(Cid,formConnection);
                cmbFactoryName.DisplayMember = "FactoryName";
                cmbFactoryName.ValueMember = "FactoryID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private void loadDetails()
        //{
        //    try
        //    {
        //        DaOrder obDaOrder = new DaOrder();
        //        if (dgvOrderDetails.Columns.Count > 0)
        //            dgvOrderDetails.Columns.Clear();
        //        dtDetails = obDaOrder.loadDetail(formConnection);
        //        dgvOrderDetails.DataSource = dtDetails;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //private void loadAfterSelection(string strItemID)
        //{
        //    try
        //    {
        //        DaOrder obDaOrder = new DaOrder();
        //        if (dgvOrderDetails.Columns.Count > 0)   dgvOrderDetails.Columns.Clear();

        //        dtDetails = obDaOrder.loadSelectedItems(formConnection, strItemID);
        //        dgvOrderDetails.DataSource = dtDetails;

        //        DataGridViewComboBoxColumn colcbo = new DataGridViewComboBoxColumn();
        //        colcbo.DataSource = obDaOrder.loadUnit(formConnection);
        //        colcbo.Name = "Unit";
        //        colcbo.DisplayMember = "UnitsName";
        //        colcbo.ValueMember = "UnitsID";
        //        colcbo.HeaderText = "UnitsName";

        //        DataGridViewTextBoxColumn OrderQty, Price, OrderDID, OrderValue, UnitPrice;

        //        OrderDID = new DataGridViewTextBoxColumn();
        //        OrderDID.Name = "OrderDID";
        //        OrderDID.HeaderText = "OrderDID";
        //        OrderDID.ReadOnly = false;

        //        OrderQty = new DataGridViewTextBoxColumn();
        //        OrderQty.Name = "OrderQty";
        //        OrderQty.HeaderText = "OrderQty";
        //        OrderQty.ReadOnly = false;

        //        Price = new DataGridViewTextBoxColumn();
        //        Price.HeaderText = "Price";
        //        Price.Name = "Price";
        //        Price.ReadOnly = false;

        //        UnitPrice = new DataGridViewTextBoxColumn();
        //        UnitPrice.HeaderText = "UnitPrice";
        //        UnitPrice.Name = "UnitPrice";
        //        UnitPrice.ReadOnly = false;

        //        OrderValue = new DataGridViewTextBoxColumn();
        //        OrderValue.HeaderText = "OrderValue";
        //        OrderValue.Name = "OrderValue";
        //        OrderValue.ReadOnly = false;

        //        dgvOrderDetails.Columns.Add(OrderDID);
        //        dgvOrderDetails.Columns.Add(OrderQty);
        //        dgvOrderDetails.Columns.Add(colcbo);
        //        dgvOrderDetails.Columns.Add(Price);
        //        dgvOrderDetails.Columns.Add(UnitPrice);
        //        dgvOrderDetails.Columns.Add(OrderValue);
        //        dgvOrderDetails.setColumnsVisible(false, "OrderDID", "ItemID","Price");
        //       // dgvOrderDetails.setColumnsDisplayOrder(new string[] { "ItemName", "ColorsName", "SizesName", "CountName", "ShadeNo", "OrderQty", "Unit", "UnitPrice", "OrderValue" });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private void btnClose_Click(object sender, EventArgs e)
        {
            
                this.Close();
            
           
        }
        private void frmSalesOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }
        private bool validation()
        {
            if (txtCustomer.Text == "")
            {
                MessageBox.Show("Please Select a customer");
                return false;
            }
            if (txtOrderNo.Text == "")
            {
                MessageBox.Show("Please insert an OrderNo");
                return false;
            }
            //if (txtLedgerNo.Text == "")
            //{
            //    MessageBox.Show("Please Select a LedgerNo");
            //    return false;
            //}
            if (dgvOrderDetails.Rows.Count == 0)
            {
                MessageBox.Show("Empty Item List" + Environment.NewLine + "Please Add Items");
                return false;
            }
            if (txtTotalOrderQty.Text == "")
            {
                MessageBox.Show("Please ckeck Order Quantity and UnitPrice");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
            {
            if (validation() == false)
                return;
            SqlTransaction trans = null;
            try
            {
                getTotalQty();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                trans = formConnection.BeginTransaction();
                DaOrder obDaOrder = new DaOrder();
                Order_Master obOrder_Master = createMaster("Save");
                int lastID = obDaOrder.saveUpdateOrderMaster(obOrder_Master, trans, formConnection);
                
                int i, nR;
                nR = dgvOrderDetails.Rows.Count;
                for (i = 0; i < nR-1 ; i++)
                {
                    Order_Details obOrder_Details = createdetails(lastID, i, "Save");
                    obDaOrder.saveUpdateOrder_Details(obOrder_Details, trans, formConnection);
                }
                trans.Commit();
                refresh();
                loadCurrency();
                MessageBox.Show("Save Successfully");
               
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                MessageBox.Show(ex.Message);
            }

        }
        private Order_Master createMaster(string saveType)
        {
            try
            {
                Order_Master obOrder_Master = new Order_Master();

                int CustID, OrMID;
                if (txtOrderMID.Text.ToString() == "")
                    OrMID = 0;
                else
                    OrMID = int.Parse(txtOrderMID.Text);

                if (txtCustomerID.Text.ToString() == "")
                    CustID = 0;
                else
                    CustID = int.Parse(txtCustomerID.Text);

                obOrder_Master.OrderMID = OrMID;
                obOrder_Master.CustomerID = CustID;
                obOrder_Master.OrderNo = txtOrderNo.Text;
                obOrder_Master.OrderType = "Sales Order";
                obOrder_Master.LedgerNo = txtLedgerNo.Text;
                obOrder_Master.CurrencyID =(int)cmbCurrency.SelectedValue;
                obOrder_Master.OrderDate = dateTimePicker1.Value.Date;
                obOrder_Master.DeliveryDate = dateTimePicker2.Value.Date;
                obOrder_Master.FactoryID = cmbFactoryName.SelectedValue == DBNull.Value ? 0 : Convert.ToInt32(cmbFactoryName.SelectedValue);
                if (saveType == "Amend")
                {
                    obOrder_Master.TotalOrderQty = Convert.ToDouble(txtTotalOrderQty.Text) + Convert.ToDouble(txtTotalAQty.Text);
                    obOrder_Master.OrderValue = Convert.ToDouble(txtTotalOrderVal.Text) + Convert.ToDouble(txtTotalAValue.Text);
                }
                else
                {
                    obOrder_Master.TotalOrderQty = Convert.ToDouble(txtTotalOrderQty.Text);
                    obOrder_Master.OrderValue = Convert.ToDouble(txtTotalOrderVal.Text);
                }
                //int.Parse(txtTotalOrderQty.Text);
                
                //double.Parse(txtTotalOrderVal.Text);
                obOrder_Master.UnitID = 0;
                obOrder_Master.Rate = Convert.ToDouble(ctlNumRate.Value);
                obOrder_Master.Buyer_ref = rtxtBuyer_ref.Text;
                return obOrder_Master;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        private Order_Details createdetails(int OrderMID, int RowID,string SaveType)
        {
            Order_Details obOrder_Details = new Order_Details();
            try
            {
                obOrder_Details.OrderDID = GlobalFunctions.isNull( dgvOrderDetails["colODID", RowID].Value ,0);
                obOrder_Details.OrderMID = OrderMID;

                obOrder_Details.ItemID = Convert.ToInt32(dgvOrderDetails["colItem",RowID].Value);
                obOrder_Details.UnitID = 0;// Convert.ToInt32(dgvOrderDetails.Rows[RowID].Cells["UnitID"].Value);
                obOrder_Details.PriceID = 0;

                obOrder_Details.UnitPrice = GlobalFunctions.isNull(dgvOrderDetails["colUnitPrice", RowID].Value ,0.0);

                obOrder_Details.CountID = GlobalFunctions.isNull(dgvOrderDetails["colCount", RowID].Value, 0);
                obOrder_Details.SizeID = GlobalFunctions.isNull(dgvOrderDetails["colSize", RowID].Value, 0);
                obOrder_Details.ColorID = GlobalFunctions.isNull(dgvOrderDetails["colColor", RowID].Value, 0);

                
                if (SaveType == "Amend")
                {
                    obOrder_Details.OrderQty = GlobalFunctions.isNull(dgvOrderDetails["colQty",RowID].Value, 0.0) + GlobalFunctions.isNull(dgvOrderDetails["AQty",RowID].Value,0.0);
                    obOrder_Details.OrderValue = GlobalFunctions.isNull(dgvOrderDetails["colAmt",RowID].Value,0.0) + GlobalFunctions.isNull(dgvOrderDetails["AValue",RowID].Value,0.0);
                }
                else
                {

                    obOrder_Details.OrderQty = GlobalFunctions.isNull(dgvOrderDetails["colQty",RowID].Value,0.0);
                    obOrder_Details.OrderValue = GlobalFunctions.isNull(dgvOrderDetails["colAmt",RowID].Value, 0.0);

                }
                obOrder_Details.ColorCode = GlobalFunctions.isNull( dgvOrderDetails["colColorCode", RowID].Value,string.Empty);
                obOrder_Details.Labdip = GlobalFunctions.isNull(dgvOrderDetails["colLabdip",RowID].Value,string.Empty);
                obOrder_Details.Remarks = GlobalFunctions.isNull(dgvOrderDetails["colRemarks",RowID].Value,string.Empty);

                return obOrder_Details;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void dgvOrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == -1)
            //        return;
            //    if (dgvOrderDetails.Columns[e.ColumnIndex].Name == "ItemName")
            //    {
            //        string strItemID = "";
            //        //frmLvItem frmitem = new frmLvItem();
            //        frmItemSearch frm = new frmItemSearch();
            //        frm.ShowDialog();
            //        strItemID = frm.ItemList;
            //        if (strItemID == string.Empty) return;
            //        addItems(strItemID);
            //        //loadAfterSelection(strItemID);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void addItems(string items)
        {
            try
            {
                string where = " WHERE ItemID IN " + items;
                string Cols = "ItemID,UnitsName AS Unit,0.0 AS UnitPrice ";
                DataTable dt = new DAChartsOfItem().GetItemsWithPrice(where, dateTimePicker1.Value.Date, Cols, formConnection);

                int i, nR;
                nR = dt.Rows.Count;

                for (i = 0; i < nR; i++)
                {
                    dgvOrderDetails.Rows.Add(new object[] 
                    {
                        0,0,
                        dt.Rows[i].Field<object>("ItemID"),null,
                        null,null,
                        "","",
                        null,dt.Rows[i].Field<object>("Unit"),
                        dt.Rows[i].Field<object>("UnitPrice"),null,
                        null
                    });
                }
                //int i, nR = dt.Rows.Count;

                //for (i = 0; i < nR; i++)
                //{
                //   
                //        //dtDetails.Rows.Add(0, 0, dt.Rows[i].Field<object>("ItemID"), dt.Rows[i].Field<object>("ItemName"),
                //        //                          dt.Rows[i].Field<object>("ItemCode"), dt.Rows[i].Field<object>("Size"),
                //        //                          dt.Rows[i].Field<object>("Color"), dt.Rows[i].Field<object>("Shade"),
                //        //                          dt.Rows[i].Field<object>("Count"), null, dt.Rows[i].Field<object>("UnitID"),
                //        //                          dt.Rows[i].Field<object>("GroupName"), null, dt.Rows[i].Field<object>("Unit"),
                //        //                           dt.Rows[i].Field<object>("UnitPrice")
                //        //                          );


                //        dtDetails.Rows.Add(0, 0, dt.Rows[i].Field<object>("ItemID"), dt.Rows[i].Field<object>("ItemName"),
                //                                  dt.Rows[i].Field<object>("ItemCode"), dt.Rows[i].Field<object>("Count"),
                //                                  dt.Rows[i].Field<object>("Size"), dt.Rows[i].Field<object>("Color"),
                //                                  dt.Rows[i].Field<object>("Shade"), null, dt.Rows[i].Field<object>("GroupName"),
                //                                  dt.Rows[i].Field<object>("UnitID"), null, null, null,
                //                                  dt.Rows[i].Field<object>("Unit"), dt.Rows[i].Field<object>("UnitPrice")
                //                                       );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        private void txtCustomer_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Ledgers objCustomer;
            //    int CustomerID = 0;
            //    string CustomerName = "";
            //    frmCustomer obfrmCustomer = new frmCustomer();
            //    obfrmCustomer.ShowDialog();
            //    objCustomer = obfrmCustomer.ReturnCustomerID();
            //    if (objCustomer == null) return;
            //    CustomerID = objCustomer.LedgerID;
            //    CustomerName = objCustomer.LedgerName;
            //    txtCustomer.Text = CustomerName;
            //    txtCustomerID.Text = CustomerID.ToString();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            try
            {
                txtCustomerID.Text = "";
                txtCustomer.Text = "";
                txtOrderMID.Text = "";
                txtLedgerNo.Text = "";
                //txtOrderNo.Text = GlobalFunctions.generateNo(formConnection, "Order_Master", "OrderNo", "SO-");
                txtOrderNo.Text = "";
                txtTotalOrderQty.Text = "";
                txtTotalOrderVal.Text = "";
                txtTotalAQty.Text = "";
                txtTotalAValue.Text = "";
                ctlNumRate.Value = 1;
                rtxtBuyer_ref.Text = "";
                loadOrderItems(-4);
                //formLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                Ledgers obCustomer = new Ledgers();
                frmFind obfrmFind = new frmFind();
                obfrmFind.ShowDialog();
                Order_Master obOrderNo;
                obOrderNo = obfrmFind.obOrderNo;
                //obOrderNo = obfrmFind.ReturnOrderNo();
                if (obOrderNo == null) return;
                txtOrderNo.Text = obOrderNo.OrderNo.ToString();
                txtOrderMID.Text = obOrderNo.OrderMID.ToString();
                txtCustomerID.Text = obOrderNo.CustomerID.ToString();
                obCustomer = new DaLedger().GetLedger(formConnection, obOrderNo.CustomerID);
                txtCustomer.Text = obCustomer.LedgerName;
                cmbCurrency.SelectedValue = obOrderNo.CurrencyID;
                txtLedgerNo.Text = obOrderNo.LedgerNo;
                dateTimePicker1.Value = obOrderNo.OrderDate.Date;
                dateTimePicker2.Value = obOrderNo.DeliveryDate.Date;
                cmbFactoryName.SelectedValue = obOrderNo.FactoryID;
                txtTotalOrderQty.Text = obOrderNo.TotalOrderQty.ToString();
                txtTotalOrderVal.Text = obOrderNo.OrderValue.ToString();
                ctlNumRate.Value = obOrderNo.Rate;
                rtxtBuyer_ref.Text = obOrderNo.Buyer_ref;
                loadOrderItems(obOrderNo.OrderMID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void Find()
        //{
        //    string OrderNo = "";
        //    OrderNo = txtOrderNo.Text.ToString();
        //    DaOrder obDaOrder=new DaOrder();
        //    dtDetails = obDaOrder.Find(formConnection, OrderNo);
        //    if (dtDetails == null || dtDetails.Rows.Count == 0) return;
        //    txtCustomer.Text=dtDetails.Rows[0].Field<string>("CustomerName");
        //    txtOrderMID.Text = dtDetails.Rows[0].Field<int>("OrderMID").ToString();
        //    txtLedgerNo.Text = dtDetails.Rows[0].Field<string>("LedgerNo");
        //    dateTimePicker1.Text = dtDetails.Rows[0].Field<DateTime>("OrderDate").ToShortDateString();
        //    dateTimePicker2.Text = dtDetails.Rows[0].Field<DateTime>("DeliveryDate").ToShortDateString();

        //    cmbFactoryName.Text = dtDetails.Rows[0].Field<string>("FactoryName");
        //    txtTotalOrderQty.Text =dtDetails.Rows[0].Field<object>("TotalOrderQty").ToString();
        //    txtTotalOrderVal.Text = dtDetails.Rows[0].Field<object>("TotalOrderValue").ToString();
        //    lblUnit.Text = dtDetails.Rows[0].Field<string>("UnitsName");

        //    if (dgvOrderDetails.Columns.Count > 0) dgvOrderDetails.Columns.Clear();
            
        //    DataGridViewComboBoxColumn Colcbo = new DataGridViewComboBoxColumn();
        //    Colcbo.DataSource = obDaOrder.loadUnit(formConnection);
        //    Colcbo.Name = "Unit";
        //    Colcbo.HeaderText = "UnitsName";
        //    Colcbo.DisplayMember = "UnitsName";
        //    Colcbo.ValueMember = "UnitsID";
        //    Colcbo.DataPropertyName = "UnitID";
            
        //    dgvOrderDetails.setColumnsVisible(false, "OrderMID","CustomerID","FactoryID","UnitID","OrderDID","ItemID","PriceID");
        //    dgvOrderDetails.DataSource = dtDetails;
        //    dgvOrderDetails.setColumnsVisible(false, "OrderMID", "UnitsName", "OrderDID", "ItemID", "UnitID", "TotalOrderQty", "FactoryName", "FactoryID", "OrderDate", "DeliveryDate", "LedgerNo", "OrderNo", "CustomerName", "CustomerID", "OrderValue", "TotalOrderValue");
        //    dgvOrderDetails.setColumnsReadOnly(true, "ColorsName", "CountName", "SizesName", "ShadeNo");
        //    dgvOrderDetails.setColumnsDisplayOrder(new string[] {"ItemName","ColorsName","CountName","SizesName","ShadeNo","OrderQty","UnitPrice","OrderValue" });
        //    dgvOrderDetails.Columns.Add(Colcbo);
            
        //}
        private void btnDeleteItems_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderDetails.CurrentCell == null)
                    return;
                int rowID = 0;
                rowID = dgvOrderDetails.CurrentCell.RowIndex;
                int OrderDID = 0;
                OrderDID = GlobalFunctions.isNull(dgvOrderDetails[colODID.Name, rowID].Value, 0);//Convert.ToInt32(dgvOrderDetails.Rows[rowID].Cells["OrderDID"].Value == DBNull.Value ? 0 : dgvOrderDetails.Rows[rowID].Cells["OrderDID"].Value);

                if (OrderDID == 0)
                {
                    dgvOrderDetails.Rows.RemoveAt(rowID);
                   
                }
                else
                {
                if (MessageBox.Show("Are you sure to delete the Items", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                DaOrder obDaOrder = new DaOrder();

                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                
                
                    obDaOrder.DeleteItems(formConnection, OrderDID);
                    loadOrderItems(int.Parse(txtOrderMID.Text));
                    MessageBox.Show("Delete Successful");
                }
                if (IsAmendment == true)
                    AmendAction();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Delete Items" + ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOrderMID.Text == "")
                    return;
                int OrderMasterID = 0;
                OrderMasterID = Convert.ToInt32(txtOrderMID.Text.ToString());
                if (OrderMasterID == 0) return;

                if (MessageBox.Show("Are you sure to delete the Items", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                
                DaOrder obDaOrder = new DaOrder();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDaOrder.Delete(formConnection, OrderMasterID);
                MessageBox.Show("Delete Successful");
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Delete" + ex.Message);
            }
        }
        private void itmPrice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrderDetails.CurrentCell == null)
                    return;
                if (txtCustomerID.Text == "") return;
                if (dgvOrderDetails.Columns[dgvOrderDetails.CurrentCell.ColumnIndex].Name == colUnitPrice.Name)
                {
                    int ItemID, CustomerID,CountID,SizeID,ColorID;
                    double UnitPrice = 0.0;

                    CustomerID = Convert.ToInt32(txtCustomerID.Text.ToString());
                    ItemID = GlobalFunctions.isNull(dgvOrderDetails.CurrentRow.Cells[colItem.Name].Value, 0);
                    CountID = GlobalFunctions.isNull(dgvOrderDetails.CurrentRow.Cells[colCount.Name].Value, 0);
                    SizeID = GlobalFunctions.isNull(dgvOrderDetails.CurrentRow.Cells[colSize.Name].Value, 0);
                    ColorID = GlobalFunctions.isNull(dgvOrderDetails.CurrentRow.Cells[colColor.Name].Value, 0);
                    DaOrder obDaOrder = new DaOrder();
                    UnitPrice = obDaOrder.loadPrice(formConnection, CustomerID, ItemID,CountID,SizeID,ColorID,DateTime.Now.Date);
                    // MessageBox.Show(CustomerID.ToString() + ItemID.ToString() + UnitPrice.ToString());
                    dgvOrderDetails[colUnitPrice.Name, dgvOrderDetails.CurrentRow.Index].Value = UnitPrice;
                    //SendKeys.Send("{RIGHT}"
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getTotalQty()
            {
            double Qty = 0.0;
            double TotalVal = 0.0;
            double AQty = 0.0,Avalue=0.0;
            try
            {
                int  nR = dgvOrderDetails.Rows.Count;
                for (int i = 0; i < nR; i++)
                {
                    Qty += GlobalFunctions.isNull(dgvOrderDetails[colQty.Name,i].Value,0.0);
                    TotalVal += GlobalFunctions.isNull(dgvOrderDetails[colAmt.Name,i].Value,0.0);
                    
                    if(dgvOrderDetails.Columns.Contains("AQty"))
                    AQty += GlobalFunctions.isNull(dgvOrderDetails["AQty",i].Value,0.0);
                    if (dgvOrderDetails.Columns.Contains("AValue"))
                    Avalue += GlobalFunctions.isNull(dgvOrderDetails["AValue",i].Value,0.0) ;
                }
                txtTotalOrderQty.Text = Qty.ToString("0.00");
                txtTotalOrderVal.Text = TotalVal.ToString("0.00");
                txtTotalAQty.Text = AQty.ToString("0.00");
                txtTotalAValue.Text = Avalue.ToString("0.00");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void dgvOrderDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
                if (dgvOrderDetails.Columns[e.ColumnIndex].Name == colQty.Name || dgvOrderDetails.Columns[e.ColumnIndex].Name == colUnitPrice.Name)
                {
                    dgvOrderDetails.Rows[e.RowIndex].Cells[colAmt.Name].Value = GlobalFunctions.isNull(dgvOrderDetails[colQty.Name, e.RowIndex].Value, 0.0) * GlobalFunctions.isNull(dgvOrderDetails[colUnitPrice.Name, e.RowIndex].Value, 0.0);
                }
                if ((dgvOrderDetails.Columns[e.ColumnIndex].Name.ToLower() == "aqty" || dgvOrderDetails.Columns[e.ColumnIndex].Name == colUnitPrice.Name) && IsAmendment == true)
                {
                    dgvOrderDetails.Rows[e.RowIndex].Cells["AValue"].Value = GlobalFunctions.isNull(dgvOrderDetails["AQty", e.RowIndex].Value, 0.0) * GlobalFunctions.isNull(dgvOrderDetails[colUnitPrice.Name, e.RowIndex].Value, 0.0);
                }
                if (dgvOrderDetails.Columns[e.ColumnIndex].Name == colItem.Name)
                    dgvOrderDetails[colUnit.Name, e.RowIndex].Value = new DAChartsOfItem().getUnitOfItem(formConnection, GlobalFunctions.isNull( dgvOrderDetails[colItem.Name, e.RowIndex].Value,0));
                lblUnit.Text = dgvOrderDetails.Rows[e.RowIndex].Cells[colUnit.Name].Value.ToString();
                getTotalQty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmSalesOrder_Paint(object sender, PaintEventArgs e)
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
        private void dgvOrderDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
            if (dgvOrderDetails.Columns[dgvOrderDetails.CurrentCell.ColumnIndex].CellType.Name != "DataGridViewComboBoxCell")
                
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

        private void llblItems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string strItemID = "";
                //frmLvItem frmitem = new frmLvItem();
                frmItemSearch frm = new frmItemSearch();
                frm.ShowDialog();
                strItemID = frm.ItemList;
                if (strItemID == string.Empty) return;
                addItems(strItemID);
                //loadAfterSelection(strItemID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                loadFactory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Ledgers objCustomer;
                    int CustomerID = 0;
                    string CustomerName = "";
                    frmCustomer obfrmCustomer = new frmCustomer();
                    obfrmCustomer.ShowDialog();
                    objCustomer = obfrmCustomer.ReturnCustomerID();
                    if (objCustomer == null) return;
                    CustomerID = objCustomer.LedgerID;
                    CustomerName = objCustomer.LedgerName;
                    txtCustomer.Text = CustomerName;
                    txtCustomerID.Text = CustomerID.ToString();
                    cmbCurrency.SelectedValue = objCustomer.CurrencyID;

                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
              
        }

        private void txtOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtLedgerNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void cmbFactoryName_KeyDown(object sender, KeyEventArgs e)
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

        private void btnDelete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void btnDeleteItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void btnPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void cmbFactoryName_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void txtCustomer_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtOrderNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtLedgerNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtCustomer_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtOrderNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtLedgerNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                #region report variable
                frmReportViewer frmRV = new frmReportViewer();
                ParameterValues pvc = new ParameterValues();
                ParameterDiscreteValue pdv = new ParameterDiscreteValue();

                #endregion

                rptOrderSheet rpt = new rptOrderSheet();

                pdv.Value = Convert.ToInt32(txtOrderMID.Text);
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@OrderMID"].ApplyCurrentValues(pvc);

                pdv.Value = "Sales Order";
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@orderType"].ApplyCurrentValues(pvc);


                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rpt, false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AmendAction()
        {
            try
            {
                btnAmend.Text = "Save As &Amendment";
                pAmend.Enabled = true;
                btnFindAmendment.Enabled = true;

                dgvOrderDetails.Columns.Add("AQty", "Amend Qty");
                dgvOrderDetails.Columns["AQty"].ValueType = typeof(double);
                dgvOrderDetails.Columns.Add("AValue", "Amend Value");
                dgvOrderDetails.Columns["AValue"].ValueType = typeof(double);
                dgvOrderDetails.Columns["AValue"].ReadOnly = true;
                dgvOrderDetails.Columns[colQty.Name].ReadOnly = true;
                dgvOrderDetails.Columns["AQty"].ReadOnly = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void AmendCancelAction()
        {
            try
            {
                pAmend.Enabled = false;
                btnAmend.Text = "&Amendment";
                dgvOrderDetails.Columns[colQty.Name].ReadOnly=false;
                dgvOrderDetails.Columns["AQty"].ReadOnly = true;
                dgvOrderDetails.Columns.Remove("AQty");
                dgvOrderDetails.Columns.Remove("AValue");
                txtTotalAQty.Text = "0.00";
                txtTotalAValue.Text = "0.00";
                btnFindAmendment.Enabled = false;
                IsAmendment = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnAmend_Click(object sender, EventArgs e)
        {
            IsAmendment = true;
            SqlTransaction trans = null;
            try
            {
                if (validation() == false || txtOrderMID.Text == "")
                {
                    MessageBox.Show("Please Find an Order");
                    return;
                }
                    //return;
                if (btnAmend.Text == "&Amendment")
                {

                    AmendAction();


                    return;
                }
                //new frmOrderAmend().ShowDialog(Convert.ToInt32(txtOrderMID.Text));
                //loadOrderItems(Convert.ToInt32(txtOrderMID.Text));
                //getTotalQty();
                getTotalQty();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();

                DaOrder objDaOrder = new DaOrder();
                trans = formConnection.BeginTransaction();
                objDaOrder.CreateAmendment(formConnection, trans, 1, Convert.ToInt32(txtOrderMID.Text), dtpAmendDate.Value.Date, txtComment.Text, Convert.ToDouble(txtTotalAQty.Text), Convert.ToDouble(txtTotalAValue.Text));

                DaOrder obDaOrder = new DaOrder();
                Order_Master obOrder_Master = createMaster("Amend");
                int lastID = obDaOrder.saveUpdateOrderMaster(obOrder_Master, trans, formConnection);

                int i, nR;
                double AQty,Avalue;
                nR = dgvOrderDetails.Rows.Count;
                for (i = 0; i < nR - 1; i++)
                {
                    Order_Details obOrder_Details = createdetails(lastID, i, "Amend");
                    obDaOrder.saveUpdateOrder_Details(obOrder_Details, trans, formConnection);
                    AQty = GlobalFunctions.isNull(dgvOrderDetails.Rows[i].Cells["AQty"].Value, 0.0);
                    Avalue = GlobalFunctions.isNull(dgvOrderDetails.Rows[i].Cells["AValue"].Value, 0.0);
                    objDaOrder.UpdateOrderItemAmendment(formConnection, trans, obOrder_Details.OrderMID, obOrder_Details.OrderDID, obOrder_Details.ItemID, AQty, Avalue);
                }

               // objDaOrder.CreateAmendment(formConnection, trans, 2, Convert.ToInt32(txtOrderMID.Text), DateTime.Now.Date, "");
                
                trans.Commit();
                refresh();
                btnAmend.Text = "&Amendment";
                pAmend.Enabled = false;
                btnFindAmendment.Enabled = false;
                MessageBox.Show("Amendment Successfully Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                AmendCancelAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFindAmendment_Click(object sender, EventArgs e)
        {
            new frmOrderAmend().ShowDialog(Convert.ToInt32(txtOrderMID.Text));
            loadOrderItems(Convert.ToInt32(txtOrderMID.Text));
            AmendAction();
            return;
        }

        private void txtTotalOrderQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTtlQty.Text = (TextBoxValue(txtTotalOrderQty) + TextBoxValue(txtTotalAQty)).ToString("0.00");
                txtTtlValue.Text = (TextBoxValue(txtTotalOrderVal) + TextBoxValue(txtTotalAValue)).ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private double TextBoxValue(TextBox txt)
        {
            try
            {
                return Convert.ToDouble(txt.Text.Trim());
            }
            catch (FormatException ex)
            {
                return 0;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                dgvOrderDetails.Rows.Add(new object[] { 1, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value });
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvOrderDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrderDetails.Columns[e.ColumnIndex].CellType.Name == "DataGridViewComboBoxCell")
                SendKeys.Send("{F4}");
            
        }

        private void rtxtBuyer_ref_Enter(object sender, EventArgs e)
        {
            RichTextBox obrtxtBox = (RichTextBox)sender;
            obrtxtBox.ForeColor = Color.White;
            obrtxtBox.BackColor = Color.Black;
            obrtxtBox.SelectAll();
        }

        private void rtxtBuyer_ref_Leave(object sender, EventArgs e)
        {
            RichTextBox obrtxtBox = (RichTextBox)sender;
            obrtxtBox.ForeColor = Color.Black;
            obrtxtBox.BackColor = Color.White;
            obrtxtBox.SelectAll();
        }
    }
}
