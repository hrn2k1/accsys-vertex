namespace Accounting.UI
{
    partial class frmCountry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCountry = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCountry = new Accounting.Controls.ctlDaraGridView();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblCountryTotal = new System.Windows.Forms.Label();
            this.btnEditCountry = new System.Windows.Forms.Button();
            this.btnDeleteCountry = new System.Windows.Forms.Button();
            this.btnCloseCountry = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCountryID = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.btnSaveCountry = new System.Windows.Forms.Button();
            this.tpCurrency = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvCurrency = new Accounting.Controls.ctlDaraGridView();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblCurrencyRecords = new System.Windows.Forms.Label();
            this.btnEditCurrency = new System.Windows.Forms.Button();
            this.btnDeleteCurrency = new System.Windows.Forms.Button();
            this.btnCloseCurrency = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrencySymbol = new System.Windows.Forms.TextBox();
            this.btnSaveCurrency = new System.Windows.Forms.Button();
            this.txtCurrencyCode = new System.Windows.Forms.TextBox();
            this.txtCurrencyID = new System.Windows.Forms.TextBox();
            this.txtCurrencyName = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tpCountry.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountry)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tpCurrency.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrency)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpCountry);
            this.tabControl1.Controls.Add(this.tpCurrency);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(361, 499);
            this.tabControl1.TabIndex = 0;
            // 
            // tpCountry
            // 
            this.tpCountry.Controls.Add(this.groupBox3);
            this.tpCountry.Controls.Add(this.groupBox1);
            this.tpCountry.Location = new System.Drawing.Point(4, 22);
            this.tpCountry.Name = "tpCountry";
            this.tpCountry.Padding = new System.Windows.Forms.Padding(3);
            this.tpCountry.Size = new System.Drawing.Size(353, 473);
            this.tpCountry.TabIndex = 0;
            this.tpCountry.Text = "Country";
            this.tpCountry.UseVisualStyleBackColor = true;
            this.tpCountry.Paint += new System.Windows.Forms.PaintEventHandler(this.tp_Paint);
            this.tpCountry.Enter += new System.EventHandler(this.tpCountry_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dgvCountry);
            this.groupBox3.Controls.Add(this.lblCountry);
            this.groupBox3.Controls.Add(this.lblCountryTotal);
            this.groupBox3.Controls.Add(this.btnEditCountry);
            this.groupBox3.Controls.Add(this.btnDeleteCountry);
            this.groupBox3.Controls.Add(this.btnCloseCountry);
            this.groupBox3.Location = new System.Drawing.Point(3, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(342, 405);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // dgvCountry
            // 
            this.dgvCountry.AllowUserToAddRows = false;
            this.dgvCountry.AllowUserToDeleteRows = false;
            this.dgvCountry.AllowUserToResizeColumns = false;
            this.dgvCountry.AllowUserToResizeRows = false;
            this.dgvCountry.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvCountry.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCountry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCountry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCountry.ContextMenuFields = null;
            this.dgvCountry.IsSortable = false;
            this.dgvCountry.Location = new System.Drawing.Point(5, 17);
            this.dgvCountry.MultiSelect = false;
            this.dgvCountry.Name = "dgvCountry";
            this.dgvCountry.ReadOnly = true;
            this.dgvCountry.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCountry.RowHeadersVisible = false;
            this.dgvCountry.RowHeadersWidth = 25;
            this.dgvCountry.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCountry.RowPointer = 0;
            this.dgvCountry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCountry.ShowDateTimePicker = true;
            this.dgvCountry.Size = new System.Drawing.Size(331, 353);
            this.dgvCountry.TabIndex = 4;
            this.dgvCountry.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCountry_CellDoubleClick);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(65, 376);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(13, 13);
            this.lblCountry.TabIndex = 3;
            this.lblCountry.Text = "0";
            // 
            // lblCountryTotal
            // 
            this.lblCountryTotal.AutoSize = true;
            this.lblCountryTotal.Location = new System.Drawing.Point(6, 376);
            this.lblCountryTotal.Name = "lblCountryTotal";
            this.lblCountryTotal.Size = new System.Drawing.Size(53, 13);
            this.lblCountryTotal.TabIndex = 3;
            this.lblCountryTotal.Text = "Records :";
            // 
            // btnEditCountry
            // 
            this.btnEditCountry.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditCountry.Location = new System.Drawing.Point(133, 376);
            this.btnEditCountry.Name = "btnEditCountry";
            this.btnEditCountry.Size = new System.Drawing.Size(50, 23);
            this.btnEditCountry.TabIndex = 2;
            this.btnEditCountry.Text = "Edit";
            this.btnEditCountry.UseVisualStyleBackColor = false;
            this.btnEditCountry.Click += new System.EventHandler(this.btnEditCountry_Click);
            // 
            // btnDeleteCountry
            // 
            this.btnDeleteCountry.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteCountry.Location = new System.Drawing.Point(189, 376);
            this.btnDeleteCountry.Name = "btnDeleteCountry";
            this.btnDeleteCountry.Size = new System.Drawing.Size(70, 23);
            this.btnDeleteCountry.TabIndex = 2;
            this.btnDeleteCountry.Text = "Delete";
            this.btnDeleteCountry.UseVisualStyleBackColor = false;
            this.btnDeleteCountry.Click += new System.EventHandler(this.btnDeleteCountry_Click);
            // 
            // btnCloseCountry
            // 
            this.btnCloseCountry.BackColor = System.Drawing.SystemColors.Control;
            this.btnCloseCountry.Location = new System.Drawing.Point(265, 376);
            this.btnCloseCountry.Name = "btnCloseCountry";
            this.btnCloseCountry.Size = new System.Drawing.Size(60, 23);
            this.btnCloseCountry.TabIndex = 2;
            this.btnCloseCountry.Text = "Close";
            this.btnCloseCountry.UseVisualStyleBackColor = false;
            this.btnCloseCountry.Click += new System.EventHandler(this.btnCloseCountry_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtCountryID);
            this.groupBox1.Controls.Add(this.txtCountry);
            this.groupBox1.Controls.Add(this.btnSaveCountry);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Country";
            // 
            // txtCountryID
            // 
            this.txtCountryID.Location = new System.Drawing.Point(284, 30);
            this.txtCountryID.Name = "txtCountryID";
            this.txtCountryID.Size = new System.Drawing.Size(24, 20);
            this.txtCountryID.TabIndex = 1;
            this.txtCountryID.Text = "0";
            this.txtCountryID.Visible = false;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(6, 19);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(249, 20);
            this.txtCountry.TabIndex = 1;
            // 
            // btnSaveCountry
            // 
            this.btnSaveCountry.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveCountry.Location = new System.Drawing.Point(261, 16);
            this.btnSaveCountry.Name = "btnSaveCountry";
            this.btnSaveCountry.Size = new System.Drawing.Size(60, 23);
            this.btnSaveCountry.TabIndex = 0;
            this.btnSaveCountry.Text = "Save";
            this.btnSaveCountry.UseVisualStyleBackColor = false;
            this.btnSaveCountry.Click += new System.EventHandler(this.btnSaveCountry_Click);
            // 
            // tpCurrency
            // 
            this.tpCurrency.Controls.Add(this.groupBox4);
            this.tpCurrency.Controls.Add(this.groupBox2);
            this.tpCurrency.Location = new System.Drawing.Point(4, 22);
            this.tpCurrency.Name = "tpCurrency";
            this.tpCurrency.Padding = new System.Windows.Forms.Padding(3);
            this.tpCurrency.Size = new System.Drawing.Size(353, 473);
            this.tpCurrency.TabIndex = 1;
            this.tpCurrency.Text = "Currency";
            this.tpCurrency.UseVisualStyleBackColor = true;
            this.tpCurrency.Paint += new System.Windows.Forms.PaintEventHandler(this.tp_Paint);
            this.tpCurrency.Enter += new System.EventHandler(this.tpCurrency_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.dgvCurrency);
            this.groupBox4.Controls.Add(this.lblCurrency);
            this.groupBox4.Controls.Add(this.lblCurrencyRecords);
            this.groupBox4.Controls.Add(this.btnEditCurrency);
            this.groupBox4.Controls.Add(this.btnDeleteCurrency);
            this.groupBox4.Controls.Add(this.btnCloseCurrency);
            this.groupBox4.Location = new System.Drawing.Point(6, 112);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(339, 353);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // dgvCurrency
            // 
            this.dgvCurrency.AllowUserToAddRows = false;
            this.dgvCurrency.AllowUserToDeleteRows = false;
            this.dgvCurrency.AllowUserToResizeColumns = false;
            this.dgvCurrency.AllowUserToResizeRows = false;
            this.dgvCurrency.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCurrency.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCurrency.ContextMenuFields = null;
            this.dgvCurrency.IsSortable = false;
            this.dgvCurrency.Location = new System.Drawing.Point(4, 9);
            this.dgvCurrency.MultiSelect = false;
            this.dgvCurrency.Name = "dgvCurrency";
            this.dgvCurrency.ReadOnly = true;
            this.dgvCurrency.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCurrency.RowHeadersWidth = 20;
            this.dgvCurrency.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCurrency.RowPointer = 0;
            this.dgvCurrency.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrency.ShowDateTimePicker = true;
            this.dgvCurrency.Size = new System.Drawing.Size(329, 309);
            this.dgvCurrency.TabIndex = 0;
            this.dgvCurrency.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCurrency_CellDoubleClick);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(65, 329);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(13, 13);
            this.lblCurrency.TabIndex = 4;
            this.lblCurrency.Text = "0";
            // 
            // lblCurrencyRecords
            // 
            this.lblCurrencyRecords.AutoSize = true;
            this.lblCurrencyRecords.Location = new System.Drawing.Point(6, 329);
            this.lblCurrencyRecords.Name = "lblCurrencyRecords";
            this.lblCurrencyRecords.Size = new System.Drawing.Size(53, 13);
            this.lblCurrencyRecords.TabIndex = 5;
            this.lblCurrencyRecords.Text = "Records :";
            // 
            // btnEditCurrency
            // 
            this.btnEditCurrency.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditCurrency.Location = new System.Drawing.Point(132, 324);
            this.btnEditCurrency.Name = "btnEditCurrency";
            this.btnEditCurrency.Size = new System.Drawing.Size(59, 23);
            this.btnEditCurrency.TabIndex = 1;
            this.btnEditCurrency.Text = "Edit";
            this.btnEditCurrency.UseVisualStyleBackColor = false;
            this.btnEditCurrency.Click += new System.EventHandler(this.btnEditCurrency_Click);
            // 
            // btnDeleteCurrency
            // 
            this.btnDeleteCurrency.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteCurrency.Location = new System.Drawing.Point(197, 324);
            this.btnDeleteCurrency.Name = "btnDeleteCurrency";
            this.btnDeleteCurrency.Size = new System.Drawing.Size(70, 23);
            this.btnDeleteCurrency.TabIndex = 2;
            this.btnDeleteCurrency.Text = "Delete";
            this.btnDeleteCurrency.UseVisualStyleBackColor = false;
            this.btnDeleteCurrency.Click += new System.EventHandler(this.btnDeleteCurrency_Click);
            // 
            // btnCloseCurrency
            // 
            this.btnCloseCurrency.BackColor = System.Drawing.SystemColors.Control;
            this.btnCloseCurrency.Location = new System.Drawing.Point(273, 324);
            this.btnCloseCurrency.Name = "btnCloseCurrency";
            this.btnCloseCurrency.Size = new System.Drawing.Size(60, 23);
            this.btnCloseCurrency.TabIndex = 3;
            this.btnCloseCurrency.Text = "Close";
            this.btnCloseCurrency.UseVisualStyleBackColor = false;
            this.btnCloseCurrency.Click += new System.EventHandler(this.btnCloseCurrency_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCurrencySymbol);
            this.groupBox2.Controls.Add(this.btnSaveCurrency);
            this.groupBox2.Controls.Add(this.txtCurrencyCode);
            this.groupBox2.Controls.Add(this.txtCurrencyID);
            this.groupBox2.Controls.Add(this.txtCurrencyName);
            this.groupBox2.Location = new System.Drawing.Point(3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Currency";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Symbol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // txtCurrencySymbol
            // 
            this.txtCurrencySymbol.Location = new System.Drawing.Point(73, 74);
            this.txtCurrencySymbol.Name = "txtCurrencySymbol";
            this.txtCurrencySymbol.Size = new System.Drawing.Size(145, 20);
            this.txtCurrencySymbol.TabIndex = 2;
            // 
            // btnSaveCurrency
            // 
            this.btnSaveCurrency.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveCurrency.Location = new System.Drawing.Point(230, 57);
            this.btnSaveCurrency.Name = "btnSaveCurrency";
            this.btnSaveCurrency.Size = new System.Drawing.Size(62, 23);
            this.btnSaveCurrency.TabIndex = 3;
            this.btnSaveCurrency.Text = "Save";
            this.btnSaveCurrency.UseVisualStyleBackColor = false;
            this.btnSaveCurrency.Click += new System.EventHandler(this.btnSaveCurrency_Click);
            // 
            // txtCurrencyCode
            // 
            this.txtCurrencyCode.Location = new System.Drawing.Point(73, 45);
            this.txtCurrencyCode.Name = "txtCurrencyCode";
            this.txtCurrencyCode.Size = new System.Drawing.Size(146, 20);
            this.txtCurrencyCode.TabIndex = 1;
            // 
            // txtCurrencyID
            // 
            this.txtCurrencyID.Location = new System.Drawing.Point(288, 19);
            this.txtCurrencyID.Name = "txtCurrencyID";
            this.txtCurrencyID.Size = new System.Drawing.Size(16, 20);
            this.txtCurrencyID.TabIndex = 7;
            this.txtCurrencyID.Text = "0";
            this.txtCurrencyID.Visible = false;
            // 
            // txtCurrencyName
            // 
            this.txtCurrencyName.Location = new System.Drawing.Point(73, 19);
            this.txtCurrencyName.Name = "txtCurrencyName";
            this.txtCurrencyName.Size = new System.Drawing.Size(207, 20);
            this.txtCurrencyName.TabIndex = 0;
            // 
            // frmCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 499);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCountry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Country";
            this.Load += new System.EventHandler(this.frmCountry_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmCountry_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCountry_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tpCountry.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountry)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpCurrency.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrency)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCountry;
        private System.Windows.Forms.TabPage tpCurrency;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Button btnSaveCountry;
        private System.Windows.Forms.TextBox txtCountryID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCloseCountry;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCurrencyID;
        private System.Windows.Forms.TextBox txtCurrencyName;
        private System.Windows.Forms.Button btnSaveCurrency;
        private System.Windows.Forms.Button btnEditCountry;
        private System.Windows.Forms.Button btnDeleteCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblCountryTotal;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblCurrencyRecords;
        private System.Windows.Forms.Button btnEditCurrency;
        private System.Windows.Forms.Button btnDeleteCurrency;
        private System.Windows.Forms.Button btnCloseCurrency;
        private Accounting.Controls.ctlDaraGridView dgvCountry;
        private Accounting.Controls.ctlDaraGridView dgvCurrency;
        private System.Windows.Forms.TextBox txtCurrencySymbol;
        private System.Windows.Forms.TextBox txtCurrencyCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}