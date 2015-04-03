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
            Mapper.CreateMap<DA.RatingType, D.RatingType>();
            Mapper.CreateMap<DA.ActionType, D.ActionType>();
            Mapper.CreateMap<DA.Action, D.Action>();
            Mapper.CreateMap<DA.Rating, D.Rating>();
            Mapper.CreateMap<DA.ProjectUser, D.ProjectUser>();
        }

        private static void RegisterFromDomainToDataAccess()
        {
            Mapper.CreateMap<D.User, DA.User>()
                    .ForMember(daRole=> daRole.Role, opt=> opt.Ignore());
            Mapper.CreateMap<D.Project, DA.Project>()
                    .ForMember(daProject => daProject.User, opt => opt.Ignore());
            Mapper.CreateMap<D.Role, DA.Role>()
                .ForMember(daRole => daRole.User, opt => opt.Ignore());
            Mapper.CreateMap<D.RatingType, DA.RatingType>()
                    .ForMember(daRatingType => daRatingType.Project, opt => opt.Ignore());
            Mapper.CreateMap<D.ActionType, DA.ActionType>()
                    .ForMember(daActionType => daActionType.RatingType, opt => opt.Ignore());
        }
    }
}
