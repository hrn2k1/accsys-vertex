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
    public partial class frmLC : Form
    {
        SqlConnection conn = ConnectionHelper.getConnection();
        public int PImID = 0;
        public int ForAmLCMID = 0;
         int LCmID = 0;
       public string PILists = string.Empty;

        DataTable dtt = new DataTable();
        public frmLC()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CHKUDDate_CheckedChanged(object sender, EventArgs e)
        {
            bool state = CHKUDDate.Checked;
            if (state == true)
            {
                CHKDocumentDate.Enabled = true;
                DTPUDDate.Visible = true;
            }
            else
            {
                CHKDocumentDate.Enabled = false;
                DTPUDDate.Visible = false;
                CHKDocumentDate.Checked = false;
            }
        }

        private void CHKDocumentDate_CheckedChanged(object sender, EventArgs e)
        {
            bool state = CHKDocumentDate.Checked;
            if (state == true)
            {
                DTPDocDate.Visible = true;
            }
            else
            {
                DTPDocDate.Visible = false;
            }
        }

        private void CHKNegotiationDate_CheckedChanged(object sender, EventArgs e)
        {
            bool state = CHKNegotiationDate.Checked;
            if (state == true)
            {
                DTPNegDate.Visible = true;
            }
            else
            {
                DTPNegDate.Visible = false;
            }
        }

        private void txtLCNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void cmbLCType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtMasterLCNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnGetLC.Enabled)
                    btnGetLC_Click(null, null);
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void cmbMasterLC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void cmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void cmbNeBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DTPLCDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }
        private void LoadIssuBank()
        {
            DaLC daobj = new DaLC();
            DataTable dtt = new DataTable();
            dtt = daobj.GetBank(conn);
            //dtt.Rows.Add(new object[] { 0, "N/A" });
            cmbBank.DataSource = dtt;
            cmbBank.DisplayMember = "LedgerName";
            cmbBank.ValueMember = "LedgerID";

        }
        private void LoadNegoBank()
        {
            DaLC daobj = new DaLC();
            DataTable dtt = new DataTable();
            dtt = daobj.GetBank(conn);
            dtt.Rows.Add(new object[] { 0, "N/A" });
            cmbNeBank.DataSource = dtt;
            cmbNeBank.DisplayMember = "LedgerName";
            cmbNeBank.ValueMember = "LedgerID";
        }
        private void LoadMasterLCNo()
        {
            //DaLC daobj = new DaLC();
            //DataTable dt = new DataTable();
            //dt = daobj.GetLCNO(conn);
            //cmbMasterLCNo.DataSource = dt;
            //cmbMasterLCNo.DisplayMember = "LCNo";
            //cmbMasterLCNo.ValueMember = "LCID";

        }

               
        

        private void frmLC_Load(object sender, EventArgs e)
        {
            try
            {
                LoadIssuBank();
                LoadNegoBank();
                loadCurrency();
                //LoadMasterLCNo();
                cmbLCType.SelectedIndex = 0;
                chkMasterLC_CheckedChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void txtFileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtPINo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    SelectNextControl((Control)sender, true, true, true, true);
                frmSearchMultiplePI frmobj = new frmSearchMultiplePI();
                frmobj.ShowDialog();
                PILists = frmobj.PIList;
                if (PILists == "") return;
                string where = " WHERE T_PI_Master.PIMID IN " + PILists;
                loadGrid(where);
                int nr = ctlDGVLC.Rows.Count;
                int TotalQTY = 0;
                double TotalValue = 0.0;
                for (int i = 0; i < nr; i++)
                {
                    TotalQTY += ctlDGVLC.Rows[i].Cells["OrderQty"].Value == null || ctlDGVLC.Rows[i].Cells["OrderQty"].Value == DBNull.Value ? 0 : (int)ctlDGVLC.Rows[i].Cells["OrderQty"].Value;
                    TotalValue += ctlDGVLC.Rows[i].Cells["OrderValue"].Value == null || ctlDGVLC.Rows[i].Cells["OrderValue"].Value == DBNull.Value ? 0 : Convert.ToDouble(ctlDGVLC.Rows[i].Cells["OrderValue"].Value);
                }
                txtTotalValue.Text = TotalValue.ToString();
                txtTotalQty.Text = TotalQTY.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private double convertToDouble(object p)
        {
            throw new NotImplementedException();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void dateTimePicker4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void dateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void CHKUDDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void CHKDocumentDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void CHKNegotiationDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }
    


     /* private void txtPINo_Click(object sender, EventArgs e)
        {
            frmSearchMultiplePI frmobj = new frmSearchMultiplePI();
            frmobj.ShowDialog();
            /*Orders = frmOrder.OrderList;
            if (Orders == "") return;
            string where = "WHERE Order_Details.OrderMID IN" + Orders;
            dt = new DaPI().GetOrderRefNo(where, conn);
            if (DGVOrderRefNo.Rows.Count <= 0)
            {
                DGVOrderRefNo.DataSource = dt;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {


                        dtt.Rows.Add(dt.Rows[i].Field<object>("PIDID"), 0,
                          dt.Rows[i].Field<object>("OrderNo"), dt.Rows[i].Field<object>("ItemName"),
                          dt.Rows[i].Field<object>("ItemCode"), dt.Rows[i].Field<object>("SizesName"),
                          dt.Rows[i].Field<object>("ColorsName"), dt.Rows[i].Field<object>("ShadeNo"),
                          dt.Rows[i].Field<object>("CountName"), dt.Rows[i].Field<object>("UnitsName"),
                          dt.Rows[i].Field<object>("GroupName"), dt.Rows[i].Field<object>("OrderQty"),
                          0);
                    }


                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }*/
        /*

        private void cmbLCType_TextChanged(object sender, EventArgs e)
        {
            if (cmbLCType.Text.Trim() == "Import LC")
            {
                txtMasterLCNo.Visible = false;
                //cmbMasterLCNo.Visible = true;
                //cmbMasterLCNo.Location = txtMasterLCNo.Location;
                //cmbMasterLCNo.Size = txtMasterLCNo.Size;
            }
            else
            {
                txtMasterLCNo.Visible = true;
                //cmbMasterLCNo.Visible = false;
            }
        }
         * */
        /*
        private void LoadMasterLCNo()
        {
            DaLC daobj = new DaLC();
            DataTable dtt = new DataTable();
            dtt = daobj.GetMasterLCNo(conn);
            cmbMasterLCNo.DataSource = dtt;
            cmbMasterLCNo.DisplayMember = "MasterLCNo";
            cmbMasterLCNo.ValueMember ="LCID";
        }
        */
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (ctlDGVLC.Columns.Count > 0) ctlDGVLC.Columns.Clear();
                frmSearchLC objfrm = new frmSearchLC();
                objfrm.ShowDialog();

                if (objfrm == null) return;
                LCmID = objfrm.LCID;
                if (LCmID <= 0) return;
                DaLC objdalc = new DaLC();

                LC_Master objlcmaster = objdalc.GetLC_Master(LCmID, conn);
                if (objlcmaster == null) return;

             
                #region LC Detail load
                DataTable dtLCPIs = objdalc.getPIsOfLC(conn, LCmID);
                if (dgvPIs.Rows.Count > 0)
                    dgvPIs.Rows.Clear();
                for (int j = 0; j < dtLCPIs.Rows.Count; j++)
                {
                    dgvPIs.Rows.Add(new object[] { dtLCPIs.Rows[j].Field<object>("LCDetailID"), dtLCPIs.Rows[j].Field<object>("PIID") });
                }
                #endregion 

                #region LC Data Show
                dtt = objdalc.GetLCDTL(LCmID, conn);
                ctlDGVLC.DataSource = dtt;
                ctlDGVLC.setColumnsVisible(false, "LCID", "LCDetailID", "PIMID");
                ctlDGVLC.setColumnsFormat(new string[] { "OrderQty", "OrderValue" }, "0.00", "0.00");
                ctlDGVLC.Columns["OrderQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctlDGVLC.Columns["OrderValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                #endregion
                #region LC Master
                cmbLCType.SelectedItem = objlcmaster.LCType;
                LCMasterID.Text = objlcmaster.LCID.ToString();
                txtLCNo.Text = objlcmaster.LCNo;
                cmbCurrency.SelectedValue = objlcmaster.CurrencyID;
                txtMasterLCNo.Text = objlcmaster.MasterLCNo;
                if (objlcmaster.MasterLCNo == string.Empty && objlcmaster.MasterLCID <= 0)
                {
                    chkMasterLC.Checked = false;
                    txtMasterLCNo.Tag = null;
                }
                else
                {
                    chkMasterLC.Checked = true;
                    txtMasterLCNo.Tag = new DaLC().GetLC_Master(objlcmaster.MasterLCID, conn);
                }
                
                cmbBank.SelectedValue = (int)objlcmaster.IssuBankID;
                cmbNeBank.SelectedValue = (int)objlcmaster.NegotiationBankID;
                txtFileNo.Text = objlcmaster.FileNo;
                txtAtSight.Text = objlcmaster.AtSight.ToString();
                CHKDocumentDate.Checked = !(objlcmaster.DocumentDate == new DateTime(1900, 1, 1));
                DTPDocDate.Value = objlcmaster.DocumentDate;
                DTPLCDate.Value = objlcmaster.LCDate;
                CHKNegotiationDate.Checked = !(objlcmaster.NegotiationDate == new DateTime(1900, 1, 1));
                DTPNegDate.Value = objlcmaster.NegotiationDate;
                DTPShipmentDate.Value = objlcmaster.ShipmentDate;
                CHKUDDate.Checked = !(objlcmaster.UDDate == new DateTime(1900, 1, 1));
                DTPUDDate.Value = objlcmaster.UDDate;
                DTPExpireDate.Value = objlcmaster.ExpiredDate;
                chkAcceptDate.Checked = !(objlcmaster.AcceptDate == new DateTime(1900, 1, 1));
                DTPAcceptDate.Value = objlcmaster.AcceptDate;
                txtTotalQty.Text = objlcmaster.TotalQty.ToString();
                txtTotalValue.Text = objlcmaster.TotalValue.ToString();
                txtAtSight.Text = objlcmaster.AtSight.ToString();
                txtRate.Text = objlcmaster.Rate.ToString("0.00");
                txtUnit.Text = objlcmaster.LcUnit;
                txtDesc.Text = objlcmaster.LCDescription;

               // chkUnderLCDate.Checked = !(objlcmaster.UnderLCDate == new DateTime(1900, 1, 1));
                DTPUnderLCDate.Value = objlcmaster.UnderLCDate;


                chkActualShDate.Checked = !(objlcmaster.ActualShipmentDate == new DateTime(1900, 1, 1));
                DTPActualShDate.Value = objlcmaster.ActualShipmentDate;

                chkPaid.Checked = !(objlcmaster.ActualPaymentDate == new DateTime(1900, 1, 1));
                dtpPaidDate.Value = objlcmaster.ActualPaymentDate;
                dtpPaymentDate.Value = objlcmaster.PaymentDate;

                Ledgers ldgr = new DaLedger().GetLedger(conn, objlcmaster.CustomerSupplierID);
                txtCustSupp.Text = ldgr.LedgerName;
                txtCustSupp.Tag = ldgr;
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
        private LC_Master CreateObjectLCMaster(LC_Master objMaster)
        {
            try
            {
                objMaster.LCID = int.Parse(LCMasterID.Text);

                objMaster.LCType = (string)cmbLCType.SelectedItem;


                objMaster.LCNo = txtLCNo.Text.ToString();
                objMaster.CurrencyID = (int)cmbCurrency.SelectedValue;

                if (chkMasterLC.Checked)
                {
                    objMaster.MasterLCNo = txtMasterLCNo.Text;
                    if (objMaster.LCType == "Import LC")
                    {
                        LC_Master mL = (LC_Master)txtMasterLCNo.Tag;
                        objMaster.MasterLCID = mL.LCID;
                        objMaster.UnderLCDate = mL.LCDate;
                    }
                    else
                    {
                        objMaster.MasterLCID = 0;
                        objMaster.UnderLCDate = DTPUnderLCDate.Value.Date;
                    }
                }
                else
                {
                    objMaster.MasterLCNo = "";
                    objMaster.MasterLCID = 0;
                    objMaster.UnderLCDate = new DateTime(1900, 1, 1);
                }

                objMaster.CustomerSupplierID = ((Ledgers)txtCustSupp.Tag).LedgerID;
                objMaster.IssuBankID = (int)cmbBank.SelectedValue;
                objMaster.Rate = Convert.ToDouble(txtRate.Text);
                objMaster.NegotiationBankID = (int)cmbNeBank.SelectedValue;
                objMaster.NegotiationDate = CHKNegotiationDate.Checked ? DTPNegDate.Value.Date : new DateTime(1900, 1, 1);
                objMaster.ShipmentDate = DTPShipmentDate.Value.Date;
                objMaster.UDDate = CHKUDDate.Checked ? DTPUDDate.Value.Date : new DateTime(1900, 1, 1);
                objMaster.AcceptDate = chkAcceptDate.Checked ? DTPAcceptDate.Value.Date : new DateTime(1900, 1, 1);
               
                objMaster.DocumentDate = CHKDocumentDate.Checked ? DTPDocDate.Value.Date : new DateTime(1900, 1, 1);
                objMaster.ExpiredDate = DTPExpireDate.Value.Date;
                objMaster.FileNo = txtFileNo.Text.ToString();
                objMaster.LCDate = DTPLCDate.Value.Date;
                objMaster.TotalQty = double.Parse(txtTotalQty.Text);
                objMaster.TotalValue = double.Parse(txtTotalValue.Text);
                objMaster.AtSight = txtAtSight.Text.ToString();
                if (chkActualShDate.Checked == false)
                    objMaster.ActualShipmentDate = new DateTime(1900, 1, 1);
                else
                    objMaster.ActualShipmentDate = DTPActualShDate.Value.Date;
               // if (chkUnderLCDate.Checked == false)
                 //   objMaster.UnderLCDate = new DateTime(1900, 1, 1);
                //else
                    objMaster.UnderLCDate = DTPUnderLCDate.Value.Date;
                objMaster.ActualPaymentDate=chkPaid.Checked?dtpPaidDate.Value.Date:new DateTime(1900,1,1);
                objMaster.PaymentDate = dtpPaymentDate.Value.Date;
                objMaster.LCDescription = txtDesc.Text;
                objMaster.LcUnit = txtUnit.Text;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return objMaster;
        }

        private LC_Detail CreateObjectDetail(int LCMID,int PIID,int LCDID)
        {
            LC_Detail objDetail = new LC_Detail();
            objDetail.LCDetailID = LCDID;
            objDetail.LCID = LCMID;
            objDetail.PIID = PIID;
            return objDetail;
        }
        /*
        private void cmbLCType_TextChanged_1(object sender, EventArgs e)
        {
            if (cmbLCType.Text.Trim() == "Import LC")
            {
                txtMasterLCNo.Visible = false;
                //cmbMasterLCNo.Visible = true;
                //cmbMasterLCNo.Location = txtMasterLCNo.Location;
                //cmbMasterLCNo.Size = txtMasterLCNo.Size;
            }
            else
            {
                txtMasterLCNo.Visible = true;
                //cmbMasterLCNo.Visible = false;
            }
        }
        */
        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            int mLCID;
            try
            {

                if (cmbLCType.SelectedIndex == 2 || cmbLCType.SelectedIndex == 3)
                {

                    #region Direct LC
                    if (txtLCNo.Text == "")
                    {
                        MessageBox.Show("Please Enter LCNo");
                        return;
                    }
                    if (txtCustSupp.Tag == null)
                    {
                        MessageBox.Show("Please Select Customer/Supplier");
                        return;
                    }
                    if (txtAtSight.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Enter AtSight Days");
                        return;
                    }
                    LC_Detail objLCDTL = new LC_Detail();
                    LC_Master objLCMaster = new LC_Master();
                    DaLC objDALC = new DaLC();
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    trans = conn.BeginTransaction();
                    objLCMaster = CreateObjectLCMaster(objLCMaster);

                    mLCID = objDALC.SaveUpdateLCMaster(objLCMaster, conn,trans);
                    #endregion
                }


                else
                {
                    if (cmbLCType.Text == "")
                    {
                        MessageBox.Show("Please Enter LCType");
                        return;
                    }
                    if (txtLCNo.Text == "")
                    {
                        MessageBox.Show("Please Enter LCNo");
                        return;
                    }
                    if (txtCustSupp.Tag == null)
                    {
                        MessageBox.Show("Please Select Customer/Supplier");
                        return;
                    }
                    if (dgvPIs.Rows.Count == 0)
                    {
                        MessageBox.Show("Please Select PI for LC");
                        return;
                    }
                    if (txtAtSight.Text.Trim()  == "")
                    {
                        MessageBox.Show("Please Enter AtSight Days");
                        return;
                    }
                    LC_Detail objLCDTL = new LC_Detail();
                    LC_Master objLCMaster = new LC_Master();
                    DaLC objDALC = new DaLC();
                    int PIMID, LCDID;
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    trans = conn.BeginTransaction();
                    objLCMaster = CreateObjectLCMaster(objLCMaster);
                    mLCID = objDALC.SaveUpdateLCMaster(objLCMaster, conn,trans);
                    //int l = PILists.Length;
                    //if (l == 0)
                    //{
                    //    PIMID = (int)ctlDGVLC.Rows[0].Cells["PIMID"].Value;
                    //    LCDID = ctlDGVLC.Rows[0].Cells["LCDetailID"].Value == DBNull.Value || ctlDGVLC.Rows[0].Cells["LCDetailID"].Value == null ? 0 : (int)ctlDGVLC.Rows[0].Cells["LCDetailID"].Value;
                    //    objLCDTL = CreateObjectDetail(LCmID, PIMID, LCDID);
                    //    objDALC.SaveUpdateLCDetail(objLCDTL, conn);
                    //}
                    //else
                    //{
                    //    string[] piList = PILists.Substring(3, l - 4).Split(',');
                    //    int i, L = piList.Length;

                    //    for (i = 0; i < L; i++)
                    //    {
                    //        PIMID = int.Parse(piList[i]);
                    //        objLCDTL = CreateObjectDetail(LCmID, PIMID, 0);
                    //        objDALC.SaveUpdateLCDetail(objLCDTL, conn);
                    //    }
                    //}

                    int i, nR;
                    nR = dgvPIs.Rows.Count;
                    for (i = 0; i < nR; i++)
                    {
                        LCDID = dgvPIs.Rows[i].Cells["LCDetailID"].Value == DBNull.Value || dgvPIs.Rows[i].Cells["LCDetailID"].Value == null ? 0 : (int)dgvPIs.Rows[i].Cells["LCDetailID"].Value;
                        PIMID = (int)dgvPIs.Rows[i].Cells["PIID"].Value;
                        objLCDTL = CreateObjectDetail(mLCID, PIMID, LCDID);
                        objDALC.SaveUpdateLCDetail(objLCDTL, conn,trans);
                    }

                }
                trans.Commit();
                loadCurrency();
                MessageBox.Show("Data saved successfully");
                LCmID = mLCID;
                llblUnderLC_LinkClicked(null, null);
                btnNew_Click(null, null);
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFileNo_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DTPShipmentDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DTPExpireDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DTPAcceptDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DTPUDDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DTPDocDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DTPNegDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void CHKUDDate_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void CHKDocumentDate_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void CHKNegotiationDate_KeyDown_1(object sender, KeyEventArgs e)
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

        private void txtMasterLCNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtFileNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtPINo_Enter(object sender, EventArgs e)
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

        private void txtMasterLCNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtPINo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void Refreshs()
        {
            try
            {
                LoadIssuBank();
                LoadNegoBank();
                //LoadMasterLCNo();
                txtFileNo.Text = "";
                txtLCNo.Text = "";
                txtMasterLCNo.Text = "";
                LCMasterID.Text = "0";
                CHKUDDate.Checked = false;
                CHKDocumentDate.Checked = false;
                CHKNegotiationDate.Checked = false;
                chkAcceptDate.Checked = false;
                chkActualShDate.Checked = false;
                chkPaid.Checked = false;
                txtAtSight.Text = "";
                txtRate.Text = "1";
                LCmID = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Refreshs();
                loadCurrency();
                 DaLC objda = new DaLC();
                 dtt = objda.GetLCDTL(-1, conn);
                ctlDGVLC.DataSource = dtt;
                ctlDGVLC.setColumnsVisible(false, "LCID", "LCDetailID", "PIMID");
                if (dgvPIs.Rows.Count > 0) dgvPIs.Rows.Clear();
                //dgvPIs.DataSource = objda.getPIsOfLC(conn, 0);
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
                int LC = Convert.ToInt32(LCMasterID.Text);
                if (LC == 0) return;

                if (MessageBox.Show("Do you really want to delete the LC?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                DaLC objda = new DaLC();
                objda.DeleteLC(LC, conn);
                Refreshs();
                dtt = objda.GetLCDTL(0, conn);
                ctlDGVLC.DataSource = dtt;
                if (dgvPIs.Rows.Count > 0) dgvPIs.Rows.Clear();
                //dgvPIs.DataSource = objda.getPIsOfLC(conn, 0);

                MessageBox.Show("Data is deleted successfully");
                loadCurrency();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex+"Trere is an error");
            }
           
        }

        private void cmbLCType_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void cmbMasterLCNo_Enter(object sender, EventArgs e)
        {

        }

        private void cmbBank_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void cmbNeBank_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void cmbLCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cmbLCType.SelectedIndex)
                {
                    case 0: /* Export LC */
                        txtMasterLCNo.ReadOnly = false;
                        btnAmend.Enabled = false;
                        lblCustSupp.Text = "Customer";
                        llblLCAcceptance.Enabled = false;
                        //btnGetLC
                        break;
                    case 1: /* Import LC */
                        txtMasterLCNo.ReadOnly = true;
                        btnAmend.Enabled = false;
                        lblCustSupp.Text = "Supplier";
                        llblLCAcceptance.Enabled = true;
                        break;
                    case 2: /* Direct Export LC */
                        txtMasterLCNo.ReadOnly = false;
                        btnAmend.Enabled = true;
                        lblCustSupp.Text = "Customer";
                        llblLCAcceptance.Enabled = false;
                        break;
                    case 3: /* Direct Import LC */
                        txtMasterLCNo.ReadOnly = true;
                        btnAmend.Enabled = true;
                        lblCustSupp.Text = "Supplier";
                        llblLCAcceptance.Enabled = true;
                        break;
                }
                //if (cmbLCType.SelectedIndex == 0)
                //{
                //    chkUnderLCDate.Enabled = true;
                //    txtMasterLCNo.Enabled = true;
                //}
                //else
                //{
                //    chkUnderLCDate.Enabled = false;
                //    txtMasterLCNo.Enabled = false;
                //}

                //if (cmbLCType.SelectedIndex == 1)
                //{
                //    cmbMasterLCNo.Enabled = false;
                //    cmbNeBank.Enabled = false;
                //}
                //else
                //{
                //    cmbMasterLCNo.Enabled = true;
                //    cmbNeBank.Enabled = true;
                //}

                if (cmbLCType.SelectedIndex == 2 || cmbLCType.SelectedIndex == 3)
                {
                    ctlDGVLC.Enabled = false;
                    txtTotalQty.Enabled = true;
                    txtTotalValue.Enabled = true;
                    txtPINo.Enabled = false;
                    llblPIs.Enabled = false;
                    chkAddPI.Enabled = false;
                    //lblTotalQTY.Location = new Point(0, 0);
                }
                else
                {
                    ctlDGVLC.Enabled = true;
                    txtTotalQty.Enabled = false;
                    txtTotalValue.Enabled = false;
                    txtPINo.Enabled = true;
                    llblPIs.Enabled = true;
                    chkAddPI.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLC_Paint(object sender, PaintEventArgs e)
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

        private void txtAtSight_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtAtSight_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }
        private void loadGrid(string where)
        {
            try
            {
                dtt = new DaLC().GetLCNo(where, conn);
                ctlDGVLC.DataSource = dtt;

                ctlDGVLC.setColumnsVisible(false, "LCDID", "PIMID");
                ctlDGVLC.setColumnsFormat(new string[] { "OrderQty", "OrderValue" }, "0.00", "0.00");
                ctlDGVLC.Columns["OrderQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctlDGVLC.Columns["OrderValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvPIs.DataSource = new DaLC().getPIsOfLC(conn,0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void llblPIs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtCustSupp.Tag == null)
                {
                    MessageBox.Show("Please Customer/Supplier");
                    return;
                }
                int lID=((Ledgers)txtCustSupp.Tag).LedgerID;
                frmSearchMultiplePI frmobj = new frmSearchMultiplePI();
                frmobj.ShowDialog(cmbLCType.SelectedItem.ToString() == "Export LC" ?  "To Customer":"For Supplier",lID);
                PILists = frmobj.PIList;
                if (PILists == "") return;
                #region LC Detail load
                DataTable dtLCPIs = frmobj.PIs;
                //dgvPIs.DataSource = frmobj.PIs;
                if (chkAddPI.Checked == false) dgvPIs.Rows.Clear();
                for (int j = 0; j < dtLCPIs.Rows.Count; j++)
                {
                    dgvPIs.Rows.Add(new object[] { dtLCPIs.Rows[j].Field<object>("LCDetailID"), dtLCPIs.Rows[j].Field<object>("PIID") });
                }
                #endregion 

                #region LC Data Show
                string PIs = "(0";
                int k, R;
                R = dgvPIs.Rows.Count;
                for (k = 0; k < R; k++)
                {
                    PIs += "," + dgvPIs["PIID", k].Value.ToString();


                }
                PIs += ")";
                string where = " WHERE PM.PIMID IN " + PIs;
                loadGrid(where);

                //DGVOrderRefNo.Columns["OrderMID"].Visible = false;
                int nr = ctlDGVLC.Rows.Count;
                double TotalQTY = 0;
                double TotalValue = 0.0;
                for (int i = 0; i < nr; i++)
                {
                    TotalQTY += GlobalFunctions.isNull( ctlDGVLC.Rows[i].Cells["OrderQty"].Value,0.0);
                    TotalValue += GlobalFunctions.isNull(ctlDGVLC.Rows[i].Cells["OrderValue"].Value,0.0);
                }
                txtTotalValue.Text = TotalValue.ToString();
                txtTotalQty.Text = TotalQTY.ToString();
                txtUnit.Text = ctlDGVLC.Rows[0].Cells["Unit"].Value.ToString();
                #endregion
                SelectNextControl((Control)sender, true, true, true, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkUnderLCDate_CheckedChanged(object sender, EventArgs e)
        {
           
             //   DTPUnderLCDate.Enabled= chkUnderLCDate.Checked;
        }

        private void chkActualShDate_CheckedChanged(object sender, EventArgs e)
        {
          
                DTPActualShDate.Visible = chkActualShDate.Checked;
        }

        private void chkAcceptDate_CheckedChanged(object sender, EventArgs e)
        {
            DTPAcceptDate.Visible = chkAcceptDate.Checked;
        }

        private void chkPayDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpPaidDate.Visible = chkPaid.Checked;
        }

        private void chkMasterLC_CheckedChanged(object sender, EventArgs e)
        {
             txtMasterLCNo.Enabled = chkMasterLC.Checked;
             DTPUnderLCDate.Enabled = chkMasterLC.Checked;
             btnGetLC.Enabled = chkMasterLC.Checked && txtMasterLCNo.ReadOnly;
        }

        private void txtMasterLCNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtMasterLCNo.ReadOnly == false) return;
            if (btnGetLC.Enabled == false) return;
            btnGetLC_Click(sender, null);
        }

        private void txtMasterLCNo_ReadOnlyChanged(object sender, EventArgs e)
        {
            //btnGetLC.Enabled =  txtMasterLCNo.ReadOnly;
        }

        private void btnGetLC_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMasterLCNo.ReadOnly == false) return;
                
                frmSearchLC objfrm = new frmSearchLC();
                objfrm.ShowDialog();

                if (objfrm == null) return;
                //LCmID = objfrm.LCID;

                DaLC objdalc = new DaLC();

                LC_Master objlcmaster = objdalc.GetLC_Master(objfrm.LCID, conn);
                if (objlcmaster == null) return;

                txtMasterLCNo.Text = objlcmaster.LCNo;
                DTPUnderLCDate.Value = objlcmaster.LCDate;
                txtMasterLCNo.Tag = objlcmaster;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCustSupp_DoubleClick(object sender, EventArgs e)
        {
            

        }

        private void txtCustSupp_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtCustSupp_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtCustSupp_KeyDown(object sender, KeyEventArgs e)
        {
          
                

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbLCType.Text == "")
                    {
                        MessageBox.Show("Select a PI type");
                        return;
                    }

                    if (cmbLCType.SelectedItem.ToString().ToLower() == "Import LC".ToLower() || cmbLCType.SelectedItem.ToString().ToLower() == "Direct Import LC".ToLower())
                    {

                        Ledgers objSupplier;

                        string SuppliersName = "";
                        frmSupplierSearch frmSup = new frmSupplierSearch();
                        frmSup.ShowDialog();
                        objSupplier = frmSup.SelectedSupplier;
                        if (frmSup == null) return;
                        if (objSupplier == null) return;
                        //SuppliersID = objSupplier.LedgerID;
                        SuppliersName = objSupplier.LedgerName;
                        txtCustSupp.Text = SuppliersName;
                        txtCustSupp.Tag = objSupplier;
                        cmbCurrency.SelectedValue = objSupplier.CurrencyID;

                    }
                    else
                    {


                        Ledgers objCustomers = new Ledgers();

                        string CustomersName = "";
                        frmCustomer frmCusr = new frmCustomer();
                        frmCusr.ShowDialog();
                        objCustomers = frmCusr.ReturnCustomerID();
                        if (objCustomers == null) return;

                        CustomersName = objCustomers.LedgerName;
                        txtCustSupp.Text = CustomersName;
                        txtCustSupp.Tag = objCustomers;
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

        private void txtAtSight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void DTPUnderLCDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void chkAcceptDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void chkActualShDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void chkPaid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void chk_Enter(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            chk.ForeColor = Color.Red;
        }

        private void chk_Leave(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            chk.ForeColor = Color.Black;
        }

        private void llblPIs_Enter(object sender, EventArgs e)
        {
            llblPIs.LinkColor = Color.Red;
        }

        private void llblPIs_Leave(object sender, EventArgs e)
        {
            llblPIs.LinkColor = Color.Blue;
        }

        private void btnAmendment_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(LCMasterID.Text) == 0)
                {
                    MessageBox.Show("Please Select a LC"); return;
                }
                ForAmLCMID = int.Parse(LCMasterID.Text);
                frmLCAmendment obj = new frmLCAmendment(ForAmLCMID,Convert.ToDouble(txtTotalQty.Text),Convert.ToDouble(txtTotalValue.Text));
                obj.ShowDialog();
                DaLC objdalc = new DaLC();
                LC_Master objlcmaster = objdalc.GetLC_Master(ForAmLCMID, conn);
                if (objlcmaster == null) return;
                txtTotalQty.Text = objlcmaster.TotalQty.ToString();
                txtTotalValue.Text = objlcmaster.TotalValue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error to load"+ex);
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

        private void llblLCAcceptance_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LCmID == 0)
            {
                MessageBox.Show("Please Find a Import LC");
                return;
            }
            try
            {
                frmLCAcceptance frm = new frmLCAcceptance(LCmID);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void llblUnderLC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (LCmID == 0)
                {
                    MessageBox.Show("Please Find LC");
                    return;
                }
                frmUnderLC frm = new frmUnderLC(LCmID);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ctlDGVLC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
       

        
       

        
    }
}
