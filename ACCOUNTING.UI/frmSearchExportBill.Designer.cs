namespace Accounting.UI
{
    partial class frmSearchExportBill
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.chkBillNo = new System.Windows.Forms.CheckBox();
            this.chkBillDate = new System.Windows.Forms.CheckBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ctldgvExBill = new Accounting.Controls.ctlDaraGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvExBill)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtBillNo);
            this.groupBox1.Controls.Add(this.chkBillNo);
            this.groupBox1.Controls.Add(this.chkBillDate);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // txtBillNo
            // 
            this.txtBillNo.Location = new System.Drawing.Point(108, 42);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(239, 20);
            this.txtBillNo.TabIndex = 3;
            this.txtBillNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBillNo_KeyDown);
            // 
            // chkBillNo
            // 
            this.chkBillNo.AutoSize = true;
            this.chkBillNo.Checked = true;
            this.chkBillNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBillNo.Location = new System.Drawing.Point(15, 45);
            this.chkBillNo.Name = "chkBillNo";
            this.chkBillNo.Size = new System.Drawing.Size(82, 17);
            this.chkBillNo.TabIndex = 2;
            this.chkBillNo.Text = "Bill No. Like";
            this.chkBillNo.UseVisualStyleBackColor = true;
            this.chkBillNo.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            this.chkBillNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkBillNo_KeyDown);
            // 
            // chkBillDate
            // 
            this.chkBillDate.AutoSize = true;
            this.chkBillDate.Checked = true;
            this.chkBillDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBillDate.Location = new System.Drawing.Point(15, 19);
            this.chkBillDate.Name = "chkBillDate";
            this.chkBillDate.Size = new System.Drawing.Size(91, 17);
            this.chkBillDate.TabIndex = 10;
            this.chkBillDate.Text = "Bill Date From";
            this.chkBillDate.UseVisualStyleBackColor = true;
            this.chkBillDate.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(353, 39);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(36, 24);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = ">>";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            this.btnShow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnShow_KeyDown);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(272, 16);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(117, 20);
            this.dtpEnd.TabIndex = 1;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            this.dtpEnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpEnd_KeyDown);
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "dd/MM/yyyy";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(108, 16);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(116, 20);
            this.dtpStart.TabIndex = 0;
            this.dtpStart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpStart_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(230, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "To";
            // 
            // ctldgvExBill
            // 
            this.ctldgvExBill.AllowUserToAddRows = false;
            this.ctldgvExBill.AllowUserToDeleteRows = false;
            this.ctldgvExBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctldgvExBill.ContextMenuFields = null;
            this.ctldgvExBill.isEnterKeyLikeTabKey = true;
            this.ctldgvExBill.isExcelSheetCell = false;
            this.ctldgvExBill.IsSortable = false;
            this.ctldgvExBill.Location = new System.Drawing.Point(6, 82);
            this.ctldgvExBill.MultiSelect = false;
            this.ctldgvExBill.Name = "ctldgvExBill";
            this.ctldgvExBill.ReadOnly = true;
            this.ctldgvExBill.RowHeadersVisible = false;
            this.ctldgvExBill.RowPointer = 0;
            this.ctldgvExBill.RowTemplate.ReadOnly = true;
            this.ctldgvExBill.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctldgvExBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctldgvExBill.ShowDateTimePicker = false;
            this.ctldgvExBill.Size = new System.Drawing.Size(398, 404);
            this.ctldgvExBill.TabIndex = 5;
            this.ctldgvExBill.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvExBill_CellDoubleClick);
            this.ctldgvExBill.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctldgvExBill_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(129, 492);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            this.btnOk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnOk_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(210, 492);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyDown);
            // 
            // frmSearchExportBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 518);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ctldgvExBill);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchExportBill";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Export Bill";
            this.Load += new System.EventHandler(this.frmSearchExportBill_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSearchExportBill_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvExBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.TextBox txtBillNo;
        private Accounting.Controls.ctlDaraGridView ctldgvExBill;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkBillDate;
        private System.Windows.Forms.CheckBox chkBillNo;
    }
}