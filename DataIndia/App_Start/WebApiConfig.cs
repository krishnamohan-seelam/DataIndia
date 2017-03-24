using DataIndia.Helpers;
using DataIndia.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace DataIndia 
{
    public class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;
              var dataContainer = DataModelContainer.Instance;

             config.DependencyResolver = new UnityHttpDependencyResolver(dataContainer);

            /*config.Routes.MapHttpRoute(name:"DefaultApi" ,routeTemplate :"api/{controller}/id)",
                                          defaults: new { id = RouteParameter.Optional });*/


        }
    }
}