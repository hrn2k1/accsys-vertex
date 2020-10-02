namespace Accounting.UI
{
    partial class frmLCAmendment
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
            this.DTPAmend = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtLCValue = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtLCQTY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlDGVLCAmend = new Accounting.Controls.ctlDaraGridView();
            this.txtPrevLCQty = new System.Windows.Forms.TextBox();
            this.txtPrevLCvalue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbxAmend = new System.Windows.Forms.GroupBox();
            this.ctlDaraGridView1 = new Accounting.Controls.ctlDaraGridView();
            this.llblCancel = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVLCAmend)).BeginInit();
            this.gbxAmend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDaraGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.gbxAmend);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPrevLCvalue);
            this.groupBox1.Controls.Add(this.txtPrevLCQty);
            this.groupBox1.Controls.Add(this.DTPAmend);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.txtLCValue);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.txtLCQTY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ctlDGVLCAmend);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 222);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // DTPAmend
            // 
            this.DTPAmend.CustomFormat = "dd/MM/yyyy";
            this.DTPAmend.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPAmend.Location = new System.Drawing.Point(132, 132);
            this.DTPAmend.Name = "DTPAmend";
            this.DTPAmend.Size = new System.Drawing.Size(95, 20);
            this.DTPAmend.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(378, 189);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.SystemColors.Control;
            this.btnFind.Location = new System.Drawing.Point(300, 189);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(222, 189);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.Location = new System.Drawing.Point(142, 190);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtLCValue
            // 
            this.txtLCValue.Location = new System.Drawing.Point(132, 107);
            this.txtLCValue.Name = "txtLCValue";
            this.txtLCValue.Size = new System.Drawing.Size(95, 20);
            this.txtLCValue.TabIndex = 1;
            this.txtLCValue.Text = "0.0";
            this.txtLCValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(132, 161);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(329, 24);
            this.txtComment.TabIndex = 3;
            // 
            // txtLCQTY
            // 
            this.txtLCQTY.Location = new System.Drawing.Point(132, 82);
            this.txtLCQTY.Name = "txtLCQTY";
            this.txtLCQTY.Size = new System.Drawing.Size(95, 20);
            this.txtLCQTY.TabIndex = 0;
            this.txtLCQTY.Text = "0.0";
            this.txtLCQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Amendment Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Amendment Title";
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Amendment Date";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Amendment QTY";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ctlDGVLCAmend
            // 
            this.ctlDGVLCAmend.AllowUserToAddRows = false;
            this.ctlDGVLCAmend.AllowUserToDeleteRows = false;
            this.ctlDGVLCAmend.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ctlDGVLCAmend.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ctlDGVLCAmend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDGVLCAmend.ContextMenuFields = null;
            this.ctlDGVLCAmend.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ctlDGVLCAmend.IsSortable = false;
            this.ctlDGVLCAmend.Location = new System.Drawing.Point(6, 13);
            this.ctlDGVLCAmend.Name = "ctlDGVLCAmend";
            this.ctlDGVLCAmend.RowHeadersVisible = false;
            this.ctlDGVLCAmend.RowPointer = 0;
            this.ctlDGVLCAmend.ShowDateTimePicker = true;
            this.ctlDGVLCAmend.Size = new System.Drawing.Size(455, 16);
            this.ctlDGVLCAmend.TabIndex = 0;
            this.ctlDGVLCAmend.Visible = false;
            this.ctlDGVLCAmend.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlDGVLCAmend_CellValueChanged);
            this.ctlDGVLCAmend.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ctlDGVLCAmend_EditingControlShowing);
            this.ctlDGVLCAmend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctlDGVLCAmend_KeyDown);
            this.ctlDGVLCAmend.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlDGVLCAmend_CellEnter);
            // 
            // txtPrevLCQty
            // 
            this.txtPrevLCQty.BackColor = System.Drawing.Color.White;
            this.txtPrevLCQty.Location = new System.Drawing.Point(132, 32);
            this.txtPrevLCQty.Name = "txtPrevLCQty";
            this.txtPrevLCQty.ReadOnly = true;
            this.txtPrevLCQty.Size = new System.Drawing.Size(95, 20);
            this.txtPrevLCQty.TabIndex = 8;
            this.txtPrevLCQty.Text = "0.0";
            this.txtPrevLCQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrevLCvalue
            // 
            this.txtPrevLCvalue.BackColor = System.Drawing.Color.White;
            this.txtPrevLCvalue.Location = new System.Drawing.Point(132, 57);
            this.txtPrevLCvalue.Name = "txtPrevLCvalue";
            this.txtPrevLCvalue.ReadOnly = true;
            this.txtPrevLCvalue.Size = new System.Drawing.Size(95, 20);
            this.txtPrevLCvalue.TabIndex = 9;
            this.txtPrevLCvalue.Text = "0.0";
            this.txtPrevLCvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total LC  QTY";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total LC Value";
            // 
            // gbxAmend
            // 
            this.gbxAmend.Controls.Add(this.llblCancel);
            this.gbxAmend.Controls.Add(this.ctlDaraGridView1);
            this.gbxAmend.Location = new System.Drawing.Point(233, 2);
            this.gbxAmend.Name = "gbxAmend";
            this.gbxAmend.Size = new System.Drawing.Size(228, 153);
            this.gbxAmend.TabIndex = 12;
            this.gbxAmend.TabStop = false;
            this.gbxAmend.Text = "Amendments";
            this.gbxAmend.Visible = false;
            this.gbxAmend.VisibleChanged += new System.EventHandler(this.gbxAmend_VisibleChanged);
            // 
            // ctlDaraGridView1
            // 
            this.ctlDaraGridView1.AllowUserToAddRows = false;
            this.ctlDaraGridView1.AllowUserToDeleteRows = false;
            this.ctlDaraGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ctlDaraGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDaraGridView1.ContextMenuFields = null;
            this.ctlDaraGridView1.IsSortable = false;
            this.ctlDaraGridView1.Location = new System.Drawing.Point(6, 11);
            this.ctlDaraGridView1.MultiSelect = false;
            this.ctlDaraGridView1.Name = "ctlDaraGridView1";
            this.ctlDaraGridView1.ReadOnly = true;
            this.ctlDaraGridView1.RowHeadersVisible = false;
            this.ctlDaraGridView1.RowPointer = 0;
            this.ctlDaraGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctlDaraGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctlDaraGridView1.ShowDateTimePicker = false;
            this.ctlDaraGridView1.Size = new System.Drawing.Size(214, 123);
            this.ctlDaraGridView1.TabIndex = 0;
            this.ctlDaraGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlDaraGridView1_CellDoubleClick);
            // 
            // llblCancel
            // 
            this.llblCancel.AutoSize = true;
            this.llblCancel.Location = new System.Drawing.Point(82, 136);
            this.llblCancel.Name = "llblCancel";
            this.llblCancel.Size = new System.Drawing.Size(40, 13);
            this.llblCancel.TabIndex = 1;
            this.llblCancel.TabStop = true;
            this.llblCancel.Text = "Cancel";
            this.llblCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblCancel_LinkClicked);
            // 
            // frmLCAmendment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 228);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLCAmendment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LC Amendment";
            this.Load += new System.EventHandler(this.frmLCAmendment_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmLCAmendment_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVLCAmend)).EndInit();
            this.gbxAmend.ResumeLayout(false);
            this.gbxAmend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDaraGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Accounting.Controls.ctlDaraGridView ctlDGVLCAmend;
        private System.Windows.Forms.TextBox txtLCValue;
        private System.Windows.Forms.TextBox txtLCQTY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DateTimePicker DTPAmend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrevLCvalue;
        private System.Windows.Forms.TextBox txtPrevLCQty;
        private System.Windows.Forms.GroupBox gbxAmend;
        private Accounting.Controls.ctlDaraGridView ctlDaraGridView1;
        private System.Windows.Forms.LinkLabel llblCancel;
    }
}