using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rating.Models
{
    public class BadgeTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Scores { get; set; }
        public int RatingTypeId { get; set; }
        public int FileId { get; set; }
        //public virtual RatingType RatingType { get; set; }
        public  FileModel File { get; set; }
    }
}