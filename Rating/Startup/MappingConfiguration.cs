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
            Mapper.CreateMap<R.RatingTypeModel, D.RatingType>();
            Mapper.CreateMap<R.ActionTypeModel, D.ActionType>();
            Mapper.CreateMap<R.BadgeTypeModel, D.BadgeType>()
                .ForMember(dBadgeType => dBadgeType.RatingType, otp => otp.Ignore())
                .ForMember(dBadgeType => dBadgeType.File, otp => otp.Ignore());
           
        }

        private static void RegisterFromDomainToRatingModels()
        {
            Mapper.CreateMap<D.Project, R.ProjectModel>();
            Mapper.CreateMap<D.User, R.UserModel>();
            Mapper.CreateMap<D.Role, R.RoleModel>();
            Mapper.CreateMap<D.RatingType, R.RatingTypeModel>();
            Mapper.CreateMap<D.ActionType, R.ActionTypeModel>();
            Mapper.CreateMap<D.BadgeType, R.BadgeTypeModel>()
                .ForMember(rBadgeTypeModel => rBadgeTypeModel.Image, otp=> otp.Ignore());

        }

    }
}