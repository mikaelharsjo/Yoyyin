using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using Microsoft.Web.Infrastructure;

[assembly: WebActivator.PostApplicationStartMethod(typeof(Yoyyin.Web.AppStart_RegisterRoutesAreasFilters), "Start")]

namespace Yoyyin.Web {
    public static class AppStart_RegisterRoutesAreasFilters {
        public static void Start() {
            // Set everything up with you having to do any work.
            // I'm doing this because it means that
            // your app will just run. You might want to get rid of this 
            // and integrate with your own Global.asax. 
            // It's up to you. 
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(Configuration.Configuration.Container));
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "Default", // Route name
            //    "{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            //);
        }
    
    }

}