namespace Accounting.UI
{
    partial class frmStartFiscalYear
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
            this.pBalanceSheet = new System.Windows.Forms.Panel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFYEndDate = new System.Windows.Forms.DateTimePicker();
            this.ctlNumWorkInProcess = new Accounting.Controls.ctlNum();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctlNumDivamt = new Accounting.Controls.ctlNum();
            this.ctlNumFinish = new Accounting.Controls.ctlNum();
            this.ctlNumRaw = new Accounting.Controls.ctlNum();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.llblAssetSchdl = new System.Windows.Forms.LinkLabel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pBalanceSheet.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBalanceSheet
            // 
            this.pBalanceSheet.BackColor = System.Drawing.Color.Transparent;
            this.pBalanceSheet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBalanceSheet.Controls.Add(this.txtTitle);
            this.pBalanceSheet.Controls.Add(this.label3);
            this.pBalanceSheet.Controls.Add(this.dtpFYEndDate);
            this.pBalanceSheet.Controls.Add(this.ctlNumWorkInProcess);
            this.pBalanceSheet.Controls.Add(this.label1);
            this.pBalanceSheet.Controls.Add(this.label2);
            this.pBalanceSheet.Controls.Add(this.ctlNumDivamt);
            this.pBalanceSheet.Controls.Add(this.ctlNumFinish);
            this.pBalanceSheet.Controls.Add(this.ctlNumRaw);
            this.pBalanceSheet.Controls.Add(this.label22);
            this.pBalanceSheet.Controls.Add(this.label21);
            this.pBalanceSheet.Controls.Add(this.label20);
            this.pBalanceSheet.Location = new System.Drawing.Point(3, 4);
            this.pBalanceSheet.Name = "pBalanceSheet";
            this.pBalanceSheet.Size = new System.Drawing.Size(372, 142);
            this.pBalanceSheet.TabIndex = 0;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(165, 107);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 20);
            this.txtTitle.TabIndex = 38;
            this.txtTitle.Text = "FY";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "Enter a title for new fiscal year";
            // 
            // dtpFYEndDate
            // 
            this.dtpFYEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFYEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFYEndDate.Location = new System.Drawing.Point(233, 82);
            this.dtpFYEndDate.Name = "dtpFYEndDate";
            this.dtpFYEndDate.Size = new System.Drawing.Size(133, 20);
            this.dtpFYEndDate.TabIndex = 4;
            // 
            // ctlNumWorkInProcess
            // 
            this.ctlNumWorkInProcess.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumWorkInProcess.Location = new System.Drawing.Point(232, 41);
            this.ctlNumWorkInProcess.Name = "ctlNumWorkInProcess";
            this.ctlNumWorkInProcess.ReadOnly = false;
            this.ctlNumWorkInProcess.Size = new System.Drawing.Size(133, 20);
            this.ctlNumWorkInProcess.TabIndex = 2;
            this.ctlNumWorkInProcess.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumWorkInProcess.Value = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Enter Ending Date of This Fiscal Year";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Work In Progress ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctlNumDivamt
            // 
            this.ctlNumDivamt.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumDivamt.Location = new System.Drawing.Point(232, 60);
            this.ctlNumDivamt.Name = "ctlNumDivamt";
            this.ctlNumDivamt.ReadOnly = false;
            this.ctlNumDivamt.Size = new System.Drawing.Size(133, 20);
            this.ctlNumDivamt.TabIndex = 3;
            this.ctlNumDivamt.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumDivamt.Value = 0;
            // 
            // ctlNumFinish
            // 
            this.ctlNumFinish.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumFinish.Location = new System.Drawing.Point(232, 22);
            this.ctlNumFinish.Name = "ctlNumFinish";
            this.ctlNumFinish.ReadOnly = false;
            this.ctlNumFinish.Size = new System.Drawing.Size(133, 20);
            this.ctlNumFinish.TabIndex = 1;
            this.ctlNumFinish.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumFinish.Value = 0;
            // 
            // ctlNumRaw
            // 
            this.ctlNumRaw.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumRaw.Location = new System.Drawing.Point(232, 3);
            this.ctlNumRaw.Name = "ctlNumRaw";
            this.ctlNumRaw.ReadOnly = false;
            this.ctlNumRaw.Size = new System.Drawing.Size(133, 20);
            this.ctlNumRaw.TabIndex = 0;
            this.ctlNumRaw.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumRaw.Value = 0;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(7, 61);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(177, 19);
            this.label22.TabIndex = 2;
            this.label22.Text = "Dividen Amount";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(7, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(177, 19);
            this.label21.TabIndex = 2;
            this.label21.Text = "Closing Stock of Finished Goods";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(7, 4);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(152, 19);
            this.label20.TabIndex = 2;
            this.label20.Text = "Closing Stock of Raw Material";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // llblAssetSchdl
            // 
            this.llblAssetSchdl.Location = new System.Drawing.Point(0, 157);
            this.llblAssetSchdl.Name = "llblAssetSchdl";
            this.llblAssetSchdl.Size = new System.Drawing.Size(108, 20);
            this.llblAssetSchdl.TabIndex = 4;
            this.llblAssetSchdl.TabStop = true;
            this.llblAssetSchdl.Text = "Asset Schedule Calculation";
            this.llblAssetSchdl.Visible = false;
            this.llblAssetSchdl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblAssetSchdl_LinkClicked);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(114, 152);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(195, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmStartFiscalYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 176);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pBalanceSheet);
            this.Controls.Add(this.llblAssetSchdl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStartFiscalYear";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Start New Fiscal Year";
            this.Load += new System.EventHandler(this.frmStartFiscalYear_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmStartFiscalYear_Paint);
            this.pBalanceSheet.ResumeLayout(false);
            this.pBalanceSheet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBalanceSheet;
        private System.Windows.Forms.LinkLabel llblAssetSchdl;
        private Accounting.Controls.ctlNum ctlNumDivamt;
        private Accounting.Controls.ctlNum ctlNumFinish;
        private Accounting.Controls.ctlNum ctlNumRaw;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label1;
        private Accounting.Controls.ctlNum ctlNumWorkInProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFYEndDate;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label3;
    }
}