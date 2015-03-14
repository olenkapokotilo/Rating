using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rating.Models
{
    public class RatingTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public ICollection<ActionTypeModel> ActionTypes { get; set; }
        public static RatingTypeModel FromDomainModel(Domain.Entities.RatingType domainRatingType)
        {
            return Mapper.Map<RatingTypeModel>(domainRatingType);
        }

        public Domain.Entities.RatingType ToDomainModel()
        {
            return Mapper.Map<Domain.Entities.RatingType>(this);
        }
    }
}