
using Autofac.Integration.WebApi;
using Domain.Repositories.Interfaces;
using RatingAPI.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Domain.Services;

namespace RatingAPI.CompositionRoot
{
    public static class AutofacContainerFactory
    {
        public static Autofac.IContainer GetContainer() 
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DataAccess.Repositories.RatingTypeRepository>().As<IRatingTypeRepository>().SingleInstance();
            builder.RegisterType<DataAccess.Repositories.ActionTypeRepository>().As<IActionTypeRepository>().SingleInstance();
            builder.RegisterType<DataAccess.Repositories.RatingRepository>().As<IRatingRepository>().SingleInstance();
            builder.RegisterType<DataAccess.Repositories.ActionRepository>().As<IActionRepository>().SingleInstance();
            builder.RegisterType<DataAccess.Repositories.ProjectUserRepository>().As<IProjectUserRepository>().SingleInstance();
            builder.RegisterType<Domain.Services.ActionService>().As<ActionService>().SingleInstance();


            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            return builder.Build();
        }
    }
}