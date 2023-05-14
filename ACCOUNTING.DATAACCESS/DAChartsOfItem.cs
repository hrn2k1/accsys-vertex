using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Accounting.DataAccess
{
    public class DAChartsOfItem
    {
        public DAChartsOfItem() { }

        public static DataTable GetChartOfItems(int companyId)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Name, Type, ParentId, CompanyID FROM VW_ChartOfItems WHERE CompanyID=" + companyId.ToString(), ConnectionHelper.getConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public static DataTable GetItemGroups(int companyId)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT ItemGroupID AS Id, GroupName AS Name, 'Group' AS Type, ParentGroupID AS ParentId, CompanyID FROM T_ItemGroup WHERE CompanyID=" + companyId.ToString(), ConnectionHelper.getConnection());
            DataTable ds = new DataTable();
            da.Fill(ds);
            da.Dispose();
            return ds;
        }
        public static DataTable LoadItemGroup(int companyId)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT *,'<div style=''padding-left:'+CAST(5*ISNULL(GroupDepth,0) AS VARCHAR)+'px !important;'' class=''usertext'' >'+GroupName+'</div>' AS GroupNameHtml FROM T_ItemGroup WHERE CompanyID=" + companyId.ToString(), ConnectionHelper.getConnection());
            DataTable ds = new DataTable();
            da.Fill(ds);
            da.Dispose();
            return ds;
        }
        public static DataTable GetItems(int groupId, int companyId)
        {
            DataTable dt = new DataTable();
            try
            {
                string qstr = "SELECT * FROM T_Item WHERE CompanyID=" + companyId.ToString();
                if(groupId > 0)
                {
                    qstr += " AND ItemGroupID=" + groupId.ToString();
                }
                qstr += " ORDER BY ItemName";
                SqlDataAdapter da = new SqlDataAdapter(qstr, ConnectionHelper.DefaultConnectionString);
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public static DataTable GetItems(string Where, string OrderBy)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_GET_Items", ConnectionHelper.getConnection()))
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
        public static DataTable LoadUnits()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM P_Units ORDER BY UnitsName", ConnectionHelper.getConnection()))
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

        public DataTable LoadItemGroup(SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from T_ItemGroup WHERE CompanyID=" + LogInInfo.CompanyID.ToString(), con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            da.Dispose();
            return ds;
        }
        public DataTable LoadSize(SqlConnection con)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from  P_Sizes WHERE CompanyID=" + LogInInfo.CompanyID.ToString(), con);
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
        public DataTable LoadUnits(SqlConnection con)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from  P_Units WHERE CompanyID=" + LogInInfo.CompanyID.ToString(), con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable LoadColors(SqlConnection con)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from  P_Colors WHERE CompanyID=" + LogInInfo.CompanyID.ToString(), con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                da.Dispose();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable LoadCounts(SqlConnection con)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from T_Count WHERE CompanyID=" + LogInInfo.CompanyID.ToString(), con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadShade(SqlConnection con)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from T_Shade WHERE CompanyID=" + LogInInfo.CompanyID.ToString(), con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable LoadGroupInDGV(SqlConnection con)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select G.*,P.GroupName AS Parent from T_ItemGroup G LEFT OUTER JOIN T_ItemGroup P ON G.parentGroupID=P.ItemGroupID WHERE G.CompanyID=" + LogInInfo.CompanyID.ToString(), con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable LoadItemInDGV(SqlConnection con)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("spGridItemData", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveOrUpdateItemGroup(ItemGroup objGr, SqlConnection con)
        {
            SqlCommand com = null;
            SqlTransaction trans = null;
            try
            {
                ItemGroup objParentGroup = null;
                if (objGr.ParentGroupID > 0 && objGr.GroupDepth == -1)
                {
                    objParentGroup = GetGroup(objGr.ParentGroupID, con);
                    if (objParentGroup != null)
                    {
                        objGr.GroupDepth = objParentGroup.GroupDepth + 1;
                    }
                }
                else
                    objGr.GroupDepth = 0;
                com = new SqlCommand();
                trans = con.BeginTransaction();
                com.Connection = con;
                com.Transaction = trans;
                if (objGr.ItemGroupID == 0)
                {
                    com.CommandText = "insert into T_ItemGroup(GroupName,ParentGroupID,GroupCode,GroupDepth,CompanyID,UserID,ModifiedDate)" +
                        "values(@GroupName,@ParentGroupID,@GroupCode,@GroupDepth,@CompanyID,@UserID,@mdate)";
                }
                else
                {
                    com.CommandText = "update T_ItemGroup set GroupName=@GroupName,ParentGroupID=@ParentGroupID,GroupCode=@GroupCode,GroupDepth=@GroupDepth,CompanyID=@CompanyID,UserID=@UserID,ModifiedDate=@mdate where ItemGroupID=@ItemGroupID";
                }
                com.Parameters.Add("@ItemGroupID", SqlDbType.Int).Value = objGr.ItemGroupID;
                com.Parameters.Add("@GroupName", SqlDbType.VarChar, 100).Value = objGr.GroupName;
                com.Parameters.Add("@ParentGroupID", SqlDbType.Int).Value = objGr.ParentGroupID;
                com.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = objGr.GroupCode;
                com.Parameters.Add("@GroupDepth", SqlDbType.Int).Value = objGr.GroupDepth;
                com.Parameters.Add("@CompanyID", SqlDbType.Int).Value = objGr.CompanyID > 0 ? objGr.CompanyID : LogInInfo.CompanyID;
                com.Parameters.Add("@UserID", SqlDbType.Int).Value = LogInInfo.UserID;
                com.Parameters.Add("@mdate", SqlDbType.DateTime).Value = DateTime.Now;
                com.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            return objGr.ItemGroupID;

        }

        public int SaveOrUpdateItem(ChartsOfItem obj, SqlConnection con)
        {
            SqlCommand com = null;
            SqlTransaction trans = null;
            try
            {
                com = new SqlCommand();
                trans = con.BeginTransaction();
                com.Connection = con;
                com.Transaction = trans;
                com.CommandText = "spInsertOrUpdateItem";
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ItemCode", SqlDbType.VarChar, 50).Value = obj.ItemCode;
                com.Parameters.Add("@HSCode", SqlDbType.VarChar, 50).Value = obj.HSCode;
                com.Parameters.Add("@ItemName", SqlDbType.VarChar, 50).Value = obj.ItemName;
                com.Parameters.Add("@ItemDescription", SqlDbType.VarChar, 100).Value = obj.ItemDescription;
                com.Parameters.Add("@ItemPurpose", SqlDbType.VarChar, 100).Value = obj.ItemPurpose;
                com.Parameters.Add("@ItemGroupID", SqlDbType.Int).Value = obj.GroupID;
                com.Parameters.Add("@ItemCatagory", SqlDbType.VarChar, 50).Value = obj.ItemCatagory;
                if (obj.SizeID == 0)
                    com.Parameters.Add("@SizeID", SqlDbType.Int).Value = DBNull.Value;
                else
                    com.Parameters.Add("@SizeID", SqlDbType.Int).Value = obj.SizeID;
                com.Parameters.Add("@ItemID", SqlDbType.Int).Value = obj.ItemID;
                if (obj.ColorID == 0)
                    com.Parameters.Add("@ColorID", SqlDbType.Int).Value = DBNull.Value;
                else
                    com.Parameters.Add("@ColorID", SqlDbType.Int).Value = obj.ColorID;
                if (obj.ShadeID == 0)
                    com.Parameters.Add("@ShadeID", SqlDbType.Int).Value = DBNull.Value;
                else
                    com.Parameters.Add("@ShadeID", SqlDbType.Int).Value = obj.ShadeID;
                if (obj.CountID == 0)
                    com.Parameters.Add("@CountID", SqlDbType.Int).Value = DBNull.Value;
                else
                    com.Parameters.Add("@CountID", SqlDbType.Int).Value = obj.CountID;
                com.Parameters.Add("@UnitID", SqlDbType.Int).Value = obj.UnitID;
                com.Parameters.Add("@OpeningQty", SqlDbType.Int).Value = obj.OpeningQty;
                com.Parameters.Add("@OpeningValue", SqlDbType.Money).Value = obj.OpeningValue;
                com.Parameters.Add("@ItemStatus", SqlDbType.VarChar, 50).Value = obj.ItemStatus;
                com.Parameters.Add("@MinQty", SqlDbType.Int).Value = obj.MinQty;
                com.Parameters.Add("@UnitPrice", SqlDbType.Money).Value = obj.UnitPrice;
                com.Parameters.Add("@Picture", SqlDbType.Image).Value = GlobalFunctions.GetNullValue(obj.Picture);
                com.Parameters.Add("@CompanyID", SqlDbType.Int).Value = obj.CompanyID > 0 ? obj.CompanyID : LogInInfo.CompanyID;
                com.Parameters.Add("@UserID", SqlDbType.Int).Value = LogInInfo.UserID;
                com.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            return obj.ItemID;

        }

        public void DeleteGroup(int dd, SqlConnection con)
        {
            SqlCommand comm = null;
            SqlTransaction trans = null;
            try
            {
                comm = new SqlCommand();
                trans = con.BeginTransaction();
                comm.Connection = con;
                comm.Transaction = trans;
                comm.CommandText = "delete from T_ItemGroup where ItemGroupID=@ItemGroupID";
                //comm.CommandText = "delete from T_Item where ItemID=@ItemID";
                comm.Parameters.Add("@ItemGroupID", SqlDbType.Int).Value = dd;
                comm.ExecuteNonQuery();
                trans.Commit();

            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }

        }
        public void DeleteGroup(int id)
        {
            DeleteGroup(id, ConnectionHelper.getConnection());
        }

        public void DeleteItem(int dd, SqlConnection con)
        {
            SqlCommand comm = null;
            SqlTransaction trans = null;
            try
            {
                comm = new SqlCommand();
                trans = con.BeginTransaction();
                comm.Connection = con;
                comm.Transaction = trans;
                //comm.CommandText = "delete from T_ItemGroup where ItemGroupID=@ItemGroupID";
                comm.CommandText = "delete from T_Item where ItemID=@ItemID";
                comm.Parameters.Add("@ItemID", SqlDbType.Int).Value = dd;
                comm.ExecuteNonQuery();
                trans.Commit();

            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
        }
        public void DeleteItem(int id)
        {
            DeleteItem(id, ConnectionHelper.getConnection());
        }

        public DataTable SearchByGroup(int dd, SqlConnection con)
        {
            DataTable dt = new DataTable();

            try
            {

                //comm.CommandText = "delete from T_ItemGroup where ItemGroupID=@ItemGroupID";
                SqlDataAdapter da = new SqlDataAdapter("select ItemID,ItemName,SizeID,SizesName Size,ColorID,ColorsName Color,CountID,CountName Count,ShadeID,ShadeNo Shade,UnitsName Unit,ItemGroupID,ItemCategory,ItemCode,HSCode,UnitID,ItemStatus,ItemDescription,ItemPurpose,MinQty,OpeningQty,UnitPrice,OpeningValue from VW_Items where ItemGroupID=@ItemGroupID", con);
                da.SelectCommand.Parameters.Add("@ItemGroupID", SqlDbType.Int).Value = dd;
                da.Fill(dt);
                da.Dispose();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;

        }

        public DataTable GetPrimeryGroup(SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from T_ItemGroup where ParentGroupID=0 AND CompanyID=" + LogInInfo.CompanyID.ToString(), con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public ItemGroup GetGroup(int GroupID, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM T_ItemGroup WHERE ItemGroupID=" + GroupID.ToString(), con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            if (dt.Rows.Count == 0)
                return null;
            return new ItemGroup()
            {
                ItemGroupID = GlobalFunctions.isNull(dt.Rows[0]["ItemGroupID"], 0),
                CompanyID = GlobalFunctions.isNull(dt.Rows[0]["CompanyID"], 0),
                GroupCode = GlobalFunctions.isNull(dt.Rows[0]["GroupCode"], ""),
                GroupDepth = GlobalFunctions.isNull(dt.Rows[0]["GroupDepth"], 0),
                GroupName = GlobalFunctions.isNull(dt.Rows[0]["GroupName"], ""),
                ParentGroupID = GlobalFunctions.isNull(dt.Rows[0]["ParentGroupID"], 0),
                UserID = GlobalFunctions.isNull(dt.Rows[0]["UserID"], 0)
            };
        }
        public ItemGroup GetGroup(int GroupID)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM T_ItemGroup WHERE ItemGroupID=" + GroupID.ToString(), ConnectionHelper.DefaultConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            if (dt.Rows.Count == 0)
                return null;
            return new ItemGroup()
            {
                ItemGroupID = GlobalFunctions.isNull(dt.Rows[0]["ItemGroupID"], 0),
                CompanyID = GlobalFunctions.isNull(dt.Rows[0]["CompanyID"], 0),
                GroupCode = GlobalFunctions.isNull(dt.Rows[0]["GroupCode"], ""),
                GroupDepth = GlobalFunctions.isNull(dt.Rows[0]["GroupDepth"], 0),
                GroupName = GlobalFunctions.isNull(dt.Rows[0]["GroupName"], ""),
                ParentGroupID = GlobalFunctions.isNull(dt.Rows[0]["ParentGroupID"], 0),
                UserID = GlobalFunctions.isNull(dt.Rows[0]["UserID"], 0)
            };
        }
        public DataTable GetChildGroup(int ParentGroupID, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from T_ItemGroup where ParentGroupID=" + ParentGroupID.ToString(), con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public DataTable GetChildItem(int ParentID, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from T_Item where ItemGroupID=" + ParentID.ToString(), con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
        public DataTable GetItems(int itemGroupID, string ItemName, SqlConnection con)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from T_Item where CompanyID=" + LogInInfo.CompanyID.ToString() + " AND (ItemGroupID=@ItemGroupID OR @ItemGroupID=0) AND (ItemName Like @ItemName) ORDER BY ItemName", con);
                da.SelectCommand.Parameters.Add("@ItemGroupID", SqlDbType.Int).Value = itemGroupID;
                da.SelectCommand.Parameters.Add("@ItemName", SqlDbType.VarChar, 100).Value = ItemName + "%";
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetItems(int itemGroupID, string ItemName, string colnums, SqlConnection con)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select " + colnums + " from VW_Items where CompanyID=" + LogInInfo.CompanyID.ToString() + " AND (ItemGroupID=@ItemGroupID OR @ItemGroupID=0) AND (ItemName Like @ItemName) ORDER BY ItemName", con);
                da.SelectCommand.Parameters.Add("@ItemGroupID", SqlDbType.Int).Value = itemGroupID;
                da.SelectCommand.Parameters.Add("@ItemName", SqlDbType.VarChar, 100).Value = ItemName + "%";
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public ChartsOfItem GetItem(int ItemID)
        {
            return getItem(ItemID, ConnectionHelper.getConnection());
        }
        public ChartsOfItem getItem(int ItemID, SqlConnection con)
        {
            DataTable dt = new DataTable();
            ChartsOfItem objItem = null;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from T_Item where (ItemID=@ItemID)", con);
                da.SelectCommand.Parameters.Add("@ItemID", SqlDbType.Int).Value = ItemID;
                da.Fill(dt);
                da.Dispose();
                if (dt.Rows.Count == 0) return null;

                objItem = new ChartsOfItem();
                objItem.ItemID = dt.Rows[0].Field<int>("ItemID");
                objItem.ItemCode = dt.Rows[0].Field<string>("ItemCode");
                objItem.HSCode = dt.Rows[0].Field<string>("HSCode");
                objItem.ItemName = dt.Rows[0].Field<string>("ItemName");
                objItem.ItemDescription = dt.Rows[0].Field<string>("ItemDescription");
                objItem.ItemPurpose = dt.Rows[0].Field<string>("ItemPurpose");
                objItem.GroupID = dt.Rows[0].Field<int>("ItemGroupID");
                objItem.ItemCatagory = dt.Rows[0].Field<string>("ItemCategory");
                objItem.UnitID = dt.Rows[0].Field<int>("UnitID");
                objItem.ItemPurpose = dt.Rows[0].Field<string>("ItemPurpose");
                objItem.ItemStatus = dt.Rows[0].Field<string>("ItemStatus");
                objItem.UnitPrice = (double)dt.Rows[0].Field<decimal>("UnitPrice");
                objItem.OpeningQty = dt.Rows[0].Field<int>("OpeningQty");
                objItem.OpeningValue = (double)dt.Rows[0].Field<decimal>("OpeningValue");
                objItem.MinQty = dt.Rows[0].Field<int>("MinQty");
                objItem.CurrentItem = dt.Rows[0].Field<int>("CurrentQty");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objItem;
        }
        public string getUnitOfItem(SqlConnection con, int ItemID)
        {
            try
            {
                if (con.State != ConnectionState.Open) con.Open();
                SqlCommand cmd = new SqlCommand("SELECT UnitsName FROM T_Item INNER JOIN P_Units ON T_Item.UnitID=P_Units.UnitsID WHERE T_Item.ItemID=" + ItemID.ToString(), con);
                object obj = cmd.ExecuteScalar();

                if (obj == null || obj == DBNull.Value) return string.Empty;
                else return obj.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetItems(string Where, string Columns, SqlConnection con)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select " + Columns + " from VW_Items " + Where + " ORDER BY ItemName", con);

                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable getItemsForGrid(SqlConnection con)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select ItemID,ItemName From T_Item Where CompanyID=" + LogInInfo.CompanyID.ToString() + "  ORDER BY ItemName", con);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable GetItemsWithPrice(string Where, DateTime priceDate, string Columns, SqlConnection con)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select " + Columns + " from VW_Items " + Where + " ORDER BY ItemName", con);
                da.SelectCommand.Parameters.Add("@priceDate", SqlDbType.DateTime).Value = priceDate;
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public byte[] GetImage(SqlConnection con, int ItemID)
        {
            SqlCommand comm = null;
            try
            {
                comm = new SqlCommand("select Picture from T_Item where ItemID=@ItemID", con);
                comm.Parameters.Add("@ItemID", SqlDbType.Int).Value = ItemID;
                object obj = comm.ExecuteScalar();

                if (obj == null || obj == DBNull.Value)
                    return null;
                else
                    return (byte[])obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetCurrentItem(int ItemID, SqlConnection conn)
        {
            SqlCommand com = new SqlCommand();
            SqlTransaction trans = null;
            try
            {
                trans = conn.BeginTransaction();
                com.Connection = conn;
                com.Transaction = trans;
                com.CommandText = "select isnull(CurrentQty,0) from T_Item where ItemID=" + ItemID.ToString();
                int CurrentQTY = Convert.ToInt32(com.ExecuteScalar());
                trans.Commit();
                return CurrentQTY;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
