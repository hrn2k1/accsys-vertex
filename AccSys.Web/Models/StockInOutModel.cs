using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AccSys.Web.Models
{
    public enum StockInOutType
    {
        StoreInForCustomer = 0,
        StoreOutViaRequisition = 1,
        StoreOutForCustomer = 2,
        Damage = 3
    }
    public enum TransType
    {
        In = 1,
        Out = -1
    }
    public class StockInOutModel
    {
        private TransType TransType { get; set; }
        public int StockId { get; set; }
        public StockInOutType InOutType { get; set; }
        public DateTime TransDate { get; set; }
        public string VoucherNo { get; set; }
        public string ChalanNo { get; set; }
        public DateTime ChalanDate { get; set; }
        public Double TransAmount { get; set; }
        
        public string Remarks { get; set; }
        public int RefId { get; set; }
        public int LedgerId { get; set; }
        public int CompanyId { get; set; }

        public double TotalQty { get; set; }
        public DataTable StockItems { get; set; }

        public Stock_InOut_Master Stock
        {
            get
            {
                var stock =  new Stock_InOut_Master
                {
                    StockMID = StockId,
                    TransDate = TransDate,
                    TransType = "Store In For Customer",
                    ChalanNo = ChalanNo,
                    ChalanDate = TransDate,
                    CustSupplID = LedgerId,
                    RefID = RefId,
                    Remarks = Remarks,
                    Module = "Stock In Out",
                    VoucherNo = VoucherNo,
                    CompanyID = CompanyId
                };
                switch (this.InOutType)
                {
                    case StockInOutType.Damage:
                        stock.TransType = "Damage";
                        this.TransType = TransType.Out;
                        break;
                    case StockInOutType.StoreInForCustomer:
                        stock.TransType = "Store In For Customer";
                        this.TransType = TransType.In;
                        break;
                    case StockInOutType.StoreOutForCustomer:
                        stock.TransType = "Store Out For Customer";
                        this.TransType = TransType.Out;
                        break;
                    case StockInOutType.StoreOutViaRequisition:
                        stock.TransType = "Store Out Via Requisition";
                        this.TransType = TransType.Out;
                        break;

                }
                return stock;
            }
        }

        public List<Stock_InOut_Detail> StockDetails
        {
            get
            {
                var items = new List<Stock_InOut_Detail>();
                foreach (DataRow row in StockItems.Rows)
                {
                    items.Add(new Stock_InOut_Detail
                    {
                        StockDID = 0,
                        StockMID = StockId,
                        TransNature = this.TransType.ToString(),
                        ItemID = GlobalFunctions.isNull(row["ItemID"], 0),
                        InQty = this.TransType == TransType.In ? GlobalFunctions.isNull(row["Qty"], 0.0): 0,
                        OutQty = this.TransType == TransType.Out ? GlobalFunctions.isNull(row["Qty"], 0.0): 0,
                        UnitPrice = GlobalFunctions.isNull(row["UnitPrice"], 0.0),
                        InAmount = this.TransType == TransType.In ? GlobalFunctions.isNull(row["Amount"], 0.0) : 0.0,
                        OutAmount = this.TransType == TransType.Out ? GlobalFunctions.isNull(row["Amount"], 0.0) : 0.0,
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
                //if (string.IsNullOrWhiteSpace(VoucherNo))
                //{
                //    errors.Add("Voucher No. required.");
                //}
                //if(TotalQty <= 0)
                //{
                //    errors.Add("Quantity must be greater than 0");
                //}
                
                return errors;
            }
        }
    }
}