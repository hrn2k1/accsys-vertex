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
using System.Collections;

namespace Accounting.UI
{
    public partial class frmSearchOrder : Form
    {
        public frmSearchOrder()
        {
            InitializeComponent();
        }

        #region Field
        int numCustomerSupplierID;
        DateTime dtStartDate;
        DateTime dtEndDate;
        string strOrderNo;
        string strOrderType;
        bool ShowCheckBox = false;
        ArrayList arOrderIDs=null;
        DataTable dtOrders = new DataTable();
        SqlConnection formConn = null;
        #endregion

        #region Properties
        public int CustomerID
        {
            get { return numCustomerSupplierID; }
            set { numCustomerSupplierID = value; }
        }
        public int SupplierID
        {
            get { return numCustomerSupplierID; }
            set { numCustomerSupplierID = value; }
        }

        public DateTime StartDate
        {
            get { return dtStartDate; }
            set { dtStartDate = value; }
        }
        public DateTime EndDate
        {
            get { return dtEndDate; }
            set { dtEndDate = value; }
        }
        public string OrderNo
        {
            get { return strOrderNo; }
            set { strOrderNo = value; }
        }
        public string OrderType
        {
            get { return strOrderType; }
            set { strOrderType = value; }
        }

        public ArrayList OrderIDs
        {
            get { return arOrderIDs; }
            set { arOrderIDs = value; }
        }
        #endregion

        private void loadCustomerSupplier()
        {
            try
            {
                int ledgerType = strOrderType == "Purchase Order" ? 3 : 2;
                cboCustomerSupplier.DataSource = new DaLedger().GetLadgers(formConn, ledgerType);
                cboCustomerSupplier.DisplayMember = "LedgerName";
                cboCustomerSupplier.ValueMember = "LedgerID";
                cboCustomerSupplier.SelectedValue = numCustomerSupplierID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ShowDialog(int CustomerOrSupplierID,string Ordertype)
        {
            this.numCustomerSupplierID = CustomerOrSupplierID;
            this.strOrderType = Ordertype;
            chkCustSupp.Text = Ordertype == "Purchase Order" ? "Supplier" : "Customer";
            this.ShowDialog();
        }
        public void ShowDialog(int CustomerOrSupplierID, string Ordertype,bool ShowCheckBox)
        {
            this.numCustomerSupplierID = CustomerOrSupplierID;
            this.strOrderType = Ordertype;
            chkCustSupp.Text = Ordertype == "Purchase Order" ? "Supplier" : "Customer";
            this.ShowCheckBox = ShowCheckBox;
            this.ShowDialog();
        }
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk=(CheckBox)sender;
            if (sender.Equals(chkCustSupp))
            {
                cboCustomerSupplier.Enabled = chk.Checked;
            }
            else if (sender.Equals(chkDate))
            {
                dtpStartDate.Enabled = chk.Checked;
                dtpEndDate.Enabled = chk.Checked;
            }
            else if (sender.Equals(chkOrderNo))
            {
                txtOrderNo.Enabled = chk.Checked;
            }

            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtStartDate, dtEndDate;
                string Where = "WHERE CompanyID=" + LogInInfo.CompanyID.ToString() + " AND  OrderType LIKE '" + strOrderType + "'";

                if (chkCustSupp.Checked) Where += " AND CustomerID=" + cboCustomerSupplier.SelectedValue.ToString();
                if (chkDate.Checked)
                {
                    Where += " AND OrderDate BETWEEN @startDate AND @endDate";
                    dtStartDate = dtpStartDate.Value.Date;
                    dtEndDate = dtpEndDate.Value.Date;
                }
                else
                {
                    dtStartDate = new DateTime(1900,1,1);
                    dtEndDate = new DateTime(1900,1,1);
                }

                if (chkOrderNo.Checked) Where += " AND OrderNo LIKE '" + txtOrderNo.Text.Trim() + "%' ";
                dtOrders = new DaOrder().getOrders(formConn, " OrderMID,OrderNo,OrderDate", Where, dtStartDate, dtEndDate);
                ctldgvOrders.DataSource = dtOrders;
                ctldgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                ctldgvOrders.setColumnsReadOnly(true, "OrderNo", "OrderDate");
                ctldgvOrders.Columns["OrderMID"].Visible = false;
                ctldgvOrders.setColumnsWidth(new string[] { "OrderNo", "OrderDate" }, 220, 80);
                ctldgvOrders.Columns[0].Visible = chkAll.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmSearchOrder_Load(object sender, EventArgs e)
        {
            try
            {

                formConn = ConnectionHelper.getConnection();
                loadCustomerSupplier();
                chkAll.Visible = ShowCheckBox;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {

            int i, nR;
            nR = ctldgvOrders.Rows.Count;
            for (i = 0; i < nR; i++)
            {
                ctldgvOrders.Rows[i].Cells[0].Value = chkAll.Checked ? 1 : 0;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            try
            {
                arOrderIDs = new ArrayList();
                if (chkAll.Visible == true)
                {
                    int i, nR;
                    nR = ctldgvOrders.Rows.Count;

                  
                    for (i = 0; i < nR; i++)
                    {
                        if (Convert.ToInt32(ctldgvOrders.Rows[i].Cells[0].Value) == 1)
                            arOrderIDs.Add(Convert.ToInt32(ctldgvOrders.Rows[i].Cells["OrderMID"].Value));
                    }
                }
                else
                {
                    if (ctldgvOrders.SelectedRows==null || ctldgvOrders.SelectedRows.Count == 0) return;
                    arOrderIDs.Add(Convert.ToInt32(ctldgvOrders.Rows[ctldgvOrders.SelectedRows[0].Index].Cells["OrderMID"].Value));
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            arOrderIDs = null;
            this.Close();
        }

        private void ctldgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOK_Click(null, null);
        }

        private void ctldgvOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(null, null);
            }
        }

        private void frmSearchOrder_Paint(object sender, PaintEventArgs e)
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

        private void cboCustomerSupplier_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void cboCustomerSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void chkCustSupp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void chkDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void dtpStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void dtpEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void chkOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
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

        private void ctldgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
