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
    public partial class frmBranch : Form
    {
        SqlConnection formConnection = null;
        DataTable dtBranch = new DataTable();
        public frmBranch()
        {
            InitializeComponent();
        }
        private void frmBranch_Load(object sender, EventArgs e)
        {
            txtBranchName.Focus();
            formConnection = ConnectionHelper.getConnection();
            loadBranch();
        }
        private void loadBranch()
        {
            try
            {
                DaTeam obDaTeam = new DaTeam();
                //DaBranch obDaBranch=new DaBranch();
                dtBranch = obDaTeam.loadBranch(formConnection);
                dgvbranch.DataSource = dtBranch;
                dgvbranch.setColumnsVisible(false, "BranchID", "CompanyID", "UserID", "ModifiedDate");
                dgvbranch.setColumnsWidth(dgvbranch.Width / 2 - 13);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void dgvbranch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            try
            {
                txtBranchID.Text = dgvbranch.Rows[e.RowIndex].Cells["BranchID"].Value.ToString();
                txtBranchName.Text = dgvbranch.Rows[e.RowIndex].Cells["BranchName"].Value.ToString();
                rtxtAddress.Text = dgvbranch.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error "+ex.Message);
            }
        }
        private bool validation()
        {
            if (txtBranchName.Text.Trim() == "")
            {
                MessageBox.Show("Please insert Branch Name");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation() == false) return;
            if (MessageBox.Show("Are you sure to save ", "conformatrion", MessageBoxButtons.YesNo) == DialogResult.No) return;
            try
            {
                Branch obBranch = new Branch();
                DaBranch obDaBranch = new DaBranch();
                obBranch = createBranch();
                obDaBranch.SaveUpdateBranch(obBranch, formConnection);
                resetBranch();
                MessageBox.Show("Save successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
        private Branch createBranch()
        {
            Branch obBranch = new Branch();
            try
            {
                obBranch.BranchID = txtBranchID.Text == "" ? 0 : Convert.ToInt32(txtBranchID.Text);
                obBranch.BranchName = txtBranchName.Text;
                obBranch.Address = rtxtAddress.Text;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obBranch;
        }
        private void resetBranch()
        {
            try
            {
                txtBranchID.Text = "";
                txtBranchName.Text = "";
                rtxtAddress.Text = "";
                loadBranch();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtBranchID.Text == "")
            {
                MessageBox.Show("No Branch Selected for Delete " + Environment.NewLine + "Please Select a Branch For Delete");
                return;
            }
            if (MessageBox.Show("Are you sure to delete the branch ", "Conformation ", MessageBoxButtons.YesNo) == DialogResult.No) return;
            int Branchid = Convert.ToInt32(txtBranchID.Text);
            try
            {
                DaBranch obDaBranch = new DaBranch();
                obDaBranch.deleteBranch(formConnection, Branchid);
                resetBranch();
                MessageBox.Show("Delete Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmBranch_Paint(object sender, PaintEventArgs e)
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
        private void frmBranch_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }
    }
}
