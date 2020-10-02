namespace Accounting.UI
{
	partial class frmImportBill
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gbxInput = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtAdjID = new System.Windows.Forms.TextBox();
            this.dtpMaturityDate = new System.Windows.Forms.DateTimePicker();
            this.dtpAcceptDate = new System.Windows.Forms.DateTimePicker();
            this.dtpPayDate = new System.Windows.Forms.DateTimePicker();
            this.txtChequeLCNo = new System.Windows.Forms.TextBox();
            this.cboPayMethod = new System.Windows.Forms.ComboBox();
            this.ctlNumPayAmt = new Accounting.Controls.ctlNum();
            this.txtPayFromAcc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRefNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctlNumDue = new Accounting.Controls.ctlNum();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.ctldgvAdjusts = new Accounting.Controls.ctlDaraGridView();
            this.ctldgvBills = new Accounting.Controls.ctlDaraGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBillOfAcc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.txtBillFromAcc = new System.Windows.Forms.TextBox();
            this.txtBillForAcc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ctlNumBillAmt = new Accounting.Controls.ctlNum();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.chkHitACC = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ctlDaraGridView1 = new Accounting.Controls.ctlDaraGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbxInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvAdjusts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDaraGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(787, 538);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctlDaraGridView1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.chkHitACC);
            this.tabPage1.Controls.Add(this.ctlNumBillAmt);
            this.tabPage1.Controls.Add(this.dtpBillDate);
            this.tabPage1.Controls.Add(this.txtBillForAcc);
            this.tabPage1.Controls.Add(this.txtComment);
            this.tabPage1.Controls.Add(this.txtBillFromAcc);
            this.tabPage1.Controls.Add(this.txtBillNo);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(779, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bill Entry";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbxInput);
            this.tabPage2.Controls.Add(this.btnClose);
            this.tabPage2.Controls.Add(this.ctlNumDue);
            this.tabPage2.Controls.Add(this.btnDelete);
            this.tabPage2.Controls.Add(this.btnPost);
            this.tabPage2.Controls.Add(this.ctldgvAdjusts);
            this.tabPage2.Controls.Add(this.ctldgvBills);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtBillOfAcc);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.chkAll);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(779, 512);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bill Pay";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(779, 512);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Bill Adjust";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gbxInput
            // 
            this.gbxInput.BackColor = System.Drawing.Color.Transparent;
            this.gbxInput.Controls.Add(this.txtRemarks);
            this.gbxInput.Controls.Add(this.txtAdjID);
            this.gbxInput.Controls.Add(this.dtpMaturityDate);
            this.gbxInput.Controls.Add(this.dtpAcceptDate);
            this.gbxInput.Controls.Add(this.dtpPayDate);
            this.gbxInput.Controls.Add(this.txtChequeLCNo);
            this.gbxInput.Controls.Add(this.cboPayMethod);
            this.gbxInput.Controls.Add(this.ctlNumPayAmt);
            this.gbxInput.Controls.Add(this.txtPayFromAcc);
            this.gbxInput.Controls.Add(this.label5);
            this.gbxInput.Controls.Add(this.label9);
            this.gbxInput.Controls.Add(this.label8);
            this.gbxInput.Controls.Add(this.label7);
            this.gbxInput.Controls.Add(this.label6);
            this.gbxInput.Controls.Add(this.lblRefNo);
            this.gbxInput.Controls.Add(this.label4);
            this.gbxInput.Controls.Add(this.label3);
            this.gbxInput.Location = new System.Drawing.Point(12, 220);
            this.gbxInput.Name = "gbxInput";
            this.gbxInput.Size = new System.Drawing.Size(306, 219);
            this.gbxInput.TabIndex = 13;
            this.gbxInput.TabStop = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(81, 192);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(225, 20);
            this.txtRemarks.TabIndex = 7;
            // 
            // txtAdjID
            // 
            this.txtAdjID.Location = new System.Drawing.Point(233, 15);
            this.txtAdjID.Name = "txtAdjID";
            this.txtAdjID.Size = new System.Drawing.Size(43, 20);
            this.txtAdjID.TabIndex = 6;
            this.txtAdjID.Text = "0";
            this.txtAdjID.Visible = false;
            // 
            // dtpMaturityDate
            // 
            this.dtpMaturityDate.CustomFormat = "dd/MM/yyyy";
            this.dtpMaturityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMaturityDate.Location = new System.Drawing.Point(81, 112);
            this.dtpMaturityDate.Name = "dtpMaturityDate";
            this.dtpMaturityDate.Size = new System.Drawing.Size(147, 20);
            this.dtpMaturityDate.TabIndex = 4;
            // 
            // dtpAcceptDate
            // 
            this.dtpAcceptDate.CustomFormat = "dd/MM/yyyy";
            this.dtpAcceptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAcceptDate.Location = new System.Drawing.Point(81, 88);
            this.dtpAcceptDate.Name = "dtpAcceptDate";
            this.dtpAcceptDate.Size = new System.Drawing.Size(147, 20);
            this.dtpAcceptDate.TabIndex = 3;
            // 
            // dtpPayDate
            // 
            this.dtpPayDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPayDate.Location = new System.Drawing.Point(81, 166);
            this.dtpPayDate.Name = "dtpPayDate";
            this.dtpPayDate.Size = new System.Drawing.Size(147, 20);
            this.dtpPayDate.TabIndex = 6;
            // 
            // txtChequeLCNo
            // 
            this.txtChequeLCNo.Location = new System.Drawing.Point(81, 62);
            this.txtChequeLCNo.Name = "txtChequeLCNo";
            this.txtChequeLCNo.Size = new System.Drawing.Size(147, 20);
            this.txtChequeLCNo.TabIndex = 2;
            // 
            // cboPayMethod
            // 
            this.cboPayMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayMethod.FormattingEnabled = true;
            this.cboPayMethod.Location = new System.Drawing.Point(81, 12);
            this.cboPayMethod.Name = "cboPayMethod";
            this.cboPayMethod.Size = new System.Drawing.Size(147, 21);
            this.cboPayMethod.TabIndex = 0;
            // 
            // ctlNumPayAmt
            // 
            this.ctlNumPayAmt.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumPayAmt.Location = new System.Drawing.Point(81, 38);
            this.ctlNumPayAmt.Name = "ctlNumPayAmt";
            this.ctlNumPayAmt.ReadOnly = false;
            this.ctlNumPayAmt.Size = new System.Drawing.Size(147, 20);
            this.ctlNumPayAmt.TabIndex = 1;
            this.ctlNumPayAmt.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumPayAmt.Value = 0;
            // 
            // txtPayFromAcc
            // 
            this.txtPayFromAcc.BackColor = System.Drawing.Color.White;
            this.txtPayFromAcc.Location = new System.Drawing.Point(81, 139);
            this.txtPayFromAcc.Name = "txtPayFromAcc";
            this.txtPayFromAcc.ReadOnly = true;
            this.txtPayFromAcc.Size = new System.Drawing.Size(219, 20);
            this.txtPayFromAcc.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Remarks";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(11, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Maturity Date";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(11, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Accept Date";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Pay Date";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pay From";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRefNo
            // 
            this.lblRefNo.Location = new System.Drawing.Point(11, 61);
            this.lblRefNo.Name = "lblRefNo";
            this.lblRefNo.Size = new System.Drawing.Size(66, 20);
            this.lblRefNo.TabIndex = 0;
            this.lblRefNo.Text = "Cheque No. ";
            this.lblRefNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pay Now TK.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Pay Method";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(233, 445);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ctlNumDue
            // 
            this.ctlNumDue.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumDue.Location = new System.Drawing.Point(109, 196);
            this.ctlNumDue.Name = "ctlNumDue";
            this.ctlNumDue.ReadOnly = true;
            this.ctlNumDue.Size = new System.Drawing.Size(121, 20);
            this.ctlNumDue.TabIndex = 11;
            this.ctlNumDue.TabStop = false;
            this.ctlNumDue.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumDue.Value = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(150, 445);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(67, 445);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 14;
            this.btnPost.Text = "&Post";
            this.btnPost.UseVisualStyleBackColor = true;
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
            this.ctldgvAdjusts.Location = new System.Drawing.Point(324, 200);
            this.ctldgvAdjusts.MultiSelect = false;
            this.ctldgvAdjusts.Name = "ctldgvAdjusts";
            this.ctldgvAdjusts.ReadOnly = true;
            this.ctldgvAdjusts.RowHeadersVisible = false;
            this.ctldgvAdjusts.RowPointer = 0;
            this.ctldgvAdjusts.RowTemplate.ReadOnly = true;
            this.ctldgvAdjusts.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctldgvAdjusts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctldgvAdjusts.ShowDateTimePicker = false;
            this.ctldgvAdjusts.Size = new System.Drawing.Size(445, 260);
            this.ctldgvAdjusts.TabIndex = 19;
            // 
            // ctldgvBills
            // 
            this.ctldgvBills.AllowUserToAddRows = false;
            this.ctldgvBills.AllowUserToDeleteRows = false;
            this.ctldgvBills.AllowUserToResizeColumns = false;
            this.ctldgvBills.AllowUserToResizeRows = false;
            this.ctldgvBills.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctldgvBills.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctldgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctldgvBills.ContextMenuFields = null;
            this.ctldgvBills.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ctldgvBills.IsSortable = false;
            this.ctldgvBills.Location = new System.Drawing.Point(3, 34);
            this.ctldgvBills.MultiSelect = false;
            this.ctldgvBills.Name = "ctldgvBills";
            this.ctldgvBills.ReadOnly = true;
            this.ctldgvBills.RowHeadersVisible = false;
            this.ctldgvBills.RowPointer = 0;
            this.ctldgvBills.RowTemplate.ReadOnly = true;
            this.ctldgvBills.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctldgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctldgvBills.ShowDateTimePicker = false;
            this.ctldgvBills.Size = new System.Drawing.Size(766, 160);
            this.ctldgvBills.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Bill for";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBillOfAcc
            // 
            this.txtBillOfAcc.BackColor = System.Drawing.Color.White;
            this.txtBillOfAcc.Location = new System.Drawing.Point(65, 11);
            this.txtBillOfAcc.Name = "txtBillOfAcc";
            this.txtBillOfAcc.ReadOnly = true;
            this.txtBillOfAcc.Size = new System.Drawing.Size(291, 20);
            this.txtBillOfAcc.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(9, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Total Due Amount";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            this.chkAll.Location = new System.Drawing.Point(367, 13);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(58, 17);
            this.chkAll.TabIndex = 12;
            this.chkAll.TabStop = false;
            this.chkAll.Text = "All Bills";
            this.chkAll.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Bill Ref No.";
            // 
            // txtBillNo
            // 
            this.txtBillNo.Location = new System.Drawing.Point(105, 28);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(113, 20);
            this.txtBillNo.TabIndex = 1;
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillDate.Location = new System.Drawing.Point(105, 55);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(113, 20);
            this.dtpBillDate.TabIndex = 2;
            // 
            // txtBillFromAcc
            // 
            this.txtBillFromAcc.Location = new System.Drawing.Point(105, 109);
            this.txtBillFromAcc.Name = "txtBillFromAcc";
            this.txtBillFromAcc.Size = new System.Drawing.Size(302, 20);
            this.txtBillFromAcc.TabIndex = 1;
            // 
            // txtBillForAcc
            // 
            this.txtBillForAcc.Location = new System.Drawing.Point(105, 82);
            this.txtBillForAcc.Name = "txtBillForAcc";
            this.txtBillForAcc.Size = new System.Drawing.Size(302, 20);
            this.txtBillForAcc.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Bill Date";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Bill For";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Bill From";
            // 
            // ctlNumBillAmt
            // 
            this.ctlNumBillAmt.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumBillAmt.Location = new System.Drawing.Point(105, 161);
            this.ctlNumBillAmt.Name = "ctlNumBillAmt";
            this.ctlNumBillAmt.ReadOnly = false;
            this.ctlNumBillAmt.Size = new System.Drawing.Size(113, 20);
            this.ctlNumBillAmt.TabIndex = 3;
            this.ctlNumBillAmt.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumBillAmt.Value = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 165);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Bill Amount TK";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 190);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Remarks";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(105, 187);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(363, 49);
            this.txtComment.TabIndex = 1;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            // 
            // chkHitACC
            // 
            this.chkHitACC.AutoSize = true;
            this.chkHitACC.Location = new System.Drawing.Point(19, 135);
            this.chkHitACC.Name = "chkHitACC";
            this.chkHitACC.Size = new System.Drawing.Size(80, 17);
            this.chkHitACC.TabIndex = 4;
            this.chkHitACC.Text = "checkBox1";
            this.chkHitACC.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(105, 135);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 20);
            this.textBox1.TabIndex = 5;
            // 
            // ctlDaraGridView1
            // 
            this.ctlDaraGridView1.AllowUserToAddRows = false;
            this.ctlDaraGridView1.AllowUserToDeleteRows = false;
            this.ctlDaraGridView1.AllowUserToResizeColumns = false;
            this.ctlDaraGridView1.AllowUserToResizeRows = false;
            this.ctlDaraGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlDaraGridView1.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctlDaraGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDaraGridView1.ContextMenuFields = null;
            this.ctlDaraGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ctlDaraGridView1.IsSortable = false;
            this.ctlDaraGridView1.Location = new System.Drawing.Point(3, 258);
            this.ctlDaraGridView1.MultiSelect = false;
            this.ctlDaraGridView1.Name = "ctlDaraGridView1";
            this.ctlDaraGridView1.ReadOnly = true;
            this.ctlDaraGridView1.RowHeadersVisible = false;
            this.ctlDaraGridView1.RowPointer = 0;
            this.ctlDaraGridView1.RowTemplate.ReadOnly = true;
            this.ctlDaraGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctlDaraGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctlDaraGridView1.ShowDateTimePicker = false;
            this.ctlDaraGridView1.Size = new System.Drawing.Size(766, 212);
            this.ctlDaraGridView1.TabIndex = 19;
            // 
            // frmImportBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 538);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Bill";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gbxInput.ResumeLayout(false);
            this.gbxInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvAdjusts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDaraGridView1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbxInput;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtAdjID;
        private System.Windows.Forms.DateTimePicker dtpMaturityDate;
        private System.Windows.Forms.DateTimePicker dtpAcceptDate;
        private System.Windows.Forms.DateTimePicker dtpPayDate;
        private System.Windows.Forms.TextBox txtChequeLCNo;
        private System.Windows.Forms.ComboBox cboPayMethod;
        private Accounting.Controls.ctlNum ctlNumPayAmt;
        private System.Windows.Forms.TextBox txtPayFromAcc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRefNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private Accounting.Controls.ctlNum ctlNumDue;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPost;
        private Accounting.Controls.ctlDaraGridView ctldgvAdjusts;
        private Accounting.Controls.ctlDaraGridView ctldgvBills;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBillOfAcc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dtpBillDate;
        private System.Windows.Forms.TextBox txtBillForAcc;
        private System.Windows.Forms.TextBox txtBillFromAcc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private Accounting.Controls.ctlNum ctlNumBillAmt;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkHitACC;
        private System.Windows.Forms.TextBox textBox1;
        private Accounting.Controls.ctlDaraGridView ctlDaraGridView1;
	}
}