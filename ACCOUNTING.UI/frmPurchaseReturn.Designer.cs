namespace Accounting.UI
{
    partial class frmPurchaseReturn
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
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.llblPInv = new System.Windows.Forms.LinkLabel();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpRetDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPurchaseAccNo = new System.Windows.Forms.TextBox();
            this.txtSupplierAccNo = new System.Windows.Forms.TextBox();
            this.txtStockRefID = new System.Windows.Forms.TextBox();
            this.txtTransRefID = new System.Windows.Forms.TextBox();
            this.txtPurchaseAccID = new System.Windows.Forms.TextBox();
            this.txtPurchaseInvoiceNo = new System.Windows.Forms.TextBox();
            this.txtSupplierAccID = new System.Windows.Forms.TextBox();
            this.txtPIID = new System.Windows.Forms.TextBox();
            this.txtReturnMID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctlDGVPurchaseReturn = new Accounting.Controls.ctlDaraGridView();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtReturnAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPurRet = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVPurchaseReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbCurrency);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.llblPInv);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpRetDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPurchaseAccNo);
            this.groupBox1.Controls.Add(this.txtSupplierAccNo);
            this.groupBox1.Controls.Add(this.txtStockRefID);
            this.groupBox1.Controls.Add(this.txtTransRefID);
            this.groupBox1.Controls.Add(this.txtPurchaseAccID);
            this.groupBox1.Controls.Add(this.txtPurchaseInvoiceNo);
            this.groupBox1.Controls.Add(this.txtSupplierAccID);
            this.groupBox1.Controls.Add(this.txtPIID);
            this.groupBox1.Controls.Add(this.txtReturnMID);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 95);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(723, 34);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(91, 20);
            this.txtRate.TabIndex = 5;
            this.txtRate.Text = "1.00";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            this.txtRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRate_KeyDown);
            this.txtRate.Leave += new System.EventHandler(this.txtRate_Leave);
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            this.txtRate.Enter += new System.EventHandler(this.txtRate_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(687, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Rate";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(563, 34);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(118, 21);
            this.cmbCurrency.TabIndex = 4;
            this.cmbCurrency.Enter += new System.EventHandler(this.cmbCurrency_Enter);
            this.cmbCurrency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCurrency_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(492, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Currency";
            // 
            // llblPInv
            // 
            this.llblPInv.AutoSize = true;
            this.llblPInv.Location = new System.Drawing.Point(492, 79);
            this.llblPInv.Name = "llblPInv";
            this.llblPInv.Size = new System.Drawing.Size(123, 13);
            this.llblPInv.TabIndex = 7;
            this.llblPInv.TabStop = true;
            this.llblPInv.Text = "Select Purchase Invoice";
            this.llblPInv.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblPInv_LinkClicked);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(563, 55);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(251, 20);
            this.txtRemarks.TabIndex = 6;
            this.txtRemarks.TextChanged += new System.EventHandler(this.txtRemarks_TextChanged);
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemarks_KeyDown);
            this.txtRemarks.Leave += new System.EventHandler(this.txtRemarks_Leave);
            this.txtRemarks.Enter += new System.EventHandler(this.txtRemarks_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(493, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Remarks";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(492, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Return Date";
            // 
            // dtpRetDate
            // 
            this.dtpRetDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRetDate.Location = new System.Drawing.Point(563, 13);
            this.dtpRetDate.Name = "dtpRetDate";
            this.dtpRetDate.Size = new System.Drawing.Size(118, 20);
            this.dtpRetDate.TabIndex = 3;
            this.dtpRetDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpRetDate_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Purchase Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Supplier Account";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Invoice No.";
            // 
            // txtPurchaseAccNo
            // 
            this.txtPurchaseAccNo.Location = new System.Drawing.Point(126, 67);
            this.txtPurchaseAccNo.Name = "txtPurchaseAccNo";
            this.txtPurchaseAccNo.ReadOnly = true;
            this.txtPurchaseAccNo.Size = new System.Drawing.Size(225, 20);
            this.txtPurchaseAccNo.TabIndex = 2;
            this.txtPurchaseAccNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerAccNo_KeyDown);
            this.txtPurchaseAccNo.Leave += new System.EventHandler(this.txtCustomerAccNo_Leave);
            this.txtPurchaseAccNo.Enter += new System.EventHandler(this.txtCustomerAccNo_Enter);
            // 
            // txtSupplierAccNo
            // 
            this.txtSupplierAccNo.Location = new System.Drawing.Point(126, 39);
            this.txtSupplierAccNo.Name = "txtSupplierAccNo";
            this.txtSupplierAccNo.ReadOnly = true;
            this.txtSupplierAccNo.Size = new System.Drawing.Size(225, 20);
            this.txtSupplierAccNo.TabIndex = 1;
            this.txtSupplierAccNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierAccNo_KeyDown);
            this.txtSupplierAccNo.Leave += new System.EventHandler(this.txtSupplierAccNo_Leave);
            this.txtSupplierAccNo.Enter += new System.EventHandler(this.txtSupplierAccNo_Enter);
            // 
            // txtStockRefID
            // 
            this.txtStockRefID.Location = new System.Drawing.Point(427, 66);
            this.txtStockRefID.Name = "txtStockRefID";
            this.txtStockRefID.Size = new System.Drawing.Size(24, 20);
            this.txtStockRefID.TabIndex = 13;
            this.txtStockRefID.Text = "0";
            this.txtStockRefID.Visible = false;
            // 
            // txtTransRefID
            // 
            this.txtTransRefID.Location = new System.Drawing.Point(427, 39);
            this.txtTransRefID.Name = "txtTransRefID";
            this.txtTransRefID.Size = new System.Drawing.Size(24, 20);
            this.txtTransRefID.TabIndex = 12;
            this.txtTransRefID.Text = "0";
            this.txtTransRefID.Visible = false;
            // 
            // txtPurchaseAccID
            // 
            this.txtPurchaseAccID.Location = new System.Drawing.Point(376, 65);
            this.txtPurchaseAccID.Name = "txtPurchaseAccID";
            this.txtPurchaseAccID.Size = new System.Drawing.Size(24, 20);
            this.txtPurchaseAccID.TabIndex = 10;
            this.txtPurchaseAccID.Text = "0";
            this.txtPurchaseAccID.Visible = false;
            // 
            // txtPurchaseInvoiceNo
            // 
            this.txtPurchaseInvoiceNo.Location = new System.Drawing.Point(126, 13);
            this.txtPurchaseInvoiceNo.Name = "txtPurchaseInvoiceNo";
            this.txtPurchaseInvoiceNo.Size = new System.Drawing.Size(225, 20);
            this.txtPurchaseInvoiceNo.TabIndex = 0;
            this.txtPurchaseInvoiceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPurchaseInvoiceNo_KeyDown);
            this.txtPurchaseInvoiceNo.Leave += new System.EventHandler(this.txtPurchaseInvoiceNo_Leave);
            this.txtPurchaseInvoiceNo.Enter += new System.EventHandler(this.txtPurchaseInvoiceNo_Enter);
            // 
            // txtSupplierAccID
            // 
            this.txtSupplierAccID.Location = new System.Drawing.Point(377, 39);
            this.txtSupplierAccID.Name = "txtSupplierAccID";
            this.txtSupplierAccID.Size = new System.Drawing.Size(24, 20);
            this.txtSupplierAccID.TabIndex = 9;
            this.txtSupplierAccID.Text = "0";
            this.txtSupplierAccID.Visible = false;
            // 
            // txtPIID
            // 
            this.txtPIID.Location = new System.Drawing.Point(377, 13);
            this.txtPIID.Name = "txtPIID";
            this.txtPIID.Size = new System.Drawing.Size(24, 20);
            this.txtPIID.TabIndex = 8;
            this.txtPIID.Text = "0";
            this.txtPIID.Visible = false;
            // 
            // txtReturnMID
            // 
            this.txtReturnMID.Location = new System.Drawing.Point(427, 13);
            this.txtReturnMID.Name = "txtReturnMID";
            this.txtReturnMID.Size = new System.Drawing.Size(24, 20);
            this.txtReturnMID.TabIndex = 11;
            this.txtReturnMID.Text = "0";
            this.txtReturnMID.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.ctlDGVPurchaseReturn);
            this.groupBox2.Location = new System.Drawing.Point(12, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(849, 309);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Purchase Return Detail Info";
            // 
            // ctlDGVPurchaseReturn
            // 
            this.ctlDGVPurchaseReturn.AllowUserToAddRows = false;
            this.ctlDGVPurchaseReturn.AllowUserToDeleteRows = false;
            this.ctlDGVPurchaseReturn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ctlDGVPurchaseReturn.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctlDGVPurchaseReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDGVPurchaseReturn.ContextMenuFields = null;
            this.ctlDGVPurchaseReturn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ctlDGVPurchaseReturn.IsSortable = false;
            this.ctlDGVPurchaseReturn.Location = new System.Drawing.Point(6, 17);
            this.ctlDGVPurchaseReturn.Name = "ctlDGVPurchaseReturn";
            this.ctlDGVPurchaseReturn.RowHeadersVisible = false;
            this.ctlDGVPurchaseReturn.RowPointer = 0;
            this.ctlDGVPurchaseReturn.ShowDateTimePicker = true;
            this.ctlDGVPurchaseReturn.Size = new System.Drawing.Size(837, 286);
            this.ctlDGVPurchaseReturn.TabIndex = 0;
            this.ctlDGVPurchaseReturn.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlDGVPurchaseReturn_CellValueChanged);
            this.ctlDGVPurchaseReturn.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ctlDGVPurchaseReturn_EditingControlShowing);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(529, 428);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(17, 23);
            this.btnFind.TabIndex = 0;
            this.btnFind.Text = "&Find Invoice";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Visible = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            this.btnFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnFind_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(132, 428);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(211, 428);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDelete_KeyDown);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(291, 428);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnReset_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(453, 428);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyDown);
            // 
            // txtReturnAmount
            // 
            this.txtReturnAmount.Enabled = false;
            this.txtReturnAmount.Location = new System.Drawing.Point(631, 428);
            this.txtReturnAmount.Name = "txtReturnAmount";
            this.txtReturnAmount.Size = new System.Drawing.Size(104, 20);
            this.txtReturnAmount.TabIndex = 6;
            this.txtReturnAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReturnAmount.TextChanged += new System.EventHandler(this.txtReturnAmount_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(547, 433);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Return Amount";
            // 
            // btnPurRet
            // 
            this.btnPurRet.Location = new System.Drawing.Point(373, 428);
            this.btnPurRet.Name = "btnPurRet";
            this.btnPurRet.Size = new System.Drawing.Size(75, 23);
            this.btnPurRet.TabIndex = 8;
            this.btnPurRet.Text = "&Find";
            this.btnPurRet.UseVisualStyleBackColor = true;
            this.btnPurRet.Click += new System.EventHandler(this.btnPurRet_Click);
            this.btnPurRet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnPurRet_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(737, 431);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "=";
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(755, 427);
            this.txtTK.Name = "txtTK";
            this.txtTK.ReadOnly = true;
            this.txtTK.Size = new System.Drawing.Size(88, 20);
            this.txtTK.TabIndex = 11;
            this.txtTK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(848, 432);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "TK";
            // 
            // frmPurchaseReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 459);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnPurRet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtReturnAmount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPurchaseReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Purchase Return";
            this.Load += new System.EventHandler(this.frmPurchaseReturn_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPurchaseReturn_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVPurchaseReturn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Accounting.Controls.ctlDaraGridView ctlDGVPurchaseReturn;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPurchaseAccNo;
        private System.Windows.Forms.TextBox txtSupplierAccNo;
        private System.Windows.Forms.TextBox txtPurchaseAccID;
        private System.Windows.Forms.TextBox txtPurchaseInvoiceNo;
        private System.Windows.Forms.TextBox txtSupplierAccID;
        private System.Windows.Forms.TextBox txtPIID;
        private System.Windows.Forms.TextBox txtReturnMID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpRetDate;
        private System.Windows.Forms.TextBox txtStockRefID;
        private System.Windows.Forms.TextBox txtTransRefID;
        private System.Windows.Forms.TextBox txtReturnAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPurRet;
        private System.Windows.Forms.LinkLabel llblPInv;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Label label10;
    }
}