using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Accounting.Entity;
using Accounting.Utility;

namespace Accounting.DataAccess
{
    public class DaInventoryRequisition
    {
        public DaInventoryRequisition() { }

        public static DataTable GetRequisitions(string Where, string OrderBy)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_GET_Requisitions", ConnectionHelper.getConnection()))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Where", SqlDbType.NVarChar, 500).Value = Where;
                    if (OrderBy != string.Empty)
                        da.SelectCommand.Parameters.Add("@OrderBy", SqlDbType.NVarChar, 500).Value = OrderBy;
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
        public DataTable GetReqDetail( int ReqMID)
        {
            return loadReqDetail(ConnectionHelper.getConnection(), ReqMID);
        }
        public DataTable loadReqDetail(SqlConnection con, int ReqMID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("spReqDetailload", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ReqMID", SqlDbType.Int).Value = ReqMID;
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
        public DataTable loadSection(SqlConnection con)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT SectionID,Name,Description FROM Section WHERE CompanyID=" + LogInInfo.CompanyID.ToString() + " ", con);
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public int SaveUpdateReqMaster(ReqMaster obReqMaster, SqlConnection con, SqlTransaction trans)
        {
            int ID = 0;
            SqlCommand com = null;
            try
            {
                if(obReqMaster.CompanyID <= 0)
                {
                    obReqMaster.CompanyID = LogInInfo.CompanyID;
                    obReqMaster.UserID = LogInInfo.UserID;
                }
                com = new SqlCommand("spSaveUpdateReqMaster", con, trans);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ReqMID", SqlDbType.Int).Value = obReqMaster.ReqMID;
                com.Parameters.Add("@ReqNo", SqlDbType.VarChar, 100).Value = obReqMaster.ReqNo;
                com.Parameters.Add("@ReqDate", SqlDbType.DateTime).Value = obReqMaster.ReqDate;
                com.Parameters.Add("@ReqSectionID", SqlDbType.Int).Value = obReqMaster.ReqSectionID;
                com.Parameters.Add("@ReqBy", SqlDbType.VarChar, 500).Value = obReqMaster.ReqBy;
                com.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = obReqMaster.Remarks;
                com.Parameters.Add("@CompanyID", SqlDbType.Int).Value = obReqMaster.CompanyID;
                com.Parameters.Add("@UserID", SqlDbType.Int).Value = obReqMaster.UserID;
                com.ExecuteNonQuery();

                if (obReqMaster.ReqMID == 0)
                {
                    SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(ReqMID),0) FROM T_Requisition_Master", con, trans);
                    ID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                    ID = obReqMaster.ReqMID;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ID;
        }
        public void SaveUpdateReqDetail(ReqDetail obReqDetail, SqlConnection con, SqlTransaction trans)
        {
            SqlCommand com = null;
            try
            {
                com = new SqlCommand("spSaveUpdateReqDetail", con, trans);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ReqDID", SqlDbType.Int).Value = obReqDetail.ReqDID;
                com.Parameters.Add("@ReqMID", SqlDbType.Int).Value = obReqDetail.ReqMID;
                com.Parameters.Add("@ItemID", SqlDbType.Int).Value = obReqDetail.ItemID;
                com.Parameters.Add("@ReqQty", SqlDbType.Money).Value = obReqDetail.ReqQty;
                com.Parameters.Add("@UnitID", SqlDbType.Int).Value = obReqDetail.UnitID;
                com.Parameters.Add("@Budle_Pack_Qty", SqlDbType.VarChar, 500).Value = obReqDetail.Budle_Pack_Qty;
                com.Parameters.Add("@Specifications", SqlDbType.VarChar, 100).Value = obReqDetail.Specifications;
                com.Parameters.Add("@Budle_Pack_Size", SqlDbType.VarChar, 500).Value = obReqDetail.Budle_Pack_Size;
                if (obReqDetail.ColorID == 0)
                    com.Parameters.Add("@ColorID", SqlDbType.Int).Value = DBNull.Value;
                else
                    com.Parameters.Add("@ColorID", SqlDbType.Int).Value = obReqDetail.ColorID;
                if (obReqDetail.CountID == 0)
                    com.Parameters.Add("@CountID", SqlDbType.Int).Value = DBNull.Value;
                else
                    com.Parameters.Add("@CountID", SqlDbType.Int).Value = obReqDetail.CountID;
                if (obReqDetail.SizeID == 0)
                    com.Parameters.Add("@SizeID", SqlDbType.Int).Value = DBNull.Value;
                else
                    com.Parameters.Add("@SizeID", SqlDbType.Int).Value = obReqDetail.SizeID;
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable SearchSelectedReq(SqlConnection con, DateTime sDate, DateTime eDate, string ReqNo)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("spsearchReqNo", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@sDate", SqlDbType.DateTime).Value = sDate;
                da.SelectCommand.Parameters.Add("@eDate", SqlDbType.DateTime).Value = eDate;
                da.SelectCommand.Parameters.Add("@ReqNo", SqlDbType.VarChar, 100).Value = ReqNo;
               da.SelectCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        public ReqMaster getReqMID(SqlConnection con, int ReqMID)
        {
            DataTable dt = new DataTable();
            ReqMaster obReqMaster = new ReqMaster();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from T_Requisition_Master Where ReqMID = " + @ReqMID.ToString(), con);
                da.SelectCommand.Parameters.Add("@ReqMID", SqlDbType.Int).Value = ReqMID;
                da.Fill(dt);
                da.Dispose();
                if (dt.Rows.Count == 0) return null;
                obReqMaster.ReqMID = Convert.ToInt32(dt.Rows[0].Field<object>("ReqMID"));
                obReqMaster.ReqNo = dt.Rows[0].Field<object>("ReqNo").ToString();
                obReqMaster.ReqSectionID=Convert.ToInt32(dt.Rows[0].Field<object>("ReqSectionID"));
                obReqMaster.ReqDate = Convert.ToDateTime(dt.Rows[0].Field<object>("ReqDate"));
                obReqMaster.ReqBy = dt.Rows[0].Field<object>("ReqBy").ToString();
                obReqMaster.Remarks = dt.Rows[0].Field<object>("Remarks").ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obReqMaster;
        }
        public void DeleteRequisition(SqlConnection con, SqlTransaction trans, int ReqID)
        {
            SqlCommand com = null;
            try
            {
                com = new SqlCommand("spDeleteRequisition", con, trans);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ReqMID", SqlDbType.Int).Value = ReqID;
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteItem(SqlConnection con, int reqDID)
        {
            SqlTransaction trans = null;
            SqlCommand com = null;
            try
            {
                com = new SqlCommand();
                trans = con.BeginTransaction();
                com.Connection = con;
                com.Transaction = trans;
                com.CommandText = "Delete From T_Requisition_Detail WHERE ReqDID = @ReqDID";
                com.Parameters.Add("@ReqDID", SqlDbType.Int).Value = reqDID;
                com.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetRequisitionItems(SqlConnection con, int ReqID)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT T_Requisition_Detail.ItemID, T_Item.ItemName, ReqQty FROM T_Requisition_Detail INNER JOIN T_Item ON T_Requisition_Detail.ItemID = T_Item.ItemID WHERE ReqMID = @ReqMID", con);
                da.SelectCommand.Parameters.Add("@ReqMID", SqlDbType.Int).Value = ReqID;
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
