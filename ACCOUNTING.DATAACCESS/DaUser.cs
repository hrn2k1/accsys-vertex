﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using Accounting.Utility;
using System.Data;
using Accounting.Entity;

namespace Accounting.DataAccess
{
    public class DaUser
    {
        public DaUser() { }

        public DataTable getUser(SqlConnection con)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = null;
            try
            {
                if (isSuperUser(LogInInfo.UserID) == true)
                {
                    da = new SqlDataAdapter("Select * FROM Users Order by UserName", con);
                }
                else
                {
                    da = new SqlDataAdapter("Select * FROM Users WHERE RoleId != @RoleId Order by UserName", con);
                    da.SelectCommand.Parameters.Add("@RoleId", SqlDbType.Int).Value = 1;
                }
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public DataTable getUser(int RoleId, SqlConnection con)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select UserID FROM Users WHERE (RoleId = @RoleId)  Order by UserID", con);
                da.SelectCommand.Parameters.Add("@RoleId", SqlDbType.Int).Value = RoleId;
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        public ArrayList getUser(int id)
        {
            ArrayList list = new ArrayList();
            SqlConnection con = null;
            SqlCommand com = null;

            try
            {
                con = ConnectionHelper.getConnection();
                com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "Select * FROM Users WHERE (UserID = @UserID OR @UserID=0)  Order by UserName";
                com.Parameters.Add("@UserID", SqlDbType.Int).Value = id;
                IDataReader oReader = com.ExecuteReader();
                while (oReader.Read())
                {
                    list.Add(CreateObject(oReader));
                }
                oReader.Close();
                ConnectionHelper.closeConnection(con);
            }
            catch (Exception Ex)
            {
                throw new Exception("Can not get User" + Ex.Message);
            }
            return list;
        }
        public ArrayList getUser(int id, int CompanyID)
        {
            ArrayList list = new ArrayList();
            SqlConnection con = null;
            SqlCommand com = null;
            try
            {
                con = ConnectionHelper.getConnection();
                com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "Select * FROM Users WHERE (UserID = @UserID OR @UserID=0)  Order by UserName";
                com.Parameters.Add("@UserID", SqlDbType.Int).Value = id;

                IDataReader oReader = com.ExecuteReader();
                while (oReader.Read())
                {
                    list.Add(CreateObject(oReader));
                }
                oReader.Close();
                ConnectionHelper.closeConnection(con);
            }
            catch (Exception Ex)
            {
                throw new Exception("Can not get User" + Ex.Message);
            }
            return list;
        }

        public int SaveUpdateUser(User objUser)
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

                com.CommandText = "SELECT COUNT(UserID) FROM Users WHERE UserName LIKE @UserName0 AND UserID != @UserID0";
                com.Parameters.Add("@UserName0", SqlDbType.VarChar, 50).Value = objUser.UserName;
                com.Parameters.Add("@UserID0", SqlDbType.Int).Value = objUser.UserID;
                int count = GlobalFunctions.isNull(com.ExecuteScalar(), 0);
                if (count > 0)
                {
                    throw new Exception("User already exists with name '" + objUser.UserName + "'");
                }
                if (objUser.UserID == 0)
                {
                    objUser.UserID = ConnectionHelper.GetID(con, trans, "UserID", "Users");

                    com.CommandText = "INSERT INTO Users(UserID, UserName, Password, ConfirmPassword, RoleId)"
                                      + " VALUES (@UserID,@UserName,@Password,@ConfirmPassword,@RoleId)";

                }
                else
                {
                    com.CommandText = "UPDATE Users SET UserName = @UserName, Password = @Password, ConfirmPassword = @ConfirmPassword, RoleId = @RoleId"
                                    + " WHERE (UserID = @UserID)";
                }
                com.Parameters.Add("@UserID", SqlDbType.Int).Value = objUser.UserID;
                com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = objUser.UserName;
                com.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = objUser.Password;
                com.Parameters.Add("@ConfirmPassword", SqlDbType.NVarChar, 50).Value = objUser.ConfirmPassword;
                com.Parameters.Add("@RoleId", SqlDbType.Int).Value = objUser.RoleId;

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
            return objUser.UserID;
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

                    com.CommandText = "INSERT INTO Users(UserID, UserName, Password, ConfirmPassword, RoleId)"
                                      + " VALUES     (@UserID,@UserName,@Password,@ConfirmPassword,@RoleId)";

                }
                else
                {
                    com.CommandText = "UPDATE    Users SET UserName = @UserName, Password = @Password, ConfirmPassword = @ConfirmPassword, RoleId = @RoleId"
                                    + " WHERE (UserID = @UserID)";
                }
                com.Parameters.Add("@UserID", SqlDbType.Int).Value = objUser.UserID;
                com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = objUser.UserName;
                com.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = objUser.Password;
                com.Parameters.Add("@ConfirmPassword", SqlDbType.NVarChar, 50).Value = objUser.ConfirmPassword;
                com.Parameters.Add("@RoleId", SqlDbType.Int).Value = objUser.RoleId;

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
        public int SaveUpdateUser(User objUser, SqlConnection con, SqlTransaction trans)
        {
            SqlCommand com = null;
            try
            {
                com = new SqlCommand();
                com.Connection = con;
                com.Transaction = trans;
                if (objUser.UserID == 0)
                {
                    objUser.UserID = ConnectionHelper.GetID(con, "UserID", "Users");

                    com.CommandText = "INSERT INTO Users(UserID, UserName, Password, ConfirmPassword, RoleId)"
                                      + " VALUES     (@UserID,@UserName,@Password,@ConfirmPassword,@RoleId)";
                }
                else
                {
                    com.CommandText = "UPDATE    Users SET UserName = @UserName, Password = @Password, ConfirmPassword = @ConfirmPassword, RoleId = @RoleId"
                                    + " WHERE AND (UserID = @UserID)";
                }
                com.CommandType = CommandType.Text;
                com.Parameters.Add("@UserID", SqlDbType.Int).Value = objUser.UserID;
                com.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = objUser.UserName;
                com.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = objUser.Password;
                com.Parameters.Add("@ConfirmPassword", SqlDbType.NVarChar, 50).Value = objUser.ConfirmPassword;
                com.Parameters.Add("@RoleId", SqlDbType.Int).Value = objUser.RoleId;

                com.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return objUser.UserID;
        }
        public string SaveUpdateRolePrivilege(RolePrivilege objRolePrivilege, SqlConnection con, SqlTransaction trans)
        {
            SqlCommand com = null;
            try
            {
                com = new SqlCommand("spSaveOrUpdateRolePrivilege", con, trans);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Role", SqlDbType.VarChar, 50).Value = objRolePrivilege.Role;
                com.Parameters.Add("@FriendlyName", SqlDbType.VarChar, 100).Value = objRolePrivilege.FriendlyName;
                com.Parameters.Add("@CanEdit", SqlDbType.TinyInt).Value = objRolePrivilege.CanEdit;
                com.Parameters.Add("@CanDelete", SqlDbType.TinyInt).Value = objRolePrivilege.CanDelete;
                com.Parameters.Add("@CanAdd", SqlDbType.TinyInt).Value = objRolePrivilege.CanAdd;
                com.Parameters.Add("@CanView", SqlDbType.TinyInt).Value = objRolePrivilege.CanView;
                com.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                com.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return objRolePrivilege.Role;
        }
        public int SaveUpdateUserPrivilege(UserPrivilege objUserPrivilege, SqlConnection con, SqlTransaction trans)
        {
            SqlCommand com = null;
            try
            {
                com = new SqlCommand("spSaveOrUpdatePrivilege", con, trans);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@UserID", SqlDbType.Int).Value = objUserPrivilege.UserID;
                com.Parameters.Add("@FriendlyName", SqlDbType.VarChar, 100).Value = objUserPrivilege.FriendlyName;
                com.Parameters.Add("@CanEdit", SqlDbType.TinyInt).Value = objUserPrivilege.CanEdit;
                com.Parameters.Add("@CanDelete", SqlDbType.TinyInt).Value = objUserPrivilege.CanDelete;
                com.Parameters.Add("@CanAdd", SqlDbType.TinyInt).Value = objUserPrivilege.CanAdd;
                com.Parameters.Add("@CanView", SqlDbType.TinyInt).Value = objUserPrivilege.CanView;
                com.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;

                com.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return objUserPrivilege.UserID;
        }
        public void DeleteUser(int id)
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
                com.CommandText = "DELETE FROM Users WHERE UserID = @UserID";
                com.Parameters.Add("@UserID", SqlDbType.Int).Value = id;
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
                throw new Exception("Can not get User" + Ex.Message);
            }
        }
        public void DeleteUser(int id, SqlConnection con, SqlTransaction trans)
        {
            SqlCommand com = null;
            try
            {
                com = new SqlCommand("DELETE FROM Users WHERE UserID = @UserID", con, trans);
                //com.Connection = con;
                //com.Transaction = trans;
                //com.CommandText = "DELETE FROM Users WHERE UserID = @UserID";
                com.Parameters.Add("@UserID", SqlDbType.Int).Value = id;
                com.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
        public bool isSuperUser(int userID)
        {
            bool superUser = false;
            SqlConnection con = null;
            SqlCommand com = null;
            string role = "";

            try
            {
                con = ConnectionHelper.getConnection();
                com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "Select ISNULL(RoleName,'') FROM Users LEFT JOIN Roles ON Users.RoleId = Roles.RoleId WHERE UserID = @userID";
                com.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                role = (string)com.ExecuteScalar();
                ConnectionHelper.closeConnection(con);
            }
            catch (Exception Ex)
            {
                superUser = false;
                throw new Exception("Can not get superUser. " + Ex.Message);
            }
            if (role.ToLower() == "SuperAdministrator".ToLower())
                superUser = true;
            return superUser;
        }
        public DataTable GetFrmModule(SqlConnection con)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT     DISTINCT ModulesName, FriendlyName, ParentMenuName, MenuName"
                                + " FROM         Modules WHERE     (MenuName IN"
                               + " (SELECT     ParentMenuName FROM          Modules AS Modules_1"
                               + " WHERE      (ModulesName IS NOT NULL))) AND Software = 'ACC_INV'", con);
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public DataTable getRolePrivilege(string strRole, string strParentMenuName, SqlConnection con)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("spGetAccRolePrivileges", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Role", SqlDbType.VarChar, 50).Value = strRole;
                da.SelectCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                da.SelectCommand.Parameters.Add("@ModulesName", SqlDbType.VarChar, 100).Value = "all";
                da.SelectCommand.Parameters.Add("@ParentMenuName", SqlDbType.VarChar, 200).Value = strParentMenuName;

                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return dt;
        }
        #region CreateObjects
        private User CreateObject(IDataReader oReader)
        {
            User objUser = new User();

            NullManager Reader = new NullManager(oReader);
            try
            {
                objUser.UserID = Reader.GetInt32("UserID");
                objUser.UserName = Reader.GetString("UserName");
                objUser.Password = Reader.GetString("Password");
                objUser.ConfirmPassword = Reader.GetString("ConfirmPassword");
                objUser.RoleId = Reader.GetInt32("RoleId");
            }
            catch (Exception Ex)
            {
                throw new Exception("Error while creating object" + Ex.Message);
            }
            return objUser;
        }
        public User getUsers(int UserID, SqlConnection con)
        {
            User obUser = new User();
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * FROM Users WHERE (UserID = @UserID) Order by UserName", con);
                da.SelectCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                da.Fill(dt);
                da.Dispose();
                if (dt.Rows.Count == 0) return null;
                obUser.UserID = dt.Rows[0].Field<int>("UserID");
                obUser.UserName = dt.Rows[0].Field<object>("UserName").ToString();
                obUser.RoleId = dt.Rows[0].Field<int>("RoleId");
                //obUser.Password = dt.Rows[0].Field<object>("Password").ToString();
                obUser.Password = GlobalFunctions.Decode(dt.Rows[0].Field<object>("Password").ToString(), GlobalFunctions.CypherText);
                //GlobalFunctions.Decode(
                obUser.ConfirmPassword = GlobalFunctions.Decode(dt.Rows[0].Field<object>("ConfirmPassword").ToString(), GlobalFunctions.CypherText);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obUser;
        }
        #endregion
    }
}
