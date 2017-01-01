using Acme.StockExchange.Domain.Utility;
using System;

namespace Acme.StockExchange.Domain.Entity
{
    public class Stock : StockExchangeEntity, IAggregateRoot
    {
        public decimal CurrentPrice { get; private set; }
        public int OfferingAmount { get; private set; }
        public decimal OfferingPrice { get; private set; }
        public decimal PercentagePriceChange { get; private set; }
        public decimal PriceChange { get; private set; }
        public string TickerSymbol { get; private set; }

        protected Stock() { }

        public Stock(IIdentityFactory<Guid> identityFactory)
            : base(identityFactory)
        { }

        public void NewPrice(decimal newPrice)
        {
            if (newPrice < default(decimal))
                throw new DomainException("Price must be greater than zero");

            PriceChange = CurrentPrice - newPrice;
            PercentagePriceChange = Math.Round(CurrentPrice / newPrice, 2, MidpointRounding.AwayFromZero);
            CurrentPrice = newPrice;
        }
    }
}