using System;
using Rating.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Repositories.Interfaces;
using  AutoMapper;

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

        public ActionResult Edit(string id)
        {
            int ratingTypeId = Convert.ToInt32(id);
            return PartialView(RatingTypeModel.FromDomainModel(_ratingTypeRepository.GetRatingType(ratingTypeId)));
        }

        [HttpPost]
        public ActionResult Edit(Rating.Models.RatingTypeModel ratingType)
        {
            _ratingTypeRepository.Edit(Mapper.Map<Domain.Entities.RatingType>(ratingType));
            return Redirect("/RatingType/Index");
        }

        public ActionResult Delete(string id)
        {
            int ratingTypeId = Convert.ToInt32(id);
            _ratingTypeRepository.Delete(ratingTypeId);
            return Redirect("/RatingType/Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RatingTypeModel ratingType)
        {
            _ratingTypeRepository.Create(Mapper.Map<Domain.Entities.RatingType>(ratingType));
            return Redirect("/RatingType/Index");
        }
    }
}