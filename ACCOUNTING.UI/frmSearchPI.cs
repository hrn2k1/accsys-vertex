using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.DataAccess;
using Accounting.Utility;
using System.Data.SqlClient;

namespace Accounting.UI
{
    
    public partial class frmSearchPI : Form
    {
        private string PIType = "";
        private int CustSuppID;
        SqlConnection conn = ConnectionHelper.getConnection();
         public int PIMasterID=0;
        public frmSearchPI()
        {
            InitializeComponent();
        }
        public frmSearchPI(string CustSupp,int custsuppID)
        {
            InitializeComponent();
            PIType = CustSupp;
            CustSuppID = custsuppID;
        }

        private void btnSearchPI_Click(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            DateTime stdate = new DateTime();
            DateTime enddate = new DateTime();
            stdate = DTPStartDate.Value.Date;
            enddate = DTPEndDate.Value.Date;
            DaPI objDaPI=new DaPI();
            string strPINo = txtPI.Text.Trim();
            string stPI = "";
            if (strPINo == "")
            {
                stPI = "ignore";
            }
            else
            {
                stPI = strPINo;
            }
            if (PIType == "")
                dtt = objDaPI.GetPINo(stPI, stdate, enddate,CustSuppID, conn);
            else
                dtt = objDaPI.GetPINo(stPI, stdate, enddate, PIType,CustSuppID, conn);
            ctlDGVSearchPI.DataSource = dtt;
            ctlDGVSearchPI.setColumnsVisible(false, "PIMID");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ctlDGVSearchPI.Rows.Count == 0) { this.Close(); return; }
                if (ctlDGVSearchPI.CurrentRow.Cells["PIMID"].Value == DBNull.Value) { this.Close(); return; }

                PIMasterID = (int)ctlDGVSearchPI.CurrentRow.Cells["PIMID"].Value;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an Error for selecting Data" + ex.Message);
                return;
            }
        }

        private void DTPStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DTPEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtPI_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("123");
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void btnSearchPI_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
               // btnSearchPI_Click(null, null);
                SelectNextControl((Control)sender, true, true, true, true);
            }
         
        }

        private void ctlDGVSearchPI_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CHKPINO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void frmSearchPI_Paint(object sender, PaintEventArgs e)
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

        private void frmSearchPI_Load(object sender, EventArgs e)
        {
            DTPStartDate.Focus();
        }

        private void ctlDGVSearchPI_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ctlDGVSearchPI.Rows.Count == 0) { this.Close(); return; }
                if (ctlDGVSearchPI.CurrentRow.Cells["PIMID"].Value == DBNull.Value) { this.Close(); return; }

                PIMasterID = (int)ctlDGVSearchPI.CurrentRow.Cells["PIMID"].Value;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an Error for selecting Data" + ex.Message);
                return;
            }
        }

        //private void DTPStartDate_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        SelectNextControl((Control)sender, true, true, true, true);
        //}

        //private void DTPEndDate_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        SelectNextControl((Control)sender, true, true, true, true);
        //}

        //private void txtPI_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        SelectNextControl((Control)sender, true, true, true, true);
        //}

        //private void btnSearchPI_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        SelectNextControl((Control)sender, true, true, true, true);
        //}

        //private void btnOK_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        SelectNextControl((Control)sender, true, true, true, true);
        //}

        //private void btnCancel_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        SelectNextControl((Control)sender, true, true, true, true);
        //}

        
    }
}
