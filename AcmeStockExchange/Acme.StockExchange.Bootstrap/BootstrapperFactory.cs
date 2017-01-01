using Acme.StockExchange.Bootstrap.Unity;
using Microsoft.Practices.Unity;
using System.ComponentModel;
using System;

namespace Acme.StockExchange.Bootstrap
{
    public static class BootstrapperFactory
    {
        public static IBootstrapper Create(Context context)
        {
            switch (context)
            {
                case Context.BrokerWebSite:
                    return new BrokerWebSiteBootstrapper(new UnityContainer());
                default:
                    throw new InvalidEnumArgumentException(nameof(context));
            }
        }

        public static object Create(object brokerWebSite)
        {
            throw new NotImplementedException();
        }
    }

    public enum Context
    {
        BrokerWebSite
    }
}