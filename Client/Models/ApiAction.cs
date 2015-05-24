using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public class ApiAction
    {
        public int projectId { get; set; }//ip-token
        public string projectUserName { get; set; }
        public string ratingTypeName { get; set; }
        public string actionTypeName { get; set; }
    }
}