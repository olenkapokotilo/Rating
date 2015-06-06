using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    interface IBadgeTypeRepository
    {
        Domain.Entities.BadgeType GetBadgeType(int id);
        IEnumerable<Domain.Entities.BadgeType> GetAllBadgeTypeByRatingType(int id);
        void Create(Domain.Entities.BadgeType badgeType);
        void Delete(int id);
    }
}
