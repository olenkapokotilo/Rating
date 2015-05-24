using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IProjectUserRepository
    {
        void GetProjectUser(int id);
        public bool ExistProjectUser(int id);
        void Create(Domain.Entities.ProjectUser projectUser);
        public Domain.Entities.ProjectUser GetProjectUserByName(string name);
    }
}
