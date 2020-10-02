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
    public partial class frmSupplierSearch : Form
    {
        public frmSupplierSearch()
        {
            InitializeComponent();
        }

        private DataTable dtSuppliers = null;
        private CurrencyManager cmSupplier = null;
        //public Refreshing DoRefresh;
        private int supplierID=-1;
        public Ledgers SelectedSupplier = null;
        SqlConnection con = null;
        private void frmSupplierSearch_Load(object sender, EventArgs e)
        {
            con = ConnectionHelper.getConnection();
            loadSuppliers();
        }

        private void loadSuppliers()
        {
            try
            {
              

                dtSuppliers = new DaLedger().GetLadgers(con, 3, txtSupplier.Text.Trim());
                cmSupplier = (CurrencyManager)this.BindingContext[dtSuppliers];
                ctldgvSupplier.DataSource = dtSuppliers;
                ctldgvSupplier.setColumnsVisible(false, "LedgerID", "LedgerTypeID", "CountryID","CurrencyID","BankAccType","BusinessType","Phone","Fax","Email","CompanyID","UserID","ModifiedDate","AccountID","TeamID");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                loadSuppliers();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                supplierID = (int)ctldgvSupplier.Rows[ctldgvSupplier.CurrentCell.RowIndex].Cells["LedgerID"].Value;
                SelectedSupplier = new DaLedger().GetLedger(con, supplierID);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOK_Click(null, null);
        }

        private void ctldgvSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(null, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSupplierSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(con);
        }

        private void frmSupplierSearch_Paint(object sender, PaintEventArgs e)
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


    }
}
