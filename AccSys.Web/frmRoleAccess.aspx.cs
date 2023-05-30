using AccSys.Web.WebControls;
using System;
using System.Web.UI.WebControls;
using Tools;

namespace AccSys.Web
{
    public partial class frmRoleAccess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var roleId = Convert.ToInt32(ddlRoles.SelectedValue);
                var groupName = ddlGroup.SelectedValue;
                var roleAccess = DalResourceAuthorization.GetResourcesOfRole(roleId, groupName);
                gvData.DataSource = roleAccess;
                gvData.DataBind();
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {

                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow r in gvData.Rows)
                {
                    Label lblResourceID = (Label)r.FindControl("lblResourceID");
                    CheckBox chkView = (CheckBox)r.FindControl("chkView");
                    CheckBox chkAdd = (CheckBox)r.FindControl("chkAdd");
                    CheckBox chkEdit = (CheckBox)r.FindControl("chkEdit");
                    CheckBox chkDelete = (CheckBox)r.FindControl("chkDelete");
                    var resourceId = Convert.ToInt32(lblResourceID.Text);
                    var roleId = Convert.ToInt32(ddlRoles.SelectedValue);

                    DalResourceAuthorization.SaveResourcesOfRole(resourceId, roleId, chkView.Checked, chkAdd.Checked, chkEdit.Checked, chkDelete.Checked);
                    lblMsg.Text = UIMessage.Message2User("Successfully Saved.", UserUILookType.Success);
                }
            }
            catch (Exception ex)
            {

                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void chkTickView_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow r in gvData.Rows)
            {

                ((CheckBox)r.FindControl("chkView")).Checked = ((CheckBox)sender).Checked;

            }
        }

        protected void chkTickAdd_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow r in gvData.Rows)
            {

                ((CheckBox)r.FindControl("chkAdd")).Checked = ((CheckBox)sender).Checked;

            }
        }

        protected void chkTickEdit_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow r in gvData.Rows)
            {

                ((CheckBox)r.FindControl("chkEdit")).Checked = ((CheckBox)sender).Checked;

            }
        }

        protected void chkTickDelete_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow r in gvData.Rows)
            {

                ((CheckBox)r.FindControl("chkDelete")).Checked = ((CheckBox)sender).Checked;

            }
        }
    }
}