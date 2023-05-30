using Accounting.DataAccess;
using Accounting.Entity;
using Accounting.Utility;
using AccSys.Web.WebControls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Tools;

namespace AccSys.Web
{
    public partial class frmRoles : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadRoles();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        private void LoadRoles()
        {
            using (var connection = new SqlConnection(ConnectionHelper.DefaultConnectionString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                dt = new DaRole().GetRoles(connection);
                gvData.DataSource = dt;
                gvData.DataBind();
                connection.Close();
            }
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var lblRoleId = ((LinkButton)sender).NamingContainer.FindControl("lblRoleId");
                if (lblRoleId != null)
                {
                    var roleId = Convert.ToInt32(((Label)lblRoleId).Text);
                    new DaRole().DeleteRole(roleId);
                    LoadRoles();
                    lblMsg.Text = UIMessage.Message2User("Role deleted successfully", UserUILookType.Success);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var role = new Role()
                {
                    RoleId = Convert.ToInt32(lblRoleId.Text),
                    RoleName = txtRoleName.Text.Trim()
                };
                new DaRole().SaveUpdateRole(role);
                LoadRoles();
                lblMsg.Text = UIMessage.Message2User("Role saved successfully", UserUILookType.Success);
                btnReset_Click(null, e);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblRoleId.Text = "0";
            txtRoleName.Text = "";
            btnCreate.Text = "Create Role";
            if (sender != null)
            {
                lblMsg.Text = "";
            }
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionHelper.DefaultConnectionString))
                {
                    connection.Open();
                    Label lblId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblRoleId");
                    lblRoleId.Text = lblId.Text;
                    Label lblRoleName = (Label)((LinkButton)sender).NamingContainer.FindControl("lblRoleName");
                    txtRoleName.Text = lblRoleName.Text;
                    btnCreate.Text = "Update Role";
                    lblMsg.Text = "";
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}