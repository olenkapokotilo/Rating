using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatingAPI.Models
{
    public class ApiAction
    {
        public int ProjectId { get; set; }//ip-token
        public int ProjectUserId { get; set; }
        public string RatingTypeName { get; set; }
        public string ActionTypeName { get; set; }
    }
}