using ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiClient.Controllers
{
    public class CommentController : Controller
    {
        ClientContext db = new ClientContext();
        // GET: Comment
        public ActionResult Index()
        {
            return View(db.Comments);
        }
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Comment comment) 
        {
            db.Comments.Add(comment);
            db.SaveChanges();
            return Redirect("/Comment/Index");
        }
    }
}