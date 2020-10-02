namespace Accounting.UI
{
    partial class frmPurchasesInvoice
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.llblPOs = new System.Windows.Forms.LinkLabel();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.txtSupplierAcc = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTransRefID = new System.Windows.Forms.TextBox();
            this.txtStockRefID = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtSupplierAccID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInvoiceID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbInvoiceType = new System.Windows.Forms.ComboBox();
            this.txtPurchasesRowAcc = new System.Windows.Forms.TextBox();
            this.txtPurchasesRawAccID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pFinish = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFinishAccID = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.ctlNumFinish = new Accounting.Controls.ctlNum();
            this.ctlNumFinishTK = new Accounting.Controls.ctlNum();
            this.txtFinishAcc = new System.Windows.Forms.TextBox();
            this.pRaw = new System.Windows.Forms.Panel();
            this.ctlNumRaw = new Accounting.Controls.ctlNum();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ctlNumRawTK = new Accounting.Controls.ctlNum();
            this.ctlDGVPurchaseDTL = new Accounting.Controls.ctlDaraGridView();
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
            this.ColUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPriceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtTransAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pFinish.SuspendLayout();
            this.pRaw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVPurchaseDTL)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbCurrency);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.llblPOs);
            this.groupBox1.Controls.Add(this.dtpInvoiceDate);
            this.groupBox1.Controls.Add(this.txtSupplierAcc);
            this.groupBox1.Controls.Add(this.txtInvoiceNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTransRefID);
            this.groupBox1.Controls.Add(this.txtStockRefID);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.txtSupplierAccID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtInvoiceID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbInvoiceType);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 108);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(690, 34);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(84, 20);
            this.txtRate.TabIndex = 5;
            this.txtRate.Text = "1";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            this.txtRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRate_KeyDown);
            this.txtRate.Leave += new System.EventHandler(this.txtRate_Leave);
            this.txtRate.Enter += new System.EventHandler(this.txtRate_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(655, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Rate";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(522, 33);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(127, 21);
            this.cmbCurrency.TabIndex = 4;
            this.cmbCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbCurrency_SelectedIndexChanged);
            this.cmbCurrency.Enter += new System.EventHandler(this.cmbCurrency_Enter);
            this.cmbCurrency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCurrency_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(444, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Currency";
            // 
            // llblPOs
            // 
            this.llblPOs.AutoSize = true;
            this.llblPOs.Location = new System.Drawing.Point(16, 86);
            this.llblPOs.Name = "llblPOs";
            this.llblPOs.Size = new System.Drawing.Size(164, 13);
            this.llblPOs.TabIndex = 7;
            this.llblPOs.TabStop = true;
            this.llblPOs.Text = "Select Purchase Order to Invoice";
            this.llblPOs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblPOs_LinkClicked);
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(522, 12);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(127, 20);
            this.dtpInvoiceDate.TabIndex = 3;
            this.dtpInvoiceDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpInvoiceDate_KeyDown);
            // 
            // txtSupplierAcc
            // 
            this.txtSupplierAcc.Location = new System.Drawing.Point(108, 60);
            this.txtSupplierAcc.Name = "txtSupplierAcc";
            this.txtSupplierAcc.ReadOnly = true;
            this.txtSupplierAcc.Size = new System.Drawing.Size(240, 20);
            this.txtSupplierAcc.TabIndex = 2;
            this.txtSupplierAcc.TextChanged += new System.EventHandler(this.txtSupplierAcc_TextChanged);
            this.txtSupplierAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierAcc_KeyDown);
            this.txtSupplierAcc.Leave += new System.EventHandler(this.txtSupplierAcc_Leave);
            this.txtSupplierAcc.Enter += new System.EventHandler(this.txtSupplierAcc_Enter);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(108, 37);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(240, 20);
            this.txtInvoiceNo.TabIndex = 1;
            this.txtInvoiceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceNo_KeyDown);
            this.txtInvoiceNo.Leave += new System.EventHandler(this.txtInvoiceNo_Leave);
            this.txtInvoiceNo.Enter += new System.EventHandler(this.txtInvoiceNo_Enter);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(444, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Remarks";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTransRefID
            // 
            this.txtTransRefID.Location = new System.Drawing.Point(365, 38);
            this.txtTransRefID.Name = "txtTransRefID";
            this.txtTransRefID.Size = new System.Drawing.Size(19, 20);
            this.txtTransRefID.TabIndex = 2;
            this.txtTransRefID.Text = "0";
            this.txtTransRefID.Visible = false;
            // 
            // txtStockRefID
            // 
            this.txtStockRefID.Location = new System.Drawing.Point(756, 17);
            this.txtStockRefID.Name = "txtStockRefID";
            this.txtStockRefID.Size = new System.Drawing.Size(19, 20);
            this.txtStockRefID.TabIndex = 2;
            this.txtStockRefID.Text = "0";
            this.txtStockRefID.Visible = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(522, 56);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(0);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(253, 21);
            this.txtRemarks.TabIndex = 6;
            this.txtRemarks.TextChanged += new System.EventHandler(this.txtRemarks_TextChanged);
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemarks_KeyDown);
            this.txtRemarks.Leave += new System.EventHandler(this.txtRemarks_Leave);
            this.txtRemarks.Enter += new System.EventHandler(this.txtRemarks_Enter);
            // 
            // txtSupplierAccID
            // 
            this.txtSupplierAccID.Location = new System.Drawing.Point(365, 61);
            this.txtSupplierAccID.Name = "txtSupplierAccID";
            this.txtSupplierAccID.Size = new System.Drawing.Size(19, 20);
            this.txtSupplierAccID.TabIndex = 2;
            this.txtSupplierAccID.Text = "0";
            this.txtSupplierAccID.Visible = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(444, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Invoice Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.Location = new System.Drawing.Point(365, 13);
            this.txtInvoiceID.Multiline = true;
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Size = new System.Drawing.Size(19, 20);
            this.txtInvoiceID.TabIndex = 2;
            this.txtInvoiceID.Text = "0";
            this.txtInvoiceID.Visible = false;
            this.txtInvoiceID.TextChanged += new System.EventHandler(this.txtInvoiceID_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Supplier Account";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Invoice No";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Invoice Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbInvoiceType
            // 
            this.cmbInvoiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceType.FormattingEnabled = true;
            this.cmbInvoiceType.Items.AddRange(new object[] {
            "Purchases Order",
            "Direct Purchases"});
            this.cmbInvoiceType.Location = new System.Drawing.Point(108, 13);
            this.cmbInvoiceType.Name = "cmbInvoiceType";
            this.cmbInvoiceType.Size = new System.Drawing.Size(240, 21);
            this.cmbInvoiceType.TabIndex = 0;
            this.cmbInvoiceType.Enter += new System.EventHandler(this.cmbInvoiceType_Enter);
            this.cmbInvoiceType.SelectedValueChanged += new System.EventHandler(this.cmbInvoiceType_SelectedValueChanged);
            this.cmbInvoiceType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbInvoiceType_KeyDown);
            // 
            // txtPurchasesRowAcc
            // 
            this.txtPurchasesRowAcc.Location = new System.Drawing.Point(521, 4);
            this.txtPurchasesRowAcc.Name = "txtPurchasesRowAcc";
            this.txtPurchasesRowAcc.ReadOnly = true;
            this.txtPurchasesRowAcc.Size = new System.Drawing.Size(227, 20);
            this.txtPurchasesRowAcc.TabIndex = 1;
            this.txtPurchasesRowAcc.Text = "Raw Materials Purchase";
            this.txtPurchasesRowAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPurchasesAcc_KeyDown_1);
            this.txtPurchasesRowAcc.Leave += new System.EventHandler(this.txtPurchasesAcc_Leave);
            this.txtPurchasesRowAcc.Enter += new System.EventHandler(this.txtPurchasesAcc_Enter);
            // 
            // txtPurchasesRawAccID
            // 
            this.txtPurchasesRawAccID.Location = new System.Drawing.Point(752, 7);
            this.txtPurchasesRawAccID.Name = "txtPurchasesRawAccID";
            this.txtPurchasesRawAccID.Size = new System.Drawing.Size(19, 20);
            this.txtPurchasesRawAccID.TabIndex = 2;
            this.txtPurchasesRawAccID.Text = "0";
            this.txtPurchasesRawAccID.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.pFinish);
            this.groupBox2.Controls.Add(this.pRaw);
            this.groupBox2.Controls.Add(this.ctlDGVPurchaseDTL);
            this.groupBox2.Location = new System.Drawing.Point(3, 111);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 336);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Invoice Details";
            // 
            // pFinish
            // 
            this.pFinish.Controls.Add(this.label13);
            this.pFinish.Controls.Add(this.txtFinishAccID);
            this.pFinish.Controls.Add(this.label19);
            this.pFinish.Controls.Add(this.label14);
            this.pFinish.Controls.Add(this.label17);
            this.pFinish.Controls.Add(this.ctlNumFinish);
            this.pFinish.Controls.Add(this.ctlNumFinishTK);
            this.pFinish.Controls.Add(this.txtFinishAcc);
            this.pFinish.Location = new System.Drawing.Point(7, 307);
            this.pFinish.Name = "pFinish";
            this.pFinish.Size = new System.Drawing.Size(777, 27);
            this.pFinish.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Total Finish Goods";
            // 
            // txtFinishAccID
            // 
            this.txtFinishAccID.Location = new System.Drawing.Point(752, 3);
            this.txtFinishAccID.Name = "txtFinishAccID";
            this.txtFinishAccID.Size = new System.Drawing.Size(19, 20);
            this.txtFinishAccID.TabIndex = 2;
            this.txtFinishAccID.Text = "0";
            this.txtFinishAccID.Visible = false;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(346, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 13);
            this.label19.TabIndex = 105;
            this.label19.Text = "TK";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(447, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 18);
            this.label14.TabIndex = 1;
            this.label14.Text = "Finish Goods";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(230, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(10, 16);
            this.label17.TabIndex = 102;
            this.label17.Text = "=";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctlNumFinish
            // 
            this.ctlNumFinish.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumFinish.Location = new System.Drawing.Point(106, 5);
            this.ctlNumFinish.Name = "ctlNumFinish";
            this.ctlNumFinish.ReadOnly = true;
            this.ctlNumFinish.Size = new System.Drawing.Size(121, 20);
            this.ctlNumFinish.TabIndex = 0;
            this.ctlNumFinish.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumFinish.Value = 0;
            this.ctlNumFinish.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.CtlNum_ValueChanged);
            // 
            // ctlNumFinishTK
            // 
            this.ctlNumFinishTK.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumFinishTK.Location = new System.Drawing.Point(244, 5);
            this.ctlNumFinishTK.Name = "ctlNumFinishTK";
            this.ctlNumFinishTK.ReadOnly = true;
            this.ctlNumFinishTK.Size = new System.Drawing.Size(99, 20);
            this.ctlNumFinishTK.TabIndex = 10;
            this.ctlNumFinishTK.TabStop = false;
            this.ctlNumFinishTK.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumFinishTK.Value = 0;
            // 
            // txtFinishAcc
            // 
            this.txtFinishAcc.Location = new System.Drawing.Point(521, 2);
            this.txtFinishAcc.Name = "txtFinishAcc";
            this.txtFinishAcc.ReadOnly = true;
            this.txtFinishAcc.Size = new System.Drawing.Size(227, 20);
            this.txtFinishAcc.TabIndex = 1;
            this.txtFinishAcc.Text = "Finished Goods Purchase";
            this.txtFinishAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFinishAcc_KeyDown);
            // 
            // pRaw
            // 
            this.pRaw.Controls.Add(this.ctlNumRaw);
            this.pRaw.Controls.Add(this.txtPurchasesRawAccID);
            this.pRaw.Controls.Add(this.label18);
            this.pRaw.Controls.Add(this.txtPurchasesRowAcc);
            this.pRaw.Controls.Add(this.label15);
            this.pRaw.Controls.Add(this.label16);
            this.pRaw.Controls.Add(this.label12);
            this.pRaw.Controls.Add(this.ctlNumRawTK);
            this.pRaw.Location = new System.Drawing.Point(8, 281);
            this.pRaw.Name = "pRaw";
            this.pRaw.Size = new System.Drawing.Size(775, 29);
            this.pRaw.TabIndex = 0;
            // 
            // ctlNumRaw
            // 
            this.ctlNumRaw.BackgroudColor = System.Drawing.Color.White;
            this.ctlNumRaw.Location = new System.Drawing.Point(106, 5);
            this.ctlNumRaw.Name = "ctlNumRaw";
            this.ctlNumRaw.ReadOnly = true;
            this.ctlNumRaw.Size = new System.Drawing.Size(121, 20);
            this.ctlNumRaw.TabIndex = 0;
            this.ctlNumRaw.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumRaw.Value = 0;
            this.ctlNumRaw.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.CtlNum_ValueChanged);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(346, 6);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 13);
            this.label18.TabIndex = 104;
            this.label18.Text = "TK";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(447, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 18);
            this.label15.TabIndex = 1;
            this.label15.Text = "Raw Material";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(230, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 16);
            this.label16.TabIndex = 102;
            this.label16.Text = "=";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Total Raw Materials";
            // 
            // ctlNumRawTK
            // 
            this.ctlNumRawTK.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumRawTK.Location = new System.Drawing.Point(244, 5);
            this.ctlNumRawTK.Name = "ctlNumRawTK";
            this.ctlNumRawTK.ReadOnly = true;
            this.ctlNumRawTK.Size = new System.Drawing.Size(99, 20);
            this.ctlNumRawTK.TabIndex = 9;
            this.ctlNumRawTK.TabStop = false;
            this.ctlNumRawTK.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumRawTK.Value = 0;
            // 
            // ctlDGVPurchaseDTL
            // 
            this.ctlDGVPurchaseDTL.AllowUserToDeleteRows = false;
            this.ctlDGVPurchaseDTL.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctlDGVPurchaseDTL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDGVPurchaseDTL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.ColUnitPrice,
            this.ColPriceAmount,
            this.ColRemarks});
            this.ctlDGVPurchaseDTL.ContextMenuFields = null;
            this.ctlDGVPurchaseDTL.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ctlDGVPurchaseDTL.GridColor = System.Drawing.Color.Silver;
            this.ctlDGVPurchaseDTL.isEnterKeyLikeTabKey = true;
            this.ctlDGVPurchaseDTL.isExcelSheetCell = false;
            this.ctlDGVPurchaseDTL.IsSortable = false;
            this.ctlDGVPurchaseDTL.Location = new System.Drawing.Point(6, 19);
            this.ctlDGVPurchaseDTL.MultiSelect = false;
            this.ctlDGVPurchaseDTL.Name = "ctlDGVPurchaseDTL";
            this.ctlDGVPurchaseDTL.RowHeadersVisible = false;
            this.ctlDGVPurchaseDTL.RowHeadersWidth = 25;
            this.ctlDGVPurchaseDTL.RowPointer = 0;
            this.ctlDGVPurchaseDTL.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctlDGVPurchaseDTL.ShowDateTimePicker = false;
            this.ctlDGVPurchaseDTL.Size = new System.Drawing.Size(771, 261);
            this.ctlDGVPurchaseDTL.TabIndex = 0;
            this.ctlDGVPurchaseDTL.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlDGVPurchaseDTL_CellValueChanged);
            this.ctlDGVPurchaseDTL.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ctlDGVPurchaseDTL_EditingControlShowing);
            this.ctlDGVPurchaseDTL.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlDGVPurchaseDTL_CellEnter);
            // 
            // ColSLNo
            // 
            this.ColSLNo.HeaderText = "SLNo";
            this.ColSLNo.Name = "ColSLNo";
            this.ColSLNo.Visible = false;
            this.ColSLNo.Width = 59;
            // 
            // ColOrderID
            // 
            this.ColOrderID.HeaderText = "OrderID";
            this.ColOrderID.Name = "ColOrderID";
            this.ColOrderID.Visible = false;
            this.ColOrderID.Width = 69;
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
            this.ColCountID.Width = 60;
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
            this.ColUnit.Width = 60;
            // 
            // ColInvQty
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.ColInvQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColInvQty.HeaderText = "Inv Qty";
            this.ColInvQty.Name = "ColInvQty";
            this.ColInvQty.Width = 70;
            // 
            // ColUnitPrice
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.ColUnitPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColUnitPrice.HeaderText = "Unit Price";
            this.ColUnitPrice.Name = "ColUnitPrice";
            this.ColUnitPrice.Width = 85;
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
            this.ColPriceAmount.Width = 70;
            // 
            // ColRemarks
            // 
            this.ColRemarks.HeaderText = "Remarks";
            this.ColRemarks.Name = "ColRemarks";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(437, 449);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(204, 449);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(512, 452);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "TTL Amt";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(126, 449);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnReset_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(282, 449);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDelete_KeyDown);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(360, 449);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            this.btnFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnFind_KeyDown);
            // 
            // txtTransAmount
            // 
            this.txtTransAmount.BackColor = System.Drawing.Color.White;
            this.txtTransAmount.Location = new System.Drawing.Point(564, 449);
            this.txtTransAmount.Name = "txtTransAmount";
            this.txtTransAmount.ReadOnly = true;
            this.txtTransAmount.Size = new System.Drawing.Size(83, 20);
            this.txtTransAmount.TabIndex = 100;
            this.txtTransAmount.TabStop = false;
            this.txtTransAmount.Text = "0.00";
            this.txtTransAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransAmount.TextChanged += new System.EventHandler(this.txtTransAmount_TextChanged);
            this.txtTransAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransAmount_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(650, 452);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 16);
            this.label10.TabIndex = 101;
            this.label10.Text = "=";
            // 
            // txtTK
            // 
            this.txtTK.BackColor = System.Drawing.Color.White;
            this.txtTK.Location = new System.Drawing.Point(663, 449);
            this.txtTK.Name = "txtTK";
            this.txtTK.ReadOnly = true;
            this.txtTK.Size = new System.Drawing.Size(95, 20);
            this.txtTK.TabIndex = 102;
            this.txtTK.TabStop = false;
            this.txtTK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(764, 454);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 103;
            this.label11.Text = "TK";
            // 
            // frmPurchasesInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 476);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtTransAmount);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPurchasesInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Purchase Invoice";
            this.Load += new System.EventHandler(this.frmPurchasesInvoice_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPurchasesInvoice_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.pFinish.ResumeLayout(false);
            this.pFinish.PerformLayout();
            this.pRaw.ResumeLayout(false);
            this.pRaw.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVPurchaseDTL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbInvoiceType;
        private System.Windows.Forms.TextBox txtInvoiceID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPurchasesRowAcc;
        private System.Windows.Forms.TextBox txtSupplierAcc;
        private System.Windows.Forms.TextBox txtPurchasesRawAccID;
        private System.Windows.Forms.TextBox txtSupplierAccID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTransRefID;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private Accounting.Controls.ctlDaraGridView ctlDGVPurchaseDTL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTransAmount;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtStockRefID;
        private System.Windows.Forms.LinkLabel llblPOs;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Label label11;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPriceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRemarks;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private Accounting.Controls.ctlNum ctlNumFinish;
        private Accounting.Controls.ctlNum ctlNumRaw;
        private System.Windows.Forms.TextBox txtFinishAcc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private Accounting.Controls.ctlNum ctlNumFinishTK;
        private Accounting.Controls.ctlNum ctlNumRawTK;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtFinishAccID;
        private System.Windows.Forms.Panel pRaw;
        private System.Windows.Forms.Panel pFinish;
    }
}