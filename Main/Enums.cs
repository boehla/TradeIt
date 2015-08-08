using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main {
    public enum OrderType { undef, buy, sell }
    public enum LogPrior { Debug = 20, Info = 40, Warning = 60, Error = 80, Trader = 90, Importand = 100 }
    public enum SettKeys { MAX_CHART_POINTS, DATA_FILE, TRADER_DLL_FILE, API_DLL_FILE, CANDLE_INTERVALL }
    public enum CandleInterval {
        _1m = 60,
        _5m = 5 * 60,
        _15m = 15 * 60,
        _1h = 1 * 60 * 60,
        _2h = 2 * 60 * 60,
        _4h = 4 * 60 * 60,
        _12h = 12 * 60 * 60
    }
    class Enums {
    }
}
