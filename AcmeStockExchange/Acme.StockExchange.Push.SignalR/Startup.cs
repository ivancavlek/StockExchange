using Acme.StockExchange.Bootstrap;
using Microsoft.AspNet.SignalR;
using Owin;

//[assembly: OwinStartup(typeof(Acme.StockExchange.Push.SignalR.Startup), "Configuration")]
namespace Acme.StockExchange.Push.SignalR
{
    public class Startup
    {
        private readonly IBootstrapper _bootstrapper;

        public Startup(IBootstrapper bootstrapper)
        {
            _bootstrapper = bootstrapper;
        }

        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR(new HubConfiguration { Resolver = new UnityDependencyResolver(_bootstrapper) });
        }
    }
}