using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Domain.Entities.Rating GetRating(int ratingTypeId, int projectUserId);
        Domain.Entities.Rating Create(Domain.Entities.Rating rating);
        void Update(Domain.Entities.Rating newRating);
        //public bool ExistRating(int idRatingType, int idProjectUser);
    }
}
