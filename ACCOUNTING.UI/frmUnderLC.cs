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
    public partial class frmUnderLC : Form
    {
        SqlConnection formConnection = null;
        DaLC obDaLc = new DaLC();
        private int LcId = 0;
        private DataTable dtLc = new DataTable();

        public frmUnderLC()
        {
            InitializeComponent();
        }
        public frmUnderLC(int SlNo)
        {
            InitializeComponent();
            LcId = SlNo;
        }
        private void frmUnderLC_Load(object sender, EventArgs e)
        {
            try
            {
                formConnection = ConnectionHelper.getConnection();
                loadMasterLc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadMasterLc()
        {
            try
            {
                dtLc = obDaLc.getUnderLc(formConnection, LcId);
                dgvMasterLC.DataSource = dtLc;
                dgvMasterLC.setColumnsVisible(false, "SLNo", "LCID", "UnderLCID");
                dgvMasterLC.setColumnsWidth(new string[] { "UnderLCNo" }, 180);
                dgvMasterLC.setColumnsFormat(new string[] { "UnderLCDate", "ShipmentDate", "ExpDate" }, "dd/MM/yyyy");
                //dgvMasterLC.Columns["ColUnderLCNo"].DefaultHeaderCellType = DataGridViewComboBoxDisplayStyle.DropDownButton;
                //dgvMasterLC[ColUnderLCNo.Name
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //private void btnAddLC_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        frmSearchLC objfrm = new frmSearchLC();
        //        objfrm.ShowDialog();

        //        if (objfrm == null) return;
        //        txtLCNo.Text = objfrm.LCID.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void txtLCNo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            //btnAddLC_Click(null, null);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            UnderLC obUnderLC = new UnderLC();
            try
            {
                int i, nR = dgvMasterLC.Rows.Count;
                for (i = 0; i < nR - 1; i++)
                {
                    obUnderLC = createUnderLC(i);
                    obDaLc.saveUpdateUnderLC(formConnection, obUnderLC);
                }
                loadMasterLc();
                MessageBox.Show("Data Saved Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private UnderLC createUnderLC(int rowId)
        {
            UnderLC obUnderLC = new UnderLC();
            try
            {
                obUnderLC.SLNo = GlobalFunctions.isNull(dgvMasterLC.Rows[rowId].Cells["SLNo"].Value, 0);
                obUnderLC.LCID = LcId;
                obUnderLC.UnderLCID = GlobalFunctions.isNull(dgvMasterLC.Rows[rowId].Cells["UnderLCID"].Value, 0);
                obUnderLC.UnderLCNo = dgvMasterLC.Rows[rowId].Cells["UnderLCNo"].Value.ToString();
                obUnderLC.UnderLCDate = GlobalFunctions.isNull(dgvMasterLC.Rows[rowId].Cells["UnderLCDate"].Value, new DateTime(1900,1,1));
                obUnderLC.ShipmentDate = GlobalFunctions.isNull(dgvMasterLC.Rows[rowId].Cells["ShipmentDate"].Value, new DateTime(1900, 1, 1));
                obUnderLC.ExpDate = GlobalFunctions.isNull(dgvMasterLC.Rows[rowId].Cells["ExpDate"].Value, new DateTime(1900, 1, 1));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obUnderLC;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMasterLC.CurrentCell == null) return;
            try
            {
                int rowId = dgvMasterLC.CurrentCell.RowIndex;
                int slno = GlobalFunctions.isNull(dgvMasterLC.Rows[rowId].Cells["SLNo"].Value, 0);
                if (slno == 0)
                {
                    dgvMasterLC.Rows.RemoveAt(rowId);
                }
                else
                {
                    if (MessageBox.Show("Are you sure to delete the Items", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                    obDaLc.deleteUnderLc(formConnection, slno);
                    loadMasterLc();
                    MessageBox.Show("Deleted Successfully");
                }
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

        private void frmUnderLC_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void llblUnderLCID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmSearchLC objfrm = new frmSearchLC();
                objfrm.ShowDialog();

                if (objfrm == null) return;
                //txtLCNo.Text = objfrm.LCID.ToString();
                addLc(objfrm.LCID);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void addLc(int LcId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = obDaLc.getLc(formConnection, LcId);
                if (dt == null) return;
                dtLc.Rows.Add(
                    null, null, Convert.ToInt32(dt.Rows[0].Field<object>("LCID")),
                    dt.Rows[0].Field<object>("LCNo").ToString(),
                    dt.Rows[0].Field<DateTime>("LCDate"),
                    dt.Rows[0].Field<DateTime>("ShipmentDate"),
                    dt.Rows[0].Field<DateTime>("ExpireDate")
                    );
                //dgvMasterLC.DataSource = dtLc;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmUnderLC_Paint(object sender, PaintEventArgs e)
        {
            FormColorClass.ColorForm(this, e);
        }
    }
}
