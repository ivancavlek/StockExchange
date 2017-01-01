using Acme.StockExchange.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Acme.StockExchange.Repository.EntityFramework.Configuration
{
    public class StockConfiguration : EntityTypeConfiguration<Stock>
    {
        public StockConfiguration()
        {
            Property(p => p.OfferingPrice).HasPrecision(9, 2);
            Property(p => p.TickerSymbol).IsRequired();
        }
    }
}