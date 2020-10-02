using Accounting.DataAccess;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Accounting.Web.DbControls
{
    public class VoucherTypeDropDownList : DropDownList
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
        public VoucherTypeDropDownList()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(VoucherTypeDropDownList_Load);


        }
        public void Bind()
        {
            VoucherTypeDropDownList_Load(null, null);
        }
        void VoucherTypeDropDownList_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    string Where = " 1 = 1";

                    DataTable dtdata = DaVoucherType.GetVoucherTypes(Where, "VoucherType");
                    if (_NullItemValue != null)
                    {
                        DataRow dr = dtdata.NewRow();
                        dr["VoucherTypeID"] = _NullItemValue;
                        dr["VoucherType"] = _NullItemText;
                        dtdata.Rows.InsertAt(dr, 0);

                    }
                    this.DataSource = dtdata;
                    this.DataTextField = "VoucherType";
                    this.DataValueField = "VoucherTypeID";
                    this.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}