using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Repositories.Interfaces;
using DataAccess.Model;
using System.Data.Entity;

namespace DataAccess.Repositories
{
    public class ActionTypeRepository : IActionTypeRepository
    {
        public IEnumerable<Domain.Entities.ActionType> GetAllActionType()
        {
            using (var entities = new Entities())
            {
                var dbActionType = entities.ActionType.ToList();
                var result = Mapper.Map<IEnumerable<Domain.Entities.ActionType>>(dbActionType);
                return result;
            }
        }
        public IEnumerable<Domain.Entities.ActionType> GetAllActionTypeByRatingType(int id)
        {
            using (var entities = new Entities())
            {
                var dbActionType = entities.ActionType.Where(at => at.RatingTypeId == id);
                var result = Mapper.Map<IEnumerable<Domain.Entities.ActionType>>(dbActionType);
                return result;
            }
        }
        public Domain.Entities.ActionType GetActionTypeByNameAndRatingTypeId(string name, int ratingTypeId)
        {
            using (var entities = new Entities())
            {
                var dbActionType = entities.ActionType.SingleOrDefault(at =>at.RatingTypeId == ratingTypeId && at.Name == name);
                var result = Mapper.Map<Domain.Entities.ActionType>(dbActionType);
                return result;
            }
        }
        public Domain.Entities.ActionType GetActionType(int id)
        {
            using (var entities = new Entities())
            {
                var actionType = entities.ActionType.SingleOrDefault(at => at.Id == id);
                var result = Mapper.Map<Domain.Entities.ActionType>(actionType);
                return result;
            }
        }
        public void Create(Domain.Entities.ActionType actionType)
        {
            using (var entities = new Entities())
            {
                entities.ActionType.Add(Mapper.Map<DataAccess.Model.ActionType>(actionType));
                entities.SaveChanges();
            }
        }
        public void Delete(int id) 
        {
            using (var entities = new Entities()) 
            {
                var actionType = this.GetActionType(id);
                entities.Entry(Mapper.Map<DataAccess.Model.ActionType>(actionType)).State = EntityState.Deleted;
                entities.SaveChanges();
            }
        }
        public void Edit(Domain.Entities.ActionType newActionType) 
        {
            using (var entities = new Entities()) 
            {
                var actionType = this.GetActionType(newActionType.Id);
                actionType.Name = newActionType.Name;
                actionType.Scores = newActionType.Scores;
                actionType.RatingTypeId = newActionType.RatingTypeId;
                entities.Entry(Mapper.Map<DataAccess.Model.ActionType>(actionType)).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }
    }
}