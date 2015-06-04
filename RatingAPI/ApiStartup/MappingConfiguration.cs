using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using R_API = RatingAPI.Models;
using D = Domain.Entities;
namespace RatingAPI.ApiStartup
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
            //Mapper.CreateMap<R_API.ActionModel, D.Action>();
            Mapper.CreateMap<R_API.RatingModel, D.Rating>();
            Mapper.CreateMap<R_API.ProjectUserModel, D.ProjectUser>();
        }

        private static void RegisterFromDomainToRatingModels()
        {
            //Mapper.CreateMap<D.Action, R_API.ActionModel>();
            Mapper.CreateMap<D.Rating, R_API.RatingModel>();
            Mapper.CreateMap<D.ProjectUser, R_API.ProjectUserModel>();
            Mapper.CreateMap<D.Rating, R_API.RatingListModel>()
                .ForMember(apiModel => apiModel.ExternalUserId, opt => opt.MapFrom(domainModel => domainModel.ProjectUser.ExternalId))
                .ForMember(apiModel => apiModel.Scores, opt => opt.MapFrom(domainModel => domainModel.Score));

        }

    }
}