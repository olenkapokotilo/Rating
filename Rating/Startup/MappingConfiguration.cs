using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using R = Rating.Models;
using D = Domain.Entities;


namespace Rating
{
    public class MappingConfiguration
    {
        public static void RegisterMapping()
        {
            RegisterFromRatingModelsToDomain();
            RegisterFromDomainToRatingModels();
            Mapper.AssertConfigurationIsValid();
        }

        private static void RegisterFromRatingModelsToDomain()
        {
            Mapper.CreateMap<R.ProjectModel, D.Project>();
            Mapper.CreateMap<R.UserModel, D.User>();
            Mapper.CreateMap<R.RoleModel, D.Role>();
           
        }

        private static void RegisterFromDomainToRatingModels()
        {
            Mapper.CreateMap<D.Project, R.ProjectModel>();
            Mapper.CreateMap<D.User, R.UserModel>();
            Mapper.CreateMap<D.Role, R.RoleModel>();
        }

    }
}