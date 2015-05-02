using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public string UserId { get; set; }
       
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}