using Accounting.DataAccess;
using CustomDropDown;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;

namespace AccSys.Web.DbControls
{
    public class OrderDropDownListChosen : DropDownListChosen
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
        public OrderDropDownListChosen()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(OrderDropDownListChosen_Load);


        }
        public void Bind()
        {
            DataTable dtdata = DaOrder.GetOrders(string.Format(" OrderType='{1}' AND Order_Master.CompanyID={0}", Tools.Utility.IsNull<int>(HttpContext.Current.Session["CompanyId"], 0), Type == 1 ? "Purchase Order" : "Sales Order"), "OrderDate");
            if (_NullItemValue != null)
            {
                DataRow dr = dtdata.NewRow();
                dr["OrderMID"] = _NullItemValue;
                dr["OrderHtml"] = _NullItemText;
                dtdata.Rows.InsertAt(dr, 0);

            }
            this.DataSource = dtdata;
            this.DataTextField = "OrderHtml";
            this.DataValueField = "OrderMID";
            this.DataBind();
        }
        void OrderDropDownListChosen_Load(object sender, EventArgs e)
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
        private string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }
        public string SelectedOrderNo()
        {
            try
            {
                string accNoTag = Regex.Match(SelectedItem.Text, "<div class=\"usertext order-no\">\\s*(.+?)\\s*</div>").Value;
                return StripTagsRegex(accNoTag);
            }
            catch (Exception)
            {

                return "";
            }
        }
        
    }
   
}