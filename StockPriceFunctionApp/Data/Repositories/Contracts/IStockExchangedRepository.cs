using StockPriceFunctionApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockPriceFunctionApp.Data.Repositories.Contracts
{
    public interface IStockExchangedRepository
    {
        Task<IList<StockExchanged>> GetAllAsync();

        Task<StockExchanged> GetByIdAsync(int id);

        Task InsertAsync(StockExchanged entity);

        Task UpdateAsync(StockExchanged entity);

        Task DeleteAsync(StockExchanged entity);
    }
}
