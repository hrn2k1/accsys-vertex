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
    public partial class frmFindLoan : Form
    {
     public  int LoanID = 0;
     public Loan loan = new Loan();
     public DataTable dtt = new DataTable();
        SqlConnection conn = ConnectionHelper.getConnection();
        public int lcid = 0;
        public frmFindLoan()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            loan = null;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbtnLoanNo.Checked == true)
            {
                string strLoanNo = null;
                DaLoan objDa = new DaLoan();
                DataTable dt = new DataTable();
                DateTime stdt = DTPstDate.Value.Date;
                DateTime enddt = DTPend.Value.Date;
                if (txtLoanNo.Text == "")
                    strLoanNo = "0";
                else

                    strLoanNo = txtLoanNo.Text.Trim();

                dt = objDa.SearchLoan(conn, stdt, enddt, strLoanNo);
                ctlDGVLoan.DataSource = dt;

                ctlDGVLoan.setColumnsVisible(false,"LoanID", "RefAccID", "TransRefID", "LCID", "LoanAccID", "Remarks", "InterestPeriod", "InterestRate", "ApplyDate", "ExpireDate");
            }
            else if (rbtnLCNO.Checked == true)
            {
                try
                {
                    string Lcno = txtLCNO.Text;
                    DataTable dt = new DaLoan().SearchLC(conn, DTPstDate.Value, DTPend.Value, Lcno);
                    ctlDGVLoan.DataSource = dt;
                    ctlDGVLoan.setColumnsVisible(false, "LCID");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

       
        /*
        private void ctlDGVLoan_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            btnOK_Click(null, null);
            /*
            dtt = new DaLoan().ReturnLoan(conn, LoanID);
            try
            {
                loan.LoanID = dtt.Rows[0].Field<int>("LoanID");
                loan.ApplyDate = dtt.Rows[0].Field<DateTime>("ApplyDate");
                loan.DueAmount =Convert.ToDouble( dtt.Rows[0].Field<object>("DueAmount"));
                loan.ExpireDate = dtt.Rows[0].Field<DateTime>("ExpireDate");
                loan.InterestPeriod = dtt.Rows[0].Field<string>("InterestPeriod");
                loan.InterestRate =Convert.ToDouble( dtt.Rows[0].Field<object>("InterestRate"));
                loan.LCID = dtt.Rows[0].Field<int>("LCID");
                loan.LoanAccID = dtt.Rows[0].Field<int>("LoanAccID");
                loan.LoanAmount =Convert.ToDouble( dtt.Rows[0].Field<object>("LoanAmount"));
                loan.LoanID = dtt.Rows[0].Field<int>("LoanID");
                loan.LoanNo = dtt.Rows[0].Field<string>("LoanNo");
                loan.RefAccID = dtt.Rows[0].Field<int>("RefAccID");
                loan.Remarks = dtt.Rows[0].Field<string>("Remarks");
                loan.SanktionDate = dtt.Rows[0].Field<DateTime>("SanktionDate");
                loan.TransRefID = dtt.Rows[0].Field<int>("TransRefID");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error to return loan object"+ex);
            }
            */
        /*

        }
        */
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnLoanNo.Checked == true)
                {
                    LoanID = Convert.ToInt32(ctlDGVLoan.CurrentRow.Cells["LoanID"].Value);
                    loan = new DaLoan().GetLoan(conn, LoanID);
                }
                else if (rbtnLCNO.Checked == true)
                {
                    loan = null;
                    lcid = GlobalFunctions.isNull(ctlDGVLoan.CurrentRow.Cells["LCID"].Value, 0);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmFindLoan_Paint(object sender, PaintEventArgs e)
        {
            FormColorClass.ColorForm(this, e);
        }

        private void ctlDGVLoan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            btnOK_Click(null, null);
        }
        
    }
}
