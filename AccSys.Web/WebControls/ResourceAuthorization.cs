using System;

namespace AccSys.Web.WebControls
{
    public class ResourceAuthorizity
    {
        public bool CanView { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
    public class ResourceAuthorization : ResourceAuthorizity
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int ResourceID { get; set; }
        public string GroupName { get; set; }
        public string ResourceName { get; set; }
        public string ResourcePath { get; set; }
        public string ResourceType { get; set; }

    }
}
