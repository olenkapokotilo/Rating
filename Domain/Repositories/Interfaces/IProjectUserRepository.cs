using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IProjectUserRepository
    {
        Domain.Entities.ProjectUser GetProjectUser(int id);
        bool ExistProjectUser(int id);
        Domain.Entities.ProjectUser Create(Domain.Entities.ProjectUser projectUser);
        Domain.Entities.ProjectUser GetProjectUserByName(string name);
        Domain.Entities.ProjectUser GetProjectUserByExternalId(string externalId);
    }
}
