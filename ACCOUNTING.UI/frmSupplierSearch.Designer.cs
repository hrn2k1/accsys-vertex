namespace Accounting.UI
{
    partial class frmSupplierSearch
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
            this.ctldgvSupplier = new Accounting.Controls.ctlDaraGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvSupplier)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctldgvSupplier
            // 
            this.ctldgvSupplier.AllowUserToAddRows = false;
            this.ctldgvSupplier.AllowUserToDeleteRows = false;
            this.ctldgvSupplier.BackgroundColor = System.Drawing.Color.DimGray;
            this.ctldgvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctldgvSupplier.ContextMenuFields = null;
            this.ctldgvSupplier.IsSortable = false;
            this.ctldgvSupplier.Location = new System.Drawing.Point(4, 41);
            this.ctldgvSupplier.Name = "ctldgvSupplier";
            this.ctldgvSupplier.ReadOnly = true;
            this.ctldgvSupplier.RowHeadersVisible = false;
            this.ctldgvSupplier.RowPointer = 0;
            this.ctldgvSupplier.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctldgvSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctldgvSupplier.ShowDateTimePicker = true;
            this.ctldgvSupplier.Size = new System.Drawing.Size(388, 433);
            this.ctldgvSupplier.TabIndex = 0;
            this.ctldgvSupplier.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ctldgvSupplier_CellDoubleClick);
            this.ctldgvSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctldgvSupplier_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtSupplier);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 37);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(105, 13);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(277, 20);
            this.txtSupplier.TabIndex = 1;
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplier_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier  Name";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(236, 480);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(317, 480);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSupplierSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 506);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctldgvSupplier);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSupplierSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Supplier Searching";
            this.Load += new System.EventHandler(this.frmSupplierSearch_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSupplierSearch_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSupplierSearch_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ctldgvSupplier)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Accounting.Controls.ctlDaraGridView ctldgvSupplier;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}