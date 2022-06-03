using AutoMapper;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using StockPriceFunction.Data.Models;
using StockPriceFunction.Repositories.Contracts;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockPriceFunction
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
        public async Task Run([QueueTrigger("anthill-demo-queue", Connection = "DefaultEndpointsProtocol=https;AccountName=cascadedemostorage;AccountKey=qT4OIPCbfWAvf0xFLBmMyv5tl2EG2jNikvLpUZaO4fc2vUQOTzEbgFD7+eCu0Tt1QC24jrXw6ZD+jaLtqWDngw==;EndpointSuffix=core.windows.net")]
            StockPriceQueueItem stockPriceQueueItem, ILogger log)
        {
            var stockExchanged = _mapper.Map<StockExchanged>(stockPriceQueueItem);

            await _stockExchangedRepository.InsertAsync(stockExchanged);

            // TODO
            log.LogInformation($"C# Queue trigger function processed: {JsonSerializer.Serialize(stockPriceQueueItem)}");
        }
    }
}
