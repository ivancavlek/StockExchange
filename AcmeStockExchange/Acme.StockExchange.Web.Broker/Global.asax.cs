using Acme.StockExchange.Bootstrap;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;

namespace Acme.StockExchange.Web.Broker
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            var bootstrapper = BootstrapperFactory.Create(Bootstrap.Context.BrokerWebSite);
            bootstrapper.RegisterComponents();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DiContainerConfig.SetDependencyInjectionContainer(bootstrapper);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}