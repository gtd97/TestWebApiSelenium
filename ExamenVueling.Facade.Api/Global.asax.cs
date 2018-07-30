using ExamenVueling.Application.Services.Service;
using ExamenVueling.Common.Layer;
using ExamenVueling.Facade.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ExamenVueling.Facade.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ObtenerDatos controller = new ObtenerDatos();
            controller.ObtenerClients(ConfigurationManager.AppSettings.Get("RutaApiExternaClientsPath").ToString());
            controller.ObtenerPolicies(ConfigurationManager.AppSettings.Get("RutaApiExternaPoliciesPath").ToString());
        }
    }
}
