using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Gamrzone
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //The only nice thing about the default route is it makes index work, however it has loads of features not worth caring about
            routes.MapRoute(
                name: "Default",
                url: "{controller}",
                defaults: new { controller = "Home", action = "Index"}
            );
            //This place holder is a good version of a routing table that allows us to have beautiful urls, without the fun that is MVC vs IIS
            routes.MapRoute(
                "Page Router",                                      //Descriptive Name
                "PAGE/{action}",                                    //Masking Url
                new { controller = "Home", action = "Index"}        //Handle the routing only in the part of the url we care about
            );

            //Lets catch the 404 pages and actually send them somewhere
            routes.MapRoute(
                "404-PageNotFound",
                "{*url}", //This is a catch all for url's that don't match our other paterns, we will have to work with IIS to make this function as intended
                new { controller = "StaticPages", action = "NoPageFound"}
            );
        }
    }
}
