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
        public ActionResult Index()
        {
            return PartialView(_actionTypeRepository.GetAllActionType().Select(at=> ActionTypeModel.FromDomainModel(at)));
        }
        public ActionResult Delete(string id) 
        {
            int actionTypeId = Convert.ToInt32(id);
            _actionTypeRepository.Delete(actionTypeId);
            return Redirect("/ActionType/Index");
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
                _actionTypeRepository.Create(Mapper.Map<Domain.Entities.ActionType>(actionType));
                return Redirect("/ActionType/Index");
            }
            else 
            {
                throw new InvalidOperationException("ActionType already exists!");
            }
        }
        
    }
}