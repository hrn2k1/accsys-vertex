namespace Accounting.UI
{
    partial class frmReportPrivilege
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
            this.gboxUserReportPrivilege = new System.Windows.Forms.GroupBox();
            this.cboMenu = new System.Windows.Forms.ComboBox();
            this.chkAllView = new System.Windows.Forms.CheckBox();
            this.dgvModule = new Accounting.Controls.ctlDaraGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gboxUserReportPrivilege.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModule)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxUserReportPrivilege
            // 
            this.gboxUserReportPrivilege.BackColor = System.Drawing.Color.Transparent;
            this.gboxUserReportPrivilege.Controls.Add(this.cboMenu);
            this.gboxUserReportPrivilege.Controls.Add(this.chkAllView);
            this.gboxUserReportPrivilege.Controls.Add(this.dgvModule);
            this.gboxUserReportPrivilege.Controls.Add(this.label2);
            this.gboxUserReportPrivilege.Controls.Add(this.label1);
            this.gboxUserReportPrivilege.Location = new System.Drawing.Point(2, 5);
            this.gboxUserReportPrivilege.Name = "gboxUserReportPrivilege";
            this.gboxUserReportPrivilege.Size = new System.Drawing.Size(347, 366);
            this.gboxUserReportPrivilege.TabIndex = 0;
            this.gboxUserReportPrivilege.TabStop = false;
            this.gboxUserReportPrivilege.Text = "User Report Privilege";
            // 
            // cboMenu
            // 
            this.cboMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMenu.FormattingEnabled = true;
            this.cboMenu.Location = new System.Drawing.Point(99, 19);
            this.cboMenu.Name = "cboMenu";
            this.cboMenu.Size = new System.Drawing.Size(226, 21);
            this.cboMenu.TabIndex = 3;
            this.cboMenu.SelectedIndexChanged += new System.EventHandler(this.cboMenu_SelectedIndexChanged);
            // 
            // chkAllView
            // 
            this.chkAllView.AutoSize = true;
            this.chkAllView.Location = new System.Drawing.Point(295, 58);
            this.chkAllView.Name = "chkAllView";
            this.chkAllView.Size = new System.Drawing.Size(15, 14);
            this.chkAllView.TabIndex = 2;
            this.chkAllView.UseVisualStyleBackColor = true;
            this.chkAllView.CheckedChanged += new System.EventHandler(this.chkAllView_CheckedChanged);
            // 
            // dgvModule
            // 
            this.dgvModule.AllowUserToAddRows = false;
            this.dgvModule.AllowUserToDeleteRows = false;
            this.dgvModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModule.ContextMenuFields = null;
            this.dgvModule.IsSortable = false;
            this.dgvModule.Location = new System.Drawing.Point(6, 80);
            this.dgvModule.MultiSelect = false;
            this.dgvModule.Name = "dgvModule";
            this.dgvModule.RowHeadersVisible = false;
            this.dgvModule.RowPointer = 0;
            this.dgvModule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModule.ShowDateTimePicker = true;
            this.dgvModule.Size = new System.Drawing.Size(334, 279);
            this.dgvModule.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Check All :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report Category";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Location = new System.Drawing.Point(169, 379);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(75, 379);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmReportPrivilege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 405);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gboxUserReportPrivilege);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReportPrivilege";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report Privilege";
            this.Load += new System.EventHandler(this.frmReportPrivilege_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmReportPrivilege_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReportPrivilege_FormClosed);
            this.gboxUserReportPrivilege.ResumeLayout(false);
            this.gboxUserReportPrivilege.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxUserReportPrivilege;
        private Accounting.Controls.ctlDaraGridView dgvModule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkAllView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboMenu;
    }
}