using Autofac;
using Autofac.Integration.Mvc;
using Domain.Repositories.Interfaces;
using Rating.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Rating.CompositionRoot
{
    public static class AutofacContainerFactory
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DataAccess.Repositories.UserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<DataAccess.Repositories.RoleRepository>().As<IRoleRepository>().SingleInstance();
            builder.RegisterType<DataAccess.Repositories.ProjectRepository>().As<IProjectRepository>().SingleInstance();
            builder.RegisterType<DataAccess.Repositories.RatingTypeRepository>().As<IRatingTypeRepository>().SingleInstance();
            builder.RegisterType<DataAccess.Repositories.ActionTypeRepository>().As<IActionTypeRepository>().SingleInstance();
            builder.RegisterType<DataAccess.Repositories.BadgeTypeRepository>().As<IBadgeTypeRepository>().SingleInstance();
            builder.RegisterType<DataAccess.Repositories.FileRepository>().As<IFileRepository>().SingleInstance();



            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            return builder.Build();
        }
    }
}