using Accounting.DataAccess;
using CustomDropDown;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;

namespace Accounting.Web.DbControls
{
    public class AccountDropDownListChosen : DropDownListChosen
    {
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
        public AccountDropDownListChosen()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(AccountDropDownListChosen_Load);


        }
        public void Bind()
        {
            AccountDropDownListChosen_Load(null, null);
        }
        void AccountDropDownListChosen_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack || sender == null)
                {
                    DataTable dtdata = DaAccount.GetAccounts(string.Format(" CompanyID={0}", Tools.Utility.IsNull<int>( HttpContext.Current.Session["CompanyId"],0)), "AccountTitle");
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
   
}