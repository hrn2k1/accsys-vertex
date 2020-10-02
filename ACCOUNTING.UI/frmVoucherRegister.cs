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
using CrystalDecisions.Shared;
using Accounting.Reports;

namespace Accounting.UI
{
    public partial class frmVoucherRegister : Form
    {
        public frmVoucherRegister()
        {
            InitializeComponent();
        }

        SqlConnection formCon = null;
        DataTable dtVoucher = null;
      
        DataTable dtAccountAmount = null;
        
        DaTransaction objDaTrans = null;
        public int SelectedTransactionID = 0;
        public int SelectedVoucherTypeID = 0;
        public bool IsEditable = true;
        private object CallerForm= null;
        private void loadVoucherType()
        {
            try
            {
                DataTable dt = new DaVoucherType().getVoucherType(formCon);

                dt.Rows.Add(0, "All");
                
                cboVoucherType.DataSource = dt;
                cboVoucherType.DisplayMember = "VoucherType";
                cboVoucherType.ValueMember = "VoucherTypeID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ShowDialog(object caller)
        {
            this.CallerForm = caller;
            this.ShowDialog();
        }

        private void loadVoucherDetails()
        {
            try
            {
                int i, j, nR,N;
                dtVoucher = objDaTrans.getVoucher(formCon, (int)cboVoucherType.SelectedValue, dtpStartDate.Value.Date, dtpEndDate.Value.Date);
                ListViewItem lvi;
                nR = dtVoucher.Rows.Count;
                lvVoucher.Items.Clear();
                for (i = 0; i < nR; i++)
                {
                     lvi = new ListViewItem(dtVoucher.Rows[i].Field<string>("VoucherNo"));
                    lvi.SubItems.Add(dtVoucher.Rows[i].Field<DateTime>("TransDate").ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(Convert.ToDouble(dtVoucher.Rows[i].Field<object>("Amount")).ToString("0.00"));
                    

                    dtAccountAmount = objDaTrans.getTransAccounts(formCon, dtVoucher.Rows[i].Field<int>("TransMID"), "Journal");
                    N = dtAccountAmount.Rows.Count;
                    double DrAmt, CrAmt;
                    string strModule = dtVoucher.Rows[i].Field<string>("Module");
                    for (j = 0; j < N; j++)
                    {
                       DrAmt= Convert.ToDouble(dtAccountAmount.Rows[j].Field<object>("Debit"));
                       CrAmt= Convert.ToDouble(dtAccountAmount.Rows[j].Field<object>("Credit"));
                        if (j == 0)
                        {
                            lvi.SubItems.Add(dtAccountAmount.Rows[j].Field<string>("AccountTitle"));
                            lvi.SubItems.Add(DrAmt==0?string.Empty:DrAmt.ToString("0.00"));
                            lvi.SubItems.Add(CrAmt==0?string.Empty:CrAmt.ToString("0.00"));
                            lvi.SubItems.Add(dtVoucher.Rows[i].Field<string>("Module"));
                            lvi.Tag = new int[] { dtVoucher.Rows[i].Field<int>("TransMID"), dtVoucher.Rows[i].Field<int>("VoucherType"), (strModule == "Voucher" || strModule == "Asset Schedule" ? 1 : 0) };
                            lvVoucher.Items.Add(lvi);
                        }
                        else
                        {
                            lvi = new ListViewItem(string.Empty);
                            lvi.SubItems.Add(string.Empty);
                            lvi.SubItems.Add(string.Empty);
                            lvi.SubItems.Add(dtAccountAmount.Rows[j].Field<string>("AccountTitle"));
                            lvi.SubItems.Add(DrAmt == 0 ? string.Empty : DrAmt.ToString("0.00"));
                            lvi.SubItems.Add(CrAmt == 0 ? string.Empty : CrAmt.ToString("0.00"));
                            lvi.SubItems.Add(string.Empty);
                            lvi.Tag = new int[] { dtVoucher.Rows[i].Field<int>("TransMID"), dtVoucher.Rows[i].Field<int>("VoucherType"), (strModule == "Voucher" || strModule == "Asset Schedule" ? 1 : 0) };
                            lvVoucher.Items.Add(lvi);
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
     

        private void frmVoucherRegister_Load(object sender, EventArgs e)
        {
            try
            {
                formCon = ConnectionHelper.getConnection();
                objDaTrans = new DaTransaction();
                loadVoucherType();
                cboVoucherType.SelectedValue = 0;
                loadVoucherDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                loadVoucherDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedTransactionID = 0;
            SelectedVoucherTypeID = 0;
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                if (lvVoucher.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Select a voucher to update", "Voucher Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int editable = ((int[])lvVoucher.SelectedItems[0].Tag)[2];
                //if (editable == 0)
                //{
                //    MessageBox.Show("This Voucher is not editable here." + Environment.NewLine + "Go to the specific module to edit it", "Voucher Register",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //    return;
                //}
                SelectedTransactionID = ((int[])lvVoucher.SelectedItems[0].Tag)[0];
                SelectedVoucherTypeID = ((int[])lvVoucher.SelectedItems[0].Tag)[1];
                IsEditable = (editable==0)?false:true;
                //if (this.CallerForm.Equals(frmMain))
                //{
                //    frmVouchers frm = new frmVouchers();
                    

                //}
                //else
                    this.Close();
               
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvVoucher_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_Click(null, null);
        }

        private void chkShowLine_CheckedChanged(object sender, EventArgs e)
        {
            lvVoucher.GridLines = chkShowLine.Checked;
        }

        private void frmVoucherRegister_Paint(object sender, PaintEventArgs e)
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
        #region report variable
        frmReportViewer frmRV = new frmReportViewer();
        ParameterValues pvc = new ParameterValues();
        ParameterDiscreteValue pdv = new ParameterDiscreteValue();

        #endregion
        private void VoucherPrint(int TransMID)
        {
            try
            {
                rptVoucher rptV = new rptVoucher();

                pdv.Value = TransMID;
                pvc.Add(pdv);
                rptV.DataDefinition.ParameterFields["@TransMID"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptV.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);


                frmRV.ShowDialog(rptV, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void JournalVoucherPrint(int TransMID)
        {
            try
            {
                rptJournalVoucher rptV = new rptJournalVoucher();

                pdv.Value = TransMID;
                pvc.Add(pdv);
                rptV.DataDefinition.ParameterFields["@TransMID"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptV.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);


                frmRV.ShowDialog(rptV, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
               int SelectedTransID = ((int[])lvVoucher.SelectedItems[0].Tag)[0];
               int SelectedVTypeID = ((int[])lvVoucher.SelectedItems[0].Tag)[1];
               if (SelectedVTypeID != 3)
                   VoucherPrint(SelectedTransID);
               else
                   JournalVoucherPrint(SelectedTransID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
