using Acme.StockExchange.Domain.Utility;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Acme.StockExchange.Web.Broker.Filter
{
    public class StockExchangeExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is DomainException)
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionExecutedContext.Exception.Message);
            else
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "System exception occured");
        }
    }
}