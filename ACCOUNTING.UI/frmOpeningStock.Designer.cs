namespace Accounting.UI
{
    partial class frmOpeningStock
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
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.llblItems = new System.Windows.Forms.LinkLabel();
            this.numDollorRate = new Accounting.Controls.ctlNum();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.dtpOpeningDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkHitAccount = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFinishedAccount = new System.Windows.Forms.TextBox();
            this.txtRawAccount = new System.Windows.Forms.TextBox();
            this.ctlNumFinishGoods = new Accounting.Controls.ctlNum();
            this.ctlNumRawMaterials = new Accounting.Controls.ctlNum();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOpnRaw = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctldgvItems = new Accounting.Controls.ctlDaraGridView();
            this.ColOpeningStockID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColCountID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColSizeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColColorID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColColorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLabdip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOpeningQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOpeningAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cboCurrency);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.llblItems);
            this.groupBox1.Controls.Add(this.numDollorRate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCustomerID);
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.dtpOpeningDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cboCurrency
            // 
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(580, 14);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(96, 21);
            this.cboCurrency.TabIndex = 2;
            this.cboCurrency.Enter += new System.EventHandler(this.cboCurrency_Enter);
            this.cboCurrency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCurrency_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(525, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Currency";
            // 
            // llblItems
            // 
            this.llblItems.AutoSize = true;
            this.llblItems.Location = new System.Drawing.Point(16, 41);
            this.llblItems.Name = "llblItems";
            this.llblItems.Size = new System.Drawing.Size(68, 13);
            this.llblItems.TabIndex = 4;
            this.llblItems.TabStop = true;
            this.llblItems.Text = "Select  Items";
            this.llblItems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblItems_LinkClicked);
            // 
            // numDollorRate
            // 
            this.numDollorRate.BackgroudColor = System.Drawing.SystemColors.Window;
            this.numDollorRate.Location = new System.Drawing.Point(725, 13);
            this.numDollorRate.Name = "numDollorRate";
            this.numDollorRate.ReadOnly = false;
            this.numDollorRate.Size = new System.Drawing.Size(49, 20);
            this.numDollorRate.TabIndex = 3;
            this.numDollorRate.TextColor = System.Drawing.SystemColors.WindowText;
            this.numDollorRate.Value = 1;
            this.numDollorRate.Leave += new System.EventHandler(this.numDollorRate_Leave);
            this.numDollorRate.Enter += new System.EventHandler(this.numDollorRate_Enter);
            this.numDollorRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numDollorRate_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(689, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rate";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(265, 14);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(20, 20);
            this.txtCustomerID.TabIndex = 6;
            this.txtCustomerID.Text = "0";
            this.txtCustomerID.Visible = false;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(79, 14);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(180, 20);
            this.txtCustomer.TabIndex = 0;
            this.txtCustomer.DoubleClick += new System.EventHandler(this.txtCustomer_DoubleClicked);
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            this.txtCustomer.Leave += new System.EventHandler(this.txtCustomer_Leave);
            this.txtCustomer.Enter += new System.EventHandler(this.txtCustomer_Enter);
            // 
            // dtpOpeningDate
            // 
            this.dtpOpeningDate.CustomFormat = "dd/MM/yyyy";
            this.dtpOpeningDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOpeningDate.Location = new System.Drawing.Point(371, 13);
            this.dtpOpeningDate.Name = "dtpOpeningDate";
            this.dtpOpeningDate.Size = new System.Drawing.Size(127, 20);
            this.dtpOpeningDate.TabIndex = 1;
            this.dtpOpeningDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpOpeningDate_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(291, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Opening Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Customer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.chkHitAccount);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtFinishedAccount);
            this.groupBox3.Controls.Add(this.txtRawAccount);
            this.groupBox3.Controls.Add(this.ctlNumFinishGoods);
            this.groupBox3.Controls.Add(this.ctlNumRawMaterials);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblOpnRaw);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Location = new System.Drawing.Point(7, 408);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(778, 82);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // chkHitAccount
            // 
            this.chkHitAccount.AutoSize = true;
            this.chkHitAccount.Enabled = false;
            this.chkHitAccount.Location = new System.Drawing.Point(540, 15);
            this.chkHitAccount.Name = "chkHitAccount";
            this.chkHitAccount.Size = new System.Drawing.Size(140, 17);
            this.chkHitAccount.TabIndex = 10;
            this.chkHitAccount.Text = "Effect to Stock Account";
            this.chkHitAccount.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(220, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "TK";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "TK";
            // 
            // txtFinishedAccount
            // 
            this.txtFinishedAccount.Location = new System.Drawing.Point(251, 40);
            this.txtFinishedAccount.Name = "txtFinishedAccount";
            this.txtFinishedAccount.ReadOnly = true;
            this.txtFinishedAccount.Size = new System.Drawing.Size(242, 20);
            this.txtFinishedAccount.TabIndex = 1;
            this.txtFinishedAccount.Visible = false;
            this.txtFinishedAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRawAccount_KeyDown);
            this.txtFinishedAccount.Leave += new System.EventHandler(this.txtRawAccount_Leave);
            this.txtFinishedAccount.Enter += new System.EventHandler(this.txtFinishedAccount_Enter);
            // 
            // txtRawAccount
            // 
            this.txtRawAccount.Location = new System.Drawing.Point(251, 10);
            this.txtRawAccount.Name = "txtRawAccount";
            this.txtRawAccount.ReadOnly = true;
            this.txtRawAccount.Size = new System.Drawing.Size(242, 20);
            this.txtRawAccount.TabIndex = 0;
            this.txtRawAccount.Visible = false;
            this.txtRawAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRawAccount_KeyDown);
            this.txtRawAccount.Leave += new System.EventHandler(this.txtRawAccount_Leave);
            this.txtRawAccount.Enter += new System.EventHandler(this.txtRawAccount_Enter);
            // 
            // ctlNumFinishGoods
            // 
            this.ctlNumFinishGoods.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumFinishGoods.Location = new System.Drawing.Point(147, 40);
            this.ctlNumFinishGoods.Name = "ctlNumFinishGoods";
            this.ctlNumFinishGoods.ReadOnly = true;
            this.ctlNumFinishGoods.Size = new System.Drawing.Size(70, 20);
            this.ctlNumFinishGoods.TabIndex = 6;
            this.ctlNumFinishGoods.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumFinishGoods.Value = 0;
            this.ctlNumFinishGoods.Enter += new System.EventHandler(this.ctlNumRawMaterials_Enter);
            // 
            // ctlNumRawMaterials
            // 
            this.ctlNumRawMaterials.BackgroudColor = System.Drawing.SystemColors.Window;
            this.ctlNumRawMaterials.Location = new System.Drawing.Point(147, 10);
            this.ctlNumRawMaterials.Name = "ctlNumRawMaterials";
            this.ctlNumRawMaterials.ReadOnly = true;
            this.ctlNumRawMaterials.Size = new System.Drawing.Size(70, 20);
            this.ctlNumRawMaterials.TabIndex = 5;
            this.ctlNumRawMaterials.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumRawMaterials.Value = 0;
            this.ctlNumRawMaterials.Enter += new System.EventHandler(this.ctlNumRawMaterials_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Opening of Finished Goods";
            // 
            // lblOpnRaw
            // 
            this.lblOpnRaw.AutoSize = true;
            this.lblOpnRaw.Location = new System.Drawing.Point(5, 12);
            this.lblOpnRaw.Name = "lblOpnRaw";
            this.lblOpnRaw.Size = new System.Drawing.Size(129, 13);
            this.lblOpnRaw.TabIndex = 7;
            this.lblOpnRaw.Text = "Opening of Raw Materials";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(702, 53);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(621, 53);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDelete_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(540, 53);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // ctldgvItems
            // 
            this.ctldgvItems.AllowUserToDeleteRows = false;
            this.ctldgvItems.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctldgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctldgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColOpeningStockID,
            this.ColItemID,
            this.ColCountID,
            this.ColSizeID,
            this.ColColorID,
            this.ColColorCode,
            this.ColLabdip,
            this.ColOpeningQty,
            this.ColUnitID,
            this.ColUnit,
            this.ColUnitPrice,
            this.ColOpeningAmount,
            this.ColRemarks});
            this.ctldgvItems.ContextMenuFields = null;
            this.ctldgvItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ctldgvItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ctldgvItems.IsSortable = false;
            this.ctldgvItems.Location = new System.Drawing.Point(4, 65);
            this.ctldgvItems.MultiSelect = false;
            this.ctldgvItems.Name = "ctldgvItems";
            this.ctldgvItems.RowHeadersWidth = 25;
            this.ctldgvItems.RowPointer = 0;
            this.ctldgvItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctldgvItems.ShowDateTimePicker = true;
            this.ctldgvItems.Size = new System.Drawing.Size(781, 340);
            this.ctldgvItems.TabIndex = 1;
            this.ctldgvItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvItems_CellValueChanged);
            this.ctldgvItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ctldgvItems_EditingControlShowing);
            this.ctldgvItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctldgvItems_KeyDown);
            this.ctldgvItems.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvItems_CellEnter);
            this.ctldgvItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvItems_CellContentClick);
            // 
            // ColOpeningStockID
            // 
            this.ColOpeningStockID.HeaderText = "OpeningStockID";
            this.ColOpeningStockID.Name = "ColOpeningStockID";
            this.ColOpeningStockID.Visible = false;
            // 
            // ColItemID
            // 
            this.ColItemID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColItemID.HeaderText = "Item";
            this.ColItemID.Name = "ColItemID";
            this.ColItemID.Width = 150;
            // 
            // ColCountID
            // 
            this.ColCountID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColCountID.HeaderText = "Count";
            this.ColCountID.Name = "ColCountID";
            this.ColCountID.Width = 70;
            // 
            // ColSizeID
            // 
            this.ColSizeID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColSizeID.HeaderText = "Size";
            this.ColSizeID.Name = "ColSizeID";
            this.ColSizeID.Width = 70;
            // 
            // ColColorID
            // 
            this.ColColorID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.ColColorID.HeaderText = "Color";
            this.ColColorID.Name = "ColColorID";
            this.ColColorID.Width = 70;
            // 
            // ColColorCode
            // 
            this.ColColorCode.HeaderText = "ColorCode";
            this.ColColorCode.Name = "ColColorCode";
            this.ColColorCode.Width = 90;
            // 
            // ColLabdip
            // 
            this.ColLabdip.HeaderText = "Labdip";
            this.ColLabdip.Name = "ColLabdip";
            this.ColLabdip.Width = 90;
            // 
            // ColOpeningQty
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0.00";
            this.ColOpeningQty.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColOpeningQty.HeaderText = "OpeningQty";
            this.ColOpeningQty.Name = "ColOpeningQty";
            this.ColOpeningQty.Width = 90;
            // 
            // ColUnitID
            // 
            this.ColUnitID.HeaderText = "UnitID";
            this.ColUnitID.Name = "ColUnitID";
            this.ColUnitID.Visible = false;
            // 
            // ColUnit
            // 
            this.ColUnit.HeaderText = "Unit";
            this.ColUnit.Name = "ColUnit";
            this.ColUnit.ReadOnly = true;
            this.ColUnit.Width = 70;
            // 
            // ColUnitPrice
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.ColUnitPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColUnitPrice.HeaderText = "UnitPrice";
            this.ColUnitPrice.Name = "ColUnitPrice";
            this.ColUnitPrice.Width = 90;
            // 
            // ColOpeningAmount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0.00";
            this.ColOpeningAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColOpeningAmount.HeaderText = "OpeningAmount";
            this.ColOpeningAmount.Name = "ColOpeningAmount";
            this.ColOpeningAmount.ReadOnly = true;
            this.ColOpeningAmount.Width = 90;
            // 
            // ColRemarks
            // 
            this.ColRemarks.HeaderText = "Remarks";
            this.ColRemarks.Name = "ColRemarks";
            this.ColRemarks.Width = 90;
            // 
            // frmOpeningStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 497);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ctldgvItems);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOpeningStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opening Stock";
            this.Load += new System.EventHandler(this.frmOpeningStock_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmOpeningStock_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOpeningStock_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpOpeningDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Accounting.Controls.ctlDaraGridView ctldgvItems;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label3;
        private Accounting.Controls.ctlNum numDollorRate;
        private System.Windows.Forms.LinkLabel llblItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOpeningStockID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColItemID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColCountID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColSizeID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColColorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColColorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLabdip;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOpeningQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOpeningAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRemarks;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Label label4;
        private Accounting.Controls.ctlNum ctlNumFinishGoods;
        private Accounting.Controls.ctlNum ctlNumRawMaterials;
        private System.Windows.Forms.Label lblOpnRaw;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFinishedAccount;
        private System.Windows.Forms.TextBox txtRawAccount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkHitAccount;
    }
}