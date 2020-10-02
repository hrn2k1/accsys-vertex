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
    public partial class frmsearchSalesOrder : Form
    {
        private DataTable dtOrder = new DataTable();
        public Order_Master obOrderNo;
        private SqlConnection formConnection = null;
        private int CustomerSalesAccount = 0;

        public frmsearchSalesOrder()
        {
            InitializeComponent();
        }

        public frmsearchSalesOrder(int CustomerSalesAcc)
        {
            InitializeComponent();
            CustomerSalesAccount = CustomerSalesAcc;
        }


        private void frmsearchSalesOrder_Load(object sender, EventArgs e)
        {
            formConnection = ConnectionHelper.getConnection();
        }

        private void txtOrderNo_KeyDown(object sender, KeyEventArgs e)
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
                MessageBox.Show("Unable to load Order " + ex.Message);
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
                DaSalesInvoice obDaSalesInvoice = new DaSalesInvoice();
                dtOrder = obDaSalesInvoice.searchSelectedOrder(formConnection, sDate, eDate, OrderNo, CustomerSalesAccount);
                dgvCustomer.DataSource = dtOrder;
                dgvCustomer.setColumnsVisible(false, "OrderMID", "Orderdate");
                dgvCustomer.setColumnsDisplayOrder(new string[] { "OrderNo", "CustomerName" });
                dgvCustomer.setColumnsReadOnly(true, "OrderNo", "CustomerName");
                dgvCustomer.setColumnsWidth(dgvCustomer.Width / 2 - 13);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            btnOK_Click(null, null);
        }

        public Order_Master ReturnOrderNo()
        {
            return obOrderNo;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmsearchSalesOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void dgvCustomer_Enter(object sender, EventArgs e)
        {
            btnOK.Focus();
        }

        private void dateTimePicker1_Enter(object sender, EventArgs e)
        {
            txtOrderNo.Focus();
        }

        private void dateTimePicker2_Enter(object sender, EventArgs e)
        {
            txtOrderNo.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomer.SelectedRows.Count == 0)
                {
                    MessageBox.Show("No row selected");
                    return;
                }
                string OrderNo = "";
                OrderNo = dgvCustomer.Rows[dgvCustomer.SelectedRows[0].Index].Cells["OrderNo"].Value.ToString();
                obOrderNo = new DaOrder().GetOrder_Master(formConnection, OrderNo);
                this.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void frmsearchSalesOrder_Paint(object sender, PaintEventArgs e)
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

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

        private void dgvCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
