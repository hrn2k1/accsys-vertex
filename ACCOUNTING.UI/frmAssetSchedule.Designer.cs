namespace Accounting.UI
{
    partial class frmAssetSchedule
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.chkPost = new System.Windows.Forms.CheckBox();
            this.ctlNumDep = new Accounting.Controls.ctlNum();
            this.dgvAsset = new Accounting.Controls.ctlDaraGridView();
            this.colAssetSchdlID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAssetAccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAssetAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOpBal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAddition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalBal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOpDepr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDepr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalDepr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCloseBal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFiscalYear = new System.Windows.Forms.Label();
            this.cboFiscalYear = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.ctlDaraGridView1 = new Accounting.Controls.ctlDaraGridView();
            this.pnlAS = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDaraGridView1)).BeginInit();
            this.pnlAS.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(746, 476);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(628, 476);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(56, 23);
            this.btnReport.TabIndex = 1;
            this.btnReport.Text = "&Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(564, 477);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(61, 23);
            this.btnCalc.TabIndex = 1;
            this.btnCalc.Text = "Ca&lculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 480);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total Depriciation";
            // 
            // dtpdate
            // 
            this.dtpdate.CustomFormat = "dd/MM/yyyy";
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdate.Location = new System.Drawing.Point(79, 476);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(102, 20);
            this.dtpdate.TabIndex = 4;
            // 
            // chkPost
            // 
            this.chkPost.AutoSize = true;
            this.chkPost.Location = new System.Drawing.Point(429, 479);
            this.chkPost.Name = "chkPost";
            this.chkPost.Size = new System.Drawing.Size(120, 17);
            this.chkPost.TabIndex = 6;
            this.chkPost.Text = " Post after calculate";
            this.chkPost.UseVisualStyleBackColor = true;
            // 
            // ctlNumDep
            // 
            this.ctlNumDep.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumDep.Location = new System.Drawing.Point(302, 476);
            this.ctlNumDep.Name = "ctlNumDep";
            this.ctlNumDep.ReadOnly = false;
            this.ctlNumDep.Size = new System.Drawing.Size(111, 20);
            this.ctlNumDep.TabIndex = 5;
            this.ctlNumDep.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumDep.Value = 0;
            // 
            // dgvAsset
            // 
            this.dgvAsset.AllowUserToAddRows = false;
            this.dgvAsset.AllowUserToDeleteRows = false;
            this.dgvAsset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsset.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAssetSchdlID,
            this.ColAssetAccountID,
            this.ColAssetAccount,
            this.ColOpBal,
            this.ColAddition,
            this.ColTotalBal,
            this.ColRate,
            this.ColOpDepr,
            this.ColDepr,
            this.ColTotalDepr,
            this.ColCloseBal});
            this.dgvAsset.ContextMenuFields = null;
            this.dgvAsset.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAsset.isEnterKeyLikeTabKey = true;
            this.dgvAsset.isExcelSheetCell = false;
            this.dgvAsset.IsSortable = false;
            this.dgvAsset.Location = new System.Drawing.Point(12, 32);
            this.dgvAsset.Name = "dgvAsset";
            this.dgvAsset.RowHeadersWidth = 25;
            this.dgvAsset.RowPointer = 0;
            this.dgvAsset.ShowDateTimePicker = true;
            this.dgvAsset.Size = new System.Drawing.Size(789, 436);
            this.dgvAsset.TabIndex = 0;
            this.dgvAsset.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvAsset_EditingControlShowing);
            this.dgvAsset.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsset_CellContentClick);
            // 
            // colAssetSchdlID
            // 
            this.colAssetSchdlID.HeaderText = "AssetSchdlID";
            this.colAssetSchdlID.Name = "colAssetSchdlID";
            this.colAssetSchdlID.Visible = false;
            // 
            // ColAssetAccountID
            // 
            this.ColAssetAccountID.HeaderText = "AssetAccountID";
            this.ColAssetAccountID.Name = "ColAssetAccountID";
            this.ColAssetAccountID.Visible = false;
            // 
            // ColAssetAccount
            // 
            this.ColAssetAccount.HeaderText = "AssetAccount";
            this.ColAssetAccount.Name = "ColAssetAccount";
            this.ColAssetAccount.ReadOnly = true;
            this.ColAssetAccount.Width = 200;
            // 
            // ColOpBal
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = "0.00";
            this.ColOpBal.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColOpBal.HeaderText = "Opening Balance";
            this.ColOpBal.Name = "ColOpBal";
            this.ColOpBal.ReadOnly = true;
            this.ColOpBal.Width = 70;
            // 
            // ColAddition
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0.00";
            this.ColAddition.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColAddition.HeaderText = "Addition this year";
            this.ColAddition.Name = "ColAddition";
            this.ColAddition.ReadOnly = true;
            this.ColAddition.Width = 70;
            // 
            // ColTotalBal
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = "0.00";
            this.ColTotalBal.DefaultCellStyle = dataGridViewCellStyle11;
            this.ColTotalBal.HeaderText = "Total";
            this.ColTotalBal.Name = "ColTotalBal";
            this.ColTotalBal.ReadOnly = true;
            this.ColTotalBal.Width = 70;
            // 
            // ColRate
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = "0.00";
            this.ColRate.DefaultCellStyle = dataGridViewCellStyle12;
            this.ColRate.HeaderText = "Rate % per year";
            this.ColRate.Name = "ColRate";
            this.ColRate.Width = 70;
            // 
            // ColOpDepr
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = "0.00";
            this.ColOpDepr.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColOpDepr.HeaderText = "Opening Depreciation";
            this.ColOpDepr.Name = "ColOpDepr";
            this.ColOpDepr.Width = 70;
            // 
            // ColDepr
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = "0.00";
            this.ColDepr.DefaultCellStyle = dataGridViewCellStyle14;
            this.ColDepr.HeaderText = "Depreciation";
            this.ColDepr.Name = "ColDepr";
            this.ColDepr.Width = 70;
            // 
            // ColTotalDepr
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = "0.00";
            this.ColTotalDepr.DefaultCellStyle = dataGridViewCellStyle15;
            this.ColTotalDepr.HeaderText = "Total";
            this.ColTotalDepr.Name = "ColTotalDepr";
            this.ColTotalDepr.ReadOnly = true;
            this.ColTotalDepr.Width = 70;
            // 
            // ColCloseBal
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = "0.00";
            this.ColCloseBal.DefaultCellStyle = dataGridViewCellStyle16;
            this.ColCloseBal.HeaderText = "Closing Balance";
            this.ColCloseBal.Name = "ColCloseBal";
            this.ColCloseBal.ReadOnly = true;
            this.ColCloseBal.Width = 70;
            // 
            // lblFiscalYear
            // 
            this.lblFiscalYear.AutoSize = true;
            this.lblFiscalYear.Location = new System.Drawing.Point(17, 9);
            this.lblFiscalYear.Name = "lblFiscalYear";
            this.lblFiscalYear.Size = new System.Drawing.Size(59, 13);
            this.lblFiscalYear.TabIndex = 22;
            this.lblFiscalYear.Text = "Fiscal Year";
            // 
            // cboFiscalYear
            // 
            this.cboFiscalYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiscalYear.FormattingEnabled = true;
            this.cboFiscalYear.Items.AddRange(new object[] {
            "Islam",
            "Hindu"});
            this.cboFiscalYear.Location = new System.Drawing.Point(99, 5);
            this.cboFiscalYear.Name = "cboFiscalYear";
            this.cboFiscalYear.Size = new System.Drawing.Size(348, 21);
            this.cboFiscalYear.TabIndex = 21;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(687, 476);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(56, 23);
            this.btnFind.TabIndex = 23;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ctlDaraGridView1
            // 
            this.ctlDaraGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDaraGridView1.ContextMenuFields = null;
            this.ctlDaraGridView1.isEnterKeyLikeTabKey = true;
            this.ctlDaraGridView1.isExcelSheetCell = false;
            this.ctlDaraGridView1.IsSortable = false;
            this.ctlDaraGridView1.Location = new System.Drawing.Point(3, 5);
            this.ctlDaraGridView1.Name = "ctlDaraGridView1";
            this.ctlDaraGridView1.RowPointer = 0;
            this.ctlDaraGridView1.ShowDateTimePicker = true;
            this.ctlDaraGridView1.Size = new System.Drawing.Size(345, 282);
            this.ctlDaraGridView1.TabIndex = 24;
            // 
            // pnlAS
            // 
            this.pnlAS.Controls.Add(this.button2);
            this.pnlAS.Controls.Add(this.button1);
            this.pnlAS.Controls.Add(this.ctlDaraGridView1);
            this.pnlAS.Location = new System.Drawing.Point(451, 148);
            this.pnlAS.Name = "pnlAS";
            this.pnlAS.Size = new System.Drawing.Size(351, 320);
            this.pnlAS.TabIndex = 25;
            this.pnlAS.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(193, 291);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Ca&ncel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "&Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAssetSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 506);
            this.Controls.Add(this.pnlAS);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblFiscalYear);
            this.Controls.Add(this.cboFiscalYear);
            this.Controls.Add(this.chkPost);
            this.Controls.Add(this.ctlNumDep);
            this.Controls.Add(this.dtpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvAsset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAssetSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asset Schedule";
            this.Load += new System.EventHandler(this.frmAssetSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDaraGridView1)).EndInit();
            this.pnlAS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Accounting.Controls.ctlDaraGridView dgvAsset;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private Accounting.Controls.ctlNum ctlNumDep;
        private System.Windows.Forms.CheckBox chkPost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetSchdlID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAssetAccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAssetAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOpBal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAddition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalBal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOpDepr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDepr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalDepr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCloseBal;
        private System.Windows.Forms.Label lblFiscalYear;
        private System.Windows.Forms.ComboBox cboFiscalYear;
        private System.Windows.Forms.Button btnFind;
        private Accounting.Controls.ctlDaraGridView ctlDaraGridView1;
        private System.Windows.Forms.Panel pnlAS;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}