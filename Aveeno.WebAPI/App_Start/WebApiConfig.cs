using Aveeno.WebAPI.App_Start;
using Elmah.Contrib.WebApi;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Aveeno.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());
            // Web API configuration and services
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.EnableCors();            

            config.Routes.MapHttpRoute(
                name: "defaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Web API routes
            config.MapHttpAttributeRoutes();
          
        }
    }
}
