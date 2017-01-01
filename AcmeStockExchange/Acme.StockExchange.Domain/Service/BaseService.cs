using Acme.StockExchange.Domain.Utility;
using System;

namespace Acme.StockExchange.Domain.Service
{
    public abstract class BaseService
    {
        protected readonly IMapper Mapper;

        protected BaseService(IMapper mapper)
        {
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            Mapper = mapper;
        }
    }
}