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
                 name: "Default",
                 routeTemplate: "{controller}/{action}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );

            config.Routes.MapHttpRoute(
                name: "userRegisterApi",
                routeTemplate: "{controller}/Register/{user}",
                 defaults: new { controller = "User" }
            );

            config.Routes.MapHttpRoute(
               name: "userLogoutApi",
               routeTemplate: "{controller}/Logout",
               defaults: new { controller = "User" }
           );

            config.Routes.MapHttpRoute(
                name: "PlaceApi",
                routeTemplate: "{controller}/{id}/{action}",
                defaults: new { controller = "Place" }
            );
        }
    }
}