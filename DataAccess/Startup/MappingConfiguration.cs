using AutoMapper;
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
            //Mapper.CreateMap<DA.Action, D.Action>();
            Mapper.CreateMap<DA.Rating, D.Rating>();
            Mapper.CreateMap<DA.ProjectUser, D.ProjectUser>();
            Mapper.CreateMap<DA.BadgeType, D.BadgeType>();
            Mapper.CreateMap<DA.File, D.File>();
        }

        private static void RegisterFromDomainToDataAccess()
        {
            Mapper.CreateMap<D.User, DA.User>()
                    .ForMember(daRole=> daRole.Role, opt=> opt.Ignore());
            Mapper.CreateMap<D.Project, DA.Project>()
                 .ForMember(daProject => daProject.ProjectUser, opt => opt.Ignore())
                    .ForMember(daProject => daProject.User, opt => opt.Ignore());
            Mapper.CreateMap<D.Role, DA.Role>()
                 .ForMember(daRole => daRole.User, opt => opt.Ignore());
            Mapper.CreateMap<D.RatingType, DA.RatingType>()
                    .ForMember(daRatingType => daRatingType.Rating, opt => opt.Ignore())
                    .ForMember(daRatingType => daRatingType.Project, opt => opt.Ignore());
            Mapper.CreateMap<D.ActionType, DA.ActionType>()
                    .ForMember(daActionType => daActionType.Action, opt => opt.Ignore())
                    .ForMember(daActionType => daActionType.RatingType, opt => opt.Ignore());
            Mapper.CreateMap<D.ProjectUser, DA.ProjectUser>()
                    .ForMember(daProjectUser => daProjectUser.Action, opt => opt.Ignore())
                    .ForMember(daProjectUser => daProjectUser.Rating, opt => opt.Ignore())
                    .ForMember(daProjectUser => daProjectUser.Project, opt => opt.Ignore());
          Mapper.CreateMap<D.Rating, DA.Rating>()
                     .ForMember(daRating => daRating.Action, opt => opt.Ignore())
                    .ForMember(daRating => daRating.ProjectUser, opt => opt.Ignore())
                    .ForMember(daRating => daRating.RatingType, opt => opt.Ignore());
          Mapper.CreateMap<D.BadgeType, DA.BadgeType>();
          Mapper.CreateMap<D.File, DA.File>();
          //Mapper.CreateMap<D.Action, DA.Action>()
          //          .ForMember(daAction => daAction.Rating, opt => opt.Ignore())
          //          .ForMember(daAction => daAction.ProjectUser, opt => opt.Ignore())
          //          .ForMember(daAction => daAction.ActionType, opt => opt.Ignore());
        }
    }
}
