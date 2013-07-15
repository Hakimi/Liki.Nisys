using System;
using System.Web.Http;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(Liki.Web.App_Start.CorsConfig), "PreStart")]

namespace Liki.Web.App_Start {
    public static class CorsConfig {
        public static void PreStart() {
            GlobalConfiguration.Configuration.MessageHandlers.Add(new RedRocket.WebApi.Cors.CorsHandler());
        }
    }
}

