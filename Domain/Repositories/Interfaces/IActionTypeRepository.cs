using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IActionTypeRepository
    {
        Domain.Entities.ActionType GetActionType(int id);
        IEnumerable<Domain.Entities.ActionType> GetAllActionType();
        IEnumerable<Domain.Entities.ActionType> GetAllActionTypeByRatingType(int id);
        Domain.Entities.ActionType GetActionTypeByNameAndRatingTypeId(string name, int ratingTypeId);
        void Edit(Domain.Entities.ActionType actionType);
        void Create(Domain.Entities.ActionType actionType);
        void Delete(int id);
    }
}
