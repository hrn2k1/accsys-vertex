using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Collections.Generic;
using System.Data;

namespace AccSys.Web.Models
{
    public enum InvoiceType
    {
        DirectPurchase = 0,
        OrderPurchase = 1
    }
    public class PurchaseInvoiceModel
    {
        
        public int InvoiceId { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public int CurrencyId { get; set; }
        public double CurrencyRate { get; set; }
        public double InvoiceAmount { get; set; }
        /// <summary>
        /// Supplier or Cash/Bank Account Id
        /// </summary>
        public int AccountId { get; set; }
        public string AccountTitle { get; set; }
        public int LedgerId { get; set; }
        public string Remarks { get; set; }
        public int RawMaterialAccountId { get; set; }
        public string RawMaterialAccountTitle { get; set; }
        public double RawMaterialAmount { get; set; }
        public int FinishGoodsAccountId { get; set; }
        public string FinishGoodsAccountTitle { get; set; }
        public double FinishGoodsAmount { get; set; }
        public int TransRefId { get; set; }
        public string VoucherNo { get; set; }
        public int StockRefId { get; set; }
        public int CompanyId { get; set; }
        public DataTable InvoiceItems { get; set; }
        public Purchases_Invoice InvoiceMaster
        {
            get
            {
                return new Purchases_Invoice
                {
                    InvoiceID = this.InvoiceId,
                    InvoiceDate = this.InvoiceDate,
                    InvoiceNo = this.InvoiceNo,
                    InvoiceType = this.InvoiceType == InvoiceType.DirectPurchase ? "Direct Purchases" : "Purchases Order",
                    CurrencyID = this.CurrencyId,
                    Rate = this.CurrencyRate,
                    TransAmmount = this.InvoiceAmount * CurrencyRate,
                    SupplierAccountID = this.AccountId,
                    PurchasesAccountID = this.RawMaterialAccountId,
                    PurchasesAccount2ID = this.FinishGoodsAccountId,
                    Remarks = this.Remarks,
                    TransRefID = this.TransRefId,
                    StockRefID = this.StockRefId,
                    CompanyID = this.CompanyId
                };
            }
        }
        public List<Purchases_Invoice_DTL> InvoiceDetails
        {
            get
            {
                var items = new List<Purchases_Invoice_DTL>();
                foreach (DataRow row in this.InvoiceItems.Rows)
                {
                    var item = new Purchases_Invoice_DTL
                    {
                        SLNO = 0,
                        InvoiceID = this.InvoiceId,
                        ItemID = GlobalFunctions.isNull(row["ItemID"], 0),
                        InvQty = GlobalFunctions.isNull(row["Qty"], 0.0),
                        UnitPrice = GlobalFunctions.isNull(row["UnitPrice"], 0.0),
                        PriceAmmount = GlobalFunctions.isNull(row["Amount"], 0.0),
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
                    VoucherType = InvoiceType == InvoiceType.DirectPurchase ? 2 : 3,
                    TransactionMethodID = -1,
                    MethodRefID = -1,
                    MethodRefNo = string.Empty,
                    ApprovedBy = string.Empty,
                    ApprovedDate = new DateTime(1900, 1, 1),
                    Module = "Purchase Invoice",
                    CompanyID = CompanyId
                };
            }
        }
        public List<TransactionDetail> VoucherAccounts
        {
            get
            {
                var accounts = new List<TransactionDetail>();
                var accLine = new TransactionDetail
                {
                    TransactionDetailID = 0,
                    TransactionMasterID = TransRefId,
                    TransactionAccountID = AccountId,
                    DebitAmount = 0,
                    CreditAmount = InvoiceAmount * CurrencyRate,
                    Comments = "",
                    CompanyID = CompanyId
                };
                accLine.Comments += accLine.Comments != "" ? Environment.NewLine : "";
                if (RawMaterialAmount != 0) accLine.Comments += RawMaterialAccountTitle;
                accLine.Comments += accLine.Comments != "" ? Environment.NewLine : "";
                if (FinishGoodsAmount != 0) accLine.Comments += FinishGoodsAccountTitle;
                accounts.Add(accLine);
                if (RawMaterialAmount != 0)
                {
                    accounts.Add(new TransactionDetail
                    {
                        TransactionDetailID = 0,
                        TransactionMasterID = TransRefId,
                        TransactionAccountID = RawMaterialAccountId,
                        DebitAmount = RawMaterialAmount * CurrencyRate,
                        CreditAmount = 0,
                        Comments = AccountTitle,
                        CompanyID = CompanyId
                    });
                }
                if (FinishGoodsAmount != 0)
                {
                    accounts.Add(new TransactionDetail
                    {
                        TransactionDetailID = 0,
                        TransactionMasterID = TransRefId,
                        TransactionAccountID = FinishGoodsAccountId,
                        DebitAmount = FinishGoodsAmount * CurrencyRate,
                        CreditAmount = 0,
                        Comments = AccountTitle,
                        CompanyID = CompanyId
                    });
                }
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
                    TransType = "Store In For Supplier",
                    ChalanNo = "",
                    ChalanDate = InvoiceDate,
                    CustSupplID = LedgerId,
                    RefID = 0, // orderId
                    Remarks = "Store In ",
                    Module = "Purchase Invoice",
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
                        InQty = item.InvQty,
                        OutQty = 0,
                        UnitPrice = item.UnitPrice,
                        InAmount = item.PriceAmmount,
                        OutAmount = 0,
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
                    errors.Add("Supplier account required.");
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