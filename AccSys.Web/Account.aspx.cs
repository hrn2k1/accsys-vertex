using Accounting.DataAccess;
using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Data.SqlClient;
using Tools;

namespace AccSys.Web
{
    public partial class AccountPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                   var userName = Tools.Utility.IsNull<string>(Session["UserName"], "");
                    using (var connection = new SqlConnection(ConnectionHelper.DefaultConnectionString))
                    {
                        connection.Open();
                        DaLogIn objl = new DaLogIn();
                        var user = objl.GetUser(connection, userName);
                        if (user != null)
                        {
                            lblId.Text = user.UserID.ToString();
                            lblUserName.Text = user.UserName;
                            lblRole.Text = user.Role;
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string cuurentPass = string.IsNullOrWhiteSpace(txtCurrentPassword.Text) ? txtCurrentPassword.Text.Trim() : GlobalFunctions.Encode(txtCurrentPassword.Text, GlobalFunctions.CypherText);
                int userId = Convert.ToInt32(lblId.Text);
                if(new DaLogIn().ValidateUserPassword(userId, cuurentPass) == false)
                {
                    throw new Exception("Current password is wrong.");
                }
                if(txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                {
                    throw new Exception("New password and confirm password mismatch.");
                }
                string strpass = string.IsNullOrWhiteSpace(txtPassword.Text) ? txtPassword.Text.Trim() : GlobalFunctions.Encode(txtPassword.Text, GlobalFunctions.CypherText);

                User user = new User()
                {
                    UserID = userId,
                    CompanyID = Tools.Utility.IsNull<int>(Session["CompanyId"], 0),
                    UserName = lblUserName.Text.Trim(),
                    Password = strpass,
                    ConfirmPassword = strpass,
                    Role = lblRole.Text
                };
                new DaUser().SaveUpdateUser(user);
                lblMsg.Text = UIMessage.Message2User("Password changed successfully", UserUILookType.Success);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}