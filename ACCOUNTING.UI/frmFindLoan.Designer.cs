namespace Accounting.UI
{
    partial class frmFindLoan
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
            this.rbtnLoanNo = new System.Windows.Forms.RadioButton();
            this.rbtnLCNO = new System.Windows.Forms.RadioButton();
            this.txtLCNO = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtLoanNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DTPend = new System.Windows.Forms.DateTimePicker();
            this.DTPstDate = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ctlDGVLoan = new Accounting.Controls.ctlDaraGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVLoan)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbtnLoanNo);
            this.groupBox1.Controls.Add(this.rbtnLCNO);
            this.groupBox1.Controls.Add(this.txtLCNO);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtLoanNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DTPend);
            this.groupBox1.Controls.Add(this.DTPstDate);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // rbtnLoanNo
            // 
            this.rbtnLoanNo.AutoSize = true;
            this.rbtnLoanNo.Location = new System.Drawing.Point(6, 69);
            this.rbtnLoanNo.Name = "rbtnLoanNo";
            this.rbtnLoanNo.Size = new System.Drawing.Size(66, 17);
            this.rbtnLoanNo.TabIndex = 8;
            this.rbtnLoanNo.TabStop = true;
            this.rbtnLoanNo.Text = "Loan No";
            this.rbtnLoanNo.UseVisualStyleBackColor = true;
            // 
            // rbtnLCNO
            // 
            this.rbtnLCNO.AutoSize = true;
            this.rbtnLCNO.Checked = true;
            this.rbtnLCNO.Location = new System.Drawing.Point(6, 44);
            this.rbtnLCNO.Name = "rbtnLCNO";
            this.rbtnLCNO.Size = new System.Drawing.Size(57, 17);
            this.rbtnLCNO.TabIndex = 8;
            this.rbtnLCNO.TabStop = true;
            this.rbtnLCNO.Text = "LC NO";
            this.rbtnLCNO.UseVisualStyleBackColor = true;
            // 
            // txtLCNO
            // 
            this.txtLCNO.Location = new System.Drawing.Point(78, 43);
            this.txtLCNO.Name = "txtLCNO";
            this.txtLCNO.Size = new System.Drawing.Size(246, 20);
            this.txtLCNO.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Location = new System.Drawing.Point(344, 55);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(39, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = ">>";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.Location = new System.Drawing.Point(78, 69);
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(246, 20);
            this.txtLoanNo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "To";
            // 
            // DTPend
            // 
            this.DTPend.CustomFormat = "dd/MM/yyyy";
            this.DTPend.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPend.Location = new System.Drawing.Point(227, 14);
            this.DTPend.Name = "DTPend";
            this.DTPend.Size = new System.Drawing.Size(156, 20);
            this.DTPend.TabIndex = 0;
            // 
            // DTPstDate
            // 
            this.DTPstDate.CustomFormat = "dd/MM/yyyy";
            this.DTPstDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPstDate.Location = new System.Drawing.Point(55, 14);
            this.DTPstDate.Name = "DTPstDate";
            this.DTPstDate.Size = new System.Drawing.Size(148, 20);
            this.DTPstDate.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(118, 489);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(68, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(192, 489);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ctlDGVLoan
            // 
            this.ctlDGVLoan.AllowUserToAddRows = false;
            this.ctlDGVLoan.AllowUserToDeleteRows = false;
            this.ctlDGVLoan.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctlDGVLoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDGVLoan.ContextMenuFields = null;
            this.ctlDGVLoan.isEnterKeyLikeTabKey = true;
            this.ctlDGVLoan.isExcelSheetCell = false;
            this.ctlDGVLoan.IsSortable = false;
            this.ctlDGVLoan.Location = new System.Drawing.Point(7, 115);
            this.ctlDGVLoan.Name = "ctlDGVLoan";
            this.ctlDGVLoan.ReadOnly = true;
            this.ctlDGVLoan.RowHeadersVisible = false;
            this.ctlDGVLoan.RowPointer = 0;
            this.ctlDGVLoan.ShowDateTimePicker = true;
            this.ctlDGVLoan.Size = new System.Drawing.Size(374, 368);
            this.ctlDGVLoan.TabIndex = 1;
            this.ctlDGVLoan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlDGVLoan_CellDoubleClick);
            // 
            // frmFindLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 514);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ctlDGVLoan);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindLoan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find Loan";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmFindLoan_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVLoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTPend;
        private System.Windows.Forms.DateTimePicker DTPstDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtLoanNo;
        private Accounting.Controls.ctlDaraGridView ctlDGVLoan;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtLCNO;
        private System.Windows.Forms.RadioButton rbtnLoanNo;
        private System.Windows.Forms.RadioButton rbtnLCNO;
    }
}