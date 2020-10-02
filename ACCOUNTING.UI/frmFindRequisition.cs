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
    public partial class frmFindRequisition : Form
    {
        private SqlConnection formConnection = null;
        private DataTable dtReq = null;
        public ReqMaster obReqMaster = null;
        public frmFindRequisition()
        {
            InitializeComponent();
        }

        private void frmFindRequisition_Load(object sender, EventArgs e)
        {
            formConnection = ConnectionHelper.getConnection();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchselectedReq();
        }

        private void txtRequisitionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }
        private void searchselectedReq()
        {
            string strReqNo = "";
            DateTime sDate, eDate;
            DaInventoryRequisition obDaReq = new DaInventoryRequisition();
            try
            {
                strReqNo += txtRequisitionNo.Text;
                sDate = dtpSDate.Value.Date;
                eDate = dtpEDate.Value.Date;
                dtReq = new DataTable();
                dtReq = obDaReq.SearchSelectedReq(formConnection, sDate, eDate, strReqNo);
                dgvRequisition.DataSource = dtReq;
                dgvRequisition.setColumnsVisible(false, "ReqMID");
                dgvRequisition.setColumnsWidth(dgvRequisition.Width / 3 - 9);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void dgvRequisition_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            btnOK_Click(null, null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DaInventoryRequisition obDaReq = new DaInventoryRequisition();
            obReqMaster = new ReqMaster();
            try
            {
                if (dgvRequisition.SelectedRows.Count == 0)
                {
                    return;
                }
                int ReqID = 0;
                ReqID = (int)dgvRequisition.Rows[dgvRequisition.SelectedRows[0].Index].Cells["ReqMID"].Value;
                obReqMaster = obDaReq.getReqMID(formConnection, ReqID);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured due to " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFindRequisition_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void dtpSDate_Enter(object sender, EventArgs e)
        {
            txtRequisitionNo.Focus();
        }

        private void dgvRequisition_Enter(object sender, EventArgs e)
        {
            btnOK.Focus();
        }

        private void dtpEDate_Enter(object sender, EventArgs e)
        {
            txtRequisitionNo.Focus();
        }

        private void frmFindRequisition_Paint(object sender, PaintEventArgs e)
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
