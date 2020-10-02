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
    public partial class frmFindSalesReturn : Form
    {
        private SqlConnection formConnection = null;
        public SalesReturn obSalesReturn;
        public frmFindSalesReturn()
        {
            InitializeComponent();
        }

        private void frmFindSalesReturn_Load(object sender, EventArgs e)
        {
            formConnection = ConnectionHelper.getConnection();
            dtpFrom.Value = new DateTime(2008, 1, 1);
            txtInvoiceNo.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string InvoiceNo = "";
            DateTime sDate, eDate;
            DaSalesReturn obDaSalesReturn = new DaSalesReturn();
            DataTable dt = new DataTable();
            try
            {
                InvoiceNo = txtInvoiceNo.Text.ToString();
                sDate = dtpFrom.Value.Date;
                eDate = dtpTo.Value.Date;
                dt = obDaSalesReturn.searchSalesReturn(formConnection, InvoiceNo, sDate, eDate);
                dgvSalesreturn.DataSource = dt;
                dgvSalesreturn.setColumnsVisible(false, "ReturnMID");
                dgvSalesreturn.setColumnsWidth(dgvSalesreturn.Width / 2 - 14);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Search " + ex.Message);
            }
        }

        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(null, null);
        }

        private void dgvSalesreturn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1)
                return;
            btnOK_Click(null, null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int ReturnMID = 0;
            DaSalesReturn obDaSalesReturn = new DaSalesReturn();
            try
            {
                if (dgvSalesreturn.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No rows selected " + Environment.NewLine + "Please select row");
                    return;
                }
                ReturnMID = Convert.ToInt32(dgvSalesreturn.SelectedRows[0].Cells["ReturnMID"].Value);
                obSalesReturn = obDaSalesReturn.getSalesreturn(formConnection, ReturnMID);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured due to " + ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            obSalesReturn = null;
            this.Close();
        }

        private void frmFindSalesReturn_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void frmFindSalesReturn_Paint(object sender, PaintEventArgs e)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {


        }

        private void dgvSalesreturn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
