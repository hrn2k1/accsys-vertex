namespace Accounting.UI
{
    partial class frmPI
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
            this.txtPINO = new System.Windows.Forms.TextBox();
            this.dtpPIDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCustSupp = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.dgvOrderRefNo = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAddOrders = new System.Windows.Forms.CheckBox();
            this.llblPIOrder = new System.Windows.Forms.LinkLabel();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbDefault = new System.Windows.Forms.RadioButton();
            this.rbCustome = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPIType = new System.Windows.Forms.ComboBox();
            this.cmbFactory = new System.Windows.Forms.ComboBox();
            this.lblFactory = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtAttention = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtTemrs = new System.Windows.Forms.TextBox();
            this.gbxTerms = new System.Windows.Forms.GroupBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.PIDID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPIMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrintPI = new System.Windows.Forms.Button();
            this.llblSave = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderRefNo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxTerms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "PI NO.";
            // 
            // txtPINO
            // 
            this.txtPINO.Enabled = false;
            this.txtPINO.Location = new System.Drawing.Point(133, 20);
            this.txtPINO.Margin = new System.Windows.Forms.Padding(0);
            this.txtPINO.Name = "txtPINO";
            this.txtPINO.Size = new System.Drawing.Size(141, 20);
            this.txtPINO.TabIndex = 2;
            this.txtPINO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPINO_KeyDown);
            this.txtPINO.Leave += new System.EventHandler(this.txtPINO_Leave);
            this.txtPINO.Enter += new System.EventHandler(this.txtPINO_Enter);
            // 
            // dtpPIDate
            // 
            this.dtpPIDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPIDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPIDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPIDate.Location = new System.Drawing.Point(524, 54);
            this.dtpPIDate.Name = "dtpPIDate";
            this.dtpPIDate.Size = new System.Drawing.Size(106, 22);
            this.dtpPIDate.TabIndex = 6;
            this.dtpPIDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "PI Date";
            // 
            // lblCustSupp
            // 
            this.lblCustSupp.AutoSize = true;
            this.lblCustSupp.Location = new System.Drawing.Point(6, 40);
            this.lblCustSupp.Name = "lblCustSupp";
            this.lblCustSupp.Size = new System.Drawing.Size(51, 13);
            this.lblCustSupp.TabIndex = 98;
            this.lblCustSupp.Text = "Customer";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(117, 39);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(180, 20);
            this.txtCustomer.TabIndex = 1;
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            this.txtCustomer.Leave += new System.EventHandler(this.txtPINO_Leave);
            this.txtCustomer.Enter += new System.EventHandler(this.txtPINO_Enter);
            // 
            // dgvOrderRefNo
            // 
            this.dgvOrderRefNo.AllowUserToAddRows = false;
            this.dgvOrderRefNo.AllowUserToDeleteRows = false;
            this.dgvOrderRefNo.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvOrderRefNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderRefNo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvOrderRefNo.Location = new System.Drawing.Point(8, 145);
            this.dgvOrderRefNo.Margin = new System.Windows.Forms.Padding(0);
            this.dgvOrderRefNo.MultiSelect = false;
            this.dgvOrderRefNo.Name = "dgvOrderRefNo";
            this.dgvOrderRefNo.ReadOnly = true;
            this.dgvOrderRefNo.RowHeadersVisible = false;
            this.dgvOrderRefNo.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrderRefNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOrderRefNo.Size = new System.Drawing.Size(764, 183);
            this.dgvOrderRefNo.TabIndex = 1;
            this.dgvOrderRefNo.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkAddOrders);
            this.groupBox1.Controls.Add(this.llblPIOrder);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbCurrency);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbPIType);
            this.groupBox1.Controls.Add(this.cmbFactory);
            this.groupBox1.Controls.Add(this.lblFactory);
            this.groupBox1.Controls.Add(this.txtCustomerID);
            this.groupBox1.Controls.Add(this.txtAttention);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpPIDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.lblCustSupp);
            this.groupBox1.Location = new System.Drawing.Point(8, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PI Information";
            // 
            // chkAddOrders
            // 
            this.chkAddOrders.AutoSize = true;
            this.chkAddOrders.Location = new System.Drawing.Point(639, 100);
            this.chkAddOrders.Name = "chkAddOrders";
            this.chkAddOrders.Size = new System.Drawing.Size(79, 17);
            this.chkAddOrders.TabIndex = 9;
            this.chkAddOrders.TabStop = false;
            this.chkAddOrders.Text = "Add Orders";
            this.chkAddOrders.UseVisualStyleBackColor = true;
            // 
            // llblPIOrder
            // 
            this.llblPIOrder.AutoSize = true;
            this.llblPIOrder.Location = new System.Drawing.Point(453, 99);
            this.llblPIOrder.Name = "llblPIOrder";
            this.llblPIOrder.Size = new System.Drawing.Size(175, 13);
            this.llblPIOrder.TabIndex = 8;
            this.llblPIOrder.TabStop = true;
            this.llblPIOrder.Text = "Select Order(s) for Proforma Invoice";
            this.llblPIOrder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblPIOrder_LinkClicked);
            this.llblPIOrder.Leave += new System.EventHandler(this.llblPIOrder_Leave);
            this.llblPIOrder.Enter += new System.EventHandler(this.llblPIOrder_Enter);
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(672, 31);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(75, 20);
            this.txtRate.TabIndex = 5;
            this.txtRate.Text = "1";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker1_KeyDown);
            this.txtRate.Leave += new System.EventHandler(this.txtPINO_Leave);
            this.txtRate.Enter += new System.EventHandler(this.txtPINO_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(636, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 101;
            this.label8.Text = "Rate";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(524, 31);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(106, 21);
            this.cmbCurrency.TabIndex = 4;
            this.cmbCurrency.Enter += new System.EventHandler(this.cmbPIType_Enter);
            this.cmbCurrency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbFactory_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "Currency";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbDefault);
            this.groupBox2.Controls.Add(this.rbCustome);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtPINO);
            this.groupBox2.Location = new System.Drawing.Point(9, 62);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 57);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PI No. Setup";
            // 
            // rbDefault
            // 
            this.rbDefault.AutoSize = true;
            this.rbDefault.Checked = true;
            this.rbDefault.Location = new System.Drawing.Point(7, 13);
            this.rbDefault.Margin = new System.Windows.Forms.Padding(0);
            this.rbDefault.Name = "rbDefault";
            this.rbDefault.Size = new System.Drawing.Size(72, 17);
            this.rbDefault.TabIndex = 0;
            this.rbDefault.TabStop = true;
            this.rbDefault.Text = "Default PI";
            this.rbDefault.UseVisualStyleBackColor = true;
            this.rbDefault.Leave += new System.EventHandler(this.rbDefault_Leave);
            this.rbDefault.Enter += new System.EventHandler(this.rbDefault_Enter);
            this.rbDefault.CheckedChanged += new System.EventHandler(this.rbDefault_CheckedChanged);
            this.rbDefault.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbDefault_KeyDown);
            // 
            // rbCustome
            // 
            this.rbCustome.AutoSize = true;
            this.rbCustome.Location = new System.Drawing.Point(7, 32);
            this.rbCustome.Margin = new System.Windows.Forms.Padding(0);
            this.rbCustome.Name = "rbCustome";
            this.rbCustome.Size = new System.Drawing.Size(81, 17);
            this.rbCustome.TabIndex = 1;
            this.rbCustome.Text = "Cutomize PI";
            this.rbCustome.UseVisualStyleBackColor = true;
            this.rbCustome.Leave += new System.EventHandler(this.rbCustome_Leave);
            this.rbCustome.Enter += new System.EventHandler(this.rbCustome_Enter);
            this.rbCustome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rbCustome_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 90;
            this.label7.Text = "Proforma Invoice ";
            // 
            // cmbPIType
            // 
            this.cmbPIType.AllowDrop = true;
            this.cmbPIType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPIType.FormattingEnabled = true;
            this.cmbPIType.Items.AddRange(new object[] {
            "To Customer",
            "From Supplier"});
            this.cmbPIType.Location = new System.Drawing.Point(117, 15);
            this.cmbPIType.Name = "cmbPIType";
            this.cmbPIType.Size = new System.Drawing.Size(180, 21);
            this.cmbPIType.TabIndex = 0;
            this.cmbPIType.Enter += new System.EventHandler(this.cmbPIType_Enter);
            this.cmbPIType.SelectedValueChanged += new System.EventHandler(this.cmbPIType_SelectedValueChanged_1);
            this.cmbPIType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPIType_KeyDown);
            // 
            // cmbFactory
            // 
            this.cmbFactory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFactory.FormattingEnabled = true;
            this.cmbFactory.Location = new System.Drawing.Point(524, 9);
            this.cmbFactory.Name = "cmbFactory";
            this.cmbFactory.Size = new System.Drawing.Size(224, 21);
            this.cmbFactory.TabIndex = 3;
            this.cmbFactory.Enter += new System.EventHandler(this.cmbPIType_Enter);
            this.cmbFactory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbFactory_KeyDown);
            // 
            // lblFactory
            // 
            this.lblFactory.AutoSize = true;
            this.lblFactory.Location = new System.Drawing.Point(453, 12);
            this.lblFactory.Name = "lblFactory";
            this.lblFactory.Size = new System.Drawing.Size(65, 13);
            this.lblFactory.TabIndex = 88;
            this.lblFactory.Text = "Proforma To";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(86, 40);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(28, 20);
            this.txtCustomerID.TabIndex = 33;
            this.txtCustomerID.Text = "0";
            this.txtCustomerID.Visible = false;
            this.txtCustomerID.TextChanged += new System.EventHandler(this.txtCustomerID_TextChanged);
            // 
            // txtAttention
            // 
            this.txtAttention.Location = new System.Drawing.Point(524, 77);
            this.txtAttention.Multiline = true;
            this.txtAttention.Name = "txtAttention";
            this.txtAttention.Size = new System.Drawing.Size(224, 20);
            this.txtAttention.TabIndex = 7;
            this.txtAttention.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAttention_KeyDown);
            this.txtAttention.Leave += new System.EventHandler(this.txtPINO_Leave);
            this.txtAttention.Enter += new System.EventHandler(this.txtPINO_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(453, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Attention";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(374, 465);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            this.btnNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnNew_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(455, 465);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnNew_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(698, 465);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnNew_KeyDown);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(536, 465);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            this.btnFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnNew_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(617, 465);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDelete_KeyDown);
            // 
            // txtTemrs
            // 
            this.txtTemrs.BackColor = System.Drawing.Color.White;
            this.txtTemrs.Location = new System.Drawing.Point(6, 13);
            this.txtTemrs.Multiline = true;
            this.txtTemrs.Name = "txtTemrs";
            this.txtTemrs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTemrs.Size = new System.Drawing.Size(754, 89);
            this.txtTemrs.TabIndex = 0;
            this.txtTemrs.WordWrap = false;
            // 
            // gbxTerms
            // 
            this.gbxTerms.BackColor = System.Drawing.Color.Transparent;
            this.gbxTerms.Controls.Add(this.llblSave);
            this.gbxTerms.Controls.Add(this.txtItem);
            this.gbxTerms.Controls.Add(this.txtTemrs);
            this.gbxTerms.Location = new System.Drawing.Point(9, 331);
            this.gbxTerms.Name = "gbxTerms";
            this.gbxTerms.Size = new System.Drawing.Size(763, 128);
            this.gbxTerms.TabIndex = 2;
            this.gbxTerms.TabStop = false;
            this.gbxTerms.Text = "Terms && Condition";
            // 
            // txtItem
            // 
            this.txtItem.BackColor = System.Drawing.Color.White;
            this.txtItem.Location = new System.Drawing.Point(6, 105);
            this.txtItem.Margin = new System.Windows.Forms.Padding(0);
            this.txtItem.Multiline = true;
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(754, 17);
            this.txtItem.TabIndex = 1;
            this.txtItem.Visible = false;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PIDID,
            this.colPIMID,
            this.OrderID,
            this.OrderQty,
            this.OrderValue});
            this.dgvOrders.Location = new System.Drawing.Point(150, 145);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.Size = new System.Drawing.Size(274, 170);
            this.dgvOrders.TabIndex = 27;
            this.dgvOrders.Visible = false;
            // 
            // PIDID
            // 
            this.PIDID.HeaderText = "PIDID";
            this.PIDID.Name = "PIDID";
            this.PIDID.ReadOnly = true;
            // 
            // colPIMID
            // 
            this.colPIMID.HeaderText = "PIMID";
            this.colPIMID.Name = "colPIMID";
            this.colPIMID.ReadOnly = true;
            // 
            // OrderID
            // 
            this.OrderID.HeaderText = "OrderID";
            this.OrderID.Name = "OrderID";
            this.OrderID.ReadOnly = true;
            // 
            // OrderQty
            // 
            this.OrderQty.HeaderText = "OrderQty";
            this.OrderQty.Name = "OrderQty";
            this.OrderQty.ReadOnly = true;
            // 
            // OrderValue
            // 
            this.OrderValue.HeaderText = "OrderValue";
            this.OrderValue.Name = "OrderValue";
            this.OrderValue.ReadOnly = true;
            // 
            // btnPrintPI
            // 
            this.btnPrintPI.Location = new System.Drawing.Point(293, 465);
            this.btnPrintPI.Name = "btnPrintPI";
            this.btnPrintPI.Size = new System.Drawing.Size(75, 23);
            this.btnPrintPI.TabIndex = 8;
            this.btnPrintPI.Text = "&Print";
            this.btnPrintPI.UseVisualStyleBackColor = true;
            this.btnPrintPI.Click += new System.EventHandler(this.btnPrintPI_Click);
            // 
            // llblSave
            // 
            this.llblSave.AutoSize = true;
            this.llblSave.Location = new System.Drawing.Point(6, 105);
            this.llblSave.Name = "llblSave";
            this.llblSave.Size = new System.Drawing.Size(166, 13);
            this.llblSave.TabIndex = 28;
            this.llblSave.TabStop = true;
            this.llblSave.Text = "Save As Default Terms & Condition";
            this.llblSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSave_LinkClicked);
            // 
            // frmPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 492);
            this.Controls.Add(this.btnPrintPI);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.gbxTerms);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvOrderRefNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Proforma Invoice";
            this.Load += new System.EventHandler(this.frmPI_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPI_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderRefNo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxTerms.ResumeLayout(false);
            this.gbxTerms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPINO;
        private System.Windows.Forms.DateTimePicker dtpPIDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCustSupp;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.DataGridView dgvOrderRefNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAttention;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.RadioButton rbCustome;
        private System.Windows.Forms.RadioButton rbDefault;
        private System.Windows.Forms.ComboBox cmbFactory;
        private System.Windows.Forms.Label lblFactory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbPIType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtTemrs;
        private System.Windows.Forms.GroupBox gbxTerms;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPrintPI;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIDID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPIMID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderValue;
        private System.Windows.Forms.CheckBox chkAddOrders;
        private System.Windows.Forms.LinkLabel llblPIOrder;
        private System.Windows.Forms.LinkLabel llblSave;
    }
}