namespace Accounting.UI
{
    partial class frmSearchLC
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DTPStartDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtLCNo = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.DTPEndDate = new System.Windows.Forms.DateTimePicker();
            this.ctlDGVLC = new Accounting.Controls.ctlDaraGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVLC)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "From";
            // 
            // DTPStartDate
            // 
            this.DTPStartDate.CustomFormat = "dd/MM/yyyy";
            this.DTPStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPStartDate.Location = new System.Drawing.Point(63, 12);
            this.DTPStartDate.Name = "DTPStartDate";
            this.DTPStartDate.Size = new System.Drawing.Size(125, 20);
            this.DTPStartDate.TabIndex = 0;
            this.DTPStartDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPStartDate_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtLCNo);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DTPEndDate);
            this.groupBox1.Controls.Add(this.DTPStartDate);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(341, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(38, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = ">>";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSearch_KeyDown);
            // 
            // txtLCNo
            // 
            this.txtLCNo.Location = new System.Drawing.Point(63, 39);
            this.txtLCNo.Name = "txtLCNo";
            this.txtLCNo.Size = new System.Drawing.Size(272, 20);
            this.txtLCNo.TabIndex = 2;
            this.txtLCNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLCNo_KeyDown);
            this.txtLCNo.Leave += new System.EventHandler(this.txtLCNo_Leave);
            this.txtLCNo.Enter += new System.EventHandler(this.txtLCNo_Enter);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "LC No.";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkBox1_KeyDown);
            // 
            // DTPEndDate
            // 
            this.DTPEndDate.CustomFormat = "dd/MM/yyyy";
            this.DTPEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPEndDate.Location = new System.Drawing.Point(252, 13);
            this.DTPEndDate.Name = "DTPEndDate";
            this.DTPEndDate.Size = new System.Drawing.Size(125, 20);
            this.DTPEndDate.TabIndex = 1;
            this.DTPEndDate.ValueChanged += new System.EventHandler(this.DTPEndDate_ValueChanged);
            this.DTPEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPEndDate_KeyDown);
            // 
            // ctlDGVLC
            // 
            this.ctlDGVLC.AllowUserToAddRows = false;
            this.ctlDGVLC.AllowUserToDeleteRows = false;
            this.ctlDGVLC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ctlDGVLC.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctlDGVLC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDGVLC.ContextMenuFields = null;
            this.ctlDGVLC.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ctlDGVLC.isEnterKeyLikeTabKey = true;
            this.ctlDGVLC.isExcelSheetCell = false;
            this.ctlDGVLC.IsSortable = false;
            this.ctlDGVLC.Location = new System.Drawing.Point(3, 78);
            this.ctlDGVLC.MultiSelect = false;
            this.ctlDGVLC.Name = "ctlDGVLC";
            this.ctlDGVLC.ReadOnly = true;
            this.ctlDGVLC.RowHeadersVisible = false;
            this.ctlDGVLC.RowPointer = 0;
            this.ctlDGVLC.RowTemplate.Height = 18;
            this.ctlDGVLC.RowTemplate.ReadOnly = true;
            this.ctlDGVLC.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctlDGVLC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctlDGVLC.ShowDateTimePicker = true;
            this.ctlDGVLC.Size = new System.Drawing.Size(388, 405);
            this.ctlDGVLC.TabIndex = 1;
            this.ctlDGVLC.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlDGVLC_CellDoubleClick);
            this.ctlDGVLC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctlDGVLC_CellContentClick);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.Location = new System.Drawing.Point(106, 489);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnOK_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(194, 489);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyDown);
            // 
            // frmSearchLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(392, 515);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ctlDGVLC);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchLC";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search LC";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSearchLC_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDGVLC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPStartDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLCNo;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker DTPEndDate;
        private System.Windows.Forms.Button btnSearch;
        private Accounting.Controls.ctlDaraGridView ctlDGVLC;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}