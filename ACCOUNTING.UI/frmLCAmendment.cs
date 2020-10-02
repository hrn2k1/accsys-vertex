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
    public partial class frmLCAmendment : Form
    {
        SqlConnection conn = ConnectionHelper.getConnection();
        int LCMID = 0;
        double _PrevLCqty, _PrevLCvalue;
        public frmLCAmendment()
        {
            InitializeComponent();
        }
        public frmLCAmendment(int d)
        {
            InitializeComponent();
            LCMID = d;
        }
        public frmLCAmendment(int d,double PrevLCqty,double PrevLCvalue)
        {
            InitializeComponent();
            LCMID = d;
            _PrevLCqty=PrevLCqty;
            _PrevLCvalue = PrevLCvalue;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLCAmendment_Load(object sender, EventArgs e)
        {
            try
            {
                DaLC objDALC = new DaLC();
                DataTable dt = new DataTable();
                dt = objDALC.GetLCDTLAmend(LCMID, conn);
                ctlDGVLCAmend.DataSource = dt;
                ctlDGVLCAmend.setColumnsVisible(false,"LCID","LCDetailID","PIMID");
                ctlDGVLCAmend.setColumnsReadOnly(true,"PINO","OrderNo","Item","Size","Color","Shade","Count","Unit","OrderQty","OrderValue","AmendValue");
                txtPrevLCQty.Text = _PrevLCqty.ToString("0.00");
                txtPrevLCvalue.Text = _PrevLCvalue.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("there is an error."+ex);
            }
        }

        private void ctlDGVLCAmend_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (ctlDGVLCAmend.Columns[e.ColumnIndex].Name.ToLower() == "amendqty" || ctlDGVLCAmend.Columns[e.ColumnIndex].Name.ToLower() == "unitprice")
                {
                    ctlDGVLCAmend.Rows[e.RowIndex].Cells["AmendValue"].Value = Convert.ToDouble(ctlDGVLCAmend.Rows[e.RowIndex].Cells["AmendQTY"].Value == DBNull.Value ? 0 : ctlDGVLCAmend.Rows[e.RowIndex].Cells["AmendQTY"].Value) * Convert.ToDouble(ctlDGVLCAmend.Rows[e.RowIndex].Cells["UnitPrice"].Value == DBNull.Value ? 0 : ctlDGVLCAmend.Rows[e.RowIndex].Cells["UnitPrice"].Value);
                }
                //lblUnit.Text = ctlDGVLCAmend.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
                getTotalQty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void getTotalQty()
        {
            double Qty = 0;
            double TotalVal = 0.0;
            try
            {
                int nR = ctlDGVLCAmend.Rows.Count;
                for (int i = 0; i < nR; i++)
                {
                    Qty += Convert.ToDouble(ctlDGVLCAmend.Rows[i].Cells["AmendQTY"].Value == DBNull.Value ? 0 : ctlDGVLCAmend.Rows[i].Cells["AmendQTY"].Value);
                    TotalVal += Convert.ToDouble(ctlDGVLCAmend.Rows[i].Cells["AmendValue"].Value == DBNull.Value ? 0 : ctlDGVLCAmend.Rows[i].Cells["AmendValue"].Value);
                }
                txtLCQTY.Text = Qty.ToString();
                txtLCValue.Text = TotalVal.ToString("0.00");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ctlDGVLCAmend_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (ctlDGVLCAmend.Columns[e.ColumnIndex].ReadOnly == true)
                SendKeys.Send("{TAB}");
        }

        private void ctlDGVLCAmend_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Black;
            e.CellStyle.ForeColor = Color.White;
        }

        private void ctlDGVLCAmend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmLCAmendment_Paint(object sender, PaintEventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtLCQTY.Text) == 0 && Convert.ToDouble(txtLCValue.Text) == 0) return;

            SqlTransaction trans = null;
            try
            {
                if (btnSave.Text == "&Save")
                {
                    DaLC objDaLC = new DaLC();
                    trans = conn.BeginTransaction();
                   
                    objDaLC.CreateAmendment(conn, trans, LCMID, DTPAmend.Value.Date, Convert.ToDouble(txtLCQTY.Text), Convert.ToDouble(txtLCValue.Text), txtComment.Text);

                    //int i, nR, ODID;
                    //double OQty, Uprice, OValue, AQty, AValue;
                    //nR = dgvAmendOrder.Rows.Count;
                    //for (i = 0; i < nR; i++)
                    //{
                    //    ODID = dgvAmendOrder["OrderDID", i].Value == DBNull.Value || dgvAmendOrder["OrderDID", i].Value == null ? 0 : Convert.ToInt32(dgvAmendOrder["OrderDID", i].Value);
                    //    OQty = dgvAmendOrder["OrderQty", i].Value == DBNull.Value || dgvAmendOrder["OrderQty", i].Value == null ? 0.0 : Convert.ToDouble(dgvAmendOrder["OrderQty", i].Value);
                    //    Uprice = dgvAmendOrder["UnitPrice", i].Value == DBNull.Value || dgvAmendOrder["UnitPrice", i].Value == null ? 0.0 : Convert.ToDouble(dgvAmendOrder["UnitPrice", i].Value);
                    //    OValue = dgvAmendOrder["OrderValue", i].Value == DBNull.Value || dgvAmendOrder["OrderValue", i].Value == null ? 0.0 : Convert.ToDouble(dgvAmendOrder["OrderValue", i].Value);
                    //    AQty = dgvAmendOrder["AmendQty", i].Value == DBNull.Value || dgvAmendOrder["AmendQty", i].Value == null ? 0.0 : Convert.ToDouble(dgvAmendOrder["AmendQty", i].Value);
                    //    AValue = dgvAmendOrder["AmendValue", i].Value == DBNull.Value || dgvAmendOrder["AmendValue", i].Value == null ? 0.0 : Convert.ToDouble(dgvAmendOrder["AmendValue", i].Value);

                    //    objDaOrder.UpdateOrderDetail(formCon, trans, _OrderID, ODID, OQty + AQty, Uprice, OValue + AValue);
                    //    objDaOrder.UpdateOrderItemAmendment(formCon, trans, _OrderID, ODID, AQty, AValue);
                    //}
                    trans.Commit();
                    btnReset_Click(sender, null);
                    MessageBox.Show("Amendment Successfully Saved");
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                DaLC objDALC = new DaLC();
                DataTable dt = new DataTable();
                dt = objDALC.GetLCDTLAmend(-1, conn);
                ctlDGVLCAmend.DataSource = dt;
                ctlDGVLCAmend.setColumnsVisible(false, "LCID", "LCDetailID", "PIMID");
                ctlDGVLCAmend.setColumnsReadOnly(true, "PINO", "OrderNo", "Item", "Size", "Color", "Shade", "Count", "Unit", "OrderQty", "OrderValue", "AmendValue");

                DTPAmend.Value = DateTime.Now;
                txtComment.Text = string.Empty;
                txtLCQTY.Text = "0.0";
                txtLCValue.Text = "0.0";
                groupBox1.Text = "New Amendment";
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("there is an error" + ex);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                gbxAmend.Visible = true;
                gbxAmend.BringToFront();
                DataTable dtA = new DaLC().getAmendments(conn, LCMID);
                ctlDaraGridView1.DataSource = dtA;
                ctlDaraGridView1.setColumnsVisible(false, "LCID", "TotalQty", "TotalValue", "AmendQty", "AmendUnitPrice", "AmendValue");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void llblCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gbxAmend.Visible = false;
           
        }

        private void ctlDaraGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                txtComment.Text =ctlDaraGridView1.Rows[r].Cells["AmendComment"].Value.ToString();
                txtPrevLCQty.Text =Convert.ToDouble( ctlDaraGridView1.Rows[r].Cells["TotalQty"].Value).ToString("0.00");
                txtPrevLCvalue.Text = Convert.ToDouble(ctlDaraGridView1.Rows[r].Cells["TotalValue"].Value).ToString("0.00");
                txtLCQTY.Text = Convert.ToDouble(ctlDaraGridView1.Rows[r].Cells["AmendQty"].Value).ToString("0.00");
                txtLCValue.Text = Convert.ToDouble(ctlDaraGridView1.Rows[r].Cells["AmendValue"].Value).ToString("0.00");
                DTPAmend.Value = Convert.ToDateTime(ctlDaraGridView1.Rows[r].Cells["AmendDate"].Value);
                //llblCancel_LinkClicked(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gbxAmend_VisibleChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = ! gbxAmend.Visible;
        }

        
    }
}
