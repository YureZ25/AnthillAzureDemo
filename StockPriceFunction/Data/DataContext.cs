using Microsoft.EntityFrameworkCore;
using StockPriceFunction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceFunction.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { Database.EnsureCreated(); }

        public DbSet<StockExchanged> StockExchanged { get; set; } = null!;
    }
}
