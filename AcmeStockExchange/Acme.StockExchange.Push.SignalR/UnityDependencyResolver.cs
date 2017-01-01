using Acme.StockExchange.Bootstrap;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acme.StockExchange.Push.SignalR
{
    public class UnityDependencyResolver : DefaultDependencyResolver
    {
        private readonly IBootstrapper _bootstrapper;

        public UnityDependencyResolver(IBootstrapper bootstrapper)
        {
            _bootstrapper = bootstrapper;
        }

        public override object GetService(Type serviceType)
        {
            return _bootstrapper.Initialize(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }
    }
}