using Jayrock.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Api {
    public class ApiHelp {
        private ApiPortfolio _curPortfolio = null;

        public ApiPortfolio Portfolio {
            get {
                if (_curPortfolio == null) this.refreshPortfolio();
                return _curPortfolio;
            }
        }

        public ApiHelp() {
        }
        public virtual void init() {

        }
        public virtual String Name {
            get { return "ND"; }
        }
        public virtual String Version {
            get { return "ND"; }
        }
        public virtual ApiTicker getTicker(string pair) {
            List<ApiTicker> ret = getTicker(new List<string>() { pair });
            if (ret.Count > 0) return ret[0];
            return new ApiTicker();
        }

        public virtual List<ApiTicker> getTicker(List<string> pair) {
            return new List<ApiTicker>();
        }
        public virtual ApiTradeHistory getTrades() {
            return new ApiTradeHistory();
        }
        public List<ApiTrade> getRecentTrades(string pair) {
            return this.getRecentTrades(new List<string>(){pair});
        }
        public virtual List<ApiTrade> getRecentTrades(List<string> pair) {
            return new List<ApiTrade>();
        }

        public virtual ApiPortfolio getBalance() {
            return new ApiPortfolio();
        }
        public void refreshPortfolio() {
            _curPortfolio = getBalance();
        }

        public virtual bool sell(decimal volume) {
            Logging.log("ORDERSELL: " + volume.ToString(), LogPrior.Importand);
            return true;
        }
        public virtual bool buy(decimal volume) {
            Logging.log("ORDERBUY: " + volume.ToString(), LogPrior.Importand);
            return true;
        }
        public void log(string text) {

        }

        public string loadSettings() {
            return Settings.getString(SettKeys.API_TICKER_SETTINGS);
        }
        public void saveSettings(string value) {
            Settings.set(SettKeys.API_TICKER_SETTINGS, value);
        }
    }

    public class ApiErrorException : Exception {
        public ApiErrorException() {
        }

        public ApiErrorException(string message)
            : base(message) {
        }

        public ApiErrorException(string message, Exception inner)
            : base(message, inner) {
        }
    }
}
