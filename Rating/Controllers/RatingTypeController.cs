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
        public ActionResult Edit(string id)
        {
            int ratingTypeId = Convert.ToInt32(id);
            return PartialView(RatingTypeModel.FromDomainModel(_ratingTypeRepository.GetRatingType(ratingTypeId)));
        }

        [HttpPost]
        public ActionResult Edit(Rating.Models.RatingTypeModel ratingType)
        {
             var at = RatingTypeModel.FromDomainModel(_ratingTypeRepository.GetRatingType(ratingType.Id));
            if (at == null)
            {
                _ratingTypeRepository.Edit((ratingType).ToDomainModel());
                return Redirect("~/Project/Edit/"+ ratingType.ProjectId.ToString());
            }
            else
            {
                throw new InvalidOperationException("This rating type exsist already!!!");
            }
        }

        public ActionResult Delete(string id)
        {
            int ratingTypeId = Convert.ToInt32(id);
            _ratingTypeRepository.Delete(ratingTypeId);
            return Redirect("~/Project/Edit/" + RouteData.Values["projectId"].ToString());
        }

        public ActionResult Create(int id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult Create(RatingTypeModel ratingType)
        {
                _ratingTypeRepository.Create(Mapper.Map<Domain.Entities.RatingType>(ratingType));
                return Redirect("~/Project/Edit/" + ratingType.ProjectId.ToString());
        }
    }
}