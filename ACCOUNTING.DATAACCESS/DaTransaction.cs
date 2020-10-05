using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Accounting.DataAccess
{
    public class DaTransaction
    {
        public DaTransaction() { }

        public static DataTable SearchVouchers(int top, string where, string orderby, string selectFields)
        {
            DataTable dtVouchers = new DataTable();
            if (top <= 0) top = 10000;
            if (string.IsNullOrEmpty(where)) where = " 1=1 ";
            if (string.IsNullOrEmpty(orderby)) orderby = " TransDate DESC ";
            if (string.IsNullOrEmpty(selectFields)) selectFields = " * ";
            string qstr = string.Format(@"WITH myCTE AS (SELECT TOP({0}) TransMID AS Id FROM T_Transaction_Master WHERE {1} ORDER BY {2}) 
                SELECT {3} FROM VW_Transactions INNER JOIN myCTE ON TransMID = Id  ORDER BY {2},VoucherNo", top, where, orderby, selectFields);
            using (SqlDataAdapter adapter = new SqlDataAdapter(qstr, ConnectionHelper.getConnection()))
            {
                adapter.Fill(dtVouchers);
                adapter.Dispose();
            }

            return dtVouchers;
        }
        public static DataTable GetTransactionMethods(string pWhere, string OrderBy)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM T_TransactionMethod WHERE " + pWhere + " ORDER BY " + OrderBy, ConnectionHelper.getConnection()))
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
        private int VoucherNoDigitLength = 6;

        public int SaveEditTransactionMaster(TransactionMaster objTM, SqlConnection con, SqlTransaction trans)
        {
            int ID = 0;
            try
            {
                if (objTM.CompanyID <= 0) objTM.CompanyID = LogInInfo.CompanyID;
                if (objTM.UserID <= 0) objTM.UserID = LogInInfo.UserID;
                SqlCommand com = new SqlCommand("spInsertUpdateTransMaster", con, trans);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@TransMID", SqlDbType.Int).Value = objTM.TransactionMasterID;
                com.Parameters.Add("@TransDate", SqlDbType.DateTime).Value = objTM.TransactionDate;
                com.Parameters.Add("@VoucherNo", SqlDbType.VarChar, 100).Value = objTM.VoucherNo;
                com.Parameters.Add("@VoucherPayee", SqlDbType.VarChar, 500).Value = objTM.VoucherPayee;
                com.Parameters.Add("@VoucherType", SqlDbType.Int).Value = objTM.VoucherType;

                if (objTM.TransactionMethodID <= 0)
                    com.Parameters.Add("@TransMethodID", SqlDbType.Int).Value = DBNull.Value;
                else
                    com.Parameters.Add("@TransMethodID", SqlDbType.Int).Value = objTM.TransactionMethodID;

                if (objTM.MethodRefID <= 0)
                    com.Parameters.Add("@MethodRefID", SqlDbType.Int).Value = DBNull.Value;
                else
                    com.Parameters.Add("@MethodRefID", SqlDbType.Int).Value = objTM.MethodRefID;
                com.Parameters.Add("@MethodRefNo", SqlDbType.VarChar, 100).Value = objTM.MethodRefNo;
                com.Parameters.Add("@TransDescription", SqlDbType.VarChar, 1000).Value = objTM.TransactionDescription;
                com.Parameters.Add("@ApprovedBy", SqlDbType.VarChar, 100).Value = objTM.ApprovedBy;

                if (objTM.ApprovedDate == new DateTime(1900, 1, 1))
                    com.Parameters.Add("@ApprovedDate", SqlDbType.DateTime).Value = DBNull.Value;
                else
                    com.Parameters.Add("@ApprovedDate", SqlDbType.DateTime).Value = objTM.ApprovedDate;


                com.Parameters.Add("@CompanyID", SqlDbType.Int).Value = objTM.CompanyID;
                com.Parameters.Add("@UserID", SqlDbType.Int).Value = objTM.UserID;
                com.Parameters.Add("@Module", SqlDbType.VarChar, 500).Value = objTM.Module;
                com.ExecuteNonQuery();


                if (objTM.TransactionMasterID == 0)
                {
                    SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(TransMID),0) FROM T_Transaction_Master", con, trans);
                    ID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                    ID = objTM.TransactionMasterID;
                // ID = Convert.ToInt32(com.Parameters["@TransMID"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ID;
        }

        public int SaveEditTransactionDetail(TransactionDetail objTD, SqlConnection con, SqlTransaction trans)
        {
            int ID = 0;
            try
            {

                SqlCommand com = new SqlCommand("spInsertUpdateTransDetail", con, trans);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@TransDID", SqlDbType.Int).Value = objTD.TransactionDetailID;
                com.Parameters.Add("@TransMID", SqlDbType.Int).Value = objTD.TransactionMasterID;
                com.Parameters.Add("@AccountID", SqlDbType.Int).Value = objTD.TransactionAccountID;
                com.Parameters.Add("@CreditAmt", SqlDbType.Money).Value = objTD.CreditAmount;
                com.Parameters.Add("@DebitAmt", SqlDbType.Money).Value = objTD.DebitAmount;
                com.Parameters.Add("@Comments", SqlDbType.VarChar, 500).Value = objTD.Comments;

                com.ExecuteNonQuery();

                //if (objTM.AccountID == 0)
                //    ID = ConnectionHelper.GetID(con, "AccountID", "T_Account");
                //else
                //    ID = objTM.AccountID;
                ID = Convert.ToInt32(com.Parameters["@TransDID"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ID;
        }
        public TransactionMaster getTransMaster(SqlConnection con, int numTMID)
        {
            TransactionMaster objTM = null;

            try
            {
                if (con == null)
                {
                    con = ConnectionHelper.getConnection();
                }
                if (con.State != ConnectionState.Open) con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM T_Transaction_Master WHERE TransMID=" + numTMID.ToString(), con);
                da.Fill(dt);
                da.Dispose();

                if (dt.Rows.Count == 0) return null;
                objTM = new TransactionMaster();
                objTM.TransactionMasterID = dt.Rows[0].Field<int>("TransMID");
                objTM.TransactionDate = dt.Rows[0].Field<DateTime>("TransDate");
                objTM.VoucherNo = dt.Rows[0].Field<string>("VoucherNo");
                objTM.VoucherPayee = dt.Rows[0].Field<string>("VoucherPayee");
                objTM.VoucherType = dt.Rows[0].Field<int>("VoucherType");
                objTM.TransactionMethodID = dt.Rows[0].Field<object>("TransMethodID") == DBNull.Value || dt.Rows[0].Field<object>("TransMethodID") == null ? -1 : dt.Rows[0].Field<int>("TransMethodID");
                objTM.MethodRefID = dt.Rows[0].Field<object>("MethodRefID") == DBNull.Value || dt.Rows[0].Field<object>("MethodRefID") == null ? -1 : dt.Rows[0].Field<int>("MethodRefID");
                objTM.MethodRefNo = dt.Rows[0].Field<string>("MethodRefNo");
                objTM.TransactionDescription = dt.Rows[0].Field<string>("TransDescription");

                objTM.ApprovedBy = dt.Rows[0].Field<string>("approvedBy");

                if (dt.Rows[0].Field<object>("approvedDate") == DBNull.Value || dt.Rows[0].Field<object>("approvedDate") == null)
                    objTM.ApprovedDate = new DateTime(1900, 1, 1);
                else
                    objTM.ApprovedDate = dt.Rows[0].Field<DateTime>("approvedDate");
                objTM.Module = dt.Rows[0].Field<object>("Module") == DBNull.Value || dt.Rows[0].Field<object>("Module") == null ? "" : dt.Rows[0].Field<string>("Module");
                objTM.CompanyID = dt.Rows[0].Field<object>("CompanyID") == DBNull.Value || dt.Rows[0].Field<object>("CompanyID") == null ? -1 : dt.Rows[0].Field<int>("CompanyID");
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return objTM;
        }
        public DataTable getTransAccounts(SqlConnection con, int numTMID, string DebitOrCredit)
        {
            DataTable dt = null;
            try
            {
                if (con == null)
                {
                    con = ConnectionHelper.getConnection();
                }
                if (con.State != ConnectionState.Open) con.Open();
                string qstr = string.Empty;
                if (DebitOrCredit.ToLower() == "debit")
                    qstr = "SELECT TransDID,T.AccountID,A.AccountNo,A.AccountTitle,DebitAmt AS Amount FROM T_Transaction_Detail AS T INNER JOIN VW_Account AS A ON T.AccountID=A.AccountID  WHERE DebitAmt <> 0 AND TransMID= @TransMID Order By AccountTitle";
                else if (DebitOrCredit.ToLower() == "credit")
                    qstr = "SELECT TransDID,T.AccountID,A.AccountNo,A.AccountTitle,CreditAmt AS Amount FROM T_Transaction_Detail AS T INNER JOIN VW_Account AS A ON T.AccountID=A.AccountID  WHERE CreditAmt <> 0 AND TransMID= @TransMID Order By AccountTitle";
                else
                    qstr = "SELECT TransDID,T.AccountID,A.AccountNo,A.AccountTitle,DebitAmt AS Debit,CreditAmt AS Credit FROM T_Transaction_Detail AS T INNER JOIN VW_Account AS A ON T.AccountID=A.AccountID WHERE  TransMID= @TransMID  Order By CreditAmt,AccountTitle";
                dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(qstr, con);
                da.SelectCommand.Parameters.Add("@TransMID", SqlDbType.Int).Value = numTMID;
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetVoucherAccounts(SqlConnection con, int voucherId)
        {
            DataTable dt = null;
            try
            {
                if (con == null)
                {
                    con = ConnectionHelper.getConnection();
                }
                if (con.State != ConnectionState.Open) con.Open();
                string qstr = "SELECT TransDID,T.AccountID,A.AccountNo,A.AccountTitle, T.DebitAmt, T.CreditAmt FROM T_Transaction_Detail AS T INNER JOIN T_Account AS A ON T.AccountID=A.AccountID  WHERE TransMID= @TransMID Order By AccountTitle";
                dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(qstr, con);
                da.SelectCommand.Parameters.Add("@TransMID", SqlDbType.Int).Value = voucherId;
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getVoucher(SqlConnection con, int VoucherType, DateTime stDate, DateTime edDate)
        {
            DataTable dt = null;
            try
            {
                string qstr = "SELECT M.TransMID,VoucherType,M.VoucherNo,M.TransDate,SUM(D.CreditAmt)AS Amount,M.Module FROM T_Transaction_Master AS M INNER JOIN "
                            + " T_Transaction_Detail AS D ON M.TransMID = D.TransMID WHERE(M.VoucherType = @VoucherType OR @VoucherType = 0) AND (M.CompanyID=@CompanyID) GROUP BY M.TransMID, M.VoucherNo, M.TransDate,VoucherType,Module HAVING (M.TransDate BETWEEN @startDate AND @endDate)"
                            + " Order by M.TransDate,VoucherNo";
                SqlDataAdapter da = new SqlDataAdapter(qstr, con);
                da.SelectCommand.Parameters.Add("@VoucherType", SqlDbType.Int).Value = VoucherType;
                da.SelectCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                da.SelectCommand.Parameters.Add("@startDate", SqlDbType.DateTime).Value = stDate;
                da.SelectCommand.Parameters.Add("@endDate", SqlDbType.DateTime).Value = edDate;
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public string getVoucherNo(SqlConnection con, string preFix)
        {
            return getVoucherNo(con, preFix, LogInInfo.CompanyID);
        }
        public string getVoucherNo(SqlConnection con, string preFix, int companyId)
        {
            string Vno = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT ISNULL((SELECT SUBSTRING(MAX(VoucherNo), 2, 50) + 1 FROM T_Transaction_Master WHERE CompanyID=@CompanyID AND (VoucherNo LIKE @DCJ + '%')),1)", con);
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@DCJ", SqlDbType.VarChar, 5).Value = preFix;
                Vno = cmd.ExecuteScalar().ToString();
                Vno = preFix.ToUpper() + Vno.PadLeft(VoucherNoDigitLength, '0');

            }
            catch (Exception ex)
            {
                //return string.Empty;
                throw ex;
            }
            return Vno;
        }
        public string getVoucherNo(SqlConnection con, SqlTransaction trans, string preFix)
        {
            string Vno = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT ISNULL((SELECT SUBSTRING(MAX(VoucherNo), 2, 50) + 1 FROM T_Transaction_Master WHERE CompanyID=@CompanyID AND (VoucherNo LIKE @DCJ + '%')),1)", con, trans);
                cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = LogInInfo.CompanyID;
                cmd.Parameters.Add("@DCJ", SqlDbType.VarChar, 5).Value = preFix;
                Vno = cmd.ExecuteScalar().ToString();
                Vno = preFix.ToUpper() + Vno.PadLeft(VoucherNoDigitLength, '0');

            }
            catch (Exception ex)
            {
                return string.Empty;
                throw ex;
            }
            return Vno;
        }

        public void DeleteTransAccount(int TDID, SqlConnection con, SqlTransaction trans)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spDeleteTransAccount", con, trans);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TransDID", SqlDbType.Int).Value = TDID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteTransAccounts(SqlConnection connection, SqlTransaction trans, int transMID)
        {
            try
            {
                using (var da = new SqlDataAdapter(new SqlCommand("SELECT TransDID FROM T_Transaction_Detail WHERE TransMID=" + transMID.ToString(), connection, trans)))
                {
                    var dtTDIds = new DataTable();
                    da.Fill(dtTDIds);
                    da.Dispose();
                    foreach (DataRow row in dtTDIds.Rows)
                    {
                        SqlCommand cmd = new SqlCommand("spDeleteTransAccount", connection, trans);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@TransDID", SqlDbType.Int).Value = row["TransDID"];
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteTransaction(int TMID, SqlConnection con, SqlTransaction trans)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spDeleteTransaction", con, trans);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TransMID", SqlDbType.Int).Value = TMID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteTransDetail(int TMID, SqlConnection con, SqlTransaction trans)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spDeleteTransDetail", con, trans);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TransMID", SqlDbType.Int).Value = TMID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getTransDID(SqlConnection con, int TransMID, int AccountID)
        {
            int TransDID = -1;
            try
            {
                SqlCommand cmd = new SqlCommand("Select dbo.fnGetTransDID( @TransMID,@AccountID)", con);
                cmd.Parameters.Add("@TransMID", SqlDbType.Int).Value = TransMID;
                cmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
                TransDID = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return TransDID;
        }
        public int getTransDID(SqlConnection con, SqlTransaction trans, int TransMID, int AccountID)
        {
            int TransDID = -1;
            try
            {
                SqlCommand cmd = new SqlCommand("Select dbo.fnGetTransDID( @TransMID,@AccountID)", con, trans);
                cmd.Parameters.Add("@TransMID", SqlDbType.Int).Value = TransMID;
                cmd.Parameters.Add("@AccountID", SqlDbType.Int).Value = AccountID;
                TransDID = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return TransDID;
        }
    }
}
