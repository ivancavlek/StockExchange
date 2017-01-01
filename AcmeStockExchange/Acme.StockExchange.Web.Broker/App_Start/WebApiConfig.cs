using Acme.StockExchange.Web.Broker.Filter;
using System.Web.Http;

namespace Acme.StockExchange.Web.Broker
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new StockExchangeExceptionFilterAttribute());
        }
    }
}