using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Entity;
using Accounting.Reports;
using CrystalDecisions.Shared;
using Accounting.Utility;

namespace Accounting.UI
{
    public partial class frmForwardingLetter : Form
    {
        public frmForwardingLetter()
        {
            InitializeComponent();
        }

        private void ctlNumDraftNo_valueChanged(object sender, EventArgs e)
        {
            if (ctlNumBeneficiarysCertificate.Value > 1) label21.Text = "Nos";
            else
                label21.Text = "No";
            if (ctlNumCertificateOfOrigin.Value > 1) label23.Text = "Nos";
            else
                label23.Text = "No";
            if (ctlNumDraftNo.Value > 1) label16.Text = "Nos";
            else
                label16.Text = "No";
            if (ctlNumInvoiceNo.Value > 1) label17.Text = "Nos";
            else
                label17.Text = "No";
            if (ctlNumPackingList.Value > 1) label18.Text = "Nos";
            else
                label18.Text = "No";
            if (ctlNumDeliveryChallan.Value > 1) label20.Text = "Nos";
            else
                label20.Text = "No";
            if (ctlNumTruckreceipts.Value > 1) label22.Text = "Nos";
            else
                label22.Text = "No";
            if (ctlNumPreShipmentInspectioncertioncertificate.Value > 1) label19.Text = "Nos";
            else
                label19.Text = "No";
            if (ctlNumLCNo.Value > 1) label15.Text = "Nos";
            else
                label15.Text = "No";
        }

        private void txtComDocNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    frmSearchCommercialDocuments frm = new frmSearchCommercialDocuments();
                    frm.ShowDialog();
                    CommercialDocuments objComDocs = frm.objComDoc;

                    if (objComDocs == null)
                        return;
                    else
                    {
                        txtComDocNo.Text = objComDocs.ComInvoiceNo;
                        txtComDocNo.Tag = objComDocs;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void txtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            //Account obAccount = null;
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //obAccount = new Account();
                    //frmAccountSearch obfrmCustomerAccount = new frmAccountSearch();
                    //obfrmCustomerAccount.ShowDialog();
                    //obAccount = obfrmCustomerAccount.SelectedAccount;
                    //if (obAccount == null) return;
                    //txtAccountNo.Text = obAccount.AccountTitle;
                    //txtAccountNo.Tag = obAccount;
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to find Account " + ex.Message);
            }
        }
        private bool validation()
        {
            if (txtTo.Text.Trim() == "")
            {
                MessageBox.Show("Please Type Tex in the field");
                txtTo.Focus();
                return false;
            }
            if (txtSubject.Text.Trim() == "")
            {
                MessageBox.Show("Please Type Subject int field");
                txtSubject.Focus();
                return false;
            }
            if (txtComDocNo.Tag == null)
            {
                MessageBox.Show("Please Select Commercial Invoice No");
                txtComDocNo.Focus();
                return false;
            }
            if (txtAccountNo.Text == "")
            {
                MessageBox.Show("Please select an Account No");
                txtAccountNo.Focus();
                return false;
            }
            return true;
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (validation() == false) return;
            try
            {
                #region report variable
                frmReportViewer frmRV = new frmReportViewer();
                ParameterValues pvc = new ParameterValues();
                ParameterDiscreteValue pdv = new ParameterDiscreteValue();

                #endregion

                //rptOrderSheet rpt = new rptOrderSheet();
                rptForwardingLetter rpt = new rptForwardingLetter();

                pdv.Value = ((CommercialDocuments)txtComDocNo.Tag).ComInvoiceID;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@ComInvoiceID"].ApplyCurrentValues(pvc);

                //pdv.Value = ((Account)txtAccountNo.Tag).AccountID;
                pdv.Value = txtAccountNo.Text.ToString();
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@Account"].ApplyCurrentValues(pvc);


                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = dtpApplyDate.Value.Date;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@Date"].ApplyCurrentValues(pvc);

                pdv.Value = txtTo.Text.ToString();
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@To"].ApplyCurrentValues(pvc);

                pdv.Value = txtSubject.Text.ToString();
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@Sub"].ApplyCurrentValues(pvc);


                pdv.Value = Math.Round(ctlNumDraftNo.Value, 0);
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@DraftNo"].ApplyCurrentValues(pvc);

                pdv.Value = label16.Text.ToString();
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@DeNo"].ApplyCurrentValues(pvc);

                pdv.Value = ctlNumInvoiceNo.Value;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@InvNo"].ApplyCurrentValues(pvc);

                pdv.Value = label17.Text.ToString();
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@InvN"].ApplyCurrentValues(pvc);

                pdv.Value = ctlNumPackingList.Value;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@PL"].ApplyCurrentValues(pvc);

                pdv.Value = label18.Text.ToString();
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@PLN"].ApplyCurrentValues(pvc);

                pdv.Value = ctlNumDeliveryChallan.Value;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@DC"].ApplyCurrentValues(pvc);

                pdv.Value = label20.Text.ToString();
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@DCN"].ApplyCurrentValues(pvc);

                pdv.Value = ctlNumTruckreceipts.Value;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@TR"].ApplyCurrentValues(pvc);

                pdv.Value = label22.Text.ToString();
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@TRN"].ApplyCurrentValues(pvc);

                pdv.Value = ctlNumCertificateOfOrigin.Value;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@CO"].ApplyCurrentValues(pvc);

                pdv.Value = label23.Text.ToString();
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@CON"].ApplyCurrentValues(pvc);
                //ii
                pdv.Value = ctlNumBeneficiarysCertificate.Value;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@BC"].ApplyCurrentValues(pvc);

                pdv.Value = label21.Text.ToString();
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@BCN"].ApplyCurrentValues(pvc);

                pdv.Value = ctlNumPreShipmentInspectioncertioncertificate.Value;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@PIC"].ApplyCurrentValues(pvc);

                pdv.Value = label19.Text.ToString();
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@PICN"].ApplyCurrentValues(pvc);

                pdv.Value = ctlNumLCNo.Value;
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@L"].ApplyCurrentValues(pvc);

                pdv.Value = label15.Text.ToString();
                pvc.Add(pdv);
                rpt.DataDefinition.ParameterFields["@LN"].ApplyCurrentValues(pvc);


                frmRV.ShowDialog(rpt, false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmForwardingLetter_Load(object sender, EventArgs e)
        {

        }

        private void frmForwardingLetter_Paint(object sender, PaintEventArgs e)
        {
            FormColorClass.ColorForm(this, e);
        }

        private void dtpApplyDate_Enter(object sender, EventArgs e)
        {
            Control conl = (Control)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
        }

        private void dtpApplyDate_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void dtpApplyDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);

        }

        private void txtTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void txtSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void ctlNumDraftNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                dtpApplyDate.Value = DateTime.Now;
                txtAccountNo.Text = "";
                //txtAccountNo.Tag = null;
                txtComDocNo.Tag = null;
                txtComDocNo.Text = "";
                txtTo.Text = "";
                txtSubject.Text = "";
                ctlNumBeneficiarysCertificate.Value = 1;
                ctlNumCertificateOfOrigin.Value = 1;
                ctlNumDeliveryChallan.Value = 1;
                ctlNumDraftNo.Value = 1;
                ctlNumInvoiceNo.Value = 1;
                ctlNumLCNo.Value = 1;
                ctlNumPackingList.Value = 1;
                ctlNumPreShipmentInspectioncertioncertificate.Value = 1;
                ctlNumTruckreceipts.Value = 1;
                label15.Text = "No";
                label16.Text = "No";
                label17.Text = "No";
                label18.Text = "No";
                label19.Text = "No";
                label20.Text = "No";
                label21.Text = "No";
                label22.Text = "No";
                label23.Text = "No";
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

        private void ctlNumTruckreceipts_Load(object sender, EventArgs e)
        {

        }
    }
}
