using Acme.StockExchange.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Acme.StockExchange.Domain.Repository
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetStocks();
        Stock GetStockById(Guid stockId);
    }
}