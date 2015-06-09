using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface IFileRepository
    {
        Domain.Entities.File GetFile(int id);
        int Create(byte[] image);
        void Delete(int id);
    }
}
