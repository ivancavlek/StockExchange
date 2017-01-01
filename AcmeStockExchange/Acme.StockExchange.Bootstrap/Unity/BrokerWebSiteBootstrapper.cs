using Acme.StockExchange.Domain.Entity;
using Acme.StockExchange.Domain.Utility;
using Microsoft.Practices.Unity;
using System;

namespace Acme.StockExchange.Bootstrap.Unity
{
    public class BrokerWebSiteBootstrapper : UnityBootstrapper
    {

        public BrokerWebSiteBootstrapper(IUnityContainer unityContainer)
            : base(unityContainer)
        { }

        public override void RegisterComponents() =>
            RegisterBaseComponents()
                .RegisterType<IIdentityFactory<Guid>, GuidIdentityFactory>(new InjectionConstructor(SequentialGuidType.SequentialAtEnd));

        protected override bool TypeIsFromApplication(Type type) =>
            // ReSharper disable PossibleNullReferenceException
            type != BootstrapperType &&
            type != typeof(IAggregateRoot) &&
            type.Namespace.StartsWith(GetApplicationNamespace(), StringComparison.InvariantCultureIgnoreCase);
        // ReSharper restore PossibleNullReferenceException
    }
}