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
using Accounting.Entity;
using CrystalDecisions.Shared;
using Accounting.Reports;

namespace Accounting.UI
{
    public partial class frmPI : Form
    {
        SqlConnection conn = ConnectionHelper.getConnection();
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        DataTable dtPIOrders = new DataTable();
        int PImID = 0;
        public frmPI()
        {
            InitializeComponent();
        }
        string Orders = string.Empty;
        DataTable dtTermsConds = new DataTable();
        CurrencyManager cmTermsConds = null;
        private void frmPI_Load(object sender, EventArgs e)
        {
            try
            {
                rbDefault.ForeColor = Color.Red;
                // txtPINO.Text = GeneratePINO();
                txtPINO.Text = DaCompanySettings.GeneratePINO();
                cmbPIType.Focus();
                PI_Print_Settings objPrinting = new PI_Print_Settings();
                DaPI objDA = new DaPI();
                objPrinting = objDA.GetPrittingItems(conn);
                txtTemrs.Text = objPrinting.Terms;
                txtItem.Text = objPrinting.Condition;
                cmbPIType.SelectedIndex = 0;
                loadCurrency();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void LoadTerms()
        //{
        //    try
        //    {
        //        dtTermsConds = new DaPI().GetPrittingItemsTable(conn);
        //        cmTermsConds=(CurrencyManager)this.BindingContext[dtTermsConds];
        //        cboTermsCond.DataSource = cmTermsConds;
        //        cboTermsCond.DisplayMember = "";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private string GeneratePINO()
        {
            DaPI obj = new DaPI();
            string ad = obj.GetMaxID(conn);

            string ss = ad.PadLeft(5, '0');
            ss = "PI" + ss;
            return ss;

        }



        //private void btnCustomer_Click(object sender, EventArgs e)
        //{
        //    if (cmbPIType.Text == "")
        //    {
        //        MessageBox.Show("Select a PI type");
        //        return;
        //    }
        //    if (txtPINO.Text == "")
        //    {
        //        MessageBox.Show("Select a PI No");
        //        return;
        //    }
        //    if (label3.Text == "Supplier")
        //    {
        //        try
        //        {
        //            Ledgers objSupplier;
        //            int SuppliersID = 0;
        //            string SuppliersName = "";
        //            frmSupplierSearch frmSup = new frmSupplierSearch();
        //            frmSup.ShowDialog();
        //            objSupplier = frmSup.SelectedSupplier;
        //            if (frmSup == null) return;
        //            if (objSupplier == null) return;
        //            SuppliersID = objSupplier.LedgerID;
        //            SuppliersName = objSupplier.LedgerName;
        //            txtCustomerID.Text = SuppliersID.ToString();
        //            txtCustomer.Text = SuppliersName;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    else
        //    {

        //        try
        //        {
        //            Ledgers objCustomers;
        //            int CustomersID = 0;
        //            string CustomersName = "";
        //            //frmCustomer obCustomer = new frmCustomer();
        //            frmSearchCustomer frmCusr = new frmSearchCustomer();
        //            frmCusr.ShowDialog();
        //            //obCustomer.ShowDialog();
        //            objCustomers = frmCusr.ReturnCustomerID();
        //            if (frmCusr == null) return;
        //            if (objCustomers == null) return;
        //            CustomersID = objCustomers.LedgerID;
        //            CustomersName = objCustomers.LedgerName;
        //            //if (CustomerID == 0) return;
        //            txtCustomer.Text = CustomersName;
        //            txtCustomerID.Text = CustomersID.ToString();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //    }

        //}

        //private void rbCustome_CheckedChanged(object sender, EventArgs e)
        //{
        //    bool state = rbCustome.Checked;
        //    if (state == true)
        //    {
        //        txtPINO.Enabled = true;
        //        txtPINO.Text = "";
        //    }
        //}

        //private void rbDefault_CheckedChanged(object sender, EventArgs e)
        //{
        //    bool state = rbDefault.Checked;
        //    if (state == true)
        //    {
        //        txtPINO.Enabled = false;
        //        txtPINO.Text = GeneratePINO();
        //    }
        //}

        private void loadFactoryInCMB()
        {
            DaPI obj = new DaPI();
            DataTable dt = new DataTable();
            int df;
            if (txtCustomerID.Text == "")
            { df = 0; }
            else
            {
                df = int.Parse(txtCustomerID.Text);
            }
            dt = obj.LoadFactoryIncmb(df, conn);
            cmbFactory.DataSource = dt;
            cmbFactory.DisplayMember = "FactoryName";
            cmbFactory.ValueMember = "FactoryID";

        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            loadFactoryInCMB();
        }
        /*
        private void GetFrom()
        {
            if (cmbPIType.Text == "Supplier")
            {
                lblCustSupp.Text = "Supplier";
                label5.Visible = false;
                cmbFactory.Visible = false;
            }
            else
            {
                lblCustSupp.Text = "Customer";
                label5.Visible = true; ;
                cmbFactory.Visible = true;
                return; 
            }
        }
        private void cmbPIType_SelectedValueChanged(object sender, EventArgs e)
        {
            GetFrom(); 
        }
        */
        private void cmbPIType_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cmbPIType.Text == "To Customer")
            {
                lblCustSupp.Text = "Customer";
                lblFactory.Visible = true;
                cmbFactory.Visible = true;
                gbxTerms.Visible = true;
                dgvOrderRefNo.Height = 180;
            }
            else
            {
                lblCustSupp.Text = "Supplier";
                lblFactory.Visible = false;
                cmbFactory.Visible = false;
                gbxTerms.Visible = false;
                dgvOrderRefNo.Height = 180 + 130;
            }
        }

        //private void btnOrderRefNo_Click(object sender, EventArgs e)
        //{
        //    if (txtCustomerID.Text == "0")
        //    {
        //        MessageBox.Show("Select a Customer/Supplier");
        //        return;
        //    }
        //    else
        //    {
        //        frmSearchOrderNo frmOrder = new frmSearchOrderNo();
        //        frmOrder.ShowDialog(int.Parse(txtCustomerID.Text));
        //         Orders = frmOrder.OrderList;
        //        if (Orders == "") return;
        //        string where = " WHERE OrderMID IN " + Orders;
        //        dt = new DaPI().GetOrderRefNo(where, conn);
        //        DGVOrderRefNo.DataSource = dt;
        //        //DGVOrderRefNo.Columns["OrderMID"].Visible = false;
        //    }
        //}

        //private void cmbPIType_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        SelectNextControl((Control)sender, true, true, true, true); 
        //}

        //private void rbDefault_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        SelectNextControl((Control)sender, true, true, true, true);

        //          if (cmbPIType.Text == "")
        //    {
        //        MessageBox.Show("Select a PI type");
        //        return;
        //    }
        //    if (txtPINO.Text == "")
        //    {
        //        MessageBox.Show("Select a PI No");
        //        return;
        //    }
        //    if (label3.Text == "Supplier")
        //    {
        //        try
        //        {
        //            Ledgers objSupplier;
        //            int SuppliersID = 0;
        //            string SuppliersName = "";
        //            frmSupplierSearch frmSup = new frmSupplierSearch();
        //            frmSup.ShowDialog();
        //            objSupplier = frmSup.SelectedSupplier;
        //            if (frmSup == null) return;
        //            if (objSupplier == null) return;
        //            SuppliersID = objSupplier.LedgerID;
        //            SuppliersName = objSupplier.LedgerName;
        //            txtCustomerID.Text = SuppliersID.ToString();
        //            txtCustomer.Text = SuppliersName;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    else
        //    {

        //        try
        //        {
        //            Ledgers objCustomers;
        //            int CustomersID = 0;
        //            string CustomersName = "";
        //            //frmCustomer obCustomer = new frmCustomer();
        //            frmSearchCustomer frmCusr = new frmSearchCustomer();
        //            frmCusr.ShowDialog();
        //            //obCustomer.ShowDialog();
        //            objCustomers = frmCusr.ReturnCustomerID();
        //            if (frmCusr == null) return;
        //            if (objCustomers == null) return;
        //            CustomersID = objCustomers.LedgerID;
        //            CustomersName = objCustomers.LedgerName;
        //            //if (CustomerID == 0) return;
        //            txtCustomer.Text = CustomersName;
        //            txtCustomerID.Text = CustomersID.ToString();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //    }

        //}


        private void txtPINO_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
            //txtPINO_KeyDown(null, null);
        }

        private void txtPINO_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }
        private void cmbPIType_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }
        private void btnNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validation()
        {
            if (txtCustomer.Text == "")
            {
                MessageBox.Show("Select a Customer");
                return false;
            }
            if (dgvOrders.Rows.Count == 0)
            {
                MessageBox.Show("Empty Order " + Environment.NewLine + "Please select a Order Reference No");
                return false;
            }
            if (dgvOrderRefNo.Rows.Count == 0)
            {
                MessageBox.Show("Empty Order " + Environment.NewLine + "Please select a Order Reference No");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            try
            {
                if (validation() == false)
                    return;
                PI_Details objPIDTL = new PI_Details();
                PI_Master objPIMaster = new PI_Master();
                DaPI objDAPI = new DaPI();
                objPIMaster = CreatePI_MasterObject();
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                trans = conn.BeginTransaction();
                PImID = objDAPI.SaveUpdatePI_Master(objPIMaster, conn, trans);
                int l = Orders.Length;
                int OrderMID = 0;
                int nR = dgvOrders.Rows.Count;
                for (int i = 0; i < nR; i++)
                {


                    objPIDTL = CreatePI_DetailObject(PImID, OrderMID, i);
                    objDAPI.SaveUpdatePI_Details(objPIDTL, conn, trans);
                }
                
                trans.Commit();
                MessageBox.Show("Data saved successfully");
                loadCurrency();
                RefreshForm();

                //txtPINO.Text = GeneratePINO();
                txtPINO.Text = DaCompanySettings.GeneratePINO();
                cmbPIType.Focus();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }
        public PI_Master CreatePI_MasterObject()
        {
            PI_Master objMaster = null;
            try
            {
                objMaster = new PI_Master();
                objMaster.PIMID = PImID;
                objMaster.Rate = Convert.ToDouble(txtRate.Text);
                objMaster.PIType = cmbPIType.Text;
                objMaster.PINO = txtPINO.Text;
                objMaster.CurrencyID = (int)cmbCurrency.SelectedValue;
                objMaster.PIDate = dtpPIDate.Value.Date;
                objMaster.Attention = txtAttention.Text;
                if (objMaster.PIType == "From Supplier")
                    objMaster.FactoryID = 0;
                else
                    objMaster.FactoryID = (int)cmbFactory.SelectedValue;

                objMaster.CustomerOrSupplierID = Convert.ToInt32(txtCustomerID.Text);
                objMaster.TermsCondition = txtTemrs.Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMaster;
        }
        private PI_Details CreatePI_DetailObject(int PIMID, int OrderMID, int rowID)
        {
            try
            {
                PI_Details objDetail = new PI_Details();
                objDetail.PIDID = GlobalFunctions.isNull(dgvOrders["PIDID",rowID].Value,0) ;// dgvOrders.Rows[rowID].Cells["PIDID"].Value == DBNull.Value || dgvOrders.Rows[rowID].Cells["PIDID"].Value == null ? 0 : Convert.ToInt32(dgvOrders.Rows[rowID].Cells["PIDID"].Value);
                objDetail.PIMID = PIMID;
                objDetail.OrderID = Convert.ToInt32(dgvOrders.Rows[rowID].Cells["OrderID"].Value); // (int)DGVOrderRefNo.CurrentRow.Cells["OrderMID"].Value;
                objDetail.OrderQty = GlobalFunctions.isNull(dgvOrders.Rows[rowID].Cells["OrderQty"].Value,0.0);
                objDetail.OrderValue = GlobalFunctions.isNull(dgvOrders.Rows[rowID].Cells["OrderValue"].Value,0.0);
                return objDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RefreshForm()
        {
            txtAttention.Text = "";
            txtCustomer.Text = "";
            txtCustomerID.Text = "0";
           
            //txtPIMID.Text = "0";
            //txtPIDID.Text = "0";
            txtRate.Text = "1";
            if (dgvOrderRefNo.Columns.Count > 0) dgvOrderRefNo.Columns.Clear();
            dgvOrders.Rows.Clear();
            PImID = 0;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshForm();
                loadCurrency();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {


                    if (cmbPIType.Text == "")
                    {
                        MessageBox.Show("Select a PI type");
                        return;
                    }
                    if (txtPINO.Text == "")
                    {
                        MessageBox.Show("Select a PI No");
                        return;
                    }
                    if (lblCustSupp.Text == "Supplier")
                    {
                        Ledgers objSupplier;
                        int SuppliersID = 0;
                        string SuppliersName = "";
                        frmSupplierSearch frmSup = new frmSupplierSearch();
                        frmSup.ShowDialog();
                        objSupplier = frmSup.SelectedSupplier;
                        if (frmSup == null) return;
                        if (objSupplier == null) return;
                        SuppliersID = objSupplier.LedgerID;
                        SuppliersName = objSupplier.LedgerName;
                        txtCustomerID.Text = SuppliersID.ToString();
                        txtCustomer.Text = SuppliersName;
                        cmbCurrency.SelectedValue = objSupplier.CurrencyID;

                    }
                    else
                    {
                        Ledgers objCustomers = new Ledgers();
                        int CustomersID = 0;
                        string CustomersName = "";
                        frmCustomer frmCusr = new frmCustomer();
                        frmCusr.ShowDialog();
                        objCustomers = frmCusr.ReturnCustomerID();
                        if (objCustomers == null) return;
                        CustomersID = objCustomers.LedgerID;
                        CustomersName = objCustomers.LedgerName;
                        txtCustomer.Text = CustomersName;
                        txtCustomerID.Text = CustomersID.ToString();
                        cmbCurrency.SelectedValue = objCustomers.CurrencyID;
                    }

                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        private void rbDefault_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool state = rbDefault.Checked;
                if (state == true)
                {
                    //txtPINO.Text = GeneratePINO();
                    txtPINO.Text = DaCompanySettings.GeneratePINO();
                    txtPINO.Enabled = false;
                }
                else
                {
                    // txtPINO.Text = "";
                    txtPINO.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /*
              private void txtOrderRefNo_KeyDown(object sender, KeyEventArgs e)
              {
                  if (e.KeyCode == Keys.Enter)
                      SelectNextControl((Control)sender, true, true, true, true);

                  if (txtCustomerID.Text == "0")
                  {
                      MessageBox.Show("Select a Customer/Supplier");
                      return;
                  }
                  else
                  {
                      frmSearchOrderNo frmOrder = new frmSearchOrderNo();
                      frmOrder.ShowDialog(int.Parse(txtCustomerID.Text));
                      string Orders = frmOrder.OrderList;
                      if (Orders == "") return;
                      string where = " WHERE Order_Master.CompanyID=" + LogInInfo.CompanyID.ToString() + " AND Order_Master.OrderMID IN " + Orders;
                      dt = new DaPI().GetOrderRefNo(where, conn);
                      DGVOrderRefNo.DataSource = dt;
                      //DGVOrderRefNo.Columns["OrderMID"].Visible = false;
                  }
              }
        */
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomer.Text == "")
                {
                    MessageBox.Show("select a customer/supplier");
                    return;
                }

                string PIType = cmbPIType.SelectedItem.ToString();
                frmSearchPI frmobj = new frmSearchPI(PIType, Convert.ToInt32(txtCustomerID.Text));
                frmobj.ShowDialog();

                PImID = frmobj.PIMasterID;
                if (PImID <= 0) return;
                DaPI objdapi = new DaPI();

                PI_Master objpimaster = objdapi.GetPI_Master(PImID, conn);
                if (objpimaster == null) return;

                #region PI Master load
                cmbPIType.Text = objpimaster.PIType.ToString();

                txtRate.Text = objpimaster.Rate.ToString("0.00");
                txtPINO.Text = objpimaster.PINO.ToString();
                cmbCurrency.SelectedValue = objpimaster.CurrencyID;
                cmbFactory.SelectedValue = objpimaster.FactoryID;
                dtpPIDate.Value = objpimaster.PIDate;
                txtAttention.Text = objpimaster.Attention.ToString();
                txtTemrs.Text = objpimaster.TermsCondition;
                #endregion
                #region PI Detail load
                string where1 = " WHERE  PI.PIMID IS NOT NULL ";
                dtPIOrders = new DaPI().getPIDetail(conn, where1, PImID);
                if (dgvOrders.Rows.Count > 0) dgvOrders.Rows.Clear();
                int i, nR;
                nR = dtPIOrders.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    dgvOrders.Rows.Add(new object[] { dtPIOrders.Rows[i].Field<object>("PIDID"), dtPIOrders.Rows[i].Field<object>("PIMID")
                                                                ,dtPIOrders.Rows[i].Field<object>("OrderID"),dtPIOrders.Rows[i].Field<object>("OrderQty"),dtPIOrders.Rows[i].Field<object>("OrderValue") });
                }

                #endregion

                #region PI Data Show
                dtt = objdapi.GetPINoatTrans(PImID, conn);

                dgvOrderRefNo.DataSource = dtt;
                dgvOrderRefNo.Columns["PIDID"].Visible = false;
                dgvOrderRefNo.Columns["OrderMID"].Visible = false;
                //DGVOrderRefNo.Columns["ItemID"].Visible = false;

                dgvOrderRefNo.Columns["PIMID"].Visible = false;
                dgvOrderRefNo.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOrderRefNo.Columns["OrderQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOrderRefNo.Columns["OrderValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOrderRefNo.Columns["OrderQty"].DefaultCellStyle.Format = "0.00";
                dgvOrderRefNo.Columns["UnitPrice"].DefaultCellStyle.Format = "0.00";
                dgvOrderRefNo.Columns["OrderValue"].DefaultCellStyle.Format = "0.00";
                dgvOrderRefNo.Columns["OrderNo"].Width = 70;
                dgvOrderRefNo.Columns["ItemName"].Width = 100;
                dgvOrderRefNo.Columns["Count"].Width = 70;
                dgvOrderRefNo.Columns["Size"].Width = 70;
                dgvOrderRefNo.Columns["Prd.Type"].Width = 70;
                dgvOrderRefNo.Columns["ColorCode"].Width = 70;
                dgvOrderRefNo.Columns["Labdip"].Width = 70;
                dgvOrderRefNo.Columns["OrderQty"].Width = 70;
                dgvOrderRefNo.Columns["Unit"].Width = 50;
                dgvOrderRefNo.Columns["UnitPrice"].Width = 70;
                dgvOrderRefNo.Columns["OrderValue"].Width = 70;
                dgvOrderRefNo.Columns["C.Qty"].Width = 40;
                #endregion


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
                if (PImID <= 0) return;
                if (MessageBox.Show("Do you really want to delete the PI ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                DaPI objda = new DaPI();
                if (conn.State != ConnectionState.Open) conn.Open();
                objda.DeletePI(PImID, conn);
              
                //dtt = objda.GetPINoatTrans(PImID, conn);
                //dgvOrderRefNo.DataSource = dtt;
                RefreshForm();
                loadCurrency();
                MessageBox.Show("Data is deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + Environment.NewLine + "There is an error");
               
            }
        }
        private void txtCustomer_Click(object sender, EventArgs e)
        {

        }
        private void cmbPIType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }
        private void rbDefault_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }
        private void rbCustome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }
        private void txtPINO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }
        private void cmbFactory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }
        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }
        private void txtAttention_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }
        private void btnDelete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }
        private void rbDefault_Enter(object sender, EventArgs e)
        {
            Control cn = (Control)sender;
            cn.ForeColor = Color.Red;
        }
        private void rbCustome_Enter(object sender, EventArgs e)
        {
            Control cn = (Control)sender;
            cn.ForeColor = Color.Red;
        }
        private void rbDefault_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
        }
        private void rbCustome_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
        }
        private void frmPI_Paint(object sender, PaintEventArgs e)
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

        private void loadCurrency()
        {
            try
            {
                DataTable dtt = new DataTable();
                DaOrder objDAorder = new DaOrder();
                dtt = objDAorder.LoadCurrency(conn);
                cmbCurrency.DataSource = dtt;
                cmbCurrency.DisplayMember = "Code";
                cmbCurrency.ValueMember = "CurrencyID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error to load currency" + ex);
            }
        }

        private void btnPrintPI_Click(object sender, EventArgs e)
        {
            if (PImID == 0)
            {
                MessageBox.Show("Please Load a Proforma Invoice");
                return;
            }
            try
            {
                #region report variable
                frmReportViewer frmRV = new frmReportViewer();
                ParameterValues pvc = new ParameterValues();
                ParameterDiscreteValue pdv = new ParameterDiscreteValue();
                #endregion

                rptProformainvoice rpt = new rptProformainvoice();
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = PImID;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@PIMID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rpt, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void llblPIOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtCustomerID.Text == "0")
                {
                    MessageBox.Show("Select a Customer/Supplier");
                    return;
                }

                frmSearchOrderNo frmOrder = new frmSearchOrderNo();
                frmOrder.ShowDialog(int.Parse(txtCustomerID.Text));
                Orders = frmOrder.OrderList;
                if (Orders == "") return;

                #region PI Detail load
                string where1 = " WHERE OrderM.OrderMID IN " + Orders;
                dtPIOrders = new DaPI().getPIDetail(conn, where1, PImID);
                int i, nR;
                nR = dtPIOrders.Rows.Count;
                if (chkAddOrders.Checked == false) dgvOrders.Rows.Clear(); 
                for (i = 0; i < nR; i++)
                {
                    dgvOrders.Rows.Add(new object[] { dtPIOrders.Rows[i].Field<object>("PIDID"), dtPIOrders.Rows[i].Field<object>("PIMID")
                                                                ,dtPIOrders.Rows[i].Field<object>("OrderID"),dtPIOrders.Rows[i].Field<object>("OrderQty"),dtPIOrders.Rows[i].Field<object>("OrderValue") });
                }
                #endregion

                #region  Data Show
                string ONs = "(0";
                int j, R;
                R = dgvOrders.Rows.Count;
                for (j = 0; j < R; j++)
                {
                    ONs += "," + dgvOrders["OrderID", j].Value.ToString();


                }
                ONs += ")";
                string where = "WHERE OM.CompanyID=" + LogInInfo.CompanyID.ToString() + "  AND  OD.OrderMID IN" + ONs;
                dt = new DaPI().GetOrderRefNo(where, conn);



                dgvOrderRefNo.DataSource = dt;
                dgvOrderRefNo.Columns["PIDID"].Visible = false;
                dgvOrderRefNo.Columns["OrderMID"].Visible = false;
                dgvOrderRefNo.Columns["ItemID"].Visible = false;


                dgvOrderRefNo.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOrderRefNo.Columns["OrderQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOrderRefNo.Columns["OrderValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvOrderRefNo.Columns["OrderQty"].DefaultCellStyle.Format = "0.00";
                dgvOrderRefNo.Columns["UnitPrice"].DefaultCellStyle.Format = "0.00";
                dgvOrderRefNo.Columns["OrderValue"].DefaultCellStyle.Format = "0.00";
                dgvOrderRefNo.Columns["OrderNo"].Width = 70;
                dgvOrderRefNo.Columns["ItemName"].Width = 100;
                dgvOrderRefNo.Columns["Count"].Width = 70;
                dgvOrderRefNo.Columns["Size"].Width = 70;
                dgvOrderRefNo.Columns["Prd.Type"].Width = 70;
                dgvOrderRefNo.Columns["ColorCode"].Width = 70;
                dgvOrderRefNo.Columns["Labdip"].Width = 70;
                dgvOrderRefNo.Columns["OrderQty"].Width = 70;
                dgvOrderRefNo.Columns["Unit"].Width = 50;
                dgvOrderRefNo.Columns["UnitPrice"].Width = 70;
                dgvOrderRefNo.Columns["OrderValue"].Width = 70;
                dgvOrderRefNo.Columns["C.Qty"].Width = 40;

                #endregion

                SelectNextControl((Control)sender, true, true, true, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void llblPIOrder_Enter(object sender, EventArgs e)
        {
            llblPIOrder.BorderStyle = BorderStyle.FixedSingle;
        }

        private void llblPIOrder_Leave(object sender, EventArgs e)
        {
            llblPIOrder.BorderStyle = BorderStyle.None;
        }

        private void llblSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                new DaPI().UpdateT_PI_Print_Setting(txtTemrs.Text, conn);
                MessageBox.Show("Successfully set this terms & condition as default", "PI");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





    }


}
