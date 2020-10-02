using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Utility;
using Accounting.DataAccess;
using System.Data.SqlClient;
using Accounting.Entity;
using System.Collections;

namespace Accounting.UI
{
    public partial class frmReportPrivilege : Form
    {
        DataTable _dtPrivileges = new DataTable();
        DataTable dtMenu = new DataTable();
        SqlConnection formConnection = null;
        Report obReport = new Report();
        User obuser = new User();
        RoleReportPrivilege obRoleReportPrivilege = new RoleReportPrivilege();
        UserReportPrivilege obUserReportPrivilege = new UserReportPrivilege();
        //string strRole = "";
        bool _blIsDefault = false;
        public frmReportPrivilege()
        {
            InitializeComponent();
        }
        public frmReportPrivilege(Report obreport, User obUser, bool isDefault)
        {
            InitializeComponent();
            obReport = obreport;
            _blIsDefault = isDefault;
            obuser = obUser;
        }

        private void frmReportPrivilege_Load(object sender, EventArgs e)
        {
            formConnection = ConnectionHelper.getConnection();
            //cboMenu.SelectedIndex = 0;
            LoadReportMenu();
        }
        private void LoadReportMenu()
        {
            DaReportPrivilege obDaReportPrivilege = new DaReportPrivilege();
            try
            {
                dtMenu = obDaReportPrivilege.getMenuName("all", formConnection);
                cboMenu.DataSource = dtMenu;
                //ArrayList list = obDaReportPrivilege.getMenuName("all");
                cboMenu.DisplayMember = "FriendlyName";
                cboMenu.ValueMember = "FriendlyName";
                if (obReport != null)
                {
                    cboMenu.SelectedValue = obReport.ReportName;
                    LoadDgv();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void frmReportPrivilege_Paint(object sender, PaintEventArgs e)
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

        private void cboMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMenu.SelectedValue == null || cboMenu.SelectedValue.GetType() == typeof(DataRowView)) return;
            LoadDgv();
        }
        private void LoadDgv()
        {
            DaReportPrivilege obDaReportPrivilege = new DaReportPrivilege();
            try
            {
                if (dgvModule.Columns.Count != 0) dgvModule.Columns.Clear();
                DataGridViewCheckBoxColumn colchkView = new DataGridViewCheckBoxColumn();



                configColumnCheckBox(colchkView, 1, 0, 40, "CanView", "View");

                chkAllView.Checked = false;


                if (_blIsDefault)
                    _dtPrivileges = obDaReportPrivilege.getRoleReportPrivilege(obuser.Role, (string)cboMenu.SelectedValue, formConnection);
                else
                    _dtPrivileges = obDaReportPrivilege.getUserReportPrivilege(obuser.UserID, (string)cboMenu.SelectedValue, formConnection);

                dgvModule.DataSource = _dtPrivileges;


                string[] columns = new string[] { "ReportName", "CanView" };

                dgvModule.setColumnsVisible(columns, true, true);

                dgvModule.setColumnsReadOnly(new string[] { "ReportName" }, true);

                dgvModule.setColumnsDisplayOrder(columns, "Asc");

                dgvModule.Columns["ReportName"].Width = dgvModule.Width - colchkView.Width - 20;

                //if (!IsEdit)
                //    fillCheckBoxes();
                //chkAllEmp.Visible = true;
                //chkAllEmp.Checked = false;
            }
            catch (Exception ex)
            {
                //new ExceptionAgent(ex).SaveError();
                MessageBox.Show(ex.Message);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            DaReportPrivilege obDaReportPrivilege = new DaReportPrivilege();
            try
            {
                int row = dgvModule.RowCount;
                ArrayList list = new ArrayList();
                if (_blIsDefault)
                {
                    for (int i = 0; i < row; i++)
                    {
                        obRoleReportPrivilege = new RoleReportPrivilege();
                        obRoleReportPrivilege.Role = obuser.Role;
                        obRoleReportPrivilege.RbName = (string)dgvModule.Rows[i].Cells["RbName"].Value;
                        obRoleReportPrivilege.CanView = Convert.ToInt32(dgvModule.Rows[i].Cells["CanView"].Value);
                        obRoleReportPrivilege.IsEdit = true;
                        list.Add(obRoleReportPrivilege);
                        obDaReportPrivilege.SaveUpdateRole(obRoleReportPrivilege, formConnection);
                        //obDaReportPrivilege.SaveUpdateRole(list);
                    }

                   
                }
                else
                {
                    for (int i = 0; i < row; i++)
                    {
                        obUserReportPrivilege = new UserReportPrivilege();
                        obUserReportPrivilege.UserID = obuser.UserID;
                        obUserReportPrivilege.RbName = (string)dgvModule.Rows[i].Cells["RbName"].Value;
                        obUserReportPrivilege.CanView = Convert.ToInt32(dgvModule.Rows[i].Cells["CanView"].Value);
                        obUserReportPrivilege.IsEdit = true;
                        list.Add(obUserReportPrivilege);

                        obDaReportPrivilege.SaveUpdateUserReportPrivilege(obUserReportPrivilege, formConnection);
                    }
                }
               
                MessageBox.Show("Updated successfully");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmReportPrivilege_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
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
    }
}
