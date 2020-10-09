using Accounting.Reports;
using Accounting.Utility;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Accounting.Web
{
    public partial class frmReport : System.Web.UI.Page
    {
        ParameterValues pvc = new ParameterValues();
        ParameterDiscreteValue pdv = new ParameterDiscreteValue();
        CrystalReportHelper oCrsHelper = new CrystalReportHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(-7));
                txtToDate.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                ShowParameters();
            }

            ShowReport();

        }
        private void ShowParameters()
        {
            var reportName = Request["rpt"];
            List<WebControl> controls = null;
            switch (reportName)
            {
                case "ledgerbook":
                    controls = new List<WebControl>() { lblAccount, ddlAccount, lblDateFrom, txtFromDate, lblDateTo, txtToDate };
                    break;
                case "journalbook":
                    controls = new List<WebControl>() { lblDateFrom, txtFromDate, lblDateTo, txtToDate };
                    break;
            }
            if(controls != null)
            {
                foreach (var control in controls)
                {
                    control.Visible = true;
                }
            }
        }
        private void ShowReport()
        {
            try
            {
                var reportName = Request["rpt"];
                ReportClass rpt = null;
                if (reportName == "chartofaccounts")
                {
                    rpt = new rptChartsOfAccount();
                    pdv.Value = Tools.Utility.IsNull<int>(Session["CompanyId"], 0);
                    pvc.Add(pdv);
                    rpt.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                }
                else if (reportName == "ledgerbook")
                {
                    rpt = new rptLedgerBook();

                    pdv.Value = ddlAccount.SelectedValue == "" ? 0 : Convert.ToInt32(ddlAccount.SelectedValue);
                    pvc.Add(pdv);
                    rpt.DataDefinition.ParameterFields["@AccountID"].ApplyCurrentValues(pvc);

                    pdv.Value = Tools.Utility.GetDateValue(txtFromDate.Text.Trim());
                    pvc.Add(pdv);
                    rpt.DataDefinition.ParameterFields["@UpToDate"].ApplyCurrentValues(pvc);
                    pdv.Value = Tools.Utility.GetDateValue(txtFromDate.Text.Trim());
                    pvc.Add(pdv);
                    rpt.DataDefinition.ParameterFields["@startDate"].ApplyCurrentValues(pvc);

                    pdv.Value = Tools.Utility.GetDateValue(txtToDate.Text.Trim());
                    pvc.Add(pdv);
                    rpt.DataDefinition.ParameterFields["@endDate"].ApplyCurrentValues(pvc);

                    pdv.Value = Tools.Utility.IsNull<int>(Session["CompanyId"], 0);
                    pvc.Add(pdv);
                    rpt.DataDefinition.ParameterFields["@CompanyID"].ApplyCurrentValues(pvc);
                }
                else if (reportName == "journalbook")
                {

                }
                if (rpt != null)
                {
                    oCrsHelper.setDBConnectionForReport(rpt.Database.Tables);
                    int i, nS;
                    nS = rpt.Subreports.Count;
                    for (i = 0; i < nS; i++)
                    {
                        oCrsHelper.setDBConnectionForReport(rpt.Subreports[i].Database.Tables);
                    }
                    CrystalReportViewer1.ReportSource = rpt;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {

        }
    }
}