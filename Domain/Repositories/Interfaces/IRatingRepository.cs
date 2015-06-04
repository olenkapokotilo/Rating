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
        IEnumerable<Domain.Entities.Rating> GetRatingsByRatingTypeId(int ratingTypeId);
        void Update(Domain.Entities.Rating newRating);
        //Domain.Entities.RatingType GetRatingTypeByNameAndProjectId(string name, int projectId);
    }
}
