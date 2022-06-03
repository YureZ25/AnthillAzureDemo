using Azure.Storage.Queues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPriceAPI.Models;
using StockPriceAPI.Services.Contracts;

namespace StockPriceAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StockPriceController : ControllerBase
    {
        private readonly IStockPriceService _stockPriceService;

        public StockPriceController(IStockPriceService stockPriceService)
        {
            _stockPriceService = stockPriceService;
        }

        [HttpPost]
        public async Task<IActionResult> StockExchanged([FromBody]StockExchangedModel stockExchangedModel)
        {
            await _stockPriceService.AddStockPriceChangingToQueue(stockExchangedModel);

            return Ok();
        }
    }
}
