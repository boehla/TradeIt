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

        private static LogPrior _forceLogPrior = LogPrior.Debug;

        public static void log(string text, LogPrior lp) {
            log(text, lp, DateTime.MinValue);
        }
        public static void log(string text, LogPrior lp, DateTime dt) {
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
            string filename = "log_" + lp.ToString() + ".txt";
            writeToLogFile(text, filename);
            string prefix = lp.ToString();
            if (prefix.Length > 0) prefix = prefix.Substring(0, 2);
            writeToLogFile(prefix + " " + text, "log_All.txt");
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
        }
        public static void releaseForceLogPrior() {
            _forceLogPrior = LogPrior.Debug;
        }
    }
}
