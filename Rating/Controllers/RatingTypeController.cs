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
        public ActionResult Edit(int id)
        {
            return View(RatingTypeModel.FromDomainModel(_ratingTypeRepository.GetRatingType(id)));
        }

        [HttpPost]
        public ActionResult Edit(Rating.Models.RatingTypeModel ratingType)
        {
            try
            {
                _ratingTypeRepository.Edit((ratingType).ToDomainModel());
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                return Redirect("/Share/Error?message" + e);
            }
                return Redirect("~/Project/Edit/"+ ratingType.ProjectId.ToString());
        }

        public ActionResult Delete(int id)
        {
            _ratingTypeRepository.Delete(id);
            return Redirect("~/Project/Edit/" + RouteData.Values["projectId"].ToString());
        }

        public ActionResult Create(int id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult Create(RatingTypeModel ratingType)
        {
            try
            {
                _ratingTypeRepository.Create(Mapper.Map<Domain.Entities.RatingType>(ratingType));
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                return Redirect("/Share/Error?message" + e);
            }
                return Redirect("~/Project/Edit/" + ratingType.ProjectId.ToString());
        }
    }
}