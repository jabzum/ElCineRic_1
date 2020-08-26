using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ElCineRic_1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Func",
               url: "{controller}/{action}/{id}/{sala}/{idimdb}",
               defaults: new { controller = "Funciones", action = "Index", id = UrlParameter.Optional, sala = UrlParameter.Optional, idimdb = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Func2",
               url: "{controller}/{action}/{id}/{idimdb}",
               defaults: new { controller = "Funciones", action = "Index", id = UrlParameter.Optional, idimdb = UrlParameter.Optional }
           );
            routes.MapRoute(
            name: "TmdbApi",
            url: "TmdbApi/{id}/",
            defaults: new { controller = "TmdbApi", action = "GetPerson", id = "" },
            constraints: new { id = @"^[0-9]+$" }
            );
            routes.MapRoute(
                name: "TmdbApiPaging",
                url: "TmdbApi/{peopleName}/{page}",
                defaults: new { controller = "TmdbApi", action = "Index", peopleName = "", page = "" },
                constraints: new { peopleName = @"^[a-zA-Z]+$", page = @"^[0-9]+$" }
            );
        }
    }
}
