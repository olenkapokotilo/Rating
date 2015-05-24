using Domain.Entities;
using Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ActionService
    {
        private IProjectUserRepository _projectUserRepository;
        private IActionTypeRepository _actionTypeRepository;
        //private IActionRepository _actionRepository;
        private IRatingTypeRepository _ratingTypeRepository;
        private IRatingRepository _ratingRepository;

        public ActionService(IProjectUserRepository projectUserRepository, IRatingTypeRepository ratingTypeRepository,
                              IRatingRepository ratingRepository, IActionTypeRepository actionTypeReposotory)//, IActionRepository actionRepository)
        {
            _projectUserRepository = projectUserRepository;
            _actionTypeRepository = actionTypeReposotory;
            // _actionRepository = actionRepository;
            _ratingTypeRepository = ratingTypeRepository;
            _ratingRepository = ratingRepository;
        }

        public void Create(Action action)
        {
            Rating rating = GetRating(action);
            rating.Score += _actionTypeRepository.GetActionType(action.ActionTypeId).Scores;
            _ratingRepository.Update(rating);
            // TODO: save action..
        }

        private Rating GetRating(Action action)
        {
            var projectUser = GetUser(action);
            var actionType = _actionTypeRepository.GetActionType(action.ActionTypeId);

            Rating rating = _ratingRepository.GetRating(actionType.RatingTypeId, projectUser.Id);

            if (rating == null)
            {
                var newRating = new Rating() { RatingTypeId = actionType.RatingTypeId, ProjectUserId = projectUser.Id };
                rating = _ratingRepository.Create(newRating);
            }
            return rating;
        }

        private ProjectUser GetUser(Action action)
        {
            var projectUser = _projectUserRepository.GetProjectUser(action.ProjectId);
            if (projectUser == null)
            {
                var newProjectUser = new ProjectUser() { Id = action.ProjectUserId, ProjectId = action.ProjectId };
                projectUser = _projectUserRepository.Create(newProjectUser);
            }
            return projectUser;
        }
    }
}
