using Microsoft.EntityFrameworkCore;
using StockPriceFunction.Data;
using StockPriceFunction.Data.Models;
using StockPriceFunction.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockPriceFunction.Repositories
{
    internal class StockExchangedRepository : IStockExchangedRepository
    {
        private readonly DataContext _context;

        public StockExchangedRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IList<StockExchanged>> GetAllAsync()
        {
            var query = from se in _context.StockExchanged
                        select se;

            return await query.ToListAsync();
        }

        public async Task<StockExchanged> GetByIdAsync(int id)
        {
            return await _context.FindAsync<StockExchanged>(id);
        }

        public async Task InsertAsync(StockExchanged entity)
        {
            await _context.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StockExchanged entity)
        {
            _context.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(StockExchanged entity)
        {
            _context.Remove(entity);

            await _context.SaveChangesAsync();
        }


    }
}
