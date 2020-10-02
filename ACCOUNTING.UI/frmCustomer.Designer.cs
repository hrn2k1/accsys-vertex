namespace Accounting.UI
{
    partial class frmCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbTeamName = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.rbtnTeamName = new System.Windows.Forms.RadioButton();
            this.rbtnCustomerName = new System.Windows.Forms.RadioButton();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.dgvCustomerName = new Accounting.Controls.ctlDaraGridView();
            this.cmbMember = new System.Windows.Forms.ComboBox();
            this.lebelMember = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerName)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTeamName
            // 
            this.cmbTeamName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeamName.FormattingEnabled = true;
            this.cmbTeamName.Location = new System.Drawing.Point(75, 17);
            this.cmbTeamName.Name = "cmbTeamName";
            this.cmbTeamName.Size = new System.Drawing.Size(140, 21);
            this.cmbTeamName.TabIndex = 1;
            this.cmbTeamName.TabStop = false;
            this.cmbTeamName.SelectedValueChanged += new System.EventHandler(this.cmbTeamName_SelectedValueChanged);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.Location = new System.Drawing.Point(302, 392);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(103, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rbtnTeamName
            // 
            this.rbtnTeamName.AutoSize = true;
            this.rbtnTeamName.Location = new System.Drawing.Point(6, 18);
            this.rbtnTeamName.Name = "rbtnTeamName";
            this.rbtnTeamName.Size = new System.Drawing.Size(52, 17);
            this.rbtnTeamName.TabIndex = 5;
            this.rbtnTeamName.Text = "Team";
            this.rbtnTeamName.UseVisualStyleBackColor = true;
            this.rbtnTeamName.CheckedChanged += new System.EventHandler(this.rbtnTeamName_CheckedChanged);
            // 
            // rbtnCustomerName
            // 
            this.rbtnCustomerName.AutoSize = true;
            this.rbtnCustomerName.Checked = true;
            this.rbtnCustomerName.Location = new System.Drawing.Point(5, 45);
            this.rbtnCustomerName.Name = "rbtnCustomerName";
            this.rbtnCustomerName.Size = new System.Drawing.Size(69, 17);
            this.rbtnCustomerName.TabIndex = 4;
            this.rbtnCustomerName.Text = "Customer";
            this.rbtnCustomerName.UseVisualStyleBackColor = true;
            this.rbtnCustomerName.CheckedChanged += new System.EventHandler(this.rbtnCustomerName_CheckedChanged);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(75, 42);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(331, 20);
            this.txtCustomerName.TabIndex = 0;
            this.txtCustomerName.TabStop = false;
            this.txtCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerName_KeyDown);
            // 
            // dgvCustomerName
            // 
            this.dgvCustomerName.AllowUserToAddRows = false;
            this.dgvCustomerName.AllowUserToDeleteRows = false;
            this.dgvCustomerName.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvCustomerName.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomerName.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomerName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerName.ContextMenuFields = null;
            this.dgvCustomerName.IsSortable = false;
            this.dgvCustomerName.Location = new System.Drawing.Point(4, 16);
            this.dgvCustomerName.MultiSelect = false;
            this.dgvCustomerName.Name = "dgvCustomerName";
            this.dgvCustomerName.ReadOnly = true;
            this.dgvCustomerName.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCustomerName.RowHeadersVisible = false;
            this.dgvCustomerName.RowHeadersWidth = 25;
            this.dgvCustomerName.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCustomerName.RowPointer = 0;
            this.dgvCustomerName.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomerName.ShowDateTimePicker = true;
            this.dgvCustomerName.Size = new System.Drawing.Size(402, 370);
            this.dgvCustomerName.TabIndex = 0;
            this.dgvCustomerName.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerName_CellDoubleClick);
            this.dgvCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCustomerName_KeyDown);
            this.dgvCustomerName.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerName_CellContentClick);
            // 
            // cmbMember
            // 
            this.cmbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMember.FormattingEnabled = true;
            this.cmbMember.Location = new System.Drawing.Point(272, 17);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(134, 21);
            this.cmbMember.TabIndex = 2;
            this.cmbMember.TabStop = false;
            this.cmbMember.SelectedValueChanged += new System.EventHandler(this.cmbMember_SelectedValueChanged);
            // 
            // lebelMember
            // 
            this.lebelMember.AutoSize = true;
            this.lebelMember.Location = new System.Drawing.Point(221, 20);
            this.lebelMember.Name = "lebelMember";
            this.lebelMember.Size = new System.Drawing.Size(45, 13);
            this.lebelMember.TabIndex = 3;
            this.lebelMember.Text = "Member";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lebelMember);
            this.groupBox2.Controls.Add(this.txtCustomerName);
            this.groupBox2.Controls.Add(this.cmbTeamName);
            this.groupBox2.Controls.Add(this.rbtnCustomerName);
            this.groupBox2.Controls.Add(this.cmbMember);
            this.groupBox2.Controls.Add(this.rbtnTeamName);
            this.groupBox2.Location = new System.Drawing.Point(5, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 68);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search By";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dgvCustomerName);
            this.groupBox3.Controls.Add(this.btnOK);
            this.groupBox3.Location = new System.Drawing.Point(5, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(412, 421);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Customer";
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 506);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer Searching";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmCustomer_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCustomer_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerName)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTeamName;
        private Accounting.Controls.ctlDaraGridView dgvCustomerName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rbtnTeamName;
        private System.Windows.Forms.RadioButton rbtnCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.ComboBox cmbMember;
        private System.Windows.Forms.Label lebelMember;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}