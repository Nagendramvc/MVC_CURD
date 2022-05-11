using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyNoteMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            //Attribute Routing
            //routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);


            ////CURDEF
            //routes.MapRoute(
            //        name: "EmployeeList",
            //        url: "EmployeeList",
            //        defaults: new { controller = "CURDEF", action = "List" }
            //    );


            ////CURDWithoutEF
            //routes.MapRoute("CURDWithoutEF-Lists", "Employee-List", new { controller = "CURDWithoutEF", action = "List" });


            //routes.MapRoute("AJAXCURDWithtEF-Lists", "Employee-Lists", new { controller = "CURDAJAX", action = "Index" });

            //Default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MyHomePage", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
