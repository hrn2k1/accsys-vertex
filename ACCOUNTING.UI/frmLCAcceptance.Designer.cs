namespace Accounting.UI
{
    partial class frmLCAcceptance
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
            this.dgvLCAcceptance = new Accounting.Controls.ctlDaraGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLC = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNegotiateBank = new System.Windows.Forms.TextBox();
            this.txtIssueBank = new System.Windows.Forms.TextBox();
            this.txtLCID = new System.Windows.Forms.TextBox();
            this.txtLCNo = new System.Windows.Forms.TextBox();
            this.ctlNumTotalValue = new Accounting.Controls.ctlNum();
            this.ctlNumTotalQty = new Accounting.Controls.ctlNum();
            this.lblAcceptValue = new System.Windows.Forms.Label();
            this.lblAcceptQty = new System.Windows.Forms.Label();
            this.lblLCNo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLCAcceptance)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLCAcceptance
            // 
            this.dgvLCAcceptance.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLCAcceptance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLCAcceptance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLCAcceptance.ContextMenuFields = null;
            this.dgvLCAcceptance.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvLCAcceptance.isEnterKeyLikeTabKey = true;
            this.dgvLCAcceptance.isExcelSheetCell = false;
            this.dgvLCAcceptance.IsSortable = false;
            this.dgvLCAcceptance.Location = new System.Drawing.Point(6, 14);
            this.dgvLCAcceptance.Name = "dgvLCAcceptance";
            this.dgvLCAcceptance.RowHeadersWidth = 25;
            this.dgvLCAcceptance.RowPointer = 0;
            this.dgvLCAcceptance.ShowDateTimePicker = true;
            this.dgvLCAcceptance.Size = new System.Drawing.Size(626, 205);
            this.dgvLCAcceptance.TabIndex = 0;
            this.dgvLCAcceptance.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLCAcceptance_CellValueChanged);
            this.dgvLCAcceptance.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvLCAcceptance_EditingControlShowing);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnLC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNegotiateBank);
            this.groupBox1.Controls.Add(this.txtIssueBank);
            this.groupBox1.Controls.Add(this.txtLCID);
            this.groupBox1.Controls.Add(this.txtLCNo);
            this.groupBox1.Controls.Add(this.ctlNumTotalValue);
            this.groupBox1.Controls.Add(this.ctlNumTotalQty);
            this.groupBox1.Controls.Add(this.lblAcceptValue);
            this.groupBox1.Controls.Add(this.lblAcceptQty);
            this.groupBox1.Controls.Add(this.lblLCNo);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 144);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnLC
            // 
            this.btnLC.BackColor = System.Drawing.SystemColors.Control;
            this.btnLC.Location = new System.Drawing.Point(406, 13);
            this.btnLC.Name = "btnLC";
            this.btnLC.Size = new System.Drawing.Size(22, 23);
            this.btnLC.TabIndex = 0;
            this.btnLC.Text = "..";
            this.btnLC.UseVisualStyleBackColor = false;
            this.btnLC.Click += new System.EventHandler(this.btnLC_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Negotiate Bank";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Issue Bank";
            // 
            // txtNegotiateBank
            // 
            this.txtNegotiateBank.Location = new System.Drawing.Point(103, 65);
            this.txtNegotiateBank.Name = "txtNegotiateBank";
            this.txtNegotiateBank.ReadOnly = true;
            this.txtNegotiateBank.Size = new System.Drawing.Size(297, 20);
            this.txtNegotiateBank.TabIndex = 3;
            // 
            // txtIssueBank
            // 
            this.txtIssueBank.Location = new System.Drawing.Point(103, 39);
            this.txtIssueBank.Name = "txtIssueBank";
            this.txtIssueBank.ReadOnly = true;
            this.txtIssueBank.Size = new System.Drawing.Size(297, 20);
            this.txtIssueBank.TabIndex = 2;
            // 
            // txtLCID
            // 
            this.txtLCID.Location = new System.Drawing.Point(51, 13);
            this.txtLCID.Name = "txtLCID";
            this.txtLCID.Size = new System.Drawing.Size(36, 20);
            this.txtLCID.TabIndex = 11;
            this.txtLCID.Visible = false;
            this.txtLCID.TextChanged += new System.EventHandler(this.txtLCID_TextChanged);
            // 
            // txtLCNo
            // 
            this.txtLCNo.Location = new System.Drawing.Point(103, 13);
            this.txtLCNo.Name = "txtLCNo";
            this.txtLCNo.ReadOnly = true;
            this.txtLCNo.Size = new System.Drawing.Size(297, 20);
            this.txtLCNo.TabIndex = 1;
            // 
            // ctlNumTotalValue
            // 
            this.ctlNumTotalValue.BackgroudColor = System.Drawing.SystemColors.Control;
            this.ctlNumTotalValue.Location = new System.Drawing.Point(103, 117);
            this.ctlNumTotalValue.Name = "ctlNumTotalValue";
            this.ctlNumTotalValue.ReadOnly = true;
            this.ctlNumTotalValue.Size = new System.Drawing.Size(174, 20);
            this.ctlNumTotalValue.TabIndex = 5;
            this.ctlNumTotalValue.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumTotalValue.Value = 0;
            // 
            // ctlNumTotalQty
            // 
            this.ctlNumTotalQty.BackgroudColor = System.Drawing.SystemColors.Control;
            this.ctlNumTotalQty.Location = new System.Drawing.Point(103, 91);
            this.ctlNumTotalQty.Name = "ctlNumTotalQty";
            this.ctlNumTotalQty.ReadOnly = true;
            this.ctlNumTotalQty.Size = new System.Drawing.Size(174, 20);
            this.ctlNumTotalQty.TabIndex = 4;
            this.ctlNumTotalQty.TextColor = System.Drawing.SystemColors.WindowText;
            this.ctlNumTotalQty.Value = 0;
            // 
            // lblAcceptValue
            // 
            this.lblAcceptValue.AutoSize = true;
            this.lblAcceptValue.Location = new System.Drawing.Point(11, 127);
            this.lblAcceptValue.Name = "lblAcceptValue";
            this.lblAcceptValue.Size = new System.Drawing.Size(61, 13);
            this.lblAcceptValue.TabIndex = 6;
            this.lblAcceptValue.Text = "Total Value";
            // 
            // lblAcceptQty
            // 
            this.lblAcceptQty.AutoSize = true;
            this.lblAcceptQty.Location = new System.Drawing.Point(11, 98);
            this.lblAcceptQty.Name = "lblAcceptQty";
            this.lblAcceptQty.Size = new System.Drawing.Size(50, 13);
            this.lblAcceptQty.TabIndex = 7;
            this.lblAcceptQty.Text = "Total Qty";
            // 
            // lblLCNo
            // 
            this.lblLCNo.AutoSize = true;
            this.lblLCNo.Location = new System.Drawing.Point(11, 16);
            this.lblLCNo.Name = "lblLCNo";
            this.lblLCNo.Size = new System.Drawing.Size(34, 13);
            this.lblLCNo.TabIndex = 10;
            this.lblLCNo.Text = "LCNo";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(466, 225);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(547, 225);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.dgvLCAcceptance);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Location = new System.Drawing.Point(3, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(638, 253);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Location = new System.Drawing.Point(383, 225);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmLCAcceptance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 409);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLCAcceptance";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LC Acceptance";
            this.Load += new System.EventHandler(this.frmLCAcceptance_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmLCAcceptance_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLCAcceptance_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLCAcceptance)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Accounting.Controls.ctlDaraGridView dgvLCAcceptance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAcceptValue;
        private System.Windows.Forms.Label lblAcceptQty;
        private System.Windows.Forms.Label lblLCNo;
        private Accounting.Controls.ctlNum ctlNumTotalValue;
        private Accounting.Controls.ctlNum ctlNumTotalQty;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLCNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLCID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIssueBank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNegotiateBank;
        private System.Windows.Forms.Button btnLC;
        private System.Windows.Forms.Button btnDelete;
    }
}