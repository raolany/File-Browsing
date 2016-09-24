﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FileBrowsingWebSystem
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "PathParamRoute",
            //    routeTemplate: "api/{controller}/{action}/{path}"
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // disable xml output data
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
