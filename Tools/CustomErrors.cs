using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Tools
{
    public static class CustomErrors
    {
        public static string CustomMessage(this Exception ex, object sender/*=null*/)
        {
            string msg = ex.Message;
            if (ex.GetType() == typeof(SqlException))
            {
                if (ex.Message.Contains("IX_Resources"))
                {
                    msg = "Operation failed. Error: The resource already exists.";
                }
                else if (ex.Message.Contains("IX_Company_Name"))
                {
                    msg = "Operation failed. Error: The institute name already exists.";
                }
            }
            return msg;
        }

        public static string CustomDialogMessage(this Exception ex, object sender/*=null*/)
        {
            string msg = ex.CustomMessage(sender);

            return UIMessage.Message2User(msg, UserUILookType.Danger);
        }
        public static string CustomDialogMessage(this Exception ex)
        {
            string msg = ex.CustomMessage(null);

            return UIMessage.Message2User(msg, UserUILookType.Danger);
        }
    }
}
