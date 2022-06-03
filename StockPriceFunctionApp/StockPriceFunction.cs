using AutoMapper;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using StockPriceFunctionApp.Data.Models;
using StockPriceFunctionApp.Data.Repositories.Contracts;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockPriceFunctionApp
{
    public class StockPriceFunction
    {
        private readonly IStockExchangedRepository _stockExchangedRepository;
        private readonly IMapper _mapper;

        public StockPriceFunction(IStockExchangedRepository stockExchangedRepository, IMapper mapper)
        {
            _stockExchangedRepository = stockExchangedRepository;
            _mapper = mapper;
        }

        [FunctionName("StockPriceFunction")]
        public async Task Run([QueueTrigger("anthill-demo-queue", Connection = "AzureWebJobsStorage")]string message, ILogger log)
        {
            var stockPriceQueueItem = JsonSerializer.Deserialize<StockPriceQueueItem>(message);

            var stockExchanged = _mapper.Map<StockExchanged>(stockPriceQueueItem);

            stockExchanged.DateTime = DateTime.UtcNow;
            await _stockExchangedRepository.InsertAsync(stockExchanged);

            log.LogInformation($"Store transaction for stock: {stockExchanged.TickerSymbol} at {stockExchanged.DateTime}");
        }
    }
}
