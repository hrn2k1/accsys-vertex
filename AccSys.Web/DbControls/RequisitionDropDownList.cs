using Accounting.DataAccess;
using CustomDropDown;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;

namespace AccSys.Web.DbControls
{
    public class RequisitionDropDownList : DropDownListChosen
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
        public int Type { get; set; } = 1;
        public RequisitionDropDownList()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(RequisitionDropDownList_Load);


        }
        public void Bind()
        {
            DataTable dtdata = DaInventoryRequisition.GetRequisitions(string.Format(" M.CompanyID={0}", Tools.Utility.IsNull<int>(HttpContext.Current.Session["CompanyId"], 0)), "ReqDate");
            if (_NullItemValue != null)
            {
                DataRow dr = dtdata.NewRow();
                dr["ReqMID"] = _NullItemValue;
                dr["ReqHtml"] = _NullItemText;
                dtdata.Rows.InsertAt(dr, 0);

            }
            this.DataSource = dtdata;
            this.DataTextField = "ReqHtml";
            this.DataValueField = "ReqMID";
            this.DataBind();
        }
        void RequisitionDropDownList_Load(object sender, EventArgs e)
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
        private string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }
        public string SelectedRequisitionNo()
        {
            try
            {
                string accNoTag = Regex.Match(SelectedItem.Text, "<div class=\"usertext req-no\">\\s*(.+?)\\s*</div>").Value;
                return StripTagsRegex(accNoTag);
            }
            catch (Exception)
            {

                return "";
            }
        }
        
    }
   
}