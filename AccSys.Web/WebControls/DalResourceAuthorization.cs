using System;
using System.Data;
using System.Data.SqlClient;
using Tools;
using System.Configuration;
using Accounting.Utility;
using Accounting.DataAccess;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Linq;

namespace AccSys.Web.WebControls
{
    public class DalResourceAuthorization
    {
        public static List<ResourceAuthorization> GetAuthorizationResources(int userId)
        {
            var access = new List<ResourceAuthorization>();
            var user = new DaLogIn().GetUser(ConnectionHelper.getConnection(), userId);
            DataTable dt = new DataTable();
            if (user != null && user.RoleId > 0)
            {
                string qstr = @"SELECT Resources.ResourceId,GroupName,ResourceName,ResourceType,ResourcePath,ResourcesInRole.RoleId, RoleName,CanView,CanAdd,CanEdit,CanDelete
                            FROM Resources LEFT JOIN ResourcesInRole ON Resources.ResourceID = ResourcesInRole.ResourceID AND RoleId=@RoleId
                            LEFT JOIN Roles ON Roles.RoleId = ResourcesInRole.RoleId
                            ORDER BY GroupName,ResourceName";

                using (SqlDataAdapter da = new SqlDataAdapter(qstr, ConnectionHelper.DefaultConnectionString))
                {
                    da.SelectCommand.Parameters.Add("@RoleId", SqlDbType.Int).Value = user.RoleId;
                    da.Fill(dt);
                    da.Dispose();
                }

                foreach (DataRow dr in dt.Rows)
                {
                    access.Add(Map(dr, user.UserID, user.UserName));
                }
            }
            return access;
        }

        public static ResourceAuthorization GetAuthorization(HttpSessionState Session, string ResourcePath)
        {
            if (Session.IsSuperAdmin())
            {
                return new ResourceAuthorization
                {
                    CanAdd = true,
                    CanDelete = true,
                    CanEdit = true,
                    CanView = true,
                    ResourcePath = ResourcePath,
                    UserName = Session.UserName()
                };
            }
            var userRoleAccess = Session.UserRoleAccess();

            var access = userRoleAccess.FirstOrDefault(x => x.ResourcePath.ToLower().Contains(ResourcePath.ToLower()));

            if (access != null)
            {
                return access;
            }
            else
            {
                return new ResourceAuthorization()
                {
                    ResourcePath = ResourcePath,
                    UserName = Session.UserName(),
                    CanAdd = false,
                    CanEdit = false,
                    CanDelete = false,
                    CanView = false
                };
            }


        }
        public static ResourceAuthorization Map(DataRow dataRow)
        {
            ResourceAuthorization obj = new ResourceAuthorization();
            try
            {
                obj.CanAdd = Utility.IsNull<bool>(dataRow["CanAdd"], false);
                obj.CanDelete = Utility.IsNull<bool>(dataRow["CanDelete"], false);
                obj.CanEdit = Utility.IsNull<bool>(dataRow["CanEdit"], false);
                obj.CanView = Utility.IsNull<bool>(dataRow["CanView"], false);
                obj.GroupName = Utility.IsNull<string>(dataRow["GroupName"], "");
                obj.ResourceID = Utility.IsNull<int>(dataRow["ResourceID"], 0);
                obj.ResourceName = Utility.IsNull<string>(dataRow["ResourceName"], "");
                obj.ResourcePath = Utility.IsNull<string>(dataRow["ResourcePath"], "");
                obj.ResourceType = Utility.IsNull<string>(dataRow["ResourceType"], "");
                obj.RoleId = Utility.IsNull<int>(dataRow["RoleId"], 0);
                obj.RoleName = Utility.IsNull<string>(dataRow["RoleName"], "");
                obj.UserID = Utility.IsNull<int>(dataRow["UserID"], 0);
                obj.UserName = Utility.IsNull<string>(dataRow["UserName"], "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }
        public static ResourceAuthorization Map(DataRow dataRow, int userId, string userName)
        {
            ResourceAuthorization obj = new ResourceAuthorization();
            try
            {
                obj.CanAdd = Utility.IsNull<bool>(dataRow["CanAdd"], false);
                obj.CanDelete = Utility.IsNull<bool>(dataRow["CanDelete"], false);
                obj.CanEdit = Utility.IsNull<bool>(dataRow["CanEdit"], false);
                obj.CanView = Utility.IsNull<bool>(dataRow["CanView"], false);
                obj.GroupName = Utility.IsNull<string>(dataRow["GroupName"], "");
                obj.ResourceID = Utility.IsNull<int>(dataRow["ResourceID"], 0);
                obj.ResourceName = Utility.IsNull<string>(dataRow["ResourceName"], "");
                obj.ResourcePath = Utility.IsNull<string>(dataRow["ResourcePath"], "");
                obj.ResourceType = Utility.IsNull<string>(dataRow["ResourceType"], "");
                obj.RoleId = Utility.IsNull<int>(dataRow["RoleId"], 0);
                obj.RoleName = Utility.IsNull<string>(dataRow["RoleName"], "");
                obj.UserID = userId;
                obj.UserName = userName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }
        public static DataTable GetResources(string ResourceType)
        {
            DataTable dtResources = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Resources WHERE ResourceType=@ResourceType ORDER BY GroupName,ResourceName", ConnectionHelper.DefaultConnectionString))
                {
                    da.SelectCommand.Parameters.Add("@ResourceType", SqlDbType.VarChar, 50).Value = ResourceType;
                    da.Fill(dtResources);
                    da.Dispose();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dtResources;
        }

        public static DataTable GetResourceGroupNames()
        {
            DataTable dtGroups = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT GroupName FROM Resources", ConnectionHelper.DefaultConnectionString))
            {
                da.Fill(dtGroups);
                da.Dispose();
            }

            return dtGroups;
        }
        public static void SaveResource(int resourceId, string resourceName, string resourcePath, string resourceType, string groupName)
        {
            try
            {
                string qstr = "";

                if (resourceId > 0)
                    qstr = @"UPDATE Resources SET ResourceName=@ResourceName,ResourcePath=@ResourcePath,ResourceType=@ResourceType,GroupName=@GroupName 
                            WHERE ResourceID=@ResourceID";
                else
                    qstr = @"INSERT INTO Resources(ResourceName, ResourcePath, ResourceType, GroupName)
                            VALUES (@ResourceName,@ResourcePath,@ResourceType,@GroupName)";

                using (SqlConnection conn = new SqlConnection(ConnectionHelper.DefaultConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(qstr, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@ResourceName", SqlDbType.NVarChar, 50).Value = resourceName;
                        cmd.Parameters.Add("@ResourcePath", SqlDbType.NVarChar, 100).Value = resourcePath;
                        cmd.Parameters.Add("@ResourceType", SqlDbType.VarChar, 50).Value = resourceType;
                        cmd.Parameters.Add("@GroupName", SqlDbType.NVarChar, 100).Value = groupName;

                        if (resourceId > 0)
                            cmd.Parameters.Add("@ResourceID", SqlDbType.Int).Value = resourceId;
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void DeleteResource(int resourceId)
        {
            try
            {
                if (resourceId <= 0) return;
                string qstr = @"DELETE FROM Resources WHERE ResourceID=@ResourceID";

                using (SqlConnection conn = new SqlConnection(ConnectionHelper.DefaultConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(qstr, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@ResourceID", SqlDbType.Int).Value = resourceId;
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void ResolveResource(string resourceName, string resourcePath, string resourceType, string groupName, Guid applicationID, string applicationName)
        {
            try
            {
                string qstr = @"IF NOT EXISTS(SELECT * FROM  Resources WHERE ResourcePath=@ResourcePath)
                                INSERT INTO Resources(ResourceName, ResourcePath, ResourceType, GroupName)
                                VALUES(@ResourceName,@ResourcePath,@ResourceType,@GroupName)
                                ELSE
                                UPDATE Resources SET ResourceName=@ResourceName,ResourceType=@ResourceType,GroupName=@GroupName 
                                WHERE ResourcePath=@ResourcePath";
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.DefaultConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(qstr, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@ResourceName", SqlDbType.NVarChar, 50).Value = resourceName;
                        cmd.Parameters.Add("@ResourcePath", SqlDbType.NVarChar, 100).Value = resourcePath;
                        cmd.Parameters.Add("@ResourceType", SqlDbType.VarChar, 50).Value = resourceType;
                        cmd.Parameters.Add("@GroupName", SqlDbType.NVarChar, 100).Value = groupName;
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable GetResourcesOfRole(int roleId, string groupName)
        {
            DataTable dtResources = new DataTable();
            try
            {
                string qstr = @"SELECT Resources.ResourceID, Resources.ResourceName, Resources.ResourcePath, Resources.ResourceType, Resources.GroupName, 
                      ISNULL(ResourcesInRole.RoleId,@RoleId) AS RoleId, ISNULL(CanView, 0) AS CanView, ISNULL(CanAdd, 0) AS CanAdd, ISNULL(CanEdit,0) AS CanEdit, 
                      ISNULL(CanDelete,0) AS CanDelete
                      FROM Resources LEFT OUTER JOIN ResourcesInRole ON (Resources.ResourceID = ResourcesInRole.ResourceID AND RoleId=@RoleId)";
                if (groupName.ToLower() != "all")
                    qstr += string.Format(" WHERE ISNULL(GroupName,'')='{0}'", groupName);
                qstr += " ORDER BY GroupName,ResourceName";
                using (SqlDataAdapter da = new SqlDataAdapter(qstr, ConnectionHelper.DefaultConnectionString))
                {
                    da.SelectCommand.Parameters.Add("@RoleId", SqlDbType.Int).Value = roleId;
                    da.SelectCommand.Parameters.Add("@GroupName", SqlDbType.NVarChar, 100).Value = groupName;
                    da.Fill(dtResources);
                    da.Dispose();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dtResources;
        }

        public static void SaveResourcesOfRole(int resourceId, int roleId, bool canView, bool canAdd, bool canEdit, bool canDelete)
        {
            try
            {
                string qstr = @"IF EXISTS(SELECT * FROM ResourcesInRole WHERE ResourceID = @ResourceID AND RoleId = @RoleId)
                                UPDATE ResourcesInRole
                                SET CanView = @CanView, CanAdd = @CanAdd, CanEdit = @CanEdit, CanDelete = @CanDelete
                                WHERE ResourceID = @ResourceID AND RoleId = @RoleId
                                ELSE
                                INSERT INTO ResourcesInRole(ResourceID, RoleId, CanView, CanAdd, CanEdit, CanDelete)
                                VALUES (@ResourceID,@RoleId,@CanView,@CanAdd,@CanEdit,@CanDelete)";


                using (SqlConnection conn = new SqlConnection(ConnectionHelper.DefaultConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(qstr, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@ResourceID", SqlDbType.Int).Value = resourceId;
                        cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = roleId;
                        cmd.Parameters.Add("@CanView", SqlDbType.Bit).Value = canView;
                        cmd.Parameters.Add("@CanAdd", SqlDbType.Bit).Value = canAdd;
                        cmd.Parameters.Add("@CanEdit", SqlDbType.Bit).Value = canEdit;
                        cmd.Parameters.Add("@CanDelete", SqlDbType.Bit).Value = canDelete;
                        if (conn.State != ConnectionState.Open)
                            conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
