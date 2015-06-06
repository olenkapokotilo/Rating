using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    interface IFileRepository
    {
        void Create(Domain.Entities.File badgeType);
        void Delete(int id);
    }
}
