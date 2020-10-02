namespace Accounting.UI
{
    partial class frmSearchMultiplePI
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPI = new System.Windows.Forms.TextBox();
            this.CHKPINO = new System.Windows.Forms.CheckBox();
            this.DTPEndDate = new System.Windows.Forms.DateTimePicker();
            this.DTPStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlDGVSearchPI = new Accounting.Controls.ctlDaraGridView();
            this.tick = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVSearchPI)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtPI);
            this.groupBox1.Controls.Add(this.CHKPINO);
            this.groupBox1.Controls.Add(this.DTPEndDate);
            this.groupBox1.Controls.Add(this.DTPStartDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SearchBy";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(324, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = ">>";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPStartDate_KeyDown);
            // 
            // txtPI
            // 
            this.txtPI.Location = new System.Drawing.Point(76, 37);
            this.txtPI.Name = "txtPI";
            this.txtPI.Size = new System.Drawing.Size(235, 20);
            this.txtPI.TabIndex = 4;
            this.txtPI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPStartDate_KeyDown);
            // 
            // CHKPINO
            // 
            this.CHKPINO.AutoSize = true;
            this.CHKPINO.Location = new System.Drawing.Point(11, 38);
            this.CHKPINO.Margin = new System.Windows.Forms.Padding(0);
            this.CHKPINO.Name = "CHKPINO";
            this.CHKPINO.Size = new System.Drawing.Size(53, 17);
            this.CHKPINO.TabIndex = 3;
            this.CHKPINO.Text = "PI No";
            this.CHKPINO.UseVisualStyleBackColor = true;
            this.CHKPINO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPStartDate_KeyDown);
            // 
            // DTPEndDate
            // 
            this.DTPEndDate.CustomFormat = "dd/MM/yyyy";
            this.DTPEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPEndDate.Location = new System.Drawing.Point(235, 12);
            this.DTPEndDate.Name = "DTPEndDate";
            this.DTPEndDate.Size = new System.Drawing.Size(129, 20);
            this.DTPEndDate.TabIndex = 1;
            this.DTPEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPStartDate_KeyDown);
            // 
            // DTPStartDate
            // 
            this.DTPStartDate.CustomFormat = "dd/MM/yyyy";
            this.DTPStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPStartDate.Location = new System.Drawing.Point(76, 12);
            this.DTPStartDate.Name = "DTPStartDate";
            this.DTPStartDate.Size = new System.Drawing.Size(129, 20);
            this.DTPStartDate.TabIndex = 0;
            this.DTPStartDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPStartDate_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "From";
            // 
            // ctlDGVSearchPI
            // 
            this.ctlDGVSearchPI.AllowUserToAddRows = false;
            this.ctlDGVSearchPI.AllowUserToDeleteRows = false;
            this.ctlDGVSearchPI.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctlDGVSearchPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDGVSearchPI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tick});
            this.ctlDGVSearchPI.ContextMenuFields = null;
            this.ctlDGVSearchPI.isEnterKeyLikeTabKey = true;
            this.ctlDGVSearchPI.isExcelSheetCell = false;
            this.ctlDGVSearchPI.IsSortable = false;
            this.ctlDGVSearchPI.Location = new System.Drawing.Point(6, 69);
            this.ctlDGVSearchPI.Name = "ctlDGVSearchPI";
            this.ctlDGVSearchPI.RowHeadersVisible = false;
            this.ctlDGVSearchPI.RowPointer = 0;
            this.ctlDGVSearchPI.ShowDateTimePicker = true;
            this.ctlDGVSearchPI.Size = new System.Drawing.Size(375, 406);
            this.ctlDGVSearchPI.TabIndex = 1;
            // 
            // tick
            // 
            this.tick.FalseValue = "0";
            this.tick.FillWeight = 30F;
            this.tick.HeaderText = "";
            this.tick.Name = "tick";
            this.tick.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tick.TrueValue = "1";
            this.tick.Width = 30;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(100, 478);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(184, 477);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSearchMultiplePI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 506);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ctlDGVSearchPI);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchMultiplePI";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search  Proforma Invoice";
            this.Load += new System.EventHandler(this.frmSearchMultiplePI_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSearchMultiplePI_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVSearchPI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CHKPINO;
        private System.Windows.Forms.DateTimePicker DTPEndDate;
        private System.Windows.Forms.DateTimePicker DTPStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtPI;
        private Accounting.Controls.ctlDaraGridView ctlDGVSearchPI;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tick;
    }
}