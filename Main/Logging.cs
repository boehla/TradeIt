using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Main {

    class Logging {
        private static int _maxFileSize_kb = 1000;
        private static string _folder = "logs\\";
        private static bool _withDate = true;
        private static Dictionary<LogPrior, StringBuilder> logBuffer = new Dictionary<LogPrior, StringBuilder>();
        private static DateTime logBufferAge = new DateTime(0);
        //private static TimeSpan 

        private static LogPrior _forceLogPrior = LogPrior.Debug;

        public static void log(string text, LogPrior lp) {
            log(text, lp, DateTime.MinValue);
        }
        public static void log(string text, LogPrior lp, DateTime dt) {
            Lib.Performance.setWatch("log", true);
            if ((int)_forceLogPrior > (int)lp) return;
            if (dt < Lib.Const.NULL_DATE) dt = DateTime.Now;
            if (_withDate) text = dt.ToString("dd.MM.yyyy HH:mm:ss") + " " + text;
            if (!text.EndsWith("\r\n")) text += "\r\n";
            if (MainForm.df != null) {
                switch (lp) {
                    case LogPrior.Debug:
                        MainForm.df.logDebug(text);
                        break;
                    case LogPrior.Info:
                        MainForm.df.logInfo(text);
                        break;
                    case LogPrior.Warning:
                        MainForm.df.logWarning(text);
                        break;
                    case LogPrior.Error:
                        MainForm.df.logError(text);
                        break;
                    case LogPrior.Importand:
                        MainForm.df.logImportand(text);
                        break;
                    case LogPrior.Trader:
                        MainForm.df.logTrader(text);
                        break;
                }
            }
            
            


            //writeToLogFile(text, filename);
            //writeToLogFile(prefix + " " + text, "log_All.txt");
            addToBuffer(lp, text);
            Lib.Performance.setWatch("log", false);
        }
        private static void addToBuffer(LogPrior lp, string text) {
            Lib.Performance.setWatch("addlogbuffer", true);
            if(!logBuffer.ContainsKey(LogPrior.All)) logBuffer.Add(LogPrior.All, new StringBuilder());
            if (!logBuffer.ContainsKey(lp)) logBuffer.Add(lp, new StringBuilder());

            string prefix = lp.ToString();
            if (prefix.Length > 0) prefix = prefix.Substring(0, 2);

            logBuffer[lp].Append(text);
            logBuffer[LogPrior.All].Append(prefix + " " + text);

            if (logBufferAge.AddSeconds(5) < DateTime.Now) {
                emptyBuffer();
            }
            Lib.Performance.setWatch("addlogbuffer", false);
        }
        private static void emptyBuffer() {
            Lib.Performance.setWatch("emptyBuffer", true);
            foreach (KeyValuePair<LogPrior, StringBuilder> entry in logBuffer) {
                string filename = "log_" + entry.Key.ToString() + ".txt";
                writeToLogFile(entry.Value.ToString(), filename);
                entry.Value.Clear();
            }
            logBuffer.Clear();
            logBufferAge = DateTime.Now;
            Lib.Performance.setWatch("emptyBuffer", false);
        }

        public static void logException(string text, Exception ex) {
            text += "\r\n" + ex.Message + "\r\n" + ex.StackTrace;
            log(text, LogPrior.Error);
        }

        private static void writeToLogFile(string text, string filename) {
            if (!Directory.Exists(_folder)) {
                Directory.CreateDirectory(_folder);
            }
            string logfile = _folder + filename;
            if (File.Exists(logfile)) {
                FileInfo finfo = new FileInfo(logfile);
                if (finfo.Length > _maxFileSize_kb * 1024) {
                    string oldLog = logfile + ".old";
                    if (File.Exists(oldLog)) File.Delete(oldLog);
                    File.Move(logfile, oldLog);
                }
            }
            StreamWriter fout = new StreamWriter(logfile, true);
            fout.Write(text);
            fout.Close();
        }
        public static void setForceLogPrior(LogPrior lp) {
            _forceLogPrior = lp;
            MainForm.df.stopUpdate();
        }
        public static void releaseForceLogPrior() {
            _forceLogPrior = LogPrior.Debug;
            MainForm.df.stopUpdate();
        }
    }
}
