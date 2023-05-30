using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AccSys.Web.Models
{
    public enum SalesInvoiceType
    {
        DirectSale = 0,
        OrderSale = 1
    }
    public class SalesInvoiceModel
    {
        public int InvoiceId { get; set; }
        public SalesInvoiceType InvoiceType { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string ChalanNo { get; set; }
        public int CurrencyId { get; set; }
        public double CurrencyRate { get; set; }
        public double InvoiceAmount { get; set; }
        public int DiscountType { get; set; }
        public Double DiscountRate { get; set; }
        public Double DiscountAmount => DiscountType == 0 ? DiscountRate : InvoiceAmount * CurrencyRate / 100.0 * DiscountRate;
        public Double TransAmount => InvoiceAmount * CurrencyRate - DiscountAmount;
        /// <summary>
        /// Customer or Cash/Bank Account Id
        /// </summary>
        public int AccountId { get; set; }
        public string AccountTitle { get; set; }
        public int LedgerId { get; set; }
        public int SalesAccountId { get; set; }
        public string SalesAccountTitle { get; set; }
        public string Remarks { get; set; }
        public int TransRefId { get; set; }
        public string VoucherNo { get; set; }
        public int StockRefId { get; set; }
        public int CompanyId { get; set; }
        public DataTable InvoiceItems { get; set; }
        public Sales_Invoice InvoiceMaster
        {
            get
            {
                return new Sales_Invoice
                {
                    InvoiceID = InvoiceId,
                    InvoiceDate = InvoiceDate,
                    InvoiceNo = InvoiceNo,
                    ChalanNo = ChalanNo,
                    InvoiceType = InvoiceType == SalesInvoiceType.DirectSale ? "Direct Sale" : "Sales Order",
                    CurrencyID = CurrencyId,
                    Rate = CurrencyRate,
                    CustomerAccount = AccountId,
                    SalesAccount = SalesAccountId,
                    SalesAmount = InvoiceAmount * CurrencyRate,
                    DiscountRate = DiscountType == 0 ? 0: DiscountRate,
                    DiscountAmount = DiscountAmount,
                    TransAmount = TransAmount,
                    Remarks = Remarks,
                    TransRefID = TransRefId,
                    StockRefID = StockRefId,
                    CompanyID = CompanyId
                };
            }
        }
        public List<Sales_Invoice_Detail> InvoiceDetails
        {
            get
            {
                var items = new List<Sales_Invoice_Detail>();
                foreach (DataRow row in this.InvoiceItems.Rows)
                {
                    var item = new Sales_Invoice_Detail
                    {
                        SLNo = 0,
                        InvoiceID = this.InvoiceId,
                        ItemID = GlobalFunctions.isNull(row["ItemID"], 0),
                        InvQty = GlobalFunctions.isNull(row["Qty"], 0.0),
                        UnitPrice = GlobalFunctions.isNull(row["UnitPrice"], 0.0),
                        PriceAmount = GlobalFunctions.isNull(row["Amount"], 0.0),
                        OrderID = GlobalFunctions.isNull(row["OrderID"], 0),
                        Remarks = "",
                        Labdip = "",
                        ColorCode = ""
                    };
                    items.Add(item);
                }
                return items;
            }
        }
        public TransactionMaster Voucher
        {
            get
            {
                return new TransactionMaster
                {
                    TransactionMasterID = this.TransRefId,
                    VoucherNo = VoucherNo,
                    TransactionDate = this.InvoiceDate,
                    TransactionDescription = Remarks,
                    VoucherPayee = "",
                    VoucherType = InvoiceType == SalesInvoiceType.DirectSale ? 1 : 3,
                    TransactionMethodID = -1,
                    MethodRefID = -1,
                    MethodRefNo = string.Empty,
                    ApprovedBy = string.Empty,
                    ApprovedDate = new DateTime(1900, 1, 1),
                    Module = "Sales Invoice",
                    CompanyID = CompanyId
                };
            }
        }
        public List<TransactionDetail> VoucherAccounts
        {
            get
            {
                var accounts = new List<TransactionDetail>();
                accounts.Add(new TransactionDetail
                {
                    TransactionDetailID = 0,
                    TransactionMasterID = TransRefId,
                    TransactionAccountID = AccountId,
                    DebitAmount = TransAmount,
                    CreditAmount = 0,
                    Comments = SalesAccountTitle,
                    CompanyID = CompanyId
                });
                accounts.Add(new TransactionDetail
                {
                    TransactionDetailID = 0,
                    TransactionMasterID = TransRefId,
                    TransactionAccountID = SalesAccountId,
                    DebitAmount = 0,
                    CreditAmount = TransAmount,
                    Comments = AccountTitle,
                    CompanyID = CompanyId
                });
                
                return accounts;
            }
        }
        public Stock_InOut_Master Stock
        {
            get
            {
                return new Stock_InOut_Master
                {
                    StockMID = StockRefId,
                    TransDate = InvoiceDate,
                    TransType = "Store In For Customer",
                    ChalanNo = ChalanNo,
                    ChalanDate = InvoiceDate,
                    CustSupplID = LedgerId,
                    RefID = 0, // orderId
                    Remarks = "Store Out ",
                    Module = "Sales Invoice",
                    VoucherNo = VoucherNo,
                    CompanyID = CompanyId
                };
            }
        }

        public List<Stock_InOut_Detail> StockItems
        {
            get
            {
                var items = new List<Stock_InOut_Detail>();
                foreach (var item in InvoiceDetails)
                {
                    items.Add(new Stock_InOut_Detail
                    {
                        StockDID = 0,
                        StockMID = StockRefId,
                        TransNature = "In",
                        ItemID = item.ItemID,
                        InQty = 0,
                        OutQty = item.InvQty,
                        UnitPrice = item.UnitPrice,
                        InAmount = 0,
                        OutAmount = item.PriceAmount,
                        Budle_Pack_Qty = "",
                        Budle_Pack_Size = "",
                        Specifications = ""
                    });
                }
                return items;
            }
        }

        public List<string> ValidationErrors
        {
            get
            {
                var errors = new List<string>();
                if (CompanyId <= 0)
                {
                    errors.Add("Session expired. Please login again.");
                }
                if (string.IsNullOrWhiteSpace(InvoiceNo))
                {
                    errors.Add("Invoice No. required.");
                }
                if (CurrencyId <= 0)
                {
                    errors.Add("Currency required");
                }
                if (CurrencyRate <= 0)
                {
                    errors.Add("Currency rate is invalid.");
                }
                if (AccountId <= 0)
                {
                    errors.Add("Customer account required.");
                }
                if (SalesAccountId <= 0)
                {
                    errors.Add("Sales account required.");
                }
                if (InvoiceAmount <= 0)
                {
                    errors.Add("Invoice amount is invalid");
                }
                return errors;
            }
        }
    }
}