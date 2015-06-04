using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Services
{
    public class RatingListModel
    {
        public string ExternalUserId { get; set; }
        public int Scores { get; set; }
        public ApplicationUser User { get; set; }
    }
}