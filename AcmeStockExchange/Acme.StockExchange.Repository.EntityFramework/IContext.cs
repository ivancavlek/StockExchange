using Acme.StockExchange.Domain.Entity;
using System.Linq;

namespace Acme.StockExchange.Repository.EntityFramework
{
    public interface IContext
    {
        IQueryable<TBaseEntity> GetContext<TBaseEntity>() where TBaseEntity : StockExchangeEntity;
    }
}