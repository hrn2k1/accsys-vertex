using Accounting.DataAccess;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace AccSys.Web.DbControls
{
    public class UnitDropDownList : DropDownList
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
        public UnitDropDownList()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(UnitDropDownList_Load);


        }
        public void Bind()
        {
            DataTable dtdata = DAChartsOfItem.LoadUnits();
            if (_NullItemValue != null)
            {
                DataRow dr = dtdata.NewRow();
                dr["UnitsID"] = _NullItemValue;
                dr["UnitsName"] = _NullItemText;
                dtdata.Rows.InsertAt(dr, 0);

            }
            this.DataSource = dtdata;
            this.DataTextField = "UnitsName";
            this.DataValueField = "UnitsID";
            this.DataBind();
        }
        void UnitDropDownList_Load(object sender, EventArgs e)
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