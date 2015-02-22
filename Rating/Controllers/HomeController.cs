﻿using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rating.Models;
using Domain.Repositories.Interfaces;
using System.Web.Security;

namespace Rating.Controllers
{
    
    [Authorize]
    public class HomeController : Controller
    {
        private IUserRepository _userRepository;
        
        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {

            //var user = _provider.CreateUser();
            
            return View(_userRepository.GetAllUsers().Select(u=> UserModel.FromDomainModel(u)));
        }

        public ActionResult About(int id)
        {
            return View(UserModel.FromDomainModel(_userRepository.GetUser(id)));
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}