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
        public void Create(ApiAction apiAction) //?Create(obj jsonApiAction)
        {
            //JsonConvert.DeserializeObject(jsonApiAction); //?
            ProjectUserModel projectUser = ProjectUserModel.FromDomainModel(_projectUserRepository.GetProjectUserByName(apiAction.projectUserName));
           
            if (projectUser != null)//_projectUserRepository.ExistProjectUser(projectUser.Id)) 
            {
                int idRatingType = _ratingTypeRepository.GetRatingTypeIdByName(apiAction.ratingTypeName);
                RatingModel rating = RatingModel.FromDomainModel(_ratingRepository.GetRating(idRatingType, projectUser.Id));
                if(rating != null)
                {
                    rating.Score += _actionTypeRepository.GetActionTypeScoresByName(apiAction.actionTypeName);
                    
                    
                }else
                { //?
                    try
                    {
                        int score = _actionTypeRepository.GetActionTypeScoresByName(apiAction.actionTypeName);
                        RatingModel newRating = new RatingModel(apiAction.ratingTypeName, score, idRatingType, projectUser.Id);
                        _ratingRepository.Create(Mapper.Map<Domain.Entities.Rating>(newRating));
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                    {
                        //throw new
                    }
                }

            }
            else {
                try
                {
                    ProjectUserModel newProjectUser = new ProjectUserModel(apiAction.projectUserName, apiAction.projectId);
                    _projectUserRepository.Create(Mapper.Map<Domain.Entities.ProjectUser>(newProjectUser));
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                {
                    //throw new
                }
            }
        }
    }
}