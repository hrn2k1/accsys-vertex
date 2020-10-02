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
    public partial class frmPriceList : Form
    {
        public frmPriceList()
        {
            InitializeComponent();
        }
        SqlConnection formCon = null;
        DataTable dtPriceList = null;
        private DataTable dtItems = new DataTable();
        private DataTable dtCounts = new DataTable();
        private DataTable dtSizes = new DataTable();
        private DataTable dtColors = new DataTable();
        private DataTable dtUnits = new DataTable();
        CurrencyManager cmPriceList = null;
        private void frmPriceList_Load(object sender, EventArgs e)
        {
            try
            {
              formCon=  new LocalConnection().getConnection();

              loadItems();
              loadCounts();
              loadSizes();
              loadColors();
              loadUnits();
              loadTeam();
              loadTeamMember((int)cboTeam.SelectedValue);
              loadCustomer((int)cboMember.SelectedValue);

              
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
        private void loadUnits()
        {
            try
            {
                dtUnits = new DaUnits().unitsLoad(formCon);
                UnitID.DataSource = dtUnits;
                UnitID.DisplayMember = "UnitsName";
                UnitID.ValueMember = "UnitsID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadTeam()
        {
            try
            {
                DataTable dt = new DaTeam().loadMaster(formCon);
                dt.Rows.Add(new object[] { 0,"", "Independant" });
                cboTeam.DataSource = dt;
                cboTeam.DisplayMember = "TeamName";
                cboTeam.ValueMember = "TeamID";
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadTeamMember(int teamID)
        {
            try
            {
                cboMember.DataSource = new DaTeam().loadDetail(formCon, teamID);
                cboMember.DisplayMember = "MemberName";
                cboMember.ValueMember = "MemberID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadCustomer(int memberID)
        {
            try
            {
                DataTable dtC=new DaLedger().GetLadgers(formCon, 2, memberID);
                cboCustomer.DataSource = dtC;
                cboCustomer.DisplayMember = "LedgerName";
                cboCustomer.ValueMember = "LedgerID";
                AutoCompleteStringCollection strCol = new AutoCompleteStringCollection();
                DataTable dt=(DataTable)cboCustomer.DataSource;
                foreach (DataRow r in dt.Rows)
                {
                    strCol.Add(r.Field<string>(cboCustomer.DisplayMember));
                }
                cboCustomer.AutoCompleteCustomSource = strCol;

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadPriceList()
        {
            try
            {

                string mode = rbCustomerwise.Checked ? "Customerwise" : "Itemwise";
                
                DaPriceList objDaPriceList = new DaPriceList();
                dtPriceList = objDaPriceList.getPriceList(formCon, mode,dtpStartDate.Value.Date,dtpEndDate.Value.Date, rbCustomerwise.Checked ? (int)cboCustomer.SelectedValue : 0);
                //cmPriceList = (CurrencyManager)this.BindingContext[dtPriceList];
                //dtPriceList.Columns["ItemID"].Unique = true;
                //ctldgvPriceList.DataSource = dtPriceList;

                //ctldgvPriceList.setColumnsVisible(false, "PriceID", "CustomerID", "ItemID", /*"SetupDate",*/ "UnitID", "SetupUnitID");
                //ctldgvPriceList.setColumnsReadOnly(true, "ItemName", "Size", "Color", "Shade", "Count", "Unit");

                int i, nR;
                nR = dtPriceList.Rows.Count;
                ctldgvPriceList.Rows.Clear();
                for (i = 0; i < nR; i++)
                {
                    ctldgvPriceList.Rows.Add(dtPriceList.Rows[i].Field<object>("PriceID"), dtPriceList.Rows[i].Field<object>("ItemID"),
                                             dtPriceList.Rows[i].Field<object>("CountID"), dtPriceList.Rows[i].Field<object>("SizeID"),
                                             dtPriceList.Rows[i].Field<object>("ColorID"), dtPriceList.Rows[i].Field<object>("unitID"),
                                             dtPriceList.Rows[i].Field<object>("price"), dtPriceList.Rows[i].Field<object>("vat"),
                                             dtPriceList.Rows[i].Field<object>("remarks"), dtPriceList.Rows[i].Field<object>("setupDate"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmPriceList_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
               new LocalConnection().closeConnection(formCon);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboTeam_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(cboTeam.SelectedValue==null ||cboTeam.SelectedValue.GetType()==typeof(DataRowView)) return ;
                if (cboTeam.Items.Count == 0) loadTeamMember(-1);
                if ((int)cboTeam.SelectedValue <= 0)
                    loadCustomer(0);
                
                loadTeamMember((int)cboTeam.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboMember_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(cboMember.SelectedValue==null ||cboMember.SelectedValue.GetType()==typeof(DataRowView)) return ;
                
                loadCustomer((int)cboMember.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCustomer.SelectedValue == null || cboCustomer.SelectedValue.GetType() == typeof(DataRowView)) return;
               // if (cboCustomer.Items.Count == 0) loadPriceList(" CustomerID= -2");
               //loadPriceList(  " CustomerID= " + cboCustomer.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbCustomerwise_CheckedChanged(object sender, EventArgs e)
        {
            gbxCustomer.Visible = rbCustomerwise.Checked;
            ctldgvPriceList.Height = gbxButtons.Location.Y - ctldgvPriceList.Top - 50;
            //cboCustomer_SelectedValueChanged(sender, e);
        }

        private void ctldgvPriceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == -1) return;
            //    string mode =rbCustomerwise.Checked?"Customerwise":"Itemwise";
            //    if (ctldgvPriceList.Columns[e.ColumnIndex].Name == "ItemName")
            //    {
            //        frmItemSearch frm = new frmItemSearch();
            //        frm.ShowDialog();
            //        string items = frm.ItemList;
            //        if (items == string.Empty) return;
            //        addItems(items);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void ctldgvPriceList_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //     string mode =rbCustomerwise.Checked?"Customerwise":"Itemwise";
            //    if (ctldgvPriceList.Columns[ctldgvPriceList.CurrentCell.ColumnIndex].Name == "ItemName" && e.KeyCode == Keys.Enter)
            //    {
            //        frmItemSearch frm = new frmItemSearch();
            //        frm.ShowDialog();
            //        string items = frm.ItemList;
            //        if (items == string.Empty) return;
            //        addItems(items);
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
               

                DaPriceList objDaPriceList = new DaPriceList();
                DataTable dt = objDaPriceList.getItems(formCon," ItemID,UnitID " ,items);


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                        ctldgvPriceList.Rows.Add(0, dt.Rows[i].Field<object>("ItemID"),null,null,null,
                                                  dt.Rows[i].Field<object>("UnitID"), null,
                                                  null);
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void rbItemwise_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
                
            //    loadPriceList(" P.CustomerID IS NULL ");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int i, nR;
                bool msgFlag = false;
                PriceList objPriceList = new PriceList();
                DaPriceList objDaPL = new DaPriceList();
                nR = ctldgvPriceList.Rows.Count;
                for (i = 0; i < nR-1; i++)
                {
                    objPriceList = CreatePriceListObject(i);
                    objDaPL.SaveUpdate(objPriceList, formCon);
                    msgFlag = true;
                }
                if (msgFlag == true)
                {
                    ctldgvPriceList.Rows.Clear();
                    MessageBox.Show("Save Successful");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private PriceList CreatePriceListObject(int rowID)
        {
            PriceList objPL = null;
            try
            {
                objPL = new PriceList();
                objPL.PriceID = GlobalFunctions.isNull( ctldgvPriceList["PriceID",rowID].Value,0);
                objPL.CustomerID = rbCustomerwise.Checked ? (int)cboCustomer.SelectedValue : -1;

                objPL.ItemID = Convert.ToInt32( ctldgvPriceList["ItemID",rowID].Value);
                objPL.CountID = GlobalFunctions.isNull(ctldgvPriceList["CountID", rowID].Value, 0);
                objPL.SizeID = GlobalFunctions.isNull(ctldgvPriceList["SizeID", rowID].Value, 0);
                objPL.ColorID = GlobalFunctions.isNull(ctldgvPriceList["ColorID", rowID].Value, 0);
                objPL.UnitID = Convert.ToInt32( ctldgvPriceList["UnitID",rowID].Value);
                objPL.Price =  GlobalFunctions.isNull( ctldgvPriceList["Price",rowID].Value,0.0);
                objPL.VAT = GlobalFunctions.isNull(ctldgvPriceList["VAT",rowID].Value,0.0);
                objPL.SetupDate =  GlobalFunctions.isNull( ctldgvPriceList["SetupDate",rowID].Value,dtpSetupDate.Value.Date);
                objPL.Remarks = GlobalFunctions.isNull(ctldgvPriceList["Remarks",rowID].Value,"");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objPL;
        }
        private bool isNullOrEmpty(object obj)
        {
            if (obj == null || obj.ToString() == "")
                return true;
            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if(ctldgvPriceList.CurrentCell==null) return ;
                int priceID=isNullOrEmpty(ctldgvPriceList.Rows[ctldgvPriceList.CurrentCell.RowIndex].Cells["PriceID"].Value)?0:(int)ctldgvPriceList.Rows[ctldgvPriceList.CurrentCell.RowIndex].Cells["PriceID"].Value;
                DaPriceList objDaPL = new DaPriceList();
                if (priceID == 0)
                    ctldgvPriceList.Rows.RemoveAt(ctldgvPriceList.CurrentCell.RowIndex);
                else
                {
                    objDaPL.DeletePriceList(formCon, priceID);
                    btnFind_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbo_Enter(object sender, EventArgs e)
        {
            //SendKeys.Send("{F4}");
        }

        private void ctl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
           
            
        }

        private void ctldgvPriceList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (ctldgvPriceList.Columns[ctldgvPriceList.CurrentCell.ColumnIndex].CellType.Name != "DataGridViewComboBoxCell")
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void ctldgvPriceList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (ctldgvPriceList.Columns[e.ColumnIndex].CellType.Name == "DataGridViewComboBoxCell")
                SendKeys.Send("{F4}");
        }

        private void frmPriceList_Paint(object sender, PaintEventArgs e)
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

        private void llblItems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                
                string mode = rbCustomerwise.Checked ? "Customerwise" : "Itemwise";
                
                    frmItemSearch frm = new frmItemSearch();
                    frm.ShowDialog();
                    string items = frm.ItemList;
                    if (items == string.Empty) return;
                    addItems( items );
               
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
                if (cboCustomer.Items.Count == 0 && rbCustomerwise.Checked)
                {
                    MessageBox.Show("Please select a cutomer");
                    return;
                }
                loadPriceList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ctldgvPriceList.Rows.Clear();
        }

        private void ctldgvPriceList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            if (ctldgvPriceList.Columns[e.ColumnIndex].Name == ItemID.Name)
            {
                int iID = GlobalFunctions.isNull(ctldgvPriceList[ItemID.Name, e.RowIndex].Value, 0);
                ChartsOfItem I=new DAChartsOfItem().getItem(iID, formCon);
                ctldgvPriceList[UnitID.Name, e.RowIndex].Value = I.UnitID;
            }
             
        }

       

       
    }
}
