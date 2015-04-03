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
       public void GetProjectUser(int id)
       {
            using(var entities = new Entities())
            {
    
            }
       }
       public void Create(Domain.Entities.ProjectUser projectUser) 
       {
           using (var entities = new Entities())
           {
               entities.ProjectUser.Add(AutoMapper.Mapper.Map<DataAccess.Model.ProjectUser>(projectUser));
               entities.SaveChanges();

           }
       }
    }
}
