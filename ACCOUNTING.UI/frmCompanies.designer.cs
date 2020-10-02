namespace Accounting.UI
{
    partial class frmCompanies
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lvwCompany = new System.Windows.Forms.ListView();
            this.Col1 = new System.Windows.Forms.ColumnHeader();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.gbxCompany = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTINno = new System.Windows.Forms.Label();
            this.lblTradeLicense = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBusinessSubTypeID = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblWebSite = new System.Windows.Forms.Label();
            this.cboCurrencyID = new System.Windows.Forms.ComboBox();
            this.cboBusinessType = new System.Windows.Forms.ComboBox();
            this.cboBusinessSubTypeID = new System.Windows.Forms.ComboBox();
            this.lblCurrencyID = new System.Windows.Forms.Label();
            this.txtTINno = new System.Windows.Forms.TextBox();
            this.lblCompanyLogo = new System.Windows.Forms.Label();
            this.txtTradeLicense = new System.Windows.Forms.TextBox();
            this.txtWebSite = new System.Windows.Forms.TextBox();
            this.lblContactPersonPhone = new System.Windows.Forms.Label();
            this.txtContactPersonPhone = new System.Windows.Forms.TextBox();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.lblMembershipNo2 = new System.Windows.Forms.Label();
            this.txtBOIorFID = new System.Windows.Forms.TextBox();
            this.lblMembershipNo1 = new System.Windows.Forms.Label();
            this.txtVatregdNo = new System.Windows.Forms.TextBox();
            this.lblERCNo = new System.Windows.Forms.Label();
            this.txtERCNo = new System.Windows.Forms.TextBox();
            this.IRCNo = new System.Windows.Forms.Label();
            this.txtIRCNo = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddressLine2 = new System.Windows.Forms.Label();
            this.txtAddressLine2 = new System.Windows.Forms.TextBox();
            this.lblAddressLine1 = new System.Windows.Forms.Label();
            this.txtAddressLine1 = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(473, 336);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 21);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnEdit.Location = new System.Drawing.Point(313, 336);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(74, 21);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(393, 336);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 21);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.Control;
            this.btnNew.Location = new System.Drawing.Point(166, 335);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(74, 21);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lvwCompany
            // 
            this.lvwCompany.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Col1});
            this.lvwCompany.FullRowSelect = true;
            this.lvwCompany.GridLines = true;
            this.lvwCompany.HideSelection = false;
            this.lvwCompany.Location = new System.Drawing.Point(12, 20);
            this.lvwCompany.Name = "lvwCompany";
            this.lvwCompany.Size = new System.Drawing.Size(148, 317);
            this.lvwCompany.TabIndex = 6;
            this.lvwCompany.UseCompatibleStateImageBehavior = false;
            this.lvwCompany.View = System.Windows.Forms.View.Details;
            this.lvwCompany.SelectedIndexChanged += new System.EventHandler(this.lvwCompany_SelectedIndexChanged);
            this.lvwCompany.DoubleClick += new System.EventHandler(this.lvwCompany_DoubleClick);
            // 
            // Col1
            // 
            this.Col1.Text = "CompanyName";
            this.Col1.Width = 131;
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblTotalRecords.Location = new System.Drawing.Point(9, 340);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(108, 16);
            this.lblTotalRecords.TabIndex = 7;
            this.lblTotalRecords.Text = "Total Records : ";
            // 
            // gbxCompany
            // 
            this.gbxCompany.BackColor = System.Drawing.Color.Transparent;
            this.gbxCompany.Controls.Add(this.btnBrowse);
            this.gbxCompany.Controls.Add(this.picLogo);
            this.gbxCompany.Controls.Add(this.lblTINno);
            this.gbxCompany.Controls.Add(this.lblTradeLicense);
            this.gbxCompany.Controls.Add(this.label1);
            this.gbxCompany.Controls.Add(this.lblBusinessSubTypeID);
            this.gbxCompany.Controls.Add(this.lblEmail);
            this.gbxCompany.Controls.Add(this.lblWebSite);
            this.gbxCompany.Controls.Add(this.cboCurrencyID);
            this.gbxCompany.Controls.Add(this.cboBusinessType);
            this.gbxCompany.Controls.Add(this.cboBusinessSubTypeID);
            this.gbxCompany.Controls.Add(this.lblCurrencyID);
            this.gbxCompany.Controls.Add(this.txtTINno);
            this.gbxCompany.Controls.Add(this.lblCompanyLogo);
            this.gbxCompany.Controls.Add(this.txtTradeLicense);
            this.gbxCompany.Controls.Add(this.txtWebSite);
            this.gbxCompany.Controls.Add(this.lblContactPersonPhone);
            this.gbxCompany.Controls.Add(this.txtContactPersonPhone);
            this.gbxCompany.Controls.Add(this.lblContactPerson);
            this.gbxCompany.Controls.Add(this.txtEmail);
            this.gbxCompany.Controls.Add(this.txtContactPerson);
            this.gbxCompany.Controls.Add(this.lblMembershipNo2);
            this.gbxCompany.Controls.Add(this.txtBOIorFID);
            this.gbxCompany.Controls.Add(this.lblMembershipNo1);
            this.gbxCompany.Controls.Add(this.txtVatregdNo);
            this.gbxCompany.Controls.Add(this.lblERCNo);
            this.gbxCompany.Controls.Add(this.txtERCNo);
            this.gbxCompany.Controls.Add(this.IRCNo);
            this.gbxCompany.Controls.Add(this.txtIRCNo);
            this.gbxCompany.Controls.Add(this.lblFax);
            this.gbxCompany.Controls.Add(this.txtFax);
            this.gbxCompany.Controls.Add(this.lblPhone);
            this.gbxCompany.Controls.Add(this.txtPhone);
            this.gbxCompany.Controls.Add(this.lblAddressLine2);
            this.gbxCompany.Controls.Add(this.txtAddressLine2);
            this.gbxCompany.Controls.Add(this.lblAddressLine1);
            this.gbxCompany.Controls.Add(this.txtAddressLine1);
            this.gbxCompany.Controls.Add(this.lblCompanyName);
            this.gbxCompany.Controls.Add(this.txtCompanyName);
            this.gbxCompany.Location = new System.Drawing.Point(166, 14);
            this.gbxCompany.Name = "gbxCompany";
            this.gbxCompany.Size = new System.Drawing.Size(728, 315);
            this.gbxCompany.TabIndex = 0;
            this.gbxCompany.TabStop = false;
            this.gbxCompany.Text = "Company Information";
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.btnBrowse.Location = new System.Drawing.Point(555, 287);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(97, 21);
            this.btnBrowse.TabIndex = 18;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.White;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(543, 163);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(126, 120);
            this.picLogo.TabIndex = 33;
            this.picLogo.TabStop = false;
            // 
            // lblTINno
            // 
            this.lblTINno.Location = new System.Drawing.Point(6, 239);
            this.lblTINno.Name = "lblTINno";
            this.lblTINno.Size = new System.Drawing.Size(93, 20);
            this.lblTINno.TabIndex = 18;
            this.lblTINno.Text = "TINno";
            // 
            // lblTradeLicense
            // 
            this.lblTradeLicense.Location = new System.Drawing.Point(375, 16);
            this.lblTradeLicense.Name = "lblTradeLicense";
            this.lblTradeLicense.Size = new System.Drawing.Size(93, 20);
            this.lblTradeLicense.TabIndex = 24;
            this.lblTradeLicense.Text = "TradeLicense";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Business Type";
            // 
            // lblBusinessSubTypeID
            // 
            this.lblBusinessSubTypeID.Location = new System.Drawing.Point(5, 214);
            this.lblBusinessSubTypeID.Name = "lblBusinessSubTypeID";
            this.lblBusinessSubTypeID.Size = new System.Drawing.Size(106, 20);
            this.lblBusinessSubTypeID.TabIndex = 16;
            this.lblBusinessSubTypeID.Text = "Business SubType";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(6, 163);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(93, 20);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Email";
            // 
            // lblWebSite
            // 
            this.lblWebSite.Location = new System.Drawing.Point(6, 139);
            this.lblWebSite.Name = "lblWebSite";
            this.lblWebSite.Size = new System.Drawing.Size(93, 20);
            this.lblWebSite.TabIndex = 10;
            this.lblWebSite.Text = "WebSite";
            // 
            // cboCurrencyID
            // 
            this.cboCurrencyID.BackColor = System.Drawing.Color.White;
            this.cboCurrencyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrencyID.FormattingEnabled = true;
            this.cboCurrencyID.Location = new System.Drawing.Point(486, 135);
            this.cboCurrencyID.Name = "cboCurrencyID";
            this.cboCurrencyID.Size = new System.Drawing.Size(236, 21);
            this.cboCurrencyID.TabIndex = 17;
            this.cboCurrencyID.Enter += new System.EventHandler(this.cbo_Enter);
            this.cboCurrencyID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            // 
            // cboBusinessType
            // 
            this.cboBusinessType.BackColor = System.Drawing.Color.White;
            this.cboBusinessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusinessType.FormattingEnabled = true;
            this.cboBusinessType.Location = new System.Drawing.Point(118, 185);
            this.cboBusinessType.Name = "cboBusinessType";
            this.cboBusinessType.Size = new System.Drawing.Size(236, 21);
            this.cboBusinessType.TabIndex = 7;
            this.cboBusinessType.SelectedIndexChanged += new System.EventHandler(this.cboBusinessType_SelectedIndexChanged);
            this.cboBusinessType.Enter += new System.EventHandler(this.cbo_Enter);
            this.cboBusinessType.SelectedValueChanged += new System.EventHandler(this.cboBusinessType_SelectedValueChanged);
            this.cboBusinessType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            // 
            // cboBusinessSubTypeID
            // 
            this.cboBusinessSubTypeID.BackColor = System.Drawing.Color.White;
            this.cboBusinessSubTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusinessSubTypeID.FormattingEnabled = true;
            this.cboBusinessSubTypeID.Location = new System.Drawing.Point(118, 211);
            this.cboBusinessSubTypeID.Name = "cboBusinessSubTypeID";
            this.cboBusinessSubTypeID.Size = new System.Drawing.Size(236, 21);
            this.cboBusinessSubTypeID.TabIndex = 8;
            this.cboBusinessSubTypeID.Enter += new System.EventHandler(this.cbo_Enter);
            this.cboBusinessSubTypeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            // 
            // lblCurrencyID
            // 
            this.lblCurrencyID.Location = new System.Drawing.Point(375, 137);
            this.lblCurrencyID.Name = "lblCurrencyID";
            this.lblCurrencyID.Size = new System.Drawing.Size(93, 20);
            this.lblCurrencyID.TabIndex = 34;
            this.lblCurrencyID.Text = "Currency";
            // 
            // txtTINno
            // 
            this.txtTINno.BackColor = System.Drawing.Color.White;
            this.txtTINno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTINno.Location = new System.Drawing.Point(118, 237);
            this.txtTINno.MaxLength = 50;
            this.txtTINno.Name = "txtTINno";
            this.txtTINno.Size = new System.Drawing.Size(236, 20);
            this.txtTINno.TabIndex = 9;
            this.txtTINno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtTINno.Leave += new System.EventHandler(this.txt_Leave);
            this.txtTINno.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // lblCompanyLogo
            // 
            this.lblCompanyLogo.Location = new System.Drawing.Point(386, 163);
            this.lblCompanyLogo.Name = "lblCompanyLogo";
            this.lblCompanyLogo.Size = new System.Drawing.Size(93, 20);
            this.lblCompanyLogo.TabIndex = 36;
            this.lblCompanyLogo.Text = "Company Logo";
            // 
            // txtTradeLicense
            // 
            this.txtTradeLicense.BackColor = System.Drawing.Color.White;
            this.txtTradeLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTradeLicense.Location = new System.Drawing.Point(487, 14);
            this.txtTradeLicense.MaxLength = 50;
            this.txtTradeLicense.Name = "txtTradeLicense";
            this.txtTradeLicense.Size = new System.Drawing.Size(236, 20);
            this.txtTradeLicense.TabIndex = 12;
            this.txtTradeLicense.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtTradeLicense.Leave += new System.EventHandler(this.txt_Leave);
            this.txtTradeLicense.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // txtWebSite
            // 
            this.txtWebSite.BackColor = System.Drawing.Color.White;
            this.txtWebSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWebSite.Location = new System.Drawing.Point(118, 137);
            this.txtWebSite.MaxLength = 50;
            this.txtWebSite.Name = "txtWebSite";
            this.txtWebSite.Size = new System.Drawing.Size(236, 20);
            this.txtWebSite.TabIndex = 5;
            this.txtWebSite.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtWebSite.Leave += new System.EventHandler(this.txt_Leave);
            this.txtWebSite.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // lblContactPersonPhone
            // 
            this.lblContactPersonPhone.Location = new System.Drawing.Point(374, 113);
            this.lblContactPersonPhone.Name = "lblContactPersonPhone";
            this.lblContactPersonPhone.Size = new System.Drawing.Size(112, 20);
            this.lblContactPersonPhone.TabIndex = 32;
            this.lblContactPersonPhone.Text = "ContactPersonPhone";
            // 
            // txtContactPersonPhone
            // 
            this.txtContactPersonPhone.BackColor = System.Drawing.Color.White;
            this.txtContactPersonPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactPersonPhone.Location = new System.Drawing.Point(486, 111);
            this.txtContactPersonPhone.MaxLength = 50;
            this.txtContactPersonPhone.Name = "txtContactPersonPhone";
            this.txtContactPersonPhone.Size = new System.Drawing.Size(236, 20);
            this.txtContactPersonPhone.TabIndex = 16;
            this.txtContactPersonPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtContactPersonPhone.Leave += new System.EventHandler(this.txt_Leave);
            this.txtContactPersonPhone.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.Location = new System.Drawing.Point(374, 89);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(93, 20);
            this.lblContactPerson.TabIndex = 30;
            this.lblContactPerson.Text = "ContactPerson";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(118, 161);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(236, 20);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtEmail.Leave += new System.EventHandler(this.txt_Leave);
            this.txtEmail.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.BackColor = System.Drawing.Color.White;
            this.txtContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactPerson.Location = new System.Drawing.Point(486, 87);
            this.txtContactPerson.MaxLength = 50;
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(236, 20);
            this.txtContactPerson.TabIndex = 15;
            this.txtContactPerson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtContactPerson.Leave += new System.EventHandler(this.txt_Leave);
            this.txtContactPerson.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // lblMembershipNo2
            // 
            this.lblMembershipNo2.Location = new System.Drawing.Point(374, 65);
            this.lblMembershipNo2.Name = "lblMembershipNo2";
            this.lblMembershipNo2.Size = new System.Drawing.Size(93, 20);
            this.lblMembershipNo2.TabIndex = 28;
            this.lblMembershipNo2.Text = "BOI/FID";
            // 
            // txtBOIorFID
            // 
            this.txtBOIorFID.BackColor = System.Drawing.Color.White;
            this.txtBOIorFID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBOIorFID.Location = new System.Drawing.Point(486, 63);
            this.txtBOIorFID.MaxLength = 50;
            this.txtBOIorFID.Name = "txtBOIorFID";
            this.txtBOIorFID.Size = new System.Drawing.Size(236, 20);
            this.txtBOIorFID.TabIndex = 14;
            this.txtBOIorFID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtBOIorFID.Leave += new System.EventHandler(this.txt_Leave);
            this.txtBOIorFID.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // lblMembershipNo1
            // 
            this.lblMembershipNo1.Location = new System.Drawing.Point(374, 41);
            this.lblMembershipNo1.Name = "lblMembershipNo1";
            this.lblMembershipNo1.Size = new System.Drawing.Size(93, 20);
            this.lblMembershipNo1.TabIndex = 26;
            this.lblMembershipNo1.Text = "Vat Regd. No.";
            // 
            // txtVatregdNo
            // 
            this.txtVatregdNo.BackColor = System.Drawing.Color.White;
            this.txtVatregdNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVatregdNo.Location = new System.Drawing.Point(486, 39);
            this.txtVatregdNo.MaxLength = 50;
            this.txtVatregdNo.Name = "txtVatregdNo";
            this.txtVatregdNo.Size = new System.Drawing.Size(236, 20);
            this.txtVatregdNo.TabIndex = 13;
            this.txtVatregdNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtVatregdNo.Leave += new System.EventHandler(this.txt_Leave);
            this.txtVatregdNo.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // lblERCNo
            // 
            this.lblERCNo.Location = new System.Drawing.Point(6, 289);
            this.lblERCNo.Name = "lblERCNo";
            this.lblERCNo.Size = new System.Drawing.Size(93, 20);
            this.lblERCNo.TabIndex = 22;
            this.lblERCNo.Text = "ERCNo";
            // 
            // txtERCNo
            // 
            this.txtERCNo.BackColor = System.Drawing.Color.White;
            this.txtERCNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtERCNo.Location = new System.Drawing.Point(118, 287);
            this.txtERCNo.MaxLength = 50;
            this.txtERCNo.Name = "txtERCNo";
            this.txtERCNo.Size = new System.Drawing.Size(236, 20);
            this.txtERCNo.TabIndex = 11;
            this.txtERCNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtERCNo.Leave += new System.EventHandler(this.txt_Leave);
            this.txtERCNo.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // IRCNo
            // 
            this.IRCNo.Location = new System.Drawing.Point(6, 265);
            this.IRCNo.Name = "IRCNo";
            this.IRCNo.Size = new System.Drawing.Size(93, 20);
            this.IRCNo.TabIndex = 20;
            this.IRCNo.Text = "IRCNo";
            // 
            // txtIRCNo
            // 
            this.txtIRCNo.BackColor = System.Drawing.Color.White;
            this.txtIRCNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIRCNo.Location = new System.Drawing.Point(118, 263);
            this.txtIRCNo.MaxLength = 50;
            this.txtIRCNo.Name = "txtIRCNo";
            this.txtIRCNo.Size = new System.Drawing.Size(236, 20);
            this.txtIRCNo.TabIndex = 10;
            this.txtIRCNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtIRCNo.Leave += new System.EventHandler(this.txt_Leave);
            this.txtIRCNo.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(6, 115);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(93, 20);
            this.lblFax.TabIndex = 8;
            this.lblFax.Text = "Fax";
            // 
            // txtFax
            // 
            this.txtFax.BackColor = System.Drawing.Color.White;
            this.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFax.Location = new System.Drawing.Point(118, 113);
            this.txtFax.MaxLength = 50;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(236, 20);
            this.txtFax.TabIndex = 4;
            this.txtFax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtFax.Leave += new System.EventHandler(this.txt_Leave);
            this.txtFax.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(6, 91);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(93, 20);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Location = new System.Drawing.Point(118, 89);
            this.txtPhone.MaxLength = 50;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(236, 20);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtPhone.Leave += new System.EventHandler(this.txt_Leave);
            this.txtPhone.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // lblAddressLine2
            // 
            this.lblAddressLine2.Location = new System.Drawing.Point(6, 67);
            this.lblAddressLine2.Name = "lblAddressLine2";
            this.lblAddressLine2.Size = new System.Drawing.Size(93, 20);
            this.lblAddressLine2.TabIndex = 4;
            this.lblAddressLine2.Text = "AddressLine2";
            // 
            // txtAddressLine2
            // 
            this.txtAddressLine2.BackColor = System.Drawing.Color.White;
            this.txtAddressLine2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddressLine2.Location = new System.Drawing.Point(118, 65);
            this.txtAddressLine2.MaxLength = 50;
            this.txtAddressLine2.Name = "txtAddressLine2";
            this.txtAddressLine2.Size = new System.Drawing.Size(236, 20);
            this.txtAddressLine2.TabIndex = 2;
            this.txtAddressLine2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtAddressLine2.Leave += new System.EventHandler(this.txt_Leave);
            this.txtAddressLine2.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // lblAddressLine1
            // 
            this.lblAddressLine1.Location = new System.Drawing.Point(6, 43);
            this.lblAddressLine1.Name = "lblAddressLine1";
            this.lblAddressLine1.Size = new System.Drawing.Size(93, 20);
            this.lblAddressLine1.TabIndex = 2;
            this.lblAddressLine1.Text = "AddressLine1";
            // 
            // txtAddressLine1
            // 
            this.txtAddressLine1.BackColor = System.Drawing.Color.White;
            this.txtAddressLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddressLine1.Location = new System.Drawing.Point(118, 41);
            this.txtAddressLine1.MaxLength = 50;
            this.txtAddressLine1.Name = "txtAddressLine1";
            this.txtAddressLine1.Size = new System.Drawing.Size(236, 20);
            this.txtAddressLine1.TabIndex = 1;
            this.txtAddressLine1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtAddressLine1.Leave += new System.EventHandler(this.txt_Leave);
            this.txtAddressLine1.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Location = new System.Drawing.Point(6, 19);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(93, 20);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "CompanyName";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.Color.White;
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.Location = new System.Drawing.Point(118, 17);
            this.txtCompanyName.MaxLength = 50;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(236, 20);
            this.txtCompanyName.TabIndex = 0;
            this.txtCompanyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctl_KeyDown);
            this.txtCompanyName.Leave += new System.EventHandler(this.txt_Leave);
            this.txtCompanyName.Enter += new System.EventHandler(this.txt_Enter);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(246, 335);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 21);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmCompanies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(909, 379);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbxCompany);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lvwCompany);
            this.Controls.Add(this.lblTotalRecords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCompanies";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Companies";
            this.Load += new System.EventHandler(this.frmCompanies_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmCompanies_Paint);
            this.gbxCompany.ResumeLayout(false);
            this.gbxCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ListView lvwCompany;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.GroupBox gbxCompany;
        private System.Windows.Forms.ComboBox cboCurrencyID;
        private System.Windows.Forms.ComboBox cboBusinessSubTypeID;
        private System.Windows.Forms.Label lblCurrencyID;
        private System.Windows.Forms.TextBox txtTINno;
        private System.Windows.Forms.Label lblCompanyLogo;
        private System.Windows.Forms.TextBox txtTradeLicense;
        private System.Windows.Forms.TextBox txtWebSite;
        private System.Windows.Forms.Label lblContactPersonPhone;
        private System.Windows.Forms.TextBox txtContactPersonPhone;
        private System.Windows.Forms.Label lblContactPerson;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.Label lblMembershipNo2;
        private System.Windows.Forms.TextBox txtBOIorFID;
        private System.Windows.Forms.Label lblMembershipNo1;
        private System.Windows.Forms.TextBox txtVatregdNo;
        private System.Windows.Forms.Label lblERCNo;
        private System.Windows.Forms.TextBox txtERCNo;
        private System.Windows.Forms.Label IRCNo;
        private System.Windows.Forms.TextBox txtIRCNo;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddressLine2;
        private System.Windows.Forms.TextBox txtAddressLine2;
        private System.Windows.Forms.Label lblAddressLine1;
        private System.Windows.Forms.TextBox txtAddressLine1;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblTINno;
        private System.Windows.Forms.Label lblTradeLicense;
        private System.Windows.Forms.Label lblBusinessSubTypeID;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblWebSite;
        private System.Windows.Forms.ColumnHeader Col1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboBusinessType;
    }
}