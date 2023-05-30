using Accounting.DataAccess;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace AccSys.Web.DbControls
{
    public class RoleDropDownList : DropDownList
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
        public RoleDropDownList()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(RoleDropDownList_Load);


        }
        public void Bind()
        {
            DataTable dtdata = CommonDataSource.GetDataV2(" RoleId, RoleName ", "Roles", " 1=1 ", "RoleName", 100, 0);
            if (_NullItemValue != null)
            {
                DataRow dr = dtdata.NewRow();
                dr["RoleId"] = _NullItemValue;
                dr["RoleName"] = _NullItemText;
                dtdata.Rows.InsertAt(dr, 0);

            }
            this.DataSource = dtdata;
            this.DataTextField = "RoleName";
            this.DataValueField = "RoleId";
            this.DataBind();
        }
        void RoleDropDownList_Load(object sender, EventArgs e)
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