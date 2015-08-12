using Jayrock.Json;
using Jayrock.Json.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Api {
    public class ApiTicker {
        public double Ask { get; set; }
        public double Bid { get; set; }
        private double last = -1;
        public double Volume { get; set; }
        public double VolumeWeight { get; set; }
        public int NumberOfTrades { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
        public bool CorrectData { get; set; }

        public double Open { get; set; }
        public double Close { get; set; }

        private int _countMerged;
        public int CountMerged {
            get { return _countMerged; }
            set { _countMerged = value; }
        }
        public double Last {
            get { return last; }
            set {
                last = value;
                if (last < 0) return;
                if (Open < 0) Open = last;
                Close = last;
                if (last < Low || Low < 0) Low = last;
                if (last > High) High = last;
            }
        }

        public ApiTicker() {
            Ask = -1;
            Bid = -1;
            Last = -1;
            Volume = -1;
            VolumeWeight = -1;
            NumberOfTrades = -1;
            Low = -1;
            High = -1;
            _countMerged = 1;
            Open = -1;
            Close = -1;
            CorrectData = false;
        }

        public override string ToString() {
            return string.Format("Ask={0}, Bid={1}, Last={2}, Volume={3}, NumTrads={4}, Low={5}, High={6}, merged={7}", Ask, Bid, Last, Volume, NumberOfTrades, Low, High, _countMerged);
        }

        public void mergeNewTick(ApiTicker newapi) {
            this.Ask = mergeDoubleAvarage(this.Ask, newapi.Ask);
            this.Bid = mergeDoubleAvarage(this.Bid, newapi.Bid);
            this.Last = mergeDoubleAvarage(this.Last, newapi.Last);
            this.Volume = mergeDoubleAvarage(this.Volume, newapi.Volume);
            this.VolumeWeight = mergeDoubleAvarage(this.VolumeWeight, newapi.VolumeWeight);
            this.NumberOfTrades = (int)mergeDoubleAvarage(this.NumberOfTrades, newapi.NumberOfTrades);
            this.Low = mergeDoubleMin(this.Low, newapi.Low);
            this.High = mergeDoubleMax(this.High, newapi.High);

            if(newapi.Last > 0){
                if (this.Low > newapi.Last || this.Low < 0) this.Low = newapi.Last;
                if (this.High < newapi.Last) this.High = newapi.Last;
            }

            if (this.Open < 0) this.Open = newapi.Last;
            this.Close = newapi.Last;
            _countMerged++;
        }
        public ApiTicker clone() {
            ApiTicker ret = new ApiTicker();

            ret.Ask = this.Ask;
            ret.Bid = this.Bid;
            ret.last = this.last;
            ret.Volume = this.Volume;
            ret.VolumeWeight = this.VolumeWeight;
            ret.NumberOfTrades = this.NumberOfTrades;
            ret.Low = this.Low;
            ret.High = this.High;
            ret._countMerged = this._countMerged;
            ret.Open = this.Open;
            ret.Close = this.Close;

            return ret;
        }

        private double mergeDoubleAvarage(double thisv, double newv){
            if (thisv <= 0) return newv;
            if (newv <= 0) return thisv;

            return (((thisv * _countMerged) + newv) / (_countMerged + 1));
        }
        private double mergeDoubleMin(double thisv, double newv) {
            if (thisv <= 0) return newv;
            if (newv <= 0) return thisv;

            return thisv > newv ? newv : thisv;
        }
        private double mergeDoubleMax(double thisv, double newv) {
            if (thisv <= 0) return newv;
            if (newv <= 0) return thisv;

            return thisv < newv ? newv : thisv;
        }
    }
}
