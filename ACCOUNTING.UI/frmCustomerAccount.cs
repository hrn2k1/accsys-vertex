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
    public partial class frmCustomerAccount : Form
    {
        private SqlConnection formConnection = null;
        private DataTable dtAccount = null;
        public Account obSalesAccount = null;
        private string strLoadType = "";
        private string strLedgerType = "";
        public frmCustomerAccount()
        {
            InitializeComponent();
        }
        public frmCustomerAccount(int LedgerTypeID)
        {
            InitializeComponent();
            if (LedgerTypeID == 2)
            {
                strLedgerType += " AND  LedgerTypeID = 2 AND CompanyID=" + LogInInfo.CompanyID.ToString() +"  ";
                strLoadType += " Where CompanyID="+ LogInInfo.CompanyID.ToString()+  " AND LedgerTypeID = 2 ";
            }
            else
            {
                strLedgerType = "";
                strLoadType = "";
            }
        }

        private void frmCustomerAccount_Load(object sender, EventArgs e)
        {
            try
            {
                formConnection = ConnectionHelper.getConnection();
                loadCustomerAccount(strLoadType);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load Account " + ex.Message);
            }
        }

        private void loadCustomerAccount(string LedgerTypeID)
        {
            try
            {
                DaAccount obDaAccount = new DaAccount();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dtAccount = obDaAccount.loadCustomerAccount(formConnection, LedgerTypeID);
                dgvCustomerAccount.DataSource = dtAccount;
                dgvCustomerAccount.setColumnsVisible(false, "AccountID");
                dgvCustomerAccount.setColumnsWidth(dgvCustomerAccount.Width / 2 - 13);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtAccountTitle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //dgvCustomerAccount_CellDoubleClick(null, null);
                    //SearchAccount(strLedgerType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load Accounts " + ex.Message);
            }

        }

        private void SearchAccount(string LedgerTypeID)
        {
            try
            {
                string strQuerry = "";
                strQuerry += txtAccountTitle.Text.ToString();
                DaAccount obDaAccount = new DaAccount();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dtAccount = obDaAccount.searchAccount(formConnection, strQuerry, LedgerTypeID);
                dgvCustomerAccount.DataSource = dtAccount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchAccount(strLedgerType);
        }

        private void dgvCustomerAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            obSalesAccount = new Account();
            DaAccount obDaAccount = new DaAccount();
            try
            {
                if (e.RowIndex == -1) return;
                int AccountID = 0;
                AccountID = Convert.ToInt32(dgvCustomerAccount.Rows[e.RowIndex].Cells["AccountID"].Value);
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obSalesAccount = obDaAccount.getSalesAccount(formConnection, AccountID);
                btnClose_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sending Failed " + ex.Message);
            }
        }

        public Account returnSalesAccount()
        {
            return obSalesAccount;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            obSalesAccount = new Account();
            DaAccount obDaAccount = new DaAccount();
            try
            {
                if (dgvCustomerAccount.SelectedRows.Count == 0) return;
                int rowID = dgvCustomerAccount.SelectedRows[0].Index;
                int AccountID = 0;
                AccountID = Convert.ToInt32(dgvCustomerAccount.Rows[rowID].Cells["AccountID"].Value);
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obSalesAccount = obDaAccount.getSalesAccount(formConnection, AccountID);
                btnClose_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sending Failed " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomerAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void txtAccountTitle_TextChanged(object sender, EventArgs e)
        {
            SearchAccount(strLedgerType);

        }

        private void dgvCustomerAccount_Enter(object sender, EventArgs e)
        {
            txtAccountTitle.Focus();
        }

        private void frmCustomerAccount_Paint(object sender, PaintEventArgs e)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
