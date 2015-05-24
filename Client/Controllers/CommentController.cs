using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Client.Services;

namespace Client.Controllers
{
    public class CommentController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        string path = "http://localhost:2250/api/User/Create";
        // GET: Comment
        public ActionResult List()
        {
            return View(db.Comments.ToList());
        }
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Comment newComment)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                newComment.UserId = User.Identity.GetUserId(); 
                 db.Comments.Add(newComment);
                 db.SaveChanges();
                 //eventService.Comment(newComment.UserId);
                //var request = new JsonRequestService(path);
                // request.Post("{actionType:'comment', raitntgType:'Active'}");
            }
            
            return Redirect("/Comment/List");
        }
    }
}