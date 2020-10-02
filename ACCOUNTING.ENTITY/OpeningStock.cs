using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Entity
{
   public class OpeningStock : BaseObject
    {
       public OpeningStock() : base() { }

       private int numOpID;
       private int numFiscalYearID;
       private int numCustomerID;
       private int numItemID;
       private int numUnitID;
       private double numOpQty;
       private double dblUnitPrice;
       private double dblOpAmt;
       private DateTime dtOpDate;
       private double dblDRate;
       private string strSpecifications = "";
       private string strBudle_Pack_Size = "";
       private string strBudle_Pack_Qty = "";
       private int nCountID;
       private int nSizeID;
       private int nColorID;
       private int nCurrencyID;

       public int OpeningID
       {
           get { return numOpID; }
           set { numOpID=value; }
       }
       public int FiscalYearID
       {
           get { return numFiscalYearID; }
           set { numFiscalYearID=value; }
       }
       public int CustomerID
       {
           get { return numCustomerID; }
           set { numCustomerID=value; }
       }
       public int ItemID
       {
           get { return numItemID; }
           set { numItemID=value; }
       }
       public int UnitID
       {
           get { return numUnitID; }
           set { numUnitID=value; }
       }
       public double OpeningQuantity
       {
           get { return numOpQty; }
           set { numOpQty=value; }
       }
       public double UnitPrice
       {
           get { return dblUnitPrice; }
           set { dblUnitPrice=value; }
       }
       public double OpeningAmount
       {
           get { return dblOpAmt; }
           set { dblOpAmt=value; }
       }
       public DateTime OpeningDate
       {
           get { return dtOpDate; }
           set { dtOpDate=value; }
       }
       public double DRate
       {
           get { return dblDRate; }
           set { dblDRate = value; }
       }
       public string Specifications
       {
           get { return strSpecifications; }
           set { strSpecifications = value; }
       }
       public string Budle_Pack_Size
       {
           get { return strBudle_Pack_Size; }
           set { strBudle_Pack_Size = value; }
       }
       public string Budle_Pack_Qty
       {
           get { return strBudle_Pack_Qty; }
           set { strBudle_Pack_Qty = value; }
       }
       public int CountID
       {
           get { return nCountID; }
           set { nCountID = value; }
       }
       public int SizeID
       {
           get { return nSizeID; }
           set { nSizeID = value; }
       }
       public int ColorID
       {
           get { return nColorID; }
           set { nColorID = value; }
       }
       public int CurrencyID
       {
           get { return nCurrencyID; }
           set { nCurrencyID = value; }
       }
    }
}
