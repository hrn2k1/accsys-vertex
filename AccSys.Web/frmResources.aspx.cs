using AccSys.Web.WebControls;
using System;
using System.Web.UI.WebControls;
using Tools;

namespace AccSys.Web
{
    public partial class frmResources : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void DsData_OperationCompleted(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                lblMsg.Text = e.Exception.CustomDialogMessage(sender);
                e.ExceptionHandled = true;
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DsResources.Insert();
                DsResources.DataBind();
                gvData.DataBind();
                btnReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

            // txtGroup.Text = "";
            txtName.Text = "";
            txtPath.Text = "";
            //lblMsg.Text = "";
        }
    }
}