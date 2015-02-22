using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rating.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserModel User { get; set; }

    }
}