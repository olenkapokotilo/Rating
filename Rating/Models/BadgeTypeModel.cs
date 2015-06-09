using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rating.Models
{
    public class BadgeTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Scores { get; set; }
        public int RatingTypeId { get; set; }
        public int FileId { get; set; }
        public byte[] Image { get; set; }
        
        public static BadgeTypeModel FromDomainModel(Domain.Entities.BadgeType domainBadgeType)
        {
            return Mapper.Map<BadgeTypeModel>(domainBadgeType);
        }

        public Domain.Entities.BadgeType ToDomainModel()
        {
            return Mapper.Map<Domain.Entities.BadgeType>(this);
        }
    }
}