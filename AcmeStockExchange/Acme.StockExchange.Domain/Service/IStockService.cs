using Acme.StockExchange.Domain.DataTransferObject;
using System;
using System.Collections.Generic;

namespace Acme.StockExchange.Domain.Service
{
    public interface IStockService
    {
        StockDto CreateStock(StockDto stockDto);
        void DeleteStock(Guid stockId);
        IEnumerable<StockDto> GetStocks();
        StockDto UpdateStock(StockDto stockDto);
    }
}