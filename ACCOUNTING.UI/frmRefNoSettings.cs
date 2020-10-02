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

namespace Accounting.UI
{
    public partial class frmRefNoSettings : Form
    {
        public frmRefNoSettings()
        {
            InitializeComponent();
        }
        SqlConnection formCon = null;
        DataTable dtSettings = new DataTable();
        private void frmRefNoSettings_Load(object sender, EventArgs e)
        {
            try
            {
                formCon = ConnectionHelper.getConnection();
                loadSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadSettings()
        {
            try
            {
                dtSettings = new DaCompanySettings().getSettings(formCon);
                ctlDaraGridView1.DataSource = dtSettings;
                ctlDaraGridView1.setColumnsVisible(false, "SlNo", "CompanyID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlTransaction trans=null;
            try
            {
                CompanySettings cs;
                DaCompanySettings objDaCs = new DaCompanySettings();
                trans = formCon.BeginTransaction();
                int i, nR;
                nR = ctlDaraGridView1.Rows.Count;
                for (i = 0; i < nR - 1; i++)
                {
                    cs = CreateObject(i);
                    objDaCs.SaveUpdateSettings(formCon, trans, cs);
                }
                trans.Commit();
                loadSettings();
                MessageBox.Show("Saved Successfully");
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private CompanySettings CreateObject(int rowID)
        {
            CompanySettings cs = new CompanySettings();
            try
            {
                cs.SlNo = ctlDaraGridView1["SlNo", rowID].Value == null || ctlDaraGridView1["SlNo", rowID].Value == DBNull.Value ? 0 : Convert.ToInt32(ctlDaraGridView1["SlNo", rowID].Value);
                cs.SettingCode = ctlDaraGridView1["SettingCode", rowID].Value == null || ctlDaraGridView1["SettingCode", rowID].Value == DBNull.Value ? string.Empty : ctlDaraGridView1["SettingCode", rowID].Value.ToString();
                cs.SettingTitle = ctlDaraGridView1["SettingTitle", rowID].Value == null || ctlDaraGridView1["SettingTitle", rowID].Value == DBNull.Value ? string.Empty : ctlDaraGridView1["SettingTitle", rowID].Value.ToString();
                cs.SettingValue = ctlDaraGridView1["SettingValue", rowID].Value == null || ctlDaraGridView1["SettingValue", rowID].Value == DBNull.Value ? string.Empty : ctlDaraGridView1["SettingValue", rowID].Value.ToString();
                cs.CompanyID = LogInInfo.CompanyID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cs;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ctlDaraGridView1.SelectedRows.Count == 0) return;
                int rowID = ctlDaraGridView1.SelectedRows[0].Index;
                int slNo = ctlDaraGridView1["SlNo", rowID].Value == null || ctlDaraGridView1["SlNo", rowID].Value == DBNull.Value ? 0 : Convert.ToInt32(ctlDaraGridView1["SlNo", rowID].Value);
                if (slNo == 0)
                    ctlDaraGridView1.Rows.RemoveAt(rowID);
                else
                {
                    new DaCompanySettings().DeleteSettings(formCon, slNo);
                    loadSettings();
                    MessageBox.Show("Delete Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
