using AutoMapper;
using DataAccess.Model;
using Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public Domain.Entities.Role GetRole(int id)
        {
            using (var entities = new Entities())
            {
                var dbRole = entities.Role.Single(r => r.Id == id);
                var result = Mapper.Map<Domain.Entities.Role>(dbRole);
                return result;
            }
        }

        public List<Domain.Entities.Role> GetAllRoles()
        {
            using (var entities = new Entities())
            {
                var dbRoles = entities.Role.ToList();
                IEnumerable<Domain.Entities.Role> result = Mapper.Map<IEnumerable<Domain.Entities.Role>>(dbRoles);
                return result.ToList();
            }
        }
    }
}
