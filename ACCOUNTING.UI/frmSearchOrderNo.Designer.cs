namespace Accounting.UI
{
    partial class frmSearchOrderNo
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
            this.ChOrder = new System.Windows.Forms.CheckBox();
            this.chDate = new System.Windows.Forms.CheckBox();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.DTPstardate = new System.Windows.Forms.DateTimePicker();
            this.DTPenddate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DGVSearchOrder = new Accounting.Controls.ctlDaraGridView();
            this.tick = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSearchOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.ChOrder);
            this.groupBox1.Controls.Add(this.chDate);
            this.groupBox1.Controls.Add(this.txtOrderNo);
            this.groupBox1.Controls.Add(this.DTPstardate);
            this.groupBox1.Controls.Add(this.DTPenddate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SearchBy";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(365, 35);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(27, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = ">>";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSearch_KeyDown);
            // 
            // ChOrder
            // 
            this.ChOrder.AutoSize = true;
            this.ChOrder.Location = new System.Drawing.Point(6, 40);
            this.ChOrder.Name = "ChOrder";
            this.ChOrder.Size = new System.Drawing.Size(52, 17);
            this.ChOrder.TabIndex = 3;
            this.ChOrder.Text = "Order";
            this.ChOrder.UseVisualStyleBackColor = true;
            // 
            // chDate
            // 
            this.chDate.AutoSize = true;
            this.chDate.Checked = true;
            this.chDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chDate.Location = new System.Drawing.Point(6, 17);
            this.chDate.Name = "chDate";
            this.chDate.Size = new System.Drawing.Size(49, 17);
            this.chDate.TabIndex = 3;
            this.chDate.Text = "Date";
            this.chDate.UseVisualStyleBackColor = true;
            this.chDate.Visible = false;
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Location = new System.Drawing.Point(115, 37);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(233, 20);
            this.txtOrderNo.TabIndex = 2;
            this.txtOrderNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderNo_KeyDown);
            // 
            // DTPstardate
            // 
            this.DTPstardate.CustomFormat = "dd/MM/yyyy";
            this.DTPstardate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPstardate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPstardate.Location = new System.Drawing.Point(96, 12);
            this.DTPstardate.Margin = new System.Windows.Forms.Padding(0);
            this.DTPstardate.Name = "DTPstardate";
            this.DTPstardate.Size = new System.Drawing.Size(125, 22);
            this.DTPstardate.TabIndex = 0;
            this.DTPstardate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPstardate_KeyDown);
            // 
            // DTPenddate
            // 
            this.DTPenddate.CustomFormat = "dd/MM/yyyy";
            this.DTPenddate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPenddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPenddate.Location = new System.Drawing.Point(260, 12);
            this.DTPenddate.Name = "DTPenddate";
            this.DTPenddate.Size = new System.Drawing.Size(132, 22);
            this.DTPenddate.TabIndex = 1;
            this.DTPenddate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPenddate_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 100;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Order No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "To";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(124, 481);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 21);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnOK_KeyDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(208, 481);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 21);
            this.button2.TabIndex = 5;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button2_KeyDown);
            // 
            // DGVSearchOrder
            // 
            this.DGVSearchOrder.AllowUserToAddRows = false;
            this.DGVSearchOrder.AllowUserToDeleteRows = false;
            this.DGVSearchOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVSearchOrder.BackgroundColor = System.Drawing.Color.DimGray;
            this.DGVSearchOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSearchOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tick});
            this.DGVSearchOrder.ContextMenuFields = null;
            this.DGVSearchOrder.isEnterKeyLikeTabKey = true;
            this.DGVSearchOrder.isExcelSheetCell = false;
            this.DGVSearchOrder.IsSortable = false;
            this.DGVSearchOrder.Location = new System.Drawing.Point(5, 70);
            this.DGVSearchOrder.Name = "DGVSearchOrder";
            this.DGVSearchOrder.RowHeadersVisible = false;
            this.DGVSearchOrder.RowPointer = 0;
            this.DGVSearchOrder.ShowDateTimePicker = true;
            this.DGVSearchOrder.Size = new System.Drawing.Size(400, 408);
            this.DGVSearchOrder.TabIndex = 3;
            this.DGVSearchOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGVSearchOrder_KeyDown);
            // 
            // tick
            // 
            this.tick.FalseValue = "0";
            this.tick.Frozen = true;
            this.tick.HeaderText = "";
            this.tick.Name = "tick";
            this.tick.TrueValue = "1";
            this.tick.Width = 5;
            // 
            // frmSearchOrderNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 506);
            this.Controls.Add(this.DGVSearchOrder);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSearchOrderNo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Order Refferance No";
            this.Load += new System.EventHandler(this.frmSearchOrderNo_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSearchOrderNo_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSearchOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.DateTimePicker DTPstardate;
        private System.Windows.Forms.DateTimePicker DTPenddate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox ChOrder;
        private System.Windows.Forms.CheckBox chDate;
        private Accounting.Controls.ctlDaraGridView DGVSearchOrder;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tick;
    }
}