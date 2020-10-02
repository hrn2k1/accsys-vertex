using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Utility;
using Accounting.DataAccess;
using System.Data.SqlClient;
using Accounting.Entity;

namespace Accounting.UI
{
    public partial class frmLoanSearch : Form
    {
        SqlConnection conn = ConnectionHelper.getConnection();
        public DataTable dtLoan = new DataTable();
        public int LoanID = 0;
        public Loan objLoan = new Loan();
        public frmLoanSearch()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            objLoan = null;
            this.Close();
        }

        private void frmLoanSearch_Paint(object sender, PaintEventArgs e)
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
        private void LoadLoan()
        {
            try
            {
               
                DaLoan objDaLoan = new DaLoan();
                dtLoan = objDaLoan.GetLoanInfo(conn);
                ctlDGVLoan.DataSource = dtLoan;
                ctlDGVLoan.setColumnsVisible(false, "LoanID", "RefAccID", "TransRefID", "LCID", "LoanAccID", "Remarks", "SanktionDate", "ExpireDate","InterestPeriod");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmLoanSearch_Load(object sender, EventArgs e)
        {
            LoadLoan();
        }

        public Loan CreateLoanObject(int rowID)
        {
            try
            {
                objLoan.ApplyDate = dtLoan.Rows[rowID].Field<object>("ApplyDate") == DBNull.Value || dtLoan.Rows[rowID].Field<object>("ApplyDate") == null ? new DateTime(1900, 1, 1) : dtLoan.Rows[rowID].Field<DateTime>("ApplyDate");
                objLoan.DueAmount = Convert.ToDouble(dtLoan.Rows[rowID].Field<object>("DueAmount"));
                objLoan.ExpireDate = dtLoan.Rows[rowID].Field<object>("ExpireDate") == DBNull.Value || dtLoan.Rows[rowID].Field<object>("ExpireDate") == null ? new DateTime(1900, 1, 1) : dtLoan.Rows[rowID].Field<DateTime>("ExpireDate");
                objLoan.InterestPeriod = dtLoan.Rows[rowID].Field<string>("InterestPeriod");
                objLoan.InterestRate = Convert.ToDouble(dtLoan.Rows[rowID].Field<object>("InterestRate"));
                objLoan.LCID = dtLoan.Rows[rowID].Field<int>("LCID");
                objLoan.LoanAccID = dtLoan.Rows[rowID].Field<int>("LoanAccID");
                objLoan.LoanAmount = Convert.ToDouble(dtLoan.Rows[rowID].Field<object>("LoanAmount"));
                objLoan.LoanID = dtLoan.Rows[rowID].Field<int>("LoanID");
                objLoan.LoanNo = dtLoan.Rows[rowID].Field<string>("LoanNo");
                objLoan.RefAccID = dtLoan.Rows[rowID].Field<int>("RefAccID");
                objLoan.Remarks = dtLoan.Rows[rowID].Field<string>("Remarks");
                objLoan.SanktionDate = dtLoan.Rows[rowID].Field<object>("SanktionDate") == DBNull.Value || dtLoan.Rows[rowID].Field<object>("SanktionDate") == null ? new DateTime(1900, 1, 1) : dtLoan.Rows[rowID].Field<DateTime>("SanktionDate");
                objLoan.TransRefID = dtLoan.Rows[rowID].Field<object>("TransRefID") == DBNull.Value || dtLoan.Rows[0].Field<object>("TransRefID") == null ? 0 : dtLoan.Rows[0].Field<int>("TransRefID");
                return objLoan;
            }
            catch (Exception ex)
            {
                throw ex;
            }


 
        }

        private void ctlDGVLoan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int ab = e.RowIndex;
                LoanID = Convert.ToInt32(ctlDGVLoan.Rows[ab].Cells["LoanID"].Value);
                objLoan = CreateLoanObject(ab);
                
            
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Loan ReturnLoan()
        {
            return objLoan;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int ab = ctlDGVLoan.CurrentRow.Index;
                LoanID = Convert.ToInt32(ctlDGVLoan.Rows[ab].Cells["LoanID"].Value);
                objLoan = CreateLoanObject(ab);


                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ctlDGVLoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int ab = ctlDGVLoan.CurrentRow.Index; 
                LoanID = Convert.ToInt32(ctlDGVLoan.Rows[ab].Cells["LoanID"].Value);
                objLoan = CreateLoanObject(ab);


                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }

        private void ctlDGVLoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }


        
        
    }
}
