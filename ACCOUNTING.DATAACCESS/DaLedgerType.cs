using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Accounting.Utility;

namespace Accounting.DataAccess
{
   public class DaLedgerType
    {
       public DaLedgerType() { }
        public static DataTable GetLedgerTypes(string pWhere, string OrderBy)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM T_LedgerType WHERE " + pWhere + " ORDER BY " + OrderBy, ConnectionHelper.getConnection()))
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
        public DataTable getLedgerType(SqlConnection con)
       {
           try
           {
               SqlDataAdapter da = new SqlDataAdapter("select * from T_LedgerType", con);
               DataTable ds = new DataTable();
               da.Fill(ds);
               da.Dispose();
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
    }
}
