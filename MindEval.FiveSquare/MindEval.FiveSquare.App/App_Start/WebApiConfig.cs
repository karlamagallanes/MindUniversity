using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MindEval.FiveSquare.App
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           // config.Routes.MapHttpRoute(
           //    name: "CheckApi",
           //    routeTemplate: "{controller}/{id}/{action}",
           //    defaults: new { id = RouteParameter.Optional }
           //);

           // config.Routes.MapHttpRoute(
           //    name: "Api",
           //    routeTemplate: "api/{controller}/{action}"
           //);
        }
    }
}
