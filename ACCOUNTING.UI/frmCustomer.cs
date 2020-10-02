using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.DataAccess;
using Accounting.Utility;
using System.Data.SqlClient;
using Accounting.Entity;

namespace Accounting.UI
{
    public partial class frmCustomer : Form
    {
        private SqlConnection formConnection = null;
        private DataTable dtMembers = new DataTable();
        public Ledgers objCustomer;
        public int CustomerID = 0;

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                DoubleBuffered = Enabled;
                formConnection = ConnectionHelper.getConnection();
                txtCustomerName.Focus();
                cmbMember.Enabled = false;
                cmbTeamName.Enabled = false;
                loadSelectedCustomer();
                //loadTeamMaster();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void loadTeamMaster()
        {
            try
            {
                DaTeam obDaTeam = new DaTeam();
                dtMembers = obDaTeam.loadMaster(formConnection);
                cmbTeamName.DataSource = dtMembers;
                cmbTeamName.DisplayMember = "TeamName";
                cmbTeamName.ValueMember = "TeamID";
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }

        private void cmbTeamName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTeamName.SelectedValue == null || cmbTeamName.SelectedValue.GetType() == typeof(DataRowView)) return;
                loadMembers(cmbTeamName.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbMember_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbMember.SelectedValue == null || cmbMember.SelectedValue.GetType() == typeof(DataRowView)) return;
                loadSelectedCustomer();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadSelectedCustomer();
               
            }
            
        }

        private void loadMembers(string TeamName)
        {
            DaTeam obDaTeam = new DaTeam();
            formConnection = ConnectionHelper.getConnection();
            try
            {
                dtMembers = obDaTeam.loadMembers(formConnection,TeamName);
                cmbMember.DataSource = dtMembers;
                cmbMember.DisplayMember = "MemberName";
                cmbMember.ValueMember = "MemberID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void rbtnCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomerName.Focus();
            lebelMember.Enabled = false;
            cmbTeamName.Enabled = false;
            cmbMember.Enabled = false;
            txtCustomerName.Enabled = true;
        }

        private void rbtnTeamName_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomerName.Enabled = false;
            cmbTeamName.Enabled = true;
            cmbMember.Enabled = true;
            lebelMember.Enabled = true;
            loadTeamMaster();
        }

        private void loadSelectedCustomer()
        {
            string strQuerry = " Select LedgerID, LedgerName from T_Ledgers Where LedgerTypeID = 2 AND CompanyID= "+ LogInInfo.CompanyID.ToString()+" ";
            if (rbtnTeamName.Checked == true)
                strQuerry += "AND teamID=" + cmbMember.SelectedValue.ToString();
            else if (rbtnCustomerName.Checked == true)
                strQuerry += "AND ledgerName Like '" + txtCustomerName.Text.ToString() + "%'";
            strQuerry += " ORDER BY LedgerName";
            try
            {
                DaTeam obDaTeam = new DaTeam();
                formConnection = ConnectionHelper.getConnection();
                dtMembers = obDaTeam.loadSelectedCustomer(formConnection, strQuerry);
                dgvCustomerName.DataSource = dtMembers;
                dgvCustomerName.setColumnsVisible(false, "LedgerID");
                dgvCustomerName.setColumnsWidth(dgvCustomerName.Width - 27);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvCustomerName.SelectedRows.Count == 0)
            {
                MessageBox.Show("No rows selected" + Environment.NewLine + "Please select a row");
                return;
            }
            try
            {
                CustomerID = (int)dgvCustomerName.SelectedRows[0].Cells["LedgerID"].Value;
                //CustomerID = (int)dgvCustomerName.Rows[dgvCustomerName.CurrentRow.Index].Cells["LedgerID"].Value;
                objCustomer = new DaLedger().GetLedger(formConnection, CustomerID);
                //if (objCustomer == null) return;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public Ledgers ReturnCustomerID()
        {
            return objCustomer;
        }

        private void dgvCustomerName_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOK_Click(null, null);
        }

        private void frmCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void frmCustomer_Paint(object sender, PaintEventArgs e)
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

        private void dgvCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            btnOK_Click(null, null);
        }

        private void dgvCustomerName_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

       
    }
}
