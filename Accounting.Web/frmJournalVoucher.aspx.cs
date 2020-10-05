using System;

namespace Accounting.Web
{
    public partial class frmJournalVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request["id"]))
                    CtlJournalVoucher1.VoucherId = Convert.ToInt32(Request["id"]);
            }
        }
    }
}