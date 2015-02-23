using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
     public interface IRoleRepository
    {
        Role GetRole(int id);

        List<Role> GetAllRoles();
    }
}
