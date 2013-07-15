using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Liki.WebAPI.App_Start;
using StructureMap;

namespace Liki.WebAPI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BootStrapper.ConfigureDependencies();
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

            GlobalConfiguration.Configuration.Services
                .Replace(typeof(IHttpControllerActivator),
                    new StructureMapHttpControllerActivator(ObjectFactory.Container.GetNestedContainer()));
        }
    }
}