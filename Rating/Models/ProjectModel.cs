using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rating.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }

        public static ProjectModel FromDomainModel(Domain.Entities.Project domainProject)
        {
            return Mapper.Map<ProjectModel>(domainProject);
        }

        public Domain.Entities.Project ToDomainModel()
        {
            return Mapper.Map<Domain.Entities.Project>(this);
        }
        public void Foo() { }

    }
}