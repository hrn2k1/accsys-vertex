using Accounting.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Accounting.DataAccess
{
    public class ReportDataSource
    {
        private static readonly string _connectionString = ConnectionHelper.DefaultConnectionString;

        public static DataTable GetAccountList(int companyId)
        {
            var dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT AccountId, AccountTitle FROM T_Account Where CompanyId=@CompanyId AND AccOrGroup='Account' ORDER BY AccountTitle", _connectionString))
            {
                adapter.SelectCommand.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.Fill(dt);
                adapter.Dispose();
            }
            return dt;
        }
        public static DataTable GetItemList(int companyId)
        {
            var dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT ItemId, ItemName FROM T_Item Where CompanyId=@CompanyId ORDER BY ItemName", _connectionString))
            {
                adapter.SelectCommand.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.Fill(dt);
                adapter.Dispose();
            }
            return dt;
        }
        public static DataTable GetItemGroups(int companyId)
        {
            var dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT ItemGroupId AS GroupId, GroupName FROM T_ItemGroup Where CompanyId=@CompanyId ORDER BY GroupName", _connectionString))
            {
                adapter.SelectCommand.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.Fill(dt);
                adapter.Dispose();
            }
            return dt;
        }
        public static DataRow GetAccountOpeningBalance(int companyId, int accountId, DateTime onDate)
        {
            var dtAccount = new DataTable();
            if (accountId > 0)
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT A.AccountId, A.AccountNo, A.AccountTitle, A.Nature, AB.Balance FROM fnAccountBalance(@onDate, @CompanyID) AS AB INNER JOIN T_Account A ON AB.AccountId=A.AccountId WHERE AB.AccountId=@AccountID", _connectionString))
                {
                    adapter.SelectCommand.Parameters.Add("@onDate", SqlDbType.DateTime).Value = onDate;
                    adapter.SelectCommand.Parameters.Add("@AccountID", SqlDbType.Int).Value = accountId;
                    adapter.SelectCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyId;
                    adapter.Fill(dtAccount);
                    adapter.Dispose();
                }
            }
            if (dtAccount.Rows.Count > 0)
            {
                return dtAccount.Rows[0];
            }
            else
            {
                dtAccount = new DataTable();
                dtAccount.Columns.Add("AccountId");
                dtAccount.Columns.Add("AccountNo");
                dtAccount.Columns.Add("AccountTitle");
                dtAccount.Columns.Add("Nature");
                dtAccount.Columns.Add("Balance");
                var row = dtAccount.NewRow();
                row["AccountId"] = 0;
                row["AccountNo"] = "";
                row["AccountTitle"] = "";
                row["Nature"] = "";
                row["Balance"] = 0;
                return row;
            }
        }
        public static DataTable GetAccountOpeningBalances(int companyId, string type, DateTime onDate)
        {
            var dtAccounts = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT A.AccountId, A.AccountNo, A.AccountTitle, A.Nature, AB.Balance FROM fnAccountBalance(@onDate, @CompanyID) AS AB INNER JOIN VW_AccountWithClassification A ON AB.AccountId=A.AccountId WHERE A.CompanyID=@CompanyID AND ISNULL(A.AccountSubType, '') LIKE '" + type + "' ORDER BY A.AccountTitle", _connectionString))
            {
                adapter.SelectCommand.Parameters.Add("@onDate", SqlDbType.DateTime).Value = onDate;
                adapter.SelectCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyId;
                adapter.Fill(dtAccounts);
                adapter.Dispose();
            }
            return dtAccounts;
        }
        public static DataRow GetItemOpeningBalance(int companyId, int itemId, DateTime onDate)
        {
            var dtItem = new DataTable();
            if (itemId > 0)
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT B.ItemId, B.ItemName, GroupName, Qty,Value FROM fnItemBalance(@onDate, @CompanyID) B INNER JOIN VW_Items A ON B.ItemId = A.ItemId WHERE A.ItemId=@ItemId", _connectionString))
                {
                    adapter.SelectCommand.Parameters.Add("@onDate", SqlDbType.DateTime).Value = onDate;
                    adapter.SelectCommand.Parameters.Add("@ItemId", SqlDbType.Int).Value = itemId;
                    adapter.SelectCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyId;
                    adapter.Fill(dtItem);
                    adapter.Dispose();
                }
            }
            if (dtItem.Rows.Count > 0)
            {
                return dtItem.Rows[0];
            }
            else
            {
                dtItem = new DataTable();
                dtItem.Columns.Add("ItemId");
                dtItem.Columns.Add("ItemName");
                dtItem.Columns.Add("Qty");
                dtItem.Columns.Add("Value");
                var row = dtItem.NewRow();
                row["ItemId"] = 0;
                row["ItemName"] = "";
                row["Qty"] = 0;
                row["Value"] = 0;
                return row;
            }
        }
        public static DataTable GetItemOpeningBalances(int companyId, int groupId, DateTime onDate)
        {
            var dtItems = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT A.ItemId, A.ItemName, A.GroupName, B.Qty, B.Value FROM fnItemBalance(@onDate, @CompanyID) AS B INNER JOIN VW_Items A ON B.ItemId=A.ItemId WHERE A.CompanyID=@CompanyID AND A.ItemGroupID=@GroupId ORDER BY A.ItemName", _connectionString))
            {
                adapter.SelectCommand.Parameters.Add("@onDate", SqlDbType.DateTime).Value = onDate;
                adapter.SelectCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyId;
                adapter.SelectCommand.Parameters.Add("@GroupId", SqlDbType.Int).Value = groupId;
                adapter.Fill(dtItems);
                adapter.Dispose();
            }
            return dtItems;
        }
        public static DataTable GetLedgerBookData(int companyId, int accountId, DateTime startDate, DateTime endDate)
        {
            var dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter("spRptLedgerBook", _connectionString))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                adapter.SelectCommand.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
                adapter.SelectCommand.Parameters.Add("@AccountID", SqlDbType.Int).Value = accountId;
                adapter.SelectCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyId;
                adapter.Fill(dt);
                adapter.Dispose();
            }
            return dt;
        }
        public static DataTable GetJournalBookData(int companyId, DateTime startDate, DateTime endDate)
        {
            var data = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter("spRptJournalBook", _connectionString))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                adapter.SelectCommand.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
                adapter.SelectCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyId;
                adapter.Fill(data);
                adapter.Dispose();
            }
            return data;
        }

        public static DataTable GetStockItemData(int itemId, DateTime startDate, DateTime endDate)
        {
            var data = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(@"SELECT TransDate, VoucherNo, Module, InQty, OutQty
                    FROM  VW_StockInOut WHERE ItemId=@ItemId AND TransDate BETWEEN @StartDate AND @EndDate
                    ORDER BY TransDate", _connectionString))
            {
                adapter.SelectCommand.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                adapter.SelectCommand.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                adapter.SelectCommand.Parameters.Add("@ItemId", SqlDbType.Int).Value = itemId;
                adapter.Fill(data);
                adapter.Dispose();
            }
            return data;
        }

        public static DataSet GetVoucherRegister(int companyId, DateTime startDate, DateTime endDate, int voucherType)
        {
            var where = voucherType > 0 ? " AND VoucherType = " + voucherType.ToString() : "";
            var data = new DataSet();
            data.Tables.Add("Vouchers");
            using (var adapter = new SqlDataAdapter(string.Format(@"SELECT TransMID,TransDate,VoucherNo,TransDescription FROM T_Transaction_Master 
                                                WHERE CompanyID=@CompanyId AND TransDate BETWEEN @StartDate AND @EndDate {0}
                                                ORDER BY TransDate, VoucherNo", where), _connectionString))
            {
                adapter.SelectCommand.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.SelectCommand.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate;
                adapter.SelectCommand.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate;
                adapter.Fill(data.Tables["Vouchers"]);
                adapter.Dispose();
            }
            data.Tables.Add("VoucherDetails");
            using (var adapter = new SqlDataAdapter(string.Format(@"SELECT TransDID, D.TransMID, D.AccountID, A.AccountTitle, A.AccountNo, DebitAmt, CreditAmt 
                        FROM T_Transaction_Detail D INNER JOIN T_Transaction_Master M ON D.TransMID = M.TransMID INNER JOIN T_Account A ON D.AccountID = A.AccountID
                        WHERE M.CompanyID=@CompanyId AND TransDate BETWEEN @StartDate AND @EndDate {0}
                        ORDER BY CreditAmt", where), _connectionString))
            {
                adapter.SelectCommand.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.SelectCommand.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate;
                adapter.SelectCommand.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate;
                adapter.Fill(data.Tables["VoucherDetails"]);
                adapter.Dispose();
            }
            data.Relations.Add("Relations", data.Tables["Vouchers"].Columns["TransMID"], data.Tables["VoucherDetails"].Columns["TransMID"], false);
            return data;
        }
        public static DataTable GetBillsPayables(int companyId, DateTime onDate)
        {
            var data = new DataTable();
            var qstr = @"SELECT A.AccountID, A.AccountNo, A.AccountTitle, A.Nature * B.Balance AS Balance, A.CompanyID FROM dbo.fnAccountBalance(@OnDate, @CompanyId) B INNER JOIN VW_AccountWithClassification A ON A.AccountID=B.AccountID
                        WHERE A.AccountSubType LIKE 'Bills Payable' AND A.CompanyID=@CompanyId
                        ORDER BY A.AccountTitle";
            using (var adapter = new SqlDataAdapter(qstr, _connectionString))
            {
                adapter.SelectCommand.Parameters.Add("@OnDate", SqlDbType.Date).Value = onDate;
                adapter.SelectCommand.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.Fill(data);
                adapter.Dispose();
            }
            return data;
        }

        public static DataTable GetBillsReceiavble(int companyId, DateTime onDate)
        {
            var data = new DataTable();
            var qstr = @"SELECT A.AccountID, A.AccountNo, A.AccountTitle, A.Nature * B.Balance AS Balance, A.CompanyID FROM dbo.fnAccountBalance(@OnDate, @CompanyId) B INNER JOIN VW_AccountWithClassification A ON A.AccountID=B.AccountID
                        WHERE A.AccountSubType LIKE 'Bills Receivable' AND A.CompanyID=@CompanyId
                        ORDER BY A.AccountTitle";
            using (var adapter = new SqlDataAdapter(qstr, _connectionString))
            {
                adapter.SelectCommand.Parameters.Add("@OnDate", SqlDbType.Date).Value = onDate;
                adapter.SelectCommand.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.Fill(data);
                adapter.Dispose();
            }
            return data;
        }

        public static DataTable GetTrialBalanceSummary(int companyId, DateTime onDate)
        {
            var data = new DataTable();
            using (var adapter = new SqlDataAdapter("spRptTrialBalanceSummery", _connectionString))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add("@AtDate", SqlDbType.Date).Value = onDate;
                adapter.SelectCommand.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.Fill(data);
                adapter.Dispose();
            }
            return data;
        }
        public static TrialBalanceItem GetTrialBalanceDetail(int companyId, DateTime onDate)
        {
            
            var items = new List<TrialBalanceItem>();
            var data = new DataTable();
            using (var adapter = new SqlDataAdapter("spRptTrialBalanceDetails", _connectionString))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.Add("@AtDate", SqlDbType.Date).Value = onDate;
                adapter.SelectCommand.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.Fill(data);
                adapter.Dispose();
            }
            decimal crTotal = 0.0m, drTotal = 0.0m;
            foreach (DataRow row in data.Rows)
            {
                var group = row["AccountType"]?.ToString() ?? "";
                var amt = Convert.ToDecimal(row["OpeningBalance"]);
                var dr = amt >= 0 ? amt : 0;
                var cr = amt < 0 ? -amt : 0;
                drTotal += dr;
                crTotal += cr;
                var item = items.FirstOrDefault(x => x.Title == group);
                if (item == null)
                {
                    item = new TrialBalanceItem { Title = group, Type = "0", Debit = dr, Credit = cr, Details = new List<TrialBalanceItem>() };
                    items.Add(item);
                }
                else
                {
                    item.Debit += dr;
                    item.Credit += cr;
                }
                var subGoup = row["AccountSubType"]?.ToString() ?? "";
                var accDetails = new List<TrialBalanceItem>();
                if (subGoup != "")
                {
                    var subItem = item.Details.FirstOrDefault(x => x.Title == subGoup);
                    if (subItem == null)
                    {
                        subItem = new TrialBalanceItem { Title = subGoup, Type = "1", Debit = dr, Credit = cr, Details = new List<TrialBalanceItem>() };
                        item.Details.Add(subItem);
                    }
                    else
                    {
                        subItem.Debit += dr;
                        subItem.Credit += cr;
                    }
                    accDetails = subItem.Details;
                }
                else
                {
                    accDetails = item.Details;
                }
                var account = row["AccountTitle"]?.ToString() ?? "";
                accDetails.Add(new TrialBalanceItem { Title = account, Type = "2", Debit = dr, Credit = cr, Details = new List<TrialBalanceItem>() });
            }

            return new TrialBalanceItem
            {
                Title = "Grand Total",
                Type = "3",
                Debit = drTotal,
                Credit = crTotal,
                Details = items
            };
        }

        public static DataTable GetStockSummary(int companyId)
        {
            string qstr = @"SELECT I.ItemID, I.ItemName, I.CurrentQty, I.UnitsName, ISNULL(SD.UnitPrice, I.UnitPrice) AS UnitPrice, I.CompanyID FROM T_Stock_InOut_Detail AS SD INNER JOIN dbo.T_Stock_InOut_Master AS SM ON SD.StockMID = SM.StockMID INNER JOIN 
                        (SELECT SD.ItemID, MAX(SM.TransDate) AS LastTransDate FROM T_Stock_InOut_Detail AS SD INNER JOIN dbo.T_Stock_InOut_Master AS SM ON SD.StockMID = SM.StockMID
                        WHERE SM.CompanyID = @CompanyID --AND SM.TransDate BETWEEN @StartDate AND @EndDate
                        GROUP BY SD.ItemID) LT ON LT.ItemID = SD.ItemID AND LT.LastTransDate = SM.TransDate
                        RIGHT OUTER JOIN vw_items I ON I.ItemID = LT.ItemID
                        WHERE I.CompanyID = @CompanyID ORDER BY I.GroupName, I.ItemName";
            var data = new DataTable();
            using (var adapter = new SqlDataAdapter(qstr, _connectionString))
            {
                adapter.SelectCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyId;
                adapter.Fill(data);
                adapter.Dispose();
            }
            return data;
        }

        public static List<ChartOfItem> GetChartOfItems(int companyId)
        {

            var items = new List<ChartOfItem>();
            var data = new DataTable();
            using (var adapter = new SqlDataAdapter("SELECT AccountID, AccountNo, AccountTitle, AccountType, AccountSubType, AccountMinorType, CompanyID FROM VW_AccountWithClassification WHERE CompanyID=@CompanyId ORDER BY  AccountType, AccountSubType, AccountMinorType, AccountTitle", _connectionString))
            {
                adapter.SelectCommand.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                adapter.Fill(data);
                adapter.Dispose();
            }
            foreach (DataRow row in data.Rows)
            {
                var group0 = row["AccountType"]?.ToString() ?? "";
                var accountNo = row["AccountNo"].ToString();
                var item = items.FirstOrDefault(x => x.AccountTitle == group0);
                if (item == null)
                {
                    item = new ChartOfItem { AccountTitle = group0, Type = "Group0", Children = new List<ChartOfItem>() };
                    items.Add(item);
                }
                
                var group1 = row["AccountSubType"]?.ToString() ?? "";
                var children = new List<ChartOfItem>();
                ChartOfItem subItem = null;
                if (group1 != "")
                {
                    subItem = item.Children.FirstOrDefault(x => x.AccountTitle == group1);
                    if (subItem == null)
                    {
                        subItem = new ChartOfItem { AccountTitle = group1, Type = "Group1", Children = new List<ChartOfItem>() };
                        item.Children.Add(subItem);
                    }
                    children = subItem.Children;
                }
                else
                {
                    children = item.Children;
                }
                if (subItem != null)
                {
                    var group2 = row["AccountMinorType"]?.ToString() ?? "";
                    if (group2 != "")
                    {
                        var minorItem = subItem.Children.FirstOrDefault(x => x.AccountTitle == group2);
                        if (minorItem == null)
                        {
                            minorItem = new ChartOfItem { AccountTitle = group1, Type = "Group2", Children = new List<ChartOfItem>() };
                            subItem.Children.Add(minorItem);
                        }
                        children = minorItem.Children;
                    }
                    else
                    {
                        children = subItem.Children;
                    }
                }
                var account = row["AccountTitle"]?.ToString() ?? "";
                children.Add(new ChartOfItem { AccountNo = accountNo, AccountTitle= account, Type = "Account",Children = new List<ChartOfItem>() });
            }

            return items;
        }
    }

    public class ChartOfItem
    {
        public string AccountNo { get; set; }
        public string AccountTitle { get; set; }
        public string Type { get; set; }
        public List<ChartOfItem> Children { get; set; }
    }
    public class TrialBalanceItem
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public List<TrialBalanceItem> Details { get; set; }
    }

}