using Acme.StockExchange.Bootstrap;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Acme.StockExchange.Web.Broker.ControllerFactory
{
    public class MvcControllerFactory : DefaultControllerFactory
    {
        private readonly IBootstrapper _bootstrapper;

        public MvcControllerFactory(IBootstrapper bootstrapper)
        {
            if (bootstrapper == null)
                throw new ArgumentNullException(nameof(bootstrapper));

            _bootstrapper = bootstrapper;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found or it does not implement IController",
                         requestContext.RouteData));
            if (!typeof(IController).IsAssignableFrom(controllerType))
                throw new ArgumentException(string.Format("Type requested is not a controller: {0}", controllerType.Name));

            IController controller;

            try
            {
                controller = _bootstrapper.Initialize(controllerType) as IController;
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(string.Format("Error resolving controller {0}", controllerType.Name), exception);
            }

            return controller;
        }
    }
}