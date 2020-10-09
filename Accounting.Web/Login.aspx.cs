﻿using Accounting.DataAccess;
using Accounting.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using Tools;

namespace Accounting.Web
{
    public partial class Login : System.Web.UI.Page
    {
        private void LoadCompany(SqlConnection conn)
        {
            System.Web.UI.WebControls.Login Login1 = (System.Web.UI.WebControls.Login)LoginView1.FindControl("Login1");
            var control = Login1.FindControl("ddlCompany");
            if (control != null)
            {
                var ddlCompany = (DropDownList)control;
                DaLogIn obj = new DaLogIn();
                DataTable dtt = new DataTable();
                dtt = obj.GetCompant(conn);
                ddlCompany.DataSource = dtt;
                ddlCompany.DataTextField = "CompanyName";
                ddlCompany.DataValueField = "CompanyID";
                ddlCompany.DataBind();
                if (!string.IsNullOrWhiteSpace(ddlCompany.SelectedValue))
                {
                    var companyId = Convert.ToInt32(ddlCompany.SelectedValue);
                    LoadUser(conn, companyId);
                }
            }
        }
        private void LoadUser(SqlConnection conn, int companyId)
        {
            System.Web.UI.WebControls.Login Login1 = (System.Web.UI.WebControls.Login)LoginView1.FindControl("Login1");
            var control = Login1.FindControl("UserName");
            if (control != null)
            {
                var ddlUser = (DropDownList)control;
                DaLogIn objl = new DaLogIn();
                DataTable dt = new DataTable();
                dt = objl.GetUser(companyId, conn);
                ddlUser.DataSource = dt;
                ddlUser.DataTextField = "UserName";
                ddlUser.DataValueField = "UserName";
                ddlUser.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    using (var connection = new SqlConnection(ConnectionHelper.DefaultConnectionString))
                    {
                        connection.Open();
                        LoadCompany(connection);
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            try
            {
                System.Web.UI.WebControls.Login Login1 = (System.Web.UI.WebControls.Login)LoginView1.FindControl("Login1");
                var control = Login1.FindControl("UserName");
                if (control != null)
                {
                    var ddlUser = (DropDownList)control;
                    Session["UserName"] = ddlUser.SelectedItem.Text;
                    //Session["UserId"] = ddlUser.SelectedItem.Value;
                    //Session["UserRoles"] = userRoleList;
                    //Session["IsSuperAdmin"] = isSuperAdmin;
                    control = Login1.FindControl("ddlCompany");
                    if (control != null)
                    {
                        var ddlCompany = (DropDownList)control;
                        int companyId = Convert.ToInt32(ddlCompany.SelectedValue);
                        Session["CompanyId"] = companyId;
                        var objDaCompany = new DaCompany();
                        var company = objDaCompany.GetCompany(companyId);
                        var logo = company.CompanyLogo;
                        if(logo != null)
                        {
                            var logo64 = Convert.ToBase64String(logo);
                        }
                        Session["Company"] = new CompanyInformation(company);
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }

        }
        protected void LoginStatus1_LoggingOut(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
        {
            try
            {
                Session.Clear();
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }

        }

        protected void Login1_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {
            System.Web.UI.WebControls.Login Login1 = (System.Web.UI.WebControls.Login)LoginView1.FindControl("Login1");
            var control = Login1.FindControl("UserName");
            if (control != null)
            {
                var ddlUser = (DropDownList)control;
                Login1.UserName = ddlUser.SelectedItem.Text;
                string strpass = string.IsNullOrWhiteSpace(Login1.Password) ? Login1.Password.Trim() : GlobalFunctions.Encode(Login1.Password, GlobalFunctions.CypherText);
                var objDaLogin = new DaLogIn();
                e.Authenticated = objDaLogin.ValidateUserPassword(ddlUser.SelectedItem.Text, Login1.Password);
            }
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionHelper.DefaultConnectionString))
                {
                    connection.Open();
                    System.Web.UI.WebControls.Login Login1 = (System.Web.UI.WebControls.Login)LoginView1.FindControl("Login1");
                    var control = Login1.FindControl("ddlCompany");
                    if (control != null)
                    {
                        var ddlCompany = (DropDownList)control;
                        if (!string.IsNullOrWhiteSpace(ddlCompany.SelectedValue))
                        {
                            var companyId = Convert.ToInt32(ddlCompany.SelectedValue);
                            LoadUser(connection, companyId);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}