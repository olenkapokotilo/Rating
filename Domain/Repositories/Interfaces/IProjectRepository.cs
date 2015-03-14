using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Project GetProject(int id);
        IEnumerable<Domain.Entities.Project> GetAllProject();
        Project GetProjectByName(string name);
        IEnumerable<Domain.Entities.Project> GetAllProjectByUserId(int userId);
        void Edit(Domain.Entities.Project project);
        void Create(Domain.Entities.Project project);
        void Delete(int id);

    }
}
