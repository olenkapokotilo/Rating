using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rating.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static RoleModel FromDomainModel(Domain.Entities.Role domainRole)
        {
            return Mapper.Map<RoleModel>(domainRole);
        }

        public Domain.Entities.Role ToDomainModel()
        {
            return Mapper.Map<Domain.Entities.Role>(this);
        }
    }
}