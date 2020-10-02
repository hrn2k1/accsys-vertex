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
    public partial class frmSearch_Purchase_Return : Form
    {
        SqlConnection conn = ConnectionHelper.getConnection();
        DataTable dtPurchaseReturn = null;
        public PurchaseReturn obPurchaseReturn = null;
        public frmSearch_Purchase_Return()
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
                string RetnNo = "";
                DateTime sDate, eDate;
                RetnNo += txtReturnNo.Text;
                sDate = DTPST.Value.Date;
                eDate = DTPED.Value.Date;
                DaPurchaseReturn obPurchaseReturn = new DaPurchaseReturn();
                dtPurchaseReturn = obPurchaseReturn.searchSelectedPurchaseReturn(conn, sDate, eDate, RetnNo);
                ctlDGVPurchaseReturn.DataSource = dtPurchaseReturn;
                ctlDGVPurchaseReturn.setColumnsVisible(false, "PurchaseInvoiceID","ReturnMID");
                ctlDGVPurchaseReturn.setColumnsWidth(ctlDGVPurchaseReturn.Width / 2 - 13);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void ctlDGVPurchaseReturn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DaPurchaseReturn obDaPurchaseReturn = new DaPurchaseReturn();
            if (e.RowIndex == -1) return;
            btnOK_Click(null, null);
            //try
            //{
            //    int InvoiceID = 0;
            //    InvoiceID = Convert.ToInt32(ctlDGVPurchaseReturn.Rows[e.RowIndex].Cells["ReturnMID"].Value);
            //    if (conn.State != ConnectionState.Open)
            //        conn.Open();
            //    obPurchaseReturn = new DaPurchaseReturn().getPurchaseReturn(conn, InvoiceID);
            //    this.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Unable to send Invoice " + ex.Message);
            //}
        
        }
        private void frmSearch_Purchase_Return_Paint(object sender, PaintEventArgs e)
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
            DaPurchaseReturn obDaPurchaseReturn = new DaPurchaseReturn();
            try
            {
                if (ctlDGVPurchaseReturn.SelectedRows.Count == 0) return;
                int InvoiceID = 0;
                InvoiceID = Convert.ToInt32(ctlDGVPurchaseReturn.Rows[ctlDGVPurchaseReturn.SelectedRows[0].Index].Cells["ReturnMID"].Value);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                obPurchaseReturn = new DaPurchaseReturn().getPurchaseReturn(conn, InvoiceID);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to send Invoice " + ex.Message);
            }
        
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmSearch_Purchase_Return_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(conn);
        }

        private void frmSearch_Purchase_Return_Load(object sender, EventArgs e)
        {

        }
    }
}
