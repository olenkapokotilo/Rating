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

        public ActionResult Delete(int id) 
        {
            _actionTypeRepository.Delete(id);
            return Redirect("~/RatingType/Edit/" + RouteData.Values["ratingTypeId"].ToString());
        }
        public ActionResult Create(int ratingTypeId) 
        {
            return View(ratingTypeId);
        }
        [HttpPost]
        public ActionResult Create(Rating.Models.ActionTypeModel actionType) 
        {
            try
            {
                _actionTypeRepository.Create(actionType.ToDomainModel());
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                return Redirect("/Share/Error?message" + e);
            }
                return Redirect("~/RatingType/Edit/" + actionType.RatingTypeId.ToString());
        }
        public ActionResult Edit(int id)
        {
            return View(ActionTypeModel.FromDomainModel(_actionTypeRepository.GetActionType(id)));
        }
        [HttpPost]
        public ActionResult Edit(ActionTypeModel actionType) 
        {
             try
             {
                _actionTypeRepository.Edit(actionType.ToDomainModel());
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                return Redirect("/Share/Error?message" + e);
            }
             return Redirect("~/RatingType/Edit/" + actionType.RatingTypeId.ToString());
        }
        
    }
}