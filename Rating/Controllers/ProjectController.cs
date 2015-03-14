using Domain.Repositories.Interfaces;
using AutoMapper;
using Rating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rating.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRepository _projectRepository;
        
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        // GET: Project
        public ActionResult List()
        {
            return View( _projectRepository.GetAllProject().Select(p=> ProjectModel.FromDomainModel(p)));
        }
        public ActionResult Edit(int id) 
        {
            return View(ProjectModel.FromDomainModel(_projectRepository.GetProject(id)));
        }
        [HttpPost]
        public ActionResult Edit(ProjectModel project) 
        {
            _projectRepository.Edit(Mapper.Map<Domain.Entities.Project>(project));
            return Redirect("/Project/List");
        }
        [Authorize]
        public ActionResult ProjectMenu()
        {
            int id = Convert.ToInt32(HttpContext.Request.Cookies["userId"].Value);
            return PartialView(_projectRepository.GetAllProjectByUserId(id).Select(p => ProjectModel.FromDomainModel(p)));

        }
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProjectModel newProject) 
        {
                newProject.UserId = Convert.ToInt32(HttpContext.Request.Cookies["userId"].Value);
                _projectRepository.Create(newProject.ToDomainModel());
                return Redirect("/Project/List");
        }
        public void Delete(int id)
        {
            _projectRepository.Delete(id);
        }
    }
}