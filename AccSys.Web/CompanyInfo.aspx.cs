using Accounting.Utility;
using AccSys.Web.DbControls;
using AccSys.Web.WebControls;
using System;
using System.Web.UI.WebControls;
using Tools;

namespace AccSys.Web
{
    public partial class CompanyInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dsCompany.ConnectionString = ConnectionHelper.DefaultConnectionString;
        }

        protected void DsData_OperationCompleted(object sender, System.Web.UI.WebControls.SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                lblMsg.Text = e.Exception.CustomDialogMessage(sender);
                e.ExceptionHandled = true;
            }
            else
            {
                if (e.Command.CommandText == dsCompany.UpdateCommand)
                {
                    if (Request.Files.Count > 0 && Request.Files[0].FileName != "")
                    {
                        try
                        {
                            Request.Files[0].SaveAs(Server.MapPath(string.Format("~/Logo/logo_{0}.jpg", Tools.Utility.IsNull<int>(Session["CompanyId"], 0))));
                        }
                        catch (Exception ex)
                        {
                            lblMsg.Text = ex.CustomDialogMessage(sender);
                        }
                    }
                    lblMsg.Text = UIMessage.Message2User("Successfully Saved.", UserUILookType.Success);
                }
                else
                    lblMsg.Text = "";
            }
        }

        protected void ddlLedgerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            var ctl = ddl.NamingContainer.FindControl("BusinessSubTypeDropDownList1");
            if (ctl != null)
            {
                ((BusinessSubTypeDropDownList)ctl).Bind(ddl.SelectedValue.ToInt());
            }
        }
    }
}