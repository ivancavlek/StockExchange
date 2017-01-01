using Acme.StockExchange.Domain.DataTransferObject;
using Acme.StockExchange.Domain.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Acme.StockExchange.Web.Broker.Controllers
{
    public class StockController : ApiController
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            if (stockService == null)
                throw new ArgumentNullException(nameof(stockService));

            _stockService = stockService;
        }

        public HttpResponseMessage Delete(Guid id)
        {
            _stockService.DeleteStock(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public IEnumerable<StockDto> Get() => _stockService.GetStocks();

        public HttpResponseMessage Post([FromBody]StockDto stockDto)
        {
            var newStock = _stockService.CreateStock(stockDto);
            var response = Request.CreateResponse(HttpStatusCode.OK, newStock);
            var url = Url.Link("DefaultApi", new { stockDto.Id });
            response.Headers.Location = new Uri(url);
            return response;
        }

        public HttpResponseMessage Put([FromBody]StockDto stockDto)
        {
            var updatedStock = _stockService.UpdateStock(stockDto);
            return Request.CreateResponse(HttpStatusCode.OK, updatedStock);
        }
    }
}