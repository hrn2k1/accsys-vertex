namespace Accounting.UI
{
    partial class frmSalesInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtDiscount = new Accounting.Controls.ctlNum();
            this.btnFind = new System.Windows.Forms.Button();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.rtxtRemarks = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboDiscount = new System.Windows.Forms.ComboBox();
            this.txtTotalBill = new System.Windows.Forms.TextBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvSalesInvoiceDetails = new Accounting.Controls.ctlDaraGridView();
            this.ColSLNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColCountID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColSizeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColColorID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColColorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLabdip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInvQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInvUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPriceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChalanNo = new System.Windows.Forms.TextBox();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomerAccount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSalesAccount = new System.Windows.Forms.TextBox();
            this.cboInvoiceType = new System.Windows.Forms.ComboBox();
            this.txtCustomerAcc = new System.Windows.Forms.TextBox();
            this.txtSalesAcc = new System.Windows.Forms.TextBox();
            this.txtInvoiceID = new System.Windows.Forms.TextBox();
            this.txtTMID = new System.Windows.Forms.TextBox();
            this.txtStockRefID = new System.Windows.Forms.TextBox();
            this.llblSOs = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesInvoiceDetails)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtTK);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.txtDiscount);
            this.groupBox2.Controls.Add(this.btnFind);
            this.groupBox2.Controls.Add(this.lblRemarks);
            this.groupBox2.Controls.Add(this.rtxtRemarks);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cboDiscount);
            this.groupBox2.Controls.Add(this.txtTotalBill);
            this.groupBox2.Controls.Add(this.txtSubTotal);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.dgvSalesInvoiceDetails);
            this.groupBox2.Location = new System.Drawing.Point(4, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(844, 364);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "InvoiceDetails";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(821, 339);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "TK";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(698, 339);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "=";
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(716, 335);
            this.txtTK.Name = "txtTK";
            this.txtTK.ReadOnly = true;
            this.txtTK.Size = new System.Drawing.Size(100, 20);
            this.txtTK.TabIndex = 17;
            this.txtTK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.Location = new System.Drawing.Point(39, 341);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 16;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackgroudColor = System.Drawing.SystemColors.Window;
            this.txtDiscount.Location = new System.Drawing.Point(594, 307);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = false;
            this.txtDiscount.Size = new System.Drawing.Size(145, 20);
            this.txtDiscount.TabIndex = 8;
            this.txtDiscount.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtDiscount.Value = 0;
            this.txtDiscount.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.txtDiscount_valueChanged);
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiscount_KeyDown);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.Control;
            this.btnFind.Location = new System.Drawing.Point(264, 341);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 11;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(13, 292);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(49, 13);
            this.lblRemarks.TabIndex = 8;
            this.lblRemarks.Text = "Remarks";
            // 
            // rtxtRemarks
            // 
            this.rtxtRemarks.Location = new System.Drawing.Point(62, 284);
            this.rtxtRemarks.Name = "rtxtRemarks";
            this.rtxtRemarks.Size = new System.Drawing.Size(427, 29);
            this.rtxtRemarks.TabIndex = 7;
            this.rtxtRemarks.Text = "";
            this.rtxtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxtRemarks_KeyDown);
            this.rtxtRemarks.Enter += new System.EventHandler(this.rtxtRemarks_Enter);
            this.rtxtRemarks.Leave += new System.EventHandler(this.rtxtRemarks_Leave);
            this.rtxtRemarks.TextChanged += new System.EventHandler(this.rtxtRemarks_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(512, 309);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Discount";
            // 
            // cboDiscount
            // 
            this.cboDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiscount.FormattingEnabled = true;
            this.cboDiscount.Items.AddRange(new object[] {
            "Fixed Value",
            "Amt %"});
            this.cboDiscount.Location = new System.Drawing.Point(745, 306);
            this.cboDiscount.Name = "cboDiscount";
            this.cboDiscount.Size = new System.Drawing.Size(91, 21);
            this.cboDiscount.TabIndex = 9;
            this.cboDiscount.SelectedIndexChanged += new System.EventHandler(this.txtDiscount_valueChanged);
            this.cboDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboDiscount_KeyDown);
            // 
            // txtTotalBill
            // 
            this.txtTotalBill.Location = new System.Drawing.Point(594, 335);
            this.txtTotalBill.Margin = new System.Windows.Forms.Padding(0);
            this.txtTotalBill.Name = "txtTotalBill";
            this.txtTotalBill.ReadOnly = true;
            this.txtTotalBill.Size = new System.Drawing.Size(101, 20);
            this.txtTotalBill.TabIndex = 10;
            this.txtTotalBill.Text = "0.00";
            this.txtTotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalBill.TextChanged += new System.EventHandler(this.txtTotalBill_TextChanged);
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(594, 283);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(242, 20);
            this.txtSubTotal.TabIndex = 9;
            this.txtSubTotal.Text = "0.00";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSubTotal.TextChanged += new System.EventHandler(this.txtDiscount_valueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(515, 335);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Total Bill";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(512, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "SubTotal";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(339, 341);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.Location = new System.Drawing.Point(114, 341);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(189, 341);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(414, 341);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvSalesInvoiceDetails
            // 
            this.dgvSalesInvoiceDetails.AllowUserToDeleteRows = false;
            this.dgvSalesInvoiceDetails.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvSalesInvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesInvoiceDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSLNo,
            this.ColOrderID,
            this.ColItemID,
            this.ColCountID,
            this.ColSizeID,
            this.ColColorID,
            this.ColColorCode,
            this.ColLabdip,
            this.ColOrderQty,
            this.ColUnitID,
            this.ColUnit,
            this.ColInvQty,
            this.ColInvUnitPrice,
            this.ColPriceAmount,
            this.ColRemarks});
            this.dgvSalesInvoiceDetails.ContextMenuFields = null;
            this.dgvSalesInvoiceDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSalesInvoiceDetails.IsSortable = false;
            this.dgvSalesInvoiceDetails.Location = new System.Drawing.Point(7, 19);
            this.dgvSalesInvoiceDetails.Name = "dgvSalesInvoiceDetails";
            this.dgvSalesInvoiceDetails.RowHeadersWidth = 25;
            this.dgvSalesInvoiceDetails.RowPointer = 0;
            this.dgvSalesInvoiceDetails.ShowDateTimePicker = false;
            this.dgvSalesInvoiceDetails.Size = new System.Drawing.Size(831, 258);
            this.dgvSalesInvoiceDetails.TabIndex = 0;
            this.dgvSalesInvoiceDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesInvoiceDetails_CellValueChanged);
            this.dgvSalesInvoiceDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesInvoiceDetails_CellClick);
            this.dgvSalesInvoiceDetails.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSalesInvoiceDetails_EditingControlShowing);
            this.dgvSalesInvoiceDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSalesInvoiceDetails_KeyDown);
            this.dgvSalesInvoiceDetails.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesInvoiceDetails_CellEnter);
            this.dgvSalesInvoiceDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesInvoiceDetails_CellContentClick);
            // 
            // ColSLNo
            // 
            this.ColSLNo.HeaderText = "SLNo";
            this.ColSLNo.Name = "ColSLNo";
            this.ColSLNo.Visible = false;
            // 
            // ColOrderID
            // 
            this.ColOrderID.HeaderText = "OrderID";
            this.ColOrderID.Name = "ColOrderID";
            this.ColOrderID.Visible = false;
            // 
            // ColItemID
            // 
            this.ColItemID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColItemID.HeaderText = "Item";
            this.ColItemID.Name = "ColItemID";
            this.ColItemID.Width = 150;
            // 
            // ColCountID
            // 
            this.ColCountID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColCountID.HeaderText = "Count";
            this.ColCountID.Name = "ColCountID";
            this.ColCountID.Width = 70;
            // 
            // ColSizeID
            // 
            this.ColSizeID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColSizeID.HeaderText = "Size";
            this.ColSizeID.Name = "ColSizeID";
            this.ColSizeID.Width = 70;
            // 
            // ColColorID
            // 
            this.ColColorID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColColorID.HeaderText = "Color";
            this.ColColorID.Name = "ColColorID";
            this.ColColorID.Width = 70;
            // 
            // ColColorCode
            // 
            this.ColColorCode.HeaderText = "Color Code";
            this.ColColorCode.Name = "ColColorCode";
            this.ColColorCode.Width = 85;
            // 
            // ColLabdip
            // 
            this.ColLabdip.HeaderText = "Labdip";
            this.ColLabdip.Name = "ColLabdip";
            this.ColLabdip.Width = 70;
            // 
            // ColOrderQty
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0.00";
            this.ColOrderQty.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColOrderQty.HeaderText = "Order Qty";
            this.ColOrderQty.Name = "ColOrderQty";
            this.ColOrderQty.ReadOnly = true;
            this.ColOrderQty.Width = 80;
            // 
            // ColUnitID
            // 
            this.ColUnitID.HeaderText = "UnitID";
            this.ColUnitID.Name = "ColUnitID";
            this.ColUnitID.Visible = false;
            // 
            // ColUnit
            // 
            this.ColUnit.HeaderText = "Unit";
            this.ColUnit.Name = "ColUnit";
            this.ColUnit.ReadOnly = true;
            this.ColUnit.Width = 70;
            // 
            // ColInvQty
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.ColInvQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColInvQty.HeaderText = "Inv Qty";
            this.ColInvQty.Name = "ColInvQty";
            // 
            // ColInvUnitPrice
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.ColInvUnitPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColInvUnitPrice.HeaderText = "Unit Price";
            this.ColInvUnitPrice.Name = "ColInvUnitPrice";
            this.ColInvUnitPrice.Width = 90;
            // 
            // ColPriceAmount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0.00";
            this.ColPriceAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColPriceAmount.HeaderText = "Inv Amt";
            this.ColPriceAmount.Name = "ColPriceAmount";
            this.ColPriceAmount.ReadOnly = true;
            // 
            // ColRemarks
            // 
            this.ColRemarks.HeaderText = "C. Qty";
            this.ColRemarks.Name = "ColRemarks";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(561, 89);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(130, 21);
            this.cmbCurrency.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "InvoiceType";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "InvoiceNo";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(77, 39);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(229, 20);
            this.txtInvoiceNo.TabIndex = 1;
            this.txtInvoiceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceNo_KeyDown);
            this.txtInvoiceNo.Leave += new System.EventHandler(this.txtInvoiceNo_Leave);
            this.txtInvoiceNo.Enter += new System.EventHandler(this.txtInvoiceNo_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "ChalanNo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Invoice Date";
            // 
            // txtChalanNo
            // 
            this.txtChalanNo.Location = new System.Drawing.Point(77, 65);
            this.txtChalanNo.Name = "txtChalanNo";
            this.txtChalanNo.Size = new System.Drawing.Size(229, 20);
            this.txtChalanNo.TabIndex = 2;
            this.txtChalanNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChalanNo_KeyDown);
            this.txtChalanNo.Leave += new System.EventHandler(this.txtChalanNo_Leave);
            this.txtChalanNo.Enter += new System.EventHandler(this.txtChalanNo_Enter);
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(561, 68);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(130, 20);
            this.dtpInvoiceDate.TabIndex = 5;
            this.dtpInvoiceDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpInvoiceDate_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(466, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Customer Account";
            // 
            // txtCustomerAccount
            // 
            this.txtCustomerAccount.Location = new System.Drawing.Point(561, 16);
            this.txtCustomerAccount.Name = "txtCustomerAccount";
            this.txtCustomerAccount.ReadOnly = true;
            this.txtCustomerAccount.Size = new System.Drawing.Size(255, 20);
            this.txtCustomerAccount.TabIndex = 3;
            this.txtCustomerAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerAccount_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(466, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Sales Account";
            // 
            // txtSalesAccount
            // 
            this.txtSalesAccount.Location = new System.Drawing.Point(561, 42);
            this.txtSalesAccount.Name = "txtSalesAccount";
            this.txtSalesAccount.ReadOnly = true;
            this.txtSalesAccount.Size = new System.Drawing.Size(255, 20);
            this.txtSalesAccount.TabIndex = 4;
            this.txtSalesAccount.Click += new System.EventHandler(this.txtSalesAccount_Click);
            this.txtSalesAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesAccount_KeyDown);
            // 
            // cboInvoiceType
            // 
            this.cboInvoiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInvoiceType.FormattingEnabled = true;
            this.cboInvoiceType.Items.AddRange(new object[] {
            "Sales Order",
            "Direct Sale"});
            this.cboInvoiceType.Location = new System.Drawing.Point(77, 13);
            this.cboInvoiceType.Name = "cboInvoiceType";
            this.cboInvoiceType.Size = new System.Drawing.Size(229, 21);
            this.cboInvoiceType.TabIndex = 0;
            this.cboInvoiceType.Enter += new System.EventHandler(this.cboInvoiceType_Enter);
            this.cboInvoiceType.SelectedValueChanged += new System.EventHandler(this.cboInvoiceType_SelectedValueChanged);
            this.cboInvoiceType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboInvoiceType_KeyDown);
            // 
            // txtCustomerAcc
            // 
            this.txtCustomerAcc.Location = new System.Drawing.Point(821, 16);
            this.txtCustomerAcc.Name = "txtCustomerAcc";
            this.txtCustomerAcc.Size = new System.Drawing.Size(12, 20);
            this.txtCustomerAcc.TabIndex = 6;
            this.txtCustomerAcc.Text = "0";
            this.txtCustomerAcc.Visible = false;
            // 
            // txtSalesAcc
            // 
            this.txtSalesAcc.Location = new System.Drawing.Point(821, 42);
            this.txtSalesAcc.Name = "txtSalesAcc";
            this.txtSalesAcc.Size = new System.Drawing.Size(12, 20);
            this.txtSalesAcc.TabIndex = 7;
            this.txtSalesAcc.Text = "0";
            this.txtSalesAcc.Visible = false;
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.Location = new System.Drawing.Point(821, 65);
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Size = new System.Drawing.Size(13, 20);
            this.txtInvoiceID.TabIndex = 8;
            this.txtInvoiceID.Text = "0";
            this.txtInvoiceID.Visible = false;
            this.txtInvoiceID.TextChanged += new System.EventHandler(this.txtInvoiceID_TextChanged);
            // 
            // txtTMID
            // 
            this.txtTMID.Location = new System.Drawing.Point(349, 16);
            this.txtTMID.Name = "txtTMID";
            this.txtTMID.Size = new System.Drawing.Size(12, 20);
            this.txtTMID.TabIndex = 9;
            this.txtTMID.Text = "0";
            this.txtTMID.Visible = false;
            // 
            // txtStockRefID
            // 
            this.txtStockRefID.Location = new System.Drawing.Point(348, 42);
            this.txtStockRefID.Name = "txtStockRefID";
            this.txtStockRefID.Size = new System.Drawing.Size(13, 20);
            this.txtStockRefID.TabIndex = 16;
            this.txtStockRefID.Text = "0";
            this.txtStockRefID.Visible = false;
            // 
            // llblSOs
            // 
            this.llblSOs.AutoSize = true;
            this.llblSOs.Location = new System.Drawing.Point(74, 93);
            this.llblSOs.Name = "llblSOs";
            this.llblSOs.Size = new System.Drawing.Size(151, 13);
            this.llblSOs.TabIndex = 6;
            this.llblSOs.TabStop = true;
            this.llblSOs.Text = "Select Sales Order to Invoioce";
            this.llblSOs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSOs_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.llblSOs);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.txtStockRefID);
            this.groupBox1.Controls.Add(this.cmbCurrency);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTMID);
            this.groupBox1.Controls.Add(this.txtInvoiceID);
            this.groupBox1.Controls.Add(this.txtSalesAcc);
            this.groupBox1.Controls.Add(this.txtCustomerAcc);
            this.groupBox1.Controls.Add(this.cboInvoiceType);
            this.groupBox1.Controls.Add(this.txtSalesAccount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCustomerAccount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpInvoiceDate);
            this.groupBox1.Controls.Add(this.txtChalanNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtInvoiceNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(843, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(693, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Rate";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(729, 90);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(87, 20);
            this.txtRate.TabIndex = 19;
            this.txtRate.Text = "1";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(466, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Currency";
            // 
            // frmSalesInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(852, 491);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SalesInvoice";
            this.Load += new System.EventHandler(this.frmSalesInvoice_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSalesInvoice_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSalesInvoice_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesInvoiceDetails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private Accounting.Controls.ctlDaraGridView dgvSalesInvoiceDetails;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTotalBill;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDiscount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.RichTextBox rtxtRemarks;
        private System.Windows.Forms.Button btnFind;
        private Accounting.Controls.ctlNum txtDiscount;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChalanNo;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomerAccount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSalesAccount;
        private System.Windows.Forms.ComboBox cboInvoiceType;
        private System.Windows.Forms.TextBox txtCustomerAcc;
        private System.Windows.Forms.TextBox txtSalesAcc;
        private System.Windows.Forms.TextBox txtInvoiceID;
        private System.Windows.Forms.TextBox txtTMID;
        private System.Windows.Forms.TextBox txtStockRefID;
        private System.Windows.Forms.LinkLabel llblSOs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSLNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOrderID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColItemID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColCountID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColSizeID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColColorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColColorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLabdip;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOrderQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInvQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInvUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPriceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRemarks;
    }
}