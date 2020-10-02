namespace Accounting.UI
{
    partial class frmVoucherRegister
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboVoucherType = new System.Windows.Forms.ComboBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lvVoucher = new System.Windows.Forms.ListView();
            this.colVNo = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colVAmt = new System.Windows.Forms.ColumnHeader();
            this.colAccount = new System.Windows.Forms.ColumnHeader();
            this.colDebit = new System.Windows.Forms.ColumnHeader();
            this.colCredit = new System.Windows.Forms.ColumnHeader();
            this.colModule = new System.Windows.Forms.ColumnHeader();
            this.chkShowLine = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cboVoucherType);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Location = new System.Drawing.Point(627, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(66, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboVoucherType
            // 
            this.cboVoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVoucherType.FormattingEnabled = true;
            this.cboVoucherType.Location = new System.Drawing.Point(470, 18);
            this.cboVoucherType.Name = "cboVoucherType";
            this.cboVoucherType.Size = new System.Drawing.Size(151, 21);
            this.cboVoucherType.TabIndex = 2;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(245, 18);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(123, 20);
            this.dtpEndDate.TabIndex = 1;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(86, 18);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(123, 20);
            this.dtpStartDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(215, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "To";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(375, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Voucher Type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dated from";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(631, 439);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "&Update";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(712, 439);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(540, 438);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(85, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "&Print Voucher";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lvVoucher
            // 
            this.lvVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvVoucher.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVNo,
            this.colDate,
            this.colVAmt,
            this.colAccount,
            this.colDebit,
            this.colCredit,
            this.colModule});
            this.lvVoucher.FullRowSelect = true;
            this.lvVoucher.GridLines = true;
            this.lvVoucher.Location = new System.Drawing.Point(6, 59);
            this.lvVoucher.MultiSelect = false;
            this.lvVoucher.Name = "lvVoucher";
            this.lvVoucher.Size = new System.Drawing.Size(771, 373);
            this.lvVoucher.TabIndex = 6;
            this.lvVoucher.UseCompatibleStateImageBehavior = false;
            this.lvVoucher.View = System.Windows.Forms.View.Details;
            this.lvVoucher.DoubleClick += new System.EventHandler(this.lvVoucher_DoubleClick);
            // 
            // colVNo
            // 
            this.colVNo.Text = "Voucher No.";
            this.colVNo.Width = 88;
            // 
            // colDate
            // 
            this.colDate.Text = "Voucher Date";
            this.colDate.Width = 86;
            // 
            // colVAmt
            // 
            this.colVAmt.Text = "Amount";
            this.colVAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colVAmt.Width = 93;
            // 
            // colAccount
            // 
            this.colAccount.Text = "Account";
            this.colAccount.Width = 226;
            // 
            // colDebit
            // 
            this.colDebit.Text = "Debit";
            this.colDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDebit.Width = 93;
            // 
            // colCredit
            // 
            this.colCredit.Text = "Credit";
            this.colCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCredit.Width = 107;
            // 
            // colModule
            // 
            this.colModule.Text = "Module";
            this.colModule.Width = 100;
            // 
            // chkShowLine
            // 
            this.chkShowLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowLine.AutoSize = true;
            this.chkShowLine.BackColor = System.Drawing.Color.Transparent;
            this.chkShowLine.Checked = true;
            this.chkShowLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowLine.Location = new System.Drawing.Point(6, 440);
            this.chkShowLine.Name = "chkShowLine";
            this.chkShowLine.Size = new System.Drawing.Size(98, 17);
            this.chkShowLine.TabIndex = 7;
            this.chkShowLine.Text = "Show Grid Line";
            this.chkShowLine.UseVisualStyleBackColor = false;
            this.chkShowLine.CheckedChanged += new System.EventHandler(this.chkShowLine_CheckedChanged);
            // 
            // frmVoucherRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 463);
            this.Controls.Add(this.chkShowLine);
            this.Controls.Add(this.lvVoucher);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmVoucherRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Voucher Register";
            this.Load += new System.EventHandler(this.frmVoucherRegister_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmVoucherRegister_Paint);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboVoucherType;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ListView lvVoucher;
        private System.Windows.Forms.ColumnHeader colVNo;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colVAmt;
        private System.Windows.Forms.ColumnHeader colAccount;
        private System.Windows.Forms.ColumnHeader colDebit;
        private System.Windows.Forms.ColumnHeader colCredit;
        private System.Windows.Forms.CheckBox chkShowLine;
        private System.Windows.Forms.ColumnHeader colModule;
    }
}