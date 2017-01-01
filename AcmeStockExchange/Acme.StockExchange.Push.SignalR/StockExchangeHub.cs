using Acme.StockExchange.Domain.DataTransferObject;
using Acme.StockExchange.Domain.Service;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Acme.StockExchange.Push.SignalR
{
    public class StockExchangeHub : Hub
    {
        private readonly IStockService _stockService;

        private readonly Timer _stockTimer;
        private readonly int _stockUpdateDelay = 2000;
        private readonly int _timeInterval = 500;
        private readonly Random random = new Random(); // ToDo: Delete

        public StockExchangeHub(IStockService stockService)
        {
            if (stockService == null)
                throw new ArgumentNullException(nameof(stockService));

            _stockService = stockService;
            _stockTimer = new Timer(Update, null, _stockUpdateDelay, _timeInterval);
        }

        public IEnumerable<StockDto> GetStocks()
        {
            return _stockService.GetStocks();
        }

        public void Update(object state)
        {
            Clients.All.updateStock(GetDummyStocks()); // GetStocks
        }

        private IEnumerable<StockDto> GetDummyStocks() // ToDo: Delete
        {
            var stocks = GetStocks();

            foreach (var stock in stocks)
            {
                var r = random.NextDouble();
                if (r > 0.1)
                    break;

                if (stock.CurrentPrice.Equals(0))
                    stock.CurrentPrice = stock.OfferingPrice;

                var random1 = new Random((int)Math.Floor(stock.CurrentPrice));
                var percentChange = random1.NextDouble() * 0.002;
                var pos = random1.NextDouble() > 0.51;
                var change = Math.Round(stock.CurrentPrice * (decimal)percentChange, 2);
                change = pos ? change : -change;

                stock.CurrentPrice += change;
            }

            return stocks;
        }
    }
}