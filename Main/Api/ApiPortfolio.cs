using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Api{
    public class ApiPortfolio {
        public decimal btc { get; set; }
        public decimal eur { get; set; }

        public ApiPortfolio() {
            btc = -1;
            eur = -1;
        }
        public override string ToString() {
            return string.Format("eur={0}; btc={1}", eur, btc);
        }
        public ApiPortfolio clone() {
            ApiPortfolio ret = new ApiPortfolio();
            ret.eur = this.eur;
            ret.btc = this.btc;
            return ret;
        }
    }
}
