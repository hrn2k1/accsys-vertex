namespace Accounting.UI
{
    partial class frmStockInOut
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboTransType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblRefID = new System.Windows.Forms.Label();
            this.llblSelection = new System.Windows.Forms.LinkLabel();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStockMID = new System.Windows.Forms.TextBox();
            this.dtpChalanDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTransDate = new System.Windows.Forms.DateTimePicker();
            this.lblChalanNo = new System.Windows.Forms.Label();
            this.lblChalanDate = new System.Windows.Forms.Label();
            this.txtChalanNo = new System.Windows.Forms.TextBox();
            this.txtCustSupp = new System.Windows.Forms.TextBox();
            this.lblCustSupp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkHitAccount = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctldgvItems = new Accounting.Controls.ctlDaraGridView();
            this.StockDID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TNature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CountID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SizeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColorID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Specifications = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Budle_Pack_Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Budle_Pack_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAvailQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTransType
            // 
            this.cboTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransType.FormattingEnabled = true;
            this.cboTransType.Location = new System.Drawing.Point(105, 13);
            this.cboTransType.Name = "cboTransType";
            this.cboTransType.Size = new System.Drawing.Size(181, 21);
            this.cboTransType.TabIndex = 0;
            this.cboTransType.Tag = "II";
            this.cboTransType.Enter += new System.EventHandler(this.cboTransType_Enter);
            this.cboTransType.SelectedValueChanged += new System.EventHandler(this.cboTransType_SelectedValueChanged);
            this.cboTransType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboTransType_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Transaction Type";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(381, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Voucher No.";
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.BackColor = System.Drawing.Color.White;
            this.txtVoucherNo.Location = new System.Drawing.Point(483, 40);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.Size = new System.Drawing.Size(139, 20);
            this.txtVoucherNo.TabIndex = 4;
            this.txtVoucherNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVoucherNo_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblPrefix);
            this.groupBox1.Controls.Add(this.lblOrderNo);
            this.groupBox1.Controls.Add(this.lblRefID);
            this.groupBox1.Controls.Add(this.llblSelection);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtStockMID);
            this.groupBox1.Controls.Add(this.dtpChalanDate);
            this.groupBox1.Controls.Add(this.dtpTransDate);
            this.groupBox1.Controls.Add(this.lblChalanNo);
            this.groupBox1.Controls.Add(this.lblChalanDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtChalanNo);
            this.groupBox1.Controls.Add(this.txtCustSupp);
            this.groupBox1.Controls.Add(this.txtVoucherNo);
            this.groupBox1.Controls.Add(this.cboTransType);
            this.groupBox1.Controls.Add(this.lblCustSupp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(292, 69);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(43, 13);
            this.lblPrefix.TabIndex = 18;
            this.lblPrefix.Text = "lblPrefix";
            this.lblPrefix.Visible = false;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.Location = new System.Drawing.Point(607, 116);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(168, 18);
            this.lblOrderNo.TabIndex = 17;
            this.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRefID
            // 
            this.lblRefID.AutoSize = true;
            this.lblRefID.Location = new System.Drawing.Point(449, 118);
            this.lblRefID.Name = "lblRefID";
            this.lblRefID.Size = new System.Drawing.Size(13, 13);
            this.lblRefID.TabIndex = 16;
            this.lblRefID.Text = "0";
            this.lblRefID.Visible = false;
            this.lblRefID.TextChanged += new System.EventHandler(this.lblRefID_TextChanged);
            // 
            // llblSelection
            // 
            this.llblSelection.AutoSize = true;
            this.llblSelection.Location = new System.Drawing.Point(11, 118);
            this.llblSelection.Name = "llblSelection";
            this.llblSelection.Size = new System.Drawing.Size(55, 13);
            this.llblSelection.TabIndex = 7;
            this.llblSelection.TabStop = true;
            this.llblSelection.Text = "Select .....";
            this.llblSelection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSelection_LinkClicked);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(104, 95);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(671, 20);
            this.txtRemarks.TabIndex = 6;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemarks_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Remarks";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStockMID
            // 
            this.txtStockMID.Location = new System.Drawing.Point(292, 42);
            this.txtStockMID.Name = "txtStockMID";
            this.txtStockMID.Size = new System.Drawing.Size(44, 20);
            this.txtStockMID.TabIndex = 7;
            this.txtStockMID.Text = "0";
            this.txtStockMID.Visible = false;
            this.txtStockMID.TextChanged += new System.EventHandler(this.txtStockMID_TextChanged);
            // 
            // dtpChalanDate
            // 
            this.dtpChalanDate.CustomFormat = "dd/MM/yyyy";
            this.dtpChalanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpChalanDate.Location = new System.Drawing.Point(105, 68);
            this.dtpChalanDate.Name = "dtpChalanDate";
            this.dtpChalanDate.Size = new System.Drawing.Size(118, 20);
            this.dtpChalanDate.TabIndex = 2;
            this.dtpChalanDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpChalanDate_KeyDown);
            // 
            // dtpTransDate
            // 
            this.dtpTransDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransDate.Location = new System.Drawing.Point(104, 41);
            this.dtpTransDate.Name = "dtpTransDate";
            this.dtpTransDate.Size = new System.Drawing.Size(118, 20);
            this.dtpTransDate.TabIndex = 1;
            this.dtpTransDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpTransDate_KeyDown);
            // 
            // lblChalanNo
            // 
            this.lblChalanNo.Location = new System.Drawing.Point(381, 71);
            this.lblChalanNo.Name = "lblChalanNo";
            this.lblChalanNo.Size = new System.Drawing.Size(90, 13);
            this.lblChalanNo.TabIndex = 15;
            this.lblChalanNo.Text = "Chalan No.";
            // 
            // lblChalanDate
            // 
            this.lblChalanDate.Location = new System.Drawing.Point(11, 70);
            this.lblChalanDate.Name = "lblChalanDate";
            this.lblChalanDate.Size = new System.Drawing.Size(90, 13);
            this.lblChalanDate.TabIndex = 10;
            this.lblChalanDate.Text = "Chalan Date";
            // 
            // txtChalanNo
            // 
            this.txtChalanNo.BackColor = System.Drawing.Color.White;
            this.txtChalanNo.Location = new System.Drawing.Point(483, 66);
            this.txtChalanNo.Name = "txtChalanNo";
            this.txtChalanNo.Size = new System.Drawing.Size(139, 20);
            this.txtChalanNo.TabIndex = 5;
            this.txtChalanNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChalanNo_KeyDown);
            // 
            // txtCustSupp
            // 
            this.txtCustSupp.Enabled = false;
            this.txtCustSupp.Location = new System.Drawing.Point(483, 15);
            this.txtCustSupp.Name = "txtCustSupp";
            this.txtCustSupp.Size = new System.Drawing.Size(292, 20);
            this.txtCustSupp.TabIndex = 3;
            this.txtCustSupp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustSupp_KeyDown);
            this.txtCustSupp.Enter += new System.EventHandler(this.txtCustSupp_Enter);
            // 
            // lblCustSupp
            // 
            this.lblCustSupp.Location = new System.Drawing.Point(381, 21);
            this.lblCustSupp.Name = "lblCustSupp";
            this.lblCustSupp.Size = new System.Drawing.Size(90, 13);
            this.lblCustSupp.TabIndex = 14;
            this.lblCustSupp.Text = "Customer";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Date";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.chkHitAccount);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnFind);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Location = new System.Drawing.Point(3, 418);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 35);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // chkHitAccount
            // 
            this.chkHitAccount.Enabled = false;
            this.chkHitAccount.Location = new System.Drawing.Point(6, 10);
            this.chkHitAccount.Name = "chkHitAccount";
            this.chkHitAccount.Size = new System.Drawing.Size(117, 20);
            this.chkHitAccount.TabIndex = 107;
            this.chkHitAccount.Text = "Effect to Accounts";
            this.chkHitAccount.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.Location = new System.Drawing.Point(306, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.Location = new System.Drawing.Point(387, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.Control;
            this.btnFind.Location = new System.Drawing.Point(467, 8);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(547, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(626, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(705, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctldgvItems
            // 
            this.ctldgvItems.AllowUserToDeleteRows = false;
            this.ctldgvItems.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctldgvItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctldgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctldgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockDID,
            this.TNature,
            this.ItemID,
            this.CountID,
            this.SizeID,
            this.ColorID,
            this.Specifications,
            this.Budle_Pack_Size,
            this.Budle_Pack_Qty,
            this.OrderQty,
            this.ColAvailQty,
            this.Qty,
            this.Unit,
            this.UnitPrice,
            this.Amount});
            this.ctldgvItems.ContextMenuFields = null;
            this.ctldgvItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ctldgvItems.GridColor = System.Drawing.Color.Silver;
            this.ctldgvItems.isEnterKeyLikeTabKey = true;
            this.ctldgvItems.isExcelSheetCell = false;
            this.ctldgvItems.IsSortable = false;
            this.ctldgvItems.Location = new System.Drawing.Point(3, 140);
            this.ctldgvItems.Margin = new System.Windows.Forms.Padding(0);
            this.ctldgvItems.MultiSelect = false;
            this.ctldgvItems.Name = "ctldgvItems";
            this.ctldgvItems.RowHeadersVisible = false;
            this.ctldgvItems.RowHeadersWidth = 25;
            this.ctldgvItems.RowPointer = 0;
            this.ctldgvItems.RowTemplate.Height = 20;
            this.ctldgvItems.ShowDateTimePicker = false;
            this.ctldgvItems.Size = new System.Drawing.Size(784, 281);
            this.ctldgvItems.TabIndex = 1;
            this.ctldgvItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvItems_CellValueChanged);
            this.ctldgvItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ctldgvItems_EditingControlShowing);
            this.ctldgvItems.AllowUserToAddRowsChanged += new System.EventHandler(this.ctldgvItems_AllowUserToAddRowsChanged);
            this.ctldgvItems.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvItems_CellEnter);
            // 
            // StockDID
            // 
            this.StockDID.HeaderText = "StockDID";
            this.StockDID.Name = "StockDID";
            this.StockDID.Visible = false;
            // 
            // TNature
            // 
            this.TNature.HeaderText = "TransNature";
            this.TNature.Name = "TNature";
            this.TNature.Visible = false;
            // 
            // ItemID
            // 
            this.ItemID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ItemID.HeaderText = "Item";
            this.ItemID.Name = "ItemID";
            // 
            // CountID
            // 
            this.CountID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CountID.HeaderText = "Count";
            this.CountID.Name = "CountID";
            this.CountID.Width = 60;
            // 
            // SizeID
            // 
            this.SizeID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.SizeID.HeaderText = "Size/WT";
            this.SizeID.Name = "SizeID";
            this.SizeID.Width = 80;
            // 
            // ColorID
            // 
            this.ColorID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColorID.HeaderText = "Prd.Type";
            this.ColorID.Name = "ColorID";
            this.ColorID.Width = 70;
            // 
            // Specifications
            // 
            this.Specifications.HeaderText = "Spec.";
            this.Specifications.Name = "Specifications";
            this.Specifications.Width = 85;
            // 
            // Budle_Pack_Size
            // 
            this.Budle_Pack_Size.HeaderText = "Bdl/Pk Size";
            this.Budle_Pack_Size.Name = "Budle_Pack_Size";
            this.Budle_Pack_Size.Width = 90;
            // 
            // Budle_Pack_Qty
            // 
            this.Budle_Pack_Qty.HeaderText = "Bdl/Pk Qty";
            this.Budle_Pack_Qty.Name = "Budle_Pack_Qty";
            this.Budle_Pack_Qty.Width = 90;
            // 
            // OrderQty
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0.0";
            this.OrderQty.DefaultCellStyle = dataGridViewCellStyle1;
            this.OrderQty.HeaderText = "Order Qty";
            this.OrderQty.Name = "OrderQty";
            this.OrderQty.ReadOnly = true;
            this.OrderQty.Width = 80;
            // 
            // ColAvailQty
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.ColAvailQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColAvailQty.HeaderText = "Avail Qty";
            this.ColAvailQty.Name = "ColAvailQty";
            this.ColAvailQty.ReadOnly = true;
            this.ColAvailQty.Width = 85;
            // 
            // Qty
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.Qty.DefaultCellStyle = dataGridViewCellStyle3;
            this.Qty.HeaderText = "Trans. Qty";
            this.Qty.Name = "Qty";
            this.Qty.Width = 85;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 55;
            // 
            // UnitPrice
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0.00";
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.UnitPrice.HeaderText = "UnitPrice";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.Width = 70;
            // 
            // Amount
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0.00";
            this.Amount.DefaultCellStyle = dataGridViewCellStyle5;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 70;
            // 
            // frmStockInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(790, 460);
            this.Controls.Add(this.ctldgvItems);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStockInOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock In Out";
            this.Load += new System.EventHandler(this.frmStockInOut_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmStockInOut_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStockInOut_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTransType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpTransDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpChalanDate;
        private System.Windows.Forms.Label lblChalanNo;
        private System.Windows.Forms.Label lblChalanDate;
        private System.Windows.Forms.TextBox txtChalanNo;
        private System.Windows.Forms.TextBox txtCustSupp;
        private System.Windows.Forms.Label lblCustSupp;
        private Accounting.Controls.ctlDaraGridView ctldgvItems;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtStockMID;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel llblSelection;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblRefID;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.CheckBox chkHitAccount;
        private System.Windows.Forms.Label lblPrefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockDID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TNature;
        private System.Windows.Forms.DataGridViewComboBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewComboBoxColumn CountID;
        private System.Windows.Forms.DataGridViewComboBoxColumn SizeID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Specifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn Budle_Pack_Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Budle_Pack_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAvailQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}