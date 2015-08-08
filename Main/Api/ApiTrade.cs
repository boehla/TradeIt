using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Api {
    public class ApiTrade {
        public string ordertxid { get; set; }
        public string pair { get; set; }
        public DateTime time { get; set; }
        public OrderType type { get; set; }
        public decimal price { get; set; }
        public decimal cost { get; set; }
        public decimal fee { get; set; }
        public decimal vol { get; set; }
        public decimal margin { get; set; }
        public string misc { get; set; }

        public ApiTrade() {
            ordertxid = "";
            pair = "";
            time = Lib.Const.NULL_DATE;
            type = OrderType.undef;
            price = -1;
            cost = -1;
            fee = -1;
            vol = -1;
            margin = -1;
            misc = "";
        }
    }
    public class ApiTradeHistory {
        private List<ApiTrade> trades = new List<ApiTrade>();

        public List<ApiTrade> Trades {
            get { return trades; }
            set { trades = value; }
        }
        public ApiTradeHistory() {
            trades = new List<ApiTrade>();
        }

        public DataTable getDataTable() {
            DataTable dt = new DataTable();

            dt.Columns.Add("ordertxid");
            dt.Columns.Add("pair");
            dt.Columns.Add("time", DateTime.Now.GetType());
            dt.Columns.Add("type");
            dt.Columns.Add("price");
            dt.Columns.Add("cost");
            dt.Columns.Add("fee");
            dt.Columns.Add("vol");
            dt.Columns.Add("margin");
            dt.Columns.Add("misc");

            foreach (ApiTrade trade in trades) {
                DataRow dr = dt.NewRow();
                dr["ordertxid"] = Lib.Converter.toString(trade.ordertxid);
                dr["pair"] = Lib.Converter.toString(trade.pair);
                dr["time"] = trade.time;
                dr["type"] = Lib.Converter.toString(trade.type);
                dr["price"] = Lib.Converter.toString(trade.price);
                dr["cost"] = Lib.Converter.toString(trade.cost);
                dr["fee"] = Lib.Converter.toString(trade.fee);
                dr["vol"] = Lib.Converter.toString(trade.vol);
                dr["margin"] = Lib.Converter.toString(trade.margin);
                dr["misc"] = Lib.Converter.toString(trade.misc);
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }

}
