using Accounting.DataAccess;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace AccSys.Web.DbControls
{
    public class UserDropDownList : DropDownList
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
        public UserDropDownList()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(UserDropDownList_Load);


        }
        public void Bind()
        {
            DataTable dtdata = CommonDataSource.GetDataV2(" UserID, UserName ", "Users", " 1=1 ", "UserName", 100, 0);
            if (_NullItemValue != null)
            {
                DataRow dr = dtdata.NewRow();
                dr["UserID"] = _NullItemValue;
                dr["UserName"] = _NullItemText;
                dtdata.Rows.InsertAt(dr, 0);

            }
            this.DataSource = dtdata;
            this.DataTextField = "UserName";
            this.DataValueField = "UserID";
            this.DataBind(false);
        }
        void UserDropDownList_Load(object sender, EventArgs e)
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