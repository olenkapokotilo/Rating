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
            return Redirect("/ActionType/List");
        }
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Rating.Models.ActionTypeModel actionType) 
        {
            var at = ActionTypeModel.FromDomainModel(_actionTypeRepository.GetActionType(actionType.Id));
            if(at == null)
            {
                _actionTypeRepository.Create(actionType.ToDomainModel());
                return Redirect("/ActionType/List");
            }
            else 
            {
                throw new InvalidOperationException("ActionType already exists!");
            }
        }
        public ActionResult Edit(int id) 
        {
            return View(ActionTypeModel.FromDomainModel(_actionTypeRepository.GetActionType(id)));
        }
        [HttpPost]
        public ActionResult Edit(ActionTypeModel actionType) 
        {
            _actionTypeRepository.Edit(Mapper.Map<Domain.Entities.ActionType>(actionType));
            return Redirect("/Actiontype/List");
        }
        
    }
}