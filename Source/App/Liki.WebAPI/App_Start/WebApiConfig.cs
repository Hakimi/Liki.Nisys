using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Liki.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var routes = GlobalConfiguration.Configuration.Routes;
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapHttpRoute(
            "PaymentsHttpRoute",
            "v1/{Payments}/{controller}",
            defaults: new { },
            constraints: new { controller = "^Payments$" }
         );

            routes.MapHttpRoute(
                "DefaultHttpRoute",
                "v1/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );
        }
    }
}
