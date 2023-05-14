using Accounting.DataAccess;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace AccSys.Web.DbControls
{
    public class CurrencyDropDownList : DropDownList
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
        public CurrencyDropDownList()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(CurrencyDropDownList_Load);


        }
        public void Bind()
        {
            DataTable dtData = DaCommon.GetList("Currency", "CurrencyID,Name", "1=1", "Name");
            if (_NullItemValue != null)
            {
                DataRow dr = dtData.NewRow();
                dr["CurrencyID"] = _NullItemValue;
                dr["Name"] = _NullItemText;
                dtData.Rows.InsertAt(dr, 0);

            }
            this.DataSource = dtData;
            this.DataTextField = "Name";
            this.DataValueField = "CurrencyID";
            this.DataBind();
        }
        void CurrencyDropDownList_Load(object sender, EventArgs e)
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