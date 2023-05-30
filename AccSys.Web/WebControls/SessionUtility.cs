using Accounting.Entity;
using System;
using System.Collections.Generic;
using System.Web.SessionState;
using Tools;

namespace AccSys.Web.WebControls
{
    public static class SessionUtility
    {
        public static void CompanyId(this HttpSessionState Session, int companyId)
        {
            Session["CompanyID"] = companyId;
        }
        public static int CompanyId(this HttpSessionState Session)
        {
            return Utility.IsNull<int>(Session["CompanyID"], 1);
        }
        public static void UserName(this HttpSessionState Session, string userName)
        {
            Session["UserName"] = userName;
        }
        public static string UserName(this HttpSessionState Session)
        {
            return Utility.IsNull<string>(Session["UserName"], "");
        }

        public static void UserId(this HttpSessionState Session, int userID)
        {
            Session["UserID"] = userID;
        }
        public static int UserId(this HttpSessionState Session)
        {
            return Session["UserID"] == null ? 0 : Convert.ToInt32(Session["UserID"].ToString());
        }
        public static void IsSuperAdmin(this HttpSessionState Session, bool isSuperAdmin)
        {
            Session["SuperAdmin"] = isSuperAdmin;
        }
        public static bool IsSuperAdmin(this HttpSessionState Session)
        {
            return Utility.IsNull<bool>(Session["SuperAdmin"], false);
        }

        public static void Company(this HttpSessionState Session, Company objCompany)
        {
            Session["Company"] = objCompany;
        }
        public static Company Company(this HttpSessionState Session)
        {
            return Utility.IsNull<Company>(Session["Company"], null);
        }

        public static void UserRoleAccess(this HttpSessionState Session, List<ResourceAuthorization> access)
        {
            Session["UserRoleAccess"] = access;
        }
        public static List<ResourceAuthorization> UserRoleAccess(this HttpSessionState Session)
        {
            return Utility.IsNull<List<ResourceAuthorization>>(Session["UserRoleAccess"], new List<ResourceAuthorization>());
        }
        public static int UserRoleId(this HttpSessionState Session)
        {
            return Session["UserRoleId"] == null ? 0 : (int)Session["UserRoleId"];
        }
        public static void UserRoleId(this HttpSessionState Session, int roleId)
        {
            Session["UserRoleId"] = roleId;
        }


    }
}
