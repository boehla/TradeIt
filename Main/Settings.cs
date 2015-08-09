using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Windows.Forms;

namespace Main {
    public class Settings {
        static private Dictionary<string, object> data = new Dictionary<string, object>();
        static private string filename = @"data\\settings.data";
        static private bool _hasChange = false;

        static public bool HasChange {
            get { return _hasChange; }
        }

        static public int getInt(object key) {
            return Lib.Converter.toInt(get(key));
        }
        static public long getLong(object key) {
            return Lib.Converter.toLong(get(key));
        }
        static public bool getBool(object key) {
            return Lib.Converter.toBool(get(key));
        }
        static public double getDouble(object key) {
            return Lib.Converter.toDouble(get(key));
        }
        static public string getString(object key) {
            return Lib.Converter.toString(get(key));
        }
        static public object get(object key) {
            string strkey = Lib.Converter.toString(key);
            if (!data.ContainsKey(strkey)) return getDefault(strkey);
            return data[strkey];
        }
        static public void set(object key, object value) {
            string strkey = Lib.Converter.toString(key);
            if (!data.ContainsKey(strkey)) {
                data.Add(strkey, value);
                _hasChange = true;
            } else {
                if (!data[strkey].Equals(value)) _hasChange = true;
                data[strkey] = value;
            }
        }
        static public void save() {
            FileStream writerFileStream =
                new FileStream(filename, FileMode.Create, FileAccess.Write);
            // Save our dictionary of friends to file
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(writerFileStream, data);

            // Close the writerFileStream when we are done.
            writerFileStream.Close();
            _hasChange = false;
        }
        static public void load() {
            try {
                if (!File.Exists(filename)) return;
                FileStream readerFileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                // Reconstruct information of our friends from file.
                BinaryFormatter formatter = new BinaryFormatter();
                data = (Dictionary<string, object>)
                    formatter.Deserialize(readerFileStream);
                // Close the readerFileStream when we are done
                readerFileStream.Close();
            } catch (Exception ex) {
                Logging.logException("Cannot load Settings", ex);
            }
        }

        static private object getDefault(string key) {
            switch (key) {
                case "MAX_CHART_POINTS": return 3000;
                case "DATA_FILE": return @"data\\backup.data";
                case "TRADER_DLL_FILE": return @"";
            }
            Logging.log("No Option found for key " + key, LogPrior.Warning);
            return null;
        }

        static public DataTable getDataTable() {
            DataTable dt = new DataTable();

            dt.Columns.Add("key");
            dt.Columns.Add("value");

            foreach (KeyValuePair<string, Object> entry in data) {
                DataRow dr = dt.NewRow();
                dr["key"] = entry.Key;
                dr["value"] = entry.Value;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        static public void fromTable(DataGridView table) {
            if (table == null) return;
            if (table.Rows == null || table.Rows.Count <= 0) return;
            if (!table.Columns.Contains("key") || !table.Columns.Contains("value")) return;

            data.Clear();
            foreach (DataGridViewRow row in table.Rows) {
                set(Lib.Converter.toString(row.Cells["key"].Value), Lib.Converter.toString(row.Cells["value"].Value));
            }
        }
    }
}
