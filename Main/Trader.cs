using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Main;
using Main.Api;

namespace Main {
    public class Trader {
        private ApiHelp _api = null;
        private CandleInterval _ci = CandleInterval._4h;
        private Indikators _data = null;
        private CandleManager _cm = null;
        private int tickcount = 0;
        private bool live = false;
        private ApiPortfolio _startPortfolio = null;
        private int maxChartPoints = 300;

        public DateTime CurDate {
            get {
                DateTime dt = Data.Candle().dt;
                if (live) {
                    dt = DateTime.Now;
                }
                return dt;
            }
        }
        public int MaxChartPoints {
            get { return maxChartPoints; }
            set { maxChartPoints = value; }
        }
        public virtual string Version {
            get { return "ND"; }
        }
        public virtual string Name {
            get { return "ND"; }
        }
        public virtual bool Active {
            get  {return false; }
        }
        public Indikators Data {
            get { return _data; }
        }
        public CandleInterval UpdateIntervall {
            get { return _ci; }
            set { _ci = value; }
        }
        public int TickCount {
            get { return tickcount; }
        }
        public ApiPortfolio StartPortfolio {
            get { return _startPortfolio; }
        }
        public ApiPortfolio Portfolio {
            get { return _api.Portfolio; }
        }
        public bool Live {
            get { return live; }
            set { live = value; }
        }

        public Trader() {

        }
        public void init(ApiHelp kh, CandleInterval ci, CandleManager cm) {
            this._api = kh;
            this._ci = ci;
            this._data = new Indikators(cm, ci);
            this._cm = cm;
        }

        public virtual void Initiale() {
            tickcount = 0;
            _startPortfolio = _api.Portfolio.clone();
        }
        public virtual void Update() {
            tickcount++;
        }
        public virtual void Stop() {

        }

        public void sellBtc(decimal vol) {
            this.writeLog(string.Format("SELL {2} btc: {0}@{1}", vol, Data.Candle().value.Last, live? "live" : "simualte" ));
            plotPoint("sell", CurDate, Data.Candle().value.Last, Color.Red);
            if (live) {
                _api.sell(vol);
            }
        }
        public void buyBtc(decimal vol) {
            this.writeLog(string.Format("BUY {2} btc: {0}@{1}", vol, Data.Candle().value.Last, live ? "live" : "simualte"));
            plotPoint("buy", CurDate, Data.Candle().value.Last, Color.Green);
            if (live) {
                _api.buy(vol);
            }
        }
        public void log(string text) {
            this.writeLog("TRADING: " + text);
        }
        private void writeLog(string text){
            DateTime dt = DateTime.Now;
            if (_cm.CandleList[(int)_ci].getCandelCount() > 0) dt = Data.Candle().dt;
            Logging.log(text, LogPrior.Trader, dt);
        }
        public void plot(string name, double value, bool secondaryAxis = false, int area = 0) {
            if (MainForm.chartcont == null) return;
            if (secondaryAxis) name += " (sec)";
            while (MainForm.chartcont.ChartAreas.Count <= area) {
                ChartArea ca = new ChartArea(area.ToString());
                ca.AlignWithChartArea = "0";
                ca.AlignmentStyle = MainForm.chartcont.ChartAreas[0].AlignmentStyle;
                MainForm.chartcont.ChartAreas.Add(ca);
            }
            Series ser = null;
            foreach (Series item in MainForm.chartcont.Series) {
                if (name.Equals(item.Name)) {
                    ser = item;
                    break;
                }
            }
            if (ser == null) {
                ser = new Series(name);
                ser.ChartType = SeriesChartType.Line;
                ser.XValueType = ChartValueType.DateTime;
                ser.BorderWidth = 5;
                if (area > 0) ser.ChartArea = area.ToString();
                MainForm.chartcont.Series.Add(ser);
            }
            if(secondaryAxis) ser.YAxisType = AxisType.Secondary;
            ser.Points.AddXY(_data.Candle().dt, value);

            checkSerMaxPoints();
            //if (value > chartmaxy) chartmaxy = value;
            //if (value < chartminy) chartminy = value;
            //MainForm.chartcont.ChartAreas[0].AxisY.Minimum = chartminy;
            //MainForm.chartcont.ChartAreas[0].AxisY.Maximum = chartmaxy;
        }
        private void plotPoint(string name, DateTime dt, double value, Color col) {
            Series ser = null;
            foreach (Series item in MainForm.chartcont.Series) {
                if (name.Equals(item.Name)) {
                    ser = item;
                    break;
                }
            }
            if (ser == null) {
                ser = new Series(name);
                ser.ChartType = SeriesChartType.Point;
                ser.XValueType = ChartValueType.DateTime;
                ser.MarkerSize = 20;
                ser.MarkerStyle = MarkerStyle.Circle;
                ser.Color = col;
                MainForm.chartcont.Series.Add(ser);
            }
            ser.Points.AddXY(dt, value);
            checkSerMaxPoints();
        }
        private void checkSerMaxPoints() {
            foreach (Series ser in MainForm.chartcont.Series) {
                DateTime maxDate = Data.Candle().dt - new TimeSpan(0, 0, maxChartPoints * (int)_ci);
                while (ser.Points.Count > 0) {
                    if (ser.Points[0].XValue < maxDate.ToOADate()) {
                        ser.Points.RemoveAt(0);
                    } else { break; }
                }
            }

        }
    }
    public class Indikators {
        private CandleInterval _defaultci;
        private CandleManager _cm;

        public Indikators(CandleManager cm, CandleInterval defaultci) {
            this._cm = cm;
            this._defaultci = defaultci;
        }

        public bool checkIfDataFalid(int count, int intervall = -1) {
            if (intervall == -1) intervall = (int)_defaultci;
            checkIntervall(intervall);
            if (_cm.CandleList[intervall] == null || _cm.CandleList[intervall].getCandelCount() < count) return false;
            return true;
        }

        public Candle Candle(int c = 0, int intervall = -1) {
            if (intervall == -1) intervall = (int)_defaultci;
            checkIntervall(intervall);
            if (_cm.CandleList[intervall] == null || _cm.CandleList[intervall].getCandelCount() <= c) throw new Exception("Too less Candle datas!");
            return _cm.CandleList[intervall].Candles[c];
        }
        /// <summary>
        /// MA (Simple Moving Average)
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public double ma(int period, int intervall = -1) {
            if (intervall == -1) intervall = (int)_defaultci;
            checkIntervall(intervall);
            if (_cm.CandleList[intervall] == null || _cm.CandleList[intervall].getCandelCount() < period) {
                throw new Exception(string.Format("Too less Candle datas! {0} from {1}", _cm.CandleList[intervall].getCandelCount(), period));
            }

            double sum = 0;
            int count = 0;
            for (int i = 0; i < period; i++) {
                if (_cm.CandleList[intervall].Candles[i].value.Last <= 0) continue;
                sum += _cm.CandleList[intervall].Candles[i].value.Last;
                count++;
            }
            return sum / count;
        }
        private double calcEma(double today, int numDays, double emaYesterday) {
            double k = 2.0 / (numDays + 1);
            return today * k + emaYesterday * (1 - k);
        }
        public double ema(int period, int intervall = -1) {
            if (intervall == -1) intervall = (int)_defaultci;
            checkIntervall(intervall);
                        if (_cm.CandleList[intervall] == null || _cm.CandleList[intervall].getCandelCount() < period) {
                throw new Exception(string.Format("Too less Candle datas! {0} from {1}", _cm.CandleList[intervall].getCandelCount(), period));
            }

            double emayesterday = _cm.CandleList[intervall].Candles[period - 1].value.Last;
            double ema = 0;
            for (int i = period - 2; i >= 0; i--) {
                double tdprice = _cm.CandleList[intervall].Candles[i].value.Last;
                if (tdprice <= 0) continue;
                ema = calcEma(tdprice, period, emayesterday);
                emayesterday = ema;
            }
            return ema;
        }
        public double macd(int shortper, int longper, int intervall = -1) {
            if (intervall == -1) intervall = (int)_defaultci;
            checkIntervall(intervall);
            if (_cm.CandleList[intervall] == null || _cm.CandleList[intervall].getCandelCount() < longper) throw new Exception("Too less Candle datas!");

            return ema(shortper, intervall) - ema(longper, intervall);
        }
        public Candle getLastTicke(int intervall = -1) {
            if (intervall == -1) intervall = (int)_defaultci;
            checkIntervall(intervall);
            return _cm.CandleList[intervall].LastTick;
        }

        private void checkIntervall(int intervall){
            if (intervall < 0) throw new Exception("intervall cannot be lower then 0");
            if (!_cm.CandleList.ContainsKey(intervall)) throw new Exception("Intervall not found in CandleList!");
            
        }
    }
}
