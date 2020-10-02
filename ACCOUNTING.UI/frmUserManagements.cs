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
    public partial class frmUserManagements : Form
    {
        SqlConnection formConnection = null;
        DataTable dtPrivileges = new DataTable();
        User obuser = new User();
        public frmUserManagements()
        {
            InitializeComponent();
        }
        public frmUserManagements(User obUser)
        {
            InitializeComponent();
            DaUser obDaUser=new DaUser();
            if (obDaUser.isSuperUser(LogInInfo.UserID) == false)
                cboRole.Items.Remove("SuperAdministrator");
            cboRole.SelectedItem = obUser.Role;
            obuser = obUser;
            lblUserName.Tag = obUser;
            txtConfirmPassward.Text = obUser.ConfirmPassword.ToString();
            txtPassward.Text = obUser.Password.ToString();
            txtUserName.Text = obUser.UserName;
            groupBox2.Enabled = true;
        }
        private void frmUserManagements_Load(object sender, EventArgs e)
        {
            try
            {
                formConnection = ConnectionHelper.getConnection();
                if (obuser == null)
                    cboRole.SelectedIndex = 0;
                GetFrmModule();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool validation()
        {
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Please insert User Name");
                return false;
            }
            if (txtConfirmPassward.Text.Trim() != txtPassward.Text.Trim())
            {
                MessageBox.Show("Please Check the password");
                return false;
            }
            return true;
        }
        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if (validation() == false) return;
            if (MessageBox.Show("Are you sure to save the user", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            //User obUser = new User();
            DaUser obDaUser = new DaUser();
            try
            {
                obuser = CreateUserObject();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obuser.UserID = obDaUser.SaveUpdateUser(obuser, formConnection);
                MessageBox.Show("Save Succfull");
                groupBox2.Enabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private User CreateUserObject()
        {
            User obUser = new User();
            try
            {
                obUser.UserID = lblUserName.Tag == null ? 0 : ((User)lblUserName.Tag).UserID;
                obUser.UserName = txtUserName.Text.Trim();
                obUser.Password = GlobalFunctions.Encode(txtPassward.Text.Trim(), GlobalFunctions.CypherText);
                obUser.ConfirmPassword = GlobalFunctions.Encode(txtConfirmPassward.Text.Trim(), GlobalFunctions.CypherText);
                obUser.Role = cboRole.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obUser;
        }
        private void btnDefaultRole_Click(object sender, EventArgs e)
        {
            frmRolePrivilege frmRP = new frmRolePrivilege();
            frmRP.ShowDialog();
        }

        private void cboMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMenu.SelectedValue == null || cboMenu.SelectedValue.GetType() == typeof(DataRowView)) return;
            try
            {
                if (cboMenu.Items.Count > 0)
                    loadDgv();
                if ((string)cboMenu.SelectedValue == "mnuReport")
                    btnReportPrivilege.Enabled = true;
                else
                    btnReportPrivilege.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadDgv()
        {
            if (dgvModule.Columns.Count > 0) dgvModule.Columns.Clear();
            DaUser obDaUser = new DaUser();
            try
            {
                DataGridViewCheckBoxColumn colChkView = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxColumn colChkEdit = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxColumn colChkAdd = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxColumn colChkDelete = new DataGridViewCheckBoxColumn();


                configColumnCheckBox(colChkView, 1, 0, 40, "CanView", "View");
                configColumnCheckBox(colChkEdit, 1, 0, 40, "CanEdit", "Edit");
                configColumnCheckBox(colChkAdd, 1, 0, 40, "CanAdd", "Add");
                configColumnCheckBox(colChkDelete, 1, 0, 40, "CanDelete", "Delete");
                /*
                string[] columns = new string[] { "Modules", "Can View", "Can Edit", "Can Add", "Can delete" };
                dgvModule.setColumnsVisible(columns, true, true);
                dgvModule.Columns.Add("Module", "Module");
                */

                //chkAllView.Checked = false;
                //chkAllEdit.Checked = false;
                //chkAllAdd.Checked = false;
                //chkAllDelete.Checked = false;
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dtPrivileges = obDaUser.getRolePrivilege(cboRole.Text, (string)cboMenu.SelectedValue, formConnection);
                dgvModule.DataSource = dtPrivileges;


                string[] columns = new string[] { "Modules", "CanView", "CanEdit", "CanAdd", "CanDelete" };

                dgvModule.setColumnsVisible(columns, true, true);

                dgvModule.setColumnsReadOnly(new string[] { "Modules" }, true);

                dgvModule.setColumnsDisplayOrder(columns, "Asc");

                dgvModule.Columns["Modules"].Width = dgvModule.Width - colChkView.Width - colChkEdit.Width - colChkAdd.Width - colChkDelete.Width;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void configColumnCheckBox(DataGridViewCheckBoxColumn colchk, int trueValue, int falseValue, int width, string name, string HeaderText)
        {
            colchk.TrueValue = trueValue;
            colchk.FalseValue = falseValue;
            colchk.HeaderText = HeaderText;
            colchk.Width = width;
            colchk.Name = name;
            colchk.DataPropertyName = name;
            dgvModule.Columns.Add(colchk);
        }
        private void GetFrmModule()
        {
            DaUser obDaUser = new DaUser();
            try
            {
                DataTable dt = new DataTable();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dt = obDaUser.GetFrmModule(formConnection);
                cboMenu.DataSource = dt;
                cboMenu.DisplayMember = "FriendlyName";
                cboMenu.ValueMember = "MenuName";
                //cboMenu.SelectedValue=""
                loadDgv();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
        private void loadDgv()
        {
            if (dgvModule.Columns.Count > 0) dgvModule.Columns.Clear();
            DaUser obDaUser = new DaUser();
            try
            {
                DataGridViewCheckBoxColumn colChkView = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxColumn colChkEdit = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxColumn colChkAdd = new DataGridViewCheckBoxColumn();
                DataGridViewCheckBoxColumn colChkDelete = new DataGridViewCheckBoxColumn();


                configColumnCheckBox(colChkView, 1, 0, 40, "CanView", "View");
                configColumnCheckBox(colChkEdit, 1, 0, 40, "CanEdit", "Edit");
                configColumnCheckBox(colChkAdd, 1, 0, 40, "CanAdd", "Add");
                configColumnCheckBox(colChkDelete, 1, 0, 40, "CanDelete", "Delete");

                chkAllView.Checked = false;
                chkAllEdit.Checked = false;
                chkAllAdd.Checked = false;
                chkAllDelete.Checked = false;
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dtPrivileges = obDaUser.getRolePrivilege(cboRole.Text, (string)cboMenu.SelectedValue, formConnection);
                dgvModule.DataSource = dtPrivileges;


                string[] columns = new string[] { "Modules", "CanView", "CanEdit", "CanAdd", "CanDelete" };

                dgvModule.setColumnsVisible(columns, true, true);

                dgvModule.setColumnsReadOnly(new string[] { "Modules" }, true);

                dgvModule.setColumnsDisplayOrder(columns, "Asc");

                dgvModule.Columns["Modules"].Width = dgvModule.Width - colChkView.Width - colChkEdit.Width - colChkAdd.Width - colChkDelete.Width;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */
        private void dgvModule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSavePrivilege_Click(object sender, EventArgs e)
        {
            //DataTable dtUser = new DataTable();
            DaUser obDaUser = new DaUser();
            RolePrivilege obRolePrivilege = null;
            UserPrivilege obUserPrivilege = null;
            SqlTransaction trans = null;
            try
            {
                if (MessageBox.Show("Are you sure to Save ", "Conformation", MessageBoxButtons.YesNo) == DialogResult.No) return;
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                trans = formConnection.BeginTransaction();
                int rowId = dgvModule.Rows.Count;
                for (int i = 0; i < rowId; i++)
                {
                    obRolePrivilege = new RolePrivilege();
                    obRolePrivilege = createRolePrivilege(i);
                    obDaUser.SaveUpdateRolePrivilege(obRolePrivilege, formConnection, trans);

                    obUserPrivilege = new UserPrivilege();
                    obUserPrivilege = createUserPrivilege(i);
                    obDaUser.SaveUpdateUserPrivilege(obUserPrivilege, formConnection, trans);
                }
                trans.Commit();
                MessageBox.Show("Save Successfull");
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }
        private RolePrivilege createRolePrivilege(int rowId)
        {
            RolePrivilege obRolePrivilege = new RolePrivilege();
            try
            {
                obRolePrivilege.Role = cboRole.Text;
                obRolePrivilege.FriendlyName = (string)dgvModule.Rows[rowId].Cells["Modules"].Value;
                obRolePrivilege.CanView = Convert.ToInt32(dgvModule.Rows[rowId].Cells["CanView"].Value);
                obRolePrivilege.CanEdit = Convert.ToInt32(dgvModule.Rows[rowId].Cells["CanEdit"].Value);
                obRolePrivilege.CanAdd = Convert.ToInt32(dgvModule.Rows[rowId].Cells["CanAdd"].Value);
                obRolePrivilege.CanDelete = Convert.ToInt32(dgvModule.Rows[rowId].Cells["CanDelete"].Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obRolePrivilege;
        }
        private UserPrivilege createUserPrivilege(int rowId)
        {
            UserPrivilege obUserPrivilege = new UserPrivilege();
            try
            {
                obUserPrivilege.FriendlyName = (string)dgvModule.Rows[rowId].Cells["Modules"].Value;
                obUserPrivilege.CanView = Convert.ToInt32(dgvModule.Rows[rowId].Cells["CanView"].Value);
                obUserPrivilege.CanEdit = Convert.ToInt32(dgvModule.Rows[rowId].Cells["CanEdit"].Value);
                obUserPrivilege.CanAdd = Convert.ToInt32(dgvModule.Rows[rowId].Cells["CanAdd"].Value);
                obUserPrivilege.CanDelete = Convert.ToInt32(dgvModule.Rows[rowId].Cells["CanDelete"].Value);
                obUserPrivilege.IsEdit = true;
                obUserPrivilege.UserID = obuser.UserID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obUserPrivilege;
        }

        private void btnReportPrivilege_Click(object sender, EventArgs e)
        {
            Report obReport = new Report();
            try
            {
                obReport.ReportName = dgvModule.SelectedRows[0].Cells["Modules"].Value.ToString();
                frmReportPrivilege frm = new frmReportPrivilege(obReport, obuser, false);
                frm.ShowDialog();
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

        private void frmUserManagements_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void txtConfirmPassward_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmUserManagements_Paint(object sender, PaintEventArgs e)
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
