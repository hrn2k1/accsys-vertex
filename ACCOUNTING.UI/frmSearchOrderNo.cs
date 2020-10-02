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

namespace Accounting.UI
{
    public partial class frmSearchOrderNo : Form
    {
        SqlConnection conn = ConnectionHelper.getConnection();
        private int CustomerID;
        public DataTable Orders = null;
        public string OrderList = string.Empty;
     

        
        public frmSearchOrderNo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Orders = null;
            this.Close();
        }

        public void ShowDialog(int customerID)
        {
            this.CustomerID = customerID;
            this.ShowDialog();
        }

        private void PIOpenedCheck()
        {
            for (int i = 0; i < DGVSearchOrder.Rows.Count; i++)
                if (DGVSearchOrder.Rows[i].Cells["Status"].Value.ToString() == "PI Opened") { DGVSearchOrder.Rows[i].Cells[0].ReadOnly = true; for (int j = 0; j < DGVSearchOrder.Rows[i].Cells.Count; j++)DGVSearchOrder.Rows[i].Cells[j].Style.BackColor = Color.Red; }

        }
        private void LoadOrderInDGV()
        {
            try
            {
                DaPI objDaPI = new DaPI();
                DataTable dtt = new DataTable();
                DateTime stdate = new DateTime();
                DateTime endate = new DateTime();
                stdate = DTPstardate.Value;
                endate = DTPenddate.Value;
                dtt = objDaPI.GetOrderNo(CustomerID,stdate,endate ,conn);
                DGVSearchOrder.DataSource = dtt;

                DGVSearchOrder.setColumnsVisible(false, "Rate", "Buyer_ref", "OrderMID", "CustomerID", "DeliveryDate", "FactoryID", "LedgerNo", "TotalOrderQty", "UnitID", "OrderValue", "CurrencyID", "PIOpen", "CompanyID", "UserID", "ModifiedDate");
                DGVSearchOrder.setColumnsReadOnly(true, "Status");
                PIOpenedCheck();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadOrderNoInDGV()
        {
            try
            {
                DaPI objDaPI = new DaPI();
                DataTable dtt = new DataTable();
                DateTime stdate = new DateTime();
                DateTime endate = new DateTime();
                string strOrderNo = "";
                stdate = DTPstardate.Value;
                endate = DTPenddate.Value;
                strOrderNo = txtOrderNo.Text.Trim();
                dtt = objDaPI.GetOrderNos(CustomerID, stdate, endate,strOrderNo, conn);
                DGVSearchOrder.DataSource = dtt;
                DGVSearchOrder.setColumnsReadOnly(true, "OrderNo", "OrderDate", "Status");
                PIOpenedCheck();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void LoadOrderNosaInDGV()
        {
            try
            {
                DaPI objDaPI = new DaPI();
                DataTable dtt = new DataTable();
               
                string strOrderNo = null;
                
                strOrderNo = txtOrderNo.Text.Trim();
                dtt = objDaPI.GetOrderNosa(CustomerID,strOrderNo, conn);
                DGVSearchOrder.DataSource = dtt;
                DGVSearchOrder.setColumnsReadOnly(true, "Status");
                PIOpenedCheck();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (chDate.Checked == true)
            {
                LoadOrderInDGV();
            }
           
            if (chDate.Checked == true && ChOrder.Checked == true)
            {
                LoadOrderNoInDGV();
            }
            
            if (ChOrder.Checked == true)
            {
                if (txtOrderNo.Text == "")
                {
                    MessageBox.Show("Please select a correct order No.");
                    return;
                }
                LoadOrderNosaInDGV();
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                OrderList = "(0";
                

                int i, nR;
                nR = DGVSearchOrder.Rows.Count;

                for (i = 0; i < nR; i++)
                {
                    if (DGVSearchOrder.Rows[i].Cells[0].Value == null) continue;
                    if (Convert.ToInt32(DGVSearchOrder.Rows[i].Cells[0].Value) == 1)
                    {

                        OrderList += "," + DGVSearchOrder.Rows[i].Cells["OrderMID"].Value.ToString();
                        
                    }
                }
                OrderList += ")";
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DTPstardate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DTPenddate_KeyDown(object sender, KeyEventArgs e)
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

            try
            {
                OrderList = "(0";


                int i, nR;
                nR = DGVSearchOrder.Rows.Count;

                for (i = 0; i < nR; i++)
                {
                    if (DGVSearchOrder.Rows[i].Cells[0].Value == null) continue;
                    if (Convert.ToInt32(DGVSearchOrder.Rows[i].Cells[0].Value) == 1)
                    {

                        OrderList += "," + DGVSearchOrder.Rows[i].Cells["OrderMID"].Value.ToString();

                    }
                }
                OrderList += ")";
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DGVSearchOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                 

            btnOK_Click(null, null);
        }

        private void frmSearchOrderNo_Paint(object sender, PaintEventArgs e)
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

        private void frmSearchOrderNo_Load(object sender, EventArgs e)
        {

        }

       
        

        
       
    }


}
