using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Utility;
using Accounting.DataAccess;
using Accounting.Entity;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;

namespace Accounting.UI
{
    public partial class frmMain : Form
    {
        private ArrayList _list = new ArrayList();
        private Authentication _objAuthentication = new Authentication();
        private DaUserPrivilege obDaUserPrivilege = new DaUserPrivilege();
        //private string[] _strButtonNames = new string[] { "btnSave", "btnReset", "btnDelete", "" };
        //btnReset
        public frmMain()
        {
            InitializeComponent();
           
        }

        private void itmLedgers_Click(object sender, EventArgs e)
        {
            try
            {

                frmLedger frm = new frmLedger();
                if (Authenticate(frm, new string[] { "btnSave", "btnNew", "btnDelete" }))
                    frm.ShowDialog();
                else
                    itmLedgers.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmSalesTeam_Click(object sender, EventArgs e)
        {
            try
            {
                frmTeam team = new frmTeam();
                if (Authenticate(team, new string[] { "btnSave", "btnNew", "btnDeleteTeam", "btnDeleteMember" }))
                    team.ShowDialog();
                else
                    itmSalesTeam.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmSalesOrder_Click(object sender, EventArgs e)
        {
            try
            {

                frmSalesOrder SalesOrder = new frmSalesOrder();
                if (Authenticate(SalesOrder, new string[] { "btnSave", "btnDelete", "btnDeleteItems" }))
                    SalesOrder.ShowDialog();
                else
                    itmSalesOrder.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmPI_Click(object sender, EventArgs e)
        {
            try
            {
                frmPI PI = new frmPI();
                if (Authenticate(PI, new string[] { "btnSave", "btnNew", "btnDelete" }))
                    PI.ShowDialog();
                else
                    itmPI.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmItems_Click(object sender, EventArgs e)
        {
            try
            {
                frmChartsOfItem objChOfItem = new frmChartsOfItem();
                if (Authenticate(objChOfItem, new string[] { "btnSave", "btnNew", "btnDelete" }))
                    objChOfItem.ShowDialog();
                else
                    itmItems.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void itmPO_Click(object sender, EventArgs e)
        {
            try
            {
                frmPurchaseOrder frm = new frmPurchaseOrder();
                if (Authenticate(frm, new string[] { "btnSave", "btnNew", "btnDeleteOrder", "btnDelete", "btnAmend" }))
                    frm.ShowDialog();
                else
                    itmPurchaseOrder.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmPriceList_Click(object sender, EventArgs e)
        {
            try
            {
                frmPriceList frm = new frmPriceList();
                if (Authenticate(frm, new string[] { "btnSave", "btnDelete" }))
                    frm.ShowDialog();
                else
                    itmPriceLists.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmFactory_Click(object sender, EventArgs e)
        {
            try
            {
                frmFactory obFactory = new frmFactory();
                if (Authenticate(obFactory, new string[] { "btnSave", "btnDelete" }))
                    obFactory.ShowDialog();
                else
                    itmFactory.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmCountry_Click(object sender, EventArgs e)
        {
            try
            {
                frmCountry obCountry = new frmCountry();
                if (Authenticate(obCountry, new string[] { "btnSaveCountry", "btnEditCountry", "btnDeleteCountry", "btnSaveCurrency", "btnEditCurrency", "btnDeleteCurrency" }))
                    obCountry.ShowDialog();
                else
                    itmCountry.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
 
            try
            {
                 // VarifyResistration();
                this.label1.BackColor = Color.Transparent;
                DialogResult dg = new frmLogIn().ShowDialog();
                if (dg == DialogResult.Cancel)
                {
                    DaUser objDaUser=new DaUser();
                    DaCompany objDaCompany=new DaCompany();
                    stlblUser.Text =((User) (objDaUser.getUser(LogInInfo.UserID)[0])).UserName;
                    stlblTime.Text = DateTime.Now.ToLongTimeString();
                    stLblDate.Text = DateTime.Today.ToShortDateString();
                    stLblCompany.Text= ((Company)(objDaCompany.getCompany(LogInInfo.CompanyID)[0])).CompanyName;
                    AuthenticateMenu();
                    label1.Text = ((Company)(objDaCompany.getCompany(LogInInfo.CompanyID)[0])).CompanyName;

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        //private void VarifyResistration()
        //{
        //    NameValueCollection configaration = ConfigurationSettings.AppSettings;
        //    string GivenKey = "";
        //    foreach (string keys in configaration.AllKeys)
        //    {
        //        if (keys == "RegKey") { GivenKey = configaration.Get(keys); break; }

        //    }
        //    string CosumerID = ResistationClass.GenerateMotherBoardSirialNo() + "-" + ResistationClass.GenerateProcessorID();
        //    if (ResistationClass.GenerateAuthorizationCode(CosumerID) != GivenKey)
        //    {
        //        frmResistrations fReg = new frmResistrations();
        //        fReg.IsOK = false;
        //        fReg.SerialNo = ResistationClass.GenerateAuthorizationCode(CosumerID);
        //        fReg.ConsumerID = CosumerID;
        //        fReg.ShowDialog();
        //        if (fReg.IsOK == false) this.Close();

        //    }
        //}
        private void itmLC_Click(object sender, EventArgs e)
        {
            try
            {
                frmLC objfrm = new frmLC();
                if (Authenticate(objfrm, new string[] { "btnSave", "btnAmend", "btnDelete" }))
                    objfrm.ShowDialog();
                else
                    itmLC.Enabled = false;
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmSalesInvoice_Click(object sender, EventArgs e)
        {
            try
            {
            frmSalesInvoice obfrmSalesInvoice = new frmSalesInvoice();
            if (Authenticate(obfrmSalesInvoice, new string[]{"btnSave","btnDelete"}))
                obfrmSalesInvoice.ShowDialog();
            else
                itmSalesInvoice.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmDebitVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                frmVouchers frmDebit = new frmVouchers();
                if (Authenticate(frmDebit, new string[] { "btnDrPost", "btnDrDelete" }))
                    frmDebit.ShowDialog(0);
                else
                    itmDebitVoucher.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void itmCreditVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                frmVouchers frmCredit = new frmVouchers();
                if (Authenticate(frmCredit, new string[] { "btnCrPost", "btnCrDelete" }))
                    frmCredit.ShowDialog(1);
                else
                    itmCreditVoucher.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmJournalVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                frmVouchers frmJournal = new frmVouchers();
                if (Authenticate(frmJournal, new string[] { "btnJrPost", "btnJrDelete" }))
                    frmJournal.ShowDialog(2);
                else
                    itmJournalVoucher.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmPurchaseInvoice_Click(object sender, EventArgs e)
        {
            try
            {
            frmPurchasesInvoice frmobj = new frmPurchasesInvoice();
            if (Authenticate(frmobj, new string[] { "btnSave", "btnDelete" }))
                frmobj.ShowDialog();
            else
                itmPurchaseInvoice.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmItemProperties_Click(object sender, EventArgs e)
        {
            try
            {
                frmBasicEntryScreen obBasicEntry = new frmBasicEntryScreen();
                if (Authenticate(obBasicEntry, new string[] { "btnColoresEdit", "btnSaveColors", "btnColoresDelete", "btnCountsEdit", "btnSaveCounts", "btnCountsDelete", "btnSizesEdit", "btnSaveSizes", "btnSizesdelete", "btnShadeEdit", "btnSaveShade", "btnShadedelete", "btnUnitsEdit", "btnSaveUnits", "btnUnitsDelete" }))
                    obBasicEntry.ShowDialog();
                else
                    itmItemProperties.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmStockInOut_Click(object sender, EventArgs e)
        {
            try
            {
                frmStockInOut frm = new frmStockInOut();
                if (Authenticate(frm, new string[] { "btnSave", "btnDelete" }))
                    frm.ShowDialog();
                else
                    itmStockInOut.Enabled = false;
            }
           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmRequisition_Click(object sender, EventArgs e)
        {
            try
            {
                frmInventoryRequisition obIRequisition = new frmInventoryRequisition();
                if (Authenticate(obIRequisition, new string[] { "btnSave", "btnDelete" }))
                obIRequisition.ShowDialog();
                else
                itmRequisition.Enabled=false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void itmCommercialDocs_Click(object sender, EventArgs e)
        {
            try
            {
                frmCommertialDocument frmobj = new frmCommertialDocument();
                if (Authenticate(frmobj, new string[] { "btnSave", "btnNew", "btnDelete" }))
                    frmobj.ShowDialog();
                else
                    itmCommercialDocs.Enabled = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void itmExportBill_Click(object sender, EventArgs e)
        {
            try
            {
                frmExportBill frm = new frmExportBill();
                if (Authenticate(frm, new string[] { "btnSave", "btnPost" }))
                    frm.ShowDialog();
                else
                    itmExportBills.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmPurchaseReturn_Click(object sender, EventArgs e)
        {
            try
            {
                frmPurchaseReturn objfrm = new frmPurchaseReturn();
                if (Authenticate(objfrm, new string[] { "btnSave", "btnDelete" }))
                    objfrm.ShowDialog();
                else
                    itmPurchaseReturn.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmBillReceivable_Click(object sender, EventArgs e)
        {
            try
            {
                frmBillReceivable frm = new frmBillReceivable();
                if (Authenticate(frm, new string[] { "btnPost", "btnDelete" }))
                    frm.ShowDialog();
                else
                    itmBillReceivable.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmSalesReturn_Click(object sender, EventArgs e)
        {
            try
            {
                frmSalesReturn obfrm = new frmSalesReturn();
                if (Authenticate(obfrm, new string[] { "btnSave", "btnDelete" }))
                    obfrm.ShowDialog();
                else
                    itmSalesReturn.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void importBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmImportBill().ShowDialog();
        }

        private void itmBillPayable_Click(object sender, EventArgs e)
        {
            try
            {
            frmBillsPayable frm = new frmBillsPayable();
            if (Authenticate(frm, new string[] { "btnPost", "btnDelete" }))
                frm.ShowDialog();
            else
                itmBillPayable.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmloan_Click(object sender, EventArgs e)
        {
            try
            {
                frmLoan objfrm = new frmLoan();
                if (Authenticate(objfrm, new string[] { "btnSaveUpdate", "btnNew", "btnDelete" }))
                    objfrm.ShowDialog();
                else
                    itmLoan.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void itmOPstock_Click(object sender, EventArgs e)
        {
            try
            {
                frmOpeningStock frm = new frmOpeningStock();
                if (Authenticate(frm, new string[] { "btnSave", "btnDelete" }))
                    new frmOpeningStock().ShowDialog();
                else
                    itmOPstock.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void itmLoanAdjust_Click(object sender, EventArgs e)
        {
            try
            {
                frmLoanPayment objfrm = new frmLoanPayment();
                if (Authenticate(objfrm, new string[] { "btnPost", "btnDelete" }))
                    objfrm.ShowDialog();
                else
                    itmLoanAdjust.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmAccReport_Click(object sender, EventArgs e)
        {

          frmReportParameter frm=  new frmReportParameter();
         
            frm.ShowDialog("pnlAccounting", "rbLedgerBook");
        }

        private void itmInventoryReport_Click(object sender, EventArgs e)
        {
            new frmReportParameter().ShowDialog("pnlInventory", "rbStockItemJournal");
        }

        private void itmSchedule_Click(object sender, EventArgs e)
        {
            //new frmReportParameter().ShowDialog("pnlSchedule", "rbMonthlyAttStatus");
        }

        private void itmFiscalYear_Click(object sender, EventArgs e)
        {
            try
            {
                //frmFiscalYear frm = new frmFiscalYear();
                //if (Authenticate(frm, new string[] { "btnSave", "btnDelete" }))
                //    frm.ShowDialog();
                //else
                //    itmFiscalYear.Enabled = false;
                frmStartFiscalYear frm = new frmStartFiscalYear();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmSection_Click(object sender, EventArgs e)
        {
            try
            {
                frmSection frm = new frmSection();
                if (Authenticate(frm, new string[] { "btnSave", "btnDelete" }))
                    frm.ShowDialog();
                else
                    itmSection.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void itmBranch_Click(object sender, EventArgs e)
        {
            try
            {
                frmBranch frmBranch = new frmBranch();
                if (Authenticate(frmBranch, new string[] { "btnSave", "btnDelete" }))
                    frmBranch.ShowDialog();
                else
                    itmBranch.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmDept_Click(object sender, EventArgs e)
        {
            try
            {
                frmDepartment frmdep = new frmDepartment();
                if (Authenticate(frmdep, new string[] { "btnSave", "btnDelete" }))
                    frmdep.ShowDialog();
                else
                    itmDept.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void itmLogOff_Click(object sender, EventArgs e)
        {
            frmMain_Load(sender, e);
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            //try
            //{
            //    FormColorClass.ColorForm(this, e);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void itmCompany_Click(object sender, EventArgs e)
        {
            try
            {
                frmCompanies frm = new frmCompanies();
                if (Authenticate(frm, new string[] { "btnNew", "btnEdit", "btnDelete" }))
                    frm.ShowDialog();
                else
                    itmCompany.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmCommReport_Click(object sender, EventArgs e)
        {
            new frmReportParameter().ShowDialog("pnlCommDocs", "rbPI");
        }

        private void itmUsers_Click(object sender, EventArgs e)
        {
            try
            {
                frmUser frmU = new frmUser();
                if (Authenticate(frmU, new string[] { "btnNew", "btnEdit", "btnDelete" }))
                    frmU.ShowDialog();
                else
                    itmUsers.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmBusinessType_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusinessTypes frm = new frmBusinessTypes();
                if (Authenticate(frm, new string[] { "btnEdit", "btnNew", "btnDelete" }))
                    frm.ShowDialog();
                else
                    itmBusinessType.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmBusinessSubType_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusinessSubTypes frm = new frmBusinessSubTypes();
                if (Authenticate(frm, new string[] { "btnEdit", "btnNew", "btnDelete" }))
                    frm.ShowDialog();
                else
                    itmBusinessSubType.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmSalesReport_Click(object sender, EventArgs e)
        {
            new frmReportParameter().ShowDialog("pnlSales", "rbSalesLedger");
        }

        private void itmPurchaseReport_Click(object sender, EventArgs e)
        {
            new frmReportParameter().ShowDialog("pnlPurchase", "rbPurchaseLedger");
        }

        private void itmVoucherRegister_Click(object sender, EventArgs e)
        {
            try
            {
                frmVoucherRegister frmVReg = new frmVoucherRegister();
                if (Authenticate(frmVReg, new string[] { "btnEdit" }))
                    frmVReg.ShowDialog();
                else
                {
                    itmVoucherRegister.Enabled = false;
                    return;
                }
                int VTid = frmVReg.SelectedVoucherTypeID;
                int TMID = frmVReg.SelectedTransactionID;
                bool isE = frmVReg.IsEditable;
                if (VTid == 0 && TMID == 0) return;
                new frmVouchers().ShowDialog(VTid, TMID, isE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        #region Authentication
        private bool Authenticate(Form frm, string[] btnNames)
        {
            try
            {

                _objAuthentication = new Authentication(frm.Name);
                if (!_objAuthentication.CanView)
                    return false;

                //if (btnNames[0] != "") frm.Controls.Find(btnNames[0], true)[0].Visible = _objAuthentication.CanEdit;
                //if (btnNames[1] != "") frm.Controls.Find(btnNames[1], true)[0].Visible = _objAuthentication.CanAdd;
                //if (btnNames[2] != "") frm.Controls.Find(btnNames[2], true)[0].Visible = _objAuthentication.CanDelete;
                //if (btnNames[3] != "") frm.Controls.Find(btnNames[3], true)[0].Visible = _objAuthentication.CanEdit;

                //if (btnNames[0] != "") frm.Controls.Find(btnNames[0], true)[0].Enabled = _objAuthentication.CanEdit;
                //if (btnNames[1] != "") frm.Controls.Find(btnNames[1], true)[0].Enabled = _objAuthentication.CanAdd;
                //if (btnNames[2] != "") frm.Controls.Find(btnNames[2], true)[0].Enabled = _objAuthentication.CanDelete;
                //if (btnNames[3] != "") frm.Controls.Find(btnNames[3], true)[0].Enabled = _objAuthentication.CanEdit;

                for (int i = 0; i < btnNames.Length; i++)
                {
                    if (btnNames[i] == "") continue;
                    if(btnNames[i].ToLower().Contains("edit"))
                        frm.Controls.Find(btnNames[i], true)[0].Enabled = _objAuthentication.CanEdit;
                    if (btnNames[i].ToLower().Contains("post"))
                        frm.Controls.Find(btnNames[i], true)[0].Enabled = _objAuthentication.CanEdit && _objAuthentication.CanAdd;
                    if (btnNames[i].ToLower().Contains("amend"))
                        frm.Controls.Find(btnNames[i], true)[0].Enabled = _objAuthentication.CanEdit && _objAuthentication.CanAdd;
                    if (btnNames[i].ToLower().Contains("save"))
                        frm.Controls.Find(btnNames[i], true)[0].Enabled = _objAuthentication.CanAdd;
                    if (btnNames[i].ToLower().Contains("add"))
                        frm.Controls.Find(btnNames[i], true)[0].Enabled = _objAuthentication.CanAdd;
                    if (btnNames[i].ToLower().Contains("new"))
                        frm.Controls.Find(btnNames[i], true)[0].Enabled = _objAuthentication.CanAdd;
                    if (btnNames[i].ToLower().Contains("delete"))
                        frm.Controls.Find(btnNames[i], true)[0].Enabled = _objAuthentication.CanDelete;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        private bool AuthenticateView(Form frm)
        {
            try
            {

                _objAuthentication = new Authentication(frm.Name);
                if (!_objAuthentication.CanView)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                //new ExceptionAgent(ex).SaveError();
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        private bool AuthenticateEdit(Form frm)
        {
            try
            {

                _objAuthentication = new Authentication(frm.Name);
                if (!_objAuthentication.CanEdit)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                //new ExceptionAgent(ex).SaveError();
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        private void AuthenticateMenu()
        {
            #region If DB is not consistant
            //*******If DB is not consistant
            //ArrayList list=_objModulesBO.getMenuName("all");
            //int Count=0;
            //string msg="";
            //foreach (string mnuItemName in list)
            //{
            //    ToolStripItem[] MenuItem=menuStrip1.Items.Find(mnuItemName.Trim(),true);
            //    if (MenuItem.Length > 0)
            //        MenuItem[0].Enabled = HasAnyPrivilege(mnuItemName);
            //    else
            //    {
            //        Count++;
            //        msg += mnuItemName+",";
            //    }
            //}
            //MessageBox.Show(Count.ToString() + ":" + msg);
            #endregion
            //**********If DB is Consistant
            _list = obDaUserPrivilege.getUserPrivileges("all");
            foreach (ToolStripMenuItem mnuItem in MenuBar.Items)
            {
                RecurciveAuthenticateMenu(mnuItem);
            }
            MenuBar.Items.Find("itmLogOff", true)[0].Enabled = true;
            MenuBar.Items.Find("itmExit", true)[0].Enabled = true;
            MenuBar.Items.Find("mnuHelp", true)[0].Enabled = true;
            MenuBar.Items.Find("itmBackup", true)[0].Enabled = true;

        }
        private void RecurciveAuthenticateMenu(ToolStripMenuItem ParentMenuItem)
        {

            if (ParentMenuItem.DropDownItems.Count > 0)
                foreach (ToolStripMenuItem mnuItem in ParentMenuItem.DropDownItems)
                {
                    RecurciveAuthenticateMenu(mnuItem);
                }
            //*******This Code is Only for All ,UnComment if "HasAnyPrivilege" is in use *****
            //
            //ParentMenuItem.Enabled = HasPrivilege(ParentMenuItem.Name);
            //
            //*******This Code is Only for All ,UnComment if "HasAnyPrivilege" is in use *****


            //*******This Code is Only for Modules,Comment if "HasAnyPrivilege" is in use *****
            if (ParentMenuItem.Name.Substring(0, 3) == "itm")
                ParentMenuItem.Enabled = HasPrivilege(ParentMenuItem.Name);
            //*******This Code is Only for Modules,Comment if "HasAnyPrivilege" is in use *****

        }
        private bool HasAnyPrivilege(string strMenuName)
        {
            /* string strMenuname=strMenuName.Trim();
             try
             {
                 if (_objModulesBO.IsModule(strMenuname))
                 {
                     if (_UserPrivilegeBO.getUserPrivilege(strMenuname) > 0)
                         return true;
                     else return false;
                 }
                 else
                 {
                     ArrayList list = _objModulesBO.getChildModules(strMenuname);
                     foreach (ERP.Entity.Modules objModules in list)
                     {
                         if (HasAnyPrivilege(objModules.MenuName))
                             return true;
                     }
                 }
             }
             catch (Exception ex)
             {
                 new ExceptionAgent(ex).SaveError();
                 MessageBox.Show(ex.Message);
             }*/
            return true;
        }
        private bool HasPrivilege(string strMenuName)
        {
            try
            {
                //if (_UserPrivilegeBO.getUserPrivilege(strMenuName.Trim()) > 0)
                //    return true;     
                foreach (ModuleDictionary objModuleDictionary in _list)
                    if (objModuleDictionary.MenuName.Trim() == strMenuName.Trim())
                    {
                        if (objModuleDictionary.TotalPrivilege > 0)
                            return true;
                        else return false;
                    }
            }
            catch (Exception ex)
            {
                //new ExceptionAgent(ex).SaveError();
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        #endregion

        private void MenuBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void itmDesignation_Click(object sender, EventArgs e)
        {
            try
            {
                frmDesignations frm = new frmDesignations();
                if (Authenticate(frm, new string[] { "btnEdit", "btnNew", "btnDelete" }))
                    frm.ShowDialog();
                else
                    itmDesignation.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void itmSettings_Click(object sender, EventArgs e)
        {
            
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                new frmRefNoSettings().ShowDialog();
            }
        }

        private void itmAssetSchdl_Click(object sender, EventArgs e)
        {
            new frmAssetSchedule().ShowDialog();
        }

        private void itmSchdlReport_Click(object sender, EventArgs e)
        {
           
          

            new frmReportParameter().ShowDialog("pnlSchedule", "rbCash");
        }

       

        

        private void itmForwardLetter_Click(object sender, EventArgs e)
        {
            frmForwardingLetter frm = new frmForwardingLetter();
            frm.ShowDialog();
        }

        private void itmSettings_Click_1(object sender, EventArgs e)
        {
            frmCompanySettings frm = new frmCompanySettings();
            frm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void itmBackup_Click(object sender, EventArgs e)
        {
            new frmBackup().ShowDialog();
        }
/*
        private void ctlDaraGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
         
        }

        private double getResult(string exp)
        {
            try
            {
                SqlConnection con = ConnectionHelper.getConnection();
                SqlCommand cmd = new SqlCommand("SELECT " + exp + " ", con);
                object obj = cmd.ExecuteScalar();
                return GlobalFunctions.isNull(obj, 0.0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ctlDaraGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ctlDaraGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           
        }*/
    }
}
