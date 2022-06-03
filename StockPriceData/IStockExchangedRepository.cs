﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceData
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
