using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Entity;
using Accounting.Utility;
using Accounting.DataAccess;
using System.Data.SqlClient;

namespace Accounting.UI
{
    public partial class frmFiscalYear : Form
    {
        public frmFiscalYear()
        {
            InitializeComponent();
        }
        
        public Refreshing DoRefresh;
        SqlConnection formCon = new SqlConnection();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFiscalYear_Load(object sender, EventArgs e)
        {
            try
            {
                formCon = ConnectionHelper.getConnection();
                loadFiscalYears();
               
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.Message);
            }
        }
        private FiscalYear _objFY = new FiscalYear();
        private DaFiscalYear _objDaFY = new DaFiscalYear();
        private DataTable _dtFiscalYear = new DataTable();
        private CurrencyManager _cmRowPointer = null;

        private void loadFiscalYears()
        {
            try
            {
                if (ctldgvFiscalYear.Columns.Count != 0) ctldgvFiscalYear.Columns.Clear();
                
                _dtFiscalYear = _objDaFY.getFiscalYear(formCon,0);
                ctldgvFiscalYear.DataSource = _dtFiscalYear;
                _cmRowPointer = (CurrencyManager)this.BindingContext[_dtFiscalYear];
                ctldgvFiscalYear.setColumnsVisible(false, "FiscalYearID", "CompanyID", "UserID", "ModifiedDate");
                ctldgvFiscalYear.setColumnsHeaderText(new string[] { "Title", "startDate","enddate" }, "Title", "Start Date","End Date");
                ctldgvFiscalYear.setColumnsWidth(new string[] { "Title", "startdate","endDate" }, 200,100,100);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private FiscalYear CreateObject(int rowID)
        {
            FiscalYear obj = new FiscalYear();
            try
            {
                obj.FiscalYearID = isNullOrEmpty(ctldgvFiscalYear.Rows[rowID].Cells["FiscalYearID"].Value) == true ? 0 : (int)ctldgvFiscalYear.Rows[rowID].Cells["FiscalYearID"].Value;
                obj.Titile = isNullOrEmpty(ctldgvFiscalYear.Rows[rowID].Cells["Title"].Value) == true ? "" : (string )ctldgvFiscalYear.Rows[rowID].Cells["Title"].Value;
                DateTime dt = isNullOrEmpty(ctldgvFiscalYear.Rows[rowID].Cells["startdate"].Value) == true ? DateTime.Now.Date : (DateTime)ctldgvFiscalYear.Rows[rowID].Cells["startdate"].Value;
                obj.StartDate = dt.Date;
                dt = isNullOrEmpty(ctldgvFiscalYear.Rows[rowID].Cells["enddate"].Value) == true ? DateTime.Now.Date : (DateTime)ctldgvFiscalYear.Rows[rowID].Cells["enddate"].Value;
                obj.EndDate = dt.Date;
                
                obj.CompanyID = LogInInfo.CompanyID;
                obj.UserID = LogInInfo.UserID;
                obj.ModifiedDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        private bool isNullOrEmpty(object obj)
        {
            try
            {
                if (obj.GetType() == typeof(DataRow) || obj.GetType() == typeof(DataRowView)) return true;
                if (obj == null)
                    return true;
                else if (obj.ToString() == "")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                if (ex != null)
                    return true;
                else
                    return true;
            }
        }
        private int validation()
        {
            int i, nR,j;
            nR = _dtFiscalYear.Rows.Count;
            for (i = 0; i < nR; i++)
            {
                for (j = i+1; j < nR; j++)
                {
                    if (GlobalFunctions.IsOverlap2DateRange( Convert.ToDateTime(ctldgvFiscalYear.Rows[i].Cells["startdate"].Value),Convert.ToDateTime(ctldgvFiscalYear.Rows[i].Cells["enddate"].Value),Convert.ToDateTime(ctldgvFiscalYear.Rows[j].Cells["startdate"].Value),Convert.ToDateTime(ctldgvFiscalYear.Rows[j].Cells["enddate"].Value)))
                    {
                        MessageBox.Show("Fiscl Year Over Lap");
                        return i + 1;
                    }
                }
                    
            }
            return 0;
        }
       private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validation() != 0) return; 
                int i, nR;
                nR = _dtFiscalYear.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    _objDaFY.SaveUpdateFiscalYear(formCon, CreateObject(i));

                }
                loadFiscalYears();
                MessageBox.Show("Save successful", "Salary Sheets");
                if (DoRefresh != null)
                {
                    DoRefresh();
                }
            }
            catch (Exception ex)
            {
              
                MessageBox.Show(ex.Message);
            }

        }

       

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int ID;
                if (ctldgvFiscalYear.SelectedRows.Count == 0) return;
                if (ctldgvFiscalYear.SelectedRows[0].IsNewRow == true) return;
                if (isNullOrEmpty(ctldgvFiscalYear.Rows[_cmRowPointer.Position].Cells["FiscalYearID"].Value) == true)
                {
                    ctldgvFiscalYear.Rows.RemoveAt(_cmRowPointer.Position);
                }
                else
                {
                    ID = (int)ctldgvFiscalYear.Rows[_cmRowPointer.Position].Cells["FiscalYearID"].Value;
                    _objDaFY.DeleteFiscalYear(formCon,ID);
                    loadFiscalYears();
                    if (DoRefresh != null)
                    {
                        DoRefresh();
                    }
                }

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void frmFiscalYear_Paint(object sender, PaintEventArgs e)
        {
            FormColorClass.ColorForm(this, e);
        }
    }
}
