using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceData
{
    public class StockExchanged
    {
        public int Id { get; set; }


        public int BrokerId { get; set; }


        public string TickerSymbol { get; set; }

        public double NewPrice { get; set; }

        public double OldPrice { get; set; }
    }
}
