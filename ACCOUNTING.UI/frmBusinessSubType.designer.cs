namespace Accounting.UI
{
    partial class frmBusinessSubType
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxCountry = new System.Windows.Forms.GroupBox();
            this.cboBusinessType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrencyName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.gbxCountry.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(295, 107);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(221, 107);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbxCountry
            // 
            this.gbxCountry.Controls.Add(this.cboBusinessType);
            this.gbxCountry.Controls.Add(this.label1);
            this.gbxCountry.Controls.Add(this.lblCurrencyName);
            this.gbxCountry.Controls.Add(this.txtName);
            this.gbxCountry.Location = new System.Drawing.Point(12, 12);
            this.gbxCountry.Name = "gbxCountry";
            this.gbxCountry.Size = new System.Drawing.Size(347, 89);
            this.gbxCountry.TabIndex = 0;
            this.gbxCountry.TabStop = false;
            this.gbxCountry.Text = "BusinessSubType";
            // 
            // cboBusinessType
            // 
            this.cboBusinessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusinessType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboBusinessType.FormattingEnabled = true;
            this.cboBusinessType.Location = new System.Drawing.Point(105, 19);
            this.cboBusinessType.Name = "cboBusinessType";
            this.cboBusinessType.Size = new System.Drawing.Size(232, 21);
            this.cboBusinessType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "BusinessType";
            // 
            // lblCurrencyName
            // 
            this.lblCurrencyName.ForeColor = System.Drawing.Color.Red;
            this.lblCurrencyName.Location = new System.Drawing.Point(6, 56);
            this.lblCurrencyName.Name = "lblCurrencyName";
            this.lblCurrencyName.Size = new System.Drawing.Size(93, 20);
            this.lblCurrencyName.TabIndex = 2;
            this.lblCurrencyName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(105, 56);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(236, 20);
            this.txtName.TabIndex = 3;
            // 
            // frmBusinessSubType
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(376, 145);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbxCountry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBusinessSubType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Business SubType";
            this.Load += new System.EventHandler(this.frmBusinessSubType_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmBusinessSubType_Paint);
            this.gbxCountry.ResumeLayout(false);
            this.gbxCountry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbxCountry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrencyName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboBusinessType;
    }
}