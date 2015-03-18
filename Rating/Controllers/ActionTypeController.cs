using Domain.Repositories.Interfaces;
using Rating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace Rating.Controllers
{
    public class ActionTypeController : Controller
    {
        private IActionTypeRepository _actionTypeRepository;
         public ActionTypeController(IActionTypeRepository actionTypeRepository)
        {
            _actionTypeRepository = actionTypeRepository;
        }
        // GET: ActionType

        public ActionResult Delete(string id) 
        {
            int actionTypeId = Convert.ToInt32(id);
            _actionTypeRepository.Delete(actionTypeId);
            return Redirect("~/RatingType/Edit/" + RouteData.Values["ratingTypeId"].ToString());
        }
        public ActionResult Create(int ratingTypeId) 
        {
            return View(ratingTypeId);
        }
        [HttpPost]
        public ActionResult Create(Rating.Models.ActionTypeModel actionType) 
        {
                _actionTypeRepository.Create(actionType.ToDomainModel());
                return Redirect("~/RatingType/Edit/" + actionType.RatingTypeId.ToString());
        }
        public ActionResult Edit(string id)
        {
            var actionTypeId = Convert.ToInt32(id);
            return View(ActionTypeModel.FromDomainModel(_actionTypeRepository.GetActionType(actionTypeId)));
        }
        [HttpPost]
        public ActionResult Edit(ActionTypeModel actionType) 
        {
                _actionTypeRepository.Edit(actionType.ToDomainModel());
                return Redirect("~/RatingType/Edit/" + actionType.RatingTypeId.ToString());
        }
        
    }
}