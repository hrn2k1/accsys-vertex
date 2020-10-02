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
    public partial class frmLCAcceptance : Form
    {
        SqlConnection formConnection = null;
        int LcID = 0;
        DaLC obDaLc = new DaLC();
        DataTable dt = null;

        public frmLCAcceptance()
        {
            InitializeComponent();
        }
        public frmLCAcceptance(int LCMasterId)
        {
            InitializeComponent();
            LcID = LCMasterId;
        }

        private void frmLCAcceptance_Load(object sender, EventArgs e)
        {
            try
            {
                formConnection = ConnectionHelper.getConnection();
                txtLCID.Text = LcID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool validation()
        {
            if (txtLCID.Text == "" || txtLCID.Text == "0")
            {
                MessageBox.Show("Please select A LC");
                return false;
            }
            //if (dgvLCAcceptance.Rows.Count > 1)
            //{
            //    int i, nR = dgvLCAcceptance.Rows.Count;
            //    double TotalQty = 0, TotalValue = 0;
            //    for (i = 0; i < nR - 1; i++)
            //    {
            //        TotalQty += GlobalFunctions.isNull(dgvLCAcceptance.Rows[i].Cells["acceptQty"].Value, 0.0);
            //        TotalValue += GlobalFunctions.isNull(dgvLCAcceptance.Rows[i].Cells["acceptValue"].Value, 0.0);
            //    }
            //    if (TotalValue > ctlNumTotalValue.Value || TotalQty > ctlNumTotalQty.Value)
            //    {
            //        MessageBox.Show("Please Check the Total Quantity and Value");
            //        return false;
            //    }
            //}
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation() == false) return;
            LCAcceptance obLCAcceptance = new LCAcceptance();
            try
            {
                LcID = int.Parse(txtLCID.Text);
                int i, nR = dgvLCAcceptance.Rows.Count;
                for (i = 0; i < nR - 1; i++)
                {
                    obLCAcceptance = createLCAcceptance(LcID, i);
                    obDaLc.SaveUpdateLCAcceptance(obLCAcceptance, formConnection);
                }
                txtLCID_TextChanged(null, null);
                MessageBox.Show("Save Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private LCAcceptance createLCAcceptance(int LCID, int rowID)
        {
            LCAcceptance obLCAcceptance = new LCAcceptance();
            try
            {
                obLCAcceptance.SlNo = GlobalFunctions.isNull(dgvLCAcceptance.Rows[rowID].Cells["SlNo"].Value, 0);
                obLCAcceptance.LCID = LCID;
                obLCAcceptance.acceptValue = GlobalFunctions.isNull(dgvLCAcceptance.Rows[rowID].Cells["acceptValue"].Value, 0.0);
                obLCAcceptance.acceptQty = GlobalFunctions.isNull(dgvLCAcceptance.Rows[rowID].Cells["acceptQty"].Value, 0.0);
                obLCAcceptance.acceptDate = GlobalFunctions.isNull(dgvLCAcceptance.Rows[rowID].Cells["acceptDate"].Value,new DateTime(1900,1,1));
                obLCAcceptance.ActualShipmentDate = GlobalFunctions.isNull(dgvLCAcceptance.Rows[rowID].Cells["ActualShipmentDate"].Value,new DateTime(1900,1,1));
                obLCAcceptance.MaturityDate = GlobalFunctions.isNull(dgvLCAcceptance.Rows[rowID].Cells["MaturityDate"].Value,new DateTime(1900,1,1));
                obLCAcceptance.PaidDate = GlobalFunctions.isNull(dgvLCAcceptance.Rows[rowID].Cells["PaidDate"].Value,new DateTime(1900,1,1));
                obLCAcceptance.remarks = GlobalFunctions.isNull(dgvLCAcceptance.Rows[rowID].Cells["remarks"].Value, "");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obLCAcceptance;
        }
        private void loadLC(int LCid)
        {
            try
            {
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                DataTable dt = new DaLC().loadLCAcceptance(formConnection, LCid);
                dgvLCAcceptance.DataSource = dt;
                dgvLCAcceptance.Columns["remarks"].HeaderText = "Remarks";
                dgvLCAcceptance.Columns["acceptQty"].HeaderText = "Accept Qty";
                dgvLCAcceptance.Columns["acceptValue"].HeaderText = "Accept Value";
                dgvLCAcceptance.Columns["acceptDate"].HeaderText = "Accept Date";
                dgvLCAcceptance.Columns["ActualShipmentDate"].Width=120;
                dgvLCAcceptance.Columns["remarks"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvLCAcceptance.setColumnsVisible(false, "SLNo", "LCID");
                dgvLCAcceptance.Columns["acceptQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvLCAcceptance.Columns["acceptValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvLCAcceptance.setColumnsFormat(new string[] { "acceptQty", "acceptValue", "acceptDate", "ActualShipmentDate", "MaturityDate", "PaidDate" }, "0.00", "0.00", "dd/MM/yyyy", "dd/MM/yyyy", "dd/MM/yyyy", "dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnLC_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearchLC frm = new frmSearchLC("Direct LC");
                frm.ShowDialog();
                txtLCID.Text = frm.LCID.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvLCAcceptance_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtLCID_TextChanged(object sender, EventArgs e)
        {
            if (txtLCID.Text == "" || txtLCID.Text == "0") return;
            try
            {
                LC_Master objlcmaster = obDaLc.GetLC_Master(int.Parse(txtLCID.Text), formConnection);
                if (objlcmaster == null) return;
                txtLCNo.Text = objlcmaster.LCNo;
                dt = new DataTable();
                dt = obDaLc.GetBank(objlcmaster.IssuBankID, formConnection);
                if (dt.Rows.Count != 0)
                    txtIssueBank.Text = dt.Rows[0].Field<object>("LedgerName").ToString();

                dt = new DataTable();
                dt = obDaLc.GetBank(objlcmaster.NegotiationBankID, formConnection);
                if (dt.Rows.Count != 0)
                    txtNegotiateBank.Text = dt.Rows[0].Field<object>("LedgerName").ToString();
                ctlNumTotalQty.Value = objlcmaster.TotalQty;
                ctlNumTotalValue.Value = objlcmaster.TotalValue;

                loadLC(int.Parse(txtLCID.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLCAcceptance.CurrentCell == null)
                return;
            int rowID = 0;
            try
            {
                rowID = dgvLCAcceptance.CurrentCell.RowIndex;
                int SLNo = 0;
                SLNo = GlobalFunctions.isNull(dgvLCAcceptance.Rows[rowID].Cells["SLNo"].Value, 0);
                if (SLNo == 0)
                {
                    dgvLCAcceptance.Rows.RemoveAt(rowID);
                }
                else
                {
                    obDaLc.deleteLcAcceptance(formConnection, SLNo);
                    txtLCID_TextChanged(null, null);
                }
                MessageBox.Show("delete Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLCAcceptance_Paint(object sender, PaintEventArgs e)
        {
            FormColorClass.ColorForm(this, e);

        }

        private void frmLCAcceptance_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void dgvLCAcceptance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Black;
            e.CellStyle.ForeColor = Color.White;
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        }
    }
}
