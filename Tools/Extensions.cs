using System;
using System.Web;
using System.Web.SessionState;

namespace Tools
{
    public static class Extensions
    {
        public static int CompanyId(this HttpSessionState session)
        {
            var companyIdObj = HttpContext.Current.Session["CompanyID"];
            if (companyIdObj == null)
                return 0;
            int.TryParse(companyIdObj.ToString(), out int companyId);
            return companyId;
        }
        public static int ToInt(this string str, int? fallbackValue = 0)
        {
            if (int.TryParse(str, out int num))
                return num;
            else if(fallbackValue.HasValue)
            {
                return fallbackValue.Value;
            }
            else
            {
                throw new Exception(string.Format("'{0}' is not an interger", str));
            }
        }
        public static double ToDouble(this string str, double? fallbackValue = 0.0)
        {
            if (double.TryParse(str, out double num))
                return num;
            else if (fallbackValue.HasValue)
            {
                return fallbackValue.Value;
            }
            else
            {
                throw new Exception(string.Format("'{0}' is not a double", str));
            }
        }
    }
}
