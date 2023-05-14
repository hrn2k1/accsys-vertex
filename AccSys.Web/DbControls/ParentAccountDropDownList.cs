using Accounting.DataAccess;
using CustomDropDown;
using System;
using System.Data;
using System.Web;

namespace AccSys.Web.DbControls
{
    public class ParentAccountDropDownListChosen : DropDownListChosen
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
        public ParentAccountDropDownListChosen()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(ParentAccountDropDownListChosen_Load);


        }
        public void Bind()
        {
            DataTable dtdata = DaAccount.GetAccountGroups(Tools.Utility.IsNull<int>(HttpContext.Current.Session["CompanyId"], 0));
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
        void ParentAccountDropDownListChosen_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    Bind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}