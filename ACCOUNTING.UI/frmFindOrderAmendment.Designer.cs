namespace Accounting.UI
{
    partial class frmFindOrderAmendment
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
            this.dgvFindAmend = new Accounting.Controls.ctlDaraGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindAmend)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFindAmend
            // 
            this.dgvFindAmend.AllowUserToAddRows = false;
            this.dgvFindAmend.AllowUserToDeleteRows = false;
            this.dgvFindAmend.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFindAmend.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvFindAmend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFindAmend.ContextMenuFields = null;
            this.dgvFindAmend.IsSortable = false;
            this.dgvFindAmend.Location = new System.Drawing.Point(3, 3);
            this.dgvFindAmend.MultiSelect = false;
            this.dgvFindAmend.Name = "dgvFindAmend";
            this.dgvFindAmend.ReadOnly = true;
            this.dgvFindAmend.RowHeadersVisible = false;
            this.dgvFindAmend.RowPointer = 0;
            this.dgvFindAmend.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFindAmend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFindAmend.ShowDateTimePicker = true;
            this.dgvFindAmend.Size = new System.Drawing.Size(256, 299);
            this.dgvFindAmend.TabIndex = 0;
            this.dgvFindAmend.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFindAmend_CellDoubleClick);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(139, 308);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(57, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(202, 308);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmFindOrderAmendment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 332);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvFindAmend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindOrderAmendment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order Amendment";
            this.Load += new System.EventHandler(this.frmFindOrderAmendment_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmFindOrderAmendment_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFindOrderAmendment_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindAmend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Accounting.Controls.ctlDaraGridView dgvFindAmend;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}