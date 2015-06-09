using AutoMapper;
using DataAccess.Model;
using Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BadgeTypeRepository :IBadgeTypeRepository
    {
        public Domain.Entities.BadgeType GetBadgeType(int id) 
        {
            using (var entities = new Entities()) 
            {
                var badgeType = entities.BadgeType.SingleOrDefault(at => at.Id == id);
                var result = Mapper.Map<Domain.Entities.BadgeType>(badgeType);
                return result;
            }
        }
        public IEnumerable<Domain.Entities.BadgeType> GetAllBadgeTypeByRatingType(int id) 
        {
            using (var entities = new Entities())
            {
                var dbBadgeType = entities.BadgeType.Where(at => at.RatingTypeId == id);
                var result = Mapper.Map<IEnumerable<Domain.Entities.BadgeType>>(dbBadgeType);
                return result;
            }
        }
        public void Create(Domain.Entities.BadgeType badgeType) 
        {
            using (var entities = new Entities())
            {
                entities.BadgeType.Add(Mapper.Map<DataAccess.Model.BadgeType>(badgeType));
                entities.SaveChanges();
            }
        }
        public void Delete(int id) 
        {
            using (var entities = new Entities())
            {
                var badgeType = this.GetBadgeType(id);
                entities.Entry(Mapper.Map<DataAccess.Model.BadgeType>(badgeType)).State = EntityState.Deleted;
                entities.SaveChanges();
            }
        }
    }
}
