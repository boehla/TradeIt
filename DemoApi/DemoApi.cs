using Main.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi
{
    public class KrakenApi : ApiHelp {

        private ApiPortfolio _curPortfolio = null;

        public ApiPortfolio Portfolio {
            get {
                if (_curPortfolio == null) this.refreshPortfolio();
                return _curPortfolio;
            }
        }
        public override void init() {
            base.init();
        }
        public override String Name {
            get { return "DemoApi"; }
        }
        public override String Version {
            get { return "0.0.1"; }
        }

        public override ApiTicker getTicker(string pair) {
            List<ApiTicker> ret = getTicker(new List<string>() { pair });
            if (ret.Count > 0) return ret[0];
            return null;
        }

        public override List<ApiTicker> getTicker(List<string> pair) {
            List<ApiTicker> ret = new List<ApiTicker>();
            ApiTicker demotick = new ApiTicker();
            demotick.Ask = 202;
            demotick.Bid = 200;
            demotick.High = 204;
            demotick.Last = 201;
            demotick.Low = 199;
            demotick.NumberOfTrades = 1000;
            demotick.Volume = 10;
            demotick.VolumeWeight = 100;
            demotick.CorrectData = true;
            ret.Add(demotick);
            return ret;
        }
        public override ApiTradeHistory getTrades() {
            ApiTradeHistory tr = new ApiTradeHistory();
            ApiTrade demotrade = new ApiTrade();
            demotrade.ordertxid = "XXXXX";
            demotrade.pair = "BTCEUR";
            demotrade.cost = (decimal)0.12;
            demotrade.fee = (decimal)0.11221;
            demotrade.margin = (decimal)10.0123;
            demotrade.misc = "WHATEVER";
            demotrade.price = (decimal)123.021;
            demotrade.time = DateTime.Now.AddDays(-1);
            demotrade.type = Main.OrderType.buy;
            demotrade.vol = (decimal)10.231;
            tr.Trades.Add(demotrade);
            return tr;
        }
        public override ApiPortfolio getBalance() {
            ApiPortfolio ret = new ApiPortfolio();
            ret.eur = 100;
            ret.btc = 10;
            return ret;
        }

        public override void sell(decimal volume) {
            base.sell(volume);
        }
        public override void buy(decimal volume) {
            base.buy(volume);
        }
    }
}
