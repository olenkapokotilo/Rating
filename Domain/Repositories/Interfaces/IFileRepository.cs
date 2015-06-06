using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    interface IFileRepository
    {
        Domain.Entities.File GetFile(int id);
        void Create(Domain.Entities.File file);
        void Delete(int id);
    }
}
