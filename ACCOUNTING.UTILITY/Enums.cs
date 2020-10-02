using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Utility
{
    public enum LedgerTypes
    {
        GeneralLedger = 1,
        CustomerLedger = 2,
        SupplierLedger = 3,
        BankLedger = 4,
        CashLedger = 5
    }
    public enum VoucherTypes
    {
        Credit = 1,
        Debit = 2,
        Journal = 3
    };
}
