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

namespace Accounting.UI
{
    public partial class frmOrderAmend : Form
    {
        public frmOrderAmend()
        {
            InitializeComponent();
        }
        private int _OrderID;
        
        private DataTable dtAmendment=new DataTable();
        private SqlConnection formCon=null;

        public void ShowDialog(int OrderID)
        {
            _OrderID = OrderID;
            this.ShowDialog();
        }

        private void frmSalesOrderAmend_Load(object sender, EventArgs e)
        {
            try
            {
                formCon = ConnectionHelper.getConnection();
                loadAmendment(_OrderID,-1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadAmendment(int orderID, int amendID)
        {
            try
            {
                dtAmendment = new DaOrder().SelectOrNewAmendment(formCon, orderID, amendID);
                dgvAmendOrder.DataSource = dtAmendment;
                dgvAmendOrder.setColumnsVisible(false, "OrderDID", "OrderMID", "ItemID", "Items", "UnitID", "PriceID", "AmendID");
                dgvAmendOrder.setColumnsReadOnly(true, "Item", "Items","Size","Color","Shade","Count","Unit","OrderQty","OrderValue","AmendValue");
                getTotalQty();
                if(dgvAmendOrder.Rows.Count >0)
                lblUnit.Text = dgvAmendOrder.Rows[0].Cells["Unit"].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvAmendOrder_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Black;
            e.CellStyle.ForeColor = Color.White;
        }

        private void dgvAmendOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvAmendOrder.Columns[e.ColumnIndex].Name.ToLower() == "amendqty" || dgvAmendOrder.Columns[e.ColumnIndex].Name.ToLower() == "unitprice")
                {
                    dgvAmendOrder.Rows[e.RowIndex].Cells["AmendValue"].Value = Convert.ToDouble(dgvAmendOrder.Rows[e.RowIndex].Cells["AmendQty"].Value == DBNull.Value ? 0 : dgvAmendOrder.Rows[e.RowIndex].Cells["AmendQty"].Value) * Convert.ToDouble(dgvAmendOrder.Rows[e.RowIndex].Cells["UnitPrice"].Value == DBNull.Value ? 0 : dgvAmendOrder.Rows[e.RowIndex].Cells["UnitPrice"].Value);
                }
                lblUnit.Text = dgvAmendOrder.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
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
                int nR = dgvAmendOrder.Rows.Count;
                for (int i = 0; i < nR; i++)
                {
                    Qty += Convert.ToDouble(dgvAmendOrder.Rows[i].Cells["AmendQty"].Value == DBNull.Value ? 0 : dgvAmendOrder.Rows[i].Cells["AmendQty"].Value);
                    TotalVal += Convert.ToDouble(dgvAmendOrder.Rows[i].Cells["AmendValue"].Value == DBNull.Value ? 0 : dgvAmendOrder.Rows[i].Cells["AmendValue"].Value);
                }
                txtTotalOrderQty.Text = Qty.ToString();
                txtTotalOrderVal.Text = TotalVal.ToString("0.00");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvAmendOrder.Rows.Count == 0 || Convert.ToDouble(txtTotalOrderQty.Text) == 0) return;

            SqlTransaction trans=null;
            try
            {
                if (btnSave.Text == "&Save")
                {
                    DaOrder objDaOrder = new DaOrder();
                    trans = formCon.BeginTransaction();
                    //objDaOrder.CreateAmendment(formCon, trans, _OrderID, dtpAmendDate.Value.Date, Convert.ToDouble(txtTotalOrderQty.Text), Convert.ToDouble(txtTotalOrderVal.Text), txtComment.Text);

                    int i, nR, ODID;
                    double OQty, Uprice, OValue, AQty, AValue;
                    nR = dgvAmendOrder.Rows.Count;
                    for (i = 0; i < nR; i++)
                    {
                        ODID = dgvAmendOrder["OrderDID", i].Value == DBNull.Value || dgvAmendOrder["OrderDID", i].Value == null ? 0 : Convert.ToInt32(dgvAmendOrder["OrderDID", i].Value);
                        OQty = dgvAmendOrder["OrderQty", i].Value == DBNull.Value || dgvAmendOrder["OrderQty", i].Value == null ? 0.0 : Convert.ToDouble(dgvAmendOrder["OrderQty", i].Value);
                        Uprice = dgvAmendOrder["UnitPrice", i].Value == DBNull.Value || dgvAmendOrder["UnitPrice", i].Value == null ? 0.0 : Convert.ToDouble(dgvAmendOrder["UnitPrice", i].Value);
                        OValue = dgvAmendOrder["OrderValue", i].Value == DBNull.Value || dgvAmendOrder["OrderValue", i].Value == null ? 0.0 : Convert.ToDouble(dgvAmendOrder["OrderValue", i].Value);
                        AQty = dgvAmendOrder["AmendQty", i].Value == DBNull.Value || dgvAmendOrder["AmendQty", i].Value == null ? 0.0 : Convert.ToDouble(dgvAmendOrder["AmendQty", i].Value);
                        AValue = dgvAmendOrder["AmendValue", i].Value == DBNull.Value || dgvAmendOrder["AmendValue", i].Value == null ? 0.0 : Convert.ToDouble(dgvAmendOrder["AmendValue", i].Value);

                        //objDaOrder.UpdateOrderDetail(formCon, trans, _OrderID, ODID, OQty + AQty, Uprice, OValue + AValue);
                        //objDaOrder.UpdateOrderItemAmendment(formCon, trans, _OrderID, ODID, AQty, AValue);
                    }
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
                loadAmendment(-1, -1);
                dtpAmendDate.Value = DateTime.Now;
                txtComment.Text = string.Empty;
                txtTotalOrderQty.Text = "0.0";
                txtTotalOrderVal.Text = "0.0";
                groupBox1.Text = "New Amendment";
                //btnSave.Text = "&Save";
                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                if (sender.Equals(btnReset))
                {
                    MessageBox.Show(ex.Message);
                }
                else
                    throw ex;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                frmFindOrderAmendment frm = new frmFindOrderAmendment();
                frm.ShowDialog(_OrderID);
                int AmendID = frm.SelectedAmendID;
                if (AmendID == 0) return;
                loadAmendment(_OrderID, AmendID);
                dtpAmendDate.Value = frm.AmendmentDate;
                txtComment.Text = frm.Comment;
                groupBox1.Text = "Edit Amendment";
                //btnSave.Text = "&Edit";
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmSalesOrderAmend_Paint(object sender, PaintEventArgs e)
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
