using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace PassDailyParentsApi.Service
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
                routeTemplate: "PassDailyParentsApi/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Clear();
            //config.Formatters.Add(new JsonMediaTypeFormatter() { SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore } });
            config.Formatters.Add(new JsonMediaTypeFormatter() { SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings() });
        }
    }
}
