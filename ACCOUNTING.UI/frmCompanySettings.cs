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
    public partial class frmCompanySettings : Form
    {
        public frmCompanySettings()
        {
            InitializeComponent();
        }
        SqlConnection formCon = null;
        private CompanySettings CreateObject(int slNo,string code,string title,string value)
        {
            CompanySettings cs = new CompanySettings();
            try
            {
                cs.SlNo = slNo;
                cs.SettingCode =code;
                cs.SettingTitle = title;
                cs.SettingValue = value;
                cs.CompanyID = LogInInfo.CompanyID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cs;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DaCompanySettings objDaCS = new DaCompanySettings();
            CompanySettings CS = new CompanySettings();
            SqlTransaction trans = null;
            try
            {
                trans = formCon.BeginTransaction();
                objDaCS.DeleteSettings(formCon,trans);

                //PI Setting
                CS = CreateObject(0, "PI", "Proforma Invoice", txtPrefix.Text);
                objDaCS.SaveUpdateSettings(formCon, trans, CS);

                //Integration 
                CS = CreateObject(0, "INV_ACC", "Inventory Integreted With Accounting", (chkEffectToAc.Checked?"YES":"NO"));
                objDaCS.SaveUpdateSettings(formCon, trans, CS);

                trans.Commit();
                MessageBox.Show("Successfully Saved");
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void frmCompanySettings_Load(object sender, EventArgs e)
        {
            try
            {
                formCon = ConnectionHelper.getConnection();

                DaCompanySettings daCS = new DaCompanySettings();
                txtPrefix.Text = daCS.getSettingValue("PI", LogInInfo.CompanyID);

                string f=daCS.getSettingValue("INV_ACC", LogInInfo.CompanyID);
                chkEffectToAc.Checked = (f == "YES");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmCompanySettings_Paint(object sender, PaintEventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }


}
