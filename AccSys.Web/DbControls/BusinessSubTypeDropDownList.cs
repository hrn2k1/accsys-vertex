using Accounting.DataAccess;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace AccSys.Web.DbControls
{
    public class BusinessSubTypeDropDownList : DropDownList
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
        public BusinessSubTypeDropDownList()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(BusinessSubTypeDropDownList_Load);


        }
        public void Bind(int typeId=0)
        {
            string where = " 1 = 1";
            if(typeId > 0)
            {
                where = string.Format(" BusinessTypeID={0} ", typeId);
            }
            DataTable dtdata = CommonDataSource.GetData(" BusinessSubTypeID, BusinessTypeID, Name ", "BusinessSubType", where, "Name", 100, 0);
            if (_NullItemValue != null)
            {
                DataRow dr = dtdata.NewRow();
                dr["BusinessSubTypeID"] = _NullItemValue;
                dr["Name"] = _NullItemText;
                dtdata.Rows.InsertAt(dr, 0);

            }
            this.DataSource = dtdata;
            this.DataTextField = "Name";
            this.DataValueField = "BusinessSubTypeID";
            this.DataBind(false);
        }
        void BusinessSubTypeDropDownList_Load(object sender, EventArgs e)
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