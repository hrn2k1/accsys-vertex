namespace Accounting.UI
{
    partial class frmMain
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
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.mnuSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCompanys = new System.Windows.Forms.ToolStripMenuItem();
            this.itmBusinessType = new System.Windows.Forms.ToolStripMenuItem();
            this.itmBusinessSubType = new System.Windows.Forms.ToolStripMenuItem();
            this.itmCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBasicEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.itmItemProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.itmCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSection = new System.Windows.Forms.ToolStripMenuItem();
            this.itmBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.itmDept = new System.Windows.Forms.ToolStripMenuItem();
            this.itmDesignation = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSalesTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLedgers = new System.Windows.Forms.ToolStripMenuItem();
            this.itmItems = new System.Windows.Forms.ToolStripMenuItem();
            this.itmFactory = new System.Windows.Forms.ToolStripMenuItem();
            this.itmPriceLists = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.itmPurchaseOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.itmPurchaseInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.itmPurchaseReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSales = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSalesOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSalesInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSalesReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCommercial = new System.Windows.Forms.ToolStripMenuItem();
            this.itmPI = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLC = new System.Windows.Forms.ToolStripMenuItem();
            this.itmCommercialDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.itmForwardLetter = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExportBills = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.itmOPstock = new System.Windows.Forms.ToolStripMenuItem();
            this.itmRequisition = new System.Windows.Forms.ToolStripMenuItem();
            this.itmStockInOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.itmDebitVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.itmCreditVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.itmJournalVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.itmVoucherRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.itmBillReceivable = new System.Windows.Forms.ToolStripMenuItem();
            this.itmBillPayable = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLoan = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLoanAdjust = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.itmAccReport = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSchdlReport = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSalesReport = new System.Windows.Forms.ToolStripMenuItem();
            this.itmPurchaseReport = new System.Windows.Forms.ToolStripMenuItem();
            this.itmInventoryReport = new System.Windows.Forms.ToolStripMenuItem();
            this.itmCommReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUtility = new System.Windows.Forms.ToolStripMenuItem();
            this.itmFiscalYear = new System.Windows.Forms.ToolStripMenuItem();
            this.itmUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLogOff = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stLblCompany = new System.Windows.Forms.ToolStripStatusLabel();
            this.stlblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.stLblDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.stlblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.itmBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBar.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.BackColor = System.Drawing.Color.Snow;
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetup,
            this.mnuPurchase,
            this.mnuSales,
            this.mnuCommercial,
            this.mnuInventory,
            this.mnuAccounts,
            this.mnuReport,
            this.mnuUtility,
            this.mnuHelp});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(693, 24);
            this.MenuBar.TabIndex = 1;
            this.MenuBar.Text = "menuStrip1";
            // 
            // mnuSetup
            // 
            this.mnuSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCompanys,
            this.mnuBasicEntry,
            this.itmSalesTeam,
            this.itmLedgers,
            this.itmItems,
            this.itmFactory,
            this.itmPriceLists});
            this.mnuSetup.Name = "mnuSetup";
            this.mnuSetup.Size = new System.Drawing.Size(47, 20);
            this.mnuSetup.Text = "&Setup";
            // 
            // mnuCompanys
            // 
            this.mnuCompanys.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmBusinessType,
            this.itmBusinessSubType,
            this.itmCompany,
            this.itmSettings});
            this.mnuCompanys.Name = "mnuCompanys";
            this.mnuCompanys.Size = new System.Drawing.Size(172, 22);
            this.mnuCompanys.Text = "&Company";
            // 
            // itmBusinessType
            // 
            this.itmBusinessType.Name = "itmBusinessType";
            this.itmBusinessType.Size = new System.Drawing.Size(171, 22);
            this.itmBusinessType.Text = "Business &Type";
            this.itmBusinessType.Click += new System.EventHandler(this.itmBusinessType_Click);
            // 
            // itmBusinessSubType
            // 
            this.itmBusinessSubType.Name = "itmBusinessSubType";
            this.itmBusinessSubType.Size = new System.Drawing.Size(171, 22);
            this.itmBusinessSubType.Text = "Business &SubType";
            this.itmBusinessSubType.Click += new System.EventHandler(this.itmBusinessSubType_Click);
            // 
            // itmCompany
            // 
            this.itmCompany.Name = "itmCompany";
            this.itmCompany.Size = new System.Drawing.Size(171, 22);
            this.itmCompany.Text = "Company &Info";
            this.itmCompany.Click += new System.EventHandler(this.itmCompany_Click);
            // 
            // itmSettings
            // 
            this.itmSettings.Name = "itmSettings";
            this.itmSettings.ShortcutKeyDisplayString = "";
            this.itmSettings.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.itmSettings.Size = new System.Drawing.Size(171, 22);
            this.itmSettings.Text = "Se&ttings";
            this.itmSettings.Click += new System.EventHandler(this.itmSettings_Click_1);
            // 
            // mnuBasicEntry
            // 
            this.mnuBasicEntry.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmItemProperties,
            this.itmCountry,
            this.itmSection,
            this.itmBranch,
            this.itmDept,
            this.itmDesignation});
            this.mnuBasicEntry.Name = "mnuBasicEntry";
            this.mnuBasicEntry.Size = new System.Drawing.Size(172, 22);
            this.mnuBasicEntry.Text = "Basic &Entry";
            // 
            // itmItemProperties
            // 
            this.itmItemProperties.Name = "itmItemProperties";
            this.itmItemProperties.Size = new System.Drawing.Size(159, 22);
            this.itmItemProperties.Text = "&Item Properties";
            this.itmItemProperties.Click += new System.EventHandler(this.itmItemProperties_Click);
            // 
            // itmCountry
            // 
            this.itmCountry.Name = "itmCountry";
            this.itmCountry.Size = new System.Drawing.Size(159, 22);
            this.itmCountry.Text = "&Country";
            this.itmCountry.Click += new System.EventHandler(this.itmCountry_Click);
            // 
            // itmSection
            // 
            this.itmSection.Name = "itmSection";
            this.itmSection.Size = new System.Drawing.Size(159, 22);
            this.itmSection.Text = "&Section";
            this.itmSection.Click += new System.EventHandler(this.itmSection_Click);
            // 
            // itmBranch
            // 
            this.itmBranch.Name = "itmBranch";
            this.itmBranch.Size = new System.Drawing.Size(159, 22);
            this.itmBranch.Text = "&Branch";
            this.itmBranch.Click += new System.EventHandler(this.itmBranch_Click);
            // 
            // itmDept
            // 
            this.itmDept.Name = "itmDept";
            this.itmDept.Size = new System.Drawing.Size(159, 22);
            this.itmDept.Text = "&Department";
            this.itmDept.Click += new System.EventHandler(this.itmDept_Click);
            // 
            // itmDesignation
            // 
            this.itmDesignation.Name = "itmDesignation";
            this.itmDesignation.Size = new System.Drawing.Size(159, 22);
            this.itmDesignation.Text = "Desi&gnation";
            this.itmDesignation.Click += new System.EventHandler(this.itmDesignation_Click);
            // 
            // itmSalesTeam
            // 
            this.itmSalesTeam.Name = "itmSalesTeam";
            this.itmSalesTeam.Size = new System.Drawing.Size(172, 22);
            this.itmSalesTeam.Text = "Sales &Team";
            this.itmSalesTeam.Click += new System.EventHandler(this.itmSalesTeam_Click);
            // 
            // itmLedgers
            // 
            this.itmLedgers.Name = "itmLedgers";
            this.itmLedgers.Size = new System.Drawing.Size(172, 22);
            this.itmLedgers.Text = "Chart of &Accounts";
            this.itmLedgers.Click += new System.EventHandler(this.itmLedgers_Click);
            // 
            // itmItems
            // 
            this.itmItems.Name = "itmItems";
            this.itmItems.Size = new System.Drawing.Size(172, 22);
            this.itmItems.Text = "Chart of &Items";
            this.itmItems.Click += new System.EventHandler(this.itmItems_Click);
            // 
            // itmFactory
            // 
            this.itmFactory.Name = "itmFactory";
            this.itmFactory.Size = new System.Drawing.Size(172, 22);
            this.itmFactory.Text = "&Factory";
            this.itmFactory.Click += new System.EventHandler(this.itmFactory_Click);
            // 
            // itmPriceLists
            // 
            this.itmPriceLists.Name = "itmPriceLists";
            this.itmPriceLists.Size = new System.Drawing.Size(172, 22);
            this.itmPriceLists.Text = "&Price List";
            this.itmPriceLists.Click += new System.EventHandler(this.itmPriceList_Click);
            // 
            // mnuPurchase
            // 
            this.mnuPurchase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmPurchaseOrder,
            this.itmPurchaseInvoice,
            this.itmPurchaseReturn});
            this.mnuPurchase.Name = "mnuPurchase";
            this.mnuPurchase.Size = new System.Drawing.Size(63, 20);
            this.mnuPurchase.Text = "&Purchase";
            // 
            // itmPurchaseOrder
            // 
            this.itmPurchaseOrder.Name = "itmPurchaseOrder";
            this.itmPurchaseOrder.Size = new System.Drawing.Size(167, 22);
            this.itmPurchaseOrder.Text = "Purchase &Order";
            this.itmPurchaseOrder.Click += new System.EventHandler(this.itmPO_Click);
            // 
            // itmPurchaseInvoice
            // 
            this.itmPurchaseInvoice.Name = "itmPurchaseInvoice";
            this.itmPurchaseInvoice.Size = new System.Drawing.Size(167, 22);
            this.itmPurchaseInvoice.Text = "Purchase &Invoice";
            this.itmPurchaseInvoice.Click += new System.EventHandler(this.itmPurchaseInvoice_Click);
            // 
            // itmPurchaseReturn
            // 
            this.itmPurchaseReturn.Name = "itmPurchaseReturn";
            this.itmPurchaseReturn.Size = new System.Drawing.Size(167, 22);
            this.itmPurchaseReturn.Text = "Purchase &Return";
            this.itmPurchaseReturn.Click += new System.EventHandler(this.itmPurchaseReturn_Click);
            // 
            // mnuSales
            // 
            this.mnuSales.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmSalesOrder,
            this.itmSalesInvoice,
            this.itmSalesReturn});
            this.mnuSales.Name = "mnuSales";
            this.mnuSales.Size = new System.Drawing.Size(44, 20);
            this.mnuSales.Text = "&Sales";
            // 
            // itmSalesOrder
            // 
            this.itmSalesOrder.Name = "itmSalesOrder";
            this.itmSalesOrder.Size = new System.Drawing.Size(148, 22);
            this.itmSalesOrder.Text = "Sales &Order";
            this.itmSalesOrder.Click += new System.EventHandler(this.itmSalesOrder_Click);
            // 
            // itmSalesInvoice
            // 
            this.itmSalesInvoice.Name = "itmSalesInvoice";
            this.itmSalesInvoice.Size = new System.Drawing.Size(148, 22);
            this.itmSalesInvoice.Text = "Sales &Invoice";
            this.itmSalesInvoice.Click += new System.EventHandler(this.itmSalesInvoice_Click);
            // 
            // itmSalesReturn
            // 
            this.itmSalesReturn.Name = "itmSalesReturn";
            this.itmSalesReturn.Size = new System.Drawing.Size(148, 22);
            this.itmSalesReturn.Text = "Sales &Return";
            this.itmSalesReturn.Click += new System.EventHandler(this.itmSalesReturn_Click);
            // 
            // mnuCommercial
            // 
            this.mnuCommercial.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmPI,
            this.itmLC,
            this.itmCommercialDocs,
            this.itmForwardLetter,
            this.itmExportBills});
            this.mnuCommercial.Name = "mnuCommercial";
            this.mnuCommercial.Size = new System.Drawing.Size(73, 20);
            this.mnuCommercial.Text = "&Commercial";
            // 
            // itmPI
            // 
            this.itmPI.Name = "itmPI";
            this.itmPI.Size = new System.Drawing.Size(190, 22);
            this.itmPI.Text = "&Proforma Invoice";
            this.itmPI.Click += new System.EventHandler(this.itmPI_Click);
            // 
            // itmLC
            // 
            this.itmLC.Name = "itmLC";
            this.itmLC.Size = new System.Drawing.Size(190, 22);
            this.itmLC.Text = "&LC";
            this.itmLC.Click += new System.EventHandler(this.itmLC_Click);
            // 
            // itmCommercialDocs
            // 
            this.itmCommercialDocs.Name = "itmCommercialDocs";
            this.itmCommercialDocs.Size = new System.Drawing.Size(190, 22);
            this.itmCommercialDocs.Text = "Commercial Document";
            this.itmCommercialDocs.Click += new System.EventHandler(this.itmCommercialDocs_Click);
            // 
            // itmForwardLetter
            // 
            this.itmForwardLetter.Name = "itmForwardLetter";
            this.itmForwardLetter.Size = new System.Drawing.Size(190, 22);
            this.itmForwardLetter.Text = "&Forwarding Letter";
            this.itmForwardLetter.Click += new System.EventHandler(this.itmForwardLetter_Click);
            // 
            // itmExportBills
            // 
            this.itmExportBills.Name = "itmExportBills";
            this.itmExportBills.Size = new System.Drawing.Size(190, 22);
            this.itmExportBills.Text = "&Export Bill";
            this.itmExportBills.Click += new System.EventHandler(this.itmExportBill_Click);
            // 
            // mnuInventory
            // 
            this.mnuInventory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmOPstock,
            this.itmRequisition,
            this.itmStockInOut});
            this.mnuInventory.Name = "mnuInventory";
            this.mnuInventory.Size = new System.Drawing.Size(67, 20);
            this.mnuInventory.Text = "&Inventory";
            // 
            // itmOPstock
            // 
            this.itmOPstock.Name = "itmOPstock";
            this.itmOPstock.Size = new System.Drawing.Size(154, 22);
            this.itmOPstock.Text = "&Opening Stock";
            this.itmOPstock.Click += new System.EventHandler(this.itmOPstock_Click);
            // 
            // itmRequisition
            // 
            this.itmRequisition.Name = "itmRequisition";
            this.itmRequisition.Size = new System.Drawing.Size(154, 22);
            this.itmRequisition.Text = "&Requisition";
            this.itmRequisition.Click += new System.EventHandler(this.itmRequisition_Click);
            // 
            // itmStockInOut
            // 
            this.itmStockInOut.Name = "itmStockInOut";
            this.itmStockInOut.Size = new System.Drawing.Size(154, 22);
            this.itmStockInOut.Text = "&Stock In Out";
            this.itmStockInOut.Click += new System.EventHandler(this.itmStockInOut_Click);
            // 
            // mnuAccounts
            // 
            this.mnuAccounts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmDebitVoucher,
            this.itmCreditVoucher,
            this.itmJournalVoucher,
            this.itmVoucherRegister,
            this.itmBillReceivable,
            this.itmBillPayable,
            this.itmLoan,
            this.itmLoanAdjust});
            this.mnuAccounts.Name = "mnuAccounts";
            this.mnuAccounts.Size = new System.Drawing.Size(63, 20);
            this.mnuAccounts.Text = "&Accounts";
            // 
            // itmDebitVoucher
            // 
            this.itmDebitVoucher.Name = "itmDebitVoucher";
            this.itmDebitVoucher.Size = new System.Drawing.Size(167, 22);
            this.itmDebitVoucher.Text = "&Debit Voucher";
            this.itmDebitVoucher.Click += new System.EventHandler(this.itmDebitVoucher_Click);
            // 
            // itmCreditVoucher
            // 
            this.itmCreditVoucher.Name = "itmCreditVoucher";
            this.itmCreditVoucher.Size = new System.Drawing.Size(167, 22);
            this.itmCreditVoucher.Text = "&Credit Voucher";
            this.itmCreditVoucher.Click += new System.EventHandler(this.itmCreditVoucher_Click);
            // 
            // itmJournalVoucher
            // 
            this.itmJournalVoucher.Name = "itmJournalVoucher";
            this.itmJournalVoucher.Size = new System.Drawing.Size(167, 22);
            this.itmJournalVoucher.Text = "&Journal Voucher";
            this.itmJournalVoucher.Click += new System.EventHandler(this.itmJournalVoucher_Click);
            // 
            // itmVoucherRegister
            // 
            this.itmVoucherRegister.Name = "itmVoucherRegister";
            this.itmVoucherRegister.Size = new System.Drawing.Size(167, 22);
            this.itmVoucherRegister.Text = "&Voucher Register";
            this.itmVoucherRegister.Click += new System.EventHandler(this.itmVoucherRegister_Click);
            // 
            // itmBillReceivable
            // 
            this.itmBillReceivable.Name = "itmBillReceivable";
            this.itmBillReceivable.Size = new System.Drawing.Size(167, 22);
            this.itmBillReceivable.Text = "Bills &Receivable";
            this.itmBillReceivable.Click += new System.EventHandler(this.itmBillReceivable_Click);
            // 
            // itmBillPayable
            // 
            this.itmBillPayable.Name = "itmBillPayable";
            this.itmBillPayable.Size = new System.Drawing.Size(167, 22);
            this.itmBillPayable.Text = "Bills &Payable";
            this.itmBillPayable.Click += new System.EventHandler(this.itmBillPayable_Click);
            // 
            // itmLoan
            // 
            this.itmLoan.Name = "itmLoan";
            this.itmLoan.Size = new System.Drawing.Size(167, 22);
            this.itmLoan.Text = "&Loan";
            this.itmLoan.Click += new System.EventHandler(this.itmloan_Click);
            // 
            // itmLoanAdjust
            // 
            this.itmLoanAdjust.Name = "itmLoanAdjust";
            this.itmLoanAdjust.Size = new System.Drawing.Size(167, 22);
            this.itmLoanAdjust.Text = "Loan &Adjust";
            this.itmLoanAdjust.Click += new System.EventHandler(this.itmLoanAdjust_Click);
            // 
            // mnuReport
            // 
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmAccReport,
            this.itmSchdlReport,
            this.itmSalesReport,
            this.itmPurchaseReport,
            this.itmInventoryReport,
            this.itmCommReport});
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(52, 20);
            this.mnuReport.Text = "&Report";
            // 
            // itmAccReport
            // 
            this.itmAccReport.Name = "itmAccReport";
            this.itmAccReport.Size = new System.Drawing.Size(175, 22);
            this.itmAccReport.Text = "&Accounting Report";
            this.itmAccReport.Click += new System.EventHandler(this.itmAccReport_Click);
            // 
            // itmSchdlReport
            // 
            this.itmSchdlReport.Name = "itmSchdlReport";
            this.itmSchdlReport.Size = new System.Drawing.Size(175, 22);
            this.itmSchdlReport.Text = "Sc&hedule Report";
            this.itmSchdlReport.Click += new System.EventHandler(this.itmSchdlReport_Click);
            // 
            // itmSalesReport
            // 
            this.itmSalesReport.Name = "itmSalesReport";
            this.itmSalesReport.Size = new System.Drawing.Size(175, 22);
            this.itmSalesReport.Text = "&Sales Report";
            this.itmSalesReport.Click += new System.EventHandler(this.itmSalesReport_Click);
            // 
            // itmPurchaseReport
            // 
            this.itmPurchaseReport.Name = "itmPurchaseReport";
            this.itmPurchaseReport.Size = new System.Drawing.Size(175, 22);
            this.itmPurchaseReport.Text = "&Purchase Report";
            this.itmPurchaseReport.Click += new System.EventHandler(this.itmPurchaseReport_Click);
            // 
            // itmInventoryReport
            // 
            this.itmInventoryReport.Name = "itmInventoryReport";
            this.itmInventoryReport.Size = new System.Drawing.Size(175, 22);
            this.itmInventoryReport.Text = "&Inventory Report";
            this.itmInventoryReport.Click += new System.EventHandler(this.itmInventoryReport_Click);
            // 
            // itmCommReport
            // 
            this.itmCommReport.Name = "itmCommReport";
            this.itmCommReport.Size = new System.Drawing.Size(175, 22);
            this.itmCommReport.Text = "&Commercial Report";
            this.itmCommReport.Click += new System.EventHandler(this.itmCommReport_Click);
            // 
            // mnuUtility
            // 
            this.mnuUtility.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmFiscalYear,
            this.itmUsers,
            this.itmLogOff,
            this.itmExit,
            this.itmBackup});
            this.mnuUtility.Name = "mnuUtility";
            this.mnuUtility.Size = new System.Drawing.Size(53, 20);
            this.mnuUtility.Text = "&Utilities";
            // 
            // itmFiscalYear
            // 
            this.itmFiscalYear.Name = "itmFiscalYear";
            this.itmFiscalYear.Size = new System.Drawing.Size(172, 22);
            this.itmFiscalYear.Text = "Start &Fiscal Year";
            this.itmFiscalYear.Click += new System.EventHandler(this.itmFiscalYear_Click);
            // 
            // itmUsers
            // 
            this.itmUsers.Name = "itmUsers";
            this.itmUsers.Size = new System.Drawing.Size(172, 22);
            this.itmUsers.Text = "&User Management";
            this.itmUsers.Click += new System.EventHandler(this.itmUsers_Click);
            // 
            // itmLogOff
            // 
            this.itmLogOff.Name = "itmLogOff";
            this.itmLogOff.Size = new System.Drawing.Size(172, 22);
            this.itmLogOff.Text = "&Log Off";
            this.itmLogOff.Click += new System.EventHandler(this.itmLogOff_Click);
            // 
            // itmExit
            // 
            this.itmExit.Name = "itmExit";
            this.itmExit.Size = new System.Drawing.Size(172, 22);
            this.itmExit.Text = "E&xit";
            this.itmExit.Click += new System.EventHandler(this.itmExit_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(40, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Snow;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stLblCompany,
            this.stlblUser,
            this.stLblDate,
            this.stlblTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 423);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(693, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stLblCompany
            // 
            this.stLblCompany.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stLblCompany.Name = "stLblCompany";
            this.stLblCompany.Size = new System.Drawing.Size(169, 17);
            this.stLblCompany.Spring = true;
            this.stLblCompany.Text = "Vertex Software Ltd.";
            // 
            // stlblUser
            // 
            this.stlblUser.Name = "stlblUser";
            this.stlblUser.Size = new System.Drawing.Size(169, 17);
            this.stlblUser.Spring = true;
            this.stlblUser.Text = "User Name";
            // 
            // stLblDate
            // 
            this.stLblDate.Name = "stLblDate";
            this.stLblDate.Size = new System.Drawing.Size(169, 17);
            this.stLblDate.Spring = true;
            this.stLblDate.Text = "Date";
            // 
            // stlblTime
            // 
            this.stlblTime.Name = "stlblTime";
            this.stlblTime.Size = new System.Drawing.Size(169, 17);
            this.stlblTime.Spring = true;
            this.stlblTime.Text = "Time";
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 195);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(693, 53);
            this.label1.TabIndex = 5;
            this.label1.Text = "Company";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.itmAssetSchdl_Click);
            // 
            // itmBackup
            // 
            this.itmBackup.Name = "itmBackup";
            this.itmBackup.Size = new System.Drawing.Size(172, 22);
            this.itmBackup.Text = "Database &Backup";
            this.itmBackup.Click += new System.EventHandler(this.itmBackup_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Accounting.UI.Properties.Resources.interface_for_ERP;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(693, 445);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MenuBar);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accounting System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuSetup;
        private System.Windows.Forms.ToolStripMenuItem mnuPurchase;
        private System.Windows.Forms.ToolStripMenuItem mnuSales;
        private System.Windows.Forms.ToolStripMenuItem mnuCommercial;
        private System.Windows.Forms.ToolStripMenuItem mnuInventory;
        private System.Windows.Forms.ToolStripMenuItem mnuAccounts;
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ToolStripMenuItem mnuUtility;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuBasicEntry;
        private System.Windows.Forms.ToolStripMenuItem itmItemProperties;
        private System.Windows.Forms.ToolStripMenuItem itmCountry;
        private System.Windows.Forms.ToolStripMenuItem itmSection;
        private System.Windows.Forms.ToolStripMenuItem itmBranch;
        private System.Windows.Forms.ToolStripMenuItem itmDept;
        private System.Windows.Forms.ToolStripMenuItem itmSalesTeam;
        private System.Windows.Forms.ToolStripMenuItem itmLedgers;
        private System.Windows.Forms.ToolStripMenuItem itmItems;
        private System.Windows.Forms.ToolStripMenuItem itmFactory;
        private System.Windows.Forms.ToolStripMenuItem itmPriceLists;
        private System.Windows.Forms.ToolStripMenuItem itmPurchaseOrder;
        private System.Windows.Forms.ToolStripMenuItem itmPurchaseInvoice;
        private System.Windows.Forms.ToolStripMenuItem itmPurchaseReturn;
        private System.Windows.Forms.ToolStripMenuItem itmSalesOrder;
        private System.Windows.Forms.ToolStripMenuItem itmSalesInvoice;
        private System.Windows.Forms.ToolStripMenuItem itmSalesReturn;
        private System.Windows.Forms.ToolStripMenuItem itmPI;
        private System.Windows.Forms.ToolStripMenuItem itmLC;
        private System.Windows.Forms.ToolStripMenuItem itmCommercialDocs;
        private System.Windows.Forms.ToolStripMenuItem itmOPstock;
        private System.Windows.Forms.ToolStripMenuItem itmRequisition;
        private System.Windows.Forms.ToolStripMenuItem itmStockInOut;
        private System.Windows.Forms.ToolStripMenuItem itmDebitVoucher;
        private System.Windows.Forms.ToolStripMenuItem itmCreditVoucher;
        private System.Windows.Forms.ToolStripMenuItem itmJournalVoucher;
        private System.Windows.Forms.ToolStripMenuItem itmVoucherRegister;
        private System.Windows.Forms.ToolStripMenuItem itmBillReceivable;
        private System.Windows.Forms.ToolStripMenuItem itmBillPayable;
        private System.Windows.Forms.ToolStripMenuItem itmLoan;
        private System.Windows.Forms.ToolStripMenuItem itmLoanAdjust;
        private System.Windows.Forms.ToolStripMenuItem itmAccReport;
        private System.Windows.Forms.ToolStripMenuItem itmInventoryReport;
        private System.Windows.Forms.ToolStripMenuItem itmCommReport;
        private System.Windows.Forms.ToolStripMenuItem itmFiscalYear;
        private System.Windows.Forms.ToolStripMenuItem itmUsers;
        private System.Windows.Forms.ToolStripMenuItem itmLogOff;
        private System.Windows.Forms.ToolStripMenuItem itmExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stLblCompany;
        private System.Windows.Forms.ToolStripStatusLabel stlblUser;
        private System.Windows.Forms.ToolStripStatusLabel stlblTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mnuCompanys;
        private System.Windows.Forms.ToolStripMenuItem itmExportBills;
        private System.Windows.Forms.ToolStripMenuItem itmBusinessType;
        private System.Windows.Forms.ToolStripMenuItem itmBusinessSubType;
        private System.Windows.Forms.ToolStripMenuItem itmCompany;
        private System.Windows.Forms.ToolStripMenuItem itmSalesReport;
        private System.Windows.Forms.ToolStripMenuItem itmPurchaseReport;
        private System.Windows.Forms.ToolStripStatusLabel stLblDate;
        private System.Windows.Forms.ToolStripMenuItem itmDesignation;
        private System.Windows.Forms.ToolStripMenuItem itmSchdlReport;
        private System.Windows.Forms.ToolStripMenuItem itmForwardLetter;
        private System.Windows.Forms.ToolStripMenuItem itmSettings;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itmBackup;
    }
}

