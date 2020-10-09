using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Accounting.Entity;
using Accounting.Utility;

namespace Accounting.DataAccess
{
    public class DaLogIn
    {
        public DaLogIn() { }
        public DataTable GetCompant(SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Company", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;

        }

        public DataTable GetUser(int numCompanyID, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Users where CompanyID=@CompanyID", con);
            da.SelectCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = numCompanyID;
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;

        }
        public bool ValidateUserPassword(string userName, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionHelper.DefaultConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(UserID) FROM Users WHERE UserName=@UserName AND Password=@Password", connection))
                {
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = userName;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = password;
                    connection.Open();
                    var obj = cmd.ExecuteScalar();
                    connection.Close();
                    if (obj == null || obj == DBNull.Value) return false;
                    if (Convert.ToInt32(obj) > 0) return true;
                }
            }
            return false;
        }
    }
}
