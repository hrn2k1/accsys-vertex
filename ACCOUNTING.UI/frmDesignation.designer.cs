namespace Accounting.UI
{
    partial class frmDesignation
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
            this.gbxDesg = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxPayScale = new System.Windows.Forms.GroupBox();
            this.lblbyGross = new System.Windows.Forms.Label();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblLastAmount = new System.Windows.Forms.Label();
            this.lblInitalAmount = new System.Windows.Forms.Label();
            this.lblLastPay = new System.Windows.Forms.Label();
            this.lblInitialPay = new System.Windows.Forms.Label();
            this.chkIsGross = new System.Windows.Forms.CheckBox();
            this.lblPSTSelected = new System.Windows.Forms.Label();
            this.lblPayScaleType = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.utxtGrade = new Accounting.Controls.ctlNum();
            this.gbxDesg.SuspendLayout();
            this.gbxPayScale.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxDesg
            // 
            this.gbxDesg.Controls.Add(this.txtName);
            this.gbxDesg.Controls.Add(this.lblName);
            this.gbxDesg.Location = new System.Drawing.Point(10, 4);
            this.gbxDesg.Name = "gbxDesg";
            this.gbxDesg.Size = new System.Drawing.Size(298, 53);
            this.gbxDesg.TabIndex = 0;
            this.gbxDesg.TabStop = false;
            this.gbxDesg.Text = "New Designation";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(95, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(188, 20);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(8, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(164, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(87, 199);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 24);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbxPayScale
            // 
            this.gbxPayScale.Controls.Add(this.lblbyGross);
            this.gbxPayScale.Controls.Add(this.lblGrade);
            this.gbxPayScale.Controls.Add(this.utxtGrade);
            this.gbxPayScale.Controls.Add(this.lblLastAmount);
            this.gbxPayScale.Controls.Add(this.lblInitalAmount);
            this.gbxPayScale.Controls.Add(this.lblLastPay);
            this.gbxPayScale.Controls.Add(this.lblInitialPay);
            this.gbxPayScale.Controls.Add(this.chkIsGross);
            this.gbxPayScale.Controls.Add(this.lblPSTSelected);
            this.gbxPayScale.Controls.Add(this.lblPayScaleType);
            this.gbxPayScale.Enabled = false;
            this.gbxPayScale.Location = new System.Drawing.Point(12, 94);
            this.gbxPayScale.Name = "gbxPayScale";
            this.gbxPayScale.Size = new System.Drawing.Size(296, 99);
            this.gbxPayScale.TabIndex = 3;
            this.gbxPayScale.TabStop = false;
            this.gbxPayScale.Text = "PayScale";
            // 
            // lblbyGross
            // 
            this.lblbyGross.AutoSize = true;
            this.lblbyGross.Location = new System.Drawing.Point(6, 74);
            this.lblbyGross.Name = "lblbyGross";
            this.lblbyGross.Size = new System.Drawing.Size(54, 13);
            this.lblbyGross.TabIndex = 20;
            this.lblbyGross.Text = "By Bross?";
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(6, 50);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(36, 13);
            this.lblGrade.TabIndex = 19;
            this.lblGrade.Text = "Grade";
            // 
            // lblLastAmount
            // 
            this.lblLastAmount.AutoSize = true;
            this.lblLastAmount.Location = new System.Drawing.Point(222, 74);
            this.lblLastAmount.Name = "lblLastAmount";
            this.lblLastAmount.Size = new System.Drawing.Size(13, 13);
            this.lblLastAmount.TabIndex = 17;
            this.lblLastAmount.Text = "0";
            // 
            // lblInitalAmount
            // 
            this.lblInitalAmount.AutoSize = true;
            this.lblInitalAmount.Location = new System.Drawing.Point(222, 50);
            this.lblInitalAmount.Name = "lblInitalAmount";
            this.lblInitalAmount.Size = new System.Drawing.Size(13, 13);
            this.lblInitalAmount.TabIndex = 16;
            this.lblInitalAmount.Text = "0";
            // 
            // lblLastPay
            // 
            this.lblLastPay.AutoSize = true;
            this.lblLastPay.Location = new System.Drawing.Point(154, 74);
            this.lblLastPay.Name = "lblLastPay";
            this.lblLastPay.Size = new System.Drawing.Size(59, 13);
            this.lblLastPay.TabIndex = 15;
            this.lblLastPay.Text = "Last  Basic";
            // 
            // lblInitialPay
            // 
            this.lblInitialPay.AutoSize = true;
            this.lblInitialPay.Location = new System.Drawing.Point(154, 50);
            this.lblInitialPay.Name = "lblInitialPay";
            this.lblInitialPay.Size = new System.Drawing.Size(60, 13);
            this.lblInitialPay.TabIndex = 14;
            this.lblInitialPay.Text = "Initial Basic";
            // 
            // chkIsGross
            // 
            this.chkIsGross.AutoSize = true;
            this.chkIsGross.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsGross.Enabled = false;
            this.chkIsGross.Location = new System.Drawing.Point(70, 73);
            this.chkIsGross.Name = "chkIsGross";
            this.chkIsGross.Size = new System.Drawing.Size(15, 14);
            this.chkIsGross.TabIndex = 13;
            this.chkIsGross.UseVisualStyleBackColor = true;
            this.chkIsGross.CheckedChanged += new System.EventHandler(this.chkIsGross_CheckedChanged);
            // 
            // lblPSTSelected
            // 
            this.lblPSTSelected.AutoSize = true;
            this.lblPSTSelected.Location = new System.Drawing.Point(110, 24);
            this.lblPSTSelected.Name = "lblPSTSelected";
            this.lblPSTSelected.Size = new System.Drawing.Size(0, 13);
            this.lblPSTSelected.TabIndex = 1;
            // 
            // lblPayScaleType
            // 
            this.lblPayScaleType.AutoSize = true;
            this.lblPayScaleType.Location = new System.Drawing.Point(6, 24);
            this.lblPayScaleType.Name = "lblPayScaleType";
            this.lblPayScaleType.Size = new System.Drawing.Size(79, 13);
            this.lblPayScaleType.TabIndex = 0;
            this.lblPayScaleType.Text = "PayScale Type";
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(83, 65);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(149, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Select PayScale";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // utxtGrade
            // 
            this.utxtGrade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.utxtGrade.BackColor = System.Drawing.Color.White;
            this.utxtGrade.BackgroudColor = System.Drawing.SystemColors.Window;
            this.utxtGrade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.utxtGrade.Enabled = false;
            this.utxtGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utxtGrade.Location = new System.Drawing.Point(57, 47);
            this.utxtGrade.Name = "utxtGrade";
            this.utxtGrade.ReadOnly = false;
            this.utxtGrade.Size = new System.Drawing.Size(78, 20);
            this.utxtGrade.TabIndex = 18;
            this.utxtGrade.TextColor = System.Drawing.SystemColors.WindowText;
            this.utxtGrade.Value = 0;
            // 
            // frmDesignation
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(323, 235);
            this.ControlBox = false;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.gbxPayScale);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbxDesg);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmDesignation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Designation";
            this.Load += new System.EventHandler(this.frmDesignation_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmDesignation_Paint);
            this.Activated += new System.EventHandler(this.frmDesignation_Activated);
            this.gbxDesg.ResumeLayout(false);
            this.gbxDesg.PerformLayout();
            this.gbxPayScale.ResumeLayout(false);
            this.gbxPayScale.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxDesg;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox gbxPayScale;
        private System.Windows.Forms.Label lblPSTSelected;
        private System.Windows.Forms.Label lblPayScaleType;
        private Accounting.Controls.ctlNum utxtGrade;
        private System.Windows.Forms.Label lblLastAmount;
        private System.Windows.Forms.Label lblInitalAmount;
        private System.Windows.Forms.Label lblLastPay;
        private System.Windows.Forms.Label lblInitialPay;
        private System.Windows.Forms.CheckBox chkIsGross;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblbyGross;
    }
}