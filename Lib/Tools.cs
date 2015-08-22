using Jayrock.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;

namespace Lib
{
    public class Json {
        static public string getArrayItem(JsonObject ob, string arrayname, int arrayind){
            if (ob == null || !ob.Contains(arrayname)) return "";
            if (!(ob[arrayname] is JsonArray)) return "";
            JsonArray arr = (JsonArray)ob[arrayname];
            if (arr.Length < arrayind) return "";
            return Converter.toString(arr[arrayind]);
        }
    }
    
    public class Converter
    {
        static public string toString(Object ob) {
            if (ob == null) return "";
            if (ob is DateTime) {
                DateTime dt = (DateTime)ob;
                return dt.ToString(Const.DATE_TIME_FORMAT);
            }
            return String.Format(CultureInfo.InvariantCulture, "{0}", ob);
        }
        static public bool toBool(Object ob) {
            return toBool(ob, false);
        }
        static public bool toBool(Object ob, bool defValue) {
            if (ob == null) return defValue;
            string strval = ob.ToString();
            bool retvalue = defValue;
            string[] trueValues = new string[] { "1", "true"};
            string[] falseeValues = new string[] { "0", "false" };
            for (int i = 0; i < trueValues.Length; i++) {
                if (strval.Equals(trueValues[i], StringComparison.InvariantCultureIgnoreCase)) return true;
                if (strval.Equals(falseeValues[i], StringComparison.InvariantCultureIgnoreCase)) return false;
            }
            if (bool.TryParse(strval, out retvalue)) return retvalue;
            return defValue;
        }
        static public double toDouble(Object ob){
            return toDouble(ob, 0);
        }
        static public double toDouble(Object ob, double defValue) {
            if (ob == null) return defValue;
            string strval = ob.ToString();
            double retvalue = defValue;
            if (double.TryParse(strval, System.Globalization.NumberStyles.Any, Const.INV_CULTURE, out retvalue)) return retvalue;
            return defValue;
        }

        static public int toInt(Object ob) {
            return toInt(ob, 0);
        }
        static public int toInt(Object ob, int defValue) {
            return (int)toLong(ob, defValue);
        }
        static public long toLong(Object ob) {
            return toLong(ob, 0);
        }
        static public long toLong(Object ob, long defValue) {
            if (ob == null) return defValue;
            string strval = ob.ToString();
            long retvalue = defValue;
            if (long.TryParse(strval, System.Globalization.NumberStyles.Any, Const.INV_CULTURE, out retvalue)) return retvalue;
            double dbvl = 0;
            if (double.TryParse(strval, System.Globalization.NumberStyles.Any, Const.INV_CULTURE, out dbvl)) return (long)dbvl;
            return defValue;
        }
        static public decimal toDecimal(Object ob) {
            return toDecimal(ob, 0);
        }
        static public decimal toDecimal(Object ob, decimal defValue) {
            if (ob == null) return defValue;
            string strval = ob.ToString();
            decimal retvalue = defValue;
            if (decimal.TryParse(strval, System.Globalization.NumberStyles.Any, Const.INV_CULTURE, out retvalue)) return retvalue;
            return defValue;
        }
        static public DateTime toDateTime(Object ob) {
            return toDateTime(ob, DateTime.MinValue);
        }
        static public DateTime toDateTime(Object ob, DateTime defValue) {
            return toDateTime(ob, DateTime.MinValue, Const.DATE_TIME_FORMAT);
        }
        static public DateTime toDateTime(Object ob, DateTime defValue, String format){
            if (ob == null) return defValue;
            string strval = toString(ob);
            DateTime retvalue = defValue;
            if (format.ToLower().Equals("1970")) return Const.ORIGN_DATE.AddMilliseconds(Lib.Converter.toDouble(strval) * 1000);
            if (DateTime.TryParseExact(strval, format, Const.INV_CULTURE, DateTimeStyles.None, out retvalue)) return retvalue;
            if (DateTime.TryParse(strval, Const.INV_CULTURE, DateTimeStyles.None, out retvalue)) return retvalue;
            return defValue;
        }
    }
    public class Tools {
        static public bool checkDoubleEqual(double pa1, double pa2) {
            if (pa1 - Const.ZERO < pa2 && pa1 + Const.ZERO > pa2) return true;
            return false;
        }
        static public string seperateCSV(char sep, params Object[] pars) {
            string ret = "";
            foreach (Object item in pars) {
                ret += Converter.toString(item) + sep;
            }
            return ret;
        }
        static public void makeFolders(string filename) {
            string folder = Path.GetDirectoryName(filename);
            if (!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }
        }
        static public string formatSpace(long space) {
            string[] suffix = new string[] { "b", "kb", "mb", "gb", "tb", "pb" };
            int logsize = 0;
            while (space > 1024) {
                logsize++;
                space /= 1024;
            }
            return string.Format("{0}{1}", space, suffix[logsize]);
        }
        static public string formatTimeSpan(TimeSpan ts) {
            string ret = "";
            if (ts.Days > 0) ret += ts.Days + "d ";
            if (ts.Hours > 0) ret += ts.Hours + "h ";
            if (ts.Minutes > 0) ret += ts.Minutes + "m ";
            if (ts.Seconds > 0) ret += ts.Seconds + "s ";
            if (ts.Milliseconds > 0) ret += ts.Milliseconds + "ms ";
            return ret;
        }
    }
    public class Performance {
        static private Dictionary<string, MyWatch> watches = new Dictionary<string, MyWatch>();

        static public void resetWatches() {
            watches.Clear();
        }

        static public void setWatch(string key, bool on) {
            if(key != "total") setWatch("total", on);
            if(!watches.ContainsKey(key)) watches.Add(key, new MyWatch( ));
            if(on){
                watches[key].Start();
            }else{
                watches[key].Stop();
            }
        }

        static public DataTable getTable() {
            DataTable dt = new DataTable();
            dt.Columns.Add("key");
            dt.Columns.Add("total");
            dt.Columns.Add("avarage");
            dt.Columns.Add("avarage_ticks");
            dt.Columns.Add("count");

            foreach (KeyValuePair<string, MyWatch> entry in watches) {
                DataRow dr = dt.NewRow();
                dr["key"] = entry.Key;
                dr["total"] = Lib.Tools.formatTimeSpan(entry.Value.Total);
                dr["avarage"] = Lib.Tools.formatTimeSpan(entry.Value.Avarage);
                dr["avarage_ticks"] = entry.Value.Avarage.Ticks;
                dr["count"] = entry.Value.Count;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private class MyWatch : Stopwatch {
            private int count = 0;
            public void Start() {
                base.Start();
            }
            public void Stop() {
                if (base.IsRunning) count++;
                base.Stop();
            }
            public TimeSpan Avarage {
                get { return  new TimeSpan(base.ElapsedTicks / count); }
            }
            public TimeSpan Total {
                get { return new TimeSpan(base.ElapsedTicks); }
            }
            public int Count {
                get { return count; }
            }
        }
    }
}
