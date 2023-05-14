using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccSys.Web.ReportUtils
{
    public static class ReportHelpers
    {
        public static string FormatDateTime(this object date, string format)
        {
            return date != null ? Convert.ToDateTime(date).ToString(format) : "";
        }
        public static string FormatNumber(this object number, string format, bool showZero = false)
        {
            if (number == null) return "-";
            var num = Convert.ToDecimal(number);
            if (num == 0 && !showZero) return "-";
            return num.ToString(format);
        }
        public static string FormatNature(this object nature)
        {
            if (nature == null) return "";
            return nature.ToString() == "1" ? "Dr" : "Cr";
        }
    }
}