using System;

namespace Acme.StockExchange.Bootstrap
{
    public interface IBootstrapper
    {
        object Initialize(Type type);
        void RegisterComponents();
    }
}