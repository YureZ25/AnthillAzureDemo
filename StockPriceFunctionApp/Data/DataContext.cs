using Microsoft.EntityFrameworkCore;
using StockPriceFunctionApp.Data.Models;

namespace StockPriceFunctionApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { Database.EnsureCreated(); }

        public DbSet<StockExchanged> StockExchanged { get; set; } = null!;
    }
}
