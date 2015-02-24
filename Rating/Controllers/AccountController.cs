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
using Rating.Services;

namespace Rating.Controllers
{
   
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        //private C
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Password, bool forgotpass) 
            {
                if (forgotpass == true)
                {
                    var user = _userRepository.GetUserByEmail(Email);
                    if (user != null)
                    {
                        EmailService.SendForgottenPassword(user.Email, user.Password);
                        return View();
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("No user with the email '{0}' exists.", Email));
                    }
                }
                else { 
                if (Membership.ValidateUser(Email, Password) == true)
                {
                    FormsAuthentication.SetAuthCookie(Email, false);
                    return Redirect("/Home/Index"); 
                }
                else 
                {
                    return View();
                }
            }
        }
        public ActionResult LogOff() 
        {
            FormsAuthentication.SignOut();
            return Redirect("/Account/Login");
        }
        
        [AllowAnonymous]
        public ActionResult Register() 
        {
            return View();
        }
         [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(string Email, string Password) 
        {
            
            MembershipUser newUser = Membership.CreateUser(Email, Password);
            FormsAuthentication.SetAuthCookie(Email, false);
            return Redirect("/Home/Index");
        }
         [Authorize] 
         public ActionResult ChangePassword() 
         {
             ViewBag.Cookie_0 = HttpContext.Response.Cookies["Email"];
             return View(ViewBag.Cookie_0);
         }
        [Authorize]
        [HttpPost]
         public ActionResult ChangePassword(string Email, string oldPassword, string newPassword, string newRepeatPassword, bool forgot) 
        {
            
            if (Membership.ValidateUser(Email, oldPassword) == true)
            {
                _userRepository.ChangePassword(newPassword, newRepeatPassword, Email);
                return Redirect("/Account/LogOff"); //what's view you return here??
            }
            return Redirect("/Account/ChangePassword");
        }

        [AllowAnonymous]
        public string Confirm(string Email)
        {
            return "На почтовый адрес " + Email + " Вам высланы дальнейшие" +
                    "инструкции по завершению регистрации";
        } 

    }
}