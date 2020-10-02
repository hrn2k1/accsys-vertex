namespace Accounting.UI
{
    partial class frmInventoryRequisition
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.llblItems = new System.Windows.Forms.LinkLabel();
            this.txtReqMID = new System.Windows.Forms.TextBox();
            this.cboReqSection = new System.Windows.Forms.ComboBox();
            this.dtpReqDate = new System.Windows.Forms.DateTimePicker();
            this.lblReqBy = new System.Windows.Forms.Label();
            this.lblReqDate = new System.Windows.Forms.Label();
            this.lblReqSection = new System.Windows.Forms.Label();
            this.lblReqNo = new System.Windows.Forms.Label();
            this.txtReqBy = new System.Windows.Forms.TextBox();
            this.txtReqNo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rtxtRemarks = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvReqDetail = new Accounting.Controls.ctlDaraGridView();
            this.ColReqDID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColCountID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColSizeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColColorID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Specifications = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Budle_Pack_Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Budle_Pack_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReqQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReqDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.llblItems);
            this.groupBox1.Controls.Add(this.txtReqMID);
            this.groupBox1.Controls.Add(this.cboReqSection);
            this.groupBox1.Controls.Add(this.dtpReqDate);
            this.groupBox1.Controls.Add(this.lblReqBy);
            this.groupBox1.Controls.Add(this.lblReqDate);
            this.groupBox1.Controls.Add(this.lblReqSection);
            this.groupBox1.Controls.Add(this.lblReqNo);
            this.groupBox1.Controls.Add(this.txtReqBy);
            this.groupBox1.Controls.Add(this.txtReqNo);
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // llblItems
            // 
            this.llblItems.AutoSize = true;
            this.llblItems.Location = new System.Drawing.Point(11, 64);
            this.llblItems.Name = "llblItems";
            this.llblItems.Size = new System.Drawing.Size(141, 13);
            this.llblItems.TabIndex = 4;
            this.llblItems.TabStop = true;
            this.llblItems.Text = "Select  Items  for Requisition";
            this.llblItems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblItems_LinkClicked);
            // 
            // txtReqMID
            // 
            this.txtReqMID.Location = new System.Drawing.Point(312, 14);
            this.txtReqMID.Name = "txtReqMID";
            this.txtReqMID.Size = new System.Drawing.Size(17, 20);
            this.txtReqMID.TabIndex = 7;
            this.txtReqMID.Text = "0";
            this.txtReqMID.Visible = false;
            // 
            // cboReqSection
            // 
            this.cboReqSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReqSection.FormattingEnabled = true;
            this.cboReqSection.Location = new System.Drawing.Point(88, 40);
            this.cboReqSection.Name = "cboReqSection";
            this.cboReqSection.Size = new System.Drawing.Size(218, 21);
            this.cboReqSection.TabIndex = 1;
            // 
            // dtpReqDate
            // 
            this.dtpReqDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReqDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReqDate.Location = new System.Drawing.Point(555, 13);
            this.dtpReqDate.Name = "dtpReqDate";
            this.dtpReqDate.Size = new System.Drawing.Size(220, 20);
            this.dtpReqDate.TabIndex = 2;
            // 
            // lblReqBy
            // 
            this.lblReqBy.AutoSize = true;
            this.lblReqBy.Location = new System.Drawing.Point(468, 44);
            this.lblReqBy.Name = "lblReqBy";
            this.lblReqBy.Size = new System.Drawing.Size(74, 13);
            this.lblReqBy.TabIndex = 9;
            this.lblReqBy.Text = "Requisition By";
            // 
            // lblReqDate
            // 
            this.lblReqDate.AutoSize = true;
            this.lblReqDate.Location = new System.Drawing.Point(468, 16);
            this.lblReqDate.Name = "lblReqDate";
            this.lblReqDate.Size = new System.Drawing.Size(50, 13);
            this.lblReqDate.TabIndex = 8;
            this.lblReqDate.Text = "ReqDate";
            // 
            // lblReqSection
            // 
            this.lblReqSection.AutoSize = true;
            this.lblReqSection.Location = new System.Drawing.Point(8, 43);
            this.lblReqSection.Name = "lblReqSection";
            this.lblReqSection.Size = new System.Drawing.Size(66, 13);
            this.lblReqSection.TabIndex = 6;
            this.lblReqSection.Text = "Req Section";
            // 
            // lblReqNo
            // 
            this.lblReqNo.AutoSize = true;
            this.lblReqNo.Location = new System.Drawing.Point(8, 17);
            this.lblReqNo.Name = "lblReqNo";
            this.lblReqNo.Size = new System.Drawing.Size(76, 13);
            this.lblReqNo.TabIndex = 5;
            this.lblReqNo.Text = "Requisition No";
            // 
            // txtReqBy
            // 
            this.txtReqBy.Location = new System.Drawing.Point(555, 41);
            this.txtReqBy.Name = "txtReqBy";
            this.txtReqBy.Size = new System.Drawing.Size(220, 20);
            this.txtReqBy.TabIndex = 3;
            this.txtReqBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReqNo_KeyDown);
            this.txtReqBy.Leave += new System.EventHandler(this.txtReqNo_Leave);
            this.txtReqBy.Enter += new System.EventHandler(this.txtReqNo_Enter);
            // 
            // txtReqNo
            // 
            this.txtReqNo.Location = new System.Drawing.Point(88, 13);
            this.txtReqNo.Name = "txtReqNo";
            this.txtReqNo.Size = new System.Drawing.Size(218, 20);
            this.txtReqNo.TabIndex = 0;
            this.txtReqNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReqNo_KeyDown);
            this.txtReqNo.Leave += new System.EventHandler(this.txtReqNo_Leave);
            this.txtReqNo.Enter += new System.EventHandler(this.txtReqNo_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnDeleteItem);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnFind);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.rtxtRemarks);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.dgvReqDetail);
            this.groupBox2.Location = new System.Drawing.Point(3, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(783, 397);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteItem.Location = new System.Drawing.Point(547, 360);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteItem.TabIndex = 4;
            this.btnDeleteItem.Text = "Delete Item";
            this.btnDeleteItem.UseVisualStyleBackColor = false;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.Location = new System.Drawing.Point(223, 360);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Print Slip";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Remarks";
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.Control;
            this.btnFind.Location = new System.Drawing.Point(462, 360);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.Location = new System.Drawing.Point(304, 360);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(628, 360);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(383, 360);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rtxtRemarks
            // 
            this.rtxtRemarks.Location = new System.Drawing.Point(69, 317);
            this.rtxtRemarks.Name = "rtxtRemarks";
            this.rtxtRemarks.Size = new System.Drawing.Size(706, 38);
            this.rtxtRemarks.TabIndex = 1;
            this.rtxtRemarks.Text = "";
            this.rtxtRemarks.Enter += new System.EventHandler(this.txtReqNo_Enter);
            this.rtxtRemarks.Leave += new System.EventHandler(this.txtReqNo_Leave);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(706, 360);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvReqDetail
            // 
            this.dgvReqDetail.AllowUserToDeleteRows = false;
            this.dgvReqDetail.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvReqDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReqDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColReqDID,
            this.ColItemID,
            this.ColCountID,
            this.ColSizeID,
            this.ColColorID,
            this.Specifications,
            this.Budle_Pack_Size,
            this.Budle_Pack_Qty,
            this.ColReqQty,
            this.ColUnitID,
            this.ColUnit});
            this.dgvReqDetail.ContextMenuFields = null;
            this.dgvReqDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvReqDetail.isEnterKeyLikeTabKey = true;
            this.dgvReqDetail.isExcelSheetCell = false;
            this.dgvReqDetail.IsSortable = false;
            this.dgvReqDetail.Location = new System.Drawing.Point(6, 13);
            this.dgvReqDetail.Name = "dgvReqDetail";
            this.dgvReqDetail.RowHeadersVisible = false;
            this.dgvReqDetail.RowHeadersWidth = 25;
            this.dgvReqDetail.RowPointer = 0;
            this.dgvReqDetail.ShowDateTimePicker = true;
            this.dgvReqDetail.Size = new System.Drawing.Size(771, 300);
            this.dgvReqDetail.TabIndex = 0;
            this.dgvReqDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReqDetail_CellValueChanged);
            this.dgvReqDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvReqDetail_EditingControlShowing);
            this.dgvReqDetail.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReqDetail_CellEnter);
            // 
            // ColReqDID
            // 
            this.ColReqDID.HeaderText = "ReqDID";
            this.ColReqDID.Name = "ColReqDID";
            this.ColReqDID.Visible = false;
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
            // Specifications
            // 
            this.Specifications.HeaderText = "Specifications";
            this.Specifications.Name = "Specifications";
            this.Specifications.Width = 80;
            // 
            // Budle_Pack_Size
            // 
            this.Budle_Pack_Size.HeaderText = "Bdl/Pk Size";
            this.Budle_Pack_Size.Name = "Budle_Pack_Size";
            this.Budle_Pack_Size.Width = 80;
            // 
            // Budle_Pack_Qty
            // 
            this.Budle_Pack_Qty.HeaderText = "Bdl/Pk Size";
            this.Budle_Pack_Qty.Name = "Budle_Pack_Qty";
            // 
            // ColReqQty
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0.00";
            this.ColReqQty.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColReqQty.HeaderText = "ReqQty";
            this.ColReqQty.Name = "ColReqQty";
            this.ColReqQty.Width = 90;
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
            // frmInventoryRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 475);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInventoryRequisition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventory Requisition";
            this.Load += new System.EventHandler(this.frmInventoryRequisition_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmInventoryRequisition_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInventoryRequisition_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReqDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblReqDate;
        private System.Windows.Forms.Label lblReqSection;
        private System.Windows.Forms.Label lblReqNo;
        private System.Windows.Forms.TextBox txtReqBy;
        private System.Windows.Forms.TextBox txtReqNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
        private Accounting.Controls.ctlDaraGridView dgvReqDetail;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtpReqDate;
        private System.Windows.Forms.Label lblReqBy;
        private System.Windows.Forms.ComboBox cboReqSection;
        private System.Windows.Forms.RichTextBox rtxtRemarks;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReqMID;
        private System.Windows.Forms.LinkLabel llblItems;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReqDID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColItemID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColCountID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColSizeID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColColorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Specifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn Budle_Pack_Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Budle_Pack_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReqQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnit;
    }
}