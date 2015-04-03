using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Action
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int ActioTypeId { get; set; }
        public int ProjectUserId { get; set; }
        public int? RatingId { get; set; }
    }
}
