﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Accounting.Entity;
using Accounting.Utility;

namespace Accounting.DataAccess
{
   public class DaCountry
    {
       public DaCountry() { }

        public static DataTable GetCountries(string pWhere, string OrderBy)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Country WHERE " + pWhere + " ORDER BY " + OrderBy, ConnectionHelper.getConnection()))
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
        public DataTable getCountry(SqlConnection con)
       {
           try
           {
               SqlDataAdapter da = new SqlDataAdapter("select * from  Country WHERE CompanyID = " + LogInInfo.CompanyID.ToString(), con);
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

       public void saveUpdateCountry(Country obCountry, SqlConnection con)
       {
           SqlCommand com = null;
           SqlTransaction trans = null;
           try
           {
               com = new SqlCommand();
               trans = con.BeginTransaction();
               com.Transaction = trans;
               com.Connection = con;
               com.CommandText = "spSaveUpdateCountry";
               com.CommandType = CommandType.StoredProcedure;
               com.Parameters.Add("@CountryID", SqlDbType.Int).Value = obCountry.CountryID;
               com.Parameters.Add("@CountryName", SqlDbType.VarChar, 100).Value = obCountry.CountryName;
               com.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
               com.Parameters.Add("@UserID", SqlDbType.Int).Value = LogInInfo.UserID;
               //com.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = obCountry.ModifiedDate;
               com.ExecuteNonQuery();
               trans.Commit();
           }
           catch (Exception ex)
           {
               trans.Rollback();
               throw ex;
           }
       }

       public void deleteCountry(SqlConnection con, int CountryID)
       {
           SqlCommand com = null;
           SqlTransaction trans = null;
           try
           {
               com = new SqlCommand();
               trans = con.BeginTransaction();
               com.Transaction = trans;
               com.Connection = con;
               com.CommandText = "Delete from  Country where CountryID = @CountryID";
               com.CommandType = CommandType.Text;
               com.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;
               com.ExecuteNonQuery();
               trans.Commit();
           }
           catch (Exception ex)
           {
               trans.Rollback();
               throw ex;
           }
       }
    }
}
