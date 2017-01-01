using System;

namespace Acme.StockExchange.Domain.Entity
{
    public class Share : StockExchangeEntity, IAggregateRoot
    {
        public Guid ClientId { get; private set; }
        public Guid StockId { get; private set; }

        public Shareholder Client { get; private set; }
        public Stock Stock { get; private set; }

        protected Share() { }
    }
}