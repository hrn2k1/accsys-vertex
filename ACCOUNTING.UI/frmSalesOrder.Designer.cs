namespace Accounting.UI
{
    partial class frmSalesOrder
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
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.lblLedgerNo = new System.Windows.Forms.Label();
            this.txtLedgerNo = new System.Windows.Forms.TextBox();
            this.txtTotalOrderQty = new System.Windows.Forms.TextBox();
            this.lblTotalOrderQty = new System.Windows.Forms.Label();
            this.txtTotalOrderVal = new System.Windows.Forms.TextBox();
            this.lblTotalOrderValue = new System.Windows.Forms.Label();
            this.lblFactoryName = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.cmbFactoryName = new System.Windows.Forms.ComboBox();
            this.gbSalesOrder = new System.Windows.Forms.GroupBox();
            this.ctlNumRate = new Accounting.Controls.ctlNum();
            this.rtxtBuyer_ref = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.llblItems = new System.Windows.Forms.LinkLabel();
            this.txtOrderMID = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblUnit = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTtlQty = new System.Windows.Forms.TextBox();
            this.txtTtlValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnFindAmendment = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalAQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAmend = new System.Windows.Forms.Button();
            this.txtTotalAValue = new System.Windows.Forms.TextBox();
            this.btnDeleteItems = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvOrderDetails = new Accounting.Controls.ctlDaraGridView();
            this.colOMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colODID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItem = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colColorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLabdip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pAmend = new System.Windows.Forms.GroupBox();
            this.dtpAmendDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itmPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.gbSalesOrder.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.pAmend.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(91, 9);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(216, 20);
            this.txtCustomer.TabIndex = 0;
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            this.txtCustomer.Leave += new System.EventHandler(this.txtCustomer_Leave);
            this.txtCustomer.Enter += new System.EventHandler(this.txtCustomer_Enter);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(10, 16);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 16;
            this.lblCustomer.Text = "Customer";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Location = new System.Drawing.Point(10, 41);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(50, 13);
            this.lblOrderNo.TabIndex = 17;
            this.lblOrderNo.Text = "Order No";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Location = new System.Drawing.Point(91, 34);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(159, 20);
            this.txtOrderNo.TabIndex = 1;
            this.txtOrderNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderNo_KeyDown);
            this.txtOrderNo.Leave += new System.EventHandler(this.txtOrderNo_Leave);
            this.txtOrderNo.Enter += new System.EventHandler(this.txtOrderNo_Enter);
            // 
            // lblLedgerNo
            // 
            this.lblLedgerNo.AutoSize = true;
            this.lblLedgerNo.Location = new System.Drawing.Point(10, 67);
            this.lblLedgerNo.Name = "lblLedgerNo";
            this.lblLedgerNo.Size = new System.Drawing.Size(57, 13);
            this.lblLedgerNo.TabIndex = 18;
            this.lblLedgerNo.Text = "Ledger No";
            // 
            // txtLedgerNo
            // 
            this.txtLedgerNo.Location = new System.Drawing.Point(91, 60);
            this.txtLedgerNo.Name = "txtLedgerNo";
            this.txtLedgerNo.Size = new System.Drawing.Size(159, 20);
            this.txtLedgerNo.TabIndex = 2;
            this.txtLedgerNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLedgerNo_KeyDown);
            this.txtLedgerNo.Leave += new System.EventHandler(this.txtLedgerNo_Leave);
            this.txtLedgerNo.Enter += new System.EventHandler(this.txtLedgerNo_Enter);
            // 
            // txtTotalOrderQty
            // 
            this.txtTotalOrderQty.Location = new System.Drawing.Point(48, 249);
            this.txtTotalOrderQty.Name = "txtTotalOrderQty";
            this.txtTotalOrderQty.ReadOnly = true;
            this.txtTotalOrderQty.Size = new System.Drawing.Size(72, 20);
            this.txtTotalOrderQty.TabIndex = 7;
            this.txtTotalOrderQty.Text = "0.00";
            this.txtTotalOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalOrderQty.TextChanged += new System.EventHandler(this.txtTotalOrderQty_TextChanged);
            // 
            // lblTotalOrderQty
            // 
            this.lblTotalOrderQty.AutoSize = true;
            this.lblTotalOrderQty.Location = new System.Drawing.Point(2, 252);
            this.lblTotalOrderQty.Name = "lblTotalOrderQty";
            this.lblTotalOrderQty.Size = new System.Drawing.Size(43, 13);
            this.lblTotalOrderQty.TabIndex = 24;
            this.lblTotalOrderQty.Text = "Odr Qty";
            // 
            // txtTotalOrderVal
            // 
            this.txtTotalOrderVal.Location = new System.Drawing.Point(180, 248);
            this.txtTotalOrderVal.Name = "txtTotalOrderVal";
            this.txtTotalOrderVal.ReadOnly = true;
            this.txtTotalOrderVal.Size = new System.Drawing.Size(72, 20);
            this.txtTotalOrderVal.TabIndex = 8;
            this.txtTotalOrderVal.Text = "0.00";
            this.txtTotalOrderVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalOrderVal.TextChanged += new System.EventHandler(this.txtTotalOrderQty_TextChanged);
            // 
            // lblTotalOrderValue
            // 
            this.lblTotalOrderValue.AutoSize = true;
            this.lblTotalOrderValue.Location = new System.Drawing.Point(123, 252);
            this.lblTotalOrderValue.Name = "lblTotalOrderValue";
            this.lblTotalOrderValue.Size = new System.Drawing.Size(54, 13);
            this.lblTotalOrderValue.TabIndex = 25;
            this.lblTotalOrderValue.Text = "Odr Value";
            // 
            // lblFactoryName
            // 
            this.lblFactoryName.AutoSize = true;
            this.lblFactoryName.Location = new System.Drawing.Point(441, 80);
            this.lblFactoryName.Name = "lblFactoryName";
            this.lblFactoryName.Size = new System.Drawing.Size(73, 13);
            this.lblFactoryName.TabIndex = 23;
            this.lblFactoryName.Text = "Factory Name";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(526, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(106, 20);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker1_KeyDown);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(526, 33);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(106, 20);
            this.dateTimePicker2.TabIndex = 4;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            this.dateTimePicker2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker2_KeyDown);
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(441, 14);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(59, 13);
            this.lblOrderDate.TabIndex = 21;
            this.lblOrderDate.Text = "Order Date";
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Location = new System.Drawing.Point(441, 37);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(71, 13);
            this.lblDeliveryDate.TabIndex = 22;
            this.lblDeliveryDate.Text = "Delivery Date";
            // 
            // cmbFactoryName
            // 
            this.cmbFactoryName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFactoryName.FormattingEnabled = true;
            this.cmbFactoryName.Location = new System.Drawing.Point(526, 77);
            this.cmbFactoryName.Name = "cmbFactoryName";
            this.cmbFactoryName.Size = new System.Drawing.Size(224, 21);
            this.cmbFactoryName.TabIndex = 7;
            this.cmbFactoryName.Enter += new System.EventHandler(this.cmbFactoryName_Enter);
            this.cmbFactoryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbFactoryName_KeyDown);
            // 
            // gbSalesOrder
            // 
            this.gbSalesOrder.BackColor = System.Drawing.Color.Transparent;
            this.gbSalesOrder.Controls.Add(this.ctlNumRate);
            this.gbSalesOrder.Controls.Add(this.rtxtBuyer_ref);
            this.gbSalesOrder.Controls.Add(this.label9);
            this.gbSalesOrder.Controls.Add(this.label8);
            this.gbSalesOrder.Controls.Add(this.label7);
            this.gbSalesOrder.Controls.Add(this.llblItems);
            this.gbSalesOrder.Controls.Add(this.txtOrderMID);
            this.gbSalesOrder.Controls.Add(this.txtCustomerID);
            this.gbSalesOrder.Controls.Add(this.cmbCurrency);
            this.gbSalesOrder.Controls.Add(this.cmbFactoryName);
            this.gbSalesOrder.Controls.Add(this.txtCustomer);
            this.gbSalesOrder.Controls.Add(this.dateTimePicker2);
            this.gbSalesOrder.Controls.Add(this.dateTimePicker1);
            this.gbSalesOrder.Controls.Add(this.label12);
            this.gbSalesOrder.Controls.Add(this.txtLedgerNo);
            this.gbSalesOrder.Controls.Add(this.lblCustomer);
            this.gbSalesOrder.Controls.Add(this.lblLedgerNo);
            this.gbSalesOrder.Controls.Add(this.lblOrderDate);
            this.gbSalesOrder.Controls.Add(this.txtOrderNo);
            this.gbSalesOrder.Controls.Add(this.lblDeliveryDate);
            this.gbSalesOrder.Controls.Add(this.lblOrderNo);
            this.gbSalesOrder.Controls.Add(this.lblFactoryName);
            this.gbSalesOrder.Location = new System.Drawing.Point(6, 5);
            this.gbSalesOrder.Name = "gbSalesOrder";
            this.gbSalesOrder.Size = new System.Drawing.Size(777, 135);
            this.gbSalesOrder.TabIndex = 0;
            this.gbSalesOrder.TabStop = false;
            this.gbSalesOrder.Text = "SalesOrder";
            // 
            // ctlNumRate
            // 
            this.ctlNumRate.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumRate.Location = new System.Drawing.Point(680, 54);
            this.ctlNumRate.Name = "ctlNumRate";
            this.ctlNumRate.ReadOnly = false;
            this.ctlNumRate.Size = new System.Drawing.Size(70, 20);
            this.ctlNumRate.TabIndex = 6;
            this.ctlNumRate.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumRate.Value = 1;
            // 
            // rtxtBuyer_ref
            // 
            this.rtxtBuyer_ref.Location = new System.Drawing.Point(91, 86);
            this.rtxtBuyer_ref.Name = "rtxtBuyer_ref";
            this.rtxtBuyer_ref.Size = new System.Drawing.Size(301, 43);
            this.rtxtBuyer_ref.TabIndex = 8;
            this.rtxtBuyer_ref.Text = "";
            this.rtxtBuyer_ref.Enter += new System.EventHandler(this.rtxtBuyer_ref_Enter);
            this.rtxtBuyer_ref.Leave += new System.EventHandler(this.rtxtBuyer_ref_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 106;
            this.label9.Text = "Buyer Ref.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(638, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 103;
            this.label8.Text = "Rate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(441, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 102;
            this.label7.Text = "Currency";
            // 
            // llblItems
            // 
            this.llblItems.AutoSize = true;
            this.llblItems.Location = new System.Drawing.Point(443, 102);
            this.llblItems.Name = "llblItems";
            this.llblItems.Size = new System.Drawing.Size(109, 13);
            this.llblItems.TabIndex = 9;
            this.llblItems.TabStop = true;
            this.llblItems.Text = "Select Items for Order";
            this.llblItems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblItems_LinkClicked);
            // 
            // txtOrderMID
            // 
            this.txtOrderMID.Location = new System.Drawing.Point(63, 39);
            this.txtOrderMID.Name = "txtOrderMID";
            this.txtOrderMID.Size = new System.Drawing.Size(22, 20);
            this.txtOrderMID.TabIndex = 101;
            this.txtOrderMID.Visible = false;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(63, 9);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(22, 20);
            this.txtCustomerID.TabIndex = 100;
            this.txtCustomerID.Visible = false;
            this.txtCustomerID.TextChanged += new System.EventHandler(this.txtCustomerID_TextChanged);
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(526, 54);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(106, 21);
            this.cmbCurrency.TabIndex = 5;
            this.cmbCurrency.Enter += new System.EventHandler(this.cmbFactoryName_Enter);
            this.cmbCurrency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbFactoryName_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(-27, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Unit";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.Location = new System.Drawing.Point(209, 303);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 24);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnReset_KeyDown);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(-1, 309);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(26, 13);
            this.lblUnit.TabIndex = 26;
            this.lblUnit.Text = "Unit";
            this.lblUnit.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTtlQty);
            this.groupBox1.Controls.Add(this.txtTtlValue);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnFindAmendment);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTotalAQty);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnAmend);
            this.groupBox1.Controls.Add(this.txtTotalAValue);
            this.groupBox1.Controls.Add(this.btnDeleteItems);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.dgvOrderDetails);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.lblTotalOrderQty);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtTotalOrderQty);
            this.groupBox1.Controls.Add(this.txtTotalOrderVal);
            this.groupBox1.Controls.Add(this.lblUnit);
            this.groupBox1.Controls.Add(this.lblTotalOrderValue);
            this.groupBox1.Controls.Add(this.pAmend);
            this.groupBox1.Location = new System.Drawing.Point(4, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(779, 333);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(516, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Ttl Qty";
            // 
            // txtTtlQty
            // 
            this.txtTtlQty.Location = new System.Drawing.Point(562, 248);
            this.txtTtlQty.Name = "txtTtlQty";
            this.txtTtlQty.ReadOnly = true;
            this.txtTtlQty.Size = new System.Drawing.Size(72, 20);
            this.txtTtlQty.TabIndex = 30;
            this.txtTtlQty.Text = "0.00";
            this.txtTtlQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTtlValue
            // 
            this.txtTtlValue.Location = new System.Drawing.Point(694, 247);
            this.txtTtlValue.Name = "txtTtlValue";
            this.txtTtlValue.ReadOnly = true;
            this.txtTtlValue.Size = new System.Drawing.Size(72, 20);
            this.txtTtlValue.TabIndex = 31;
            this.txtTtlValue.Text = "0.00";
            this.txtTtlValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(637, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Ttl Value";
            // 
            // btnFindAmendment
            // 
            this.btnFindAmendment.BackColor = System.Drawing.SystemColors.Control;
            this.btnFindAmendment.Enabled = false;
            this.btnFindAmendment.Location = new System.Drawing.Point(29, 303);
            this.btnFindAmendment.Name = "btnFindAmendment";
            this.btnFindAmendment.Size = new System.Drawing.Size(106, 24);
            this.btnFindAmendment.TabIndex = 29;
            this.btnFindAmendment.Text = "Find Amendment";
            this.btnFindAmendment.UseVisualStyleBackColor = false;
            this.btnFindAmendment.Click += new System.EventHandler(this.btnFindAmendment_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Amd Qty";
            // 
            // txtTotalAQty
            // 
            this.txtTotalAQty.Location = new System.Drawing.Point(305, 248);
            this.txtTotalAQty.Name = "txtTotalAQty";
            this.txtTotalAQty.ReadOnly = true;
            this.txtTotalAQty.Size = new System.Drawing.Size(72, 20);
            this.txtTotalAQty.TabIndex = 8;
            this.txtTotalAQty.Text = "0.00";
            this.txtTotalAQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAQty.TextChanged += new System.EventHandler(this.txtTotalOrderQty_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Amd Value";
            // 
            // btnAmend
            // 
            this.btnAmend.BackColor = System.Drawing.SystemColors.Control;
            this.btnAmend.Location = new System.Drawing.Point(581, 303);
            this.btnAmend.Name = "btnAmend";
            this.btnAmend.Size = new System.Drawing.Size(116, 24);
            this.btnAmend.TabIndex = 27;
            this.btnAmend.Text = "&Amendment";
            this.btnAmend.UseVisualStyleBackColor = false;
            this.btnAmend.Click += new System.EventHandler(this.btnAmend_Click);
            // 
            // txtTotalAValue
            // 
            this.txtTotalAValue.Location = new System.Drawing.Point(441, 249);
            this.txtTotalAValue.Name = "txtTotalAValue";
            this.txtTotalAValue.ReadOnly = true;
            this.txtTotalAValue.Size = new System.Drawing.Size(72, 20);
            this.txtTotalAValue.TabIndex = 9;
            this.txtTotalAValue.Text = "0.00";
            this.txtTotalAValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAValue.TextChanged += new System.EventHandler(this.txtTotalOrderQty_TextChanged);
            // 
            // btnDeleteItems
            // 
            this.btnDeleteItems.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteItems.Location = new System.Drawing.Point(357, 303);
            this.btnDeleteItems.Name = "btnDeleteItems";
            this.btnDeleteItems.Size = new System.Drawing.Size(75, 24);
            this.btnDeleteItems.TabIndex = 13;
            this.btnDeleteItems.Text = "Del.Items";
            this.btnDeleteItems.UseVisualStyleBackColor = false;
            this.btnDeleteItems.Click += new System.EventHandler(this.btnDeleteItems_Click);
            this.btnDeleteItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDeleteItems_KeyDown);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.Location = new System.Drawing.Point(135, 303);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 24);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btnPrint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnPrint_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(431, 303);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 24);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDelete_KeyDown);
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.AllowUserToDeleteRows = false;
            this.dgvOrderDetails.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.colAmt,
            this.colRemarks});
            this.dgvOrderDetails.ContextMenuFields = null;
            this.dgvOrderDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvOrderDetails.IsSortable = false;
            this.dgvOrderDetails.Location = new System.Drawing.Point(6, 14);
            this.dgvOrderDetails.MultiSelect = false;
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.RowHeadersWidth = 25;
            this.dgvOrderDetails.RowPointer = 0;
            this.dgvOrderDetails.ShowDateTimePicker = true;
            this.dgvOrderDetails.Size = new System.Drawing.Size(766, 229);
            this.dgvOrderDetails.TabIndex = 10;
            this.dgvOrderDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderDetails_CellValueChanged);
            this.dgvOrderDetails.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvOrderDetails_EditingControlShowing);
            this.dgvOrderDetails.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderDetails_CellEnter);
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
            // colAmt
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = "0.00";
            this.colAmt.DefaultCellStyle = dataGridViewCellStyle12;
            this.colAmt.HeaderText = "Amount";
            this.colAmt.Name = "colAmt";
            this.colAmt.ReadOnly = true;
            // 
            // colRemarks
            // 
            this.colRemarks.HeaderText = "C.Qty";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.Width = 50;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(697, 303);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.Control;
            this.btnFind.Location = new System.Drawing.Point(505, 303);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 24);
            this.btnFind.TabIndex = 11;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            this.btnFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnFind_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(283, 303);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // pAmend
            // 
            this.pAmend.Controls.Add(this.dtpAmendDate);
            this.pAmend.Controls.Add(this.label1);
            this.pAmend.Controls.Add(this.btnCancel);
            this.pAmend.Controls.Add(this.label2);
            this.pAmend.Controls.Add(this.txtComment);
            this.pAmend.Enabled = false;
            this.pAmend.Location = new System.Drawing.Point(26, 266);
            this.pAmend.Margin = new System.Windows.Forms.Padding(0);
            this.pAmend.Name = "pAmend";
            this.pAmend.Size = new System.Drawing.Size(746, 35);
            this.pAmend.TabIndex = 28;
            this.pAmend.TabStop = false;
            this.pAmend.Text = "Amendment";
            // 
            // dtpAmendDate
            // 
            this.dtpAmendDate.CustomFormat = "dd/MM/yyyy";
            this.dtpAmendDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAmendDate.Location = new System.Drawing.Point(58, 12);
            this.dtpAmendDate.Name = "dtpAmendDate";
            this.dtpAmendDate.Size = new System.Drawing.Size(91, 20);
            this.dtpAmendDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(690, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 25);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.Color.White;
            this.txtComment.Location = new System.Drawing.Point(235, 11);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(449, 20);
            this.txtComment.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmPrice});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // itmPrice
            // 
            this.itmPrice.Name = "itmPrice";
            this.itmPrice.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.itmPrice.Size = new System.Drawing.Size(146, 22);
            this.itmPrice.Text = "Price";
            this.itmPrice.Click += new System.EventHandler(this.itmPrice_Click);
            // 
            // frmSalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 479);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSalesOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sales Order Register";
            this.Load += new System.EventHandler(this.frmSalesOrder_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSalesOrder_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSalesOrder_FormClosed);
            this.gbSalesOrder.ResumeLayout(false);
            this.gbSalesOrder.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.pAmend.ResumeLayout(false);
            this.pAmend.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label lblLedgerNo;
        private System.Windows.Forms.TextBox txtLedgerNo;
        private System.Windows.Forms.TextBox txtTotalOrderQty;
        private System.Windows.Forms.Label lblTotalOrderQty;
        private System.Windows.Forms.TextBox txtTotalOrderVal;
        private System.Windows.Forms.Label lblTotalOrderValue;
        private System.Windows.Forms.Label lblFactoryName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.ComboBox cmbFactoryName;
        private System.Windows.Forms.GroupBox gbSalesOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtOrderMID;
        private Accounting.Controls.ctlDaraGridView dgvOrderDetails;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDeleteItems;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itmPrice;
        private System.Windows.Forms.LinkLabel llblItems;
        private System.Windows.Forms.Button btnAmend;
        private System.Windows.Forms.GroupBox pAmend;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.DateTimePicker dtpAmendDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalAValue;
        private System.Windows.Forms.TextBox txtTotalAQty;
        private System.Windows.Forms.Button btnFindAmendment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTtlQty;
        private System.Windows.Forms.TextBox txtTtlValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox rtxtBuyer_ref;
        private Accounting.Controls.ctlNum ctlNumRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOMID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colODID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colItem;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCount;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSize;
        private System.Windows.Forms.DataGridViewComboBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLabdip;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Size;
    }
}