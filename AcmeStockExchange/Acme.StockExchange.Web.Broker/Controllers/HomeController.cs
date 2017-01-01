using System.Web.Mvc;

namespace Acme.StockExchange.Web.Broker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();
    }
}