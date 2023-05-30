using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Accounting.Utility;

namespace Accounting.DataAccess
{
   public class DaVoucherType
    {
       public DaVoucherType() { }
        public static DataTable GetVoucherTypes()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM T_VoucherType ", ConnectionHelper.getConnection()))
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
        public static DataTable GetVoucherTypes(string pWhere, string OrderBy)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM T_VoucherType WHERE " + pWhere + " ORDER BY " + OrderBy, ConnectionHelper.getConnection()))
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
        public DataTable getVoucherType(SqlConnection con)
       {
           DataTable dt = null;
           try
           {
               dt = new DataTable();
               SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM T_VoucherType ORDER BY VoucherType", con);
               da.Fill(dt);
               da.Dispose();
               
           }
           catch (Exception ex)
           {
               
               throw ex;
           }

           return dt;
       }

    }
}
