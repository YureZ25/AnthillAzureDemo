namespace StockPriceAPI.Models
{
    public class StockExchangedModel
    {
        public int BrokerId { get; set; }

        public string TickerSymbol { get; set; }

        public double NewPrice { get; set; }

        public double OldPrice { get; set; }
    }
}
