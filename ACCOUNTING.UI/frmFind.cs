using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Entity;
using Accounting.DataAccess;
using System.Data.SqlClient;
using Accounting.Utility;

namespace Accounting.UI
{
    public partial class frmFind : Form
    {
        private SqlConnection formConnection;
        private DataTable dtOrder = new DataTable();
        public Order_Master obOrderNo;

        public frmFind()
        {
            InitializeComponent();
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            formConnection = ConnectionHelper.getConnection();
            dateTimePicker1.Value = new DateTime(2008, 1, 1);
            txtOrderNo.Focus();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //txtOrderNo_KeyDown(null, null);
            searchSelectedCustomer();
        }

        private void searchSelectedCustomer()
        {
            string OrderNo = "";
            DateTime eDate = DateTime.Now;
            DateTime sDate = DateTime.Now;
            sDate = dateTimePicker1.Value.Date;
            eDate = dateTimePicker2.Value.Date;
            OrderNo += txtOrderNo.Text.ToString();
            DaOrder obDaOrder=new DaOrder();
            if (formConnection.State != ConnectionState.Open)
                formConnection.Open();
            dtOrder = obDaOrder.searchSelectedCustomer(formConnection, sDate, eDate, OrderNo);
            dgvCustomer.DataSource = dtOrder;
            dgvCustomer.setColumnsVisible(false, "OrderMID", "Orderdate");
            dgvCustomer.setColumnsDisplayOrder(new string[] { "OrderNo", "CustomerName" });
            dgvCustomer.setColumnsReadOnly(true, "OrderNo", "CustomerName");

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string OrderNo = "";
                OrderNo = dgvCustomer.Rows[dgvCustomer.CurrentRow.Index].Cells["OrderNo"].Value.ToString();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                obOrderNo = new DaOrder().GetOrder_Master(formConnection, OrderNo);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Order_Master ReturnOrderNo()
        {
            return obOrderNo;
        }

        private void txtOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void frmFind_Paint(object sender, PaintEventArgs e)
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

        private void frmFind_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            dgvCustomer_CellDoubleClick(sender, null);
        }
    }
}
