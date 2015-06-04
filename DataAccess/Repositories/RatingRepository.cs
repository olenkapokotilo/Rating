using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories.Interfaces;
using DataAccess.Model;
using AutoMapper;
using System.Data.Entity;

namespace DataAccess.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        public Domain.Entities.Rating GetRating(int ratingTypeId, int projectUserId)
        {
            using (var entities = new Entities())
            {
                var rating = entities.Rating.SingleOrDefault(r => r.RatingTypeId == ratingTypeId && r.ProjectUserId == projectUserId);
                var result = Mapper.Map<Domain.Entities.Rating>(rating);
                return result;

            }
        }
        public Domain.Entities.Rating Create(Domain.Entities.Rating rating)
        {
            using (var entities = new Entities())
            {
                rating.Name = "rating"; 
                var newRating = entities.Rating.Add(Mapper.Map<DataAccess.Model.Rating>(rating));
                entities.SaveChanges();
                return newRating.ToDomain();
            }
        }
        public void Update(Domain.Entities.Rating newRating) 
        {
            using (var entities = new Entities()) 
            {
                var rating = this.GetRating(newRating.RatingTypeId, newRating.ProjectUserId);
                rating.Score = newRating.Score;
                entities.Entry(Mapper.Map<DataAccess.Model.Rating>(rating)).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }
        public IEnumerable<Domain.Entities.Rating> GetRatingsByRatingTypeId(int ratingTypeId) 
        {
            using (var entities = new Entities()) 
            {
                IEnumerable<Rating> rating = entities.Rating.Where(r => r.RatingTypeId == ratingTypeId).ToList();
                var result = Mapper.Map<IEnumerable<Domain.Entities.Rating>>(rating);
                return result;
            }
        }

    }
    public static class RatingDataModelExtensions
    {
        public static Domain.Entities.Rating ToDomain(this Rating dataModel)
        {
            return Mapper.Map<Domain.Entities.Rating>(dataModel);
        }
    }
}
