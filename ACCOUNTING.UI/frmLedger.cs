

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.DataAccess;
using System.Data.SqlClient;
using Accounting.Utility;
using Accounting.Entity;

namespace Accounting.UI
{
    public partial class frmLedger : Form
    {
        public frmLedger()
        {
            InitializeComponent();
        }

        CurrencyManager cmGridPointer = null;
        DataTable dtGridData = null;
        #region Combo Load
        private void loadLedgerTypes()
        {
            try
            {
                DataTable dt=new DaLedgerType().getLedgerType(formConnection);
                cboLedgerType.DataSource = dt;
                cboLedgerType.ValueMember = "LedgerTypeID";
                cboLedgerType.DisplayMember = "LedgerType";
                cboSearchBy.DataSource = dt;
                cboSearchBy.ValueMember = "LedgerTypeID";
                cboSearchBy.DisplayMember="LedgerType";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void loadSearchBy()
        {
            try
            {
                DataTable dt = new DaLedgerType().getLedgerType(formConnection);
               
                cboSearchBy.DataSource = dt;
                cboSearchBy.ValueMember = "LedgerTypeID";
                cboSearchBy.DisplayMember = "LedgerType";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadParentAccounts()
        {
            try
            {
                cboParentLedger.DataSource = new DaAccount().getAccountHeads(formConnection);
                cboParentLedger.ValueMember = "AccountID";
                cboParentLedger.DisplayMember = "AccountTitle";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadCountry()
        {
            try
            {
                cboCountry.DataSource = new DaCountry().getCountry(formConnection);
                cboCountry.ValueMember = "CountryID";
                cboCountry.DisplayMember = "CountryName";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadCurrency()
        {
            try
            {
                cboCurrency.DataSource = new DaCurrency().getCurrency(formConnection);
                cboCurrency.ValueMember = "CurrencyID";
                cboCurrency.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadTeam()
        {
            try
            {
                DataTable dt = new DaTeam().loadMaster(formConnection);
                dt.Rows.Add(-1, "","Independant");
                cboTeam.DataSource = dt;
                cboTeam.ValueMember = "TeamID";
                cboTeam.DisplayMember = "TeamName";
                cboTeam.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadTeamMember(int teamID)
        {
            try
            {
                cboMember.DataSource = new DaTeam().loadDetail(formConnection,teamID);
                cboMember.ValueMember = "MemberID";
                cboMember.DisplayMember = "MemberName";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        SqlConnection formConnection = null;
        private void frmLedger_Load(object sender, EventArgs e)
        {
            try
            {
                formConnection = ConnectionHelper.getConnection();
                loadLedgerTypes();
                
                loadParentAccounts();
                cboAccOrGroup.SelectedIndex = 0;
                cboAccStatus.SelectedIndex = 0;
                cboAcType.SelectedIndex = 0;
                loadCountry();
                loadCurrency();
                loadTeam();
                loadSearchBy();
                cboType.SelectedIndex = 0;
                //loadTeamMember((int)cboTeam.SelectedValue);
                //cboAccOrGroup_SelectedValueChanged(null, null);
                treeLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkInChartOfAcc_CheckedChanged(object sender, EventArgs e)
        {
            bool state = chkInChartOfAcc.Checked;
            flpParentLedger.Visible = state;
            flpAccOrGroup.Visible = state;
            //cboAccOrGroup_SelectedIndexChanged(null, null);
            

            if (cboAccOrGroup.SelectedItem.ToString() == "Account")
            {
                flpBalance.Visible = state;
                flpInventoryStatus.Visible = state;
                flpLedgerNo.Visible = state;
               
            }
           
           
            
            //if (state == false)
            //    ctlDgvAccountLedger.Height = ctlDgvAccountLedger.Height +nC*27;
            //else
            //    ctlDgvAccountLedger.Height = ctlDgvAccountLedger.Height - nC*27;  

            ctlDgvAccountLedger.Height = flpContainer.Bottom - ctlDgvAccountLedger.Top-10;
        }

        private void chkDetail_CheckedChanged(object sender, EventArgs e)
        {
            bool state = chkDetail.Checked;
            flpAddress.Visible = state;
            flpBankAccType.Visible = state;
            flpContactPerson.Visible = state;
            flpCountry.Visible = state;
            flpCurrency.Visible = state;
            flpEmail.Visible = state;
            flpFax.Visible = state;
            flpPhone.Visible = state;
            flpBusinessType.Visible = state;
            flpRemarks.Visible = state;
            flpTeam.Visible = state;
            //if (state == false)
            //    ctlDgvAccountLedger.Height = ctlDgvAccountLedger.Height + 5*27;
            //else
            //    ctlDgvAccountLedger.Height = ctlDgvAccountLedger.Height - 5*27;  
            ctlDgvAccountLedger.Height = flpContainer.Bottom - ctlDgvAccountLedger.Top - 10;
        }

        private void cbo_Enter(object sender, EventArgs e)
        {

            SendKeys.Send("{F4}");
          
        }

        private void Ctl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            SelectNextControl((Control)sender,true,true, true, true);
        }

       

        private void txt_Enter(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.BackColor = Color.Black;
            c.ForeColor = Color.White;
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.BackColor = Color.White;
            c.ForeColor = Color.Black;
        }

        private void chk_Enter(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.ForeColor = Color.Blue;
        }

        private void chk_Leave(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.ForeColor = Color.Black;
        }

        private void cboTeam_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboTeam.SelectedValue == null || cboTeam.SelectedValue.GetType()==typeof(DataRowView)) return;
            if ((int)cboTeam.SelectedValue == -1) cboMember.Enabled = false; else cboMember.Enabled = true;
            loadTeamMember((int)cboTeam.SelectedValue);
        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                #region Comment
                //if (cboSearchBy.SelectedItem.ToString() == "Sub Ledger")
                //{
                //    ctlDgvAccountLedger.DataSource = new DaAccount().getAccountHeads(formConnection);
                //    ctlDgvAccountLedger.setColumnsVisible(false, "AccountID", "AccountNo", "AccOrGroup", "AccDepth", "AccountStatus", "OpeningBalance","CurrentBalance","IsInventoryRelated","LedgerID","CompanyID","UserID","ModifiedDate");
                //}
                //else if (cboSearchBy.SelectedItem.ToString() == "Account")
                //{
                //    ctlDgvAccountLedger.DataSource = new DaAccount().GetAccounts(formConnection);
                //    ctlDgvAccountLedger.setColumnsVisible(false, "AccountID", "AccOrGroup", "AccDepth", "LedgerID", "CompanyID", "UserID", "ModifiedDate");
                //}
                //else if (cboSearchBy.SelectedItem.ToString() == "Account and Sub Ledger")
                //{
                //    ctlDgvAccountLedger.DataSource = new DaAccount().GetAllAccounts(formConnection);
                //    ctlDgvAccountLedger.setColumnsVisible(false, "AccountID",  "AccDepth", "AccountStatus", "OpeningBalance", "CurrentBalance", "IsInventoryRelated", "LedgerID", "CompanyID", "UserID", "ModifiedDate");
                //}
                //else if (cboSearchBy.SelectedItem.ToString() == "Customer")
                //{
                //    ctlDgvAccountLedger.DataSource = new DaLedger().GetLadgers(formConnection, 2);
                //    ctlDgvAccountLedger.setColumnsVisible(false, "LedgerID", "LedgerTypeID","BankAccType" ,"CompanyID", "UserID", "ModifiedDate");
                //}
                //else if (cboSearchBy.SelectedItem.ToString() == "Supplier")
                //{
                //    ctlDgvAccountLedger.DataSource = new DaLedger().GetLadgers(formConnection, 3);
                //    ctlDgvAccountLedger.setColumnsVisible(false, "LedgerID", "LedgerTypeID","BankAccType", "CompanyID", "UserID", "ModifiedDate");
                //}
                //else if (cboSearchBy.SelectedItem.ToString() == "Bank")
                //{
                //    ctlDgvAccountLedger.DataSource = new DaLedger().GetLadgers(formConnection, 4);
                //    ctlDgvAccountLedger.setColumnsVisible(false, "LedgerID", "LedgerTypeID", "CompanyID", "UserID", "ModifiedDate");
                //}
                #endregion

                int pos = cmGridPointer==null?0:cmGridPointer.Position;
                dtGridData = new DaAccount().getAccountsLedgers(formConnection, cboType.SelectedItem.ToString(), (int)cboSearchBy.SelectedValue,txtSrcTitle.Text.Trim());
                cmGridPointer = (CurrencyManager)this.BindingContext[dtGridData];

                
                if (ctlDgvAccountLedger.Columns.Count > 0) ctlDgvAccountLedger.Columns.Clear();
                ctlDgvAccountLedger.DataSource = dtGridData;
                ctlDgvAccountLedger.Tag = cboType.SelectedItem.ToString();
                if (cboType.SelectedItem.ToString() == "Account")
                {
                    ctlDgvAccountLedger.setColumnsVisible(false, "AccountID", "LedgerID","ParentID");
                    ctlDgvAccountLedger.setColumnsFormat(new string[] { "OpeningBalance", "CurrentBalance" }, "0.00", "0.00");
                    ctlDgvAccountLedger.Columns["OpeningBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    ctlDgvAccountLedger.Columns["CurrentBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                {
                    ctlDgvAccountLedger.setColumnsVisible(false, "AccountID", "LedgerID");
                }
                cmGridPointer.Position = pos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private Account CreateAccountObject(int LdgrID)
        {
            Account objAcc = null;
            try
            {
                DataRowView drv=(DataRowView)cboParentLedger.SelectedItem;
                objAcc = new Account();
                objAcc.AccountID = int.Parse(lblAccountID.Text);
                objAcc.AccountNo = txtLedgerNo.Text;
                objAcc.AccountTitle = txtLedgerTitle.Text.Trim();
                objAcc.AccountOrGroup = cboAccOrGroup.SelectedItem.ToString() == "Account" ? "Account" : "Group";

                if (cboAccOrGroup.SelectedItem.ToString() == "Account")
                {
                    objAcc.AccountCreateDate = dtpCreateDate.Value.Date;
                    objAcc.AccountStatus = cboAccStatus.SelectedItem.ToString();
                    objAcc.OpeningBalance = double.Parse(txtOpBal.Text.Trim());
                    objAcc.IsInventoryRelated = chkInvRel.Checked ? 1 : 0;
                }
                else
                {
                    objAcc.AccountCreateDate = DateTime.Now.Date;
                    objAcc.AccountStatus = "Active";
                    objAcc.OpeningBalance = 0;
                    objAcc.IsInventoryRelated =  0;
                }
                objAcc.LedgerTypeID = (int)cboLedgerType.SelectedValue;
                objAcc.AccountDepth = drv.Row.Field<int>("AccDepth")+1;
                objAcc.AccountNature = drv.Row.Field<int>("Nature") ;
                
                objAcc.ParentID =(int) cboParentLedger.SelectedValue;
                
                objAcc.LedgerID = LdgrID;
                //objAcc.CompanyID = DBNull.Value;
                //objAcc.UserID = DBNull.Value;
                //objAcc.ModifiedDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objAcc;
        }

        private Ledgers CreateLedgerObject()
        {
            Ledgers objLdgr = null;
            try
            {
                objLdgr = new Ledgers();
                objLdgr.LedgerID = int.Parse(lblLedgerID.Text);
                objLdgr.LedgerName = txtLedgerTitle.Text.Trim();
                objLdgr.LedgerTypeID = (int)cboLedgerType.SelectedValue;
                objLdgr.Address = txtAddress.Text.Trim();
                objLdgr.CountryID =(int) cboCountry.SelectedValue;
                objLdgr.CurrencyID = (int)cboCurrency.SelectedValue;
                objLdgr.ContactPerson = txtContactPerson.Text.Trim();
                if (flpBankAccType.Enabled == false)
                    objLdgr.BankAccountType = "NULL";
                else
                    objLdgr.BankAccountType = cboAcType.SelectedItem.ToString();
                objLdgr.BusinessType = txtBusinessType.Text.Trim();
                objLdgr.Phone = txtPhone.Text.Trim();
                objLdgr.Fax = txtFax.Text.Trim();
                objLdgr.Email = txtEmail.Text.Trim();
                if (flpTeam.Enabled == false)
                    objLdgr.TeamMemberID = -1;
                else if ((int)cboTeam.SelectedValue==-1)
                    objLdgr.TeamMemberID = -1;
                else
                    objLdgr.TeamMemberID = (int)cboMember.SelectedValue;
                objLdgr.Remarks = txtRemarks.Text.Trim();
                objLdgr.AccountID = -1;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objLdgr;
        }
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;
            try
            {
                string err = InputValidation();

                if (err != string.Empty)
                {
                    MessageBox.Show(err);
                    return;
                }

                bool msgFlag = false;
                int LdgrID=-1,AccID=-1;
                trans = formConnection.BeginTransaction();
                if (chkDetail.Checked)
                {
                    Ledgers objLedger = CreateLedgerObject();
                    LdgrID = new DaLedger().InsertUpdateLedger(objLedger, formConnection, trans);
                    msgFlag = true;
                }
                else
                {
                    int lID=int.Parse(lblLedgerID.Text);
                    if (lID > 0)
                        new DaLedger().DeleteLedger(lID, formConnection,trans);
                }

                if (chkInChartOfAcc.Checked)
                {
                    Account objAccount = CreateAccountObject(LdgrID);
                    AccID = new DaAccount().InsertUpdateAccount(objAccount, formConnection, trans);
                    msgFlag = true;
                }
                else
                {
                    int aID = int.Parse(lblAccountID.Text);
                    if (aID > 0)
                        new DaAccount().DeleteAccount(aID, formConnection, trans);
                }
                new DaLedger().UpdateAccountID(formConnection, trans, LdgrID, AccID);
                new DaAccount().UpdateLedgerID(formConnection, trans, AccID, LdgrID);

                trans.Commit();
                if (msgFlag == true)
                {
                    btnNew_Click(null, null);
                    btnSearch_Click(null, null);
                    MessageBox.Show("Saved successfully");
                }
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                if (ex.Message.Contains("duplicate"))
                    MessageBox.Show("This same type ledger or account already exists" + Environment.NewLine + "Please choose a different one.", "Chart Of Account");
                else
                    MessageBox.Show(ex.Message);
            }
        }

        private void cboParentLedger_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboParentLedger.SelectedValue == null || cboParentLedger.SelectedValue.GetType() == typeof(DataRowView)) return;
                txtLedgerNo.Text = new DaAccount().GenerateAccountNo(formConnection,(int)cboParentLedger.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboAccOrGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboAccOrGroup.SelectedItem.ToString() == "Account")
            {

                flpBalance.Visible = true;
                flpLedgerNo.Visible = true;
                flpInventoryStatus.Visible = true;
                //ctlDgvAccountLedger.Height = ctlDgvAccountLedger.Height - 2 * 27;
            }
            else
            {
                flpBalance.Visible = false;
                flpLedgerNo.Visible = false;
                flpInventoryStatus.Visible = false;
                //ctlDgvAccountLedger.Height = ctlDgvAccountLedger.Height + 2 * 27;
            }
            ctlDgvAccountLedger.Height = flpContainer.Bottom - ctlDgvAccountLedger.Top - 10;
        }

        private void ctlDgvAccountLedger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowID ;
                int AccID, LdgrID;
                Account objAccount = null;
                Ledgers objLedger = null;
                
                if (sender.Equals(tvAccounts))
                    rowID = 0;
                else
                    rowID = e.RowIndex;
                if (rowID < 0) return;
                if (ctlDgvAccountLedger.Tag==null|| ctlDgvAccountLedger.Tag.ToString() == "Account")
                {
                    //if (IsNullOrEmpty(rowID, "ParentID"))

                    if(isDefaultChartOfAccounts(sender.Equals(tvAccounts)?tvAccounts.SelectedNode.Text:ctlDgvAccountLedger.Rows[rowID].Cells["AccountTitle"].Value.ToString())==true)
                    {
                        MessageBox.Show("Not Editable");
                        return;
                    }

                    if (sender.Equals(tvAccounts))
                        AccID = Convert.ToInt32(tvAccounts.SelectedNode.Name);
                    else
                        AccID = (int)ctlDgvAccountLedger.Rows[rowID].Cells["AccountID"].Value; 
                    objAccount = new DaAccount().GetAccount(formConnection, AccID);

                    lblAccountID.Text = objAccount.AccountID.ToString();
                    txtLedgerTitle.Text = objAccount.AccountTitle;
                    cboLedgerType.SelectedValue = objAccount.LedgerTypeID;
                    chkInChartOfAcc.Checked = true;
                    cboParentLedger.SelectedValue = objAccount.ParentID;

                    if (objAccount.AccountOrGroup == "Account")
                        cboAccOrGroup.SelectedItem = "Account";
                    else
                        cboAccOrGroup.SelectedItem = "Sub Ledger";
                    txtOpBal.Text = objAccount.OpeningBalance.ToString("0.00");
                    txtCurBal.Text = objAccount.CurrentBalance.ToString("0.00");
                    txtLedgerNo.Text = objAccount.AccountNo;
                    chkInvRel.Checked = objAccount.IsInventoryRelated == 1 ? true : false;
                    dtpCreateDate.Value = objAccount.AccountCreateDate.Date;

                    if (objAccount.LedgerID == -1)
                    {
                        chkDetail.Checked = false;
                        lblLedgerID.Text = "0";
                    }
                    else
                    {
                        chkDetail.Checked = true;
                        objLedger = new DaLedger().GetLedger(formConnection, objAccount.LedgerID);
                        if (objLedger == null) return;
                        lblLedgerID.Text = objLedger.LedgerID.ToString();
                        txtContactPerson.Text = objLedger.ContactPerson;
                        cboAcType.SelectedItem = objLedger.BankAccountType;
                        txtAddress.Text = objLedger.Address;
                        txtBusinessType.Text = objLedger.BusinessType;
                        txtPhone.Text = objLedger.Phone;
                        txtFax.Text = objLedger.Fax;
                        txtEmail.Text = objLedger.Email;
                        cboCountry.SelectedValue = objLedger.CountryID;
                        cboCurrency.SelectedValue = objLedger.CurrencyID;
                        if (objLedger.TeamMemberID == -1) cboTeam.SelectedValue = -1;
                        else
                        {
                            TeamDetail objSalesTeam = new DaTeam().getTeamMember(formConnection, objLedger.TeamMemberID);
                            if (objSalesTeam != null)
                            {
                                cboTeam.SelectedValue = objSalesTeam.intTeamID;
                                cboMember.SelectedValue = objLedger.TeamMemberID;
                            }
                        }

                    }
                }
                else
                {
                    LdgrID = (int)ctlDgvAccountLedger.Rows[rowID].Cells["LedgerID"].Value;
                    chkDetail.Checked = true;
                    objLedger = new DaLedger().GetLedger(formConnection, LdgrID);
                    if (objLedger == null) return;
                    lblLedgerID.Text = objLedger.LedgerID.ToString();
                    txtContactPerson.Text = objLedger.ContactPerson;
                    cboAcType.SelectedItem = objLedger.BankAccountType;
                    txtAddress.Text = objLedger.Address;
                    txtPhone.Text = objLedger.Phone;
                    txtFax.Text = objLedger.Fax;
                    txtEmail.Text = objLedger.Email;
                    txtBusinessType.Text = objLedger.BusinessType;
                    cboCountry.SelectedValue = objLedger.CountryID;
                    cboCurrency.SelectedValue = objLedger.CurrencyID;
                    if (objLedger.TeamMemberID == -1) cboTeam.SelectedValue = -1;
                    else
                    {
                        TeamDetail objSalesTeam = new DaTeam().getTeamMember(formConnection, objLedger.TeamMemberID);
                        if (objSalesTeam != null)
                        {
                            cboTeam.SelectedValue = objSalesTeam.intTeamID;
                            cboMember.SelectedValue = objLedger.TeamMemberID;
                        }
                    }
                    if (objLedger.AccountID == -1)
                    {
                        chkInChartOfAcc.Checked = false;
                        txtLedgerTitle.Text = objLedger.LedgerName;
                        cboLedgerType.SelectedValue = objLedger.LedgerTypeID;
                        lblAccountID.Text = "0";
                    }

                    else
                    {
                        chkInChartOfAcc.Checked = true;


                        objAccount = new DaAccount().GetAccount(formConnection, objLedger.AccountID);

                        lblAccountID.Text = objAccount.AccountID.ToString();
                        txtLedgerTitle.Text = objAccount.AccountTitle;
                        cboLedgerType.SelectedValue = objAccount.LedgerTypeID;

                        cboParentLedger.SelectedValue = objAccount.ParentID;

                        if (objAccount.AccountOrGroup == "Account")
                            cboAccOrGroup.SelectedItem = "Account";
                        else
                            cboAccOrGroup.SelectedItem = "Sub Ledger";
                        txtOpBal.Text = objAccount.OpeningBalance.ToString("0.00");
                        txtCurBal.Text = objAccount.CurrentBalance.ToString("0.00");
                        txtLedgerNo.Text = objAccount.AccountNo;
                        chkInvRel.Checked = objAccount.IsInventoryRelated == 1 ? true : false;
                        dtpCreateDate.Value = objAccount.AccountCreateDate.Date;
                        
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool isDefaultChartOfAccounts(string Acc)
        {
            string[] strGroups = new string[]{"Current Assets", "Cash","Sundry Debtors","Bills Receivable","Bank Account","Advance Payment",
                                            "Stock & Store", "Fixed Assets","Current Liabilities","Sundry Creditors","Advanced Received","Bank Loan",
                                            "Bills Payable","Branch/Divisions","Accrued Payable","Accrued Receivable","Long Term Liabilities","Capital","Income","Sales Account","Other Income Account","Expense",
                                            "Production Overhead","Administrative Overhead","Financial Expense","Selling Expense","Purchase Account"     };

            string[] strAccs = new string[] { "Cash in hand", /*"Petty Cash",*/ "Stock of Finished Goods", "Stock of Raw Materials", "Raw Materials Purchase", "Finished Goods Purchase", "Export Sales", "Local Sales", "Depreciation", "Work In Progress", "Profit and Loss Appropriation" };

            txtLedgerTitle.Enabled = true;
            cboParentLedger.Enabled = true;
            cboAccOrGroup.Enabled = true;

            for (int i = 0; i < strAccs.Length; i++)
            {

                if (Acc == strAccs[i])
                {
                    txtLedgerTitle.Enabled = false;
                    cboParentLedger.Enabled = false;
                    cboAccOrGroup.Enabled = false;
                    break;
                }
            }
            for (int i = 0; i < strGroups.Length; i++)
            {
                if (strGroups[i] == Acc)
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsNullOrEmpty(int rowID, string ColName)
        {
            if (ctlDgvAccountLedger.Rows[rowID].Cells[ColName].Value == null || ctlDgvAccountLedger.Rows[rowID].Cells[ColName].Value.ToString().Trim()=="")
                return true;
            else
                return false;
        }

        private void cboLedgerType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboLedgerType.SelectedValue == null || cboLedgerType.SelectedValue.GetType() == typeof(DataRowView)) return;
                if ((int)cboLedgerType.SelectedValue == 1)  //General 
                {
                    flpContactPerson.Enabled = true;
                    flpBankAccType.Enabled = false;
                    flpAddress.Enabled = true;
                    flpPhone.Enabled = true;
                    flpFax.Enabled = true;
                    flpEmail.Enabled = true;
                    flpCountry.Enabled = true;
                    flpCurrency.Enabled = true;
                    flpBusinessType.Enabled = true;
                    flpRemarks.Enabled = true;
                    flpTeam.Enabled = false;
                    lblContact.Text = "Contact Person";
                    lblBusiness.Text = "Business Type";
                }
                else if ((int)cboLedgerType.SelectedValue == 2)  //customer
                {
                    flpContactPerson.Enabled = true;
                    flpBankAccType.Enabled = false;
                    flpAddress.Enabled = true;
                    flpPhone.Enabled = true;
                    flpFax.Enabled = true;
                    flpEmail.Enabled = true;
                    flpCountry.Enabled = true;
                    flpCurrency.Enabled = true;
                    flpBusinessType.Enabled = true;
                    flpRemarks.Enabled = true;
                    flpTeam.Enabled = true;
                    lblContact.Text = "Contact Person";
                    lblBusiness.Text = "Business Type";
                    
                }
                else if ((int)cboLedgerType.SelectedValue == 3)  // Supplier
                {
                    flpContactPerson.Enabled = true;
                    flpBankAccType.Enabled = false;
                    flpAddress.Enabled = true;
                    flpPhone.Enabled = true;
                    flpFax.Enabled = true;
                    flpEmail.Enabled = true;
                    flpCountry.Enabled = true;
                    flpCurrency.Enabled = true;
                    flpBusinessType.Enabled = true;
                    flpRemarks.Enabled = true;
                    flpTeam.Enabled = false;
                    lblContact.Text = "Contact Person";
                    lblBusiness.Text = "Business Type";

                }
                else if ((int)cboLedgerType.SelectedValue == 4)  // Bank
                {
                    flpContactPerson.Enabled = true;
                    flpBankAccType.Enabled = true;
                    flpAddress.Enabled = true;
                    flpPhone.Enabled = true;
                    flpFax.Enabled = true;
                    flpEmail.Enabled = true;
                    flpCountry.Enabled = true;
                    flpCurrency.Enabled = true;
                    flpBusinessType.Enabled = true;
                    flpRemarks.Enabled = true;
                    flpTeam.Enabled = false;
                    lblContact.Text = "A/C Holder";
                    lblBusiness.Text = "Branch";
                   
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            try
            {
                lblAccountID.Text = "0";
                lblLedgerID.Text = "0";
                txtLedgerTitle.Text = string.Empty;
                txtOpBal.Text = string.Empty;
                txtCurBal.Text = string.Empty;
                chkInvRel.Checked = false;
                cboAccStatus.SelectedItem = "Active";

                txtContactPerson.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtBusinessType.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtFax.Text = string.Empty;
                txtLedgerNo.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtRemarks.Text = string.Empty;

                loadParentAccounts();
                treeLoad();
                txtLedgerTitle.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int rowID ;//= ctlDgvAccountLedger.CurrentRow.Index;
                int ldgrID, accID;

                //if (ctlDgvAccountLedger.Tag.ToString() == "Account")
                //{
                //    if (IsNullOrEmpty(rowID, "ParentID"))
                //    {
                //        MessageBox.Show("Not Deletable");
                //        return;
                //    }
                //}
                if (isDefaultChartOfAccounts(txtLedgerTitle.Text) == true)
                {
                    MessageBox.Show("Not Deletable");
                    return;
                }
                if (MessageBox.Show("Do you really want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                

                

               
                //ldgrID = IsNullOrEmpty(rowID, "LedgerID") ? -1 : (int)ctlDgvAccountLedger.CurrentRow.Cells["LedgerID"].Value;
                //accID = IsNullOrEmpty(rowID, "AccountID") ? -1 : (int)ctlDgvAccountLedger.CurrentRow.Cells["AccountID"].Value;
                
                ldgrID = Convert.ToInt32(lblLedgerID.Text);
                accID = Convert.ToInt32(lblAccountID.Text);
                
                new DaAccount().DeleteAccountAndLedger(accID,ldgrID, formConnection);
                btnNew_Click(null, null);
                btnSearch_Click(null, null);
                MessageBox.Show("Deleted Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //treeLoad();

            //treeView1.GetNodeAt(
        }

        private void treeLoad()
        {
            try
            {
                
                tvAccounts.Nodes.Clear();
                DataTable dt = new DataTable();
                dt = new DaAccount().GetAccountsOfDepth(0, formConnection);

                foreach (DataRow dr in dt.Rows)
                {
                 TreeNode tn=   tvAccounts.Nodes.Add((dr.Field<int>("AccountID")).ToString(), dr.Field<string>("AccountTitle"));

                 if (dr.Field<string>("AccOrGroup") == "Account")
                     tn.ForeColor = Color.Red;
                 else
                     tn.ForeColor = Color.Black; 
                }
               
                foreach (TreeNode node in tvAccounts.Nodes)
                {
                   
                    //MessageBox.Show(node.Text,node.Name);
                    addChild(node);
                }
                tvAccounts.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void addChild(TreeNode n)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = new DaAccount().GetChildsOfParents(int.Parse(n.Name), formConnection);
                if (dt.Rows.Count == 0) return;
                foreach (DataRow dr in dt.Rows)
                {
               TreeNode NN= n.Nodes.Add((dr.Field<int>("AccountID")).ToString(), dr.Field<string>("AccountTitle"));
               if (dr.Field<string>("AccOrGroup") == "Account")
                   NN.ForeColor = Color.Red;
               else
                   NN.ForeColor = Color.Black; 
               addChild(NN);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string InputValidation()
        {
            string err=string.Empty;
            try
            {
                if (txtLedgerTitle.Text.Trim() == "")
                    return  "Enter a valid Title";
                if (txtLedgerNo.Text.Trim() == "")
                    return "Invalid Ledger No";
                txtOpBal.Text = txtOpBal.Text.Trim();
                if (txtOpBal.Text == "") txtOpBal.Text = "0";
                if (chkInChartOfAcc.Checked == false && chkDetail.Checked == false)
                    return "you must create either an account or ledger";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return string.Empty;
        }

        private void cboType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedItem.ToString() == "Account")
            {
                cboSearchBy.Enabled = false;
            }
            else
            {
                cboSearchBy.Enabled = true;
            }
        }

        private void frmLedger_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                FormColorClass.ColorForm(this, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tvAccounts_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           //MessageBox.Show( e.Node.Name,tvAccounts.SelectedNode.Text);
           ctlDgvAccountLedger_CellDoubleClick(tvAccounts, null);
        }
    }
}
