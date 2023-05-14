using Accounting.Utility;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Accounting.DataAccess
{
    public class DaCommon
    {
        public static DataTable GetList(string table, string fields, string where, string orderBy)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(string.Format("SELECT {0} FROM {1} WHERE {2} ORDER BY {3}", fields, table, where, orderBy), ConnectionHelper.DefaultConnectionString))
                {
                    da.Fill(dt);
                    da.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
