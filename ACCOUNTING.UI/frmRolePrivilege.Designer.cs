namespace Accounting.UI
{
    partial class frmRolePrivilege
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
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAllDelete = new System.Windows.Forms.CheckBox();
            this.chkAllAdd = new System.Windows.Forms.CheckBox();
            this.chkAllEdit = new System.Windows.Forms.CheckBox();
            this.chkAllView = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReportPrivilege = new System.Windows.Forms.Button();
            this.dgvModule = new Accounting.Controls.ctlDaraGridView();
            this.cboMenu = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModule)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cboRole);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Role";
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Items.AddRange(new object[] {
            "Administrator",
            "User",
            "Guest"});
            this.cboRole.Location = new System.Drawing.Point(128, 16);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(198, 21);
            this.cboRole.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Role";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAllDelete);
            this.groupBox2.Controls.Add(this.chkAllAdd);
            this.groupBox2.Controls.Add(this.chkAllEdit);
            this.groupBox2.Controls.Add(this.chkAllView);
            this.groupBox2.Location = new System.Drawing.Point(185, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 40);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ckeck All";
            // 
            // chkAllDelete
            // 
            this.chkAllDelete.AutoSize = true;
            this.chkAllDelete.Location = new System.Drawing.Point(135, 19);
            this.chkAllDelete.Name = "chkAllDelete";
            this.chkAllDelete.Size = new System.Drawing.Size(15, 14);
            this.chkAllDelete.TabIndex = 0;
            this.chkAllDelete.UseVisualStyleBackColor = true;
            this.chkAllDelete.CheckedChanged += new System.EventHandler(this.chkAllDelete_CheckedChanged);
            // 
            // chkAllAdd
            // 
            this.chkAllAdd.AutoSize = true;
            this.chkAllAdd.Location = new System.Drawing.Point(95, 19);
            this.chkAllAdd.Name = "chkAllAdd";
            this.chkAllAdd.Size = new System.Drawing.Size(15, 14);
            this.chkAllAdd.TabIndex = 0;
            this.chkAllAdd.UseVisualStyleBackColor = true;
            this.chkAllAdd.CheckedChanged += new System.EventHandler(this.chkAllAdd_CheckedChanged);
            // 
            // chkAllEdit
            // 
            this.chkAllEdit.AutoSize = true;
            this.chkAllEdit.Location = new System.Drawing.Point(58, 19);
            this.chkAllEdit.Name = "chkAllEdit";
            this.chkAllEdit.Size = new System.Drawing.Size(15, 14);
            this.chkAllEdit.TabIndex = 0;
            this.chkAllEdit.UseVisualStyleBackColor = true;
            this.chkAllEdit.CheckedChanged += new System.EventHandler(this.chkAllEdit_CheckedChanged);
            // 
            // chkAllView
            // 
            this.chkAllView.AutoSize = true;
            this.chkAllView.Location = new System.Drawing.Point(20, 19);
            this.chkAllView.Name = "chkAllView";
            this.chkAllView.Size = new System.Drawing.Size(15, 14);
            this.chkAllView.TabIndex = 0;
            this.chkAllView.UseVisualStyleBackColor = true;
            this.chkAllView.CheckedChanged += new System.EventHandler(this.chkAllView_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.btnReportPrivilege);
            this.groupBox3.Controls.Add(this.dgvModule);
            this.groupBox3.Controls.Add(this.cboMenu);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(6, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 403);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User Privilege";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(269, 372);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(180, 372);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReportPrivilege
            // 
            this.btnReportPrivilege.Enabled = false;
            this.btnReportPrivilege.Location = new System.Drawing.Point(6, 372);
            this.btnReportPrivilege.Name = "btnReportPrivilege";
            this.btnReportPrivilege.Size = new System.Drawing.Size(105, 23);
            this.btnReportPrivilege.TabIndex = 4;
            this.btnReportPrivilege.Text = "&Report Privilege";
            this.btnReportPrivilege.UseVisualStyleBackColor = true;
            this.btnReportPrivilege.Click += new System.EventHandler(this.btnReportPrivilege_Click);
            // 
            // dgvModule
            // 
            this.dgvModule.AllowUserToAddRows = false;
            this.dgvModule.AllowUserToDeleteRows = false;
            this.dgvModule.AllowUserToResizeColumns = false;
            this.dgvModule.AllowUserToResizeRows = false;
            this.dgvModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModule.ContextMenuFields = null;
            this.dgvModule.IsSortable = false;
            this.dgvModule.Location = new System.Drawing.Point(6, 90);
            this.dgvModule.MultiSelect = false;
            this.dgvModule.Name = "dgvModule";
            this.dgvModule.RowHeadersVisible = false;
            this.dgvModule.RowPointer = 0;
            this.dgvModule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModule.ShowDateTimePicker = true;
            this.dgvModule.Size = new System.Drawing.Size(342, 275);
            this.dgvModule.TabIndex = 3;
            // 
            // cboMenu
            // 
            this.cboMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMenu.FormattingEnabled = true;
            this.cboMenu.Location = new System.Drawing.Point(128, 17);
            this.cboMenu.Name = "cboMenu";
            this.cboMenu.Size = new System.Drawing.Size(198, 21);
            this.cboMenu.TabIndex = 2;
            this.cboMenu.SelectedIndexChanged += new System.EventHandler(this.cboMenu_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu";
            // 
            // frmRolePrivilege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 478);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRolePrivilege";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Role Privilege";
            this.Load += new System.EventHandler(this.frmRolePrivilege_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmRolePrivilege_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRolePrivilege_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAllDelete;
        private System.Windows.Forms.CheckBox chkAllAdd;
        private System.Windows.Forms.CheckBox chkAllEdit;
        private System.Windows.Forms.CheckBox chkAllView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReportPrivilege;
        private Accounting.Controls.ctlDaraGridView dgvModule;
    }
}