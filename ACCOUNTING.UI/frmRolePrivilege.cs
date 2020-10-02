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
using Accounting.Entity;
using Accounting.DataAccess;

namespace Accounting.UI
{
    public partial class frmRolePrivilege : Form
    {
        SqlConnection formConnection = null;
        DataTable dtPrivileges = new DataTable();
        User obuser = new User();
        public frmRolePrivilege()
        {
            InitializeComponent();
        }

        private void frmRolePrivilege_Load(object sender, EventArgs e)
        {
            try
            {
                formConnection = ConnectionHelper.getConnection();
                cboRole.SelectedIndex = 0;
                GetFrmModule();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtUser = new DataTable();
            DaUser obDaUser = new DaUser();
            RolePrivilege obRolePrivilege = null;
            UserPrivilege obUserPrivilege = null;
            SqlTransaction trans = null;
            try
            {
                if (MessageBox.Show("Are you sure to Save ", "Conformation", MessageBoxButtons.YesNo) == DialogResult.No) return;
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dtUser = obDaUser.getUser(cboRole.Text, formConnection);
                trans = formConnection.BeginTransaction();
                int userCount = dtUser.Rows.Count;
                int rowId = dgvModule.Rows.Count;
                for (int i = 0; i < rowId; i++)
                {
                    obRolePrivilege = new RolePrivilege();
                    obRolePrivilege = createRolePrivilege(i);
                    obDaUser.SaveUpdateRolePrivilege(obRolePrivilege, formConnection, trans);

                    obUserPrivilege = new UserPrivilege();
                    obUserPrivilege = createUserPrivilege(i);
                    for (int j = 0; j < userCount; j++)
                    {
                        obUserPrivilege.UserID = dtUser.Rows[j].Field<int>("UserID");
                        obDaUser.SaveUpdateUserPrivilege(obUserPrivilege, formConnection, trans);
                    }
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
                //obUserPrivilege.Role = cboRole.Text;
                obUserPrivilege.FriendlyName = (string)dgvModule.Rows[rowId].Cells["Modules"].Value;
                obUserPrivilege.CanView = Convert.ToInt32(dgvModule.Rows[rowId].Cells["CanView"].Value);
                obUserPrivilege.CanEdit = Convert.ToInt32(dgvModule.Rows[rowId].Cells["CanEdit"].Value);
                obUserPrivilege.CanAdd = Convert.ToInt32(dgvModule.Rows[rowId].Cells["CanAdd"].Value);
                obUserPrivilege.CanDelete = Convert.ToInt32(dgvModule.Rows[rowId].Cells["CanDelete"].Value);
                obUserPrivilege.IsEdit = true;
                obUserPrivilege.UserID = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obUserPrivilege;
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

        private void btnReportPrivilege_Click(object sender, EventArgs e)
        {
            Report obReport = new Report();
            try
            {
                obuser.Role = (string)cboRole.SelectedItem;
                obReport.ReportName = dgvModule.SelectedRows[0].Cells["Modules"].Value.ToString();
                frmReportPrivilege frm = new frmReportPrivilege(obReport, obuser, true);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //frmReportPrivilege frm = new frmReportPrivilege();
            //frm.ShowDialog();
        }

        private void chkAllView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int row = dgvModule.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    dgvModule.Rows[i].Cells["CanView"].Value = chkAllView.Checked ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void chkAllEdit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int row = dgvModule.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    dgvModule.Rows[i].Cells["CanEdit"].Value = chkAllEdit.Checked ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void chkAllAdd_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int row = dgvModule.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    dgvModule.Rows[i].Cells["CanAdd"].Value = chkAllAdd.Checked ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void chkAllDelete_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int row = dgvModule.Rows.Count;
                for (int i = 0; i < row; i++)
                {
                    dgvModule.Rows[i].Cells["CanDelete"].Value = chkAllDelete.Checked ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRolePrivilege_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void frmRolePrivilege_Paint(object sender, PaintEventArgs e)
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
