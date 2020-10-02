namespace Accounting.UI
{
    partial class frmOrderAmend
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.dtpAmendDate = new System.Windows.Forms.DateTimePicker();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.dgvAmendOrder = new Accounting.Controls.ctlDaraGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.lblTotalOrderQty = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTotalOrderQty = new System.Windows.Forms.TextBox();
            this.txtTotalOrderVal = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblTotalOrderValue = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmendOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.dtpAmendDate);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.dgvAmendOrder);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.lblTotalOrderQty);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtTotalOrderQty);
            this.groupBox1.Controls.Add(this.txtTotalOrderVal);
            this.groupBox1.Controls.Add(this.lblUnit);
            this.groupBox1.Controls.Add(this.lblTotalOrderValue);
            this.groupBox1.Location = new System.Drawing.Point(2, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 345);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Amendment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Amendment Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Amendment Date";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.Location = new System.Drawing.Point(442, 314);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(62, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dtpAmendDate
            // 
            this.dtpAmendDate.CustomFormat = "dd/MM/yyyy";
            this.dtpAmendDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAmendDate.Location = new System.Drawing.Point(98, 272);
            this.dtpAmendDate.Name = "dtpAmendDate";
            this.dtpAmendDate.Size = new System.Drawing.Size(100, 20);
            this.dtpAmendDate.TabIndex = 1;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(98, 299);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(335, 40);
            this.txtComment.TabIndex = 2;
            // 
            // dgvAmendOrder
            // 
            this.dgvAmendOrder.AllowUserToAddRows = false;
            this.dgvAmendOrder.AllowUserToDeleteRows = false;
            this.dgvAmendOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAmendOrder.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvAmendOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAmendOrder.ContextMenuFields = null;
            this.dgvAmendOrder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAmendOrder.IsSortable = false;
            this.dgvAmendOrder.Location = new System.Drawing.Point(6, 17);
            this.dgvAmendOrder.MultiSelect = false;
            this.dgvAmendOrder.Name = "dgvAmendOrder";
            this.dgvAmendOrder.RowHeadersWidth = 25;
            this.dgvAmendOrder.RowPointer = 0;
            this.dgvAmendOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAmendOrder.ShowDateTimePicker = true;
            this.dgvAmendOrder.Size = new System.Drawing.Size(735, 247);
            this.dgvAmendOrder.TabIndex = 0;
            this.dgvAmendOrder.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAmendOrder_CellValueChanged);
            this.dgvAmendOrder.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvAmendOrder_EditingControlShowing);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(668, 314);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.Control;
            this.btnFind.Location = new System.Drawing.Point(589, 314);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lblTotalOrderQty
            // 
            this.lblTotalOrderQty.AutoSize = true;
            this.lblTotalOrderQty.Location = new System.Drawing.Point(241, 276);
            this.lblTotalOrderQty.Name = "lblTotalOrderQty";
            this.lblTotalOrderQty.Size = new System.Drawing.Size(109, 13);
            this.lblTotalOrderQty.TabIndex = 24;
            this.lblTotalOrderQty.Text = "Total Amendment Qty";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(510, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTotalOrderQty
            // 
            this.txtTotalOrderQty.Location = new System.Drawing.Point(356, 273);
            this.txtTotalOrderQty.Name = "txtTotalOrderQty";
            this.txtTotalOrderQty.ReadOnly = true;
            this.txtTotalOrderQty.Size = new System.Drawing.Size(84, 20);
            this.txtTotalOrderQty.TabIndex = 7;
            this.txtTotalOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalOrderVal
            // 
            this.txtTotalOrderVal.Location = new System.Drawing.Point(631, 273);
            this.txtTotalOrderVal.Name = "txtTotalOrderVal";
            this.txtTotalOrderVal.ReadOnly = true;
            this.txtTotalOrderVal.Size = new System.Drawing.Size(111, 20);
            this.txtTotalOrderVal.TabIndex = 8;
            this.txtTotalOrderVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(446, 276);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(26, 13);
            this.lblUnit.TabIndex = 26;
            this.lblUnit.Text = "Unit";
            // 
            // lblTotalOrderValue
            // 
            this.lblTotalOrderValue.AutoSize = true;
            this.lblTotalOrderValue.Location = new System.Drawing.Point(507, 276);
            this.lblTotalOrderValue.Name = "lblTotalOrderValue";
            this.lblTotalOrderValue.Size = new System.Drawing.Size(120, 13);
            this.lblTotalOrderValue.TabIndex = 25;
            this.lblTotalOrderValue.Text = "Total Amendment Value";
            // 
            // frmOrderAmend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 362);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrderAmend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order Amendment";
            this.Load += new System.EventHandler(this.frmSalesOrderAmend_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSalesOrderAmend_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmendOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Accounting.Controls.ctlDaraGridView dgvAmendOrder;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblTotalOrderQty;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTotalOrderQty;
        private System.Windows.Forms.TextBox txtTotalOrderVal;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblTotalOrderValue;
        private System.Windows.Forms.DateTimePicker dtpAmendDate;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}