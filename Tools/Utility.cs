using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Tools
{
    public enum DateNumericFormat
    {
        /// <summary>
        /// Day Month Year
        /// </summary>
        DDMMYYYY = 0,
        /// <summary>
        /// Month Day Year
        /// </summary>
        MMDDYYYY = 1,
        /// <summary>
        /// Year Month Day
        /// </summary>
        YYYYMMDD = 2

    }
    public class Utility
    {
        public static double Evaluate(string expression)
        {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)(loDataTable.Rows[0]["Eval"]);
        }
        double DoCal(string expression)
        {
            DataTable dt = new DataTable();
            var v = dt.Compute("3 * (2+4)", "");
            return (double)v;
        }
        public static string GetDaySuffix(int day)
        {
            switch (day)
            {
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
        }
        public static DateTime FirstDateOfMonth(int Month, int Year)
        {
            return new DateTime(Year, Month, 1);
        }
        public static DateTime FirstDateOfMonth(DateTime AnyDateofTheMonth)
        {
            return new DateTime(AnyDateofTheMonth.Year, AnyDateofTheMonth.Month, 1);
        }
        public static DateTime LastDateOfMonth(int Month, int Year)
        {
            return new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
        }
        public static DateTime LastDateOfMonth(DateTime AnyDateofTheMonth)
        {
            int Month, Year;
            Month = AnyDateofTheMonth.Month;
            Year = AnyDateofTheMonth.Year;
            return new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
        }
        public static DateTime GetDateValue(string DateString, DateNumericFormat format/*=DateNumericFormat.DDMMYYYY*/)
        {
            DateTime dt = new DateTime();
            string DDPart = "", MMPart = "", YYPart = "";
            try
            {
                string[] dates = DateString.Trim().Split(new char[] { '/', '.', '-' });

                switch (format)
                {
                    case DateNumericFormat.DDMMYYYY:
                        DDPart = dates[0];
                        MMPart = dates[1];
                        YYPart = dates[2];
                        break;
                    case DateNumericFormat.MMDDYYYY:
                        MMPart = dates[0];
                        DDPart = dates[1];
                        YYPart = dates[2];
                        break;
                    case DateNumericFormat.YYYYMMDD:
                        YYPart = dates[0];
                        MMPart = dates[1];
                        DDPart = dates[2];
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Date");
            }

            int dd = 0;
            try
            {
                dd = Convert.ToInt32(DDPart);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Day Value");
            }
            if (dd <= 0 || dd > 31)
                throw new Exception("Day value must be 1-31");

            int MM = 0;
            try
            {
                MM = Convert.ToInt32(MMPart);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Month Value");
            }
            if (MM <= 0 || MM > 12)
                throw new Exception("Month value must be 1-12");


            int yy = 0;
            try
            {
                yy = Convert.ToInt32(YYPart);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Year Value");
            }

            try
            {
                dt = new DateTime(yy, MM, dd);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Date ");
            }
            return dt;
        }
        public static DateTime GetDateValue(string DateString)
        {
            return GetDateValue(DateString, DateNumericFormat.DDMMYYYY);
        }
        public static DateTime GetDateTimeValue(DateTime Date, string TimeHHMMSS)
        {
            DateTime dt = new DateTime();
            string[] times = TimeHHMMSS.Trim().Split(new char[] { ':', '.' });
            int hh = 0;
            try
            {
                hh = Convert.ToInt32(times[0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Hour Value");
            }
            if (hh < 0 || hh > 24)
                throw new Exception("Hour value must be 1-23");

            int mm = 0;
            try
            {
                mm = Convert.ToInt32(times[1]);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Minute Value");
            }
            if (mm < 0 || mm > 60)
                throw new Exception("Minute value must be 1-60");


            int ss = 0;
            try
            {
                ss = Convert.ToInt32(times[2]);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Second Value");
            }
            if (ss < 0 || ss > 60)
                throw new Exception("Second value must be 1-60");


            try
            {
                dt = new DateTime(Date.Year, Date.Month, Date.Day, hh, mm, ss);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid DateTime");
            }
            return dt;
        }
        /// <summary>
        /// 01/01/1900
        /// </summary>
        public static DateTime NullDate = new DateTime(1900, 1, 1);
        public static Guid NullGuid = new Guid();
        public static double IsNull(object obj, double nullValue)
        {
            try
            {
                return (obj == null || obj == DBNull.Value) ? nullValue : Convert.ToDouble(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static decimal IsNull(object obj, decimal nullValue)
        {
            try
            {
                return (obj == null || obj == DBNull.Value) ? nullValue : Convert.ToDecimal(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int IsNull(object obj, int nullValue)
        {
            try
            {
                return (obj == null || obj == DBNull.Value) ? nullValue : Convert.ToInt32(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static long IsNull(object obj, long nullValue)
        {
            try
            {
                return (obj == null || obj == DBNull.Value) ? nullValue : Convert.ToInt64(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string IsNull(object obj, string nullValue)
        {
            try
            {
                return (obj == null || obj == DBNull.Value) ? nullValue : Convert.ToString(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool IsNull(object obj, bool nullValue)
        {
            try
            {
                return (obj == null || obj == DBNull.Value) ? nullValue : Convert.ToBoolean(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DateTime IsNull(object obj, DateTime nullValue)
        {
            try
            {
                return (obj == null || obj == DBNull.Value) ? nullValue : Convert.ToDateTime(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Guid IsNull(object obj, Guid nullValue)
        {
            try
            {
                return (obj == null || obj == DBNull.Value) ? nullValue : new Guid(Convert.ToString(obj));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static T IsNull<T>(object obj, T nullValue)
        {
            try
            {
                return (obj == null || obj == DBNull.Value) ? nullValue : (T)Convert.ChangeType(obj, typeof(T));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DateTime ToDate(long d)
        {
            DateTime dt;
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(string.Format("SELECT CAST({0} AS DATETIME) AS DT", d), @"Data Source=HARUN-PC\SQL2K8;Initial Catalog=SCMS;User ID=sa;Password=sa1234"))
                {
                    DataTable dtData = new DataTable();
                    da.Fill(dtData);
                    da.Dispose();

                    if (dtData.Rows.Count > 0)
                        dt = IsNull<DateTime>(dtData.Rows[0]["DT"], NullDate);
                    else
                        dt = NullDate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
        public static DateTime ToDate(double d)
        {
            DateTime dt;
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(string.Format("SELECT CAST({0} AS DATETIME) AS DT", d), @"Data Source=HARUN-PC\SQL2K8;Initial Catalog=SCMS;User ID=sa;Password=sa1234"))
                {
                    DataTable dtData = new DataTable();
                    da.Fill(dtData);
                    da.Dispose();

                    if (dtData.Rows.Count > 0)
                        dt = IsNull<DateTime>(dtData.Rows[0]["DT"], NullDate);
                    else
                        dt = NullDate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void SetSystemTime(ref SYSTEMTIME st);

        public static void SetSystemDateTime(DateTime ServerDateTime)
        {
            try
            {
                //ServerDateTime = ServerDateTime.AddHours(-5).AddMinutes(-30);
                SystemTime st = new SystemTime();
                st.Year = (ushort)ServerDateTime.Year; // must be short
                st.Month = (ushort)ServerDateTime.Month;
                st.Day = (ushort)ServerDateTime.Day;
                st.Hour = (ushort)ServerDateTime.Hour;
                st.Minute = (ushort)ServerDateTime.Minute;
                st.Second = (ushort)ServerDateTime.Second;
                st.Millisecond = (ushort)ServerDateTime.Millisecond;
                //SetSystemTime(ref st);
                Win32SetSystemTime(ref st);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public struct SystemTime
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Millisecond;
        };

        [DllImport("kernel32.dll", EntryPoint = "GetSystemTime", SetLastError = true)]
        public extern static void Win32GetSystemTime(ref SystemTime sysTime);

        [DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
        public extern static bool Win32SetSystemTime(ref SystemTime sysTime);
        public static void setDate(string dateInYourSystemFormat)
        {
            var proc = new System.Diagnostics.ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = @"C:\Windows\System32";
            proc.CreateNoWindow = true;
            proc.FileName = @"C:\Windows\System32\cmd.exe";
            proc.Verb = "runas";
            proc.Arguments = "/C date " + dateInYourSystemFormat;
            proc.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            try
            {
                System.Diagnostics.Process.Start(proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setTime(string timeInYourSystemFormat)
        {
            var proc = new System.Diagnostics.ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = @"C:\Windows\System32";
            proc.CreateNoWindow = true;
            proc.FileName = @"C:\Windows\System32\cmd.exe";
            proc.Verb = "runas";
            proc.Arguments = "/C time " + timeInYourSystemFormat;
            try
            {
                System.Diagnostics.Process.Start(proc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
