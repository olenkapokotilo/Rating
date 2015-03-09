using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

namespace Rating.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public IEnumerable<ProjectModel> Projects { get; set; }

        public static UserModel FromDomainModel(Domain.Entities.User domainUser)
        {
            return Mapper.Map<UserModel>(domainUser);
        }

        public Domain.Entities.User ToDomainModel()
        {
            return Mapper.Map<Domain.Entities.User>(this);
        }
    }
}