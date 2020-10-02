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
    public partial class frmSearchLC : Form
    {
        string LcType = string.Empty;
        SqlConnection conn = ConnectionHelper.getConnection();
        public int LCID = 0;
        //public string strLcType = string.Empty;
        public frmSearchLC()
        {
            InitializeComponent();
        }
        public frmSearchLC(string LCType)
        {
            InitializeComponent();
            LcType = LCType;
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
                DaLC objDaLC = new DaLC();
                string strLCNo = txtLCNo.Text.Trim();
                string stLC = "";
                if (LcType != string.Empty)
                {
                    dtt = objDaLC.GetImportLC(conn, stdate, enddate);
                }
                else
                {
                    if (strLCNo == "")
                    {
                        stLC = "ignore";
                    }
                    else
                    {
                        stLC = strLCNo;
                    }
                    dtt = objDaLC.GetLCNos(stLC, stdate, enddate, conn);
                }
                ctlDGVLC.DataSource = dtt;
                ctlDGVLC.setColumnsVisible(false, "LCID", "MasterLCID");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ctlDGVLC.Rows.Count == 0) { this.Close(); return; }
                if (ctlDGVLC.CurrentRow.Cells["LCID"].Value == null) { this.Close(); return; }

                LCID = (int)ctlDGVLC.CurrentRow.Cells["LCID"].Value;
                //strLcType = GlobalFunctions.isNull(ctlDGVLC.CurrentRow.Cells["LCType"].Value, "");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LCID = 0;
            this.Close();
        }

        private void frmSearchLC_Paint(object sender, PaintEventArgs e)
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

        private void ctlDGVLC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOK_Click(sender, null);
        }

        private void DTPEndDate_ValueChanged(object sender, EventArgs e)
        {

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

        private void checkBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtLCNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
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

        private void txtLCNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtLCNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void ctlDGVLC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
