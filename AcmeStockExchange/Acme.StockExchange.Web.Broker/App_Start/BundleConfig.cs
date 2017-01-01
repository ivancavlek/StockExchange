using System.Web.Optimization;

namespace Acme.StockExchange.Web.Broker
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/dataTables").Include(
                "~/scripts/DataTables/jquery.dataTables.js"));
            bundles.Add(new ScriptBundle("~/jquery").Include(
                "~/scripts/jquery-{version}.js",
                "~/scripts/jquery-ui-{version}.js",
                "~/scripts/jquery.validate.js",
                "~/scripts/noty/jquery.noty.js",
                "~/scripts/noty/themes/relax.js",
                "~/scripts/noty/layouts/topCenter.js"));
            bundles.Add(new ScriptBundle("~/knockout").Include(
                "~/scripts/knockout-{version}.js",
                "~/scripts/knockout.mapping-latest.js"));
            bundles.Add(new ScriptBundle("~/stock").Include(
                "~/scripts/Site/common.js",
                "~/scripts/Site/stock.js"));

            bundles.Add(new StyleBundle("~/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css",
                "~/Content/DataTables/css/jquery.dataTables.css",
                "~/Content/themes/base/all.css"));
        }
    }
}