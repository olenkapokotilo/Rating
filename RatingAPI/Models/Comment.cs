using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatingAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public string UserId { get; set; }
    }
}