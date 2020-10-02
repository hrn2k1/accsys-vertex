namespace Accounting.UI
{
    partial class frmUserManagements
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassward = new System.Windows.Forms.TextBox();
            this.txtConfirmPassward = new System.Windows.Forms.TextBox();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblConfirmPassward = new System.Windows.Forms.Label();
            this.lblPassward = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnSaveInfo = new System.Windows.Forms.Button();
            this.btnDefaultRole = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvModule = new Accounting.Controls.ctlDaraGridView();
            this.cboMenu = new System.Windows.Forms.ComboBox();
            this.lblMenu = new System.Windows.Forms.Label();
            this.btnSavePrivilege = new System.Windows.Forms.Button();
            this.btnReportPrivilege = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModule)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.txtPassward);
            this.groupBox1.Controls.Add(this.txtConfirmPassward);
            this.groupBox1.Controls.Add(this.cboRole);
            this.groupBox1.Controls.Add(this.lblRole);
            this.groupBox1.Controls.Add(this.lblConfirmPassward);
            this.groupBox1.Controls.Add(this.lblPassward);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.btnSaveInfo);
            this.groupBox1.Controls.Add(this.btnDefaultRole);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 345);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New user Info";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(105, 48);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(136, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // txtPassward
            // 
            this.txtPassward.Location = new System.Drawing.Point(105, 98);
            this.txtPassward.Name = "txtPassward";
            this.txtPassward.PasswordChar = '*';
            this.txtPassward.Size = new System.Drawing.Size(136, 20);
            this.txtPassward.TabIndex = 4;
            // 
            // txtConfirmPassward
            // 
            this.txtConfirmPassward.Location = new System.Drawing.Point(105, 148);
            this.txtConfirmPassward.Name = "txtConfirmPassward";
            this.txtConfirmPassward.PasswordChar = '*';
            this.txtConfirmPassward.Size = new System.Drawing.Size(136, 20);
            this.txtConfirmPassward.TabIndex = 4;
            this.txtConfirmPassward.TextChanged += new System.EventHandler(this.txtConfirmPassward_TextChanged);
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Items.AddRange(new object[] {
            "Administrator",
            "User",
            "Guest",
            "SuperAdministrator"});
            this.cboRole.Location = new System.Drawing.Point(105, 197);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(136, 21);
            this.cboRole.TabIndex = 3;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(6, 205);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(29, 13);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "Role";
            // 
            // lblConfirmPassward
            // 
            this.lblConfirmPassward.AutoSize = true;
            this.lblConfirmPassward.Location = new System.Drawing.Point(6, 151);
            this.lblConfirmPassward.Name = "lblConfirmPassward";
            this.lblConfirmPassward.Size = new System.Drawing.Size(91, 13);
            this.lblConfirmPassward.TabIndex = 2;
            this.lblConfirmPassward.Text = "Confirm Passward";
            // 
            // lblPassward
            // 
            this.lblPassward.AutoSize = true;
            this.lblPassward.Location = new System.Drawing.Point(6, 101);
            this.lblPassward.Name = "lblPassward";
            this.lblPassward.Size = new System.Drawing.Size(53, 13);
            this.lblPassward.TabIndex = 2;
            this.lblPassward.Text = "Passward";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(6, 51);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User Name";
            // 
            // btnSaveInfo
            // 
            this.btnSaveInfo.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveInfo.Location = new System.Drawing.Point(166, 249);
            this.btnSaveInfo.Name = "btnSaveInfo";
            this.btnSaveInfo.Size = new System.Drawing.Size(75, 23);
            this.btnSaveInfo.TabIndex = 1;
            this.btnSaveInfo.Text = "Save";
            this.btnSaveInfo.UseVisualStyleBackColor = false;
            this.btnSaveInfo.Click += new System.EventHandler(this.btnSaveInfo_Click);
            // 
            // btnDefaultRole
            // 
            this.btnDefaultRole.BackColor = System.Drawing.SystemColors.Control;
            this.btnDefaultRole.Location = new System.Drawing.Point(14, 304);
            this.btnDefaultRole.Name = "btnDefaultRole";
            this.btnDefaultRole.Size = new System.Drawing.Size(227, 23);
            this.btnDefaultRole.TabIndex = 1;
            this.btnDefaultRole.Text = "Set Default Role Privilege";
            this.btnDefaultRole.UseVisualStyleBackColor = false;
            this.btnDefaultRole.Click += new System.EventHandler(this.btnDefaultRole_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvModule);
            this.groupBox2.Controls.Add(this.cboMenu);
            this.groupBox2.Controls.Add(this.lblMenu);
            this.groupBox2.Controls.Add(this.btnSavePrivilege);
            this.groupBox2.Controls.Add(this.btnReportPrivilege);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(282, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 345);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Privilege";
            // 
            // dgvModule
            // 
            this.dgvModule.AllowUserToAddRows = false;
            this.dgvModule.AllowUserToDeleteRows = false;
            this.dgvModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModule.ContextMenuFields = null;
            this.dgvModule.IsSortable = false;
            this.dgvModule.Location = new System.Drawing.Point(6, 40);
            this.dgvModule.MultiSelect = false;
            this.dgvModule.Name = "dgvModule";
            this.dgvModule.RowHeadersVisible = false;
            this.dgvModule.RowPointer = 0;
            this.dgvModule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModule.ShowDateTimePicker = true;
            this.dgvModule.Size = new System.Drawing.Size(330, 269);
            this.dgvModule.TabIndex = 4;
            this.dgvModule.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModule_CellDoubleClick);
            // 
            // cboMenu
            // 
            this.cboMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMenu.FormattingEnabled = true;
            this.cboMenu.Location = new System.Drawing.Point(96, 13);
            this.cboMenu.Name = "cboMenu";
            this.cboMenu.Size = new System.Drawing.Size(198, 21);
            this.cboMenu.TabIndex = 3;
            this.cboMenu.SelectedIndexChanged += new System.EventHandler(this.cboMenu_SelectedIndexChanged);
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Location = new System.Drawing.Point(15, 16);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(34, 13);
            this.lblMenu.TabIndex = 2;
            this.lblMenu.Text = "Menu";
            // 
            // btnSavePrivilege
            // 
            this.btnSavePrivilege.BackColor = System.Drawing.SystemColors.Control;
            this.btnSavePrivilege.Location = new System.Drawing.Point(261, 316);
            this.btnSavePrivilege.Name = "btnSavePrivilege";
            this.btnSavePrivilege.Size = new System.Drawing.Size(75, 23);
            this.btnSavePrivilege.TabIndex = 1;
            this.btnSavePrivilege.Text = "Save";
            this.btnSavePrivilege.UseVisualStyleBackColor = false;
            this.btnSavePrivilege.Click += new System.EventHandler(this.btnSavePrivilege_Click);
            // 
            // btnReportPrivilege
            // 
            this.btnReportPrivilege.BackColor = System.Drawing.SystemColors.Control;
            this.btnReportPrivilege.Enabled = false;
            this.btnReportPrivilege.Location = new System.Drawing.Point(6, 316);
            this.btnReportPrivilege.Name = "btnReportPrivilege";
            this.btnReportPrivilege.Size = new System.Drawing.Size(113, 23);
            this.btnReportPrivilege.TabIndex = 1;
            this.btnReportPrivilege.Text = "Report Privilege";
            this.btnReportPrivilege.UseVisualStyleBackColor = false;
            this.btnReportPrivilege.Click += new System.EventHandler(this.btnReportPrivilege_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(263, 364);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmUserManagements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 393);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUserManagements";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Info & Privileges ";
            this.Load += new System.EventHandler(this.frmUserManagements_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmUserManagements_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUserManagements_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveInfo;
        private System.Windows.Forms.Button btnDefaultRole;
        private System.Windows.Forms.Button btnSavePrivilege;
        private System.Windows.Forms.Button btnReportPrivilege;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassward;
        private System.Windows.Forms.TextBox txtConfirmPassward;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblConfirmPassward;
        private System.Windows.Forms.Label lblPassward;
        private System.Windows.Forms.Label lblUserName;
        private Accounting.Controls.ctlDaraGridView dgvModule;
        private System.Windows.Forms.ComboBox cboMenu;
        private System.Windows.Forms.Label lblMenu;
    }
}