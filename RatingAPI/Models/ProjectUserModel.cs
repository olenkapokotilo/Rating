using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatingAPI.Models
{
    public class ProjectUserModel
    {
        public ProjectUserModel(string name, int projectId) 
        {
            this.Name = name;
            this.ProjectId = projectId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProjectId { get; set; }
        public static ProjectUserModel FromDomainModel(Domain.Entities.ProjectUser domainProjectUser)
        {
            return Mapper.Map<ProjectUserModel>(domainProjectUser);
        }

        public Domain.Entities.ProjectUser ToDomainModel()
        {
            return Mapper.Map<Domain.Entities.ProjectUser>(this);
        }
    }
}