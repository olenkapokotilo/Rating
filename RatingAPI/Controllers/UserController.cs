using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Repositories.Interfaces;
using DataAccess.Model;
using RatingAPI.Models;
using Newtonsoft.Json;
using AutoMapper;
using System.Web.Http;
using Domain.Services;

namespace RatingAPI.Controllers
{
    public class UserController : ApiController
    {
        private ActionService _actionService;

        private IProjectUserRepository _projectUserRepository;
        private IActionTypeRepository _actionTypeRepository;
        //private IActionRepository _actionRepository;
        private IRatingTypeRepository _ratingTypeRepository;
        private IRatingRepository _ratingRepository;

        public UserController(ActionService actionService, IProjectUserRepository projectUserRepository, IRatingTypeRepository ratingTypeRepository,
                              IRatingRepository ratingRepository, IActionTypeRepository actionTypeReposotory)//, IActionRepository actionRepository)
        {
            _projectUserRepository = projectUserRepository;
            _actionTypeRepository = actionTypeReposotory;
            // _actionRepository = actionRepository;
            _ratingTypeRepository = ratingTypeRepository;
            _ratingRepository = ratingRepository;
            _actionService = actionService;
        }
        // GET: User
        [HttpPost]
        public void Create(ApiAction apiAction)
        {
            var action = ConvertToDomain(apiAction);
            _actionService.Create(action);
        }

        private Domain.Entities.Action ConvertToDomain(ApiAction apiAction)
        {
           var ratingType = _ratingTypeRepository.GetRatingTypeByNameAndProjectId(apiAction.RatingTypeName, apiAction.ProjectId);
           var actionType = _actionTypeRepository.GetActionTypeByNameAndRatingTypeId(apiAction.ActionTypeName, ratingType.Id);
          // var projectUser =  _projectUserRepository.GetProjectUserByExternalId(apiAction.ProjectUserExternalId);

           return new Domain.Entities.Action()
           {
               DateTime = DateTime.Now,
               ActionTypeId = actionType.Id,
               ProjectId = apiAction.ProjectId,
               ExternalId = apiAction.ProjectUserExternalId
           };
        }

    }
}
