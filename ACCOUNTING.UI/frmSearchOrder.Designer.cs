namespace Accounting.UI
{
    partial class frmSearchOrder
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
            this.cboCustomerSupplier = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.chkCustSupp = new System.Windows.Forms.CheckBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkOrderNo = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.ctldgvOrders = new Accounting.Controls.ctlDaraGridView();
            this.tick = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // cboCustomerSupplier
            // 
            this.cboCustomerSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerSupplier.FormattingEnabled = true;
            this.cboCustomerSupplier.Location = new System.Drawing.Point(86, 7);
            this.cboCustomerSupplier.Name = "cboCustomerSupplier";
            this.cboCustomerSupplier.Size = new System.Drawing.Size(301, 21);
            this.cboCustomerSupplier.TabIndex = 1;
            this.cboCustomerSupplier.Enter += new System.EventHandler(this.cboCustomerSupplier_Enter);
            this.cboCustomerSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCustomerSupplier_KeyDown);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(120, 31);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(116, 20);
            this.dtpStartDate.TabIndex = 3;
            this.dtpStartDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpStartDate_KeyDown);
            // 
            // lblEDate
            // 
            this.lblEDate.AutoSize = true;
            this.lblEDate.Location = new System.Drawing.Point(242, 34);
            this.lblEDate.Name = "lblEDate";
            this.lblEDate.Size = new System.Drawing.Size(20, 13);
            this.lblEDate.TabIndex = 5;
            this.lblEDate.Text = "To";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(268, 31);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(119, 20);
            this.dtpEndDate.TabIndex = 4;
            this.dtpEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpEndDate_KeyDown);
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Enabled = false;
            this.txtOrderNo.Location = new System.Drawing.Point(120, 55);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(210, 20);
            this.txtOrderNo.TabIndex = 6;
            this.txtOrderNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderNo_KeyDown);
            // 
            // chkCustSupp
            // 
            this.chkCustSupp.AutoSize = true;
            this.chkCustSupp.BackColor = System.Drawing.Color.Transparent;
            this.chkCustSupp.Checked = true;
            this.chkCustSupp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCustSupp.Location = new System.Drawing.Point(8, 9);
            this.chkCustSupp.Name = "chkCustSupp";
            this.chkCustSupp.Size = new System.Drawing.Size(70, 17);
            this.chkCustSupp.TabIndex = 0;
            this.chkCustSupp.Text = "Customer";
            this.chkCustSupp.UseVisualStyleBackColor = false;
            this.chkCustSupp.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            this.chkCustSupp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkCustSupp_KeyDown);
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.BackColor = System.Drawing.Color.Transparent;
            this.chkDate.Location = new System.Drawing.Point(9, 34);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(104, 17);
            this.chkDate.TabIndex = 2;
            this.chkDate.Text = "Order Date From";
            this.chkDate.UseVisualStyleBackColor = false;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            this.chkDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkDate_KeyDown);
            // 
            // chkOrderNo
            // 
            this.chkOrderNo.AutoSize = true;
            this.chkOrderNo.BackColor = System.Drawing.Color.Transparent;
            this.chkOrderNo.Location = new System.Drawing.Point(9, 58);
            this.chkOrderNo.Name = "chkOrderNo";
            this.chkOrderNo.Size = new System.Drawing.Size(95, 17);
            this.chkOrderNo.TabIndex = 5;
            this.chkOrderNo.Text = "Order No. Like";
            this.chkOrderNo.UseVisualStyleBackColor = false;
            this.chkOrderNo.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            this.chkOrderNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkOrderNo_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(106, 457);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnOK_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(191, 457);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(331, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 22);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSearch_KeyDown);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(15, 86);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 14;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // ctldgvOrders
            // 
            this.ctldgvOrders.AllowUserToAddRows = false;
            this.ctldgvOrders.AllowUserToDeleteRows = false;
            this.ctldgvOrders.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctldgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctldgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tick});
            this.ctldgvOrders.ContextMenuFields = null;
            this.ctldgvOrders.IsSortable = false;
            this.ctldgvOrders.Location = new System.Drawing.Point(6, 81);
            this.ctldgvOrders.MultiSelect = false;
            this.ctldgvOrders.Name = "ctldgvOrders";
            this.ctldgvOrders.RowHeadersVisible = false;
            this.ctldgvOrders.RowPointer = 0;
            this.ctldgvOrders.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctldgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctldgvOrders.ShowDateTimePicker = false;
            this.ctldgvOrders.Size = new System.Drawing.Size(381, 370);
            this.ctldgvOrders.TabIndex = 8;
            this.ctldgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvOrders_CellDoubleClick);
            this.ctldgvOrders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctldgvOrders_KeyDown);
            this.ctldgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvOrders_CellContentClick);
            // 
            // tick
            // 
            this.tick.FalseValue = "0";
            this.tick.Frozen = true;
            this.tick.HeaderText = "";
            this.tick.IndeterminateValue = "0";
            this.tick.Name = "tick";
            this.tick.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tick.TrueValue = "1";
            this.tick.Width = 30;
            // 
            // frmSearchOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 488);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkOrderNo);
            this.Controls.Add(this.chkDate);
            this.Controls.Add(this.chkCustSupp);
            this.Controls.Add(this.txtOrderNo);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblEDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cboCustomerSupplier);
            this.Controls.Add(this.ctldgvOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSearchOrder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order Searching";
            this.Load += new System.EventHandler(this.frmSearchOrder_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSearchOrder_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Accounting.Controls.ctlDaraGridView ctldgvOrders;
        private System.Windows.Forms.ComboBox cboCustomerSupplier;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.CheckBox chkCustSupp;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkOrderNo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tick;
    }
}