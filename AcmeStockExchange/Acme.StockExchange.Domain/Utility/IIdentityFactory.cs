namespace Acme.StockExchange.Domain.Utility
{
    public interface IIdentityFactory<out TKey>
    {
        TKey CreateIdentity();
    }
}