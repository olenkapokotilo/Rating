using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rating.Models
{
    public class ActionTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Scores { get; set; }
        public int RatingTypeId { get; set; }

        public static ActionTypeModel FromDomainModel(Domain.Entities.ActionType domainActionType)
        {
            return Mapper.Map<ActionTypeModel>(domainActionType);
        }

        public Domain.Entities.ActionType ToDomainModel()
        {
            return Mapper.Map<Domain.Entities.ActionType>(this);
        }
    }
}