namespace StockPriceFunction
{
    public class StockPriceQueueItem
    {
        public int BrokerId { get; set; }

        public string TickerSymbol { get; set; }

        public double NewPrice { get; set; }

        public double OldPrice { get; set; }
    }
}
