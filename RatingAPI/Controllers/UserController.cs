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

namespace RatingAPI.Controllers
{
    public class UserController : ApiController
    {
        private IProjectUserRepository _projectUserRepository;
        private IActionTypeRepository _actionTypeRepository;
        //private IActionRepository _actionRepository;
        private IRatingTypeRepository _ratingTypeRepository;
        private IRatingRepository _ratingRepository;

        public UserController(IProjectUserRepository projectUserRepository, IRatingTypeRepository ratingTypeRepository,
                              IRatingRepository ratingRepository, IActionTypeRepository actionTypeReposotory)//, IActionRepository actionRepository)
        {
            _projectUserRepository = projectUserRepository;
            _actionTypeRepository = actionTypeReposotory;
            // _actionRepository = actionRepository;
            _ratingTypeRepository = ratingTypeRepository;
            _ratingRepository = ratingRepository;
        }
        // GET: User
        [HttpPost]
        public void Create(ApiAction apiAction)
        {
            int ratingTypeId = _ratingTypeRepository.GetRatingTypeIdByName(apiAction.ratingTypeName);
            
            Domain.Entities.Rating rating = GetRating(apiAction,ratingTypeId);
            rating.Score += _actionTypeRepository.GetActionTypeScoresByName(apiAction.actionTypeName);
            _ratingRepository.Update(rating);

            // TODO: save action..
        }

        private Domain.Entities.Rating GetRating(ApiAction apiAction, int ratingTypeId)
        {
            var projectUser = GetUser(apiAction);

            Domain.Entities.Rating rating = _ratingRepository.GetRating(ratingTypeId, projectUser.Id);

            if (rating == null)
            {
                var newRating = new Domain.Entities.Rating() { RatingTypeId = ratingTypeId, ProjectUserId = projectUser.Id };
                rating = _ratingRepository.Create(newRating);
            }
            return rating;
        }

        private Domain.Entities.ProjectUser GetUser(ApiAction apiAction)
        {
            var projectUser = _projectUserRepository.GetProjectUserByName(apiAction.projectUserName);
            if (projectUser == null)
            {
                var newProjectUser = new Domain.Entities.ProjectUser() { Name = apiAction.projectUserName, ProjectId = apiAction.projectId };
                projectUser = _projectUserRepository.Create(newProjectUser);
            }
            return projectUser;
        }

    }
}
