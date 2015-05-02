using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Repositories.Interfaces;
using DataAccess.Model;
using RatingAPI.Models;
using Newtonsoft.Json;
using AutoMapper;
using System.Web.Http;

namespace RatingAPI.Controllers
{
    public class UserController : ApiController
    {
        private IProjectUserRepository _projectUserRepository;

        public UserController(IProjectUserRepository projectUserRepository)
        {
            _projectUserRepository = projectUserRepository;
        }
        // GET: User
        [HttpPost]
        public void Create(ProjectUserModel projectUser)
        {
            _projectUserRepository.Create(projectUser.ToDomainModel());
        }
    }
}