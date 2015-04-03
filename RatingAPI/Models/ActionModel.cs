using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatingAPI.Models
{
    public class ActionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int ActionTypeId { get; set; }
        public int ProjectUserId { get; set; }
        public int? RatingId { get; set; }

        public static ActionModel FromDomainModel(Domain.Entities.Action domainAction)
        {
            return Mapper.Map<ActionModel>(domainAction);
        }

        public Domain.Entities.Action ToDomainModel()
        {
            return Mapper.Map<Domain.Entities.Action>(this);
        }
    }
}