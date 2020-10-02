using Accounting.DataAccess;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Accounting.Web.DbControls
{
    public class TransMethodDropDownList : DropDownList
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
        public TransMethodDropDownList()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(TransMethodDropDownList_Load);


        }
        public void Bind()
        {
            TransMethodDropDownList_Load(null, null);
        }
        void TransMethodDropDownList_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    string Where = " 1=1 ";

                    DataTable dtData = DaTransaction.GetTransactionMethods(Where, "TransMethod");
                    if (_NullItemValue != null)
                    {
                        DataRow dr = dtData.NewRow();
                        dr["TransMethodID"] = _NullItemValue;
                        dr["TransMethod"] = _NullItemText;
                        dtData.Rows.InsertAt(dr, 0);

                    }
                    this.DataSource = dtData;
                    this.DataTextField = "TransMethod";
                    this.DataValueField = "TransMethodID";
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