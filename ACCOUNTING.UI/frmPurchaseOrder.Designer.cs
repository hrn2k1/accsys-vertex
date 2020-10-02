namespace Accounting.UI
{
    partial class frmPurchaseOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxPO = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rtxtBuyer_ref = new System.Windows.Forms.RichTextBox();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.llblItems = new System.Windows.Forms.LinkLabel();
            this.txtPOID = new System.Windows.Forms.TextBox();
            this.txtsupplierID = new System.Windows.Forms.TextBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.txtTotalAmt = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTtlValue = new System.Windows.Forms.TextBox();
            this.ctltxtTotalAValue = new Accounting.Controls.ctlNum();
            this.label8 = new System.Windows.Forms.Label();
            this.ctltxtTotalAQty = new Accounting.Controls.ctlNum();
            this.txtTtlQty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAmend = new System.Windows.Forms.Button();
            this.lblAmendDate = new System.Windows.Forms.Label();
            this.dtpAmendDate = new System.Windows.Forms.DateTimePicker();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtAmendmentComment = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFindAmendment = new System.Windows.Forms.Button();
            this.pAmend = new System.Windows.Forms.GroupBox();
            this.ctldgvOrderItems = new Accounting.Controls.ctlDaraGridView();
            this.colOMID = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colODID = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colItem = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colColorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLabdip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxPO.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pAmend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxPO
            // 
            this.gbxPO.BackColor = System.Drawing.Color.Transparent;
            this.gbxPO.Controls.Add(this.label11);
            this.gbxPO.Controls.Add(this.rtxtBuyer_ref);
            this.gbxPO.Controls.Add(this.cmbCurrency);
            this.gbxPO.Controls.Add(this.label10);
            this.gbxPO.Controls.Add(this.llblItems);
            this.gbxPO.Controls.Add(this.txtPOID);
            this.gbxPO.Controls.Add(this.txtsupplierID);
            this.gbxPO.Controls.Add(this.txtSupplier);
            this.gbxPO.Controls.Add(this.txtOrderNo);
            this.gbxPO.Controls.Add(this.dtpOrderDate);
            this.gbxPO.Controls.Add(this.label3);
            this.gbxPO.Controls.Add(this.label2);
            this.gbxPO.Controls.Add(this.label1);
            this.gbxPO.Location = new System.Drawing.Point(7, 5);
            this.gbxPO.Name = "gbxPO";
            this.gbxPO.Size = new System.Drawing.Size(776, 108);
            this.gbxPO.TabIndex = 0;
            this.gbxPO.TabStop = false;
            this.gbxPO.Text = "Purchase Order";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Buyer Ref.";
            // 
            // rtxtBuyer_ref
            // 
            this.rtxtBuyer_ref.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtBuyer_ref.Location = new System.Drawing.Point(105, 61);
            this.rtxtBuyer_ref.Name = "rtxtBuyer_ref";
            this.rtxtBuyer_ref.Size = new System.Drawing.Size(594, 28);
            this.rtxtBuyer_ref.TabIndex = 4;
            this.rtxtBuyer_ref.Text = "";
            this.rtxtBuyer_ref.Enter += new System.EventHandler(this.txtSupplier_Enter);
            this.rtxtBuyer_ref.Leave += new System.EventHandler(this.txtSupplier_Leave);
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(518, 38);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(181, 21);
            this.cmbCurrency.TabIndex = 3;
            this.cmbCurrency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCurrency_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(456, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Currency";
            // 
            // llblItems
            // 
            this.llblItems.AutoSize = true;
            this.llblItems.Location = new System.Drawing.Point(119, 92);
            this.llblItems.Name = "llblItems";
            this.llblItems.Size = new System.Drawing.Size(109, 13);
            this.llblItems.TabIndex = 5;
            this.llblItems.TabStop = true;
            this.llblItems.Text = "Select Items for Order";
            this.llblItems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblItems_LinkClicked);
            // 
            // txtPOID
            // 
            this.txtPOID.Location = new System.Drawing.Point(313, 35);
            this.txtPOID.Name = "txtPOID";
            this.txtPOID.ReadOnly = true;
            this.txtPOID.Size = new System.Drawing.Size(61, 20);
            this.txtPOID.TabIndex = 7;
            this.txtPOID.TabStop = false;
            this.txtPOID.Text = "0";
            this.txtPOID.Visible = false;
            // 
            // txtsupplierID
            // 
            this.txtsupplierID.Location = new System.Drawing.Point(313, 13);
            this.txtsupplierID.Name = "txtsupplierID";
            this.txtsupplierID.ReadOnly = true;
            this.txtsupplierID.Size = new System.Drawing.Size(38, 20);
            this.txtsupplierID.TabIndex = 6;
            this.txtsupplierID.TabStop = false;
            this.txtsupplierID.Text = "0";
            this.txtsupplierID.Visible = false;
            this.txtsupplierID.TextChanged += new System.EventHandler(this.txtsupplierID_TextChanged);
            // 
            // txtSupplier
            // 
            this.txtSupplier.BackColor = System.Drawing.Color.White;
            this.txtSupplier.Location = new System.Drawing.Point(105, 13);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.ReadOnly = true;
            this.txtSupplier.Size = new System.Drawing.Size(195, 20);
            this.txtSupplier.TabIndex = 0;
            this.txtSupplier.DoubleClick += new System.EventHandler(this.txtSupplier_DoubleClick);
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplier_KeyDown);
            this.txtSupplier.Leave += new System.EventHandler(this.txtSupplier_Leave);
            this.txtSupplier.Enter += new System.EventHandler(this.txtSupplier_Enter);
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Location = new System.Drawing.Point(104, 35);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(195, 20);
            this.txtOrderNo.TabIndex = 2;
            this.txtOrderNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpOrderDate_KeyDown);
            this.txtOrderNo.Leave += new System.EventHandler(this.txtSupplier_Leave);
            this.txtOrderNo.Enter += new System.EventHandler(this.txtSupplier_Enter);
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.CustomFormat = "dd/MM/yyyy";
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderDate.Location = new System.Drawing.Point(518, 13);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(181, 20);
            this.dtpOrderDate.TabIndex = 1;
            this.dtpOrderDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpOrderDate_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(29, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Order No.";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(447, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Order Date";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(29, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Supplier";
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(310, 435);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(89, 23);
            this.btnDeleteOrder.TabIndex = 5;
            this.btnDeleteOrder.TabStop = false;
            this.btnDeleteOrder.Text = "Delete &Order";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDelOrder_Click);
            // 
            // txtTotalAmt
            // 
            this.txtTotalAmt.Location = new System.Drawing.Point(180, 10);
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.ReadOnly = true;
            this.txtTotalAmt.Size = new System.Drawing.Size(72, 20);
            this.txtTotalAmt.TabIndex = 3;
            this.txtTotalAmt.TabStop = false;
            this.txtTotalAmt.Text = "0.00";
            this.txtTotalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(131, 434);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(89, 23);
            this.btnNew.TabIndex = 6;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "&Reset";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            this.btnNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Odr Value";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(47, 10);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(72, 20);
            this.txtTotalQty.TabIndex = 1;
            this.txtTotalQty.TabStop = false;
            this.txtTotalQty.Text = "0.00";
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalQty.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Odr Qty";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(222, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(402, 435);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "&Delete Item";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(495, 435);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(88, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.TabStop = false;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            this.btnFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(721, 434);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtTtlValue);
            this.groupBox1.Controls.Add(this.ctltxtTotalAValue);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ctltxtTotalAQty);
            this.groupBox1.Controls.Add(this.txtTtlQty);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTotalAmt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTotalQty);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(3, 355);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 34);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // txtTtlValue
            // 
            this.txtTtlValue.Location = new System.Drawing.Point(698, 12);
            this.txtTtlValue.Name = "txtTtlValue";
            this.txtTtlValue.ReadOnly = true;
            this.txtTtlValue.Size = new System.Drawing.Size(72, 20);
            this.txtTtlValue.TabIndex = 11;
            this.txtTtlValue.TabStop = false;
            this.txtTtlValue.Text = "0.00";
            this.txtTtlValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ctltxtTotalAValue
            // 
            this.ctltxtTotalAValue.BackgroudColor = System.Drawing.SystemColors.Control;
            this.ctltxtTotalAValue.Location = new System.Drawing.Point(443, 14);
            this.ctltxtTotalAValue.Name = "ctltxtTotalAValue";
            this.ctltxtTotalAValue.ReadOnly = true;
            this.ctltxtTotalAValue.Size = new System.Drawing.Size(72, 20);
            this.ctltxtTotalAValue.TabIndex = 7;
            this.ctltxtTotalAValue.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctltxtTotalAValue.Value = 0;
            this.ctltxtTotalAValue.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctltxtTotalAQty_valueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(640, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Ttl Value";
            // 
            // ctltxtTotalAQty
            // 
            this.ctltxtTotalAQty.BackgroudColor = System.Drawing.SystemColors.Control;
            this.ctltxtTotalAQty.Location = new System.Drawing.Point(306, 13);
            this.ctltxtTotalAQty.Name = "ctltxtTotalAQty";
            this.ctltxtTotalAQty.ReadOnly = true;
            this.ctltxtTotalAQty.Size = new System.Drawing.Size(72, 20);
            this.ctltxtTotalAQty.TabIndex = 5;
            this.ctltxtTotalAQty.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctltxtTotalAQty.Value = 0;
            this.ctltxtTotalAQty.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctltxtTotalAQty_valueChanged);
            // 
            // txtTtlQty
            // 
            this.txtTtlQty.Location = new System.Drawing.Point(563, 12);
            this.txtTtlQty.Name = "txtTtlQty";
            this.txtTtlQty.ReadOnly = true;
            this.txtTtlQty.Size = new System.Drawing.Size(72, 20);
            this.txtTtlQty.TabIndex = 9;
            this.txtTtlQty.TabStop = false;
            this.txtTtlQty.Text = "0.00";
            this.txtTtlQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(382, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Amd Value";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(519, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Ttl Qty";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Amd Qty";
            // 
            // btnAmend
            // 
            this.btnAmend.Location = new System.Drawing.Point(587, 434);
            this.btnAmend.Name = "btnAmend";
            this.btnAmend.Size = new System.Drawing.Size(128, 23);
            this.btnAmend.TabIndex = 5;
            this.btnAmend.Text = "&Amendment";
            this.btnAmend.UseVisualStyleBackColor = true;
            this.btnAmend.Click += new System.EventHandler(this.btnAmend_Click);
            // 
            // lblAmendDate
            // 
            this.lblAmendDate.AutoSize = true;
            this.lblAmendDate.Location = new System.Drawing.Point(10, 18);
            this.lblAmendDate.Name = "lblAmendDate";
            this.lblAmendDate.Size = new System.Drawing.Size(30, 13);
            this.lblAmendDate.TabIndex = 3;
            this.lblAmendDate.Text = "Date";
            // 
            // dtpAmendDate
            // 
            this.dtpAmendDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAmendDate.Location = new System.Drawing.Point(54, 14);
            this.dtpAmendDate.Name = "dtpAmendDate";
            this.dtpAmendDate.Size = new System.Drawing.Size(97, 20);
            this.dtpAmendDate.TabIndex = 2;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(166, 18);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 4;
            this.lblComment.Text = "Comment";
            // 
            // txtAmendmentComment
            // 
            this.txtAmendmentComment.Location = new System.Drawing.Point(226, 15);
            this.txtAmendmentComment.Name = "txtAmendmentComment";
            this.txtAmendmentComment.Size = new System.Drawing.Size(430, 20);
            this.txtAmendmentComment.TabIndex = 0;
            this.txtAmendmentComment.Leave += new System.EventHandler(this.txtSupplier_Leave);
            this.txtAmendmentComment.Enter += new System.EventHandler(this.txtSupplier_Enter);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(665, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFindAmendment
            // 
            this.btnFindAmendment.Enabled = false;
            this.btnFindAmendment.Location = new System.Drawing.Point(5, 433);
            this.btnFindAmendment.Name = "btnFindAmendment";
            this.btnFindAmendment.Size = new System.Drawing.Size(124, 23);
            this.btnFindAmendment.TabIndex = 7;
            this.btnFindAmendment.Text = "Find Amendment";
            this.btnFindAmendment.UseVisualStyleBackColor = true;
            this.btnFindAmendment.Click += new System.EventHandler(this.btnFindAmendment_Click);
            // 
            // pAmend
            // 
            this.pAmend.BackColor = System.Drawing.Color.Transparent;
            this.pAmend.Controls.Add(this.btnCancel);
            this.pAmend.Controls.Add(this.txtAmendmentComment);
            this.pAmend.Controls.Add(this.lblAmendDate);
            this.pAmend.Controls.Add(this.dtpAmendDate);
            this.pAmend.Controls.Add(this.lblComment);
            this.pAmend.Enabled = false;
            this.pAmend.Location = new System.Drawing.Point(3, 393);
            this.pAmend.Name = "pAmend";
            this.pAmend.Size = new System.Drawing.Size(780, 38);
            this.pAmend.TabIndex = 8;
            this.pAmend.TabStop = false;
            this.pAmend.Text = "Amendment";
            // 
            // ctldgvOrderItems
            // 
            this.ctldgvOrderItems.AllowUserToDeleteRows = false;
            this.ctldgvOrderItems.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctldgvOrderItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctldgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctldgvOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOMID,
            this.colODID,
            this.colItem,
            this.colCount,
            this.colSize,
            this.colColor,
            this.colColorCode,
            this.colLabdip,
            this.colQty,
            this.colUnit,
            this.colUnitPrice,
            this.colAmount,
            this.colCQty});
            this.ctldgvOrderItems.ContextMenuFields = null;
            this.ctldgvOrderItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ctldgvOrderItems.IsSortable = false;
            this.ctldgvOrderItems.Location = new System.Drawing.Point(7, 122);
            this.ctldgvOrderItems.Name = "ctldgvOrderItems";
            this.ctldgvOrderItems.RowHeadersWidth = 25;
            this.ctldgvOrderItems.RowPointer = 0;
            this.ctldgvOrderItems.ShowDateTimePicker = true;
            this.ctldgvOrderItems.Size = new System.Drawing.Size(776, 237);
            this.ctldgvOrderItems.TabIndex = 1;
            this.ctldgvOrderItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvOrderItems_CellValueChanged);
            this.ctldgvOrderItems.DoubleClick += new System.EventHandler(this.ctldgvOrderItems_DoubleClick);
            this.ctldgvOrderItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvOrderItems_CellClick);
            this.ctldgvOrderItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ctldgvOrderItems_EditingControlShowing);
            this.ctldgvOrderItems.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvOrderItems_CellEnter);
            this.ctldgvOrderItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvOrderItems_CellContentClick);
            // 
            // colOMID
            // 
            this.colOMID.HeaderText = "OMID";
            this.colOMID.Name = "colOMID";
            this.colOMID.Visible = false;
            // 
            // colODID
            // 
            this.colODID.HeaderText = "ODID";
            this.colODID.Name = "colODID";
            this.colODID.Visible = false;
            // 
            // colItem
            // 
            this.colItem.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colItem.HeaderText = "Item";
            this.colItem.Name = "colItem";
            // 
            // colCount
            // 
            this.colCount.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colCount.HeaderText = "Count";
            this.colCount.Name = "colCount";
            this.colCount.Width = 70;
            // 
            // colSize
            // 
            this.colSize.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.Width = 70;
            // 
            // colColor
            // 
            this.colColor.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colColor.HeaderText = "Prod.Type";
            this.colColor.Name = "colColor";
            this.colColor.Width = 70;
            // 
            // colColorCode
            // 
            this.colColorCode.HeaderText = "ColorCode";
            this.colColorCode.Name = "colColorCode";
            this.colColorCode.Width = 70;
            // 
            // colLabdip
            // 
            this.colLabdip.HeaderText = "Labdip";
            this.colLabdip.Name = "colLabdip";
            this.colLabdip.Width = 70;
            // 
            // colQty
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0.00";
            this.colQty.DefaultCellStyle = dataGridViewCellStyle10;
            this.colQty.HeaderText = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Width = 70;
            // 
            // colUnit
            // 
            this.colUnit.HeaderText = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            this.colUnit.Width = 70;
            // 
            // colUnitPrice
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = "0.00";
            this.colUnitPrice.DefaultCellStyle = dataGridViewCellStyle11;
            this.colUnitPrice.HeaderText = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Width = 70;
            // 
            // colAmount
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = "0.00";
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle12;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colCQty
            // 
            this.colCQty.HeaderText = "C.Qty";
            this.colCQty.Name = "colCQty";
            this.colCQty.Width = 50;
            // 
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 461);
            this.Controls.Add(this.pAmend);
            this.Controls.Add(this.btnFindAmendment);
            this.Controls.Add(this.btnAmend);
            this.Controls.Add(this.ctldgvOrderItems);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbxPO);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Purchase Order";
            this.Load += new System.EventHandler(this.frmPurchaseOrder_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPurchaseOrder_Paint);
            this.gbxPO.ResumeLayout(false);
            this.gbxPO.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pAmend.ResumeLayout(false);
            this.pAmend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvOrderItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxPO;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSupplier;
        private Accounting.Controls.ctlDaraGridView ctldgvOrderItems;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtsupplierID;
        private System.Windows.Forms.TextBox txtTotalAmt;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPOID;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.LinkLabel llblItems;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAmend;
        private System.Windows.Forms.DateTimePicker dtpAmendDate;
        private System.Windows.Forms.Label lblAmendDate;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtAmendmentComment;
        private System.Windows.Forms.Button btnFindAmendment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Accounting.Controls.ctlNum ctltxtTotalAValue;
        private Accounting.Controls.ctlNum ctltxtTotalAQty;
        private System.Windows.Forms.GroupBox pAmend;
        private System.Windows.Forms.TextBox txtTtlValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTtlQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox rtxtBuyer_ref;
        private System.Windows.Forms.DataGridViewButtonColumn colOMID;
        private System.Windows.Forms.DataGridViewButtonColumn colODID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCount;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSize;
        private System.Windows.Forms.DataGridViewComboBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLabdip;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCQty;
    }
}