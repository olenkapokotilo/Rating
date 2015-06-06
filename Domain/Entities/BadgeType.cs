using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BadgeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Scores { get; set; }
        public int RatingTypeId { get; set; }
        public int FileId { get; set; }

        public  RatingType RatingType { get; set; }
        public  File File { get; set; }
    }
}
