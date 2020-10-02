namespace Accounting.UI
{
    partial class frmTeam
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
            this.txtTeamNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvTeamDetails = new Accounting.Controls.ctlDaraGridView();
            this.btnDeleteMember = new System.Windows.Forms.Button();
            this.txtTeamID = new System.Windows.Forms.TextBox();
            this.dgvTeamMaster = new Accounting.Controls.ctlDaraGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteTeam = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamMaster)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTeamNo
            // 
            this.txtTeamNo.Location = new System.Drawing.Point(90, 16);
            this.txtTeamNo.Name = "txtTeamNo";
            this.txtTeamNo.Size = new System.Drawing.Size(220, 20);
            this.txtTeamNo.TabIndex = 0;
            this.txtTeamNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTeamNo_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "TeamNo";
            // 
            // txtTeamName
            // 
            this.txtTeamName.Location = new System.Drawing.Point(90, 42);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(220, 20);
            this.txtTeamName.TabIndex = 1;
            this.txtTeamName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTeamNo_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "TeamName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Branch";
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(90, 67);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(220, 21);
            this.cmbBranch.TabIndex = 2;
            this.cmbBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTeamNo_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(287, 438);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvTeamDetails
            // 
            this.dgvTeamDetails.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvTeamDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeamDetails.ContextMenuFields = null;
            this.dgvTeamDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTeamDetails.IsSortable = false;
            this.dgvTeamDetails.Location = new System.Drawing.Point(14, 99);
            this.dgvTeamDetails.MultiSelect = false;
            this.dgvTeamDetails.Name = "dgvTeamDetails";
            this.dgvTeamDetails.RowHeadersWidth = 25;
            this.dgvTeamDetails.RowPointer = 0;
            this.dgvTeamDetails.ShowDateTimePicker = true;
            this.dgvTeamDetails.Size = new System.Drawing.Size(532, 333);
            this.dgvTeamDetails.TabIndex = 3;
            this.dgvTeamDetails.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvTeamDetails_EditingControlShowing);
            this.dgvTeamDetails.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeamDetails_CellEnter);
            // 
            // btnDeleteMember
            // 
            this.btnDeleteMember.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteMember.Location = new System.Drawing.Point(366, 438);
            this.btnDeleteMember.Name = "btnDeleteMember";
            this.btnDeleteMember.Size = new System.Drawing.Size(94, 23);
            this.btnDeleteMember.TabIndex = 5;
            this.btnDeleteMember.Text = "Delete Member";
            this.btnDeleteMember.UseVisualStyleBackColor = false;
            this.btnDeleteMember.Click += new System.EventHandler(this.btnDeleteMember_Click);
            // 
            // txtTeamID
            // 
            this.txtTeamID.Location = new System.Drawing.Point(326, 16);
            this.txtTeamID.Name = "txtTeamID";
            this.txtTeamID.Size = new System.Drawing.Size(54, 20);
            this.txtTeamID.TabIndex = 7;
            this.txtTeamID.Visible = false;
            // 
            // dgvTeamMaster
            // 
            this.dgvTeamMaster.AllowUserToAddRows = false;
            this.dgvTeamMaster.AllowUserToDeleteRows = false;
            this.dgvTeamMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTeamMaster.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvTeamMaster.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTeamMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeamMaster.ContextMenuFields = null;
            this.dgvTeamMaster.GridColor = System.Drawing.Color.LightGray;
            this.dgvTeamMaster.IsSortable = false;
            this.dgvTeamMaster.Location = new System.Drawing.Point(10, 16);
            this.dgvTeamMaster.Name = "dgvTeamMaster";
            this.dgvTeamMaster.ReadOnly = true;
            this.dgvTeamMaster.RowHeadersVisible = false;
            this.dgvTeamMaster.RowPointer = 0;
            this.dgvTeamMaster.RowTemplate.Height = 20;
            this.dgvTeamMaster.RowTemplate.ReadOnly = true;
            this.dgvTeamMaster.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTeamMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeamMaster.ShowDateTimePicker = true;
            this.dgvTeamMaster.Size = new System.Drawing.Size(207, 416);
            this.dgvTeamMaster.TabIndex = 0;
            this.dgvTeamMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeamMaster_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTeamNo);
            this.groupBox1.Controls.Add(this.txtTeamID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnDeleteMember);
            this.groupBox1.Controls.Add(this.txtTeamName);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgvTeamDetails);
            this.groupBox1.Controls.Add(this.cmbBranch);
            this.groupBox1.Location = new System.Drawing.Point(232, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 467);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Team Members";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(464, 438);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.Control;
            this.btnNew.Location = new System.Drawing.Point(10, 438);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New Team";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnDeleteTeam);
            this.groupBox2.Controls.Add(this.dgvTeamMaster);
            this.groupBox2.Location = new System.Drawing.Point(3, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 467);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sales Team";
            // 
            // btnDeleteTeam
            // 
            this.btnDeleteTeam.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteTeam.Location = new System.Drawing.Point(97, 438);
            this.btnDeleteTeam.Name = "btnDeleteTeam";
            this.btnDeleteTeam.Size = new System.Drawing.Size(106, 23);
            this.btnDeleteTeam.TabIndex = 2;
            this.btnDeleteTeam.Text = "Delete Team";
            this.btnDeleteTeam.UseVisualStyleBackColor = false;
            this.btnDeleteTeam.Click += new System.EventHandler(this.btnDeleteTeam_Click);
            // 
            // frmTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(790, 482);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTeam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sales Team";
            this.Load += new System.EventHandler(this.frmTeam_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmTeam_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTeam_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamMaster)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTeamNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBranch;
        private Accounting.Controls.ctlDaraGridView dgvTeamDetails;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeleteMember;
        private System.Windows.Forms.TextBox txtTeamID;
        private Accounting.Controls.ctlDaraGridView dgvTeamMaster;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDeleteTeam;
    }
}