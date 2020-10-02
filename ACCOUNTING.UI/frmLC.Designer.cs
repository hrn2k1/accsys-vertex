namespace Accounting.UI
{
    partial class frmLC
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
            this.btnNew = new System.Windows.Forms.Button();
            this.CHKUDDate = new System.Windows.Forms.CheckBox();
            this.cmbLCType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.llblUnderLC = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.DTPUnderLCDate = new System.Windows.Forms.DateTimePicker();
            this.llblLCAcceptance = new System.Windows.Forms.LinkLabel();
            this.chkAddPI = new System.Windows.Forms.CheckBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpPaidDate = new System.Windows.Forms.DateTimePicker();
            this.txtCustSupp = new System.Windows.Forms.TextBox();
            this.DTPActualShDate = new System.Windows.Forms.DateTimePicker();
            this.chkPaid = new System.Windows.Forms.CheckBox();
            this.lblCustSupp = new System.Windows.Forms.Label();
            this.chkAcceptDate = new System.Windows.Forms.CheckBox();
            this.chkActualShDate = new System.Windows.Forms.CheckBox();
            this.DTPAcceptDate = new System.Windows.Forms.DateTimePicker();
            this.btnGetLC = new System.Windows.Forms.Button();
            this.chkMasterLC = new System.Windows.Forms.CheckBox();
            this.CHKNegotiationDate = new System.Windows.Forms.CheckBox();
            this.CHKDocumentDate = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.DTPNegDate = new System.Windows.Forms.DateTimePicker();
            this.llblPIs = new System.Windows.Forms.LinkLabel();
            this.txtAtSight = new System.Windows.Forms.TextBox();
            this.DTPDocDate = new System.Windows.Forms.DateTimePicker();
            this.LCMasterID = new System.Windows.Forms.TextBox();
            this.DTPUDDate = new System.Windows.Forms.DateTimePicker();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.DTPExpireDate = new System.Windows.Forms.DateTimePicker();
            this.DTPShipmentDate = new System.Windows.Forms.DateTimePicker();
            this.txtPINo = new System.Windows.Forms.TextBox();
            this.DTPLCDate = new System.Windows.Forms.DateTimePicker();
            this.txtFileNo = new System.Windows.Forms.TextBox();
            this.txtMasterLCNo = new System.Windows.Forms.TextBox();
            this.txtLCNo = new System.Windows.Forms.TextBox();
            this.cmbNeBank = new System.Windows.Forms.ComboBox();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTotalQTY = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.txtTotalValue = new System.Windows.Forms.TextBox();
            this.dgvPIs = new System.Windows.Forms.DataGridView();
            this.LCDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PIID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAmend = new System.Windows.Forms.Button();
            this.ctlDGVLC = new Accounting.Controls.ctlDaraGridView();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPIs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVLC)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.Control;
            this.btnNew.Location = new System.Drawing.Point(8, 453);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(69, 23);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // CHKUDDate
            // 
            this.CHKUDDate.AutoSize = true;
            this.CHKUDDate.Location = new System.Drawing.Point(548, 39);
            this.CHKUDDate.Name = "CHKUDDate";
            this.CHKUDDate.Size = new System.Drawing.Size(91, 17);
            this.CHKUDDate.TabIndex = 17;
            this.CHKUDDate.Text = "UD Received";
            this.CHKUDDate.UseVisualStyleBackColor = true;
            this.CHKUDDate.Leave += new System.EventHandler(this.chk_Leave);
            this.CHKUDDate.Enter += new System.EventHandler(this.chk_Enter);
            this.CHKUDDate.CheckedChanged += new System.EventHandler(this.CHKUDDate_CheckedChanged);
            this.CHKUDDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CHKUDDate_KeyDown_1);
            // 
            // cmbLCType
            // 
            this.cmbLCType.BackColor = System.Drawing.Color.White;
            this.cmbLCType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLCType.FormattingEnabled = true;
            this.cmbLCType.Items.AddRange(new object[] {
            "Export LC",
            "Import LC",
            "Direct Export LC",
            "Direct Import LC"});
            this.cmbLCType.Location = new System.Drawing.Point(88, 12);
            this.cmbLCType.Name = "cmbLCType";
            this.cmbLCType.Size = new System.Drawing.Size(201, 21);
            this.cmbLCType.TabIndex = 0;
            this.cmbLCType.SelectedIndexChanged += new System.EventHandler(this.cmbLCType_SelectedIndexChanged);
            this.cmbLCType.Enter += new System.EventHandler(this.cmbLCType_Enter);
            this.cmbLCType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMasterLC_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.llblUnderLC);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DTPUnderLCDate);
            this.groupBox1.Controls.Add(this.llblLCAcceptance);
            this.groupBox1.Controls.Add(this.chkAddPI);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.cmbCurrency);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dtpPaidDate);
            this.groupBox1.Controls.Add(this.txtCustSupp);
            this.groupBox1.Controls.Add(this.DTPActualShDate);
            this.groupBox1.Controls.Add(this.chkPaid);
            this.groupBox1.Controls.Add(this.lblCustSupp);
            this.groupBox1.Controls.Add(this.chkAcceptDate);
            this.groupBox1.Controls.Add(this.chkActualShDate);
            this.groupBox1.Controls.Add(this.DTPAcceptDate);
            this.groupBox1.Controls.Add(this.btnGetLC);
            this.groupBox1.Controls.Add(this.chkMasterLC);
            this.groupBox1.Controls.Add(this.CHKNegotiationDate);
            this.groupBox1.Controls.Add(this.CHKDocumentDate);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.CHKUDDate);
            this.groupBox1.Controls.Add(this.DTPNegDate);
            this.groupBox1.Controls.Add(this.llblPIs);
            this.groupBox1.Controls.Add(this.txtAtSight);
            this.groupBox1.Controls.Add(this.DTPDocDate);
            this.groupBox1.Controls.Add(this.LCMasterID);
            this.groupBox1.Controls.Add(this.DTPUDDate);
            this.groupBox1.Controls.Add(this.dtpPaymentDate);
            this.groupBox1.Controls.Add(this.DTPExpireDate);
            this.groupBox1.Controls.Add(this.DTPShipmentDate);
            this.groupBox1.Controls.Add(this.txtPINo);
            this.groupBox1.Controls.Add(this.DTPLCDate);
            this.groupBox1.Controls.Add(this.txtFileNo);
            this.groupBox1.Controls.Add(this.txtMasterLCNo);
            this.groupBox1.Controls.Add(this.txtLCNo);
            this.groupBox1.Controls.Add(this.cmbNeBank);
            this.groupBox1.Controls.Add(this.cmbBank);
            this.groupBox1.Controls.Add(this.cmbLCType);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 205);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LC Information";
            // 
            // txtDesc
            // 
            this.txtDesc.AutoCompleteCustomSource.AddRange(new string[] {
            "Accessories",
            "Yarn"});
            this.txtDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDesc.Location = new System.Drawing.Point(379, 154);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(157, 20);
            this.txtDesc.TabIndex = 52;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(296, 157);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 51;
            this.label16.Text = "Description";
            // 
            // llblUnderLC
            // 
            this.llblUnderLC.AutoSize = true;
            this.llblUnderLC.Location = new System.Drawing.Point(195, 108);
            this.llblUnderLC.Name = "llblUnderLC";
            this.llblUnderLC.Size = new System.Drawing.Size(84, 13);
            this.llblUnderLC.TabIndex = 50;
            this.llblUnderLC.TabStop = true;
            this.llblUnderLC.Text = "More Under LCs";
            this.llblUnderLC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblUnderLC_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Under Lc Date";
            // 
            // DTPUnderLCDate
            // 
            this.DTPUnderLCDate.CustomFormat = "dd/MM/yyyy";
            this.DTPUnderLCDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPUnderLCDate.Location = new System.Drawing.Point(88, 104);
            this.DTPUnderLCDate.Name = "DTPUnderLCDate";
            this.DTPUnderLCDate.Size = new System.Drawing.Size(101, 20);
            this.DTPUnderLCDate.TabIndex = 5;
            this.DTPUnderLCDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPUnderLCDate_KeyDown);
            // 
            // llblLCAcceptance
            // 
            this.llblLCAcceptance.AutoSize = true;
            this.llblLCAcceptance.Location = new System.Drawing.Point(544, 166);
            this.llblLCAcceptance.Name = "llblLCAcceptance";
            this.llblLCAcceptance.Size = new System.Drawing.Size(81, 13);
            this.llblLCAcceptance.TabIndex = 27;
            this.llblLCAcceptance.TabStop = true;
            this.llblLCAcceptance.Text = "LC Acceptance";
            this.llblLCAcceptance.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblLCAcceptance_LinkClicked);
            // 
            // chkAddPI
            // 
            this.chkAddPI.AutoSize = true;
            this.chkAddPI.Location = new System.Drawing.Point(459, 182);
            this.chkAddPI.Name = "chkAddPI";
            this.chkAddPI.Size = new System.Drawing.Size(58, 17);
            this.chkAddPI.TabIndex = 26;
            this.chkAddPI.TabStop = false;
            this.chkAddPI.Text = "Add PI";
            this.chkAddPI.UseVisualStyleBackColor = true;
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(379, 57);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(94, 20);
            this.txtRate.TabIndex = 11;
            this.txtRate.Text = "1";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLCNo_KeyDown);
            this.txtRate.Leave += new System.EventHandler(this.txtLCNo_Leave);
            this.txtRate.Enter += new System.EventHandler(this.txtLCNo_Enter);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(296, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "Rate";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(379, 33);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(94, 21);
            this.cmbCurrency.TabIndex = 10;
            this.cmbCurrency.Enter += new System.EventHandler(this.cmbLCType_Enter);
            this.cmbCurrency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLCType_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(296, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Currency";
            // 
            // dtpPaidDate
            // 
            this.dtpPaidDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPaidDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaidDate.Location = new System.Drawing.Point(683, 146);
            this.dtpPaidDate.Name = "dtpPaidDate";
            this.dtpPaidDate.Size = new System.Drawing.Size(91, 20);
            this.dtpPaidDate.TabIndex = 28;
            this.dtpPaidDate.Visible = false;
            // 
            // txtCustSupp
            // 
            this.txtCustSupp.Location = new System.Drawing.Point(88, 176);
            this.txtCustSupp.Name = "txtCustSupp";
            this.txtCustSupp.Size = new System.Drawing.Size(198, 20);
            this.txtCustSupp.TabIndex = 8;
            this.txtCustSupp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustSupp_KeyDown);
            this.txtCustSupp.Leave += new System.EventHandler(this.txtCustSupp_Leave);
            this.txtCustSupp.Enter += new System.EventHandler(this.txtCustSupp_DoubleClick);
            // 
            // DTPActualShDate
            // 
            this.DTPActualShDate.CustomFormat = "dd/MM/yyyy";
            this.DTPActualShDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPActualShDate.Location = new System.Drawing.Point(683, 123);
            this.DTPActualShDate.Name = "DTPActualShDate";
            this.DTPActualShDate.Size = new System.Drawing.Size(91, 20);
            this.DTPActualShDate.TabIndex = 26;
            this.DTPActualShDate.Visible = false;
            // 
            // chkPaid
            // 
            this.chkPaid.AutoSize = true;
            this.chkPaid.Location = new System.Drawing.Point(547, 146);
            this.chkPaid.Name = "chkPaid";
            this.chkPaid.Size = new System.Drawing.Size(47, 17);
            this.chkPaid.TabIndex = 27;
            this.chkPaid.Text = "Paid";
            this.chkPaid.UseVisualStyleBackColor = true;
            this.chkPaid.Leave += new System.EventHandler(this.chk_Leave);
            this.chkPaid.Enter += new System.EventHandler(this.chk_Enter);
            this.chkPaid.CheckedChanged += new System.EventHandler(this.chkPayDate_CheckedChanged);
            this.chkPaid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkPaid_KeyDown);
            // 
            // lblCustSupp
            // 
            this.lblCustSupp.Location = new System.Drawing.Point(5, 174);
            this.lblCustSupp.Name = "lblCustSupp";
            this.lblCustSupp.Size = new System.Drawing.Size(78, 22);
            this.lblCustSupp.TabIndex = 47;
            this.lblCustSupp.Text = "Customer/Supplier";
            // 
            // chkAcceptDate
            // 
            this.chkAcceptDate.AutoSize = true;
            this.chkAcceptDate.Location = new System.Drawing.Point(548, 99);
            this.chkAcceptDate.Name = "chkAcceptDate";
            this.chkAcceptDate.Size = new System.Drawing.Size(86, 17);
            this.chkAcceptDate.TabIndex = 23;
            this.chkAcceptDate.Text = "Accept Date";
            this.chkAcceptDate.UseVisualStyleBackColor = true;
            this.chkAcceptDate.Leave += new System.EventHandler(this.chk_Leave);
            this.chkAcceptDate.Enter += new System.EventHandler(this.chk_Enter);
            this.chkAcceptDate.CheckedChanged += new System.EventHandler(this.chkAcceptDate_CheckedChanged);
            this.chkAcceptDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkAcceptDate_KeyDown);
            // 
            // chkActualShDate
            // 
            this.chkActualShDate.AutoSize = true;
            this.chkActualShDate.Location = new System.Drawing.Point(547, 121);
            this.chkActualShDate.Name = "chkActualShDate";
            this.chkActualShDate.Size = new System.Drawing.Size(129, 17);
            this.chkActualShDate.TabIndex = 25;
            this.chkActualShDate.Text = "Actual Shipment Date";
            this.chkActualShDate.UseVisualStyleBackColor = true;
            this.chkActualShDate.Leave += new System.EventHandler(this.chk_Leave);
            this.chkActualShDate.Enter += new System.EventHandler(this.chk_Enter);
            this.chkActualShDate.CheckedChanged += new System.EventHandler(this.chkActualShDate_CheckedChanged);
            this.chkActualShDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkActualShDate_KeyDown);
            // 
            // DTPAcceptDate
            // 
            this.DTPAcceptDate.CustomFormat = "dd/MM/yyyy";
            this.DTPAcceptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPAcceptDate.Location = new System.Drawing.Point(683, 101);
            this.DTPAcceptDate.Name = "DTPAcceptDate";
            this.DTPAcceptDate.Size = new System.Drawing.Size(91, 20);
            this.DTPAcceptDate.TabIndex = 24;
            this.DTPAcceptDate.Visible = false;
            this.DTPAcceptDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPAcceptDate_KeyDown);
            // 
            // btnGetLC
            // 
            this.btnGetLC.Location = new System.Drawing.Point(271, 83);
            this.btnGetLC.Name = "btnGetLC";
            this.btnGetLC.Size = new System.Drawing.Size(21, 20);
            this.btnGetLC.TabIndex = 36;
            this.btnGetLC.TabStop = false;
            this.btnGetLC.Text = "..";
            this.btnGetLC.UseVisualStyleBackColor = true;
            this.btnGetLC.Click += new System.EventHandler(this.btnGetLC_Click);
            // 
            // chkMasterLC
            // 
            this.chkMasterLC.Location = new System.Drawing.Point(5, 83);
            this.chkMasterLC.Name = "chkMasterLC";
            this.chkMasterLC.Size = new System.Drawing.Size(76, 24);
            this.chkMasterLC.TabIndex = 3;
            this.chkMasterLC.Text = "Under LC";
            this.chkMasterLC.UseVisualStyleBackColor = true;
            this.chkMasterLC.Leave += new System.EventHandler(this.chk_Leave);
            this.chkMasterLC.Enter += new System.EventHandler(this.chk_Enter);
            this.chkMasterLC.CheckedChanged += new System.EventHandler(this.chkMasterLC_CheckedChanged);
            this.chkMasterLC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPLCDate_KeyDown);
            // 
            // CHKNegotiationDate
            // 
            this.CHKNegotiationDate.AutoSize = true;
            this.CHKNegotiationDate.Location = new System.Drawing.Point(548, 79);
            this.CHKNegotiationDate.Margin = new System.Windows.Forms.Padding(0);
            this.CHKNegotiationDate.Name = "CHKNegotiationDate";
            this.CHKNegotiationDate.Size = new System.Drawing.Size(135, 17);
            this.CHKNegotiationDate.TabIndex = 21;
            this.CHKNegotiationDate.Text = " Docoment Negotiation";
            this.CHKNegotiationDate.UseVisualStyleBackColor = true;
            this.CHKNegotiationDate.Leave += new System.EventHandler(this.chk_Leave);
            this.CHKNegotiationDate.Enter += new System.EventHandler(this.chk_Enter);
            this.CHKNegotiationDate.CheckedChanged += new System.EventHandler(this.CHKNegotiationDate_CheckedChanged);
            this.CHKNegotiationDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CHKNegotiationDate_KeyDown_1);
            // 
            // CHKDocumentDate
            // 
            this.CHKDocumentDate.AutoSize = true;
            this.CHKDocumentDate.Enabled = false;
            this.CHKDocumentDate.Location = new System.Drawing.Point(548, 59);
            this.CHKDocumentDate.Name = "CHKDocumentDate";
            this.CHKDocumentDate.Size = new System.Drawing.Size(124, 17);
            this.CHKDocumentDate.TabIndex = 19;
            this.CHKDocumentDate.Text = "Document Received";
            this.CHKDocumentDate.UseVisualStyleBackColor = true;
            this.CHKDocumentDate.Leave += new System.EventHandler(this.chk_Leave);
            this.CHKDocumentDate.Enter += new System.EventHandler(this.chk_Enter);
            this.CHKDocumentDate.CheckedChanged += new System.EventHandler(this.CHKDocumentDate_CheckedChanged);
            this.CHKDocumentDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CHKDocumentDate_KeyDown_1);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(480, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Days";
            // 
            // DTPNegDate
            // 
            this.DTPNegDate.CustomFormat = "dd/MM/yyyy";
            this.DTPNegDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPNegDate.Location = new System.Drawing.Point(683, 80);
            this.DTPNegDate.Margin = new System.Windows.Forms.Padding(0);
            this.DTPNegDate.Name = "DTPNegDate";
            this.DTPNegDate.Size = new System.Drawing.Size(91, 20);
            this.DTPNegDate.TabIndex = 22;
            this.DTPNegDate.Visible = false;
            this.DTPNegDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPNegDate_KeyDown);
            // 
            // llblPIs
            // 
            this.llblPIs.AutoSize = true;
            this.llblPIs.Location = new System.Drawing.Point(296, 183);
            this.llblPIs.Name = "llblPIs";
            this.llblPIs.Size = new System.Drawing.Size(157, 13);
            this.llblPIs.TabIndex = 15;
            this.llblPIs.TabStop = true;
            this.llblPIs.Text = "Select  Proforma Invoice  for LC";
            this.llblPIs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblPIs_LinkClicked);
            this.llblPIs.Leave += new System.EventHandler(this.llblPIs_Leave);
            this.llblPIs.Enter += new System.EventHandler(this.llblPIs_Enter);
            // 
            // txtAtSight
            // 
            this.txtAtSight.Location = new System.Drawing.Point(379, 11);
            this.txtAtSight.Name = "txtAtSight";
            this.txtAtSight.Size = new System.Drawing.Size(94, 20);
            this.txtAtSight.TabIndex = 9;
            this.txtAtSight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAtSight_KeyDown);
            this.txtAtSight.Leave += new System.EventHandler(this.txtAtSight_Leave);
            this.txtAtSight.Enter += new System.EventHandler(this.txtAtSight_Enter);
            // 
            // DTPDocDate
            // 
            this.DTPDocDate.CustomFormat = "dd/MM/yyyy";
            this.DTPDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPDocDate.Location = new System.Drawing.Point(683, 57);
            this.DTPDocDate.Name = "DTPDocDate";
            this.DTPDocDate.Size = new System.Drawing.Size(91, 20);
            this.DTPDocDate.TabIndex = 20;
            this.DTPDocDate.Visible = false;
            this.DTPDocDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPDocDate_KeyDown);
            // 
            // LCMasterID
            // 
            this.LCMasterID.Location = new System.Drawing.Point(55, 15);
            this.LCMasterID.Name = "LCMasterID";
            this.LCMasterID.Size = new System.Drawing.Size(29, 20);
            this.LCMasterID.TabIndex = 40;
            this.LCMasterID.Text = "0";
            this.LCMasterID.Visible = false;
            // 
            // DTPUDDate
            // 
            this.DTPUDDate.CustomFormat = "dd/MM/yyyy";
            this.DTPUDDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPUDDate.Location = new System.Drawing.Point(683, 35);
            this.DTPUDDate.Name = "DTPUDDate";
            this.DTPUDDate.Size = new System.Drawing.Size(91, 20);
            this.DTPUDDate.TabIndex = 18;
            this.DTPUDDate.Visible = false;
            this.DTPUDDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPUDDate_KeyDown);
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(683, 11);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(91, 20);
            this.dtpPaymentDate.TabIndex = 16;
            this.dtpPaymentDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPExpireDate_KeyDown);
            // 
            // DTPExpireDate
            // 
            this.DTPExpireDate.CustomFormat = "dd/MM/yyyy";
            this.DTPExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPExpireDate.Location = new System.Drawing.Point(379, 105);
            this.DTPExpireDate.Name = "DTPExpireDate";
            this.DTPExpireDate.Size = new System.Drawing.Size(94, 20);
            this.DTPExpireDate.TabIndex = 13;
            this.DTPExpireDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPExpireDate_KeyDown);
            // 
            // DTPShipmentDate
            // 
            this.DTPShipmentDate.CustomFormat = "dd/MM/yyyy";
            this.DTPShipmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPShipmentDate.Location = new System.Drawing.Point(379, 81);
            this.DTPShipmentDate.Name = "DTPShipmentDate";
            this.DTPShipmentDate.Size = new System.Drawing.Size(94, 20);
            this.DTPShipmentDate.TabIndex = 12;
            this.DTPShipmentDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPShipmentDate_KeyDown);
            // 
            // txtPINo
            // 
            this.txtPINo.Location = new System.Drawing.Point(517, 79);
            this.txtPINo.Name = "txtPINo";
            this.txtPINo.Size = new System.Drawing.Size(19, 20);
            this.txtPINo.TabIndex = 31;
            this.txtPINo.Visible = false;
            this.txtPINo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPINo_KeyDown);
            this.txtPINo.Leave += new System.EventHandler(this.txtPINo_Leave);
            this.txtPINo.Enter += new System.EventHandler(this.txtPINo_Enter);
            // 
            // DTPLCDate
            // 
            this.DTPLCDate.CustomFormat = "dd/MM/yyyy";
            this.DTPLCDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPLCDate.Location = new System.Drawing.Point(88, 59);
            this.DTPLCDate.Name = "DTPLCDate";
            this.DTPLCDate.Size = new System.Drawing.Size(101, 20);
            this.DTPLCDate.TabIndex = 2;
            this.DTPLCDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPLCDate_KeyDown);
            // 
            // txtFileNo
            // 
            this.txtFileNo.Location = new System.Drawing.Point(379, 129);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(94, 20);
            this.txtFileNo.TabIndex = 14;
            this.txtFileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFileNo_KeyDown_1);
            this.txtFileNo.Leave += new System.EventHandler(this.txtFileNo_Leave);
            this.txtFileNo.Enter += new System.EventHandler(this.txtFileNo_Enter);
            // 
            // txtMasterLCNo
            // 
            this.txtMasterLCNo.Location = new System.Drawing.Point(88, 82);
            this.txtMasterLCNo.Name = "txtMasterLCNo";
            this.txtMasterLCNo.Size = new System.Drawing.Size(184, 20);
            this.txtMasterLCNo.TabIndex = 4;
            this.txtMasterLCNo.ReadOnlyChanged += new System.EventHandler(this.txtMasterLCNo_ReadOnlyChanged);
            this.txtMasterLCNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMasterLCNo_KeyDown);
            this.txtMasterLCNo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtMasterLCNo_MouseDoubleClick);
            this.txtMasterLCNo.Leave += new System.EventHandler(this.txtMasterLCNo_Leave);
            this.txtMasterLCNo.Enter += new System.EventHandler(this.txtMasterLCNo_Enter);
            // 
            // txtLCNo
            // 
            this.txtLCNo.Location = new System.Drawing.Point(88, 36);
            this.txtLCNo.Name = "txtLCNo";
            this.txtLCNo.Size = new System.Drawing.Size(201, 20);
            this.txtLCNo.TabIndex = 1;
            this.txtLCNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLCNo_KeyDown);
            this.txtLCNo.Leave += new System.EventHandler(this.txtLCNo_Leave);
            this.txtLCNo.Enter += new System.EventHandler(this.txtLCNo_Enter);
            // 
            // cmbNeBank
            // 
            this.cmbNeBank.BackColor = System.Drawing.Color.White;
            this.cmbNeBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNeBank.FormattingEnabled = true;
            this.cmbNeBank.Location = new System.Drawing.Point(88, 149);
            this.cmbNeBank.Name = "cmbNeBank";
            this.cmbNeBank.Size = new System.Drawing.Size(201, 21);
            this.cmbNeBank.TabIndex = 7;
            this.cmbNeBank.Enter += new System.EventHandler(this.cmbNeBank_Enter);
            this.cmbNeBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNeBank_KeyDown);
            // 
            // cmbBank
            // 
            this.cmbBank.BackColor = System.Drawing.Color.White;
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(88, 125);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(201, 21);
            this.cmbBank.TabIndex = 6;
            this.cmbBank.Enter += new System.EventHandler(this.cmbBank_Enter);
            this.cmbBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBank_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(296, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "At Sight";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(473, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "PI No.";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(296, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Ins. CoverNote#";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(545, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Maturity date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(296, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Expire Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(296, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Shipment  Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "LC Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Negotiate Bank";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Issue Bank";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "LC Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "LC No.";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(77, 453);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(382, 453);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.Control;
            this.btnFind.Location = new System.Drawing.Point(158, 453);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(232, 453);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(632, 458);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Ttl Value";
            // 
            // lblTotalQTY
            // 
            this.lblTotalQTY.AutoSize = true;
            this.lblTotalQTY.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalQTY.Location = new System.Drawing.Point(443, 458);
            this.lblTotalQTY.Name = "lblTotalQTY";
            this.lblTotalQTY.Size = new System.Drawing.Size(56, 13);
            this.lblTotalQTY.TabIndex = 9;
            this.lblTotalQTY.Text = "Total QTY";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(505, 455);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(74, 20);
            this.txtTotalQty.TabIndex = 8;
            this.txtTotalQty.Text = "0";
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.Location = new System.Drawing.Point(680, 454);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.Size = new System.Drawing.Size(113, 20);
            this.txtTotalValue.TabIndex = 12;
            this.txtTotalValue.Text = "0.0";
            this.txtTotalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvPIs
            // 
            this.dgvPIs.AllowUserToAddRows = false;
            this.dgvPIs.AllowUserToDeleteRows = false;
            this.dgvPIs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPIs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LCDetailID,
            this.PIID});
            this.dgvPIs.Location = new System.Drawing.Point(412, 238);
            this.dgvPIs.Name = "dgvPIs";
            this.dgvPIs.ReadOnly = true;
            this.dgvPIs.RowHeadersVisible = false;
            this.dgvPIs.Size = new System.Drawing.Size(229, 170);
            this.dgvPIs.TabIndex = 13;
            this.dgvPIs.Visible = false;
            // 
            // LCDetailID
            // 
            this.LCDetailID.HeaderText = "LCDetailID";
            this.LCDetailID.Name = "LCDetailID";
            this.LCDetailID.ReadOnly = true;
            // 
            // PIID
            // 
            this.PIID.HeaderText = "PIID";
            this.PIID.Name = "PIID";
            this.PIID.ReadOnly = true;
            // 
            // btnAmend
            // 
            this.btnAmend.BackColor = System.Drawing.SystemColors.Control;
            this.btnAmend.Location = new System.Drawing.Point(307, 453);
            this.btnAmend.Name = "btnAmend";
            this.btnAmend.Size = new System.Drawing.Size(75, 23);
            this.btnAmend.TabIndex = 5;
            this.btnAmend.Text = "&Amendment";
            this.btnAmend.UseVisualStyleBackColor = false;
            this.btnAmend.Click += new System.EventHandler(this.btnAmendment_Click);
            // 
            // ctlDGVLC
            // 
            this.ctlDGVLC.AllowUserToAddRows = false;
            this.ctlDGVLC.AllowUserToDeleteRows = false;
            this.ctlDGVLC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ctlDGVLC.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctlDGVLC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDGVLC.ContextMenuFields = null;
            this.ctlDGVLC.GridColor = System.Drawing.Color.Silver;
            this.ctlDGVLC.IsSortable = false;
            this.ctlDGVLC.Location = new System.Drawing.Point(9, 223);
            this.ctlDGVLC.Name = "ctlDGVLC";
            this.ctlDGVLC.ReadOnly = true;
            this.ctlDGVLC.RowHeadersVisible = false;
            this.ctlDGVLC.RowPointer = 0;
            this.ctlDGVLC.ShowDateTimePicker = true;
            this.ctlDGVLC.Size = new System.Drawing.Size(784, 225);
            this.ctlDGVLC.TabIndex = 1;
            this.ctlDGVLC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlDGVLC_CellContentClick);
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(585, 454);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(50, 20);
            this.txtUnit.TabIndex = 14;
            // 
            // frmLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 479);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.btnAmend);
            this.Controls.Add(this.dgvPIs);
            this.Controls.Add(this.txtTotalValue);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.ctlDGVLC);
            this.Controls.Add(this.lblTotalQTY);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LC";
            this.Load += new System.EventHandler(this.frmLC_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmLC_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPIs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVLC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Accounting.Controls.ctlDaraGridView ctlDGVLC;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.CheckBox CHKUDDate;
        private System.Windows.Forms.ComboBox cmbLCType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLCNo;
        private System.Windows.Forms.DateTimePicker DTPLCDate;
        private System.Windows.Forms.TextBox txtMasterLCNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbNeBank;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DTPAcceptDate;
        private System.Windows.Forms.DateTimePicker DTPUDDate;
        private System.Windows.Forms.DateTimePicker DTPShipmentDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPINo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox CHKNegotiationDate;
        private System.Windows.Forms.CheckBox CHKDocumentDate;
        private System.Windows.Forms.DateTimePicker DTPNegDate;
        private System.Windows.Forms.DateTimePicker DTPDocDate;
        private System.Windows.Forms.DateTimePicker DTPExpireDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox LCMasterID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTotalQTY;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.TextBox txtTotalValue;
        private System.Windows.Forms.TextBox txtAtSight;
        private System.Windows.Forms.LinkLabel llblPIs;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker DTPActualShDate;
        private System.Windows.Forms.CheckBox chkActualShDate;
        private System.Windows.Forms.CheckBox chkAcceptDate;
        private System.Windows.Forms.DateTimePicker dtpPaidDate;
        private System.Windows.Forms.CheckBox chkPaid;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGetLC;
        private System.Windows.Forms.TextBox txtCustSupp;
        private System.Windows.Forms.Label lblCustSupp;
        private System.Windows.Forms.DataGridView dgvPIs;
        private System.Windows.Forms.Button btnAmend;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridViewTextBoxColumn LCDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIID;
        private System.Windows.Forms.CheckBox chkAddPI;
        private System.Windows.Forms.LinkLabel llblLCAcceptance;
        private System.Windows.Forms.CheckBox chkMasterLC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTPUnderLCDate;
        private System.Windows.Forms.LinkLabel llblUnderLC;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label16;
    }
}