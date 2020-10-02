namespace Accounting.UI
{
    partial class frmForwardingLetter
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
            this.dtpApplyDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComDocNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ctlNumInvoiceNo = new Accounting.Controls.ctlNum();
            this.ctlNumPackingList = new Accounting.Controls.ctlNum();
            this.ctlNumLCNo = new Accounting.Controls.ctlNum();
            this.ctlNumDeliveryChallan = new Accounting.Controls.ctlNum();
            this.ctlNumTruckreceipts = new Accounting.Controls.ctlNum();
            this.ctlNumCertificateOfOrigin = new Accounting.Controls.ctlNum();
            this.ctlNumBeneficiarysCertificate = new Accounting.Controls.ctlNum();
            this.ctlNumPreShipmentInspectioncertioncertificate = new Accounting.Controls.ctlNum();
            this.ctlNumDraftNo = new Accounting.Controls.ctlNum();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Date";
            // 
            // dtpApplyDate
            // 
            this.dtpApplyDate.Location = new System.Drawing.Point(158, 8);
            this.dtpApplyDate.Name = "dtpApplyDate";
            this.dtpApplyDate.Size = new System.Drawing.Size(200, 20);
            this.dtpApplyDate.TabIndex = 0;
            this.dtpApplyDate.Leave += new System.EventHandler(this.dtpApplyDate_Leave);
            this.dtpApplyDate.Enter += new System.EventHandler(this.dtpApplyDate_Enter);
            this.dtpApplyDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpApplyDate_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(28, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "To";
            // 
            // txtTo
            // 
            this.txtTo.AutoCompleteCustomSource.AddRange(new string[] {
            "The Sr. Vice President,",
            "The Vice President & Manager,"});
            this.txtTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTo.Location = new System.Drawing.Point(158, 31);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(200, 20);
            this.txtTo.TabIndex = 1;
            this.txtTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTo_KeyDown);
            this.txtTo.Leave += new System.EventHandler(this.dtpApplyDate_Leave);
            this.txtTo.Enter += new System.EventHandler(this.dtpApplyDate_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(28, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Subject";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(158, 61);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(200, 20);
            this.txtSubject.TabIndex = 2;
            this.txtSubject.Text = "Submission of 1 set exort bill for negotiation";
            this.txtSubject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubject_KeyDown);
            this.txtSubject.Leave += new System.EventHandler(this.dtpApplyDate_Leave);
            this.txtSubject.Enter += new System.EventHandler(this.dtpApplyDate_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(28, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Commercial Doccuments";
            // 
            // txtComDocNo
            // 
            this.txtComDocNo.Location = new System.Drawing.Point(158, 92);
            this.txtComDocNo.Name = "txtComDocNo";
            this.txtComDocNo.ReadOnly = true;
            this.txtComDocNo.Size = new System.Drawing.Size(200, 20);
            this.txtComDocNo.TabIndex = 3;
            this.txtComDocNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtComDocNo_KeyDown);
            this.txtComDocNo.Leave += new System.EventHandler(this.dtpApplyDate_Leave);
            this.txtComDocNo.Enter += new System.EventHandler(this.dtpApplyDate_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(28, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "01. Draft No.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(28, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "02. Invoice No.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(28, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "03. Packing List";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(28, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "04. Delivery Challan";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(28, 239);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "05. Truck Receipts";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(28, 265);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "06. Certificate of Origin";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(28, 291);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "07. Beneficiary\'s Certificate";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(28, 317);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(190, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "08. Pre-Shipment Inspection Certificate";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(28, 343);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "09. L/C No.";
            // 
            // ctlNumInvoiceNo
            // 
            this.ctlNumInvoiceNo.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumInvoiceNo.Location = new System.Drawing.Point(288, 161);
            this.ctlNumInvoiceNo.Name = "ctlNumInvoiceNo";
            this.ctlNumInvoiceNo.ReadOnly = false;
            this.ctlNumInvoiceNo.Size = new System.Drawing.Size(70, 20);
            this.ctlNumInvoiceNo.TabIndex = 5;
            this.ctlNumInvoiceNo.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumInvoiceNo.Value = 8;
            this.ctlNumInvoiceNo.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctlNumDraftNo_valueChanged);
            this.ctlNumInvoiceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlNumDraftNo_KeyDown);
            // 
            // ctlNumPackingList
            // 
            this.ctlNumPackingList.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumPackingList.Location = new System.Drawing.Point(288, 187);
            this.ctlNumPackingList.Name = "ctlNumPackingList";
            this.ctlNumPackingList.ReadOnly = false;
            this.ctlNumPackingList.Size = new System.Drawing.Size(70, 20);
            this.ctlNumPackingList.TabIndex = 6;
            this.ctlNumPackingList.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumPackingList.Value = 6;
            this.ctlNumPackingList.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctlNumDraftNo_valueChanged);
            this.ctlNumPackingList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlNumDraftNo_KeyDown);
            // 
            // ctlNumLCNo
            // 
            this.ctlNumLCNo.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumLCNo.Location = new System.Drawing.Point(288, 343);
            this.ctlNumLCNo.Name = "ctlNumLCNo";
            this.ctlNumLCNo.ReadOnly = false;
            this.ctlNumLCNo.Size = new System.Drawing.Size(70, 20);
            this.ctlNumLCNo.TabIndex = 12;
            this.ctlNumLCNo.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumLCNo.Value = 1;
            this.ctlNumLCNo.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctlNumDraftNo_valueChanged);
            this.ctlNumLCNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlNumDraftNo_KeyDown);
            // 
            // ctlNumDeliveryChallan
            // 
            this.ctlNumDeliveryChallan.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumDeliveryChallan.Location = new System.Drawing.Point(288, 213);
            this.ctlNumDeliveryChallan.Name = "ctlNumDeliveryChallan";
            this.ctlNumDeliveryChallan.ReadOnly = false;
            this.ctlNumDeliveryChallan.Size = new System.Drawing.Size(70, 20);
            this.ctlNumDeliveryChallan.TabIndex = 7;
            this.ctlNumDeliveryChallan.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumDeliveryChallan.Value = 3;
            this.ctlNumDeliveryChallan.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctlNumDraftNo_valueChanged);
            this.ctlNumDeliveryChallan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlNumDraftNo_KeyDown);
            // 
            // ctlNumTruckreceipts
            // 
            this.ctlNumTruckreceipts.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumTruckreceipts.Location = new System.Drawing.Point(288, 239);
            this.ctlNumTruckreceipts.Name = "ctlNumTruckreceipts";
            this.ctlNumTruckreceipts.ReadOnly = false;
            this.ctlNumTruckreceipts.Size = new System.Drawing.Size(70, 20);
            this.ctlNumTruckreceipts.TabIndex = 8;
            this.ctlNumTruckreceipts.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumTruckreceipts.Value = 3;
            this.ctlNumTruckreceipts.Load += new System.EventHandler(this.ctlNumTruckreceipts_Load);
            this.ctlNumTruckreceipts.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctlNumDraftNo_valueChanged);
            this.ctlNumTruckreceipts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlNumDraftNo_KeyDown);
            // 
            // ctlNumCertificateOfOrigin
            // 
            this.ctlNumCertificateOfOrigin.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumCertificateOfOrigin.Location = new System.Drawing.Point(288, 265);
            this.ctlNumCertificateOfOrigin.Name = "ctlNumCertificateOfOrigin";
            this.ctlNumCertificateOfOrigin.ReadOnly = false;
            this.ctlNumCertificateOfOrigin.Size = new System.Drawing.Size(70, 20);
            this.ctlNumCertificateOfOrigin.TabIndex = 9;
            this.ctlNumCertificateOfOrigin.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumCertificateOfOrigin.Value = 1;
            this.ctlNumCertificateOfOrigin.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctlNumDraftNo_valueChanged);
            this.ctlNumCertificateOfOrigin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlNumDraftNo_KeyDown);
            // 
            // ctlNumBeneficiarysCertificate
            // 
            this.ctlNumBeneficiarysCertificate.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumBeneficiarysCertificate.Location = new System.Drawing.Point(288, 291);
            this.ctlNumBeneficiarysCertificate.Name = "ctlNumBeneficiarysCertificate";
            this.ctlNumBeneficiarysCertificate.ReadOnly = false;
            this.ctlNumBeneficiarysCertificate.Size = new System.Drawing.Size(70, 20);
            this.ctlNumBeneficiarysCertificate.TabIndex = 10;
            this.ctlNumBeneficiarysCertificate.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumBeneficiarysCertificate.Value = 1;
            this.ctlNumBeneficiarysCertificate.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctlNumDraftNo_valueChanged);
            this.ctlNumBeneficiarysCertificate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlNumDraftNo_KeyDown);
            // 
            // ctlNumPreShipmentInspectioncertioncertificate
            // 
            this.ctlNumPreShipmentInspectioncertioncertificate.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumPreShipmentInspectioncertioncertificate.Location = new System.Drawing.Point(288, 317);
            this.ctlNumPreShipmentInspectioncertioncertificate.Name = "ctlNumPreShipmentInspectioncertioncertificate";
            this.ctlNumPreShipmentInspectioncertioncertificate.ReadOnly = false;
            this.ctlNumPreShipmentInspectioncertioncertificate.Size = new System.Drawing.Size(70, 20);
            this.ctlNumPreShipmentInspectioncertioncertificate.TabIndex = 11;
            this.ctlNumPreShipmentInspectioncertioncertificate.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumPreShipmentInspectioncertioncertificate.Value = 1;
            this.ctlNumPreShipmentInspectioncertioncertificate.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctlNumDraftNo_valueChanged);
            this.ctlNumPreShipmentInspectioncertioncertificate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlNumDraftNo_KeyDown);
            // 
            // ctlNumDraftNo
            // 
            this.ctlNumDraftNo.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumDraftNo.Location = new System.Drawing.Point(288, 134);
            this.ctlNumDraftNo.Name = "ctlNumDraftNo";
            this.ctlNumDraftNo.ReadOnly = false;
            this.ctlNumDraftNo.Size = new System.Drawing.Size(70, 20);
            this.ctlNumDraftNo.TabIndex = 4;
            this.ctlNumDraftNo.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumDraftNo.Value = 2;
            this.ctlNumDraftNo.valueChanged += new Accounting.Controls.ctlNum.EventHandler(this.ctlNumDraftNo_valueChanged);
            this.ctlNumDraftNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlNumDraftNo_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(364, 350);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "No.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(364, 141);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 29;
            this.label16.Text = "Nos.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(364, 168);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "Nos.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(364, 194);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 13);
            this.label18.TabIndex = 31;
            this.label18.Text = "Nos.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(364, 324);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(24, 13);
            this.label19.TabIndex = 36;
            this.label19.Text = "No.";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(364, 220);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 13);
            this.label20.TabIndex = 32;
            this.label20.Text = "Nos.";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(364, 298);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(24, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "No.";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(364, 246);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 13);
            this.label22.TabIndex = 33;
            this.label22.Text = "Nos.";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Location = new System.Drawing.Point(364, 272);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(24, 13);
            this.label23.TabIndex = 34;
            this.label23.Text = "No.";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Location = new System.Drawing.Point(28, 378);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 13);
            this.label24.TabIndex = 28;
            this.label24.Text = "Account No";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.AutoCompleteCustomSource.AddRange(new string[] {
            "CD-8415",
            "4002-754850-000",
            "CD-11010419",
            "4002-754851-000"});
            this.txtAccountNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtAccountNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAccountNo.Location = new System.Drawing.Point(158, 375);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(200, 20);
            this.txtAccountNo.TabIndex = 13;
            this.txtAccountNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountNo_KeyDown);
            this.txtAccountNo.Leave += new System.EventHandler(this.dtpApplyDate_Leave);
            this.txtAccountNo.Enter += new System.EventHandler(this.dtpApplyDate_Enter);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.SystemColors.Control;
            this.btnPreview.Location = new System.Drawing.Point(158, 419);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(112, 23);
            this.btnPreview.TabIndex = 14;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.Location = new System.Drawing.Point(276, 419);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 38;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(357, 419);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmForwardingLetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 454);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ctlNumPreShipmentInspectioncertioncertificate);
            this.Controls.Add(this.ctlNumDeliveryChallan);
            this.Controls.Add(this.ctlNumBeneficiarysCertificate);
            this.Controls.Add(this.ctlNumLCNo);
            this.Controls.Add(this.ctlNumCertificateOfOrigin);
            this.Controls.Add(this.ctlNumTruckreceipts);
            this.Controls.Add(this.ctlNumPackingList);
            this.Controls.Add(this.ctlNumDraftNo);
            this.Controls.Add(this.ctlNumInvoiceNo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtComDocNo);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpApplyDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmForwardingLetter";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Forwarding Letter";
            this.Load += new System.EventHandler(this.frmForwardingLetter_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmForwardingLetter_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpApplyDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtComDocNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private Accounting.Controls.ctlNum ctlNumInvoiceNo;
        private Accounting.Controls.ctlNum ctlNumPackingList;
        private Accounting.Controls.ctlNum ctlNumLCNo;
        private Accounting.Controls.ctlNum ctlNumDeliveryChallan;
        private Accounting.Controls.ctlNum ctlNumTruckreceipts;
        private Accounting.Controls.ctlNum ctlNumCertificateOfOrigin;
        private Accounting.Controls.ctlNum ctlNumBeneficiarysCertificate;
        private Accounting.Controls.ctlNum ctlNumPreShipmentInspectioncertioncertificate;
        private Accounting.Controls.ctlNum ctlNumDraftNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCancel;
    }
}