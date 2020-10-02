namespace Accounting.UI
{
    partial class frmLoanPayment
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoanID = new System.Windows.Forms.TextBox();
            this.txtLoanAccount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLoanAdjustID = new System.Windows.Forms.TextBox();
            this.txtPayNow = new Accounting.Controls.ctlNum();
            this.DTPPayDate = new System.Windows.Forms.DateTimePicker();
            this.dtpAcceptDate = new System.Windows.Forms.DateTimePicker();
            this.cmbPayMethod = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtPayFromAcc = new System.Windows.Forms.TextBox();
            this.txtChequeLCNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRefNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtLoanNo = new System.Windows.Forms.TextBox();
            this.txtLoanAccID = new System.Windows.Forms.TextBox();
            this.txtDueAmount = new Accounting.Controls.ctlNum();
            this.dgvLoanAdjust = new Accounting.Controls.ctlDaraGridView();
            this.ctlDGVLoan = new Accounting.Controls.ctlDaraGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanAdjust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVLoan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loan No.";
            // 
            // txtLoanID
            // 
            this.txtLoanID.Location = new System.Drawing.Point(330, 2);
            this.txtLoanID.Name = "txtLoanID";
            this.txtLoanID.Size = new System.Drawing.Size(15, 20);
            this.txtLoanID.TabIndex = 0;
            this.txtLoanID.Text = "0";
            this.txtLoanID.Visible = false;
            this.txtLoanID.TextChanged += new System.EventHandler(this.txtLoanID_TextChanged);
            // 
            // txtLoanAccount
            // 
            this.txtLoanAccount.Location = new System.Drawing.Point(446, 2);
            this.txtLoanAccount.Name = "txtLoanAccount";
            this.txtLoanAccount.ReadOnly = true;
            this.txtLoanAccount.Size = new System.Drawing.Size(327, 20);
            this.txtLoanAccount.TabIndex = 1;
            this.txtLoanAccount.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(369, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loan Account";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(5, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total Due Amount";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtLoanAdjustID);
            this.groupBox1.Controls.Add(this.txtPayNow);
            this.groupBox1.Controls.Add(this.DTPPayDate);
            this.groupBox1.Controls.Add(this.dtpAcceptDate);
            this.groupBox1.Controls.Add(this.cmbPayMethod);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.txtPayFromAcc);
            this.groupBox1.Controls.Add(this.txtChequeLCNo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblRefNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 208);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtLoanAdjustID
            // 
            this.txtLoanAdjustID.Location = new System.Drawing.Point(278, 13);
            this.txtLoanAdjustID.Name = "txtLoanAdjustID";
            this.txtLoanAdjustID.Size = new System.Drawing.Size(29, 20);
            this.txtLoanAdjustID.TabIndex = 6;
            this.txtLoanAdjustID.Text = "0";
            this.txtLoanAdjustID.Visible = false;
            // 
            // txtPayNow
            // 
            this.txtPayNow.BackgroudColor = System.Drawing.SystemColors.Window;
            this.txtPayNow.Location = new System.Drawing.Point(96, 32);
            this.txtPayNow.Name = "txtPayNow";
            this.txtPayNow.ReadOnly = false;
            this.txtPayNow.Size = new System.Drawing.Size(163, 20);
            this.txtPayNow.TabIndex = 1;
            this.txtPayNow.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtPayNow.Value = 0;
            // 
            // DTPPayDate
            // 
            this.DTPPayDate.CustomFormat = "dd/MM/yyyy";
            this.DTPPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPPayDate.Location = new System.Drawing.Point(96, 121);
            this.DTPPayDate.Name = "DTPPayDate";
            this.DTPPayDate.Size = new System.Drawing.Size(163, 20);
            this.DTPPayDate.TabIndex = 5;
            this.DTPPayDate.ValueChanged += new System.EventHandler(this.DTPPayDate_ValueChanged);
            this.DTPPayDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            // 
            // dtpAcceptDate
            // 
            this.dtpAcceptDate.CustomFormat = "dd/MM/yyyy";
            this.dtpAcceptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAcceptDate.Location = new System.Drawing.Point(96, 77);
            this.dtpAcceptDate.Name = "dtpAcceptDate";
            this.dtpAcceptDate.Size = new System.Drawing.Size(163, 20);
            this.dtpAcceptDate.TabIndex = 3;
            this.dtpAcceptDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            // 
            // cmbPayMethod
            // 
            this.cmbPayMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayMethod.FormattingEnabled = true;
            this.cmbPayMethod.Location = new System.Drawing.Point(96, 10);
            this.cmbPayMethod.Name = "cmbPayMethod";
            this.cmbPayMethod.Size = new System.Drawing.Size(163, 21);
            this.cmbPayMethod.TabIndex = 0;
            this.cmbPayMethod.Enter += new System.EventHandler(this.cmbPayMethod_Enter);
            this.cmbPayMethod.SelectedValueChanged += new System.EventHandler(this.cmbPayMethod_SelectedValueChanged);
            this.cmbPayMethod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(96, 143);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(256, 20);
            this.txtRemarks.TabIndex = 6;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtRemarks.Leave += new System.EventHandler(this.txt_Leave);
            this.txtRemarks.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // txtPayFromAcc
            // 
            this.txtPayFromAcc.Location = new System.Drawing.Point(96, 99);
            this.txtPayFromAcc.Name = "txtPayFromAcc";
            this.txtPayFromAcc.ReadOnly = true;
            this.txtPayFromAcc.Size = new System.Drawing.Size(256, 20);
            this.txtPayFromAcc.TabIndex = 4;
            this.txtPayFromAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPayFromAcc_KeyDown);
            this.txtPayFromAcc.Leave += new System.EventHandler(this.txt_Leave);
            this.txtPayFromAcc.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // txtChequeLCNo
            // 
            this.txtChequeLCNo.Location = new System.Drawing.Point(96, 54);
            this.txtChequeLCNo.Name = "txtChequeLCNo";
            this.txtChequeLCNo.Size = new System.Drawing.Size(163, 20);
            this.txtChequeLCNo.TabIndex = 2;
            this.txtChequeLCNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtChequeLCNo.Leave += new System.EventHandler(this.txt_Leave);
            this.txtChequeLCNo.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Remarks";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Pay Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Pay From";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Accept Date";
            // 
            // lblRefNo
            // 
            this.lblRefNo.AutoSize = true;
            this.lblRefNo.Location = new System.Drawing.Point(12, 57);
            this.lblRefNo.Name = "lblRefNo";
            this.lblRefNo.Size = new System.Drawing.Size(61, 13);
            this.lblRefNo.TabIndex = 3;
            this.lblRefNo.Text = "Chaque No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Pay Now (TK)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Pay Method";
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(12, 433);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 2;
            this.btnPost.Text = "&Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(93, 434);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(174, 434);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.Location = new System.Drawing.Point(61, 2);
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.ReadOnly = true;
            this.txtLoanNo.Size = new System.Drawing.Size(263, 20);
            this.txtLoanNo.TabIndex = 0;
            this.txtLoanNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoanNo_KeyDown);
            this.txtLoanNo.Leave += new System.EventHandler(this.txt_Leave);
            this.txtLoanNo.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // txtLoanAccID
            // 
            this.txtLoanAccID.Location = new System.Drawing.Point(351, 2);
            this.txtLoanAccID.Name = "txtLoanAccID";
            this.txtLoanAccID.Size = new System.Drawing.Size(15, 20);
            this.txtLoanAccID.TabIndex = 0;
            this.txtLoanAccID.Text = "0";
            this.txtLoanAccID.Visible = false;
            // 
            // txtDueAmount
            // 
            this.txtDueAmount.BackgroudColor = System.Drawing.SystemColors.Control;
            this.txtDueAmount.Location = new System.Drawing.Point(104, 174);
            this.txtDueAmount.Name = "txtDueAmount";
            this.txtDueAmount.ReadOnly = true;
            this.txtDueAmount.Size = new System.Drawing.Size(163, 20);
            this.txtDueAmount.TabIndex = 2;
            this.txtDueAmount.TabStop = false;
            this.txtDueAmount.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtDueAmount.Value = 0;
            // 
            // dgvLoanAdjust
            // 
            this.dgvLoanAdjust.AllowUserToAddRows = false;
            this.dgvLoanAdjust.AllowUserToDeleteRows = false;
            this.dgvLoanAdjust.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvLoanAdjust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoanAdjust.ContextMenuFields = null;
            this.dgvLoanAdjust.isEnterKeyLikeTabKey = true;
            this.dgvLoanAdjust.isExcelSheetCell = false;
            this.dgvLoanAdjust.IsSortable = false;
            this.dgvLoanAdjust.Location = new System.Drawing.Point(372, 175);
            this.dgvLoanAdjust.Name = "dgvLoanAdjust";
            this.dgvLoanAdjust.ReadOnly = true;
            this.dgvLoanAdjust.RowHeadersVisible = false;
            this.dgvLoanAdjust.RowPointer = 0;
            this.dgvLoanAdjust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoanAdjust.ShowDateTimePicker = true;
            this.dgvLoanAdjust.Size = new System.Drawing.Size(404, 281);
            this.dgvLoanAdjust.TabIndex = 5;
            this.dgvLoanAdjust.TabStop = false;
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
            this.ctlDGVLoan.Location = new System.Drawing.Point(8, 27);
            this.ctlDGVLoan.Name = "ctlDGVLoan";
            this.ctlDGVLoan.ReadOnly = true;
            this.ctlDGVLoan.RowHeadersVisible = false;
            this.ctlDGVLoan.RowPointer = 0;
            this.ctlDGVLoan.ShowDateTimePicker = true;
            this.ctlDGVLoan.Size = new System.Drawing.Size(768, 144);
            this.ctlDGVLoan.TabIndex = 2;
            this.ctlDGVLoan.TabStop = false;
            // 
            // frmLoanPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 463);
            this.Controls.Add(this.txtDueAmount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvLoanAdjust);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctlDGVLoan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLoanAccID);
            this.Controls.Add(this.txtLoanID);
            this.Controls.Add(this.txtLoanAccount);
            this.Controls.Add(this.txtLoanNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoanPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loan Payment";
            this.Load += new System.EventHandler(this.frmLoanPayment_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmLoanPayment_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLoanPayment_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanAdjust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVLoan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLoanID;
        private System.Windows.Forms.TextBox txtLoanAccount;
        private System.Windows.Forms.Label label2;
        private Accounting.Controls.ctlDaraGridView ctlDGVLoan;
        private System.Windows.Forms.Label label3;
        private Accounting.Controls.ctlDaraGridView dgvLoanAdjust;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbPayMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtChequeLCNo;
        private System.Windows.Forms.Label lblRefNo;
        private System.Windows.Forms.DateTimePicker dtpAcceptDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPayFromAcc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DTPPayDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtLoanNo;
        private System.Windows.Forms.TextBox txtLoanAccID;
        private Accounting.Controls.ctlNum txtPayNow;
        private Accounting.Controls.ctlNum txtDueAmount;
        private System.Windows.Forms.TextBox txtLoanAdjustID;
    }
}