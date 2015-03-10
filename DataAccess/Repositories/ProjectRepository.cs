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
                var dbProject = entities.Project.SingleOrDefault(p => p.Name == name);
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
                project.UserId = newProject.UserId;
                entities.Entry(Mapper.Map<DataAccess.Model.Project>(project)).State = EntityState.Modified;
                entities.SaveChanges();

            }
        }
        public IEnumerable<Domain.Entities.Project> GetAllProjectByUserId(int userId)
        {
            using (var entities = new Entities()) 
            {
                var projects = entities.Project.Where(p => p.UserId == userId).ToList();
                var result = Mapper.Map<IEnumerable<Domain.Entities.Project>>(projects);
                return result;

            }
        }
        public void Create(Domain.Entities.Project project) 
        {
            using (var entities = new Entities()) 
            {
                entities.Project.Add(Mapper.Map<DataAccess.Model.Project>(project));
                entities.SaveChanges();
            }
        }
    }
}
