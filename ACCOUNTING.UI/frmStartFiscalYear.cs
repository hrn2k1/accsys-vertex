using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Utility;
using System.Data.SqlClient;

namespace Accounting.UI
{
    public partial class frmStartFiscalYear : Form
    {
        public frmStartFiscalYear()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private SqlConnection formConnection = null;
        #region 
        private double getStock(string str)
        {
            double amt;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT dbo.fnGetStockOfRawFinish(@ItemCategory,@CompanyID)", formConnection);
                cmd.Parameters.Add("@ItemCategory", SqlDbType.VarChar, 100).Value = str;
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                amt = GlobalFunctions.isNull(cmd.ExecuteScalar(), 0.0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return amt;
        }
        private double getOpOfWorkInProces()
        {
            double amt;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Nature*OpeningBalance FROM  VW_AccountWithClassification WHERE (AccountTitle LIKE 'Work in Process') AND (ISNULL(AccountType,'') LIKE 'Current Assets') AND (ISNULL(AccountSubType,'')  LIKE 'Stock & Store') AND (CompanyID = @CompanyID)", formConnection);
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                amt = GlobalFunctions.isNull(cmd.ExecuteScalar(), 0.0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return amt;
        }
        private double getCostOfGoodsSold(double stockRaw, double stockFinish, double WorkInProcess)
        {
            double amt;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT   dbo.fnGetCostOfGoodsSold(@StockRaw,@stockFinish,@WorkinProgress,@CompanyID)", formConnection);
                cmd.Parameters.Add("@StockRaw", SqlDbType.Money).Value = stockRaw;
                cmd.Parameters.Add("@stockFinish", SqlDbType.Money).Value = stockFinish;
                cmd.Parameters.Add("@WorkinProgress", SqlDbType.Money).Value = WorkInProcess;
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                amt = GlobalFunctions.isNull(cmd.ExecuteScalar(), 0.0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return amt;
        }
        private double getCostOfGoodsSold(double stockRaw, double stockFinish, double WorkInProcess,SqlTransaction trans)
        {
            double amt;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT   dbo.fnGetCostOfGoodsSold(@StockRaw,@stockFinish,@WorkinProgress,@CompanyID)", formConnection, trans);
                cmd.Parameters.Add("@StockRaw", SqlDbType.Money).Value = stockRaw;
                cmd.Parameters.Add("@stockFinish", SqlDbType.Money).Value = stockFinish;
                cmd.Parameters.Add("@WorkinProgress", SqlDbType.Money).Value = WorkInProcess;
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                amt = GlobalFunctions.isNull(cmd.ExecuteScalar(), 0.0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return amt;
        }
        #endregion
        private void frmStartFiscalYear_Load(object sender, EventArgs e)
        {
            try
            {
                formConnection = ConnectionHelper.getConnection();
                ctlNumRaw.Value = Math.Round(getStock("Raw Material"), 2);
                ctlNumFinish.Value = Math.Round(getStock("Finished Good"), 2);
                ctlNumWorkInProcess.Value = Math.Round(getOpOfWorkInProces(), 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmStartFiscalYear_Paint(object sender, PaintEventArgs e)
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

        private void llblAssetSchdl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmAssetSchedule().ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                new frmAssetSchedule().ShowDialog();
                CreateOrCloseFY();
                MessageBox.Show("Fiscal Year Created Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateOrCloseFY()
        {
            SqlTransaction trans=null;
            try
            {
                trans=formConnection.BeginTransaction();
                SqlCommand cmd = new SqlCommand("T_spCloseFiscalYear", formConnection, trans);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cost_of_goods_sold", SqlDbType.Money).Value = getCostOfGoodsSold(ctlNumRaw.Value, ctlNumFinish.Value, ctlNumWorkInProcess.Value,trans);
                cmd.Parameters.Add("@rowMaterials", SqlDbType.Money).Value =ctlNumRaw.Value;
                cmd.Parameters.Add("@finishedGoods", SqlDbType.Money).Value = ctlNumFinish.Value;
                cmd.Parameters.Add("@WorkProgress", SqlDbType.Money).Value = ctlNumWorkInProcess.Value;
                cmd.Parameters.Add("@dividend", SqlDbType.Money).Value = ctlNumDivamt.Value;
                cmd.Parameters.Add("@newFYTitle", SqlDbType.VarChar,500).Value = txtTitle.Text;
                cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = dtpFYEndDate.Value.Date;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value =LogInInfo.UserID;;
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                throw ex;
            }
        }
    }
}
