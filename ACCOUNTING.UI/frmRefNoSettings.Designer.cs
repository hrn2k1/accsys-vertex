namespace Accounting.UI
{
    partial class frmRefNoSettings
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
            this.ctlDaraGridView1 = new Accounting.Controls.ctlDaraGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDaraGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlDaraGridView1
            // 
            this.ctlDaraGridView1.AllowUserToDeleteRows = false;
            this.ctlDaraGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ctlDaraGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlDaraGridView1.ContextMenuFields = null;
            this.ctlDaraGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ctlDaraGridView1.IsSortable = false;
            this.ctlDaraGridView1.Location = new System.Drawing.Point(11, 12);
            this.ctlDaraGridView1.MultiSelect = false;
            this.ctlDaraGridView1.Name = "ctlDaraGridView1";
            this.ctlDaraGridView1.RowHeadersWidth = 25;
            this.ctlDaraGridView1.RowPointer = 0;
            this.ctlDaraGridView1.ShowDateTimePicker = false;
            this.ctlDaraGridView1.Size = new System.Drawing.Size(385, 421);
            this.ctlDaraGridView1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(170, 434);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(251, 434);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(89, 434);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmRefNoSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 458);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctlDaraGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRefNoSettings";
            this.Text = "Reffence No. Settings";
            this.Load += new System.EventHandler(this.frmRefNoSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctlDaraGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Accounting.Controls.ctlDaraGridView ctlDaraGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
    }
}