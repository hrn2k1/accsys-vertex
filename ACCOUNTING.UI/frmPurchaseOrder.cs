using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Entity;
using System.Collections;
using Accounting.DataAccess;
using System.Data.SqlClient;
using Accounting.Utility;

namespace Accounting.UI
{
    public partial class frmPurchaseOrder : Form
    {
        private bool IsAmendment = false;
        private DataTable dtDetails = new DataTable();
        private DataTable dtItems = new DataTable();
        private DataTable dtCounts = new DataTable();
        private DataTable dtSizes = new DataTable();
        private DataTable dtColors = new DataTable();
        public frmPurchaseOrder()
        {
            InitializeComponent();
        }
        private Ledgers Supplier = null;
        private SqlConnection formCon = null;
        private DataTable dtOrderItems = null;
        private CurrencyManager cmOrderItems=null;
        private Order_Master objOrder=null;
        private int numFindingOrderID;
        private void txtSupplier_Enter(object sender, EventArgs e)
        {
            Control conl = (Control)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            //conl.SelectAll();
        }

        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmSupplierSearch frm = new frmSupplierSearch();

                    frm.ShowDialog();
                    Supplier = frm.SelectedSupplier;
                    if (Supplier == null)
                    {
                        //txtsupplierID.Text = "-1";
                        //txtSupplier.Text = string.Empty;
                    }
                    else
                    {
                        txtsupplierID.Text = Supplier.LedgerID.ToString();
                        txtSupplier.Text = Supplier.LedgerName;
                        cmbCurrency.SelectedValue = Supplier.CurrencyID;
                    }
                    //MessageBox.Show();
                    dtpOrderDate.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvOrderItems_DoubleClick(object sender, EventArgs e)
        {
            
            
        }

        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {
            try
            {
                formCon = ConnectionHelper.getConnection();
                loadCurrency();
               // LoadItemProperties();
               // btnNew_Click(null, null);
                loadItems();
                loadCounts();
                loadSizes();
                loadColors();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void ctldgvOrderItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == -1) return;


            //    if (ctldgvOrderItems.Columns[e.ColumnIndex].Name == "ItemName")
            //    {
            //        frmItemSearch frm = new frmItemSearch();
            //        frm.ShowDialog();
            //        string Items = frm.ItemList;
            //        if (Items == "") return;
            //        addItems(Items);
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
                DataTable dt = new DAChartsOfItem().GetItemsWithPrice(where, dtpOrderDate.Value.Date, Cols, formCon);

                int i, nR;
                nR = dt.Rows.Count;

                for (i = 0; i < nR; i++)
                {
                    ctldgvOrderItems.Rows.Add(new object[] 
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

        private void loadOrderItems(int OrderMasterID)
        {
            try
            {
                if (ctldgvOrderItems.Rows.Count > 0) ctldgvOrderItems.Rows.Clear();
                dtDetails = new DaOrder().getOrderItems(formCon, OrderMasterID);

                int i, nR;
                nR = dtDetails.Rows.Count;

                for (i = 0; i < nR; i++)
                {
                    ctldgvOrderItems.Rows.Add(new object[] 
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                txtPOID.Text = "0";
                //txtOrderNo.Text = GlobalFunctions.generateNo(formCon, "Order_Master", "OrderNo", "PO-");
                txtOrderNo.Text = "";
                dtpOrderDate.Value = DateTime.Now;
                txtTotalAmt.Text = "0";
                txtTotalQty.Text = "0";
                rtxtBuyer_ref.Text = "";
                ctltxtTotalAValue.Value = 0;
                ctltxtTotalAQty.Value = 0;
                loadOrderItems(-1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool Validation()
        {
            if (txtOrderNo.Text.Trim() == "")
            {
                MessageBox.Show("Enter a valid order no.");
                return false;
            }
           if(ctldgvOrderItems.Rows.Count==0)
            {
                MessageBox.Show("Its not a valid order without items." + Environment.NewLine + "Please input items and their quantity");
                return false;
            }

           return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation() == false) return;
          
            DaOrder objDaOrder = new DaOrder();
            Order_Master objOM = null;
            Order_Details objOD = null;
            SqlTransaction trans = null;
            
            int OMID = -1;
            try
            {
                CalculateTotals();
                if (formCon.State != ConnectionState.Open) formCon.Open();
                trans = formCon.BeginTransaction();

                objOM = CreateOrderMasterObject("Save");
                OMID = objDaOrder.saveUpdateOrderMaster(objOM, trans, formCon);

                int i,nR;
                nR = ctldgvOrderItems.Rows.Count - 1;
                for (i = 0; i < nR; i++)
                {
                    objOD = createdetails(OMID, i, "Save");
                    objDaOrder.saveUpdateOrder_Details(objOD, trans, formCon);
                }



                trans.Commit();
                MessageBox.Show("Saved Successfully");
                loadCurrency();
                btnNew_Click(null, null);
                txtSupplier.Focus();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private Order_Master CreateOrderMasterObject(string saveType)
        {
            Order_Master objOrderMaster = new Order_Master();
            try
            {
                objOrderMaster.OrderMID = int.Parse(txtPOID.Text);
                objOrderMaster.OrderNo = txtOrderNo.Text.Trim();
                objOrderMaster.OrderType = "Purchase Order";
                objOrderMaster.OrderDate = dtpOrderDate.Value.Date;
                objOrderMaster.LedgerNo = "";
                objOrderMaster.FactoryID = -1;
                objOrderMaster.CustomerID = int.Parse(txtsupplierID.Text);
                objOrderMaster.CurrencyID =(int)cmbCurrency.SelectedValue;
                objOrderMaster.DeliveryDate = new DateTime(1900, 1, 1);
                if (saveType == "Amend")
                {
                    objOrderMaster.TotalOrderQty = Convert.ToDouble(txtTotalQty.Text) + Convert.ToDouble(ctltxtTotalAQty.Value);
                    objOrderMaster.OrderValue = Convert.ToDouble(txtTotalAmt.Text) + Convert.ToDouble(ctltxtTotalAValue.Value);
                }
                else
                {
                    objOrderMaster.TotalOrderQty = Convert.ToDouble(txtTotalQty.Text);
                    objOrderMaster.OrderValue = Convert.ToDouble(txtTotalAmt.Text);
                }
                objOrderMaster.Buyer_ref = rtxtBuyer_ref.Text;
                //objOrderMaster.TotalOrderQty = double.Parse(txtTotalQty.Text);
                //objOrderMaster.OrderValue = Convert.ToDouble(txtTotalAmt.Text);
                
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            return objOrderMaster;
        }

        private Order_Details createdetails(int OrderMID, int RowID, string SaveType)
        {
            Order_Details obOrder_Details = new Order_Details();
            try
            {
                obOrder_Details.OrderDID = GlobalFunctions.isNull(ctldgvOrderItems["colODID", RowID].Value, 0);
                obOrder_Details.OrderMID = OrderMID;

                obOrder_Details.ItemID = Convert.ToInt32(ctldgvOrderItems["colItem", RowID].Value);
                obOrder_Details.UnitID = 0;// Convert.ToInt32(dgvOrderDetails.Rows[RowID].Cells["UnitID"].Value);
                obOrder_Details.PriceID = 0;

                obOrder_Details.UnitPrice = GlobalFunctions.isNull(ctldgvOrderItems["colUnitPrice", RowID].Value, 0.0);

                obOrder_Details.CountID = GlobalFunctions.isNull(ctldgvOrderItems["colCount", RowID].Value, 0);
                obOrder_Details.SizeID = GlobalFunctions.isNull(ctldgvOrderItems["colSize", RowID].Value, 0);
                obOrder_Details.ColorID = GlobalFunctions.isNull(ctldgvOrderItems["colColor", RowID].Value, 0);


                if (SaveType == "Amend")
                {
                    obOrder_Details.OrderQty = GlobalFunctions.isNull(ctldgvOrderItems["colQty", RowID].Value, 0.0) + GlobalFunctions.isNull(ctldgvOrderItems["AQty", RowID].Value, 0.0);
                    obOrder_Details.OrderValue = GlobalFunctions.isNull(ctldgvOrderItems["colAmount", RowID].Value, 0.0) + GlobalFunctions.isNull(ctldgvOrderItems["AValue", RowID].Value, 0.0);
                }
                else
                {

                    obOrder_Details.OrderQty = GlobalFunctions.isNull(ctldgvOrderItems["colQty", RowID].Value, 0.0);
                    obOrder_Details.OrderValue = GlobalFunctions.isNull(ctldgvOrderItems["colAmount", RowID].Value, 0.0);

                }
                obOrder_Details.ColorCode = GlobalFunctions.isNull(ctldgvOrderItems["colColorCode", RowID].Value, string.Empty);
                obOrder_Details.Labdip = GlobalFunctions.isNull(ctldgvOrderItems["colLabdip", RowID].Value, string.Empty);
                obOrder_Details.Remarks = GlobalFunctions.isNull(ctldgvOrderItems["colCQty", RowID].Value, string.Empty);

                return obOrder_Details;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void ctldgvOrderItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
                if (ctldgvOrderItems.Columns[e.ColumnIndex].Name.ToLower() == "colqty" || ctldgvOrderItems.Columns[e.ColumnIndex].Name.ToLower() == "colunitprice")
                {
                    ctldgvOrderItems.Rows[e.RowIndex].Cells["colAmount"].Value = Convert.ToDouble(ctldgvOrderItems.Rows[e.RowIndex].Cells["colQty"].Value == DBNull.Value ? 0 : ctldgvOrderItems.Rows[e.RowIndex].Cells["colQty"].Value) * Convert.ToDouble(ctldgvOrderItems.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                }
                if ((ctldgvOrderItems.Columns[e.ColumnIndex].Name.ToLower() == "aqty" || ctldgvOrderItems.Columns[e.ColumnIndex].Name.ToLower() == "colunitprice") /*&& IsAmendment == true*/)
                {
                    if (ctldgvOrderItems.Columns.Contains("AQty") && ctldgvOrderItems.Columns.Contains("AValue"))
                    ctldgvOrderItems.Rows[e.RowIndex].Cells["AValue"].Value = Convert.ToDouble(ctldgvOrderItems.Rows[e.RowIndex].Cells["AQty"].Value == DBNull.Value ? 0 : ctldgvOrderItems.Rows[e.RowIndex].Cells["AQty"].Value) * Convert.ToDouble(ctldgvOrderItems.Rows[e.RowIndex].Cells["colUnitPrice"].Value == DBNull.Value ? 0 : ctldgvOrderItems.Rows[e.RowIndex].Cells["colUnitPrice"].Value);
                }
                
                if (ctldgvOrderItems.Columns[e.ColumnIndex].Name == colItem.Name)
                    ctldgvOrderItems[colUnit.Name, e.RowIndex].Value = new DAChartsOfItem().getUnitOfItem(formCon, GlobalFunctions.isNull(ctldgvOrderItems[colItem.Name, e.RowIndex].Value, 0));
           
                CalculateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalculateTotals()
        {
            try
            {
                double totalAmt = 0;
                double totalQty = 0, AQty = 0, Avalue = 0;
                int i, nR;
                nR = ctldgvOrderItems.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    totalQty += Convert.ToDouble(ctldgvOrderItems.Rows[i].Cells["colQty"].Value == DBNull.Value ? 0 : ctldgvOrderItems.Rows[i].Cells["colQty"].Value);
                    totalAmt += Convert.ToDouble(ctldgvOrderItems.Rows[i].Cells["colAmount"].Value == DBNull.Value ? 0 : ctldgvOrderItems.Rows[i].Cells["colAmount"].Value);
                    if (ctldgvOrderItems.Columns.Contains("AQty"))
                        AQty += Convert.ToDouble(ctldgvOrderItems.Rows[i].Cells["AQty"].Value == DBNull.Value ? 0 : ctldgvOrderItems.Rows[i].Cells["AQty"].Value);
                    if (ctldgvOrderItems.Columns.Contains("AValue"))
                        Avalue += Convert.ToDouble(ctldgvOrderItems.Rows[i].Cells["AValue"].Value == DBNull.Value ? 0 : ctldgvOrderItems.Rows[i].Cells["AValue"].Value);

                }

                txtTotalQty.Text = totalQty.ToString("0.00");
                txtTotalAmt.Text = totalAmt.ToString("0.00");
                ctltxtTotalAQty.Value = AQty;
                ctltxtTotalAValue.Value = Avalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ctldgvOrderItems.CurrentCell == null) return;
                int rowID=ctldgvOrderItems.CurrentCell.RowIndex;
                int OrderDID = GlobalFunctions.isNull( ctldgvOrderItems.Rows[rowID].Cells[colODID.Name].Value,0);

                if (OrderDID == 0)
                    ctldgvOrderItems.Rows.RemoveAt(rowID);
                else
                {
                    new DaOrder().DeleteItems(formCon, OrderDID);
                    loadOrderItems(int.Parse(txtPOID.Text));
                }
                CalculateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearchOrder frm = new frmSearchOrder();
                frm.ShowDialog(Convert.ToInt32(txtsupplierID.Text), "Purchase Order", false);
                if (frm.OrderIDs == null) return;
                numFindingOrderID = Convert.ToInt32(frm.OrderIDs[0]);
                DaOrder objDaOrder = new DaOrder();
                objOrder = objDaOrder.GetOrder_Master(formCon, numFindingOrderID);
                txtPOID.Text = numFindingOrderID.ToString();
                txtSupplier.Text = (new DaLedger().GetLedger(formCon, objOrder.CustomerID)).LedgerName;
                txtsupplierID.Text = objOrder.CustomerID.ToString();
                txtOrderNo.Text = objOrder.OrderNo;
                rtxtBuyer_ref.Text = objOrder.Buyer_ref;
                dtpOrderDate.Value = objOrder.OrderDate;
                cmbCurrency.SelectedValue = objOrder.CurrencyID;
                txtTotalQty.Text = objOrder.TotalOrderQty.ToString();
                txtTotalAmt.Text = objOrder.OrderValue.ToString("0.00");
                //ctltxtTotalAQty.Value=
                loadOrderItems(numFindingOrderID);
                
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

        private void btnDelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPOID.Text == "" || txtPOID.Text == "0")
                    return;
                if (MessageBox.Show("Are you sure to delete the Items", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                int OrderMasterID = 0;
                OrderMasterID = Convert.ToInt32(txtPOID.Text.ToString());
                DaOrder obDaOrder = new DaOrder();
                if (formCon.State != ConnectionState.Open)
                    formCon.Open();
                obDaOrder.Delete(formCon, OrderMasterID);
                MessageBox.Show("Delete Successful");
                 btnNew_Click(sender,e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Delete" + ex.Message);
            }
        }

        private void ctldgvOrderItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (ctldgvOrderItems.Columns[ctldgvOrderItems.CurrentCell.ColumnIndex].CellType.Name == "DataGridViewComboBoxCell")
                SendKeys.Send("{F4}");
            else
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

       

        private void ctldgvOrderItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmPurchaseOrder_Paint(object sender, PaintEventArgs e)
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

        private void txtSupplier_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    frmSupplierSearch frm = new frmSupplierSearch();

            //    frm.ShowDialog();
            //    Supplier = frm.SelectedSupplier;
            //    if (Supplier == null)
            //    {
            //        //txtsupplierID.Text = "-1";
            //        //txtSupplier.Text = string.Empty;
            //    }
            //    else
            //    {
            //        txtsupplierID.Text = Supplier.LedgerID.ToString();
            //        txtSupplier.Text = Supplier.LedgerName;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void llblItems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpOrderDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control c = (Control)sender;
                SelectNextControl(c, true, true, true, true);
            }
        }

        private void btnAmend_Click(object sender, EventArgs e)
        {
            IsAmendment = true;
            SqlTransaction trans = null;
            try
            {
                if (Validation() == false)
                    return;
                if (Convert.ToInt32(txtPOID.Text) <= 0) return;
                if (btnAmend.Text == "&Amendment")
                {

                    AmendAction();


                    return;
                }
                //new frmOrderAmend().ShowDialog(Convert.ToInt32(txtPOID.Text));
                //loadOrderItems(Convert.ToInt32(txtPOID.Text));
                //CalculateTotals();
                CalculateTotals();
                if (formCon.State != ConnectionState.Open)
                    formCon.Open();

                DaOrder objDaOrder = new DaOrder();
                trans = formCon.BeginTransaction();
                objDaOrder.CreateAmendment(formCon, trans, 1, Convert.ToInt32(txtPOID.Text), dtpAmendDate.Value.Date, txtAmendmentComment.Text, Convert.ToDouble(ctltxtTotalAQty.Value), Convert.ToDouble(ctltxtTotalAValue.Value));

                DaOrder obDaOrder = new DaOrder();
                Order_Master obOrder_Master = CreateOrderMasterObject("Amend");
                int lastID = obDaOrder.saveUpdateOrderMaster(obOrder_Master, trans, formCon);

                int i, nR;
                double AQty, Avalue;
                nR = ctldgvOrderItems.Rows.Count;
                for (i = 0; i < nR-1; i++)
                {
                    Order_Details obOrder_Details = createdetails(lastID, i, "Amend");
                    obDaOrder.saveUpdateOrder_Details(obOrder_Details, trans, formCon);
                    AQty = Convert.ToDouble(ctldgvOrderItems.Rows[i].Cells["AQty"].Value == DBNull.Value ? 0 : ctldgvOrderItems.Rows[i].Cells["AQty"].Value);
                    Avalue = Convert.ToDouble(ctldgvOrderItems.Rows[i].Cells["AValue"].Value == DBNull.Value ? 0 : ctldgvOrderItems.Rows[i].Cells["AValue"].Value);
                    objDaOrder.UpdateOrderItemAmendment(formCon, trans, obOrder_Details.OrderMID, obOrder_Details.OrderDID, obOrder_Details.ItemID, AQty, Avalue);
                }

                // objDaOrder.CreateAmendment(formCon, trans, 2, Convert.ToInt32(txtPOID.Text), DateTime.Now.Date, "");

                trans.Commit();
                btnNew_Click(null, null);
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
        private void AmendAction()
        {
            try
            {
                btnAmend.Text = "Save As &Amendment";
                pAmend.Enabled = true;
                btnFindAmendment.Enabled = true;

                ctldgvOrderItems.Columns.Add("AQty", "Amend Qty");
                ctldgvOrderItems.Columns["AQty"].ValueType = typeof(double);
                ctldgvOrderItems.Columns.Add("AValue", "Amend Value");
                ctldgvOrderItems.Columns["AValue"].ValueType = typeof(double);
                ctldgvOrderItems.Columns["AValue"].ReadOnly = true;
                ctldgvOrderItems.Columns["colQty"].ReadOnly = true;
                ctldgvOrderItems.Columns["AQty"].ReadOnly = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnFindAmendment_Click(object sender, EventArgs e)
        {
            try
            {
                new frmOrderAmend().ShowDialog(Convert.ToInt32(txtPOID.Text));
                numFindingOrderID = Convert.ToInt32(txtPOID.Text);
                loadOrderItems(numFindingOrderID);
                CalculateTotals();
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
        private void AmendCancelAction()
        {
            try
            {
                pAmend.Enabled = false;
                btnAmend.Text = "&Amendment";
                ctldgvOrderItems.Columns["OrderQty"].ReadOnly = false;
                ctldgvOrderItems.Columns["AQty"].ReadOnly = true;
                ctldgvOrderItems.Columns.Remove("AQty");
                ctldgvOrderItems.Columns.Remove("AValue");
                ctltxtTotalAQty.Value = 0;
                ctltxtTotalAValue.Value = 0;
                btnFindAmendment.Enabled = false;
                IsAmendment = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTtlQty.Text = (TextBoxValue(txtTotalQty) + ctltxtTotalAQty.Value).ToString("0.00");
                txtTtlValue.Text = (TextBoxValue(txtTotalAmt) + ctltxtTotalAValue.Value).ToString("0.00");
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

        private void ctltxtTotalAQty_valueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTtlQty.Text = (TextBoxValue(txtTotalQty) + ctltxtTotalAQty.Value).ToString("0.00");
                txtTtlValue.Text = (TextBoxValue(txtTotalAmt) + ctltxtTotalAValue.Value).ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                MessageBox.Show("There is an error to load currency" + ex);
            }
        }


        private void LoadItemProperties()
        {
            try
            {
                DaOrder obDaOrder = new DaOrder();

                if (ctldgvOrderItems.Columns.Count > 0) ctldgvOrderItems.Columns.Clear();

                DataGridViewComboBoxColumn colcbo, colcbo1, colcbo2, colcbo3;
                colcbo = new DataGridViewComboBoxColumn();
                colcbo1 = new DataGridViewComboBoxColumn();
                colcbo2 = new DataGridViewComboBoxColumn();
                colcbo3 = new DataGridViewComboBoxColumn();

                //colcbo.DataSource = obDaOrder.loadItem(formCon);
                //colcbo.Name = "ItemID";
                //colcbo.DisplayMember = "ItemName";
                //colcbo.HeaderText = "Item";
                //colcbo.ValueMember = "ItemID";
                //colcbo.DataPropertyName = "ItemID";
                //ctldgvOrderItems.Columns.Add(colcbo);

                colcbo1.DataSource = obDaOrder.loadCount(formCon);
                colcbo1.Name = "CountID";
                colcbo1.DisplayMember = "CountName";
                colcbo1.HeaderText = "Count";
                colcbo1.ValueMember = "CountID";
                colcbo1.DataPropertyName = "CountID";
                ctldgvOrderItems.Columns.Add(colcbo1);



                colcbo3.DataSource = obDaOrder.loadColor(formCon);
                colcbo3.Name = "ColorsID";
                colcbo3.DisplayMember = "ColorsName";
                colcbo3.HeaderText = "Colors";
                colcbo3.ValueMember = "ColorsID";
                colcbo3.DataPropertyName = "ColorsID";
                ctldgvOrderItems.Columns.Add(colcbo3);




                colcbo2.DataSource = obDaOrder.loadSize(formCon); 
                colcbo2.Name = "SizesID";
                colcbo2.DisplayMember = "SizesName";
                colcbo2.HeaderText = "Size";
                colcbo2.ValueMember = "SizesID";
                colcbo2.DataPropertyName = "SizesID";
                ctldgvOrderItems.Columns.Add(colcbo2);

                //dtMembers = obDaOrder.loadDetail(formConnection, TeamID);
                //dgvTeamDetails.DataSource = dtMembers;
                //dgvTeamDetails.setColumnsVisible(false, "MemberID", "TeamID");
                //dgvTeamDetails.setColumnsDisplayOrder(new string[] { "MemberName", "DesignationID", "DeptID", "ContactNo", "Remarks" });

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
                dtCounts = new DaCounts().getCountsForGrid(formCon);
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
                dtSizes = new DaSizes().getSizesForGrid(formCon);
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
                dtColors = new Dacolors().getColorsForGrid(formCon);
                colColor.DataSource = dtColors;
                colColor.DisplayMember = "ColorsName";
                colColor.ValueMember = "ColorsID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LoadOrderItems(int OrderMasterID)
        {
            try
            {
                if (ctldgvOrderItems.Rows.Count > 0) ctldgvOrderItems.Rows.Clear();
                dtDetails = new DaOrder().getOrderItems(formCon, OrderMasterID);

                int i, nR;
                nR = dtDetails.Rows.Count;

                for (i = 0; i < nR; i++)
                {
                    ctldgvOrderItems.Rows.Add(new object[] 
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

        private void loadItems()
        {
            try
            {
                dtItems = new DAChartsOfItem().getItemsForGrid(formCon);
                colItem.DataSource = dtItems;
                colItem.DisplayMember = "ItemName";
                colItem.ValueMember = "ItemID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtsupplierID_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtsupplierID.Text == "0") return;
            //    DaOrder objDaorder = new DaOrder();
            //    int ab = objDaorder.SuppCusCurrency(formCon, Convert.ToInt32(txtsupplierID.Text));
            //    cmbCurrency.SelectedValue = ab;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("There is an error to load Currency"+ex);
            //}
        }

        private void txtSupplier_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void cmbCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

       
    }
}
