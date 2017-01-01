using Acme.StockExchange.Bootstrap;
using Acme.StockExchange.Web.Broker.ControllerFactory;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;

namespace Acme.StockExchange.Web.Broker
{
    public class DiContainerConfig
    {
        public static void SetDependencyInjectionContainer(IBootstrapper bootstrapper)
        {
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator), new WebApiControllerActivator(bootstrapper));
            ControllerBuilder.Current.SetControllerFactory(new MvcControllerFactory(bootstrapper));
            //var stratup = new Startup(bootstrapper);
        }
    }
}