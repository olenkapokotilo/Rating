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
    }
}
