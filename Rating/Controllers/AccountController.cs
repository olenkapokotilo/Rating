using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Rating.Models;
using Domain.Repositories.Interfaces;
using Rating.Providers;
using System.Web.Security;

namespace Rating.Controllers
{
   
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string Email, string Password) 
        {
            if (Membership.ValidateUser(Email, Password) == true)
            {
                FormsAuthentication.SetAuthCookie(Email, false);
                return Redirect("/Home/Index"); //what's view you return here??
            }
            else 
            {
                return Redirect("/Account/Login"); //why to do redirect its still a "Login" method?
            }
            
        }
        public ActionResult LogOff() 
        {
            FormsAuthentication.SignOut();
            return Redirect("/Account/Login");
        }
    }
}