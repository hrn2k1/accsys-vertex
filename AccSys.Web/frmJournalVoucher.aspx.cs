using AccSys.Web.WebControls;
using System;

namespace AccSys.Web
{
    public partial class frmJournalVoucher : BasePage
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