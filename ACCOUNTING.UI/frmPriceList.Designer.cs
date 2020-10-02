namespace Accounting.UI
{
    partial class frmPriceList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbItemwise = new System.Windows.Forms.RadioButton();
            this.rbCustomerwise = new System.Windows.Forms.RadioButton();
            this.dtpSetupDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.gbxCustomer = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.cboMember = new System.Windows.Forms.ComboBox();
            this.cboTeam = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.llblItems = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.gbxButtons = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctldgvPriceList = new Accounting.Controls.ctlDaraGridView();
            this.PriceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CountID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SizeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColorID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.UnitID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetupDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.gbxCustomer.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvPriceList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbItemwise);
            this.groupBox1.Controls.Add(this.rbCustomerwise);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 41);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Price Setup Option";
            // 
            // rbItemwise
            // 
            this.rbItemwise.AutoSize = true;
            this.rbItemwise.Location = new System.Drawing.Point(191, 19);
            this.rbItemwise.Name = "rbItemwise";
            this.rbItemwise.Size = new System.Drawing.Size(110, 17);
            this.rbItemwise.TabIndex = 1;
            this.rbItemwise.Text = "General item price";
            this.rbItemwise.UseVisualStyleBackColor = true;
            this.rbItemwise.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctl_KeyDown);
            // 
            // rbCustomerwise
            // 
            this.rbCustomerwise.AutoSize = true;
            this.rbCustomerwise.Checked = true;
            this.rbCustomerwise.Location = new System.Drawing.Point(10, 18);
            this.rbCustomerwise.Name = "rbCustomerwise";
            this.rbCustomerwise.Size = new System.Drawing.Size(141, 17);
            this.rbCustomerwise.TabIndex = 0;
            this.rbCustomerwise.TabStop = true;
            this.rbCustomerwise.Text = "Customer wise item price";
            this.rbCustomerwise.UseVisualStyleBackColor = true;
            this.rbCustomerwise.CheckedChanged += new System.EventHandler(this.rbCustomerwise_CheckedChanged);
            this.rbCustomerwise.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctl_KeyDown);
            // 
            // dtpSetupDate
            // 
            this.dtpSetupDate.CustomFormat = "dd/MM/yyyy";
            this.dtpSetupDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSetupDate.Location = new System.Drawing.Point(89, 8);
            this.dtpSetupDate.Name = "dtpSetupDate";
            this.dtpSetupDate.Size = new System.Drawing.Size(106, 20);
            this.dtpSetupDate.TabIndex = 2;
            this.dtpSetupDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctl_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "SetupDate";
            // 
            // gbxCustomer
            // 
            this.gbxCustomer.Controls.Add(this.label3);
            this.gbxCustomer.Controls.Add(this.label2);
            this.gbxCustomer.Controls.Add(this.label1);
            this.gbxCustomer.Controls.Add(this.cboCustomer);
            this.gbxCustomer.Controls.Add(this.cboMember);
            this.gbxCustomer.Controls.Add(this.cboTeam);
            this.gbxCustomer.Location = new System.Drawing.Point(0, 0);
            this.gbxCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.gbxCustomer.Name = "gbxCustomer";
            this.gbxCustomer.Size = new System.Drawing.Size(738, 51);
            this.gbxCustomer.TabIndex = 0;
            this.gbxCustomer.TabStop = false;
            this.gbxCustomer.Text = "Customer";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(477, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Customer";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(234, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Team member";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sales Team";
            // 
            // cboCustomer
            // 
            this.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(534, 20);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(198, 21);
            this.cboCustomer.TabIndex = 2;
            this.cboCustomer.Enter += new System.EventHandler(this.cbo_Enter);
            this.cboCustomer.SelectedValueChanged += new System.EventHandler(this.cboCustomer_SelectedValueChanged);
            this.cboCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctl_KeyDown);
            // 
            // cboMember
            // 
            this.cboMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMember.FormattingEnabled = true;
            this.cboMember.Location = new System.Drawing.Point(316, 20);
            this.cboMember.Name = "cboMember";
            this.cboMember.Size = new System.Drawing.Size(157, 21);
            this.cboMember.TabIndex = 1;
            this.cboMember.Enter += new System.EventHandler(this.cbo_Enter);
            this.cboMember.SelectedValueChanged += new System.EventHandler(this.cboMember_SelectedValueChanged);
            this.cboMember.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctl_KeyDown);
            // 
            // cboTeam
            // 
            this.cboTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTeam.FormattingEnabled = true;
            this.cboTeam.Location = new System.Drawing.Point(77, 20);
            this.cboTeam.Name = "cboTeam";
            this.cboTeam.Size = new System.Drawing.Size(150, 21);
            this.cboTeam.TabIndex = 0;
            this.cboTeam.Enter += new System.EventHandler(this.cbo_Enter);
            this.cboTeam.SelectedValueChanged += new System.EventHandler(this.cboTeam_SelectedValueChanged);
            this.cboTeam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctl_KeyDown);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.gbxCustomer);
            this.flowLayoutPanel1.Controls.Add(this.llblItems);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.ctldgvPriceList);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 51);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(742, 387);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // llblItems
            // 
            this.llblItems.Location = new System.Drawing.Point(0, 51);
            this.llblItems.Margin = new System.Windows.Forms.Padding(0);
            this.llblItems.Name = "llblItems";
            this.llblItems.Size = new System.Drawing.Size(301, 40);
            this.llblItems.TabIndex = 1;
            this.llblItems.TabStop = true;
            this.llblItems.Text = "Select Items to set price";
            this.llblItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblItems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblItems_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtpEndDate);
            this.groupBox2.Controls.Add(this.dtpStartDate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnFind);
            this.groupBox2.Location = new System.Drawing.Point(301, 51);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 42);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search By";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = " to ";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(234, 15);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(105, 20);
            this.dtpEndDate.TabIndex = 3;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(94, 14);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(105, 20);
            this.dtpStartDate.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Setup date from";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(345, 13);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(71, 23);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "&Search";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // gbxButtons
            // 
            this.gbxButtons.BackColor = System.Drawing.Color.Transparent;
            this.gbxButtons.Controls.Add(this.btnReset);
            this.gbxButtons.Controls.Add(this.dtpSetupDate);
            this.gbxButtons.Controls.Add(this.btnClose);
            this.gbxButtons.Controls.Add(this.label4);
            this.gbxButtons.Controls.Add(this.btnDelete);
            this.gbxButtons.Controls.Add(this.btnSave);
            this.gbxButtons.Location = new System.Drawing.Point(15, 438);
            this.gbxButtons.Margin = new System.Windows.Forms.Padding(0);
            this.gbxButtons.Name = "gbxButtons";
            this.gbxButtons.Size = new System.Drawing.Size(739, 33);
            this.gbxButtons.TabIndex = 4;
            this.gbxButtons.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(411, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(654, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(573, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(492, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctldgvPriceList
            // 
            this.ctldgvPriceList.AllowUserToDeleteRows = false;
            this.ctldgvPriceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctldgvPriceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PriceID,
            this.ItemID,
            this.CountID,
            this.SizeID,
            this.ColorID,
            this.UnitID,
            this.Price,
            this.Vat,
            this.Remarks,
            this.SetupDate});
            this.ctldgvPriceList.ContextMenuFields = null;
            this.ctldgvPriceList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ctldgvPriceList.isEnterKeyLikeTabKey = true;
            this.ctldgvPriceList.isExcelSheetCell = false;
            this.ctldgvPriceList.IsSortable = false;
            this.ctldgvPriceList.Location = new System.Drawing.Point(3, 96);
            this.ctldgvPriceList.MultiSelect = false;
            this.ctldgvPriceList.Name = "ctldgvPriceList";
            this.ctldgvPriceList.RowHeadersWidth = 25;
            this.ctldgvPriceList.RowPointer = 0;
            this.ctldgvPriceList.ShowDateTimePicker = false;
            this.ctldgvPriceList.Size = new System.Drawing.Size(729, 288);
            this.ctldgvPriceList.TabIndex = 0;
            this.ctldgvPriceList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvPriceList_CellValueChanged);
            this.ctldgvPriceList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ctldgvPriceList_EditingControlShowing);
            this.ctldgvPriceList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvPriceList_CellEnter);
            // 
            // PriceID
            // 
            this.PriceID.HeaderText = "PriceID";
            this.PriceID.Name = "PriceID";
            this.PriceID.Visible = false;
            // 
            // ItemID
            // 
            this.ItemID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ItemID.HeaderText = "Item";
            this.ItemID.Name = "ItemID";
            // 
            // CountID
            // 
            this.CountID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CountID.HeaderText = "Count";
            this.CountID.Name = "CountID";
            this.CountID.Width = 60;
            // 
            // SizeID
            // 
            this.SizeID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.SizeID.HeaderText = "Size";
            this.SizeID.Name = "SizeID";
            this.SizeID.Width = 70;
            // 
            // ColorID
            // 
            this.ColorID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColorID.HeaderText = "Prd.Type";
            this.ColorID.Name = "ColorID";
            this.ColorID.Width = 70;
            // 
            // UnitID
            // 
            this.UnitID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.UnitID.HeaderText = "Unit";
            this.UnitID.Name = "UnitID";
            this.UnitID.ReadOnly = true;
            this.UnitID.Width = 70;
            // 
            // Price
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0.00";
            this.Price.DefaultCellStyle = dataGridViewCellStyle1;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.Width = 70;
            // 
            // Vat
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.Vat.DefaultCellStyle = dataGridViewCellStyle2;
            this.Vat.HeaderText = "VAT";
            this.Vat.Name = "Vat";
            this.Vat.Width = 70;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            // 
            // SetupDate
            // 
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.SetupDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.SetupDate.HeaderText = "Setup Date";
            this.SetupDate.Name = "SetupDate";
            this.SetupDate.ReadOnly = true;
            // 
            // frmPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 480);
            this.Controls.Add(this.gbxButtons);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPriceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Price List";
            this.Load += new System.EventHandler(this.frmPriceList_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPriceList_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPriceList_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxCustomer.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxButtons.ResumeLayout(false);
            this.gbxButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvPriceList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbItemwise;
        private System.Windows.Forms.RadioButton rbCustomerwise;
        private System.Windows.Forms.GroupBox gbxCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.ComboBox cboMember;
        private System.Windows.Forms.ComboBox cboTeam;
        private Accounting.Controls.ctlDaraGridView ctldgvPriceList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox gbxButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpSetupDate;
        private System.Windows.Forms.LinkLabel llblItems;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewComboBoxColumn CountID;
        private System.Windows.Forms.DataGridViewComboBoxColumn SizeID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColorID;
        private System.Windows.Forms.DataGridViewComboBoxColumn UnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetupDate;
    }
}