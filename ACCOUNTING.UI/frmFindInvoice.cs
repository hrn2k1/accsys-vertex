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

namespace Accounting.Entity
{
    public partial class frmFindInvoice : Form
    {
        private SqlConnection formConnection = null;
        private DataTable dtInvoice = null;
        public Sales_Invoice obInvoice;
        public Purchases_Invoice obPurchaseInvoics;

        public frmFindInvoice()
        {
            InitializeComponent();
        }

        private void frmFindInvoice_Load(object sender, EventArgs e)
        {
            formConnection = ConnectionHelper.getConnection();
            dtpFrom.Value = new DateTime(2008, 1, 1);
        }

        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to find such Invoice " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                sarchSelectedInvoice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to find such Invoice " + ex.Message);
            }
        }
        private void sarchSelectedInvoice()
        {
            try
            {
                string InvNo = "";
                DateTime sDate, eDate;
                InvNo += txtInvoiceNo.Text;
                sDate = dtpFrom.Value.Date;
                eDate = dtpTo.Value.Date;
                DaSalesInvoice obSalesInvoice = new DaSalesInvoice();
                dtInvoice = obSalesInvoice.searchSelectedInvoice(formConnection, sDate, eDate, InvNo);
                dgvInvoice.DataSource = dtInvoice;
                dgvInvoice.setColumnsVisible(false, "InvoiceID");
                dgvInvoice.setColumnsWidth(dgvInvoice.Width / 2 - 13);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFindInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void dgvInvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            btnOK_Click(null, null);
        }

        private void dtpFrom_Enter(object sender, EventArgs e)
        {
            txtInvoiceNo.Focus();
        }

        private void dtpTo_Enter(object sender, EventArgs e)
        {
            txtInvoiceNo.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DaSalesInvoice obDaSalesInvoice = new DaSalesInvoice();
            try
            {
                if (dgvInvoice.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please Select a row");
                    return;
                }
                int InvoiceID = 0;
                InvoiceID = Convert.ToInt32(dgvInvoice.Rows[dgvInvoice.SelectedRows[0].Index].Cells["InvoiceID"].Value);
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obInvoice = new DaSalesInvoice().getSalesInvoice(formConnection, InvoiceID);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to send Invoice " + ex.Message);
            }
        }

        private void dgvInvoice_Enter(object sender, EventArgs e)
        {
            btnOK.Focus();
        }

        private void frmFindInvoice_Paint(object sender, PaintEventArgs e)
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

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void dtpTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void dgvInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender,true,true,true,true); 
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true,true, true); 
        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void dgvInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
