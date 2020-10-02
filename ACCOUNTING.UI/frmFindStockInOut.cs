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
    public partial class frmFindStockInOut : Form
    {
        private SqlConnection formConnection = null;
        public Stock_InOut_Master obInOutMaster = new Stock_InOut_Master();
        public frmFindStockInOut()
        {
            InitializeComponent();
        }

        private void frmFindStockInOut_Load(object sender, EventArgs e)
        {
            formConnection = ConnectionHelper.getConnection();
            txtVoucharNo.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime sDate, eDate;
            string VoucharNo;
            DaStockInOut obInOut = new DaStockInOut();
            try
            {
                VoucharNo = txtVoucharNo.Text;
                sDate = dtpFrom.Value.Date;
                eDate = dtpTo.Value.Date;
                dgvStockInOut.DataSource = obInOut.searchStockInOut(formConnection, VoucharNo, sDate, eDate);
                dgvStockInOut.setColumnsVisible(false, "StockMID");
                dgvStockInOut.setColumnsWidth(new string[] { "VoucherNo", "TransDate", "TransType" }, 100, 79, 200);
                dgvStockInOut.Columns["TransDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                //dgvStockInOut.setColumnsWidth(dgvStockInOut.Width / 2 - 14);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured due to " + ex.Message);
            }
        }

        private void txtVoucharNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(null, null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvStockInOut.Rows.Count == 0) return;
            int StockMID = 0;
            try
            {
                StockMID = Convert.ToInt32(dgvStockInOut.Rows[dgvStockInOut.SelectedRows[0].Index].Cells["StockMID"].Value);
                DaStockInOut obIO = new DaStockInOut();
                obInOutMaster = obIO.getStockInOutMaster(formConnection, StockMID);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured due to " + ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            obInOutMaster = null;
            this.Close();
        }

        private void ctlDaraGridView1_Enter(object sender, EventArgs e)
        {
            btnOk.Focus();
        }

        private void dtpFrom_Enter(object sender, EventArgs e)
        {
            txtVoucharNo.Focus();
        }

        private void dtpTo_Enter(object sender, EventArgs e)
        {
            txtVoucharNo.Focus();
        }

        private void frmFindStockInOut_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
            //if(sender.Equals(this))
            //obInOutMaster = null;
        }

        private void dgvStockInOut_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex ==-1) return;
            btnOK_Click(null, null);
        }

        private void frmFindStockInOut_Paint(object sender, PaintEventArgs e)
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
