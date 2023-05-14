using Accounting.DataAccess;
using Accounting.Utility;
using CustomDropDown;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;

namespace AccSys.Web.DbControls
{
    public class AccountByLedgerTypeDropDownListChosen : DropDownListChosen
    {
        private LedgerTypes _LedgerType = LedgerTypes.GeneralLedger;
        public LedgerTypes LedgerType { get { return _LedgerType; } set { _LedgerType = value; } }
        private string _NullItemValue = null;

        public string NullItemValue
        {
            get { return _NullItemValue; }
            set { _NullItemValue = value; }
        }
        private string _NullItemText = string.Empty;

        public string NullItemText
        {
            get { return _NullItemText; }
            set { _NullItemText = value; }
        }
        public AccountByLedgerTypeDropDownListChosen()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(AccountByLedgerTypeDropDownListChosen_Load);


        }
        public void Bind()
        {
            DataTable dtdata = DaAccount.GetAccounts(string.Format(" CompanyID={0} AND LedgerTypeID={1}", Tools.Utility.IsNull<int>(HttpContext.Current.Session["CompanyId"], 0), (int)_LedgerType), "AccountTitle");
            if (_NullItemValue != null)
            {
                DataRow dr = dtdata.NewRow();
                dr["AccountID"] = _NullItemValue;
                dr["AccountTitleHtml"] = _NullItemText;
                dtdata.Rows.InsertAt(dr, 0);

            }
            this.DataSource = dtdata;
            this.DataTextField = "AccountTitleHtml";
            this.DataValueField = "AccountID";
            this.DataBind();
        }
        void AccountByLedgerTypeDropDownListChosen_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack || sender == null)
                {
                    Bind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }
        public string SelectedAccountNo()
        {
            try
            {
                string accNoTag = Regex.Match(SelectedItem.Text, "<div class=\"account-no\">\\s*(.+?)\\s*</div>").Value;
                return StripTagsRegex(accNoTag);
            }
            catch (Exception)
            {
                return "";
            }
        }
        public string SelectedAccountTitle()
        {
            try
            {
                string accNoTag = Regex.Match(SelectedItem.Text, "<div class=\"usertext account-title\">\\s*(.+?)\\s*</div>").Value;
                return StripTagsRegex(accNoTag);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
    //public class AccountByLedgerTypeDropDownList : DropDownList
    //{
    //    private LedgerTypes _LedgerType = LedgerTypes.GeneralLedger;
    //    public LedgerTypes LedgerType { get { return _LedgerType; } set { _LedgerType = value; } }
    //    private string _NullItemValue = null;

    //    public string NullItemValue
    //    {
    //        get { return _NullItemValue; }
    //        set { _NullItemValue = value; }
    //    }
    //    private string _NullItemText = string.Empty;

    //    public string NullItemText
    //    {
    //        get { return _NullItemText; }
    //        set { _NullItemText = value; }
    //    }
    //    public AccountByLedgerTypeDropDownList()
    //        : base()
    //    {
    //        //this.CssClass = "WindowsStyle";
    //        this.AppendDataBoundItems = false;
    //        this.Load += new EventHandler(AccountByLedgerTypeDropDownList_Load);


    //    }
    //    public void Bind()
    //    {
    //        AccountByLedgerTypeDropDownList_Load(null, null);
    //    }
    //    void AccountByLedgerTypeDropDownList_Load(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            if (!this.Page.IsPostBack)
    //            {
    //                string Where = string.Format("CompanyID={0} AND AccOrGroup='Account' AND LedgerTypeID={1}", Tools.Utility.IsNull<int>(HttpContext.Current.Session["CompanyID"], 1), (int)_LedgerType);


    //                DataTable dtdata = DaAccount.GetAccounts(Where, "AccountTitle");
    //                if (_NullItemValue != null)
    //                {
    //                    DataRow dr = dtdata.NewRow();
    //                    dr["AccountID"] = _NullItemValue;
    //                    dr["AccountTitle"] = _NullItemText;
    //                    dtdata.Rows.InsertAt(dr, 0);

    //                }
    //                this.DataSource = dtdata;
    //                this.DataTextField = "AccountTitle";
    //                this.DataValueField = "AccountID";
    //                this.DataBind();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }
    //}
    //public class AccountByLedgerTypeComboBox : AjaxControlToolkit.ComboBox
    //{
    //    private LedgerTypes _LedgerType = LedgerTypes.GeneralLedger;
    //    public LedgerTypes LedgerType { get { return _LedgerType; } set { _LedgerType = value; } }

    //    private string _NullItemValue = null;

    //    public string NullItemValue
    //    {
    //        get { return _NullItemValue; }
    //        set { _NullItemValue = value; }
    //    }
    //    private string _NullItemText = string.Empty;

    //    public string NullItemText
    //    {
    //        get { return _NullItemText; }
    //        set { _NullItemText = value; }
    //    }
    //    public AccountByLedgerTypeComboBox()
    //        : base()
    //    {
    //        this.AutoCompleteMode = ComboBoxAutoCompleteMode.SuggestAppend;
    //        this.CssClass = "WindowsStyle";
    //        this.AppendDataBoundItems = false;
    //        this.DropDownStyle = ComboBoxStyle.DropDownList;
    //        this.Load += new EventHandler(AccountByLedgerTypeComboBox_Load);


    //    }
    //    public void Bind()
    //    {
    //        AccountByLedgerTypeComboBox_Load(null, null);
    //    }
    //    void AccountByLedgerTypeComboBox_Load(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            if (!this.Page.IsPostBack)
    //            {
    //                string Where = string.Format("CompanyID={0} AND AccOrGroup='Account' AND LedgerTypeID={1}", Tools.Utility.IsNull<int>(HttpContext.Current.Session["CompanyID"], 0), (int)_LedgerType);


    //                DataTable dtdata = DaAccount.GetAccounts(Where, "AccountTitle");
    //                if (_NullItemValue != null)
    //                {
    //                    DataRow dr = dtdata.NewRow();
    //                    dr["AccountID"] = _NullItemValue;
    //                    dr["AccountTitle"] = _NullItemText;
    //                    dtdata.Rows.InsertAt(dr, 0);

    //                }
    //                this.DataSource = dtdata;
    //                this.DataTextField = "AccountTitle";
    //                this.DataValueField = "AccountID";
    //                this.DataBind();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }
    //}
}