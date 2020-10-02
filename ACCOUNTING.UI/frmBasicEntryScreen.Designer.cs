namespace Accounting.UI
{
    partial class frmBasicEntryScreen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpColors = new System.Windows.Forms.TabPage();
            this.lblColors = new System.Windows.Forms.Label();
            this.dgvColors = new Accounting.Controls.ctlDaraGridView();
            this.btnColoresClose = new System.Windows.Forms.Button();
            this.btnColoresDelete = new System.Windows.Forms.Button();
            this.btnColoresEdit = new System.Windows.Forms.Button();
            this.lblTotalColors = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtColorsID = new System.Windows.Forms.TextBox();
            this.txtColorsName = new System.Windows.Forms.TextBox();
            this.btnSaveColors = new System.Windows.Forms.Button();
            this.tpCounts = new System.Windows.Forms.TabPage();
            this.lblCounts = new System.Windows.Forms.Label();
            this.dgvCounts = new Accounting.Controls.ctlDaraGridView();
            this.btnCountsClose = new System.Windows.Forms.Button();
            this.btnCountsDelete = new System.Windows.Forms.Button();
            this.btnCountsEdit = new System.Windows.Forms.Button();
            this.lblTotalCounts = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCountsID = new System.Windows.Forms.TextBox();
            this.btnSaveCounts = new System.Windows.Forms.Button();
            this.txtCountsName = new System.Windows.Forms.TextBox();
            this.tpSizes = new System.Windows.Forms.TabPage();
            this.lblSizes = new System.Windows.Forms.Label();
            this.dgvSizes = new Accounting.Controls.ctlDaraGridView();
            this.btnSizesClose = new System.Windows.Forms.Button();
            this.btnSizesdelete = new System.Windows.Forms.Button();
            this.btnSizesEdit = new System.Windows.Forms.Button();
            this.lblTotalSizes = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSizesID = new System.Windows.Forms.TextBox();
            this.btnSaveSizes = new System.Windows.Forms.Button();
            this.txtSizes = new System.Windows.Forms.TextBox();
            this.tpShade = new System.Windows.Forms.TabPage();
            this.lblShade = new System.Windows.Forms.Label();
            this.dgvShade = new Accounting.Controls.ctlDaraGridView();
            this.btnShadeClose = new System.Windows.Forms.Button();
            this.btnShadedelete = new System.Windows.Forms.Button();
            this.btnShadeEdit = new System.Windows.Forms.Button();
            this.lblTotalShade = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtShadeID = new System.Windows.Forms.TextBox();
            this.btnSaveShade = new System.Windows.Forms.Button();
            this.txtShade = new System.Windows.Forms.TextBox();
            this.tpUnits = new System.Windows.Forms.TabPage();
            this.lblUnits = new System.Windows.Forms.Label();
            this.dgvUnits = new Accounting.Controls.ctlDaraGridView();
            this.btnUnitsClose = new System.Windows.Forms.Button();
            this.btnUnitsDelete = new System.Windows.Forms.Button();
            this.btnUnitsEdit = new System.Windows.Forms.Button();
            this.lblTotalUnits = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtUnitsID = new System.Windows.Forms.TextBox();
            this.btnSaveUnits = new System.Windows.Forms.Button();
            this.txtUnits = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tpColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColors)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tpCounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCounts)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tpSizes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSizes)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tpShade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShade)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tpUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpColors);
            this.tabControl1.Controls.Add(this.tpCounts);
            this.tabControl1.Controls.Add(this.tpSizes);
            this.tabControl1.Controls.Add(this.tpShade);
            this.tabControl1.Controls.Add(this.tpUnits);
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(391, 476);
            this.tabControl1.TabIndex = 0;
            // 
            // tpColors
            // 
            this.tpColors.Controls.Add(this.lblColors);
            this.tpColors.Controls.Add(this.dgvColors);
            this.tpColors.Controls.Add(this.btnColoresClose);
            this.tpColors.Controls.Add(this.btnColoresDelete);
            this.tpColors.Controls.Add(this.btnColoresEdit);
            this.tpColors.Controls.Add(this.lblTotalColors);
            this.tpColors.Controls.Add(this.groupBox1);
            this.tpColors.Location = new System.Drawing.Point(4, 22);
            this.tpColors.Name = "tpColors";
            this.tpColors.Size = new System.Drawing.Size(383, 450);
            this.tpColors.TabIndex = 0;
            this.tpColors.Text = "Prd. Type";
            this.tpColors.UseVisualStyleBackColor = true;
            this.tpColors.Paint += new System.Windows.Forms.PaintEventHandler(this.tp_Paint);
            this.tpColors.Enter += new System.EventHandler(this.tpColors_Enter);
            // 
            // lblColors
            // 
            this.lblColors.AutoSize = true;
            this.lblColors.Location = new System.Drawing.Point(92, 412);
            this.lblColors.Name = "lblColors";
            this.lblColors.Size = new System.Drawing.Size(13, 13);
            this.lblColors.TabIndex = 6;
            this.lblColors.Text = "0";
            this.lblColors.Visible = false;
            // 
            // dgvColors
            // 
            this.dgvColors.AllowUserToAddRows = false;
            this.dgvColors.AllowUserToDeleteRows = false;
            this.dgvColors.BackgroundColor = System.Drawing.Color.DimGray;
            this.dgvColors.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvColors.ColumnHeadersVisible = false;
            this.dgvColors.ContextMenuFields = null;
            this.dgvColors.isEnterKeyLikeTabKey = true;
            this.dgvColors.isExcelSheetCell = false;
            this.dgvColors.IsSortable = false;
            this.dgvColors.Location = new System.Drawing.Point(6, 70);
            this.dgvColors.MultiSelect = false;
            this.dgvColors.Name = "dgvColors";
            this.dgvColors.ReadOnly = true;
            this.dgvColors.RowHeadersVisible = false;
            this.dgvColors.RowHeadersWidth = 25;
            this.dgvColors.RowPointer = 0;
            this.dgvColors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColors.ShowDateTimePicker = true;
            this.dgvColors.Size = new System.Drawing.Size(368, 336);
            this.dgvColors.TabIndex = 1;
            this.dgvColors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColors_CellDoubleClick);
            // 
            // btnColoresClose
            // 
            this.btnColoresClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnColoresClose.Location = new System.Drawing.Point(292, 424);
            this.btnColoresClose.Name = "btnColoresClose";
            this.btnColoresClose.Size = new System.Drawing.Size(86, 23);
            this.btnColoresClose.TabIndex = 3;
            this.btnColoresClose.Text = "Close";
            this.btnColoresClose.UseVisualStyleBackColor = false;
            this.btnColoresClose.Click += new System.EventHandler(this.btnColoresClose_Click);
            // 
            // btnColoresDelete
            // 
            this.btnColoresDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnColoresDelete.Location = new System.Drawing.Point(197, 424);
            this.btnColoresDelete.Name = "btnColoresDelete";
            this.btnColoresDelete.Size = new System.Drawing.Size(89, 23);
            this.btnColoresDelete.TabIndex = 2;
            this.btnColoresDelete.Text = "Delete";
            this.btnColoresDelete.UseVisualStyleBackColor = false;
            this.btnColoresDelete.Click += new System.EventHandler(this.btnColoresDelete_Click);
            // 
            // btnColoresEdit
            // 
            this.btnColoresEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnColoresEdit.Location = new System.Drawing.Point(107, 424);
            this.btnColoresEdit.Name = "btnColoresEdit";
            this.btnColoresEdit.Size = new System.Drawing.Size(84, 23);
            this.btnColoresEdit.TabIndex = 4;
            this.btnColoresEdit.Text = "Edit";
            this.btnColoresEdit.UseVisualStyleBackColor = false;
            this.btnColoresEdit.Click += new System.EventHandler(this.btnColoresEdit_Click);
            // 
            // lblTotalColors
            // 
            this.lblTotalColors.AutoSize = true;
            this.lblTotalColors.Location = new System.Drawing.Point(9, 411);
            this.lblTotalColors.Name = "lblTotalColors";
            this.lblTotalColors.Size = new System.Drawing.Size(77, 13);
            this.lblTotalColors.TabIndex = 5;
            this.lblTotalColors.Text = "TotalRecords :";
            this.lblTotalColors.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtColorsID);
            this.groupBox1.Controls.Add(this.txtColorsName);
            this.groupBox1.Controls.Add(this.btnSaveColors);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Type";
            // 
            // txtColorsID
            // 
            this.txtColorsID.Location = new System.Drawing.Point(358, 17);
            this.txtColorsID.Name = "txtColorsID";
            this.txtColorsID.Size = new System.Drawing.Size(10, 20);
            this.txtColorsID.TabIndex = 2;
            this.txtColorsID.Text = "0";
            this.txtColorsID.Visible = false;
            // 
            // txtColorsName
            // 
            this.txtColorsName.Location = new System.Drawing.Point(6, 19);
            this.txtColorsName.Name = "txtColorsName";
            this.txtColorsName.Size = new System.Drawing.Size(291, 20);
            this.txtColorsName.TabIndex = 0;
            this.txtColorsName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtColorsName_KeyDown);
            // 
            // btnSaveColors
            // 
            this.btnSaveColors.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveColors.Location = new System.Drawing.Point(303, 17);
            this.btnSaveColors.Name = "btnSaveColors";
            this.btnSaveColors.Size = new System.Drawing.Size(49, 23);
            this.btnSaveColors.TabIndex = 1;
            this.btnSaveColors.Text = "Save";
            this.btnSaveColors.UseVisualStyleBackColor = false;
            this.btnSaveColors.Click += new System.EventHandler(this.btnSaveColors_Click);
            this.btnSaveColors.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtColorsName_KeyDown);
            // 
            // tpCounts
            // 
            this.tpCounts.Controls.Add(this.lblCounts);
            this.tpCounts.Controls.Add(this.dgvCounts);
            this.tpCounts.Controls.Add(this.btnCountsClose);
            this.tpCounts.Controls.Add(this.btnCountsDelete);
            this.tpCounts.Controls.Add(this.btnCountsEdit);
            this.tpCounts.Controls.Add(this.lblTotalCounts);
            this.tpCounts.Controls.Add(this.groupBox2);
            this.tpCounts.Location = new System.Drawing.Point(4, 22);
            this.tpCounts.Name = "tpCounts";
            this.tpCounts.Size = new System.Drawing.Size(383, 450);
            this.tpCounts.TabIndex = 1;
            this.tpCounts.Text = "Counts";
            this.tpCounts.UseVisualStyleBackColor = true;
            this.tpCounts.Paint += new System.Windows.Forms.PaintEventHandler(this.tp_Paint);
            this.tpCounts.Enter += new System.EventHandler(this.tpCounts_Enter);
            // 
            // lblCounts
            // 
            this.lblCounts.AutoSize = true;
            this.lblCounts.Location = new System.Drawing.Point(94, 407);
            this.lblCounts.Name = "lblCounts";
            this.lblCounts.Size = new System.Drawing.Size(13, 13);
            this.lblCounts.TabIndex = 6;
            this.lblCounts.Text = "0";
            this.lblCounts.Visible = false;
            // 
            // dgvCounts
            // 
            this.dgvCounts.AllowUserToAddRows = false;
            this.dgvCounts.AllowUserToDeleteRows = false;
            this.dgvCounts.AllowUserToResizeColumns = false;
            this.dgvCounts.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCounts.ColumnHeadersVisible = false;
            this.dgvCounts.ContextMenuFields = null;
            this.dgvCounts.isEnterKeyLikeTabKey = true;
            this.dgvCounts.isExcelSheetCell = false;
            this.dgvCounts.IsSortable = false;
            this.dgvCounts.Location = new System.Drawing.Point(14, 72);
            this.dgvCounts.MultiSelect = false;
            this.dgvCounts.Name = "dgvCounts";
            this.dgvCounts.ReadOnly = true;
            this.dgvCounts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCounts.RowHeadersWidth = 25;
            this.dgvCounts.RowPointer = 0;
            this.dgvCounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCounts.ShowDateTimePicker = true;
            this.dgvCounts.Size = new System.Drawing.Size(360, 330);
            this.dgvCounts.TabIndex = 1;
            this.dgvCounts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCounts_CellDoubleClick);
            // 
            // btnCountsClose
            // 
            this.btnCountsClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnCountsClose.Location = new System.Drawing.Point(285, 420);
            this.btnCountsClose.Name = "btnCountsClose";
            this.btnCountsClose.Size = new System.Drawing.Size(89, 23);
            this.btnCountsClose.TabIndex = 2;
            this.btnCountsClose.Text = "Close";
            this.btnCountsClose.UseVisualStyleBackColor = false;
            this.btnCountsClose.Click += new System.EventHandler(this.btnCountsClose_Click);
            // 
            // btnCountsDelete
            // 
            this.btnCountsDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnCountsDelete.Location = new System.Drawing.Point(190, 420);
            this.btnCountsDelete.Name = "btnCountsDelete";
            this.btnCountsDelete.Size = new System.Drawing.Size(92, 23);
            this.btnCountsDelete.TabIndex = 3;
            this.btnCountsDelete.Text = "Delete";
            this.btnCountsDelete.UseVisualStyleBackColor = false;
            this.btnCountsDelete.Click += new System.EventHandler(this.btnCountsDelete_Click);
            // 
            // btnCountsEdit
            // 
            this.btnCountsEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnCountsEdit.Location = new System.Drawing.Point(100, 420);
            this.btnCountsEdit.Name = "btnCountsEdit";
            this.btnCountsEdit.Size = new System.Drawing.Size(87, 23);
            this.btnCountsEdit.TabIndex = 4;
            this.btnCountsEdit.Text = "Edit";
            this.btnCountsEdit.UseVisualStyleBackColor = false;
            this.btnCountsEdit.Click += new System.EventHandler(this.btnCountsEdit_Click);
            // 
            // lblTotalCounts
            // 
            this.lblTotalCounts.AutoSize = true;
            this.lblTotalCounts.Location = new System.Drawing.Point(11, 404);
            this.lblTotalCounts.Name = "lblTotalCounts";
            this.lblTotalCounts.Size = new System.Drawing.Size(77, 13);
            this.lblTotalCounts.TabIndex = 5;
            this.lblTotalCounts.Text = "TotalRecords :";
            this.lblTotalCounts.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtCountsID);
            this.groupBox2.Controls.Add(this.btnSaveCounts);
            this.groupBox2.Controls.Add(this.txtCountsName);
            this.groupBox2.Location = new System.Drawing.Point(14, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 52);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Count\'s Name";
            // 
            // txtCountsID
            // 
            this.txtCountsID.Location = new System.Drawing.Point(346, 19);
            this.txtCountsID.Name = "txtCountsID";
            this.txtCountsID.Size = new System.Drawing.Size(10, 20);
            this.txtCountsID.TabIndex = 2;
            this.txtCountsID.Text = "0";
            this.txtCountsID.Visible = false;
            // 
            // btnSaveCounts
            // 
            this.btnSaveCounts.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveCounts.Location = new System.Drawing.Point(291, 20);
            this.btnSaveCounts.Name = "btnSaveCounts";
            this.btnSaveCounts.Size = new System.Drawing.Size(49, 23);
            this.btnSaveCounts.TabIndex = 1;
            this.btnSaveCounts.Text = "Save";
            this.btnSaveCounts.UseVisualStyleBackColor = false;
            this.btnSaveCounts.Click += new System.EventHandler(this.btnSaveCounts_Click);
            // 
            // txtCountsName
            // 
            this.txtCountsName.Location = new System.Drawing.Point(6, 22);
            this.txtCountsName.Name = "txtCountsName";
            this.txtCountsName.Size = new System.Drawing.Size(279, 20);
            this.txtCountsName.TabIndex = 0;
            // 
            // tpSizes
            // 
            this.tpSizes.Controls.Add(this.lblSizes);
            this.tpSizes.Controls.Add(this.dgvSizes);
            this.tpSizes.Controls.Add(this.btnSizesClose);
            this.tpSizes.Controls.Add(this.btnSizesdelete);
            this.tpSizes.Controls.Add(this.btnSizesEdit);
            this.tpSizes.Controls.Add(this.lblTotalSizes);
            this.tpSizes.Controls.Add(this.groupBox3);
            this.tpSizes.Location = new System.Drawing.Point(4, 22);
            this.tpSizes.Name = "tpSizes";
            this.tpSizes.Size = new System.Drawing.Size(383, 450);
            this.tpSizes.TabIndex = 2;
            this.tpSizes.Text = "Sizes";
            this.tpSizes.UseVisualStyleBackColor = true;
            this.tpSizes.Paint += new System.Windows.Forms.PaintEventHandler(this.tp_Paint);
            this.tpSizes.Enter += new System.EventHandler(this.tpSizes_Enter);
            // 
            // lblSizes
            // 
            this.lblSizes.AutoSize = true;
            this.lblSizes.Location = new System.Drawing.Point(93, 405);
            this.lblSizes.Name = "lblSizes";
            this.lblSizes.Size = new System.Drawing.Size(13, 13);
            this.lblSizes.TabIndex = 6;
            this.lblSizes.Text = "0";
            this.lblSizes.Visible = false;
            // 
            // dgvSizes
            // 
            this.dgvSizes.AllowUserToAddRows = false;
            this.dgvSizes.AllowUserToDeleteRows = false;
            this.dgvSizes.AllowUserToResizeColumns = false;
            this.dgvSizes.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSizes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSizes.ColumnHeadersVisible = false;
            this.dgvSizes.ContextMenuFields = null;
            this.dgvSizes.isEnterKeyLikeTabKey = true;
            this.dgvSizes.isExcelSheetCell = false;
            this.dgvSizes.IsSortable = false;
            this.dgvSizes.Location = new System.Drawing.Point(12, 78);
            this.dgvSizes.MultiSelect = false;
            this.dgvSizes.Name = "dgvSizes";
            this.dgvSizes.ReadOnly = true;
            this.dgvSizes.RowHeadersWidth = 25;
            this.dgvSizes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSizes.RowPointer = 0;
            this.dgvSizes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSizes.ShowDateTimePicker = true;
            this.dgvSizes.Size = new System.Drawing.Size(362, 324);
            this.dgvSizes.TabIndex = 1;
            this.dgvSizes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSizes_CellDoubleClick);
            // 
            // btnSizesClose
            // 
            this.btnSizesClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnSizesClose.Location = new System.Drawing.Point(292, 421);
            this.btnSizesClose.Name = "btnSizesClose";
            this.btnSizesClose.Size = new System.Drawing.Size(86, 23);
            this.btnSizesClose.TabIndex = 2;
            this.btnSizesClose.Text = "Close";
            this.btnSizesClose.UseVisualStyleBackColor = false;
            this.btnSizesClose.Click += new System.EventHandler(this.btnSizesClose_Click);
            // 
            // btnSizesdelete
            // 
            this.btnSizesdelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnSizesdelete.Location = new System.Drawing.Point(197, 421);
            this.btnSizesdelete.Name = "btnSizesdelete";
            this.btnSizesdelete.Size = new System.Drawing.Size(89, 23);
            this.btnSizesdelete.TabIndex = 3;
            this.btnSizesdelete.Text = "Delete";
            this.btnSizesdelete.UseVisualStyleBackColor = false;
            this.btnSizesdelete.Click += new System.EventHandler(this.btnSizesdelete_Click);
            // 
            // btnSizesEdit
            // 
            this.btnSizesEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnSizesEdit.Location = new System.Drawing.Point(107, 421);
            this.btnSizesEdit.Name = "btnSizesEdit";
            this.btnSizesEdit.Size = new System.Drawing.Size(84, 23);
            this.btnSizesEdit.TabIndex = 4;
            this.btnSizesEdit.Text = "Edit";
            this.btnSizesEdit.UseVisualStyleBackColor = false;
            this.btnSizesEdit.Click += new System.EventHandler(this.btnSizesEdit_Click);
            // 
            // lblTotalSizes
            // 
            this.lblTotalSizes.AutoSize = true;
            this.lblTotalSizes.Location = new System.Drawing.Point(10, 405);
            this.lblTotalSizes.Name = "lblTotalSizes";
            this.lblTotalSizes.Size = new System.Drawing.Size(77, 13);
            this.lblTotalSizes.TabIndex = 5;
            this.lblTotalSizes.Text = "TotalRecords :";
            this.lblTotalSizes.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtSizesID);
            this.groupBox3.Controls.Add(this.btnSaveSizes);
            this.groupBox3.Controls.Add(this.txtSizes);
            this.groupBox3.Location = new System.Drawing.Point(5, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(373, 55);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Size\'s Name";
            // 
            // txtSizesID
            // 
            this.txtSizesID.Location = new System.Drawing.Point(363, 21);
            this.txtSizesID.Name = "txtSizesID";
            this.txtSizesID.Size = new System.Drawing.Size(10, 20);
            this.txtSizesID.TabIndex = 2;
            this.txtSizesID.Text = "0";
            this.txtSizesID.Visible = false;
            // 
            // btnSaveSizes
            // 
            this.btnSaveSizes.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveSizes.Location = new System.Drawing.Point(299, 19);
            this.btnSaveSizes.Name = "btnSaveSizes";
            this.btnSaveSizes.Size = new System.Drawing.Size(58, 23);
            this.btnSaveSizes.TabIndex = 1;
            this.btnSaveSizes.Text = "Save";
            this.btnSaveSizes.UseVisualStyleBackColor = false;
            this.btnSaveSizes.Click += new System.EventHandler(this.btnSaveSizes_Click);
            // 
            // txtSizes
            // 
            this.txtSizes.Location = new System.Drawing.Point(8, 24);
            this.txtSizes.Name = "txtSizes";
            this.txtSizes.Size = new System.Drawing.Size(285, 20);
            this.txtSizes.TabIndex = 0;
            // 
            // tpShade
            // 
            this.tpShade.Controls.Add(this.lblShade);
            this.tpShade.Controls.Add(this.dgvShade);
            this.tpShade.Controls.Add(this.btnShadeClose);
            this.tpShade.Controls.Add(this.btnShadedelete);
            this.tpShade.Controls.Add(this.btnShadeEdit);
            this.tpShade.Controls.Add(this.lblTotalShade);
            this.tpShade.Controls.Add(this.groupBox4);
            this.tpShade.Location = new System.Drawing.Point(4, 22);
            this.tpShade.Name = "tpShade";
            this.tpShade.Size = new System.Drawing.Size(383, 450);
            this.tpShade.TabIndex = 3;
            this.tpShade.Text = "Shade";
            this.tpShade.UseVisualStyleBackColor = true;
            this.tpShade.Paint += new System.Windows.Forms.PaintEventHandler(this.tp_Paint);
            this.tpShade.Enter += new System.EventHandler(this.tpShade_Enter);
            // 
            // lblShade
            // 
            this.lblShade.AutoSize = true;
            this.lblShade.Location = new System.Drawing.Point(93, 403);
            this.lblShade.Name = "lblShade";
            this.lblShade.Size = new System.Drawing.Size(13, 13);
            this.lblShade.TabIndex = 6;
            this.lblShade.Text = "0";
            this.lblShade.Visible = false;
            // 
            // dgvShade
            // 
            this.dgvShade.AllowUserToAddRows = false;
            this.dgvShade.AllowUserToDeleteRows = false;
            this.dgvShade.AllowUserToResizeColumns = false;
            this.dgvShade.AllowUserToResizeRows = false;
            this.dgvShade.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShade.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvShade.ColumnHeadersHeight = 18;
            this.dgvShade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvShade.ColumnHeadersVisible = false;
            this.dgvShade.ContextMenuFields = null;
            this.dgvShade.isEnterKeyLikeTabKey = true;
            this.dgvShade.isExcelSheetCell = false;
            this.dgvShade.IsSortable = false;
            this.dgvShade.Location = new System.Drawing.Point(13, 74);
            this.dgvShade.MultiSelect = false;
            this.dgvShade.Name = "dgvShade";
            this.dgvShade.ReadOnly = true;
            this.dgvShade.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvShade.RowHeadersWidth = 25;
            this.dgvShade.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvShade.RowPointer = 0;
            this.dgvShade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShade.ShowDateTimePicker = true;
            this.dgvShade.Size = new System.Drawing.Size(360, 326);
            this.dgvShade.TabIndex = 1;
            this.dgvShade.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShade_CellDoubleClick);
            // 
            // btnShadeClose
            // 
            this.btnShadeClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnShadeClose.Location = new System.Drawing.Point(292, 420);
            this.btnShadeClose.Name = "btnShadeClose";
            this.btnShadeClose.Size = new System.Drawing.Size(86, 23);
            this.btnShadeClose.TabIndex = 2;
            this.btnShadeClose.Text = "Close";
            this.btnShadeClose.UseVisualStyleBackColor = false;
            this.btnShadeClose.Click += new System.EventHandler(this.btnShadeClose_Click);
            // 
            // btnShadedelete
            // 
            this.btnShadedelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnShadedelete.Location = new System.Drawing.Point(197, 420);
            this.btnShadedelete.Name = "btnShadedelete";
            this.btnShadedelete.Size = new System.Drawing.Size(89, 23);
            this.btnShadedelete.TabIndex = 3;
            this.btnShadedelete.Text = "Delete";
            this.btnShadedelete.UseVisualStyleBackColor = false;
            this.btnShadedelete.Click += new System.EventHandler(this.btnShadedelete_Click);
            // 
            // btnShadeEdit
            // 
            this.btnShadeEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnShadeEdit.Location = new System.Drawing.Point(107, 420);
            this.btnShadeEdit.Name = "btnShadeEdit";
            this.btnShadeEdit.Size = new System.Drawing.Size(84, 23);
            this.btnShadeEdit.TabIndex = 4;
            this.btnShadeEdit.Text = "Edit";
            this.btnShadeEdit.UseVisualStyleBackColor = false;
            this.btnShadeEdit.Click += new System.EventHandler(this.btnShadeEdit_Click);
            // 
            // lblTotalShade
            // 
            this.lblTotalShade.AutoSize = true;
            this.lblTotalShade.Location = new System.Drawing.Point(10, 403);
            this.lblTotalShade.Name = "lblTotalShade";
            this.lblTotalShade.Size = new System.Drawing.Size(77, 13);
            this.lblTotalShade.TabIndex = 5;
            this.lblTotalShade.Text = "TotalRecords :";
            this.lblTotalShade.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.txtShadeID);
            this.groupBox4.Controls.Add(this.btnSaveShade);
            this.groupBox4.Controls.Add(this.txtShade);
            this.groupBox4.Location = new System.Drawing.Point(13, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(360, 54);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Shade\'s Name";
            // 
            // txtShadeID
            // 
            this.txtShadeID.Location = new System.Drawing.Point(346, 19);
            this.txtShadeID.Name = "txtShadeID";
            this.txtShadeID.Size = new System.Drawing.Size(10, 20);
            this.txtShadeID.TabIndex = 2;
            this.txtShadeID.Text = "0";
            this.txtShadeID.Visible = false;
            // 
            // btnSaveShade
            // 
            this.btnSaveShade.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveShade.Location = new System.Drawing.Point(289, 16);
            this.btnSaveShade.Name = "btnSaveShade";
            this.btnSaveShade.Size = new System.Drawing.Size(56, 23);
            this.btnSaveShade.TabIndex = 1;
            this.btnSaveShade.Text = "Save";
            this.btnSaveShade.UseVisualStyleBackColor = false;
            this.btnSaveShade.Click += new System.EventHandler(this.btnSaveShade_Click);
            // 
            // txtShade
            // 
            this.txtShade.Location = new System.Drawing.Point(6, 19);
            this.txtShade.Name = "txtShade";
            this.txtShade.Size = new System.Drawing.Size(277, 20);
            this.txtShade.TabIndex = 0;
            // 
            // tpUnits
            // 
            this.tpUnits.Controls.Add(this.lblUnits);
            this.tpUnits.Controls.Add(this.dgvUnits);
            this.tpUnits.Controls.Add(this.btnUnitsClose);
            this.tpUnits.Controls.Add(this.btnUnitsDelete);
            this.tpUnits.Controls.Add(this.btnUnitsEdit);
            this.tpUnits.Controls.Add(this.lblTotalUnits);
            this.tpUnits.Controls.Add(this.groupBox5);
            this.tpUnits.Location = new System.Drawing.Point(4, 22);
            this.tpUnits.Name = "tpUnits";
            this.tpUnits.Size = new System.Drawing.Size(383, 450);
            this.tpUnits.TabIndex = 4;
            this.tpUnits.Text = "Units";
            this.tpUnits.UseVisualStyleBackColor = true;
            this.tpUnits.Paint += new System.Windows.Forms.PaintEventHandler(this.tp_Paint);
            this.tpUnits.Enter += new System.EventHandler(this.tpUnits_Enter);
            // 
            // lblUnits
            // 
            this.lblUnits.AutoSize = true;
            this.lblUnits.Location = new System.Drawing.Point(94, 408);
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Size = new System.Drawing.Size(13, 13);
            this.lblUnits.TabIndex = 6;
            this.lblUnits.Text = "0";
            this.lblUnits.Visible = false;
            // 
            // dgvUnits
            // 
            this.dgvUnits.AllowUserToAddRows = false;
            this.dgvUnits.AllowUserToDeleteRows = false;
            this.dgvUnits.AllowUserToResizeColumns = false;
            this.dgvUnits.AllowUserToResizeRows = false;
            this.dgvUnits.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUnits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUnits.ColumnHeadersHeight = 18;
            this.dgvUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUnits.ColumnHeadersVisible = false;
            this.dgvUnits.ContextMenuFields = null;
            this.dgvUnits.isEnterKeyLikeTabKey = true;
            this.dgvUnits.isExcelSheetCell = false;
            this.dgvUnits.IsSortable = false;
            this.dgvUnits.Location = new System.Drawing.Point(14, 70);
            this.dgvUnits.MultiSelect = false;
            this.dgvUnits.Name = "dgvUnits";
            this.dgvUnits.ReadOnly = true;
            this.dgvUnits.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUnits.RowHeadersWidth = 25;
            this.dgvUnits.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUnits.RowPointer = 0;
            this.dgvUnits.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUnits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnits.ShowDateTimePicker = true;
            this.dgvUnits.Size = new System.Drawing.Size(358, 335);
            this.dgvUnits.TabIndex = 1;
            this.dgvUnits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnits_CellDoubleClick);
            // 
            // btnUnitsClose
            // 
            this.btnUnitsClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnUnitsClose.Location = new System.Drawing.Point(290, 421);
            this.btnUnitsClose.Name = "btnUnitsClose";
            this.btnUnitsClose.Size = new System.Drawing.Size(86, 23);
            this.btnUnitsClose.TabIndex = 2;
            this.btnUnitsClose.Text = "Close";
            this.btnUnitsClose.UseVisualStyleBackColor = false;
            this.btnUnitsClose.Click += new System.EventHandler(this.btnUnitsClose_Click);
            // 
            // btnUnitsDelete
            // 
            this.btnUnitsDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnUnitsDelete.Location = new System.Drawing.Point(195, 421);
            this.btnUnitsDelete.Name = "btnUnitsDelete";
            this.btnUnitsDelete.Size = new System.Drawing.Size(89, 23);
            this.btnUnitsDelete.TabIndex = 3;
            this.btnUnitsDelete.Text = "Delete";
            this.btnUnitsDelete.UseVisualStyleBackColor = false;
            this.btnUnitsDelete.Click += new System.EventHandler(this.btnUnitsDelete_Click);
            // 
            // btnUnitsEdit
            // 
            this.btnUnitsEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnUnitsEdit.Location = new System.Drawing.Point(105, 421);
            this.btnUnitsEdit.Name = "btnUnitsEdit";
            this.btnUnitsEdit.Size = new System.Drawing.Size(84, 23);
            this.btnUnitsEdit.TabIndex = 4;
            this.btnUnitsEdit.Text = "Edit";
            this.btnUnitsEdit.UseVisualStyleBackColor = false;
            this.btnUnitsEdit.Click += new System.EventHandler(this.btnUnitsEdit_Click);
            // 
            // lblTotalUnits
            // 
            this.lblTotalUnits.AutoSize = true;
            this.lblTotalUnits.Location = new System.Drawing.Point(11, 408);
            this.lblTotalUnits.Name = "lblTotalUnits";
            this.lblTotalUnits.Size = new System.Drawing.Size(77, 13);
            this.lblTotalUnits.TabIndex = 5;
            this.lblTotalUnits.Text = "TotalRecords :";
            this.lblTotalUnits.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.txtUnitsID);
            this.groupBox5.Controls.Add(this.btnSaveUnits);
            this.groupBox5.Controls.Add(this.txtUnits);
            this.groupBox5.Location = new System.Drawing.Point(14, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(358, 51);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Unit\'s Name";
            // 
            // txtUnitsID
            // 
            this.txtUnitsID.Location = new System.Drawing.Point(346, 19);
            this.txtUnitsID.Name = "txtUnitsID";
            this.txtUnitsID.Size = new System.Drawing.Size(10, 20);
            this.txtUnitsID.TabIndex = 2;
            this.txtUnitsID.Text = "0";
            this.txtUnitsID.Visible = false;
            // 
            // btnSaveUnits
            // 
            this.btnSaveUnits.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveUnits.Location = new System.Drawing.Point(289, 17);
            this.btnSaveUnits.Name = "btnSaveUnits";
            this.btnSaveUnits.Size = new System.Drawing.Size(54, 23);
            this.btnSaveUnits.TabIndex = 1;
            this.btnSaveUnits.Text = "Save";
            this.btnSaveUnits.UseVisualStyleBackColor = false;
            this.btnSaveUnits.Click += new System.EventHandler(this.btnSaveUnits_Click);
            // 
            // txtUnits
            // 
            this.txtUnits.Location = new System.Drawing.Point(6, 19);
            this.txtUnits.Name = "txtUnits";
            this.txtUnits.Size = new System.Drawing.Size(277, 20);
            this.txtUnits.TabIndex = 0;
            // 
            // frmBasicEntryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 482);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBasicEntryScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Basic Entry Screen";
            this.Load += new System.EventHandler(this.frmBasicEntryScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmBasicEntryScreen_Paint);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBasicEntryScreen_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tpColors.ResumeLayout(false);
            this.tpColors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColors)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpCounts.ResumeLayout(false);
            this.tpCounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCounts)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tpSizes.ResumeLayout(false);
            this.tpSizes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSizes)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tpShade.ResumeLayout(false);
            this.tpShade.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShade)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tpUnits.ResumeLayout(false);
            this.tpUnits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpColors;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveColors;
        private System.Windows.Forms.Button btnColoresClose;
        private System.Windows.Forms.Button btnColoresDelete;
        private System.Windows.Forms.Button btnColoresEdit;
        private System.Windows.Forms.Label lblTotalColors;
        private System.Windows.Forms.TextBox txtColorsName;
        private System.Windows.Forms.TabPage tpCounts;
        private System.Windows.Forms.TabPage tpSizes;
        private System.Windows.Forms.TabPage tpShade;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveCounts;
        private System.Windows.Forms.TextBox txtCountsName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSaveSizes;
        private System.Windows.Forms.TextBox txtSizes;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSaveShade;
        private System.Windows.Forms.TextBox txtShade;
        private System.Windows.Forms.Button btnCountsClose;
        private System.Windows.Forms.Button btnCountsDelete;
        private System.Windows.Forms.Button btnCountsEdit;
        private System.Windows.Forms.Label lblTotalCounts;
        private System.Windows.Forms.Button btnSizesClose;
        private System.Windows.Forms.Button btnSizesdelete;
        private System.Windows.Forms.Button btnSizesEdit;
        private System.Windows.Forms.Label lblTotalSizes;
        private System.Windows.Forms.Button btnShadeClose;
        private System.Windows.Forms.Button btnShadedelete;
        private System.Windows.Forms.Button btnShadeEdit;
        private System.Windows.Forms.Label lblTotalShade;
        private System.Windows.Forms.TabPage tpUnits;
        private System.Windows.Forms.Button btnUnitsClose;
        private System.Windows.Forms.Button btnUnitsDelete;
        private System.Windows.Forms.Button btnUnitsEdit;
        private System.Windows.Forms.Label lblTotalUnits;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSaveUnits;
        private System.Windows.Forms.TextBox txtUnits;
        private Accounting.Controls.ctlDaraGridView dgvUnits;
        private Accounting.Controls.ctlDaraGridView dgvCounts;
        private Accounting.Controls.ctlDaraGridView dgvSizes;
        private Accounting.Controls.ctlDaraGridView dgvShade;
        private Accounting.Controls.ctlDaraGridView dgvColors;
        private System.Windows.Forms.TextBox txtColorsID;
        private System.Windows.Forms.TextBox txtCountsID;
        private System.Windows.Forms.TextBox txtSizesID;
        private System.Windows.Forms.TextBox txtShadeID;
        private System.Windows.Forms.TextBox txtUnitsID;
        private System.Windows.Forms.Label lblColors;
        private System.Windows.Forms.Label lblCounts;
        private System.Windows.Forms.Label lblSizes;
        private System.Windows.Forms.Label lblShade;
        private System.Windows.Forms.Label lblUnits;
    }
}