using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Web_Project_Server.Models;

namespace Web_Project_Server
{
    public class MvcApplication : System.Web.HttpApplication
    {
		
        protected void Application_Start()
        {
			Database.SetInitializer<ElectionCatalog>(null);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start()
        {
            Session["LoginStage"] = 0;
        }
    }
}
