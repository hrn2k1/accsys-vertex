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
    public partial class frmCountry : Form
    {
        private SqlConnection formConnection = null;
        private DataTable dtCountry = null;
        public frmCountry()
        {
            InitializeComponent();
        }

        private void frmCountry_Load(object sender, EventArgs e)
        {
            DoubleBuffered = Enabled;
            formConnection = ConnectionHelper.getConnection();
        }

        /*----------------Country Section start ----------------*/
        private void tpCountry_Enter(object sender, EventArgs e)
        {
            loadCountry();
            refreshCountry();
        }

        private void loadCountry()
        {
            try
            {
                DaCountry obDaCountry = new DaCountry();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dtCountry = obDaCountry.getCountry(formConnection);
                dgvCountry.DataSource = dtCountry;
                dgvCountry.setColumnsWidth(dgvCountry.Width - 28);
                dgvCountry.setColumnsVisible(false, "CountryID", "CompanyID","UserID","ModifiedDate");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Open Country" + ex.Message);
            }
        }

        private void refreshCountry()
        {
            try
            {
                txtCountry.Text = "";
                txtCountryID.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Refresh" + ex.Message);
            }
        }

        private void btnSaveCountry_Click(object sender, EventArgs e)
        {
            try
            {
                Country obCountry = new Country();
                obCountry = createCountry();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                DaCountry obDaCountry = new DaCountry();
                obDaCountry.saveUpdateCountry(obCountry, formConnection);
                refreshCountry();
                loadCountry();
                MessageBox.Show("Save successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Country " + ex.Message);
            }
        }

        private Country createCountry()
        {
            Country obCountry = new Country();
            try
            {
               
                obCountry.CountryID = Convert.ToInt32(txtCountryID.Text);
                obCountry.CountryName = txtCountry.Text;
                //obCountry.CompanyID = 1;
                //obCountry.UserID = 1;
                //obCountry.ModifiedDate = DateTime.Now.Date;
                return obCountry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnDeleteCountry_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCountry.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete ");
                    return;
                }

                if (MessageBox.Show("Are you sure to delete ", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No) return;
                int rowID = dgvCountry.SelectedRows[0].Index;
                int CountryID = Convert.ToInt32(dgvCountry.Rows[rowID].Cells["CountryID"].Value);
                DaCountry obDaCountry = new DaCountry();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDaCountry.deleteCountry(formConnection, CountryID);
                refreshCountry();
                loadCountry();
                MessageBox.Show("Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to delete " + ex.Message);
            }

        }

        private void dgvCountry_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            refreshCountry();
            try
            {
                if (e.RowIndex == -1) return;

                txtCountryID.Text = dgvCountry.Rows[e.RowIndex].Cells["CountryID"].Value.ToString();
                txtCountry.Text = dgvCountry.Rows[e.RowIndex].Cells["CountryName"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditCountry_Click(object sender, EventArgs e)
        {
            refreshCountry();
            try
            {
                if (dgvCountry.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to edit");
                    return;
                }
                txtCountryID.Text = dgvCountry.SelectedRows[0].Cells["CountryID"].Value.ToString();
                txtCountry.Text = dgvCountry.SelectedRows[0].Cells["CountryName"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to edit " + ex.Message);
            }

        }

        private void btnCloseCountry_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*--------------close Country ------------------------*/

        /*-------------- Currency Start --------------------*/

        private void tpCurrency_Enter(object sender, EventArgs e)
        {
            loadCurrency();
        }

        private void loadCurrency()
        {
            try
            {
                DaCurrency obDaCurrency = new DaCurrency();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dtCountry = obDaCurrency.getCurrency(formConnection);
                dgvCurrency.DataSource = dtCountry;
                dgvCurrency.setColumnsVisible(false, "CurrencyID", "CompanyID", "UserID", "ModifiedDate");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open currency " + ex.Message);
            }
        }

        private void refreshCurrency()
        {
            try
            {
                txtCurrencyName.Text = "";
                txtCurrencyID.Text = "0";
                txtCurrencySymbol.Text = "";
                txtCurrencyCode.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("unable to Refresh " + ex.Message);
            }
        }

        private void btnSaveCurrency_Click(object sender, EventArgs e)
        {
            try
            {
                Currency obCurrency = new Currency();
                DaCurrency obDaCurrency = new DaCurrency();
                obCurrency = createCurrency();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDaCurrency.saveUpdate(obCurrency, formConnection);
                refreshCurrency();
                loadCurrency();
                MessageBox.Show("Save successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Save Currency " + ex.Message);
            }
        }

        private Currency createCurrency()
        {
            Currency obCurrency = new Currency();
            try
            {
                obCurrency.CurrencyID = Convert.ToInt32(txtCurrencyID.Text);
                obCurrency.Name = txtCurrencyName.Text;
                obCurrency.Code = txtCurrencyCode.Text;
                obCurrency.Symbol = txtCurrencySymbol.Text;
                //obCurrency.CompanyID = 1;
                //obCurrency.UserID = 1;
                //obCurrency.ModifiedDate = DateTime.Now.Date;
                return obCurrency;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnDeleteCurrency_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCurrency.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete ");
                    return;
                }
                if (MessageBox.Show("Are you sure to delete ", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No) return;

                int rowID = dgvCurrency.SelectedRows[0].Index;
                int CurrencyID = Convert.ToInt32(dgvCurrency.Rows[rowID].Cells["CurrencyID"].Value);
                DaCurrency obDaCurrency = new DaCurrency();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDaCurrency.deleteCurrency(formConnection, CurrencyID);
                refreshCurrency();
                loadCurrency();
                MessageBox.Show("deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to delete " + ex.Message);
            }
        }

        private void dgvCurrency_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            refreshCurrency();
            try
            {
                if (e.RowIndex == -1) return;
                txtCurrencyID.Text = dgvCurrency.Rows[e.RowIndex].Cells["CurrencyID"].Value.ToString();
                txtCurrencyName.Text = dgvCurrency.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtCurrencyCode.Text = dgvCurrency.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                txtCurrencySymbol.Text = dgvCurrency.Rows[e.RowIndex].Cells["Symbol"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditCurrency_Click(object sender, EventArgs e)
        {
            refreshCurrency();
            try
            {
                if (dgvCurrency.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to Edit");
                    return;
                }
                txtCurrencyCode.Text = dgvCurrency.SelectedRows[0].Cells["Code"].Value.ToString();
                txtCurrencyID.Text = dgvCurrency.SelectedRows[0].Cells["CurrencyID"].Value.ToString();
                txtCurrencyName.Text = dgvCurrency.SelectedRows[0].Cells["Name"].Value.ToString();
                txtCurrencySymbol.Text = dgvCurrency.SelectedRows[0].Cells["Symbol"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCloseCurrency_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*---------------- End of Currency --------------------------*/

        private void frmCountry_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void frmCountry_Paint(object sender, PaintEventArgs e)
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
    }
}
