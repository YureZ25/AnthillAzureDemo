using AutoMapper;
using StockPriceFunction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceFunction.Data.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StockExchanged, StockPriceQueueItem>().ReverseMap();
        }
    }
}
