using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Reports;
using CrystalDecisions.CrystalReports.Engine;
using Accounting.Utility;

namespace Accounting.UI
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }
        public void ShowDialog(object CrystalReport)
        {
            this._ReportSource = CrystalReport;
            this.ShowDialog();
        }
        public void ShowDialog(object CrystalReport,bool showGroupTree)
        {
            this._ReportSource = CrystalReport;
            crvCommon.DisplayGroupTree= showGroupTree;
            this.ShowDialog();
        }
      
        #region Variable
        private object _ReportSource = null;
        CrystalReportHelper oCrsHelper = new CrystalReportHelper();
        #endregion
        private void crvCommon_Load(object sender, EventArgs e)
        {
            try
            {
                crvCommon.ReportSource = _ReportSource;
                ReportClass rpt = (ReportClass)_ReportSource;
                oCrsHelper.setDBConnectionForReport(rpt.Database.Tables);
                int i, nS;
                nS = rpt.Subreports.Count;
                for (i = 0; i < nS; i++)
                {
                    oCrsHelper.setDBConnectionForReport(rpt.Subreports[i].Database.Tables);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
