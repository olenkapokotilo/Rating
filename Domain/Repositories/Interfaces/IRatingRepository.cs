using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        public Domain.Entities.Rating GetRating(int idRatingType, int projectUserId);
        void Create(Domain.Entities.Rating rating);
        //public bool ExistRating(int idRatingType, int idProjectUser);
    }
}
