using Acme.StockExchange.Domain.Utility;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Acme.StockExchange.Mapping
{
    [SuppressMessage("Microsoft.Design", "CA1001", Justification = "Currently there is no other way - Ivan")]
    public sealed class AutoMapperMapping : IMapper
    {
        private readonly AutoMapper.IMapper _mapper;

        public AutoMapperMapping()
        {
            var config = new AutoMapper.MapperConfiguration(cfg => AutoMapperProfiles.Get().ToList().ForEach(cfg.AddProfile));

            _mapper = config.CreateMapper();
        }

        TDestination IMapper.Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        TDestination IMapper.Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}