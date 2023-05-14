using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccSys.Web
{
    public partial class frmCreditVoucher : System.Web.UI.Page
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