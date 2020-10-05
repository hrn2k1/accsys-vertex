using Accounting.DataAccess;
using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;

namespace Accounting.Web.UserControls
{
    public partial class CtlChartOfAccounts : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTree();

            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            this.Page.LoadComplete += new EventHandler(Page_LoadComplete);
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlParent_SelectedIndexChanged(sender, e);
            }
        }
        protected void chkAccount_CheckedChanged(object sender, EventArgs e)
        {
            trBalance.Visible = chkAccount.Checked;
            trParent.Visible = chkAccount.Checked;
            trLedgerNo.Visible = chkAccount.Checked;
        }

        protected void chkLedger_CheckedChanged(object sender, EventArgs e)
        {
            trDtl1.Visible = trDtl1.Visible = trDtl2.Visible = trDtl3.Visible = trDtl4.Visible = trDtl5.Visible = chkLedger.Checked;
        }

        protected void ddlACType_SelectedIndexChanged(object sender, EventArgs e)
        {
            trBalance.Visible = (ddlACType.SelectedValue == "Account");
        }

        private string CreateWhere()
        {
            string where = "";
            try
            {
                where = string.Format(" Account.CompanyID={0}", Session["CompanyID"] ?? 1);

                if (ddlAccGroup.SelectedValue != "All")
                    where += (where != "" ? " AND " : "") + string.Format(" Account.AccOrGroup='{0}' ", ddlAccGroup.SelectedValue);
                if (ddlSrcLedgerType.SelectedValue != "0")
                    where += (where != "" ? " AND " : "") + string.Format(" Account.LedgerTypeID={0} ", ddlSrcLedgerType.SelectedValue);
                if (ddlSrcParent.SelectedValue != "0")
                    where += (where != "" ? " AND " : "") + string.Format(" Account.ParentID={0} ", ddlSrcParent.SelectedValue);
                //if (ddlCustomField.SelectedValue != "")
                //    where += (where != "" ? " AND " : "") + string.Format(ddlCustomField.SelectedValue, txtCustomValue.Text.Trim());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return where;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvData.DataSourceID = "odsCommon";
                odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @"  Account.AccountID, Account.AccountNo, Account.AccountTitle, Account.AccOrGroup, Account.AccountStatus, Account.OpeningBalance, Account.CurrentBalance, 
                      Account.LedgerTypeID, LedgerType.LedgerType, Account.CompanyID, Account.ParentID, Parent.AccountNo AS ParentACNo, Parent.AccountTitle AS ParentACTitle, 
                      Account.AccDepth";
                odsCommon.SelectParameters["FromTable"].DefaultValue = @" T_Account AS Account LEFT OUTER JOIN
                      T_LedgerType AS LedgerType ON Account.LedgerTypeID = LedgerType.LedgerTypeID LEFT OUTER JOIN
                      T_Account AS Parent ON Account.ParentID = Parent.AccountID";
                odsCommon.SelectParameters["Where"].DefaultValue = CreateWhere();
                odsCommon.SelectParameters["OrderBy"].DefaultValue = "Account.AccountNo";

                if (sender != null)
                    gvData.PageIndex = 0;
                gvData.DataBind();

                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }

        protected void gvData_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                string sOrder = "ASC";
                if (ViewState[e.SortExpression.Replace(".", "_")] != null)
                    sOrder = ViewState[e.SortExpression.Replace(".", "_")].ToString();

                gvData.DataSourceID = "odsCommon";
                odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @"  Account.AccountID, Account.AccountNo, Account.AccountTitle, Account.AccOrGroup, Account.AccountStatus, Account.OpeningBalance, Account.CurrentBalance, 
                      Account.LedgerTypeID, LedgerType.LedgerType, Account.CompanyID, Account.ParentID, Parent.AccountNo AS ParentACNo, Parent.AccountTitle AS ParentACTitle, 
                      Account.AccDepth";
                odsCommon.SelectParameters["FromTable"].DefaultValue = @" T_Account AS Account LEFT OUTER JOIN
                      T_LedgerType AS LedgerType ON Account.LedgerTypeID = LedgerType.LedgerTypeID LEFT OUTER JOIN
                      T_Account AS Parent ON Account.ParentID = Parent.AccountID";
                odsCommon.SelectParameters["Where"].DefaultValue = CreateWhere();
                odsCommon.SelectParameters["OrderBy"].DefaultValue = string.Format("{0} {1}", e.SortExpression, sOrder);
                gvData.DataBind();


                ViewState[e.SortExpression.Replace(".", "_")] = sOrder == "DESC" ? "ASC" : "DESC";
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        #region Tree
        private DataSet dsGLs;
        private void LoadTree()
        {

            try
            {
                dsGLs = new DataSet();

                DataTable dtAccs = DaAccount.GetAccounts(string.Format("CompanyID={0}", Session["CompanyID"] ?? 1));

                dsGLs.Tables.Add(dtAccs);
                dsGLs.Tables[0].TableName = "Dir";
                dsGLs.Relations.Add("DirRelation", dsGLs.Tables["Dir"].Columns["AccountID"], dsGLs.Tables["Dir"].Columns["ParentID"], false);

                //dsGLs.WriteXml("../XML/coa.xml");
                if (TreeView1.Nodes.Count > 0) TreeView1.Nodes.Clear();
                TreeNode node = new TreeNode();
                foreach (DataRow row in dsGLs.Tables["Dir"].Rows)
                {
                    if (row.Field<object>("ParentID") == DBNull.Value || row.Field<object>("ParentID") == null)
                    {
                        if (row.Field<string>("AccOrGroup") == "Account")
                            node = new TreeNode(string.Format("<B style='color:red'>{0}</B>", row.Field<string>("AccountTitle")), row.Field<object>("AccountID").ToString());
                        else
                            node = new TreeNode(string.Format("{0}", row.Field<string>("AccountTitle")), row.Field<object>("AccountID").ToString());

                        TreeView1.Nodes.Add(node);
                        AddNode(row, node);
                    }
                }
                TreeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void AddNode(DataRow dr, TreeNode n)
        {
            try
            {


                foreach (DataRow r in dr.GetChildRows("DirRelation"))
                {
                    TreeNode nn = new TreeNode(r.Field<string>("AccountTitle"), r.Field<object>("AccountID").ToString());
                    n.ChildNodes.Add(nn);
                    AddNode(r, nn);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }
        protected void lbtnExpandAll_Click(object sender, EventArgs e)
        {
            TreeView1.ExpandAll();
        }

        protected void lbtnCollapAll_Click(object sender, EventArgs e)
        {
            TreeView1.CollapseAll();
        }

        protected void lbtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTree();

            }
            catch (Exception ex)
            {

            }
        }
        #endregion



        protected void ddlParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int accountId = Convert.ToInt32(lblAccountID.Text);
                if (accountId <= 0)
                {
                    string AccountNo = DaAccount.GenerateAccountNo(Convert.ToInt32(ddlParent.SelectedValue));
                    txtLedgerNo.Text = AccountNo;
                }
            }
            catch (Exception ex)
            {
                lblPanel1Msg.Text = ex.Message;
            }
        }

        
        private Ledgers CreateLedgerObject()
        {
            Ledgers objLdgr = null;
            try
            {
                objLdgr = new Ledgers();
                objLdgr.LedgerID = int.Parse(lblLedgerID.Text);
                objLdgr.LedgerName = txtLedgerTitle.Text.Trim();
                objLdgr.LedgerTypeID = Convert.ToInt32(ddlLedgerType.SelectedValue);
                objLdgr.Address = txtAddress.Text.Trim();
                objLdgr.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                objLdgr.CurrencyID = Convert.ToInt32(ddlCurrency.SelectedValue);
                objLdgr.ContactPerson = txtContact.Text.Trim();
                objLdgr.BankAccountType = txtBankACType.Text;
                objLdgr.BusinessType = txtBusinessType.Text.Trim();
                objLdgr.Phone = txtPhone.Text.Trim();
                objLdgr.Fax = txtFax.Text.Trim();
                objLdgr.Email = txtEmail.Text.Trim();
                objLdgr.TeamMemberID = -1;
                objLdgr.Remarks = txtRemarks.Text.Trim();
                objLdgr.AccountID = -1;
                objLdgr.CompanyID = Tools.Utility.IsNull<int>(Session["CompanyId"], 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objLdgr;
        }
        private Account CreateAccountObject(int LdgrID)
        {
            Account objAcc = null;
            try
            {
                
                objAcc = new Account();
                objAcc.AccountID = int.Parse(lblAccountID.Text);
                objAcc.AccountNo = txtLedgerNo.Text;
                objAcc.AccountTitle = txtLedgerTitle.Text.Trim();
                objAcc.AccountOrGroup = ddlACType.SelectedValue;

                if (objAcc.AccountOrGroup == "Account")
                {
                    objAcc.AccountCreateDate = DateTime.Now;
                    objAcc.AccountStatus = ddlStatus.SelectedValue;
                    objAcc.OpeningBalance = double.Parse(txtOpBal.Text.Trim());
                    objAcc.IsInventoryRelated = chkInventory.Checked ? 1 : 0;
                }
                else
                {
                    objAcc.AccountCreateDate = DateTime.Now.Date;
                    objAcc.AccountStatus = "Active";
                    objAcc.OpeningBalance = 0;
                    objAcc.IsInventoryRelated = 0;
                }
                objAcc.LedgerTypeID = Convert.ToInt32(ddlLedgerType.SelectedValue);
                objAcc.AccountDepth = -1; // will be calculated auto
                objAcc.AccountNature = 0; // will be set auto

                objAcc.ParentID = Convert.ToInt32(ddlParent.SelectedValue);

                objAcc.LedgerID = LdgrID;
                objAcc.CompanyID = Tools.Utility.IsNull<int>(Session["CompanyId"], 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objAcc;
        }
        private string InputValidation()
        {
            string err = string.Empty;
            try
            {
                if (txtLedgerTitle.Text.Trim() == "")
                    return "Enter a valid Title";
                if (txtLedgerNo.Text.Trim() == "")
                    return "Invalid Ledger No";
                txtOpBal.Text = txtOpBal.Text.Trim();
                if (txtOpBal.Text == "") txtOpBal.Text = "0";
                if (chkAccount.Checked == false && chkLedger.Checked == false)
                    return "You must create either an account or ledger";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return string.Empty;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection connection = null;
            SqlTransaction trans = null;
            try
            {
                string err = InputValidation();

                if (err != string.Empty)
                {
                    lblPanel1Msg.Text = UIMessage.Message2User(err, UserUILookType.Warning);
                    return;
                }

                bool msgFlag = false;
                int LdgrID = -1, AccID = -1;
                connection = new SqlConnection(ConnectionHelper.DefaultConnectionString);
                connection.Open();
                trans = connection.BeginTransaction();
                if (chkLedger.Checked)
                {
                    Ledgers objLedger = CreateLedgerObject();
                    LdgrID = new DaLedger().InsertUpdateLedger(objLedger, connection, trans);
                    msgFlag = true;
                }
                else
                {
                    int lID = int.Parse(lblLedgerID.Text);
                    if (lID > 0)
                        new DaLedger().DeleteLedger(lID, connection, trans);
                }

                if (chkAccount.Checked)
                {
                    Account objAccount = CreateAccountObject(LdgrID);
                    AccID = new DaAccount().InsertUpdateAccount(objAccount, connection, trans);
                    msgFlag = true;
                }
                else
                {
                    int aID = int.Parse(lblAccountID.Text);
                    if (aID > 0)
                        new DaAccount().DeleteAccount(aID, connection, trans);
                }
                new DaLedger().UpdateAccountID(connection, trans, LdgrID, AccID);
                new DaAccount().UpdateLedgerID(connection, trans, AccID, LdgrID);

                trans.Commit();
                connection.Close();
                if (msgFlag == true)
                {
                    btnReset_Click(null, null);
                    btnSearch_Click(null, null);
                    lblPanel1Msg.Text = UIMessage.Message2User("Saved successfully", UserUILookType.Success);
                }
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                if (connection.State != ConnectionState.Closed) connection.Close();
                if (ex.Message.Contains("duplicate"))
                    lblPanel1Msg.Text = UIMessage.Message2User("This same type ledger or account already exists<br/>Please choose a different one.",  UserUILookType.Danger);
                else
                    lblPanel1Msg.Text = ex.CustomDialogMessage();
            }
            
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                lblAccountID.Text = "0";
                lblLedgerID.Text = "0";
                txtLedgerTitle.Text = "";
                txtCurBal.Text = "";
                txtOpBal.Text = "";
                txtAddress.Text = "";
                txtBankACType.Text = "";
                txtBusinessType.Text = "";
                txtContact.Text = "";
                txtEmail.Text = "";
                txtFax.Text = "";
                txtPhone.Text = "";
                txtRemarks.Text = "";

                ddlParent_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
        private Ledgers CreateLedger(int AccountID)
        {
            Ledgers obj = new Ledgers();
            try
            {
                obj.AccountID = AccountID;
                obj.Address = txtAddress.Text;
                if (Convert.ToInt32(ddlLedgerType.SelectedValue) == (int)LedgerTypes.BankLedger)
                    obj.BankAccountType = txtBankACType.Text;
                else
                    obj.BankAccountType = "";
                obj.BusinessType = txtBusinessType.Text;
                obj.CompanyID = Tools.Utility.IsNull<int>(Session["CompanyID"], 0);
                obj.ContactPerson = txtContact.Text;
                obj.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                obj.CurrencyID = Convert.ToInt32(ddlCurrency.SelectedValue);
                obj.Email = txtEmail.Text;
                obj.Fax = txtFax.Text;
                obj.LedgerID = Convert.ToInt32(lblLedgerID.Text);
                obj.LedgerName = txtLedgerTitle.Text;
                obj.LedgerTypeID = Convert.ToInt32(ddlLedgerType.SelectedValue);
                obj.ModifiedDate = DateTime.Now;
                obj.Phone = txtPhone.Text;
                obj.Remarks = txtRemarks.Text;
                obj.TeamMemberID = 0; //ignore;
                //obj.UserID = Tools.Utility.IsNull<Guid>(Session["UserID"], new Guid());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Label lblAccID = (Label)((LinkButton)sender).NamingContainer.FindControl("lblAccountID");
                //int AccountID = Convert.ToInt32(lblAccID.Text);
                Account objA = new DaAccount().GetAccount(Convert.ToInt32(lblAccID.Text));
                if (objA != null)
                {
                    lblAccountID.Text = objA.AccountID.ToString();
                    txtLedgerTitle.Text = objA.AccountTitle;
                    if (objA.LedgerTypeID > 0)
                        ddlLedgerType.SelectedValue = objA.LedgerTypeID.ToString();
                    else
                        ddlLedgerType.SelectedValue = ((int)LedgerTypes.GeneralLedger).ToString();
                    if (objA.AccountID > 0)
                    {
                        chkAccount.Checked = true;
                    }
                    if (objA.ParentID > 0)
                        ddlParent.SelectedValue = objA.ParentID.ToString();
                    else
                        ddlParent.SelectedValue = "0";
                    ddlACType.SelectedValue = objA.AccountOrGroup;
                    ddlACType_SelectedIndexChanged(sender, e);
                    txtLedgerNo.Text = objA.AccountNo;
                    chkInventory.Checked = Convert.ToBoolean(objA.IsInventoryRelated);
                    txtOpBal.Text = objA.OpeningBalance.ToString("0.00");
                    txtCurBal.Text = objA.CurrentBalance.ToString("0.00");
                    ddlStatus.SelectedValue = objA.AccountStatus;

                    if (objA.LedgerID > 0)
                    {
                        chkLedger.Checked = true;
                        Ledgers objL = new DaLedger().GetLedger(objA.LedgerID);
                        lblLedgerID.Text = objL.LedgerID.ToString();
                        txtAddress.Text = objL.Address;
                        txtBankACType.Text = objL.BankAccountType;
                        txtBusinessType.Text = objL.BusinessType;
                        txtContact.Text = objL.ContactPerson;
                        txtEmail.Text = objL.Email;
                        txtFax.Text = objL.Fax;
                        txtPhone.Text = objL.Phone;
                        txtRemarks.Text = objL.Remarks;

                    }
                    else
                    {
                        chkLedger.Checked = false;
                        lblLedgerID.Text = "0";
                        txtAddress.Text = "";
                        txtBankACType.Text = "";
                        txtBusinessType.Text = "";
                        txtContact.Text = "";
                        txtEmail.Text = "";
                        txtFax.Text = "";
                        txtPhone.Text = "";
                        txtRemarks.Text = "";
                    }
                    chkAccount_CheckedChanged(sender, e);
                    chkLedger_CheckedChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        protected void gvData_PageIndexChanged(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }
    }
}