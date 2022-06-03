using StockPriceAPI.Models;

namespace StockPriceAPI.Services.Contracts
{
    public interface IStockPriceService
    {
        Task AddStockPriceChangingToQueue(StockExchangedModel stockExchangedModel);
    }
}
