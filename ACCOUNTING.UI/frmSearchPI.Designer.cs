namespace Accounting.UI
{
    partial class frmSearchPI
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
            this.btnSearchPI = new System.Windows.Forms.Button();
            this.txtPI = new System.Windows.Forms.TextBox();
            this.CHKPINO = new System.Windows.Forms.CheckBox();
            this.DTPEndDate = new System.Windows.Forms.DateTimePicker();
            this.DTPStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlDGVSearchPI = new Accounting.Controls.ctlDaraGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVSearchPI)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSearchPI);
            this.groupBox1.Controls.Add(this.txtPI);
            this.groupBox1.Controls.Add(this.CHKPINO);
            this.groupBox1.Controls.Add(this.DTPEndDate);
            this.groupBox1.Controls.Add(this.DTPStartDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SearchBy";
            // 
            // btnSearchPI
            // 
            this.btnSearchPI.Location = new System.Drawing.Point(373, 36);
            this.btnSearchPI.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearchPI.Name = "btnSearchPI";
            this.btnSearchPI.Size = new System.Drawing.Size(36, 23);
            this.btnSearchPI.TabIndex = 3;
            this.btnSearchPI.Text = ">>";
            this.btnSearchPI.UseVisualStyleBackColor = true;
            this.btnSearchPI.Click += new System.EventHandler(this.btnSearchPI_Click);
            this.btnSearchPI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSearchPI_KeyDown);
            // 
            // txtPI
            // 
            this.txtPI.Location = new System.Drawing.Point(60, 37);
            this.txtPI.Name = "txtPI";
            this.txtPI.Size = new System.Drawing.Size(301, 20);
            this.txtPI.TabIndex = 2;
            this.txtPI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPI_KeyDown);
            // 
            // CHKPINO
            // 
            this.CHKPINO.AutoSize = true;
            this.CHKPINO.Location = new System.Drawing.Point(8, 39);
            this.CHKPINO.Name = "CHKPINO";
            this.CHKPINO.Size = new System.Drawing.Size(56, 17);
            this.CHKPINO.TabIndex = 98;
            this.CHKPINO.Text = "PI No.";
            this.CHKPINO.UseVisualStyleBackColor = true;
            this.CHKPINO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CHKPINO_KeyDown);
            // 
            // DTPEndDate
            // 
            this.DTPEndDate.CustomFormat = "dd/MM/yyyy";
            this.DTPEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPEndDate.Location = new System.Drawing.Point(231, 13);
            this.DTPEndDate.Name = "DTPEndDate";
            this.DTPEndDate.Size = new System.Drawing.Size(130, 20);
            this.DTPEndDate.TabIndex = 1;
            this.DTPEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPEndDate_KeyDown);
            // 
            // DTPStartDate
            // 
            this.DTPStartDate.CustomFormat = "dd/MM/yyyy";
            this.DTPStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPStartDate.Location = new System.Drawing.Point(60, 13);
            this.DTPStartDate.Name = "DTPStartDate";
            this.DTPStartDate.Size = new System.Drawing.Size(125, 20);
            this.DTPStartDate.TabIndex = 0;
            this.DTPStartDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPStartDate_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 100;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "From";
            // 
            // ctlDGVSearchPI
            // 
            this.ctlDGVSearchPI.AllowUserToAddRows = false;
            this.ctlDGVSearchPI.AllowUserToDeleteRows = false;
            this.ctlDGVSearchPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDGVSearchPI.ContextMenuFields = null;
            this.ctlDGVSearchPI.isEnterKeyLikeTabKey = true;
            this.ctlDGVSearchPI.isExcelSheetCell = false;
            this.ctlDGVSearchPI.IsSortable = false;
            this.ctlDGVSearchPI.Location = new System.Drawing.Point(3, 71);
            this.ctlDGVSearchPI.Name = "ctlDGVSearchPI";
            this.ctlDGVSearchPI.ReadOnly = true;
            this.ctlDGVSearchPI.RowHeadersVisible = false;
            this.ctlDGVSearchPI.RowPointer = 0;
            this.ctlDGVSearchPI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctlDGVSearchPI.ShowDateTimePicker = true;
            this.ctlDGVSearchPI.Size = new System.Drawing.Size(415, 413);
            this.ctlDGVSearchPI.TabIndex = 4;
            this.ctlDGVSearchPI.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlDGVSearchPI_CellDoubleClick);
            this.ctlDGVSearchPI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnOK_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(113, 487);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnOK_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 487);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyDown);
            // 
            // frmSearchPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 518);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ctlDGVSearchPI);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchPI";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Proforma Invoice";
            this.Load += new System.EventHandler(this.frmSearchPI_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSearchPI_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVSearchPI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchPI;
        private System.Windows.Forms.TextBox txtPI;
        private System.Windows.Forms.CheckBox CHKPINO;
        private System.Windows.Forms.DateTimePicker DTPEndDate;
        private System.Windows.Forms.DateTimePicker DTPStartDate;
        private Accounting.Controls.ctlDaraGridView ctlDGVSearchPI;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}