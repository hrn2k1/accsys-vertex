using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Entity;

using System.Collections;
using Accounting.Reports;
using Accounting.Utility;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using Accounting.DataAccess;
using CrystalDecisions.CrystalReports.Engine;


namespace Accounting.UI
{
    public partial class frmReportParameter : Form
    {
        private SqlConnection formConnection = null;
        public frmReportParameter()
        {
            InitializeComponent();
        }

        #region Var

        private int numHeight = 0;
        private RadioButton rbFirst = new RadioButton();
        private RadioButton rbCurrent = new RadioButton();
        private bool _bDefaultInValid = false;
        #endregion
        public void ShowDialog(string strPanelName, string strRbName)
        {
           
            try
            {
                
                    Panel pnl = (Panel)this.Controls.Find(strPanelName, true)[0];
                    try
                    {
                        rbFirst = (RadioButton)this.Controls.Find(strRbName, true)[0];
                    }
                    catch
                    {

                        rbFirst = null;
                    }

                    pnl.Visible = true;
                    flpParam.Top = flpReportType.Top;
                    flpReportType.Width = pnl.Width + 5;
                    flpParam.Location = new Point(flpReportType.Location.X + flpReportType.Width + 5, flpParam.Location.Y);

                    //CalcParamHeight(strPanelName);
                    flpParam.Height = 380;
                    numHeight = (flpParam.Height > pnl.Height ? flpParam.Height : pnl.Height);
                    pnl.Height = numHeight;
                    flpReportType.Height = numHeight + 5;
                    flpParam.Height = numHeight;
                    this.Height = numHeight + 42;
                    this.Width = flpParam.Location.X + flpParam.Width + 12;

                    string[] str = new string[] { "pnlAccounting", "pnlInventory", "pnlCommDocs", "pnlSales", "pnlPurchase","pnlSchedule" };
                    for (int i = 0; i < str.Length; i++)
                    {

                        if (!str[i].Equals(strPanelName))
                        {
                            Control oCon = this.Controls.Find(str[i], true)[0];

                            foreach (Control oControl in oCon.Controls)
                            {
                                if (oControl.GetType() == typeof(RadioButton))
                                {
                                    ((RadioButton)oControl).Checked = false;
                                }
                            }
                        }
                    }
                    ArrayList lRbList = new ArrayList();
                    //int j = 0;
                    foreach (Control oControl in pnl.Controls)
                    {
                        if (oControl.GetType() == typeof(RadioButton))
                        {
                            lRbList.Add(oControl.Name);
                        }
                    }
                    //if (strPanelName != pnlSchedule.Name)
                    //{
                    //    Authentication _objAuthentication = new Authentication(lRbList, true);
                    //    int j = 0;
                    //    foreach (Control oControl in pnl.Controls)
                    //    {
                    //        if (oControl.GetType() == typeof(RadioButton))
                    //        {

                    //            if (!(bool)_objAuthentication.ListCanView[j++])
                    //            {
                    //                oControl.Enabled = false;
                    //                if (oControl.Name == rbFirst.Name)
                    //                    _bDefaultInValid = true;
                    //            }
                    //        }
                    //    }
                    //}
                    if (rbFirst != null) rb_CheckedChanged(rbFirst, null);
                
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CalcParamHeight(string strPanelName)
        {
            switch (strPanelName)
            {
                case "pnlManPower": flpParam.Height = 260; break;
                case "pnlLeave": flpParam.Height = 260; break;
                case "pnlIncrement": flpParam.Height = 260; break;
                case "pnlPromotion": flpParam.Height = 260; break;
                case "pnlLoanAdvance": flpParam.Height = 260; break;
                case "pnlBonus": flpParam.Height = 260; break;
                case "pnlDeduction": flpParam.Height = 260; break;
                case "pnlAllowances": flpParam.Height = 260; break;
                case "pnlProvidentFund": flpParam.Height = 260; break;
                case "pnlIncomeTax": flpParam.Height = 260; break;
                case "pnlGratuity": flpParam.Height = 260; break;
                default: break;
            }
        }
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = new RadioButton();
                if (sender != null)
                {
                    rb = (RadioButton)sender;
                    rbCurrent = rb;
                    rbCurrent.Enabled = rb.Enabled;

                    if (rb.Checked == true)
                    {

                        rb.ForeColor = Color.White;
                        rb.BackColor = Color.Silver;


                        //rb.Appearance = Appearance.Button;
                    }
                    else
                    {
                        rb.ForeColor = Color.Black;
                        rb.BackColor = Color.Transparent;

                        //  rb.ForeColor = Color.Black;
                        // rb.Appearance = Appearance.Normal;
                    }
                }
                if (rb != rbFirst)
                    btnShow.Visible = true;
                else if (_bDefaultInValid)
                    btnShow.Visible = false;
                ParameterDisplay(rb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region report variable
        frmReportViewer frmRV = new frmReportViewer();
        ParameterValues pvc = new ParameterValues();
        ParameterDiscreteValue pdv = new ParameterDiscreteValue();

        #endregion

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (rbCurrent.Enabled == false) return;
            try
            {

                #region Accounting Report
                if (rbLedgerBook.Checked == true)
                    CallLedgerBookReport();
                else if (rbJournalBook.Checked == true)
                    CallJournalBookReport();
                else if (rbCashBook.Checked == true)
                    CallCashBookReport();
                else if (rbBankBook.Checked == true)
                    CallBankBookReport();
                else if (rbVoucherRegister.Checked == true)
                    CallVoucherRegister();
                else if (rbTrialBalance.Checked == true)
                {
                    #region Trial Balance
                    if (cmbTrialBalance.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Select Trial Balance Type"); return;
                    }
                    if (rbTrialBalance.Checked == true && cmbTrialBalance.Text.Trim() == "Summary")
                    {
                        CallTrialBalanceSummeryReport();
                    }
                    else
                    {
                        CallTrialBalanceDetailsReport();
                    }
                    #endregion
                }
                else if (rbCashFlow.Checked == true)
                    CallCashFlowStatementReport();
                else if (rbBillsReceivable.Checked == true)
                    //CallBillsReceivable();
                    CallVariousReport("BR", "Bills Receivable", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                else if (rbBillsPayable.Checked == true)
                    //CallBillsPayable();
                    CallVariousReport("BP", "Bills Payable", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                else if (rbClosingBalance.Checked == true)
                    CallClosingBalance();
                else if (rbChartOfAccounts.Checked == true)
                    CallChartsOfAccounts();
                else if (rbBalanceSheet.Checked)
                {

                    int FYID = 0;
                    if (cboFiscalYear.SelectedValue == null || cboFiscalYear.SelectedValue.GetType() == typeof(DataRowView))
                    {
                        MessageBox.Show("No Fiscal Year created");
                        return;
                    }
                    FYID = (int)cboFiscalYear.SelectedValue;
                    try
                    {

                        if (FYID == new DaFiscalYear().getCurrentFiscalYearID(formConnection))
                        {
                            SqlCommand com = new SqlCommand();

                            com.Connection = formConnection;

                            com.CommandText = "T_spRptBalanceSheet";
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                            com.Parameters.Add("@dividend", SqlDbType.Money).Value = ctlNumDivamt.Value;
                            com.Parameters.Add("@cost_of_goods_sold", SqlDbType.Money).Value = getCostOfGoodsSold(ctlNumRaw.Value, ctlNumFinish.Value, ctlNumWorkInProcess.Value);
                            com.Parameters.Add("@rowMaterials", SqlDbType.Money).Value = ctlNumRaw.Value; // getStock("Raw Material");
                            com.Parameters.Add("@finishedGoods", SqlDbType.Money).Value = ctlNumFinish.Value; // getStock("Finished Good");
                            com.Parameters.Add("@WorkProgress", SqlDbType.Money).Value = ctlNumWorkInProcess.Value;
                            com.Parameters.Add("@FYID", SqlDbType.Int).Value = (int)cboFiscalYear.SelectedValue;
                            com.ExecuteNonQuery();
                        }
                        CallBalanceSheet(FYID);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message);

                    }
                }
                #endregion

                #region Sales Report
                else if (rbSalesLedger.Checked == true)
                    CallSalesLedger();

                else if (rbSalesReturn.Checked == true)
                    CallSalesReturn();

                else if (rbClientCountWiseDelivery.Checked)
                    CallClientCountWiseDeliveryReport();
                else if (rbDeliveryStatement.Checked)
                    CallDeliveryStatementReport();
                else if (rbProdWiseDelvryStat.Checked)
                    CallProductWiseDeliveryStatementReport();
                else if (rbSalesDeliveryChalan.Checked)
                    CallSalesDeliveryChalanReport();
                else if (rbSalesPos.Checked)
                {
                    CallSalesAndPaymentPosition();
                }
                else if (rbStatementofSalesofThread.Checked)
                {
                    CallSalesThread();
                }
                else if (rbInOutQty.Checked)
                {
                    CallrbInOutQty();
                }
                #endregion
                #region purchase Report
                else if (rbPurchaseLedger.Checked == true)
                    CallPurchaseLedger();
                else if (rbPurchaseReturn.Checked == true)
                    CallPurchaseReturn();
                #endregion

                #region Commercial Report
                else if (rbCommDocs.Checked == true)
                    CallCommercialInvoice();
                else if (rbPI.Checked == true)
                    CallPIReport();
                else if (rbExportBill.Checked == true)
                    CallExportBillReport();
                else if (rbExportBillRealize.Checked == true)
                    CallExportBillRealizedReport();
                else if (rbLCRegister.Checked)
                    CallLCRegisterReport();
                else if (rbLCSearch.Checked)
                    CallLCSearchReport();
                else if (rbBBLClist.Checked)
                    CallBBLCListReport();
                else if (rbImportBill.Checked)
                    CallImportBillStatusReport();
                else if (rbImportBill2.Checked)
                    CallImportBillStatusReport2();
                else if (rbListLCPay.Checked)
                    CallLCStatusReport();
                else if (rbLoanAgnstLC.Checked)
                    CallLoanAgainstLCReport();
                else if (rbLiability.Checked)
                    CallLiabilityReport();
                #endregion
                #region Schedule Report
                else if (rbTurnOver.Checked)
                {
                    CallTurnOverReport();
                }
                else if (rbProfitLossAcc.Checked)
                {
                    CallProfitLossAccReport();
                }
                else if (rbCash.Checked)
                {

                    CallVariousReport("CB", "Cash Book", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbSecurityDeposit.Checked)
                {
                    CallVariousReport("D", "Security Deposit", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbSockStore.Checked)
                {
                    CallVariousReport("SS", "Stock & Stores", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbAdvanceSalWage.Checked)
                {
                    CallVariousReport("ASW", "Advance Salary & Wages", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbBankAcc.Checked)
                {
                    CallVariousReport("BACC", "Bank Accounts", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbBillRecvable.Checked)
                {
                    CallVariousReport("BR", "Bills Receivable", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbSundryDr.Checked)
                {
                    CallVariousReport("SDr", "Sundry Debtors", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbSundyCr.Checked)
                {
                    CallVariousReport("SC", "Sundry Creditors", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbBillPayable.Checked)
                {
                    CallVariousReport("BP", "Bills Payable", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbAdvanceRecv.Checked)
                {
                    CallVariousReport("AR", "Advance Rent Received", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbAccruedEx.Checked)
                {
                    CallVariousReport("AE", "Accrued Expense", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbBankLoan.Checked)
                {
                    CallVariousReport("BL", "Bank Loan", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbAdminOverHead.Checked)
                {
                    CallVariousReport("AO", "Administrative Over Head", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbFinancial.Checked)
                {
                    CallVariousReport("FE", "Financial Expense", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbOtherIncome.Checked)
                {
                    CallVariousReport("OI", "Other Income", cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem));
                }
                else if (rbPLA.Checked)
                {
                    CallProfitLossApprReport();
                }
                else if (rbAsstSchdl.Checked)
                {
                    CallAssetScheduleReport();
                }
                #endregion
                #region Inv Report
                else if (rbStockItemJournal.Checked == true)
                    CallStockItemJournal();
                else if (rbItemLedger.Checked == true)
                    CallItemLedger();
                else if (rbtnStockSummeryDetail.Checked == true)
                    CallStockSummeryDetail();
                else if (rbReqSlip.Checked)
                    CallRequisitionSlipReport();
                #endregion

               
                
               
                
                //else if (rbDailyStatementofSalesandPayment.Checked)
                //{
                //    CallDailySalesAndPayment();
                //}
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private double getStock(string str)
        {
            double amt;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT dbo.fnGetStockOfRawFinish(@ItemCategory,@CompanyID)", formConnection);
                cmd.Parameters.Add("@ItemCategory", SqlDbType.VarChar, 100).Value = str;
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                amt = GlobalFunctions.isNull(cmd.ExecuteScalar(), 0.0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return amt;
        }
        private double getOpOfWorkInProces()
        {
            double amt;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Nature*OpeningBalance FROM  VW_AccountWithClassification WHERE (AccountTitle LIKE 'Work in Process') AND (ISNULL(AccountType,'') LIKE 'Current Assets') AND (ISNULL(AccountSubType,'')  LIKE 'Stock & Store') AND (CompanyID = @CompanyID)", formConnection);
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                amt = GlobalFunctions.isNull(cmd.ExecuteScalar(), 0.0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return amt;
        }
        private double getCostOfGoodsSold(double stockRaw, double stockFinish,double WorkInProcess)
        {
            double amt;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT   dbo.fnGetCostOfGoodsSold(@StockRaw,@stockFinish,@WorkinProgress,@CompanyID)", formConnection);
                cmd.Parameters.Add("@StockRaw", SqlDbType.Money).Value = stockRaw;
                cmd.Parameters.Add("@stockFinish", SqlDbType.Money).Value = stockFinish;
                cmd.Parameters.Add("@WorkinProgress", SqlDbType.Money).Value = WorkInProcess;
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                amt = GlobalFunctions.isNull(cmd.ExecuteScalar(), 0.0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return amt;
        }

        #region  Report Call Functions
        private void CallBalanceSheet(int fyID)
        {
            try
            {
                ReportClass rptBSheet=null;
                if (cmbType.SelectedItem.ToString() == "Details" && cmbDisplayType.SelectedItem.ToString() == "! Format")
                    rptBSheet = new rptBalanceSheet();
                else if (cmbType.SelectedItem.ToString() == "Summary" && cmbDisplayType.SelectedItem.ToString() == "! Format")
                    rptBSheet = new rptBalanceSheetSummary();
                else if (cmbType.SelectedItem.ToString() == "Details" && cmbDisplayType.SelectedItem.ToString() == "T Format")
                    rptBSheet = new rptBalanceSheetTDetail();
                if (rptBSheet != null)
                {
                    pdv.Value = LogInInfo.CompanyID;
                    pvc.Add(pdv);
                    rptBSheet.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                    pdv.Value = fyID;
                    pvc.Add(pdv);
                    rptBSheet.DataDefinition.ParameterFields["@FYID"].ApplyCurrentValues(pvc);
                    frmRV.ShowDialog(rptBSheet, false);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CallTurnOverReport()
        {
            try
            {
                rptTurnOver rptTO = new rptTurnOver();


                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptTO.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                pdv.Value = cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem);
                pvc.Add(pdv);
                rptTO.DataDefinition.ParameterFields["@Heading"].ApplyCurrentValues(pvc);
                pdv.Value =(int) cboFiscalYear.SelectedValue;
                pvc.Add(pdv);
                rptTO.DataDefinition.ParameterFields["@FYID"].ApplyCurrentValues(pvc);
                frmRV.ShowDialog(rptTO,false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CallProfitLossAccReport()
        {
            try
            {
                rptProfitLossAccount rptPLA = new rptProfitLossAccount();

                pdv.Value = ctlNumRaw.Value;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@stockRaw"].ApplyCurrentValues(pvc);
                pdv.Value = ctlNumFinish.Value;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@stockFinish"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                pdv.Value = cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem);
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@Title"].ApplyCurrentValues(pvc);
                pdv.Value = ctlNumWorkInProcess.Value;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@WorkinProgress"].ApplyCurrentValues(pvc);
                pdv.Value = (int)cboFiscalYear.SelectedValue;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@FYID"].ApplyCurrentValues(pvc);
                frmRV.ShowDialog(rptPLA, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private void CallProfitLossApprReport()
        {
            try
            {
                rptProfitLossAppr rptPLA = new rptProfitLossAppr();

                pdv.Value = ctlNumRaw.Value;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@stockRaw"].ApplyCurrentValues(pvc);
                pdv.Value = ctlNumFinish.Value;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@stockFinish"].ApplyCurrentValues(pvc);
                pdv.Value = ctlNumDivamt.Value;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@Dividend"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                pdv.Value = cboFiscalYear.GetItemText(cboFiscalYear.SelectedItem);
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@Heading"].ApplyCurrentValues(pvc);
                pdv.Value = ctlNumWorkInProcess.Value;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@WorkinProgress"].ApplyCurrentValues(pvc);
                pdv.Value = (int)cboFiscalYear.SelectedValue;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@FYID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptPLA, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CallAssetScheduleReport()
        {
            try
            {
                rptAssetSchedule rptPLA = new rptAssetSchedule();

                
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = (int)cboFiscalYear.SelectedValue;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@FiscalYearID"].ApplyCurrentValues(pvc);
                frmRV.ShowDialog(rptPLA, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallVariousReport(string rType,string Title,string Heading)
        {
            try
            {
                rptVariousReport rptPLA = new rptVariousReport();

                pdv.Value = rType;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@Report"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                pdv.Value = Title;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@Title"].ApplyCurrentValues(pvc);
                pdv.Value = Heading;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@Heading"].ApplyCurrentValues(pvc);

                pdv.Value = (int)cboFiscalYear.SelectedValue;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@FYID"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptPLA.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                frmRV.ShowDialog(rptPLA, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallLedgerBookReport()
        {
            try
            {


                rptLedgerBook rptLB = new rptLedgerBook();

                pdv.Value = ((Account)txtAccount.Tag).AccountID;
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@AccountID"].ApplyCurrentValues(pvc);

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@UpToDate"].ApplyCurrentValues(pvc);
                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptLB, false);
                //rbListLCPay

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CallCashBookReport()
        {
            //DaAccount obDaAccount = new DaAccount();
           // int AccountId = 0;
            try
            {
                //AccountId = obDaAccount.GetAccountIdOfTitle(formConnection, "Cash in hand");

                rptLedgerBookOfAccounts rptLB = new rptLedgerBookOfAccounts();

                

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);
                pdv.Value = "Cash";
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@AccSubType"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                

                frmRV.ShowDialog(rptLB, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CallBankBookReport()
        {
            try
            {


                rptLedgerBookOfAccounts rptLB = new rptLedgerBookOfAccounts();

                

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);
                pdv.Value = "Bank Account";
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@AccSubType"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                

                frmRV.ShowDialog(rptLB, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CallJournalBookReport()
        {
            try
            {



                rptJournalBook rptJB = new rptJournalBook();


                //pdv.Value = dtpStartdate.Value.Date;
                //pvc.Add(pdv);
                //rptJB.DataDefinition.ParameterFields["@UpToDate"].ApplyCurrentValues(pvc);
                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptJB.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptJB.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptJB.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptJB, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CallVoucherRegister()
        {
            try
            {

                //rptJournalBook rptJB = new rptJournalBook();
                rptVoucharRegister rptVouReg = new rptVoucharRegister();

                pdv.Value = Convert.ToInt32(cboVoucherType.SelectedValue);
                pvc.Add(pdv);
                rptVouReg.DataDefinition.ParameterFields["@VoucherTypeID"].ApplyCurrentValues(pvc);

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptVouReg.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptVouReg.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptVouReg.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptVouReg, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CallStockItemJournal()
        {
            try
            {

                rptStockItemJournal rptSIJ = new rptStockItemJournal();
                pdv.Value = chkItem.Checked==false? 0:Convert.ToInt32(cboItem.SelectedValue);
                pvc.Add(pdv);
                rptSIJ.DataDefinition.ParameterFields["@ItemID"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptSIJ.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptSIJ.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptSIJ.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                pdv.Value = chkItemGroup.Checked? Convert.ToInt32(cboGroupName.SelectedValue):0;
                pvc.Add(pdv);
                rptSIJ.DataDefinition.ParameterFields["@ItemGroupID"].ApplyCurrentValues(pvc);
                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptSIJ.DataDefinition.ParameterFields["@UpToDate"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptSIJ, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CallSalesLedger()
        {
            try
            {

                //rptStockItemJournal rptSIJ = new rptStockItemJournal();
                rptSalesLedger rptSL = new rptSalesLedger();

                pdv.Value = Convert.ToInt32(cboItem.SelectedValue);
                pvc.Add(pdv);
                rptSL.DataDefinition.ParameterFields["@ItemID"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptSL.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptSL.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptSL.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptSL, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallSalesReturn()
        {
            try
            {

                //rptSalesLedger rptSL = new rptSalesLedger();
                rptSalesReturn rptSR = new rptSalesReturn();

                pdv.Value = Convert.ToInt32(cboItem.SelectedValue);
                pvc.Add(pdv);
                rptSR.DataDefinition.ParameterFields["@ItemID"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptSR.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptSR.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptSR.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptSR, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallPurchaseLedger()
        {
            try
            {
                rptPurchaseLedger rptPL = new rptPurchaseLedger();

                pdv.Value = Convert.ToInt32(cboItem.SelectedValue);
                pvc.Add(pdv);
                rptPL.DataDefinition.ParameterFields["@ItemID"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptPL.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptPL.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptPL.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptPL, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallPurchaseReturn()
        {
            try
            {
                rptPurchaseReturn rptPR = new rptPurchaseReturn();
                pdv.Value = Convert.ToInt32(cboItem.SelectedValue);
                pvc.Add(pdv);
                rptPR.DataDefinition.ParameterFields["@ItemID"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptPR.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptPR.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptPR.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptPR, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallItemLedger()
        {
            try
            {
                //rptPurchaseReturn rptPR = new rptPurchaseReturn();
                rptItemLedger rptIL = new rptItemLedger();
                pdv.Value = Convert.ToInt32(cboItem.SelectedValue);
                pvc.Add(pdv);
                rptIL.DataDefinition.ParameterFields["@ItemID"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptIL.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptIL.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptIL.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptIL.DataDefinition.ParameterFields["@UpToDate"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptIL, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallBillsReceivable()
        {
            try
            {
                rptBillsReceivablePayable rptBills = new rptBillsReceivablePayable();
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptBills.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = "Bills Receivable";
                pvc.Add(pdv);
                rptBills.DataDefinition.ParameterFields["@BillType"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptBills, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallBillsPayable()
        {
            try
            {
                rptBillsReceivablePayable rptBills = new rptBillsReceivablePayable();
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptBills.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = "Bills Payable";
                pvc.Add(pdv);
                rptBills.DataDefinition.ParameterFields["@BillType"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptBills, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallClosingBalance()
        {
            try
            {
                rptClosingBalanceOfAccounts rptCB = new rptClosingBalanceOfAccounts();

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptCB.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = Convert.ToInt32(cboAccountingHead.SelectedValue);
                pvc.Add(pdv);
                rptCB.DataDefinition.ParameterFields["@ParentID"].ApplyCurrentValues(pvc);
                /*
                pdv.Value = dtpDate.Value.Date;
                pvc.Add(pdv);
                rptCB.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);
                */
                pdv.Value = cboAccountingHead.GetItemText(cboAccountingHead.SelectedItem);
                pvc.Add(pdv);
                rptCB.DataDefinition.ParameterFields["@HeaderName"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptCB, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CallTrialBalanceSummeryReport()
        {
            try
            {


                rptTrialBalanceSummery rptTB = new rptTrialBalanceSummery();

                //pdv.Value = ((Account)txtAccount.Tag).AccountID;
                //pvc.Add(pdv);
                //rptLB.DataDefinition.ParameterFields["@AccountID"].ApplyCurrentValues(pvc);

                //pdv.Value = dtpStartdate.Value.Date;
                //pvc.Add(pdv);
                //rptLB.DataDefinition.ParameterFields["@UpToDate"].ApplyCurrentValues(pvc);


                pdv.Value = dateTimePicker1.Value.Date;
                pvc.Add(pdv);
                rptTB.DataDefinition.ParameterFields["@atDate"].ApplyCurrentValues(pvc);

                //pdv.Value = dtpEndDate.Value.Date;
                //pvc.Add(pdv);
                //rptLB.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptTB.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptTB, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallTrialBalanceDetailsReport()
        {
            try
            {


                rptTrialBalanceDetail rptTB = new rptTrialBalanceDetail();

                //pdv.Value = ((Account)txtAccount.Tag).AccountID;
                //pvc.Add(pdv);
                //rptLB.DataDefinition.ParameterFields["@AccountID"].ApplyCurrentValues(pvc);

                //pdv.Value = dtpStartdate.Value.Date;
                //pvc.Add(pdv);
                //rptLB.DataDefinition.ParameterFields["@UpToDate"].ApplyCurrentValues(pvc);


                pdv.Value = dateTimePicker1.Value.Date;
                pvc.Add(pdv);
                rptTB.DataDefinition.ParameterFields["@atDate"].ApplyCurrentValues(pvc);

                //pdv.Value = dtpEndDate.Value.Date;
                //pvc.Add(pdv);
                //rptLB.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptTB.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptTB, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallCashFlowStatementReport()
        {
            try
            {


                rptCashFlowStatement rptLB = new rptCashFlowStatement();




                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptLB.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptLB, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallChartsOfAccounts()
        {
            try
            {
                //rptChartOfAccounts rptCOA = new rptChartOfAccounts();
                rptChartsOfAccount rptCOA = new rptChartsOfAccount();
                
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptCOA.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                frmRV.ShowDialog(rptCOA, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallCommercialInvoice()
        {
            try
            {
                if (txtComInvNo.Tag == null)
                {
                    MessageBox.Show("Please Enter Commercial Invoice No.");
                    return;
                }
                if (cboComDocs.SelectedItem.ToString().ToLower() == "Bill Of Exchange".ToLower())
                {
                    rptBillOfExchange rptCI = new rptBillOfExchange();

                    pdv.Value = (int)txtComInvNo.Tag;
                    pvc.Add(pdv);
                    rptCI.DataDefinition.ParameterFields["@ComInvoiceID"].ApplyCurrentValues(pvc);
                    pdv.Value = LogInInfo.CompanyID;
                    pvc.Add(pdv);
                    rptCI.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                    pdv.Value = 1;
                    pvc.Add(pdv);
                    rptCI.DataDefinition.ParameterFields["@Suppress"].ApplyCurrentValues(pvc);
                    frmRV.ShowDialog(rptCI, false);
                }
                else if (cboComDocs.SelectedItem.ToString().ToLower() == "Commercial Invoice".ToLower())
                {
                    rptCommercialInvoice rptCI = new rptCommercialInvoice();

                    pdv.Value = (int)txtComInvNo.Tag;
                    pvc.Add(pdv);
                    rptCI.DataDefinition.ParameterFields["@ComInvoiceID"].ApplyCurrentValues(pvc);
                    pdv.Value = LogInInfo.CompanyID;
                    pvc.Add(pdv);
                    rptCI.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                    frmRV.ShowDialog(rptCI, false);
                }
                else if (cboComDocs.SelectedItem.ToString().ToLower() == "Musok".ToLower())
                {
                    rptMusok rptMus = new rptMusok();
                    pdv.Value = (int)txtComInvNo.Tag;
                    pvc.Add(pdv);
                    rptMus.DataDefinition.ParameterFields["@ComInvoiceID"].ApplyCurrentValues(pvc);
                    pdv.Value = LogInInfo.CompanyID;
                    pvc.Add(pdv);
                    rptMus.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                    frmRV.ShowDialog(rptMus, false);
                }
                else if (cboComDocs.SelectedItem.ToString().ToLower() == "Packing List".ToLower())
                {
                    rptPackingList rptPL = new rptPackingList();

                    pdv.Value = (int)txtComInvNo.Tag;
                    pvc.Add(pdv);
                    rptPL.DataDefinition.ParameterFields["@ComInvoiceID"].ApplyCurrentValues(pvc);
                    pdv.Value = LogInInfo.CompanyID;
                    pvc.Add(pdv);
                    rptPL.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                    frmRV.ShowDialog(rptPL, false);
                }
                else if (cboComDocs.SelectedItem.ToString().ToLower() == "Certificate of Origin".ToLower())
                {
                    rptCertificateOfOrigin rptCO = new rptCertificateOfOrigin();

                    pdv.Value = (int)txtComInvNo.Tag;
                    pvc.Add(pdv);
                    rptCO.DataDefinition.ParameterFields["@ComInvoiceID"].ApplyCurrentValues(pvc);
                    pdv.Value = LogInInfo.CompanyID;
                    pvc.Add(pdv);
                    rptCO.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                    frmRV.ShowDialog(rptCO, false);
                }
                else if (cboComDocs.SelectedItem.ToString().ToLower() == "Pre-Shipment Inspection Certificate".ToLower())
                {
                    rptPreShipmentInspectionCertificate rptPSC = new rptPreShipmentInspectionCertificate();

                    pdv.Value = (int)txtComInvNo.Tag;
                    pvc.Add(pdv);
                    rptPSC.DataDefinition.ParameterFields["@ComInvoiceID"].ApplyCurrentValues(pvc);
                    pdv.Value = LogInInfo.CompanyID;
                    pvc.Add(pdv);
                    rptPSC.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                    frmRV.ShowDialog(rptPSC, false);
                }

                else if (cboComDocs.SelectedItem.ToString().ToLower() == "Beneficiary Certificate".ToLower())
                {
                    rptBeneficiaryCertificate rptBFC = new rptBeneficiaryCertificate();

                    pdv.Value = (int)txtComInvNo.Tag;
                    pvc.Add(pdv);
                    rptBFC.DataDefinition.ParameterFields["@ComInvoiceID"].ApplyCurrentValues(pvc);
                    pdv.Value = LogInInfo.CompanyID;
                    pvc.Add(pdv);
                    rptBFC.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                    frmRV.ShowDialog(rptBFC, false);
                }
                else if (cboComDocs.SelectedItem.ToString().ToLower() == "Delivery Challan".ToLower())
                {
                    rptDeliveryChallan rptDc = new rptDeliveryChallan();

                    pdv.Value = (int)txtComInvNo.Tag;
                    pvc.Add(pdv);
                    rptDc.DataDefinition.ParameterFields["@ComInvoiceID"].ApplyCurrentValues(pvc);
                    pdv.Value = LogInInfo.CompanyID;
                    pvc.Add(pdv);
                    rptDc.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                    frmRV.ShowDialog(rptDc, false);
                }

                else if (cboComDocs.SelectedItem.ToString().ToLower() == "Truck Receipt".ToLower())
                {
                    rptTruckReceipt rptTR = new rptTruckReceipt();

                    pdv.Value = (int)txtComInvNo.Tag;
                    pvc.Add(pdv);
                    rptTR.DataDefinition.ParameterFields["@ComInvoiceID"].ApplyCurrentValues(pvc);
                    pdv.Value = LogInInfo.CompanyID;
                    pvc.Add(pdv);
                    rptTR.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                    frmRV.ShowDialog(rptTR, false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallStockSummeryDetail()
        {
            try
            {

                rptStockSummeryDetail rptSSD = new rptStockSummeryDetail();

                pdv.Value = Convert.ToInt32(cboItem.SelectedValue);
                pvc.Add(pdv);
                rptSSD.DataDefinition.ParameterFields["@ItemID"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptSSD.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptSSD.DataDefinition.ParameterFields["@sDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptSSD.DataDefinition.ParameterFields["@eDate"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptSSD, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CallExportBillReport()
        {
            try
            {

               
                rptExportBillNew rptExBill = new rptExportBillNew();

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptExBill.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptExBill.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptExBill.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);


                pdv.Value = (chkCustomer.Checked ? ((Ledgers)txtCustomerSupplier.Tag).LedgerID : 0);
                pvc.Add(pdv);
                rptExBill.DataDefinition.ParameterFields["@CustomerID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptExBill, false);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CallExportBillRealizedReport()
        {
            try
            {



                rptExportBillAccs rptExBillAcc = new rptExportBillAccs();

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptExBillAcc.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptExBillAcc.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptExBillAcc.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = (chkCustomer.Checked ? ((Ledgers)txtCustomerSupplier.Tag).LedgerID : 0);
                pvc.Add(pdv);
                rptExBillAcc.DataDefinition.ParameterFields["@CustomerID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptExBillAcc, false);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CallLCRegisterReport()
        {
            try
            {

                rptLCregister rptLCR = new rptLCregister();



                pdv.Value = cmbLCType.SelectedItem.ToString();
                pvc.Add(pdv);
                rptLCR.DataDefinition.ParameterFields["@LCType"].ApplyCurrentValues(pvc);
                pdv.Value = 0;
                pvc.Add(pdv);
                rptLCR.DataDefinition.ParameterFields["@CustSuppID"].ApplyCurrentValues(pvc);
                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptLCR.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptLCR.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptLCR.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = chkTeam.Checked ? (int)cmbMember.SelectedValue : 0; 
                pvc.Add(pdv);
                rptLCR.DataDefinition.ParameterFields["@TeamID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptLCR, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        private void CallLCSearchReport()
        {
            try
            {

                rptLCSearchByStatus rptLCS = new rptLCSearchByStatus();

                if (cboLCStatus.Tag == null)
                {
                    MessageBox.Show("Correctly select LC status");
                    return;
                }

                pdv.Value = "all";
                pvc.Add(pdv);
                rptLCS.DataDefinition.ParameterFields["@LCType"].ApplyCurrentValues(pvc);
                pdv.Value = cboLCStatus.Tag.ToString();
                pvc.Add(pdv);
                rptLCS.DataDefinition.ParameterFields["@reportName"].ApplyCurrentValues(pvc);
                pdv.Value = dtpDate.Value.Date;
                pvc.Add(pdv);
                rptLCS.DataDefinition.ParameterFields["@ToDayDate"].ApplyCurrentValues(pvc);

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptLCS.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = cboLCStatus.SelectedItem.ToString();
                pvc.Add(pdv);
                rptLCS.DataDefinition.ParameterFields["@Header"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptLCS, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
     
         private void CallBBLCListReport()
        {
            try
            {

                rptBBLClist rptBBLCS = new rptBBLClist();
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptBBLCS.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptBBLCS.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);
                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptBBLCS.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);
                frmRV.ShowDialog(rptBBLCS, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       private void CallImportBillStatusReport()
         {
             try
             {
                 //if (txtLCNo.Tag == null || ((LC_Master)txtLCNo.Tag).LCID <= 0)
                 //{
                 //    MessageBox.Show("Please Select LC Correctly");
                 //    return;
                 //}
                 rptImportBill rptImportStatus = new rptImportBill();

                 pdv.Value = 0;// ((LC_Master)txtLCNo.Tag).LCID;
                 pvc.Add(pdv);
                 rptImportStatus.DataDefinition.ParameterFields["@LCID"].ApplyCurrentValues(pvc);
                 pdv.Value = cmbLCType.SelectedItem.ToString();
                 pvc.Add(pdv);
                 rptImportStatus.DataDefinition.ParameterFields["@LCType"].ApplyCurrentValues(pvc);
                 pdv.Value = LogInInfo.CompanyID;
                 pvc.Add(pdv);
                 rptImportStatus.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                 pdv.Value = dtpStartdate.Value.Date;
                 pvc.Add(pdv);
                 rptImportStatus.DataDefinition.ParameterFields["@StartDate"].ApplyCurrentValues(pvc);
                 pdv.Value = dtpEndDate.Value.Date;
                 pvc.Add(pdv);
                 rptImportStatus.DataDefinition.ParameterFields["@EndDate"].ApplyCurrentValues(pvc);
                 
                 frmRV.ShowDialog(rptImportStatus,true);


                 //rptImportStatusNew rptIS = new rptImportStatusNew();

                 //pdv.Value = dtpStartdate.Value.Date;
                 //pvc.Add(pdv);
                 //rptIS.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);
                 //pdv.Value = dtpEndDate.Value.Date;
                 //pvc.Add(pdv);
                 //rptIS.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);
                 //pdv.Value = LogInInfo.CompanyID;
                 //pvc.Add(pdv);
                 //rptIS.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                 //frmRV.ShowDialog(rptIS, false);
             }
             catch (Exception ex)
             {
                 throw ex;
             }

         }
       private void CallImportBillStatusReport2()
       {
           try
           {

               rptImportStatusNew rptIS = new rptImportStatusNew();

               pdv.Value = dtpStartdate.Value.Date;
               pvc.Add(pdv);
               rptIS.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);
               pdv.Value = dtpEndDate.Value.Date;
               pvc.Add(pdv);
               rptIS.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);
               pdv.Value = LogInInfo.CompanyID;
               pvc.Add(pdv);
               rptIS.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
               frmRV.ShowDialog(rptIS, false);
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }
        
        private void  CallLCStatusReport()
         {
             try
             {

                 rptLCStatus rptLCStatus = new rptLCStatus();

                 pdv.Value = dtpStartdate.Value.Date;
                 pvc.Add(pdv);
                 rptLCStatus.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);
                 pdv.Value = dtpEndDate.Value.Date;
                 pvc.Add(pdv);
                 rptLCStatus.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);
                 pdv.Value = LogInInfo.CompanyID;
                 pvc.Add(pdv);
                 rptLCStatus.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                 pdv.Value = cmbLCType.SelectedItem.ToString();
                 pvc.Add(pdv);
                 rptLCStatus.DataDefinition.ParameterFields["@LCType"].ApplyCurrentValues(pvc);
                 frmRV.ShowDialog(rptLCStatus, false);

             }
             catch (Exception ex)
             {
                 throw ex;
             }

         }
        
        private void  CallLoanAgainstLCReport()
         {
             try
             {

                 rptLoanAgaintLC rptLoanLC = new rptLoanAgaintLC();

                 pdv.Value = cmbLCType.SelectedItem.ToString();
                 pvc.Add(pdv);
                 rptLoanLC.DataDefinition.ParameterFields["@LCType"].ApplyCurrentValues(pvc);
                 pdv.Value = dtpStartdate.Value.Date;
                 pvc.Add(pdv);
                 rptLoanLC.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);
                 pdv.Value = dtpEndDate.Value.Date;
                 pvc.Add(pdv);
                 rptLoanLC.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);
                 pdv.Value = LogInInfo.CompanyID;
                 pvc.Add(pdv);
                 rptLoanLC.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                 
                 frmRV.ShowDialog(rptLoanLC, false);

             }
             catch (Exception ex)
             {
                 throw ex;
             }

         }

        private void CallLiabilityReport()
         {
             try
             {

                 rptLiabilityPosition rptLP = new rptLiabilityPosition();


                 pdv.Value = ((Account)txtAccount.Tag).AccountID; 
                 pvc.Add(pdv);
                 rptLP.DataDefinition.ParameterFields["@LoanFromAccID"].ApplyCurrentValues(pvc);
                 pdv.Value = LogInInfo.CompanyID;
                 pvc.Add(pdv);
                 rptLP.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                 
                 frmRV.ShowDialog(rptLP, false);

             }
             catch (Exception ex)
             {
                 throw ex;
             }

         }
        private void  CallRequisitionSlipReport()
         {
             try
             {

                 rptStoreRequisitionSlip rptReq = new rptStoreRequisitionSlip();

                 pdv.Value = ((ReqMaster)txtReqNo.Tag).ReqMID;
                 pvc.Add(pdv);
                 rptReq.DataDefinition.ParameterFields["@ReqMID"].ApplyCurrentValues(pvc);
                
                 pdv.Value = LogInInfo.CompanyID;
                 pvc.Add(pdv);
                 rptReq.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                 
                 frmRV.ShowDialog(rptReq, false);

             }
             catch (Exception ex)
             {
                 throw ex;
             }

         }
       
         private void  CallClientCountWiseDeliveryReport()
         {
             try
             {

                 rptClientCountWiseSalesQty rptReq = new rptClientCountWiseSalesQty();

                 pdv.Value = dtpStartdate.Value.Date;
                 pvc.Add(pdv);
                 rptReq.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);
                 pdv.Value = dtpEndDate.Value.Date;
                 pvc.Add(pdv);
                 rptReq.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                 
                 pdv.Value = LogInInfo.CompanyID;
                 pvc.Add(pdv);
                 rptReq.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                 #region Create List
                 int i, nR;
                 string cList = "";
                 nR = CtldgvCustomers.Rows.Count;
                 for (i = 0; i < nR; i++)
                 {
                     if (GlobalFunctions.isNull(CtldgvCustomers[Coltick.Name, i].Value, 0) == 1)
                         cList += GlobalFunctions.isNull(CtldgvCustomers["LedgerID", i].Value, "0") + ",";
                 }
                 #endregion
                 pdv.Value = cList;
                 pvc.Add(pdv);
                 rptReq.DataDefinition.ParameterFields["@CustomerList"].ApplyCurrentValues(pvc);

                 frmRV.ShowDialog(rptReq, false);

             }
             catch (Exception ex)
             {
                 throw ex;
             }

         }

         private void CallDeliveryStatementReport()
         {
             try
             {

                 rptDeliveryStatement rpt = new rptDeliveryStatement();

                 pdv.Value = dtpStartdate.Value.Date;
                 pvc.Add(pdv);
                 rpt.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);
                 pdv.Value = dtpEndDate.Value.Date;
                 pvc.Add(pdv);
                 rpt.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                
                 pdv.Value = LogInInfo.CompanyID;
                 pvc.Add(pdv);
                 rpt.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                 #region Create List
                 int i, nR;
                 string cList = "";
                 nR = CtldgvCustomers.Rows.Count;
                 for (i = 0; i < nR; i++)
                 {
                     if (GlobalFunctions.isNull(CtldgvCustomers[Coltick.Name, i].Value, 0) == 1)
                         cList += GlobalFunctions.isNull(CtldgvCustomers["LedgerID", i].Value, "0") + ",";
                 }
                 #endregion
                 pdv.Value = cList;
                 pvc.Add(pdv);
                 rpt.DataDefinition.ParameterFields["@CustomerList"].ApplyCurrentValues(pvc);

                 frmRV.ShowDialog(rpt, false);

             }
             catch (Exception ex)
             {
                 throw ex;
             }

         }

         private void CallProductWiseDeliveryStatementReport()
         {
             try
             {

                 rptProductWiseDeliveryStatement rpt = new rptProductWiseDeliveryStatement();

                 pdv.Value = dtpStartdate.Value.Date;
                 pvc.Add(pdv);
                 rpt.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);
                 pdv.Value = dtpEndDate.Value.Date;
                 pvc.Add(pdv);
                 rpt.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                
                 pdv.Value = LogInInfo.CompanyID;
                 pvc.Add(pdv);
                 rpt.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                 pdv.Value = "0";
                 pvc.Add(pdv);
                 rpt.DataDefinition.ParameterFields["@CustomerList"].ApplyCurrentValues(pvc);

                 frmRV.ShowDialog(rpt, false);

             }
             catch (Exception ex)
             {
                 throw ex;
             }

         }

         private void CallSalesDeliveryChalanReport()
         {
             try
             {

                 rptSalesDeliveryChalanStock rpt = new rptSalesDeliveryChalanStock();

                 pdv.Value = (int)txtSalesInvNo.Tag;
                 pvc.Add(pdv);
                 rpt.DataDefinition.ParameterFields["@InvoiceID"].ApplyCurrentValues(pvc);
                 

                
                 pdv.Value = LogInInfo.CompanyID;
                 pvc.Add(pdv);
                 rpt.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                 frmRV.ShowDialog(rpt, false);

             }
             catch (Exception ex)
             {
                 throw ex;
             }

         }
        private void CallPIReport()
        {
            try
            {
                if (txtPINo.Tag == null)
                {
                    MessageBox.Show("Please Enter Proforma Invoice No.");
                    return;
                }

                rptProformainvoice rptPI = new rptProformainvoice();

                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptPI.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                pdv.Value = (int)txtPINo.Tag;
                pvc.Add(pdv);
                rptPI.DataDefinition.ParameterFields["@PIMID"].ApplyCurrentValues(pvc);
                
                frmRV.ShowDialog(rptPI, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /*
        private void CallDailySalesAndPayment()
        {
            try
            {

                //rptExportBill rptExBill = new rptExportBill();
                rptDailySalesAndPayment rptDSSPP = new rptDailySalesAndPayment();
                
                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptDSSPP.DataDefinition.ParameterFields["@sDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptDSSPP.DataDefinition.ParameterFields["@eDate"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptDSSPP.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptDSSPP, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
         * */
        private void CallSalesAndPaymentPosition()
        {
            try
            {


                //rptSalesPaymentPosition rptDSSPP = new rptSalesPaymentPosition();

                //pdv.Value = dtpStartdate.Value.Date;
                //pvc.Add(pdv);
                //rptDSSPP.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                //pdv.Value = dtpEndDate.Value.Date;
                //pvc.Add(pdv);
                //rptDSSPP.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);
                //pdv.Value = LogInInfo.CompanyID;
                //pvc.Add(pdv);
                //rptDSSPP.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                //frmRV.ShowDialog(rptDSSPP, false);
                rptSalesPosition rptDSSPP = new rptSalesPosition();

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptDSSPP.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptDSSPP.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptDSSPP.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                #region Create List
                int i, nR;
                string cList = "";
                nR = CtldgvCustomers.Rows.Count;
                for(i=0;i<nR;i++)
                {
                    if(GlobalFunctions.isNull(CtldgvCustomers[Coltick.Name,i].Value, 0)==1)
                    cList += GlobalFunctions.isNull(CtldgvCustomers["LedgerID",i].Value, "0") + ",";
                }
                #endregion

                pdv.Value = cList;
                pvc.Add(pdv);
                rptDSSPP.DataDefinition.ParameterFields["@CustomerList"].ApplyCurrentValues(pvc);
                frmRV.ShowDialog(rptDSSPP, false);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
      
            
        private void CallrbInOutQty()
        {
            try
            {

                //rptLoanAgaintLC rptLoanLC = new rptLoanAgaintLC();
                rptCustomerLCOrderItemInOut rptCustomerLCOrderItemInOut = new rptCustomerLCOrderItemInOut();
                try
                {
                    pdv.Value = chkCustomer.Checked ? ((Ledgers)txtCustomerSupplier.Tag).LedgerID : -1;
                    pvc.Add(pdv);
                    rptCustomerLCOrderItemInOut.DataDefinition.ParameterFields["@LedgerID"].ApplyCurrentValues(pvc);
                }
                catch { MessageBox.Show("Please Select a Customer"); return; }
                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptCustomerLCOrderItemInOut.DataDefinition.ParameterFields["@SDate"].ApplyCurrentValues(pvc);
                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptCustomerLCOrderItemInOut.DataDefinition.ParameterFields["@EDate"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptCustomerLCOrderItemInOut.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                pdv.Value = chkOrderNo.Checked?txtOrderNo.Text:"all";
                pvc.Add(pdv);
                rptCustomerLCOrderItemInOut.DataDefinition.ParameterFields["@OrderNo"].ApplyCurrentValues(pvc);
                pdv.Value = chkLCNew.Checked ? txtLCNew.Text : "all";
                pvc.Add(pdv);
                rptCustomerLCOrderItemInOut.DataDefinition.ParameterFields["@LCNo"].ApplyCurrentValues(pvc);
                 pdv.Value = -1;
                pvc.Add(pdv);
                rptCustomerLCOrderItemInOut.DataDefinition.ParameterFields["@LCID"].ApplyCurrentValues(pvc);
                pdv.Value = -1;
                pvc.Add(pdv);
                rptCustomerLCOrderItemInOut.DataDefinition.ParameterFields["@OrderID"].ApplyCurrentValues(pvc);
                pdv.Value = -1;
                pvc.Add(pdv);
                rptCustomerLCOrderItemInOut.DataDefinition.ParameterFields["@ItemID"].ApplyCurrentValues(pvc);
                frmRV.ShowDialog(rptCustomerLCOrderItemInOut, false);






            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CallSalesThread()
        {
            try
            {

                //rptLoanAgaintLC rptLoanLC = new rptLoanAgaintLC();
                rptSalesThread rptST = new rptSalesThread();

                pdv.Value = ((Ledgers)txtCustomerSupplier.Tag).LedgerID;
                pvc.Add(pdv);
                rptST.DataDefinition.ParameterFields["@CustSupplID"].ApplyCurrentValues(pvc);

                pdv.Value = dtpStartdate.Value.Date;
                pvc.Add(pdv);
                rptST.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);
                pdv.Value = dtpEndDate.Value.Date;
                pvc.Add(pdv);
                rptST.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);
                pdv.Value = LogInInfo.CompanyID;
                pvc.Add(pdv);
                rptST.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);

                frmRV.ShowDialog(rptST, false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        private void ParameterDisplay(RadioButton rb)
        {
            try
            {

                switch (rb.Name)
                {
                    case "rbLedgerBook": setControlVisible(true, pDateRange.Name, pAccount.Name); break;
                    case "rbJournalBook": setControlVisible(true, pDateRange.Name); break;
                    case "rbCashBook": setControlVisible(true, pDateRange.Name); break;
                    case "rbBankBook": setControlVisible(true, pDateRange.Name); break;
                    case "rbVoucherRegister": setControlVisible(true, pDateRange.Name, pVoucherType.Name); break;
                    case "rbTrialBalance": setControlVisible(true, pnlTrialBalance.Name); cmbTrialBalance.SelectedItem = "Summary"; break;
                    case "rbStockItemJournal": setControlVisible(true, pDateRange.Name, pItem.Name); break;
                    case "rbSalesLedger": setControlVisible(true, pDateRange.Name, pItem.Name); break;
                    case "rbSalesReturn": setControlVisible(true, pDateRange.Name, pItem.Name); break;
                    case "rbCashFlow": setControlVisible(true, pDateRange.Name); break;
                    case "rbPurchaseLedger": setControlVisible(true, pDateRange.Name, pItem.Name); break;
                    case "rbPurchaseReturn": setControlVisible(true, pDateRange.Name, pItem.Name); break;
                    case "rbItemLedger": setControlVisible(true, pDateRange.Name, pItem.Name); break;
                    case "rbBillsPayable": setControlVisible(true); break;
                    case "rbBillsReceivable": setControlVisible(true); break;
                    case "rbClosingBalance": setControlVisible(true, pAccountHead.Name); break;
                    case "rbChartOfAccounts": setControlVisible(true); break;
                    case "rbCommDocs": setControlVisible(true, pnlComDocs.Name, pnlComInvNo.Name); cboComDocs.SelectedIndex = 0; break;
                    case "rbPI": setControlVisible(true, pnlPINo.Name); break;
                    case "rbtnStockSummeryDetail": setControlVisible(true, pDateRange.Name, pItem.Name); break;
                    case "rbExportBill":
                        setControlVisible(true, pDateRange.Name, pCustomerSupplier.Name); break;
                    case "rbExportBillRealize":
                        setControlVisible(true, pDateRange.Name,pCustomerSupplier.Name); break;
                    case "rbSalesPos":
                        setControlVisible(true, pDateRange.Name,pCustomerList.Name); break;

                    case "rbLCRegister": setControlVisible(true, pDateRange.Name, pSalesTeam.Name, pLCType.Name/*,pCustomerSupplier.Name*/); cmbLCType.SelectedIndex = 0; break;
                    case "rbLCSearch": setControlVisible(true, pLCSatus.Name, pDate.Name); cboLCStatus.SelectedIndex = 0; break;
                    case "rbBBLClist": setControlVisible(true, pDateRange.Name); break;
                    case "rbImportBill2": setControlVisible(true, pDateRange.Name); break;
                    case "rbImportBill": setControlVisible(true, pDateRange.Name, pLCType.Name); cmbLCType.SelectedIndex = 0; break;
                    case "rbListLCPay": setControlVisible(true, pDateRange.Name, pLCType.Name); cmbLCType.SelectedIndex = 0; break;
                    case "rbLoanAgnstLC": setControlVisible(true, pDateRange.Name, pLCType.Name); cmbLCType.SelectedIndex = 0; break;
                    case "rbReqSlip": setControlVisible(true, pRegNo.Name); break;
                    case "rbClientCountWiseDelivery": setControlVisible(true, pDateRange.Name,pCustomerList.Name); break;
                    case "rbDeliveryStatement": setControlVisible(true, pDateRange.Name,pCustomerList.Name); break;
                    case "rbProdWiseDelvryStat": setControlVisible(true, pDateRange.Name); break;
                    case "rbSalesDeliveryChalan": setControlVisible(true, pSalesInvNo.Name); break;
                    case "rbBalanceSheet": setControlVisible(true, pFiscalYear.Name, pBalanceSheet.Name, pBalShtType.Name); break;
                    case "rbAccruedEx":
                    case "rbAdvanceRecv":
                    case "rbBillPayable":
                    case "rbSundyCr":
                    case "rbBankLoan":
                    case "rbAdminOverHead":
                    case "rbFinancial":
                    case "rbOtherIncome":
                    case "rbCash":
                    case "rbSecurityDeposit":
                    case "rbSockStore":
                    case "rbAdvanceSalWage":
                    case "rbBillRecvable":
                    case "rbSundryDr":
                    case "rbBankAcc":
                        setControlVisible(true, pFiscalYear.Name); break;
                    case "rbTurnOver": setControlVisible(true, pFiscalYear.Name); break;
                    case "rbProfitLossAcc": setControlVisible(true, pFiscalYear.Name, pBalanceSheet.Name); break;
                    case "rbPLA": setControlVisible(true, pFiscalYear.Name, pBalanceSheet.Name); break;
                    case "rbAsstSchdl": setControlVisible(true, pFiscalYear.Name); break;

                    case "rbDailyStatementofSalesandPayment": setControlVisible(true, pDateRange.Name); break;
                    case "rbStatementofSalesofThread": setControlVisible(true, pDateRange.Name, pCustomerSupplier.Name); break;
                    case "rbInOutQty": setControlVisible(true,pLCNew.Name, pCustomerSupplier.Name,pDateRange.Name,pOrder.Name); break;
                    case "rbLiability": setControlVisible(true, pAccount.Name); break;
                    default: setControlVisible(true, null); break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void setControlVisible(bool f, params string[] strControlName)
        {
            try
            {
                int i, nCtl;
                nCtl = flpParam.Controls.Count;
                for (i = 0; i < nCtl; i++)
                {
                    flpParam.Controls[i].Visible = !f;
                }
                if (strControlName == null) return;
                nCtl = strControlName.Length;

                for (i = 0; i < nCtl; i++)
                {
                    flpParam.Controls[strControlName[i]].Visible = f;
                }
                btnShow.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmReportParameter_Paint(object sender, PaintEventArgs e)
        {
            FormColorClass.ColorForm(this, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAccount_Enter(object sender, EventArgs e)
        {
            try
            {

                frmAccountSearch frm = new frmAccountSearch();
                if (txtAccount.Tag == null)
                    frm.ShowDialog();
                else
                {
                    Account acc = (Account)txtAccount.Tag;
                    frm.ShowDialog(acc.AccountID);
                }
                Account objSelectedAcc = frm.SelectedAccount;
                if (objSelectedAcc == null) return;

                txtAccount.Text = objSelectedAcc.AccountTitle;
                txtAccount.Tag = objSelectedAcc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void flpReportType_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmReportParameter_Load(object sender, EventArgs e)
        {
            try
            {
                formConnection = ConnectionHelper.getConnection();
                DoubleBuffered = Enabled;
                loadVoucherType();
                loadFiscalYear();
                cboVoucherType.SelectedValue = 0;
                loadAccountHead();
                cboAccountingHead.SelectedIndex = 0;
                loadTeamMaster();
                //cboBillsType.SelectedIndex = 0;

                DataTable dtItem = new DAChartsOfItem().LoadGroupInDGV(formConnection);
                dtItem.Rows.Add(0, "ALL");
                cboGroupName.DataSource = dtItem;
                cboGroupName.DisplayMember = "GroupName";
                cboGroupName.ValueMember = "ItemGroupID";
                //cboGroupName.SelectedValue = 0;
                cboGroupName.SelectedIndex = 0;
                cmbType.SelectedIndex = 0;
                cmbDisplayType.SelectedIndex = 0;
                ctlNumRaw.Value =Math.Round( getStock("Raw Material"),2);
                ctlNumFinish.Value =Math.Round( getStock("Finished Good"),2);
                ctlNumWorkInProcess.Value = Math.Round(getOpOfWorkInProces(), 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error " + ex.Message);
            }
        }
        private void loadSelectedCustomer()
        {
            string strQuerry = " Select LedgerID, LedgerName Customer from T_Ledgers Where LedgerTypeID = 2 AND CompanyID= " + LogInInfo.CompanyID.ToString() + " ";
            if (chkSalesTeam.Checked == true)
            {
                if ((int)cmbSalesTeam.SelectedValue > 0)
                    strQuerry += " AND teamID=" + cmbTeamMember.SelectedValue.ToString();
                else
                    strQuerry += " AND teamID IS NULL";

            }
            else if (chkCust.Checked == true)
                strQuerry += " AND ledgerName Like '" + txtCustomerName.Text.ToString() + "%'";
            strQuerry += " ORDER BY LedgerName";
            try
            {
                DaTeam obDaTeam = new DaTeam();
                formConnection = ConnectionHelper.getConnection();
                DataTable dtcust = obDaTeam.loadSelectedCustomer(formConnection, strQuerry);
                CtldgvCustomers.DataSource = dtcust;
                CtldgvCustomers.setColumnsVisible(false, "LedgerID");
                CtldgvCustomers.setColumnsReadOnly(true, "Customer");
                CtldgvCustomers.Columns["Customer"].Width= CtldgvCustomers.Width - 50;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadVoucherType()
        {
            try
            {
                DataTable dt = new DaVoucherType().getVoucherType(formConnection);

                dt.Rows.Add(0, "All");

                cboVoucherType.DataSource = dt;
                cboVoucherType.DisplayMember = "VoucherType";
                cboVoucherType.ValueMember = "VoucherTypeID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadFiscalYear()
        {
            {
                try
                {
                    cboFiscalYear.DataSource = (new DaFiscalYear()).getFiscalYearS(formConnection, 0);
                    cboFiscalYear.DisplayMember = "Period";
                    cboFiscalYear.ValueMember = "FiscalYearID";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private void loadAccountHead()
        {
            try
            {
                DaAccount obDaAcc = new DaAccount();
                DataTable dt = new DataTable();
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                dt = obDaAcc.getAccountHeads(formConnection);
                cboAccountingHead.DataSource = dt;
                cboAccountingHead.DisplayMember = "AccountTitle";
                cboAccountingHead.ValueMember = "AccountID";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void loadTeamMaster()
        {
            try
            {
                DaTeam obDaTeam = new DaTeam();

               DataTable  dtMembers = obDaTeam.loadMaster(formConnection);
                cmbTeamName.DataSource = dtMembers;
                cmbTeamName.DisplayMember = "TeamName";
                cmbTeamName.ValueMember = "TeamID";

                dtMembers.Rows.Add(0, "Independent", "Independent");
                cmbSalesTeam.DataSource = dtMembers;
                cmbSalesTeam.DisplayMember = "TeamName";
                cmbSalesTeam.ValueMember = "TeamID";
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }

        private void loadMembers(int TeamName)
        {
            DaTeam obDaTeam = new DaTeam();
           
            try
            {
                DataTable dtMembers = obDaTeam.loadDetail(formConnection, TeamName);
                cmbMember.DataSource = dtMembers;
                cmbMember.DisplayMember = "MemberName";
                cmbMember.ValueMember = "MemberID";

                cmbTeamMember.DataSource = dtMembers;
                cmbTeamMember.DisplayMember = "MemberName";
                cmbTeamMember.ValueMember = "MemberID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmReportParameter_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }



        private void cboGroupName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboGroupName.SelectedValue == null || cboGroupName.SelectedValue.GetType() == typeof(DataRowView)) return;
                if ((int)cboGroupName.SelectedValue == 0 && rbSalesLedger.Checked == true)
                {
                    cboItem.Enabled = false;
                    cboItem.SelectedValue = 0;
                }
                else
                {
                    cboItem.Enabled = true;
                    int GroupID = Convert.ToInt32(cboGroupName.SelectedValue == DBNull.Value ? 0 : cboGroupName.SelectedValue);
                    cboItem.DataSource = new DAChartsOfItem().GetItems(GroupID, "", formConnection);
                    cboItem.DisplayMember = "ItemName";
                    cboItem.ValueMember = "ItemID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void txtComInvNo_DoubleClick(object sender, EventArgs e)
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
                    txtComInvNo.Text = objComDocs.ComInvoiceNo;
                    txtComInvNo.Tag = objComDocs.ComInvoiceID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPINo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                frmSearchPI frmobj = new frmSearchPI("all",0);
                frmobj.ShowDialog();
                if (frmobj == null) return;
                int piID = frmobj.PIMasterID;

                PI_Master pi = new DaPI().GetPI_Master(piID, formConnection);
                if (pi == null) return;
                txtPINo.Text = pi.PINO;
                txtPINo.Tag = pi.PIMID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void cmbTeamName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox cmb = (ComboBox)sender;
                if (cmb.SelectedValue == null || cmb.SelectedValue.GetType() == typeof(DataRowView)) return;

                cmbTeamMember.Enabled = ((int)cmb.SelectedValue > 0 && chkSalesTeam.Checked);
                if ((int)cmb.SelectedValue == 0)
                    return;
                loadMembers((int)cmb.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkTeam_CheckedChanged(object sender, EventArgs e)
        {
            cmbTeamName.Enabled = cmbMember.Enabled = chkTeam.Checked;
        }

        private void cboLCStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            dtpDate.Enabled = (cboLCStatus.SelectedIndex == 3 || cboLCStatus.SelectedIndex == 6 || cboLCStatus.SelectedIndex == 7);

            switch (cboLCStatus.SelectedIndex)
            {
                case 0: cboLCStatus.Tag = "inhand"; break;
                case 1: cboLCStatus.Tag = "docsend"; break;
                case 2: cboLCStatus.Tag = "sendtobank"; break;
                case 3: cboLCStatus.Tag = "payment"; break;
                case 4: cboLCStatus.Tag = "inhand"; break;
                case 5: cboLCStatus.Tag = "negotiation"; break;
                case 6: cboLCStatus.Tag = "paymentnextmonth"; break;
                case 7: cboLCStatus.Tag = "expired"; break;
                case 8: cboLCStatus.Tag = "ALL"; break;
                default: cboLCStatus.Tag = null; break;
            }
        }

        private void txtLCNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                frmSearchLC objfrm = new frmSearchLC();
                objfrm.ShowDialog();
               int LCmID = objfrm.LCID;
                if (LCmID <= 0) return;
                DaLC objdalc = new DaLC();

                LC_Master objlcmaster = objdalc.GetLC_Master(LCmID, formConnection);
                if (objlcmaster == null) return;
                txtLCNo.Tag = objlcmaster;
                txtLCNo.Text = objlcmaster.LCNo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtReqNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ReqMaster obReqMaster = new ReqMaster();
                frmFindRequisition obReq = new frmFindRequisition();
                obReq.ShowDialog();
                obReqMaster = obReq.obReqMaster;
                if (obReqMaster == null) return;
                txtReqNo.Text = obReqMaster.ReqNo;
                txtReqNo.Tag = obReqMaster;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSalesInvNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                frmFindInvoice obfrmFindInvoice = new frmFindInvoice();
                obfrmFindInvoice.ShowDialog();
                Sales_Invoice obSales_Invoice = new Sales_Invoice();
                obSales_Invoice = obfrmFindInvoice.obInvoice;
                if (obSales_Invoice == null) return;

               
                txtSalesInvNo.Text = obSales_Invoice.InvoiceNo;
                txtSalesInvNo.Tag = obSales_Invoice.InvoiceID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void llblAssetSchdl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmAssetSchedule().ShowDialog();
        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (lblCustomerSupplier.Text.Trim() == "Customer")
                    {
                        Ledgers objCustomer;
                        int CustomerID = 0;
                        string CustomerName = "";
                        frmCustomer obfrmCustomer = new frmCustomer();
                        obfrmCustomer.ShowDialog();
                        objCustomer = obfrmCustomer.ReturnCustomerID();
                        if (objCustomer == null) return;
                        CustomerID = objCustomer.LedgerID;
                        CustomerName = objCustomer.LedgerName;
                        txtCustomerSupplier.Text = CustomerName;
                        txtCustomerSupplier.Tag = objCustomer;
                        //SelectNextControl((Control)sender, true, true, true, true);
                    }
                    else
                    {
                        frmSupplierSearch frm = new frmSupplierSearch();

                        frm.ShowDialog();
                       Ledgers Supplier = frm.SelectedSupplier;
                       if (Supplier == null)
                           return;
                       else
                       {

                           txtCustomerSupplier.Text = Supplier.LedgerName;
                           txtCustomerSupplier.Tag = Supplier;
                       }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lblCustomerSupplier.Text.Trim() == "Customer")
                {
                    Ledgers objCustomer;
                    int CustomerID = 0;
                    string CustomerName = "";
                    frmCustomer obfrmCustomer = new frmCustomer();
                    obfrmCustomer.ShowDialog();
                    objCustomer = obfrmCustomer.ReturnCustomerID();
                    if (objCustomer == null) return;
                    CustomerID = objCustomer.LedgerID;
                    CustomerName = objCustomer.LedgerName;
                    txtCustomerSupplier.Text = CustomerName;
                    txtCustomerSupplier.Tag = objCustomer;
                    //SelectNextControl((Control)sender, true, true, true, true);
                }
                else
                {
                    frmSupplierSearch frm = new frmSupplierSearch();

                    frm.ShowDialog();
                    Ledgers Supplier = frm.SelectedSupplier;
                    if (Supplier == null)
                        return;
                    else
                    {

                        txtCustomerSupplier.Text = Supplier.LedgerName;
                        txtCustomerSupplier.Tag = Supplier;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbLCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbLCType.SelectedIndex)
            {
                case 0:
                case 2:
                    lblCustomerSupplier.Text = "Customer"; break;
                case 1:
                case 3:
                    lblCustomerSupplier.Text = "Supplier"; break;
            };
        }

        private void chkItemGroup_CheckedChanged(object sender, EventArgs e)
        {
            cboGroupName.Enabled = chkItemGroup.Checked;
        }

        private void chkItem_CheckedChanged(object sender, EventArgs e)
        {
            cboItem.Enabled = chkItem.Checked;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                loadSelectedCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkSalesTeam_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cmbSalesTeam.Enabled = chkSalesTeam.Checked;
                cmbTeamMember.Enabled = (chkSalesTeam.Checked && (int)cmbSalesTeam.SelectedValue > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Sales Team Created");
            }
        }

        private void chkCust_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomerName.Enabled = chkCust.Checked;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int i, nR;
                nR = CtldgvCustomers.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    CtldgvCustomers[Coltick.Name, i].Value = chkAll.Checked?1:0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkLCNew_CheckedChanged(object sender, EventArgs e)
        {
            txtLCNew.Enabled = chkLCNew.Checked;
        }

        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomerSupplier.Enabled = chkCustomer.Checked;
        }

        private void chkOrderNo_CheckedChanged(object sender, EventArgs e)
        {
            txtOrderNo.Enabled = chkOrderNo.Checked;
        }

        private void txtLCNew_Enter(object sender, EventArgs e)
        {
            try
            {
                frmSearchLC objfrm = new frmSearchLC();
                objfrm.ShowDialog();
                int LCmID = objfrm.LCID;
                if (LCmID <= 0) return;
                DaLC objdalc = new DaLC();

                LC_Master objlcmaster = objdalc.GetLC_Master(LCmID, formConnection);
                if (objlcmaster == null) return;
                txtLCNew.Tag = objlcmaster;
                txtLCNew.Text = objlcmaster.LCNo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtOrderNo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                
                frmFind obfrmFind = new frmFind();
                obfrmFind.ShowDialog();
                Order_Master obOrderNo;
                obOrderNo = obfrmFind.obOrderNo;
                
                if (obOrderNo == null) return;
                txtOrderNo.Text = obOrderNo.OrderNo.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




    }
}
