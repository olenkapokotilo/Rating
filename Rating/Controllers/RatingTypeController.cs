using System;
using Rating.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Repositories.Interfaces;

namespace Rating.Controllers
{
    public class RatingTypeController : Controller
    {
        private IRatingTypeRepository _ratingTypeRepository;

        public RatingTypeController(IRatingTypeRepository ratingTypeRepository)
        {
            _ratingTypeRepository = ratingTypeRepository;
        }
        // GET: RatingType
        public ActionResult Index()
        {
            return PartialView(_ratingTypeRepository.GetAllRatingType().Select(rt=> RatingTypeModel.FromDomainModel(rt)));
        }
    }
}