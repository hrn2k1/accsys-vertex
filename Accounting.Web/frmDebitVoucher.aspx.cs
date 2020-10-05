using System;

namespace Accounting.Web
{
    public partial class frmDebitVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request["id"]))
                    CtlDebitVoucher1.VoucherId = Convert.ToInt32(Request["id"]);
            }
        }
    }
}