﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DA = DataAccess.Model;
using D = Domain.Entities;

namespace DataAccess.Startup
{
    public static class MappingConfiguration
    {
        public static void RegisterMapping()
        {
            RegisterFromDataAccessToDomain();
            RegisterFromDomainToDataAccess();
            Mapper.AssertConfigurationIsValid();
        }

        private static void RegisterFromDataAccessToDomain()
        {
            Mapper.CreateMap<DA.User, D.User>();
            Mapper.CreateMap<DA.Project, D.Project>();
            Mapper.CreateMap<DA.Role, D.Role>();
        }

        private static void RegisterFromDomainToDataAccess()
        {
            Mapper.CreateMap<D.User, DA.User>()
                    .ForMember(daRole=> daRole.Role, opt=> opt.Ignore());
            Mapper.CreateMap<D.Project, DA.Project>();
            Mapper.CreateMap<D.Role, DA.Role>()
                    .ForMember(daRole => daRole.Users, opt => opt.Ignore());
        }
    }
}
