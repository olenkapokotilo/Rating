﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Rating
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "RatingType",
                url: "Poject/{projectId}/RatingType/{action}/{id}",
                defaults: new { controller = "RatingType", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "ActionType",
               url: "RatingType/{ratingTypeId}/ActionType/{action}/{id}",
               defaults: new { controller = "ActionType", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
