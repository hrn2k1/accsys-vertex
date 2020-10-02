namespace Accounting.UI
{
    partial class frmSearch_Purchase_Return
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
            this.txtReturnNo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DTPED = new System.Windows.Forms.DateTimePicker();
            this.DTPST = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ctlDGVPurchaseReturn = new Accounting.Controls.ctlDaraGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVPurchaseReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtReturnNo);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DTPED);
            this.groupBox1.Controls.Add(this.DTPST);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // txtReturnNo
            // 
            this.txtReturnNo.Location = new System.Drawing.Point(77, 38);
            this.txtReturnNo.Name = "txtReturnNo";
            this.txtReturnNo.Size = new System.Drawing.Size(152, 20);
            this.txtReturnNo.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Location = new System.Drawing.Point(239, 36);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Return No";
            // 
            // DTPED
            // 
            this.DTPED.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPED.Location = new System.Drawing.Point(206, 12);
            this.DTPED.Name = "DTPED";
            this.DTPED.Size = new System.Drawing.Size(111, 20);
            this.DTPED.TabIndex = 2;
            // 
            // DTPST
            // 
            this.DTPST.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPST.Location = new System.Drawing.Point(77, 12);
            this.DTPST.Name = "DTPST";
            this.DTPST.Size = new System.Drawing.Size(105, 20);
            this.DTPST.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date From";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnOK);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.ctlDGVPurchaseReturn);
            this.groupBox2.Location = new System.Drawing.Point(3, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 407);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.Location = new System.Drawing.Point(75, 377);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(156, 377);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ctlDGVPurchaseReturn
            // 
            this.ctlDGVPurchaseReturn.AllowUserToAddRows = false;
            this.ctlDGVPurchaseReturn.AllowUserToDeleteRows = false;
            this.ctlDGVPurchaseReturn.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctlDGVPurchaseReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDGVPurchaseReturn.ContextMenuFields = null;
            this.ctlDGVPurchaseReturn.IsSortable = false;
            this.ctlDGVPurchaseReturn.Location = new System.Drawing.Point(1, 11);
            this.ctlDGVPurchaseReturn.MultiSelect = false;
            this.ctlDGVPurchaseReturn.Name = "ctlDGVPurchaseReturn";
            this.ctlDGVPurchaseReturn.ReadOnly = true;
            this.ctlDGVPurchaseReturn.RowHeadersVisible = false;
            this.ctlDGVPurchaseReturn.RowPointer = 0;
            this.ctlDGVPurchaseReturn.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctlDGVPurchaseReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctlDGVPurchaseReturn.ShowDateTimePicker = false;
            this.ctlDGVPurchaseReturn.Size = new System.Drawing.Size(316, 360);
            this.ctlDGVPurchaseReturn.TabIndex = 0;
            this.ctlDGVPurchaseReturn.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlDGVPurchaseReturn_CellDoubleClick);
            // 
            // frmSearch_Purchase_Return
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 488);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearch_Purchase_Return";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Purchase Return";
            this.Load += new System.EventHandler(this.frmSearch_Purchase_Return_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSearch_Purchase_Return_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSearch_Purchase_Return_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVPurchaseReturn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DTPED;
        private System.Windows.Forms.DateTimePicker DTPST;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReturnNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private Accounting.Controls.ctlDaraGridView ctlDGVPurchaseReturn;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnOK;
    }
}