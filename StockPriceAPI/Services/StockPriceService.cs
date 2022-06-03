using Azure.Storage.Queues;
using StockPriceAPI.Helpers;
using StockPriceAPI.Models;
using StockPriceAPI.Services.Contracts;
using System.Text;
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
            var message = JsonSerializer.Serialize(stockExchangedModel);

            try
            {
                var bytesMessage = UnicodeEncoding.UTF8.GetBytes(message);
                await _queueClient.SendMessageAsync(Convert.ToBase64String(bytesMessage));
            }
            catch(Exception ex)
            {
                _logger.LogError("Message wasn't send to queue. Error message: " + ex.Message, ex);
            }

            _logger.LogInformation($"Message for stock {stockExchangedModel.TickerSymbol} was send to queue");
        }
    }
}
