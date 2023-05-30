using AccSys.Web.WebControls;
using System;

namespace AccSys.Web
{
    public partial class frmCreditVoucher : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request["id"]))
                    CtlCreditVoucher1.VoucherId = Convert.ToInt32(Request["id"]);
            }
        }
    }
}