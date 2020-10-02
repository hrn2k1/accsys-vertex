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
namespace Accounting.UI
{
    public partial class frmCommertialDocument : Form
    {
        private int LCmID = 0;
        private SqlConnection conn = null;
        public frmCommertialDocument()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLCNo_Click(object sender, EventArgs e)
        {
           
        }
        private CommercialDocuments CreateObject()
        {
            try
            {
                CommercialDocuments objComDoc = new CommercialDocuments();
                objComDoc.ComInvoiceID = int.Parse(txtComDocID.Text);
                objComDoc.ComInvoiceNo = txtComDocNO.Text.ToString();
                objComDoc.ChalanNo = txtChalanNo.Text.ToString();
                objComDoc.ChalanDate = DTPChalanDate.Value.Date;
                objComDoc.ComInvoiceDate = DTPComDocDate.Value.Date;
                objComDoc.NotifyParty = txtNotifyParty.Text.ToString();
                objComDoc.FromLocation = txtFromLocation.Text.ToString();
                objComDoc.ToLocation = txtToLocation.Text.ToString();
                objComDoc.ExpNo = txtExpNo.Text.ToString();
                objComDoc.ExpDate = DTPExpDate.Value.Date;
                objComDoc.Carrier = txtCarrier.Text.ToString();
                objComDoc.CarrierNo = txtCarrierNo.Text.ToString();
                objComDoc.LCID = int.Parse(txtLCID.Text);
                objComDoc.OriginCountry = txtOriginalCountry.Text.ToString();
                objComDoc.TotalQty = double.Parse(txtTotalQty.Text.ToString());
                objComDoc.TotalValue = double.Parse(txtTotalValue.Text.ToString());
                objComDoc.PackingListNo = txtPackingListNo.Text.ToString();
                objComDoc.PackingDate = DTPPackingDate.Value.Date;
                objComDoc.CONo = txtCONo.Text.ToString();
                objComDoc.CODate = DTPCODate.Value.Date;
                objComDoc.VATerIDNo = txtVATerIDNo.Text.ToString();
                objComDoc.Remarks = txtRemarks.Text.ToString();
                objComDoc.DraftNo = txtDraftNo.Text.ToString();
                objComDoc.BankRefNo = txtBankRefNo.Text.ToString();
                objComDoc.MasterLCTitle = txtMasterLCTitle.Text.ToString();
                objComDoc.FactoryAddress = txtFactoryAddress.Text.ToString();
                objComDoc.Authority = txtAuthority.Text.ToString();
                objComDoc.LCTermsCondition = txtLCTermsCondition.Text.ToString();
                objComDoc.PackingListStatus = txtPackingListStatus.Text.ToString();
                if (checkBox1.Checked == true)
                {
                    objComDoc.SubmitDate = DTPSubmitDate.Value.Date;
                }
                else
                {
                    objComDoc.SubmitDate = new DateTime(1900, 1, 1);
                }

                if (checkBox2.Checked == true)
                {
                    objComDoc.IsEPZ = 1;
                }
                else
                {
                    objComDoc.IsEPZ = 0;
                }
                return objComDoc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool validation()
        {
            if (txtLCNo.Text == "")
            {
                MessageBox.Show("Please Select a LC No.");
                return false;
            }
            if (txtComDocNO.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Invoice No.");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation() == false)
                return;
            CommercialDocuments comobj = new CommercialDocuments();
            DaCommercialDocuments daobj = new DaCommercialDocuments();
            SqlTransaction trans = null;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                trans = conn.BeginTransaction();
                comobj = CreateObject();
                daobj.SaveUpdateCommercialDocuments(comobj, conn, trans);
                trans.Commit();

                MessageBox.Show("Data saved successfully");
                CDRefresh();
                LoadComDoc();
                COlist();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                MessageBox.Show("There is an error " + ex.Message);
                return;

            }
           
        }
        private void LoadComDoc()
        {
            DataTable dt = new DataTable();
            DaCommercialDocuments daobj = new DaCommercialDocuments();
            try
            {
                dt = daobj.GetComDoc(conn);

                ctlDGVComDoc.DataSource = dt;
                ctlDGVComDoc.Columns["ComInvoiceID"].Visible = false;
                ctlDGVComDoc.Columns["LCID"].Visible = false;
                ctlDGVComDoc.setColumnsFormat(new string[] { "TotalQty" }, "0.00");
                ctlDGVComDoc.Columns["TotalQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmCommertialDocument_Load(object sender, EventArgs e)
        {
            try
            {
                conn = ConnectionHelper.getConnection();
                //LoadComDoc();
                COlist();
                DTPSubmitDate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void COlist()
        {
            try
            {
                AutoCompleteStringCollection c = new AutoCompleteStringCollection();
                SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT OriginCountry FROM T_Commercial_Documents ", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                int i, nR;
                nR = dt.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    c.Add(dt.Rows[i].Field<string>("OriginCountry"));
                }
                txtOriginalCountry.AutoCompleteCustomSource.Clear();
                txtOriginalCountry.AutoCompleteCustomSource = c;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CDRefresh()
        {
            txtCarrier.Text = "DELIVERY VAN";
            txtCarrierNo.Text = "DHAKA Metro-MA-51-1079";
            txtComDocID.Text = "0";
            txtComDocNO.Text = "";
            txtCONo.Text = "";
            txtExpNo.Text = "";
            txtLCID.Text = "0";
            txtLCNo.Text = "";
            txtRemarks.Text = "";
            txtNotifyParty.Text = "";
            txtOriginalCountry.Text = "";
            txtPackingListNo.Text = "";
            txtToLocation.Text = "BUYER'S FACTORY";
            txtTotalQty.Text = "0";
            txtTotalValue.Text = "0.0";
            txtVATerIDNo.Text = "";
            txtChalanNo.Text = "";
            txtFromLocation.Text = "BENEFICIARY'S FACTORY";
            txtMasterLCTitle.Text = "EXPORT CREDIT NO.";
            txtLCTermsCondition.Text ="** We also certify that the goods shipped are in accordance with the specification,qualilty," +Environment.NewLine +
                                        " quantity, packing,marking & the price of above mentioned Proforma Invoice.**";
            txtPackingListStatus.Text = "Packing Export Standard";
            txtAuthority.Text = "M.R. Hassan Khan"+ Environment.NewLine +"Executive Director";

            txtFactoryAddress.Text = "Plot # 132, Mouza-Bhadam, " + Environment.NewLine +
                                    "Tongi, Gazipur, Bangladesh." + Environment.NewLine +
                                    "Tel: Off: 8931925, 8931926, 8950783."+Environment.NewLine+
                                    "Fax: 9801672, 9801228.";


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CDRefresh();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                DaCommercialDocuments objComDocDA = new DaCommercialDocuments();
                frmSearchCommercialDocuments frmobj = new frmSearchCommercialDocuments();
                frmobj.ShowDialog();
                CommercialDocuments objComDocs = new CommercialDocuments();
                //objComDocs = frmobj.GetLCNoInTextBox();
                objComDocs = frmobj.objComDoc;
                if (objComDocs == null) return;
                txtCarrier.Text = objComDocs.Carrier;
                txtCarrierNo.Text = objComDocs.CarrierNo;
                txtChalanNo.Text = objComDocs.ChalanNo;
                txtComDocID.Text = objComDocs.ComInvoiceID.ToString();
                txtComDocNO.Text = objComDocs.ComInvoiceNo;
                txtCONo.Text = objComDocs.CONo;
                txtExpNo.Text = objComDocs.ExpNo;
                txtFromLocation.Text = objComDocs.FromLocation;
                txtLCID.Text = objComDocs.LCID.ToString();
                txtNotifyParty.Text = objComDocs.NotifyParty;
                txtOriginalCountry.Text = objComDocs.OriginCountry;
                txtPackingListNo.Text = objComDocs.PackingListNo;
                txtRemarks.Text = objComDocs.Remarks;
                txtToLocation.Text = objComDocs.ToLocation;
                txtTotalQty.Text = objComDocs.TotalQty.ToString();
                txtTotalValue.Text = objComDocs.TotalValue.ToString();
                txtVATerIDNo.Text = objComDocs.VATerIDNo;
                DTPChalanDate.Value = objComDocs.ChalanDate;
                DTPCODate.Value = objComDocs.CODate;
                DTPComDocDate.Value = objComDocs.ComInvoiceDate;
                DTPExpDate.Value = objComDocs.ExpDate;
                DTPPackingDate.Value = objComDocs.PackingDate; 
                DTPChalanDate.Value = objComDocs.ChalanDate;
                txtAuthority.Text = objComDocs.Authority;
                txtBankRefNo.Text = objComDocs.BankRefNo;
                txtDraftNo.Text = objComDocs.DraftNo;
                txtFactoryAddress.Text = objComDocs.FactoryAddress;
                txtLCTermsCondition.Text = objComDocs.LCTermsCondition;
                txtMasterLCTitle.Text = objComDocs.MasterLCTitle;
                txtPackingListStatus.Text = objComDocs.PackingListStatus;
                if (objComDocs.IsEPZ == 1)
                {
                    checkBox2.Checked = true;

                }
                else
                {
                    checkBox2.Checked = false;
                }
                LCmID = int.Parse(txtLCID.Text);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                txtLCNo.Text = objComDocDA.GetLCNO(LCmID, conn);
                if (objComDocs.SubmitDate == new DateTime(1900, 1, 1))
                {
                    checkBox1.Checked = false;
                }
                else
                {
                    checkBox1.Checked = true;
                    DTPSubmitDate.Value = objComDocs.SubmitDate;
                }
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
                if (ctlDGVComDoc.Rows.Count == 0) return;
                if (ctlDGVComDoc.CurrentRow == null)
                {
                    MessageBox.Show("Please Select A Row");
                    return;
                }
                int ab = ctlDGVComDoc.CurrentRow.Index;
                int abc = (int)ctlDGVComDoc.Rows[ab].Cells["ComInvoiceID"].Value;
                DaCommercialDocuments DAobjComDoc = new DaCommercialDocuments();
                DAobjComDoc.DeleteComDoc(abc, conn);
                MessageBox.Show("Deleted Successfully");
                LoadComDoc();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtComDocNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtNotifyParty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtFromLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtExpNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtCarrier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtOriginalCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtVATerIDNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtCONo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtPackingListNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtChalanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void DTPComDocDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtLCNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    frmSearchLC frmobjLC = new frmSearchLC();
                    frmobjLC.ShowDialog();
                    if (frmobjLC == null) return;

                    LCmID = frmobjLC.LCID;
                    if (LCmID == 0) return;
                    DaCommercialDocuments daobj = new DaCommercialDocuments();
                    txtLCID.Text = LCmID.ToString();
                    LC_Master lc = new DaLC().GetLC_Master(LCmID, conn);//daobj.GetLCNO(LCmID, conn);
                    txtLCNo.Text = lc.LCNo;
                    txtTotalQty.Text = lc.TotalQty.ToString("0.00");
                    txtTotalValue.Text = lc.TotalValue.ToString("0.00");
                    txtNotifyParty.Text = (new DaLedger().GetLedger(conn, lc.CustomerSupplierID)).LedgerName;
                }
                SelectNextControl((Control)sender, true, true, true, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtToLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void DTPExpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtCarrierNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtTotalQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtTotalValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void DTPCODate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void DTPPackingDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void DTPChalanDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnDelete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtComDocNO_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtNotifyParty_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtFromLocation_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtExpNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtCarrier_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtOriginalCountry_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtVATerIDNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtCONo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtPackingListNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtChalanNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtLCNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtToLocation_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtCarrierNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtTotalQty_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtTotalValue_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtRemarks_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtComDocNO_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtNotifyParty_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtFromLocation_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtExpNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtCarrier_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtOriginalCountry_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtVATerIDNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtCONo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtPackingListNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtChalanNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtLCNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtToLocation_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtCarrierNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtTotalQty_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtTotalValue_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool state=checkBox1.Checked;
            if (state == true)
            {
                DTPSubmitDate.Enabled = true;
            }
            else
             {
                DTPSubmitDate.Enabled = false;
             }
            
        }

        private void frmCommertialDocument_Paint(object sender, PaintEventArgs e)
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

        private void ctlDGVComDoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ab = e.RowIndex;
            try
            {
                txtCarrier.Text = ctlDGVComDoc.Rows[ab].Cells["Carrier"].Value.ToString();
                txtComDocNO.Text = ctlDGVComDoc.Rows[ab].Cells["ComInvoiceNo"].Value.ToString();
                txtComDocID.Text = ctlDGVComDoc.Rows[ab].Cells["ComInvoiceID"].Value.ToString();
                txtNotifyParty.Text = ctlDGVComDoc.Rows[ab].Cells["NotifyParty"].Value.ToString();
                txtFromLocation.Text = ctlDGVComDoc.Rows[ab].Cells["FromLocation"].Value.ToString();
                txtExpNo.Text = ctlDGVComDoc.Rows[ab].Cells["ExpNo"].Value.ToString();
                txtOriginalCountry.Text = ctlDGVComDoc.Rows[ab].Cells["OriginCountry"].Value.ToString();
                txtVATerIDNo.Text = ctlDGVComDoc.Rows[ab].Cells["VATerIDNo"].Value.ToString();
                txtCONo.Text = ctlDGVComDoc.Rows[ab].Cells["CONo"].Value.ToString();
                txtPackingListNo.Text = ctlDGVComDoc.Rows[ab].Cells["PackingListNo"].Value.ToString();
                txtChalanNo.Text = ctlDGVComDoc.Rows[ab].Cells["ChalanNo"].Value.ToString();
                DTPComDocDate.Value = Convert.ToDateTime(ctlDGVComDoc.Rows[ab].Cells["ComInvoiceDate"].Value);
                txtLCNo.Text = ctlDGVComDoc.Rows[ab].Cells["LCNo"].Value.ToString();
                txtLCID.Text = ctlDGVComDoc.Rows[ab].Cells["LCID"].Value.ToString();
                txtToLocation.Text = ctlDGVComDoc.Rows[ab].Cells["ToLocation"].Value.ToString();
                DTPExpDate.Value =Convert.ToDateTime( ctlDGVComDoc.Rows[ab].Cells["ExpDate"].Value);
                txtCarrierNo.Text = ctlDGVComDoc.Rows[ab].Cells["CarrierNo"].Value.ToString();
                txtTotalQty.Text = ctlDGVComDoc.Rows[ab].Cells["TotalQty"].Value.ToString();
                txtTotalValue.Text = ctlDGVComDoc.Rows[ab].Cells["TotalValue"].Value.ToString();
                DTPCODate.Value = Convert.ToDateTime(ctlDGVComDoc.Rows[ab].Cells["CODate"].Value);
                DTPPackingDate.Value = Convert.ToDateTime(ctlDGVComDoc.Rows[ab].Cells["PackingDate"].Value);
                DTPChalanDate.Value = Convert.ToDateTime(ctlDGVComDoc.Rows[ab].Cells["ChalanDate"].Value);
                if (ctlDGVComDoc.Rows[ab].Cells["SubmitDate"].Value == DBNull.Value)
                { checkBox1.Checked = false; }
                else
                {
                    checkBox1.Checked = true;
                    DTPSubmitDate.Value = Convert.ToDateTime(ctlDGVComDoc.Rows[ab].Cells["SubmitDate"].Value);
                }

                txtRemarks.Text = ctlDGVComDoc.Rows[ab].Cells["Remarks"].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmCommertialDocument_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(conn);
        }

        private void checkBox1_Enter(object sender, EventArgs e)
        {
            checkBox1.ForeColor = Color.Red;
        }

        private void checkBox1_Leave(object sender, EventArgs e)
        {
            checkBox1.ForeColor = Color.Black;
        }

        private void ctlDGVComDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDraftNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtBankRefNo_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtMasterLCTitle_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtLCTermsCondition_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtPackingListStatus_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtAuthority_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtFactoryAddress_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtDraftNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtBankRefNo_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtMasterLCTitle_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtLCTermsCondition_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtPackingListStatus_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtAuthority_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtFactoryAddress_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtDraftNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtBankRefNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtMasterLCTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtLCTermsCondition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender,true,true,true,true); 
        }

        private void txtFactoryAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtAuthority_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtPackingListStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void checkBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtFactoryAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtComDocNO_TextChanged(object sender, EventArgs e)
        {
            txtDraftNo.Text = txtComDocNO.Text;
        }
    }
}
