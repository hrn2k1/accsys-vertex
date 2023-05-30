using Accounting.DataAccess;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace AccSys.Web.DbControls
{
    public class LedgerTypeDropDownList : DropDownList
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
        public LedgerTypeDropDownList()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(LedgerTypeDropDownList_Load);


        }
        public void Bind()
        {
            string Where = " 1 = 1";

            DataTable dtdata = DaLedgerType.GetLedgerTypes(Where, "LedgerTypeId");
            if (_NullItemValue != null)
            {
                DataRow dr = dtdata.NewRow();
                dr["LedgerTypeID"] = _NullItemValue;
                dr["LedgerType"] = _NullItemText;
                dtdata.Rows.InsertAt(dr, 0);

            }
            this.DataSource = dtdata;
            this.DataTextField = "LedgerType";
            this.DataValueField = "LedgerTypeID";
            this.DataBind();
        }
        void LedgerTypeDropDownList_Load(object sender, EventArgs e)
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