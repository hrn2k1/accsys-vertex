using Accounting.DataAccess;
using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Tools;

namespace AccSys.Web.UserControls
{
    public partial class CtlUsers : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        private void LoadUsers()
        {
            using (var connection = new SqlConnection(ConnectionHelper.DefaultConnectionString))
            {
                connection.Open();
                DaLogIn objl = new DaLogIn();
                DataTable dt = new DataTable();
                dt = objl.GetUsers(connection);
                gvData.DataSource = dt;
                gvData.DataBind();
                connection.Close();
            }
        }


        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var lblUserId = ((LinkButton)sender).NamingContainer.FindControl("lblUserId");
                if (lblUserId != null)
                {
                    var userId = Convert.ToInt32(((Label)lblUserId).Text);
                    new DaUser().DeleteUser(userId);
                    LoadUsers();
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
                string strpass = "";
                if (chkPass.Checked)
                {
                    strpass = string.IsNullOrWhiteSpace(txtPassword.Text) ? txtPassword.Text.Trim() : GlobalFunctions.Encode(txtPassword.Text, GlobalFunctions.CypherText);
                }
                else
                {
                    strpass = string.IsNullOrWhiteSpace(lblPassword.Text) ? lblPassword.Text.Trim() : GlobalFunctions.Encode(lblPassword.Text, GlobalFunctions.CypherText);
                }
                var user = new User()
                {
                    UserID = Convert.ToInt32(lblId.Text),
                    CompanyID = Tools.Utility.IsNull<int>(Session["CompanyId"], 0),
                    UserName = txtUserName.Text.Trim(),
                    Password = strpass,
                    ConfirmPassword = strpass,
                    RoleId = Convert.ToInt32(ddlRole.SelectedValue)
                };
                new DaUser().SaveUpdateUser(user);
                LoadUsers();
                lblMsg.Text = UIMessage.Message2User("User saved successfully", UserUILookType.Success);
                btnReset_Click(null, e);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionHelper.DefaultConnectionString))
                {
                    connection.Open();
                    Label lblUserId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblUserId");
                    lblId.Text = lblUserId.Text;
                    var user = new DaLogIn().GetUser(connection, Convert.ToInt32(lblUserId.Text));
                    if (user != null)
                    {
                        lblId.Text = lblUserId.Text;
                        txtUserName.Text = user.UserName;
                        txtPassword.Text = user.Password;
                        txtConfirmPassword.Text = user.ConfirmPassword;
                        if (user.RoleId > 0)
                            ddlRole.SelectedValue = user.RoleId.ToString();
                        else
                            ddlRole.SelectedIndex = 0;
                        lblPassword.Text = user.Password;
                        chkPass.Visible = true;
                        chkPass.Checked = false;
                        ChangePasswordMode(false);
                        btnCreate.Text = "Update User";
                    }
                    lblMsg.Text = "";
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            ChangePasswordMode(chkPass.Checked);
        }

        private void ChangePasswordMode(bool flag)
        {
            txtPassword.Enabled = flag;
            txtPassword.CausesValidation = flag;
            txtPassword.ValidationGroup = flag ? "Create" : "";
            vtxtPassword.ValidationGroup = flag ? "Create" : "";
            txtConfirmPassword.Enabled = flag;
            txtConfirmPassword.CausesValidation = flag;
            txtConfirmPassword.ValidationGroup = flag ? "Create" : "";
            vtxtConfirmPassword.ValidationGroup = flag ? "Create" : "";
            PasswordCompare.ValidationGroup = flag ? "Create" : "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblId.Text = "0";
            txtUserName.Text = "";
            btnCreate.Text = "Create User";
            lblPassword.Text = "";
            chkPass.Checked = true;
            chkPass.Visible = false;
            ChangePasswordMode(true);
            if (sender != null)
            {
                lblMsg.Text = "";
            }
        }
    }
}