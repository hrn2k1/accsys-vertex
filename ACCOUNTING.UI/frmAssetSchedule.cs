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
using Accounting.Reports;
using CrystalDecisions.Shared;

namespace Accounting.UI
{
    public partial class frmAssetSchedule : Form
    {
        public frmAssetSchedule()
        {
            InitializeComponent();
        }
        SqlConnection formCon = null;
        int FYID =7;
        private void frmAssetSchedule_Load(object sender, EventArgs e)
        {
            try
            {
                formCon = ConnectionHelper.getConnection();
                loadGrid();
                loadFiscalYear();
                FYID = (int)cboFiscalYear.SelectedValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region Grid Load
        private void loadFiscalYear()
        {
            {
                try
                {
                    cboFiscalYear.DataSource = (new DaFiscalYear()).getFiscalYearS(formCon, 0);
                    cboFiscalYear.DisplayMember = "Period";
                    cboFiscalYear.ValueMember = "FiscalYearID";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private void loadGrid()
        {
            try
            {
                if (dgvAsset.Rows.Count > 0) dgvAsset.Rows.Clear();
                DataTable dtAsset = getFixedAssets();
                int i, nR;
                nR = dtAsset.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    dgvAsset.Rows.Add(0, dtAsset.Rows[i].Field<object>("AccountID"), dtAsset.Rows[i].Field<object>("AccountTitle"), dtAsset.Rows[i].Field<object>("OpeningBalance"), dtAsset.Rows[i].Field<object>("addition"), dtAsset.Rows[i].Field<object>("CurrentBalance"), 0.0,dtAsset.Rows[i].Field<object>("TotalDepr"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Data Access
        private DataTable getFixedAssets()
        {
            DataTable dt = new DataTable();
            try
            {
                //string qstr = "SELECT AccountID, AccountTitle, OpeningBalance, CurrentBalance - OpeningBalance AS addition,CurrentBalance  " +
                //               " FROM VW_AccountWithClassification WHERE (ISNULL(AccountType,'') LIKE 'Fixed Assets') AND (CurrentBalance <> 0) AND (CompanyID = "+ LogInInfo.CompanyID.ToString() + ") ";
                SqlDataAdapter da = new SqlDataAdapter("spGetFixedAssetForDepr", formCon);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@FiscalYearID", SqlDbType.Int).Value = FYID;
                da.SelectCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        private void InsertAsset(int rowID, int DepAccID,SqlTransaction trans)
        {
            try
            {
                string qstr = "INSERT INTO T_AssetSchedule " +
                         " (AssetAccountID, OpeningBalance, Addition, TotalBalance, DepreciationRate, DeprecAccountID, OpDepreciation, Depreciation, TotalDeprec, " +
                          " ClosingBalance, DeprecDate, FiscalYearID, CompanyID, UserID, ModifiedDate) " +
                         " VALUES  (@AssetAccountID,@OpeningBalance,@Addition,@TotalBalance,@DepreciationRate, @DeprecAccountID,@OpDepreciation,@Depreciation,@TotalDeprec,@ClosingBalance,@DeprecDate,@FiscalYearID,@CompanyID,@UserID,  GETDATE())";
                SqlCommand cmd = new SqlCommand(qstr, formCon,trans);
                cmd.Parameters.Add("@AssetAccountID", SqlDbType.Int).Value = GlobalFunctions.isNull(dgvAsset[ColAssetAccountID.Name, rowID].Value, 0);
                cmd.Parameters.Add("@OpeningBalance", SqlDbType.Money).Value = GlobalFunctions.isNull(dgvAsset[ColOpBal.Name, rowID].Value, 0.0);
                cmd.Parameters.Add("@Addition", SqlDbType.Money).Value = GlobalFunctions.isNull(dgvAsset[ColAddition.Name, rowID].Value, 0.0);
                cmd.Parameters.Add("@TotalBalance", SqlDbType.Money).Value = GlobalFunctions.isNull(dgvAsset[ColTotalBal.Name, rowID].Value, 0.0);
                cmd.Parameters.Add("@DepreciationRate", SqlDbType.Money).Value = GlobalFunctions.isNull(dgvAsset[ColRate.Name, rowID].Value, 0.0);
                cmd.Parameters.Add("@DeprecAccountID", SqlDbType.Int).Value = DepAccID;
                cmd.Parameters.Add("@OpDepreciation", SqlDbType.Money).Value = GlobalFunctions.isNull(dgvAsset[ColOpDepr.Name, rowID].Value, 0.0);
                cmd.Parameters.Add("@Depreciation", SqlDbType.Money).Value = GlobalFunctions.isNull(dgvAsset[ColDepr.Name, rowID].Value, 0.0);
                cmd.Parameters.Add("@TotalDeprec", SqlDbType.Money).Value = GlobalFunctions.isNull(dgvAsset[ColTotalDepr.Name, rowID].Value, 0.0);
                cmd.Parameters.Add("@ClosingBalance", SqlDbType.Money).Value = GlobalFunctions.isNull(dgvAsset[ColCloseBal.Name, rowID].Value, 0.0);
                cmd.Parameters.Add("@DeprecDate", SqlDbType.DateTime).Value = dtpdate.Value.Date;
                cmd.Parameters.Add("@FiscalYearID", SqlDbType.Int).Value = (int)cboFiscalYear.SelectedValue;
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = LogInInfo.UserID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void dgvAsset_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            e.CellStyle.BackColor = Color.Black;
            e.CellStyle.ForeColor = Color.White;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            try
            {
                DateTime startDate, toDate;
                FYID =Convert.ToInt32( cboFiscalYear.SelectedValue);
                FiscalYear FY = new DaFiscalYear().getAFiscalYear(formCon, FYID);
                if (FY == null) return;
                startDate = FY.StartDate;
                toDate = dtpdate.Value.Date;

                TimeSpan ts = toDate.Subtract(startDate);
               int days = ts.Days+1;
               double ttlDep = 0.0;
               int i, nR;
               nR = dgvAsset.Rows.Count;
               for (i = 0; i < nR; i++)
               {
                   if (GlobalFunctions.isNull(dgvAsset[ColRate.Name, i].Value, 0.0) != 0.0)
                   dgvAsset[ColDepr.Name, i].Value =Math.Round( GlobalFunctions.isNull(dgvAsset[ColTotalBal.Name, i].Value, 0.0) * days / 365.0 * GlobalFunctions.isNull(dgvAsset[ColRate.Name, i].Value, 0.0) / 100.0,2);
                   ttlDep += GlobalFunctions.isNull(dgvAsset[ColDepr.Name, i].Value, 0.0);
                   dgvAsset[ColTotalDepr.Name, i].Value = GlobalFunctions.isNull(dgvAsset[ColOpDepr.Name, i].Value, 0.0)+ GlobalFunctions.isNull(dgvAsset[ColDepr.Name, i].Value, 0.0);
                   dgvAsset[ColCloseBal.Name, i].Value = GlobalFunctions.isNull(dgvAsset[ColTotalBal.Name, i].Value, 0.0) - GlobalFunctions.isNull(dgvAsset[ColTotalDepr.Name, i].Value, 0.0);
               }
               ctlNumDep.Value = Math.Round( ttlDep,2);
              
               if (chkPost.Checked)
               {
                   if ((ctlNumDep.Value == 0))
                   {
                       MessageBox.Show("Correctly entry the depreciation amount", "Transaction Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       return;
                   }
                   int DepreAccID = new DaAccount().GetDepreciationAccountID(formCon);
                   if (DepreAccID == 0)
                   {
                       MessageBox.Show("There is no depreciation account" + Environment.NewLine + "Create 'Depreciation' Account under 'Expense'", "Transaction Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       return;
                   }
                   string Vno = new DaTransaction().getVoucherNo(formCon, "J");
                   trans = formCon.BeginTransaction();
                   post(DepreAccID, Vno,trans);
                   for (i = 0; i < nR; i++)
                   {
                       InsertAsset(i, DepreAccID, trans);
                   }
                   trans.Commit();
                   loadGrid();
                   MessageBox.Show("Depreciation posted successfully");
               }


               
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        #region Depreciation Calc
        private void post(int DepreAccID,string Vno, SqlTransaction trans)
        {
           
            
            try
            {
                int TMID = 0;
                int i, nR;
                TransactionMaster objTM = new TransactionMaster();
                TransactionDetail objTD = new TransactionDetail();
                DaTransaction objDaTrans = new DaTransaction();
                 
               
                
               
                objTM = CreateTransMasterObject(0,Vno);
                TMID = objDaTrans.SaveEditTransactionMaster(objTM, formCon, trans);

                objTD = CreateTransDetailObject(0, TMID, DepreAccID, 0, Math.Round(ctlNumDep.Value, 2));  

                objDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);


                nR = dgvAsset.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    double Cr = GlobalFunctions.isNull( dgvAsset[ColDepr.Name,i].Value,0.0);
                    double Dr = 0;
                    objTD = CreateTransDetailObject(0, TMID, GlobalFunctions.isNull(dgvAsset[ColAssetAccountID.Name, i].Value, 0), Cr, Dr);

                    objDaTrans.SaveEditTransactionDetail(objTD, formCon, trans);
                }

                

                

               
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        #region create objects
        private TransactionMaster CreateTransMasterObject(int TMID,string VoucherNo)
        {
            TransactionMaster objTM = null;
            try
            {
                objTM = new TransactionMaster();


                objTM.TransactionMasterID = TMID;
                objTM.TransactionDate = dtpdate.Value.Date;
                objTM.VoucherNo = VoucherNo;
                objTM.VoucherPayee = "";
                objTM.VoucherType = 3;
                objTM.TransactionMethodID = -1;
                objTM.MethodRefID = -1;
                objTM.MethodRefNo = string.Empty;
                objTM.TransactionDescription = string.Empty;
                objTM.Module = "Asset Schedule";


                objTM.ApprovedBy = string.Empty;
                objTM.ApprovedDate = new DateTime(1900, 1, 1);



            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objTM;
        }

        private TransactionDetail CreateTransDetailObject(int TDID, int TMID, int AccountID, double CrAmt, double DrAmt)
        {
            TransactionDetail objTD = null;
            try
            {
                objTD = new TransactionDetail();
                objTD.TransactionDetailID = TDID;
                objTD.TransactionMasterID = TMID;
                objTD.TransactionAccountID = AccountID;
                objTD.CreditAmount = CrAmt;
                objTD.DebitAmount = DrAmt;
                objTD.Comments = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objTD;
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region report variable
        frmReportViewer frmRV = new frmReportViewer();
        ParameterValues pvc = new ParameterValues();
        ParameterDiscreteValue pdv = new ParameterDiscreteValue();

        #endregion
        private void btnReport_Click(object sender, EventArgs e)
        {

            try
            {
                rptAssetSchedule rpt = new rptAssetSchedule();


                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = (int)cboFiscalYear.SelectedValue;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@FiscalYearID"].ApplyCurrentValues(pvc);
                frmRV.ShowDialog(rpt, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private void dgvAsset_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
