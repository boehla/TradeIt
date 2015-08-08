using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Api;

namespace Main {
    public delegate void NewCandleEventHandler(object source, NewCandleArgs e);

    class Myrrrd {
    }
    public class CandleManager {
        private Dictionary<int, CandleList> candllist = new Dictionary<int, CandleList>();

        public CandleManager() {


        }



        public Dictionary<int, CandleList> CandleList {
            get { return candllist; }
        }

        public void generateNew() {
            DateTime dt = DateTime.Today;
            candllist = new Dictionary<int, CandleList>();
            foreach (CandleInterval item in Enum.GetValues(typeof(CandleInterval))) {
                TimeSpan ts = new TimeSpan(0, 0, (int)item);
                candllist.Add((int)item, new CandleList(ts, dt));
            }
        }
        public void addToAllNewTicker(ApiTicker tick, DateTime dt) {
            if (dt < Lib.Const.NULL_DATE) {
                Logging.log("Skip addToAllNewTicker because Date < NULL_DATE", LogPrior.Warning);
                return;
            } else if (!tick.CorrectData) {
                Logging.log("Skip tick because correctData is not set true! " + tick.ToString(), LogPrior.Warning);
                return;
            }
            Logging.log("AddTickToAll: bid=" + tick.Bid + " ask=" + tick.Ask, LogPrior.Debug);
            foreach (KeyValuePair<int, CandleList> entry in candllist) {
                entry.Value.AddTick(tick, dt);
            }
        }

        public void saveToFile(string filename) {
            string folder = Path.GetDirectoryName(filename);
            if (!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }
            StreamWriter fout = new StreamWriter(filename, false);

            /*
            foreach (KeyValuePair<int, CandleList> entry in candllist) {
                CandleList cl = entry.Value;
                //fout.WriteLine(Lib.Tools.seperateCSV(Lib.Const.CSV_DEL, Lib.Const.IDS.CANDLE_LIST, entry.Key, cl.Intervall.Ticks, cl.RefDate.Ticks));
                for (int i = cl.Candles.Count - 1; i >= 0; i--) {
                    Candle citem = cl.Candles[i];
                    ApiTicker ti = citem.value;
                    fout.WriteLine(citem.getCSVLine(entry.Key));
                }
            }*/
            int[] indexes = new int[candllist.Count];
            int c = 0;
            foreach (KeyValuePair<int, CandleList> entry in candllist) {
                indexes[c] = entry.Value.Candles.Count - 1;
                c++;
            }
            while (true) {
                DateTime mindate = DateTime.MaxValue;
                List<int> exportCandleList = new List<int>();
                c = -1;
                foreach (KeyValuePair<int, CandleList> entry in candllist) {
                    c++;
                    if (indexes[c] < 0) continue;
                    if (mindate > entry.Value.Candles[indexes[c]].dt) {
                        exportCandleList.Clear();
                        exportCandleList.Add(c);
                        mindate = entry.Value.Candles[indexes[c]].dt;
                    } else if (mindate == entry.Value.Candles[indexes[c]].dt) {
                        exportCandleList.Add(c);
                    }
                }
                c = 0;
                foreach (KeyValuePair<int, CandleList> entry in candllist) {
                    if (exportCandleList.Contains(c)) {
                        fout.WriteLine(entry.Value.Candles[indexes[c]].getCSVLine(entry.Key));
                        indexes[c]--;
                    }
                    c++;
                }


                if (mindate == DateTime.MaxValue) break;
            }
            Logging.log("Candledata Exported to" + filename, LogPrior.Debug);
            fout.Close();
        }
        public bool loadFromFile(string filename, bool merge) {
            if (!File.Exists(filename)) {
                Logging.log("loadFromFile, File not exist:" + filename, LogPrior.Warning);
                return false;
            }
            Logging.log("Start importing candledata from: " + filename, LogPrior.Info);
            int countcandles = 0;
            if (!merge || candllist.Count <= 0) {
                this.generateNew();
            }
            StreamReader fin = new StreamReader(filename);
            Logging.setForceLogPrior(LogPrior.Warning);
            while (!fin.EndOfStream) {
                string line = fin.ReadLine();
                string[] csvs = line.Split(Lib.Const.CSV_DEL);
                if (csvs.Length <= 3) continue;
                int key = Lib.Converter.toInt(csvs[1]);
                switch (csvs[0]) {
                    case Lib.Const.IDS.CANDLE_LIST:
                        if (candllist.ContainsKey(key)) continue;
                        TimeSpan ts = new TimeSpan(Lib.Converter.toLong(csvs[2]));
                        DateTime dt = new DateTime(Lib.Converter.toLong(csvs[3]));
                        candllist.Add(key, new CandleList(ts, dt));
                        break;
                    case Lib.Const.IDS.CANDLE_ITEM:
                        dt = Lib.Converter.toDateTime(csvs[2]);
                        if (dt < Lib.Const.NULL_DATE) continue;
                        if (!candllist.ContainsKey(key)) {
                            ts = new TimeSpan(0, 0, key);
                            candllist.Add(key, new CandleList(ts, dt));
                        }
                        ApiTicker tick = new ApiTicker();
                        tick.Ask = Lib.Converter.toDouble(csvs[3]);
                        tick.Bid = Lib.Converter.toDouble(csvs[4]);
                        tick.Last = Lib.Converter.toDouble(csvs[5]);
                        tick.Volume = Lib.Converter.toDouble(csvs[6]);
                        tick.VolumeWeight = Lib.Converter.toDouble(csvs[7]);
                        tick.NumberOfTrades = Lib.Converter.toInt(csvs[8]);
                        tick.Low = Lib.Converter.toDouble(csvs[9]);
                        tick.High = Lib.Converter.toDouble(csvs[10]);
                        tick.CountMerged = Lib.Converter.toInt(csvs[11]);
                        candllist[key].AddTick(tick, dt);
                        countcandles++;
                        break;
                }
            }
            Logging.releaseForceLogPrior();
            fin.Close();
            Logging.log(String.Format("Import Candledata finished ({0} candleListes and {1} candles)", candllist.Count, countcandles), LogPrior.Info);
            return true;
        }
        public bool loadFromBitcoinAvarage(string filename, bool merge) {
            if (!File.Exists(filename)) return false;
            Logging.log("Start importing BitcoinAvarage candledata from: " + filename, LogPrior.Debug);
            int countcandles = 0;
            StreamReader fin = new StreamReader(filename);
            if (!merge || candllist.Count <= 0) {
                this.generateNew();
            }
            Logging.setForceLogPrior(LogPrior.Warning);
            while (!fin.EndOfStream) {
                countcandles++;
                string line = fin.ReadLine();
                if (countcandles <= 1) continue;
                string[] csvs = line.Split(',');
                DateTime dt = Lib.Converter.toDateTime(csvs[0], DateTime.MinValue, "yyyy-MM-dd HH:mm:ss");
                ApiTicker tick = new ApiTicker();
                if (csvs.Length == 4) {
                    tick.High = Lib.Converter.toDouble(csvs[1]);
                    tick.Low = Lib.Converter.toDouble(csvs[2]);
                    tick.Last = Lib.Converter.toDouble(csvs[3]);
                } else if (csvs.Length == 2) {
                    tick.Last = Lib.Converter.toDouble(csvs[1]);
                }
                this.addToAllNewTicker(tick, dt);
            }
            Logging.releaseForceLogPrior();
            fin.Close();
            Logging.log(String.Format("Import BitcoinAvarage Candledata finished ({0} candleListes and {1} candles)", candllist.Count, countcandles), LogPrior.Info);
            return true;
        }
        public void archiveTick(ApiTicker tick) {
            string filename = string.Format("archiv\\ticks_{0:yyyyMM}.csv", DateTime.Now);
            string folder = Path.GetDirectoryName(filename);
            if (!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }
            StreamWriter fout = new StreamWriter(filename, true);

            Candle c = new Candle(DateTime.Now, tick);
            fout.WriteLine(c.getCSVLine(1));

            fout.Close();
        }
    }
    public class CandleList {
        private List<Candle> _candls = new List<Candle>();
        private TimeSpan _intervall = TimeSpan.MinValue;
        private DateTime _refDate = DateTime.MinValue;
        private Candle _lastCandle = null;
        private Candle _lastTick = null;

        public event NewCandleEventHandler OnNewCandle;
        public Candle LastTick {
            get { return _lastTick; }
        }


        public int MaxCandels { get; set; }
        public TimeSpan Intervall {
            get { return _intervall; }
        }
        public DateTime RefDate {
            get { return _refDate; }
        }
        public List<Candle> Candles {
            get { return _candls; }
        }
        public int Key {
            get { return (int)_intervall.TotalSeconds; }
        }

        public CandleList(TimeSpan intervall, DateTime refDate) {
            _intervall = intervall;
            _refDate = refDate;
            MaxCandels = 5000;
        }
        public void AddTick(ApiTicker tick, DateTime dt) {
            if (dt < Lib.Const.NULL_DATE) {
                Logging.log("Skip addToAllNewTicker because dt < NULL_DATE", LogPrior.Warning);
                return;
            }
            DateTime normDate = getIntDate(dt);
            _lastTick = new Candle(dt, tick.clone());
            for (int i = 0; i < _candls.Count; i++) {
                if (_candls[i].dt < normDate) {
                    onNewCandle(_lastCandle);
                    _lastCandle = new Candle(normDate, tick.clone());
                    _candls.Insert(i, _lastCandle);
                    checkCandleCount();
                    return;
                }
                if (_candls[i].dt.Equals(normDate)) {
                    _candls[i].value.mergeNewTick(tick);
                    return;
                }
            }
            if (MaxCandels - 1 > _candls.Count) {
                _lastCandle = new Candle(normDate, tick.clone());
                _candls.Add(_lastCandle);
            }
        }
        private void checkCandleCount() {
            while (_candls.Count > MaxCandels) {
                int ind = _candls.Count - 1;
                Logging.log(String.Format("Delete data! Candledate={0}", Lib.Converter.toString(_candls[ind].dt)), LogPrior.Warning);
                try {
                    string filename = string.Format("archiv\\chandles_{0:MM_yyyy}.txt", DateTime.Now);
                    string folder = Path.GetDirectoryName(filename);
                    if (!Directory.Exists(folder)) {
                        Directory.CreateDirectory(folder);
                    }
                    StreamWriter fout = new StreamWriter(filename, true);
                    fout.WriteLine(_candls[ind].getCSVLine(this.Key));
                    fout.Close();
                } catch (Exception ex) {
                    Logging.logException("Couldn't Export Candle ): ", ex);
                }
                _candls.RemoveAt(ind);
            }
        }
        public DateTime getIntDate(DateTime dt) {
            DateTime ret = _refDate;
            if ((dt - _intervall) > ret) {
                while ((dt - _intervall) > ret) ret += _intervall;
            } else if ((dt) <= ret) {
                while ((dt) <= ret) ret -= _intervall;
            }
            _refDate = new DateTime(ret.Ticks);
            return ret;
        }
        public int getCandelCount() {
            return _candls.Count;
        }
        public Candle getCandle(DateTime dt) {
            DateTime normDate = getIntDate(dt);
            foreach (Candle item in _candls) {
                if (item.dt.Equals(normDate)) return item;
            }
            return null;
        }
        public Candle getCandle(int index) {
            if (_candls.Count > index) return _candls[index];
            return null;
        }
        private void onNewCandle(Candle candle) {

            if (this.OnNewCandle == null || candle == null) return;
            NewCandleArgs args = new NewCandleArgs(candle);
            OnNewCandle(this, args);
        }

    }
    public class Candle {
        public DateTime dt { get; set; }
        public ApiTicker value { get; set; }

        public Candle() {
            this.dt = DateTime.MinValue;
            this.value = null;
        }
        public Candle(DateTime dt, ApiTicker tick) {
            this.dt = new DateTime(dt.Ticks);
            this.value = tick.clone();
        }

        public string getCSVLine(int key) {
            return Lib.Tools.seperateCSV(Lib.Const.CSV_DEL, Lib.Const.IDS.CANDLE_ITEM, key, dt, value.Ask, value.Bid, value.Last, value.Volume, value.VolumeWeight, value.NumberOfTrades, value.Low, value.High, value.CountMerged);
        }
    }
    public class NewCandleArgs : EventArgs {
        private Candle _candle;

        public Candle Candle {
            get { return _candle; }
        }

        public NewCandleArgs(Candle candle) {
            _candle = candle;
        }
    }
}
