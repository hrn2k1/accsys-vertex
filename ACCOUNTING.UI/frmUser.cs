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
    public partial class frmUser : Form
    {
        SqlConnection formConnection = null;
        DataTable dtModule = null;
        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            try
            {
                formConnection = ConnectionHelper.getConnection();
                loadUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadUser()
        {
            DaUser obDaUser = new DaUser();
            dtModule = new DataTable();
            try
            {
                dtModule = obDaUser.getUser(formConnection);
                dgvUser.DataSource = dtModule;
                dgvUser.setColumnsVisible(false, "UserID", "Password", "ConfirmPassword", "CompanyID");
                dgvUser.setColumnsWidth(dgvUser.Width / 2 - 2);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmUserManagements frmUM = new frmUserManagements();
            frmUM.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a Item to edit");
                return;
            }
            User obUser = new User();
            DaUser obDaUser = new DaUser();
            try
            {
                int UserId = Convert.ToInt32(dgvUser.SelectedRows[0].Cells["UserID"].Value);
                obUser = obDaUser.getUsers(UserId, formConnection);
                frmUserManagements frmUM = new frmUserManagements(obUser);
                frmUM.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctlDaraGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to edit");
                return;
            }
            btnEdit_Click(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to delete");
                return;
            }
            if (MessageBox.Show("Are you sure to Delete ?", "Confirmation Message", MessageBoxButtons.YesNo) == DialogResult.No) return;
            SqlTransaction trans = null;
            DaUserPrivilege obDaUserPrivilege = new DaUserPrivilege();
            DaUser obDaUser = new DaUser();
            try
            {
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                trans = formConnection.BeginTransaction();
                int UserID = Convert.ToInt32(dgvUser.SelectedRows[0].Cells["UserID"].Value);
                obDaUserPrivilege.deleteUserPrivilege(UserID, formConnection, trans);
                obDaUser.DeleteUser(UserID, formConnection, trans);
                trans.Commit();
                MessageBox.Show("Delete Successfull");
                loadUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void frmUser_Paint(object sender, PaintEventArgs e)
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
