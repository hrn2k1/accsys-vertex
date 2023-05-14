using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;


using Accounting.Entity;
using Accounting.Utility;


namespace Accounting.DataAccess
{
    public class BusinessTypeDA
    {
        public BusinessTypeDA() { }

        public int SaveOrUpdate(BusinessType objBusinessType)
        {

            SqlConnection con = null;
            SqlCommand com = null;
            SqlTransaction trans = null;

            try
            {
                con = ConnectionHelper.getConnection();
                trans = con.BeginTransaction();
                com = new SqlCommand();

                com.Connection = con;
                com.Transaction = trans;

                if (objBusinessType.BusinessTypeID == 0)
                {

                    objBusinessType.BusinessTypeID = ConnectionHelper.GetID(con, trans, "BusinessTypeID", "BusinessType");

                    com.CommandText = "Insert Into BusinessType(BusinessTypeID, Name) Values(@BusinessTypeID, @Name)";

                }
                else
                {
                    com.CommandText = "Update BusinessType SET Name = @Name WHERE BusinessTypeID = @BusinessTypeID";

                }
                com.Parameters.Add("@BusinessTypeID", SqlDbType.Int).Value = objBusinessType.BusinessTypeID;
                com.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = objBusinessType.Name;

                com.ExecuteNonQuery();
                trans.Commit();

                ConnectionHelper.closeConnection(con);
            }
            catch (Exception Ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                    ConnectionHelper.closeConnection(con);
                }
                throw new Exception("Can not save or update" + Ex.Message);

            }


            return objBusinessType.BusinessTypeID;

        }

        public ArrayList getBusinessType(int numBusinessTypeID)
        {
            ArrayList list = new ArrayList();

            try
            {
                var data = new DataTable();
                string qstr = numBusinessTypeID == 0 ? "Select * FROM BusinessType"  : "Select * FROM BusinessType WHERE BusinessTypeID = " + numBusinessTypeID.ToString();
                using (SqlDataAdapter adapter = new SqlDataAdapter(qstr, ConnectionHelper.DefaultConnectionString))
                {
                    adapter.Fill(data);
                    adapter.Dispose();
                }
                foreach (DataRow row in data.Rows)
                {
                    list.Add(CreateObject(row));
                }

            }
            catch (Exception Ex)
            {
                throw new Exception("Can not get BusinessType" + Ex.Message);

            }
            return list;

        }

        public void Delete(int numBusinessTypeID)
        {
            SqlConnection con = null;
            SqlCommand com = null;
            SqlTransaction trans = null;

            try
            {
                con = ConnectionHelper.getConnection();
                trans = con.BeginTransaction();
                com = new SqlCommand();

                com.Connection = con;
                com.Transaction = trans;
                com.CommandText = "DELETE FROM BusinessType WHERE BusinessTypeID = @BusinessTypeID";
                com.Parameters.Add("@BusinessTypeID", SqlDbType.Int).Value = numBusinessTypeID;
                com.ExecuteNonQuery();
                trans.Commit();

                ConnectionHelper.closeConnection(con);
            }
            catch (Exception Ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                }
                throw new Exception("Can not get BusinessType" + Ex.Message);

            }

        }


        #region CreateObjects
        private BusinessType CreateObject(IDataReader objReader)
        {
            BusinessType objBusinessType = new BusinessType();
            NullManager reader = new NullManager(objReader);

            try
            {
                objBusinessType.BusinessTypeID = reader.GetInt32("BusinessTypeID");
                objBusinessType.Name = reader.GetString("Name");

                objBusinessType.CompanyID = reader.GetInt32("CompanyID");
                objBusinessType.UserID = reader.GetInt32("UserID");
                objBusinessType.ModifiedDate = reader.GetDateTime("ModifiedDate");
            }
            catch (Exception Ex)
            {
                throw new Exception("Error while creating object" + Ex.Message);
            }
            return objBusinessType;
        }
        private BusinessType CreateObject(DataRow row)
        {
            BusinessType objBusinessType = new BusinessType();

            try
            {
                objBusinessType.BusinessTypeID = GlobalFunctions.isNull(row["BusinessTypeID"], 0);
                objBusinessType.Name = GlobalFunctions.isNull(row["Name"], "");
            }
            catch (Exception Ex)
            {
                throw new Exception("Error while creating object" + Ex.Message);
            }
            return objBusinessType;
        }
        #endregion



    }
}
