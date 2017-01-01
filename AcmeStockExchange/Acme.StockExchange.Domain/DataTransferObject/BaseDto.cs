using System;

namespace Acme.StockExchange.Domain.DataTransferObject
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
    }
}