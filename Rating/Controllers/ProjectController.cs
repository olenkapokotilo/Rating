﻿using Domain.Repositories.Interfaces;
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
        public ActionResult Index(int id)
        {
            return View(_projectRepository.GetAllProject(id).Select(p=> ProjectModel.FromDomainModel(p)));
        }
        public ActionResult Edit(int id) 
        {
            return View(ProjectModel.FromDomainModel(_projectRepository.GetProject(id)));
        }
        [HttpPost]
        public ActionResult Edit(ProjectModel project) 
        {
            _projectRepository.Edit(Mapper.Map<Domain.Entities.Project>(project));
            return Redirect("/Project/Index");
        }
        [Authorize]
        public ActionResult ProjectMenu() 
        {
            return View(_projectRepository.GetAllProjectByUserId(id).Select(p => ProjectModel.FromDomainModel(p)));
            
        }
    }
}