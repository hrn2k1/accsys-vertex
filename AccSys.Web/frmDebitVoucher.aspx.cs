using AccSys.Web.WebControls;
using System;

namespace AccSys.Web
{
    public partial class frmDebitVoucher : BasePage
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