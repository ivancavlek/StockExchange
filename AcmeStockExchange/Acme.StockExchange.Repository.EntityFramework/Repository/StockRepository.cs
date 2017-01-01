using Acme.StockExchange.Domain.Entity;
using Acme.StockExchange.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Acme.StockExchange.Repository.EntityFramework.Repository
{
    public sealed class StockRepository : BaseRepository, IStockRepository
    {
        public StockRepository(IContext context)
            : base(context) { }

        Stock IStockRepository.GetStockById(Guid stockId) =>
            Context.GetContext<Stock>().AsNoTracking().SingleOrDefault(s => s.Id.Equals(stockId));

        IEnumerable<Stock> IStockRepository.GetStocks() =>
            Context.GetContext<Stock>().AsNoTracking().ToList();
    }
}