using Acme.StockExchange.Domain.DataTransferObject;
using Acme.StockExchange.Domain.Entity;
using AutoMapper;

namespace Acme.StockExchange.Mapping
{
    public sealed class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<Stock, StockDto>()
                .ReverseMap()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}