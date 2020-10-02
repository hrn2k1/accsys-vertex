namespace Accounting.UI
{
    partial class frmCommercialDocuments
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
            this.txtComDocNo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DTPED = new System.Windows.Forms.DateTimePicker();
            this.DTPST = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ctlDGVSearchComDoc = new Accounting.Controls.ctlDaraGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVSearchComDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtComDocNo);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DTPED);
            this.groupBox1.Controls.Add(this.DTPST);
            this.groupBox1.Location = new System.Drawing.Point(6, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // txtComDocNo
            // 
            this.txtComDocNo.Location = new System.Drawing.Point(111, 49);
            this.txtComDocNo.Name = "txtComDocNo";
            this.txtComDocNo.Size = new System.Drawing.Size(179, 20);
            this.txtComDocNo.TabIndex = 2;
            this.txtComDocNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtComDocNo_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Location = new System.Drawing.Point(294, 47);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(61, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ComDocuments No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Date    From";
            // 
            // DTPED
            // 
            this.DTPED.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPED.Location = new System.Drawing.Point(239, 13);
            this.DTPED.Name = "DTPED";
            this.DTPED.Size = new System.Drawing.Size(112, 20);
            this.DTPED.TabIndex = 1;
            // 
            // DTPST
            // 
            this.DTPST.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPST.Location = new System.Drawing.Point(84, 13);
            this.DTPST.Name = "DTPST";
            this.DTPST.Size = new System.Drawing.Size(117, 20);
            this.DTPST.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnOK);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.ctlDGVSearchComDoc);
            this.groupBox2.Location = new System.Drawing.Point(6, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 287);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.Location = new System.Drawing.Point(92, 258);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(170, 258);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ctlDGVSearchComDoc
            // 
            this.ctlDGVSearchComDoc.AllowUserToAddRows = false;
            this.ctlDGVSearchComDoc.AllowUserToDeleteRows = false;
            this.ctlDGVSearchComDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDGVSearchComDoc.ContextMenuFields = null;
            this.ctlDGVSearchComDoc.IsSortable = false;
            this.ctlDGVSearchComDoc.Location = new System.Drawing.Point(6, 13);
            this.ctlDGVSearchComDoc.Margin = new System.Windows.Forms.Padding(0);
            this.ctlDGVSearchComDoc.Name = "ctlDGVSearchComDoc";
            this.ctlDGVSearchComDoc.ReadOnly = true;
            this.ctlDGVSearchComDoc.RowHeadersVisible = false;
            this.ctlDGVSearchComDoc.RowPointer = 0;
            this.ctlDGVSearchComDoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctlDGVSearchComDoc.ShowDateTimePicker = true;
            this.ctlDGVSearchComDoc.Size = new System.Drawing.Size(347, 240);
            this.ctlDGVSearchComDoc.TabIndex = 0;
            this.ctlDGVSearchComDoc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlDGVSearchComDoc_CellDoubleClick);
            // 
            // frmCommercialDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 379);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCommercialDocuments";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Commercial Documents";
            this.Load += new System.EventHandler(this.frmCommercialDocuments_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmCommercialDocuments_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCommercialDocuments_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVSearchComDoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTPST;
        private System.Windows.Forms.TextBox txtComDocNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPED;
        private Accounting.Controls.ctlDaraGridView ctlDGVSearchComDoc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnOK;
    }
}