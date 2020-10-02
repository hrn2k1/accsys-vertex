using Accounting.DataAccess;
using AjaxControlToolkit;
using CustomDropDown;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace Accounting.Web.DbControls
{
    public class CustomAccountDropDownListChosen : DropDownListChosen
    {
        private string _FilterBy = string.Empty;
        public string FilterBy { get { return _FilterBy; } set { _FilterBy = value; } }
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
        public CustomAccountDropDownListChosen()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(CustomAccountDropDownListChosen_Load);


        }
        public void Bind()
        {
            CustomAccountDropDownListChosen_Load(null, null);
        }
        void CustomAccountDropDownListChosen_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack || sender == null)
                {
                    string Where = string.Format("CompanyID={0} ", HttpContext.Current.Session["CompanyId"]);
                    if (_FilterBy.Trim() != string.Empty)
                        Where += " AND " + _FilterBy;

                    DataTable dtdata = DaAccount.GetAccounts(Where, "AccountTitle");
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