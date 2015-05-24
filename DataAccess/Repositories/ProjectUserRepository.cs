using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories.Interfaces;
using DataAccess.Model;
using AutoMapper;

namespace DataAccess.Repositories
{
    public class ProjectUserRepository : IProjectUserRepository
    {
        public Domain.Entities.ProjectUser GetProjectUser(int id)
       {
            using(var entities = new Entities())
            {
                var projectUser = entities.ProjectUser.SingleOrDefault(pu => pu.Id == id);
                var result = Mapper.Map<Domain.Entities.ProjectUser>(projectUser);
                return result;
    
            }
       }
       public bool ExistProjectUser(int id) 
       {
           using (var entities = new Entities())
           {
               var exist = entities.ProjectUser.SingleOrDefault(pu => pu.Id == id);
               if (exist == null) 
               {
                   return false;
               }
               else 
               {
                   return true;
               }
           }
       }
       public Domain.Entities.ProjectUser Create(Domain.Entities.ProjectUser projectUser) 
       {
           using (var entities = new Entities())
           {
               var newProjectUser = entities.ProjectUser.Add(AutoMapper.Mapper.Map<DataAccess.Model.ProjectUser>(projectUser));
               entities.SaveChanges();
               return Mapper.Map<Domain.Entities.ProjectUser>(newProjectUser);

           }
       }
       public Domain.Entities.ProjectUser GetProjectUserByName(string name)
       {
           using (var entities = new Entities())
           {
               var projectUser = entities.ProjectUser.SingleOrDefault(pu => pu.Name == name);
               var result = Mapper.Map<Domain.Entities.ProjectUser>(projectUser);
               return result;

           }
       }
    }
}
