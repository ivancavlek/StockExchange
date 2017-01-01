using Acme.StockExchange.Domain.Entity;

namespace Acme.StockExchange.Domain.Repository
{
    public interface IUnitOfWork
    {
        void Commit();
        void Delete<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : BaseEntity, IAggregateRoot;
        void Insert<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : StockExchangeEntity, IAggregateRoot;
        void Update<TAggregateRoot>(TAggregateRoot aggregateRoot) where TAggregateRoot : StockExchangeEntity, IAggregateRoot;
    }
}