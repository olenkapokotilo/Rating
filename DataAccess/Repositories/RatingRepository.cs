using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories.Interfaces;
using DataAccess.Model;
using AutoMapper;

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
                var newRating = entities.Rating.Add(AutoMapper.Mapper.Map<DataAccess.Model.Rating>(rating));
                entities.SaveChanges();
                return newRating.ToDomain();
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
