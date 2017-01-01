using System;

namespace Acme.StockExchange.Domain.Entity
{
    public abstract class Order : StockExchangeEntity, IAggregateRoot
    {
        public Guid ClientId { get; private set; }
        public Guid PortfolioId { get; private set; }
        public Guid SharePriceId { get; private set; }

        public Shareholder Client { get; private set; }
        public Share Share { get; private set; }
        public Stock Stock { get; private set; }

        protected Order() { }
    }
}