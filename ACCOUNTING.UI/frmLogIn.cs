using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.DataAccess;
using System.Data.SqlClient;
using Accounting.Utility;
using Accounting.Entity;

namespace Accounting.UI
{
    public partial class frmLogIn : Form
    {
        SqlConnection conn = null;
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void btnCalcel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadCompany()
        {
            try
            {
                DaLogIn obj = new DaLogIn();
                DataTable dtt = new DataTable();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dtt = obj.GetCompant(conn);
                cmbCompanyName.DataSource = dtt;
                cmbCompanyName.DisplayMember = "CompanyName";
                cmbCompanyName.ValueMember = "CompanyID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LoadUser()
        {
            try
            {
                DaLogIn objl = new DaLogIn();
                DataTable dt = new DataTable();
                int ComID = (int)cmbCompanyName.SelectedValue;
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                dt = objl.GetUser(ComID, conn);
                cmbUserName.DataSource = dt;
                cmbUserName.DisplayMember = "UserName";
                cmbUserName.ValueMember = "UserID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            try
            {
                conn = ConnectionHelper.getConnection();
                LoadCompany();
                LoadUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private User CreateObject(User userobj)
        {
            try
            {
                userobj.CompanyID = (int)cmbCompanyName.SelectedValue;
                userobj.UserID = (int)cmbUserName.SelectedValue;
                userobj.Password = txtPassword.Text;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return userobj;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            #region
            try
            {
                DateTime expireDate = new DateTime();
                string cmnt = GlobalFunctions.getComments();
                string exDate = GlobalFunctions.DC(cmnt);
                if (cmnt != "NULL")
                {
                    expireDate = GlobalFunctions.Todate(exDate);

                    if (DateTime.Now.Date >= expireDate.Date)
                    {
                        MessageBox.Show("Unable to connect database.", "Database has faced a serious error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.Message);
                return;
            }
            #endregion
            try
            {
                if (cmbUserName.Items.Count ==0 || cmbUserName.SelectedValue == null)
                {
                    MessageBox.Show("Invalid UserName");
                    return;
                }
                //DaLogIn objda = new DaLogIn();
                //User objuser = new User();
                //CreateObject(objuser);
                // string strpass = objda.SetUserInfo(objuser, conn);
                string strpass = GlobalFunctions.Decode(((DataRowView)cmbUserName.SelectedItem).Row.Field<string>("password"), GlobalFunctions.CypherText);
                    //((DataRowView)cmbUserName.SelectedItem).Row.Field<string>("password");
                if (strpass == txtPassword.Text)
                {
                    LogInInfo.CompanyID = (int)cmbCompanyName.SelectedValue;
                    LogInInfo.UserID = (int)cmbUserName.SelectedValue;
                    LogInInfo.ModifiedDate = DateTime.Now;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Password,try again");
                    txtPassword.Text = "";
                    txtPassword.Focus();
                    return;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbCompanyName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCompanyName.SelectedValue == null || cmbCompanyName.SelectedValue.GetType() == typeof(DataRowView)) return;
                LoadUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLogIn_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                FormColorClass.ColorForm(this, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void frmLogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(conn);
        }
    }
}
