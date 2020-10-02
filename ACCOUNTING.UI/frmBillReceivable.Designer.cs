namespace Accounting.UI
{
    partial class frmBillReceivable
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
            this.gbxInput = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtAdjID = new System.Windows.Forms.TextBox();
            this.dtpCollectDate = new System.Windows.Forms.DateTimePicker();
            this.txtChequeLCNo = new System.Windows.Forms.TextBox();
            this.cboColMethod = new System.Windows.Forms.ComboBox();
            this.ctlNumColAmt = new Accounting.Controls.ctlNum();
            this.txtCollectToAcc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRefNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBillOfAcc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.ctldgvAdjusts = new Accounting.Controls.ctlDaraGridView();
            this.ctldgvBills = new Accounting.Controls.ctlDaraGridView();
            this.ctlNumDue = new Accounting.Controls.ctlNum();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpEntry = new System.Windows.Forms.TabPage();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpEdate = new System.Windows.Forms.DateTimePicker();
            this.dtpSdate = new System.Windows.Forms.DateTimePicker();
            this.chkSrcDate = new System.Windows.Forms.CheckBox();
            this.txtSrcCustomer = new System.Windows.Forms.TextBox();
            this.chkSupplier = new System.Windows.Forms.CheckBox();
            this.ctlNumBillQty = new Accounting.Controls.ctlNum();
            this.label22 = new System.Windows.Forms.Label();
            this.lblTransRefID = new System.Windows.Forms.Label();
            this.btnBEClose = new System.Windows.Forms.Button();
            this.btnDelBill = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvBills = new Accounting.Controls.ctlDaraGridView();
            this.ctlNumRate = new Accounting.Controls.ctlNum();
            this.ctlNumBillAmt = new Accounting.Controls.ctlNum();
            this.ctlNumBillAmtTK = new Accounting.Controls.ctlNum();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.txtBillForAcc = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtBillToAcc = new System.Windows.Forms.TextBox();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lblCurrency1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tpReceive = new System.Windows.Forms.TabPage();
            this.gbxInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvAdjusts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvBills)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpEntry.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.tpReceive.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxInput
            // 
            this.gbxInput.BackColor = System.Drawing.Color.Transparent;
            this.gbxInput.Controls.Add(this.txtRemarks);
            this.gbxInput.Controls.Add(this.txtAdjID);
            this.gbxInput.Controls.Add(this.dtpCollectDate);
            this.gbxInput.Controls.Add(this.txtChequeLCNo);
            this.gbxInput.Controls.Add(this.cboColMethod);
            this.gbxInput.Controls.Add(this.ctlNumColAmt);
            this.gbxInput.Controls.Add(this.txtCollectToAcc);
            this.gbxInput.Controls.Add(this.label5);
            this.gbxInput.Controls.Add(this.label7);
            this.gbxInput.Controls.Add(this.label6);
            this.gbxInput.Controls.Add(this.lblRefNo);
            this.gbxInput.Controls.Add(this.label4);
            this.gbxInput.Controls.Add(this.label3);
            this.gbxInput.Location = new System.Drawing.Point(21, 230);
            this.gbxInput.Name = "gbxInput";
            this.gbxInput.Size = new System.Drawing.Size(306, 180);
            this.gbxInput.TabIndex = 2;
            this.gbxInput.TabStop = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(97, 154);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(208, 20);
            this.txtRemarks.TabIndex = 5;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.txtRemarks.Leave += new System.EventHandler(this.txtBillOfAcc_Leave);
            this.txtRemarks.Enter += new System.EventHandler(this.txtBillOfAcc_Enter);
            // 
            // txtAdjID
            // 
            this.txtAdjID.Location = new System.Drawing.Point(235, 19);
            this.txtAdjID.Name = "txtAdjID";
            this.txtAdjID.Size = new System.Drawing.Size(43, 20);
            this.txtAdjID.TabIndex = 6;
            this.txtAdjID.Text = "0";
            this.txtAdjID.Visible = false;
            // 
            // dtpCollectDate
            // 
            this.dtpCollectDate.CustomFormat = "dd/MM/yyyy";
            this.dtpCollectDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCollectDate.Location = new System.Drawing.Point(97, 128);
            this.dtpCollectDate.Name = "dtpCollectDate";
            this.dtpCollectDate.Size = new System.Drawing.Size(121, 20);
            this.dtpCollectDate.TabIndex = 4;
            this.dtpCollectDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // txtChequeLCNo
            // 
            this.txtChequeLCNo.Location = new System.Drawing.Point(98, 71);
            this.txtChequeLCNo.Name = "txtChequeLCNo";
            this.txtChequeLCNo.Size = new System.Drawing.Size(121, 20);
            this.txtChequeLCNo.TabIndex = 2;
            this.txtChequeLCNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            this.txtChequeLCNo.Leave += new System.EventHandler(this.txtBillOfAcc_Leave);
            this.txtChequeLCNo.Enter += new System.EventHandler(this.txtBillOfAcc_Enter);
            // 
            // cboColMethod
            // 
            this.cboColMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColMethod.FormattingEnabled = true;
            this.cboColMethod.Location = new System.Drawing.Point(98, 16);
            this.cboColMethod.Name = "cboColMethod";
            this.cboColMethod.Size = new System.Drawing.Size(121, 21);
            this.cboColMethod.TabIndex = 0;
            this.cboColMethod.Enter += new System.EventHandler(this.cboColMethod_Enter);
            this.cboColMethod.SelectedValueChanged += new System.EventHandler(this.cboColMethod_SelectedValueChanged);
            this.cboColMethod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // ctlNumColAmt
            // 
            this.ctlNumColAmt.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumColAmt.Location = new System.Drawing.Point(98, 44);
            this.ctlNumColAmt.Name = "ctlNumColAmt";
            this.ctlNumColAmt.ReadOnly = false;
            this.ctlNumColAmt.Size = new System.Drawing.Size(121, 20);
            this.ctlNumColAmt.TabIndex = 1;
            this.ctlNumColAmt.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumColAmt.Value = 0;
            this.ctlNumColAmt.Leave += new System.EventHandler(this.txtBillOfAcc_Leave);
            this.ctlNumColAmt.Enter += new System.EventHandler(this.txtBillOfAcc_Enter);
            this.ctlNumColAmt.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctlNumColAmt_valueChanged);
            this.ctlNumColAmt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_KeyDown);
            // 
            // txtCollectToAcc
            // 
            this.txtCollectToAcc.BackColor = System.Drawing.Color.White;
            this.txtCollectToAcc.Location = new System.Drawing.Point(98, 98);
            this.txtCollectToAcc.Name = "txtCollectToAcc";
            this.txtCollectToAcc.ReadOnly = true;
            this.txtCollectToAcc.Size = new System.Drawing.Size(207, 20);
            this.txtCollectToAcc.TabIndex = 3;
            this.txtCollectToAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBillOfAcc_KeyDown);
            this.txtCollectToAcc.Leave += new System.EventHandler(this.txtBillOfAcc_Leave);
            this.txtCollectToAcc.Enter += new System.EventHandler(this.txtBillOfAcc_Enter);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Remarks";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Collect Date";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Collect to";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRefNo
            // 
            this.lblRefNo.Location = new System.Drawing.Point(11, 70);
            this.lblRefNo.Name = "lblRefNo";
            this.lblRefNo.Size = new System.Drawing.Size(81, 20);
            this.lblRefNo.TabIndex = 0;
            this.lblRefNo.Text = "Cheque No. ";
            this.lblRefNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Collect Now TK.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Collect Method";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(18, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Due Amount";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBillOfAcc
            // 
            this.txtBillOfAcc.BackColor = System.Drawing.Color.White;
            this.txtBillOfAcc.Location = new System.Drawing.Point(56, 4);
            this.txtBillOfAcc.Name = "txtBillOfAcc";
            this.txtBillOfAcc.ReadOnly = true;
            this.txtBillOfAcc.Size = new System.Drawing.Size(265, 20);
            this.txtBillOfAcc.TabIndex = 0;
            this.txtBillOfAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBillOfAcc_KeyDown);
            this.txtBillOfAcc.Leave += new System.EventHandler(this.txtBillOfAcc_Leave);
            this.txtBillOfAcc.Enter += new System.EventHandler(this.txtBillOfAcc_Enter);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bill of";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(76, 428);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 3;
            this.btnPost.Text = "&Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(159, 428);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(242, 428);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            this.chkAll.Location = new System.Drawing.Point(376, 6);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(58, 17);
            this.chkAll.TabIndex = 1;
            this.chkAll.TabStop = false;
            this.chkAll.Text = "All Bills";
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // ctldgvAdjusts
            // 
            this.ctldgvAdjusts.AllowUserToAddRows = false;
            this.ctldgvAdjusts.AllowUserToDeleteRows = false;
            this.ctldgvAdjusts.AllowUserToOrderColumns = true;
            this.ctldgvAdjusts.AllowUserToResizeColumns = false;
            this.ctldgvAdjusts.AllowUserToResizeRows = false;
            this.ctldgvAdjusts.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctldgvAdjusts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctldgvAdjusts.ContextMenuFields = null;
            this.ctldgvAdjusts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ctldgvAdjusts.IsSortable = false;
            this.ctldgvAdjusts.Location = new System.Drawing.Point(333, 214);
            this.ctldgvAdjusts.MultiSelect = false;
            this.ctldgvAdjusts.Name = "ctldgvAdjusts";
            this.ctldgvAdjusts.ReadOnly = true;
            this.ctldgvAdjusts.RowHeadersVisible = false;
            this.ctldgvAdjusts.RowPointer = 0;
            this.ctldgvAdjusts.RowTemplate.ReadOnly = true;
            this.ctldgvAdjusts.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctldgvAdjusts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctldgvAdjusts.ShowDateTimePicker = false;
            this.ctldgvAdjusts.Size = new System.Drawing.Size(448, 235);
            this.ctldgvAdjusts.TabIndex = 8;
            // 
            // ctldgvBills
            // 
            this.ctldgvBills.AllowUserToAddRows = false;
            this.ctldgvBills.AllowUserToDeleteRows = false;
            this.ctldgvBills.AllowUserToResizeColumns = false;
            this.ctldgvBills.AllowUserToResizeRows = false;
            this.ctldgvBills.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctldgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctldgvBills.ContextMenuFields = null;
            this.ctldgvBills.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ctldgvBills.IsSortable = false;
            this.ctldgvBills.Location = new System.Drawing.Point(8, 27);
            this.ctldgvBills.MultiSelect = false;
            this.ctldgvBills.Name = "ctldgvBills";
            this.ctldgvBills.ReadOnly = true;
            this.ctldgvBills.RowHeadersVisible = false;
            this.ctldgvBills.RowPointer = 0;
            this.ctldgvBills.RowTemplate.ReadOnly = true;
            this.ctldgvBills.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctldgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctldgvBills.ShowDateTimePicker = false;
            this.ctldgvBills.Size = new System.Drawing.Size(776, 174);
            this.ctldgvBills.TabIndex = 7;
            // 
            // ctlNumDue
            // 
            this.ctlNumDue.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumDue.Location = new System.Drawing.Point(118, 207);
            this.ctlNumDue.Name = "ctlNumDue";
            this.ctlNumDue.ReadOnly = true;
            this.ctlNumDue.Size = new System.Drawing.Size(121, 20);
            this.ctlNumDue.TabIndex = 1;
            this.ctlNumDue.TabStop = false;
            this.ctlNumDue.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumDue.Value = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpEntry);
            this.tabControl1.Controls.Add(this.tpReceive);
            this.tabControl1.Location = new System.Drawing.Point(3, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(805, 486);
            this.tabControl1.TabIndex = 9;
            // 
            // tpEntry
            // 
            this.tpEntry.Controls.Add(this.cmbCurrency);
            this.tpEntry.Controls.Add(this.btnReset);
            this.tpEntry.Controls.Add(this.groupBox1);
            this.tpEntry.Controls.Add(this.ctlNumBillQty);
            this.tpEntry.Controls.Add(this.label22);
            this.tpEntry.Controls.Add(this.lblTransRefID);
            this.tpEntry.Controls.Add(this.btnBEClose);
            this.tpEntry.Controls.Add(this.btnDelBill);
            this.tpEntry.Controls.Add(this.btnSave);
            this.tpEntry.Controls.Add(this.dgvBills);
            this.tpEntry.Controls.Add(this.ctlNumRate);
            this.tpEntry.Controls.Add(this.ctlNumBillAmt);
            this.tpEntry.Controls.Add(this.ctlNumBillAmtTK);
            this.tpEntry.Controls.Add(this.dtpBillDate);
            this.tpEntry.Controls.Add(this.txtBillForAcc);
            this.tpEntry.Controls.Add(this.txtComment);
            this.tpEntry.Controls.Add(this.txtBillToAcc);
            this.tpEntry.Controls.Add(this.txtBillNo);
            this.tpEntry.Controls.Add(this.label20);
            this.tpEntry.Controls.Add(this.lblCurrency1);
            this.tpEntry.Controls.Add(this.label17);
            this.tpEntry.Controls.Add(this.label18);
            this.tpEntry.Controls.Add(this.label14);
            this.tpEntry.Controls.Add(this.label15);
            this.tpEntry.Controls.Add(this.label13);
            this.tpEntry.Controls.Add(this.label12);
            this.tpEntry.Controls.Add(this.label11);
            this.tpEntry.Controls.Add(this.label10);
            this.tpEntry.Location = new System.Drawing.Point(4, 22);
            this.tpEntry.Name = "tpEntry";
            this.tpEntry.Padding = new System.Windows.Forms.Padding(3);
            this.tpEntry.Size = new System.Drawing.Size(797, 460);
            this.tpEntry.TabIndex = 1;
            this.tpEntry.Text = "Sales Bill Entry";
            this.tpEntry.UseVisualStyleBackColor = true;
            this.tpEntry.Paint += new System.Windows.Forms.PaintEventHandler(this.frmBillReceivable_Paint);
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(222, 110);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(96, 21);
            this.cmbCurrency.TabIndex = 85;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(450, 435);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 84;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dtpEdate);
            this.groupBox1.Controls.Add(this.dtpSdate);
            this.groupBox1.Controls.Add(this.chkSrcDate);
            this.groupBox1.Controls.Add(this.txtSrcCustomer);
            this.groupBox1.Controls.Add(this.chkSupplier);
            this.groupBox1.Location = new System.Drawing.Point(8, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 42);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(616, 19);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 13);
            this.label25.TabIndex = 7;
            this.label25.Text = "to";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(733, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(27, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = ">>";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEdate
            // 
            this.dtpEdate.CustomFormat = "dd/MM/yyyy";
            this.dtpEdate.Enabled = false;
            this.dtpEdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEdate.Location = new System.Drawing.Point(637, 15);
            this.dtpEdate.Name = "dtpEdate";
            this.dtpEdate.Size = new System.Drawing.Size(90, 20);
            this.dtpEdate.TabIndex = 5;
            // 
            // dtpSdate
            // 
            this.dtpSdate.CustomFormat = "dd/MM/yyyy";
            this.dtpSdate.Enabled = false;
            this.dtpSdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSdate.Location = new System.Drawing.Point(521, 15);
            this.dtpSdate.Name = "dtpSdate";
            this.dtpSdate.Size = new System.Drawing.Size(90, 20);
            this.dtpSdate.TabIndex = 5;
            // 
            // chkSrcDate
            // 
            this.chkSrcDate.AutoSize = true;
            this.chkSrcDate.Location = new System.Drawing.Point(448, 18);
            this.chkSrcDate.Name = "chkSrcDate";
            this.chkSrcDate.Size = new System.Drawing.Size(72, 17);
            this.chkSrcDate.TabIndex = 4;
            this.chkSrcDate.Text = "Date from";
            this.chkSrcDate.UseVisualStyleBackColor = true;
            this.chkSrcDate.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // txtSrcCustomer
            // 
            this.txtSrcCustomer.BackColor = System.Drawing.Color.White;
            this.txtSrcCustomer.Enabled = false;
            this.txtSrcCustomer.Location = new System.Drawing.Point(77, 16);
            this.txtSrcCustomer.Name = "txtSrcCustomer";
            this.txtSrcCustomer.ReadOnly = true;
            this.txtSrcCustomer.Size = new System.Drawing.Size(365, 20);
            this.txtSrcCustomer.TabIndex = 3;
            this.txtSrcCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSrcSupplier_KeyDown);
            // 
            // chkSupplier
            // 
            this.chkSupplier.AutoSize = true;
            this.chkSupplier.Location = new System.Drawing.Point(6, 18);
            this.chkSupplier.Name = "chkSupplier";
            this.chkSupplier.Size = new System.Drawing.Size(70, 17);
            this.chkSupplier.TabIndex = 2;
            this.chkSupplier.Text = "Customer";
            this.chkSupplier.UseVisualStyleBackColor = true;
            this.chkSupplier.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // ctlNumBillQty
            // 
            this.ctlNumBillQty.BackColor = System.Drawing.Color.White;
            this.ctlNumBillQty.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumBillQty.Location = new System.Drawing.Point(103, 137);
            this.ctlNumBillQty.Name = "ctlNumBillQty";
            this.ctlNumBillQty.ReadOnly = false;
            this.ctlNumBillQty.Size = new System.Drawing.Size(113, 20);
            this.ctlNumBillQty.TabIndex = 56;
            this.ctlNumBillQty.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumBillQty.Value = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(24, 137);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 13);
            this.label22.TabIndex = 80;
            this.label22.Text = "Bill Qty";
            // 
            // lblTransRefID
            // 
            this.lblTransRefID.AutoSize = true;
            this.lblTransRefID.Location = new System.Drawing.Point(294, 36);
            this.lblTransRefID.Name = "lblTransRefID";
            this.lblTransRefID.Size = new System.Drawing.Size(13, 13);
            this.lblTransRefID.TabIndex = 77;
            this.lblTransRefID.Text = "0";
            this.lblTransRefID.Visible = false;
            // 
            // btnBEClose
            // 
            this.btnBEClose.Location = new System.Drawing.Point(697, 435);
            this.btnBEClose.Name = "btnBEClose";
            this.btnBEClose.Size = new System.Drawing.Size(75, 23);
            this.btnBEClose.TabIndex = 62;
            this.btnBEClose.Text = "&Close";
            this.btnBEClose.UseVisualStyleBackColor = true;
            this.btnBEClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelBill
            // 
            this.btnDelBill.Location = new System.Drawing.Point(614, 435);
            this.btnDelBill.Name = "btnDelBill";
            this.btnDelBill.Size = new System.Drawing.Size(75, 23);
            this.btnDelBill.TabIndex = 61;
            this.btnDelBill.Text = "&Delete";
            this.btnDelBill.UseVisualStyleBackColor = true;
            this.btnDelBill.Click += new System.EventHandler(this.btnDelBill_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(531, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 60;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.AllowUserToResizeColumns = false;
            this.dgvBills.AllowUserToResizeRows = false;
            this.dgvBills.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBills.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.ContextMenuFields = null;
            this.dgvBills.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvBills.IsSortable = false;
            this.dgvBills.Location = new System.Drawing.Point(8, 245);
            this.dgvBills.MultiSelect = false;
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.RowHeadersVisible = false;
            this.dgvBills.RowPointer = 0;
            this.dgvBills.RowTemplate.ReadOnly = true;
            this.dgvBills.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBills.ShowDateTimePicker = false;
            this.dgvBills.Size = new System.Drawing.Size(780, 186);
            this.dgvBills.TabIndex = 63;
            this.dgvBills.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBills_CellDoubleClick);
            // 
            // ctlNumRate
            // 
            this.ctlNumRate.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumRate.Location = new System.Drawing.Point(403, 111);
            this.ctlNumRate.Name = "ctlNumRate";
            this.ctlNumRate.ReadOnly = false;
            this.ctlNumRate.Size = new System.Drawing.Size(113, 20);
            this.ctlNumRate.TabIndex = 54;
            this.ctlNumRate.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumRate.Value = 0;
            this.ctlNumRate.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.BillOrRate_ValueChanged);
            // 
            // ctlNumBillAmt
            // 
            this.ctlNumBillAmt.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumBillAmt.Location = new System.Drawing.Point(103, 111);
            this.ctlNumBillAmt.Name = "ctlNumBillAmt";
            this.ctlNumBillAmt.ReadOnly = false;
            this.ctlNumBillAmt.Size = new System.Drawing.Size(113, 20);
            this.ctlNumBillAmt.TabIndex = 53;
            this.ctlNumBillAmt.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumBillAmt.Value = 0;
            this.ctlNumBillAmt.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.BillOrRate_ValueChanged);
            // 
            // ctlNumBillAmtTK
            // 
            this.ctlNumBillAmtTK.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumBillAmtTK.Location = new System.Drawing.Point(617, 115);
            this.ctlNumBillAmtTK.Name = "ctlNumBillAmtTK";
            this.ctlNumBillAmtTK.ReadOnly = true;
            this.ctlNumBillAmtTK.Size = new System.Drawing.Size(113, 20);
            this.ctlNumBillAmtTK.TabIndex = 55;
            this.ctlNumBillAmtTK.TabStop = false;
            this.ctlNumBillAmtTK.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumBillAmtTK.Value = 0;
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillDate.Location = new System.Drawing.Point(103, 36);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(113, 20);
            this.dtpBillDate.TabIndex = 46;
            // 
            // txtBillForAcc
            // 
            this.txtBillForAcc.BackColor = System.Drawing.Color.White;
            this.txtBillForAcc.Location = new System.Drawing.Point(103, 61);
            this.txtBillForAcc.Name = "txtBillForAcc";
            this.txtBillForAcc.ReadOnly = true;
            this.txtBillForAcc.Size = new System.Drawing.Size(302, 20);
            this.txtBillForAcc.TabIndex = 47;
            this.txtBillForAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcc_KeyDown);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(103, 163);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(516, 28);
            this.txtComment.TabIndex = 59;
            // 
            // txtBillToAcc
            // 
            this.txtBillToAcc.BackColor = System.Drawing.Color.White;
            this.txtBillToAcc.Location = new System.Drawing.Point(103, 86);
            this.txtBillToAcc.Name = "txtBillToAcc";
            this.txtBillToAcc.ReadOnly = true;
            this.txtBillToAcc.Size = new System.Drawing.Size(302, 20);
            this.txtBillToAcc.TabIndex = 48;
            this.txtBillToAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcc_KeyDown);
            // 
            // txtBillNo
            // 
            this.txtBillNo.Location = new System.Drawing.Point(103, 11);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(113, 20);
            this.txtBillNo.TabIndex = 45;
            this.txtBillNo.Tag = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(740, 118);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 13);
            this.label20.TabIndex = 70;
            this.label20.Text = "TK.";
            // 
            // lblCurrency1
            // 
            this.lblCurrency1.AutoSize = true;
            this.lblCurrency1.Location = new System.Drawing.Point(370, 114);
            this.lblCurrency1.Name = "lblCurrency1";
            this.lblCurrency1.Size = new System.Drawing.Size(0, 13);
            this.lblCurrency1.TabIndex = 66;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(324, 114);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 13);
            this.label17.TabIndex = 69;
            this.label17.Text = "Currency Rate";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(24, 114);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 71;
            this.label18.Text = "Bill Amount";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(526, 118);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 72;
            this.label14.Text = "Bill Amount";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(24, 163);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 65;
            this.label15.Text = "Remarks";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(24, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 64;
            this.label13.Text = "Bill to";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(24, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 75;
            this.label12.Text = "Bill For";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(24, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 74;
            this.label11.Text = "Bill Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(24, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 73;
            this.label10.Text = "Bill Ref No.";
            // 
            // tpReceive
            // 
            this.tpReceive.Controls.Add(this.label1);
            this.tpReceive.Controls.Add(this.chkAll);
            this.tpReceive.Controls.Add(this.label2);
            this.tpReceive.Controls.Add(this.btnClose);
            this.tpReceive.Controls.Add(this.txtBillOfAcc);
            this.tpReceive.Controls.Add(this.btnDelete);
            this.tpReceive.Controls.Add(this.ctlNumDue);
            this.tpReceive.Controls.Add(this.btnPost);
            this.tpReceive.Controls.Add(this.ctldgvBills);
            this.tpReceive.Controls.Add(this.gbxInput);
            this.tpReceive.Controls.Add(this.ctldgvAdjusts);
            this.tpReceive.Location = new System.Drawing.Point(4, 22);
            this.tpReceive.Name = "tpReceive";
            this.tpReceive.Padding = new System.Windows.Forms.Padding(3);
            this.tpReceive.Size = new System.Drawing.Size(797, 460);
            this.tpReceive.TabIndex = 0;
            this.tpReceive.Text = "Bill Receive";
            this.tpReceive.UseVisualStyleBackColor = true;
            this.tpReceive.Paint += new System.Windows.Forms.PaintEventHandler(this.frmBillReceivable_Paint);
            // 
            // frmBillReceivable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 498);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBillReceivable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bill Receivable";
            this.Load += new System.EventHandler(this.frmBillReceivable_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmBillReceivable_Paint);
            this.gbxInput.ResumeLayout(false);
            this.gbxInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvAdjusts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvBills)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpEntry.ResumeLayout(false);
            this.tpEntry.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.tpReceive.ResumeLayout(false);
            this.tpReceive.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxInput;
        private System.Windows.Forms.DateTimePicker dtpCollectDate;
        private System.Windows.Forms.TextBox txtChequeLCNo;
        private System.Windows.Forms.ComboBox cboColMethod;
        private Accounting.Controls.ctlNum ctlNumColAmt;
        private System.Windows.Forms.TextBox txtCollectToAcc;
        private Accounting.Controls.ctlNum ctlNumDue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRefNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Accounting.Controls.ctlDaraGridView ctldgvAdjusts;
        private Accounting.Controls.ctlDaraGridView ctldgvBills;
        private System.Windows.Forms.TextBox txtBillOfAcc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtAdjID;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpReceive;
        private System.Windows.Forms.TabPage tpEntry;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpEdate;
        private System.Windows.Forms.DateTimePicker dtpSdate;
        private System.Windows.Forms.CheckBox chkSrcDate;
        private System.Windows.Forms.TextBox txtSrcCustomer;
        private System.Windows.Forms.CheckBox chkSupplier;
        private Accounting.Controls.ctlNum ctlNumBillQty;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblTransRefID;
        private System.Windows.Forms.Button btnBEClose;
        private System.Windows.Forms.Button btnDelBill;
        private System.Windows.Forms.Button btnSave;
        private Accounting.Controls.ctlDaraGridView dgvBills;
        private Accounting.Controls.ctlNum ctlNumRate;
        private Accounting.Controls.ctlNum ctlNumBillAmt;
        private Accounting.Controls.ctlNum ctlNumBillAmtTK;
        private System.Windows.Forms.DateTimePicker dtpBillDate;
        private System.Windows.Forms.TextBox txtBillForAcc;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtBillToAcc;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblCurrency1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}