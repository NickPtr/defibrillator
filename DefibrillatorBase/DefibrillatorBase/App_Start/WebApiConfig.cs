﻿using System.Web.Http;

namespace DefibrillatorBase
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes ();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{action}/{id}",
                new {id=RouteParameter.Optional}
            );
        }
    }
}