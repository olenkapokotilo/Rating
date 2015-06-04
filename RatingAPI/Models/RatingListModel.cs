using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatingAPI.Models
{
    public class RatingListModel
    {
        public string ExternalUserId { get; set; }
        public int Scores { get; set; }
    }
}