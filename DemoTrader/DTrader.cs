using Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTrader
{
    public class StdTraders : Trader {
        public StdTraders()
            : base() {

        }
        public override string Name {
            get { return "DemoTrader"; }
        }
        public override string Version {
            get { return "0.0.1"; }
        }
        public override bool Active {
            get {
                return true;
            }
        }
        public override void Initiale() {
            log("Tradeengine started.... Balance: btc=" + Portfolio.btc + "; eur=" + Portfolio.eur);
            base.Initiale();
        }
        public override void Update() {
            if (!Data.checkIfDataFalid(2)) return;

            double shortvl = Data.ma(2);
            double longvl = Data.ma(1);
            double mymacd = (longvl - shortvl) / longvl;
            plot("ma short", shortvl);
            plot("ma long", longvl);
            plot("ema short", Data.ema(2));
            plot("price", Data.Candle().value.Last);
            plot("macd", mymacd, true);
            if (TickCount % 2 == 0) {
                buyBtc(10);
            } else {
                sellBtc(10);
            }
            base.Update();
        }
        public override void Stop() {
            base.Stop();
        }
    }
}
