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

namespace Accounting.UI
{
    public partial class frmBasicEntryScreen : Form
    {
        private DataTable dtItems = null;
        private SqlConnection formConnection = null;
       
        public frmBasicEntryScreen()
        {
            InitializeComponent();
        }

        private void frmBasicEntryScreen_Load(object sender, EventArgs e)
        {

            DoubleBuffered = Enabled;
            formConnection = ConnectionHelper.getConnection();

        }

        /*************** Colors Section ****************************/
        #region Color
        private void tpColors_Enter(object sender, EventArgs e)
        {
            colorsLoad();
            txtColorsName.Focus();

        }

        private void colorsLoad()
        {
            lblColors.Text = dgvCounts.Rows.Count.ToString();

            try 
            {
                Dacolors obDacolors = new Dacolors();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dtItems = obDacolors.colorsload(formConnection);
                dgvColors.DataSource = dtItems;
                dgvColors.setColumnsWidth(dgvColors.Width - 27);
                dgvColors.setColumnsVisible(false, "ColorsID", "CompanyID", "UserID", "ModifiedDate");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enable to open Colors " + ex.Message);
            }
        }
        private bool validation()
        {
            if (txtColorsName.Text.Trim() == "")
            {
                MessageBox.Show("Please Type Colors Name");
                return false;
            }
            return true;
        }
        private void btnSaveColors_Click(object sender, EventArgs e)
        {
            if (validation() == false)
                return;
            try
            {
                Colors obColors = new Colors();
                Dacolors obDacolors = new Dacolors();
                obColors = createColors();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDacolors.SaveUpdateColors(obColors, formConnection);
                refreshColors();
                colorsLoad();
                MessageBox.Show("Save Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Save or Update Colors " + ex.Message);
            }

        }

        private Colors createColors()
        {
            Colors obColors = new Colors();
            try
            {
                obColors.ColorsID = txtColorsID.Text == "0" ? -1 : Convert.ToInt32(txtColorsID.Text);
                obColors.ColorsName = txtColorsName.Text;
                txtColorsID.Text = "0";
                txtColorsName.Text = "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obColors;
        }

        private void dgvColors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                refreshColors();
                if (e.RowIndex == -1 || dgvColors.SelectedRows[0].IsNewRow) return;
                txtColorsID.Text = dgvColors.Rows[e.RowIndex].Cells["ColorsID"].Value.ToString();
                txtColorsName.Text = dgvColors.Rows[e.RowIndex].Cells["ColorsName"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Edit Fails " + ex.Message);
            }
        }

        private void refreshColors()
        {
            try
            {
                txtColorsName.Text = "";
                txtColorsID.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Reset Text " + ex.Message);
            }
        }

        private void btnColoresEdit_Click(object sender, EventArgs e)
        {
            try
            {
                refreshColors();
                if (dgvColors.SelectedRows.Count == 0 || dgvColors.SelectedRows[0].IsNewRow)
                {
                    MessageBox.Show("Please Select Colors to Edit");
                    return;
                }
                int rowID = 0;
                rowID = dgvColors.SelectedRows[0].Index;
                txtColorsID.Text = dgvColors.Rows[rowID].Cells["ColorsID"].Value.ToString();
                txtColorsName.Text = dgvColors.Rows[rowID].Cells["ColorsName"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Edit " + ex.Message);
            }
        }

        private void btnColoresDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvColors.SelectedRows.Count == 0 || dgvColors.SelectedRows[0].IsNewRow)
                {
                    MessageBox.Show("Please select a color to delete ");
                    return;
                }

                if (MessageBox.Show("Are You Sure To Delete The Selected Row", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                int rowID = dgvColors.SelectedRows[0].Index;
                int ColorsID = 0;
                Dacolors obDacolors = new Dacolors();
                ColorsID = Convert.ToInt32(dgvColors.Rows[rowID].Cells["ColorsID"].Value);
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDacolors.deleteColors(formConnection, ColorsID);
                refreshColors();
                colorsLoad();
                MessageBox.Show("Delete Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Delete Colors " + ex.Message);
            }

        }

        private void btnColoresClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        /************************ End of Colors***********************
         
          ********************** Counts Section******************/
        #region Count
        private void tpCounts_Enter(object sender, EventArgs e)
        {
            countsload();
            txtCountsName.Focus();
        }

        private void countsload()
        {
            lblCounts.Text = dgvCounts.Rows.Count.ToString();
            try
            {
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                DaCounts obDaCounts = new DaCounts();
                dtItems = obDaCounts.countsload(formConnection);
                dgvCounts.DataSource = dtItems;
                dgvCounts.setColumnsWidth(dgvCounts.Width-27);
                dgvCounts.setColumnsVisible(false, "CountID");
                //dgvCounts.setColumnsVisible(false, "CountID", "CompanyID", "UserID", "ModifiedDate");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open Counts " + ex.Message);
            }
        }
        private bool validationCount()
        {
            if (txtCountsName.Text.Trim() == "")
            {
                MessageBox.Show("Please Type Count Name");
                return false;
            }
            return true;
        }

        private void btnSaveCounts_Click(object sender, EventArgs e)
        {
            if (validationCount() == false)
                return;
            try
            {
                DaCounts obDaCounts = new DaCounts();
                Counts obCounts = new Counts();
                obCounts = createCounts();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDaCounts.saveUpdateCounts(obCounts, formConnection);
                countsload();
                refreshCounts();
                MessageBox.Show("Save Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save or Update " + ex.Message);
            }
        }

        private Counts createCounts()
        {
            try
            {
                Counts obCounts = new Counts();
                obCounts.CountID = txtCountsID.Text == "0" ? -1 : Convert.ToInt32(txtCountsID.Text);
                obCounts.CountName = txtCountsName.Text;
                return obCounts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnCountsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCounts.SelectedRows.Count == 0 || dgvCounts.SelectedRows[0].IsNewRow)
                {
                    MessageBox.Show("Please select a CountsMane to Delete");
                    return;
                }

                if (MessageBox.Show("Are you Sure to delete the selected row ", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                int rowID = dgvCounts.SelectedRows[0].Index;
                int CountID = Convert.ToInt32(dgvCounts.Rows[rowID].Cells["CountID"].Value);
                DaCounts obDaCounts = new DaCounts();
                obDaCounts.DeleteCounts(formConnection, CountID);
                refreshCounts();
                countsload();
                MessageBox.Show("Delete Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable To Delete"+ex.Message);
            }
        }

        private void dgvCounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                refreshCounts();
                if (e.RowIndex == -1 || dgvCounts.SelectedRows[0].IsNewRow) return;
                txtCountsID.Text = dgvCounts.Rows[e.RowIndex].Cells["CountID"].Value.ToString();
                txtCountsName.Text = dgvCounts.Rows[e.RowIndex].Cells["CountName"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Edit " + ex.Message);
            }
        }

        private void btnCountsEdit_Click(object sender, EventArgs e)
        {
            try
            {
                refreshCounts();
                if (dgvCounts.SelectedRows.Count == 0 || dgvCounts.SelectedRows[0].IsNewRow)
                {
                    MessageBox.Show("Please select a CountName to Edit");
                    return;
                }
                int rowID = 0;
                rowID = dgvCounts.SelectedRows[0].Index;
                txtCountsID.Text = dgvCounts.Rows[rowID].Cells["CountID"].Value.ToString();
                txtCountsName.Text = dgvCounts.Rows[rowID].Cells["CountName"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Edit Counts " + ex.Message);
            }
        }

        private void refreshCounts()
        {
            try
            {
                txtCountsID.Text = "0";
                txtCountsName.Text = "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnCountsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        /************************ End of Counts ***********************
         
          ********************** Sizes Section******************/
        #region Size
        private void tpSizes_Enter(object sender, EventArgs e)
        {
            sizesLoad();
            txtSizes.Focus();
        }

        private void sizesLoad()
        {
            lblSizes.Text = dgvSizes.Rows.Count.ToString();
            try
            {
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                DaSizes obDaSizes=new DaSizes();
                dtItems = obDaSizes.SizesLoad(formConnection);
                dgvSizes.DataSource = dtItems;
                dgvSizes.setColumnsWidth(dgvSizes.Width-27);
                dgvSizes.setColumnsVisible(false, "SizesID", "CompanyID", "UserID", "ModifiedDate");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open Sizes " + ex.Message);
            }
        }
        private bool validationSize()
        {
            if (txtSizes.Text.Trim() == "")
            {
                MessageBox.Show("Please Type Sizes Name");
                return false;
            }
            return true;
        }

        private void btnSaveSizes_Click(object sender, EventArgs e)
        {
            if (validationSize() == false)
                return;
            try
            {
                DaSizes obDaSizes = new DaSizes();
                Sizes obSizes = new Sizes();
                obSizes = createSizes();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDaSizes.saveUpdateSizes(obSizes, formConnection);
                refreshSizes();
                sizesLoad();
                MessageBox.Show(" Save Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Save or Update Sizes"+ex.Message);
            }

        }

        private Sizes createSizes()
        {
            Sizes obSizes = new Sizes();
            try
            {
                obSizes.SizesName = txtSizes.Text;
                obSizes.SizesID = txtSizesID.Text == "0" ? -1 : Convert.ToInt32(txtSizesID.Text);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obSizes;
        }

        private void btnSizesdelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSizes.SelectedRows.Count == 0 || dgvSizes.SelectedRows[0].IsNewRow)
                {
                    MessageBox.Show("Please select a SizesMane to Delete");
                    return;
                }

                if (MessageBox.Show("Are you sure to delete the selected row ", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                int rowID = dgvSizes.SelectedRows[0].Index;
                int SizesID = Convert.ToInt32(dgvSizes.Rows[rowID].Cells["SizesID"].Value);
                DaSizes obDaSizes = new DaSizes();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDaSizes.deleteSizes(formConnection, SizesID);
                refreshSizes();
                sizesLoad();
                MessageBox.Show("Delete Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable To Delete"+ex.Message);
            }
        }

        private void dgvSizes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                refreshSizes();
                if (e.RowIndex == -1 || dgvSizes.SelectedRows[0].IsNewRow) return;
                txtSizes.Text = dgvSizes.Rows[e.RowIndex].Cells["SizesName"].Value.ToString();
                txtSizesID.Text = dgvSizes.Rows[e.RowIndex].Cells["SizesID"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Edit " + ex.Message);
            }
        }

        private void btnSizesEdit_Click(object sender, EventArgs e)
        {
            try
            {
                refreshSizes();
                if (dgvSizes.SelectedRows.Count == 0 || dgvSizes.SelectedRows[0].IsNewRow)
                {
                    MessageBox.Show("Please select a SizesName to Edit");
                    return;
                }
                int rowID = 0;
                rowID = dgvSizes.SelectedRows[0].Index;
                txtSizes.Text = dgvSizes.Rows[rowID].Cells["SizesName"].Value.ToString();
                txtSizesID.Text = dgvSizes.Rows[rowID].Cells["SizesID"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Edit Sizes " + ex.Message);
            }
        }

        private void refreshSizes()
        {
            try
            {
                txtSizes.Text = "";
                txtSizesID.Text = "0";
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }
        }

        private void btnSizesClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        /************************ End of Sizes ***********************
         
           ********************** Shade Section******************/
        #region Section

        private void tpShade_Enter(object sender, EventArgs e)
        {
            shadeload();
            txtShade.Focus();
        }

        private void shadeload()
        {
            lblShade.Text = dgvShade.Rows.Count.ToString();
            try
            {
                DaShade obDaShade = new DaShade();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dtItems = obDaShade.shadeLoad(formConnection);
                dgvShade.DataSource = dtItems;
                dgvShade.setColumnsWidth(dgvShade.Width-27);
                dgvShade.setColumnsVisible(false, "ShadeID", "CompanyID", "UserID", "ModifiedDate", "Remarks");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open ShadeNo " + ex.Message);
            }
        }
        private bool validationShade()
        {
            if (txtShade.Text.Trim() == "")
            {
                MessageBox.Show("Please Type Shade No");
                return false;
            }
            return true;
        }

        private void btnSaveShade_Click(object sender, EventArgs e)
        {
            if (validationShade() == false)
                return;
            try
            {
                DaShade obDaShade = new DaShade();
                Shade obShade = new Shade();
                obShade = createShade();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDaShade.saveUpdateShade(obShade, formConnection);
                refreshShade();
                shadeload();
                MessageBox.Show("Save Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Shade " + ex.Message);
            }

        }

        private Shade createShade()
        {
            try
            {
                Shade obShade = new Shade();
                obShade.ShadeID = txtShadeID.Text == "0" ? -1 : Convert.ToInt32(txtShadeID.Text);
                obShade.ShadeNo = txtShade.Text;
                return obShade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnShadedelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvShade.SelectedRows.Count == 0 || dgvShade.SelectedRows[0].IsNewRow)
                {
                    MessageBox.Show("Please select a ShadeNo to Delete ");
                    return;
                }

                if (MessageBox.Show("Are you sure to delete the selected row ", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                int rowID = dgvShade.SelectedRows[0].Index;
                int ShadeID = Convert.ToInt32(dgvShade.Rows[rowID].Cells["ShadeID"].Value);
                DaShade obDaShade = new DaShade();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDaShade.deleteShade(formConnection, ShadeID);
                refreshShade();
                shadeload();
                MessageBox.Show("Delete successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable To Delete"+ex.Message);
            }
        }

        private void dgvShade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                refreshShade();
                if (e.RowIndex == -1 || dgvShade.SelectedRows[0].IsNewRow) return;
                txtShadeID.Text = dgvShade.Rows[e.RowIndex].Cells["ShadeID"].Value.ToString();
                txtShade.Text = dgvShade.Rows[e.RowIndex].Cells["ShadeNo"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Edit " + ex.Message);
            }
        }

        private void btnShadeEdit_Click(object sender, EventArgs e)
        {
            try
            {
                refreshShade();
                if (dgvShade.SelectedRows.Count == 0 || dgvShade.SelectedRows[0].IsNewRow)
                {
                    MessageBox.Show("Please select a ShadeNo to Edit");
                    return;
                }
                int rowID = dgvShade.SelectedRows[0].Index;
                txtShadeID.Text = dgvShade.Rows[rowID].Cells["ShadeID"].Value.ToString();
                txtShade.Text = dgvShade.Rows[rowID].Cells["ShadeNo"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Edit Shade " + ex.Message);
            }
        }

        private void refreshShade()
        {
            try
            {
                txtShade.Text = "";
                txtShadeID.Text = "0";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnShadeClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        /************************ End of Shade ***********************
         
           ********************** Units Section******************/
        #region Unit
        private void tpUnits_Enter(object sender, EventArgs e)
        {
            unitsLoad();
            txtUnits.Focus();
        }

        private void unitsLoad()
        {
            lblUnits.Text = dgvUnits.Rows.Count.ToString();
            try
            {
                DaUnits obDaUnits = new DaUnits();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dtItems = obDaUnits.unitsLoad(formConnection);
                dgvUnits.DataSource = dtItems;
                dgvUnits.setColumnsWidth(dgvUnits.Width-27);
                dgvUnits.setColumnsVisible(false, "UnitsID", "CompanyID", "UserID", "ModifiedDate");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open Units" + ex.Message);
            }
        }

        private void refreshUnits()
        {
            try
            {
                txtUnits.Text = "";
                txtUnitsID.Text = "0";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private bool validationUnit()
        {
            if (txtUnits.Text.Trim() == "")
            {
                MessageBox.Show("Please Type Unit Name");
                return false;
            }
            return true;
        }

        private void btnSaveUnits_Click(object sender, EventArgs e)
        {
            if (validationUnit() == false)
                return;
            try
            {
                DaUnits obDaUnits = new DaUnits();
                Units obUnits = new Units();
                obUnits = createUnits();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDaUnits.saveUpdateUnits(obUnits, formConnection);
                refreshUnits();
                unitsLoad();
                MessageBox.Show("Save Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Units "+ex.Message);
            }
        }

        private Units createUnits()
        {
            Units obUnits = new Units();
            try
            {
                obUnits.UnitsID = txtUnitsID.Text == "0" ? -1 : Convert.ToInt32(txtUnitsID.Text);
                obUnits.UnitsName = txtUnits.Text;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obUnits;
        }

        private void dgvUnits_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                refreshUnits();
                if (e.RowIndex == -1 || dgvUnits.SelectedRows[0].IsNewRow) return;
                txtUnits.Text = dgvUnits.Rows[e.RowIndex].Cells["UnitsName"].Value.ToString();
                txtUnitsID.Text = dgvUnits.Rows[e.RowIndex].Cells["UnitsID"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Edit " + ex.Message);
            }
        }

        private void btnUnitsEdit_Click(object sender, EventArgs e)
        {
            try
            {
                refreshUnits();
                if (dgvUnits.SelectedRows.Count == 0 || dgvUnits.SelectedRows[0].IsNewRow)
                {
                    MessageBox.Show("Please Select a Unit to Update");
                    return;
                }
                int rowID = dgvUnits.SelectedRows[0].Index;
                txtUnits.Text = dgvUnits.Rows[rowID].Cells["UnitsName"].Value.ToString();
                txtUnitsID.Text = dgvUnits.Rows[rowID].Cells["UnitsID"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Edit Units " + ex.Message);
            }
        }

        private void btnUnitsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUnits.SelectedRows.Count == 0 || dgvUnits.SelectedRows[0].IsNewRow)
                {
                    MessageBox.Show("Please Select a UnitsName to Delete ");
                    return;
                }

                if (MessageBox.Show("Are you sure to delete the selected row ", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                int rowID = dgvUnits.SelectedRows[0].Index;
                int UnitsID = Convert.ToInt32(dgvUnits.Rows[rowID].Cells["UnitsID"].Value);
                DaUnits obDaUnits = new DaUnits();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDaUnits.deleteUnits(formConnection, UnitsID);
                refreshUnits();
                unitsLoad();
                MessageBox.Show("Delete Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable To Delete" + ex.Message);
            }
        }

        private void btnUnitsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        /************************ End of Units ***********************/
        private bool isNullOrEmpty(object obj)
        {
            if (obj == null || obj.ToString() == "")
                return true;
            return false;
        }

        private void frmBasicEntryScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void frmBasicEntryScreen_Paint(object sender, PaintEventArgs e)
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

        private void tp_Paint(object sender, PaintEventArgs e)
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

        private void txtColorsName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }
    }
}
