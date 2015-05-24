using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Domain.Entities.Rating GetRating(int idRatingType, int projectUserId);
        Domain.Entities.Rating Create(Domain.Entities.Rating rating);
        //public bool ExistRating(int idRatingType, int idProjectUser);
    }
}
