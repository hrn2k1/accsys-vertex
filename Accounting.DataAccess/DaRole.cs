using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Accounting.DataAccess
{
    public class DaRole
    {
        public DaRole() { }

        public DataTable GetRoles(SqlConnection con)
        {
            DataTable dt = new DataTable();
            using (var dataAdaper = new SqlDataAdapter("SELECT * FROM Roles ORDER BY RoleName", con))
            {
                dataAdaper.Fill(dt);
                dataAdaper.Dispose();
            }
            return dt;
        }

        public Role GetRole(int id)
        {
            DataTable dt = new DataTable();
            using (var dataAdaper = new SqlDataAdapter("SELECT * FROM Roles WHERE RoleId=" + id, ConnectionHelper.getConnection()))
            {
                dataAdaper.Fill(dt);
                dataAdaper.Dispose();
            }
            if (dt.Rows.Count > 0)
            {
                return new Role
                {
                    RoleId = GlobalFunctions.isNull(dt.Rows[0]["RoleId"], 0),
                    RoleName = GlobalFunctions.isNull(dt.Rows[0]["RoleName"], "")
                };
            }
            return null;
        }

        public Role GetRole(int id, SqlConnection con)
        {
            DataTable dt = new DataTable();
            using (var dataAdaper = new SqlDataAdapter("SELECT * FROM Roles WHERE RoleId=" + id, con))
            {
                dataAdaper.Fill(dt);
                dataAdaper.Dispose();
            }
            if (dt.Rows.Count > 0)
            {
                return new Role
                {
                    RoleId = GlobalFunctions.isNull(dt.Rows[0]["RoleId"], 0),
                    RoleName = GlobalFunctions.isNull(dt.Rows[0]["RoleName"], "")
                };
            }
            return null;
        }

        public Role GetRole(string roleName)
        {
            DataTable dt = new DataTable();
            using (var dataAdaper = new SqlDataAdapter("SELECT * FROM Roles WHERE RoleName='" + roleName + "'", ConnectionHelper.getConnection()))
            {
                dataAdaper.Fill(dt);
                dataAdaper.Dispose();
            }
            if (dt.Rows.Count > 0)
            {
                return new Role
                {
                    RoleId = GlobalFunctions.isNull(dt.Rows[0]["RoleId"], 0),
                    RoleName = GlobalFunctions.isNull(dt.Rows[0]["RoleName"], "")
                };
            }
            return null;
        }

        public int SaveUpdateRole(Role objRole)
        {
            SqlConnection con = null;
            SqlTransaction trans = null;
            try
            {
                con = ConnectionHelper.getConnection();
                trans = con.BeginTransaction();
                var com = new SqlCommand();

                com.Connection = con;
                com.Transaction = trans;

                com.CommandText = "SELECT COUNT(RoleId) FROM Roles WHERE RoleName LIKE @RoleName0 AND RoleId != @RoleId0";
                com.Parameters.Add("@RoleName0", SqlDbType.VarChar, 50).Value = objRole.RoleName;
                com.Parameters.Add("@RoleId0", SqlDbType.Int).Value = objRole.RoleId;
                int count = GlobalFunctions.isNull(com.ExecuteScalar(), 0);
                if (count > 0)
                {
                    throw new Exception("Role already exists with name '" + objRole.RoleName + "'");
                }
                if (objRole.RoleId == 0)
                {
                    com.CommandText = "INSERT INTO Roles(RoleName) VALUES (@RoleName)";
                }
                else
                {
                    com.CommandText = "UPDATE Roles SET RoleName = @RoleName WHERE RoleId = @RoleId";
                }
                if (objRole.RoleId != 0)
                    com.Parameters.Add("@RoleId", SqlDbType.Int).Value = objRole.RoleId;
                com.Parameters.Add("@RoleName", SqlDbType.VarChar, 50).Value = objRole.RoleName;
                com.ExecuteNonQuery();
                trans.Commit();

                ConnectionHelper.closeConnection(con);
            }
            catch (Exception Ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                    ConnectionHelper.closeConnection(con);
                }
                throw new Exception("Can not save or update. Error: " + Ex.Message);
            }
            return objRole.RoleId;
        }
        public int SaveUpdateUser(User objUser, SqlConnection con)
        {
            SqlCommand com = null;
            SqlTransaction trans = null;
            try
            {
                trans = con.BeginTransaction();
                com = new SqlCommand();
                com.Connection = con;
                com.Transaction = trans;
                if (objUser.UserID == 0)
                {
                    //objUser.UserID = ConnectionHelper.GetID(con, "UserID", "Users");
                    //objUser.UserID = ConnectionHelper.GetID(con, trans, "UserID", "Users");
                    objUser.UserID = ConnectionHelper.GenerateID(con, com, "UserID", "Users");

                    com.CommandText = "INSERT INTO Users(UserID, UserName, Password, ConfirmPassword, Role, CompanyID)"
                                      + " VALUES     (@UserID,@UserName,@Password,@ConfirmPassword,@Role,@CompanyID)";

                }
                else
                {
                    com.CommandText = "UPDATE    Users SET UserName = @UserName, Password = @Password, ConfirmPassword = @ConfirmPassword, Role = @Role"
                                    + " WHERE     (CompanyID = @CompanyID) AND (UserID = @UserID)";
                }
                com.Parameters.Add("@UserID", SqlDbType.Int).Value = objUser.UserID;
                com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = objUser.UserName;
                com.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = objUser.Password;
                com.Parameters.Add("@ConfirmPassword", SqlDbType.NVarChar, 50).Value = objUser.ConfirmPassword;
                com.Parameters.Add("@RoleId", SqlDbType.Int).Value = objUser.RoleId;
                com.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;

                com.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception Ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                    ConnectionHelper.closeConnection(con);
                }
                throw new Exception("Can not save or update" + Ex.Message);
            }
            return objUser.UserID;
        }
        public void DeleteRole(int id)
        {
            SqlConnection con = null;
            SqlCommand com = null;
            SqlTransaction trans = null;
            try
            {
                con = ConnectionHelper.getConnection();
                trans = con.BeginTransaction();
                com = new SqlCommand();

                com.Connection = con;
                com.Transaction = trans;
                com.CommandText = "DELETE FROM Roles WHERE RoleId = @RoleId";
                com.Parameters.Add("@RoleId", SqlDbType.Int).Value = id;
                com.ExecuteNonQuery();
                trans.Commit();

                ConnectionHelper.closeConnection(con);
            }
            catch (Exception Ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                    ConnectionHelper.closeConnection(con);
                }
                throw new Exception("Can not delete role" + Ex.Message);
            }
        }



    }
}
