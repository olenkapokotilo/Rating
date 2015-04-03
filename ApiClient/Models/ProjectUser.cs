using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiClient.Models
{
    public class ProjectUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProjectId { get; set; }
    }
}