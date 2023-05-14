using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Data;
using System.Data.SqlClient;

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
        public User GetUser(SqlConnection con, int companyId, string userName)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Users where CompanyID=@CompanyID AND UserName = @UserName", con);
            da.SelectCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyId;
            da.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = userName;
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            if (dt.Rows.Count > 0)
            {
                return new User()
                {
                    UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString()),
                    UserName = dt.Rows[0]["UserName"].ToString(),
                    Role = dt.Rows[0]["Role"].ToString()
                };
            }
            return null;

        }

        public User GetUser(SqlConnection con, int userId)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Users where UserID=@UserId", con);
            da.SelectCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            if (dt.Rows.Count > 0)
            {
                var user = new User()
                {
                    UserID = GlobalFunctions.isNull(dt.Rows[0]["UserID"], 0),
                    UserName = GlobalFunctions.isNull(dt.Rows[0]["UserName"], ""),
                    Role = GlobalFunctions.isNull(dt.Rows[0]["Role"], ""),
                    CompanyID = GlobalFunctions.isNull(dt.Rows[0]["CompanyID"], 0),
                    Password = GlobalFunctions.isNull(dt.Rows[0]["Password"], "")
                };
                if (!string.IsNullOrEmpty(user.Password))
                {
                    user.Password = GlobalFunctions.Decode(user.Password, GlobalFunctions.CypherText);
                    user.ConfirmPassword = user.Password;
                }
                return user;
            }
            return null;

        }
        public bool ValidateUserPassword(string userName, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionHelper.DefaultConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(UserID) FROM Users WHERE UserName=@UserName AND Password=@Password", connection))
                {
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 100).Value = userName;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = password;
                    connection.Open();
                    var obj = cmd.ExecuteScalar();
                    connection.Close();
                    if (obj == null || obj == DBNull.Value) return false;
                    if (Convert.ToInt32(obj) > 0) return true;
                }
            }
            return false;
        }

        public bool ValidateUserPassword(int userId, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionHelper.DefaultConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(UserID) FROM Users WHERE UserID=@UserID AND Password=@Password", connection))
                {
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = password;
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
