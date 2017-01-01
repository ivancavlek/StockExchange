using Acme.StockExchange.Domain.Utility;
using System;

namespace Acme.StockExchange.Domain.Entity
{
    public abstract class StockExchangeEntity : Entity<Guid>
    {
        protected StockExchangeEntity() { }

        protected StockExchangeEntity(IIdentityFactory<Guid> identityFactory)
            : base(identityFactory) { }
    }
}