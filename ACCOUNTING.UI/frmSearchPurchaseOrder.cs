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
    public partial class frmSearchPurchaseOrder : Form
    {
        SqlConnection conn = ConnectionHelper.getConnection();
       private DataTable dtOrder = new DataTable();
       private int SupplierPurchaseAccount = 0;
       public Order_Master obOrderNo;

        public frmSearchPurchaseOrder()
        {
            InitializeComponent();
        }

        public frmSearchPurchaseOrder(int SupplierPurchaseAcc)
        {
            InitializeComponent();
            SupplierPurchaseAccount = SupplierPurchaseAcc;
        }


        private void searchSelectedOrder()
        {
            try
            {
                string OrderNo = "";
                DateTime eDate = DateTime.Now;
                DateTime sDate = DateTime.Now;
                sDate = dateTimePicker1.Value.Date;
                eDate = dateTimePicker2.Value.Date;
                OrderNo += txtOrderNo.Text.ToString();
                DaPurchaseInvoice obDaPurchaseInvoice = new DaPurchaseInvoice();
                dtOrder = obDaPurchaseInvoice.searchSelectedOrder(conn, sDate, eDate, OrderNo, SupplierPurchaseAccount);
                ctlDGVPurchaseOrder.DataSource = dtOrder;
                ctlDGVPurchaseOrder.setColumnsVisible(false, "OrderMID", "Orderdate");
                ctlDGVPurchaseOrder.setColumnsDisplayOrder(new string[] { "OrderNo", "SupplierName" });
                ctlDGVPurchaseOrder.setColumnsReadOnly(true, "OrderNo", "SupplierName");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                searchSelectedOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load Order " + ex.Message);
            }
        }

        public Order_Master ReturnOrderNo()
        {
            return obOrderNo;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlDGVPurchaseOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                string OrderNo = "";
                OrderNo = ctlDGVPurchaseOrder.Rows[e.RowIndex].Cells["OrderNo"].Value.ToString();
                obOrderNo = new DaOrder().GetOrder_Master(conn, OrderNo);
                this.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void txtOrderNo_Enter(object sender, EventArgs e)
        {

            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtOrderNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
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

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void frmSearchPurchaseOrder_Paint(object sender, PaintEventArgs e)
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

        private void ctlDGVPurchaseOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }

        private void frmSearchPurchaseOrder_Load(object sender, EventArgs e)
        {

        }

    }
}
