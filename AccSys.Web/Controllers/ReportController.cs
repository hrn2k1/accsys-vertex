using Accounting.DataAccess;
using Accounting.Entity;
using AccSys.Web.Models;
using Rotativa.MVC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace AccSys.Web.Controllers
{
    public class ReportController : Controller
    {

        #region Common
        public ActionResult Pdf()
        {
            var param = new ReportParameter(Request);
            var report = new ActionAsPdf(param?.Report?.ActionName ?? "Blank", param);
            return report;
        }
        public ActionResult Index(ReportParameter param)
        {
            return Accounting(param);
        }
        public ActionResult Accounting(ReportParameter param)
        {
            if (Request.HttpMethod == "GET")
            {
                param.ReportName = "rptLedgerBook";
                //param.StartDate = DateTime.Now.AddDays(-7);
                //param.EndDate = DateTime.Now;
            }
            return Reporting("Accounting", param);
        }
        public ActionResult Inventory(ReportParameter param)
        {
            if (Request.HttpMethod == "GET")
                param.ReportName = "rptStockJournal";
            return Reporting("Inventory", param);
        }
        private ActionResult Reporting(string section, ReportParameter param)
        {
            param.CompanyId = Convert.ToInt32(Session["CompanyId"] ?? "1");
            if (Session["Company"] != null)
            {
                var company = (Company)Session["Company"];
                if(company != null)
                {
                    param.CompanyName = company.CompanyName;
                    param.AddressLine1 = company.AddressLine1;
                    param.AddressLine2 = company.AddressLine2;
                }
            }
            ViewBag.CompanyName = param.CompanyName;
            ViewBag.Section = section;
            ViewBag.ReportTypes = new SelectList(Config.ReportTypes, "Id", "Name");
            ViewBag.AccountList = new SelectList(new List<SelectListItem>());
            ViewBag.ItemGroups = new SelectList(new List<SelectListItem>());
            ViewBag.ItemList = new SelectList(new List<SelectListItem>());
            ViewBag.VoucherTypes = new SelectList(new List<SelectListItem>());
            ViewBag.TrialBalanceTypes = new SelectList(new List<SelectListItem>());
            if (section == "Accounting")
            {
                var dtAccounts = ReportDataSource.GetAccountList(param.CompanyId);
                ViewBag.AccountList = ToSelectList(dtAccounts, "AccountId", "AccountTitle");
                var voucherTypes = DaVoucherType.GetVoucherTypes();
                var all = voucherTypes.NewRow();
                all["VoucherTypeID"] = 0;
                all["VoucherType"] = "All";
                voucherTypes.Rows.InsertAt(all, 0);
                ViewBag.VoucherTypes = ToSelectList(voucherTypes, "VoucherTypeID", "VoucherType");

                ViewBag.TrialBalanceTypes = new SelectList(Config.TrialBalanceTypes, "Id", "Name");
            }
            else if (section == "Inventory")
            {
                var dtGroups = ReportDataSource.GetItemGroups(param.CompanyId);
                ViewBag.ItemGroups = ToSelectList(dtGroups, "GroupId", "GroupName");
                var dtItems = ReportDataSource.GetItemList(param.CompanyId);
                ViewBag.ItemList = ToSelectList(dtItems, "ItemId", "ItemName");
            }
            ViewBag.Reports = Config.Reports.Where(x => x.Section == section).ToList();
            if (param == null)
            {
                param = new ReportParameter();
            }

            return View("Index", param);
        }
        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }
        #endregion
        #region Accounting Reports
        // GET: Report
        public ActionResult LedgerBook()
        {
            var param = new ReportParameter(Request);
            ViewBag.Params = param;
            var reportData = new LedgerBookData();
            reportData.Account = ReportDataSource.GetAccountOpeningBalance(param.CompanyId, param.AccountId, param.StartDate.AddDays(-1));
            reportData.Data = ReportDataSource.GetLedgerBookData(param.CompanyId, param.AccountId, param.StartDate, param.EndDate);
            return View(reportData);
        }

        public ActionResult JournalBook()
        {
            var param = new ReportParameter(Request);
            ViewBag.Params = param;
            var data = ReportDataSource.GetJournalBookData(param.CompanyId, param.StartDate, param.EndDate);
            return View(data);
        }

        private List<LedgerBookData> GetLedgersOfAccounts(DateTime startDate, DateTime endDate, int companyId, string type)
        {
            var dtAccounts = ReportDataSource.GetAccountOpeningBalances(companyId, type, startDate.AddDays(-1));
            var reportData = new List<LedgerBookData>();
            foreach (DataRow account in dtAccounts.Rows)
            {
                var data = ReportDataSource.GetLedgerBookData(companyId, Convert.ToInt32(account["AccountId"]), startDate, endDate);
                reportData.Add(new LedgerBookData { Account = account, Data = data });
            }
            return reportData;
        }
        public ActionResult CashBook()
        {
            var param = new ReportParameter(Request);
            ViewBag.Params = param;
            var reportData = GetLedgersOfAccounts(param.StartDate, param.EndDate, param.CompanyId, "Cash");

            return View(reportData);
        }

        public ActionResult BankBook()
        {
            var param = new ReportParameter(Request);
            ViewBag.Params = param;
            var reportData = GetLedgersOfAccounts(param.StartDate, param.EndDate, param.CompanyId, "Bank Account");

            return View("CashBook", reportData);
        }

        public ActionResult VoucherRegister()
        {
            var param = new ReportParameter(Request);
            ViewBag.Params = param;
            var reportData = ReportDataSource.GetVoucherRegister(param.CompanyId, param.StartDate, param.EndDate, param.VoucherType);

            return View(reportData);
        }

        public ActionResult BillsPayable()
        {
            var param = new ReportParameter(Request);
            ViewBag.Params = param;
            var reportData = ReportDataSource.GetBillsPayables(param.CompanyId, param.Date);

            return View("Bills", reportData);
        }

        public ActionResult BillsReceivable()
        {
            var param = new ReportParameter(Request);
            ViewBag.Params = param;
            var reportData = ReportDataSource.GetBillsReceiavble(param.CompanyId, param.Date);
            return View("Bills", reportData);
        }

        public ActionResult TrialBalance()
        {
            var param = new ReportParameter(Request);
            ViewBag.Params = param;
            if (param.TrialBalanceType == (int)TrialBalanceTypes.Summary)
            {
                var reportData = ReportDataSource.GetTrialBalanceSummary(param.CompanyId, param.Date);
                return View("TrialBalanceSummary", reportData);
            }
            else
            {
                var reportData = ReportDataSource.GetTrialBalanceDetail(param.CompanyId, param.Date);
                return View("TrialBalanceDetail", reportData);
            }
        }
        public ActionResult ChartOfItems()
        {
            var param = new ReportParameter(Request);
            ViewBag.Params = param;
            var reportData = ReportDataSource.GetChartOfItems(param.CompanyId);
            return View(reportData);
        }
        #endregion

        #region Inventory Reports
        private List<ItemLedgerData> GetLedgersOfItems(DateTime startDate, DateTime endDate, int companyId, int groupId)
        {
            var dtItems = ReportDataSource.GetItemOpeningBalances(companyId, groupId, startDate.AddDays(-1));
            var reportData = new List<ItemLedgerData>();
            foreach (DataRow item in dtItems.Rows)
            {
                var data = ReportDataSource.GetStockItemData(Convert.ToInt32(item["ItemId"]), startDate, endDate);
                reportData.Add(new ItemLedgerData { Item = item, Data = data });
            }
            return reportData;
        }
        public ActionResult StockJournal()
        {
            var param = new ReportParameter(Request);
            ViewBag.Params = param;
            List<ItemLedgerData> data = GetLedgersOfItems(param.StartDate, param.EndDate, param.CompanyId, param.GroupId);
            return View(data);
        }

        public ActionResult ItemLedger()
        {
            var param = new ReportParameter(Request);
            ViewBag.Params = param;
            var data = new ItemLedgerData
            {
                Item = ReportDataSource.GetItemOpeningBalance(param.CompanyId, param.ItemId, param.StartDate.AddDays(-1)),
                Data = ReportDataSource.GetStockItemData(param.ItemId, param.StartDate, param.EndDate)
            };
            return View(data);
        }
        public ActionResult StockSummary()
        {
            var param = new ReportParameter(Request);
            ViewBag.Params = param;
            DataTable data = ReportDataSource.GetStockSummary(param.CompanyId);
            return View(data);
        }
        #endregion

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/login");
        }
    }
}