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
    public partial class frmInventoryRequisition : Form
    {
        private SqlConnection formConnection = null;
        private DataTable dtReqDetail = null;
        private DataTable dtSection = null;
        public frmInventoryRequisition()
        {
            InitializeComponent();
        }

        private void frmInventoryRequisition_Load(object sender, EventArgs e)
        {
            formConnection = ConnectionHelper.getConnection();
            loadSection();
            loadReqDetail(-4);
            loadItem();
            loadCounts();
            loadSizes();
            loadColors();
        }
        private void loadItem()
        {
            DataTable Items = new DataTable();
            try
            {
                Items = new DAChartsOfItem().getItemsForGrid(formConnection);
                ColItemID.DataSource = Items;
                ColItemID.DisplayMember = "ItemName";
                ColItemID.ValueMember = "ItemID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadCounts()
        {
            DataTable dtCounts = new DataTable();
            try
            {
                dtCounts = new DaCounts().getCountsForGrid(formConnection);
                ColCountID.DataSource = dtCounts;
                ColCountID.DisplayMember = "CountName";
                ColCountID.ValueMember = "CountID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadSizes()
        {
            DataTable dtSizes = new DataTable();
            try
            {
                dtSizes = new DaSizes().getSizesForGrid(formConnection);
                ColSizeID.DataSource = dtSizes;
                ColSizeID.DisplayMember = "SizesName";
                ColSizeID.ValueMember = "SizesID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadColors()
        {
            DataTable dtColors = new DataTable();
            try
            {
                dtColors = new Dacolors().getColorsForGrid(formConnection);
                ColColorID.DataSource = dtColors;
                ColColorID.DisplayMember = "ColorsName";
                ColColorID.ValueMember = "ColorsID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadSection()
        {
            try
            {
                DaInventoryRequisition obDaReq = new DaInventoryRequisition();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dtSection = obDaReq.loadSection(formConnection);
                cboReqSection.DataSource = dtSection;
                cboReqSection.DisplayMember = "Name";
                cboReqSection.ValueMember = "SectionID";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void loadReqDetail(int ReqMID)
        {
            dtReqDetail = new DataTable();
            try
            {
                if (dgvReqDetail.Rows.Count > 1) dgvReqDetail.Rows.Clear();

                int i, nR;

                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                DaInventoryRequisition obDaReq = new DaInventoryRequisition();
                dtReqDetail = obDaReq.loadReqDetail(formConnection, ReqMID);
                nR = dtReqDetail.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    dgvReqDetail.Rows.Add(new object[] { 
                        dtReqDetail.Rows[i].Field<object>("ReqDID"),dtReqDetail.Rows[i].Field<object>("ItemID"),
                        dtReqDetail.Rows[i].Field<object>("CountID"),dtReqDetail.Rows[i].Field<object>("SizeID"),
                        dtReqDetail.Rows[i].Field<object>("ColorID"),dtReqDetail.Rows[i].Field<object>("Specifications"),
                        dtReqDetail.Rows[i].Field<object>("Budle_Pack_Size"),dtReqDetail.Rows[i].Field<object>("Budle_Pack_Qty"),dtReqDetail.Rows[i].Field<object>("ReqQty"),
                        dtReqDetail.Rows[i].Field<object>("UnitID"),dtReqDetail.Rows[i].Field<object>("Unit")
                        
                    });
                }
                //dgvReqDetail.DataSource = dtReqDetail;
                /*
                dgvReqDetail.setColumnsVisible(false, "ReqDID", "ReqMID", "ItemID", "Shade", "UnitID");
                dgvReqDetail.setColumnsReadOnly(true, "Item", "Color", "Count", "Size", "Shade", "Unit");
                dgvReqDetail.setColumnsFormat(new string[] { "ReqQty" }, "0.00");
                dgvReqDetail.Columns["ReqQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvReqDetail.setColumnsWidth(new string[] { "Item", "Color", "Count", "Size", "Unit" }, 150, 70, 70, 70, 70, 70);
                 * */
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private bool Validation()
        {
            if (txtReqNo.Text.Trim() == "")
            {
                MessageBox.Show("Enter a valid Requisition no.");
                return false;
            }
            if (dgvReqDetail.Rows.Count == 0)
            {
                MessageBox.Show("Its not a valid order without items." + Environment.NewLine + "Please input items and their quantity");
                return false;
            }
            if (cboReqSection.SelectedValue == null)
            {
                MessageBox.Show("Requisition section not load properly");
                return false;
            }

            return true;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation() == false) return;
            SqlTransaction trans = null;
            int ReqMID = 0;
            ReqMaster obReqMaster=new ReqMaster();
            ReqDetail obReqDetail=new ReqDetail();
            DaInventoryRequisition obDaReq = new DaInventoryRequisition();
            try
            {
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                trans = formConnection.BeginTransaction();

                //Save ReqMaster
                obReqMaster = createReqMaster();
                ReqMID = obDaReq.SaveUpdateReqMaster(obReqMaster, formConnection, trans);

                //Save ReqDetail
                int i, nR;
                nR = dgvReqDetail.Rows.Count;
                for (i = 0; i < nR - 1; i++)
                {
                    obReqDetail = createReqDetail(ReqMID, i);
                    obDaReq.SaveUpdateReqDetail(obReqDetail, formConnection, trans);
                }
                trans.Commit();
                MessageBox.Show("Save Successfull");
                resetRequisition();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                MessageBox.Show("Unable to Save " + ex.Message);
            }
        }
        private ReqMaster createReqMaster()
        {
            ReqMaster obReqMaster = new ReqMaster();
            try
            {
                obReqMaster.ReqMID = Convert.ToInt32(txtReqMID.Text);
                obReqMaster.ReqNo = txtReqNo.Text;
                obReqMaster.ReqDate = dtpReqDate.Value.Date;
                obReqMaster.ReqSectionID = Convert.ToInt32(cboReqSection.SelectedValue);
                obReqMaster.ReqBy = txtReqBy.Text;
                obReqMaster.Remarks = rtxtRemarks.Text;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obReqMaster;
        }
        private ReqDetail createReqDetail(int ReqMID, int rowID)
        {
            ReqDetail obReqDetail = new ReqDetail();
            try
            {
                obReqDetail.ReqDID = GlobalFunctions.isNull(dgvReqDetail[ColReqDID.Name, rowID].Value, 0);
                obReqDetail.ReqMID = ReqMID;
                obReqDetail.ItemID = GlobalFunctions.isNull(dgvReqDetail[ColItemID.Name, rowID].Value, 0);
                obReqDetail.CountID = GlobalFunctions.isNull(dgvReqDetail[ColCountID.Name, rowID].Value, 0);
                obReqDetail.SizeID = GlobalFunctions.isNull(dgvReqDetail[ColSizeID.Name, rowID].Value, 0);
                obReqDetail.ColorID = GlobalFunctions.isNull(dgvReqDetail[ColColorID.Name, rowID].Value, 0);
                obReqDetail.ReqQty = GlobalFunctions.isNull(dgvReqDetail[ColReqQty.Name, rowID].Value, 0.00);
                obReqDetail.UnitID = GlobalFunctions.isNull(dgvReqDetail[ColUnitID.Name, rowID].Value, 0);
                obReqDetail.Budle_Pack_Qty = GlobalFunctions.isNull(dgvReqDetail[Budle_Pack_Qty.Name, rowID].Value, "");
                obReqDetail.Specifications = GlobalFunctions.isNull(dgvReqDetail[Specifications.Name, rowID].Value, "");
                obReqDetail.Budle_Pack_Size = GlobalFunctions.isNull(dgvReqDetail[Budle_Pack_Size.Name, rowID].Value, "");

                //GlobalFunctions.isNull(dgvReqDetail[ColReqDID.Name, rowID].Value, 0);
                //dgvReqDetail.Rows[rowID].Cells["ColItemID"].Value == DBNull.Value || dgvReqDetail.Rows[rowID].Cells["ColItemID"].Value == null ? 0 : Convert.ToInt32(dgvReqDetail.Rows[rowID].Cells["ColItemID"].Value);
                //dgvReqDetail.Rows[rowID].Cells["ColReqDID"].Value == DBNull.Value || dgvReqDetail.Rows[rowID].Cells["ColReqDID"].Value == null ? 0 : Convert.ToInt32(dgvReqDetail.Rows[rowID].Cells["ColReqDID"].Value);
                //dgvReqDetail.Rows[rowID].Cells["ColCountID"].Value == DBNull.Value || dgvReqDetail.Rows[rowID].Cells["ColCountID"].Value == null ? 0 : Convert.ToInt32(dgvReqDetail.Rows[rowID].Cells["ColCountID"].Value);
                //dgvReqDetail.Rows[rowID].Cells["ColColorCode"].Value.ToString();
                //dgvReqDetail.Rows[rowID].Cells["ColSizeID"].Value == DBNull.Value || dgvReqDetail.Rows[rowID].Cells["ColSizeID"].Value == null ? 0 : Convert.ToInt32(dgvReqDetail.Rows[rowID].Cells["ColSizeID"].Value);
                //dgvReqDetail.Rows[rowID].Cells["ColColorID"].Value == DBNull.Value || dgvReqDetail.Rows[rowID].Cells["ColColorID"].Value == null ? 0 : Convert.ToInt32(dgvReqDetail.Rows[rowID].Cells["ColColorID"].Value);
                //dgvReqDetail.Rows[rowID].Cells["ColRemarks"].Value.ToString();
                //dgvReqDetail.Rows[rowID].Cells["ColUnitID"].Value == DBNull.Value || dgvReqDetail.Rows[rowID].Cells["ColUnitID"].Value == null ? 0 : Convert.ToInt32(dgvReqDetail.Rows[rowID].Cells["ColUnitID"].Value);
                //dgvReqDetail.Rows[rowID].Cells["ColLabdip"].Value.ToString();
                //Convert.ToDouble(dgvReqDetail.Rows[rowID].Cells["ColReqQty"].Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obReqDetail;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetRequisition();
        }
        private void resetRequisition()
        {
            try
            {
                txtReqMID.Text = "0";
                txtReqBy.Text = "";
                txtReqNo.Text = "";
                if (dtSection.Rows.Count > 0)
                    cboReqSection.SelectedIndex = 0;
                rtxtRemarks.Text = "";
                dtpReqDate.Value = DateTime.Now.Date;
                loadReqDetail(-4);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                ReqMaster obReqMaster = new ReqMaster();
                frmFindRequisition obReq = new frmFindRequisition();
                obReq.ShowDialog();
                obReqMaster = obReq.obReqMaster;
                if (obReqMaster == null) return;
                txtReqBy.Text = obReqMaster.ReqBy.ToString();
                txtReqMID.Text = obReqMaster.ReqMID.ToString();
                txtReqNo.Text = obReqMaster.ReqNo.ToString();
                rtxtRemarks.Text = obReqMaster.Remarks.ToString();
                cboReqSection.SelectedValue = obReqMaster.ReqSectionID;
                dtpReqDate.Value = obReqMaster.ReqDate.Date;
                loadReqDetail(obReqMaster.ReqMID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (formConnection.State != ConnectionState.Open)
                formConnection.Open();
            SqlTransaction trans = formConnection.BeginTransaction();
            int ReqID = 0;
            ReqID = Convert.ToInt32(txtReqMID.Text);
            if (ReqID == 0) return;
            if (MessageBox.Show("Are You Sure To Delete The Selected Row", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            DaInventoryRequisition obDaReq = new DaInventoryRequisition();
            try
            {
                obDaReq.DeleteRequisition(formConnection, trans, ReqID);
                trans.Commit();
                MessageBox.Show("Delete Successfull");
                resetRequisition();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                MessageBox.Show("Error occured due to " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvReqDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void loadItems()
        {
            try
            {
                frmItemSearch frm = new frmItemSearch();
                frm.ShowDialog();
                string Items = frm.ItemList;
                if (Items == "") return;
                addItems(Items);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void addItems(string Items)
        {
            try
            {
                string where = " WHERE ItemID IN " + Items;
                //string Cols = "ItemID,ItemName AS Item,ColorsName AS Color,CountName AS Count,SizesName AS Size,ShadeNo AS Shade ,UnitID,UnitsName AS Unit ";
                string Cols = "ItemID, UnitID, UnitsName AS Unit";
                DataTable dt = new DAChartsOfItem().GetItems(where, Cols, formConnection);
                int i, nR = dt.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    dgvReqDetail.Rows.Add(new object[]{ 
                        null, dt.Rows[i].Field<object>("ItemID"),null,null,null,null, null,null,
                        dt.Rows[i].Field<object>("UnitID"), dt.Rows[i].Field<object>("Unit")
                    });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void dgvReqDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvReqDetail.Columns[dgvReqDetail.CurrentCell.ColumnIndex].CellType.Name == "DataGridViewComboBoxCell")
                SendKeys.Send("{F4}");
            else
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void frmInventoryRequisition_Paint(object sender, PaintEventArgs e)
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

        private void dgvReqDetail_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReqDetail.Columns[e.ColumnIndex].ReadOnly == true)
                SendKeys.Send("{TAB}");
        }

        private void llblItems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                loadItems();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region report variable
            frmReportViewer frmRV = new frmReportViewer();
            ParameterValues pvc = new ParameterValues();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();

            #endregion
            try
            {

                rptStoreRequisitionSlip rptReq = new rptStoreRequisitionSlip();

                pdv.Value = Convert.ToInt32(txtReqMID.Text);
                pvc.Add(pdv);
                rptReq.DataDefinition.ParameterFields["@ReqMID"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptReq.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
               
                frmRV.ShowDialog(rptReq, false);

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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvReqDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex == -1)
                    return;
                //if (dgvReqDetail.Columns[e.ColumnIndex].Name.ToLower() == "colopeningqty" || dgvReqDetail.Columns[e.ColumnIndex].Name.ToLower() == "colunitprice")
                //{
                //    dgvReqDetail.Rows[e.RowIndex].Cells["ColOpeningAmount"].Value = Convert.ToDouble(dgvReqDetail.Rows[e.RowIndex].Cells["ColOpeningQty"].Value == DBNull.Value ? 0 : dgvReqDetail.Rows[e.RowIndex].Cells["ColOpeningQty"].Value) * Convert.ToDouble(dgvReqDetail.Rows[e.RowIndex].Cells["ColUnitPrice"].Value == DBNull.Value ? 0.0 : dgvReqDetail.Rows[e.RowIndex].Cells["ColUnitPrice"].Value);
                //}
                if (dgvReqDetail.Columns[e.ColumnIndex].Name == ColItemID.Name)
                    dgvReqDetail[ColUnit.Name, e.RowIndex].Value = new DAChartsOfItem().getUnitOfItem(formConnection, GlobalFunctions.isNull(dgvReqDetail[ColItemID.Name, e.RowIndex].Value, 0));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReqDetail.CurrentCell == null)
                    return;
                int rowID = 0;
                rowID = dgvReqDetail.CurrentCell.RowIndex;
                int ReqDID = 0;
                ReqDID = GlobalFunctions.isNull(dgvReqDetail[ColReqDID.Name, rowID].Value, 0);//Convert.ToInt32(dgvOrderDetails.Rows[rowID].Cells["OrderDID"].Value == DBNull.Value ? 0 : dgvOrderDetails.Rows[rowID].Cells["OrderDID"].Value);

                if (ReqDID == 0)
                {
                    dgvReqDetail.Rows.RemoveAt(rowID);

                }
                else
                {
                    if (MessageBox.Show("Are you sure to delete the Items", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                    DaInventoryRequisition obDaReq = new DaInventoryRequisition();
                    if (formConnection.State != ConnectionState.Open)
                        formConnection.Open();


                    obDaReq.DeleteItem(formConnection, ReqDID);
                    loadReqDetail(int.Parse(txtReqMID.Text));
                    MessageBox.Show("Delete Successful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmInventoryRequisition_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void txtReqNo_Enter(object sender, EventArgs e)
        {
            Control conl = (Control)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            //conl.SelectAll();
        }

        private void txtReqNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtReqNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }
    }
}
