using Accounting.DataAccess;
using CustomDropDown;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;

namespace AccSys.Web.DbControls
{
    public class ItemDropDownListChosen : DropDownListChosen
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
        public ItemDropDownListChosen()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(ItemDropDownListChosen_Load);


        }
        public void Bind()
        {
            DataTable dtdata = DAChartsOfItem.GetItems(string.Format(" M.CompanyID={0}", Tools.Utility.IsNull<int>(HttpContext.Current.Session["CompanyId"], 0)), "GroupName, ItemName");
            if (_NullItemValue != null)
            {
                DataRow dr = dtdata.NewRow();
                dr["ItemID"] = _NullItemValue;
                dr["ItemHtml"] = _NullItemText;
                //dr["ItemHtml"] = "<div class='item-row'><div class='usertext item-name'>Select Item</div></div><div class='item-row'><div class='item-name'>Name</div><div class='item-group'>Group</div><div class='item-qty'>Qty</div></div>";
                dtdata.Rows.InsertAt(dr, 0);

            }
            this.DataSource = dtdata;
            this.DataTextField = "ItemHtml";
            this.DataValueField = "ItemID";
            this.DataBind();
        }
        void ItemDropDownListChosen_Load(object sender, EventArgs e)
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

        public string SelectedItemName()
        {
            try
            {
                string accNoTag = Regex.Match(SelectedItem.Text, "<div class=\"usertext item-name\">\\s*(.+?)\\s*</div>").Value;
                return StripTagsRegex(accNoTag);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
   
}