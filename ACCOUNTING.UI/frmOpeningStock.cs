using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Utility;
using System.Data.SqlClient;
using Accounting.DataAccess;
using Accounting.Entity;

namespace Accounting.UI
{
    public partial class frmOpeningStock : Form
    {
        DaCounts obDaCounts = new DaCounts();
        DaSizes obDaSize = new DaSizes();
        Dacolors obDacolor = new Dacolors();

        private DataTable dtCounts = new DataTable();
        private DataTable dtSizes = new DataTable();
        private DataTable dtColors = new DataTable();
        private DataTable dtItems = new DataTable();

        private DaOpeningStock objDaOpStk = null;
        private SqlConnection formCon = null;

        public frmOpeningStock()
        {
            InitializeComponent();
        }

        private void frmOpeningStock_Load(object sender, EventArgs e)
        {
            try
            {
                formCon = ConnectionHelper.getConnection();
                objDaOpStk = new DaOpeningStock();
                loadOpenings(-1, "NULL");
                loadCurrency();
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
        private void loadCurrency()
        {
            try
            {
                DataTable dtt = new DataTable();
                DaOrder objDAorder = new DaOrder();
                dtt = objDAorder.LoadCurrency(formCon);
                cboCurrency.DataSource = dtt;
                cboCurrency.DisplayMember = "Code";
                cboCurrency.ValueMember = "CurrencyID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error to load currency" + ex);
            }
        }

        private void loadItems()
        {
            DataTable Items = new DataTable();
            try
            {
                Items = new DAChartsOfItem().getItemsForGrid(formCon);
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
            try
            {
                dtCounts = new DaCounts().getCountsForGrid(formCon);
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
            try
            {
                dtSizes = new DaSizes().getSizesForGrid(formCon);
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
            try
            {
                dtColors = new Dacolors().getColorsForGrid(formCon);
                ColColorID.DataSource = dtColors;
                ColColorID.DisplayMember = "ColorsName";
                ColColorID.ValueMember = "ColorsID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtCustomer_DoubleClicked(object sender, EventArgs e)
        {
            //frmSearchCustomer frm = new frmSearchCustomer();
            frmCustomer frm = new frmCustomer();
            frm.ShowDialog();
            Ledgers obCus;
            try
            {
                obCus = frm.objCustomer;
                if (obCus == null) return;
                txtCustomer.Text = obCus.LedgerName;
                txtCustomerID.Text = obCus.LedgerID.ToString();
                cboCurrency.SelectedValue = obCus.CurrencyID;
                loadOpenings(obCus.LedgerID, "NULL");
                CalculateItemValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Find customer " + ex.Message);
            }
        }

        private void loadOpenings(int CustomerID, string Items)
        {
            try
            {
                if (ctldgvItems.Rows.Count > 1) ctldgvItems.Rows.Clear();
                int i, nR;
                dtItems = objDaOpStk.getOpeningStock(formCon, CustomerID, Items, "Load");
                //ctldgvItems.DataSource = dtItems;
                nR = dtItems.Rows.Count;

                
                for (i = 0; i < nR; i++)
                {
                    ctldgvItems.Rows.Add(new object[] { 
                        dtItems.Rows[i].Field<object>("OpeningStockID"),dtItems.Rows[i].Field<object>("ItemID"),
                        dtItems.Rows[i].Field<object>("CountID"),dtItems.Rows[i].Field<object>("SizeID"),
                        dtItems.Rows[i].Field<object>("ColorID"),dtItems.Rows[i].Field<object>("Specifications"),
                        dtItems.Rows[i].Field<object>("Budle_Pack_Size"),dtItems.Rows[i].Field<object>("OpeningQty"),
                        dtItems.Rows[i].Field<object>("UnitID"),dtItems.Rows[i].Field<object>("Unit"),
                        dtItems.Rows[i].Field<object>("UnitPrice"),dtItems.Rows[i].Field<object>("OpeningAmount"),
                        dtItems.Rows[i].Field<object>("Budle_Pack_Qty")
                    
                    });
                }

               
                //dtItems.Columns["ItemID"].Unique = true;
                if (dtItems.Rows.Count != 0)
                {

                    numDollorRate.Value = GlobalFunctions.isNull(dtItems.Rows[0].Field<object>("DollorRate"), 1); // Convert.ToDouble(dtItems.Rows[0].Field<object>("DollorRate"));
                    dtpOpeningDate.Value = GlobalFunctions.isNull(dtItems.Rows[0].Field<object>("Openingdate"), DateTime.Now);
                    cboCurrency.SelectedValue = GlobalFunctions.isNull(dtItems.Rows[0].Field<object>("CurrencyID"), 0);
                }
                else
                    numDollorRate.Value = 1;
                /*
                //ctldgvItems.setColumnsVisible(false, "OpeningStockID", "ItemID", "Shade", "UnitID", "OpeningDate", "DollorRate");
                //ctldgvItems.setColumnsReadOnly(true, "ItemName", "Size", "Color", "Shade", "Count", "Unit", "OpeningAmount");
                ctldgvItems.setColumnsFormat(new string[] { "OpeningQty", "UnitPrice", "OpeningAmount" }, "0.00", "0.00", "0.00");
                ctldgvItems.Columns["OpeningQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctldgvItems.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctldgvItems.Columns["OpeningAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //ctldgvItems.setColumnsWidth(new string[] { "ItemName", "Size", "Color", "Count", "Unit", "OpeningQty", "UnitPrice", "OpeningAmount" }, 140, 60, 60, 60, 60, 60, 90, 90, 90);
                 * */
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void frmOpeningStock_Paint(object sender, PaintEventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void cboFiscalYear_SelectedValueChanged(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        if (cboFiscalYear.SelectedValue == null || cboFiscalYear.SelectedValue.GetType() == typeof(DataRowView) || cboFiscalYear.Items.Count == 0)
        //            return;
        //        loadOpenings((int)cboFiscalYear.SelectedValue, "NULL");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void ctldgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == -1) return;
               
                if (ctldgvItems.Columns[e.ColumnIndex].Name == "ItemName")
                {
                    frmItemSearch frm = new frmItemSearch();
                    frm.ShowDialog();
                    string items = frm.ItemList;
                    if (items == string.Empty) return;
                    //(int)cboFiscalYear.SelectedValue, 
                    addItems(items);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addItems(string Items)
        {
            try
            {
                

                DataTable dt = objDaOpStk.getOpeningStock(formCon, -1, Items, "Select");
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ctldgvItems.Rows.Add(new object[]{ dt.Rows[i].Field<object>("OpeningStockID"),
                            dt.Rows[i].Field<object>("ItemID"), null, null, null, null, null,
                            dt.Rows[i].Field<object>("OpeningQty"), dt.Rows[i].Field<object>("UnitID"),
                            dt.Rows[i].Field<object>("Unit"), dt.Rows[i].Field<object>("UnitPrice"),
                            dt.Rows[i].Field<object>("OpeningAmount"), dt.Rows[i].Field<object>("OpeningDate")
                        });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ctldgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (ctldgvItems.Columns[ctldgvItems.CurrentCell.ColumnIndex].CellType.Name == "DataGridViewComboBoxCell")
                SendKeys.Send("{F4}");
            else
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void ctldgvItems_Enter(object sender, EventArgs e)
        {

        }

        private void ctldgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex == -1)
                    return;
                if (ctldgvItems.Columns[e.ColumnIndex].Name.ToLower() == "colopeningqty" || ctldgvItems.Columns[e.ColumnIndex].Name.ToLower() == "colunitprice")
                {
                    ctldgvItems.Rows[e.RowIndex].Cells["ColOpeningAmount"].Value = Convert.ToDouble(ctldgvItems.Rows[e.RowIndex].Cells["ColOpeningQty"].Value == DBNull.Value ? 0 : ctldgvItems.Rows[e.RowIndex].Cells["ColOpeningQty"].Value) * Convert.ToDouble(ctldgvItems.Rows[e.RowIndex].Cells["ColUnitPrice"].Value == DBNull.Value ? 0.0 : ctldgvItems.Rows[e.RowIndex].Cells["ColUnitPrice"].Value);
                    CalculateItemValue();
                }
                if (ctldgvItems.Columns[e.ColumnIndex].Name == ColItemID.Name)
                    ctldgvItems[ColUnit.Name, e.RowIndex].Value = new DAChartsOfItem().getUnitOfItem(formCon, GlobalFunctions.isNull(ctldgvItems[ColItemID.Name, e.RowIndex].Value, 0));
                //if (ctldgvItems.Columns[e.ColumnIndex].Name.ToLower() == "colopeningqty")
                //{
                //    CalculateItemValue();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CalculateItemValue()
        {
            DaOpeningStock obDaOpnStk = new DaOpeningStock();
            double RawMaterials = 0, FinishGoods = 0;
            try
            {
                int i, nR = ctldgvItems.Rows.Count;
                if (nR <= 1) return;
                for (i = 0; i < nR - 1; i++)
                {
                    if (obDaOpnStk.getItemCategory(formCon, GlobalFunctions.isNull(ctldgvItems[ColItemID.Name, i].Value, 0)) == "Finished Good")
                    {
                        FinishGoods += GlobalFunctions.isNull(ctldgvItems[ColOpeningAmount.Name, i].Value, 0.0);
                    }
                    else
                        RawMaterials += GlobalFunctions.isNull(ctldgvItems[ColOpeningAmount.Name, i].Value, 0.0);
                }
                ctlNumFinishGoods.Value = FinishGoods * numDollorRate.Value;
                ctlNumRawMaterials.Value = RawMaterials * numDollorRate.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private bool validation()
        {
            try
            {
                if (txtCustomer.Text.Trim() == "")
                {
                    MessageBox.Show("Please Select a customer");
                    return false;
                }
                if (ctldgvItems.Rows.Count == 0)
                {
                    MessageBox.Show("Empty ItemList " + Environment.NewLine + "Please Add Items ");
                    return false;
                }
                //if (txtRawAccount.Tag == null)
                //{
                //    MessageBox.Show("Please select an Account For Raw Materials");
                //    return false;
                //}
                //if (txtFinishedAccount.Tag == null)
                //{
                //    MessageBox.Show("Please select an Account For Finished Goods");
                //    return false;
                //}
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
            OpeningStock obOpStk = new OpeningStock();
            DaAccount obDaAcc = new DaAccount();
            Account obAcc = new Account();
            SqlTransaction trans = null;
            try
            {
                if (formCon.State != ConnectionState.Open)
                    formCon.Open();
                trans = formCon.BeginTransaction();
                int i, nR = ctldgvItems.Rows.Count;
                int OpnID, ItmID, CountId, SizeId, ColorId;
                double UnitP, OpnAmt, Opnqty;
                string Specifications, Budle_Pack_Size, Budle_Pack_Qty;
                for (i = 0; i < nR - 1; i++)
                {
                    if (ctldgvItems.Rows[i].Cells["ColOpeningQty"].Value == DBNull.Value
                        || ctldgvItems.Rows[i].Cells["ColOpeningQty"].Value == null
                        || ctldgvItems.Rows[i].Cells["ColUnitPrice"].Value == DBNull.Value
                        || ctldgvItems.Rows[i].Cells["ColUnitPrice"].Value == null)
                    {
                        MessageBox.Show("Please check Opening Quantity and Unitprice");
                        return;
                    }
                }
                for (i = 0; i < nR - 1; i++)
                {
                    if (ctldgvItems.Rows[i].Cells["ColOpeningStockID"].Value == null || ctldgvItems.Rows[i].Cells["ColOpeningStockID"].Value == DBNull.Value)
                        OpnID = 0;
                    else
                        OpnID = Convert.ToInt32(ctldgvItems.Rows[i].Cells["ColOpeningStockID"].Value);
                    ItmID = Convert.ToInt32(ctldgvItems.Rows[i].Cells["ColItemID"].Value);
                    Opnqty = Convert.ToDouble(ctldgvItems.Rows[i].Cells["ColOpeningQty"].Value);
                    //UnitId = Convert.ToInt32(ctldgvItems.Rows[i].Cells["UnitID"].Value);
                    UnitP = Convert.ToDouble(ctldgvItems.Rows[i].Cells["ColUnitPrice"].Value);
                    OpnAmt = Convert.ToDouble(ctldgvItems.Rows[i].Cells["ColOpeningAmount"].Value);
                    Specifications = GlobalFunctions.isNull( ctldgvItems.Rows[i].Cells["Specifications"].Value,"");
                    Budle_Pack_Size = GlobalFunctions.isNull( ctldgvItems.Rows[i].Cells["ColLabdip"].Value,"");
                    Budle_Pack_Qty =GlobalFunctions.isNull( ctldgvItems.Rows[i].Cells["ColRemarks"].Value,"");
                    CountId = ctldgvItems.Rows[i].Cells["ColCountID"].Value == DBNull.Value || ctldgvItems.Rows[i].Cells["ColCountID"].Value == null ? 0 : Convert.ToInt32(ctldgvItems.Rows[i].Cells["ColCountID"].Value);
                    SizeId = ctldgvItems.Rows[i].Cells["ColSizeID"].Value == DBNull.Value || ctldgvItems.Rows[i].Cells["ColSizeID"].Value == null ? 0 : Convert.ToInt32(ctldgvItems.Rows[i].Cells["ColSizeID"].Value);
                    ColorId = ctldgvItems.Rows[i].Cells["ColColorID"].Value == DBNull.Value || ctldgvItems.Rows[i].Cells["ColColorID"].Value == null ? 0 : Convert.ToInt32(ctldgvItems.Rows[i].Cells["ColColorID"].Value);


                    obOpStk = createOpnStock(OpnID, ItmID, CountId, SizeId, ColorId, Opnqty, UnitP, OpnAmt, Specifications, Budle_Pack_Size, Budle_Pack_Qty);
                    objDaOpStk = new DaOpeningStock();
                    objDaOpStk.SaveUpdateOpenningStock(obOpStk, formCon, trans);

                    //resetForm();
                }


                //----------Save Opening Account ------------\\\
               /* obAcc = (Account)txtFinishedAccount.Tag;
                obAcc.OpeningBalance = ctlNumFinishGoods.Value;
                obDaAcc.InsertUpdateAccount(obAcc, formCon, trans);

                obAcc = (Account)txtRawAccount.Tag;
                obAcc.OpeningBalance = ctlNumRawMaterials.Value;
                obDaAcc.InsertUpdateAccount(obAcc, formCon, trans);
                */
                if (chkHitAccount.Checked)
                    new DaStockInOut().UpdateRawMaterialAndFinishGoodsAccountBalance(formCon, trans);
                trans.Commit();
                MessageBox.Show("Save Successfull");
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                MessageBox.Show("Unable to Save " + ex.Message);
            }
        }

        private OpeningStock createOpnStock(int OpenID, int ItemID, int CountID, int SizeID, int ColorID, double OpnQty, double UnitP, double OpnAmt, string Specifications, string Budle_Pack_Size, string Budle_Pack_Qty)
        {
            OpeningStock obOpStk = new OpeningStock();
            double DRate = numDollorRate.Value;
            try
            {
                obOpStk.OpeningID = OpenID;
                obOpStk.CustomerID = Convert.ToInt32(txtCustomerID.Text);
                obOpStk.ItemID = ItemID;
                obOpStk.OpeningQuantity = OpnQty;
                obOpStk.UnitID = 0;
                obOpStk.UnitPrice = UnitP * DRate;
                obOpStk.OpeningAmount = OpnAmt * DRate;
                obOpStk.OpeningDate = dtpOpeningDate.Value.Date;
                obOpStk.DRate = DRate;
                obOpStk.Specifications = Specifications;
                obOpStk.Budle_Pack_Size = Budle_Pack_Size;
                obOpStk.Budle_Pack_Qty = Budle_Pack_Qty;
                obOpStk.CurrencyID = (int)cboCurrency.SelectedValue;
                obOpStk.ColorID = ColorID;
                obOpStk.CountID = CountID;
                obOpStk.SizeID = SizeID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obOpStk;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ctldgvItems.CurrentCell == null || ctldgvItems.CurrentRow.IsNewRow == true)
            {
                MessageBox.Show("No Item");
                return;
            }
            if (MessageBox.Show("Are you sure to Delete the selected Items", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            SqlTransaction trans = null;
            try
            {
                objDaOpStk = new DaOpeningStock();
                int OpningStockID = 0;
                OpningStockID = Convert.ToInt32(ctldgvItems.CurrentRow.Cells["ColOpeningStockID"].Value);
                if (formCon.State != ConnectionState.Open)
                    formCon.Open();
                trans = formCon.BeginTransaction();
                objDaOpStk.DeleteOpeningStock(formCon,trans, OpningStockID);
                if (chkHitAccount.Checked)
                    new DaStockInOut().UpdateRawMaterialAndFinishGoodsAccountBalance(formCon, trans);
                trans.Commit();
                resetForm();
                MessageBox.Show("Delete Successfull");
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show("Unable to Delete " + ex.Message);
            }
        }
        private void resetForm()
        {
            loadOpenings(-1, "NULL");
            txtCustomer.Text = "";
            txtCustomerID.Text = "0";
            dtpOpeningDate.Value = DateTime.Now;
        }

        private void frmOpeningStock_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formCon);
        }

        private void ctldgvItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (ctldgvItems.Columns[e.ColumnIndex].ReadOnly == true)
                SendKeys.Send("{TAB}");
        }

        private void llblItems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmItemSearch frm = new frmItemSearch();
                frm.ShowDialog();
                string items = frm.ItemList;
                if (items == string.Empty) return;
                //(int)cboFiscalYear.SelectedValue, 
                addItems(items);


                SelectNextControl((Control)sender, true, true, true, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    frmCustomer frm = new frmCustomer();
                    frm.ShowDialog();
                    Ledgers obCus;

                    obCus = frm.objCustomer;
                    if (obCus == null) return;
                    txtCustomer.Text = obCus.LedgerName;
                    txtCustomerID.Text = obCus.LedgerID.ToString();
                    cboCurrency.SelectedValue = obCus.CurrencyID;
                    loadOpenings(obCus.LedgerID, "NULL");
                    CalculateItemValue();
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Find customer " + ex.Message);
            }
           
               
        }

        private void dtpOpeningDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void numDollorRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void ctldgvItems_KeyDown(object sender, KeyEventArgs e)
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

        private void txtCustomer_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void numDollorRate_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtCustomer_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void numDollorRate_Enter(object sender, EventArgs e)
        {
            Control conl = (Control)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            //conl.SelectAll();
        }

        private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtRawAccount_Enter(object sender, EventArgs e)
        {
            try
            {
                frmAccountSearch frm = new frmAccountSearch();
                frm.ShowDialog();
                Account objSelectedAcc = frm.SelectedAccount;
                if (objSelectedAcc == null) return;

                txtRawAccount.Text = objSelectedAcc.AccountTitle;
                txtRawAccount.Tag = objSelectedAcc;

                Control conl = (Control)sender;
                conl.BackColor = Color.Black;
                conl.ForeColor = Color.White;
                //conl.SelectAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtFinishedAccount_Enter(object sender, EventArgs e)
        {
            try
            {
                frmAccountSearch frm = new frmAccountSearch();
                frm.ShowDialog();
                Account objSelectedAcc = frm.SelectedAccount;
                if (objSelectedAcc == null) return;

                txtFinishedAccount.Text = objSelectedAcc.AccountTitle;
                txtFinishedAccount.Tag = objSelectedAcc;

                Control conl = (Control)sender;
                conl.BackColor = Color.Black;
                conl.ForeColor = Color.White;
                //conl.SelectAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboCurrency_Enter(object sender, EventArgs e)
        {

        }

        private void cboCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtRawAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void ctlNumRawMaterials_Enter(object sender, EventArgs e)
        {
            Control conl = (Control)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            //conl.SelectAll();
        }

        private void txtRawAccount_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;

        }
    }
}
