namespace Accounting.UI
{
    partial class frmLoan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRate = new System.Windows.Forms.Label();
            this.ctlNumRate = new Accounting.Controls.ctlNum();
            this.ctlNumAcceptedPercent = new Accounting.Controls.ctlNum();
            this.label17 = new System.Windows.Forms.Label();
            this.lblCurrency1 = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.ctlNumLoanAmountAtTK = new Accounting.Controls.ctlNum();
            this.label16 = new System.Windows.Forms.Label();
            this.lblTtlLoanAmt = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblLCValue = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtLoanAmount = new Accounting.Controls.ctlNum();
            this.lblAcceptValue1 = new System.Windows.Forms.Label();
            this.lblAcceptValue = new System.Windows.Forms.Label();
            this.cmbInterestPeriod = new System.Windows.Forms.ComboBox();
            this.DTPExpireDate = new System.Windows.Forms.DateTimePicker();
            this.DTPSanctionDate = new System.Windows.Forms.DateTimePicker();
            this.DTPApplyDate = new System.Windows.Forms.DateTimePicker();
            this.txtloanRefID = new System.Windows.Forms.TextBox();
            this.txtReffAccID = new System.Windows.Forms.TextBox();
            this.txtTransRefID = new System.Windows.Forms.TextBox();
            this.txtLCID = new System.Windows.Forms.TextBox();
            this.txtLoanID = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtDueAmount = new System.Windows.Forms.TextBox();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.txtLoanAccount = new System.Windows.Forms.TextBox();
            this.txtRefAccount = new System.Windows.Forms.TextBox();
            this.txtLCNo = new System.Windows.Forms.TextBox();
            this.txtLoanNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpEdate = new System.Windows.Forms.DateTimePicker();
            this.dtpSdate = new System.Windows.Forms.DateTimePicker();
            this.txtLcNoLike = new System.Windows.Forms.TextBox();
            this.txtLoanNoLike = new System.Windows.Forms.TextBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkLC = new System.Windows.Forms.CheckBox();
            this.chkLoanNo = new System.Windows.Forms.CheckBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.ctlDGVLoan = new Accounting.Controls.ctlDaraGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCurrencyL = new System.Windows.Forms.Label();
            this.lblCurrencyA = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVLoan)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.lblRate);
            this.groupBox1.Controls.Add(this.ctlNumRate);
            this.groupBox1.Controls.Add(this.ctlNumAcceptedPercent);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.lblCurrency1);
            this.groupBox1.Controls.Add(this.ctlNumLoanAmountAtTK);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtLoanAmount);
            this.groupBox1.Controls.Add(this.cmbInterestPeriod);
            this.groupBox1.Controls.Add(this.DTPExpireDate);
            this.groupBox1.Controls.Add(this.DTPSanctionDate);
            this.groupBox1.Controls.Add(this.DTPApplyDate);
            this.groupBox1.Controls.Add(this.txtloanRefID);
            this.groupBox1.Controls.Add(this.txtReffAccID);
            this.groupBox1.Controls.Add(this.txtTransRefID);
            this.groupBox1.Controls.Add(this.txtLCID);
            this.groupBox1.Controls.Add(this.txtLoanID);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.txtDueAmount);
            this.groupBox1.Controls.Add(this.txtInterestRate);
            this.groupBox1.Controls.Add(this.txtLoanAccount);
            this.groupBox1.Controls.Add(this.txtRefAccount);
            this.groupBox1.Controls.Add(this.txtLCNo);
            this.groupBox1.Controls.Add(this.txtLoanNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 189);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loan Info";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(145, 121);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(75, 13);
            this.lblRate.TabIndex = 39;
            this.lblRate.Text = "Currency Rate";
            // 
            // ctlNumRate
            // 
            this.ctlNumRate.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumRate.Location = new System.Drawing.Point(226, 118);
            this.ctlNumRate.Name = "ctlNumRate";
            this.ctlNumRate.ReadOnly = false;
            this.ctlNumRate.Size = new System.Drawing.Size(52, 20);
            this.ctlNumRate.TabIndex = 6;
            this.ctlNumRate.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumRate.Value = 1;
            this.ctlNumRate.Load += new System.EventHandler(this.ctlNumRate_Load);
            this.ctlNumRate.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctlNumRate_valueChanged);
            // 
            // ctlNumAcceptedPercent
            // 
            this.ctlNumAcceptedPercent.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumAcceptedPercent.Location = new System.Drawing.Point(92, 118);
            this.ctlNumAcceptedPercent.Name = "ctlNumAcceptedPercent";
            this.ctlNumAcceptedPercent.ReadOnly = false;
            this.ctlNumAcceptedPercent.Size = new System.Drawing.Size(47, 20);
            this.ctlNumAcceptedPercent.TabIndex = 5;
            this.ctlNumAcceptedPercent.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumAcceptedPercent.Value = 0;
            this.ctlNumAcceptedPercent.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctlNumAcceptedPercent_valueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 121);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 13);
            this.label17.TabIndex = 36;
            this.label17.Text = "Accepted (%)";
            // 
            // lblCurrency1
            // 
            this.lblCurrency1.AutoSize = true;
            this.lblCurrency1.Location = new System.Drawing.Point(231, 100);
            this.lblCurrency1.Name = "lblCurrency1";
            this.lblCurrency1.Size = new System.Drawing.Size(49, 13);
            this.lblCurrency1.TabIndex = 35;
            this.lblCurrency1.Text = "Currency";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(157, 17);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(49, 13);
            this.lblCurrency.TabIndex = 35;
            this.lblCurrency.Text = "Currency";
            // 
            // ctlNumLoanAmountAtTK
            // 
            this.ctlNumLoanAmountAtTK.BackgroudColor = System.Drawing.Color.White;
            this.ctlNumLoanAmountAtTK.Location = new System.Drawing.Point(385, 118);
            this.ctlNumLoanAmountAtTK.Name = "ctlNumLoanAmountAtTK";
            this.ctlNumLoanAmountAtTK.ReadOnly = true;
            this.ctlNumLoanAmountAtTK.Size = new System.Drawing.Size(120, 20);
            this.ctlNumLoanAmountAtTK.TabIndex = 34;
            this.ctlNumLoanAmountAtTK.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumLoanAmountAtTK.Value = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(289, 121);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "Loan Amount(TK)";
            // 
            // lblTtlLoanAmt
            // 
            this.lblTtlLoanAmt.AutoSize = true;
            this.lblTtlLoanAmt.Location = new System.Drawing.Point(88, 38);
            this.lblTtlLoanAmt.Name = "lblTtlLoanAmt";
            this.lblTtlLoanAmt.Size = new System.Drawing.Size(13, 13);
            this.lblTtlLoanAmt.TabIndex = 32;
            this.lblTtlLoanAmt.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Ttl LoanAmt";
            // 
            // lblLCValue
            // 
            this.lblLCValue.AutoSize = true;
            this.lblLCValue.Location = new System.Drawing.Point(88, 18);
            this.lblLCValue.Name = "lblLCValue";
            this.lblLCValue.Size = new System.Drawing.Size(13, 13);
            this.lblLCValue.TabIndex = 31;
            this.lblLCValue.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "LC Value";
            // 
            // txtLoanAmount
            // 
            this.txtLoanAmount.BackgroudColor = System.Drawing.SystemColors.Window;
            this.txtLoanAmount.Location = new System.Drawing.Point(92, 96);
            this.txtLoanAmount.Name = "txtLoanAmount";
            this.txtLoanAmount.ReadOnly = true;
            this.txtLoanAmount.Size = new System.Drawing.Size(133, 20);
            this.txtLoanAmount.TabIndex = 4;
            this.txtLoanAmount.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtLoanAmount.Value = 0;
            this.txtLoanAmount.Leave += new System.EventHandler(this.txtLoanNo_Leave);
            this.txtLoanAmount.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.txtLoanAmount_valueChanged);
            this.txtLoanAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoanAmount_KeyDown);
            // 
            // lblAcceptValue1
            // 
            this.lblAcceptValue1.AutoSize = true;
            this.lblAcceptValue1.Location = new System.Drawing.Point(88, 59);
            this.lblAcceptValue1.Name = "lblAcceptValue1";
            this.lblAcceptValue1.Size = new System.Drawing.Size(13, 13);
            this.lblAcceptValue1.TabIndex = 0;
            this.lblAcceptValue1.Text = "0";
            // 
            // lblAcceptValue
            // 
            this.lblAcceptValue.AutoSize = true;
            this.lblAcceptValue.Location = new System.Drawing.Point(8, 59);
            this.lblAcceptValue.Name = "lblAcceptValue";
            this.lblAcceptValue.Size = new System.Drawing.Size(71, 13);
            this.lblAcceptValue.TabIndex = 30;
            this.lblAcceptValue.Text = "Accept Value";
            // 
            // cmbInterestPeriod
            // 
            this.cmbInterestPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterestPeriod.FormattingEnabled = true;
            this.cmbInterestPeriod.Items.AddRange(new object[] {
            "Monthly",
            "Yearly"});
            this.cmbInterestPeriod.Location = new System.Drawing.Point(592, 9);
            this.cmbInterestPeriod.Name = "cmbInterestPeriod";
            this.cmbInterestPeriod.Size = new System.Drawing.Size(164, 21);
            this.cmbInterestPeriod.TabIndex = 9;
            this.cmbInterestPeriod.Leave += new System.EventHandler(this.txtLoanNo_Leave);
            this.cmbInterestPeriod.Enter += new System.EventHandler(this.cmbInterestPeriod_Enter);
            this.cmbInterestPeriod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbInterestPeriod_KeyDown);
            // 
            // DTPExpireDate
            // 
            this.DTPExpireDate.CustomFormat = "dd/MM/yyyy";
            this.DTPExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPExpireDate.Location = new System.Drawing.Point(592, 76);
            this.DTPExpireDate.Name = "DTPExpireDate";
            this.DTPExpireDate.Size = new System.Drawing.Size(164, 20);
            this.DTPExpireDate.TabIndex = 12;
            this.DTPExpireDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPExpireDate_KeyDown);
            // 
            // DTPSanctionDate
            // 
            this.DTPSanctionDate.CustomFormat = "dd/MM/yyyy";
            this.DTPSanctionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPSanctionDate.Location = new System.Drawing.Point(592, 54);
            this.DTPSanctionDate.Name = "DTPSanctionDate";
            this.DTPSanctionDate.Size = new System.Drawing.Size(164, 20);
            this.DTPSanctionDate.TabIndex = 11;
            this.DTPSanctionDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPSanctionDate_KeyDown);
            // 
            // DTPApplyDate
            // 
            this.DTPApplyDate.CustomFormat = "dd/MM/yyyy";
            this.DTPApplyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPApplyDate.Location = new System.Drawing.Point(592, 32);
            this.DTPApplyDate.Name = "DTPApplyDate";
            this.DTPApplyDate.Size = new System.Drawing.Size(164, 20);
            this.DTPApplyDate.TabIndex = 10;
            this.DTPApplyDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPApplyDate_KeyDown);
            // 
            // txtloanRefID
            // 
            this.txtloanRefID.Location = new System.Drawing.Point(372, 12);
            this.txtloanRefID.Name = "txtloanRefID";
            this.txtloanRefID.Size = new System.Drawing.Size(23, 20);
            this.txtloanRefID.TabIndex = 21;
            this.txtloanRefID.Text = "0";
            this.txtloanRefID.Visible = false;
            this.txtloanRefID.TextChanged += new System.EventHandler(this.txtloanRefID_TextChanged);
            // 
            // txtReffAccID
            // 
            this.txtReffAccID.Location = new System.Drawing.Point(430, 12);
            this.txtReffAccID.Name = "txtReffAccID";
            this.txtReffAccID.Size = new System.Drawing.Size(23, 20);
            this.txtReffAccID.TabIndex = 20;
            this.txtReffAccID.Text = "0";
            this.txtReffAccID.Visible = false;
            this.txtReffAccID.TextChanged += new System.EventHandler(this.txtReffAccID_TextChanged);
            // 
            // txtTransRefID
            // 
            this.txtTransRefID.Location = new System.Drawing.Point(401, 12);
            this.txtTransRefID.Name = "txtTransRefID";
            this.txtTransRefID.Size = new System.Drawing.Size(23, 20);
            this.txtTransRefID.TabIndex = 29;
            this.txtTransRefID.Text = "0";
            this.txtTransRefID.Visible = false;
            this.txtTransRefID.TextChanged += new System.EventHandler(this.txtTransRefID_TextChanged);
            // 
            // txtLCID
            // 
            this.txtLCID.Location = new System.Drawing.Point(323, 10);
            this.txtLCID.Name = "txtLCID";
            this.txtLCID.Size = new System.Drawing.Size(36, 20);
            this.txtLCID.TabIndex = 22;
            this.txtLCID.Text = "0";
            this.txtLCID.Visible = false;
            // 
            // txtLoanID
            // 
            this.txtLoanID.Location = new System.Drawing.Point(292, 9);
            this.txtLoanID.Name = "txtLoanID";
            this.txtLoanID.Size = new System.Drawing.Size(23, 20);
            this.txtLoanID.TabIndex = 19;
            this.txtLoanID.Text = "0";
            this.txtLoanID.Visible = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(592, 102);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(164, 39);
            this.txtRemarks.TabIndex = 13;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemarks_KeyDown);
            this.txtRemarks.Leave += new System.EventHandler(this.txtLoanNo_Leave);
            this.txtRemarks.Enter += new System.EventHandler(this.txtRemarks_Enter);
            // 
            // txtDueAmount
            // 
            this.txtDueAmount.Enabled = false;
            this.txtDueAmount.Location = new System.Drawing.Point(91, 163);
            this.txtDueAmount.Name = "txtDueAmount";
            this.txtDueAmount.Size = new System.Drawing.Size(189, 20);
            this.txtDueAmount.TabIndex = 8;
            this.txtDueAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDueAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDueAmount_KeyDown);
            this.txtDueAmount.Leave += new System.EventHandler(this.txtLoanNo_Leave);
            this.txtDueAmount.Enter += new System.EventHandler(this.txtDueAmount_Enter);
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(91, 142);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(189, 20);
            this.txtInterestRate.TabIndex = 7;
            this.txtInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterestRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInterestRate_KeyDown);
            this.txtInterestRate.Leave += new System.EventHandler(this.txtLoanNo_Leave);
            this.txtInterestRate.Enter += new System.EventHandler(this.txtInterestRate_Enter);
            // 
            // txtLoanAccount
            // 
            this.txtLoanAccount.BackColor = System.Drawing.Color.White;
            this.txtLoanAccount.Location = new System.Drawing.Point(91, 54);
            this.txtLoanAccount.Name = "txtLoanAccount";
            this.txtLoanAccount.ReadOnly = true;
            this.txtLoanAccount.Size = new System.Drawing.Size(189, 20);
            this.txtLoanAccount.TabIndex = 2;
            this.txtLoanAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoanAccount_KeyDown);
            this.txtLoanAccount.Leave += new System.EventHandler(this.txtLoanAccount_Leave);
            this.txtLoanAccount.Enter += new System.EventHandler(this.txtLoanAccount_Enter);
            // 
            // txtRefAccount
            // 
            this.txtRefAccount.BackColor = System.Drawing.Color.White;
            this.txtRefAccount.Location = new System.Drawing.Point(91, 33);
            this.txtRefAccount.Name = "txtRefAccount";
            this.txtRefAccount.ReadOnly = true;
            this.txtRefAccount.Size = new System.Drawing.Size(189, 20);
            this.txtRefAccount.TabIndex = 1;
            this.txtRefAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRefAccount_KeyDown);
            this.txtRefAccount.Leave += new System.EventHandler(this.txtRefAccount_Leave);
            this.txtRefAccount.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // txtLCNo
            // 
            this.txtLCNo.BackColor = System.Drawing.Color.White;
            this.txtLCNo.Location = new System.Drawing.Point(91, 75);
            this.txtLCNo.Name = "txtLCNo";
            this.txtLCNo.ReadOnly = true;
            this.txtLCNo.Size = new System.Drawing.Size(189, 20);
            this.txtLCNo.TabIndex = 3;
            this.txtLCNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLCNo_KeyDown);
            this.txtLCNo.Leave += new System.EventHandler(this.txtLoanNo_Leave);
            this.txtLCNo.Enter += new System.EventHandler(this.txtLCNo_Enter_1);
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.Location = new System.Drawing.Point(91, 12);
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(189, 20);
            this.txtLoanNo.TabIndex = 0;
            this.txtLoanNo.TextChanged += new System.EventHandler(this.txtLoanNo_TextChanged);
            this.txtLoanNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoanNo_KeyDown);
            this.txtLoanNo.Leave += new System.EventHandler(this.txtLoanNo_Leave);
            this.txtLoanNo.Enter += new System.EventHandler(this.txtLoanNo_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Due Amount";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(509, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Remarks";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(509, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Expire Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(509, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Sanction Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(509, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Apply Date";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "LC No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(509, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Interest Period";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(285, 147);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "(%)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Interest Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Loan Amount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Loan To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Loan From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Loan No.";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.dtpEdate);
            this.groupBox2.Controls.Add(this.dtpSdate);
            this.groupBox2.Controls.Add(this.txtLcNoLike);
            this.groupBox2.Controls.Add(this.txtLoanNoLike);
            this.groupBox2.Controls.Add(this.chkDate);
            this.groupBox2.Controls.Add(this.chkLC);
            this.groupBox2.Controls.Add(this.chkLoanNo);
            this.groupBox2.Controls.Add(this.btnFind);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnSaveUpdate);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.ctlDGVLoan);
            this.groupBox2.Location = new System.Drawing.Point(7, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(769, 284);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(695, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 23);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = ">>";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(566, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(16, 13);
            this.label18.TabIndex = 21;
            this.label18.Text = "to";
            // 
            // dtpEdate
            // 
            this.dtpEdate.CustomFormat = "dd/MM/yyyy";
            this.dtpEdate.Enabled = false;
            this.dtpEdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEdate.Location = new System.Drawing.Point(587, 15);
            this.dtpEdate.Name = "dtpEdate";
            this.dtpEdate.Size = new System.Drawing.Size(107, 20);
            this.dtpEdate.TabIndex = 20;
            // 
            // dtpSdate
            // 
            this.dtpSdate.CustomFormat = "dd/MM/yyyy";
            this.dtpSdate.Enabled = false;
            this.dtpSdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSdate.Location = new System.Drawing.Point(462, 14);
            this.dtpSdate.Name = "dtpSdate";
            this.dtpSdate.Size = new System.Drawing.Size(102, 20);
            this.dtpSdate.TabIndex = 19;
            // 
            // txtLcNoLike
            // 
            this.txtLcNoLike.Enabled = false;
            this.txtLcNoLike.Location = new System.Drawing.Point(253, 12);
            this.txtLcNoLike.Name = "txtLcNoLike";
            this.txtLcNoLike.Size = new System.Drawing.Size(106, 20);
            this.txtLcNoLike.TabIndex = 18;
            // 
            // txtLoanNoLike
            // 
            this.txtLoanNoLike.Enabled = false;
            this.txtLoanNoLike.Location = new System.Drawing.Point(72, 12);
            this.txtLoanNoLike.Name = "txtLoanNoLike";
            this.txtLoanNoLike.Size = new System.Drawing.Size(115, 20);
            this.txtLoanNoLike.TabIndex = 18;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(365, 15);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(99, 17);
            this.chkDate.TabIndex = 17;
            this.chkDate.Text = "Loan Date from";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkLoanNo_CheckedChanged);
            // 
            // chkLC
            // 
            this.chkLC.AutoSize = true;
            this.chkLC.Location = new System.Drawing.Point(193, 13);
            this.chkLC.Name = "chkLC";
            this.chkLC.Size = new System.Drawing.Size(59, 17);
            this.chkLC.TabIndex = 17;
            this.chkLC.Text = "LC No.";
            this.chkLC.UseVisualStyleBackColor = true;
            this.chkLC.CheckedChanged += new System.EventHandler(this.chkLoanNo_CheckedChanged);
            // 
            // chkLoanNo
            // 
            this.chkLoanNo.AutoSize = true;
            this.chkLoanNo.Location = new System.Drawing.Point(5, 14);
            this.chkLoanNo.Name = "chkLoanNo";
            this.chkLoanNo.Size = new System.Drawing.Size(70, 17);
            this.chkLoanNo.TabIndex = 17;
            this.chkLoanNo.Text = "Loan No.";
            this.chkLoanNo.UseVisualStyleBackColor = true;
            this.chkLoanNo.CheckedChanged += new System.EventHandler(this.chkLoanNo_CheckedChanged);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.Control;
            this.btnFind.Location = new System.Drawing.Point(373, 255);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 16;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Visible = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(687, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(609, 255);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDelete_KeyDown);
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveUpdate.Location = new System.Drawing.Point(530, 255);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnSaveUpdate.TabIndex = 12;
            this.btnSaveUpdate.Text = "&Save";
            this.btnSaveUpdate.UseVisualStyleBackColor = false;
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            this.btnSaveUpdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSaveUpdate_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.Control;
            this.btnNew.Location = new System.Drawing.Point(452, 255);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            this.btnNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnNew_KeyDown);
            // 
            // ctlDGVLoan
            // 
            this.ctlDGVLoan.AllowUserToAddRows = false;
            this.ctlDGVLoan.AllowUserToDeleteRows = false;
            this.ctlDGVLoan.BackgroundColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ctlDGVLoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.ctlDGVLoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDGVLoan.ContextMenuFields = null;
            this.ctlDGVLoan.isEnterKeyLikeTabKey = true;
            this.ctlDGVLoan.isExcelSheetCell = false;
            this.ctlDGVLoan.IsSortable = false;
            this.ctlDGVLoan.Location = new System.Drawing.Point(12, 41);
            this.ctlDGVLoan.Name = "ctlDGVLoan";
            this.ctlDGVLoan.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ctlDGVLoan.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.ctlDGVLoan.RowHeadersVisible = false;
            this.ctlDGVLoan.RowPointer = 0;
            this.ctlDGVLoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctlDGVLoan.ShowDateTimePicker = false;
            this.ctlDGVLoan.Size = new System.Drawing.Size(755, 208);
            this.ctlDGVLoan.TabIndex = 0;
            this.ctlDGVLoan.TabStop = false;
            this.ctlDGVLoan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlDGVLoan_CellDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.lblLCValue);
            this.groupBox3.Controls.Add(this.lblCurrencyA);
            this.groupBox3.Controls.Add(this.lblCurrencyL);
            this.groupBox3.Controls.Add(this.lblCurrency);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.lblTtlLoanAmt);
            this.groupBox3.Controls.Add(this.lblAcceptValue);
            this.groupBox3.Controls.Add(this.lblAcceptValue1);
            this.groupBox3.Location = new System.Drawing.Point(291, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(213, 76);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // lblCurrencyL
            // 
            this.lblCurrencyL.AutoSize = true;
            this.lblCurrencyL.Location = new System.Drawing.Point(157, 37);
            this.lblCurrencyL.Name = "lblCurrencyL";
            this.lblCurrencyL.Size = new System.Drawing.Size(49, 13);
            this.lblCurrencyL.TabIndex = 35;
            this.lblCurrencyL.Text = "Currency";
            // 
            // lblCurrencyA
            // 
            this.lblCurrencyA.AutoSize = true;
            this.lblCurrencyA.Location = new System.Drawing.Point(157, 56);
            this.lblCurrencyA.Name = "lblCurrencyA";
            this.lblCurrencyA.Size = new System.Drawing.Size(49, 13);
            this.lblCurrencyA.TabIndex = 35;
            this.lblCurrencyA.Text = "Currency";
            // 
            // frmLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 475);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loan";
            this.Load += new System.EventHandler(this.frmLoan_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmLoan_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVLoan)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLoanNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReffAccID;
        private System.Windows.Forms.TextBox txtLoanID;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.TextBox txtRefAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPExpireDate;
        private System.Windows.Forms.DateTimePicker DTPSanctionDate;
        private System.Windows.Forms.DateTimePicker DTPApplyDate;
        private System.Windows.Forms.TextBox txtDueAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private Accounting.Controls.ctlDaraGridView ctlDGVLoan;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSaveUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtLoanAccount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtloanRefID;
        private System.Windows.Forms.ComboBox cmbInterestPeriod;
        private System.Windows.Forms.TextBox txtLCID;
        private System.Windows.Forms.TextBox txtLCNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTransRefID;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblAcceptValue1;
        private System.Windows.Forms.Label lblAcceptValue;
        private Accounting.Controls.ctlNum txtLoanAmount;
        private System.Windows.Forms.Label lblLCValue;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTtlLoanAmt;
        private System.Windows.Forms.Label label15;
        private Accounting.Controls.ctlNum ctlNumLoanAmountAtTK;
        private System.Windows.Forms.Label label16;
        private Accounting.Controls.ctlNum ctlNumAcceptedPercent;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblRate;
        private Accounting.Controls.ctlNum ctlNumRate;
        private System.Windows.Forms.Label lblCurrency1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpEdate;
        private System.Windows.Forms.DateTimePicker dtpSdate;
        private System.Windows.Forms.TextBox txtLcNoLike;
        private System.Windows.Forms.TextBox txtLoanNoLike;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkLC;
        private System.Windows.Forms.CheckBox chkLoanNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCurrencyA;
        private System.Windows.Forms.Label lblCurrencyL;
    }
}