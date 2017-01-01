using System;

namespace Acme.StockExchange.Repository.EntityFramework.Repository
{
    public abstract class BaseRepository
    {
        protected readonly IContext Context;

        public BaseRepository(IContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            Context = context;
        }
    }
}