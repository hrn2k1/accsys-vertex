namespace Accounting.UI
{
    partial class frmSalesReturn
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStockRefID = new System.Windows.Forms.TextBox();
            this.txtTransrefID = new System.Windows.Forms.TextBox();
            this.txtReturnMID = new System.Windows.Forms.TextBox();
            this.txtInvoiceID = new System.Windows.Forms.TextBox();
            this.txtSalesAcc = new System.Windows.Forms.TextBox();
            this.txtCusAcc = new System.Windows.Forms.TextBox();
            this.llblSelectInvoice = new System.Windows.Forms.LinkLabel();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.txtCustomerAccNo = new System.Windows.Forms.TextBox();
            this.lblCustomerAccNo = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.txtChalanNo = new System.Windows.Forms.TextBox();
            this.lblChalanNo = new System.Windows.Forms.Label();
            this.txtSalesAccNo = new System.Windows.Forms.TextBox();
            this.lblSalesAccNo = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlNumReturnAmount = new Accounting.Controls.ctlNum();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.rtxtRemarks = new System.Windows.Forms.RichTextBox();
            this.lblReturnAmount = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvSalesReturn = new Accounting.Controls.ctlDaraGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbCurrency);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtStockRefID);
            this.groupBox1.Controls.Add(this.txtTransrefID);
            this.groupBox1.Controls.Add(this.txtReturnMID);
            this.groupBox1.Controls.Add(this.txtInvoiceID);
            this.groupBox1.Controls.Add(this.txtSalesAcc);
            this.groupBox1.Controls.Add(this.txtCusAcc);
            this.groupBox1.Controls.Add(this.llblSelectInvoice);
            this.groupBox1.Controls.Add(this.dtpReturnDate);
            this.groupBox1.Controls.Add(this.lblReturnDate);
            this.groupBox1.Controls.Add(this.txtCustomerAccNo);
            this.groupBox1.Controls.Add(this.lblCustomerAccNo);
            this.groupBox1.Controls.Add(this.txtInvoiceNo);
            this.groupBox1.Controls.Add(this.txtChalanNo);
            this.groupBox1.Controls.Add(this.lblChalanNo);
            this.groupBox1.Controls.Add(this.txtSalesAccNo);
            this.groupBox1.Controls.Add(this.lblSalesAccNo);
            this.groupBox1.Controls.Add(this.lblInvoiceNo);
            this.groupBox1.Location = new System.Drawing.Point(1, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(873, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(745, 39);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(95, 20);
            this.txtRate.TabIndex = 4;
            this.txtRate.Text = "1";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(701, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Rate";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(575, 39);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(120, 21);
            this.cmbCurrency.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Currency";
            // 
            // txtStockRefID
            // 
            this.txtStockRefID.Location = new System.Drawing.Point(856, 70);
            this.txtStockRefID.Name = "txtStockRefID";
            this.txtStockRefID.Size = new System.Drawing.Size(12, 20);
            this.txtStockRefID.TabIndex = 20;
            this.txtStockRefID.Text = "0";
            this.txtStockRefID.Visible = false;
            // 
            // txtTransrefID
            // 
            this.txtTransrefID.Location = new System.Drawing.Point(856, 40);
            this.txtTransrefID.Name = "txtTransrefID";
            this.txtTransrefID.Size = new System.Drawing.Size(12, 20);
            this.txtTransrefID.TabIndex = 19;
            this.txtTransrefID.Text = "0";
            this.txtTransrefID.Visible = false;
            // 
            // txtReturnMID
            // 
            this.txtReturnMID.Location = new System.Drawing.Point(856, 16);
            this.txtReturnMID.Name = "txtReturnMID";
            this.txtReturnMID.Size = new System.Drawing.Size(12, 20);
            this.txtReturnMID.TabIndex = 18;
            this.txtReturnMID.Text = "0";
            this.txtReturnMID.Visible = false;
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.Location = new System.Drawing.Point(390, 16);
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Size = new System.Drawing.Size(22, 20);
            this.txtInvoiceID.TabIndex = 11;
            this.txtInvoiceID.Text = "0";
            this.txtInvoiceID.Visible = false;
            // 
            // txtSalesAcc
            // 
            this.txtSalesAcc.Location = new System.Drawing.Point(390, 68);
            this.txtSalesAcc.Name = "txtSalesAcc";
            this.txtSalesAcc.Size = new System.Drawing.Size(22, 20);
            this.txtSalesAcc.TabIndex = 13;
            this.txtSalesAcc.Text = "0";
            this.txtSalesAcc.Visible = false;
            // 
            // txtCusAcc
            // 
            this.txtCusAcc.Location = new System.Drawing.Point(390, 42);
            this.txtCusAcc.Name = "txtCusAcc";
            this.txtCusAcc.Size = new System.Drawing.Size(22, 20);
            this.txtCusAcc.TabIndex = 12;
            this.txtCusAcc.Text = "0";
            this.txtCusAcc.Visible = false;
            // 
            // llblSelectInvoice
            // 
            this.llblSelectInvoice.AutoSize = true;
            this.llblSelectInvoice.Location = new System.Drawing.Point(503, 82);
            this.llblSelectInvoice.Name = "llblSelectInvoice";
            this.llblSelectInvoice.Size = new System.Drawing.Size(75, 13);
            this.llblSelectInvoice.TabIndex = 2;
            this.llblSelectInvoice.TabStop = true;
            this.llblSelectInvoice.Text = "Select Invoice";
            this.llblSelectInvoice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSelectInvoice_LinkClicked);
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReturnDate.Location = new System.Drawing.Point(575, 61);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(120, 20);
            this.dtpReturnDate.TabIndex = 5;
            this.dtpReturnDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpReturnDate_KeyDown);
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Location = new System.Drawing.Point(503, 65);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(65, 13);
            this.lblReturnDate.TabIndex = 16;
            this.lblReturnDate.Text = "Return Date";
            // 
            // txtCustomerAccNo
            // 
            this.txtCustomerAccNo.Location = new System.Drawing.Point(121, 42);
            this.txtCustomerAccNo.Name = "txtCustomerAccNo";
            this.txtCustomerAccNo.ReadOnly = true;
            this.txtCustomerAccNo.Size = new System.Drawing.Size(263, 20);
            this.txtCustomerAccNo.TabIndex = 6;
            this.txtCustomerAccNo.TextChanged += new System.EventHandler(this.txtCustomerAccNo_TextChanged);
            this.txtCustomerAccNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerAccNo_KeyDown);
            this.txtCustomerAccNo.Leave += new System.EventHandler(this.txtCustomerAccNo_Leave);
            this.txtCustomerAccNo.Enter += new System.EventHandler(this.txtCustomerAccNo_Enter_1);
            // 
            // lblCustomerAccNo
            // 
            this.lblCustomerAccNo.AutoSize = true;
            this.lblCustomerAccNo.Location = new System.Drawing.Point(14, 45);
            this.lblCustomerAccNo.Name = "lblCustomerAccNo";
            this.lblCustomerAccNo.Size = new System.Drawing.Size(94, 13);
            this.lblCustomerAccNo.TabIndex = 9;
            this.lblCustomerAccNo.Text = "Customer Account";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(121, 16);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(263, 20);
            this.txtInvoiceNo.TabIndex = 0;
            this.txtInvoiceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceNo_KeyDown);
            this.txtInvoiceNo.Leave += new System.EventHandler(this.txtInvoiceNo_Leave);
            this.txtInvoiceNo.Enter += new System.EventHandler(this.txtInvoiceNo_Enter);
            // 
            // txtChalanNo
            // 
            this.txtChalanNo.Location = new System.Drawing.Point(575, 17);
            this.txtChalanNo.Name = "txtChalanNo";
            this.txtChalanNo.Size = new System.Drawing.Size(265, 20);
            this.txtChalanNo.TabIndex = 1;
            this.txtChalanNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChalanNo_KeyDown);
            this.txtChalanNo.Leave += new System.EventHandler(this.txtChalanNo_Leave);
            this.txtChalanNo.Enter += new System.EventHandler(this.txtChalanNo_Enter);
            // 
            // lblChalanNo
            // 
            this.lblChalanNo.AutoSize = true;
            this.lblChalanNo.Location = new System.Drawing.Point(503, 20);
            this.lblChalanNo.Name = "lblChalanNo";
            this.lblChalanNo.Size = new System.Drawing.Size(57, 13);
            this.lblChalanNo.TabIndex = 14;
            this.lblChalanNo.Text = "Chalan No";
            // 
            // txtSalesAccNo
            // 
            this.txtSalesAccNo.Location = new System.Drawing.Point(121, 68);
            this.txtSalesAccNo.Name = "txtSalesAccNo";
            this.txtSalesAccNo.ReadOnly = true;
            this.txtSalesAccNo.Size = new System.Drawing.Size(263, 20);
            this.txtSalesAccNo.TabIndex = 7;
            this.txtSalesAccNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesAccNo_KeyDown);
            this.txtSalesAccNo.Leave += new System.EventHandler(this.txtSalesAccNo_Leave);
            this.txtSalesAccNo.Enter += new System.EventHandler(this.txtSalesAccNo_Enter_1);
            // 
            // lblSalesAccNo
            // 
            this.lblSalesAccNo.AutoSize = true;
            this.lblSalesAccNo.Location = new System.Drawing.Point(14, 71);
            this.lblSalesAccNo.Name = "lblSalesAccNo";
            this.lblSalesAccNo.Size = new System.Drawing.Size(76, 13);
            this.lblSalesAccNo.TabIndex = 10;
            this.lblSalesAccNo.Text = "Sales Account";
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(14, 19);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(59, 13);
            this.lblInvoiceNo.TabIndex = 8;
            this.lblInvoiceNo.Text = "Invoice No";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTK);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ctlNumReturnAmount);
            this.groupBox2.Controls.Add(this.lblRemarks);
            this.groupBox2.Controls.Add(this.rtxtRemarks);
            this.groupBox2.Controls.Add(this.lblReturnAmount);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnFind);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.dgvSalesReturn);
            this.groupBox2.Location = new System.Drawing.Point(1, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(873, 381);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(843, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "TK";
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(723, 345);
            this.txtTK.Name = "txtTK";
            this.txtTK.ReadOnly = true;
            this.txtTK.Size = new System.Drawing.Size(117, 20);
            this.txtTK.TabIndex = 11;
            this.txtTK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(706, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "=";
            // 
            // ctlNumReturnAmount
            // 
            this.ctlNumReturnAmount.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumReturnAmount.Location = new System.Drawing.Point(601, 347);
            this.ctlNumReturnAmount.Name = "ctlNumReturnAmount";
            this.ctlNumReturnAmount.ReadOnly = true;
            this.ctlNumReturnAmount.Size = new System.Drawing.Size(104, 20);
            this.ctlNumReturnAmount.TabIndex = 9;
            this.ctlNumReturnAmount.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumReturnAmount.Value = 0;
            this.ctlNumReturnAmount.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctlNumReturnAmount_valueChanged);
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(8, 314);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(49, 13);
            this.lblRemarks.TabIndex = 7;
            this.lblRemarks.Text = "Remarks";
            // 
            // rtxtRemarks
            // 
            this.rtxtRemarks.Location = new System.Drawing.Point(73, 311);
            this.rtxtRemarks.Name = "rtxtRemarks";
            this.rtxtRemarks.Size = new System.Drawing.Size(793, 28);
            this.rtxtRemarks.TabIndex = 1;
            this.rtxtRemarks.Text = "";
            this.rtxtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxtRemarks_KeyDown);
            this.rtxtRemarks.Enter += new System.EventHandler(this.rtxtRemarks_Enter);
            this.rtxtRemarks.Leave += new System.EventHandler(this.rtxtRemarks_Leave);
            // 
            // lblReturnAmount
            // 
            this.lblReturnAmount.AutoSize = true;
            this.lblReturnAmount.Location = new System.Drawing.Point(519, 350);
            this.lblReturnAmount.Name = "lblReturnAmount";
            this.lblReturnAmount.Size = new System.Drawing.Size(78, 13);
            this.lblReturnAmount.TabIndex = 8;
            this.lblReturnAmount.Text = "Return Amount";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.Location = new System.Drawing.Point(119, 348);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnReset_KeyDown);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.Control;
            this.btnFind.Location = new System.Drawing.Point(200, 348);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            this.btnFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnFind_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(281, 348);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(362, 348);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDelete_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(443, 348);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            // 
            // dgvSalesReturn
            // 
            this.dgvSalesReturn.AllowUserToAddRows = false;
            this.dgvSalesReturn.AllowUserToDeleteRows = false;
            this.dgvSalesReturn.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvSalesReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesReturn.ContextMenuFields = null;
            this.dgvSalesReturn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSalesReturn.IsSortable = false;
            this.dgvSalesReturn.Location = new System.Drawing.Point(6, 11);
            this.dgvSalesReturn.Name = "dgvSalesReturn";
            this.dgvSalesReturn.RowHeadersVisible = false;
            this.dgvSalesReturn.RowPointer = 0;
            this.dgvSalesReturn.ShowDateTimePicker = true;
            this.dgvSalesReturn.Size = new System.Drawing.Size(860, 294);
            this.dgvSalesReturn.TabIndex = 0;
            this.dgvSalesReturn.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesReturn_CellValueChanged);
            this.dgvSalesReturn.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSalesReturn_EditingControlShowing);
            this.dgvSalesReturn.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesReturn_CellEnter);
            // 
            // frmSalesReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(877, 484);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sales Return";
            this.Load += new System.EventHandler(this.frmSalesReturn_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSalesReturn_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSalesReturn_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesReturn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblReturnAmount;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private Accounting.Controls.ctlDaraGridView dgvSalesReturn;
        private System.Windows.Forms.RichTextBox rtxtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.TextBox txtSalesAccNo;
        private System.Windows.Forms.TextBox txtChalanNo;
        private System.Windows.Forms.Label lblSalesAccNo;
        private System.Windows.Forms.Label lblChalanNo;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.TextBox txtCustomerAccNo;
        private System.Windows.Forms.Label lblCustomerAccNo;
        private System.Windows.Forms.LinkLabel llblSelectInvoice;
        private System.Windows.Forms.TextBox txtCusAcc;
        private System.Windows.Forms.TextBox txtSalesAcc;
        private System.Windows.Forms.TextBox txtInvoiceID;
        private System.Windows.Forms.TextBox txtReturnMID;
        private System.Windows.Forms.TextBox txtStockRefID;
        private System.Windows.Forms.TextBox txtTransrefID;
        private Accounting.Controls.ctlNum ctlNumReturnAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Label label3;
    }
}