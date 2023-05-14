using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AccSys.Web.Models
{
    public class PurchaseOrderModel
    {
        public int OrderId { get; set; }
        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNo { get; set; }
        public int CurrencyId { get; set; }
        public string BuyerRef { get; set; }
        public double OrderQty { get; set; }
        public double OrderValue { get; set; }
        public int CompanyId { get; set; }
        public DataTable OrderItems { get; set; }
        public Order_Master OrderMaster
        {
            get
            {
                return new Order_Master
                {
                    OrderMID = OrderId,
                    OrderDate = OrderDate,
                    OrderNo = OrderNo,
                    CurrencyID = CurrencyId,
                    Rate = 1,
                    CustomerID = SupplierId,
                    Buyer_ref = BuyerRef,
                    OrderType = "Purchase Order",
                    TotalOrderQty = OrderQty,
                    OrderValue = OrderValue,
                    CompanyID = CompanyId
                };
            }
        }
        public List<Order_Details> OrderDetails
        {
            get
            {
                var items = new List<Order_Details>();
                foreach (DataRow row in this.OrderItems.Rows)
                {
                    var item = new Order_Details
                    {
                        OrderDID = 0,
                        OrderMID = OrderId,
                        ItemID = GlobalFunctions.isNull(row["ItemID"], 0),
                        OrderQty = GlobalFunctions.isNull(row["Qty"], 0.0),
                        UnitPrice = GlobalFunctions.isNull(row["UnitPrice"], 0.0),
                        OrderValue = GlobalFunctions.isNull(row["Amount"], 0.0),
                        Remarks = "",
                        Labdip = "",
                        ColorCode = ""
                    };
                    items.Add(item);
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
                if (SupplierId <= 0)
                {
                    errors.Add("Supplier required.");
                }
                if (string.IsNullOrWhiteSpace(OrderNo))
                {
                    errors.Add("Order No. required.");
                }
                if (CurrencyId <= 0)
                {
                    errors.Add("Currency required");
                }
                if (OrderQty <= 0)
                {
                    errors.Add("Order quantity is invalid");
                }
                if (OrderValue <= 0)
                {
                    errors.Add("Order value is invalid");
                }
                return errors;
            }
        }
    }
}