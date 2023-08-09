using Accounting.DataAccess;
using Accounting.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;
using System.Diagnostics;

namespace AccSys.Web
{
    public partial class Sql : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnExecute_Click(object sender, EventArgs e)
        {
            SqlConnection connection = null;
            SqlTransaction trans = null;
            try
            {
                connection = ConnectionHelper.getConnection();
                trans = connection.BeginTransaction();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand(txtSql.Text, connection, trans))
                {
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
                connection.Close();
                lblMsg.Text = UIMessage.Message2User("Successfully executed", UserUILookType.Success);
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                if (connection != null) connection.Close();
                lblMsg.Text = ex.CustomDialogMessage();
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        protected void btnExeQuery_Click(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                using (var adapter = new SqlDataAdapter(txtSql.Text, ConnectionHelper.DefaultConnectionString))
                {
                    adapter.Fill(dataTable);
                    adapter.Dispose();
                }
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}