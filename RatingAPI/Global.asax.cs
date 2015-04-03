﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using RatingAPI.CompositionRoot;

namespace RatingAPI
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
            DependencyResolver.SetResolver(new Autofac.Integration.WebApi.AutofacWebApiDependencyResolver(AutofacContainerFactory.GetContainer()));
            DataAccess.Startup.MappingConfiguration.RegisterMapping();
            RatingAPI.ApiStartup.MappingConfiguration.RegisterMapping();
        }
    }
}
