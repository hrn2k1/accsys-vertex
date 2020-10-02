namespace Accounting.UI
{
    partial class frmReportViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crvCommon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCommon
            // 
            this.crvCommon.ActiveViewIndex = -1;
            this.crvCommon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCommon.Location = new System.Drawing.Point(0, 0);
            this.crvCommon.Name = "crvCommon";
            this.crvCommon.SelectionFormula = "";
            this.crvCommon.ShowRefreshButton = false;
            this.crvCommon.Size = new System.Drawing.Size(624, 539);
            this.crvCommon.TabIndex = 0;
            this.crvCommon.ViewTimeSelectionFormula = "";
            this.crvCommon.Load += new System.EventHandler(this.crvCommon_Load);
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 539);
            this.Controls.Add(this.crvCommon);
            this.Name = "frmReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCommon;
    }
}