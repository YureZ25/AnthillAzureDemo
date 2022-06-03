using Azure.Storage.Queues;
using StockPriceAPI.Helpers;
using StockPriceAPI.Models;
using StockPriceAPI.Services.Contracts;
using System.Text.Json;

namespace StockPriceAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly QueueClient _queueClient;
        private readonly ILogger<StockPriceService> _logger;

        public StockPriceService(IConfiguration configuration, ILogger<StockPriceService> logger)
        {
            string name = configuration[QueueConstaints.QueueName];
            string connectionString = configuration[QueueConstaints.QueueConnectionString];

            _queueClient = new QueueClient(connectionString, name);
            _logger = logger;
        }

        public async Task AddStockPriceChangingToQueue(StockExchangedModel stockExchangedModel)
        {
            // в стартап
            if (!await _queueClient.ExistsAsync())
            {
                await _queueClient.CreateIfNotExistsAsync();
                _logger.LogError("Queue doesn't exist, create it");
            }

            string message = JsonSerializer.Serialize(stockExchangedModel);

            await _queueClient.SendMessageAsync(message);
        }
    }
}
