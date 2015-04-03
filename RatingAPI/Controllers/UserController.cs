using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Repositories.Interfaces;
using DataAccess.Model;

namespace RatingAPI.Controllers
{
    public class UserController : Controller
    {
        private IProjectUserRepository _projectUserRepository;
        
        public UserController(IProjectUserRepository projectUserRepository)
        {
            _projectUserRepository = projectUserRepository;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}