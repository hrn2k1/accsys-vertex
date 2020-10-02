using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Entity;
using System.Data.SqlClient;
using Accounting.DataAccess;
using Accounting.Utility;
using CrystalDecisions.Shared;
using Accounting.Reports;

namespace Accounting.UI
{
    public partial class frmStockInOut : Form
    {
        public frmStockInOut()
        {
            InitializeComponent();
        }

        private SqlConnection formCon = null;
        private DaStockInOut objDaStock = null;
        private DataTable dtStockInOut = null;
        private DataTable dtItems = new DataTable();
        private DataTable dtCounts = new DataTable();
        private DataTable dtSizes = new DataTable();
        private DataTable dtColors = new DataTable();
        private string TransNature = "";
        private int RefID = 0;
        private void txtCustSupp_Enter(object sender, EventArgs e)
        {
            
        }

        private void cboTransType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTransType.SelectedValue == null || cboTransType.SelectedValue.GetType() == typeof(DataRowView)) return;
                string prefix = string.Empty;
                DataRow dr = ((DataRowView)cboTransType.SelectedItem).Row;
                prefix = dr.Field<string>("VoucherPrefix");
                lblPrefix.Text = prefix;
                if (cboTransType.SelectedValue.ToString() == "Damage")
                {
                    txtChalanNo.Text = "";
                    //txtCustSupp.Text = "";
                    txtCustSupp.Tag = null;
                    txtCustSupp.Enabled = false;
                    dtpChalanDate.Value = new DateTime(1900, 1, 1);
                    dtpChalanDate.Enabled = false;
                }
                else
                {
                    txtChalanNo.Text = objDaStock.getChalanNo(formCon, "CI");
                   // txtCustSupp.Enabled = true;
                    dtpChalanDate.Value = DateTime.Now;
                    dtpChalanDate.Enabled = true;
                }

                if (cboTransType.SelectedValue.ToString().Contains(" In"))
                {
                    //ctldgvItems.setColumnsVisible(false, "OutQty", "OutAmount");
                    //ctldgvItems.setColumnsVisible(true, "InQty", "InAmount");
                    //TransNature = "In";
                }
                else
                {
                    //ctldgvItems.setColumnsVisible(true, "OutQty", "OutAmount");
                    //ctldgvItems.setColumnsVisible(false, "InQty", "InAmount");
                    //TransNature = "Out";
                }

                txtVoucherNo.Text = objDaStock.getVoucherNo(formCon, prefix);
                //if (cboTransType.SelectedValue.ToString().ToLower() == "Store In for Customer".ToLower())
                if (cboTransType.SelectedValue.ToString().Contains("Customer"))
                {
                    lblCustSupp.Text = "Customer";
                    txtCustSupp.Text = "";
                    txtCustSupp.Tag = null;
                }
                else
                {
                    lblCustSupp.Text = "Supplier";
                    txtCustSupp.Text = "";
                    txtCustSupp.Tag = null;
                }

                llblSelection.Tag = dr.Field<string>("SelectionMode");
                llblSelection.Text = dr.Field<string>("SelectionMsg");
                ctldgvItems.AllowUserToAddRows = (dr.Field<string>("SelectionMode") == "I");
                //switch (cboTransType.SelectedValue.ToString().ToLower())
                //{
                //    case "store in for supplier":
                //         llblSelection.Text = "Select Purchase Order"; break;
                //    case "store in for customer":
                //        selectionMode = "SO"; llblSelection.Text = "Select Sales Order"; break;
                //    case "direct store in":
                //        selectionMode = "I"; llblSelection.Text = "Select Items"; break;
                //    case "store out":
                //        selectionMode = "R"; break;
                //    case "damage":
                //        selectionMode = "SI"; break;


                //};
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmStockInOut_Load(object sender, EventArgs e)
        {
            try
            {
               
                formCon = ConnectionHelper.getConnection();
              //  txtCustSupp.Enabled = true;
                dtpChalanDate.Enabled = true;
                objDaStock = new DaStockInOut();
                loadInOutType();
                loadStock(-1);
                cboTransType.SelectedIndex = 0;
                loadItems();
                loadCounts();
                loadSizes();
                loadColors();
                chkHitAccount.Checked = DaCompanySettings.IsInventoryWithAccounting();
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
                dtItems = new DAChartsOfItem().getItemsForGrid(formCon); // .GetItems(" WHERE CompanyID="+LogInInfo.CompanyID.ToString(), " ItemID,ItemName ", formConnection);
                ItemID.DataSource = dtItems;
                ItemID.DisplayMember = "ItemName";
                ItemID.ValueMember = "ItemID";

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
                CountID.DataSource = dtCounts;
                CountID.DisplayMember = "CountName";
                CountID.ValueMember = "CountID";
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
                SizeID.DataSource = dtSizes;
                SizeID.DisplayMember = "SizesName";
                SizeID.ValueMember = "SizesID";
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
                ColorID.DataSource = dtColors;
                ColorID.DisplayMember = "ColorsName";
                ColorID.ValueMember = "ColorsID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadStock(int stockMID)
        {
            try
            {
                Stock_InOut_Master objSM = objDaStock.getStockInOutMaster(formCon, stockMID);
                if (objSM != null)
                {
                    txtStockMID.Text = objSM.StockMID.ToString();
                    cboTransType.SelectedValue = objSM.TransType;
                    txtVoucherNo.Text = objSM.VoucherNo;
                    dtpTransDate.Value = objSM.TransDate;
                    dtpChalanDate.Value = objSM.ChalanDate;
                    txtChalanNo.Text = objSM.ChalanNo;
                    txtRemarks.Text = objSM.Remarks;
                    Ledgers oL = new DaLedger().GetLedger(formCon, objSM.CustSupplID);
                    if (oL != null)
                    {
                        txtCustSupp.Text = oL.LedgerName;
                        txtCustSupp.Tag = oL;
                    }
                    else
                    {
                        txtCustSupp.Text = string.Empty;
                        txtCustSupp.Tag = null;
                    }
                    lblRefID.Text = objSM.RefID.ToString();
                }
                else
                {
                    txtStockMID.Text = "0";
                    txtVoucherNo.Text = objDaStock.getVoucherNo(formCon, cboTransType.Tag.ToString());
                    //dtpTransDate.Value = objSM.TransDate;
                    //dtpChalanDate.Value = objSM.ChalanDate;
                    txtChalanNo.Text = objDaStock.getChalanNo(formCon, "CI");
                    txtCustSupp.Text = string.Empty;
                    txtCustSupp.Tag = null;
                    lblRefID.Text = "0";
                }
                
                addOrder(stockMID, -1, "ALL");
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadInOutType()
        {
            try
            {
                cboTransType.DataSource = new DaStockInOutType().getStockInOutType(formCon);
                cboTransType.DisplayMember = "InOutType";
                cboTransType.ValueMember = "InOutType";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtStockMID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtStockMID.Text) > 0)
                    cboTransType.Enabled = false;
                else
                    cboTransType.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvItems_Enter(object sender, EventArgs e)
        {
            //Selection();
        }

        private void Selection()
        {
            try
            {
                string selectionMode = (string)llblSelection.Tag;
                string TransNature = "";
                if (cboTransType.SelectedValue.ToString().Contains(" In"))
                    TransNature = "In";
                else
                    TransNature = "Out";
                if (selectionMode == "PO")
                {
                    frmSearchOrder frm = new frmSearchOrder();
                    frm.ShowDialog((txtCustSupp.Tag == null ? -1 : ((Ledgers)txtCustSupp.Tag).LedgerID), "Purchase Order", false);
                    if (frm.OrderIDs == null) return;
                    addOrder(-1, Convert.ToInt32(frm.OrderIDs[0]), TransNature /*"Out"*/);
                }
                else if (selectionMode == "SO")
                {
                    frmSearchOrder frm = new frmSearchOrder();
                    frm.ShowDialog((txtCustSupp.Tag == null ? -1 : ((Ledgers)txtCustSupp.Tag).LedgerID), "Sales Order", false);
                    if (frm.OrderIDs == null) return;
                    if (lblPrefix.Text.Trim() == "II")
                        addOrderCustomerIn(-1, Convert.ToInt32(frm.OrderIDs[0]), TransNature /*"In"*/);
                    else if(lblPrefix.Text.Trim() == "IO")
                        addOrderCustomerOut(-1, Convert.ToInt32(frm.OrderIDs[0]), TransNature /*"In"*/);
                }
                else if (selectionMode == "I")
                {
                    frmItemSearch frm = new frmItemSearch();
                    frm.ShowDialog();
                    string ItemList = frm.ItemList;
                    if (ItemList == "") return;
                    addItem(ItemList);
                    ctldgvItems.AllowUserToAddRows = true;
                }
                else if (selectionMode == "R")
                {
                    frmFindRequisition frm = new frmFindRequisition();
                    frm.ShowDialog();
                    ReqMaster obreqMaster = new ReqMaster();
                    obreqMaster = frm.obReqMaster;
                    if (obreqMaster == null) return;
                    addReq(obreqMaster.ReqMID);
                }
                else if (selectionMode == "SI")
                {
                    //Stock_InOut_Master obIOM = new Stock_InOut_Master();
                    //frmFindStockInOut frm = new frmFindStockInOut();
                    //frm.ShowDialog();

                    //obIOM = frm.obInOutMaster;
                    //if (obIOM == null) return;
                    //addStockIO(obIOM.StockMID);
                    ////loadStock(obIOM.StockMID);
                    ////loadInOutType();
                    ////txtStockMID.Text = "0";
                    ////txtRemarks.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured due to " + ex.Message);
            }
            
            
        }
        private void addStockIO(int StockMID)
        {
            try
            {
                RefID = StockMID;
                dtStockInOut = new DataTable();
                dtStockInOut = objDaStock.getStockItems(formCon, StockMID);
                ctldgvItems.DataSource = dtStockInOut;
                ctldgvItems.setColumnsVisible(false, "StockDID", "StockMID", "ItemID", "ShadeNo", "TransNature", "ShortQty", "GroupName");
                ctldgvItems.setColumnsReadOnly(true, "ItemName", "SizesName", "ColorsName", "CountName", "UnitsName", "InAmount", "OutAmount");
                ctldgvItems.setColumnsFormat(new string[] { "UnitPrice" }, "0.00");

                ctldgvItems.setColumnsVisible(false, "InQty", "InAmount");
                ctldgvItems.setColumnsReadOnly(false, "OutQty");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void addItem(string Items)
        {
            try
            {
                string where = " WHERE ItemID IN " + Items;
                string Cols = "ItemID,UnitsName AS Unit,0.00 AS UnitPrice ";
                DataTable dt = new DAChartsOfItem().GetItemsWithPrice(where, dtpTransDate.Value.Date, Cols, formCon);

                //string where = " WHERE ItemID IN " + Items;
                //string Cols = "ItemID,ItemName,SizesName,ColorsName,ShadeNo,CountName,UnitsName,GroupName,dbo.fnGetPriceOfTime(-1,ItemID,@priceDate) AS UnitPrice";
                //DateTime dtPriceDate=dtpTransDate.Value.Date;
                //DataTable dt = new DAChartsOfItem().GetItemsWithPrice(where, dtPriceDate, Cols, formCon);
                lblRefID.Text = "0";
                int i, nR = dt.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    ctldgvItems.Rows.Add(0,  "In", dt.Rows[i].Field<object>("ItemID"), null,
                                              null, null,
                                              null, null,null, null, null,dt.Rows[i].Field<object>("Unit"),null,null,null );

                }
                ctldgvItems.Columns["Qty"].HeaderText = "In/Out Qty";
                ctldgvItems.Columns["OrderQty"].HeaderText = "Order Qty";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void addOrder(int StockMID,int OrderMID,string Nature)
        {
            try
            {
                DaStockInOut objSIO = new DaStockInOut();
                DataTable dt = objSIO.getOrderOrStockItems(formCon, StockMID, OrderMID, Nature); // new DaOrder().getOrderItems(formCon, OrderMID);
                lblRefID.Text =dt.Rows.Count ==0?"0":GlobalFunctions.isNull( dt.Rows[0].Field<object>("OrderID"),"0");
                int i, nR = dt.Rows.Count;
                ctldgvItems.Rows.Clear();
                for (i = 0; i < nR; i++)
                {
                    ctldgvItems.Rows.Add(dt.Rows[i].Field<object>("StockDID"), dt.Rows[i].Field<object>("TransNature"), dt.Rows[i].Field<object>("ItemID"),
                        dt.Rows[i].Field<object>("CountID"), dt.Rows[i].Field<object>("SizeID"),
                        dt.Rows[i].Field<object>("ColorID"), dt.Rows[i].Field<object>("Specifications"),
                        dt.Rows[i].Field<object>("Budle_Pack_Size"), dt.Rows[i].Field<object>("Qty"), dt.Rows[i].Field<object>("AvailQty"), dt.Rows[i].Field<object>("AvailQty"),
                        dt.Rows[i].Field<object>("Unit"), dt.Rows[i].Field<object>("UnitPrice"), GlobalFunctions.isNull(dt.Rows[i].Field<object>("AvailQty"), 0) * GlobalFunctions.isNull(dt.Rows[i].Field<object>("UnitPrice"), 0) /* dt.Rows[i].Field<object>("Amount")*/, dt.Rows[i].Field<object>("Budle_Pack_Qty"));
                   
                }
                if (dt != null&&dt.Rows.Count>0)
                {
                    int _ledgerID = Convert.ToInt32(dt.Rows[0]["LedgerID"]);
                    if (_ledgerID != 0)
                    {
                        Ledgers objL = new DaLedger().GetLedger(formCon, _ledgerID);
                        txtCustSupp.Text = objL.LedgerName;
                        txtCustSupp.Tag = objL;
                    }
                }
                ctldgvItems.Columns["Qty"].HeaderText = "In/Out Qty";
                ctldgvItems.Columns["OrderQty"].HeaderText = "Order Qty";

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }
        private void addOrderCustomerIn(int StockMID, int OrderMID, string Nature)
        {
            try
            {
                DaStockInOut objSIO = new DaStockInOut();
                DataTable dt = objSIO.getOrderOrStockItems4CustomerIn(formCon, StockMID, OrderMID, Nature); // new DaOrder().getOrderItems(formCon, OrderMID);
                lblRefID.Text = dt.Rows.Count == 0 ? "0" : GlobalFunctions.isNull(dt.Rows[0].Field<object>("OrderID"), "0");
                int i, nR = dt.Rows.Count;
                ctldgvItems.Rows.Clear();
                for (i = 0; i < nR; i++)
                {
                    ctldgvItems.Rows.Add(dt.Rows[i].Field<object>("StockDID"), dt.Rows[i].Field<object>("TransNature"), dt.Rows[i].Field<object>("ItemID"),
                        dt.Rows[i].Field<object>("CountID"), dt.Rows[i].Field<object>("SizeID"),
                        dt.Rows[i].Field<object>("ColorID"), dt.Rows[i].Field<object>("Specifications"),
                        dt.Rows[i].Field<object>("Budle_Pack_Size"), dt.Rows[i].Field<object>("Qty"), dt.Rows[i].Field<object>("AvailInQty"), dt.Rows[i].Field<object>("AvailInQty"),
                        dt.Rows[i].Field<object>("Unit"), dt.Rows[i].Field<object>("UnitPrice"), GlobalFunctions.isNull(dt.Rows[i].Field<object>("AvailInQty"), 0) * GlobalFunctions.isNull(dt.Rows[i].Field<object>("UnitPrice"), 0) /* dt.Rows[i].Field<object>("Amount")*/, dt.Rows[i].Field<object>("Budle_Pack_Qty"));

                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    int _ledgerID = Convert.ToInt32(dt.Rows[0]["LedgerID"]);
                    if (_ledgerID != 0)
                    {
                        Ledgers objL = new DaLedger().GetLedger(formCon, _ledgerID);
                        txtCustSupp.Text = objL.LedgerName;
                        txtCustSupp.Tag = objL;
                    }
                }
                ctldgvItems.Columns["Qty"].HeaderText = "In Qty";
                ctldgvItems.Columns["OrderQty"].HeaderText = "Order Qty";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void addOrderCustomerOut(int StockMID, int OrderMID, string Nature)
        {
            try
            {
                DaStockInOut objSIO = new DaStockInOut();
                DataTable dt = objSIO.getOrderOrStockItems4CustomerOut(formCon, StockMID, OrderMID, Nature); // new DaOrder().getOrderItems(formCon, OrderMID);
                lblRefID.Text = dt.Rows.Count == 0 ? "0" : GlobalFunctions.isNull(dt.Rows[0].Field<object>("OrderID"), "0");
                int i, nR = dt.Rows.Count;
                ctldgvItems.Rows.Clear();
                for (i = 0; i < nR; i++)
                {
                    ctldgvItems.Rows.Add(dt.Rows[i].Field<object>("StockDID"), dt.Rows[i].Field<object>("TransNature"), dt.Rows[i].Field<object>("ItemID"),
                        dt.Rows[i].Field<object>("CountID"), dt.Rows[i].Field<object>("SizeID"),
                        dt.Rows[i].Field<object>("ColorID"), dt.Rows[i].Field<object>("Specifications"),
                        dt.Rows[i].Field<object>("Budle_Pack_Size"), dt.Rows[i].Field<object>("CurrentInQty"), dt.Rows[i].Field<object>("AvailOutQty"), dt.Rows[i].Field<object>("AvailOutQty"),
                        dt.Rows[i].Field<object>("Unit"), dt.Rows[i].Field<object>("UnitPrice"), GlobalFunctions.isNull(dt.Rows[i].Field<object>("AvailOutQty"), 0) * GlobalFunctions.isNull(dt.Rows[i].Field<object>("UnitPrice"), 0) /* dt.Rows[i].Field<object>("Amount")*/, dt.Rows[i].Field<object>("Budle_Pack_Qty"));

                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    int _ledgerID = Convert.ToInt32(dt.Rows[0]["LedgerID"]);
                    if (_ledgerID != 0)
                    {
                        Ledgers objL = new DaLedger().GetLedger(formCon, _ledgerID);
                        txtCustSupp.Text = objL.LedgerName;
                        txtCustSupp.Tag = objL;
                    }
                }
                ctldgvItems.Columns["Qty"].HeaderText = "Out Qty";
                ctldgvItems.Columns["OrderQty"].HeaderText = "In Qty";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        private void addReq(int ReqMID)
        {
            try
            {
                DaInventoryRequisition obDaReq = new DaInventoryRequisition();
                DataTable dt = new DataTable();
                dt = obDaReq.loadReqDetail(formCon, ReqMID);
                lblRefID.Text = dt.Rows.Count == 0 ? "0" : dt.Rows[0].Field<object>("ReqMID").ToString();
                int i, nR = dt.Rows.Count;
                ctldgvItems.Rows.Clear();
                for (i = 0; i < nR; i++)
                {
                    ctldgvItems.Rows.Add(0, "Out", dt.Rows[i].Field<object>("ItemID"),
                       dt.Rows[i].Field<object>("CountID"), dt.Rows[i].Field<object>("SizeID"), dt.Rows[i].Field<object>("ColorID"), dt.Rows[i].Field<object>("Specifications"),
                       dt.Rows[i].Field<object>("Budle_Pack_Size"), null, dt.Rows[i].Field<object>("ReqQty"), dt.Rows[i].Field<object>("ReqQty"), dt.Rows[i].Field<object>("Unit"),
                        null, null, dt.Rows[i].Field<object>("Budle_Pack_Qty"));
                   
                }
                ctldgvItems.Columns["Qty"].HeaderText = "In/Out Qty";
                ctldgvItems.Columns["OrderQty"].HeaderText = "Order Qty";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void llblSelection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Selection();
            ctldgvItems.Columns[ColAvailQty.Name].Visible = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            frmStockInOut_Load(null, null);
            //loadInOutType();
            //loadStock(-1);
        }

        private void ctldgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (ctldgvItems.Columns[ctldgvItems.CurrentCell.ColumnIndex].CellType.Name != "DataGridViewComboBoxCell")
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
            //frmStockInOut_Load(null, null);
            Stock_InOut_Master obIOM = new Stock_InOut_Master();
            frmFindStockInOut frm = new frmFindStockInOut();
            frm.ShowDialog();
            
                obIOM = frm.obInOutMaster;
                if (obIOM == null || obIOM.StockMID <=0) return;
                loadStock(obIOM.StockMID);
                cboTransType.SelectedValue = obIOM.TransType;
                ctldgvItems.Columns[ColAvailQty.Name].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured due to " + ex.Message);
            }

        }
        private bool validation()
        {
            try
            {
                //if (cboTransType.SelectedValue.ToString() != "Damage")
                //{
                //    if (txtCustSupp.Text == "")
                //    {
                //        MessageBox.Show("Please select customer or supplier");
                //        return false;
                //    }
                //}
                if (ctldgvItems.Rows.Count == 0)
                {
                    MessageBox.Show("Empty Item" + Environment.NewLine + "Please Select Item");
                    return false;
                }
                int i, nR;
                nR = ctldgvItems.Rows.Count - (ctldgvItems.AllowUserToAddRows ? 1 : 0);
                for (i = 0; i < nR; i++)
                {
                    if (GlobalFunctions.isNull(ctldgvItems[Qty.Name, i].Value, 0.0) > GlobalFunctions.isNull(ctldgvItems[ColAvailQty.Name, i].Value, 0.0))
                    {
                        MessageBox.Show("In/Out Quantity exceeds avaiable quantity");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation() == false)
                return;
            SqlTransaction trans=null;
            int StockID = 0;
            Stock_InOut_Detail obStockInOutDetail = new Stock_InOut_Detail();
            Stock_InOut_Master obStockInOutMaster = new Stock_InOut_Master();
            objDaStock = new DaStockInOut();
            try
            {
                if (formCon.State != ConnectionState.Open)
                    formCon.Open();
                trans=formCon.BeginTransaction();

                //Stock Master Save Update
                obStockInOutMaster = createInOutMaster();
                StockID = objDaStock.SaveUpdateStockInOutMaster(obStockInOutMaster, formCon, trans);

                //Stock detail Save Update
                objDaStock.DeleteStockInOutDetail(formCon, trans, StockID);
                int i, nR = ctldgvItems.Rows.Count;
                if (ctldgvItems.AllowUserToAddRows == true) nR = nR - 1;

                if (cboTransType.SelectedValue.ToString().Contains(" In"))
                    TransNature = "In";
                else
                    TransNature = "Out";

                for (i = 0; i < nR; i++)
                {
                    obStockInOutDetail = createInOutdetail(StockID, i, TransNature);
                    objDaStock.SaveUpdateStockInOutDetail(obStockInOutDetail, formCon, trans);
                }

                if (chkHitAccount.Checked)
                    objDaStock.UpdateRawMaterialAndFinishGoodsAccountBalance(formCon, trans);
                trans.Commit();
               
                frmStockInOut_Load(null, null);
                MessageBox.Show("Save Successfull");
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                MessageBox.Show("Error occured due to " + ex.Message);
            }
        }
        private Stock_InOut_Master createInOutMaster()
        {
            Stock_InOut_Master obIOMaster = new Stock_InOut_Master();
            try
            {
                obIOMaster.StockMID = Convert.ToInt32(txtStockMID.Text);
                obIOMaster.TransType = cboTransType.SelectedValue.ToString();
                obIOMaster.TransDate = dtpTransDate.Value.Date;
                obIOMaster.ChalanDate = dtpChalanDate.Value.Date;
                obIOMaster.VoucherNo = txtVoucherNo.Text;
                obIOMaster.ChalanNo = txtChalanNo.Text;
                if (txtCustSupp.Tag == null)
                    obIOMaster.CustSupplID = 0;
                else
                obIOMaster.CustSupplID = ((Ledgers)txtCustSupp.Tag).LedgerID;
                obIOMaster.RefID = Convert.ToInt32(lblRefID.Text);
                obIOMaster.Remarks = txtRemarks.Text;
                obIOMaster.Module = "Stock InOut";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obIOMaster;
        }
        private Stock_InOut_Detail createInOutdetail(int StockMID, int rowID, string TNature)
        {
            Stock_InOut_Detail obIODetail = new Stock_InOut_Detail();
            try
            {
                obIODetail.StockDID = 0;// GlobalFunctions.isNull(ctldgvItems["StockDID", rowID].Value, 0);
                obIODetail.StockMID = StockMID;
                obIODetail.TransNature = TNature;
                obIODetail.ItemID = Convert.ToInt32(ctldgvItems.Rows[rowID].Cells["ItemID"].Value);

                if (TNature == "In")
                {
                    obIODetail.InQty = GlobalFunctions.isNull(ctldgvItems["Qty", rowID].Value,0.0);
                    obIODetail.InAmount = GlobalFunctions.isNull(ctldgvItems["Amount", rowID].Value, 0.0);
                    obIODetail.OutQty = 0.0;
                    obIODetail.OutAmount = 0.0;
                }
                else
                {
                    obIODetail.InQty = 0.0;
                    obIODetail.InAmount = 0.0;
                    obIODetail.OutQty = GlobalFunctions.isNull(ctldgvItems["Qty", rowID].Value, 0.0);
                    obIODetail.OutAmount = GlobalFunctions.isNull(ctldgvItems["Amount", rowID].Value, 0.0);
                }
                obIODetail.UnitPrice = GlobalFunctions.isNull(ctldgvItems["UnitPrice", rowID].Value, 0.0);

                //obIODetail.Budle_Pack_Qty = GlobalFunctions.isNull(ctldgvItems.Rows[rowID].Cells["Budle_Pack_Qty"].Value, "");

                 obIODetail.ShortQty = 0;
                
                obIODetail.Specifications = GlobalFunctions.isNull( ctldgvItems["Specifications",rowID].Value,"");
                obIODetail.Budle_Pack_Size = GlobalFunctions.isNull(ctldgvItems["Budle_Pack_Size", rowID].Value, "");
                obIODetail.Budle_Pack_Qty = GlobalFunctions.isNull(ctldgvItems["Budle_Pack_Qty", rowID].Value, "");
                obIODetail.CountID = GlobalFunctions.isNull(ctldgvItems["CountID", rowID].Value, 0);
                obIODetail.SizeID = GlobalFunctions.isNull(ctldgvItems["SizeID", rowID].Value, 0);
                obIODetail.ColorID = GlobalFunctions.isNull(ctldgvItems["ColorID", rowID].Value, 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obIODetail;
        }

        private void ctldgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
                
                 if (ctldgvItems.Columns[e.ColumnIndex].Name==Qty.Name || ctldgvItems.Columns[e.ColumnIndex].Name==UnitPrice.Name)
                 {
                     ctldgvItems[Amount.Name,e.RowIndex].Value = GlobalFunctions.isNull(ctldgvItems[Qty.Name,e.RowIndex].Value,0.0)* GlobalFunctions.isNull(ctldgvItems[UnitPrice.Name,e.RowIndex].Value,0.0);
                 }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured due to " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DaStockInOut obDaInOut = new DaStockInOut();
            int StockMID = Convert.ToInt32(txtStockMID.Text);
            if (StockMID == 0)
            {
                MessageBox.Show("please select An Store InOut for Delete");
                return;
            }
            if (MessageBox.Show("Are you sure to delete Store I/O ", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            SqlTransaction trans = null;
            try
            {
                if (formCon.State != ConnectionState.Open)
                    formCon.Open();
                trans = formCon.BeginTransaction();
                obDaInOut.DeleteStockInOut(formCon,trans, StockMID);

                if (chkHitAccount.Checked)
                    objDaStock.UpdateRawMaterialAndFinishGoodsAccountBalance(formCon, trans);
                trans.Commit();
               
                frmStockInOut_Load(null, null);
                MessageBox.Show("Delete Successfull");
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show("Unable to Delete StockInOut " + ex.Message);
            }

        }

        private void frmStockInOut_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formCon);
        }

        private void frmStockInOut_Paint(object sender, PaintEventArgs e)
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

        private void ctldgvItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (ctldgvItems.Columns[e.ColumnIndex].CellType.Name == "DataGridViewComboBoxCell" )
                SendKeys.Send("{F4}");
        }

        private void cboTransType_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void cboTransType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void dtpTransDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void dtpChalanDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtCustSupp_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (lblCustSupp.Text == "Customer")
                    {
                        frmCustomer frmC = new frmCustomer();
                        frmC.ShowDialog();
                        Ledgers objCust = frmC.objCustomer;
                        if (objCust == null) return;
                        txtCustSupp.Text = objCust.LedgerName;
                        txtCustSupp.Tag = objCust;
                    }
                    else
                    {
                        frmSupplierSearch frmS = new frmSupplierSearch();
                        frmS.ShowDialog();
                        Ledgers objSupp = frmS.SelectedSupplier;
                        if (objSupp == null) return;
                        txtCustSupp.Text = objSupp.LedgerName;
                        txtCustSupp.Tag = objSupp;
                    }
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtChalanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void ctldgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
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
                int SID = Convert.ToInt32(txtStockMID.Text);
                if (SID <= 0 || !(cboTransType.Text.Contains("Store Out For Customer"))) return;
                rptSalesDeliveryChalanStock rptSalesDeliveryS = new rptSalesDeliveryChalanStock();

                pdv.Value = Convert.ToInt32(txtStockMID.Text);
                pvc.Add(pdv);
                rptSalesDeliveryS.DataDefinition.ParameterFields["@StockMID"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptSalesDeliveryS.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptSalesDeliveryS, false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvItems_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {
            bool f=ctldgvItems.AllowUserToAddRows;
            ItemID.ReadOnly = !f;
            CountID.ReadOnly = !f;
            SizeID.ReadOnly = !f;
            ColorID.ReadOnly = !f;
            Specifications.ReadOnly = !f;
            Budle_Pack_Size.ReadOnly = !f;

        }

        private void lblRefID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int rID=Convert.ToInt32(lblRefID.Text);
                if (rID <= 0) lblOrderNo.Text = string.Empty;
                else
                {
                    if (llblSelection.Tag == null) lblOrderNo.Text = string.Empty;
                    else if (llblSelection.Tag.ToString() == "R") lblOrderNo.Text = "Req No. : " + new DaInventoryRequisition().getReqMID(formCon, rID).ReqNo;
                    else lblOrderNo.Text = "Order Ref No. : " + new DaOrder().GetOrder_Master(formCon, rID).OrderNo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
