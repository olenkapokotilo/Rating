using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using Domain.Repositories.Interfaces;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Repositories
{
    public class ProjectRepository: IProjectRepository

    {
        public Domain.Entities.Project GetProject(int id) 
        {
            using (var entities = new Entities())
            {
                var dbProject = entities.Project.Single(p=>p.Id == id);
                var result = Mapper.Map<Domain.Entities.Project>(dbProject);
                return result;
            }
        }
        public IEnumerable<Domain.Entities.Project> GetAllProject()
        {
            using (var entities = new Entities())
            {
                var dbProject = entities.Project.ToList();
                var result = Mapper.Map<IEnumerable<Domain.Entities.Project>>(dbProject);
                return result;
            }
        }
        public Domain.Entities.Project GetProjectByName(string name) 
        {
            using(var entities = new Entities())
            {
                var dbProject = entities.Project.Single(p => p.Name == name);
                var result = Mapper.Map<Domain.Entities.Project>(dbProject);
                return result;
            }
        }
        public void Edit(Domain.Entities.Project newProject)
        {
            using (var entities = new Entities()) 
            {
                var project = this.GetProject(newProject.Id);
                project.Name = newProject.Name;
                project.User.Id = newProject.User.Id;
                entities.Entry(Mapper.Map<DataAccess.Model.Project>(project)).State = EntityState.Modified;
                entities.SaveChanges();

            }
        }
        public IEnumerable<Domain.Entities.Project> GetAllProjectByUserId(int userId)
        {
            using (var entities = new Entities()) 
            {
                var projects = this.GetAllProject();
                var result = projects.Where(p => p.User.Id == userId);
                return result;

            }
        }
    }
}
