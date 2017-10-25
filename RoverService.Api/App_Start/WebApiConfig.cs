using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace RoverService.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /* original source:  https://stackoverflow.com/questions/9847564/how-do-i-get-asp-net-web-api-to-return-json-instead-of-xml-using-chrome */
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }
            );
        }
    }
}
