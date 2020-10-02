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
    public partial class frmDepartment : Form
    {
        SqlConnection formConnection = null;
        DataTable dtDept = new DataTable();
        public frmDepartment()
        {
            InitializeComponent();
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            try
            {
                formConnection = ConnectionHelper.getConnection();
                loadDept();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }

        }
        private void loadDept()
        {
            try
            {
                DaTeam obDaTeam = new DaTeam();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dtDept = obDaTeam.loadDepartment(formConnection);
                dgvDepartment.DataSource = dtDept;
                dgvDepartment.setColumnsVisible(false, "DeptID", "CompanyID");
                dgvDepartment.setColumnsWidth(dgvDepartment.Width - 28);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private bool validation()
        {
            if (txtDepartment.Text.Trim() == "")
            {
                MessageBox.Show("Please insert a department");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation() == false) return;
            if (MessageBox.Show("are you sure to save the department", "Conformation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            try
            {
                Dadepartment obDaDept = new Dadepartment();
                Department obDept = new Department();
                obDept = createDept();
                obDaDept.SaveUpdateDept(obDept, formConnection);
                resetdept();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }
        private Department createDept()
        {
            Department obDept = new Department();
            try
            {
                obDept.DeptID = txtDepartmentID.Text == "" ? 0 : Convert.ToInt32(txtDepartmentID.Text);
                obDept.DeptName = txtDepartment.Text;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obDept;
        }
        private void resetdept()
        {
            try
            {
                loadDept();
                txtDepartment.Text = "";
                txtDepartmentID.Text = "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void dgvDepartment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            try
            {
                txtDepartment.Text = dgvDepartment.Rows[e.RowIndex].Cells["DeptName"].Value.ToString();
                txtDepartmentID.Text = dgvDepartment.Rows[e.RowIndex].Cells["DeptID"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDepartmentID.Text == "")
            {
                MessageBox.Show("No Department selected for delete" + Environment.NewLine + "Please select a department to delete");
                return;
            }
            if (MessageBox.Show("are you sure to delete the department", "Conformation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            try
            {
                int deptId = Convert.ToInt32(txtDepartmentID.Text);
                Dadepartment obDaDept = new Dadepartment();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDaDept.deleteDept(formConnection, deptId);
                resetdept();
                MessageBox.Show("Delete successfull");
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

        private void frmDepartment_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void frmDepartment_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                FormColorClass.ColorForm(this, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }
    }
}
