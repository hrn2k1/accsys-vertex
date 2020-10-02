using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Entity;
using Accounting.DataAccess;
using System.Data.SqlClient;
using Accounting.Utility;

namespace Accounting.UI
{
    public partial class frmFactory : Form
    {
        private SqlConnection formConnection = ConnectionHelper.getConnection();
        private DataTable dtFactory = new DataTable();

        public frmFactory()
        {
            InitializeComponent();
        }

        private void frmFactory_Load(object sender, EventArgs e)
        {

            formLoad();

        }

        private void formLoad()
        {
            try
            {
                int CustomerID = 0;
                if (txtCustomerID.Text == "")
                    CustomerID = 0;
                else
                    CustomerID = Convert.ToInt32(txtCustomerID.Text.ToString());
                DaFactory obFactory = new DaFactory();
                formConnection = ConnectionHelper.getConnection();
                dtFactory = obFactory.formLoadFactory(formConnection, CustomerID);
                if (dgvFactory.Columns.Count > 0) dgvFactory.Columns.Clear();
                dgvFactory.DataSource = dtFactory;
                dgvFactory.setColumnsWidth(150);
                dgvFactory.setColumnsVisible(false, "FactoryID", "CustomerID", "CompanyID", "UserID", "ModifiedDate");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                Ledgers obLedgers;
                int CustomerID = 0;
                string CustomerName = "";
                frmCustomer obCustomer = new frmCustomer();
                obCustomer.ShowDialog();

                obLedgers = obCustomer.ReturnCustomerID();
                if (obLedgers == null) return;
                CustomerID = obLedgers.LedgerID;
                CustomerName = obLedgers.LedgerName;
                txtCustomerID.Text = CustomerID.ToString();
                txtCustomerName.Text = CustomerName.ToString();
                formLoad();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private bool validation()
        {
            if (txtCustomerName.Text.Trim() == "")
            {
                MessageBox.Show("Please select a Customer ");
                return false;
            }
            if (dgvFactory.Rows.Count < 2)
            {
                MessageBox.Show("Please Type a Factory Name");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation() == false) return;
            try
            {
                Factory obFactory = new Factory();
                DaFactory obDaFactory = new DaFactory();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                int i, nR;
                nR = dgvFactory.Rows.Count;
                for (i = 0; i < nR-1; i++)
                {
                    obFactory = createFactory(i);
                    obDaFactory.SaveUpdateFactory(obFactory, formConnection);
                }
                txtCustomerID.Text = "";
                txtCustomerName.Text = "";
                formLoad();
                MessageBox.Show("Save Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Save or Update " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFactory.SelectedRows.Count == 0 || dgvFactory.SelectedRows[0].IsNewRow) return;
                DaFactory obDaFactory = new DaFactory();
                int rowID = 0, FactoryID = 0;
                rowID = dgvFactory.SelectedRows[0].Index;
                FactoryID = dgvFactory.Rows[rowID].Cells["FactoryID"].Value == DBNull.Value ? 0 : Convert.ToInt32(dgvFactory.Rows[rowID].Cells["FactoryID"].Value);
                if (FactoryID == 0)
                {
                    MessageBox.Show("This is Not a valid Factory" + Environment.NewLine + "Please select a Valid Factory");
                    return;
                }
                if (MessageBox.Show("Are you sure to delete selected factory", "Conformation", MessageBoxButtons.YesNo) == DialogResult.No) return;
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDaFactory.DeleteFactory(formConnection, FactoryID);
                formLoad();
                MessageBox.Show("Delete Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Delete " + ex.Message);
            }
        }

        private Factory createFactory(int rowID)
        {
            try
            {
                Factory obFactory = new Factory();
                obFactory.FactoryID = isNullOrEmpty(dgvFactory.Rows[rowID].Cells["FactoryID"].Value) ? 0 : (int)dgvFactory.Rows[rowID].Cells["FactoryID"].Value;
                obFactory.FactoryName = dgvFactory.Rows[rowID].Cells["FactoryName"].Value.ToString();
                obFactory.Address = dgvFactory.Rows[rowID].Cells["Address"].Value.ToString();
                obFactory.CustomerID = Convert.ToInt32(txtCustomerID.Text.ToString());
                return obFactory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

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

        private void frmFactory_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void frmFactory_Paint(object sender, PaintEventArgs e)
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

        private void dgvFactory_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Black;
            e.CellStyle.ForeColor = Color.White;
        }
    }
}
