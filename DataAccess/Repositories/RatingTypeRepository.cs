using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using DataAccess.Model;
using Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace DataAccess.Repositories
{
    public class RatingTypeRepository : IRatingTypeRepository
    {
        public IEnumerable<Domain.Entities.RatingType> GetAllRatingType() 
        {
            using (var entities = new Entities()) 
            {
                IEnumerable<DataAccess.Model.RatingType> dbRatingType = entities.RatingType.ToList();
                IEnumerable<Domain.Entities.RatingType> result = Mapper.Map<IEnumerable<Domain.Entities.RatingType>>(dbRatingType);
                return result;
            }
        }

        public Domain.Entities.RatingType GetRatingType(int id)
        {
            using (var entities = new Entities())
            {
                var ratingType = entities.RatingType.SingleOrDefault( rt=>rt.Id == id);
                var result = Mapper.Map<Domain.Entities.RatingType>(ratingType);
                return result;

            }
        }
        public Domain.Entities.RatingType GetRatingTypeByNameAndProjectId(string name, int projectId)
        {
            using (var entities = new Entities())
            {
                return Mapper.Map<Domain.Entities.RatingType>(entities.RatingType.SingleOrDefault(rt =>rt.ProjectId == projectId && rt.Name == name));
            }
        }

        public void Edit(Domain.Entities.RatingType newRatingType)
        {
            using (var entities = new Entities())
            {
                var ratingType = this.GetRatingType(newRatingType.Id);
                ratingType.Name = newRatingType.Name;
                entities.Entry(Mapper.Map<DataAccess.Model.RatingType>(ratingType)).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var entities = new Entities())
            {
                var ratingType = this.GetRatingType(id);
                entities.Entry(Mapper.Map<DataAccess.Model.RatingType>(ratingType)).State = EntityState.Deleted;
                entities.SaveChanges();
            }
        }

        public Domain.Entities.RatingType Create(Domain.Entities.RatingType ratingType)
        {
            using (var entities = new Entities())
            {
                var newRatingType = entities.RatingType.Add(Mapper.Map<DataAccess.Model.RatingType>(ratingType));
                entities.SaveChanges();
                return Mapper.Map<Domain.Entities.RatingType>(newRatingType);
            }
        }
    }
}
