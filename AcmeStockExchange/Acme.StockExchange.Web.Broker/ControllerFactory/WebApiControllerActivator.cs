using Acme.StockExchange.Bootstrap;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Acme.StockExchange.Web.Broker.ControllerFactory
{
    public class WebApiControllerActivator : IHttpControllerActivator
    {
        private readonly IBootstrapper _bootstrapper;

        public WebApiControllerActivator(IBootstrapper bootstrapper)
        {
            if (bootstrapper == null)
                throw new ArgumentNullException(nameof(bootstrapper));

            _bootstrapper = bootstrapper;
        }

        public IHttpController Create(
            HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (controllerType == null)
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found or it does not implement IController",
                         request.RequestUri));
            if (!typeof(IHttpController).IsAssignableFrom(controllerType))
                throw new ArgumentException(string.Format("Type requested is not a controller: {0}", controllerType.Name));

            IHttpController controller;

            try
            {
                controller = _bootstrapper.Initialize(controllerType) as IHttpController;
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(string.Format("Error resolving controller {0}", controllerType.Name), exception);
            }

            return controller;
        }
    }
}