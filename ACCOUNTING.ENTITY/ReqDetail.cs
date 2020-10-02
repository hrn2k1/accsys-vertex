using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Entity
{
    public class ReqDetail
    {
        public ReqDetail() { }
        #region Fields
        private int numReqDID = 0;
        private int numReqMID = 0;
        private int numItemID = 0;
        private double numReqQty = 0;
        private int numUnitID = 0;
        private string strBudle_Pack_Qty = "";
        private string strSpecifications = "";
        private string strBudle_Pack_Size = "";
        private int nCountID;
        private int nSizeID;
        private int nColorID;
        #endregion
        #region Properties
        public int ReqDID
        {
            get { return numReqDID; }
            set { numReqDID = value; }
        }
        public int ReqMID
        {
            get { return numReqMID; }
            set { numReqMID = value; }
        }
        public int ItemID
        {
            get { return numItemID; }
            set { numItemID = value; }
        }
        public double ReqQty
        {
            get { return numReqQty; }
            set { numReqQty = value; }
        }
        public int UnitID
        {
            get { return numUnitID; }
            set { numUnitID = value; }
        }
        public string Budle_Pack_Qty
        {
            get { return strBudle_Pack_Qty; }
            set { strBudle_Pack_Qty = value; }
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
        #endregion
    }
}
