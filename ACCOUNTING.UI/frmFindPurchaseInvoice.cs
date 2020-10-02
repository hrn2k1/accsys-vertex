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
using Accounting.Entity;
using Accounting.Utility;

namespace Accounting.UI
{
    public partial class frmFindPurchaseInvoice : Form
    {
        private DataTable dtPurchaseInvoice = null;
        private SqlConnection conn = ConnectionHelper.getConnection();
        public Purchases_Invoice obPurchaseInvoics;
        public frmFindPurchaseInvoice()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                sarchSelectedPurchaseInvoice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to find such Invoice " + ex.Message);
            }
        }


        private void sarchSelectedPurchaseInvoice()
        {
            try
            {
                string InvNo = "";
                DateTime sDate, eDate;
                InvNo += txtInvoiceNo.Text;
                sDate = dateTimePicker1.Value.Date;
                eDate = dateTimePicker2.Value.Date;
                DaPurchaseInvoice obPurchaseInvoice = new DaPurchaseInvoice();
                dtPurchaseInvoice = obPurchaseInvoice.searchSelectedPurchaseInvoice(conn, sDate, eDate, InvNo);
                ctlDGVPurchaseInvoice.DataSource = dtPurchaseInvoice;
                ctlDGVPurchaseInvoice.setColumnsVisible(false, "InvoiceID");
                ctlDGVPurchaseInvoice.setColumnsWidth(ctlDGVPurchaseInvoice.Width / 2 - 13);
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

        private void ctlDGVPurchaseInvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DaPurchaseInvoice obDaPurchaseInvoice = new DaPurchaseInvoice();
            try
            {
                if (e.RowIndex == -1) return;
                int InvoiceID = 0;
                InvoiceID = Convert.ToInt32(ctlDGVPurchaseInvoice.Rows[e.RowIndex].Cells["InvoiceID"].Value);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                obPurchaseInvoics = new DaPurchaseInvoice().getPurchaseInvoice(conn, InvoiceID);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to send Invoice " + ex.Message);
            }
        }

        private void frmFindPurchaseInvoice_Paint(object sender, PaintEventArgs e)
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            DaPurchaseInvoice obDaPurchaseInvoice = new DaPurchaseInvoice();
            try
            {
                if (ctlDGVPurchaseInvoice.SelectedRows.Count  == 0) return;
                int InvoiceID = 0;
                InvoiceID = Convert.ToInt32(ctlDGVPurchaseInvoice.Rows[ctlDGVPurchaseInvoice.SelectedRows[0].Index].Cells["InvoiceID"].Value);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                obPurchaseInvoics = new DaPurchaseInvoice().getPurchaseInvoice(conn, InvoiceID);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to send Invoice " + ex.Message);
            }
        }

        private void frmFindPurchaseInvoice_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Focus();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }

        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }

        private void ctlDGVPurchaseInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }
    }
}
