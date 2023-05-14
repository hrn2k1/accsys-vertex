using Accounting.DataAccess;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace AccSys.Web.DbControls
{
    public class SectionDropDownList : DropDownList
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
        public SectionDropDownList()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(SectionDropDownList_Load);


        }
        public void Bind()
        {
            DataTable dtdata = DaCommon.GetList("Section", "SectionID,Name", "1=1", "Name");
            if (_NullItemValue != null)
            {
                DataRow dr = dtdata.NewRow();
                dr["SectionID"] = _NullItemValue;
                dr["Name"] = _NullItemText;
                dtdata.Rows.InsertAt(dr, 0);

            }
            this.DataSource = dtdata;
            this.DataTextField = "Name";
            this.DataValueField = "SectionID";
            this.DataBind();
        }
        void SectionDropDownList_Load(object sender, EventArgs e)
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