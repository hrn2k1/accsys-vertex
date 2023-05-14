using Accounting.DataAccess;
using CustomDropDown;
using System;
using System.Data;
using System.Web;

namespace AccSys.Web.DbControls
{
    public class LedgerDropDownListChosen : DropDownListChosen
    {
        public string NullItemValue { get; set; } = null;

        public string NullItemText { get; set; } = string.Empty;
        public int LedgerType { get; set; } = 0;
        public LedgerDropDownListChosen()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(LedgerDropDownListChosen_Load);


        }
        public void Bind()
        {
            DataTable dtdata = DaLedger.GetLedgers(Tools.Utility.IsNull<int>(HttpContext.Current.Session["CompanyId"], 0), LedgerType);
            if (NullItemValue != null)
            {
                DataRow dr = dtdata.NewRow();
                dr["LedgerID"] = NullItemValue;
                dr["LedgerName"] = NullItemText;
                dtdata.Rows.InsertAt(dr, 0);

            }
            this.DataSource = dtdata;
            this.DataTextField = "LedgerName";
            this.DataValueField = "LedgerID";
            this.DataBind();
        }
        void LedgerDropDownListChosen_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack || sender == null)
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