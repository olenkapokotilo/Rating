using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public class ApiAction
    {
        public int ProjectId { get; set; }//ip-token
        public string ProjectUserExternalId { get; set; }
        public string RatingTypeName { get; set; }
        public string ActionTypeName { get; set; }
    }
}