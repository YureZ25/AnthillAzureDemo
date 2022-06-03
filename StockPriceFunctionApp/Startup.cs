using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockPriceFunctionApp.Data;
using StockPriceFunctionApp.Data.Mappings;
using StockPriceFunctionApp.Data.Repositories;
using StockPriceFunctionApp.Data.Repositories.Contracts;

namespace StockPriceFunctionApp
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
