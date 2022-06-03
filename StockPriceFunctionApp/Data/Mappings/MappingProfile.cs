using AutoMapper;
using StockPriceFunctionApp.Data.Models;

namespace StockPriceFunctionApp.Data.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StockExchanged, StockPriceQueueItem>().ReverseMap();
        }
    }
}
