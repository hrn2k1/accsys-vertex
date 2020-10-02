using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Accounting.DataAccess;
using Accounting.Utility;
using Accounting.Entity;

namespace Accounting.UI
{
    public partial class frmSection : Form
    {
        private DataTable dtSection = new DataTable();
        private SqlConnection formConnection = null;
        public frmSection()
        {
            InitializeComponent();
        }

        private void frmSection_Load(object sender, EventArgs e)
        {
            try
            {
                formConnection = ConnectionHelper.getConnection();
                loadSection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error " + ex.Message);
            }

        }
        private void loadSection()
        {
            try
            {
                DaInventoryRequisition obDaReq = new DaInventoryRequisition();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dtSection = obDaReq.loadSection(formConnection);
                dgvSection.DataSource = dtSection;
                dgvSection.setColumnsVisible(false, "SectionID");
                dgvSection.setColumnsWidth(dgvSection.Width / 2 - 1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void resetSection()
        {
            try
            {
                txtSectionDescription.Text = "";
                txtsectionID.Text = "0";
                txtSectionName.Text = "";
                loadSection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool validation()
        {
            if (txtSectionName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter the section Name");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation() == false)
            {
                txtSectionName.Focus();
                return;
            }
            try
            {
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                DaSection obDaSection = new DaSection();
                Section obSection = new Section();
                obSection = createSection();
                obDaSection.SaveUpdateSection(obSection, formConnection);
                resetSection();
                MessageBox.Show("Save Successfull");
                txtSectionName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private Section createSection()
        {
            Section obSectiob = new Section();
            try
            {
                obSectiob.SectionID = txtsectionID.Text == "0" ? -1 : Convert.ToInt32(txtsectionID.Text);
                obSectiob.Name = txtSectionName.Text;
                obSectiob.Description = txtSectionDescription.Text.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obSectiob;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtsectionID.Text == "0")
            {
                MessageBox.Show("Please select a section to delete");
                return;
            }
            if (MessageBox.Show("Are you sure to delete the section ", "Conformation", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            try
            {
                int SectionId = Convert.ToInt32(txtsectionID.Text);
                DaSection obDaSection = new DaSection();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obDaSection.deleteSection(formConnection, SectionId);
                resetSection();
                MessageBox.Show("delete Successfull");
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

        private void dgvSection_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1) return;
            try
            {
                txtSectionName.Text = dgvSection.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtSectionDescription.Text = dgvSection.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                txtsectionID.Text = dgvSection.Rows[e.RowIndex].Cells["SectionID"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSectionName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            SelectNextControl((Control)sender, true, true, true, true);
        }

        private void frmSection_Paint(object sender, PaintEventArgs e)
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

        private void frmSection_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
