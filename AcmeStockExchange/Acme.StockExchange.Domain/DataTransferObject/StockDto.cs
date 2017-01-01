namespace Acme.StockExchange.Domain.DataTransferObject
{
    public class StockDto : BaseDto
    {
        public decimal CurrentPrice { get; set; }
        public int OfferingAmount { get; set; }
        public decimal OfferingPrice { get; set; }
        public decimal PercentagePriceChange { get; set; }
        public decimal PriceChange { get; set; }
        public string TickerSymbol { get; set; }
    }
}