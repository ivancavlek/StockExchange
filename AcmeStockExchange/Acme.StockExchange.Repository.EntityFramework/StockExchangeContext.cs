using Acme.StockExchange.Domain.Entity;
using Acme.StockExchange.Domain.Repository;
using Acme.StockExchange.Repository.EntityFramework.Configuration;
using System.Data.Entity;
using System.Linq;

namespace Acme.StockExchange.Repository.EntityFramework
{
    public sealed class StockExchangeContext : DbContext, IContext, IUnitOfWork
    {
        public DbSet<Stock> Applications { get; private set; }

        public StockExchangeContext()
            : base("StockExchange")
        {
            // ReSharper disable once UnusedVariable
            // Hack: this line is needed to ensure that Entity Framework.SqlServer is referenced in every presentation BIN folder for Unity DI
            var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("broker");
            modelBuilder.Configurations.Add(new StockConfiguration());
        }

        IQueryable<TBaseEntity> IContext.GetContext<TBaseEntity>() => Set<TBaseEntity>();

        void IUnitOfWork.Commit() => SaveChanges();

        void IUnitOfWork.Delete<TAggregateRoot>(TAggregateRoot aggregateRoot) =>
            Entry(aggregateRoot).State = EntityState.Deleted;

        void IUnitOfWork.Insert<TAggregateRoot>(TAggregateRoot aggregateRoot) =>
            Entry(aggregateRoot).State = EntityState.Added;

        void IUnitOfWork.Update<TAggregateRoot>(TAggregateRoot aggregateRoot) =>
            Entry(aggregateRoot).State = EntityState.Modified;
    }
}