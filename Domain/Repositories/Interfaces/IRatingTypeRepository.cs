using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IRatingTypeRepository
    {
        IEnumerable<Domain.Entities.RatingType> GetAllRatingType();
    }
}
