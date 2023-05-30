using Accounting.DataAccess;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace AccSys.Web.DbControls
{
    public class CountryDropDownList : DropDownList
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
        public CountryDropDownList()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(CountryDropDownList_Load);
        }
        public void Bind()
        {
            string Where = " 1=1 ";

            DataTable dtData = DaCountry.GetCountries(Where, "CountryName");
            if (_NullItemValue != null)
            {
                DataRow dr = dtData.NewRow();
                dr["CountryID"] = _NullItemValue;
                dr["CountryName"] = _NullItemText;
                dtData.Rows.InsertAt(dr, 0);

            }
            this.DataSource = dtData;
            this.DataTextField = "CountryName";
            this.DataValueField = "CountryID";
            this.DataBind();
        }
        void CountryDropDownList_Load(object sender, EventArgs e)
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