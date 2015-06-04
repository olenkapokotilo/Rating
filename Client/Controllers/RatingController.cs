using Client.Models;
using Client.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class RatingController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Rating
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Active() 
        {
            var rating = new EventService();
            var list = rating.GetRatingList();
            List<RatingListModel> ratingList = JsonConvert.DeserializeObject<List<RatingListModel>>(list);

            var userIds = ratingList.Select(r => r.ExternalUserId).ToArray();
            var users = db.Users.Where(u => userIds.Contains(u.Id.ToString())).ToList();

            foreach (var r in ratingList) 
            {
                r.User = users.SingleOrDefault(u => u.Id.ToString() == r.ExternalUserId);
            }
            return View(ratingList);
        }
    }
}