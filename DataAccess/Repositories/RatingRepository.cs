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
        //public bool ExistRating(int idRatingType, int idProjectUser)
        //{
        //    using (var entities = new Entities())
        //    {
        //        var exist = entities.Rating.SingleOrDefault(r=> r.ProjectUserId == idProjectUser && r.RatingTypeId == idRatingType);
        //        if (exist == null)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //}
        public Domain.Entities.Rating GetRating(int idRatingType, int projectUserId)
        {
            using (var entities = new Entities())
            {
                var rating = entities.Rating.SingleOrDefault(r => r.RatingTypeId == idRatingType && r.ProjectUserId == projectUserId);
                var result = Mapper.Map<Domain.Entities.Rating>(rating);
                return result;

            }
        }
        public void Create(Domain.Entities.Rating rating)
        {
            using (var entities = new Entities())
            {
                entities.Rating.Add(AutoMapper.Mapper.Map<DataAccess.Model.Rating>(rating));
                entities.SaveChanges();

            }
        }
        //public void Create(string name, int score, int RatingTypeId, int ProjectUserId)
        //{
        //    using (var entities = new Entities())
        //    {
        //        Domain.Entities.Rating rating = new Domain.Entities.Rating
        //        entities.Rating.Add(AutoMapper.Mapper.Map<DataAccess.Model.Rating>(rating));
        //        entities.SaveChanges();

        //    }
        //}
    }
}
