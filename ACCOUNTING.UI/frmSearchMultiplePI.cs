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
    public partial class frmSearchMultiplePI : Form
    {
        SqlConnection conn = ConnectionHelper.getConnection();
        public string PIList = string.Empty;
        public DataTable PIs = null;
        private string PITYPE = "%";
        private int CustSuppID;
        public frmSearchMultiplePI()
        {
            InitializeComponent();
        }
        public void ShowDialog(string piType,int CustomerSupplierID)
        {
            this.PITYPE = piType;
            this.CustSuppID = CustomerSupplierID;
            this.Text = "Search " + (piType=="To Customer"?"Customer's " :"Supplier's ") + "Proforma Invoice";
            this.ShowDialog();
        }
        void LCOpenedCheck(){
            for (int i = 0; i < ctlDGVSearchPI.Rows.Count; i++)
                if (ctlDGVSearchPI.Rows[i].Cells["Status"].Value.ToString() == "LC Opened") { ctlDGVSearchPI.Rows[i].Cells[0].ReadOnly = true; for (int j = 0; j < ctlDGVSearchPI.Rows[i].Cells.Count; j++)ctlDGVSearchPI.Rows[i].Cells[j].Style.BackColor = Color.Red; }

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtt = new DataTable();
                DateTime stdate = new DateTime();
                DateTime enddate = new DateTime();
                stdate = DTPStartDate.Value.Date;
                enddate = DTPEndDate.Value.Date;
                DaPI objDaPI = new DaPI();
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
                dtt = objDaPI.GetPINoNew(stPI, stdate, enddate, this.PITYPE, CustSuppID, conn);
                ctlDGVSearchPI.DataSource = dtt;
                ctlDGVSearchPI.setColumnsVisible(false, "PIMID");
                ctlDGVSearchPI.setColumnsReadOnly(true, "Status");
                LCOpenedCheck();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PIList = string.Empty;
            PIs = null;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                PIList = "(0";
                PIs = new DaLC().getPIsOfLC(conn, 0);

                int i, nR;
                nR = ctlDGVSearchPI.Rows.Count;

                for (i = 0; i < nR; i++)
                {
                    if (ctlDGVSearchPI.Rows[i].Cells[0].Value == null) continue;
                    if (Convert.ToInt32(ctlDGVSearchPI.Rows[i].Cells[0].Value) == 1)
                    {

                        PIList += "," + ctlDGVSearchPI.Rows[i].Cells["PIMID"].Value.ToString();
                        PIs.Rows.Add(new object[] { 0, (int)ctlDGVSearchPI.Rows[i].Cells["PIMID"].Value });
                    }
                }
                PIList += ")";
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmSearchMultiplePI_Paint(object sender, PaintEventArgs e)
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

        private void frmSearchMultiplePI_Load(object sender, EventArgs e)
        {

        }

        private void DTPStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }
    }
}
