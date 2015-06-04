using Domain.Repositories.Interfaces;
using AutoMapper;
using Rating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

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
        public ActionResult Details(ProjectModel newProject)
        {
            return View(newProject);
        }
        public ActionResult Edit(int id) 
        {
            return View(ProjectModel.FromDomainModel(_projectRepository.GetProject(id)));
        }
        
        [HttpPost]
        public ActionResult Edit(ProjectModel project) 
        {   try
            {
                _projectRepository.Edit(Mapper.Map<Domain.Entities.Project>(project));
             }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                return Redirect("/Share/Error?message" + e);
            }
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
            try
            {
                newProject.UserId = Convert.ToInt32(HttpContext.Request.Cookies["userId"].Value);
                _projectRepository.Create(newProject.ToDomainModel());
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                return Redirect("/Share/Error?message" + e);
            }
            return Redirect("/Project/List");
        }

        public ActionResult Delete(int id)
        {
            _projectRepository.Delete(id);
            return Redirect("~/Project/List/");
        }
    }
}