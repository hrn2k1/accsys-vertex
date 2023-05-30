using Accounting.DataAccess;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace AccSys.Web.DbControls
{
    public class BusinessTypeDropDownList : DropDownList
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
        public BusinessTypeDropDownList()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(BusinessTypeDropDownList_Load);


        }
        public void Bind()
        {
            DataTable dtdata = CommonDataSource.GetDataV2(" BusinessTypeID, Name ", "BusinessType", " 1=1 ", "Name", 100, 0);
            if (_NullItemValue != null)
            {
                DataRow dr = dtdata.NewRow();
                dr["BusinessTypeID"] = _NullItemValue;
                dr["Name"] = _NullItemText;
                dtdata.Rows.InsertAt(dr, 0);

            }
            this.DataSource = dtdata;
            this.DataTextField = "Name";
            this.DataValueField = "BusinessTypeID";
            this.DataBind(false);
        }
        void BusinessTypeDropDownList_Load(object sender, EventArgs e)
        {
            try
            {
                //if (!this.Page.IsPostBack)
                //{
                    Bind();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}