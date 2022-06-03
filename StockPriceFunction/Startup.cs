using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockPriceFunction.Data;
using StockPriceFunction.Data.Mappings;
using StockPriceFunction.Repositories;
using StockPriceFunction.Repositories.Contracts;

namespace StockPriceFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AnthillAzureDemo"));

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddScoped<IStockExchangedRepository, StockExchangedRepository>();
        }
    }
}
