﻿using Accounting.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Accounting.DataAccess
{
    [DataObject(true)]
    public class CommonDataSource
    {
        public CommonDataSource() { }


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Int32 GetDataCount(string SelectedColumns, string FromTable, string Where, string OrderBy)
        {
            // Data adapter to retrieve data from SQL Server based on the page size of the grid.
            // The Select statement uses the maximumRows and startRowIndex parameters provided
            // by WebGrid to query for data between the start row index for the page, up to the page size.



            int Count = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionHelper.DefaultConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GET_ROWCOUNT", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@FromTables", SqlDbType.NVarChar, 5000).Value = FromTable;
                        cmd.Parameters.Add("@Where", SqlDbType.NVarChar, 5000).Value = Where;
                        cmd.Parameters.Add("@Return_Value", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Count = Convert.ToInt32(cmd.Parameters["@Return_Value"].Value);
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Count;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static DataTable GetData(string SelectedColumns, string FromTable, string Where, string OrderBy, int MaximumRows, int StartRowIndex)
        {
            // Data adapter to retrieve data from SQL Server based on the page size of the grid.
            // The Select statement uses the maximumRows and startRowIndex parameters provided
            // by WebGrid to query for data between the start row index for the page, up to the page size.

            int PageSize = MaximumRows;
            int PageIndex = StartRowIndex / PageSize;
            DataTable dtData = new DataTable();
            try
            {
                using (SqlDataAdapter DataAdapter = new SqlDataAdapter("SP_GET_DATA", ConnectionHelper.DefaultConnectionString))
                {
                    DataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataAdapter.SelectCommand.Parameters.Add("@PageIndex", SqlDbType.Int).Value = PageIndex;
                    DataAdapter.SelectCommand.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                    DataAdapter.SelectCommand.Parameters.Add("@SelectedColumns", SqlDbType.NVarChar, 5000).Value = SelectedColumns;
                    DataAdapter.SelectCommand.Parameters.Add("@FromTables", SqlDbType.NVarChar, 5000).Value = FromTable;
                    DataAdapter.SelectCommand.Parameters.Add("@Where", SqlDbType.NVarChar, 5000).Value = Where;
                    DataAdapter.SelectCommand.Parameters.Add("@OrderBy", SqlDbType.NVarChar, 5000).Value = OrderBy;
                    DataAdapter.Fill(dtData);
                    DataAdapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtData;
        }
    }
}