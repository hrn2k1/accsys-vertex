using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Entity
{
    
            #region Users
        public class User : BaseObject
        {
            public User() : base() { }

            #region Fields
            private int numUserID;
            private string strUserName;
            private string strPassword;
            private string strConfirmPassword;
            private int numRoleId;

            #endregion


            #region Properties
            public new int UserID
            {
                get { return numUserID; }
                set { numUserID = value; }
            }
            public string UserName
            {
                get { return strUserName; }
                set { strUserName = value; }
            }

            public string Password
            {
                get { return strPassword; }
                set { strPassword = value; }
            }
            public string ConfirmPassword
            {
                get { return strConfirmPassword; }
                set { strConfirmPassword = value; }
            }
            public int RoleId
            {
                get { return numRoleId; }
                set { numRoleId = value; }
            }
            #endregion

        }
        #endregion
    
}
