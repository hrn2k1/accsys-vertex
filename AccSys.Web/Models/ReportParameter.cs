using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;


namespace AccSys.Web.Models
{
    public enum ReportFormats
    {
        PDF = 0,
        HTML = 1
    }
    public enum TrialBalanceTypes
    {
        Summary = 0,
        Details = 1
    }
    public class ReportParameter
    {
        [Required, DefaultValue("rptLedgerBook")]
        public string ReportName { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int ReportType { get; set; }
        public int AccountId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int ItemId { get; set; }
        public int GroupId { get; set; }
        public int VoucherType { get; set; }
        public int TrialBalanceType { get; set; }
        public ReportParameter()
        {
            ReportName = "rptLedgerBook";
            StartDate = DateTime.Now.Date;
            EndDate = DateTime.Now.Date;
            ReportType = 0;
        }
        public ReportParameter(HttpRequestBase request)
        {
            try
            {
                ReportName = request["reportName"];
                CompanyId = Convert.ToInt32(request["companyId"] ?? "0");
                CompanyName = request["companyName"] ?? "";
                AddressLine1 = request["addressLine1"] ?? "";
                AddressLine2 = request["addressLine2"] ?? "";
                ReportType = Convert.ToInt32(request["reportType"] ?? "0");
                AccountId = Convert.ToInt32(request["accountId"] ?? "0");
                StartDate = request["startDate"] != null ? Convert.ToDateTime(request["startDate"]) : DateTime.Now;
                EndDate = request["endDate"] != null ? Convert.ToDateTime(request["endDate"]) : DateTime.Now;
                Date = request["date"] != null ? Convert.ToDateTime(request["date"]) : DateTime.Now;
                ItemId = Convert.ToInt32(request["itemId"] ?? "0");
                GroupId = Convert.ToInt32(request["groupId"] ?? "0");
                VoucherType = Convert.ToInt32(request["voucherType"] ?? "0");
                TrialBalanceType = Convert.ToInt32(request["trialBalanceType"] ?? "0");
            }
            catch (Exception ex)
            {

            }
        }
        
        public string ReportLink
        {
            get
            {
                var reportParams = new List<KeyValuePair<string, object>>();
                if (!string.IsNullOrWhiteSpace(ReportName)) reportParams.Add(new KeyValuePair<string, object>("reportName", ReportName));
                if (CompanyId > 0) reportParams.Add(new KeyValuePair<string, object>("companyId", CompanyId));
                if (CompanyName != "") reportParams.Add(new KeyValuePair<string, object>("companyName", CompanyName));
                if (AddressLine1 != "") reportParams.Add(new KeyValuePair<string, object>("addressLine1", AddressLine1));
                if (AddressLine2 != "") reportParams.Add(new KeyValuePair<string, object>("addressLine2", AddressLine2));
                reportParams.Add(new KeyValuePair<string, object>("reportType", ReportType));
                if (AccountId > 0) reportParams.Add(new KeyValuePair<string, object>("accountId", AccountId));
                if (StartDate != new DateTime()) reportParams.Add(new KeyValuePair<string, object>("startDate", StartDate.ToString("yyyy-MM-dd")));
                if (EndDate != new DateTime()) reportParams.Add(new KeyValuePair<string, object>("endDate", EndDate.ToString("yyyy-MM-dd")));
                if (Date != new DateTime()) reportParams.Add(new KeyValuePair<string, object>("date", EndDate.ToString("yyyy-MM-dd")));
                if (ItemId > 0) reportParams.Add(new KeyValuePair<string, object>("itemId", ItemId));
                if (GroupId > 0) reportParams.Add(new KeyValuePair<string, object>("groupId", GroupId));
                if (VoucherType > 0) reportParams.Add(new KeyValuePair<string, object>("voucherType", VoucherType));
                if (TrialBalanceType > 0) reportParams.Add(new KeyValuePair<string, object>("trialBalanceType", TrialBalanceType));
                var reportUrl = ReportType == 0 ? "/report/pdf" : "/report/" + Report.ActionName;
                return reportUrl + "?" + string.Join("&", reportParams.Select(x => $"{x.Key}={x.Value}"));
            }
        }
        public Report Report
        {
            get
            {
                return Config.Reports.FirstOrDefault(x => x.ReportName.Equals(this.ReportName, StringComparison.InvariantCultureIgnoreCase));
            }
        }
    }


    public class Report
    {
        public string ReportName { get; set; }
        public string ReportTitle { get; set; }
        public string ReportHeading { get; set; }
        public string ActionName { get; set; }
        public List<string> Parameters { get; set; }
        public string Section { get; set; }
    }
    public class IdName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Config
    {
        public static List<Report> Reports = new List<Report>()
        {

            new Report { ReportName="rptLedgerBook", ReportTitle="Ledger Book", ActionName="LedgerBook", Parameters= new List<string>(){ "AccountId", "StartDate", "EndDate" }, Section="Accounting" },
            new Report { ReportName="rptJournalBook", ReportTitle="Journal Book", ActionName="JournalBook", Parameters= new List<string>(){ "StartDate", "EndDate" }, Section="Accounting" },
            new Report { ReportName="rptCashBook", ReportTitle="Cash Book", ActionName="CashBook", Parameters= new List<string>(){ "StartDate", "EndDate" }, Section="Accounting" },
            new Report { ReportName="rptBankBook", ReportTitle="Bank Book", ActionName="BankBook", Parameters= new List<string>(){ "StartDate", "EndDate" }, Section="Accounting" },
            new Report { ReportName="rptVoucherRegister", ReportTitle="Voucher Register", ActionName="VoucherRegister", Parameters= new List<string>(){ "StartDate", "EndDate", "VoucherType" }, Section="Accounting" },
            new Report { ReportName="rptBillsPayable", ReportTitle="Bills Payable", ActionName="BillsPayable", Parameters= new List<string>(){ "Date", }, Section="Accounting" },
            new Report { ReportName="rptBillsReceivable", ReportTitle="Bills Receivable", ActionName="BillsReceivable", Parameters= new List<string>(){ "Date" }, Section="Accounting" },
            new Report { ReportName="rptChartOfItems", ReportTitle="Chart Of Items", ActionName="ChartOfItems", Parameters= new List<string>(){ }, Section="Accounting" },
            new Report { ReportName="rptTrialBalance", ReportTitle="Trial Balance", ActionName="TrialBalance", Parameters= new List<string>(){ "Date", "TrialBalanceType" }, Section="Accounting" },
            new Report { ReportName="rptStockJournal", ReportTitle="Stock Journal", ActionName="StockJournal", Parameters= new List<string>(){ "GroupId", "StartDate", "EndDate" }, Section="Inventory" },
            new Report { ReportName="rptItemLedger", ReportTitle="Item Ledger", ActionName="ItemLedger", Parameters= new List<string>(){ "ItemId", "StartDate", "EndDate" }, Section="Inventory" },
            new Report { ReportName="rptStockSummary", ReportTitle="Stock Summary", ActionName="StockSummary", Parameters= new List<string>(){ }, Section="Inventory" },
        };

        public static List<IdName> ReportTypes = Enum.GetValues(typeof(ReportFormats)).Cast<ReportFormats>().Select(x => new IdName { Id = (int)x, Name = x.ToString() }).ToList();
        public static List<IdName> TrialBalanceTypes = Enum.GetValues(typeof(TrialBalanceTypes)).Cast<TrialBalanceTypes>().Select(x => new IdName { Id = (int)x, Name = x.ToString() }).ToList();
    }

    public class LedgerBookData
    {
        public DataRow Account { get; set; }
        public DataTable Data { get; set; }
    }
    public class ItemLedgerData
    {
        public DataRow Item { get; set; }
        public DataTable Data { get; set; }
    }
}