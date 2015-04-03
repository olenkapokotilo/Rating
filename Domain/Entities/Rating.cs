using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int RatingTypeId { get; set; }
        public int? ProjectUserId { get; set; }
    }
}
