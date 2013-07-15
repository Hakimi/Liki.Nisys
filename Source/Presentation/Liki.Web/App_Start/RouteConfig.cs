using System.Web.Mvc;
using System.Web.Routing;

namespace Liki.Web.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PaymentsMapRoute",
                url: "v1/{controller}/{action}/{id}",
                defaults: new { }
            );
         

        }
    }
}