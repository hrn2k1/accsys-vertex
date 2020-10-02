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
    public partial class frmSearchExportBill : Form
    {
        public frmSearchExportBill()
        {
            InitializeComponent();
        }

        private SqlConnection formCon = null;
        private int purchase = -1;
        private int realize = -1;
       
        private DataTable dtBills = new DataTable();
        public ExportBill SelectedExportBill = null;

        public void ShowDialog(int Purchase, int Realized)
        {
            try
            {
                this.purchase = Purchase;
                this.realize = Realized;
                
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedExportBill = null;
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                string bN = string.Empty;
                string cols = " BillID,TypeNo,BillAmount,BillDate, PurchaseDate,RealisedDate ";
                if (chkBillNo.Checked) bN = txtBillNo.Text.Trim();
                else bN = "";
                if (chkBillDate.Checked)
                {
                    dtBills = new DaExportBill().getExportBills(formCon, cols, bN, dtpStart.Value.Date, dtpEnd.Value.Date,realize,purchase);

                }
                else
                {
                    dtBills = new DaExportBill().getExportBills(formCon, cols, bN, realize, purchase);
                }
                ctldgvExBill.DataSource = dtBills;
                ctldgvExBill.Columns["BillID"].Visible = false;
                ctldgvExBill.setColumnsWidth(new string[] { "TypeNo", "BillDate", "PurchaseDate", "RealisedDate" }, 150, 70,70,70);

                ctldgvExBill.setColumnsFormat(new string[] { "BillAmount", "BillDate", "PurchaseDate", "RealisedDate" }, "0.00", "dd/MM/yyyy", "dd/MM/yyyy", "dd/MM/yyyy");
                ctldgvExBill.Columns["BillAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                if (sender == null) throw ex;
                else
                    MessageBox.Show(ex.Message);
            }
        }

        private void frmSearchExportBill_Load(object sender, EventArgs e)
        {
            try
            {
                formCon = ConnectionHelper.getConnection();
                btnShow_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedExportBill = new DaExportBill().getExportBill(formCon, Convert.ToInt32(ctldgvExBill.SelectedRows[0].Cells["BillID"].Value));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
           
            dtpStart.Enabled = chkBillDate.Checked;
            dtpEnd.Enabled = chkBillDate.Checked;
            txtBillNo.Enabled = chkBillNo.Checked;
        }

        private void ctldgvExBill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            btnOk_Click(null, null);
        }

        private void frmSearchExportBill_Paint(object sender, PaintEventArgs e)
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

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void dtpEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void chkBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnShow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void ctldgvExBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void chkRealized_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnOk_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }
    }
}
