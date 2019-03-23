using SugarFreeDiet.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SugarFreeDiet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();
            
            routes.Add("RecipeDetails", new SeoFriendlyRoute("Recipes/Details/{id}",
            new RouteValueDictionary(new { controller = "Recipes", action = "Details" }),
            new MvcRouteHandler()));

            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Recipes", action = "Index", id = UrlParameter.Optional });
        }
    }
}
